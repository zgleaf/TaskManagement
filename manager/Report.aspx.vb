Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report
    Inherits System.Web.UI.Page

    Protected Shared back_url As New String("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim report As New MyReport
        Dim info As String = report.fillPie(ChartPie, "", "")
        report.fillBar(ChartBar, "", "")
        Me.TxtTaskInfo.Text = info

        updateMembers()

        If Page.IsPostBack Then Return

        If Request.UrlReferrer <> Nothing Then
            back_url = Request.UrlReferrer.AbsoluteUri.ToString()
        End If
        Me.DDL_Member.Items.Clear()
        Me.DDL_Member.Items.Add("NONE")

        Dim members As New List(Of String)
        Dim db As New MyDB
        db.getResponsible(members)

        For Each mem As String In members
            Me.DDL_Member.Items.Add(mem)
        Next

        Me.DDL_Member.Items.Add("All")

    End Sub

    Protected Sub ChartPie_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartPie.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim status As String = report.GetPieStatus(val)
        Response.Redirect("DetailReport.aspx?status=" + status)

    End Sub

    Protected Sub ChartBar_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartBar.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim type As New String("")
        Dim status As String = report.GetBarStatus(val, type)
        Response.Redirect("DetailReport.aspx?status=" + status + "&type=" + type)

    End Sub

    Protected Sub DDL_Member_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDL_Member.SelectedIndexChanged
        updateMembers()

    End Sub

    Protected Sub updateMembers()
        If (Me.DDL_Member.Text = "NONE") Then
            Me.ChartPieMember.Visible = False
            Me.ChartBarMember.Visible = False
            Me.TxtTaskInfoMember.Text = ""
            Return
        End If
        Me.ChartPieMember.Visible = True
        Me.ChartBarMember.Visible = True
        Dim name = Me.DDL_Member.Text
        Dim report As New MyReport
        If (Me.DDL_Member.Text = "All") Then
            Dim info_reponse As String = report.fillPie(ChartPieMember, name, "responsible")
            report.fillBar(ChartBarMember, name, "responsible")
            Me.TxtTaskInfoMember.Text = info_reponse
        Else
            Dim info_reponse As String = report.fillPie(ChartPieMember, name, "responsible")
            report.fillBar(ChartBarMember, name, "responsible")
            Me.TxtTaskInfoMember.Text = info_reponse
        End If
    End Sub

    Protected Sub ChartPieMember_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartPieMember.Click
        Dim val = e.PostBackValue

    End Sub

    Protected Sub ChartTypeMember_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartBarMember.Click
        Dim val = e.PostBackValue

    End Sub

    Protected Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        If back_url <> "" Then
            Response.Redirect(back_url)
        End If
    End Sub
End Class