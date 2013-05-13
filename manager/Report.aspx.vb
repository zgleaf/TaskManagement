Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim db As MyDB = New MyDB
        Dim finished_num, delay_num, ongo_num As Integer
        Dim info As String = ""

        ChartPie.Series.Clear()

        If db.getAllTaskInfo(info, finished_num, delay_num, ongo_num) Then

            Me.TxtTaskInfo.Text = info

            Dim series As Series = New Series("My series")
            ' Set series and legend tooltips
            series.ToolTip = "#VALX: #VALY"
            ' series.LegendToolTip = "#VALX"
            series.PostBackValue = "#INDEX"
            series.LegendPostBackValue = "#INDEX"
            series.Label = "#VALX: #VALY \n #PERCENT{P1}"

            ' Populate series data
            Dim yValues As Integer() = New Integer() {finished_num, delay_num, ongo_num}
            Dim xValues As String() = New String() {"已完成", "已延迟", "进行中"}
            series.Points.DataBindXY(xValues, yValues)
            ' Set series visual attributes
            series.ChartType = SeriesChartType.Pie
            series.ShadowOffset = 2
            series.BorderColor = Color.DarkGray
            ' series.CustomAttributes = "LabelStyle=Outside";
            ChartPie.Width = 400
            ChartPie.Height = 300
            ChartPie.Series.Add(series)

            ChartPie.DataBind()
        End If


        ChartType.Series.Clear()

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
                series.ToolTip = "#VALX: #VALY"
                series.PostBackValue = "#INDEX"
                series.LegendPostBackValue = "#INDEX"
                ChartType.Series.Add(series)
            Next
        End If

        '设置坐标轴
        ChartType.ChartAreas(0).AxisX.LineColor = Color.Black
        ChartType.ChartAreas(0).AxisY.LineColor = Color.Black
        ChartType.ChartAreas(0).AxisX.LineWidth = 1.5
        ChartType.ChartAreas(0).AxisY.LineWidth = 1.5
        ChartType.ChartAreas(0).AxisY.Title = "Task"
        '设置网格线
        'ChartType.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Blue
        'ChartType.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Blue

        ChartType.Width = 600
        ChartType.Height = 400

        ChartType.DataBind()
    End Sub


End Class