<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ImagesOp.aspx.cs" Inherits="Admin_ImagesOp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="Title BorderBottom">صور الموقع</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HyperLink ID="HyperLink2" CssClass="tdn fl" NavigateUrl="ImagesList.aspx" runat="server"><h5><i class="fa fa-backward"></i> رجوع</h5></asp:HyperLink>
    <div class="clear PT20"></div>
    <section>
        <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
            <table class="tblConListOpt">
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="الرمز" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ReadOnly="True" ID="txtImgKey" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="العرض" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtWidth"  ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="الارتفاع" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtHieght"  ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="النص البديل" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtAlt" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
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
                        <asp:Label ID="Label10" runat="server" Text="الصورة" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:FileUpload ID="fileImg" CssClass="txt1" ValidationGroup="Option3" runat="server" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <a href="ImagesList.aspx" class="btnLogin2 fr">الغاء</a>
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Option3" Text="حفظ" CssClass="btnLogin fr" /></td>
                </tr>
            </table>
        </asp:Panel>
    </section>

</asp:Content>


