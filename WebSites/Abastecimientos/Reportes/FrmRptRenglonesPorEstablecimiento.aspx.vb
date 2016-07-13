Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptRenglonesPorEstablecimiento
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Dim id_procesoCompra As Int64 = Request.QueryString("idProc")
        Dim id_establecimiento As Integer = Session.Item("IdEstablecimiento")
        Dim FuentesFinanciamiento As String = ""
        Dim NoDocumento As String = ""
        Dim TituloDocumento As String = ""
        Dim ds As New DataSet


        'Fuentes de financiamiento del proceso de compra
        Dim cFF As New ABASTECIMIENTOS.NEGOCIO.cFUENTEFINANCIAMIENTOS
        Dim cPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS

        cPC.ObtenerCodigoyTipoLicitacion(id_establecimiento, id_procesoCompra, ds)
        FuentesFinanciamiento = "Fondos: " & cFF.DevolverFFPC(id_procesoCompra, id_establecimiento)

        Try
            If ds.Tables.Count = 1 Then
                NoDocumento = ds.Tables(0).Rows(0).Item(0) & " No. " & ds.Tables(0).Rows(0).Item(1)
                TituloDocumento = Chr(34) & UCase(ds.Tables(0).Rows(0).Item(3)) & Chr(34)
            End If
        Catch ex As Exception

        End Try

        'Parametros del reporte

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptRenglonesPorEstablecimiento.rpt") 'nombre de reporte

        Reporte.Load(reportPath)

        Dim mComponente As New cNECESIDADESSOLICITUD

        Dim DstRpt As DataSet
        DstRpt = mComponente.ObtenerDistribucionUACI(id_establecimiento, id_procesoCompra)

        Reporte.DataDefinition.FormulaFields("TituloLicitacion").Text = "'" + NoDocumento + "'"
        Reporte.DataDefinition.FormulaFields("DescripcionLicitacion").Text = "'" + TituloDocumento + "'"

        Reporte.SetDataSource(DstRpt.Tables(0))

        'muestra reporte
        Me.crvPrincipal.ReportSource = Reporte

        Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'al inicializar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
