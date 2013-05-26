<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="TastManagement._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Name" Width="63px"></asp:Label>
        <asp:TextBox ID="TbName" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TbPassword" runat="server" TextMode="Password" Width="149px"></asp:TextBox><br />
        <asp:Button ID="BtnLogin" runat="server" Text="Login" /><br />
        <asp:Label ID="TxtLog" runat="server" Width="303px" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
