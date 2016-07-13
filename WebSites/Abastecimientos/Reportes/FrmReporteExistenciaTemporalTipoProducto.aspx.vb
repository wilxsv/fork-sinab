
Partial Class FrmReporteExistenciaTemporalTipoProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen1.VerAlmacenOrigen = True
            Me.ucFiltrosReportesAlmacen1.VerEstablecimiento = True
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.VerGrupo = True
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        With ucFiltrosReportesAlmacen1
            Dim cad = String.Format("/Reportes/FrmRptExistenciaTemporalPorTipoProducto.aspx?idA={0}&idS={1}&idG={2}&idAO={3}", Session("IdAlmacen"), .IDSUMINISTRO, .IDGRUPO, .IDALMACENORIGEN)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With

    End Sub

End Class
