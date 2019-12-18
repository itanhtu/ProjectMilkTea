using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_Menu : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        rp_ProductCate.DataSource = from proc in db.tbProductCates select proc;
        rp_ProductCate.DataBind();
        
        rp_ProductTitle.DataSource = from proc in db.tbProductCates select proc;
        rp_ProductTitle.DataBind();

    }

    protected void rp_ProductTitle_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
        Repeater rp_Product = e.Item.FindControl("rp_Product") as Repeater;
        int lkh = int.Parse(DataBinder.Eval(e.Item.DataItem, "productcate_id").ToString());
        var pro = from p in db.tbProducts
                  //join pc in db.tbProductCates on p.productcate_id equals pc.productcate_id
                  where p.productcate_id == lkh
                  orderby p.product_id descending
                  select new
                  {
                      p.product_id,
                      p.product_image,
                      p.product_price,
                      p.product_title,
                      p.product_content,
                      p.link_seo
                      //active = pc.productcate_title
                  };
        rp_Product.DataSource = pro;
        rp_Product.DataBind();
    }
}