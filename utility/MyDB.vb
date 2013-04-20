Public Class MyDB

    Public Shared ConnectString As String = My.Resources.MyConnectString.ToString()
    Private connect As SqlClient.SqlConnection

    Sub New()
        Try
            connect = New SqlClient.SqlConnection(ConnectString)
            connect.Open()

        Catch ex As Exception
            MyLog.err(ex.ToString)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            If Not connect.State = ConnectionState.Open Then
                connect.Close()
            End If

        Catch ex As Exception
            MyLog.err(ex.ToString)
        End Try
    End Sub

    Public Function isUser(ByVal name As String) As Boolean

        Dim myselect = "SELECT * FROM [User] WHERE name='" + name + "';"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myselect, connect)
            Dim usr As SqlClient.SqlDataReader = cmd.ExecuteReader()
            Dim usr_count = usr.HasRows()
            usr.Close()

            Return usr_count

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function isUserInvalid(ByVal name As String) As Boolean

        Dim myselect = "SELECT * FROM [User] WHERE name='" + name + "' AND invalid = 1;"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myselect, connect)
            Dim usr As SqlClient.SqlDataReader = cmd.ExecuteReader()
            Dim usr_count = usr.HasRows()
            usr.Close()

            Return usr_count

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function login(ByVal name As String, ByVal pwd As String) As Boolean

        Dim myselect = "SELECT * FROM [User] WHERE name='" + name + "' AND pwd='" + pwd + "' AND invalid != 1;"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myselect, connect)
            Dim usr As SqlClient.SqlDataReader = cmd.ExecuteReader()
            Dim usr_count = usr.HasRows()
            usr.Close()

            Return usr_count

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function addUser(ByVal name As String, ByVal pwd As String, ByVal perm As Integer) As Boolean

        Dim myinsert = "INSERT INTO [User] (name, pwd, permission) VALUES ('" + name + "','" + pwd + "'," + perm.ToString() + ");"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myinsert, connect)
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function updateUserPwd(ByVal name As String, ByVal pwd As String) As Boolean

        Dim myupdate = "UPDATE [User] SET pwd='" + pwd + "' WHERE name='" + name + "';"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myupdate, connect)
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function updateUserPerm(ByVal name As String, ByVal perm As Integer) As Boolean

        Dim myupdate = "UPDATE [User] SET permission='" + perm.ToString() + "' WHERE name='" + name + "';"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myupdate, connect)
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function setUserValid(ByVal name As String, ByVal valid As Boolean) As Boolean
        Dim invalid = "1"
        If valid Then
            invalid = "0"
        End If

        Dim myupdate = "UPDATE [User] SET invalid=" + invalid + " WHERE name='" + name + "';"

        'TODO: you cann't invalid yourself

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myupdate, connect)
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function getUserType(ByVal name As String) As String

        Dim myselect = "SELECT permission FROM [User] WHERE name='" + name + "' AND invalid = 0;"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return "invalid"
            End If

            Dim cmd As New SqlClient.SqlCommand(myselect, connect)
            Dim usr As SqlClient.SqlDataReader = cmd.ExecuteReader()
            Dim usr_count = usr.HasRows()

            If Not usr_count Then
                Return "invalid"
            End If

            Dim user_type = "invalid"
            While usr.Read
                Dim type = usr.GetValue(0)
                If type = 0 Then
                    user_type = "admin"
                ElseIf type = 1 Then
                    user_type = "commiter"
                ElseIf type = 2 Then
                    user_type = "worker"
                End If
            End While

            usr.Close()

            Return user_type

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return "invalid"

    End Function

    Public Function getTaskInfo(ByVal name As String, ByVal perm As String) As String

        Dim myselect = "SELECT type,state,plan_finish_date,work_state FROM [Task] WHERE " + perm + "='" + name + "';"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return "no data"
            End If

            Dim cmd As New SqlClient.SqlCommand(myselect, connect)
            Dim task As SqlClient.SqlDataReader = cmd.ExecuteReader()
            Dim task_count = task.HasRows()

            If Not task_count Then
                Return "no data"
            End If

            Dim task_num, task_kaison, task_5s, task_ehs, task_qc, task_dam As Integer
            Dim task_close, task_normal, task_delay As Integer
            While task.Read
                Dim type = task.GetString(0)
                If type = "Kaizen" Then
                    task_kaison += 1
                ElseIf type = "5s" Then
                    task_5s += 1
                ElseIf type = "EHS" Then
                    task_ehs += 1
                ElseIf type = "QC" Then
                    task_qc += 1
                ElseIf type = "DAM" Then
                    task_dam += 1
                End If

                Dim state = task.GetString(1)
                If state = "close" Then
                    task_close += 1
                Else
                    Dim plan_date As DateTime = task.GetDateTime(2)
                    Dim wk_state = task.GetInt32(3)
                    If plan_date >= Now Then
                        task_normal += 1
                    Else
                        If wk_state = 100 Then
                            task_normal += 1
                        Else
                            task_delay += 1
                        End If
                    End If
                End If

                task_num += 1
            End While

            task.Close()

            Dim res = "All " + task_num.ToString() + ", "
            res += "normal " + task_normal.ToString() + ","
            res += "delay " + task_delay.ToString() + ","
            res += "close " + task_close.ToString() + ","
            res += "Kaison " + task_kaison.ToString() + ","
            res += "5s " + task_5s.ToString() + ","
            res += "EHS " + task_ehs.ToString() + ","
            res += "QC " + task_qc.ToString() + ","
            res += "DAM " + task_dam.ToString()

            Return res
        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return "no data"

    End Function

    Public Function getTaskState(ByVal id As Integer, ByRef state As Integer, ByRef descript As String) As Boolean

        Dim myselect = "SELECT work_state, description FROM [Task] WHERE id=" + id.ToString() + ";"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myselect, connect)
            Dim task As SqlClient.SqlDataReader = cmd.ExecuteReader()
            Dim task_count = task.HasRows()

            If Not task_count Then
                Return False
            End If

            While task.Read
                state = task.GetInt32(0)
                descript = task.GetString(1)
                Return True
            End While

            task.Close()

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function setTaskState(ByVal id As Integer, ByVal worker As String, ByVal state As Integer, ByVal descript As String) As Boolean

        Dim myupdate = "UPDATE [Task] SET work_state=" + state.ToString() + ", description=@descript WHERE id=" + id.ToString() + " AND worker='" + worker + "';"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myupdate, connect)
            cmd.Parameters.AddWithValue("@descript", descript)
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function

    Public Function addTask(ByVal info As String, ByVal task As String, ByVal descript As String) As Boolean

        Dim myinsert = "INSERT INTO [Task] (" + info + ") VALUES (" + task + ");"

        Try
            If Not connect.State = ConnectionState.Open Then
                Return False
            End If

            Dim cmd As New SqlClient.SqlCommand(myinsert, connect)
            cmd.Parameters.AddWithValue("@descript", descript)
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MyLog.err(ex.ToString)

        End Try

        Return False

    End Function
End Class
