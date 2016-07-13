Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptContabilidadAlmacen
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("~/Reportes/RptContabilidadAlmacenEspecificosGasto.rpt")
        Reporte.Load(reportPath)

        Dim IDALMACEN, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, IDSUMINISTRO As Integer
        Dim MESPERIODO, ANIOPERIODO As Integer
        Dim IDESPECIFICOGASTO As Integer

        IDALMACEN = Request.QueryString("idA")
        MESPERIODO = Request.QueryString("m")
        ANIOPERIODO = Request.QueryString("a")
        IDGRUPOFUENTEFINANCIAMIENTO = Request.QueryString("idGFF")
        IDFUENTEFINANCIAMIENTO = Request.QueryString("idFF")
        IDSUMINISTRO = Request.QueryString("idS")
        IDESPECIFICOGASTO = Request.QueryString("idEG")

        Dim cA As New cALMACENES
        Dim eA As New ALMACENES
        eA = cA.ObtenerALMACENES(IDALMACEN)

        Dim EspecificoGasto As String

        If IDESPECIFICOGASTO = 0 Then
            EspecificoGasto = "Todos"
        Else
            Dim cEG As New cESPECIFICOSGASTO
            Dim eEG As New ESPECIFICOSGASTO
            eEG = cEG.ObtenerESPECIFICOGASTO(IDESPECIFICOGASTO)
            EspecificoGasto = eEG.CODIGO.ToString + " - " + eEG.NOMBRE.ToUpper
        End If

        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim InventarioInicial As Decimal

        If Session("IdEstablecimiento") = 620 Then
            InventarioInicial = cDM.ObtenerInventarioInicial(MESPERIODO, ANIOPERIODO, IDALMACEN, IDSUMINISTRO, IDGRUPOFUENTEFINANCIAMIENTO, 1, IDESPECIFICOGASTO)
        Else
            InventarioInicial = cDM.ObtenerInventarioInicial(MESPERIODO, ANIOPERIODO, IDALMACEN, IDSUMINISTRO, IDGRUPOFUENTEFINANCIAMIENTO, 0, IDESPECIFICOGASTO)
        End If

        Dim pFields As New ParameterFields()

        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "REGION"
        pDiscreteValue1.Value = eA.NOMBRE.ToUpper
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "GRUPO"

        Select Case IDGRUPOFUENTEFINANCIAMIENTO
            Case 1
                pDiscreteValue2.Value = "FONDO GENERAL"
            Case 2
                pDiscreteValue2.Value = "DONACIONES"
            Case 3
                pDiscreteValue2.Value = "PRESTAMOS EXTERNOS"
            Case 4
                pDiscreteValue2.Value = "PRESTAMOS INTERNOS"
            Case 5
                pDiscreteValue2.Value = "RECURSOS PROPIOS"

        End Select

        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim pField4 As New ParameterField()
        Dim pDiscreteValue4 As New ParameterDiscreteValue()
        pField4.ParameterFieldName = "II"
        pDiscreteValue4.Value = InventarioInicial
        pField4.CurrentValues.Add(pDiscreteValue4)
        pFields.Add(pField4)

        Dim FechaII As New Date(ANIOPERIODO, MESPERIODO, 1)

        Dim pField5 As New ParameterField()
        Dim pDiscreteValue5 As New ParameterDiscreteValue()
        pField5.ParameterFieldName = "inv"
        pDiscreteValue5.Value = "INVENTARIO AL " & FechaII.Day.ToString & " DEL MES DE " & MonthName(FechaII.Month).ToUpper & " DE " & FechaII.Year.ToString
        pField5.CurrentValues.Add(pDiscreteValue5)
        pFields.Add(pField5)

        Dim pField6 As New ParameterField()
        Dim pDiscreteValue6 As New ParameterDiscreteValue()
        pField6.ParameterFieldName = "MES"
        pDiscreteValue6.Value = MonthName(FechaII.Month).ToUpper
        pField6.CurrentValues.Add(pDiscreteValue6)
        pFields.Add(pField6)

        Dim pField7 As New ParameterField()
        Dim pDiscreteValue7 As New ParameterDiscreteValue()
        pField7.ParameterFieldName = "ESPECIFICOGASTO"
        pDiscreteValue7.Value = EspecificoGasto
        pField7.CurrentValues.Add(pDiscreteValue7)
        pFields.Add(pField7)

        Dim oSuministro As New cSUMINISTROS
        Dim oESuminitro As New SUMINISTROS
        oESuminitro = oSuministro.ObtenerSUMINISTROS(IDSUMINISTRO)
        Dim pField8 As New ParameterField()
        Dim pDiscreteValue8 As New ParameterDiscreteValue()
        pField8.ParameterFieldName = "SUMINISTRO"
        pDiscreteValue8.Value = oESuminitro.DESCRIPCION.ToUpper
        pField8.CurrentValues.Add(pDiscreteValue8)
        pFields.Add(pField8)


        Dim ds As Data.DataSet = Nothing

        Select Case IDGRUPOFUENTEFINANCIAMIENTO

            Case 1

                If Session("IdEstablecimiento") = 620 Then
                    ds = cDM.RptContabilidadAlmacen2(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 1, IDESPECIFICOGASTO)
                Else
                    ds = cDM.RptContabilidadAlmacen2(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 0, IDESPECIFICOGASTO)
                End If

            Case 2

                If Session("IdEstablecimiento") = 620 Then
                    ds = cDM.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 1, IDESPECIFICOGASTO)
                Else
                    ds = cDM.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 0, IDESPECIFICOGASTO)
                End If

            Case 3

                If Session("IdEstablecimiento") = 620 Then
                    ds = cDM.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 1, IDESPECIFICOGASTO)
                Else
                    ds = cDM.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 0, IDESPECIFICOGASTO)
                End If


            Case 4

                If Session("IdEstablecimiento") = 620 Then
                    ds = cDM.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 1, IDESPECIFICOGASTO)
                Else
                    ds = cDM.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 0, IDESPECIFICOGASTO)
                End If


            Case 5

                If Session("IdEstablecimiento") = 620 Then
                    ds = cDM.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 1, IDESPECIFICOGASTO)
                Else
                    ds = cDM.RptContabilidadAlmacen3(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, 0, IDESPECIFICOGASTO)
                End If

                'Case 3

                '    ds = cDM.RptContabilidadAlmacenFOSALUD(IDALMACEN, IDSUMINISTRO, MESPERIODO, ANIOPERIODO, IDGRUPOFUENTEFINANCIAMIENTO, IDFUENTEFINANCIAMIENTO, 0, IDESPECIFICOGASTO)

        End Select

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
        crvPrincipal.HasExportButton = False

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
