using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_LienHe : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Kiểm trả session login nếu khác null thì vào form xử lý
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
        // load data đổ vào var danh sách
        var getData = from nc in db.tbLienHes select nc;
        // đẩy dữ liệu vào gridivew
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    private void setNULL()
    {
        txtemail.Text = "";
        txtaddress.Text = "";
        txtphone.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        // Khi nhấn nút thêm thì mật định session id = 0 để thêm mới
        Session["_id"] = 0;
        // gọi hàm setNull để trả toàn bộ các control về rỗng
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        // get value từ việc click vào gridview
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "lienhe_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbLienHes
                       where nc.lienhe_id == _id
                       select nc).Single();
        txtemail.Text = getData.lienhe_email;
        txtphone.Text = getData.lienhe_phone;
        txtaddress.Text = getData.lienhe_address;

        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
        
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {

        cls_LienHe cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "lienhe_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_LienHe();
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
        if (txtemail.Text != "" && txtaddress.Text!="" && txtphone.Text!="")
            return true;
        else return false;
    }


    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_LienHe cls = new cls_LienHe();
        if (checknull() == false)
            alert.alert_Warning(Page, "Nhập đầy đủ thông tin!", "");
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                if (cls.Linq_Them(txtemail.Text, txtphone.Text, txtaddress.Text))
                {
                    alert.alert_Success(Page, "Thêm thành công", "");
                    loadData();
                }
                else alert.alert_Error(Page, "Thêm thất bại", "");
            }
            else
            {
                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtemail.Text, txtphone.Text, txtaddress.Text))
                {
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                    //popupControl.ShowOnPageLoad = false;
                    loadData();
                }
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }
        }
        
    }

}