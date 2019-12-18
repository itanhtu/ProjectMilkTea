<%@ Page Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DangKy.aspx.cs" Inherits="admin_page_module_function_module_DangKy" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script type="text/javascript">
        function func() {
            grvList.Refresh();
            popupControl.Hide();
        }
        <%-- function btnChiTiet() {
            document.getElementById('<%=btnChiTiet.ClientID%>').click();
        }--%>
        function btnPheDuyet() {
            document.getElementById('<%=btnPheDuyet.ClientID%>').click();
        }
        <%--function checkNULL() {
            var CityName = document.getElementById('<%= txtemail.ClientID%>');

            if (CityName.value.trim() == "") {
                swal('Tên form không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }--%>
        <%--function confirmDel() {
            swal("Bạn có thực sự muốn xóa?",
                "Nếu xóa, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        var xoa = document.getElementById('<%=btnXoa.ClientID%>');
                        xoa.click();
                    }
                });
        }--%>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false; return true;
        };
    </script>
    <div class="card card-block">
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <%--<asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnThem_Click" />--%>
                        <asp:Button ID="btnPheDuyet" runat="server" Text="Phê duyệt" CssClass="btn btn-primary" OnClick="btnPheDuyet_Click" />
                        <%-- <input type="submit" class="btn btn-primary" value="Xóa" onclick="confirmDel()" />
                        <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />--%>
                        <%--<asp:Button ID="btnShow" runat="server" Text="Hiển trị trang chủ" CssClass="btn btn-primary" OnClick="btnShow_Click" />
                        <asp:Button ID="btnShowhiden" runat="server" Text="Ẩn trang chủ" CssClass="btn btn-primary" OnClick="btnShowhiden_Click" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="dke_id" Width="50%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="2%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Email" FieldName="dke_email" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Trạng thái" FieldName="dke_tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="8%"></dx:GridViewDataColumn>
                </Columns>
                <ClientSideEvents RowDblClick="btnPheDuyet" />
                <SettingsSearchPanel Visible="true" />
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>
    </div>
    <%--  <dx:ASPxPopupControl ID="popupControl" runat="server" Width="800px" Height="300px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
        HeaderText="Liên hệ" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12">
                                    <div class="col-9">
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Email đăng ký:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txtemail" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Số Điện Thoại:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txtphone" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Địa Chỉ:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txtaddress" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <div class="mar_but button">
                <asp:Button ID="btnLuu" runat="server" ClientIDMode="Static" Text="Lưu" CssClass="btn btn-primary" OnClientClick="return checkNULL()" OnClick="btnLuu_Click" />
            </div>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>--%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
