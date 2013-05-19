Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click

        Dim ConnectString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        Me.TxtLog.Text = ConnectString

        Try
            Dim connect As SqlClient.SqlConnection
            connect = New SqlClient.SqlConnection(ConnectString)
            connect.Open()

        Catch ex As Exception
            Me.TxtLog.Text += ex.ToString()
            Return
        End Try

        Dim name = Me.TbName.Text()
        Dim pwd = Me.TbPassword.Text

        Dim db As New MyDB

        If Not db.isUser(name) Then
            Dim msg As MyMessage
            msg = New MyMessage(Me)
            msg.alert("用户不存在！")
            Return
        ElseIf db.isUserInvalid(name) Then
            Dim msg As MyMessage
            msg = New MyMessage(Me)
            msg.alert("用户已删除！")
            Return
        ElseIf Not db.login(name, pwd) Then
            Dim msg As MyMessage
            msg = New MyMessage(Me)
            msg.alert("密码不正确！")
            Return
        Else
            MyLog.log(name + " login.")
        End If

        Dim type = db.getUserType(name)
        If type = "commiter" Then
            Response.Redirect("commiter/Report.aspx?name=" + name)
        ElseIf type = "responsible" Then
            Response.Redirect("responsible/Responsible.aspx?name=" + name)
        ElseIf type = "admin" Then

        End If

    End Sub

End Class