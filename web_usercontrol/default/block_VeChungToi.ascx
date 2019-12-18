<%@ Control Language="C#" AutoEventWireup="true" CodeFile="block_VeChungToi.ascx.cs" Inherits="usercontrol_block_VeChungToi" %>

<section id="about-us" class="welcome-part home-icon">
    <div class="icon-default">
        <a href="#about-us" class="scroll">
            <img src="/images/scroll-arrow.png" alt=""></a>
    </div>
    <div class="container">
        <asp:Repeater runat="server" ID="rp_Introdule">
            <ItemTemplate>
                <div class="build-title">
                    <h2><%#Eval("introduce_title") %></h2>
                    <h6><%#Eval("introduce_title1") %></h6>
                </div>
                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
                        <p>
                            <%#Eval("introduce_summary") %>
                        </p>
                       <%-- <p>
                            <img src="/images/signature.png" alt="">
                        </p>--%>
                        <p><a href="/about" class="btn-black">TÌM HIỂU THÊM</a></p>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12 wow fadeInUp" data-wow-duration="1000ms" data-wow-delay="300ms">
                        <img src="<%#Eval("introduce_image") %>" alt="">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
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
</section>
