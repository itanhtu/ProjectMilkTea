using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_block_HeThongCuaHang : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        
              
        var restaurantcate = from rc in db.tbCities
                             join rs in db.tbRestaurants on rc.city_id equals rs.city_id
                             group rc by rc.city_id into g
                             select new {
                                 g.Key,
                                city_name =  g.First().city_name
                             };
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
                             rs.restaurant_linkvideo,
                             active = pc.city_name
                         };
        rpRestaurant.DataSource = restaurant;
        rpRestaurant.DataBind();

        //Truong hop lam tam thoi
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
                        rs.restaurant_map,
                        rs.restaurant_linkvideo
                    };
        rpPopup.DataSource = popup;
        rpPopup.DataBind();
    }
}


    //protected void btnpopup_ServerClick(object sender, EventArgs e)
    //{
    //    string _id = txtMaProduct.Value;
    //        var popup = from rs in db.tbRestaurants
    //                    orderby rs.city_id descending
    //                    where rs.restaurant_id == Convert.ToInt32(_id)
    //                    select new
    //                    {
    //                        rs.restaurant_id,
    //                        rs.restaurant_address,
    //                        rs.restaurant_email,
    //                        rs.restaurant_image,
    //                        rs.restaurant_name,
    //                        rs.restaurant_phone,
    //                        rs.restaurant_position,
    //                    };
    //        rpPopup.DataSource = popup;
    //        rpPopup.DataBind();
    //    }
