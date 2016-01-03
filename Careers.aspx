<%@ Page Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Careers.aspx.cs" Inherits="Careers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%@ Register Src="~/controls/Facebook.ascx" TagPrefix="uc1" TagName="Facebook" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container bounceInUp animated">
        <div class="fr">
            <h4><%=new Lang().getByKey("Careers") %></h4>
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <%#Eval("txt") %>
                </ItemTemplate>
            </asp:Repeater>

        </div>
        <div class="fl">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <h4><%=new Lang().getByKey("ContactInformation") %></h4>
                    <br />
                    <br />
                    <br />
                    <p>
                        <%#Eval("txt") %>
                    </p>


                </ItemTemplate>
            </asp:Repeater>
            <div class="space"></div>
            <uc1:Facebook runat="server" ID="Facebook" />
        </div>
    </div>

    <div class="space"></div>


</asp:Content>

