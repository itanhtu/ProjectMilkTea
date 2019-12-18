<%@ Control Language="C#" AutoEventWireup="true" CodeFile="block_ThucDonSlide.ascx.cs" Inherits="usercontrol_block_ThucDonSlide" %>

<section id="menu" class="dishes banner-bg invert invert-black home-icon wow fadeInDown" data-background="images/banner1.jpg" data-wow-duration="1000ms" data-wow-delay="300ms">
    <div class="icon-default icon-black">
        <a href="#menu" class="clickid">
            <img src="images/icon5.png" alt="">
        </a>

    </div>
    <div class="container">

        <div class="build-title">
            <h2>Thực Đơn</h2>
            <h6>Vào những khoảnh khắc đẹp nhất của tuổi trẻ đều có sự đồng hành của B&B.</h6>
        </div>
        <div id="slide-menu" class="owl-carousel owl-theme" data-items="5" data-laptop="5" data-margin="20" data-tablet="3" data-mobile="1" data-nav="true" data-dots="false" data-autoplay="true" data-speed="1800" data-autotime="5000">
            <asp:Repeater ID="rpSildeMenu" runat="server">
                <ItemTemplate>
                    <div class="item">
                       <div class="product-blog">
                        <img src="<%#Eval("product_image") %>" />
                        <h3><%#Eval("product_title") %></h3>
                        <p><%#Eval("product_content") %></p>
                      
                    </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
       <%-- <div class="slider multiple-items">
            <asp:Repeater ID="rpSildeMenu" runat="server">
                <ItemTemplate>
                    <div class="product-blog">
                        <img src="<%#Eval("product_image") %>" />
                        <h3><%#Eval("product_title") %></h3>
                        <p><%#Eval("product_content") %></p>
                      
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>

        <%-- <div class="product-blog">
                    <img src="/images/tranchau.jpg" alt="">
                    <h3>TRÂN CHÂU</h3>
                    <p>Trà sữa Trân Châu của B&B luôn thơm đậm khi quyện cùng kem sữa gây ghiền</p>

                </div>
                <div class="product-blog">
                    <img src="/images/topping.jpg" alt="">
                    <h3>TOPPING</h3>
                    <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames</p>

                </div>
                <div class="product-blog">
                    <img src="/images/soda.jpg" alt="">
                    <h3>SODA</h3>
                    <p>BLUE OCEAN, mang những bờ biển tươi xanh huyền bí đến với bạn</p>

                </div>
                <div class="product-blog">
                    <img src="/images/socoladx.jpg" alt="">
                    <h3>ĐÁ XAY SOCOLA</h3>
                    <p>Bông kem trang trí (làm từ Rich's Non-Dairy Creamer & Rich's Whip Topping Base)30gr</p>

                </div>
                <div class="product-blog">
                    <img src="/images/matchadx.jpg" alt="">
                    <h3>MATCHA ĐÁ XAY</h3>
                    <p>Bông kem trang trí (làm từ Rich's Non-Dairy Creamer & Rich's Whip Topping Base)30gr</p>

                </div>--%>
    </div>
</section>
