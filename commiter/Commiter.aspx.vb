Public Partial Class Commiter
    Inherits System.Web.UI.Page

    Protected m_name As New String("")
    Protected Shared m_selTasks As New String("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_name = Request.QueryString("name")

        If Not Page.IsPostBack Then
            m_selTasks = ""

            Me.TxtUserName.Text = m_name

            Dim db As New MyDB

            Dim mytaskinfo = db.getTaskInfo(m_name, "commiter")
            Me.HL_tasknum.Text = mytaskinfo

            Me.TB_duedate.Text = Now.ToShortDateString()
            Dim hour = Now.Hour
            If hour < 8 Then
                hour = 8
            End If
            If hour > 18 Then
                hour = 18
            End If
            Me.DDL_duehour.SelectedValue = hour

        End If

        UpdateTaskView()

    End Sub

    Protected Sub Btn_Commit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Commit.Click
        If m_name = "" Or Me.TB_descript.Text = "" Then
            Return
        End If

        Dim commiter = m_name
        Dim type = Me.DDL_Type.SelectedValue
        Dim status = "on-going"
        Dim create_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim due_date = Me.TB_duedate.Text + " " + Me.DDL_duehour.Text + ":" + Me.DDL_duemin.Text + ":00"
        Dim respon = Me.DDL_respon.Text
        Dim descript = Me.TB_descript.Text
        Dim comment = Me.TB_comment.Text
        Dim depart = Me.TB_depart.Text()

        Dim db As New MyDB
        Dim task = "'" + commiter + "','" + type + "','" + status + "','" + depart + "'"
        task += ",'" + create_date + "','" + due_date + "'"
        task += ",'" + respon + "',@update_date,@description,@comment"
        Dim info = "commiter, type, status, department, create_date, due_date, responsible, update_date, description, comment"
        If db.addTask(info, task, descript, comment) Then
            MyLog.log(commiter + "add new task.")
        End If

        Response.Redirect(Request.RawUrl.ToString)
    End Sub

    Protected Sub UpdateTaskView()
        If m_name = "" Then
            Return
        End If

        Dim myselect = "SELECT * FROM Task WHERE commiter='" + m_name + "'"

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

        myselect += " Order By [id] desc;"
        If Not m_selTasks.Equals(myselect) Then
            m_selTasks = myselect
            Me.SqlDataSourceMyTask.SelectCommand = m_selTasks
            Me.SqlDataSourceMyTask.Select(DataSourceSelectArguments.Empty)
            Me.SqlDataSourceMyTask.DataBind()
            Me.GridViewMyTask.DataBind()
        End If
    End Sub

    Protected Sub LB_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Report.Click
        Response.Redirect("Report.aspx?name=" + m_name)
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