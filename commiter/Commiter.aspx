<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Commiter.aspx.vb" Inherits="TastManagement.Commiter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LB_Report" runat="server">MyReport</asp:LinkButton>
        <asp:LinkButton ID="LB_Reponse" runat="server">MyReponsible</asp:LinkButton>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;<asp:LinkButton ID="LB_All" runat="server">AllTasks</asp:LinkButton>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:LinkButton ID="LB_Logout" runat="server">Logout</asp:LinkButton><br />
        <br />
        Commiter :
        <asp:Label ID="TxtUserName" runat="server"></asp:Label><br />
        my tasks :
        <asp:HyperLink ID="HL_tasknum" runat="server">[HL_tasknum]</asp:HyperLink><br />
        &nbsp;<br />
        Description<br />
        <asp:TextBox ID="TB_descript" runat="server" Height="82px" TextMode="MultiLine" Width="528px"></asp:TextBox><br />
        Type &nbsp;<asp:DropDownList ID="DDL_Type" runat="server" DataSourceID="SqlDataSourceTask" DataTextField="type" DataValueField="type">
            <asp:ListItem>Kaison</asp:ListItem>
            <asp:ListItem>5s</asp:ListItem>
            <asp:ListItem>EHS</asp:ListItem>
            <asp:ListItem>QC</asp:ListItem>
            <asp:ListItem>DAM</asp:ListItem>
        </asp:DropDownList>
        Assign to&nbsp;<asp:DropDownList ID="DDL_respon" runat="server" DataSourceID="SqlDataSourceWorker"
            DataTextField="name" DataValueField="name">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSourceTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [type] FROM [TaskType]"></asp:SqlDataSource>
        &nbsp;<asp:SqlDataSource ID="SqlDataSourceWorker" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [name] FROM [User] WHERE ([permission] = @permission)">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="permission" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        DueDate&nbsp;
        <asp:TextBox ID="TB_duedate" runat="server" Width="68px"></asp:TextBox>
        <asp:DropDownList ID="DDL_duehour" runat="server">
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
        </asp:DropDownList>:<asp:DropDownList ID="DDL_duemin" runat="server">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
        </asp:DropDownList><br />
        Comment &nbsp;<asp:TextBox ID="TB_comment" runat="server" Height="83px" TextMode="MultiLine" Width="443px"></asp:TextBox><br />
        <asp:Button ID="Btn_Commit" runat="server" Text="Commit" Width="131px" Height="30px" />
        <br />
        <br />
        <asp:CheckBox ID="CK_Closed" runat="server" Text="Closed" AutoPostBack="True" />&nbsp;
        <asp:CheckBox ID="CK_Finished" runat="server" Text="Finished" AutoPostBack="True" />&nbsp;
        <asp:CheckBox ID="CK_Delay" runat="server" Checked="True" Text="Delay" AutoPostBack="True" />&nbsp;
        <asp:CheckBox ID="CK_On_Going" runat="server" Checked="True" Text="On_Going" AutoPostBack="True" /><br />
        <asp:GridView ID="GridViewMyTask" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="id" DataSourceID="SqlDataSourceMyTask" PageSize="100">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="description" HeaderText="描述" SortExpression="description" />
                <asp:BoundField DataField="commiter" HeaderText="提出人" SortExpression="commiter" />
                <asp:BoundField DataField="create_date" HeaderText="提出日期" SortExpression="create_date" DataFormatString="{0:yyyy-MM-dd}"  HtmlEncode="False" />
                <asp:BoundField DataField="responsible" HeaderText="负责人" SortExpression="responsible" />
                <asp:BoundField DataField="due_date" HeaderText="计划完成日期" SortExpression="due_date" DataFormatString="{0:yyyy-MM-dd}"  HtmlEncode="False" />
                <asp:BoundField DataField="type" HeaderText="任务类型" SortExpression="type" />
                <asp:BoundField DataField="department" HeaderText="部门" SortExpression="department" />
                <asp:BoundField DataField="status" HeaderText="当前状态" SortExpression="status" />
                <asp:BoundField DataField="comment" HeaderText="备注" SortExpression="comment" />
            </Columns>
            <HeaderStyle BackColor="LightSteelBlue" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceMyTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Task] WHERE ([commiter] = @commiter)">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtUserName" Name="commiter" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
