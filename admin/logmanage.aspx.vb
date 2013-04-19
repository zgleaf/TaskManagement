Partial Public Class logmanager
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click

        Me.TaskMgr.UpdateCommand = "DELETE FROM [Log];"
        Me.TaskMgr.Update()
        Me.LogView.DataBind()

        Response.Redirect(Request.RawUrl.ToString)

    End Sub
End Class