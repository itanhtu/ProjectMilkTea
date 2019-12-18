using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_New : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    string image;
    protected void Page_Load(object sender, EventArgs e)
    {
        edtnoidung.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
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
        var getData = from n in db.tbNews
                      join tb in db.tbNewCates on n.newcate_id equals tb.newcate_id
                      orderby n.news_id descending
                      select new {
                          n.news_id,
                          n.news_title,
                          n.news_summary,
                          n.news_image,
                          active = n.active == true ? "Đã hiển thị":"Chưa hiển thị",
                          n.news_datetime
                      };
        grvList.DataSource = getData;
        grvList.DataBind();

    }
    private void setNULL()
    {
        txttitle.Text = "";
        edtnoidung.Html = "";
        txtsummary.Text = "";
        SEO_KEYWORD.Text = "";
        SEO_TITLE.Text = "";
        SEO_LINK.Text = "";
        SEO_DEP.Value = "";
        SEO_IMAGE.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Session["_id"] = null;
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();showImg('');", true);
        loadData();
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "news_id" }));
        Session["_id"] = _id;
        var getData = (from n in db.tbNews
                       join tb in db.tbNewCates on n.newcate_id equals tb.newcate_id
                       where n.news_id == _id
                       select n).Single();
        txttitle.Text = getData.news_title;
        edtnoidung.Html = getData.news_content;
        txtsummary.Text = getData.news_summary;
        SEO_KEYWORD.Text = getData.meta_keywords;
        SEO_TITLE.Text = getData.meta_title;
        SEO_LINK.Text = getData.link_seo;
        SEO_DEP.Value = getData.meta_description;
        SEO_IMAGE.Text = getData.seo_image;
        if (getData.news_image == null || getData.news_image == "")
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + "/admin_images/Preview-icon.png" + "'); ", true);
        else
            //image = getData.news_image;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + getData.news_image + "'); ", true);
        loadData();
        //loadData();
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_News cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "news_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_News();
                tbNew checkImage = (from i in db.tbNews where i.news_id == Convert.ToInt32(item) select i).SingleOrDefault();
                string pathToFiles = Server.MapPath(checkImage.news_image);
                delete(pathToFiles);
                if (cls.Linq_Xoa(Convert.ToInt32(item)))
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
    public bool checknull()
    {
        if (txttitle.Text != "" && edtnoidung.Html != "" &&  txtsummary.Text!="")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            if (Page.IsValid && FileUpload1.HasFile)
            {
                string filename = Path.GetRandomFileName() + Path.GetExtension(FileUpload1.FileName);
                string fileName_save = Path.Combine(Server.MapPath("~/uploadimages"), filename);
                FileUpload1.SaveAs(fileName_save);
                image = "/uploadimages/" + filename;
                //string filename = (FileUpload1.FileName);
                //string fileName_save = Path.Combine(Server.MapPath("~/uploadimages"), filename);
                //FileUpload1.SaveAs(fileName_save);
                //image = "/uploadimages/" + filename;
            }
            admin_User logedMember = Session["AdminLogined"] as admin_User;

            cls_News cls = new cls_News();
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
                if (Session["_id"] == null)
                {
                    if (cls.Linq_Them(txttitle.Text, txtsummary.Text, image, edtnoidung.Html, KEYWORD, TitleSeo, Link, Dep, ImageSeo))
                    {
                        alert.alert_Success(Page, "Thêm thành công", "");
                        popupControl.ShowOnPageLoad = false;
                        loadData();
                    }
                    else alert.alert_Error(Page, "Thêm thất bại", "");
                }
                else
                {
                    if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txttitle.Text, txtsummary.Text, image, edtnoidung.Html, KEYWORD, TitleSeo, Link, Dep, ImageSeo))
                    {
                        alert.alert_Success(Page, "Cập nhật thành công", "");
                        popupControl.ShowOnPageLoad = false;
                        loadData();
                    }
                    else alert.alert_Error(Page, "Cập nhật thất bại", "");
                }
            }
            loadData();
        }
        //popupControl.ShowOnPageLoad = false;
    }
    public void delete(string sFileName)
    {
        if (sFileName != String.Empty)
        {
            if (File.Exists(sFileName))

                File.Delete(sFileName);
        }
    }

    protected void btnHienThi_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "news_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getnews = (from n in db.tbNews where n.news_id == Convert.ToInt32(item) select n).SingleOrDefault();
                if (getnews != null)
                {
                    getnews.active = true;
                    getnews.news_datetime = DateTime.Now;
                    db.SubmitChanges();
                    alert.alert_Success(Page, "Hiển thị thành công!", "");
                }
                else
                {
                    alert.alert_Error(Page, "Hiển thị thất bại!", "");
                }
            }
        }
    }

    protected void btnShowhiden_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "news_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getdata = (from intr in db.tbNews where intr.news_id == Convert.ToInt32(item) select intr).SingleOrDefault();
                if (getdata != null)
                {
                    getdata.active = false;
                    getdata.news_datetime = DateTime.Now;
                    db.SubmitChanges();
                    alert.alert_Success(Page, "Ẩn thành công!", "");
                }
                else
                {
                    alert.alert_Error(Page, "Ẩn thất bại!", "");
                }
            }
        }
    }
}