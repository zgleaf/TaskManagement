Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Public Class MyReport

    Public Function fillPie(ByRef pie As Chart, ByVal name As String, ByVal perm As String) As String

        Dim db As MyDB = New MyDB(name, perm)
        Dim info As String = ""

        pie.Series.Clear()

        Dim finished_num, delay_num, ongo_num As Integer
        If db.getAllTaskInfo(info, finished_num, delay_num, ongo_num) Then

            Dim series As Series = New Series("My series")
            ' Set series and legend tooltips
            series.ToolTip = "#VALX: #VALY"
            ' series.LegendToolTip = "#VALX"
            series.PostBackValue = "#INDEX"
            series.LegendPostBackValue = "#INDEX"
            series.Label = "#VALX: #VALY \n #PERCENT{P1}"

            ' Populate series data
            Dim yValues As Integer() = New Integer() {finished_num, ongo_num, delay_num}
            Dim xValues As String() = New String() {"已完成", "进行中", "已延迟"}
            series.Points.DataBindXY(xValues, yValues)
            ' Set series visual attributes
            series.ChartType = SeriesChartType.Pie
            series.ShadowOffset = 2
            series.BorderColor = Color.DarkGray
            ' series.CustomAttributes = "LabelStyle=Outside";
            pie.Width = 400
            pie.Height = 300
            pie.Series.Add(series)

            pie.DataBind()
        End If

        Return info

    End Function

    Public Function GetPieStatus(ByVal val As Integer) As String
        If val = 0 Then
            Return New String("finished")
        ElseIf val = 1 Then
            Return New String("on-going")
        ElseIf val = 2 Then
            Return New String("delay")
        Else
            Return New String("closed")
        End If
    End Function

    Public Sub fillBar(ByRef bar As Chart, ByVal name As String, ByVal perm As String)

        Dim db As MyDB = New MyDB(name, perm)

        bar.Series.Clear()

        Dim tasktype As String() = {"Kaizen", "5s", "EHS", "QC", "DAM"}
        Dim taskstatus As String() = {"已完成", "已延迟", "进行中"}
        Dim taskcolor As Color() = {Color.Blue, Color.Green, Color.LightGreen}
        Dim tasknum As Integer(,) = {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}, {0, 0, 0}, {0, 0, 0}}

        If db.getAllTaskInfo(tasktype, tasknum) Then

            For st As Integer = 0 To 2
                Dim series As Series = New Series(taskstatus(st))
                series.ChartType = SeriesChartType.Column
                series.Color = taskcolor(st)
                series.BorderWidth = 2
                series.ShadowOffset = 1
                series.IsVisibleInLegend = True
                series.IsValueShownAsLabel = True
                series.MarkerStyle = MarkerStyle.Diamond
                series.MarkerSize = 8
                For i As Integer = 0 To tasktype.Length - 1
                    series.Points.AddXY(tasktype(i), tasknum(i, st))
                Next
                series.ToolTip = "#SERIESNAME: #VALY"
                series.PostBackValue = "#SERIESNAME:#INDEX"
                series.LegendPostBackValue = "#INDEX"
                bar.Series.Add(series)
            Next
        End If

        '设置坐标轴
        bar.ChartAreas(0).AxisX.LineColor = Color.Black
        bar.ChartAreas(0).AxisY.LineColor = Color.Black
        bar.ChartAreas(0).AxisX.LineWidth = 1.5
        bar.ChartAreas(0).AxisY.LineWidth = 1.5
        bar.ChartAreas(0).AxisY.Title = "Task"
        '设置网格线
        'bar.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Blue
        'bar.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Blue

        bar.Width = 600
        bar.Height = 400

        bar.DataBind()

    End Sub

    Public Function GetBarStatus(ByVal val As String, ByRef type As String) As String
        Dim tasktype As String() = {"Kaizen", "5s", "EHS", "QC", "DAM"}
        Dim taskstatus As String() = {"已完成", "已延迟", "进行中"}
        Dim status As String() = {"finished", "delay", "on-going"}
        Dim i As Integer = 0
        For Each st As String In taskstatus
            Dim j As Integer = 0
            For Each tp As String In tasktype
                If val = st + ":" + j.ToString() Then
                    type = tp
                    Return status(i)
                End If
                j += 1
            Next
            i += 1
        Next
        Return "Closed"
    End Function
End Class
