Partial Public Class taskmanager
    Inherits System.Web.UI.Page

    Protected Shared m_name As New String("")
    Protected Shared m_pwd As New String("")
    Protected Shared m_seltasks As String = "SELECT * FROM [Task]"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            m_name = Request.QueryString("name")
            m_pwd = Request.QueryString("pwd")

            Dim db As New MyDB
            If Not db.login(m_name, m_pwd) And Not db.getUserType(m_name) = "admin" Then
                Me.Btn_Search.Enabled = False
                Me.Btn_Clear.Enabled = False
                Response.Redirect("../login.aspx")
                Return
            End If
        End If

        UpdateTaskMgr()

    End Sub

    Protected Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        'UpdateTaskMgr()

    End Sub

    Protected Sub UpdateTaskMgr()
        Dim id As String = Me.TB_id.Text
        Dim commiter As String = Me.TB_commiter.Text
        Dim reponse As String = Me.TB_reponse.Text

        Dim myselect = "SELECT * FROM [Task]"
        If id <> "" Then
            myselect += " WHERE id=" + id
        ElseIf commiter <> "" Then
            If reponse = "" Then
                myselect += " WHERE commiter='" + commiter + "'"
            Else
                myselect += " WHERE commiter='" + commiter + "' AND " + "responsible='" + reponse + "'"
            End If
        ElseIf reponse <> "" Then
            myselect += " WHERE responsible='" + reponse + "'"
        End If
        myselect += ";"

        If Not m_seltasks.Equals(myselect) Then
            m_seltasks = myselect
            Me.TaskMgr.SelectCommand = myselect
            Me.TaskMgr.Select(DataSourceSelectArguments.Empty)
            Me.TaskMgr.DataBind()
            Me.TaskView.DataBind()
        End If
    End Sub

    Protected Sub Btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Clear.Click

        Me.TaskMgr.UpdateCommand = "DELETE FROM [Task];"
        Me.TaskMgr.Update()
        Me.TaskView.DataBind()

        Response.Redirect(Request.RawUrl.ToString)
    End Sub
End Class