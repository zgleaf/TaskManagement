Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim name = Request.QueryString("name")
        Me.TxtUserName.Text = name

        Dim report As New MyReport
        Dim info_reponse As String = report.fillPie(ChartResponsePie, name, "responsible")
        report.fillBar(ChartResponseBar, name, "responsible")
        Me.TxtReponseTask.Text = info_reponse

    End Sub

    Protected Sub LB_Reponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Reponse.Click
        Dim name = Me.TxtUserName.Text
        Response.Redirect("Responsible.aspx?name=" + name)
    End Sub

    Protected Sub LB_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Logout.Click
        Response.Redirect("..\login.aspx")
    End Sub

    Protected Sub LB_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_All.Click
        Response.Redirect("..\manager\Report.aspx")
    End Sub
End Class