<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="web_KhuyenMai.aspx.cs" Inherits="web_module_web_KhuyenMai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
      <style type="text/css">
        .gallery-pagination-inner a{
            height:52px;
            line-height:50px;
        }
        .page_enabled, .page_disabled {
            width: auto;
            display: inline;
            padding: 1.5rem;
            text-transform: uppercase;
            -webkit-border-radius: 2rem;
            -moz-border-radius: 30px;
            -o-border-radius: 30px;
            border-radius: 5rem;
            border: 2px solid #f4f2ed;
        }

        .page_enabled {
            background-color: #fff;
            color: #20202f;
        }
        .page_disabled {
            background-color: #20202f;
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="higlobal" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hislider" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibelowtop" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hibodyhead" Runat="Server">
    <div class="main-part">
                    <!-- Start Breadcrumb Part -->
                    <section class="breadcrumb-part" data-stellar-offset-parent="true" data-stellar-background-ratio="0.5" style="background-image: url('/images/slider3.jpg')  ;">
                        <div class="container">
                            <div class="breadcrumb-inner">
                                <h2>KHUYẾN MÃI</h2>
                                <a href="/Default.aspx">Trang chủ</a>
                                <span>Khuyến mãi</span>
                            </div>
                        </div>
                    </section>
                    <!-- End Breadcrumb Part -->
                    <!-- Start Blog List -->
                     <section class="home-icon blog-main-section text-center blog-main-2col wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
            <div class="icon-default">
                <img src="/images/scroll-arrow.png" alt="" />
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="blog-right-section">
                            <div class="row">
                                <asp:Repeater runat="server" ID="rpSale">
                                    <ItemTemplate>
                                        <div class="col-md-6 col-sm-6 col-xs-12 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                                            <div class="blog-right-listing">
                                                <div class="feature-img">
                                                    <img src="<%#Eval("sale_image") %>" alt="">
                                                    <%--<div class="date-feature">
                                                            27
                                                            <br> <small>may</small>
                                                        </div>--%>
                                                </div>
                                                <div class="feature-info">
                                                    <span><i class="icon-user"></i>Của B&B</span>
                                                  
                                                    <h5><%#Eval("sale_title") %></h5>
                                                    <p><%#Eval("sale_summary") %></p>
                                                    <a href="sale/<%#cls_ToAscii.ToAscii(Eval("sale_title").ToString()) %>-<%#Eval("sale_id") %>" class="button-default">Xem thêm <i class="icon-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                           
                            <div class="gallery-pagination">
                                <div class="gallery-pagination-inner">
                                    <asp:Repeater ID="rptPager" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                             <%-- <div class="gallery-pagination">
                                <div class="gallery-pagination-inner">
                                    <ul>
                                        <li><a href="#" class="pagination-prev"><i class="icon-left"></i><span>PREV page</span></a></li>
                                        <li class="active"><a href="#"><span>1</span></a></li>
                                        <li><a href="#"><span>2</span></a></li>
                                        <li><a href="#"><span>3</span></a></li>
                                        <li><a href="#" class="pagination-next"><span>next page</span> <i class="icon-right"></i></a></li>
                                    </ul>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </section>
                    <!-- End Blog List -->
                </div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" Runat="Server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" Runat="Server">
</asp:Content>

