<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="lightbox2-master/dist/css/lightbox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container bounceInUp animated">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="fr">
                    <h4><%#Eval("title") %></h4>
                    <%#Eval("txt") %>
                </div>
            </ItemTemplate>
        </asp:Repeater>
   
        <div class="fl">
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <a class="example-image-link" href="/images/images/<%#Eval("Src") %>" data-lightbox="example-set" data-title="<%#Eval("alt") %>"><img class=" SingleAboutImage img-responsive example-image" src="/images/images/<%#Eval("src") %>" alt=""/></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
      
        
    </div>
         
        <div class="space"></div>
        <div class="space"></div>
        <div class="space"></div>
 <script src="lightbox2-master/dist/js/lightbox.js"></script>
</asp:Content>

