<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="taskmanage.aspx.vb" Inherits="TastManagement.taskmanager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>task manage</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="TaskMgr" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Task]" DeleteCommand="DELETE FROM Task WHERE (id = @id)" UpdateCommand="UPDATE Task SET commiter = @commiter, type = @type, state = @state, create_date = @create_date, due_date = @due_date, worker = @worker, work_state = @work_state, update_date = @update_date, description = @description WHERE (id = @id)">
            <DeleteParameters>
                <asp:Parameter Name="id" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="commiter" />
                <asp:Parameter Name="type" />
                <asp:Parameter Name="state" />
                <asp:Parameter Name="create_date" />
                <asp:Parameter Name="due_date" />
                <asp:Parameter Name="worker" />
                <asp:Parameter Name="work_state" />
                <asp:Parameter Name="update_date" />
                <asp:Parameter Name="description" />
                <asp:Parameter Name="id" />
            </UpdateParameters>
        </asp:SqlDataSource>
        id:
        <asp:TextBox ID="TB_id" runat="server" Width="69px"></asp:TextBox>
        commiter:
        <asp:TextBox ID="TB_commiter" runat="server" Width="76px"></asp:TextBox>
        responsible:
        <asp:TextBox ID="TB_reponse" runat="server" Width="78px"></asp:TextBox>&nbsp;<asp:Button
            ID="Btn_Search" runat="server" Text="Search" /></div>
        <asp:GridView ID="TaskView" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            DataSourceID="TaskMgr" Height="379px" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                <asp:BoundField DataField="commiter" HeaderText="commiter" SortExpression="commiter" />
                <asp:BoundField DataField="create_date" HeaderText="create_date" SortExpression="create_date" />
                <asp:BoundField DataField="responsible" HeaderText="responsible" SortExpression="responsible" />
                <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" />
                <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                <asp:BoundField DataField="update_date" HeaderText="update_date" SortExpression="update_date" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </form>
</body>
</html>
