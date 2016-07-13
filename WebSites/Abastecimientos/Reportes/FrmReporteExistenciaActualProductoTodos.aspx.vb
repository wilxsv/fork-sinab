
Partial Class FrmReporteExistenciaActualTipoProductoTodos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerResponsableDistribucion = True
            Me.ucFiltrosReportesAlmacen1.VerProducto = True

            Me.ucFiltrosReportesAlmacen1.VerAlmacen = True
            Me.ucFiltrosReportesAlmacen1.VerEstablecimientoTodos = True
            ucFiltrosReportesAlmacen1.UrlRegresar = ResolveUrl("~/Almacen/FrmReportesAlmacenesGerencial.aspx")
            ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        With ucFiltrosReportesAlmacen1
            Dim cad = String.Format("/Reportes/FrmRptExistenciasPorProductoAlmacenTodos.aspx?idA={0}&idP={1}&C={2}&idFF={3}&idGF={4}&idRD={5}", .IDALMACEN, .IDPRODUCTO, .PRODUCTO, .IDFUENTEFINANCIAMIENTO, .IDGRUPOFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With
    End Sub

End Class
