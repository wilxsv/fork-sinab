Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class Reportes_frmRptProgramacionPorProducto
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("idProceso") Is Nothing Or Request.QueryString("idProducto") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idProceso As Integer = Request.QueryString("idProceso")
        Dim idProducto As Integer = Request.QueryString("idProducto")
        Dim idPrograma As Integer = 0
        Dim tipo As Integer = 0

        If Not IsNothing(Request.QueryString("idPrograma")) Then
            idPrograma = Request.QueryString("idPrograma")
        End If

        If Not IsNothing(Request.QueryString("tipo")) Then
            tipo = 1
        End If

        Reporte = New ReportDocument
        Dim reportPath As String

        If tipo = 0 Then
            reportPath = Server.MapPath("RptProgramacionCompra7.rpt")
        Else
            reportPath = Server.MapPath("RptProgramacionCompra12.rpt")
        End If


        Reporte.Load(reportPath)

        Dim x As New cPROGRAMACIONPRODUCTO

        Dim ds As Data.DataSet
        ds = x.obtenerProgramacionDetallePorProducto(idProceso, idProducto, idPrograma)

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
            disVal.Value = "Sin incluir medicamentos de programas"
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
