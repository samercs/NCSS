﻿<%@ Page Title="" EnableEventValidation="false" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="library.aspx.cs" Inherits="library" %>

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
    <asp:ScriptManager  ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="space"></div>
            <div class="container   ">
                <h4 class="inTitles"><%=new Lang().getByKey("Library") %> > <a>
                    <asp:Label ID="lblcatname" runat="server" Text=""></asp:Label></a></h4>
                <br />

                <table class="inTabls2">
                    <tr>
                        <td colspan="5">
                            <table class="searchTable">
                                <tr>
                                    <td>
                                        <p><%=new Lang().getByKey("Title") %></p>
                                        <asp:TextBox ID="txtTitle" CssClass="inTextBox" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p><%=new Lang().getByKey("Type") %></p>
                                        <asp:DropDownList CssClass="inTextBox" ID="ddlType" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <p><%=new Lang().getByKey("From") %></p>
                                        <uc1:hijriCalender Class="inTextBox" runat="server" ID="txtFrom" />
                                    </td>
                                    <td>
                                        <p><%=new Lang().getByKey("To") %></p>
                                        <uc1:hijriCalender Class="inTextBox" runat="server" ID="txtTo" />
                                    </td>
                                    <td>
                                        <p><%=new Lang().getByKey("Language") %></p>
                                        <asp:DropDownList CssClass="inTextBox" ID="ddlLang" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton OnClick="btnSearch_OnClick" ID="btnSearch" CssClass="Download" runat="server"><%=new Lang().getByKey("Search") %></asp:LinkButton>
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr class="TableTitle">
                        <td><%=new Lang().getByKey("ResearchTitle") %></td>
                        <td><%=new Lang().getByKey("Writer") %></td>
                        <td><%=new Lang().getByKey("PublishDate") %></td>
                        <td><%=new Lang().getByKey("Language") %></td>
                        <td><%=new Lang().getByKey("Download") %></td>
                    </tr>


                    <asp:ListView ID="Repeater1" OnPagePropertiesChanged="Repeater1_OnPagePropertiesChanged" runat="server">
                        <ItemTemplate>
                            <tr class="TableDetails1">
                                <td><%#Eval("Title") %></td>
                                <td><%#Eval("Writer") %></td>
                                <td style="direction: rtl;"><%# new Dates().GregToHijri(Eval("PublishDate","{0:dd/MM/yyyy}"),"dd/MMM/yyyy") %></td>
                                <td><%#Eval("lang").ToString().Equals("1") ? new Lang().getByKey("English") : new Lang().getByKey("Arabic2") %></td>
                                <td class="DownloadBtn"><a href="/images/Library/<%#Eval("file") %>" download="<%#Eval("file") %>"><img src="images/download.png" width="25"/></a></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="TableDetails2">
                                <td><%#Eval("Title") %></td>
                                <td><%#Eval("Writer") %></td>
                                <td style="direction: rtl;"><%# new Dates().GregToHijri(Eval("PublishDate","{0:dd/MM/yyyy}"),"dd/MMM/yyyy") %></td>
                                <td><%#Eval("lang").ToString().Equals("1") ? new Lang().getByKey("English") : new Lang().getByKey("Arabic2") %></td>
                                <td class="DownloadBtn"><a href="/images/Library/<%#Eval("file") %>" download="<%#Eval("file") %>"><img src="images/download.png" width="25"/></a></td>
                            </tr>
                        </AlternatingItemTemplate>
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

    
    <script type="text/javascript">
        
        $(function () {
            initPage();
            

        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    initPage();
                }
            });
        };

        function initPage() {
            

            $("#<%=txtFrom.ClientID%>_TextBox1").calendarsPicker($.extend(
            { calendar: $.calendars.instance('islamic', 'ar'), dateFormat: "dd/mm/yyyy", showTrigger: '<button type="button" class="trigger"><i class="fa fa-calendar"></i></button>' },
            $.calendarsPicker.regionalOptions['ar']));



            $("#<%=txtTo.ClientID%>_TextBox1").calendarsPicker($.extend(
            { calendar: $.calendars.instance('islamic', 'ar'), dateFormat: "dd/mm/yyyy", showTrigger: '<button type="button" class="trigger"><i class="fa fa-calendar"></i></button>' },
            $.calendarsPicker.regionalOptions['ar']));
        }

    </script>

</asp:Content>

