<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="controls_Header" %>


<div class="betaVersion">
    <%=new Lang().getByKey("BetaVersion") %>
</div>

<header>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />

    <img id="LeftImage" class="img-responsive bounceInLeft animated" src="../images/LeftBack.png" />
    <img id="RightImage" class="img-responsive bounceInRight animated" src="../images/Lins.png" />
    <img id="LeftImage2" class="img-responsive bounceInLeft animated" src="../images/LeftBack2.png" />
    <img id="RightImage2" class="img-responsive bounceInRight animated" src="../images/Lins2.png" />





    <div class="container">
        <!-- <asp:ImageButton CssClass="logo  img-responsive" ImageUrl="../images/Logo.png" OnClick="ImageButton1_Click" ID="ImageButton1" runat="server" />-->
        <div class="logo">
            <a href="../Default.aspx">
                <img class="logo  img-responsive" src="../images/Logo.png" />
            </a>
        </div>
        <a href="http://archivingsystem.azurewebsites.net/login.aspx" target="_blank" class="SystemLogin  hvr-sweep-to-top"><%= new Lang().getByKey("Archivingsystem") %>
        </a>
        <a href="../ResearchersLogin.aspx" target="_blank" class="SystemLogin  hvr-sweep-to-top"><%=new Lang().getByKey("MemberLogin") %>
        </a>
        <div class="SocialMedia">
            
            <div class="SocialIcons hvr-sink">
                <a target="_blank" href="https://twitter.com/NCSSKSA">
                    <img class="img-responsive" src="../images/Tw.png" />
                </a>
            </div>
            <div class="SocialIcons hvr-sink">
                <a target="_blank" href="https://www.facebook.com/NCSSKSA">
                    <img class="img-responsive" src="../images/Face.png" />
                </a>
            </div>
            <div class="SocialIcons hvr-sink">
                <a target="_blank" href="https://plus.google.com/u/0/108903152219506615695/posts">
                    <img class="img-responsive" src="../images/Gmail.png" />
                </a>
            </div>
            <div class="SocialIcons hvr-sink">
                <a target="_blank" href="https://instagram.com/ncssksa/">
                    <img class="img-responsive" src="../images/insagram.png" />
                </a>
            </div>


        </div>
    </div>
    <div class="MenueBack">

        <asp:LinkButton OnClick="btnChangeLang_OnClick" ID="btnChangeLang" runat="server" CssClass="Language"></asp:LinkButton>

        <div class="container">
            <nav class="navbar">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" id="float" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" target="_blank" href="https://twitter.com/NCSSKSA">
                            <img src="../images/Tw.png" /></a>
                        <a class="navbar-brand" target="_blank" href="https://www.facebook.com/NCSSKSA">
                            <img src="../images/Face.png" /></a>
                        <a class="navbar-brand" target="_blank" href="https://plus.google.com/u/0/108903152219506615695/posts">
                            <img src="../images/Gmail.png" /></a>
                        <a class="navbar-brand" target="_blank" href="https://instagram.com/ncssksa/">
                            <img src="../images/insagram.png" /></a>
                    </div>
                    <div class="collapse navbar-collapse" id="myNavbar">
                        <ul class="nav navbar-nav">

                            <li><a id="HomeLink" runat="server" href="/Default.aspx"><%=new Lang().getByKey("Home") %></a></li>


                            <li class="dropdown">

                                <a id="AboutLink" runat="server" class="dropdown-toggle" data-toggle="dropdown" href="#"><%=new Lang().getByKey("AboutUs") %> </a>
                                <asp:ListView ItemPlaceholderID="iph" ID="ListView1" runat="server">
                                    <LayoutTemplate>
                                        <ul class="dropdown-menu arrow_box ">
                                            <asp:PlaceHolder ID="iph" runat="server"></asp:PlaceHolder>
                                        </ul>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <li><a href="/About.aspx?id=<%#Eval("id") %>"><%# Eval("title") %></a></li>
                                    </ItemTemplate>
                                </asp:ListView>


                            </li>

                            <li>
                                <a id="LibraryLink" runat="server" href="/library.aspx"><%=new Lang().getByKey("Library") %></a>
                            </li>

                            <li><a id="ExpertsLink" runat="server" href="/Experts.aspx"><%=new Lang().getByKey("Researchers") %></a></li>

                            <li><a id="PhenomenonLink" runat="server" href="#"><%=new Lang().getByKey("Phenomenons") %></a></li>
                            
                            <li><a id="EventLink" runat="server" href="/Events.aspx"><%=new Lang().getByKey("EventsActivities") %></a></li>

                            <li><a id="PublicationLink" runat="server" href="/Publications.aspx"><%=new Lang().getByKey("Publications") %></a></li>
                            <li><a id="MediaCenterLink" runat="server" href="/MediaCenter.aspx"><%=new Lang().getByKey("MediaCenter") %></a></li>
                            <li><a id="ContactUsLink" runat="server" href="/ContactUs.aspx"><%=new Lang().getByKey("ContactUs") %></a></li>


                            <li class="Hide"><a href="/Careers.aspx"><%=new Lang().getByKey("Careers") %></a></li>
                            <li class="Hide"><a href="/RelatedParties.aspx"><%= new Lang().getByKey("RelatedParties") %></a></li>
                            <li class="Hide"><a href="/GlobalDatabases.aspx"><%= new Lang().getByKey("GlobalDatabases") %></a></li>
                            <li class="Hide"><a href="/SpecializedDatabases.aspx"><%= new Lang().getByKey("SpecializedDatabases") %></a></li>
                            <!--<li  class="Hide"><a data-toggle="modal" data-target="#login-modal"><%=new Lang().getByKey("SubscribeToOurMailingList") %></a></li>-->
                            <li class="Hide"><a href="#"><%=new Lang().getByKey("ArchivingSystem") %></a></li>
                            <li class="Hide"><a href="/Privacy.aspx"><%=new Lang().getByKey("PrivacyPolicy") %></a></li>
                            <li class="Hide EnFont">
                                <asp:LinkButton OnClick="btnLang_OnClick" ID="btnLang" runat="server"></asp:LinkButton>
                            </li>
                        </ul>

                    </div>
                </div>
            </nav>
        </div>
    </div>





</header>
