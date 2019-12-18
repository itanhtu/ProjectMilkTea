using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public string keywords, description, linkTungTrang, title_Google, image;
    protected void Page_Load(object sender, EventArgs e)
    {
        var getseo = (from seo in db.tbSEOs where seo.seo_id == 1 select seo).SingleOrDefault();
        title_Google = getseo.seo_title;
        keywords = getseo.seo_keyworld;
        description = getseo.seo_description;
        linkTungTrang = getseo.seo_link;
        image = getseo.seo_image;
    }
}