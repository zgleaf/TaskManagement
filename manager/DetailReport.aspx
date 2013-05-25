<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DetailReport.aspx.vb" Inherits="TastManagement.DetailReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Detail Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="Back" runat="server">Back</asp:LinkButton>
        &nbsp; &nbsp;<asp:LinkButton ID="Login" runat="server">Login</asp:LinkButton><br />
        <asp:Label ID="TxtFilter" runat="server" Text="Filter"></asp:Label>:
        <asp:Label ID="TxtFilterContent" runat="server" Text="NULL"></asp:Label><br />
        <br />
    
    </div>
        <asp:GridView ID="GridViewTask" runat="server" AutoGenerateColumns="False" Height="398px" PageSize="100" AllowPaging="True" DataKeyNames="id" DataSourceID="SqlDataSourceTask">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="description" HeaderText="����" SortExpression="description" />
                <asp:BoundField DataField="responsible" HeaderText="������" SortExpression="responsible" />
                <asp:BoundField DataField="due_date" HeaderText="�ƻ��������" SortExpression="due_date" DataFormatString="{0:yyyy-MM-dd}"  HtmlEncode="False" />
                <asp:BoundField DataField="status" HeaderText="��ǰ״̬" SortExpression="status" />
                <asp:BoundField DataField="type" HeaderText="��������" SortExpression="type" />
                <asp:BoundField DataField="commiter" HeaderText="�����" SortExpression="commiter" />
                <asp:BoundField DataField="create_date" HeaderText="�������" SortExpression="create_date" DataFormatString="{0:yyyy-MM-dd}"  HtmlEncode="False" />
                <asp:BoundField DataField="department" HeaderText="����" SortExpression="department" />
                <asp:BoundField DataField="comment" HeaderText="��ע" SortExpression="comment" />
            </Columns>
            <HeaderStyle BackColor="LightSteelBlue" />
        </asp:GridView>
        &nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSourceTask" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM Task ORDER BY id">
        </asp:SqlDataSource>
    </form>
</body>
</html>
