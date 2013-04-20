<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Commiter.aspx.vb" Inherits="TastManagement.Commiter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Commiter :
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
            SelectCommand="SELECT * FROM [Task] WHERE ([commiter] = @commiter)">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtUserName" Name="commiter" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        Type &nbsp;<asp:DropDownList ID="DDL_Type" runat="server" DataSourceID="SqlDataSourceTask" DataTextField="type" DataValueField="type">
            <asp:ListItem>Kaison</asp:ListItem>
            <asp:ListItem>5s</asp:ListItem>
            <asp:ListItem>EHS</asp:ListItem>
            <asp:ListItem>QC</asp:ListItem>
            <asp:ListItem>DAM</asp:ListItem>
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [type] FROM [TaskType]"></asp:SqlDataSource>
        <br />
        Plan&nbsp;
        <asp:TextBox ID="TB_plandate" runat="server" ReadOnly="True" Width="68px"></asp:TextBox>
        <asp:DropDownList ID="DDL_planhour" runat="server">
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
        </asp:DropDownList>:<asp:DropDownList ID="DDL_planmin" runat="server">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
        </asp:DropDownList><div style="display:none;" id="divpplandate"> 
        <asp:Calendar ID="Calendar_Plan" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
            Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        </asp:Calendar></div>
        <br />
        Assign to&nbsp;<asp:DropDownList ID="DDL_worker" runat="server" DataSourceID="SqlDataSourceWorker"
            DataTextField="name" DataValueField="name">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceWorker" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [name] FROM [User] WHERE ([permission] = @permission)">
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="permission" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:TextBox ID="TB_comment" runat="server" Height="83px" TextMode="MultiLine" Width="256px"></asp:TextBox><br />
        <br />
        <asp:Button ID="Btn_Commit" runat="server" Text="Commit" />
    
    </div>
    </form>
</body>
</html>
