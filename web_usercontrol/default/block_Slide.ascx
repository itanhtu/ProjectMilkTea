<%@ Control Language="C#" AutoEventWireup="true" CodeFile="block_Slide.ascx.cs" Inherits="usercontrol_block_Slide" %>

<section class="home-slider">
        <div class="tp-banner-container">
            <div class="tp-banner">
                <ul>
                    <asp:Repeater runat="server" ID="rpSlide">
                        <ItemTemplate>
                    <li data-transition="zoomout" data-slotamount="2" data-masterspeed="1000" data-thumb="" data-saveperformance="on" data-title="Slide">
                        <img src="/images/dummy.png" alt="slidebg1" data-lazyload="<%#Eval("slide_image") %>" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat">
                        <!-- LAYERS -->
                        <div class="tp-caption very_large_text"  data-x="center" data-hoffset="0" data-y="250" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                            <%--TRÀ SỮA <span>B&B</span> <i>Everywhere</i>--%> <%#Eval("slide_title") %>
                        </div>
                        <!-- LAYERS -->
                        <div class="tp-caption medium_text "  data-x="center" data-hoffset="0" data-y="340" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                           <%#Eval("slide_title1") %>
                            <%--B&B – một thương hiệu Trà sữa “tràn đầy năng lượng”, tạo nguồn cảm hứng cho sự trẻ trung, năng động & sáng tạo.--%>
                        </div>
                        <!-- LAYERS -->
                        <div class="tp-caption" style="margin-top:30px !important;" data-x="center" data-hoffset="0" data-y="450" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                            <a href="<%#Eval("slide_link") %>" class="button-white">Khám Phá Ngay</a>
                        </div>
                    </li>
                    </ItemTemplate>
                    </asp:Repeater>
                    <%--<li data-transition="zoomout" data-slotamount="2" data-masterspeed="1000" data-thumb="" data-saveperformance="on" data-title="Slide">
                        <img src="/images/dummy.png" alt="slidebg1" data-lazyload="/images/slider2.jpg" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat">
                        <!-- LAYERS -->
                        <div class="tp-caption very_large_text" data-x="center" data-hoffset="0" data-y="250" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                            TRÀ SỮA <span>B&B</span> <i>Everywhere</i>
                        </div>
                        <!-- LAYERS -->
                        <div class="tp-caption medium_text" data-x="center" data-hoffset="0" data-y="340" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                            B&B – một thương hiệu Trà sữa “tràn đầy năng lượng”, tạo nguồn cảm hứng cho sự trẻ trung, năng động & sáng tạo.
                        </div>
                        <!-- LAYERS -->
                        <div class="tp-caption" data-x="center" data-hoffset="0" data-y="425" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                            <a href="#" class="button-white">Khám Phá Ngay</a>
                        </div>
                    </li>
                    <li data-transition="zoomout" data-slotamount="2" data-masterspeed="1000" data-thumb="" data-saveperformance="on" data-title="Slide">
                        <img src="/images/dummy.png" alt="slidebg1" data-lazyload="/images/slider3.jpg" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat">
                        <!-- LAYERS -->
                        <div class="tp-caption very_large_text" data-x="center" data-hoffset="0" data-y="250" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                            TRÀ SỮA <span>B&B</span> <i>Everywhere</i>
                        </div>
                        <!-- LAYERS -->
                        <div class="tp-caption medium_text" data-x="center" data-hoffset="0" data-y="340" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                            B&B – một thương hiệu Trà sữa “tràn đầy năng lượng”, tạo nguồn cảm hứng cho sự trẻ trung, năng động & sáng tạo.
                        </div>
                        <!-- LAYERS -->
                        <div class="tp-caption" data-x="center" data-hoffset="0" data-y="425" data-customin="x:0;y:0;z:0;rotationX:90;rotationY:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;transformPerspective:200;transformOrigin:50% 0%;" data-customout="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0.75;scaleY:0.75;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300">
                            <a href="#" class="button-white">Khám Phá Ngay</a>
                        </div>
                    </li>--%>
                </ul>
            </div>
        </div>
    </section>