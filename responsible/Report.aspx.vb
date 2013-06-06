Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report2
    Inherits System.Web.UI.Page

    Protected m_name As New String("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_name = Request.QueryString("name")
        If Not Page.IsPostBack Then
            Me.TxtUserName.Text = m_name
        End If

        Dim report As New MyReport
        Dim info_reponse As String = report.fillPie(ChartResponsePie, m_name, "responsible")
        report.fillBar(ChartResponseBar, m_name, "responsible")
        Me.TxtReponseTask.Text = info_reponse

    End Sub

    Protected Sub ChartResponsePie_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartResponsePie.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim type As New String("")
        Dim status As String = report.GetPieStatus(val)
        Response.Redirect("..\manager\DetailReport.aspx?name=" + m_name + "&status=" + status + "&rpname=" + m_name)

    End Sub

    Protected Sub ChartResponseBarr_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartResponseBar.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim type As New String("")
        Dim status As String = report.GetBarStatus(val, type)
        Response.Redirect("..\manager\DetailReport.aspx?name=" + m_name + "&status=" + status + "&type=" + type + "&rpname=" + m_name)

    End Sub

    Protected Sub LB_Reponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Reponse.Click
        Response.Redirect("Responsible.aspx?name=" + m_name)
    End Sub

    Protected Sub LB_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Logout.Click
        Response.Redirect("..\login.aspx")
    End Sub

    Protected Sub LB_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_All.Click
        Response.Redirect("..\manager\Report.aspx?name=" + m_name)
    End Sub
End Class