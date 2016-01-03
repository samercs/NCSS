<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="controls_Header" %>
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
        <a href="http://archivingsystem.azurewebsites.net/login.aspx" target=_blank class="SystemLogin  hvr-sweep-to-top"><%= new Lang().getByKey("Archivingsystem") %>
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

                            <li><a ID="HomeLink" runat="server" href="/Default.aspx"><%=new Lang().getByKey("Home") %></a></li>


                            <li class="dropdown">

                                <a ID="AboutLink" runat="server" class="dropdown-toggle" data-toggle="dropdown" href="#"><%=new Lang().getByKey("AboutUs") %> </a>
                                <ul class="dropdown-menu arrow_box ">
                                    <li><a href="/About.aspx"><%=new Lang().getByKey("AboutUs") %></a></li>
                                    <li><a href="/About.aspx?page=MisionVision"><%=new Lang().getByKey("VisionMission") %></a></li>
                                    <li><a href="/About.aspx?page=Goal"><%=new Lang().getByKey("Goals") %></a></li>
                                    <li><a href="/OrganizationalStructure.aspx"><%=new Lang().getByKey("OrganizationalStructure") %></a></li>
                                    <li><a href="/About.aspx?page=CenterInitiative"><%=new Lang().getByKey("CenterInitiative") %></a></li>
                                </ul>
                            </li>

                            <li class="dropdown">

                                <a ID="LibraryLink" runat="server" class="dropdown-toggle" data-toggle="dropdown" href="#"><%=new Lang().getByKey("Library") %></a>
                                <ul class="dropdown-menu arrow_box ">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <li><a href="/library.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    
                                </ul>
                            </li>

                            <li ><a ID="ExpertsLink" runat="server" href="/Experts.aspx"><%=new Lang().getByKey("Researchers") %></a></li>

                            <li ><a ID="PhenomenonLink" runat="server" href="/Phenomenon.aspx"><%=new Lang().getByKey("Phenomenons") %></a></li>
                            <li><a ID="EventLink" runat="server" href="/Events.aspx"><%=new Lang().getByKey("EventsActivities") %></a></li>

                            <li ><a ID="PublicationLink" runat="server" href="/Publications.aspx"><%=new Lang().getByKey("Publications") %></a></li>
                            <li ><a ID="MediaCenterLink" runat="server" href="/MediaCenter.aspx"><%=new Lang().getByKey("MediaCenter") %></a></li>
                            <li ><a ID="ContactUsLink" runat="server" href="/ContactUs.aspx"><%=new Lang().getByKey("ContactUs") %></a></li>


                            <li  class="Hide"><a href="/Careers.aspx"><%=new Lang().getByKey("Careers") %></a></li>
                            <!--<li  class="Hide"><a data-toggle="modal" data-target="#login-modal"><%=new Lang().getByKey("SubscribeToOurMailingList") %></a></li>-->
                            <li  class="Hide"><a href="#"><%=new Lang().getByKey("ArchivingSystem") %></a></li>
                            <li  class="Hide"><a href="/Privacy.aspx"><%=new Lang().getByKey("PrivacyPolicy") %></a></li>
                            <li  class="Hide EnFont">
                                <asp:LinkButton OnClick="btnLang_OnClick" ID="btnLang" runat="server"></asp:LinkButton>
                            </li>
                        </ul>

                    </div>
                </div>
            </nav>
        </div>
    </div>





</header>
