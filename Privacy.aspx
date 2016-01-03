<%@ Page Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Privacy.aspx.cs" Inherits="Privacy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="space"></div>
      <div class="container bounceInUp animated">
        
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <h4><%#Eval("Title") %></h4>
                    <%#Eval("txt") %>
                </ItemTemplate>
            </asp:Repeater>
      </div>
    <div class="space"></div>
</asp:Content>

