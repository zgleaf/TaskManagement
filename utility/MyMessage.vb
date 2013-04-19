Public Class MyMessage
    Private p As System.Web.UI.Page

    Public Sub New(ByVal Page As System.Web.UI.Page)
        p = Page
    End Sub

    Public Sub alert(ByVal message As String)
        Dim script As String = "<script> alert('" + message + "')</script>"
        p.Response.Write(script)
    End Sub

End Class
