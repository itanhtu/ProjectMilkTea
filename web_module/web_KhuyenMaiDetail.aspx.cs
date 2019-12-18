using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_KhuyenMaiDetail : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        rpKMdetail.DataSource = (from nd in db.tbSales
                                   where nd.sale_id == Convert.ToInt32(RouteData.Values["id"])
                                   select nd);
        rpKMdetail.DataBind();
    }
}