Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports CrystalDecisions.Shared.Json
Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Tipos

Partial Class FrmRptExistenciasPorTipoProductoAlmacenTodos
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String
        reportPath = Server.MapPath("~/Reportes/RptExistenciasActualesPorTipoProductoAlmacenEspecificosGasto.rpt")

        Reporte.Load(reportPath)

        Dim IDALMACEN As Integer
        Dim IDSUMINISTRO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDGRUPOFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION As Integer
        Dim IDESPECIFICOGASTO As Integer

        IDALMACEN = CType(Request.QueryString("idA"), Integer)
        IDSUMINISTRO = CType(Request.QueryString("idS"), Integer)
        IDGRUPO = CType(Request.QueryString("idG"), Integer)
        IDFUENTEFINANCIAMIENTO = CType(Request.QueryString("idFF"), Integer)
        IDGRUPOFUENTEFINANCIAMIENTO = CType(Request.QueryString("idGF"), Integer)
        IDRESPONSABLEDISTRIBUCION = CType(Request.QueryString("idRD"), Integer)
        IDESPECIFICOGASTO = CType(Request.QueryString("idEG"), Integer)

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "Titulo"
        pField1.ParameterFieldName = "ESPECIFICOGASTO"
        pDiscreteValue1.Value = "Existencias al " + Now.Date.ToShortDateString
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim cL As New cLOTES
        Me.crvPrincipal.ParameterFieldInfo = pFields

        Dim usr = Membresia.ObtenerUsuario()
        Dim ds As New List(Of LotesFiltrados)
        If (Membresia.EsUsuarioRol("Consulta Almacen I")) Then
            ds = AlmacenHelpers.Lotes.ObtenerLotesFiltrados(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO, IDALMACEN, IDSUMINISTRO, IDESPECIFICOGASTO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDGRUPOFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION)
        Else
            ds = AlmacenHelpers.Lotes.ObtenerLotesFiltrados(0, IDALMACEN, IDSUMINISTRO, IDESPECIFICOGASTO, IDGRUPO, IDFUENTEFINANCIAMIENTO, IDGRUPOFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION)
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
