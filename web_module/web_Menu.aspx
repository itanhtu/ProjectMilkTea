<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="web_Menu.aspx.cs" Inherits="web_module_web_Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
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
    <script>
        $(document).ready(function () {
            $('#slide_SP li .menu_scroll_link:first-child').addClass('active');
        });
    </script>
    <section class="dishes banner-bg invert invert-black home-icon wow fadeInDown"  data-wow-duration="1000ms" data-wow-delay="300ms">
        <div class="icon-default icon-black">
            <img src="images/icon5.png" alt="">
        </div>
        <div class="container">
            <div class="build-title">
                <h2>THỰC ĐƠN</h2>
                <h6 class="color-2">Vào những khoảnh khắc đẹp nhất của tuổi trẻ đều có sự đồng hành của B&B.</h6>
            </div>
        </div>
        <div class="collection_menu_wrap">
            <div class="container">
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12 stikySidebar">
                        <aside class="sidebar_menu">
                            <ul id="slide_SP">
                                <asp:Repeater runat="server" ID="rp_ProductCate">
                                    <ItemTemplate>
                                        <li><a class="menu_scroll_link" href="#<%#cls_ToAscii.ToAscii(Eval("productcate_title").ToString()) %>"><%#Eval("productcate_title") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%-- <li><a class="menu_scroll_link " href="#tra-sua">TRÀ SỮA </a></li>
                                <li><a class="menu_scroll_link " href="#soda">SODA</a></li>
                                <li><a class="menu_scroll_link " href="#da-xay">ĐÁ XAY</a></li>
                                <li><a class="menu_scroll_link " href="#topping">TOPPING</a></li>
                                <li><a class="menu_scroll_link " href="#cafe">CAFE</a></li>--%>
                            </ul>
                        </aside>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-8 col-xs-12 border_right_before">
                        <asp:Repeater runat="server" ID="rp_ProductTitle" OnItemDataBound="rp_ProductTitle_ItemDataBound">
                            <ItemTemplate>
                                <div class="block_menu_item" id="<%#cls_ToAscii.ToAscii(Eval("productcate_title").ToString()) %>">
                                    <h3 class="block_menu_item_title"><span class="line_after_heading section_heading"><%#Eval("productcate_title") %></span></h3>
                                    <div class="flex_wrap display_flex menu_lists">
                                        <asp:Repeater runat="server" ID="rp_Product">
                                            <ItemTemplate>
                                                <div class="menu_item">
                                                    <div class="menu_item_image">
                                                        <a href="<%#Eval("link_seo") %>" title="">
                                                            <img src="<%#Eval("product_image") %>" alt="tradao" /></a>
                                                    </div>
                                                    <div class="menu_item_info bg_white">
                                                        <h3><a href="<%#Eval("link_seo") %>" title=""><%#Eval("product_title") %></a></h3>
                                                        <div class="price_product_item"><%#Eval("product_price" , "{0:0,00}") %> đ</div>
                                                        <a class="menu_item_action animate_btn" href="<%#Eval("link_seo") %>" target="_blank" title="Mua Ngay">Mua ngay</a>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <%--<div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/3.png" alt="tradao" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">TRÀ ĐÀO</a></h3>
                                        <div class="price_product_item">39,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/3.png" alt="tradao" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">TRÀ ĐÀO</a></h3>
                                        <div class="price_product_item">39,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/3.png" alt="tradao" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">TRÀ ĐÀO</a></h3>
                                        <div class="price_product_item">39,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>--%>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <%--<div class="block_menu_item" id="tra-sua">
                            <h3 class="block_menu_item_title"><span class="line_after_heading section_heading">TRÀ SỮA</span></h3>
                            <div class="flex_wrap display_flex menu_lists">
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/4.png" alt="tranchau" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">TRÂN CHÂU</a></h3>
                                        <div class="price_product_item">39,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/4.png" alt="tranchau" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">TRÂN CHÂU</a></h3>
                                        <div class="price_product_item">39,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/4.png" alt="tranchau" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">TRÂN CHÂU</a></h3>
                                        <div class="price_product_item">39,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="block_menu_item" id="soda">
                            <h3 class="block_menu_item_title"><span class="line_after_heading section_heading">SODA</span></h3>
                            <div class="flex_wrap display_flex menu_lists">
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/soda.jpg" alt="soda" /></a>

                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">SODA</a></h3>
                                        <div class="price_product_item">45,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="block_menu_item" id="da-xay">
                            <h3 class="block_menu_item_title"><span class="line_after_heading section_heading">ĐÁ XAY</span></h3>
                            <div class="flex_wrap display_flex menu_lists">
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/matchadx.jpg" alt="matcha da xay" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">MATCHA ĐÁ XAY</a></h3>
                                        <div class="price_product_item">59,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/socoladx.jpg" alt="socola da xay" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">CHOCOLATE ĐÁ XAY</a></h3>
                                        <div class="price_product_item">59,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="block_menu_item" id="topping">
                            <h3 class="block_menu_item_title"><span class="line_after_heading section_heading">TOPPING</span></h3>
                            <div class="flex_wrap display_flex menu_lists">
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#.png" title="">
                                            <img src="/images/7.png" alt="topping" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">Topping</a></h3>
                                        <div class="price_product_item">10,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#.png" title="">
                                            <img src="/images/7.png" alt="topping" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">Topping</a></h3>
                                        <div class="price_product_item">10,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="block_menu_item" id="cafe">
                            <h3 class="block_menu_item_title"><span class="line_after_heading section_heading">CAFE</span></h3>
                            <div class="flex_wrap display_flex menu_lists">
                                <div class="menu_item">
                                    <div class="menu_item_image">
                                        <a href="#" title="">
                                            <img src="/images/cafeden.jpg" alt="cafe den" /></a>
                                    </div>
                                    <div class="menu_item_info bg_white">
                                        <h3><a href="#" title="">CÀ PHÊ ĐEN</a></h3>
                                        <div class="price_product_item">39,000 đ</div>
                                        <a class="menu_item_action animate_btn" href="#" target="_blank" title="Mua Ngay">Mua ngay</a>
                                    </div>
                                </div>

                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" runat="Server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>

