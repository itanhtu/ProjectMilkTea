using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_About : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public string keywords, description, linkTungTrang, title_Google, image;
    protected void Page_Load(object sender, EventArgs e)
    {
        var getIntro = (from ab in db.tbIntroduces
                       select new
                       {
                           ab.introduct_id,
                           ab.introduce_title,
                           ab.introduce_title1,
                           ab.introduce_content,
                           ab.introduce_image,
                           ab.introduce_dateup,
                           ab.seo_description,
                           ab.seo_image,
                           ab.seo_keyworld,ab.seo_link,
                           ab.seo_title
                       }).SingleOrDefault();
        title_Google = getIntro.seo_title;
        keywords = getIntro.seo_keyworld;
        description = getIntro.seo_description;
        linkTungTrang = getIntro.seo_link;
        image = getIntro.seo_image;
        rpAbout.DataSource = from ab in db.tbIntroduces select ab;
        rpAbout.DataBind();
    }
}
