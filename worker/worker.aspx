<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="worker.aspx.vb" Inherits="TastManagement.Worker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Worker :
        <asp:Label ID="TxtUserName" runat="server"></asp:Label><br />
        <br />
        my tasks :
        <asp:HyperLink ID="HL_tasknum" runat="server">[HL_tasknum]</asp:HyperLink><br />
        <asp:GridView ID="GridViewMyTask" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="id" DataSourceID="SqlDataSourceMyTask">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="commiter" HeaderText="commiter" SortExpression="commiter" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                <asp:BoundField DataField="create_date" HeaderText="create_date" SortExpression="create_date" />
                <asp:BoundField DataField="plan_finish_date" HeaderText="plan_finish_date" SortExpression="plan_finish_date" />
                <asp:BoundField DataField="worker" HeaderText="worker" SortExpression="worker" />
                <asp:BoundField DataField="work_state" HeaderText="work_state" SortExpression="work_state" />
                <asp:BoundField DataField="update_date" HeaderText="update_date" SortExpression="update_date" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceMyTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT id, commiter, type, state, create_date, plan_finish_date, worker, work_state, update_date, description FROM Task WHERE (worker = @worker)">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtUserName" Name="worker" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        Id:
        <asp:DropDownList ID="DDL_TaskId" runat="server" DataSourceID="SqlDataSourceTask" DataTextField="id" DataValueField="id" AutoPostBack="True">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT id FROM Task WHERE (worker = @worker) AND (state <> 'close')">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtUserName" Name="worker" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        State:<asp:DropDownList ID="DDL_state" runat="server">
            <asp:ListItem Value="50">未完成</asp:ListItem>
            <asp:ListItem Value="100">完成</asp:ListItem>
        </asp:DropDownList><br />
        <asp:TextBox ID="TB_comment" runat="server" Height="83px" TextMode="MultiLine" Width="256px"></asp:TextBox><br />
        <br />
        <asp:Button ID="Btn_Update" runat="server" Text="Update" />
    
    </div>
    </form>
</body>
</html>
