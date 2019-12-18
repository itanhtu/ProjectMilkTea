<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_ProductCate.aspx.cs" Inherits="admin_page_module_function_module_ProductCate" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script>
        function CountLeft(field, count, max) {
            if (field.value.length > max)
                field.value = field.value.substring(0, max);
            else
                count.value = max - field.value.length;
        }
    </script>
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
        function checkNULL() {
            var CityName = document.getElementById('<%= txtloaisanpham.ClientID%>');

            if (CityName.value.trim() == "") {
                swal('Vui lòng nhập loại sản phẩm!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }
        function confirmDel() {
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
            }
    </script>
    <div class="card card-block">
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnThem_Click" />
                        <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary" OnClick="btnChiTiet_Click" />
                        <input type="submit" class="btn btn-primary" value="Xóa" onclick="confirmDel()" />
                        <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />
                        <%--<asp:Button ID="btnAn" runat="server" Text="Ẩn" CssClass="btn btn-primary" OnClick="btnAn_Click" />
                        <asp:Button ID="btnHienThi" runat="server" Text="Hiển thị" CssClass="btn btn-primary" OnClick="btnHienThi_Click" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="productcate_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="10%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Tên loại sản phẩm" FieldName="productcate_title" HeaderStyle-HorizontalAlign="Center" Width="100%"></dx:GridViewDataColumn>
                    <%--<dx:GridViewDataColumn Caption="Vị trí" FieldName="productcate_position" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>--%>
                    <%--<dx:GridViewDataColumn Caption="Nhóm sản phẩm" FieldName="productcate_parent" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>--%>
                    <%--<dx:GridViewDataColumn Caption="Tình trạng" FieldName="productcate_show" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>--%>
                </Columns>
                <ClientSideEvents RowDblClick="btnChiTiet" />
                <SettingsSearchPanel Visible="true" />
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Trống" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>
    </div>
    <dx:ASPxPopupControl ID="popupControl" runat="server" Width="800" Height="400" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
        HeaderText="Loại sản phẩm" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12 form-group">
                                    <label class="col-2 form-control-label">Loại sản phẩm:</label>
                                    <div class="col-10">
                                        <asp:TextBox ID="txtloaisanpham" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="96%"> </asp:TextBox>
                                    </div>
                                </div>
                            </div>
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
                                        <dx:ASPxTextBox ID="SEO_LINK" runat="server" ClientInstanceName="SEO_LINK" CssClass="InputText"
                                            Width="100%">
                                        </dx:ASPxTextBox>
                                    </th>
                                </tr>
                                <tr>
                                    <th style="width: 0.1%">SEO&nbsp;nội&nbsp;dung
                                    </th>
                                    <th style="width: 0.1%">&nbsp;:&nbsp;
                                    </th>
                                    <th>
                                        <input name="SEO_DEP" type="text" id="SEO_DEP" runat="server" class="InputText" style="width: 99.5%; height: 30px" onkeydown="CountLeft(hibodywrapper_popupControl_SEO_DEP, this.form.left,160);" onkeyup="CountLeft(hibodywrapper_popupControl_SEO_DEP,this.form.left,160);" />
                                        <input type="text" name="left" size="3" maxlength="3" value="160" disabled="disabled" />
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
                <asp:UpdatePanel ID="udSave" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnLuu" runat="server" ClientIDMode="Static" Text="Lưu" CssClass="btn btn-primary" OnClientClick="return checkNULL()" OnClick="btnLuu_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
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

