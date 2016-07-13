
Partial Class FrmReporteDespachosGenerales
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen1.VerFechaDesde = True
            Me.ucFiltrosReportesAlmacen1.VerFechaHasta = True
            Me.ucFiltrosReportesAlmacen1.FechasRequeridas = True
            Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerResponsableDistribucion = True
            Me.ucFiltrosReportesAlmacen1.VerEstablecimiento = True
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.VerGrupo = True
            Me.ucFiltrosReportesAlmacen1.VerAgruparPor = True
            Me.ucFiltrosReportesAlmacen1.b = 1
            Me.ucFiltrosReportesAlmacen1.VerEspecificoGasto = True
            Me.ucFiltrosReportesAlmacen1.TipoSuministroTodos = True
            Me.ucFiltrosReportesAlmacen1.VerTransferencia = True
            Me.ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        With ucFiltrosReportesAlmacen1


            Dim cad = String.Format("/Reportes/FrmRptDespachosGenerales.aspx?idA={0}&fd={1}&fh={2}&idFF={3}&idGF={4}&idRD={5}&idS={6}&idG={7}&Ag={8}&fos={9}&idED={10}&idEG={11}&transf={12}", Session.Item("IdAlmacen"), .FECHADESDE, .FECHAHASTA, .IDFUENTEFINANCIAMIENTO, .IDGRUPOFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, .IDSUMINISTRO, .IDGRUPO, .AgruparPor, .FOS, .IDESTABLECIMIENTO, .IDESPECIFICOGASTO, .Transf)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With

    End Sub

End Class
