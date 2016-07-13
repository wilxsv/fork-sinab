
Partial Class wfDetaMantCATALOGOPRODUCTOS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim bPermiteEditar As Boolean = clsObtenerDatos.OpcionPermiteEditar(Session.Item("IdRol"), Request.AppRelativeCurrentExecutionFilePath)

            Me.ucVistaDetalleCATALOGOPRODUCTOS1.Enabled = bPermiteEditar

            Dim lId As Int32 = Request.QueryString("id")
            Me.ucVistaDetalleCATALOGOPRODUCTOS1.IDPRODUCTO = lId
        End If
    End Sub

    Private Sub ucVistaDetalleCATALOGOPRODUCTOS1_ErrorEvent(ByVal errorMessage As String) Handles ucVistaDetalleCATALOGOPRODUCTOS1.ErrorEvent
        MsgBox1.ShowAlert(errorMessage, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

End Class
