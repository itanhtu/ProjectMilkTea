using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_Product
/// </summary>
public class cls_Product
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Product_Them(string product_title, string image, string product_content, int product_price, bool product_show, bool product_new, int productcate_id, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {
        tbProduct insert = new tbProduct();
        insert.product_title = product_title;
        insert.product_image = image;
        insert.product_content = product_content;
        insert.product_price = product_price;
        insert.product_date = DateTime.Now;
        insert.product_show = true;
        insert.product_new = product_new;
        insert.productcate_id = productcate_id;
        if (SEO_KEYWORD != "")
        {
            insert.meta_keywords = SEO_KEYWORD;
        }
        else
        {
            insert.meta_keywords = product_title + ", " + cls_ToAscii.ToAscii(product_title.ToLower());
        }
        if (SEO_TITLE != "")
        {
            insert.meta_title = SEO_TITLE;
        }
        else
        {
            insert.meta_title = product_title + " | " + cls_ToAscii.ToAscii(product_title.ToLower());
        }

        if (SEO_DEP != "")
        {
            insert.meta_description = SEO_DEP;
        }
        else
        {
            insert.meta_description = product_title + " | " + cls_ToAscii.ToAscii(product_title.ToLower());
        }
        insert.meta_image = SEO_IMAGE;

        db.tbProducts.InsertOnSubmit(insert);
        db.SubmitChanges();
        if (SEO_LINK != "")
        {
            insert.link_seo = SEO_LINK;
        }
        else
        {
            insert.link_seo = "san-pham/" + cls_ToAscii.ToAscii(product_title.ToLower()) + "-" + insert.product_id;
        }
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
    public bool Product_Sua(int product_id, string product_title, string image, string content, int price, int cate, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {
        tbProduct update = db.tbProducts.Where(x => x.product_id == product_id).FirstOrDefault();
        update.product_title = product_title;
        if (image != null)
            update.product_image = image;
        update.product_content = content;
        update.product_price = price;
        update.productcate_id = cate;
        if (SEO_KEYWORD != "")
        {
            update.meta_keywords = SEO_KEYWORD;
        }
        else
        {
            update.meta_keywords = product_title + ", " + cls_ToAscii.ToAscii(product_title.ToLower());
        }
        if (SEO_TITLE != "")
        {
            update.meta_title = SEO_TITLE;
        }
        else
        {
            update.meta_title = product_title + " | " + cls_ToAscii.ToAscii(product_title.ToLower());
        }

        if (SEO_DEP != "")
        {
            update.meta_description = SEO_DEP;
        }
        else
        {
            update.meta_description = product_title + " | " + cls_ToAscii.ToAscii(product_title.ToLower());
        }
        update.meta_image = SEO_IMAGE;
        if (SEO_LINK != "")
        {
            update.link_seo = SEO_LINK;
        }
        else
        {
            update.link_seo = "san-pham/" + cls_ToAscii.ToAscii(product_title.ToLower()) + "-" + update.product_id;
        }
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
    public bool Product_SuaImage(int product_id, string product_image)
    {
        tbProduct update = db.tbProducts.Where(x => x.product_id == product_id).FirstOrDefault();
        update.product_image = product_image;
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
    public bool Product_Xoa(int product_id)
    {
        tbProduct delete = db.tbProducts.Where(x => x.product_id == product_id).FirstOrDefault();
        db.tbProducts.DeleteOnSubmit(delete);
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

    public bool Product_Vip(int product_id)
    {
        tbProduct updateAn = db.tbProducts.Where(x => x.product_id == product_id).SingleOrDefault();
        //updateAn.product_tieubieu = DateTime.Now;
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