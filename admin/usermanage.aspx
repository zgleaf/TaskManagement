<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="usermanage.aspx.vb" Inherits="TastManagement.usermanage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>user manage</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="TaskMgr" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [User]">
        </asp:SqlDataSource>
    
    </div>
        <asp:GridView ID="UserView" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="TaskMgr" Height="251px"
            Width="466px" DataMember="DefaultView" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="pwd" HeaderText="pwd" SortExpression="pwd" />
                <asp:BoundField DataField="permission" HeaderText="permission" SortExpression="permission" />
                <asp:BoundField DataField="invalid" HeaderText="invalid" SortExpression="invalid" />
                <asp:BoundField DataField="uid" HeaderText="uid" SortExpression="uid" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <asp:Label ID="TxtName" runat="server" Text="name"></asp:Label>
        <asp:TextBox ID="TbName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="TxtPwd" runat="server" Text="pwd"></asp:Label>&nbsp;
        <asp:TextBox ID="TbPassword" runat="server" TextMode="Password" Width="149px"></asp:TextBox><br />
        <asp:Label ID="TxtType" runat="server" Text="Type"></asp:Label>
        <asp:DropDownList ID="ListPermission" runat="server">
            <asp:ListItem Value="1">commiter</asp:ListItem>
            <asp:ListItem Value="2">responsible</asp:ListItem>
            <asp:ListItem Value="0">admin</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Button ID="Btn_Add" runat="server" Text="Add" />
        <asp:Button ID="Btn_Pwd" runat="server" Text="RenewPwd" />
        <asp:Button ID="Btn_Perm" runat="server" Text="RenewType" />
        <asp:Button ID="Btn_Invalid" runat="server" Text="Invalid" />
        <asp:Button ID="Btn_Valid" runat="server" Text="Valid" /><br />
        <asp:Label ID="TxtLog" runat="server"></asp:Label>
    </form>
</body>
</html>
