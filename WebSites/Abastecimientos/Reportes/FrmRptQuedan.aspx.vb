'ELABORAR QUEDAN
'CU-UACI030
'Ing. Yessenia Pennelope Henriquez Duran
'quedan generado

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Reportes_FrmRptQuedan
    Inherits System.Web.UI.Page

    'declaracion e incializacion
    Dim lId As Int64
    Dim lIdProv, lIdGarant, lIdQuedan, lidTipocompra, lidGarantiacontrato As Int32
    Dim compra As String
    Dim tituloQuedan As String
    Dim ds As DataSet
    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()
        'carga de reporte
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptQuedan.rpt") 'nombre de reporte

        lId = Session.Item("idContRep") 'identificador de contrato


        lIdProv = Session.Item("idProvRep") 'identificador de proveedor
        lIdGarant = Session.Item("idGarantRep") 'identificador de garantia
        lIdQuedan = Session.Item("idQuedanRep") 'identificador de quedan
        lidTipocompra = Session.Item("idtipocompra") 'identificador de tipo de compra
        lidGarantiacontrato = Session.Item("idGarantiaContrato") 'identificadorgarantiacontrato

        Select Case lidTipocompra 'tipo de compra
            Case Is = 1
                compra = "Licitacion Publica"
            Case Is = 2
                compra = "Licitacion Publica"
            Case Is = 3
                compra = "Solicitud de Cotización"
            Case Is = 4
                compra = "Solicitud de Cotización"
            Case Is = 5
                compra = "Solicitud de Cotización"
        End Select

        Reporte.Load(reportPath)

        Dim mComponente As New cQUEDANS
        Dim mEntidad As New QUEDANS
        Dim DstRptQuedan As DataSet
        'llena dataset
        DstRptQuedan = mComponente.DatasetReporteQuedan(Session.Item("IdEstablecimiento"), lId, lIdGarant, lIdProv, lIdQuedan, lidGarantiacontrato)

        Reporte.SetDataSource(DstRptQuedan.Tables(0))


        If Session.Item("idTipoEstablecimiento") = 3 Then
            tituloQuedan = Session.Item("UsuarioEstablecimiento")
        Else
            tituloQuedan = "Direccion de Abastecimientos"
        End If

        'parmaetros como campos formula
        Reporte.DataDefinition.FormulaFields("TipoCompra").Text = "'" & compra & "'"
        Reporte.DataDefinition.FormulaFields("TituloQuedan").Text = "'" & tituloQuedan & "'"

        'muestra reeporte
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
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
