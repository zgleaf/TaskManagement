<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="responsible.aspx.vb" Inherits="TastManagement.Responsible" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LB_Report" runat="server">MyReport</asp:LinkButton>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="LB_All" runat="server">AllTasks</asp:LinkButton>
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;<asp:LinkButton ID="LB_Logout" runat="server">Logout</asp:LinkButton><br />
        <br />
        Responsible :
        <asp:Label ID="TxtUserName" runat="server"></asp:Label><br />
        my tasks :
        <asp:HyperLink ID="HL_tasknum" runat="server">[HL_tasknum]</asp:HyperLink><br />
        &nbsp;
        <br />
        <asp:CheckBox ID="CK_Closed" runat="server" Text="Closed" AutoPostBack="True" Enabled="False" />&nbsp;
        <asp:CheckBox ID="CK_Finished" runat="server" Text="Finished" AutoPostBack="True" />&nbsp;
        <asp:CheckBox ID="CK_Delay" runat="server" Checked="True" Text="Delay" AutoPostBack="True" />&nbsp;
        <asp:CheckBox ID="CK_On_Going" runat="server" Checked="True" Text="On_Going" AutoPostBack="True" /><br />
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
        <asp:TextBox ID="TB_comment" runat="server" Height="83px" TextMode="MultiLine" Width="576px"></asp:TextBox><br />
        <asp:Button ID="Btn_Update" runat="server" Text="Update" Width="120px" />
        <asp:SqlDataSource ID="SqlDataSourceMyTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM Task WHERE (responsible = @responsible)">
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
                <asp:BoundField DataField="description" HeaderText="描述" SortExpression="description" />
                <asp:BoundField DataField="due_date" HeaderText="计划完成日期" SortExpression="due_date" DataFormatString="{0:yyyy-MM-dd}"  HtmlEncode="false" />
                <asp:BoundField DataField="status" HeaderText="当前状态" SortExpression="status" />
                <asp:BoundField DataField="type" HeaderText="任务类型" SortExpression="type" />
                <asp:BoundField DataField="commiter" HeaderText="提出人" SortExpression="commiter" />
                <asp:BoundField DataField="create_date" HeaderText="提出日期" SortExpression="create_date" DataFormatString="{0:yyyy-MM-dd}"  HtmlEncode="false" />
                <asp:BoundField DataField="department" HeaderText="部门" SortExpression="department" />
                <asp:BoundField DataField="comment" HeaderText="备注" SortExpression="comment" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
