<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintResearcher.aspx.cs" Inherits="PrintResearcher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <table class="table table-striped" style="direction: rtl; width: 90%; margin:30px auto;">
                        <tr>
                            <td colspan="2">
                                <img height="200" width="200" style="margin: auto; display: inline-block;" src="/images/Researchers/<%#Eval("img") %>"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("Name") %> :
                            </td>
                            <td>
                                <%#Eval("name") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("Email") %> :
                            </td>
                            <td>
                                <%#Eval("Email") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("Major") %> :
                            </td>
                            <td>
                                <%#Eval("Major") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("Qualification") %> :
                            </td>
                            <td>
                                <%#Eval("Qualification") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("Specialization") %> :
                            </td>
                            <td>
                                <%#Eval("Specialization") %>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <%=new Lang().getByKey("Degree") %> :
                            </td>
                            <td>
                                <%#Eval("Level") %>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <%=new Lang().getByKey("Country") %> :
                            </td>
                            <td>
                                <%#Eval("Country") %>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <%=new Lang().getByKey("Work") %> :
                            </td>
                            <td>
                                <%#Eval("Organization") %>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <%=new Lang().getByKey("CurrentWork") %> :
                            </td>
                            <td>
                                <%#Eval("CurrentWork") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("Mobile") %> :
                            </td>
                            <td>
                                <%#Eval("Mobile") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("Phone") %> :
                            </td>
                            <td>
                                <%#Eval("Phone") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("facebook") %> :
                            </td>
                            <td>
                                <%#Eval("facebook") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("twitter") %> :
                            </td>
                            <td>
                                <%#Eval("twitter") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=new Lang().getByKey("linkedin") %> :
                            </td>
                            <td>
                                <%#Eval("linkedin") %>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <%#Eval("prev") %>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        
        <script type="text/javascript">
            window.print();
        </script>

    </form>
</body>
</html>
