
Imports System.Linq
Imports SINAB_Entidades.Helpers

Partial Class FrmReporteMovimientosKardex
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen1.VerFechaDesde = True
            Me.ucFiltrosReportesAlmacen1.VerFechaHasta = True
            Me.ucFiltrosReportesAlmacen1.FechasRequeridas = True
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerResponsableDistribucion = True
            Me.ucFiltrosReportesAlmacen1.VerProducto = True
            Me.ucFiltrosReportesAlmacen1.b = 0
            ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        Dim usr = Membresia.ObtenerUsuario()
        Dim cad = String.Format("/Reportes/FrmRptMovimientosAlmacen.aspx?idA={0}&idP={1}&C={2}&idFF={3}&idGF={4}&idRD={5}&fd={6},&fh={7}", usr.Almacen.IDALMACEN, ucFiltrosReportesAlmacen1.IDPRODUCTO, ucFiltrosReportesAlmacen1.PRODUCTO, ucFiltrosReportesAlmacen1.IDFUENTEFINANCIAMIENTO, ucFiltrosReportesAlmacen1.IDGRUPOFUENTEFINANCIAMIENTO, ucFiltrosReportesAlmacen1.IDRESPONSABLEDISTRIBUCION, ucFiltrosReportesAlmacen1.FECHADESDE, ucFiltrosReportesAlmacen1.FECHAHASTA)
        SINAB_Utils.Utils.MostrarVentana(cad)
    End Sub

End Class
