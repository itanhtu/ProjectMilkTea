using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_ThemVideo
/// </summary>
public class cls_ThemVideo
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_ThemVideo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Video_them(string link, string image)
    {
        tbCollectionImage insert = new tbCollectionImage();
        insert.collection_youtube = link;
        insert.collection_avatar = image;
        db.tbCollectionImages.InsertOnSubmit(insert);
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