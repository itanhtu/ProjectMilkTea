using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_City
/// </summary>
public class cls_City
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_City()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool City_Them(string city_name, string city_toado, int zoom)
    {
        tbCity insert = new tbCity();
        insert.city_name = city_name;
        try
        {
            string lat = string.Format(city_toado.Split(',')[0]);
            string longg = string.Format(city_toado.Split(',')[1]);
            insert.location_lat = lat;
            insert.location_long = longg;
        }
        catch { }
        insert.city_zoom = zoom;
        db.tbCities.InsertOnSubmit(insert);
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
    public bool City_Sua(int city_id, string city_name, string city_toado, int zoom)
    {
        tbCity update = db.tbCities.Where(x => x.city_id == city_id).FirstOrDefault();
        update.city_name = city_name;
        string lat = string.Format(city_toado.Split(',')[0]);
        string longg = string.Format(city_toado.Split(',')[1]);
        update.location_lat = lat;
        update.location_long = longg;
        update.city_zoom = zoom;
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
    public bool City_Xoa(int city_id)
    {
        tbCity delete = db.tbCities.Where(x => x.city_id == city_id).FirstOrDefault();
        db.tbCities.DeleteOnSubmit(delete);
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