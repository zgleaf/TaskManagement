Imports system.Data.SqlClient

Partial Public Class DetailReport
    Inherits System.Web.UI.Page

    Protected Shared m_ciname As New String("")
    Protected Shared m_rpname As New String("")
    Protected Shared m_type As New String("")
    Protected Shared m_status As New String("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            m_type = Request.QueryString("type")
            m_status = Request.QueryString("status")
            m_ciname = Request.QueryString("ciname")
            m_rpname = Request.QueryString("rpname")

        End If

        UpdateTaskView()

    End Sub

    Protected Sub AndorWhere(ByRef toAnd As Boolean, ByRef myselect As String)
        If toAnd Then
            myselect += " AND "
        Else
            myselect += " WHERE "
            toAnd = True
        End If
    End Sub

    Protected Sub UpdateTaskView()

        Dim toAnd As Boolean = False

        Dim myselect = "SELECT id, description, responsible, due_date, status, type, commiter, create_date, department, comment, update_date FROM Task"
        If m_status <> "" Then
            myselect += " WHERE status='" + m_status + "'"
            toAnd = True
        End If
        If m_type <> "" Then
            AndorWhere(toAnd, myselect)
            If m_type <> "delay" Then
                myselect += "type='" + m_type + "'"
            Else
                myselect += "type='on-going' or type='new'"
            End If
        End If
        If m_ciname <> "" Then
            AndorWhere(toAnd, myselect)
            myselect += "commiter='" + m_ciname + "'"
        End If
        If m_rpname <> "" Then
            AndorWhere(toAnd, myselect)
            myselect += "responsible='" + m_rpname + "'"
        End If
        myselect += ";"
        Me.SqlDataSourceTask.SelectCommand = myselect
        Me.SqlDataSourceTask.Select(DataSourceSelectArguments.Empty)
        Me.SqlDataSourceTask.DataBind()
        Me.GridViewTask.DataBind()
    End Sub

End Class