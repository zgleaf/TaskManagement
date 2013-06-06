Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report
    Inherits System.Web.UI.Page

    Protected m_name As New String("")
    Protected m_nameReq As New String("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_name = Request.QueryString("name")
        If m_name <> "" Then
            m_nameReq = "&name=" + m_name
        Else
            m_nameReq = ""
        End If

        If Not Page.IsPostBack Then

            Me.Back.Attributes.Add("onClick", "javascript:history.back(); return false;")

            If m_name <> "" Then
                Me.Login.Visible = False
            Else
                Me.Login.Visible = True
            End If


            Me.DDL_Member.Items.Clear()
            Me.DDL_Member.Items.Add("All")

            Dim members As New List(Of String)
            Dim db As New MyDB
            db.getResponsible(members)

            For Each mem As String In members
                Me.DDL_Member.Items.Add(mem)
            Next

        End If

        Dim report As New MyReport
        Dim info As String = report.fillPie(ChartPie, "", "")
        report.fillBar(ChartBar, "", "")
        Me.TxtTaskInfo.Text = info

        updateMembers()

    End Sub

    Protected Sub ChartPie_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartPie.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim status As String = report.GetPieStatus(val)
        Response.Redirect("DetailReport.aspx?status=" + status + m_nameReq)

    End Sub

    Protected Sub ChartBar_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartBar.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim type As New String("")
        Dim status As String = report.GetBarStatus(val, type)
        Response.Redirect("DetailReport.aspx?status=" + status + "&type=" + type + m_nameReq)

    End Sub

    Protected Sub DDL_Member_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDL_Member.SelectedIndexChanged
        'updateMembers()

    End Sub

    Protected Sub updateMembers()
        If (Me.DDL_Member.Text = "NONE") Then
            Me.ChartPieMember.Visible = False
            Me.ChartBarMember.Visible = False
            Me.ChartTaskByPerson.Visible = False
            Me.TxtTaskInfoMember.Text = ""
            Return
        End If
        Dim name = Me.DDL_Member.Text
        Dim report As New MyReport
        If (Me.DDL_Member.Text = "All") Then
            Me.ChartBarMember.Visible = False
            Me.ChartBarMember.Visible = False
            Me.ChartTaskByPerson.Visible = True
            Dim info_response As String = report.fillBarByPerson(ChartTaskByPerson)
            Me.TxtTaskInfoMember.Text = ""
        Else
            Me.ChartPieMember.Visible = True
            Me.ChartBarMember.Visible = True
            Me.ChartTaskByPerson.Visible = False
            Dim info_reponse As String = report.fillPie(ChartPieMember, name, "responsible")
            report.fillBar(ChartBarMember, name, "responsible")
            Me.TxtTaskInfoMember.Text = info_reponse
        End If
    End Sub

    Protected Sub ChartPieMember_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartPieMember.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim status As String = report.GetPieStatus(val)
        Response.Redirect("DetailReport.aspx?status=" + status + "&rpname=" + Me.DDL_Member.Text + m_nameReq)

    End Sub

    Protected Sub ChartTypeMember_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartBarMember.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim type As New String("")
        Dim status As String = report.GetBarStatus(val, type)
        Response.Redirect("DetailReport.aspx?status=" + status + "&type=" + type + "&rpname=" + Me.DDL_Member.Text + m_nameReq)

    End Sub

    Protected Sub ChartTaskByPerson_Point(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles ChartTaskByPerson.Click
        Dim val = e.PostBackValue
        Dim report As New MyReport
        Dim reponse As New String("")
        Dim status As String = report.GetBarStatusByPerson(val, reponse)

        Response.Redirect("DetailReport.aspx?status=" + status + "&rpname=" + reponse + m_nameReq)

    End Sub

    Protected Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Login.Click
        Response.Redirect("..\login.aspx")
    End Sub
End Class