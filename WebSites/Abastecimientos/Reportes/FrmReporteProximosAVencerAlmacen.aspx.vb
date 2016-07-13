
Partial Class FrmReporteProximosAVencerAlmacen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen2.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen2.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen2.VerGrupoFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen2.VerResponsableDistribucion = True
            Me.ucFiltrosReportesAlmacen2.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen2.VerGrupo = True
            Me.ucFiltrosReportesAlmacen2.VerPrograma = True
            Me.ucFiltrosReportesAlmacen2.VerFechaHasta = True

            Dim d As New Date(Now.Year, Now.Month, 1)

            Me.ucFiltrosReportesAlmacen2.SetFechaHasta = d.AddMonths(6)
            Me.ucFiltrosReportesAlmacen2.b = 0

        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen2.Consultar
        With ucFiltrosReportesAlmacen2
            Dim cad = String.Format("/Reportes/FrmRptProximosAVencerAlmacen.aspx?idA={0}&idS={1}&idG={2}&idFF={3}&idGF={4}&idRD={5}&FH={6}&idPR={7}", Session("IdAlmacen"), .IDSUMINISTRO, .IDGRUPO, .IDFUENTEFINANCIAMIENTO, .IDGRUPOFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, .FECHAHASTA, .IDPROGRAMA)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With
        
    End Sub

End Class
