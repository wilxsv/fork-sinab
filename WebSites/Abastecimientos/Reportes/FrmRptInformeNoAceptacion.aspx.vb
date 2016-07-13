Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptInformeNoAceptacion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim lIdMovimiento As Int64
    Dim lIdAlmacen As Int64
    Dim lAnio As Integer

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String
        reportPath = Server.MapPath("RptInformeNoAceptacion.rpt")

        Dim IDESTABLECIMIENTOMOV, IDMOVIMIENTO As Integer
        IDESTABLECIMIENTOMOV = Request.QueryString("IdEMov")
        IDMOVIMIENTO = Request.QueryString("IdMov")

        Dim IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO As Integer
        IDESTABLECIMIENTO = Request.QueryString("IdE")
        IDPROVEEDOR = Request.QueryString("IdP")
        IDCONTRATO = Request.QueryString("IdC")

        Reporte.Load(reportPath)

        Dim cM As New cMOVIMIENTOS
        Dim cC As New cCONTRATOS
        Dim eC As New CONTRATOS

        Dim ds As DataSet
        ds = cM.ObtenerNoAceptacionDS(IDESTABLECIMIENTOMOV, IDMOVIMIENTO)

        eC = cC.obtenerDatosContrato2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

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
        pDiscreteValue2.Value = eC.FUENTESFINANCIAMIENTO
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
        pDiscreteValue4.Value = eC.MODIFICATIVASCONTRATO
        pField4.CurrentValues.Add(pDiscreteValue4)
        pFields.Add(pField4)

        Dim pField5 As New ParameterField()
        Dim pDiscreteValue5 As New ParameterDiscreteValue()
        pField5.ParameterFieldName = "Resolucion"
        pDiscreteValue5.Value = eC.RESOLUCIONADJUDICACION
        pField5.CurrentValues.Add(pDiscreteValue5)
        pFields.Add(pField5)

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
