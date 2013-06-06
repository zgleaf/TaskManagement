Public Partial Class admin
    Inherits System.Web.UI.Page

    Protected Shared m_name As New String("")
    Protected Shared m_pwd As New String("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_name = Request.QueryString("name")
        m_pwd = Request.QueryString("pwd")

        If Not Page.IsPostBack Then

            Dim db As New MyDB
            If Not db.login(m_name, m_pwd) And Not db.getUserType(m_name) = "admin" Then
                Response.Redirect("../login.aspx")
                Return
            End If
        End If
    End Sub

    Protected Sub Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logout.Click

        Response.Redirect("../login.aspx")
    End Sub

    Protected Sub LB_TaskMg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_TaskMg.Click
        Response.Redirect("taskmanage.aspx?name=" + m_name + "&pwd=" + m_pwd)
    End Sub

    Protected Sub LB_LogMg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_LogMg.Click
        Response.Redirect("logmanage.aspx?name=" + m_name + "&pwd=" + m_pwd)
    End Sub

    Protected Sub LB_UserMg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_UserMg.Click
        Response.Redirect("usermanage.aspx?name=" + m_name + "&pwd=" + m_pwd)
    End Sub
End Class