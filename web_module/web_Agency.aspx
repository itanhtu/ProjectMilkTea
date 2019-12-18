<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="web_Agency.aspx.cs" Inherits="web_module_web_Agency" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
  <title>B&B | COFFEE AND MILK TEA</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="keywords" content="<%#Eval("keywords")%>" />
    <meta name="description" content="<%#Eval("description")%>" />
    <link rel="canonical" href="<%#Eval("linkTungTrang")%>" />
    <meta property="og:locale" content="vi_VN" />
    <meta property="og:type" content="website" />
    <meta property="og:title" content="<%#Eval("title_Google")%>" />
    <meta property="og:description" content="<%#Eval("description")%>" />
    <meta property="og:url" content="<%#Eval("linkTungTrang")%>" />
    <meta property="og:site_name" content="<%#Eval("linkTungTrang")%>" />
    <link rel="alternate" href="<%#Eval("linkTungTrang")%>" hreflang="vi-vn" />
    <meta name="ROBOTS" content="index, follow" />
    <!-- /SEO google plus -->
    <meta itemprop="name" content="<%#Eval("title_Google")%>" />
    <meta itemprop="description" content="<%#Eval("description")%>" />
    <meta itemprop="image" content="<%#Eval("image")%>" />
    <!-- /SEO google plus -->
    <meta name="ROBOTS" content="index, follow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="higlobal" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hislider" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibelowtop" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hibodyhead" runat="Server">
    <%-- Hệ thống cửa hàng --%>
    <section id="address" class="special-menu  home-icon wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
        <div class="icon-default icon-skeen icon-skeen2">
           

        </div>
        <div class="container">
            <div class="build-title">
                <h2>Hệ thống B&B</h2>
                <h6>Vào những khoảnh khắc đẹp nhất của tuổi trẻ đều có sự đồng hành của B&B</h6>
            </div>
            <div class="div-select">
                <div class="branch-agency">
                    <h4>&nbsp;</h4>
                </div>
               <%-- <a class="show-map" href="~/../../agency-map">
                    <label>Hiển thị bản đồ&nbsp;:&nbsp; </label>
                    <i class="fa fa-toggle-off"></i>
                </a>--%>
            </div>
            <div class="menu-wrapper">
                <div class="portfolioFilter">
                    <div class="portfolioFilter-inner">
                        <a href="javascript:;" data-filter="*" class="current">TẤT CẢ</a>
                        <asp:Repeater runat="server" ID="rpResCate">
                            <ItemTemplate>
                                <a href="javascript:;" data-filter=".<%#cls_ToAscii.ToAscii(Eval("city_name").ToString()) %>"><%#Eval("city_name") %></a>
                            </ItemTemplate>

                        </asp:Repeater>
                        <%-- <a href="javascript:;" data-filter=".Hue">Huế </a>
                    <a href="javascript:;" data-filter=".QuangNam">Quảng Nam</a>
                    <a href="javascript:;" data-filter=".QuangBinh">Quảng Bình</a>--%>
                    </div>
                </div>
                <div class="portfolioContainer row">
                    <asp:Repeater ID="rpRestaurant" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 col-sm-6 col-xs-12 isotope-item <%#cls_ToAscii.ToAscii(Eval("active").ToString()) %>">
                            <div class="menu-list-2 ">
                                <a class="popup-modal" href="#<%#Eval("restaurant_id") %>">
                                    <img src="<%#Eval("restaurant_image")%>" alt="" />
                                </a>
                                <%--<a href="#" data-toggle="modal" data-target="#DaNang">Đà Nẳng</a>--%>
                                <h5><a class="popup-modal" href="#<%#Eval("restaurant_id") %>"><%#Eval("restaurant_name") %> </a></h5>
                                <p><%#Eval("restaurant_address") %></p>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

                </div>
            </div>

        </div>
        <div class="float-main">
            <div class="icon-top-left">
                <img src="/images/icon7.png" alt="">
            </div>
            <div class="icon-bottom-left">
                <img src="/images/icon8.png" alt="">
            </div>
            <div class="icon-top-right">
                <img src="/images/icon9.png" alt="">
            </div>
            <div class="icon-bottom-right">
                <img src="/images/icon10.png" alt="">
            </div>
        </div>
        <asp:Repeater ID="rpPopup" runat="server">
        <ItemTemplate>
            <div id="<%#Eval("restaurant_id") %>" class="mfp-hide white-popup-block">
                <div class="row">
                    <div class="modal-box-left col-lg-6 col-md-6  ">
                        <h4><%#Eval("restaurant_name") %></h4>
                        <p><%#Eval("restaurant_addressname") %></p>
                        <a class="btn-open-map" target="_blank" href="<%#Eval("restaurant_map") %>">ĐẾN CỬA HÀNG </a>
                    </div>
                    <div class="col-lg-6 col-md-6 ">
                        <img src="<%#Eval("restaurant_image") %>" />
                        <button class="popup-modal-dismiss "></button>
                    </div>
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>
    </section>
    
  
    <%-- EnD Hệ thống cửa hàng --%>
    <%-- <div id="PopupControl" class="popup"  style="width: 300px; height: 300px; margin: 0; display:none; background:red;">
        <div class="col-6">
            <div class="col-6 form-group">
                <div class="col-12">
                    <h3 id="txtaddress" runat="server"><%#Eval("restaurant_address") %></h3>
                </div>
                <div class="col-12">
                    <h5 id="txtaddress1" runat="server"><%#Eval("restaurant_address") %></h5>
                </div>
            </div>
        </div>
        <div class="col-6">
            <div class="col-12 form-group">
                <div class="col-12">
                    <img src="../images/tt1.jpg" />
                </div>

            </div>
        </div>
    </div>--%>
   
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" runat="Server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>

