<%@ Page Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_SEO.aspx.cs" Inherits="admin_page_module_function_module_SEO" %>


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
        function btnChiTiet() {
            document.getElementById('<%=btnChiTiet.ClientID%>').click();
        }
        function popupHide() {
            document.getElementById('btnClosePopup').click();
        }
    </script>
    <div class="card card-block">
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary" OnClick="btnChiTiet_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="seo_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Trang" FieldName="page_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Tiêu đề" FieldName="seo_title" HeaderStyle-HorizontalAlign="Center" Width="40%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Mô tả" FieldName="seo_description" Width="40%" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataColumn>
                </Columns>
                <ClientSideEvents RowDblClick="btnChiTiet" />
                <%--<SettingsSearchPanel Visible="true" />--%>
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>
    </div>
    <dx:ASPxPopupControl ID="popupControl" runat="server" Width="1000px" Height="400px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
        HeaderText="SEO" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <table>
                                <tr>
                                    <th style="width: 0.1%">SEO&nbsp;Keywords
                                    </th>
                                    <th style="width: 0.1%">&nbsp;:&nbsp;
                                    </th>
                                    <th>
                                        <dx:ASPxTextBox ID="SEO_KEYWORD" runat="server" ClientInstanceName="SEO_KEYWORD" CssClass="InputText"
                                            Width="100%">
                                        </dx:ASPxTextBox>
                                    </th>
                                </tr>
                                <tr>
                                    <th style="width: 0.1%">SEO&nbsp;tiêu&nbsp;đề
                                    </th>
                                    <th style="width: 0.1%">&nbsp;:&nbsp;
                                    </th>
                                    <th>
                                        <dx:ASPxTextBox ID="SEO_TITLE" runat="server" ClientInstanceName="SEO_TITLE" CssClass="InputText"
                                            Width="100%">
                                        </dx:ASPxTextBox>
                                    </th>
                                </tr>
                                <tr>
                                    <th style="width: 0.1%">SEO&nbsp;link
                                    </th>
                                    <th style="width: 0.1%">&nbsp;:&nbsp;
                                    </th>
                                    <th>
                                        <dx:ASPxTextBox ID="SEO_LINK" runat="server" ClientInstanceName="SEO_LINK" CssClass="InputText" Width="100%">
                                        </dx:ASPxTextBox>
                                    </th>
                                </tr>
                                <tr>
                                    <th style="width: 0.1%">SEO&nbsp;nội&nbsp;dung
                                    </th>
                                    <th style="width: 0.1%">&nbsp;:&nbsp;
                                    </th>
                                    <th>
                                        <dx:ASPxTextBox ID="SEO_DEP" runat="server" ClientInstanceName="SEO_DEP" CssClass="InputText" Width="100%">
                                        </dx:ASPxTextBox>
                                    </th>
                                </tr>
                                <tr>
                                    <th style="width: 0.1%">SEO&nbsp;IMAGE
                                    </th>
                                    <th style="width: 0.1%">&nbsp;:&nbsp;
                                    </th>
                                    <th>
                                        <dx:ASPxTextBox ID="SEO_IMAGE" runat="server" ClientInstanceName="SEO_IMAGE" CssClass="InputText" Width="100%">
                                        </dx:ASPxTextBox>
                                    </th>
                                </tr>
                            </table>
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
    </dx:ASPxPopupControl>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

