using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_SEO : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    public string image;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;
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
        var getData = from nc in db.tbSEOs
                      select nc;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        // get value từ việc click vào gridview
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "seo_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbSEOs
                       where nc.seo_id == _id
                       select nc).Single();
        SEO_KEYWORD.Text = getData.seo_keyworld;
        SEO_TITLE.Text = getData.seo_title;
        SEO_LINK.Text = getData.seo_link;
        SEO_DEP.Text = getData.seo_description;
        SEO_IMAGE.Text = getData.seo_image;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
        loadData();
    }
    public bool checknull()
    {
        if (SEO_KEYWORD.Text != "" || SEO_TITLE.Text != "" || SEO_DEP.Text != "")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;

            cls_SEO cls = new cls_SEO();
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
                    if (SEO_DEP.Text != "")
                    {
                        Dep = SEO_DEP.Text;
                    }
                    if (SEO_IMAGE.Text != "")
                    {
                        ImageSeo = SEO_IMAGE.Text;
                    }
                }
                if (Session["_id"] == null)
                {
                    if (cls.Linq_Them(TitleSeo, Dep, KEYWORD, Link, ImageSeo))
                    {
                        alert.alert_Success(Page, "Thêm thành công", "");
                        loadData();
                    }
                    else alert.alert_Error(Page, "Thêm thất bại", "");
                }
                else
                {
                    if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), TitleSeo, Dep, KEYWORD, Link, ImageSeo))
                    {
                        alert.alert_Success(Page, "Cập nhật thành công", "");
                        loadData();
                    }
                    else alert.alert_Error(Page, "Cập nhật thất bại", "");
                }
            }
            loadData();
        }
        popupControl.ShowOnPageLoad = false;
    }
}