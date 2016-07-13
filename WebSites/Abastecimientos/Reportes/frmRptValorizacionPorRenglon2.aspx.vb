Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptValorizacionPorRenglon2
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfiguracionReporte()

        Reporte = New ReportDocument

        Dim IDPROCESOCOMPRA, IDALMACEN As Int64
        IDPROCESOCOMPRA = Request.QueryString("id")
        IDALMACEN = Request.QueryString("idA")
        Dim reportPath As String
        
        reportPath = Server.MapPath("RptValorizacionesPorRenglon2.rpt")
        

        Reporte.Load(reportPath)


        Dim cDO As New cDETALLEOFERTA
        Dim dsDO As New Data.DataSet

        cDO.ObtenerValorizacionPorRenglon2(Session("IdEstablecimiento"), IDPROCESOCOMPRA, dsDO, IDALMACEN)


        Dim cPC As New cPROCESOCOMPRAS
        Dim dsPC As New Data.DataSet
        cPC.ObtenerInfoLicitacion(Session("IdEstablecimiento"), IDPROCESOCOMPRA, dsPC)

        Dim paramField As New ParameterField()
        Dim paramFields As New ParameterFields()
        Dim discreteVal As New ParameterDiscreteValue()

        paramField = New ParameterField()
        paramField.ParameterFieldName = "TipoLicitacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsPC.Tables(0).Rows(0).Item(0)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "NumLicitacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsPC.Tables(0).Rows(0).Item(1)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "TituloLicitacion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsPC.Tables(0).Rows(0).Item(2)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Descripcion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = dsPC.Tables(0).Rows(0).Item(3)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "E"
        discreteVal = New ParameterDiscreteValue()

        Select Case IDALMACEN
            Case Is = 0
                discreteVal.Value = ""
            Case Is = 1
                discreteVal.Value = "MSPAS"
            Case Is = 114
                discreteVal.Value = "FOSALUD"
            Case Is = 499
                discreteVal.Value = "ISSS"
        End Select
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Reporte.SetDataSource(dsDO)
        Reporte.Subreports.Item(0).SetDataSource(dsDO.Tables(0))

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
