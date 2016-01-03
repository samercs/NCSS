<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="ShowcaseOp.aspx.cs" Inherits="Admin_ShowcaseOp" %>


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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="Title BorderBottom">الصور المتحركة</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HyperLink ID="HyperLink2" CssClass="tdn fl" NavigateUrl="ShowCaseList.aspx" runat="server"><h5><i class="fa fa-backward"></i> رجوع</h5></asp:HyperLink>
    <div class="clear PT20"></div>
    <section>
        <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
            <table class="tblConListOpt">
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="العنوان" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTitle" ValidationGroup="Option3"  CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                
                
                
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="ترتيب العرض" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtShowOrder" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="اللغة" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlLang" CssClass="ddl1" runat="server">
                            <asp:ListItem Text="انجليزي" Value="1"></asp:ListItem>
                            <asp:ListItem Text="عربي" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="الصورة" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:FileUpload ID="fileImg" CssClass="ddl1"  runat="server" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <a href="ShowCaseList.aspx" class="btnLogin2 fr">الغاء</a>
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Option3" Text="حفظ" CssClass="btnLogin fr" /></td>
                </tr>
            </table>
        </asp:Panel>
    </section>

</asp:Content>



