using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_Gallary : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        rp_Collection.DataSource = from col in db.tbCollectionImages orderby col.collection_id descending select col;
        rp_Collection.DataBind();
    }
}