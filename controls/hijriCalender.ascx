<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hijriCalender.ascx.cs" Inherits="controls_hijriCalender" %>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<script>
    $(function () {


        $("#<%=TextBox1.ClientID%>").calendarsPicker($.extend(
    { calendar: $.calendars.instance('islamic', 'ar'), dateFormat: "dd/mm/yyyy", showTrigger: '<button type="button" class="trigger"><i class="fa fa-calendar"></i></button>' },
    $.calendarsPicker.regionalOptions['ar']));

    });
</script>
