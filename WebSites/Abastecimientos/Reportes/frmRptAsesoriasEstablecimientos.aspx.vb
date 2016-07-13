Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_frmRptAsesoriasEstablecimientos
    Inherits System.Web.UI.Page

    Private Reporte As New ReportDocument

    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfiguracionReporte()
        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath("RptAsesoriasEstablecimientost.rpt")
        Reporte.Load(reportPath)

        Dim dv As New Data.DataView

        Dim mComponenteODN As New cOBSERVACIONDETALLENECESIDAD
        Dim ds As Data.DataSet
        ds = mComponenteODN.Obtenerobservaciones(Session("idE"), Session("idDocRep"), Session("idproducto"))

        dv.Table = ds.Tables(0)

        'Parametros de provedor al reporte
        paramField.ParameterFieldName = "NecesidadFinal"
        discreteVal.Value = Session("NecesidadFinal")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "CodigoProducto"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("CodigoProducto")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "idNecesidad"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("idNecesidad")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "establecimiento"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("establecimiento")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "NomProducto"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("NomProducto")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "UnidadMedida"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("UnidadMedida")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "ConsumoAnual"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("ConsumoAnual")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "DemandaInsatisfecha"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("DemandaInsatisfecha")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Reserva"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("Reserva")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "ReservaTotal"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("ReservaTotal")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "ExistenciaEstimada"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("ExistenciaEstimada")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "NecesidadReal"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("NecesidadReal")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "NecesidadAjustada"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("NecesidadAjustada")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "CTR"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("CTR")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "CTA"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("CTA")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Pr"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("Pr")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Su"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session("Su")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramFields.Add(paramField)
        Reporte.SetDataSource(dv.Table)
        Me.crvPrincipal.ParameterFieldInfo = paramFields
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
        ConfiguracionReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
