<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Phenomenon.aspx.cs" Inherits="Phenomenon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container bounceInUp animated">
        <h4 class="inTitles"><%=new Lang().getByKey("Phenomenons") %></h4>
        <div class="Allph">

            <asp:ListView OnPagePropertiesChanged="ListView1_OnPagePropertiesChanged" ID="ListView1" runat="server">
                <ItemTemplate>
                    <div class="singlePho hvr-shadow">
                        <a href="/PhenomenonDetails.aspx?id=<%#Eval("id") %>">
                            <img class="img-responsive" src="images/SocialEvent/<%#Eval("img") %>" />
                            <h4><%#Eval("title") %></h4>
                            <p><%#Eval("txt") %></p>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <div class="clearfix"></div>

            <div class="pager">
            <asp:DataPager ID="DataPager1" PageSize="6" PagedControlID="ListView1" runat="server">
                <Fields>
                    <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                </Fields>
            </asp:DataPager>
        </div>

        </div>
    </div>
</asp:Content>

