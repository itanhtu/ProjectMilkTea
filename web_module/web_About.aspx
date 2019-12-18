<%@ Page Title="" Language="C#" MasterPageFile="~/WebsiteMasterPage.master" AutoEventWireup="true" CodeFile="web_About.aspx.cs" Inherits="web_module_web_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <title><%=title_Google%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="keywords" content="<%=keywords %>" />
    <meta name="description" content="<%=description%>" />
    <link rel="canonical" href="<%=linkTungTrang%>" />
    <meta property="og:locale" content="vi_VN" />
    <meta property="og:type" content="website" />
    <meta property="og:title" content="<%=title_Google%>" />
    <meta property="og:description" content="<%=description%>" />
    <meta property="og:url" content="<%=linkTungTrang%>" />
    <meta property="og:site_name" content="<%=linkTungTrang%>" />
    <link rel="alternate" href="<%=linkTungTrang%>" hreflang="vi-vn" />
    <meta name="ROBOTS" content="index, follow" />
    <!-- /SEO google plus -->
    <meta itemprop="name" content="<%=title_Google%>" />
    <meta itemprop="description" content="<%=description%>" />
    <meta itemprop="image" content="<%=image%>" />
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
    <section class="default-section contact-part home-icon">
        <asp:Repeater ID="rpAbout" runat="server">
            <ItemTemplate>
                <div class="container">
                    <div class="title text-center">
                        <h2 class="text-coffee"><%#Eval("introduce_title") %></h2>
                    </div>
                    <div class="editor-container">
                        <%#Eval("introduce_content") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
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

