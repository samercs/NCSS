
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="NewsOp.aspx.cs" Inherits="Admin_NewsOp" %>
<%@ Register TagPrefix="uc1" TagName="hijriCalender" Src="~/controls/hijriCalender.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/tinymce/js/tinymce/tinymce.min.js"></script>
    
    <script type="text/javascript">
        tinymce.init({
            selector: "textarea",
            plugins: [
                "advlist autolink autosave link image lists charmap print preview hr anchor pagebreak spellchecker",
                "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
                "table contextmenu directionality emoticons template textcolor paste textcolor colorpicker textpattern"
            ],

            toolbar1: "bold italic underline strikethrough | alignleft aligncenter alignright alignjustify | styleselect formatselect fontselect fontsizeselect",
            toolbar2: "cut copy paste | searchreplace | bullist numlist | outdent indent blockquote | undo redo | link unlink anchor image media code | insertdatetime preview | forecolor backcolor",
            toolbar3: "table | hr removeformat | subscript superscript | charmap emoticons | print fullscreen | ltr rtl | spellchecker | visualchars visualblocks nonbreaking template pagebreak restoredraft",

            menubar: false,
            toolbar_items_size: 'small',

            style_formats: [
                { title: 'Bold text', inline: 'b' },
                { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
                { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
                { title: 'Example 1', inline: 'span', classes: 'example1' },
                { title: 'Example 2', inline: 'span', classes: 'example2' },
                { title: 'Table styles' },
                { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
            ],
        });</script>
    
    <script type="text/javascript" src="/js/calender/jquery.calendars.js"></script>
    <script type="text/javascript" src="/js/calender/jquery.calendars.plus.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/calender/jquery.calendars.picker.css" />
    <script type="text/javascript" src="/js/calender/jquery.plugin.js"></script>
    <script type="text/javascript" src="/js/calender/jquery.calendars.picker.js"></script>
    <script type="text/javascript" src="/js/calender/jquery.calendars.picker-ar.js"></script>
    <script type="text/javascript" src="/js/calender/jquery.calendars.islamic.js"></script>
    <script type="text/javascript" src="/js/calender/jquery.calendars.islamic-ar.js"></script>
    <script type="text/javascript" src="/js/calender/jquery.calendars.islamic-ar.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="Title BorderBottom"><%=name %></h1>
    
    <asp:HyperLink ID="HyperLink2" CssClass="tdn fl" NavigateUrl="#" runat="server"><h5><i class="fa fa-backward"></i> رجوع</h5></asp:HyperLink>
    <div class="clear PT20"></div>
    <section>
        <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
            <table class="tblConListOpt">
                
                
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="العنوان" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTitle" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="ملخص" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPrev" TextMode="MultiLine" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="التفاصيل" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTxt" TextMode="MultiLine" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
               
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="اللغة" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlLang" CssClass="ddl1" runat="server">
                            <asp:ListItem Text="English" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Arabic" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="تاريخ الاضافة" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <uc1:hijriCalender runat="server" Class="txtCal" ValidationGroup="Option3" ID="txtAddDate" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="الصورة" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:FileUpload ID="fileImg" CssClass="txt1" ValidationGroup="Option3" runat="server" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <a href="NewsList.aspx" class="btnLogin2 fr">الغاء</a>
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Option3" Text="حفظ" CssClass="btnLogin fr" />
                        
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </section>
    
</asp:Content>




