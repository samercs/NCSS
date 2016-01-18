<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MediaCenter.aspx.cs" Inherits="MediaCenter" %>

<%@ Register Src="~/controls/Vedio.ascx" TagPrefix="uc1" TagName="Vedio" %>
<%@ Register Src="~/controls/Twitter.ascx" TagPrefix="uc1" TagName="Twitter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="lightbox2-master/dist/css/lightbox.css" rel="stylesheet" />
    <link href="js/owl-carousel/owl.carousel.css" rel="stylesheet" />
    <link href="js/owl-carousel/owl.theme.css" rel="stylesheet" />
    <script src="js/owl-carousel/owl.carousel.min.js"></script>
    <script>
        $(document).ready(function () {

            $("#owl-demo").owlCarousel({
                items: 1,
                lazyLoad: true,
                navigation: false, singleItem: true, responsive:true
            });

        });
    </script><style>
                 .SingleAboutImage {
                     width:48% !important;
                 }
             </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
    <div class="space"></div>
    <div class="container">
        <div class="fr w45">
            <h4 class="inTitles"><%=new Lang().getByKey("MediaCenter") %></h4>
            <h5 class="Fullback"><%=new Lang().getByKey("News") %></h5>
            <div id="owl-demo" class="owl-carousel">
            <asp:ListView  ID="ListView1" runat="server">
                <ItemTemplate>
                    <a class="newsitem item" href="/NewsDetails.aspx?id=<%#Eval("id") %>">
                        <div class="hvr-shadow">
                            <img class="lazyOwl" data-src="images/News/<%#Eval("img") %>" alt=" <%#Eval("title") %>"  />
                        <%#Eval("Prev") %>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:ListView>
            </div>
            <div class="clearfix"></div>
             
               <h5 class="Fullback2" style="width:100%;"><%=new Lang().getByKey("PressKit") %></h5>
    
                        <div class="PressKits">    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
            <asp:ListView OnPagePropertiesChanged="ListView5_PagePropertiesChanged" ID="ListView5" runat="server">
                <ItemTemplate>
                   <div class="item">
                     <a href="PressKitDetails.aspx?id=<%# Eval("id") %>">
                           <img src="images/PressKit/<%#Eval("img") %>" />
                       <h5><%#Eval("title") %>
                           <br />
                      <span>
                          <%#new Dates().GregToHijri(Eval("AddDate","{0:dd/MM/yyyy}"),"dd/MMM/yyyy") %>
                      </span>
                       </h5>
                     </a>
                   </div>
                </ItemTemplate>
            </asp:ListView>

            <div class="clearfix"></div>
            <div class="pager">
                <asp:DataPager ID="DataPager1" PageSize="3" PagedControlID="ListView5" runat="server">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                    </Fields>
                </asp:DataPager>
            </div></ContentTemplate></asp:UpdatePanel>
                      <div class="clearfix"></div>
        <h5 class="Fullback5" style="width:100%;"><%=new Lang().getByKey("ReportsandStatistics") %></h5>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
 <section class="p0m0">
            <asp:ListView OnPagePropertiesChanged="ListView4_OnPagePropertiesChanged" ID="ListView4" runat="server">
            <ItemTemplate>
                <div class="singlePho ti7sa2">
                    <a href="/ReportDetails.aspx?id=<%#Eval("id") %>">
                        <img class="img-responsive" style="    max-height: 165px;" src="/images/Report/<%#Eval("img") %>" />
                        <h4><%#Eval("title") %></h4>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
 </section>
   <div class="clearfix"></div>
            <div class="pager">
                <asp:DataPager ID="DataPager4" PageSize="2" PagedControlID="ListView4" runat="server">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                    </Fields>
                </asp:DataPager>
                   
            </div> </ContentTemplate></asp:UpdatePanel> <div class="clearfix"></div> 
                              <h5 style="width:100%;" class="Fullback4"><%=new Lang().getByKey("LatestTweets") %></h5>
            <div class="Tw">
                <uc1:Twitter runat="server" ID="Twitter" />
            </div>
</div>
         

        </div>
        <div class="fl w40">
                   
            <h5 style="width:100%;" class="Fullback2"><%=new Lang().getByKey("VideoCenter") %></h5>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                     <asp:ListView OnPagePropertiesChanged="ListView2_OnPagePropertiesChanged" ID="ListView2" runat="server">
                <ItemTemplate>
                    <iframe class="Vedio" style="max-height:275px;margin-bottom:5px;" src="https://www.youtube.com/embed/<%#Eval("url") %>" frameborder="0" allowfullscreen></iframe>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <h5 style="width:100%;" class="Fullback3"><%=new Lang().getByKey("PhotoGallery") %></h5>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
            <asp:ListView OnPagePropertiesChanged="ListView3_OnPagePropertiesChanged" ID="ListView3" runat="server">
                <ItemTemplate>
                    <a class="example-image-link" href="/images/Albums/<%#Eval("img") %>" data-lightbox="example-set" data-title="">
                        <img class="  SingleAboutImage img-responsive example-image" src="/images/Albums/<%#Eval("img") %>" alt="" /></a>
                </ItemTemplate>
            </asp:ListView>

            <div class="clearfix"></div>

            <div class="pager">
                <asp:DataPager ID="DataPager3" PageSize="4" PagedControlID="ListView3" runat="server">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                    </Fields>
                </asp:DataPager>
            </div></ContentTemplate></asp:UpdatePanel>
               <div class="clearfix"></div>
              <h5 style="width:100%;" class="Fullback3 mb4em"><%=new Lang().getByKey("OpinionPoll") %></h5>  <div class="clearfix"></div>
               <div class="singlebox " style="width: 100%;">
            <asp:Repeater ID="Repeater7" OnItemDataBound="Repeater8_OnItemDataBound" runat="server">
                <ItemTemplate>
                    <p class="LastBoxText"><%#Eval("title") %></p>
                    <div class="clearfix"></div>

                    <asp:Repeater OnItemCommand="Repeater8_OnItemCommand" ID="Repeater8" runat="server">
                        <ItemTemplate>
                            <asp:HiddenField ID="pollid" Value='<%#Eval("PollId") %>' runat="server" />
                            <asp:HiddenField ID="optionid" Value='<%#Eval("id") %>' runat="server" />
                            <div class="progress">
                                <div class="progress-bar progress-bar-info pull-right" role="progressbar" aria-valuenow="50"
                                    aria-valuemin="0" aria-valuemax="100" style="width: <%#Eval("per") %>%">
                                    <%#Eval("per","{0:0.00}") %> %
                                </div>
                            </div>

                            <asp:LinkButton CssClass="boxBtn" ID="LinkButton1" runat="server"><%# Page.Culture.Contains("Arabic") ?  Eval("titleAr") : Eval("title") %></asp:LinkButton>
                            <div class="clearfix"></div>

                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="height: 1em; width: 100%;"></div>


                    <div class="LinkText">
                        <asp:HyperLink NavigateUrl="~/Poll.aspx" ID="HyperLink4" runat="server"><%=new Lang().getByKey("PreviousOpinionPolls") %></asp:HyperLink>
                    </div>
                    <div style="height: 0.4em; width: 100%;"></div>
                    <asp:HiddenField ID="id" Value='<%#Eval("id") %>' runat="server" />
                </ItemTemplate>
            </asp:Repeater>


        </div>
          
        </div>
      
    </div>
    <div class="space"></div>
               
    <script src="lightbox2-master/dist/js/lightbox.js"></script>
</asp:Content>

