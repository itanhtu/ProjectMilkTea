using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminmodule
/// </summary>
public class adminmodule
{
	public adminmodule()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        //Module SEO
        list.Add("moduleseo|admin-seo|~/admin_page/module_function/module_SEO.aspx");
        //Module Language
        list.Add("modulelanguage|admin-ngon-ngu|~/admin_page/module_function/admin_LanguagePage.aspx");
        //Quản lý websit
        list.Add("moduleslide|admin-slide|~/admin_page/module_function/module_Slide.aspx");
        list.Add("moduleintroduce|admin-introduce|~/admin_page/module_function/module_Introduce.aspx");
        list.Add("modulelienhe|admin-lienhe|~/admin_page/module_function/module_LienHe.aspx");
        list.Add("modulecustumer|admin-customer|~/admin_page/module_function/module_Custumer.aspx");
        list.Add("modulerestaurant|admin-restaurant|~/admin_page/module_function/module_Restaurant.aspx");
        list.Add("modulephanhoi|admin-thu-phan-hoi|~/admin_page/module_function/module_ThuPhanHoi.aspx");
        list.Add("modulemangxahoi|admin-net-work|~/admin_page/module_function/module_MXH.aspx");
        list.Add("modulegiomocua|admin-open-times|~/admin_page/module_function/module_OpenTimes.aspx");
        list.Add("modulethongbao|admin-thong-bao|~/admin_page/module_function/module_DangKy.aspx");
        //list.Add("moduleaccount|admin-accounths|~/admin_page/module_function/module_Account.aspx");
        //Quản lý sản phẩm
        list.Add("moduleproduct|admin-product|~/admin_page/module_function/module_Product.aspx");
        list.Add("moduleproductcate|admin-product-cate|~/admin_page/module_function/module_ProductCate.aspx");
        //tin tức
        list.Add("modulenew|admin-new|~/admin_page/module_function/module_New.aspx");
        //Khuyến mãi
        list.Add("modulesale|admin-sale|~/admin_page/module_function/module_Sale.aspx");
        // thư viện ảnh
        list.Add("modulethuvienanh|admin-thu-vien-anh|~/admin_page/module_function/module_ThuVienAnh.aspx");
        list.Add("modulecity|admin-thanh-pho|~/admin_page/module_function/module_City.aspx");
        list.Add("modulethemanh|admin-them-anh|~/admin_page/module_function/module_ThemAnh.aspx");
        return list;

    }
}