<%@ Control Language="C#" AutoEventWireup="true" CodeFile="global_header.ascx.cs" Inherits="web_usercontrol_global_header" %>
<asp:Repeater ID="rpHeader" runat="server">
    <ItemTemplate>
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
        <meta itemprop="image" content="<%#Eval("image")%>" />
        <!-- /SEO google plus -->
        <meta name="ROBOTS" content="index, follow" />

        <!-- /SEO Chuẩn -->
    </ItemTemplate>
</asp:Repeater>