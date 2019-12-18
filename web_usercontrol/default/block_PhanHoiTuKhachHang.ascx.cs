using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_block_PhanHoiTuKhachHang : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        var customer = from cus in db.tbCustomerFeedbacks
                       where cus.customer_active==true
                       
                       select new
                       {
                           cus.customer_id,
                           cus.customer_name,
                           //cus.customer_title,
                           cus.customer_image,
                           cus.customer_content,
                       };
        rpPHTKH.DataSource = customer;
        rpPHTKH.DataBind();
        }

        
}