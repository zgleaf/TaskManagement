Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim db As MyDB = New MyDB
        Dim finished_num, delay_num, ongo_num As Integer
        Dim info As String = ""

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
            ChartPie.Series.Clear()
            ChartPie.Series.Add(series)

            ChartPie.DataBind()
        End If
    End Sub


End Class