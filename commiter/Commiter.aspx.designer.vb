'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.5466
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



'''<summary>
'''Commiter class.
'''</summary>
'''<remarks>
'''Auto-generated class.
'''</remarks>
Partial Public Class Commiter

    '''<summary>
    '''form1 control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents form1 As Global.System.Web.UI.HtmlControls.HtmlForm

    '''<summary>
    '''LB_Report control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents LB_Report As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''LB_Reponse control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents LB_Reponse As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''LB_All control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents LB_All As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''LB_Logout control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents LB_Logout As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''TxtUserName control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents TxtUserName As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''HL_tasknum control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents HL_tasknum As Global.System.Web.UI.WebControls.HyperLink

    '''<summary>
    '''TB_descript control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents TB_descript As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''DDL_Type control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents DDL_Type As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''DDL_respon control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents DDL_respon As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''SqlDataSourceTask control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents SqlDataSourceTask As Global.System.Web.UI.WebControls.SqlDataSource

    '''<summary>
    '''SqlDataSourceWorker control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents SqlDataSourceWorker As Global.System.Web.UI.WebControls.SqlDataSource

    '''<summary>
    '''TB_duedate control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents TB_duedate As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''DDL_duehour control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents DDL_duehour As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''DDL_duemin control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents DDL_duemin As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''TB_comment control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents TB_comment As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Btn_Commit control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents Btn_Commit As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''CK_Closed control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents CK_Closed As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''CK_Finished control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents CK_Finished As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''CK_Delay control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents CK_Delay As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''CK_On_Going control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents CK_On_Going As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''GridViewMyTask control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents GridViewMyTask As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''SqlDataSourceMyTask control.
    '''</summary>
    '''<remarks>
    '''Auto-generated field.
    '''To modify move field declaration from designer file to code-behind file.
    '''</remarks>
    Protected WithEvents SqlDataSourceMyTask As Global.System.Web.UI.WebControls.SqlDataSource
End Class
