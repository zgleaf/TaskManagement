<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Commiter.aspx.vb" Inherits="TastManagement.Commiter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LB_Report" runat="server">Report</asp:LinkButton>
        <asp:LinkButton ID="LB_Reponse" runat="server">Reponse</asp:LinkButton>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
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
        Commit<br />
        <asp:TextBox ID="TB_comment" runat="server" Height="83px" TextMode="MultiLine" Width="256px"></asp:TextBox><br />
        <asp:Button ID="Btn_Commit" runat="server" Text="Commit" Width="131px" />
        <br />
        <br />
        <asp:GridView ID="GridViewMyTask" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="id" DataSourceID="SqlDataSourceMyTask">
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
            <HeaderStyle BackColor="LightSeaGreen" />
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
