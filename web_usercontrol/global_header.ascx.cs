using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_usercontrol_global_header : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    // seo giới thiệu
    private int _GioiThieu;
    public int GioiThieu
    {
        get
        {
            return GioiThieu;
        }
        set
        {
            _GioiThieu = value;
        }
    }
    // Nhóm trước loại 
    private int _NhomSanPham;
    public int NhomSanPham
    {
        get
        {
            return NhomSanPham;
        }
        set
        {
            _NhomSanPham = value;
        }
    }
    // Loại sản phẩm 
    private int _LoaiSanPham;
    public int LoaiSanPham
    {
        get
        {
            return LoaiSanPham;
        }
        set
        {
            _LoaiSanPham = value;
        }
    }
    // Sản phẩm
    private int _SanPham;
    public int SanPham
    {
        get
        {
            return SanPham;
        }
        set
        {
            _SanPham = value;
        }
    }
    //private int _NhomTinTuc;
    //public int NhomTinTuc
    //{
    //    get
    //    {
    //        return NhomTinTuc;
    //    }
    //    set
    //    {
    //        _NhomTinTuc = value;
    //    }
    //}
    private int _TinTucChiTiet;
    public int TinTucChiTiet
    {
        get
        {
            return TinTucChiTiet;
        }
        set
        {
            _TinTucChiTiet = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Giới thiệu
        //if (_GioiThieu != 0)
        //{
        //    rpHeader.DataSource = from pr in db.tbHomeIntros
        //                          where pr.intro_id == 1
        //                          select new
        //                          {
        //                              keywords = pr.meta_keywords,
        //                              description = pr.meta_description,
        //                              linkTungTrang = pr.link_seo,
        //                              title_Google = pr.meta_title,
        //                              description_Google = pr.meta_description,
        //                              summary_Google = pr.meta_description,
        //                              seo_image = pr.meta_image
        //                          };
        //    rpHeader.DataBind();
        //}
        // Nhóm sản phẩm
        if (_NhomSanPham != 0)
        {

            rpHeader.DataSource = from pr in db.tbProductCates
                                  where pr.productcate_id == _NhomSanPham
                                  select new
                                  {
                                      keywords = pr.meta_keywords,
                                      description = pr.meta_description,
                                      linkTungTrang = pr.link_seo,
                                      title_Google = pr.meta_title,
                                      description_Google = pr.meta_description,
                                      summary_Google = pr.meta_description,
                                      seo_image = pr.meta_image
                                  };
            rpHeader.DataBind();
        }
        // Loại sản phẩm
        if (_LoaiSanPham != 0)
        {

            rpHeader.DataSource = from pr in db.tbProductCates
                                  where pr.productcate_id == _LoaiSanPham
                                  select new
                                  {
                                      keywords = pr.meta_keywords,
                                      description = pr.meta_description,
                                      linkTungTrang = pr.link_seo,
                                      title_Google = pr.meta_title,
                                      description_Google = pr.meta_description,
                                      summary_Google = pr.meta_description,
                                      seo_image = pr.meta_image
                                  };
            rpHeader.DataBind();
        }
        // Sản phẩm 
        if (_SanPham != 0)
        {
            rpHeader.DataSource = from pr in db.tbProducts
                                  where pr.product_id == _SanPham
                                  select new
                                  {
                                      keywords = pr.meta_keywords,
                                      description = pr.meta_description,
                                      linkTungTrang = pr.link_seo,
                                      title_Google = pr.meta_title,
                                      description_Google = pr.meta_description,
                                      summary_Google = pr.meta_description,
                                      seo_image = pr.meta_image

                                  };
            rpHeader.DataBind();
        }
        //if (_NhomTinTuc != 0)
        //{

        //    rpHeader.DataSource = from pr in db.tbNewCates
        //                          where pr.newcate_id == _NhomTinTuc
        //                          select new
        //                          {
        //                              keywords = pr.meta_keywords,
        //                              description = pr.meta_description,
        //                              linkTungTrang = pr.link_seo,
        //                              title_Google = pr.meta_title,
        //                              description_Google = pr.meta_description,
        //                              summary_Google = pr.meta_description,
        //                          };
        //    rpHeader.DataBind();
        //}
        if (_TinTucChiTiet != 0)
        {

            rpHeader.DataSource = from pr in db.tbNews
                                  where pr.news_id == _TinTucChiTiet
                                  select new
                                  {
                                      keywords = pr.meta_keywords,
                                      description = pr.meta_description,
                                      linkTungTrang = pr.link_seo,
                                      title_Google = pr.meta_title,
                                      description_Google = pr.meta_description,
                                      summary_Google = pr.meta_description,
                                      image = pr.seo_image
                                  };
            rpHeader.DataBind();
        }

    }
}