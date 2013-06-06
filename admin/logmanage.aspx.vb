Partial Public Class logmanager
    Inherits System.Web.UI.Page

    Protected m_name As New String("")
    Protected m_pwd As New String("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_name = Request.QueryString("name")
        m_pwd = Request.QueryString("pwd")

        If Not Page.IsPostBack Then

            Dim db As New MyDB
            If Not db.login(m_name, m_pwd) And Not db.getUserType(m_name) = "admin" Then
                Me.BtnClear.Enabled = False
                Response.Redirect("../login.aspx")
                Return
            End If
        End If

    End Sub

    Protected Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click

        Me.TaskMgr.UpdateCommand = "DELETE FROM [Log];"
        Me.TaskMgr.Update()
        Me.LogView.DataBind()

        Response.Redirect(Request.RawUrl.ToString)

    End Sub
End Class