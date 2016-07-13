Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptDespachosGenerales
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim IDALMACEN, IDFUENTEFINANCIAMIENTO, IDGRUPOFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, fos As Integer
        Dim IDSUMINISTRO, IDGRUPO, AgruparPor As Integer
        Dim FECHADESDE, FECHAHASTA As Date
        Dim IDESTABLECIMIENTODESTINO As Integer
        Dim IDESPECIFICOGASTO, TRANSF As Integer

        IDALMACEN = Request.QueryString("idA")
        FECHADESDE = Date.Parse(Request.QueryString("fd"))
        FECHAHASTA = Date.Parse(Request.QueryString("fh"))
        IDFUENTEFINANCIAMIENTO = Request.QueryString("idFF")
        IDGRUPOFUENTEFINANCIAMIENTO = Request.QueryString("idGF")
        IDRESPONSABLEDISTRIBUCION = Request.QueryString("idRD")
        IDSUMINISTRO = Request.QueryString("idS")
        IDGRUPO = Request.QueryString("idG")
        AgruparPor = Request.QueryString("Ag")
        fos = Request.QueryString("fos")
        IDESTABLECIMIENTODESTINO = Request.QueryString("idED")
        IDESPECIFICOGASTO = Request.QueryString("idEG")
        TRANSF = Request.QueryString("transf")

        Dim reportPath As String = String.Empty

        Select Case AgruparPor
            Case eAGRUPAR.Fecha
                reportPath = Server.MapPath("~/Reportes/RptDespachosGeneralesEspecificosGasto.rpt")
            Case eAGRUPAR.Grupo
                reportPath = Server.MapPath("~/Reportes/RptDespachosGeneralesPorGrupo.rpt")
            Case eAGRUPAR.Producto
                reportPath = Server.MapPath("~/Reportes/RptDespachosGeneralesPorProducto.rpt")
        End Select

        Dim EspecificoGasto As String

        If IDESPECIFICOGASTO = 0 Then
            EspecificoGasto = "Todos"
        Else
            Dim cEG As New cESPECIFICOSGASTO
            Dim eEG As New ESPECIFICOSGASTO
            eEG = cEG.ObtenerESPECIFICOGASTO(IDESPECIFICOGASTO)
            EspecificoGasto = eEG.CODIGO.ToString + " - " + eEG.NOMBRE.ToUpper
        End If

        Reporte.Load(reportPath)

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "Titulo"
        pDiscreteValue1.Value = "Despachos generales de " + String.Format("{0:d}", FECHADESDE) + " a " + String.Format("{0:d}", FECHAHASTA)
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "ESPECIFICOGASTO"
        pDiscreteValue2.Value = EspecificoGasto
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim cDM As New cDETALLEMOVIMIENTOS

        Dim ds As Data.DataSet
        ds = cDM.DespachosGeneralesPorTipoProducto(IDALMACEN, FECHADESDE, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDSUMINISTRO, IDGRUPO, IDESTABLECIMIENTODESTINO, AgruparPor, IDGRUPOFUENTEFINANCIAMIENTO, fos, IDESPECIFICOGASTO, TRANSF)

        Reporte.SetDataSource(ds.Tables(0))

        Me.crvPrincipal.ParameterFieldInfo = pFields
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
