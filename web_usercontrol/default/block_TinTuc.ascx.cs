using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_block_TinTuc : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        var getnew = from gn in db.tbNews
                     where gn.active == true
                     orderby gn.news_id descending
                     select gn;
        rp_News.DataSource = getnew;
        rp_News.DataBind();
        }

        
}