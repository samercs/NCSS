<%@ Page Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PressKitDetails.aspx.cs" Inherits="NewsDetails" %>

<%@ Register Src="~/controls/Share.ascx" TagPrefix="uc1" TagName="Share" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container  ">
        <div class="fr">
            
            <asp:Repeater ID="Repeater3" runat="server">
                <ItemTemplate>
                    <h4 class="inTitles"><%#Eval("title") %> - <%#new Dates().GregToHijri(Eval("AddDate","{0:dd/MM/yyyy}"),"dd/MMM/yyyy") %></h4>
                    <img class="img-responsive PhoDatailsImg" src="/images/PressKit/<%#Eval("img") %>" />
                    <%#Eval("txt") %>

                    <h4><%=new Lang().getByKey("Share") %></h4>
                 <!--   <uc1:Share runat="server" ID="Share" /> -->
                 
<!-- زر التغريد لتوتير لصفحة الاخبار -->
<a href="https://twitter.com/share" class="twitter-share-button" data-url="http://ncss.gov.sa/PressKitDetails.aspx?id=<%#Eval("id") %>" data-text="الملف الصحفي  | المركز الوطني للدراسات والبحوث الاجتماعية" data-dnt="true">Tweet</a>
<script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } } (document, 'script', 'twitter-wjs');</script>
<!-- زر المشاركة الفيس بوك لصفحة الاخبار -->
<div   class="sharfloat">
<div id="fb-root"></div>
<script>
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.5&appId=912046478831727";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>
<div class="fb-share-button" data-href="http://ncss.gov.sa/PressKitDetails.aspx?id=<%#Eval("id") %>" data-layout="button_count"></div>
</div>
<!-- زر مشاركة  الليكند ان لصفحة الاخبار -->
<div   class="sharfloat">
<script src="//platform.linkedin.com/in.js" type="text/javascript">    lang: en_US</script>
<script type="IN/Share" data-url="http://ncss.gov.sa/PressKitDetails.aspx?id=<%#Eval("id") %>" data-counter="right"></script>
</div>
                </ItemTemplate>
            </asp:Repeater>
            
           
        </div>
        <div class="fl marg">
            <div class="LeftDetails">
                <h4><%=new Lang().getByKey("PressKit") %></h4>
                <div class="NewsArrow"></div>

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <a href="/PressKitDetails.aspx?id=<%#Eval("id") %>">
                            <div class="SingleNewsHome  hvr-shadow">
                                <img class="img-responsive" src="images/PressKit/<%#Eval("img") %>" />
                                <h5><%#Eval("title") %></h5>
                                <%#Eval("prev") %>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>


            </div>

            <div class="LeftDetails hidden">
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
    <div class="space"></div>
</asp:Content>

