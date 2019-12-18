<%@ Page Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_ThemAnh.aspx.cs" Inherits="admin_page_module_function_module_ThemAnh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <!--<script src="/js/jquery-2.2.0.min.js"></script>-->

    <script>
        window.onload = function () {
            document.getElementById("<%=btnUpload.ClientID%>").style.display = 'none';
        }

        function getCookie(cname) {
            var name = cname + "=";
            var decodedCookie = decodeURIComponent(document.cookie);
            var ca = decodedCookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }

        function xoaImage(id) {
            var user = getCookie("language");
            if (user == "1") {
                document.getElementById("<%=txtImage.ClientID%>").value = id;
                swal("Bạn có thực sự muốn xóa hình ảnh này?", "", "warning",
                    {
                        buttons: ["Hủy", "Đồng ý"],
                        dangerMode: true
                    }).then(function (value) {
                        if (value == true) {
                            var xoa = document.getElementById('<%=btnXoaImage.ClientID%>');
                            xoa.click();
                        }
                    });
                }
                else {
                    document.getElementById("<%=txtImage.ClientID%>").value = id;
                swal("Bạn có thực sự muốn xóa hình ảnh này?", "", "warning",
                    {
                        buttons: ["Cancel", "OK"],
                        dangerMode: true
                    }).then(function (value) {
                        if (value == true) {
                            var xoa = document.getElementById('<%=btnXoaImage.ClientID%>');
                            xoa.click();
                        }
                    });
                }
            //document.getElementById("<%=btnXoaImage.ClientID%>").click();
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


    <div class="addnew-step6">
        <div class="container">

            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <br />
                    <h4 class="landing__title-title"><b>Tải lên thư viện ảnh</b></h4>
                    <hr />
                    <br />
                    <!--To give the control a modern look, I have applied a stylesheet in the parent span.-->
                    <!-- <div class="col-8">-->
                    <asp:UpdatePanel ID="upUpload" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <span class="button-addimg fileinput-button">
                                <label>Lựa chọn ảnh</label>
                                <div class="text-color1"><i>Kích thước ảnh tiêu chuẩn 1000x1000</i></div>
                                <div id="up1" class="">
                                    <asp:FileUpload CssClass="hidden-xs-up" ID="files" name="files[]" ClientIDMode="Static" runat="server" multiple accept="image/jpeg, image/png, image/gif," />
                                    <button type="button" class="btn-chang" onclick="clickavatar1()">
                                        <img src="/admin_images/up-img.png" />
                                    </button>
                                </div>
                            </span>
                            <asp:UpdatePanel ID="upImage" runat="server">
                                <ContentTemplate>
                                    <ul class="thumb-Images">
                                        <asp:Repeater ID="rpImageListing" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <div class="img-wrap">
                                                        <a onclick="xoaImage(<%#Eval("collection_id") %>)"><span class="close">&times;</span></a>
                                                        <img class="thumb" src="<%#Eval("collection_image") %>" />
                                                        <div id="divSub" class="FileNameCaptionStyle" runat="server"></div>
                                                    </div>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <output id="Filelist" class="clearfix"></output>
                            <br />
                            <div class="form-group d-flex align-items-center justify-content-space-between">
                                <asp:Button ID="btnUpload" CssClass="btn btn-primary fileinput-button" runat="server" Text="Tải lên tất cả" OnClick="btnUpload_Click" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUpload" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="col-md-12 col-sm-12">
                        <div id="divMes" runat="server">
                        </div>
                    </div>
                </div>
                <div style="display: none">
                    <input id="txtImage" runat="server" />
                    <asp:UpdatePanel ID="upXoa" runat="server">
                        <ContentTemplate>
                            <a href="javascript:void(0)" id="btnXoaImage" runat="server" onserverclick="btnXoaImage_ServerClick"></a>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
    <script type="text/javascript">
        function clickavatar1() {
            $("#up1 input[type=file]").click();
        }
        //Tôi đã thêm trình xử lý sự kiện cho điều khiển tải lên tệp để truy cập các thuộc tính tệp.
        document.addEventListener("DOMContentLoaded", init, false);

        //Để lưu một loạt các tệp đính kèm
        var AttachmentArray = [];

        //bộ đếm cho mảng đính kèm
        var arrCounter = 0;

        //để đảm bảo thông báo lỗi cho số lượng tệp sẽ chỉ được hiển thị một lần.
        var filesCounterAlertStatus = false;

        //hủy danh sách để giữ hình thu nhỏ
        var ul = document.createElement('ul');
        ul.className = ("thumb-Images");
        ul.id = "imgList";

        function init() {
            //thêm trình xử lý javascript cho sự kiện tải lên tệp
            document.querySelector('#files').addEventListener('change', handleFileSelect, false);
        }

        //xử lý cho sự kiện tải lên tập tin
        function handleFileSelect(e) {

            //để đảm bảo người dùng chọn tập tin / tập tin
            if (!e.target.files) return;

            //Để có được một tài liệu tham khảo
            var files = e.target.files;
            if (files.length >= 1) {
                // Lặp lại thông qua FileList và sau đó để hiển thị các tệp hình ảnh dưới dạng hình thu nhỏ.
                for (var i = 0, f; f = files[i]; i++) {

                    //khởi tạo một đối tượng FileReader để đọc nội dung của nó vào bộ nhớ
                    var fileReader = new FileReader();

                    // Đóng để nắm bắt thông tin tập tin và áp dụng xác nhận.
                    fileReader.onload = (function (readerEvt) {
                        return function (e) {

                            //Áp dụng các quy tắc xác thực cho tải lên tệp đính kèm
                            ApplyFileValidationRules(readerEvt)

                            //Kết xuất hình đính kèm hình thu nhỏ.
                            RenderThumbnail(e, readerEvt);

                            //Điền vào mảng đính kèm
                            FillAttachmentArray(e, readerEvt)
                        };
                    })(f);

                    // Đọc trong tệp hình ảnh dưới dạng URL dữ liệu.
                    // readAsDataURL: Thuộc tính kết quả sẽ chứa dữ liệu của tệp / blob được mã hóa dưới dạng URL dữ liệu.
                    // More info about Data URI scheme https://en.wikipedia.org/wiki/Data_URI_scheme
                    fileReader.readAsDataURL(f);
                }
                document.getElementById('files').addEventListener('change', handleFileSelect, false);
                document.getElementById("<%=btnUpload.ClientID%>").style.display = 'block';

            }
            else {
                var user = getCookie("language");
                if (user == "1") {
                    cls_Alert.alert_SuccessRs(Page, "Vui lòng nhập tối thiểu 10 hình ảnh", "");
                }
                else {
                    cls_Alert.alert_SuccessRs('Please enter a minimum of 10 images');
                }

            }
        }

        //Áp dụng các quy tắc xác thực cho tải lên tệp đính kèm
        function ApplyFileValidationRules(readerEvt) {
            //Để kiểm tra loại tệp theo điều kiện tải lên
            if (CheckFileType(readerEvt.type) == false) {
                alert("The file (" + readerEvt.name + ") does not match the upload conditions, You can only upload jpg/png/gif files");
                e.preventDefault();
                return;
            }

            //Để kiểm tra Kích thước tệp theo điều kiện tải lên
            if (CheckFileSize(readerEvt.size) == false) {
                alert("The file (" + readerEvt.name + ") does not match the upload conditions, The maximum file size for uploads should not exceed 4MB");
                e.preventDefault();
                return;
            }
            if (CheckFilesCount(AttachmentArray) == false) {

                if (!filesCounterAlertStatus) {
                    filesCounterAlertStatus = true;
                    alert("You have added more than 10 files. According to upload conditions you can upload 100 files maximum");
                }
                e.preventDefault();
                return;
            }
            //Để kiểm tra số lượng tập tin theo điều kiện tải lên

        }

        //Để kiểm tra loại tệp theo điều kiện tải lên
        function CheckFileType(fileType) {
            if (fileType == "image/jpeg") {
                return true;
            }
            else if (fileType == "image/png") {
                return true;
            }
            else if (fileType == "image/gif") {
                return true;
            }
            else {
                return false;
            }
            return true;
        }

        //Để kiểm tra Kích thước tệp theo điều kiện tải lên
        function CheckFileSize(fileSize) {
            if (fileSize < 15000000) {
                return true;
            }
            else {
                return false;
            }
            return true;
        }

        //Để kiểm tra số lượng tập tin theo điều kiện tải lên
        function CheckFilesCount(AttachmentArray) {
            //Vì AttachmentArray.length trả về chỉ mục có sẵn tiếp theo trong mảng,
            //Tôi đã sử dụng vòng lặp để có được chiều dài thực
            var len = 0;
            var count = 0;
            for (var i = 0; i < AttachmentArray.length; i++) {
                if (AttachmentArray[i] !== undefined) {
                    len++;

                }

            }
            //Để kiểm tra độ dài không vượt quá 100 tệp
            if (len > 100) {
                return false;
            }
            else {
                return true;
            }
        }
        function CheckFilesCountMin() {
            //Vì AttachmentArray.length trả về chỉ mục có sẵn tiếp theo trong mảng,
            //Tôi đã sử dụng vòng lặp để có được chiều dài thực
            var len = AttachmentArray.length;
            if (len > 1)
                return true;
            else {
                return false;
            }

            //To check the length does not exceed 10 files maximum
        }
        //Render attachments thumbnails.
        function RenderThumbnail(e, readerEvt) {
            var li = document.createElement('li');
            ul.appendChild(li);
            li.innerHTML = ['<div class="img-wrap">' +
                '<img class="thumb" src="', e.target.result, '" title="', escape(readerEvt.name), '" data-id="',
            readerEvt.name, '"/>' + '</div>'].join('');

            var div = document.createElement('div');
            div.className = "FileNameCaptionStyle";
            li.appendChild(div);
            div.innerHTML = [readerEvt.name].join('');
            document.getElementById('Filelist').insertBefore(ul, null);
        }

        //Fill the array of attachment
        function FillAttachmentArray(e, readerEvt) {
            AttachmentArray[arrCounter] =
                {
                    AttachmentType: 1,
                    ObjectType: 1,
                    FileName: readerEvt.name,
                    FileDescription: "Attachment",
                    NoteText: "",
                    MimeType: readerEvt.type,
                    Content: e.target.result.split("base64,")[1],
                    FileSizeInBytes: readerEvt.size,
                };
            arrCounter = arrCounter + 1;
        }
    </script>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
