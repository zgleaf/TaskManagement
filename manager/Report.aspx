<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Report.aspx.vb" Inherits="TastManagement.Report" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Task Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="Back" runat="server">Back</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="Login" runat="server">Login</asp:LinkButton><br />
        Task: &nbsp;<asp:Label ID="TxtTaskInfo" runat="server" Text="no task"></asp:Label><br />
        <asp:Chart ID="ChartPie" runat="server">
            <Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Pie" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:Chart ID="ChartBar" runat="server">
            <Series>
                <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <br />
        Responsible:
        <asp:DropDownList ID="DDL_Member" runat="server" Width="116px" AutoPostBack="True">
            <asp:ListItem Selected="True">NONE</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="TxtTaskInfoMember" runat="server"></asp:Label><br />
        <asp:Chart ID="ChartPieMember" runat="server">
            <Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Pie" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:Chart ID="ChartBarMember" runat="server">
            <Series>
                <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Name="Series1">
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
