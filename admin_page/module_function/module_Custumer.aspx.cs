using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_Custumer : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
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
        // nếu session = null thì trả về trang login
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void loadData()
    {
        var getData = from ct in db.tbCustomerFeedbacks
                      orderby ct.customer_id descending
                      select ct;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "customer_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbCustomerFeedbacks
                       where nc.customer_id == _id
                       select nc).Single();
        txtTenKH.Text = getData.customer_name;
        edtnoidung.Html = getData.customer_content;
        if (getData.customer_image == null || getData.customer_image == "")
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + "/admin_images/Preview-icon.png" + "'); ", true);
        else
            //image = getData.news_image;
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + getData.customer_image + "'); ", true);
        loadData();
    }
    private void setNULL()
    {
        txtTenKH.Text = "";
        edtnoidung.Html = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        // Khi nhấn nút thêm thì mật định session id = 0 để thêm mới
        Session["_id"] = 0;
        // gọi hàm setNull để trả toàn bộ các control về rỗng
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
        loadData();
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_Customer cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "customer_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_Customer();

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
        if (txtTenKH.Text != "" && edtnoidung.Html != "")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_Customer cls = new cls_Customer();
        if (Page.IsValid && FileUpload1.HasFile)
        {
            string filename = Path.GetRandomFileName() + Path.GetExtension(FileUpload1.FileName);
            string fileName_save = Path.Combine(Server.MapPath("~/uploadimages"), filename);
            FileUpload1.SaveAs(fileName_save);
            image = "/uploadimages/" + filename;
        }
        if (checknull() == false)
            alert.alert_Warning(Page, "Nhập đầy đủ thông tin!", "");
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                if (cls.Linq_Them(txtTenKH.Text, edtnoidung.Html, image))
                {
                    alert.alert_Success(Page, "Thêm thành công", "");
                }
                else alert.alert_Error(Page, "Thêm thất bại", "");
            }
            else
            {
                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtTenKH.Text, edtnoidung.Html, image))
                {
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                   // popupControl.ShowOnPageLoad = false;
                    loadData();
                }
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }
            loadData();
            popupControl.ShowOnPageLoad = false;
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

    protected void btnShow_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "customer_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getdata = (from intr in db.tbCustomerFeedbacks where intr.customer_id == Convert.ToInt32(item) select intr).SingleOrDefault();
                if (getdata != null)
                {
                    getdata.customer_active = true;
                    getdata.customer_date = DateTime.Now;
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
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "customer_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getdata = (from intr in db.tbSlides where intr.slide_id == Convert.ToInt32(item) select intr).SingleOrDefault();
                if (getdata != null)
                {
                    getdata.hidden = false;
                    getdata.slide_date = DateTime.Now;
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