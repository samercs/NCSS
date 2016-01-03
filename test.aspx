<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Src="~/controls/hijriCalender.ascx" TagPrefix="uc1" TagName="hijriCalender" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script type="text/javascript" src="js/calender/jquery.calendars.js"></script> 
            <script type="text/javascript" src="js/calender/jquery.calendars.plus.js"></script>
            <link rel="stylesheet" type="text/css" href="/js/calender/jquery.calendars.picker.css" /> 
            <script type="text/javascript" src="js/calender/jquery.plugin.js"></script> 
            <script type="text/javascript" src="js/calender/jquery.calendars.picker.js"></script>
            <script type="text/javascript" src="js/calender/jquery.calendars.picker-ar.js"></script>
            <script type="text/javascript" src="js/calender/jquery.calendars.islamic.js"></script>
            <script type="text/javascript" src="js/calender/jquery.calendars.islamic-ar.js"></script>
            <script type="text/javascript" src="js/calender/jquery.calendars.islamic-ar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:hijriCalender runat="server" ID="txtAdddate" />
        <asp:Button OnClick="Button1_OnClick" ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
