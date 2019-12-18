using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_access_admin_UserManage : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            loadDataGiaoVien();
        }
        else
        {
            Response.Redirect("/admin-login");
        }

    }
    // Dành cho root
    private void loadData()
    {
        var getData = from gv in db.admin_Users select gv;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    // Dành cho các trung tâm
    private void loadDataTrungTam()
    {
        admin_User logedMember = Session["AdminLogined"] as admin_User;
        var getData = from gv in db.admin_Users
                      where gv.groupuser_id == 2
                      select gv;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    // Dành cho các giáo viên
    private void loadDataGiaoVien()
    {
        admin_User logedMember = Session["AdminLogined"] as admin_User;
        if (logedMember.username_id == 1)
        {
            var getData = from gv in db.admin_Users
                          orderby gv.username_id descending
                          select
                          new
                          {
                              gv.username_id,
                              gv.username_fullname,
                              username_gender = gv.username_gender == true ? "Nam" : "Nữ",
                              gv.username_email,
                              gv.username_phone,
                              gv.username_username
                          };
            grvList.DataSource = getData;
            grvList.DataBind();
        }
        else
        {
            var getData = from gv in db.admin_Users
                          where gv.username_id != 1
                          orderby gv.username_id descending
                          select gv;
            grvList.DataSource = getData;
            grvList.DataBind();
        }
    }
    private void setNULL()
    {
        txttensanpham.Text = "";
        txtAccount.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        //txtPass.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Session["_id"] = 0;
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "username_id" }));
        Session["_id"] = _id;
        var getData = (from gr in db.admin_Users
                       where gr.username_id == _id
                       select gr).Single();
        txttensanpham.Text = getData.username_fullname;
        if (getData.username_gender == true)
            rdGroup.Text = "Nam";
        else
            rdGroup.Text = "Nữ";
        txtEmail.Text = getData.username_email;
        txtPhone.Text = getData.username_phone;
        txtAccount.Text = getData.username_username;
        //txtPass.Text = getData.username_password;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {

        cls_GiaoVien cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "username_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_GiaoVien();
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
        if (txttensanpham.Text != "" && txtAccount.Text != "" /*&& txtPass.Text != ""*/ && txtPhone.Text != "")
            return true;
        else return false;
    }


    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_GiaoVien cls = new cls_GiaoVien();
        cls_security md5 = new cls_security();
        //string passWord = txtPass.Text.Trim();
        //string passmd5 = md5.HashCode(txtPass.Text);
        string bophan = rdGV.SelectedValue;
        if (checknull() == false)
            alert.alert_Warning(Page, "Nhập đầy đủ thông tin!", "");
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                bool gt = true;
                if (rdGroup.SelectedValue == "2")
                {
                    gt = false;
                }

                if (cls.Linq_Them(txttensanpham.Text, gt, bophan, txtEmail.Text, txtPhone.Text, txtAccount.Text))
                    alert.alert_Success(Page, "Thêm thành công", "");
                else
                    alert.alert_Error(Page, "Thêm thất bại", "");
            }
            else
            {
                bool gt = true;
                if (rdGroup.SelectedValue == "2")
                {
                    gt = false;
                }
                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txttensanpham.Text, gt, txtEmail.Text, txtPhone.Text, txtAccount.Text))
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }
        }
        popupControl.ShowOnPageLoad = false;
        loadDataGiaoVien();
    }

    //protected void grvList_HtmlRowCreated1(object sender, ASPxGridViewTableRowEventArgs e)
    //{
    //    if (e.RowType != GridViewRowType.Data) return;

    //    ASPxLabel label = grvList.FindRowCellTemplateControl(e.VisibleIndex, null,
    //    "txtGioitinh") as ASPxLabel;
    //    var getData = (from gr in db.admin_Users
    //                       //where gr.username_id == _id
    //                   select gr).FirstOrDefault();
    //    if (getData.username_gender == true)
    //    {
    //        label.Text = "Nam";
    //    }
    //}
}