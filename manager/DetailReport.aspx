<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DetailReport.aspx.vb" Inherits="TastManagement.DetailReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Detail Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>:
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
        <br />
    
    </div>
        <asp:GridView ID="GridViewTask" runat="server" AutoGenerateColumns="False" Height="398px" PageSize="20" AllowPaging="True" DataKeyNames="id" DataSourceID="SqlDataSourceTask">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                <asp:BoundField DataField="responsible" HeaderText="responsible" SortExpression="responsible" />
                <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="commiter" HeaderText="commiter" SortExpression="commiter" />
                <asp:BoundField DataField="create_date" HeaderText="create_date" SortExpression="create_date" />
                <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" />
                <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                <asp:BoundField DataField="update_date" HeaderText="update_date" SortExpression="update_date" />
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSourceTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT id, description, responsible, due_date, status, type, commiter, create_date, department, comment, update_date FROM Task ORDER BY id">
        </asp:SqlDataSource>
    </form>
</body>
</html>
