'INGRESO DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'Reporte de solicitudes de compra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Utils


Partial Class Reportes_FrmSolicitudCompra
    Inherits System.Web.UI.Page

    'declaracion e incializacion
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'cargar reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("rptSolicitudCompra.rpt") 'nombre reporte
        'Dim FuenteSolicitud As String = ""
        Dim lId As Int64
        lId = CType(Request.QueryString("Id"), Long) 'Session.Item("idDocRep")
        Dim lIde As Int64
        lIde = CType(Request.QueryString("ide"), Long) 'Session.Item("idDocRep")

        Reporte.Load(reportPath) 'carga

        Dim res = EstablecimientoHelpers.Solicitudes.ObtenerReporte(lId, lIde)
        Dim suministros = String.Join(", ", (From r In res Select r.Suministro).Distinct().ToArray())

        Reporte.SetDataSource(res)
        Dim res2 = EstablecimientoHelpers.AdministradoresContrato.ObtenerTodos(lId, Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO)
        Reporte.Subreports("AdminsContratos.rpt").SetDataSource(res2)
        Me.crvPrincipal.ReportSource = Reporte

        Reporte.SetParameterValue("suministros", suministros)

        Me.crvPrincipal.DisplayGroupTree = False
        Me.crvPrincipal.DisplayToolbar = True
        Me.crvPrincipal.EnableDrillDown = False
        Me.crvPrincipal.HasCrystalLogo = False
        Me.crvPrincipal.HasDrillUpButton = False
        Me.crvPrincipal.HasGotoPageButton = True
        Me.crvPrincipal.HasPageNavigationButtons = True
        Me.crvPrincipal.HasPrintButton = True
        Me.crvPrincipal.HasRefreshButton = False
        Me.crvPrincipal.HasSearchButton = False
        Me.crvPrincipal.HasToggleGroupTreeButton = False
        Me.crvPrincipal.HasViewList = False

        Me.crvPrincipal.HasZoomFactorList = False

        Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'al incializar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
