
Partial Class FrmReporteExistenciaAlmacenesHospital
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = False
            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = False
            Me.ucFiltrosReportesAlmacen1.VerResponsableDistribucion = False
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.VerGrupo = True
            Me.ucFiltrosReportesAlmacen1.b = 0
            ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        Dim cad = String.Format("/Reportes/FrmRptExistenciasAlmacenesHospitales.aspx?idA={0}&idS={1}&idG={2}", Session("IdAlmacen"), ucFiltrosReportesAlmacen1.IDSUMINISTRO, ucFiltrosReportesAlmacen1.IDGRUPO)
        SINAB_Utils.Utils.MostrarVentana(cad)
    End Sub

End Class
