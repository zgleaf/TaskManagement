Public Partial Class Commiter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim name = Request.QueryString("name")
        Me.TxtUserName.Text = name

        Dim db As New MyDB

        Dim mytaskinfo = db.getTaskInfo(name, "commiter")
        Me.HL_tasknum.Text = mytaskinfo

        If Not Page.IsPostBack Then
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

    End Sub

    Protected Sub Btn_Commit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Commit.Click
        If Me.TxtUserName.Text = "" Then
            Return
        End If

        Dim commiter = Me.TxtUserName.Text
        Dim type = Me.DDL_Type.SelectedValue
        Dim status = "on-going"
        Dim create_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim due_date = Me.TB_duedate.Text + " " + Me.DDL_duehour.Text + ":" + Me.DDL_duemin.Text + ":00"
        Dim respon = Me.DDL_respon.Text
        Dim descript = Me.TB_descript.Text
        Dim comment = Me.TB_comment.Text

        Dim db As New MyDB
        Dim task = "'" + commiter + "','" + type + "','" + status + "'"
        task += ",'" + create_date + "','" + due_date + "'"
        task += ",'" + respon + "',@update_date,@description,@comment"
        Dim info = "commiter, type, status, create_date, due_date, responsible, update_date, description, comment"
        If db.addTask(info, task, descript, comment) Then
            MyLog.log(commiter + "add new task.")
        End If

        Response.Redirect(Request.RawUrl.ToString)
    End Sub

    Protected Sub LB_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Report.Click
        Dim name = Me.TxtUserName.Text
        Response.Redirect("Report.aspx?name=" + name)
    End Sub

    Protected Sub LB_Reponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Reponse.Click
        Dim name = Me.TxtUserName.Text
        Response.Redirect("Responsible.aspx?name=" + name)

    End Sub

    Protected Sub LB_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Logout.Click
        Response.Redirect("..\login.aspx")
    End Sub
End Class