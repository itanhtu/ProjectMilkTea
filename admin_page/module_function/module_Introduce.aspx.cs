using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_Introduce : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    public string image;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Kiểm trả session login nếu khác null thì vào form xử lý
        //edtnoidung.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
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
        var getData = from nc in db.tbIntroduces
                      select nc;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    //private void setNULL()
    //{
    //    txtTitle.Text = "";
    //    txtTitle1.Text = "";
    //    edtnoidung.Html = "";
    //}
    //protected void btnThem_Click(object sender, EventArgs e)
    //{
    //    // Khi nhấn nút thêm thì mật định session id = 0 để thêm mới
    //    Session["_id"] = 0;
    //    // gọi hàm setNull để trả toàn bộ các control về rỗng
    //    setNULL();
    //    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    //    loadData();
    //}
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        // get value từ việc click vào gridview
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "introduct_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbIntroduces
                       where nc.introduct_id == _id
                       select nc).Single();
        txtTitle.Text = getData.introduce_title;
        txtTitle1.Text = getData.introduce_title1;
        txtSummary.Value = getData.introduce_summary;
        edtnoidung.Html = getData.introduce_content;
        SEO_KEYWORD.Text = getData.seo_keyworld;
        SEO_TITLE.Text = getData.seo_title;
        SEO_LINK.Text = getData.seo_link;
        SEO_DEP.Value = getData.seo_description;
        SEO_IMAGE.Text = getData.seo_image;
        image = getData.introduce_image;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + getData.introduce_image + "'); ", true);
        loadData();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {

        cls_Introduce cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "introduct_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_Introduce();

                if (cls.Linq_Xoa(Convert.ToInt32(item)))
                {
                    alert.alert_Success(Page, "Xóa thành công", "");
                }
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }
    public bool checknull()
    {
        if (txtTitle.Text != "" || edtnoidung.Html != "")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_Introduce cls = new cls_Introduce();
        if (Page.IsValid && FileUpload1.HasFile)
        {
            string filename = (FileUpload1.FileName);
            string fileName_save = Path.Combine(Server.MapPath("~/uploadimages"), filename);
            FileUpload1.SaveAs(fileName_save);
            image = "/uploadimages/" + filename;
        }
        if (checknull() == false)
            alert.alert_Warning(Page, "Hãy nhập đầy đủ thông tin!", "");
        else
        {
            string KEYWORD = "", TitleSeo = "", Link = "", Dep = "", ImageSeo = "";
            {
                if (SEO_KEYWORD.Text != "")
                {
                    KEYWORD = SEO_KEYWORD.Text;
                }
                if (SEO_TITLE.Text != "")
                {
                    TitleSeo = SEO_TITLE.Text;
                }
                if (SEO_LINK.Text != "")
                {
                    Link = SEO_LINK.Text;
                }
                if (SEO_DEP.Value != "")
                {
                    Dep = SEO_DEP.Value;
                }
                if (SEO_IMAGE.Text != "")
                {
                    ImageSeo = SEO_IMAGE.Text;
                }
            }
            if (Session["_id"].ToString() == "0")
            {
                if (cls.Linq_Them(txtTitle.Text, txtTitle1.Text, txtSummary.Value, edtnoidung.Html, image))
                {
                    alert.alert_Success(Page, "Thêm thành công", "");
                    loadData();
                }
                else alert.alert_Error(Page, "Thêm thất bại", "");
            }
            else
            {

                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtTitle.Text, txtTitle1.Text, txtSummary.Value, edtnoidung.Html, image, KEYWORD, TitleSeo, Link, Dep, ImageSeo))
                {
                    //alert.alert_Success(Page, "Cập nhật thành công", "");
                    ScriptManager.RegisterClientScriptBlock(Page,this.GetType(),"Alert", "swal('Cập nhật thành công','','success').then(function(){grvList.Refresh();})",true);
                    popupControl.ShowOnPageLoad = false;
                    loadData();
                }
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }
        }
        //loadData();
        //popupControl.ShowOnPageLoad = false;
    }
    //public void delete(string sFileName)
    //{
    //    if (sFileName != String.Empty)
    //    {
    //        if (File.Exists(sFileName))

    //            File.Delete(sFileName);
    //    }
    //}
}