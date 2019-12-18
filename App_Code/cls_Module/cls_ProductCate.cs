using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_ProductCate
/// </summary>
public class cls_ProductCate
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_ProductCate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them(string productcate_title, int parent, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {
        tbProductCate insert = new tbProductCate();
        insert.productcate_title = productcate_title;
        insert.productcate_parent = parent;
        //insert.productcate_position = Convert.ToInt16(vitri);
        insert.productcate_show = true;
        //insert.productcate_content = noidung;
        if (SEO_KEYWORD != "")
        {
            insert.meta_keywords = SEO_KEYWORD;
        }
        else
        {
            insert.meta_keywords = productcate_title + ", " + cls_ToAscii.ToAscii(productcate_title.ToLower());
        }
        if (SEO_TITLE != "")
        {
            insert.meta_title = SEO_TITLE;
        }
        else
        {
            insert.meta_title = productcate_title + " | " + cls_ToAscii.ToAscii(productcate_title.ToLower());
        }

        if (SEO_DEP != "")
        {
            insert.meta_description = SEO_DEP;
        }
        else
        {
            insert.meta_description = productcate_title + " | " + cls_ToAscii.ToAscii(productcate_title.ToLower());
        }
        insert.meta_image = SEO_IMAGE;
        db.tbProductCates.InsertOnSubmit(insert);
        db.SubmitChanges();
        if (SEO_LINK != "")
        {
            insert.link_seo = SEO_LINK;
        }
        else
        {
            insert.link_seo = "loai-san-pham/" + cls_ToAscii.ToAscii(productcate_title.ToLower()) + "-" + insert.productcate_id;
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
    public bool Linq_Sua(int productcate_id, string productcate_title, int parent,string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {
        tbProductCate update = db.tbProductCates.Where(x => x.productcate_id == productcate_id).FirstOrDefault();
        update.productcate_title = productcate_title;
        update.productcate_parent = parent;
        //update.productcate_position = Convert.ToInt16(vitri);
        //update.productcate_show = productcate_show;
        //update.productcate_content = noidung;
        if (SEO_KEYWORD != "")
        {
            update.meta_keywords = SEO_KEYWORD;
        }
        else
        {
            update.meta_keywords = productcate_title + ", " + cls_ToAscii.ToAscii(productcate_title.ToLower());
        }
        if (SEO_TITLE != "")
        {
            update.meta_title = SEO_TITLE;
        }
        else
        {
            update.meta_title = productcate_title + " | " + cls_ToAscii.ToAscii(productcate_title.ToLower());
        }

        if (SEO_DEP != "")
        {
            update.meta_description = SEO_DEP;
        }
        else
        {
            update.meta_description = productcate_title + " | " + cls_ToAscii.ToAscii(productcate_title.ToLower());
        }
        update.meta_image = SEO_IMAGE;
        if (SEO_LINK != "")
        {
            update.link_seo = SEO_LINK;
        }
        else
        {
            update.link_seo = "loai-san-pham/" + cls_ToAscii.ToAscii(productcate_title.ToLower()) + "-" + update.productcate_id;
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
    public bool Linq_Xoa(int productcate_id)
    {
        tbProductCate delete = db.tbProductCates.Where(x => x.productcate_id == productcate_id).FirstOrDefault();
        db.tbProductCates.DeleteOnSubmit(delete);
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
    public bool Linq_An(int productcate_id)
    {
        tbProductCate An = db.tbProductCates.Where(x => x.productcate_id == productcate_id).FirstOrDefault();
        An.productcate_show = false;
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
    public bool Linq_HienThi(int productcate_id)
    {
        tbProductCate hien = db.tbProductCates.Where(x => x.productcate_id == productcate_id).FirstOrDefault();
        hien.productcate_show = true;
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