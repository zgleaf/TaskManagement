Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click

        Dim name = Me.TbName.Text()
        Dim pwd = Me.TbPassword.Text

        Dim db As New MyDB

        If Not db.isUser(name) Then
            Dim msg As MyMessage
            msg = New MyMessage(Me)
            msg.alert("�û������ڣ�")
            Return
        ElseIf db.isUserInvalid(name) Then
            Dim msg As MyMessage
            msg = New MyMessage(Me)
            msg.alert("�û���ɾ����")
            Return
        ElseIf Not db.login(name, pwd) Then
            Dim msg As MyMessage
            msg = New MyMessage(Me)
            msg.alert("���벻��ȷ��")
            Return
        Else
            MyLog.log(name + " login.")
        End If

        Dim type = db.getUserType(name)
        If type = "commiter" Then
            Response.Redirect("commiter/Commiter.aspx?name=" + name)
        ElseIf type = "worker" Then
        ElseIf type = "admin" Then

        End If

    End Sub

End Class