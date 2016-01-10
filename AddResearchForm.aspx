<%@ Page EnableEventValidation="false" Title="" Theme="En" Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddResearchForm.aspx.cs" Inherits="AddResearchForm" %>

<%@ Register Src="~/controls/hijriCalender.ascx" TagPrefix="uc1" TagName="hijriCalender" %>

<%@ Register Src="~/controls/Facebook.ascx" TagPrefix="uc1" TagName="Facebook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script type="text/javascript" src="/js/calender/jquery.calendars.js"></script> 
            <script type="text/javascript" src="/js/calender/jquery.calendars.plus.js"></script>
            <link rel="stylesheet" type="text/css" href="/js/calender/jquery.calendars.picker.css" /> 
            <script type="text/javascript" src="/js/calender/jquery.plugin.js"></script> 
            <script type="text/javascript" src="/js/calender/jquery.calendars.picker.js"></script>
            <script type="text/javascript" src="/js/calender/jquery.calendars.picker-ar.js"></script>
            <script type="text/javascript" src="/js/calender/jquery.calendars.islamic.js"></script>
            <script type="text/javascript" src="/js/calender/jquery.calendars.islamic-ar.js"></script>
            <script type="text/javascript" src="/js/calender/jquery.calendars.islamic-ar.js"></script>
    <style>
        .txb > .fa, .txb > button{
            display:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="space"></div>
    <div class="container bounceInUp animated">
        <div class="fr">
            <h4><%=new Lang().getByKey("ResearchFile") %></h4>
            <asp:Panel ID="Panel1" DefaultButton="btnSend" runat="server">
            <table class="FormTable">
                <tr>
                    <td class="txb">
                        <asp:TextBox CssClass="FormTextBox" ID="txtTitle" runat="server"></asp:TextBox></td>
                    <td class="lbl">*<%=new Lang().getByKey("Title") %></td>
                </tr>
                   <tr>

                    <td class="txb">
                        <asp:FileUpload ID="fileFile"  CssClass="FileUpload" runat="server" /></td>
                    <td class="lbl">*<%=new Lang().getByKey("File") %></td>
                </tr>
           
                    <tr>

                    <td class="txb">
                        <asp:DropDownList CssClass="FormTextBox" ID="ddlLang" runat="server">
                             <asp:ListItem Text="انجليزي" Value="1"></asp:ListItem>
                            <asp:ListItem Text="عربي" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="lbl">*<%=new Lang().getByKey("Language") %></td>
                </tr>
                  <tr>
                    <td class="txb">
                         <uc1:hijriCalender ValidationGroup="Option3" Class="txtCal FormTextBox" runat="server" ID="txtPublishDate" /></td>
                    <td class="lbl">*<%=new Lang().getByKey("PublishDate") %></td>
                </tr>
                 <tr>
                    <td class="txb">
                        <uc1:hijriCalender ValidationGroup="Option3" Class="txtCal FormTextBox" runat="server" ID="txtAddDate" />
                    <td class="lbl">*<%=new Lang().getByKey("AddDate") %></td>
                </tr>
                <tr>

                    <td colspan="2" class="AlignRight">
                        <a class="savebtn hvr-push" href="/Experts.aspx"><%=new Lang().getByKey("Cancel") %></a>
                        <asp:LinkButton OnClick="btnSend_Click" CssClass="savebtn2 hvr-push" ID="btnSend" runat="server"><%=new Lang().getByKey("fsave") %></asp:LinkButton>
                    </td>

                </tr>
            </table>
                </asp:Panel>

        </div>
        <div class="fl">

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <h4><%#Eval("title") %></h4>
                    <br />
                    <br />
                    <br />
                    <p>
                        <%#Eval("prev") %>
                    </p>
                </ItemTemplate>
            </asp:Repeater>


            <div class="space"></div>
            <uc1:Facebook runat="server" ID="Facebook" />
        </div>
    </div>

    <div class="space"></div>

    <script>
        alertify.defaults.glossary.title = '<%=new Lang().getByKey("SiteTitle")%>';   
        $(function() {
            
            jQuery('#<%=txtAddDate.ClientID%>').datetimepicker({ format: 'd/m/Y', timepicker: false});

        });
    </script>
</asp:Content>

