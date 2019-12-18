<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ChangePassword.aspx.cs" Inherits="admin_page_module_access_admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <div class="card card-block">
        <div class="form-group row">
            <label class="col-sm-3 form-control-label">Email nhận mật khẩu:</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
            </div>
        </div>
         <div class="form-group row">
            <label class="col-sm-3 form-control-label">Mật khẩu cũ:</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtMatKhauCu" TextMode="Password" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-3 form-control-label">Mật khẩu mới:</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtMatKhauMoi" TextMode="Password" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-3 form-control-label">Xác nhận lại mật khẩu:</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtNhapLai" TextMode="Password" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btnLuu_Click" />
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <%--<asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnThem_Click" />--%>

                        <%-- <input type="submit" class="btn btn-primary" value="Xóa" onclick="confirmDel()" />
                        <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />--%>
                        <%--<asp:Button ID="btnShow" runat="server" Text="Hiển trị trang chủ" CssClass="btn btn-primary" OnClick="btnShow_Click" />
                        <asp:Button ID="btnShowhiden" runat="server" Text="Ẩn trang chủ" CssClass="btn btn-primary" OnClick="btnShowhiden_Click" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
   
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

