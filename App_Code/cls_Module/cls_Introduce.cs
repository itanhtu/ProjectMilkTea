using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_Introduce
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Introduce()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string introduce_title, string introduce_title1, string int_summary, string introduce_content, string image)
    {
        tbIntroduce insert = new tbIntroduce();
        insert.introduce_title = introduce_title;
        insert.introduce_title1 = introduce_title1;
        insert.introduce_summary = int_summary;
        insert.introduce_content = introduce_content;
        insert.introduce_active = false;
        insert.introduce_image = image;
        insert.introduce_dateup = DateTime.Now;
        db.tbIntroduces.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int introduce_id, string introduce_title, string introduce_title1, string int_summary, string introduce_content, string image, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {

        tbIntroduce update = db.tbIntroduces.Where(x => x.introduct_id == introduce_id).FirstOrDefault();
        update.introduce_title = introduce_title;
        update.introduce_title1 = introduce_title1;
        update.introduce_summary = int_summary;
        update.introduce_content = introduce_content;
        if (image != null)
            update.introduce_image = image;
        update.introduce_dateup = DateTime.Now;
        if (SEO_KEYWORD != "")
        {
            update.seo_keyworld = SEO_KEYWORD;
        }
        else
        {
            update.seo_keyworld = introduce_title1 + ", " + cls_ToAscii.ToAscii(introduce_title1.ToLower());
        }
        if (SEO_TITLE != "")
        {
            update.seo_title = SEO_TITLE;
        }
        else
        {
            update.seo_title = introduce_title1 + " | " + cls_ToAscii.ToAscii(introduce_title1.ToLower());
        }

        if (SEO_LINK != "")
        {
            update.seo_link = SEO_LINK;
        }
        else
        {
            update.seo_link = "gioi-thieu/" + cls_ToAscii.ToAscii(introduce_title1.ToLower()) + "-" + update.introduct_id;
        }
        if (SEO_DEP != "")
        {
            update.seo_description = SEO_DEP;
        }
        else
        {
            update.seo_description = introduce_title1 + " | " + cls_ToAscii.ToAscii(introduce_title1.ToLower());
        }
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
    public bool Linq_Xoa(int introduce_id)
    {
        tbIntroduce delete = db.tbIntroduces.Where(x => x.introduct_id == introduce_id).FirstOrDefault();
        db.tbIntroduces.DeleteOnSubmit(delete);
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