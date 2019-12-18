using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_Agency : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        var restaurantcate = from rc in db.tbCities
                             where rc.city_show == true
                             orderby rc.city_position ascending
                             select rc;
        rpResCate.DataSource = restaurantcate;
        rpResCate.DataBind();
        var restaurant = from rs in db.tbRestaurants
                         orderby rs.city_id descending
                         join pc in db.tbCities on rs.city_id equals pc.city_id
                         select new
                         {
                             rs.restaurant_id,
                             rs.restaurant_address,
                             rs.restaurant_email,
                             rs.restaurant_image,
                             rs.restaurant_name,
                             rs.restaurant_phone,
                             active = pc.city_name
                         };
        rpRestaurant.DataSource = restaurant;
        rpRestaurant.DataBind();

        var popup = from rs in db.tbRestaurants
                    orderby rs.city_id descending
                    select new
                    {
                        rs.restaurant_id,
                        rs.restaurant_address,
                        rs.restaurant_email,
                        rs.restaurant_image,
                        rs.restaurant_name,
                        rs.restaurant_phone,
                        rs.restaurant_addressname,
                        rs.restaurant_map
                    };
        rpPopup.DataSource = popup;
        rpPopup.DataBind();

    }

  
}