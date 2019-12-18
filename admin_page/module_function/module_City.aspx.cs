using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_City : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            loadData();
        }
    }
    private void loadData()
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;
            var getData = from tb in db.tbCities
                          orderby tb.city_id descending
                          select new
                          {
                              tb.city_id,
                              tb.city_name,
                              tb.city_zoom,
                              city_toado = tb.location_lat + "," + tb.location_long
                          };
            grvList.DataSource = getData;
            grvList.DataBind();
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void setNULL()
    {
        txtName.Text = "";
        txtToaDo.Text = "";
        txtZoom.Text = "";
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        Session["_id"] = 0;
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;
            _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "city_id" }));
            Session["_id"] = _id;
            var getData = (from tb in db.tbCities
                           where tb.city_id == _id
                           select new
                           {
                               tb.city_id,
                               tb.city_name,
                               tb.city_zoom,
                               city_toado = tb.location_lat + "," + tb.location_long
                           }).Single();
            txtName.Text = getData.city_name;
            txtToaDo.Text = getData.city_toado;
            txtZoom.Text = getData.city_zoom.ToString();
        }
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_City cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "city_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_City();
                tbCity checkImage = (from i in db.tbCities where i.city_id == Convert.ToInt32(item) select i).SingleOrDefault();
                if (cls.City_Xoa(Convert.ToInt32(item)))
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
        if (txtName.Text != "" && txtToaDo.Text != "" && txtZoom.Text != "")
            return true;
        else return false;
    }


    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_City cls = new cls_City();
        if (checknull() == false)
            alert.alert_Warning(Page, "Hãy nhập đầy đủ thông tin!", "");
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                try
                {
                    if (cls.City_Them(txtName.Text, txtToaDo.Text, Convert.ToInt32(txtZoom.Text)))
                    {
                        alert.alert_Success(Page, "Thêm thành công", "");
                        popupControl.ShowOnPageLoad = false;
                        loadData();
                    }
                    else alert.alert_Error(Page, "Thêm thất bại", "");
                }
                catch
                {
                    alert.alert_Error(Page, "Zoom phải là số!", "");
                }
            }
            else
            {
                try
                {
                    if (cls.City_Sua(Convert.ToInt32(Session["_id"].ToString()),txtName.Text, txtToaDo.Text, Convert.ToInt32(txtZoom.Text)))
                {
                    //alert.alert_Success(Page, "Cập nhật thành công", "");
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){grvList.Refresh();})", true);
                    popupControl.ShowOnPageLoad = false;
                    loadData();
                }
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
                }
                catch
                {
                    alert.alert_Error(Page, "Zoom phải là số!", "");
                }
            }
        }

    }
}