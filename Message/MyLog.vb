Public Class MyLog

    Public Shared Function log(ByRef info As String)

        Dim insert = "INSERT INTO [Log] (usr, date, info, type) VALUES ('" + "logger" + "','" + Now.ToLocalTime() + "','" + info + "','log');"

        Dim connect As New SqlClient.SqlConnection(My.Resources.MyConnectString.ToString())
        connect.Open()

        Dim cmd As New SqlClient.SqlCommand(insert, connect)
        cmd.ExecuteNonQuery()

        connect.Close()

        Return 0
    End Function

End Class
