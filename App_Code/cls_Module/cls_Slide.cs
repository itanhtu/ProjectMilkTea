using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_Slide
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Slide()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string image, string link, string slide_title, string slide_title1)
    {

        tbSlide insert = new tbSlide();
        insert.slide_title = slide_title;
        insert.slide_image = image;
        insert.slide_date = DateTime.Now;
        insert.slide_link = link;
        insert.slide_title1 = slide_title1;
        insert.hidden = true;
        db.tbSlides.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int slide_id, string image, string link, string slide_title, string slide_title1)
    {
        tbSlide update = db.tbSlides.Where(x => x.slide_id == slide_id).FirstOrDefault();
        try
        {
            update.slide_title = slide_title;
            if (image != null)
                update.slide_image = image;
            update.slide_link = link;
            update.slide_title1 = slide_title1;
        }
        catch { };
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
    public bool Linq_Xoa(int slide_id)
    {
        tbSlide delete = db.tbSlides.Where(x => x.slide_id == slide_id).FirstOrDefault();
        db.tbSlides.DeleteOnSubmit(delete);
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