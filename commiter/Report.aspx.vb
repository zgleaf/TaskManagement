Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing

Partial Public Class Report1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim name = Request.QueryString("name")
        Me.TxtUserName.Text = name

        If True Then
            Dim db As MyDB = New MyDB(name, "commiter")
            Dim info As String = db.getTaskInfo(name, "commiter")
            Me.TxtCommitTask.Text = info

            ChartCommitPie.Series.Clear()
            ChartCommitBar.Series.Clear()

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
                Dim yValues As Integer() = New Integer() {finished_num, delay_num, ongo_num}
                Dim xValues As String() = New String() {"已完成", "已延迟", "进行中"}
                series.Points.DataBindXY(xValues, yValues)
                ' Set series visual attributes
                series.ChartType = SeriesChartType.Pie
                series.ShadowOffset = 2
                series.BorderColor = Color.DarkGray
                ' series.CustomAttributes = "LabelStyle=Outside";
                ChartCommitPie.Width = 400
                ChartCommitPie.Height = 300
                ChartCommitPie.Series.Add(series)

                ChartCommitPie.DataBind()
            End If

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
                    ChartCommitBar.Series.Add(series)
                Next
            End If

            '设置坐标轴
            ChartCommitBar.ChartAreas(0).AxisX.LineColor = Color.Black
            ChartCommitBar.ChartAreas(0).AxisY.LineColor = Color.Black
            ChartCommitBar.ChartAreas(0).AxisX.LineWidth = 1.5
            ChartCommitBar.ChartAreas(0).AxisY.LineWidth = 1.5
            ChartCommitBar.ChartAreas(0).AxisY.Title = "Task"
            '设置网格线
            'ChartCommitBar.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Blue
            'ChartCommitBar.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Blue

            ChartCommitBar.Width = 600
            ChartCommitBar.Height = 400

            ChartCommitBar.DataBind()
        End If

        If True Then
            Dim db As MyDB = New MyDB(name, "responsible")
            Dim info As String = db.getTaskInfo(name, "responsible")
            Me.TxtReponseTask.Text = info

            ChartResponsePie.Series.Clear()
            ChartResponseBar.Series.Clear()

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
                Dim yValues As Integer() = New Integer() {finished_num, delay_num, ongo_num}
                Dim xValues As String() = New String() {"已完成", "已延迟", "进行中"}
                series.Points.DataBindXY(xValues, yValues)
                ' Set series visual attributes
                series.ChartType = SeriesChartType.Pie
                series.ShadowOffset = 2
                series.BorderColor = Color.DarkGray
                ' series.CustomAttributes = "LabelStyle=Outside";
                ChartResponsePie.Width = 400
                ChartResponsePie.Height = 300
                ChartResponsePie.Series.Add(series)

                ChartResponsePie.DataBind()
            End If

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
                    ChartResponseBar.Series.Add(series)
                Next
            End If

            '设置坐标轴
            ChartResponseBar.ChartAreas(0).AxisX.LineColor = Color.Black
            ChartResponseBar.ChartAreas(0).AxisY.LineColor = Color.Black
            ChartResponseBar.ChartAreas(0).AxisX.LineWidth = 1.5
            ChartResponseBar.ChartAreas(0).AxisY.LineWidth = 1.5
            ChartResponseBar.ChartAreas(0).AxisY.Title = "Task"
            '设置网格线
            'ChartResponseBar.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Blue
            'ChartResponseBar.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Blue

            ChartResponseBar.Width = 600
            ChartResponseBar.Height = 400

            ChartResponseBar.DataBind()
        End If
    End Sub

    Protected Sub LB_Reponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Reponse.Click
        Dim name = Me.TxtUserName.Text
        Response.Redirect("Responsible.aspx?name=" + name)
    End Sub

    Protected Sub LB_Commit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Commit.Click
        Dim name = Me.TxtUserName.Text
        Response.Redirect("Commiter.aspx?name=" + name)
    End Sub

    Protected Sub LB_Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Logout.Click
        Response.Redirect("..\login.aspx")
    End Sub
End Class