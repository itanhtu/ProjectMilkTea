<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="web_Contact.aspx.cs" Inherits="web_module_web_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script src="../admin_js/sweetalert.min.js"></script>
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
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibelowtop" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hibodyhead" runat="Server">
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false; return true;
        };
    </script>
    <div class="main-part">
        <%--<section class="contact-map">
            <div class="map-outer">
                <div id="map"></div>
            </div>
        </section>--%>
        <!-- Start Contact Part -->
        <section class="default-section contact-part home-icon">
           
            <div class="container">
                <div class="title text-center">
                    <h2 class="text-coffee">Liên Hệ</h2>
                    <%--<h6 class="heade-xs">We are a second-generation family business established in 1972</h6>--%>
                </div>
                <div class="row">
                    <asp:Repeater ID="rpContact" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 col-sm-4 col-xs-12 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                                <div class="contact-blog-row">
                                    <div class="contact-icon">
                                        <img src="/images/location-icon.png" alt="">
                                    </div>
                                    <p><%#Eval("lienhe_address")%></p>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                                <div class="contact-blog-row">
                                    <div class="contact-icon">
                                        <img src="/images/cell-icon.png" alt="">
                                    </div>
                                    <p><a href="tel:<%#Eval("lienhe_phone")%>"><%#Eval("lienhe_phone")%></a></p>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                                <div class="contact-blog-row">
                                    <div class="contact-icon">
                                        <img src="/images/mail-icon.png" alt="">
                                    </div>
                                    <p><a href="mailto:<%#Eval("lienhe_email")%>"><%#Eval("lienhe_email")%></a></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="row">
                    <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1 col-xs-12 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                        <h5 class="text-coffee">Để lại lời nhắn</h5>
                        <p></p>
                        <form class="form" method="post" name="contact-form">
                            <div class="row">
                                <div class="alert-container"></div>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <label>Họ và tên *</label>
                                    <input id="txtHoten" runat="server" name="first_name" type="text" />
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <label>Điện thoại *</label>
                                    <input id="txtPhone" runat="server" name="last_name" type="text" onkeypress="return isNumberKey(event)" />
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <label>Email *</label>
                                    <input id="txtEmail" runat="server" name="email" type="email" />
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <label>Nội dung *</label>
                                    <input id="txtSubject" runat="server" name="subject" type="text" />
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <label>Lời nhắn *</label>
                                    <textarea id="txtLoinhan" runat="server" name="message"></textarea>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                                    <%--<input id="btnGui" runat="server" name="submit" value="GỬI LỜI NHẮN" class="btn-black pull-right send_message" type="submit"/>--%>
                                    <button id="btnGui" runat="server" name="submit" type="submit" class="btn-black send_message" onserverclick="btnGui_ServerClick">GỬI LỜI NHẮN</button>
                                </div>
                            </div>
                        </form>
                    </div>
                    <%--<div class="col-md-4 col-sm-4 col-xs-12 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                        <h5 class="text-coffee">Giờ mở cửa</h5>
                        <asp:Repeater ID="rpOpenTime" runat="server">
                            <ItemTemplate>
                                <ul class="time-list">
                                    <li><span class="week-name"><%#Eval("open_day")%></span> <span><%#Eval("opentime")%></span></li>
                                  
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>--%>
                </div>
            </div>
        </section>
        <!-- End Contact Part -->
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

