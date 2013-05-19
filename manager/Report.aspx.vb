Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim report As New MyReport
        Dim info_reponse As String = report.fillPie(ChartPie, "", "")
        report.fillBar(ChartType, "", "")
        Me.TxtTaskInfo.Text = info_reponse

    End Sub

    Protected Sub ChartPie_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartPie.Click
        Dim val = e.PostBackValue

    End Sub

    Protected Sub ChartType_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartType.Click
        Dim val = e.PostBackValue

    End Sub

End Class