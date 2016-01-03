<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminOp.aspx.cs" Inherits="Admin_AdminOp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="Title BorderBottom">المستخدمين</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HyperLink ID="HyperLink2" CssClass="tdn fl" NavigateUrl="AdminList.aspx" runat="server"><h5><i class="fa fa-backward"></i> رجوع</h5></asp:HyperLink>
    <div class="clear PT20"></div>
    <section>
        <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
            <table class="tblConListOpt">
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="الاسم" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtFirstName" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                   <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="اسم المستخدم" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtUsername" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="البريد الالكتروني" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtEmail" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="كلمة السر" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPassword" ValidationGroup="Option3" CssClass="txt1" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="الصلاحيات" CssClass="label_xblack"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlPermition" CssClass="ddl1" runat="server">
                            <asp:ListItem Text="مدير" Value="1"></asp:ListItem>
                            <asp:ListItem Text="محرر" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td colspan="2">
                        <a href="AdminList.aspx" class="btnLogin2 fr">الغاء</a>
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Option3" Text="حفظ" CssClass="btnLogin fr" /></td>
                </tr>
            </table>
        </asp:Panel>
    </section>

</asp:Content>

