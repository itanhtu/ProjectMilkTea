using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_Restaurant : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    public string image;
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
            var getData = from tb in db.tbRestaurants
                          orderby tb.restaurant_id descending
                          select tb;
            grvList.DataSource = getData;
            grvList.DataBind();
            cbbthanhpho.DataSource = from tb in db.tbCities
                                     select tb;
            cbbthanhpho.DataBind();
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void setNULL()
    {
        txtName.Text = "";
        cbbthanhpho.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        txtMap.Text = "";
        txtMap2.Text = "";
        txtVideo.Text = "";
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

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        if (Session["AdminLogined"] != null)
        {
            admin_User logedMember = Session["AdminLogined"] as admin_User;

            _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "restaurant_id" }));
            Session["_id"] = _id;
            var getData = (from tb in db.tbRestaurants
                           join tp in db.tbCities on tb.city_id equals tp.city_id
                           where tb.restaurant_id == _id
                           select new
                           {
                               tb.restaurant_id,
                               tb.restaurant_name,
                               tb.restaurant_phone,
                               tb.restaurant_email,
                               tb.restaurant_address,
                               tb.restaurant_image,
                               tb.restaurant_linkvideo,
                               tb.city_id,
                               tp.city_name,
                               tb.restaurant_map,
                               tb.restaurant_map2
                           }).Single();
            txtName.Text = getData.restaurant_name;
            cbbthanhpho.Text = getData.city_name;
            txtPhone.Text = getData.restaurant_phone;
            txtEmail.Text = getData.restaurant_email;
            txtAddress.Text = getData.restaurant_address;
            txtMap.Text = getData.restaurant_map;
            txtMap2.Text = getData.restaurant_map2;
            txtVideo.Text = getData.restaurant_linkvideo;
            if (getData.restaurant_image == "" || getData.restaurant_image == null)
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + "/admin_images/Preview-icon.png" + "'); ", true);
            //image = "/admin_images/Preview-icon.png";
            else
                //image = getData.restaurant_image;
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();showImg1_1('" + getData.restaurant_image + "'); ", true);
            loadData();
        }
}
    public bool checknull()
    {
        if (txtName.Text!="" && txtPhone.Text != "" && txtEmail.Text != "" && txtAddress.Text != "" && txtMap.Text != "" && txtVideo.Text != "" && cbbthanhpho.Text != "")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_Restaurant cls = new cls_Restaurant();
        if (Page.IsValid && FileUpload1.HasFile)
        {
            string filename = Path.GetRandomFileName() + Path.GetExtension(FileUpload1.FileName);
            string fileName_save = Path.Combine(Server.MapPath("~/uploadimages/imagecuahang"), filename);
            FileUpload1.SaveAs(fileName_save);
            image = "/uploadimages/imagecuahang/" + filename;
        }
        if (checknull() == false)
            alert.alert_Warning(Page, "Hãy nhập đầy đủ thông tin!", "");
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                if (cls.Restaurant_Them(txtName.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text, image, txtMap.Text, txtMap2.Text, txtVideo.Text, Convert.ToInt32(cbbthanhpho.Value.ToString())))
                {
                    alert.alert_Success(Page, "Thêm thành công", "");
                    popupControl.ShowOnPageLoad = false;
                    loadData();
                }
                else alert.alert_Error(Page, "Thêm thất bại", "");
            }
            else
            {

                if (cls.Restaurant_Sua(Convert.ToInt32(Session["_id"].ToString()), txtName.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text, image, txtMap.Text, txtMap2.Text, txtVideo.Text, Convert.ToInt32(cbbthanhpho.Value.ToString())))
                {
                    //alert.alert_Success(Page, "Cập nhật thành công", "");
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){grvList.Refresh();})", true);
                    popupControl.ShowOnPageLoad = false;
                    loadData();
                }
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_Restaurant cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "restaurant_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_Restaurant();
                tbRestaurant checkImage = (from i in db.tbRestaurants where i.restaurant_id == Convert.ToInt32(item) select i).SingleOrDefault();
                if (cls.Restaurant_Xoa(Convert.ToInt32(item)))
                    alert.alert_Success(Page, "Xóa thành công", "");
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }
    public void delete(string sFileName)
    {
        if (sFileName != String.Empty)
        {
            if (File.Exists(sFileName))

                File.Delete(sFileName);
        }
    }
}