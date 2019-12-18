using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_MXH : System.Web.UI.Page
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
        var getData = from ct in db.tbKetNoiMXHs
                      select ct;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "ketnoimxh_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbKetNoiMXHs
                       where nc.ketnoimxh_id == _id
                       select nc).Single();
        txtlink1.Text = getData.ketnoimxh_facebook;
        txtlink2.Text = getData.ketnoimxh_twitter;
        txtlink3.Text = getData.ketnoimxh_instagram;
        txtlink4.Text = getData.ketnoimxh_google;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
        loadData();
    }
    public bool checknull()
    {
        if (txtlink1.Text != "" && txtlink2.Text != "" && txtlink3.Text != "" && txtlink4.Text != "")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_mxh cls = new cls_mxh();

        if (checknull() == false)
            alert.alert_Warning(Page, "Nhập đầy đủ thông tin!", "");
        else
        {
            if (Session["_id"].ToString() == "0")
            {

                if (cls.Linq_Them(txtlink1.Text, txtlink2.Text, txtlink3.Text, txtlink4.Text))
                {
                    alert.alert_Success(Page, "Thêm thành công", "");
                    loadData();

                }
                else alert.alert_Error(Page, "Thêm thất bại", "");

            }
            else
            {
                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtlink1.Text, txtlink2.Text, txtlink3.Text, txtlink4.Text))
                {
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                    loadData();
                }
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }
            loadData();
        }
    }
}