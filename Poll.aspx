<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Poll.aspx.cs" Inherits="Poll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="space"></div>
    <div class="container bounceInUp animated">

        <h4 class="inTitles"><%=new Lang().getByKey("Poll") %></h4>

        <br />

        <table class="inTabls2">
            <tr>
                <td>
                    <p><%=new Lang().getByKey("PollSubject") %></p>
                    <asp:TextBox ID="txtTitle" CssClass="inTextBox" runat="server"></asp:TextBox>
                </td>

                <td>
                    <p><%=new Lang().getByKey("From") %></p>
                    <img id="iconFromDate" class="CalImg" src="/images/CalIcon.png" />
                    <asp:TextBox ID="txtFrom" CssClass="inTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <p><%=new Lang().getByKey("To") %></p>
                    <img id="iconToDate" class="CalImg" src="/images/CalIcon.png" />
                    <asp:TextBox ID="txtTo" CssClass="inTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton OnClick="btnSearch_OnClick" CssClass="Download" ID="btnSearch" runat="server"><%=new Lang().getByKey("Search") %></asp:LinkButton>
                </td>


            </tr>

            <tr class="TableTitle">
                <td colspan="2"><%=new Lang().getByKey("PollSubject") %></td>
                <td><%=new Lang().getByKey("Date") %></td>
                <td><%=new Lang().getByKey("Vote") %></td>
            </tr>

            <asp:ListView OnItemDataBound="ListView1_OnItemDataBound" OnPagePropertiesChanged="ListView1_OnPagePropertiesChanged" ID="ListView1" runat="server">
                <ItemTemplate>
                    <tr class="TableDetails1">
                        <td class="ColWidth" colspan="2"><%#Eval("title") %> </td>
                        <td><%#Eval("adddate","{0:dd/MM/yyyy}") %></td>
                        <td class="DownloadBtn"><a data-toggle="collapse" class="btn2" style="cursor:pointer;" data-target="#demo<%# Container.DataItemIndex + 1 %>"><%=new Lang().getByKey("Vote") %></a></td>
                    </tr>
                    <tr id="demo<%# Container.DataItemIndex + 1 %>" class="collapse">
                        <td class="PollDetails " colspan="4">
                            <asp:HiddenField ID="id" Value='<%#Eval("id") %>' runat="server" />
                            <asp:Repeater OnItemCommand="Repeater1_OnItemCommand" ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <asp:HiddenField ID="pollid" Value='<%#Eval("PollId") %>' runat="server" />
                                    <asp:HiddenField ID="optionid" Value='<%#Eval("id") %>' runat="server" /> 
                                    <div class="SinglePollin">
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-info pull-right" role="progressbar" aria-valuenow="50"
                                                aria-valuemin="0" aria-valuemax="100" style="width: <%#Eval("per") %>%">
                                                <%#Eval("per","{0:0.00}") %>%
                                            </div>
                                        </div>
                                        <asp:LinkButton   CssClass="boxBtn" ID="LinkButton1" runat="server"><%# Page.Culture.Contains("Arabic") ?  Eval("titleAr") : Eval("title") %></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>



        </table>





        <div class="clearfix"></div>
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
    <script>
        $(document).ready(function () {
            
            $(".collapse").on("show.bs.collapse", function () {

                var $btn = $(this).prev().children(2).find(".btn2");
                $btn.html('<div class="Arr2"></div> <%=new Lang().getByKey("Cancel") %>');
            });

            $(".collapse").on("hidden.bs.collapse", function () {
                var $btn = $(this).prev().children(2).find(".btn2");
                $btn.html('<span></span> <%=new Lang().getByKey("Vote") %>');
            });

            $(function () {

                $('#<%=txtFrom.ClientID%>').datepicker();
                $('#<%=txtTo.ClientID%>').datepicker();



                $("#iconFromDate").click(function () {

                    $('#<%=txtFrom.ClientID%>').datepicker('show');

            });

                $("#iconToDate").click(function () {

                    $('#<%=txtTo.ClientID%>').datepicker('show');

            });

            });

        });
    </script>



</asp:Content>

