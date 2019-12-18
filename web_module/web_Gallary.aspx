<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="web_Gallary.aspx.cs" Inherits="web_module_web_Gallary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
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
    <section id="instagram" class="instagram-main bg-skeen home-icon wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                    <div class="icon-default icon-skeen">
                        <img src="/images/icon23.png" alt="">
                    </div>
                    <div class="container">
                        <div class="build-title">
                            <h2>Thư Viện Ảnh</h2>
                            <h6>Vào những khoảnh khắc đẹp nhất của tuổi trẻ đều có sự đồng hành của B&B</h6>
                        </div>
                    </div>
                    <div class="gallery-slider-img">
                        <asp:Repeater runat="server" ID="rp_Collection">
                            <ItemTemplate>
                                <div class=" col-lg-3 col-md-3 col-sm-4 col-xs-6">
                                <a href="<%#Eval("collection_image") %>" class="magnific-popup">
                                    <img src="<%#Eval("collection_image") %>" alt="">
                                    
                                </a>
                            </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                </section>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" Runat="Server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" Runat="Server">
</asp:Content>

