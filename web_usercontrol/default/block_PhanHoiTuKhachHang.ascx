<%@ Control Language="C#" AutoEventWireup="true" CodeFile="block_PhanHoiTuKhachHang.ascx.cs" Inherits="usercontrol_block_PhanHoiTuKhachHang" %>

<section id="feedbacks" class="client banner-bg invert invert-black home-icon wow fadeInDown" data-background="images/banner3.jpg" data-wow-duration="1000ms" data-wow-delay="300ms">
        <div class="icon-default icon-black">
            <a href="#feedbacks" class="clickid">
                <img src="images/icon21.png" alt="">
            </a>
            
        </div>
        <div class="container">
            <div class="build-title">
                <h2>Phản Hồi Từ Khách Hàng</h2>
                <%--<h6>1500+ Khách hàng hài lòng</h6>--%>
            </div>
            <div class="client-say">
                <div class="owl-carousel owl-theme" data-items="1" data-laptop="1" data-tablet="1" data-mobile="1" data-nav="false" data-dots="true" data-autoplay="true" data-speed="1800" data-autotime="5000" data-margin="30">
                   <asp:Repeater ID="rpPHTKH" runat="server">
                       <ItemTemplate>

                    <div class="item">
                            <img src=" <%#Eval("customer_image") %>" alt="">
                        <h5> <%#Eval("customer_name") %></h5>
                        <%--<p> <%#Eval("customer_title") %></p>--%>
                       <p>
                            <%#Eval("customer_content") %>
                                        
                        </p>
                    </div>
                           
                       </ItemTemplate>
                   </asp:Repeater>
                 <%--   <div class="item">
                        <p>
                            <img src="images/client1.png" alt=""></p>
                        <h5>Alice Williams</h5>
                        <p>Sinh viên</p>
                        <p>
                            Trà sữa có không gian thoáng mát thích hợp đi cùng bạn bè để tám chiện hay họp nhóm.
                                        <br>
                            Thức uống ngon, pha chế nhanh, giá cả hợp lý với túi tiền của sinh viên
                                 
                        </p>
                    </div>
                    <div class="item">
                        <p>
                            <img src="images/client1.png" alt=""></p>
                        <h5>Hoàng Long</h5>
                        <p>Sinh viên</p>
                        <p>
                            Trà sữa ngon Giá cả phải chăng rất phù hợp với sinh viên
                                        <br>
                            Nhân viên tùy chi nhánh mà thân thiện hay không
                                        <br>
                            Sẽ ghé lại nhiều lần vì ngon và rẻ.
                        </p>
                    </div>
                    <div class="item">
                        <p>
                            <img src="images/client1.png" alt=""></p>
                        <h5>Hoàng Long</h5>
                        <p>Sinh viên</p>
                        <p>
                            Trà sữa ngon Giá cả phải chăng rất phù hợp với sinh viên
                                        <br>
                            Nhân viên tùy chi nhánh mà thân thiện hay không
                                        <br>
                            Sẽ ghé lại nhiều lần vì ngon và rẻ.
                        </p>
                    </div>--%>
                </div>
            </div>
        </div>
    </section>