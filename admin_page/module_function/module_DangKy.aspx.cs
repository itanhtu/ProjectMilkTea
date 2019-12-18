using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_DangKy : System.Web.UI.Page
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
        var getData = from nc in db.tbDangKyEmails
                      orderby nc.dke_tinhtrang descending
                      select nc;
        grvList.DataSource = getData;
        grvList.DataBind();
    }

    protected void btnPheDuyet_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "dke_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var getData = (from n in db.tbDangKyEmails where n.dke_id == Convert.ToInt32(item) select n).SingleOrDefault();
                if (getData.dke_tinhtrang == "Đã xem")
                {
                    alert.alert_Success(Page, "Thông báo đã được phê duyệt!", "");
                }
                else
                {
                    if (getData != null)
                    {
                        getData.dke_tinhtrang = "Đã xem";
                        db.SubmitChanges();
                        alert.alert_Success(Page, "Phê duyệt thành công!", "");
                    }
                    else
                    {
                        alert.alert_Error(Page, "Phê duyệt thất bại!", "");
                    }
                }
            }
        }
    }
}