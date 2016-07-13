Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptHojaAnalisis
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument

        Dim IDPROCESOCOMPRA As Integer = Request.QueryString("idProc")
        Dim lopc As Integer = Request.QueryString("opc")
        Dim ord As Integer = Request.QueryString("ord")

        Dim mComponente As New cPROCESOCOMPRAS
        Dim McompEntregas As New cDETALLEENTREGASPROCESOCOMPRA
        Dim dsRrptHojaAnalisis As DataSet

        Dim reportPath As String

        Select Case lopc
            Case 1 'todas los renglones ofertados

                Dim ds As Data.DataSet
                ds = mComponente.ObtenerTipoSuministro(IDPROCESOCOMPRA, Session.Item("IdEstablecimiento"))

                Dim IDCLASESUMINISTRO As Integer
                IDCLASESUMINISTRO = ds.Tables(0).Rows(0).Item("IDCLASESUMINISTRO")

                If IDCLASESUMINISTRO = 1 Then
                    reportPath = Server.MapPath("RptHojaAnalisisNew.rpt")
                Else
                    reportPath = Server.MapPath("RptHojaAnalisisNew1.rpt")
                End If

                Reporte.Load(reportPath)

                If ord = 0 Then
                    dsRrptHojaAnalisis = mComponente.ObtenerHojaAnalisis(Session.Item("IdEstablecimiento"), IDPROCESOCOMPRA)
                Else
                    dsRrptHojaAnalisis = mComponente.ObtenerHojaAnalisis2(Session.Item("IdEstablecimiento"), IDPROCESOCOMPRA)
                End If

                Dim dst, dsep, ds2 As New DataSet
                Dim dt As New DataTable
                Dim r, r2 As DataRow

                Dim entregasProceso As String = ""

                dst = dsRrptHojaAnalisis
                dt = dst.Tables(0)
                dt.Columns.Add("ENTREGAS", System.Type.GetType("System.String"))

                For Each r In dst.Tables(0).Rows
                    If r("ENTREGASPRODUCTO") <> Nothing Or r("ENTREGASPRODUCTO") <> 0 Then
                        entregasProceso = (r("ENTREGASPRODUCTO"))
                        dsep = McompEntregas.ObtenerDetalledeEntregasProcesoCompra(IDPROCESOCOMPRA, Session.Item("IdEstablecimiento"), r("ENTREGASPRODUCTO"))
                        For Each r2 In dsep.Tables(0).Rows
                            If dsep.Tables(0).Rows.Count > 1 Then entregasProceso = entregasProceso & " - " & r2("PORCENTAJE") & "% a " & r2("DIAS") & " dias "
                            If dsep.Tables(0).Rows.Count = 1 Then entregasProceso = entregasProceso & "  " & r2("PORCENTAJE") & "% a " & r2("DIAS") & " dias "
                        Next r2
                        r("ENTREGAS") = entregasProceso
                        entregasProceso = ""
                    End If
                Next r

                ds2 = dst
                Reporte.SetDataSource(dst.Tables(0))

                Me.crvPrincipal.ReportSource = Reporte
                Me.crvSecundario.ReportSource = Nothing


            Case 2 'todos los renglones desiertos
                reportPath = Server.MapPath("RptHojaAnalisisDesierto.rpt")
                Reporte.Load(reportPath)
                dsRrptHojaAnalisis = mComponente.ObtenerHojaAnalisisDesierto(Session.Item("IdEstablecimiento"), IDPROCESOCOMPRA)
                Reporte.SetDataSource(dsRrptHojaAnalisis.Tables(0))

                Me.crvPrincipal.Visible = False
                Me.crvPrincipal.ReportSource = Nothing
                Me.crvSecundario.ReportSource = Reporte
        End Select

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

        Me.crvSecundario.DisplayGroupTree = False
        Me.crvSecundario.DisplayToolbar = True
        Me.crvSecundario.EnableDrillDown = False
        Me.crvSecundario.HasCrystalLogo = False
        Me.crvSecundario.HasDrillUpButton = False
        Me.crvSecundario.HasGotoPageButton = True
        Me.crvSecundario.HasPageNavigationButtons = True
        Me.crvSecundario.HasPrintButton = True
        Me.crvSecundario.HasRefreshButton = False
        Me.crvSecundario.HasSearchButton = False
        Me.crvSecundario.HasToggleGroupTreeButton = False
        Me.crvSecundario.HasViewList = False
        Me.crvSecundario.HasZoomFactorList = False

        Me.crvSecundario.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
