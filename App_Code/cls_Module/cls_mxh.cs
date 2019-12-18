using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_mxh
/// </summary>
public class cls_mxh
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_mxh()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string fb, string tw, string ins, string gg)
    {

        tbKetNoiMXH insert = new tbKetNoiMXH();
        insert.ketnoimxh_facebook = fb;
        insert.ketnoimxh_twitter = tw;
        insert.ketnoimxh_instagram = ins;
        insert.ketnoimxh_google = gg;
        db.tbKetNoiMXHs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int mxh_id, string fb, string tw, string ins, string gg)
    {
        tbKetNoiMXH update = db.tbKetNoiMXHs.Where(x => x.ketnoimxh_id == mxh_id).FirstOrDefault();
        update.ketnoimxh_facebook = fb;
        update.ketnoimxh_twitter = tw;
        update.ketnoimxh_instagram = ins;
        update.ketnoimxh_google = gg;
        // update.newcate_id = cate;
        // update.news_datetime = date;
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