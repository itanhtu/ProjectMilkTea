<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/web_usercontrol/default/block_Slide.ascx" TagPrefix="uc1" TagName="Slide" %>
<%@ Register Src="~/web_usercontrol/default/block_VeChungToi.ascx" TagPrefix="uc1" TagName="VeChungToi" %>
<%@ Register Src="~/web_usercontrol/default/block_ThucDonSlide.ascx" TagPrefix="uc1" TagName="ThucDonSlide" %>
<%@ Register Src="~/web_usercontrol/default/block_HeThongCuaHang.ascx" TagPrefix="uc1" TagName="HeThongCuaHang" %>
<%@ Register Src="~/web_usercontrol/default/block_ThuVienAnh.ascx" TagPrefix="uc1" TagName="ThuVienAnh" %>
<%@ Register Src="~/web_usercontrol/default/block_PhanHoiTuKhachHang.ascx" TagPrefix="uc1" TagName="PhanHoiTuKhachHang" %>
<%@ Register Src="~/web_usercontrol/default/block_TinTuc.ascx" TagPrefix="uc1" TagName="TinTuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <title><%=title_Google%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="keywords" content="<%=keywords %>" />
    <meta name="description" content="<%=description%>" />
    <link rel="canonical" href="<%=linkTungTrang%>" />
    <meta property="og:locale" content="vi_VN" />
    <meta property="og:type" content="website" />
    <meta property="og:title" content="<%=title_Google%>" />
    <meta property="og:description" content="<%=description%>" />
    <meta property="og:url" content="<%=linkTungTrang%>" />
    <meta property="og:site_name" content="<%=linkTungTrang%>" />
    <link rel="alternate" href="<%=linkTungTrang%>" hreflang="vi-vn" />
    <meta name="ROBOTS" content="index, follow" />
    <!-- /SEO google plus -->
    <meta itemprop="name" content="<%=title_Google%>" />
    <meta itemprop="description" content="<%=description%>" />
    <meta itemprop="image" content="<%=image%>" />
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
    <%--slide--%>
    <uc1:Slide runat="server" ID="Slide" />
    <%--end slide--%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibelowtop" runat="Server">
    <%--về chúng tôi--%>
    <uc1:VeChungToi runat="server" ID="VeChungToi" />

    <%--end về chúng tôi--%>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hibodyhead" runat="Server">
    <%-- Thực đơn slide --%>
    <uc1:ThucDonSlide runat="server" ID="ThucDonSlide" />
    <%-- Thực đơn slide --%>

    <%-- Hệ thống cửa hàng --%>
    <uc1:HeThongCuaHang runat="server" ID="HeThongCuaHang" />
    <%--<div class="modal fade menu-list" id="DaNang" tabindex="-1" role="dialog" aria-labelledby="menu-list">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <div class="col-md-6 col-sm-6 col-xs-12 ">
                            <h3> 359 Tôn Đức Thắng</h3>
                            <div class="address">
                                <div class="address-text">
                                    359 Tôn Đức Thắng, Liên Chiểu, Đà Nẳng
                                </div>
                            </div>
                            <div class="button-address" >
                                <a href="#">Đến cửa hàng ngay</a>
                            </div>
                        </div>
                        
                    </div>
                         <div class="col-md-6 col-sm-6 col-xs-12">
                           <img src="images/cuahang.jpg" alt="" />
                        </div>   
                    
            </div>
        </div>
    </div>
    --%><%-- EnD Hệ thống cửa hàng --%>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <%-- Tin Tức --%>
    <uc1:TinTuc runat="server" ID="TinTuc" />
    <%--End Tin Tức --%>
    <%-- Thư viện ảnh --%>
    <uc1:ThuVienAnh runat="server" ID="ThuVienAnh" />
    <%-- End Thư viện ảnh --%>

    <%-- Đánh giá từ khách hàng --%>
    <uc1:PhanHoiTuKhachHang runat="server" ID="PhanHoiTuKhachHang" />
    <%-- end Đánh giá từ khách hàng --%>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>

