using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ProductCate : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["AdminLogined"] != null)
        {
            //edtnoidung.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
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
        var getData = from tb in db.tbProductCates
                      orderby tb.productcate_id descending
                      where tb.productcate_parent !=0
                      select new
                      {
                        //  productcate_parent = (from p in db.tbProductCates where p.productcate_id == tb.productcate_parent select p).SingleOrDefault().productcate_title,
                          tb.productcate_id,
                          tb.productcate_position,
                          tb.productcate_show,
                          tb.productcate_title,
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
        //ddlNhomSanPham.DataSource = from n in db.tbProductCates where n.productcate_parent == 0 select n;
        //ddlNhomSanPham.DataBind();
    }
    private void setNULL()
    {
        //edtnoidung.Html = "";
        //txtViTri.Text = "";
        txtloaisanpham.Text = "";
        SEO_KEYWORD.Text = "";
        SEO_TITLE.Text = "";
        SEO_LINK.Text = "";
        SEO_DEP.Value = "";
       // SEO_IMAGE.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Session["_id"] = 0;
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "productcate_id" }));
        Session["_id"] = _id;
        var getData = (from tb in db.tbProductCates
                       where tb.productcate_id == _id
                       select new { 
                        tb.productcate_title,
                        tb.productcate_id,
                        tb.productcate_position,
                        tb.link_seo,
                        tb.productcate_show,
                        tb.meta_keywords,
                        tb.meta_title,
                        tb.meta_description,
                        tb.meta_image,
                        tb.productcate_content,
                        parent = (from p in db.tbProductCates where p.productcate_id == tb.productcate_parent select p).SingleOrDefault().productcate_title
                       }).Single();
        //ddlNhomSanPham.Text = getData.parent;
        txtloaisanpham.Text = getData.productcate_title;
        //ddltinhtrang.Text = getData.productcate_show == true ? "Hiển thị" : "Không hiển thị";
        //txtViTri.Text = getData.productcate_position + "";
        SEO_KEYWORD.Text = getData.meta_keywords;
        SEO_TITLE.Text = getData.meta_title;
        SEO_LINK.Text = getData.link_seo;
        SEO_DEP.Value = getData.meta_description;
        //SEO_IMAGE.Text = getData.meta_image;
        //edtnoidung.Html = getData.productcate_content;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_ProductCate cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "productcate_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_ProductCate();
                tbProductCate checkImage = (from i in db.tbProductCates where i.productcate_id == Convert.ToInt32(item) select i).SingleOrDefault();
                if (cls.Linq_Xoa(Convert.ToInt32(item)))
                    alert.alert_Success(Page, "Xóa thành công", "");
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }

    public bool checknull()
    {
        if (txtloaisanpham.Text != "")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_ProductCate cls = new cls_ProductCate();
       // bool tinhtrang = ddltinhtrang.Text == "Hiển thị" ? true : false;
        if (checknull() == false)
            alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin!", "");
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
                //if (SEO_IMAGE.Text != "")
                //{
                //    ImageSeo = SEO_IMAGE.Text;
                //}
            }
            if (Session["_id"].ToString() == "0")
            {
                if (cls.Linq_Them(txtloaisanpham.Text,1, KEYWORD, TitleSeo, Link, Dep, ImageSeo))
                    alert.alert_Success(Page, "Thêm thành công", "");
                else alert.alert_Error(Page, "Thêm thất bại", "");
            }
            else
            {
                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtloaisanpham.Text,1, KEYWORD, TitleSeo, Link, Dep, ImageSeo))
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }
        }
    }
    //protected void btnAn_Click(object sender, EventArgs e)
    //{
    //    cls_ProductCate cls;
    //    List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "productcate_id" });
    //    if (selectedKey.Count > 0)
    //    {
    //        foreach (var item in selectedKey)
    //        {
    //            cls = new cls_ProductCate();
    //            if (cls.Linq_An(Convert.ToInt32(item)))
    //                alert.alert_Success(Page, "Đã ẩn trên web", "");
    //            else
    //                alert.alert_Error(Page, "Ẩn thất bại", "");
    //        }
    //    }
    //    else
    //        alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    //}
    //protected void btnHienThi_Click(object sender, EventArgs e)
    //{
    //    cls_ProductCate cls;
    //    List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "productcate_id" });
    //    if (selectedKey.Count > 0)
    //    {
    //        foreach (var item in selectedKey)
    //        {
    //            cls = new cls_ProductCate();
    //            if (cls.Linq_HienThi(Convert.ToInt32(item)))
    //                alert.alert_Success(Page, "Đã là sản phẩm tiêu biểu", "");
    //            else
    //                alert.alert_Error(Page, "Hiển thị thất bại", "");
    //        }
    //    }
    //    else
    //        alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    //}
}