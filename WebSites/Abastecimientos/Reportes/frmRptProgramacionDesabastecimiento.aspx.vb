Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptProgramacionDesabastecimiento
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("idProceso") Is Nothing Or Request.QueryString("m") Is Nothing Or Request.QueryString("tipo") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idProceso As Integer = Request.QueryString("idProceso")
        Dim m As Integer = Request.QueryString("m")
        Dim tipo As Integer = Request.QueryString("tipo")

        Dim idPrograma As Integer = 0

        If Not IsNothing(Request.QueryString("idPrograma")) Then
            idPrograma = Request.QueryString("idPrograma")
        End If

        Reporte = New ReportDocument
        Dim reportPath As String

        If tipo = 1 Then
            reportPath = Server.MapPath("RptProgramacionCompra8.rpt")
        Else
            reportPath = Server.MapPath("RptProgramacionCompra9.rpt")
        End If

        Reporte.Load(reportPath)

        Dim x As New cPROGRAMACIONPRODUCTO

        Dim ds As Data.DataSet
        ds = x.obtenerDesabastecimientoConsolidado(idProceso, m, idPrograma)

        Reporte.SetDataSource(ds.Tables(0))

        'Obtenemos el detalle del proceso de compras
        Dim cEntidad As New cPROGRAMACION
        Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(idProceso)

        'Obtenemos el detalle del programa
        Dim cEntidad2 As New cPROGRAMAS
        Dim eEntidad2 As New PROGRAMAS

        eEntidad2.IDPROGRAMA = idPrograma

        cEntidad2.recuperar(eEntidad2)

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        'Establecimiento
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "establecimiento"
        disVal.Value = "Consolidado a Nivel Nacional"         'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)


        '
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "nprogramacion"
        disVal.Value = eEntidad.DESCRIPCION          'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)


        '
        'Ultimo parametro
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "nprograma"
        disVal.Value = IIf(eEntidad2.NOMBRE Is Nothing, "", eEntidad2.NOMBRE)           'Set the discrete Value
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
