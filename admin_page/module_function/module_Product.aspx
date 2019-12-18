<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_Product.aspx.cs" Inherits="admin_page_module_function_module_Product" %>

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
            //document.getElementById('btnLuu').style.visibility = 'hidden';
            var CityName = document.getElementById('<%= txttensanpham.ClientID%>');

            if (CityName.value.trim() == "") {
                swal('Tên sản phẩm không được để trống!', '', 'warning').then(function () { CityName.focus(); });
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

        function showPreview1(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgPreview1').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
        function showImg1(img) {
            $('#hibodywrapper_imgPreview1').attr('src', img);
        }
        function showImg1_1(img) {
            $('#imgPreview1').attr('src', img);
        }
        function showPreview2(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgPreview2').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
        function showImg2(img) {
            $('#hibodywrapper_imgPreview2').attr('src', img);
        }
        function showImg2_1(img) {
            $('#imgPreview2').attr('src', img);
        }
        function showPreview3(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgPreview3').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
        function showImg3(img) {
            $('#hibodywrapper_imgPreview3').attr('src', img);
        }
        function showImg3_1(img) {
            $('#imgPreview3').attr('src', img);
        }
        function showPreview4(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgPreview4').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
        function showImg4(img) {
            $('#hibodywrapper_imgPreview4').attr('src', img);
        }
        function showImg4_1(img) {
            $('#imgPreview4').attr('src', img);
        }

        function showPreview5(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgPreview5').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
        function showImg5(img) {
            $('#hibodywrapper_imgPreview5').attr('src', img);
        }
        function showImg5_1(img) {
            $('#imgPreview5').attr('src', img);
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false; return true;

        }

        function format_curency(a) {
            a.value = a.value.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.");
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
                        <asp:Button ID="btnHienThi" runat="server" Text="Hiển thị" CssClass="btn btn-primary" OnClick="btnHienThi_Click" />
                        <asp:Button ID="btnAn" runat="server" Text="Ẩn" CssClass="btn btn-primary" OnClick="btnAn_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" CssClass="table-hover" ClientInstanceName="grvList" KeyFieldName="product_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="2%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Loại sản phẩm" FieldName="productcate_title" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Tên sản phẩm" FieldName="product_title" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                    <%--<dx:GridViewDataTextColumn FieldName="product_price" Caption="Giá bán" Width="10%" HeaderStyle-HorizontalAlign="Center">
                        <PropertiesTextEdit DisplayFormatString="{0:#,0.##}" />
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataColumn FieldName="product_image" Width="20%" Caption="Hình ảnh" HeaderStyle-HorizontalAlign="Center" CellStyle-VerticalAlign="Middle">
                        <DataItemTemplate>
                            <img src="<%#Eval("product_image") %>" height="100" />
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Trạng thái" FieldName="product_show" HeaderStyle-HorizontalAlign="Center" Width="5%">
                        <DataItemTemplate>
                            <%#Eval("show") %>
                        </DataItemTemplate>

                    </dx:GridViewDataColumn>
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
    <dx:ASPxPopupControl ID="popupControl" runat="server" Width="1000px" Height="600px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
        HeaderText="Sản phẩm" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div style="display: none">
                                <input id="txtpercen" runat="server" />
                            </div>
                            <div class="div_content col-12">
                                <div class="col-12">
                                    <div class="col-8">
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Loại sản phẩm:</label>
                                            <div class="col-10">
                                                <dx:ASPxComboBox ID="ddlNhomSanPham" runat="server" ValueType="System.Int32" TextField="productcate_title" ValueField="productcate_id" ClientInstanceName="ddlNhomSanPham" CssClass="" Width="90%"></dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Tên sản phẩm:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txttensanpham" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="85%"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Nội dung:</label>
                                            <div class="col-9">
                                                <textarea id="txtContent" runat="server" class="form-control" rows="3" style="width:95%;"></textarea>
                                                <%--<asp:TextBox ID="txtContent" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>--%>
                                            </div>
                                            
                                        </div>
                                        <%--<div class="col-12 form-group">
                                            <label class="col-4 form-control-label">Giá bán:</label>
                                            <div class="col-8">
                                                <asp:TextBox ID="txtPrice" runat="server" ClientIDMode="Static" onkeypress="return isNumberKey(event)" CssClass="form-control boxed" Width="86%"> </asp:TextBox>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <div class="col-4">
                                        <div class="col-12">
                                            <div class="text-color1"><i>Kích thước ảnh tiêu chuẩn 800x800</i></div>
                                            <div class="colum-5 form-group">
                                                <label class="form-control-label">Hình ảnh :</label>
                                                <div id="up1" class="">
                                                    <asp:FileUpload CssClass="hidden-xs-up" ID="FileUpload1" runat="server" onchange="showPreview1(this)" />
                                                    <button type="button" class="btn-chang" onclick="clickavatar1()">
                                                        <img id="imgPreview1" src="/admin_images/up-img.png"  />
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-12">
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
                                                    <input name="SEO_DEP" type="text" id="SEO_DEP" runat="server" class="InputText" style="width: 99.5%; height: 30px" onkeydown="CountLeft(hibodywrapper_popupControl_SEO_DEP, this.form.left,160);" onkeyup="CountLeft(hibodywrapper_popupControl_SEO_DEP,this.form.left,160);" />
                                                    <input <%--readonly--%> type="text" name="left" size="3" maxlength="3" value="160" disabled="disabled" />
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
    </dx:ASPxPopupControl>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
    <script type="text/javascript">
        function clickavatar1() {
            $("#up1 input[type=file]").click();
        }
        function clickavatar2() {
            $("#up2 input[type=file]").click();
        }
        function clickavatar3() {
            $("#up3 input[type=file]").click();
        }
        function clickavatar4() {
            $("#up4 input[type=file]").click();
        }
        function clickavatar5() {
            $("#up5 input[type=file]").click();
        }

    </script>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

