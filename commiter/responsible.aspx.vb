Partial Public Class Responsible1
    Inherits System.Web.UI.Page

    Protected Shared m_name As New String("")
    Protected Shared m_selTaskId As New String("Select id from Task")
    Protected Shared m_selTasks As New String("Select * from Task")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            m_name = Request.QueryString("name")
            Me.TxtUserName.Text = m_name

            Dim db As New MyDB

            Dim mytaskinfo = db.getTaskInfo(m_name, "responsible")
            Me.HL_tasknum.Text = mytaskinfo

        End If

        UpdateTaskView()

    End Sub

    Protected Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDL_TaskId.DataBound
        If Me.DDL_TaskId.Text <> "" Then
            Dim id = Me.DDL_TaskId.SelectedValue

            updateTaskId(id)
        End If
    End Sub

    Protected Sub Btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Update.Click
        If m_name = "" Then
            Return
        End If

        Dim id = Me.DDL_TaskId.SelectedValue
        Dim respon = m_name
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

    Protected Sub UpdateTaskView()
        If m_name = "" Then
            Return
        End If

        Dim myselect = "WHERE responsible='" + m_name + "'"

        Dim closed As Boolean = Me.CK_Closed.Checked
        Dim finshed As Boolean = Me.CK_Finished.Checked
        Dim delay As Boolean = Me.CK_Delay.Checked
        Dim normal As Boolean = Me.CK_On_Going.Checked
        Dim none As Boolean = Not (closed Or finshed Or delay Or normal)

        If (Not none) Then
            If delay And normal Then
                myselect += " AND ((status='on-going')"
            ElseIf delay Then
                myselect += " AND (((status='on-going') AND (due_date <= GETDATE()))"
            ElseIf normal Then
                myselect += " AND (((status='on-going') AND (due_date > GETDATE()))"
            Else
                myselect += " AND ("
            End If
            If closed Then
                If delay Or normal Then myselect += " OR "
                myselect += "(status='closed')"
            End If
            If finshed Then
                If delay Or normal Or closed Then myselect += " OR "
                myselect += "(status='finished')"
            End If
            myselect += ")"

        Else
            myselect += " AND (status!='on-going') AND (status!='closed') AND (status!='finished')"

        End If

        myselect += ";"

        If True Then
            m_selTasks = "SELECT * FROM Task " + myselect
            Me.SqlDataSourceMyTask.SelectCommand = m_selTasks
            Me.SqlDataSourceMyTask.Select(DataSourceSelectArguments.Empty)
            Me.SqlDataSourceMyTask.DataBind()
            Me.GridViewMyTask.DataBind()
        End If
        If Not m_selTaskId.Equals("SELECT id FROM Task " + myselect) Then
            m_selTaskId = "SELECT id FROM Task " + myselect
            Me.SqlDataSourceTask.SelectCommand = m_selTaskId
            Me.SqlDataSourceTask.Select(DataSourceSelectArguments.Empty)
            Me.SqlDataSourceTask.DataBind()
            Me.DDL_TaskId.DataBind()
        End If
        If Me.DDL_TaskId.Text = "" Then
            Me.TB_description.Text = ""
            Me.TB_comment.Text = ""
        End If
    End Sub

    Protected Sub DDL_TaskId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDL_TaskId.SelectedIndexChanged
        If Me.DDL_TaskId.Text <> "" Then
            Dim id = Me.DDL_TaskId.SelectedValue
            updateTaskId(id)
        Else
            Me.TB_description.Text = ""
            Me.TB_comment.Text = ""
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
        Response.Redirect("Responsible.aspx?name=" + m_name)
    End Sub

    Protected Sub LB_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_All.Click
        Response.Redirect("..\manager\Report.aspx?name=" + m_name)
    End Sub

    Protected Sub LB_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Logout.Click
        Response.Redirect("..\login.aspx")
    End Sub

    Protected Sub LB_Commit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Commit.Click
        Response.Redirect("Commiter.aspx?name=" + Me.TxtUserName.Text)
    End Sub
End Class