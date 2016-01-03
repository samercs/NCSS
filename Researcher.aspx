<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Researcher.aspx.cs" Inherits="Researcher" %>

<%@ Register Src="~/controls/hijriCalender.ascx" TagPrefix="uc1" TagName="hijriCalender" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <div class="container  ">

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="fr">
                    <h4 class="inTitles"><a href="/Experts.aspx"><%=new Lang().getByKey("Researchers") %></a> > <%#Eval("name") %></h4>
                    <p><%#Eval("prev") %></p>
                    <p>
                        <%=new Lang().getByKey("Major") %> : <span class="label label-default"><%#Eval("Major") %></span>
                    </p>
                    <p>
                        <%=new Lang().getByKey("Degree") %> : <span class="label label-default"><%#Eval("Level") %></span>
                    </p>
                    <p>
                        <%=new Lang().getByKey("Country") %> : <span class="label label-default"><%#Eval("CountryName") %></span>
                    </p>
                    <p>
                        <%=new Lang().getByKey("Work") %> : <span class="label label-default"><%#Eval("Organization") %></span>
                    </p>
                    <p>
                        <%=new Lang().getByKey("Email") %> : <span class="label label-default"><%#Eval("email") %></span>
                    </p>
                </div>
                <div class="fl">
                    <img class="ResearcherImagein" src="/images/Researchers/<%#Eval("img") %>" />
                    <div class="clearfix"></div>
                    <div style="display:none;" class="AllReIcons">
                        <a target="_blank" href="<%#Eval("twitter") %>">
                            <img src="/images/ReTw.png" class="ReIcons hvr-buzz-out" />
                        </a>
                        <a target="_blank"  href="<%#Eval("linkedin") %>">
                            <img src="/images/Rein.png" class="ReIcons hvr-buzz-out" />
                        </a>
                        <a target="_blank"  href="<%#Eval("facebook") %>">
                            <img src="/images/Refa.png" class="ReIcons hvr-buzz-out" />
                        </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="Clear"></div>
        <div class="space"></div>
        <div class="space"></div>
        <br />
       



        <table class="inTabls2">
            <tr>
                <td>
                    <p><%=new Lang().getByKey("Title") %></p>
                    <asp:TextBox ID="txtTitle" CssClass="inTextBox" runat="server"></asp:TextBox>
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
                    <asp:LinkButton OnClick="btnSearch_OnClick" ID="btnSearch" CssClass="Download" runat="server"><%=new Lang().getByKey("Search") %></asp:LinkButton>
                </td>

            </tr>

            <tr class="TableTitle">
                <td><%=new Lang().getByKey("Title") %></td>
                <td><%=new Lang().getByKey("Date") %></td>
                <td><%=new Lang().getByKey("Language") %></td>
                <td><%=new Lang().getByKey("Download") %></td>
            </tr>

            <asp:ListView ID="ListView1" OnPagePropertiesChanged="ListView1_OnPagePropertiesChanged" runat="server">
                <ItemTemplate>
                    <tr class="TableDetails1">
                        <td><%#Eval("title") %></td>
                        <td style="direction: rtl"><%#new Dates().GregToHijri(Eval("AddDate","{0:dd/MM/yyyy}"),"dd/MMM/yyyy") %></td>
                        <td><%#Eval("lang").ToString().Equals("1") ? new Lang().getByKey("English") : new Lang().getByKey("Arabic2") %></td>
                        <td class="DownloadBtn"><a href="/images/Research/<%#Eval("file") %>" download="<%#Eval("file") %>"><%=new Lang().getByKey("Download") %></a></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </table>




        

        <div class="pager">
            <asp:DataPager ID="DataPager1" PageSize="5" PagedControlID="ListView1" runat="server">
                <Fields>
                    <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="PagerBtnCurent" NumericButtonCssClass="PagerBtn" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
    <div class="space"></div>
    
    
    <script src="js/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">
        $(function () {

            $('#<%=txtFrom.ClientID%>').datepicker({ format: 'dd/mm/yyyy' });
            $('#<%=txtTo.ClientID%>').datepicker({ format: 'dd/mm/yyyy' });
            
            $("#iconFromDate").click(function () {

                $('#<%=txtFrom.ClientID%>').datepicker('show');

            });

            $("#iconToDate").click(function () {

                $('#<%=txtTo.ClientID%>').datepicker('show');

            });

            

        });
    </script>

</asp:Content>

