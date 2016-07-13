﻿
Partial Class FrmReporteExistenciaHistoricaPorTipoProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen1.VerFechaHasta = True
            Me.ucFiltrosReportesAlmacen1.FechasRequeridas = True
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.VerGrupo = True
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.b = 1
            Me.ucFiltrosReportesAlmacen1.VerEspecificoGasto = True
            Me.ucFiltrosReportesAlmacen1.TipoSuministroTodos = True
            Me.ucFiltrosReportesAlmacen1.IniciarDatos()

        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar

        With ucFiltrosReportesAlmacen1
            Dim cad = String.Format("/Reportes/FrmRptExistenciaHistoricaPorTipoProductoAlmacen.aspx?idA={0}&idS={1}&idG={2}&idFF={3}&idGF={4}&idRD={5}&fh={6}&fos={7}&idEG={8}", Session("IdAlmacen"), .IDSUMINISTRO, .IDGRUPO, .IDFUENTEFINANCIAMIENTO, .IDGRUPOFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, .FECHAHASTA, .FOS, .IDESPECIFICOGASTO)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With
        
    End Sub

End Class