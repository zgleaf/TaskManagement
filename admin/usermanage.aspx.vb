Public Partial Class usermanage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Add.Click

        Dim name = Me.TbName.Text
        Dim pwd = Me.TbPassword.Text
        Dim perm = Me.ListPermission.Text

        If name = "" Then
            Me.TxtLog.Text = "no name."
            Return
        End If

        Dim db As New MyDB
        If db.isUser(name) Then
            Me.TxtLog.Text = "user is already exist."
            Return
        End If

        If Not db.addUser(name, pwd, perm) Then
            Me.TxtLog.Text = "user add failed."
            Return
        End If

        MyLog.log("add user [" + name + "].")
        Response.Redirect(Request.RawUrl.ToString)

    End Sub

    Protected Sub Btn_Valid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Valid.Click

        Dim name = Me.TbName.Text

        If name = "" Then
            Me.TxtLog.Text = "no name."
            Return
        End If

        Dim db As New MyDB
        If Not db.isUser(name) Then
            Me.TxtLog.Text = "user is not exist."
            Return
        End If

        If Not db.setUserValid(name, True) Then
            Me.TxtLog.Text = "user rm failed."
            Return
        End If

        MyLog.log("valid user [" + name + "].")
        Response.Redirect(Request.RawUrl.ToString)

    End Sub

    Protected Sub Btn_Invalid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Invalid.Click

        Dim name = Me.TbName.Text

        If name = "" Then
            Me.TxtLog.Text = "no name."
            Return
        End If

        Dim db As New MyDB
        If Not db.isUser(name) Then
            Me.TxtLog.Text = "user is not exist."
            Return
        End If

        If Not db.setUserValid(name, False) Then
            Me.TxtLog.Text = "user rm failed."
            Return
        End If

        MyLog.log("invalid user [" + name + "].")
        Response.Redirect(Request.RawUrl.ToString)

    End Sub

    Protected Sub Btn_Pwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pwd.Click

        Dim name = Me.TbName.Text
        Dim pwd = Me.TbPassword.Text

        If name = "" Then
            Me.TxtLog.Text = "no name."
            Return
        End If

        Dim db As New MyDB
        If Not db.isUser(name) Then
            Me.TxtLog.Text = "user is not exist."
            Return
        End If

        If Not db.updateUserPwd(name, pwd) Then
            Me.TxtLog.Text = "renew password failed."
            Return
        End If

        MyLog.log("change password user [" + name + "].")
        Response.Redirect(Request.RawUrl.ToString)

    End Sub

    Protected Sub Btn_Perm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Perm.Click

        Dim name = Me.TbName.Text
        Dim perm = Me.ListPermission.Text

        If name = "" Then
            Me.TxtLog.Text = "no name."
            Return
        End If

        Dim db As New MyDB
        If Not db.isUser(name) Then
            Me.TxtLog.Text = "user is not exist."
            Return
        End If

        If Not db.updateUserPerm(name, perm) Then
            Me.TxtLog.Text = "renew permission failed."
            Return
        End If

        MyLog.log("change permission [" + name + "].")
        Response.Redirect(Request.RawUrl.ToString)

    End Sub

End Class