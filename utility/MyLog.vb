Public Class MyLog

    Private Shared user_name As String = "logger"

    Public Shared Function log(ByRef info As String)

        Dim insert = "INSERT INTO [Log] (usr, date, info, type) VALUES ('" + user_name + "','" + Now.ToLocalTime() + "','" + info + "','log');"

        Return writedb(insert)

    End Function

    Public Shared Function err(ByRef info As String)

        Dim insert = "INSERT INTO [Log] (usr, date, info, type) VALUES ('" + user_name + "','" + Now.ToLocalTime() + "','" + info + "','err');"

        Return writedb(insert)

    End Function

    Public Shared Function warn(ByRef info As String)

        Dim insert = "INSERT INTO [Log] (usr, date, info, type) VALUES ('" + user_name + "','" + Now.ToLocalTime() + "','" + info + "','warn');"

        Return writedb(insert)

    End Function


    Public Shared Function writedb(ByRef insert As String)

        Dim connect As New SqlClient.SqlConnection(My.Resources.MyConnectString.ToString())
        connect.Open()

        Dim cmd As New SqlClient.SqlCommand(insert, connect)
        cmd.ExecuteNonQuery()

        connect.Close()

        Return 0

    End Function
End Class
