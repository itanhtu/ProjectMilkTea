<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="web_NewsDetail.aspx.cs" Inherits="web_module_web_NewsDetail" %>

<%@ Register TagPrefix="UControl" TagName="header" Src="~/web_usercontrol/global_header.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <UControl:header ID="header" runat="server" />
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
    <div class="main-part">
        <!-- Start Breadcrumb Part -->
        <section class="breadcrumb-part" data-stellar-offset-parent="true" data-stellar-background-ratio="0.5" style="background-image: url('/images/slider3.jpg');">
            <div class="container">
                <div class="breadcrumb-inner">
                    <h2>Tin tức</h2>
                    <a href="/">Trang chủ</a>
                    <span>Tin tức</span>
                </div>
            </div>
        </section>
        <!-- End Breadcrumb Part -->
        <section class="home-icon blog-main-section blog-single">
            <div class="icon-default">
                <img src="/images/scroll-arrow.png" alt="">
            </div>
            <asp:Repeater runat="server" ID="rpNewsDetail">
                <ItemTemplate>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                                <div class="blog-right-section">
                                    <div class="blog-right-listing wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                                        <div class="feature-img">
                                            <%--<img src="<%#Eval("news_image") %>" alt=""> --%>
                                            <%-- <div class="date-feature">
                                                27
                                                <br> <small>may</small>
                                            </div>--%>
                                        </div>
                                        <div class="feature-info">
                                            <h2><%#Eval("news_title") %></h2>
                                            <span><%#Eval("news_datetime") %></span>

                                            <div class="editor-container">
                                                <p><%#Eval("news_content") %></p>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" runat="Server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>

