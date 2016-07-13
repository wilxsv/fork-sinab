Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptHojaAnalisisXProveedor
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument

        Dim lId, lopc, lIdp As Int64

        lId = Request.QueryString("id")
        lopc = Request.QueryString("opc")
        lIdp = Request.QueryString("idP")

        Dim mComponente As New cPROCESOCOMPRAS

        Dim DstrptHojaAnalisis As DataSet
        Dim McompEntregas As New cDETALLEENTREGASPROCESOCOMPRA

        Select Case lopc
            Case 1 'todas los renglones ofertados

                Dim reportPath As String
                'Dim mComTiposuministro As New cSOLICITUDES
                'Dim ds As Data.DataSet

                'ds = mComponente.ObtenerTipoSuministro(Session.Item("id"), Session.Item("IdEstablecimiento"))
                'Dim TIPOPROCESO As Integer

                'TIPOPROCESO = ds.Tables(0).Rows(0).Item("IDCLASESUMINISTRO")

                'If TIPOPROCESO = 1 Then
                reportPath = Server.MapPath("RptHojaAnalisisNewP.rpt")
                'Else
                'reportPath = Server.MapPath("RptHojaAnalisisNew1P.rpt")
                'End If

                Reporte.Load(reportPath)

                DstrptHojaAnalisis = mComponente.ObtenerHojaAnalisisXProveedor(Session.Item("IdEstablecimiento"), lId, lIdp)

                Dim dst, dsep, ds2 As New DataSet
                Dim dt As New DataTable
                Dim r, r2 As DataRow

                Dim entregasProceso As String = ""

                dst = DstrptHojaAnalisis
                dt = dst.Tables(0)
                dt.Columns.Add("ENTREGAS", System.Type.GetType("System.String"))

                For Each r In dst.Tables(0).Rows
                    If r("ENTREGASPRODUCTO") <> Nothing Or r("ENTREGASPRODUCTO") <> 0 Then
                        entregasProceso = (r("ENTREGASPRODUCTO"))
                        dsep = McompEntregas.ObtenerDetalledeEntregasProcesoCompra(lId, Session.Item("IdEstablecimiento"), r("ENTREGASPRODUCTO"))
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
                Dim reportPath As String = Server.MapPath("RptHojaAnalisisDesierto.rpt")
                Reporte.Load(reportPath)
                DstrptHojaAnalisis = mComponente.ObtenerHojaAnalisisDesierto(Session.Item("IdEstablecimiento"), lId)
                Reporte.SetDataSource(DstrptHojaAnalisis.Tables(0))

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

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
