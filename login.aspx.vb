Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click

        Dim name = Me.TbName.Text()
        Dim pwd = Me.TbPassword.Text
        Dim myselect = "SELECT * FROM [User] WHERE name='" + name + "';"
        Dim myselect2 = "SELECT * FROM [User] WHERE name='" + name + "' AND pwd='" + pwd + "';"

        Try
            Dim connect As New SqlClient.SqlConnection(My.Resources.MyConnectString.ToString())
            connect.Open()

            Dim cmd As New SqlClient.SqlCommand(myselect, connect)
            Dim usr As SqlClient.SqlDataReader = cmd.ExecuteReader()
            Dim usr_count = usr.HasRows()
            usr.Close()

            Dim usr_login As Boolean = False
            If usr_count Then
                cmd.CommandText = myselect2
                usr = cmd.ExecuteReader()
                usr_login = usr.HasRows()
                usr.Close()
            End If
            'Me.Log.Text = myselect + " ||  " + usr_count.ToString + " || " + myselect2 + " || " + usr_login.ToString

            connect.Close()

            If usr_count <> True Then
                Dim msg As MyMessage
                msg = New MyMessage(Me)
                msg.alert("用户不存在！")
            ElseIf usr_login <> True Then
                Dim msg As MyMessage
                msg = New MyMessage(Me)
                msg.alert("密码不正确！")
            Else
                MyLog.log(name + "login.")
            End If

        Catch ex As Exception
            TxtLog.Text = ex.ToString()

        End Try

    End Sub

End Class