<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResearchersForm.aspx.cs" Inherits="ResearchersForm" %>

<%@ Register Src="~/controls/Facebook.ascx" TagPrefix="uc1" TagName="Facebook" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="space"></div>
    <div class="container bounceInUp animated">
        <div class="fr">
            <h4><%=new Lang().getByKey("ResearchersForm") %></h4>
            <asp:Panel ID="Panel1" DefaultButton="btnSend" runat="server">
            <table class="FormTable">
                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtName" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Name") %></td>
                </tr>
                 <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Password") %></td>
                </tr>
                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtConfirmPass" TextMode="Password" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("ConfirmPass") %></td>
                </tr>
                <tr>

                    <td class="txb">
                        <asp:DropDownList CssClass="FormTextBox" ID="ddlCountry" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="lbl">*<%=new Lang().getByKey("Country") %></td>
                </tr>
                    <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtQualification" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Qualification") %></td>
                </tr>
                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtMajor" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Major") %></td>
                </tr>
                   <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtSpecialization" runat="server"></asp:TextBox></td>
                    <td class="lbl"><%=new Lang().getByKey("Specialization") %></td>
                </tr>

                <tr>

                    <td class="txb">
                        <asp:DropDownList CssClass="FormTextBox" ID="ddlDegree" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="lbl">*<%=new Lang().getByKey("Degree") %></td>
                </tr>

                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtWorkPlace" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("WorkPlace") %></td>
                </tr>
                   <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtCurrentWork" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("CurrentWork") %></td>
                </tr>
                  <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtMobile" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Mobile") %></td>
                </tr>
                 <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtPhone" runat="server"></asp:TextBox></td>
                    <td class="lbl"><%=new Lang().getByKey("Phone") %></td>
                </tr>
                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtEmail" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Email") %></td>
                </tr>
               
               

                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtFacebook" runat="server"></asp:TextBox></td>
                    <td class="lbl"><%=new Lang().getByKey("FacebookLink") %></td>
                </tr>

                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtTwitter" runat="server"></asp:TextBox></td>
                    <td class="lbl"><%=new Lang().getByKey("TwitterLink") %></td>
                </tr>

                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtLinkedin" runat="server"></asp:TextBox></td>
                    <td class="lbl"><%=new Lang().getByKey("LinkedInLink") %></td>
                </tr>

                <tr class="Mutiline">
                    <td class="txb">
                        <asp:TextBox Height="130" TextMode="MultiLine" CssClass="FormTextBox" ID="txtPrev" runat="server"></asp:TextBox></td>
                    <td class="lbl"><%=new Lang().getByKey("Brief") %></td>
                </tr>

                <tr>

                    <td class="txb">
                        <asp:FileUpload ID="fileImage" CssClass="FileUpload" runat="server" /></td>
                    <td class="lbl">*<%=new Lang().getByKey("Image") %></td>
                </tr>
                   <tr>

                    <td class="txb">
                        <asp:FileUpload ID="fileCv"  CssClass="FileUpload" runat="server" /></td>
                    <td class="lbl">*<%=new Lang().getByKey("CV") %></td>
                </tr>
                <tr>

                    <td colspan="2" class="AlignRight">
                        <a class="savebtn hvr-push" href="/Experts.aspx"><%=new Lang().getByKey("Cancel") %></a>
                        <asp:LinkButton OnClick="btnSend_OnClick" CssClass="savebtn2 hvr-push" ID="btnSend" runat="server"><%=new Lang().getByKey("Submit") %></asp:LinkButton>
                    </td>

                </tr>
            </table>
                </asp:Panel>

        </div>
        <div class="fl">

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <h4><%#Eval("title") %></h4>
                    <br />
                    <br />
                    <br />
                    <p>
                        <%#Eval("prev") %>
                    </p>
                </ItemTemplate>
            </asp:Repeater>


            <div class="space"></div>
            <uc1:Facebook runat="server" ID="Facebook" />
        </div>
    </div>

    <div class="space"></div>

    <script>
        alertify.defaults.glossary.title = '<%=new Lang().getByKey("SiteTitle")%>';
    </script>
</asp:Content>

