using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_block_VeChungToi : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        rp_Introdule.DataSource = from intro in db.tbIntroduces select intro;
        rp_Introdule.DataBind();
        }

        
}