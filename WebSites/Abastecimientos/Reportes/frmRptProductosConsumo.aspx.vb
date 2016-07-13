Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_frmRptProductosConsumo
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        Dim idEstablecimiento As Integer = Session.Item("idEstablecimiento")
        Dim tipo As Integer = 0

        If Not Request.QueryString("tipo") Is Nothing Then
            If Request.QueryString("tipo") = "1" Then
                tipo = 1
            End If
        End If

        Reporte = New ReportDocument
        Dim reportPath As String

        Select Case tipo
            Case 0
                reportPath = Server.MapPath("RptProductosConsumoAlmacen.rpt")
            Case Else
                reportPath = Server.MapPath("RptProductosConsumoFarmacia.rpt")
        End Select

        Reporte.Load(reportPath)

        Dim cEntidad As New cPRODUCTOSESTABLECIMIENTOS

        
        Dim ds As Data.DataSet
        ds = cEntidad.obtenerListaProductosEstablecimientos(idEstablecimiento)

        Reporte.SetDataSource(ds.Tables(0))

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        'Establecimiento
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "establecimiento"
        disVal.Value = "Establecimiento: " & Session.Item("UsuarioEstablecimiento")         'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)

        Me.crvPrincipal.ParameterFieldInfo = pFields

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

End Class
