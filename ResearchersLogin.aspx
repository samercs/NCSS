<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResearchersLogin.aspx.cs" Inherits="ResearchersLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="space"></div>
    <div class="container bounceInUp animated">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
                <img src="images/progress.gif" style="width: 100%; max-width: 200px; display: block; margin: 0 auto; text-align: center; height: auto;" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" DefaultButton="btnReLogin" runat="server">
                    <div class="modal-dialog">
                        <div class="loginmodal-container">
                            <h1><%=new Lang().getByKey("ResearchersLogin") %></h1>
                            <br>
                            <form>
                                <asp:TextBox ID="txtReUser" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" data-error="User@Website.com" required runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtRePass" required TextMode="Password" runat="server"></asp:TextBox>
                                <asp:Button ID="btnReLogin" runat="server" OnClick="btnReLogin_Click" class="login loginmodal-submit" />
                            </form>
                            <div class="checkbox">
                                <asp:CheckBox ID="cbRememberMe" runat="server" />
                                <div class="clearfix"></div>
                                <asp:CheckBox ID="cbReKeepOnline" runat="server" />
                            </div>
                            <div class="clearfix"></div>
                            <div class="login-help">
                                <asp:LinkButton ID="btnGoToForgotPass" OnClick="btnGoToForgotPass_Click" runat="server"><%=new Lang().getByKey("ForgotPassword") %></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel2" Visible="false" DefaultButton="" runat="server">
                    <div class="modal-dialog">
                        <div class="loginmodal-container">
                            <h1><%=new Lang().getByKey("ResearchersLogin") %></h1>
                            <br>
                            <form>
                                <asp:TextBox ID="txtFEmail" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" data-error="User@Website.com" required runat="server"></asp:TextBox>
                                <asp:Button ID="btnForgotPass" runat="server" OnClick="btnForgotPass_Click" class="login loginmodal-submit" />
                            </form>
                            <div class="clearfix"></div>
                            <div class="login-help">
                                <asp:LinkButton ID="btnBackLogin" OnClick="btnBackLogin_Click" runat="server"><%=new Lang().getByKey("Backtologin") %></asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="space"></div>

    <script>
        alertify.defaults.glossary.title = '<%=new Lang().getByKey("SiteTitle")%>';
        // Setup
        this.$('.js-loading-bar').modal({
            backdrop: 'static',
            show: false
        });

        $('#load').click(function () {
            var $modal = $('.js-loading-bar'),
                $bar = $modal.find('.progress-bar');

            $modal.modal('show');
            $bar.addClass('animate');

            setTimeout(function () {
                $bar.removeClass('animate');
                $modal.modal('hide');
            }, 1500);
        });
    </script>
</asp:Content>


