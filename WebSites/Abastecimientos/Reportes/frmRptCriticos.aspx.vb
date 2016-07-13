Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class Reportes_frmRptCriticos
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument

    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptCriticos.rpt")
        Reporte.Load(reportPath)


        Dim IDPRODUCTO As Integer = Request.QueryString("ID")
        Dim cD As New cDETALLECONSUMOS
        Dim dsExistencia As Data.DataSet
        Dim dsComprasT As Data.DataSet
        Dim dsPromedioConsumo As Data.DataSet

        dsExistencia = cD.ExistenciasCriticos(IDPRODUCTO)
        dsComprasT = cD.ComprasTransitoCriticos(IDPRODUCTO)
        dsPromedioConsumo = cD.PromedioConsumoCriticos(IDPRODUCTO)

        Dim ExistenciaI, ComprasTransitoI, PromedioMensual As Integer

        'existencias
        If dsExistencia.Tables(0).Rows.Count = 0 Then
            ExistenciaI = 0
        Else
            ExistenciaI = dsExistencia.Tables(0).Rows(0).Item(4)
        End If

        ' compras en transito
        If dsComprasT.Tables(0).Rows.Count = 0 Then
            ComprasTransitoI = 0
        Else
            ComprasTransitoI = dsComprasT.Tables(0).Rows(0).Item(1)
        End If

        ' promedio mensual
        If dsPromedioConsumo.Tables(0).Rows.Count = 0 Then
            PromedioMensual = 0 'dsPromedioConsumo.Tables(0).Rows(0).Item(1)
        Else
            PromedioMensual = dsPromedioConsumo.Tables(0).Rows(0).Item(1)
        End If


        Dim r As Decimal
        Dim f As Date = Today

        Dim c As Integer = 1
        Dim dt As New DataTable
        dt = CrearTabla()
        r = (ExistenciaI + ComprasTransitoI)
        Dim dsPV As DataSet
        Dim PV As Integer

        If PromedioMensual = 0 Or r = 0 Then
            'Me.MsgBox1.ShowAlert("No existen datos suficientes para realizar los cálculos necesarios que requiere este reporte.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            Reporte.DataDefinition.FormulaFields(1).Text = "'No existen datos suficientes para realizar los cálculos necesarios que requiere este reporte.'"
            Reporte.SetDataSource(dt)
        Else

            While r > 0
                dsPV = cD.ProximoAVencerCriticos(IDPRODUCTO, DateAdd(DateInterval.Month, c, f))
                If dsPV.Tables(0).Rows.Count = 0 Then
                    PV = 0
                Else
                    PV = dsPV.Tables(0).Rows(0).Item(1)
                End If


                Dim dr As Data.DataRow = dt.NewRow
                dr(3) = r
                r = r - (PromedioMensual + PV)

                dr(0) = dsExistencia.Tables(0).Rows(0).Item(1)
                dr(1) = dsExistencia.Tables(0).Rows(0).Item(2)
                dr(2) = dsExistencia.Tables(0).Rows(0).Item(3)

                dr(4) = PromedioMensual
                dr(5) = PV
                dr(6) = r '- (PromedioMensual + PV)
                dr(7) = DateAdd(DateInterval.Month, c, f)


                dt.Rows.Add(dr)
                c += 1
            End While
            Reporte.DataDefinition.FormulaFields(1).Text = "''"
            Reporte.SetDataSource(dt)


        End If

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

    Public Function CrearTabla() As DataTable
        Dim col As New Data.DataColumn
        Dim tbl As New Data.DataTable

        col = New DataColumn("codigoproducto", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)

        col = New DataColumn("desclargo", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)

        col = New DataColumn("unidadmedida", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)

        'col = New DataColumn("preciounitario", System.Type.GetType("System.Decimal"))
        'tbl.Columns.Add(col)

        col = New DataColumn("existencia", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)

        col = New DataColumn("promedio", System.Type.GetType("System.Decimal"))
        tbl.Columns.Add(col)

        col = New DataColumn("proximovencer", System.Type.GetType("System.Int32"))
        tbl.Columns.Add(col)

        col = New DataColumn("total", System.Type.GetType("System.Decimal"))
        tbl.Columns.Add(col)

        col = New DataColumn("fecha", System.Type.GetType("System.DateTime"))
        tbl.Columns.Add(col)

        Return tbl
    End Function

    'Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
    '    If e.Key = "A" Then

    '        Response.Write("<script language='javascript'>")
    '        Response.Write("window.close;")
    '        Response.Write("</script>")

    '    End If
    'End Sub
End Class
