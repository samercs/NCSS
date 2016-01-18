<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%@ Register Src="~/controls/Facebook.ascx" TagPrefix="uc1" TagName="Facebook" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="space"></div>
    <div class="container  ">
        <div class="fr">
            <h4><%=new Lang().getByKey("ContactUs") %></h4>

            <table class="FormTable">
                <tr style="display:none;">
                    <td class="txb">
                        <asp:DropDownList CssClass="FormTextBox" ID="ddlTitle" runat="server">
                            
                        </asp:DropDownList></td>
                    <td class="lbl">Title</td>
                </tr>
                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtName" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Name") %></td>
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
                        <asp:TextBox CssClass="FormTextBox" ID="txtEmail" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Email") %></td>
                </tr>

                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtPhone" runat="server"></asp:TextBox></td>
                    <td class="lbl"><%=new Lang().getByKey("Phone") %></td>
                </tr>



                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtSubject" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Subject") %></td>
                </tr>

                <tr class="Mutiline">
                    <td class="txb">
                        <asp:TextBox  Height="130"  TextMode="MultiLine" CssClass="FormTextBox2" ID="txtMessage" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Message") %></td>
                </tr>
                <tr>

                    <td>

                        <a class="savebtn2 hvr-push" href="/Default.aspx"><%=new Lang().getByKey("Cancel") %></a>
                         <asp:LinkButton OnClick="LinkButton1_OnClick" CssClass="savebtn hvr-push" ID="LinkButton1" runat="server"><%=new Lang().getByKey("Send") %></asp:LinkButton>
                    </td>
                    <td class="lbl"></td>
                </tr>
            </table>

        </div>
        <div class="fl">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                   <div id="MobileDisplaynone">
                   <h4><%=new Lang().getByKey("ContactInformation") %></h4>
                    <br />
                    <br />
                    <br />
                    
                    <p>
                       <%#Eval("txt") %>
                   </p>
                  </div> 
                </ItemTemplate>
            </asp:Repeater>


            <div class="space"></div>
            <uc1:Facebook runat="server" ID="Facebook" />
        </div>
        <div class="clearfix"></div>
        <h4 class="inTitles"><%=new Lang().getByKey("OurMap") %></h4>
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <iframe src="<%#Eval("txt") %>" class="EventMap2"></iframe>
            </ItemTemplate>
        </asp:Repeater>

    </div>

    <div class="space"></div>
    
    
    <script>
       alertify.defaults.glossary.title = '<%=new Lang().getByKey("SiteTitle")%>';
   </script>
</asp:Content>

