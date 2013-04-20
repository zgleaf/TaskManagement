Public Partial Class Commiter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim name = Request.QueryString("name")
        Me.TxtUserName.Text = name

        Dim db As New MyDB

        Dim mytaskinfo = db.getTaskInfo(name, "commiter")
        Me.HL_tasknum.Text = mytaskinfo

        Me.TB_plandate.Text = Now.ToShortDateString()
        Dim hour = Now.Hour
        If hour < 8 Then
            hour = 8
        End If
        If hour > 18 Then
            hour = 18
        End If
        Me.DDL_planhour.SelectedValue = hour

        If Not Page.IsPostBack Then
            Me.TB_plandate.Attributes.Add("onfocus", "javascript:document.getElementById('divpplandate').style.display='block'")
        End If

    End Sub

    Protected Sub Calendar_Plan_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar_Plan.SelectionChanged

        Me.TB_plandate.Text = Me.Calendar_Plan.SelectedDate.ToShortDateString()

    End Sub

    Protected Sub Btn_Commit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Commit.Click
        If Me.TxtUserName.Text = "" Then
            Return
        End If

        Dim commiter = Me.TxtUserName.Text
        Dim type = Me.DDL_Type.SelectedValue
        Dim state = "new"
        Dim create_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim plan_date = Me.TB_plandate.Text + " " + Me.DDL_planhour.Text + ":" + Me.DDL_planmin.Text + ":00"
        Dim worker = Me.DDL_worker.Text
        Dim update_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim descript = Me.TB_comment.Text

        Dim db As New MyDB
        Dim task = "'" + commiter + "','" + type + "','" + state + "'"
        task += ",'" + create_date + "','" + plan_date + "'"
        task += ",'" + worker + "','" + update_date + "',@descript"
        Dim info = "commiter, type, state, create_date, plan_finish_date, worker, update_date, description"
        If db.addTask(info, task, descript) Then
            MyLog.log(commiter + "add new task.")
        End If

        Response.Redirect(Request.RawUrl.ToString)
    End Sub
End Class