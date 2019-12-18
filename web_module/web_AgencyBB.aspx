<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="web_AgencyBB.aspx.cs" Inherits="web_module_web_AgencyBB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <title><%#Eval("title_Google")%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="keywords" content="<%#Eval("keywords")%>" />
    <meta name="description" content="<%#Eval("description")%>" />
    <link rel="canonical" href="<%#Eval("linkTungTrang")%>" />
    <meta property="og:locale" content="vi_VN" />
    <meta property="og:type" content="website" />
    <meta property="og:title" content="<%#Eval("title_Google")%>" />
    <meta property="og:description" content="<%#Eval("description")%>" />
    <meta property="og:url" content="<%#Eval("linkTungTrang")%>" />
    <meta property="og:site_name" content="<%#Eval("linkTungTrang")%>" />
    <link rel="alternate" href="<%#Eval("linkTungTrang")%>" hreflang="vi-vn" />
    <meta name="ROBOTS" content="index, follow" />
    <!-- /SEO google plus -->
    <meta itemprop="name" content="<%#Eval("title_Google")%>" />
    <meta itemprop="description" content="<%#Eval("description")%>" />
    <meta itemprop="image" content="/images/img2.png" />
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
    <style>
        #mapagency {
            height: 400px;
            width: 100%;
        }
    </style>
    <%-- Hệ thống cửa hàng --%>
    <section id="address" class="special-menu  home-icon wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="300ms">
        <div class="container">
            <div class="build-title">
                <h2>Hệ Thống B&B</h2>
            </div>
            <div class="div-select">
                <div class="branch-agency">
                    <h4>Chi Nhánh :</h4>
                    <div class="custom-select">
                        <asp:DropDownList ID="ddChiNhanh" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddChiNhanh_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div style="display:none">
                    <input type="text" id="getValue" runat="server" value="" />
                </div>
                <script>
                    var a = document.getElementById("<% =getValue.ClientID%>")
                </script>
                <%--<a class="show-map" href="~/../../agency">
                    <label>Hiển thị bản đồ&nbsp;:&nbsp; </label>
                    <i class="fa fa-toggle-on"></i>
                </a>--%>
            </div>
            <div id="mapagency"></div>
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
    <script>
        function initMap() {
            // Map options
            var options = {
                zoom: <%=zoom%>,
                center: { lat: <%=lat%>, lng: <%=lng%> }
            }
            // New map
            var map = new google.maps.Map(document.getElementById('mapagency'), options);

            // Array of markers
            var markers = [<%=Map%>];
            // Loop through markers
            for (var i = 0; i < markers.length; i++) {
                // Add marker
                addMarker(markers[i]);
            }
            // Add Marker Function
            function addMarker(props) {
                var marker = new google.maps.Marker({
                    position: props.coords,
                    map: map,
                    icon:props.iconImage
                });

                // Check for customicon
                if (props.iconImage) {
                    // Set icon image
                    marker.setIcon(props.iconImage);
                }

                // Check content
                if (props.content) {
                    var infoWindow = new google.maps.InfoWindow({
                        content: props.content
                    });

                    marker.addListener('click', function () {
                        infoWindow.open(map, marker);
                    });
                }
            }
        }
    </script>
    <%--Nơi duyệt key API--%>
    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA2Zb2vY8-t_9BUYqFFjc9LQiNWUZPLft4&callback=initMap">
    </script>
    <%-- EnD Hệ thống cửa hàng --%>
</asp:Content>

