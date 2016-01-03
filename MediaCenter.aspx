<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MediaCenter.aspx.cs" Inherits="MediaCenter" %>

<%@ Register Src="~/controls/Vedio.ascx" TagPrefix="uc1" TagName="Vedio" %>
<%@ Register Src="~/controls/Twitter.ascx" TagPrefix="uc1" TagName="Twitter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="lightbox2-master/dist/css/lightbox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container  ">
        <div class="fr">
            <h4 class="inTitles"><%=new Lang().getByKey("MediaCenter") %></h4>
            <h5 class="Fullback"><%=new Lang().getByKey("News") %></h5>

            <asp:ListView OnPagePropertiesChanged="ListView1_OnPagePropertiesChanged" ID="ListView1" runat="server">
                <ItemTemplate>
                    <a href="/NewsDetails.aspx?id=<%#Eval("id") %>">
                        <div class="SingleNewsHome hvr-shadow">
                            <img src="images/News/<%#Eval("img") %>" />
                            <h5><%#Eval("title") %></h5>
                        <%#Eval("Prev") %>
                        </div>
                    </a>
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
            <h5 class="Fullback3"><%=new Lang().getByKey("VideoCenter") %></h5>
            <asp:ListView OnPagePropertiesChanged="ListView2_OnPagePropertiesChanged" ID="ListView2" runat="server">
                <ItemTemplate>
                    <iframe class="Vedio" src="https://www.youtube.com/embed/<%#Eval("url") %>" frameborder="0" allowfullscreen></iframe>
                </ItemTemplate>
            </asp:ListView>

            <div class="clearfix"></div>

            <div class="pager">
                <asp:DataPager ID="DataPager2" PageSize="1" PagedControlID="ListView2" runat="server">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                    </Fields>
                </asp:DataPager>
            </div>

        </div>
        <div class="fl">
            <h5 class="Fullback2"><%=new Lang().getByKey("PhotoGallery") %></h5>

            <asp:ListView OnPagePropertiesChanged="ListView3_OnPagePropertiesChanged" ID="ListView3" runat="server">
                <ItemTemplate>
                    <a class="example-image-link" href="/images/Albums/<%#Eval("img") %>" data-lightbox="example-set" data-title="">
                        <img class="  SingleAboutImage img-responsive example-image" src="/images/Albums/<%#Eval("img") %>" alt="" /></a>
                </ItemTemplate>
            </asp:ListView>

            <div class="clearfix"></div>

            <div class="pager">
                <asp:DataPager ID="DataPager3" PageSize="6" PagedControlID="ListView3" runat="server">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                    </Fields>
                </asp:DataPager>
            </div>

            <h5 class="Fullback4"><%=new Lang().getByKey("LatestTweets") %></h5>
            <div class="Tw">
                <uc1:Twitter runat="server" ID="Twitter" />
            </div>
        </div>
        <div class="clearfix"></div>
        <h5 class="Fullback5"><%=new Lang().getByKey("ReportsandStatistics") %></h5>

        <asp:ListView OnPagePropertiesChanged="ListView4_OnPagePropertiesChanged" ID="ListView4" runat="server">
            <ItemTemplate>
                <div class="singlePho">
                    <a href="/ReportDetails.aspx?id=<%#Eval("id") %>">
                        <img class="img-responsive" src="/images/Report/<%#Eval("img") %>" />
                        <h4><%#Eval("title") %></h4>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>

        <div class="clearfix"></div>

        <div class="pager">
            <asp:DataPager ID="DataPager4" PageSize="3" PagedControlID="ListView4" runat="server">
                <Fields>
                    <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                </Fields>
            </asp:DataPager>
        </div>

    </div>
    <div class="space"></div>
    <script src="lightbox2-master/dist/js/lightbox.js"></script>
</asp:Content>

