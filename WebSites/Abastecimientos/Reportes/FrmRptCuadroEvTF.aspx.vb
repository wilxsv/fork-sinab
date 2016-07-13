Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptCuadroEvTF
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptCuadroEvTF.rpt")
        Reporte.Load(reportPath)

        Dim IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON As Integer
        IDESTABLECIMIENTO = Request.QueryString("idE")
        IDPROCESOCOMPRA = Request.QueryString("idPC")
        RENGLON = Request.QueryString("R")

        Dim cDO As New cDETALLEOFERTA
        Dim ds As Data.DataSet
        ds = cDO.CuadroTecnicoFinanciero(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)

        Dim mProcesoCompra As New cPROCESOCOMPRAS
        Dim dsPC As New Data.DataSet
        mProcesoCompra.ObtenerInfoLicitacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsPC)
        Reporte.SetDataSource(ds.Tables(0))

        'If dsPC.Tables(0).Rows.Count > 0 Then
        'Reporte.DataDefinition.FormulaFields(0).Text = "'" & dsPC.Tables(0).Rows(0).Item(0) & "'"
        'Reporte.DataDefinition.FormulaFields(1).Text = "'" & dsPC.Tables(0).Rows(0).Item(1) & "'"
        'Reporte.DataDefinition.FormulaFields(2).Text = "'" & dsPC.Tables(0).Rows(0).Item(2) & "'"
        'Reporte.DataDefinition.FormulaFields(3).Text = "'" & dsPC.Tables(0).Rows(0).Item(3) & "'"
        'End If

        'agregar la cantidad recomendada al reporte
        Dim cA As New cADJUDICACION
        Dim dsRR As Data.DataSet
        dsRR = cA.obtenerRenglonRecomendado(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)

        Dim Recomendacion As String = ""

        If dsRR.Tables(0).Rows.Count = 0 Then
            Recomendacion = "Se recomienda No Adjudicar"
        Else
            Dim drx As Data.DataRow = dsRR.Tables(0).NewRow

            For Each drx In dsRR.Tables(0).Rows
                If drx(1) = 0 Then

                Else
                    'oferta-cantidad
                    Recomendacion += "Oferta " & drx(0) & "  Cantidad " & Format(drx(1), "###,##0.00") & " ;  "
                End If

            Next
        End If
        Dim NumLicitacion As String = dsPC.Tables(0).Rows(0).Item("CODIGOLICITACION")
        Dim DescripcionPC As String = dsPC.Tables(0).Rows(0).Item("DESCRIPCIONLICITACION")
        Dim TipoLicitacion As String = dsPC.Tables(0).Rows(0).Item("DESCRIPCION")

        Reporte.DataDefinition.FormulaFields(0).Text = "'" & TipoLicitacion & "'"
        Reporte.DataDefinition.FormulaFields(1).Text = "'" & NumLicitacion & "'"
        Reporte.DataDefinition.FormulaFields(3).Text = "'" & DescripcionPC & "'"
        Reporte.DataDefinition.FormulaFields(4).Text = "'" & Recomendacion & "'"

        Dim paramField As New ParameterField()
        Dim paramFields As New ParameterFields()
        Dim discreteVal As New ParameterDiscreteValue()

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Descripcion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = DescripcionPC
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Me.crvPrincipal.ReportSource = Reporte
        Me.crvPrincipal.ParameterFieldInfo = paramFields

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
