<%@ Control Language="C#" AutoEventWireup="true" CodeFile="block_TinTuc.ascx.cs" Inherits="usercontrol_block_TinTuc" %>

<section id="news" class="feature-blog-wrap bg-skeen home-icon wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
    <div class="icon-default icon-skeen">
        <a href="#news" class="clickid">
            <img src="/images/icon20.png" alt="">
        </a>

    </div>
    <div class="container">
        <div class="build-title">
            <h2>Tin Tức</h2>
            <h6>Tin Tức Mới & Sự Kiện</h6>
        </div>
        <div class="feature-blog">
            <div class="owl-carousel owl-theme" data-items="3" data-laptop="3" data-tablet="2" data-margin="30" data-mobile="1" data-nav="true" data-dots="false" data-autoplay="true" data-speed="1800" data-autotime="5000">
                <asp:Repeater runat="server" ID="rp_News">
                    <ItemTemplate>
                        <div class="item">
                            <div class="feature-img">
                                <a href="../news/<%#cls_ToAscii.ToAscii(Eval("news_title").ToString()) %>-<%#Eval("news_id") %>">
                                    <img src="<%#Eval("news_image") %>" alt="">
                                </a>
                                <!--<div class="date-feature">
                                            27
                                            <br> <small>may</small>
                                        </div>-->
                            </div>
                            <div class="feature-info">
                                <span><%#Eval("news_datetime") %></span>
                                <%--<span><i class="icon-comment"></i>5 Bình Luận</span>--%>
                                <a href="../news/<%#cls_ToAscii.ToAscii(Eval("news_title").ToString()) %>-<%#Eval("news_id") %>">
                                    <h5><%#Eval("news_title") %></h5>
                                </a>
                                <p>
                                    <%#Eval("news_summary") %>
                                </p>

                                <a href="../news/<%#cls_ToAscii.ToAscii(Eval("news_title").ToString()) %>-<%#Eval("news_id") %>">Xem Thêm <i class="icon-more"></i></a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </div>
</section>
