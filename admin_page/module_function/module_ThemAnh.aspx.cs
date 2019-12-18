using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThemAnh : System.Web.UI.Page
{
    cls_Alert cls_Alert = new cls_Alert();
    dbcsdlDataContext db = new dbcsdlDataContext();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void loadData()
    {
        Response.Redirect("/admin-thu-vien-anh");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        ctl_newbuilding insert = new ctl_newbuilding();
        String folderUser = Server.MapPath("~/uploadimages/thuvienanh/");
        if (!Directory.Exists(folderUser))
        {
            Directory.CreateDirectory(folderUser);
        }
        string filename;
        string ulr = "/uploadimages/thuvienanh/";
        HttpFileCollection hfc = Request.Files;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                //string filename = Path.GetRandomFileName() + Path.GetExtension(FileUpload1.FileName);
                //filename = ulr + System.IO.Path.GetFileName(cls_ToAscii.ToAscii(hpf.FileName).ToLower());
                filename = ulr + Path.GetRandomFileName() + Path.GetExtension(hpf.FileName);
                string path = HttpContext.Current.Server.MapPath("~/" + filename);
                hpf.SaveAs(path);
                VaryQualityLevel(System.Drawing.Image.FromStream(hpf.InputStream), path);
                insert.InsertImageOneProduct(filename);
            }
        }
        rpImageListing.DataSource = from i in db.tbCollectionImages select i;
        rpImageListing.DataBind();
        foreach (RepeaterItem item in rpImageListing.Items)
        {
            HtmlGenericControl control = item.FindControl("divSub") as HtmlGenericControl;
            if (control != null)
            {
                //set the control value here.
            }
        }
        //divMes.InnerHtml = mes;
        //Session["re_id"] = null;
        cls_Alert.alert_Success(Page, "Đã lưu thành công", "");
        loadData();

    }
    private void SaveResizeImage(System.Drawing.Image img, int width, int height, string path)
    {
        try
        {
            int resizedW = width;
            int resizedH = height;
            Bitmap b = new Bitmap(resizedW, resizedH);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.DrawImage(img, 0, 0, resizedW, resizedH);

            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            g.Dispose();
            b.Save(path, jpgEncoder, myEncoderParameters);
        }
        catch
        {
        }
    }
    private void VaryQualityLevel(System.Drawing.Image img, string path)
    {
        using (Bitmap bmp1 = new Bitmap(img))
        {
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(path, jpgEncoder, myEncoderParameters);
        }
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }
    protected void btnXoaImage_ServerClick(object sender, EventArgs e)
    {
        tbCollectionImage del = (from i in db.tbCollectionImages where i.collection_id == Convert.ToInt32(txtImage.Value) select i).SingleOrDefault();
        db.tbCollectionImages.DeleteOnSubmit(del);
        db.SubmitChanges();
        rpImageListing.DataSource = from i in db.tbCollectionImages select i;
        rpImageListing.DataBind();
    }
}