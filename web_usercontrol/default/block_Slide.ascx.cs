using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_block_Slide : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        rpSlide.DataSource = from slide in db.tbSlides
                             where slide.hidden == true
                             select slide;
        rpSlide.DataBind();
        }

        
}