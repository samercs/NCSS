<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>المركز الوطني للبحوث الاجتماعية - لوحة التحكم</title>
    <link href="Styles/font-awesome-4.4.0/css/font-awesome.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link href="Styles/Login.css" rel="stylesheet" />
    <link href="Styles/tooltipster.css" rel="stylesheet" />
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/jquery.tooltipster.min.js"></script>

    <link rel="shortcut icon" type="image/x-icon" href="/favicon.ico"/>

</head>

<body>
    <form id="form1" runat="server" autocomplete="off">
        <input name="foilautofill" style="display: none;" type="password" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
            <ProgressTemplate>
                <div class="LoadingCenter">
                    <img src="Images/small_loader.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="Content">
                    <div class="LoginBox">
                        <img alt="Logo" src="/Images/Logo.png" />
                        <hr />
                        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:Panel ID="Panel1" DefaultButton="btnLogin" runat="server">
                                    <div class="row">
                                        <i class="fa fa-user fl rl"></i>
                                        <asp:TextBox autocomplete="off" ID="txtUserName" placeholder="اسم المستخدم" required runat="server" ValidationGroup="Login" CssClass="fl txt"></asp:TextBox>
                                        <i class="fa fa-question fl rr tooltip" title="اسم المستخدم"></i>
                                    </div>
                                    <div class="row">
                                        <i class="fa fa-unlock fl rl"></i>
                                        <asp:TextBox autocomplete="off" ID="txtPassword" placeholder="كلمة السر" required TextMode="Password" ValidationGroup="Login" runat="server" CssClass="fl txt"></asp:TextBox>
                                        <i class="fa fa-question fl rr tooltip" title="ادخل كلمة السر"></i>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <asp:LinkButton ID="btnGoForget" title="نسيت كلمة السر اضغط هنا" CssClass="tooltip forgetpass tdu tdn" OnClick="btnGoForget_Click" runat="server">نسيت كلمة السر ؟</asp:LinkButton>
                                        <asp:Button ID="btnLogin" CssClass="btnLogin" OnClick="btnLogin_Click" ValidationGroup="Login" runat="server" Text="دخول" />

                                    </div>
                                    <div style="padding-top: 3px;"></div>
                                    <hr />
                                    <div class="row">
                                        <asp:CheckBox Visible="False" CssClass="tooltip forgetpass tdu tdn" Text="تذكرني !" ID="cbRememberMe" runat="server" /><br />
                                        <asp:CheckBox Visible="False" CssClass="tooltip forgetpass tdu tdn" Text="البقاء متصل !" ID="cbKeepMeLogin" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ValidationGroup="Login" ErrorMessage=""></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ValidationGroup="Login" ErrorMessage=""></asp:RequiredFieldValidator>
                                </asp:Panel>
                            </asp:View>
                            <asp:View runat="server" ID="ForgetPassView">
                                <asp:Panel ID="Panel3" DefaultButton="btnForgetPass" runat="server">
                                    <div class="row">
                                        <i class="fa fa-user fl rl"></i>
                                        <asp:TextBox autocomplete="off" ID="txtEmail" required type="email" CssClass="fl txt" ValidationGroup="fpLogin" placeholder="البريد الالكتروني" runat="server"></asp:TextBox>
                                        <i class="fa fa-question fl rr"></i>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <asp:LinkButton ID="btnBackLogin" CssClass="fl forgetpass" OnClick="btnBackLogin_Click" runat="server">الرجوع الى شاشة الدخول</asp:LinkButton>
                                        <asp:Button ID="btnForgetPass" CssClass="fr btnLogin" OnClick="btnForgetPass_Click" runat="server" ValidationGroup="fpLogin" Text="ارسال" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ValidationGroup="fpLogin" ErrorMessage=""></asp:RequiredFieldValidator>
                                </asp:Panel>
                            </asp:View>
                        </asp:MultiView>
                        <div class="">
                            <div class="sp20" runat="server" id="sp1" visible="false"></div>
                            <asp:Panel CssClass="Error" Visible="false" ID="ErrorDiv" runat="server">
                                <div>
                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <script>
                        $(document).ready(function () {
                            $('.tooltip').tooltipster();
                        });
                    </script>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
