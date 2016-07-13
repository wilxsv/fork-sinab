Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Linq
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SINAB_Entidades.Helpers.UACIHelpers

Partial Class Reportes_FrmRptNotificacionLotes
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim idestablecimiento = CType(Request.QueryString("idE"), Integer)
        Dim idproveedor = CType(Request.QueryString("idP"), Integer)
        Dim idprocesocompra = CType(Request.QueryString("idPc"), Integer)
        Dim idcontrato = CType(Request.QueryString("idC"), Integer)

        Dim reportPath = Server.MapPath("RptNotificacionLotes.rpt")

        Reporte.Load(reportPath)

        Dim ds = Notificaciones.ObtenerTodosReporte(idproveedor, idprocesocompra, idestablecimiento, idcontrato, 1)
        Dim pctp = ProcesoCompras.ObtenerTipoCompra(idestablecimiento, idprocesocompra)
        Dim prv = Proveedores.Obtener(idproveedor)

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "TIPOCOMPRA"
        pDiscreteValue1.Value = pctp.Descripcion
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "CODIGOLICITACION"
        pDiscreteValue2.Value = pctp.CodigoLicitacion
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "DESCRIPCIONLICITACION"
        pDiscreteValue3.Value = pctp.DescripcionLicitacion
        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)


        Dim pField4 As New ParameterField()
        Dim pDiscreteValue4 As New ParameterDiscreteValue()
        pField4.ParameterFieldName = "NOMBREPROVEEDOR"
        pDiscreteValue4.Value = prv.NOMBRE
        pField4.CurrentValues.Add(pDiscreteValue4)
        pFields.Add(pField4)


        Dim obj = ds.FirstOrDefault()
        Dim unidadmedida As String = obj.UnidadMedida

        Dim pField5 As New ParameterField()
        Dim pDiscreteValue5 As New ParameterDiscreteValue()
        pField5.ParameterFieldName = "UM"
        pDiscreteValue5.Value = unidadmedida
        pField5.CurrentValues.Add(pDiscreteValue5)
        pFields.Add(pField5)

        Dim pField6 As New ParameterField()
        Dim pDiscreteValue6 As New ParameterDiscreteValue()
        pField6.ParameterFieldName = "numNoti"
        pDiscreteValue6.Value = obj.NUMERONOTIFICACION
        pField6.CurrentValues.Add(pDiscreteValue6)
        pFields.Add(pField6)

        Dim pField7 As New ParameterField()
        Dim pDiscreteValue7 As New ParameterDiscreteValue()
        pField7.ParameterFieldName = "FECHANOTI"
        pDiscreteValue7.Value = obj.FECHANOTIFICACION
        pField7.CurrentValues.Add(pDiscreteValue7)
        pFields.Add(pField7)

        Reporte.SetDataSource(ds)
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

        Me.crvPrincipal.EnableDatabaseLogonPrompt = False
        Me.crvPrincipal.EnableParameterPrompt = False

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
