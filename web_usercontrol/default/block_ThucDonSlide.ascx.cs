using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_block_ThucDonSlide : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        var getData = (from tb in db.tbProducts
                       join c in db.tbProductCates on tb.productcate_id equals c.productcate_id
                       where tb.product_show == true
                      orderby tb.product_show ascending, tb.product_id descending
                      select new
                      {
                          tb.product_id,
                          tb.product_title,
                          tb.product_summary,
                          tb.product_price,
                          tb.product_content,
                          tb.product_image,
                          tb.product_position,
                      }).Take(10);
        rpSildeMenu.DataSource = getData;
        rpSildeMenu.DataBind();
        }

        
}