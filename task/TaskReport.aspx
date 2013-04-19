<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TaskReport.aspx.vb" Inherits="TastManagement.TaskBar" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:ReportViewer ID="RV_TaskMatrix" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="400px" Width="807px" ZoomMode="FullPage">
            <LocalReport ReportPath="task\TaskMatrix.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ODS_Task" Name="DataSetTask_Task" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ODS_Task" runat="server" SelectMethod="GetData"
            TypeName="TastManagement.DataSetTaskTableAdapters.TaskTableAdapter" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}">
            <InsertParameters>
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="commiter" Type="String" />
                <asp:Parameter Name="state" Type="String" />
                <asp:Parameter Name="create_date" Type="DateTime" />
                <asp:Parameter Name="plan_finish_date" Type="DateTime" />
                <asp:Parameter Name="worker" Type="String" />
                <asp:Parameter Name="work_state" Type="Int32" />
                <asp:Parameter Name="update_date" Type="DateTime" />
                <asp:Parameter Name="description" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
