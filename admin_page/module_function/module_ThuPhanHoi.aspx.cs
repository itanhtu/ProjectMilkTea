using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThuPhanHoi : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
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
        var getData = from ct in db.tbCustomers
                      orderby ct.cus_date descending
                      select new {
                          ct.cus_id,
                          ct.cus_name,
                          ct.cus_phone,
                          ct.cus_email,
                          ct.cus_content,
                          ct.cus_date,
                          cus_status = ct.cus_status==true? "Đã Xem":"Chưa Xem"
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "cus_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbCustomers
                       where nc.cus_id == _id
                       select nc).Single();
        txtHoten.Text = getData.cus_name;
        txtPhone.Text = getData.cus_phone;
        txtEmail.Text = getData.cus_email;
        txtnoidung.Value = getData.cus_content;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
        loadData();
        getData.cus_status = true;
        db.SubmitChanges();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "function(){grvList.Refresh();}", true);
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_ThuPhanHoi cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "cus_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_ThuPhanHoi();
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
}