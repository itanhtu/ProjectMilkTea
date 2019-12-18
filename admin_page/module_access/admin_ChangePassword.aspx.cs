using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_access_admin_ChangePassword : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
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
            //loadData();
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        // admin_User update = (from u in db.admin_Users where u.username_email == txtEmail.Value select u).SingleOrDefault();
        admin_User update_pass = (admin_User)Session["AdminLogined"];
        cls_security md5 = new cls_security();
        string passmd5 = md5.HashCode(txtMatKhauCu.Text);
        var checkTaiKhoan = (from tk in db.admin_Users where tk.username_username == Session["AdminLogined"].ToString() && tk.username_password == passmd5 select tk).SingleOrDefault();
        if (update_pass.username_password != passmd5)
        {
            alert.alert_Error(Page, "Mật khẩu cũ nhập không đúng!", "");

        }
        else if (update_pass.username_password == passmd5)
        {
            if (txtMatKhauMoi.Text == "" || txtNhapLai.Text == "")
            {
                alert.alert_Error(Page, "Bạn chưa nhập mật khẩu mới!", "");
            }
            else if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                alert.alert_Error(Page, "Mật khẩu nhập không khớp!", "");
            }
            else if(txtEmail.Text == "")
            {
                alert.alert_Error(Page, "Vui lòng nhâp email của bạn!", "");
            }
            else
            {
                admin_User checkTaiKhoan1 = (from tk in db.admin_Users where tk.username_id == update_pass.username_id select tk).SingleOrDefault();
                checkTaiKhoan1.username_password = md5.HashCode(txtNhapLai.Text);
                checkTaiKhoan1.username_email = txtEmail.Text;
                db.SubmitChanges();
               
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Mật khẩu đã được thay đổi!', '','success').then(function(){window.location = '/admin-login';})", true);
                Session["AdminLogined"] = null;
            }
        }
    }
}