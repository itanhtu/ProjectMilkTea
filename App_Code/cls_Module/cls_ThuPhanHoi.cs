using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_ThuPhanHoi
/// </summary>
public class cls_ThuPhanHoi
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_ThuPhanHoi()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //public bool Linq_Them(string image, string link, string slide_title, string slide_title1)
    //{

    //    tbSlide insert = new tbSlide();
    //    insert.slide_title = slide_title;
    //    insert.slide_image = image;
    //    // insert.slide_summary = slide_summary;
    //    insert.slide_date = DateTime.Now;
    //    insert.slide_link = link;
    //    insert.slide_title1 = slide_title1;
    //    insert.hidden = true;
    //    // insert.news_link= 
    //    db.tbSlides.InsertOnSubmit(insert);
    //    try
    //    {

    //        db.SubmitChanges();
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
    //public bool Linq_Sua(int slide_id, string image, string link, string slide_title, string slide_title1)
    //{
    //    tbSlide update = db.tbSlides.Where(x => x.slide_id == slide_id).FirstOrDefault();
    //    update.slide_title = slide_title;
    //    if (image != "x")
    //        update.slide_image = image;
    //    //update.slide_summary = slide_summary;
    //    //update.slide_content = content;
    //    update.slide_link = link;
    //    update.slide_title1 = slide_title1;


    //    try
    //    {
    //        db.SubmitChanges();
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
    public bool Linq_Xoa(int cus_id)
    {
        tbCustomer delete = db.tbCustomers.Where(x => x.cus_id == cus_id).FirstOrDefault();
        db.tbCustomers.DeleteOnSubmit(delete);
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