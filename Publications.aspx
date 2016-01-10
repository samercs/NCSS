<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Publications.aspx.cs" Inherits="Publications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container   ">
        <h4 class="inTitles"><%=new Lang().getByKey("Publications") %></h4>
        <div class="fr">
            <asp:ListView OnPagePropertiesChanged="ListView1_OnPagePropertiesChanged" ID="ListView1" runat="server">
                <ItemTemplate>
                    <div class="singlePub">
                        <img  src="/images/Publications/<%#Eval("img") %>" />
                        <h4><%#Eval("title") %></h4>
                        <%#Eval("prev") %> 
                        <a href="/PublicationsDetails.aspx?id=<%#Eval("id") %>"><%=new Lang().getByKey("Details") %></a>
                    </div>
                    <div class="clear"></div>
                </ItemTemplate>
            </asp:ListView>

            <div class="clearfix"></div>

            <div class="pager">
                <asp:DataPager ID="DataPager1" PageSize="3" PagedControlID="ListView1" runat="server">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                    </Fields>
                </asp:DataPager>
            </div>

            
        </div>
        <div class="fl marg">


            <div class="LeftDetails">
                <h4><%=new Lang().getByKey("LatestNews") %></h4>
                <div class="NewsArrow"></div>

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <a href="/NewsDetails.aspx?id=<%#Eval("id") %>">
                            <div class="SingleNewsHome hvr-shadow">
                                <img class="img-responsive" src="images/News/<%#Eval("img") %>" />
                                <h5><%#Eval("title") %></h5>
                                <%#Eval("prev") %>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>


            </div>

            <div class="LeftDetails">
                <h4><%=new Lang().getByKey("LatestPhenomenons") %></h4>
                <div class="NewsArrow"></div>


                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <a href="/PhenomenonDetails.aspx?id=<%#Eval("id") %>">
                            <div class="SingleNewsHome hvr-shadow">
                                <img class="img-responsive" src="images/SocialEvent/<%#Eval("img") %>" />
                                <h5><%#Eval("title") %></h5>
                                <%#Eval("txt") %>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>


            </div>
            <div class="NewsbtnImg"></div>
        </div>

    </div>
</asp:Content>

