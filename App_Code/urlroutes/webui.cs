using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for webui
/// </summary>
public class webui
{
	public webui()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        //Home
        list.Add("webTrangChu|home|~/Default.aspx");
        // Introduce
        list.Add("webabout|about|~/web_module/web_About.aspx");
        // thựcđon
        list.Add("thucdon|menu|~/web_module/web_Menu.aspx");
        // tin tức
        list.Add("webnews|news|~/web_module/web_News.aspx");
        //tintuctitiet
        list.Add("webnewsdetail|news/{name}-{id}|~/web_module/web_NewsDetail.aspx");
        // Liên hệ
        list.Add("weblienhe|contact|~/web_module/web_Contact.aspx");
        // Khuyến mãi sale
        list.Add("websale|sale|~/web_module/web_KhuyenMai.aspx");
        // Khuyến mãi detail sale
        list.Add("websaledetail|sale/{name}-{id}|~/web_module/web_KhuyenMaiDetail.aspx");
        // Collection image
        list.Add("webcollection|collection|~/web_module/web_Gallary.aspx");
        // He thong
        list.Add("webhethong|agency|~/web_module/web_Agency.aspx");
        // He thong map
        list.Add("webhethongmap|map|~/web_module/web_AgencyBB.aspx");
        //About
        list.Add("webv|map|~/web_module/web_AgencyBB.aspx");
        return list;
    }
}