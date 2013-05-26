<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="admin.aspx.vb" Inherits="TastManagement.admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="Logout" runat="server">Logout</asp:LinkButton><br />
        <br />
        <asp:LinkButton ID="LB_TaskMg" runat="server">Task manage</asp:LinkButton><br />
        <br />
        <asp:LinkButton ID="LB_LogMg" runat="server">Log manage</asp:LinkButton><br />
        <br />
        <asp:LinkButton ID="LB_UserMg" runat="server">User manage</asp:LinkButton>&nbsp;</div>
    </form>
</body>
</html>
