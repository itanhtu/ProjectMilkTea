using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_NewsDetail : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        int _id = Convert.ToInt32(RouteData.Values["id"]);
        header.TinTucChiTiet = _id;
        rpNewsDetail.DataSource = (from nd in db.tbNews
                                   where nd.news_id == _id
                                   select nd);
        rpNewsDetail.DataBind();
    }
}