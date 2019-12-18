using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_News
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_News()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string news_title, string news_summary, string image, string content, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {

        tbNew insert = new tbNew();
        insert.news_title = news_title;
        insert.news_image = image;
        insert.news_summary = news_summary;
        insert.news_content = content;
        insert.active = true;
        insert.newcate_id = 1;
        insert.news_datetime = DateTime.Now;
        if (SEO_KEYWORD != "")
        {
            insert.meta_keywords = SEO_KEYWORD;
        }
        else
        {
            insert.meta_keywords = news_title + " , " + cls_ToAscii.ToAscii(news_title.ToLower());
        }
        if (SEO_TITLE != "")
        {
            insert.meta_title = SEO_TITLE;
        }
        else
        {
            insert.meta_title = news_title + " | " + cls_ToAscii.ToAscii(news_title.ToLower());
        }
        if (SEO_DEP != "")
        {
            insert.meta_description = SEO_DEP;
        }
        else
        {
            insert.meta_description = news_title + " | " + cls_ToAscii.ToAscii(news_title.ToLower());
        }
        if (SEO_LINK != "")
        {
            insert.link_seo = SEO_LINK;
        }
        else
        {
            insert.link_seo = "tin-tuc/" + cls_ToAscii.ToAscii(news_title.ToLower()) + "-" + insert.news_id;
        }
        insert.seo_image = SEO_IMAGE;
        db.tbNews.InsertOnSubmit(insert);
        db.SubmitChanges();
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
    public bool Linq_Sua(int news_id, string title, string summary, string images, string content, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {
        tbNew update = db.tbNews.Where(x => x.news_id == news_id).FirstOrDefault();
        update.news_title = title;
        if (images != null)
            update.news_image = images;
        update.news_summary = summary;
        update.news_content = content;
        if (SEO_KEYWORD != "")
        {
            update.meta_keywords = SEO_KEYWORD;
        }
        else
        {
            update.meta_keywords = title + " , " + cls_ToAscii.ToAscii(title.ToLower());
        }
        if (SEO_TITLE != "")
        {
            update.meta_title = SEO_TITLE;
        }
        else
        {
            update.meta_title = title + " | " + cls_ToAscii.ToAscii(title.ToLower());
        }
        if (SEO_DEP != "")
        {
            update.meta_description = SEO_DEP;
        }
        else
        {
            update.meta_description = title + " | " + cls_ToAscii.ToAscii(title.ToLower());
        }
        if (SEO_LINK != "")
        {
            update.link_seo = SEO_LINK;
        }
        else
        {
            update.link_seo = "tin-tuc/" + cls_ToAscii.ToAscii(title.ToLower()) + "-" + update.news_id;
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
    public bool Linq_Xoa(int news_id)
    {
        tbNew delete = db.tbNews.Where(x => x.news_id == news_id).FirstOrDefault();
        db.tbNews.DeleteOnSubmit(delete);
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