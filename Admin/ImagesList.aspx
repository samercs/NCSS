<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ImagesList.aspx.cs" Inherits="Admin_ImagesList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="Title BorderBottom">صور الموقع</h1>
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
            <asp:HyperLink ID="HyperLink1" NavigateUrl="Default.aspx" CssClass="tdn fl" runat="server"><h5><i class="fa fa-backward"></i> رجوع</h5></asp:HyperLink>

            <div class="clear"></div>
            <table cellspacing='0' class="LoginTbl tblList">
                <!-- cellspacing='0' is important, must stay -->
                <tr>
                    <th>
                        <asp:CheckBox ID="CheckBox10" OnCheckedChanged="CheckBox10_CheckedChanged" AutoPostBack="true" runat="server" /></th>
                    <th>الصورة</th>
                    <th>العنوان</th>
                    <th>الاجراء</th>
                </tr>
                <asp:ListView ID="RepeaterLists" OnPagePropertiesChanged="ListView1_PagePropertiesChanged" ItemPlaceholderID="iph" runat="server">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="iph" runat="server"></asp:PlaceHolder>
                        <tr>
                            <td colspan="7">
                                <div class="Pager AC">
                                    <asp:DataPager ID="DataPager2" PagedControlID="RepeaterLists" PageSize="10" runat="server">
                                        <Fields>
                                            <asp:NumericPagerField CurrentPageLabelCssClass="CurrentPageNumber" ButtonCount="10" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </td>
                        </tr>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:HiddenField ID="id" runat="server" Value='<%# Eval("Id") %>' />
                                <asp:HiddenField ID="img" runat="server" Value='<%# Eval("src") %>' />
                                <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                            <td>
                                <asp:Image Width="150" ImageUrl='<%#Eval("src","~/images/images/{0}") %>' ID="Image2" runat="server" />
                            </td>
                            <td>
                                <%#Eval("ImgKey") %>
                            </td>
                            <td>

                                <asp:LinkButton ID="btnEdit" OnCommand="btnEdit_Command" CommandArgument='<%#Eval("id") %>' runat="server"><i class="fa fa-pencil-square-o fs20px"></i> تعديل</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </table>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



