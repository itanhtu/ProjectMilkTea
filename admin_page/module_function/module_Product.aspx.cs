using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_Product : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    string image;
    int gia;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            // edtnoidung.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            loadData();
            admin_User logedMember = Session["AdminLogined"] as admin_User;
            if (logedMember.groupuser_id == 4)
            {
                //  loadgrvLookup();
                // dvDaiLy.Visible = true;
            }
            else
            {
                // dvDaiLy.Visible = false;
            }
        }
    }

    private void loadData()
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;
            var getData = from tb in db.tbProducts
                          join c in db.tbProductCates on tb.productcate_id equals c.productcate_id
                          orderby tb.product_show ascending, tb.product_id descending
                          select new
                          {
                              tb.product_id,
                              tb.product_title,
                              tb.product_summary,
                              tb.product_price,
                              tb.product_content,
                              tb.product_image,
                              c.productcate_title,
                              tb.product_position,
                              show = tb.product_show == true ? "Đã hiển thị" : "Chưa hiển thị"

                          };
            grvList.DataSource = getData;
            grvList.DataBind();
            ddlNhomSanPham.DataSource = from tb in db.tbProductCates
                                        where tb.productcate_parent != 0
                                        select tb;
            ddlNhomSanPham.DataBind();
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void setNULL()
    {
        ddlNhomSanPham.Text = "";
        txttensanpham.Text = "";
        txtContent.Value = "";
        //txtgia.Text = "";
        //txtgiamgia.Text = "";
        //txtgiamoi.Text = "";
        //txtPrice.Text = "";
        SEO_KEYWORD.Text = "";
        SEO_TITLE.Text = "";
        SEO_LINK.Text = "";
        SEO_DEP.Value = "";
        SEO_IMAGE.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            Session["_id"] = null;
            setNULL();
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show(); showImg1('');", true);
        }
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        //if (Session["AdminLogined"] != null)
        //{
        admin_User logedMember = Session["AdminLogined"] as admin_User;

        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "product_id" }));
        Session["_id"] = _id;
        var getData = (from tb in db.tbProducts
                       join c in db.tbProductCates on tb.productcate_id equals c.productcate_id
                       where tb.product_id == _id
                       select new
                       {
                           tb.product_id,
                           tb.product_title,
                           // tb.product_summary,
                           tb.product_price,
                           tb.product_content,
                           tb.product_image,
                           c.productcate_title,
                           tb.product_show,
                           tb.productcate_id,
                           tb.meta_keywords,
                           tb.meta_title,
                           tb.link_seo,
                           tb.meta_description,
                           tb.meta_image,
                           tb.product_position
                       }).Single();
        ddlNhomSanPham.Text = getData.productcate_title;
        txttensanpham.Text = getData.product_title;
        txtContent.Value = getData.product_content;
        // txttomtat.Text = getData.product_summary;
        SEO_KEYWORD.Text = getData.meta_keywords;
        SEO_TITLE.Text = getData.meta_title;
        SEO_LINK.Text = getData.link_seo;
        SEO_DEP.Value = getData.meta_description;
        SEO_IMAGE.Text = getData.meta_image;
        if (getData.product_image == "" || getData.product_image == null)
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show(); showImg1_1('" + "/admin_images/preview-icon.png" + "');", true);
        else
            // image = getData.product_image;
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show(); showImg1_1('" + getData.product_image + "');", true);
        loadData();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_Product cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "product_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_Product();
                tbProduct checkImage = (from i in db.tbProducts where i.product_id == Convert.ToInt32(item) select i).SingleOrDefault();
                if (cls.Product_Xoa(Convert.ToInt32(item)))
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
        if (ddlNhomSanPham.Text != "" && txttensanpham.Text != "" && txtContent.Value != "")
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
                string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/imageproduct"), filename);
                FileUpload1.SaveAs(fileName_save);
                image = "/uploadimages/imageproduct/" + filename;
            }
            admin_User logedMember = Session["AdminLogined"] as admin_User;

            cls_Product cls = new cls_Product();
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
                    if (cls.Product_Them(txttensanpham.Text, image, txtContent.Value, gia, true, true, Convert.ToInt32(ddlNhomSanPham.Value.ToString()), KEYWORD, TitleSeo, Link, Dep, ImageSeo))
                    {
                        alert.alert_Success(Page, "Thêm thành công", "");
                        popupControl.ShowOnPageLoad = false;
                        loadData();
                    }
                    else alert.alert_Error(Page, "Thêm thất bại", "");
                }
                else
                {
                    if (cls.Product_Sua(Convert.ToInt32(Session["_id"].ToString()), txttensanpham.Text, image, txtContent.Value, gia, Convert.ToInt32(ddlNhomSanPham.Value.ToString()), KEYWORD, TitleSeo, Link, Dep, ImageSeo))
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
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "product_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getsp = (from sp in db.tbProducts where sp.product_id == Convert.ToInt32(item) select sp).SingleOrDefault();
                if (getsp.product_show == true)
                {
                    alert.alert_Success(Page, "Sản phẩm đã được hiển thị!", "");
                }
                else
                {

                    if (getsp != null)
                    {
                        getsp.product_show = true;
                        getsp.product_date = DateTime.Now;
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
    }

    protected void btnAn_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "product_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getsp = (from sp in db.tbProducts where sp.product_id == Convert.ToInt32(item) select sp).SingleOrDefault();
                if (getsp.product_show == false)
                {
                    alert.alert_Success(Page, "Sản phẩm đã được ẩn!", "");
                }
                else
                {

                    if (getsp != null)
                    {
                        getsp.product_show = false;
                        getsp.product_date = DateTime.Now;
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
}