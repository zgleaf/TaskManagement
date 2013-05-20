Partial Public Class taskmanager
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Page.IsPostBack Then Return

        UpdateTaskMgr()

    End Sub

    Protected Sub TaskMgr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskMgr.Load
        Dim myselect = Me.TaskMgr.SelectCommand

    End Sub

    Protected Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        UpdateTaskMgr()

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
        Me.TaskMgr.SelectCommand = myselect
        Me.TaskMgr.Select(DataSourceSelectArguments.Empty)
        Me.TaskMgr.DataBind()
        Me.TaskView.DataBind()
    End Sub
End Class