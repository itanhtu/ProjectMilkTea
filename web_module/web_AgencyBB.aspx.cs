using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_AgencyBB : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public string Map = "", lat = "", lng = "",zoom="";
    public string keywords, description, linkTungTrang, title_Google, image;
    protected void Page_Load(object sender, EventArgs e)
    {
        var getseo = (from seo in db.tbSEOs where seo.seo_id == 3 select seo).SingleOrDefault();
        title_Google = getseo.seo_title;
        keywords = getseo.seo_keyworld;
        description = getseo.seo_description;
        linkTungTrang = getseo.seo_link;
        image = getseo.seo_image;
        if (getValue.Value == "")
        {
            loaddata();
        }
    }

    public void loaddata()
    {
        if (getValue.Value == "")
            getValue.Value = "1";
        if (!IsPostBack)
        {
            var getCity = from city in db.tbCities
                          join rs in db.tbRestaurants on city.city_id equals rs.city_id
                          group city by city.city_id into g
                          orderby g.First().city_id ascending
                          select new
                          {
                              g.Key,
                              city_name = g.First().city_name
                          };
            ddChiNhanh.DataSource = getCity;
            ddChiNhanh.DataTextField = "city_name";
            ddChiNhanh.DataValueField = "Key";
            ddChiNhanh.DataBind();
            var getLocation2 = (from location in db.tbCities
                                where location.city_id == Convert.ToInt32(ddChiNhanh.SelectedValue)
                                select location).FirstOrDefault();
            lat = getLocation2.location_lat;
            lng = getLocation2.location_long;
            zoom = getLocation2.city_zoom.ToString();

        }
        var getLocation = from location in db.tbRestaurants
                          where location.city_id == Convert.ToInt32(getValue.Value)
                          select location;
        foreach (var item in getLocation)
        {
            Map = Map + "{coords:{lat:" + item.location_lat + ",lng:" + item.location_long + "},iconImage:'" + "/uploadimages/map_marker1.png" + "',content:'<strong>" + item.restaurant_name + "</strong><div>Địa chỉ :" + item.restaurant_address + "</div>'},";
        }
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "initMap()", true);

    }
    protected void ddChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getLocation = (from location in db.tbCities
                           where location.city_id == Convert.ToInt32(ddChiNhanh.SelectedValue)
                           select location).FirstOrDefault();
        lat = getLocation.location_lat;
        lng = getLocation.location_long;
        zoom = getLocation.city_zoom.ToString();
        getValue.Value = (getLocation.city_id)+"";
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "initMap()", true);
        loaddata();
    }
}