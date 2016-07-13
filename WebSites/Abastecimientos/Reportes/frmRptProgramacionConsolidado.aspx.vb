Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptProgramacionConsolidado
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("idProceso") Is Nothing Or Request.QueryString("tipo") Is Nothing Or Request.QueryString("idPrograma") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idProceso As Integer = Request.QueryString("idProceso")
        Dim tipo As Integer = Request.QueryString("tipo")
        Dim idPrograma As Integer = Request.QueryString("idPrograma")

        Reporte = New ReportDocument
        Dim reportPath As String

        Select Case tipo
            Case 1
                reportPath = Server.MapPath("RptProgramacionCompra1.rpt")
            Case 2
                reportPath = Server.MapPath("RptProgramacionCompra2.rpt")
            Case 3
                reportPath = Server.MapPath("RptProgramacionCompra3.rpt")
            Case 4
                reportPath = Server.MapPath("RptProgramacionCompra4.rpt")
            Case Else
                reportPath = Server.MapPath("RptProgramacionCompra6.rpt")
        End Select

        Reporte.Load(reportPath)

        Dim x As New cPROGRAMACIONPRODUCTO

        Dim ds As Data.DataSet
        ds = x.obtenerProgramacionProductosConsolidado(idProceso, IIf(tipo = 3, True, False), idPrograma)

        'Obtenemos el detalle del proceso de compras
        Dim cEntidad As New cPROGRAMACION
        Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(idProceso)

        'Obtenemos el detalle del programa
        Dim cEntidad2 As New cPROGRAMAS
        Dim eEntidad2 As New PROGRAMAS

        eEntidad2.IDPROGRAMA = idPrograma

        cEntidad2.recuperar(eEntidad2)

        Reporte.SetDataSource(ds.Tables(0))

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        'Establecimiento
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "establecimiento"
        disVal.Value = "Reporte Consolidado a Nivel Nacional"         'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)


        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "nprogramacion"
        disVal.Value = eEntidad.DESCRIPCION          'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)

        'Ultimo parametro
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "nprograma"

        If idPrograma = -1 Then
            disVal.Value = "No se incluyen medicamentos de programas"           'Set the discrete Value
        Else
        disVal.Value = IIf(eEntidad2.NOMBRE Is Nothing, "", eEntidad2.NOMBRE)           'Set the discrete Value
        End If

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
