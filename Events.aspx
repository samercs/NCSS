<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" %>

<%@ Register Src="~/controls/hijriCalender.ascx" TagPrefix="uc1" TagName="hijriCalender" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <script type="text/javascript" src="//maps.google.com/maps/api/js?sensor=true"></script>
    <script src="js/map.js"></script>

    <link href="/Admin/Styles/font-awesome-4.4.0/css/font-awesome.css" rel="stylesheet" />
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
    <div class="container">
        <h4 class="inTitles"><%=new Lang().getByKey("EventsActivities") %></h4>
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

        <table class="inTabls2">
            <tr class="TableTitle">
                <td style="width: 20%">
                    <%=new Lang().getByKey("Image") %>
                </td>
                <td colspan="2" style="width: 20%">
                    <%=new Lang().getByKey("EventName") %>
                </td>
                <td style="width: 20%">
                    <%=new Lang().getByKey("Prev") %>
                </td>
                <td style="width: 20%">
                    <%=new Lang().getByKey("Location") %>
                </td>
                <td style="width: 10%">
                    <%=new Lang().getByKey("AttachedDoc") %>
                </td>
                <td style="width: 10%">
                    <%=new Lang().getByKey("Register") %>
                </td>
            </tr>
            <asp:ListView OnItemDataBound="ListView1_OnItemDataBound" OnPagePropertiesChanged="ListView1_OnPagePropertiesChanged" ID="ListView1" runat="server">
                <ItemTemplate>
                    <asp:HiddenField ID="id" Value='<%#Eval("id") %>' runat="server" />
                    <tr class="TableDetails1">
                        <td rowspan="2">
                            <img class="img img-responsive" src="images/Event/<%#Eval("img") %>" />
                        </td>
                        <td colspan="2">
                            <%#Eval("title") %>
                        </td>
                        <td  rowspan="2">
                            <%#Eval("txt").ToString().Length > 250 ? Eval("txt").ToString().Substring(0,249) + "..." : Eval("txt") %>
                        </td>
                        <td rowspan="2">
                            <div id="map<%# Container.DataItemIndex %>" class="EventMap">
                            </div>

                        </td>
                        <td rowspan="2">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <div>
                                        <a href="images/EventDoc/<%#Eval("url") %>"><%#Eval("name") %></a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </td>
                        <td rowspan="2">
                            
                            <%# Eval("IsOpen").ToString().ToLower().Equals("false") ? new Lang().getByKey("Unavilable") : new Lang().getByKey("Avilable")  %>
                            <br/>
                            <a <%# Eval("IsOpen").ToString().ToLower().Equals("false") ?  "style='display:none'" : "" %> href="EventsReg.aspx?id=<%#Eval("id") %>"><%=new Lang().getByKey("Register") %></a>

                        </td>
                    </tr>
                    <tr class="TableDetails1">
                        <td  style="direction: rtl;"><%=new Lang().getByKey("StartDate") %> <br/><%# new Dates().GregToHijri(Eval("EventDate","{0:dd/MM/yyyy}"),"dd/MMM/yyyy") %></td>
                        <td  style="direction: rtl;"><%=new Lang().getByKey("EndDate") %> <br/><%# new Dates().GregToHijri(Eval("EventDateEnd","{0:dd/MM/yyyy}"),"dd/MMM/yyyy") %></td>
                    </tr>


                    <script>
                        $(function () {

                            var all = '<%#Eval("map")%>'.split(',');
                                    var lat = all[0];
                                    var lng = all[1];
                                    var map = new GMaps({
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
        </table>
        <div class="clearfix"></div>

        <div class="pager">
            <asp:DataPager ID="DataPager1" PageSize="3" PagedControlID="ListView1" runat="server">
                <Fields>
                    <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                </Fields>
            </asp:DataPager>
        </div>



    </div>



</asp:Content>
