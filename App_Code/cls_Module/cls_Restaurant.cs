using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Restaurant
/// </summary>
public class cls_Restaurant
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Restaurant()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Restaurant_Them(string restaurant_name, string restaurant_phone, string restaurant_email, string restaurant_address, string image, string restaurant_map, string restaurant_map2, string linkvideo, int restaurantcate_id)
    {

        tbRestaurant insert = new tbRestaurant();
        insert.restaurant_name = restaurant_name;
        insert.restaurant_phone = restaurant_phone;
        insert.restaurant_email = restaurant_email;
        insert.restaurant_address = restaurant_address;
        insert.restaurant_image = image;
        insert.restaurant_map = restaurant_map;
        try
        {
            restaurant_map2 = string.Format(restaurant_map.Split('@')[1]);
            string restaurant_a = string.Format(restaurant_map2.Split(',')[0]);
            string restaurant_b = string.Format(restaurant_map2.Split(',')[1]);
            restaurant_map2 = restaurant_a + ',' + restaurant_b;
        }
        catch { };
        insert.restaurant_map2 = restaurant_map2;
        try
        {
            string[] arrLocation = restaurant_map2.Split(',');
            string location_lat = arrLocation[0];
            string location_long = arrLocation[1];
            insert.location_lat = location_lat;
            insert.location_long = location_long;
        }
        catch { };
        try
        {
            linkvideo = string.Format(linkvideo.Split('=')[1]);

        }
        catch { };
        insert.restaurant_linkvideo = linkvideo;
        insert.restaurant_addressname = restaurant_address + "," + restaurant_name;
        insert.city_id = restaurantcate_id;

        db.tbRestaurants.InsertOnSubmit(insert);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Restaurant_Sua(int restaurant_id, string restaurant_name, string restaurant_phone, string restaurant_email, string restaurant_address, string restaurant_image, string restaurant_map, string restaurant_map2, string linkvideo, int restaurantcate_id)
    {
        tbRestaurant update = db.tbRestaurants.Where(x => x.restaurant_id == restaurant_id).FirstOrDefault();
        update.restaurant_name = restaurant_name;
        update.restaurant_phone = restaurant_phone;
        update.restaurant_email = restaurant_email;
        update.restaurant_address = restaurant_address;
        update.restaurant_map = restaurant_map;
        if (restaurant_image != null)
            update.restaurant_image = restaurant_image;
        try
        {
            restaurant_map2 = string.Format(restaurant_map.Split('@')[1]);
            string restaurant_a = string.Format(restaurant_map2.Split(',')[0]);
            string restaurant_b = string.Format(restaurant_map2.Split(',')[1]);
            restaurant_map2 = restaurant_a + ',' + restaurant_b;
        }
        catch { };
        update.restaurant_map2 = restaurant_map2;
        try
        {
            string[] arrLocation = restaurant_map2.Split(',');
            string location_lat = arrLocation[0];
            string location_long = arrLocation[1];
            update.location_lat = location_lat;
            update.location_long = location_long;
        }
        catch { };
        try
        {
            linkvideo = string.Format(linkvideo.Split('=')[1]);
        }
        catch { };
        update.restaurant_linkvideo = linkvideo;
        update.restaurant_addressname = restaurant_address + "," + restaurant_name;
        update.city_id = restaurantcate_id;
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Restaurant_SuaImage(int restaurant_id, string restaurant_image)
    {
        tbRestaurant update = db.tbRestaurants.Where(x => x.restaurant_id == restaurant_id).FirstOrDefault();
        update.restaurant_image = restaurant_image;
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Restaurant_Xoa(int restaurant_id)
    {
        tbRestaurant delete = db.tbRestaurants.Where(x => x.restaurant_id == restaurant_id).FirstOrDefault();
        db.tbRestaurants.DeleteOnSubmit(delete);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}