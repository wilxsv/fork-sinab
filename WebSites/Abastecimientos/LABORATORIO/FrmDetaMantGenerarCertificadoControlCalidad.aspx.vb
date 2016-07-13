
Partial Class FrmDetaMantGenerarCertificadoControlCalidad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Master.ControlMenu.Visible = False

        If Not Page.IsPostBack Then
            Dim lId As String = Request.QueryString("id")
            Me.ucVistaDetalleRegistrarInspeccionMuestras1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            Me.ucVistaDetalleRegistrarInspeccionMuestras1.IDINFORME = lId
        End If

    End Sub

    Protected Sub ucVistaDetalleRegistrarInspeccionMuestras1_Guardar(ByVal sError As String) Handles ucVistaDetalleRegistrarInspeccionMuestras1.Guardar
        If sError <> "" Then
            Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
        Response.Redirect("~/LABORATORIO/FrmMantGenerarCertificadoControlCalidad.aspx")
    End Sub

    Protected Sub ucVistaDetalleRegistrarInspeccionMuestras1_Cancelar() Handles ucVistaDetalleRegistrarInspeccionMuestras1.Cancelar
        Response.Redirect("~/LABORATORIO/FrmMantGenerarCertificadoControlCalidad.aspx")
    End Sub

    Private Sub ucVistaDetalleRegistrarInspeccionMuestras1_ErrorEvent(ByVal errorMessage As String) Handles ucVistaDetalleRegistrarInspeccionMuestras1.ErrorEvent
        Me.MsgBox1.ShowAlert(errorMessage, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
