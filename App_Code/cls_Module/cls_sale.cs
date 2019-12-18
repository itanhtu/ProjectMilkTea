using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_sale
/// </summary>
public class cls_sale
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_sale()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string sale_title, string sale_summary, string image, string content)
    {

        tbSale insert = new tbSale();
        insert.sale_title = sale_title;
        insert.sale_summary = sale_summary;
        insert.sale_image = image;
        insert.sale_content = content;
        insert.active = false;
        insert.salecate_id = 1;
        insert.sale_datetime = DateTime.Now;
        db.tbSales.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int sale_id, string sale_title, string sale_summary, string image, string content)
    {
        tbSale update = db.tbSales.Where(x => x.sale_id == sale_id).FirstOrDefault();
        update.sale_title = sale_title;
        update.sale_summary = sale_summary;
        if (image != "x")
            update.sale_image = image;
        update.sale_content = content;

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
    public bool Linq_Xoa(int sale_id)
    {
        tbSale delete = db.tbSales.Where(x => x.sale_id == sale_id).FirstOrDefault();
        db.tbSales.DeleteOnSubmit(delete);
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