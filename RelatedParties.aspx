<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RelatedParties.aspx.cs" Inherits="RelatedParties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">

                <h4 class="inTitles"><%=new Lang().getByKey("RelatedParties") %></h4>


                <div class="MobileSpace"></div>
                <div class="allResearchers">
                    <asp:ListView ID="ListView1" runat="server">
                        <ItemTemplate>
                            <div class="singleExpert hvr-shadow">
                                <img class="img-responsive" src="/images/RelatedLinks/<%#Eval("img") %>" />
                                <h4><%#Eval("title") %></h4>


                                <div class="clearfix"></div>
                                <asp:HyperLink Target="_blank" ID="HyperLink1" CssClass="LLL" NavigateUrl='<%#Eval("url") %>' runat="server"><%#Eval("url").ToString().Replace("http://","").Replace("https://","") %></asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
            <div class="space"></div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

