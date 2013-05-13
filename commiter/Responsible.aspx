<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Responsible.aspx.vb" Inherits="TastManagement.Responsible1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LB_Report" runat="server">Report</asp:LinkButton>
        <asp:LinkButton ID="LB_Commit" runat="server">Commit</asp:LinkButton>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:LinkButton ID="LB_Logout" runat="server">Logout</asp:LinkButton><br />
        <br />
        Responsible :
        <asp:Label ID="TxtUserName" runat="server"></asp:Label><br />
        <br />
        my tasks :
        <asp:HyperLink ID="HL_tasknum" runat="server">[HL_tasknum]</asp:HyperLink><br />
        &nbsp;
        <br />
        Id:
        <asp:DropDownList ID="DDL_TaskId" runat="server" DataSourceID="SqlDataSourceTask" DataTextField="id" DataValueField="id" AutoPostBack="True" Width="127px">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT id FROM Task WHERE (responsible = @responsible) AND (status <> 'close')">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtUserName" Name="responsible" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:TextBox ID="TB_description" runat="server" Height="80px" ReadOnly="True" TextMode="MultiLine"
            Width="578px"></asp:TextBox><br />
        Staus:<asp:DropDownList ID="DDL_state" runat="server" Width="85px">
            <asp:ListItem Value="0">未完成</asp:ListItem>
            <asp:ListItem Value="1">完成</asp:ListItem>
        </asp:DropDownList><br />
        Comment:<br />
        <asp:TextBox ID="TB_comment" runat="server" Height="83px" TextMode="MultiLine" Width="576px"></asp:TextBox><br />
        <asp:Button ID="Btn_Update" runat="server" Text="Update" Width="120px" />
        <asp:SqlDataSource ID="SqlDataSourceMyTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT id, type, description, status, due_date, commiter, create_date, comment FROM Task WHERE (responsible = @responsible)">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtUserName" Name="responsible" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridViewMyTask" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="id" DataSourceID="SqlDataSourceMyTask">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                <asp:BoundField DataField="commiter" HeaderText="commiter" SortExpression="commiter" />
                <asp:BoundField DataField="create_date" HeaderText="create_date" SortExpression="create_date" />
                <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
