<%@ Page Title="" EnableEventValidation="false" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SpecializedDatabases.aspx.cs" Inherits="SpecializedDatabases" %>

<%@ Register Src="~/controls/hijriCalender.ascx" TagPrefix="uc1" TagName="hijriCalender" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="space"></div>
            <div class="container   ">
                <h4 class="inTitles"><%=new Lang().getByKey("SpecializedDatabases") %> <a>
                    <asp:Label ID="lblcatname" runat="server" Text=""></asp:Label></a></h4>
                <br />

                <table class="inTabls2">
                    <tr>
                        <td colspan="5">
                            <table class="searchTable">
                                <tr>
                                    <td>
                                        <p><%=new Lang().getByKey("Search") %></p>
                                        <asp:TextBox Width="80%" ID="txtTitle" CssClass="inTextBox" runat="server"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:LinkButton OnClick="btnSearch_OnClick" ID="btnSearch" CssClass="Download" runat="server"><%=new Lang().getByKey("Search") %></asp:LinkButton>
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <ul class="list-inline">
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <asp:LinkButton OnCommand="LinkButton1_OnCommand" CommandArgument='<%#Eval("Id") %>' ID="LinkButton1" runat="server">
                                                <div class="linkList">
                                                    <img src="/images/DBCat/<%#Eval("img") %>"/>
                                                    <div>
                                                        <%#Eval("Title") %>
                                                    </div>
                                                </div>
                                            </asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </td>
                    </tr>
                    <tr class="TableTitle">
                        <td><%=new Lang().getByKey("ResearchTitle") %></td>
                        <td><%=new Lang().getByKey("Details") %></td>
                        <td><%=new Lang().getByKey("Explore") %></td>
                    </tr>


                    <asp:ListView ID="Repeater1" OnPagePropertiesChanged="Repeater1_OnPagePropertiesChanged" runat="server">
                        <ItemTemplate>
                            <tr class="TableDetails1">
                                <td style="min-width: 150px;"><%#Eval("Title") %></td>
                                <td><%#Eval("txt") %></td>
                                <td style="min-width: 150px;" class="DownloadBtn"><a target="_blank" href="<%#Eval("Url") %>"><%=new Lang().getByKey("Explore") %></a></td>
                            </tr>
                        </ItemTemplate>

                    </asp:ListView>



                </table>

                <div class="pager">
                    <asp:DataPager ID="DataPager1" PageSize="5" PagedControlID="Repeater1" runat="server">
                        <Fields>
                            <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                        </Fields>
                    </asp:DataPager>
                </div>



            </div>
            <div class="space"></div>
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>

