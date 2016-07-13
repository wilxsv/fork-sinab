
Imports System.Linq
Imports SINAB_Entidades.Helpers

Partial Class FrmReporteContabilidad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen1.VerPeriodo = True
            Me.ucFiltrosReportesAlmacen1.VerGrupoFuenteFinanciamiento = True
            'Me.ucFiltrosReportesAlmacen1.VerFuenteFinanciamiento = True
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.a = 1
            Me.ucFiltrosReportesAlmacen1.b = 1
            Me.ucFiltrosReportesAlmacen1.VerEspecificoGasto = True
            Me.ucFiltrosReportesAlmacen1.TipoSuministroTodos = True
            ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        With ucFiltrosReportesAlmacen1
            Dim cad = String.Format("/Reportes/FrmRptContabilidadAlmacen.aspx?idA={0}&m={1}&a={2}&idGFF={3}&idFF=0&idS={4}&&idEG={5}", Membresia.ObtenerUsuario().Almacen.IDALMACEN, .MESPERIODO, .ANIOPERIODO, .IDGRUPOFUENTEFINANCIAMIENTO, .IDSUMINISTRO, .IDESPECIFICOGASTO)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With
    End Sub

End Class
