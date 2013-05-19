Partial Public Class Responsible
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim name = Request.QueryString("name")
        Me.TxtUserName.Text = name

        Dim db As New MyDB

        Dim mytaskinfo = db.getTaskInfo(name, "responsible")
        Me.HL_tasknum.Text = mytaskinfo

    End Sub

    Protected Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDL_TaskId.DataBound
        If Me.DDL_TaskId.Text <> "" Then
            Dim id = Me.DDL_TaskId.SelectedValue

            updateTaskId(id)
        End If
    End Sub

    Protected Sub Btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Update.Click
        If Me.TxtUserName.Text = "" Then
            Return
        End If

        Dim id = Me.DDL_TaskId.SelectedValue
        Dim respon = Me.TxtUserName.Text
        Dim status = "on-going"
        If Me.DDL_state.SelectedIndex = 1 Then
            status = "finished"
        End If
        Dim comment = Me.TB_comment.Text

        Dim db As New MyDB
        If db.setTaskStatus(id, respon, status, comment) Then
            MyLog.log(respon + "update task: " + id.ToString() + ".")
        End If

        Response.Redirect(Request.RawUrl.ToString)
    End Sub

    Protected Sub DDL_TaskId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDL_TaskId.SelectedIndexChanged
        If Me.DDL_TaskId.Text <> "" Then
            Dim id = Me.DDL_TaskId.SelectedValue
            updateTaskId(id)
        End If
    End Sub

    Protected Sub updateTaskId(ByVal id As Integer)
        Dim db As New MyDB
        Dim status As String = "on-going"
        Dim descript As String = ""
        Dim comment As String = ""
        If db.getTaskStatus(id, status, descript, comment) Then
            If status.ToLower() = "new" Or status.ToLower() = "on-going" Then
                Me.DDL_state.SelectedIndex = 0
            Else
                Me.DDL_state.SelectedIndex = 1
            End If

            Me.TB_description.Text = descript
            Me.TB_comment.Text = comment

        Else
            Me.DDL_state.SelectedIndex = 0
            Me.TB_description.Text = descript
            Me.TB_comment.Text = comment

        End If
    End Sub

    Protected Sub LB_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Report.Click
        Dim name = Me.TxtUserName.Text
        Response.Redirect("Responsible.aspx?name=" + name)
    End Sub

    Protected Sub LB_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_All.Click
        Response.Redirect("..\manager\Report.aspx")
    End Sub

    Protected Sub LB_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Logout.Click
        Response.Redirect("..\manager\login.aspx")
    End Sub
End Class