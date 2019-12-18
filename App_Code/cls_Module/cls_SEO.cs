using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_SEO
/// </summary>
public class cls_SEO
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_SEO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them( string SEO_TITTLE, string SEO_DEP, string SEO_KEYWORD, string SEO_LINK, string SEO_IMAGE)
    {
        tbSEO insert = new tbSEO();
        insert.seo_title = SEO_TITTLE;
        insert.seo_description = SEO_DEP;
        insert.seo_keyworld = SEO_KEYWORD;
        insert.seo_link = SEO_LINK;
        insert.seo_image = SEO_IMAGE;
        db.tbSEOs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int seo_id, string SEO_TITTLE, string SEO_DEP, string SEO_KEYWORD, string SEO_LINK, string SEO_IMAGE)
    {

        tbSEO update = db.tbSEOs.Where(x => x.seo_id == seo_id).FirstOrDefault();
        update.seo_title = SEO_TITTLE;
        update.seo_description = SEO_DEP;
        update.seo_keyworld = SEO_KEYWORD;
        update.seo_image = SEO_IMAGE;
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