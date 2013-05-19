<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Report.aspx.vb" Inherits="TastManagement.Report2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Commiter Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LB_Reponse" runat="server">MyReponsible</asp:LinkButton>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="LB_All" runat="server">AllTasks</asp:LinkButton>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <asp:LinkButton ID="LB_Logout" runat="server">Logout</asp:LinkButton><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>:
        <asp:Label ID="TxtUserName" runat="server"></asp:Label><br />
        Responsible Task:
        <asp:Label ID="TxtReponseTask" runat="server"></asp:Label><br />
        <br />
        <asp:Chart ID="ChartResponsePie" runat="server">
            <Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Pie" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:Chart ID="ChartResponseBar" runat="server">
            <Series>
                <asp:Series ChartArea="ChartArea1" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
    </div>
    </form>
</body>
</html>
