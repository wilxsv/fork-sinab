
Partial Class FrmReporteVencidosAlmacenTodos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerResponsableDistribucion = True
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.VerGrupo = True
            Me.ucFiltrosReportesAlmacen1.VerAlmacen = True
            Me.ucFiltrosReportesAlmacen1.b = 0
            Me.ucFiltrosReportesAlmacen1.VerEstablecimientoTodos = True
            ucFiltrosReportesAlmacen1.UrlRegresar = ResolveUrl("~/Almacen/FrmReportesAlmacenesGerencial.aspx")
            Me.ucFiltrosReportesAlmacen1.IniciarDatos()


        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        With ucFiltrosReportesAlmacen1
            Dim cad = String.Format("/Reportes/FrmRptVencidosAlmacentodos.aspx?idA={0}&idS={1}&idG={2}&idFF={3}&idGF={4}&idRD={5}", .IDALMACEN, .IDSUMINISTRO, .IDGRUPO, .IDFUENTEFINANCIAMIENTO, .IDFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With

    End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Response.Redirect("~/Almacen/FrmReportesAlmacenesGerencial.aspx")
    'End Sub
End Class
