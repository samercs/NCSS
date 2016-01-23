<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Experts.aspx.cs" Inherits="Experts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <h4 class="inTitles"><%=new Lang().getByKey("Researchers") %></h4>
                
                
                
                
                <a href="/ResearchersForm.aspx">
                    <div class="AddExpert hvr-wobble-horizontal">
                        <img src="images/AddIcon.png" /><%=new Lang().getByKey("Introduceyourselfasaresearcher") %>
                    </div>
                </a>
                 <a href="/ResearchersLogin.aspx">
                    <div class="AddExpert2 AddExpert hvr-wobble-horizontal">
                        <%=new Lang().getByKey("MemberLogin") %>
                    </div>
                </a>
                
                <div class="MobileSpace"></div>


                <table class="inTabls2">

                    <tr>
                        <td>
                            <p><%=new Lang().getByKey("Name") %></p>
                            <asp:TextBox ID="txtEnName" CssClass="inTextBox2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <p><%=new Lang().getByKey("Country") %></p>
                            <asp:DropDownList CssClass="inTextBox2 maxWidth150" ID="ddlEnCountry" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <p><%=new Lang().getByKey("Major") %></p>
                            <asp:TextBox ID="txtEnMajor" CssClass="inTextBox2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <p><%=new Lang().getByKey("Degree") %></p>
                            <asp:DropDownList CssClass="inTextBox2" ID="ddlEnDegree" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <p><%=new Lang().getByKey("Work") %></p>
                            <asp:TextBox ID="txtEnWork" CssClass="inTextBox2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton OnClick="HyperLink1_OnClick" runat="server" CssClass="Download" ID="btnSearch"><%=new Lang().getByKey("Search") %></asp:LinkButton></td>

                    </tr>
                    <tr></tr>
                </table>



                <div class="MobileSpace"></div>
                <div class="allResearchers">

                    <asp:ListView ID="ListView1" runat="server">
                        <ItemTemplate>
                            <div class="singleExpert hvr-shadow">
                                <img class="img-responsive" src="/images/Researchers/<%#Eval("img") %>" />
                                <h4><%#Eval("name") %></h4>

                                <div class="AllReIcons">
                                    <a class="ReIconsA" target="_blank" href="<%#Eval("twitter") %>">
                                        <img src="/images/ReTw.png" class="ReIcons hvr-buzz-out" />
                                    </a>
                                    <a class="ReIconsA" target="_blank" href="<%#Eval("linkedin") %>">
                                        <img src="/images/Rein.png" class="ReIcons hvr-buzz-out" />
                                    </a>
                                    <a class="ReIconsA" target="_blank" href="<%#Eval("facebook") %>">
                                        <img src="/images/ReFa.png" class="ReIcons hvr-buzz-out" />
                                    </a>

                                </div>
                                <div class="clearfix"></div>
                                <asp:HyperLink ID="HyperLink1" CssClass="LLL" NavigateUrl='<%#Eval("id","~/Researcher.aspx?id={0}") %>' runat="server"><%=new Lang().getByKey("ResearcherProfile") %></asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>


                </div>
    </div>
    <div class="space"></div>

    </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>

