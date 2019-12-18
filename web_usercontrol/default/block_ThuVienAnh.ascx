<%@ Control Language="C#" AutoEventWireup="true" CodeFile="block_ThuVienAnh.ascx.cs" Inherits="usercontrol_block_ThuVienAnh" %>

<section id="photos" class="instagram-main bg-skeen2 home-icon wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
    <style>
        .mfp-counter {
            display: none;
        }
    </style>
    <div class="icon-default icon-skeen2">
        <a href="#photos" class="clickid">
            <img src="/images/icon23.png" alt="">
        </a>
    </div>
    <div class="container">
        <div class="build-title">
            <h2>Thư Viện Ảnh</h2>
            <h6>Vào những khoảnh khắc đẹp nhất của tuổi trẻ đều có sự đồng hành của B&B</h6>
        </div>
        <div class="gallery-slider">
            <div class="owl-carousel owl-theme" data-items="4" data-laptop="4" data-tablet="2" data-mobile="1" data-margin="30" data-nav="true" data-dots="false" data-autoplay="true" data-speed="2000" data-autotime="3000">
                <asp:Repeater runat="server" ID="rpAlbumImages">
                    <ItemTemplate>
                        <div class="item">
                            <a href="<%#Eval("collection") %>" class="<%#Eval("magnific") %>">
                                <img src="<%#Eval("collection_avatar") %>" alt="" class="animated">
                                <div class="gallery-overlay">
                                    <div class="gallery-overlay-inner">
                                    </div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</section>
