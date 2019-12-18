using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_block_ThuVienAnh : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        rpAlbumImages.DataSource = (from img in db.tbCollectionImages
                                        orderby img.collection_id descending
                                        select new
                                        {
                                            img.collection_id,
                                            img.collection_image,
                                            img.collection_youtube,
                                            img.collection_avatar,
                                            magnific = img.collection_youtube == null || img.collection_youtube =="" ? "magnific-popup" : "magnific-youtube",
                                            collection = img.collection_youtube == null || img.collection_youtube == "" ? img.collection_image : img.collection_youtube
                                        });
        rpAlbumImages.DataBind();
    }

        
}