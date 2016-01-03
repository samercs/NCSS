<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" %>

<%@ Register Src="~/controls/hijriCalender.ascx" TagPrefix="uc1" TagName="hijriCalender" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    
    <script type="text/javascript" src="//maps.google.com/maps/api/js?sensor=true"></script>
    <script src="js/map.js"></script>

    <link href="/Admin/Styles/font-awesome-4.4.0/css/font-awesome.css" rel="stylesheet"/>
    <script type="text/javascript" src="js/calender/jquery.calendars.js"></script>
    <script type="text/javascript" src="js/calender/jquery.calendars.plus.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/calender/jquery.calendars.picker.css" />
    <script type="text/javascript" src="js/calender/jquery.plugin.js"></script>
    <script type="text/javascript" src="js/calender/jquery.calendars.picker.js"></script>
    <script type="text/javascript" src="js/calender/jquery.calendars.picker-ar.js"></script>
    <script type="text/javascript" src="js/calender/jquery.calendars.islamic.js"></script>
    <script type="text/javascript" src="js/calender/jquery.calendars.islamic-ar.js"></script>
    <script type="text/javascript" src="js/calender/jquery.calendars.islamic-ar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container   ">
        <h4 class="inTitles"><%=new Lang().getByKey("EventsActivities") %></h4>


        <div class="fr">
           

            <table class="inTabls2">
                <tr>
                    <td>
                        <p><%=new Lang().getByKey("Name") %></p>
                        <asp:TextBox ID="txtname" CssClass="inTextBox" runat="server"></asp:TextBox>
                    </td>

                    <td>
                        <p><%=new Lang().getByKey("Date") %></p>
                        <uc1:hijriCalender Class="txtCal inTextBox" runat="server" ID="txtDate" />
                    </td>

                    <td>
                        <asp:LinkButton OnClick="btnSearch_OnClick" CssClass="Download" ID="btnSearch" runat="server"><%=new Lang().getByKey("Search") %></asp:LinkButton>
                    </td>



                </tr>
            </table>
           

            
            <div class="clearfix"></div>


            <asp:ListView OnPagePropertiesChanged="ListView1_OnPagePropertiesChanged" ID="ListView1" runat="server">
                <ItemTemplate>
                    <div class="singleEevent">
                        <div id="map<%# Container.DataItemIndex %>" class="EventMap">
                        </div>
                        <h5><%#Eval("title") %></h5>
                        <%#Eval("txt") %>
                        <img class="img-responsive" src="images/CalIcon.png" />  <h5 class="EventDate"><%=new Lang().getByKey("Date") %> : <div style="direction: rtl;display: inline-block"><%#new Dates().GregToHijri(Eval("EventDate","{0:dd/MM/yyyy}"),"dd/MMM/yyyy") %></div></h5>

                    </div>
                    <script>
                        $(function () {

                            var all = '<%#Eval("map")%>'.split(',');
                            var lat = all[0];
                            var lng = all[1];
                            var map=new GMaps({
                                div: '#map<%# Container.DataItemIndex %>',
                                lat: lat,
                                lng: lng
                            });

                            map.addMarker({
                                lat: lat,
                                lng: lng
                            });

                        });
                    </script>
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
                            <div class="SingleNewsHome  hvr-shadow">
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
                            <div class="SingleNewsHome  hvr-shadow">
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

