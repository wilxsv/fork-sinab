Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Tipos

Partial Class FrmRptCuadroDistribucion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportpath As String = Server.MapPath("RptCuadroDistribucion.rpt")
        Reporte.Load(reportpath)

        Dim idestablecimiento As Integer = CType(Request.QueryString("idE"), Integer)
        Dim idAlmacen As Integer = CType(Request.QueryString("idA"), Integer)
        Dim idprocesocompra As Integer = CType(Request.QueryString("idPC"), Integer)

        'Dim cPD As New cPROGRAMADISTRIBUCION
        'Dim ds As Data.DataSet
        'ds = cPD.CuadroDistribucion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDALMACEN)
        Dim ds As List(Of BaseEntregaContratos)
        If Membresia.EsUsuarioRol("Digitador Almacén") Or Membresia.EsUsuarioRol("Guardalmacén") Or Membresia.EsUsuarioRol("Asesor Suministros Medicos") Or Membresia.EsUsuarioRol("Medico Asesor Suministros") Or Membresia.EsUsuarioRol("ConsultaSoloAlmacen") Then
            ds = SINAB_Entidades.Helpers.UACIHelpers.AlmacenesEntregaContrato.ObtenerTodos(idestablecimiento, idAlmacen, idprocesocompra)
        Else
            ds = SINAB_Entidades.Helpers.UACIHelpers.AlmacenesEntregaContrato.ObtenerTodos(idestablecimiento, idprocesocompra)
        End If


        Reporte.SetDataSource(ds)
        Me.crvPrincipal.ReportSource = Reporte

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
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
