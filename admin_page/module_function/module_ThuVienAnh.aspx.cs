using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThuVienAnh : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    dbcsdlDataContext db = new dbcsdlDataContext();
    private int _id;
    string image;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;
            //if (logedMember.groupuser_id == 3)
            //    Response.Redirect("/user-home");
            if (!IsPostBack)
            {
                Session["_id"] = 0;

            }
            loadData();
        }
        else
        {
            Response.Redirect("/admin-login");
        }

    }
    private void loadData()
    {

        grvList.DataSource = from vd in db.tbCollectionImages
                             orderby vd.collection_id descending
                             select vd;
        grvList.DataBind();
    }
    private void setNULL()
    {
        txtlink.Text = "";
    }

    public void delete(string sFileName)
    {
        if (sFileName != String.Empty)
        {
            if (File.Exists(sFileName))

                File.Delete(sFileName);
        }
    }
    public bool checknull()
    {
        if (txtlink.Text != "")
            return true;
        else return false;
    }


    protected void btnThemImg_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin-them-anh");
    }

    protected void btnThemVideo_Click(object sender, EventArgs e)
    {
        Session["_id"] = "0";
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();showImg('');", true);
        loadData();
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "collection_id" }));
        Session["_id"] = _id;
        var getData = (from n in db.tbCollectionImages
                       where n.collection_id == _id
                       select n).Single();
        txtlink.Text = getData.collection_youtube;
        if (getData.collection_avatar == "" || getData.collection_avatar == null)
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + "/admin_images/Preview-icon.png" + "'); ", true);
        else
            image = getData.collection_avatar;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + getData.collection_avatar + "'); ", true);
        loadData();
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        ctl_newbuilding cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "collection_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new ctl_newbuilding();
                tbCollectionImage checkImage = (from i in db.tbCollectionImages where i.collection_id == Convert.ToInt32(item) select i).SingleOrDefault();
                if (cls.Linq_xoa(Convert.ToInt32(item)))
                {
                    alert.alert_Success(Page, "Xóa thành công", "");
                    loadData();
                }
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            if (Page.IsValid && FileUpload1.HasFile)
            {
                string filename = Path.GetRandomFileName() + Path.GetExtension(FileUpload1.FileName);
                string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/thuvienanh"), filename);
                FileUpload1.SaveAs(fileName_save);
                image = "/uploadimages/thuvienanh/" + filename;
            }
            admin_User logedMember = Session["AdminLogined"] as admin_User;

            ctl_newbuilding cls = new ctl_newbuilding();
            cls_ThemVideo clss = new cls_ThemVideo();
            {
                if (Session["_id"].ToString() == "0")
                {
                    if (checknull() == false)
                        alert.alert_Warning(Page, "Hãy nhập đầy đủ thông tin!", "");
                    else
                       if (clss.Video_them(txtlink.Text, image))
                    {
                        alert.alert_Success(Page, "Thêm thành công", "");
                        setNULL();
                    }
                    else alert.alert_Error(Page, "Thêm thất bại", "");
                }
                else
                {
                    if (cls.Linq_suavideo(Convert.ToInt32(Session["_id"].ToString()), txtlink.Text, image))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){grvList.Refresh();})", true);
                        popupControl.ShowOnPageLoad = false;
                        loadData();
                    }
                    else
                    {
                        alert.alert_Error(Page, "Cập nhật thất bại", "");
                    }
                }
            }
            // loadData();
        }
        // popupControl.ShowOnPageLoad = false;
    }
}