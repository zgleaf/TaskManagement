Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report1
    Inherits System.Web.UI.Page

    Protected Shared m_name As New String("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            m_name = Request.QueryString("name")
            Me.TxtUserName.Text = m_name
        End If

        Dim report As New MyReport
        Dim info_commit As String = report.fillPie(ChartCommitPie, m_name, "commiter")
        report.fillBar(ChartCommitBar, m_name, "commiter")
        Me.TxtCommitTask.Text = info_commit

        Dim info_reponse As String = report.fillPie(ChartResponsePie, m_name, "responsible")
        report.fillBar(ChartResponseBar, m_name, "responsible")
        Me.TxtReponseTask.Text = info_reponse

    End Sub

    Protected Sub ChartCommitPie_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartCommitPie.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim status As String = report.GetPieStatus(val)
        Response.Redirect("..\manager\DetailReport.aspx?name=" + m_name + "&status=" + status + "&ciname=" + Me.TxtUserName.Text)

    End Sub

    Protected Sub ChartCommitBar_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartCommitBar.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim type As New String("")
        Dim status As String = report.GetBarStatus(val, type)
        Response.Redirect("..\manager\DetailReport.aspx?name=" + m_name + "&status=" + status + "&type=" + type + "&ciname=" + Me.TxtUserName.Text)

    End Sub

    Protected Sub ChartResponsePie_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartResponsePie.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim type As New String("")
        Dim status As String = report.GetPieStatus(val)
        Response.Redirect("..\manager\DetailReport.aspx?name=" + m_name + "&status=" + status + "&rpname=" + Me.TxtUserName.Text)

    End Sub

    Protected Sub ChartResponseBarr_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartResponseBar.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim type As New String("")
        Dim status As String = report.GetBarStatus(val, type)
        Response.Redirect("..\manager\DetailReport.aspx?name=" + m_name + "&status=" + status + "&type=" + type + "&rpname=" + Me.TxtUserName.Text)

    End Sub

    Protected Sub LB_Reponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Reponse.Click
        Response.Redirect("Responsible.aspx?name=" + m_name)
    End Sub

    Protected Sub LB_Commit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Commit.Click
        Response.Redirect("Commiter.aspx?name=" + m_name)
    End Sub

    Protected Sub LB_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Logout.Click
        Response.Redirect("..\login.aspx")
    End Sub

    Protected Sub LB_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_All.Click
        Response.Redirect("..\manager\Report.aspx?name=" + m_name)
    End Sub
End Class