Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptIncumplirRecepciones
    Inherits System.Web.UI.Page

    'declaracion e inicializacion
    Private Reporte As ReportDocument
    Dim Renglones As New Data.DataTable

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument

        Dim reportPath As String = Server.MapPath(".rpt")

        Select Case Request.QueryString("TipoI")
            Case 0
                Select Case Request.QueryString("TipoC")
                    Case 0
                        reportPath = Server.MapPath("RptIncumplirProductoA.rpt")
                        Reporte.Load(reportPath)
                        Reporte.DataDefinition.FormulaFields(5).Text = "'Producto'"
                    Case 1
                        reportPath = Server.MapPath("RptIncumplirContratoA.rpt")
                        Reporte.Load(reportPath)
                        Reporte.DataDefinition.FormulaFields(5).Text = "'Contrato'"
                    Case 2
                        reportPath = Server.MapPath("RptIncumplirAlmacenA.rpt")
                        Reporte.Load(reportPath)
                        Reporte.DataDefinition.FormulaFields(5).Text = "'Almacen'"
                    Case 3
                        reportPath = Server.MapPath("RptIncumplirProveedorA.rpt")
                        Reporte.Load(reportPath)
                        Reporte.DataDefinition.FormulaFields(5).Text = "'Proveedor'"
                End Select

                Reporte.DataDefinition.FormulaFields(4).Text = "'Entregas con Atraso'"
            Case 1
                Select Case Request.QueryString("TipoC")
                    Case 0
                        reportPath = Server.MapPath("RptIncumplirProductoN.rpt")
                        Reporte.Load(reportPath)
                        Reporte.DataDefinition.FormulaFields(5).Text = "'Producto'"
                    Case 1
                        reportPath = Server.MapPath("RptIncumplirContratoN.rpt")
                        Reporte.Load(reportPath)
                        Reporte.DataDefinition.FormulaFields(5).Text = "'Contrato'"
                    Case 2
                        reportPath = Server.MapPath("RptIncumplirAlmacenN.rpt")
                        Reporte.Load(reportPath)
                        Reporte.DataDefinition.FormulaFields(5).Text = "'Almacen'"
                    Case 3
                        reportPath = Server.MapPath("RptIncumplirProveedorN.rpt")
                        Reporte.Load(reportPath)
                        Reporte.DataDefinition.FormulaFields(5).Text = "'Proveedor'"
                End Select
                Reporte.DataDefinition.FormulaFields(4).Text = "'Entregas No Realizadas'"
        End Select

        Dim cPC As New cPROCESOCOMPRAS
        Dim ds As New DataSet
        cPC.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("IdProc"), ds)

        Reporte.DataDefinition.FormulaFields(0).Text = "'" & ds.Tables(0).Rows(0).Item(0) & "'"
        Reporte.DataDefinition.FormulaFields(1).Text = "'" & ds.Tables(0).Rows(0).Item(1) & "'"
        Reporte.DataDefinition.FormulaFields(2).Text = "'" & ds.Tables(0).Rows(0).Item(3) & "'"
        Reporte.DataDefinition.FormulaFields(3).Text = "'" & ds.Tables(0).Rows(0).Item(4) & "'"

        Reporte.Load(reportPath)

        Reporte.SetDataSource(Me.Session("dsRecepciones"))
        'parametros de reporte como campos de formula

        'muestra reporte
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
        'al inicializar
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Me.Session.Remove("dsRecepciones")
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
