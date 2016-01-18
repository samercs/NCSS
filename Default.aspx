<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/controls/Twitter.ascx" TagPrefix="uc1" TagName="Twitter" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div id="myCarousel" runat="server" class="  carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="item <%#Container.ItemIndex==0 ? "active" : ""  %>">
                            <p><%#Eval("title") %></p>
                            <img src="images/Showcase/<%#Eval("img") %>" class="ShowcaseImage img-responsive" alt="<%#Eval("title") %>">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only"><%= new Lang().getByKey("Previous") %></span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only"><%= new Lang().getByKey("Next") %></span>
            </a>
        </div>
        <div class="clearfix"></div>
        <div class="space"></div>
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <div class="HomeText">
                    <h4><%#Eval("title") %></h4>
                    <p><%#Eval("prev") %></p>
                    <a class="More" href="About.aspx?id=21"><%=new Lang().getByKey("More") %></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <iframe class="AboutImage" src="https://www.youtube.com/embed/I7c28RlcIDM" frameborder="0" allowfullscreen></iframe>
    </div>


    <div class="clearfix"></div>
    <div class="space"></div>
    <section style="display: none;">
        <div id="scdLine">
            <h4><%=new Lang().getByKey("LatestResearches") %></h4>
        </div>
        <div id="ThdLine">
            <h4><%= new Lang().getByKey("LatestPublications") %></h4>
        </div>
        <div class="container">
            <div class="HomeRight">
                <asp:Repeater ID="Repeater6" runat="server">
                    <ItemTemplate>
                        <p class="ResearchLinks">
                            <asp:HyperLink download='<%#Eval("file") %>' ID="HyperLink3" NavigateUrl='<%#Eval("File","~/images/Library/{0}") %>' runat="server"><%#Eval("Title") %></asp:HyperLink>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div id="ThdLineMobile">
                <h4><%= new Lang().getByKey("LatestPublications") %></h4>
            </div>
            <div class="MobileSpace"></div>
            <div class="HomeLeft">
                <asp:Repeater ID="Repeater4" runat="server">
                    <ItemTemplate>
                        <asp:HyperLink NavigateUrl='<%#Eval("id","~/PublicationsDetails.aspx?id={0}") %>' ID="HyperLink2" runat="server">
                            <div class="SingleNewsHome hvr-shadow ">
                                <asp:Image ImageUrl='<%#Eval("img","~/images/Publications/{0}") %>' ID="Image1" runat="server" />
                                <h5><%#Eval("title") %></h5>
                                <%#Eval("prev") %>
                            </div>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

    <div class="clearfix"></div>
    <div class="space"></div>
    <div class="container">
        <div class="singlebox">
            <h4><%= new Lang().getByKey("LatestNews") %></h4>
            <asp:Repeater ID="Repeater5" runat="server">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%#Eval("id","~/NewsDetails.aspx?id={0}") %>' ID="HyperLink2" runat="server">
                        <div class="SingleNewsHome  hvr-shadow">
                            <asp:Image ImageUrl='<%#Eval("img","~/images/News/{0}") %>' ID="Image1" runat="server" />
                            <h5><%#Eval("title") %></h5>
                            <%#Eval("prev") %>
                        </div>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>


        </div>
        <div class="singlebox">
            <h4><%=new Lang().getByKey("LatestTweets") %></h4>
            <uc1:Twitter class="Twitter" runat="server" ID="Twitter" />
        </div>
        <div class="singlebox " style="position: relative;">


            <h4><%=new Lang().getByKey("OpinionPoll") %></h4>
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

    <div class="clearfix"></div>
    <div class="space"></div>
    <div id="fstLine">
        <h4><%= new Lang().getByKey("OurPartners") %></h4>
    </div>
    <br />
    <div class="container">
        <div id="amazingcarousel-container-1" style="direction: ltr;">
            <div id="amazingcarousel-1">
                <div class="amazingcarousel-list-container">
                    <ul class="amazingcarousel-list">

                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <li class="amazingcarousel-item">
                                    <div class="amazingcarousel-item-container">
                                        <div class="amazingcarousel-image">

                                            <a href="<%#Eval("Url") %>">
                                                <asp:Image ID="Image2" CssClass="Spon" ImageUrl='<%#Eval("img","~/images/Partners/{0}") %>' runat="server" />
                                                <div class="amazingcarousel-text">
                                                    <div class="amazingcarousel-text-bg"></div>
                                                    <div class="amazingcarousel-title"></div>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>



                    </ul>
                </div>
                <div class="amazingcarousel-prev"></div>
                <div class="amazingcarousel-next"></div>

            </div>
        </div>
    </div>

    <div class="clearfix"></div>

    <div class="space"></div>
    <script src="carouselengine/amazingcarousel.js"></script>
    <link rel="stylesheet" type="text/css" href="carouselengine/initcarousel-1.css">
    <script src="carouselengine/initcarousel-1.js"></script>


</asp:Content>
