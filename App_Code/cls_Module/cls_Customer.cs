using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Customer
/// </summary>
public class cls_Customer
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Customer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string customer_name, string customer_content, string image)
    {
        tbCustomerFeedback insert = new tbCustomerFeedback();
        insert.customer_title = "Phản hồi từ khách hàng";
        insert.customer_name = customer_name;
        insert.customer_content = customer_content;
        insert.customer_image = image;
        insert.customer_date = DateTime.Now;
        insert.customer_active = true;
        db.tbCustomerFeedbacks.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int customer_id, string customer_name, string customer_content, string image)
    {
        tbCustomerFeedback update = db.tbCustomerFeedbacks.Where(x => x.customer_id == customer_id).FirstOrDefault();
        update.customer_name = customer_name;
        update.customer_content = customer_content;
        if (image != null)
            update.customer_image = image;
        //update.customer_date = DateTime.Now.ToString();
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
    public bool Linq_Xoa(int customer_id)
    {
        tbCustomerFeedback delete = db.tbCustomerFeedbacks.Where(x => x.customer_id == customer_id).FirstOrDefault();
        db.tbCustomerFeedbacks.DeleteOnSubmit(delete);
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
    public bool Customer_SuaImage(int customer_id, string customer_image)
    {
        tbCustomerFeedback update = db.tbCustomerFeedbacks.Where(x => x.customer_id == customer_id).FirstOrDefault();
        update.customer_image = customer_image;
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
    public bool Customer_Xoa(int customer_id)
    {
        tbCustomerFeedback delete = db.tbCustomerFeedbacks.Where(x => x.customer_id == customer_id).FirstOrDefault();
        db.tbCustomerFeedbacks.DeleteOnSubmit(delete);
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