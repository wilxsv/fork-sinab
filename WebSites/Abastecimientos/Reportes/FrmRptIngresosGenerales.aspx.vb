Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptIngresosGenerales
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim idalmacen, idfuentefinanciamiento, idgrupofuentefinanciamiento, idresponsabledistribucion, fos As Integer
        Dim idsuministro, idgrupo, agruparPor As Integer
        Dim fechadesde, fechahasta As Date
        Dim idespecificogasto, transf As Integer

        idalmacen = CType(Request.QueryString("idA"), Integer)
        fechadesde = Date.Parse(Request.QueryString("fd"))
        fechahasta = Date.Parse(Request.QueryString("fh"))
        idfuentefinanciamiento = CType(Request.QueryString("idFF"), Integer)
        idgrupofuentefinanciamiento = CType(Request.QueryString("idGF"), Integer)
        idresponsabledistribucion = CType(Request.QueryString("idRD"), Integer)
        idsuministro = CType(Request.QueryString("idS"), Integer)
        idgrupo = CType(Request.QueryString("idG"), Integer)
        agruparPor = CType(Request.QueryString("Ag"), Integer)
        fos = CType(Request.QueryString("fos"), Integer)
        idespecificogasto = CType(Request.QueryString("idEG"), Integer)
        transf = CType(Request.QueryString("transf"), Integer)

        Dim reportPath As String = String.Empty

        Select Case agruparPor
            Case eAGRUPAR.Fecha
                reportPath = Server.MapPath("~/Reportes/RptIngresosGeneralesEspecificosGasto.rpt")
            Case eAGRUPAR.Grupo
                reportPath = Server.MapPath("~/Reportes/RptIngresosGeneralesPorGrupo.rpt")
            Case eAGRUPAR.Producto
                reportPath = Server.MapPath("~/Reportes/RptIngresosGeneralesPorProducto.rpt")
        End Select

        Reporte.Load(reportPath)

        Dim especificoGasto As String

        If idespecificogasto = 0 Then
            especificoGasto = "Todos"
        Else
            Dim cEG As New cESPECIFICOSGASTO
            Dim eEG As New ESPECIFICOSGASTO
            eEG = cEG.ObtenerESPECIFICOGASTO(idespecificogasto)
            especificoGasto = eEG.CODIGO.ToString + " - " + eEG.NOMBRE.ToUpper
        End If

        Dim pFields As New ParameterFields()

        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "Titulo"
        pDiscreteValue1.Value = "Ingresos generales de " + String.Format("{0:d}", fechadesde) + " a " + String.Format("{0:d}", fechahasta)
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "ESPECIFICOGASTO"
        pDiscreteValue2.Value = especificoGasto
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim cDM As New cDETALLEMOVIMIENTOS

        Dim ds As Data.DataSet
    
ds = cDM.IngresosGeneralesPorTipoProducto(idalmacen, fechadesde, fechahasta, idfuentefinanciamiento, idresponsabledistribucion, idsuministro, idgrupo, agruparPor, idgrupofuentefinanciamiento, fos, idespecificogasto, transf)

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
