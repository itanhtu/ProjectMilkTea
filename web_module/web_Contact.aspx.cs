using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_Contact : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public string keywords, description, linkTungTrang, title_Google, image;
    protected void Page_Load(object sender, EventArgs e)
    {
        rpContact.DataSource = from contact in db.tbLienHes select contact;
        rpContact.DataBind();
        //rpOpenTime.DataSource = from op in db.tbOpentimes select op;
        //rpOpenTime.DataBind();
        var getseo = (from seo in db.tbSEOs where seo.seo_id == 2 select seo).SingleOrDefault();
        title_Google = getseo.seo_title;
        keywords = getseo.seo_keyworld;
        description = getseo.seo_description;
        linkTungTrang = getseo.seo_link;
        image = getseo.seo_image;
    }
    protected void setNull()
    {
        txtHoten.Value = "";
        txtPhone.Value = "";
        txtEmail.Value = "";
        txtLoinhan.Value = "";
        txtSubject.Value = "";
    }
    protected void btnGui_ServerClick(object sender, EventArgs e)
    {
        //Kiểm tra email
        if (isEmail(txtEmail.Value) != true)
        {
            alert.alert_Error(Page, "Vui Lòng Kiểm tra lại mail của bạn", "");

        }
        else if (txtHoten.Value == "" || txtPhone.Value == "" || txtEmail.Value == "" || txtSubject.Value == "" || txtLoinhan.Value == "")
        {
            alert.alert_Error(Page, "Vui lòng nhập đầy đủ thông tin", "");
        }
        else
        {
            //Lưu thông tin Lời nhắn khách hàng gửi
            tbCustomer insert = new tbCustomer();
            insert.cus_name = txtHoten.Value;
            insert.cus_phone = txtPhone.Value;
            insert.cus_email = txtEmail.Value;
            insert.cus_title = txtSubject.Value;
            insert.cus_content = txtLoinhan.Value;
            insert.cus_date = DateTime.Now;
            insert.cus_status = false;
            db.tbCustomers.InsertOnSubmit(insert);
            db.SubmitChanges();
            alert.alert_Success(Page, "Đã Gửi", "");
            setNull();
        }
    }
    private bool isEmail(string txtEmail)
    {
        Regex re = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase);
        return re.IsMatch(txtEmail);
    }
}