<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="logmanage.aspx.vb" Inherits="TastManagement.logmanager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>log manage</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="TaskMgr" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Log] ORDER BY [date] DESC" DeleteCommand="DELETE FROM [Log] WHERE (id = @id)">
            <DeleteParameters>
                <asp:Parameter Name="id" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <asp:Button ID="BtnClear" runat="server" Text="Clear" />
        &nbsp;</div>
        <asp:GridView ID="LogView" runat="server" AutoGenerateColumns="False"
            DataSourceID="TaskMgr" Height="387px" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="694px" DataKeyNames="id" PageSize="100">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="usr" HeaderText="usr" SortExpression="usr" />
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                <asp:BoundField DataField="info" HeaderText="info" SortExpression="info" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        &nbsp;
    </form>
</body>
</html>
