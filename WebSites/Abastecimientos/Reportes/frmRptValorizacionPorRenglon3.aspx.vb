Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptValorizacionPorRenglon3
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfiguracionReporte()
        Dim IDPROCESOCOMPRA, IDALMACEN As Int64
        IDALMACEN = Request.QueryString("idA")
        IDPROCESOCOMPRA = Request.QueryString("idPC")
        Dim reportPath As String
        Dim X As New cPROGRAMADISTRIBUCION
        If X.ObtenerAlmacenFosIsss(Session("IdEstablecimiento"), IDPROCESOCOMPRA) = 0 Then
            reportPath = Server.MapPath("RptValorizacionesPorRenglon3.rpt")
        Else
            If IDALMACEN <> 0 Then
                reportPath = Server.MapPath("RptValorizacionesPorRenglon3.rpt")
            Else
                reportPath = Server.MapPath("RptValorizacionesPorRenglon3.rpt")
                'reportPath = Server.MapPath("RptValorizacionesPorRenglon33.rpt")
            End If
        End If

        Reporte = New ReportDocument
        'Dim reportPath As String = Server.MapPath("RptValorizacionesPorRenglon3.rpt")
        Reporte.Load(reportPath)

        Dim cDO As New cDETALLEOFERTA
        Dim dsDO As New Data.DataSet
        cDO.ObtenerValorizacionPorRenglon2(Session("IdEstablecimiento"), IDPROCESOCOMPRA, dsDO, Request.QueryString("idA"))

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
        paramField.ParameterFieldName = "ENCA"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session.Item("EncabezadoDocumento")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        '  Reporte.DataDefinition.FormulaFields(2).Text = "'" & Session.Item("EncabezadoDocumento") & "'"

        paramField = New ParameterField()
        paramField.ParameterFieldName = "E"
        discreteVal = New ParameterDiscreteValue()

        Select Case Request.QueryString("idA")
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

        '       paramFields.Add(paramField)

        Reporte.SetDataSource(dsDO)
        Reporte.Subreports.Item(0).SetDataSource(dsDO.Tables(0))
        Reporte.Subreports.Item(1).SetDataSource(dsDO.Tables(1))
        Me.crvPrincipal.ParameterFieldInfo.Clear()

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
