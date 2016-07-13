
Partial Class FrmGenerarResolucionAdjudicacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Master.ControlMenu.Visible = False

        Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
        Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False

        'Me.UcOfertasPorRenglonProcesoCompra1.CantidadAdjudicadaEnFirmeVisible = False

    End Sub

End Class

