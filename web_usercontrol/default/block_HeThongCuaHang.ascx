<%@ Control Language="C#" AutoEventWireup="true" CodeFile="block_HeThongCuaHang.ascx.cs" Inherits="usercontrol_block_HeThongCuaHang" %>

<section id="branchs" class="special-menu  home-icon wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
    <div class="icon-default icon-skeen icon-skeen2">
        <a href="#branchs" class="clickid">
            <img src="/images/shop.png" alt="">
        </a>

    </div>
    <div class="container">
        <div class="build-title">
            <h2>Hệ Thống B&B</h2>
            <%-- <h6>Vào những khoảnh khắc đẹp nhất của tuổi trẻ đều có sự đồng hành của B&B</h6>--%>
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
            <img src="/images/icon111.png" alt="">
        </div>
        <div class="icon-bottom-left">
            <img src="/images/icon333.png" alt="">
        </div>
        <div class="icon-top-right">
            <img src="/images/icon555.png" alt="">
        </div>
        <div class="icon-bottom-right">
            <img src="/images/icon222.png" alt="">
        </div>
    </div>
    <asp:Repeater ID="rpPopup" runat="server">
        <ItemTemplate>
            <div id="<%#Eval("restaurant_id") %>" class="mfp-hide white-popup-block">
                <div class="row">
                    <div class="col-lg-6 col-md-6  ">
                        <div class="modal-box-left">
                            <h4><%#Eval("restaurant_name") %></h4>
                            <p><%#Eval("restaurant_addressname") %></p>
                            <a class="btn-open-map" target="_blank" href="<%#Eval("restaurant_map") %>">ĐẾN CỬA HÀNG </a>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 ">
                        <div class="embed-responsive embed-responsive-4by3">
                            <%--<video>
                                <source src="<%#Eval("restaurant_linkvideo") %>" type="video/mp4" />
                            </video>--%>
                            <iframe class="embed-responsive-item" width="500" height="300" src="https://www.youtube.com/embed/<%#Eval("restaurant_linkvideo") %>" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
                        </div>
                       <%-- <img src="<%#Eval("restaurant_image") %>" />--%>
                        <button class="popup-modal-dismiss "></button>
                    </div>
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>
</section>
<%--<div style="display: none">
    <asp:UpdatePanel ID="upPop" runat="server">
        <ContentTemplate>
            <input type="text" id="txtMaProduct" runat="server" />
            <a href="#" id="btnTraiTim" runat="server" onserverclick="btnpopup_ServerClick"></a>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
