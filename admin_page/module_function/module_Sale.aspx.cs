using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_Sale : System.Web.UI.Page
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
        var getData = from n in db.tbSales
                      join tb in db.tbSaleCates on n.salecate_id equals tb.salecate_id
                      orderby n.sale_id descending
                      select n;
        grvList.DataSource = getData;
        grvList.DataBind();

    }
    private void setNULL()
    {
        txttitle.Text = "";
        edtnoidung.Html = "";
        txtsummary.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Session["_id"] = 0;
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();showImg('');", true);
        loadData();
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "sale_id" }));
        Session["_id"] = _id;
        var getData = (from n in db.tbSales
                       join tb in db.tbSaleCates on n.salecate_id equals tb.salecate_id
                       where n.sale_id == _id
                       select n).Single();
        txttitle.Text = getData.sale_title;
        txtsummary.Text = getData.sale_summary;
        if (getData.sale_image == null)
            image = "/admin_images/up-img.png";
        else
            image = getData.sale_image;
        edtnoidung.Html = getData.sale_content;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + getData.sale_image + "'); ", true);
        loadData();
        loadData();
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_sale cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "sale_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_sale();
                tbSale checkImage = (from i in db.tbSales where i.sale_id == Convert.ToInt32(item) select i).SingleOrDefault();
                string pathToFiles = Server.MapPath(checkImage.sale_image);
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
        if (txttitle.Text != "" || edtnoidung.Html != "")
            return true;
        else return false;
    }
    protected void btnHienThi_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "sale_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getnews = (from n in db.tbSales where n.sale_id == Convert.ToInt32(item) select n).SingleOrDefault();
                if (getnews != null)
                {
                    getnews.active = true;
                    getnews.sale_datetime = DateTime.Now;
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
    public void delete(string sFileName)
    {
        if (sFileName != String.Empty)
        {
            if (File.Exists(sFileName))

                File.Delete(sFileName);
        }
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_UploadImage uploadImg = new cls_UploadImage();
        HttpFileCollection fileCollection = Request.Files;
        string fileName = uploadImg.uploadSingle(fileCollection);
        cls_sale cls = new cls_sale();
        if (checknull() == false)
            alert.alert_Warning(Page, "Hãy nhập đầy đủ thông tin!", "");
        else
        {


        }
        if (Session["_id"].ToString() == "0")
        {

            if (cls.Linq_Them(txttitle.Text, txtsummary.Text, fileName, edtnoidung.Html))
            {
                alert.alert_Success(Page, "Thêm thành công", "");
                loadData();

            }
            else alert.alert_Error(Page, "Thêm thất bại", "");

        }
        else
        {
            if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txttitle.Text, txtsummary.Text, fileName, edtnoidung.Html))
            {
                alert.alert_Success(Page, "Cập nhật thành công", "");
                loadData();
            }
            else alert.alert_Error(Page, "Cập nhật thất bại", "");
        }
        loadData();
    }
}