using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ctl_newbuilding
/// </summary>
public class ctl_newbuilding
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public ctl_newbuilding()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // one product
    public bool InsertImageOneProduct(string image)
    {
        tbCollectionImage insert = new tbCollectionImage();
        insert.collection_image = image;
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
    //xóa image
    //public bool Image_xoa(int image_id)
    //{
    //    tbCollectionImage delete = db.tbCollectionImages.Where(x => x.collection_id == image_id).FirstOrDefault();
    //    db.tbCollectionImages.DeleteOnSubmit(delete);
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
    //thêm video
    //public bool Video_them(string link, string image)
    //{
    //    tbCollectionImage insert = new tbCollectionImage();
    //    insert.collection_youtube = link;
    //    insert.collection_avatar = image;
    //    db.tbCollectionImages.InsertOnSubmit(insert);
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
    //sửa image
    public bool Linq_suaimage(int collection_id, string image)
    {
        tbCollectionImage update = db.tbCollectionImages.Where(x => x.collection_id == collection_id).FirstOrDefault();
        if (image != null)
        {
            update.collection_image = image;
            update.collection_avatar = image;
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
    public bool Linq_suavideo(int collection_id, string link, string image)
    {
        tbCollectionImage update = db.tbCollectionImages.Where(x => x.collection_id == collection_id).FirstOrDefault();
        if (link!=null)
        {
            update.collection_youtube = link;
        }
        //else
        //{
        //    update.collection_youtube = link;
        //}
        if (image != null)
        {
            update.collection_image = image;
            update.collection_avatar = image;
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
    public bool Linq_xoa(int collection_id)
    {
        tbCollectionImage delete = db.tbCollectionImages.Where(x => x.collection_id == collection_id).FirstOrDefault();
        db.tbCollectionImages.DeleteOnSubmit(delete);
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