<%@ Page Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrganizationalStructure.aspx.cs" Inherits="OrganizationalStructure" %>

<%@ Register Src="~/controls/Images.ascx" TagPrefix="uc1" TagName="Images" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container bounceInUp animated">
        <h4 class="inTitles"><%=new Lang().getByKey("OrganizationalStructure") %></h4>
        <uc1:Images Key="OrganizationalStructure" cssClass="img-responsive StructurImage" runat="server" ID="Images" />
    </div>
    <div class="space"></div>
</asp:Content>

