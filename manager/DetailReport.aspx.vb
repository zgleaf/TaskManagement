Imports system.Data.SqlClient

Partial Public Class DetailReport
    Inherits System.Web.UI.Page

    Protected Shared back_url As New String("")

    Protected Shared m_ciname As New String("")
    Protected Shared m_rpname As New String("")
    Protected Shared m_type As New String("")
    Protected Shared m_status As New String("")

    Protected Shared m_selTasks As New String("Select * from Task")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim name = Request.QueryString("name")
            If name <> "" Then
                Me.Login.Visible = False
            Else
                Me.Login.Visible = True
            End If

            If Request.UrlReferrer <> Nothing Then
                back_url = Request.UrlReferrer.AbsoluteUri.ToString()
            End If

            m_type = Request.QueryString("type")
            m_status = Request.QueryString("status")
            m_ciname = Request.QueryString("ciname")
            m_rpname = Request.QueryString("rpname")

            Dim filter As New String("")
            If m_type <> "" Then filter += " type(" + m_type + ") "
            If m_status <> "" Then filter += " status(" + m_status + ") "
            If m_ciname <> "" Then filter += " commiter(" + m_ciname + ") "
            If m_rpname <> "" Then filter += " reponsible(" + m_rpname + ") "
            Me.TxtFilterContent.Text = filter

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

        Dim myselect = "SELECT * FROM Task"
        If m_status <> "" Then
            AndorWhere(toAnd, myselect)
            If m_status = "delay" Then
                myselect += "(status='on-going') AND (due_date <= GETDATE())"
            ElseIf m_status = "on-going" Then
                myselect += "(status='on-going') AND (due_date > GETDATE())"
            Else
                myselect += "status='" + m_status + "'"
            End If
        End If
        If m_type <> "" Then
            AndorWhere(toAnd, myselect)
            myselect += "(type='" + m_type + "')"
        End If
        If m_ciname <> "" Then
            AndorWhere(toAnd, myselect)
            myselect += "(commiter='" + m_ciname + "')"
        End If
        If m_rpname <> "" Then
            AndorWhere(toAnd, myselect)
            myselect += "(responsible='" + m_rpname + "')"
        End If
        myselect += ";"

        If True Then
            m_selTasks = myselect
            Me.SqlDataSourceTask.SelectCommand = m_selTasks
            Me.SqlDataSourceTask.Select(DataSourceSelectArguments.Empty)
            Me.SqlDataSourceTask.DataBind()
            Me.GridViewTask.DataBind()
        End If
    End Sub

    Protected Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        If back_url <> "" Then
            Response.Redirect(back_url)
        End If
    End Sub

    Protected Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Login.Click
        Response.Redirect("..\login.aspx")
    End Sub
End Class