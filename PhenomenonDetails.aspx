<%@ Page Title="" Language="C#" Theme="En" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PhenomenonDetails.aspx.cs" Inherits="PhenomenonDetails" %>

<%@ Register Src="~/controls/Share.ascx" TagPrefix="uc1" TagName="Share" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container">
        <div class="fr">

            <asp:Repeater OnItemDataBound="Repeter1_ItemDataBound" ID="Repeater1" runat="server">
                <ItemTemplate>
                    <asp:HiddenField ID="id" Value='<%#Eval("id") %>' runat="server" />
                    <h4 class="inTitles"><a href="/Phenomenon.aspx"><%=new Lang().getByKey("Phenomenons") %> </a>> <%#Eval("title") %></h4>
                    <img class="img-responsive PhoDatailsImg" src="/images/SocialEvent/<%#Eval("img") %>" />
                    <%#Eval("txt") %>

                    <h1>المرفقات
                    </h1>
                    <asp:Repeater ID="Repeater4" runat="server">
                        <ItemTemplate>
                            <div class="col-md-6">
                                <div class="row">
                                    <a href="/images/SocialEventDoc/<%#Eval("Url") %>">
                                        <div class="DocRight">
                                            <img src="images/icon1.png" class="img img-responsive" />
                                        </div>
                                        <div class="DocLeft">
                                            <h5>
                                                <%#Eval("name") %>
                                            </h5>
                                            <img src="images/download.png" />
                                            <span><%= new Lang().getByKey("Download") %></span>

                                        </div>
                                        <div class="clear"></div>
                                    </a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    </div>
                    

                    <h4><%=new Lang().getByKey("Share") %></h4>
                    <!--   <uc1:Share runat="server" ID="Share" /> -->
                    <!-- زر التغريد لتوتير لصفحة الظواهر الاجتماعية-->

                    <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://ncss.gov.sa/PhenomenonDetails.aspx?id=<%#Eval("id")%>" data-text=" الظواهر الاجتماعية | المركز الوطني للدراسات والبحوث الاجتماعية" data-dnt="true">Tweet</a>
                    <script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>


                    <!-- زر المشاركة الفيس بوك لصفحة الظواهر الاجتماعية-->
                    <div class="sharfloat">
                        <div id="fb-root"></div>
                        <script>
                            (function (d, s, id) {
                                var js, fjs = d.getElementsByTagName(s)[0];
                                if (d.getElementById(id)) return;
                                js = d.createElement(s); js.id = id;
                                js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.5&appId=912046478831727";
                                fjs.parentNode.insertBefore(js, fjs);
                            }(document, 'script', 'facebook-jssdk'));</script>

                        <div class="fb-share-button" data-href="http://ncss.gov.sa/PhenomenonDetails.aspx?id=<%#Eval("id") %>" data-layout="button_count"></div>
                    </div>
                    <div class="sharfloat">
                        ﻿<!-- زر مشاركة  الليكند ان لصفحة الظواهر الاجتماعية-->
                        <script src="//platform.linkedin.com/in.js" type="text/javascript">    lang: en_US</script>
                        <script type="IN/Share" data-url="http://ncss.gov.sa/PhenomenonDetails.aspx?id=<%#Eval("id") %>" data-counter="right"></script>
                    </div>
                </ItemTemplate>
            </asp:Repeater>



        </div>
        <div class="fl marg">

            <div class="LeftDetails">
                <h4><%=new Lang().getByKey("LatestPhenomenons") %></h4>
                <div class="NewsArrow"></div>


                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <a href="/PhenomenonDetails.aspx?id=<%#Eval("id") %>">
                            <div class="SingleNewsHome hvr-shadow">
                                <img class="img-responsive" src="images/SocialEvent/<%#Eval("img") %>" />
                                <h5><%#Eval("title") %></h5>
                                <%#Eval("txt") %>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>









                <div class="LeftDetails">
                    <h4><%=new Lang().getByKey("LatestNews") %></h4>
                    <div class="NewsArrow"></div>

                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <a href="/NewsDetails.aspx?id=<%#Eval("id") %>">
                                <div class="SingleNewsHome hvr-shadow">
                                    <img class="img-responsive" src="images/News/<%#Eval("img") %>" />
                                    <h5><%#Eval("title") %></h5>
                                    <%#Eval("prev") %>
                                </div>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>


                <div class="NewsbtnImg"></div>
            </div>

        </div>
        <div class="space"></div>
</asp:Content>

