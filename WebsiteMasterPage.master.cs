using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebsiteMasterPage : System.Web.UI.MasterPage
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        var getmxh = from mxh in db.tbKetNoiMXHs
                     where mxh.ketnoimxh_id == 1
                     select mxh;
        rp_MXH.DataSource = getmxh;
        rp_MXH.DataBind();
        rp_MXHFooter.DataSource = getmxh;
        rp_MXHFooter.DataBind();
        rpContact.DataSource = from contact in db.tbLienHes select contact;
        rpContact.DataBind();
        //rp_Contact.DataSource = from lh in db.tbLienHes select lh;
        //rp_Contact.DataBind();
        if (!IsPostBack)
        {
            var listCate_Restaurant = from bk in db.tbCities
                                      join rs in db.tbRestaurants on bk.city_id equals rs.city_id
                                      group bk by bk.city_id into g
                                      orderby g.First().city_id ascending
                                      select new
                                      {
                                          g.Key,
                                          city_name = g.First().city_name
                                      };

            ddlCity.DataSource = listCate_Restaurant;
            ddlCity.DataTextField = "city_name";
            ddlCity.DataValueField = "Key";
            ddlCity.DataBind();
            rpCity.DataSource = from h in db.tbRestaurants
                                join rsc in db.tbCities on h.city_id equals rsc.city_id
                                where rsc.city_id == Convert.ToInt32(ddlCity.SelectedValue)
                                select h;
            rpCity.DataBind();
        }
    }
    //protected void btn_Send_Admin_ServerClick(object sender, EventArgs e)
    //{
    //    var checkmail = from mail in db.tbDangKyEmails where mail.dke_email == txt_Email.Value select mail;
    //    if (isEmail(txt_Email.Value) == false)
    //    {
    //        alert.alert_Warning(Page, "Mail của bạn đã nhập sai vui lòng kiểm tra lại", "");
    //    }
    //    if (checkmail.Count() > 0)
    //    {
    //        alert.alert_Error(Page, "Mail của bạn đã tồn tại", "");
    //    }
    //    else
    //    {
    //        tbDangKyEmail insert = new tbDangKyEmail();
    //        insert.dke_email = txt_Email.Value;
    //        insert.dke_tinhtrang = "Xem";
    //        db.tbDangKyEmails.InsertOnSubmit(insert);
    //        db.SubmitChanges();
    //        alert.alert_Success(Page, "Bạn đã đăng ký thành công", "");
    //    }
    //}

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        rpCity.DataSource = from h in db.tbRestaurants
                            join rsc in db.tbCities on h.city_id equals rsc.city_id
                            where rsc.city_id == Convert.ToInt32(ddlCity.SelectedValue)
                            select h;
        rpCity.DataBind();
    }
    private bool isEmail(string txt_Email)
    {
        Regex re = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase);
        return re.IsMatch(txt_Email);
    }
}

