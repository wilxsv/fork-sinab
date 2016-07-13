Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers

Partial Class FrmRptProductosSinExistencia
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptProductosSinExistencia.rpt")
        Reporte.Load(reportPath)

        Dim usr = Membresia.ObtenerUsuario()
        ' Dim IDALMACEN, IDSUMINISTRO As Integer

        'IDALMACEN = Request.QueryString("idA")
        'Dim oCEA As New cEMPLEADOSALMACEN
        'Dim oCA As New cALMACENES
        'Dim oEAlmacenes As New ABASTECIMIENTOS.ENTIDADES.ALMACENES
        'Dim dsAlm = usr.Almacen.IDALMACEN
        'As New Data.DataSet
        'dsAlm = oCEA.ObtenerDsIdAlmacen(Session("IDEmpleado"))
        'For ca As Integer = 0 To dsAlm.Tables(0).Rows.Count
        '    oEAlmacenes = oCA.ObtenerALMACENES(dsAlm.Tables(0).Rows(ca)("IDALMACEN"))
        '    If Not CBool(oEAlmacenes.ESFARMACIA) Then
        '        IDALMACEN = oEAlmacenes.IDALMACEN
        '        Exit For
        '    End If
        'Next

        'IDSUMINISTRO = CType(Request.QueryString("idS"), Integer)
        ' IDGRUPO = Request.QueryString("idG")
        'IDFUENTEFINANCIAMIENTO = Request.QueryString("idFF")
        'IDGRUPOFUENTEFINANCIAMIENTO = Request.QueryString("idGF")
        'IDRESPONSABLEDISTRIBUCION = Request.QueryString("idRD")

        'Dim dba As New cALMACENES

        Dim semana = SINAB_Utils.Semana.ObtenerNumero()
        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "Titulo"
        pDiscreteValue1.Value = SINAB_Utils.Semana.ObtenerInformacion(Now.Year, semana)
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        'Dim cL As New cLOTES
        Dim ds = ProductoSinExistencia.ObtenerTodos(usr.Almacen.IDALMACEN, CType(Request.QueryString("idS"), Integer))

        Me.crvPrincipal.ParameterFieldInfo = pFields

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
