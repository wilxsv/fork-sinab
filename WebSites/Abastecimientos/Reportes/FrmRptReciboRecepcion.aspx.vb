Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers

Partial Class Reportes_FrmRptReciboRecepcion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String
        reportPath = Server.MapPath("RptReciboRecepcion.rpt")
        Reporte.Load(reportPath)

        Dim IDESTABLECIMIENTOMOV, IDTIPOTRANSACCION, IDMOVIMIENTO As Integer
        IDESTABLECIMIENTOMOV = Request.QueryString("IdEMov")
        IDTIPOTRANSACCION = Request.QueryString("IdTT")
        IDMOVIMIENTO = Request.QueryString("IdMov")

        Dim cM As New cMOVIMIENTOS
        Dim ds As DataSet
        ds = cM.ObtenerReciboRecepcionDS2(IDESTABLECIMIENTOMOV, IDTIPOTRANSACCION, IDMOVIMIENTO)

        Dim IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO As Integer

        Dim eC As New CONTRATOS

        If IDTIPOTRANSACCION = EnumHelpers.TiposTransaccion.RecepcionProductos Then
            IDESTABLECIMIENTO = Request.QueryString("IdE")
            IDPROVEEDOR = Request.QueryString("IdP")
            IDCONTRATO = Request.QueryString("IdC")

            Dim cC As New cCONTRATOS
            eC = cC.obtenerDatosContrato2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        End If

        Dim pFields As New ParameterFields()

        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "ModalidadCompra"
        pDiscreteValue1.Value = eC.DESCRIPCIONMODALIDADCOMPRA + " " + eC.NUMEROMODALIDADCOMPRA
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "Fondos"
        pDiscreteValue2.Value = cM.ObtenerFuentesFinanciamientoMovimiento(IDESTABLECIMIENTOMOV, IDTIPOTRANSACCION, IDMOVIMIENTO)
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "TipoDocumento"
        pDiscreteValue3.Value = eC.TIPODOCUMENTO + " " + eC.NUMEROCONTRATO
        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)

        Dim pField4 As New ParameterField()
        Dim pDiscreteValue4 As New ParameterDiscreteValue()
        pField4.ParameterFieldName = "Modificativas"
        pDiscreteValue4.Value = IIf(IsNothing(eC.MODIFICATIVASCONTRATO), IIf(IsNothing(eC.MODIFICATIVA), String.Empty, eC.MODIFICATIVA), IIf(eC.MODIFICATIVASCONTRATO = String.Empty, IIf(eC.MODIFICATIVA = String.Empty, String.Empty, eC.MODIFICATIVA), eC.MODIFICATIVASCONTRATO))
        pField4.CurrentValues.Add(pDiscreteValue4)
        pFields.Add(pField4)

        Dim pField5 As New ParameterField()
        Dim pDiscreteValue5 As New ParameterDiscreteValue()
        pField5.ParameterFieldName = "Resolucion"
        pDiscreteValue5.Value = IIf(IsNothing(eC.RESOLUCIONADJUDICACION), IIf(IsNothing(eC.RESOLUCION), String.Empty, eC.RESOLUCION), IIf(eC.RESOLUCIONADJUDICACION = String.Empty, IIf(eC.RESOLUCION = String.Empty, String.Empty, eC.RESOLUCION), eC.RESOLUCIONADJUDICACION))
        pField5.CurrentValues.Add(pDiscreteValue5)
        pFields.Add(pField5)


        Dim pField6 As New ParameterField()
        Dim pDiscreteValue6 As New ParameterDiscreteValue()
        pField6.ParameterFieldName = "ADMCONTRATO"
        pDiscreteValue6.Value = ds.Tables(0).Rows(0)("ADMCONTRATO")
        pField6.CurrentValues.Add(pDiscreteValue6)
        pFields.Add(pField6)



        If Not pDiscreteValue6.Value = Nothing Then
            Reporte.ReportDefinition.Sections("rfAdmContrato").SectionFormat.EnableSuppress = False
        Else
            Reporte.ReportDefinition.Sections("rfAdmContrato").SectionFormat.EnableSuppress = True
        End If


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
