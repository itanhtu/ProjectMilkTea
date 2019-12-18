using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_KhuyenMai : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    int currentPage = 1;
    //int pageSize = 4;
    int startPage, endPage;
    int maxPages = 100;
    private int PageSize = 10;
    int RecordCount = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GetNewsPageWise(1);
        }
        //rpNews.DataSource = (from n in db.tbNews select n);
        //rpNews.DataBind();
    }
    private void GetNewsPageWise(int pageIndex)
    {
        string constring = ConfigurationManager.ConnectionStrings["admin_TrasuaConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("GetSalePageWise", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                cmd.Parameters.AddWithValue("@PageSize", PageSize);
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int, RecordCount);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                con.Open();
                IDataReader idr = cmd.ExecuteReader();
                rpSale.DataSource = idr;
                rpSale.DataBind();
                idr.Close();
                con.Close();
                int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                this.PopulatePager(recordCount, pageIndex);
            }
        }
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / (decimal)PageSize);
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            if (currentPage != 1)
            {
                //pages.Add(new ListItem("<<", "1", currentPage > 1));
                pages.Add(new ListItem("<< Previous", (currentPage - 1).ToString()));
            }
            if (pageCount < RecordCount)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            else if (currentPage < RecordCount)
            {
                for (int i = 1; i <= RecordCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("...", (currentPage).ToString(), true));
            }
            else if (currentPage > pageCount - RecordCount)
            {
                pages.Add(new ListItem("...", (currentPage).ToString(), true));
                for (int i = currentPage - 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            else
            {
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
                for (int i = currentPage - 2; i <= currentPage + 2; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("...", (currentPage).ToString(), false));
            }
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("next >>", (currentPage + 1).ToString()));
                //pages.Add(new ListItem("", pageCount.ToString(), currentPage < pageCount));

            }
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetNewsPageWise(pageIndex);
    }
}