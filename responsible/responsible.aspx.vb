Partial Public Class Responsible
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim name = "tom" ' Request.QueryString("name")
        Me.TxtUserName.Text = name

        Dim db As New MyDB

        Dim mytaskinfo = db.getTaskInfo(name, "responsible")
        Me.HL_tasknum.Text = mytaskinfo

        Dim id = Me.DDL_TaskId.SelectedValue
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
        Dim descript = Me.TB_comment.Text

        Dim db As New MyDB
        If db.setTaskStatus(id, respon, status, descript) Then
            MyLog.log(respon + "update task: " + id.ToString() + ".")
        End If

        Response.Redirect(Request.RawUrl.ToString)
    End Sub

    Protected Sub DDL_TaskId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDL_TaskId.SelectedIndexChanged
        If Me.DDL_TaskId.SelectedValue = "" Then
            Return
        End If

        Dim id = Me.DDL_TaskId.SelectedValue
        Dim db As New MyDB
        Dim status As String = "on-going"
        Dim descript As String = ""
        If db.getTaskStatus(id, status, descript) Then
            If status = "new" Or status = "on-going" Then
                Me.DDL_state.SelectedIndex = 0
            Else
                Me.DDL_state.SelectedIndex = 1
            End If

            Me.TB_comment.Text = descript

        Else
            Me.DDL_state.SelectedIndex = 0
            Me.TB_comment.Text = descript

        End If
    End Sub

    Protected Sub DDL_state_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDL_state.SelectedIndexChanged

        Dim state = Me.DDL_state.SelectedValue

    End Sub
End Class