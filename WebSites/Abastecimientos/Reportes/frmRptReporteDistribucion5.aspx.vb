Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptReporteDistribucion5
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        'If Request.QueryString("id") Is Nothing Or Request.QueryString("id") Is Nothing Then

        '    Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        'End If



        'Dim idoc As Integer = Request.QueryString("id")
        ' Dim idEstablecimiento As Integer = IIf(Session("IdEstablecimiento") = 619, 620, Session("IdEstablecimiento"))

        ''   Dim m As Integer = Request.QueryString("m")

        Reporte = New ReportDocument
        Dim reportPath As String

        'If Request.QueryString("tipo") = 7 Then
        '    reportPath = Server.MapPath("RptProgramacionCompraRequisicion.rpt")
        'Else
        reportPath = Server.MapPath("RptReporteDistribucion4.rpt")
        ' End If


        Reporte.Load(reportPath)

        'Obtenemos el detalle del proceso de compras
        'Dim cEntidad As New cPROGRAMACION
        'Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(idProceso)

        Dim ides As Integer
        ides = IIf(Session("Idestablecimiento") = 619, 620, Session("Idestablecimiento"))

        Dim x As New cDistribucion

        Dim ds As Data.DataSet
        ds = x.ObtenerReporteDistribucion4(ides, Request.QueryString("anio"))

        Reporte.SetDataSource(ds.Tables(0))

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        ''Primer parametro
        'pField = New ParameterField
        'disVal = New ParameterDiscreteValue

        'pField.ParameterFieldName = "establecimiento"
        'disVal.Value = "Establecimiento: " & Session.Item("UsuarioEstablecimiento")         'Set the discrete Value
        'pField.CurrentValues.Add(disVal)

        'pFields.Add(pField)

        ''Segundo parametro
        'pField = New ParameterField
        'disVal = New ParameterDiscreteValue

        'pField.ParameterFieldName = "m"
        'disVal.Value = m         'Set the discrete Value
        'pField.CurrentValues.Add(disVal)

        'pFields.Add(pField)

        'Tercer parametro
        'pField = New ParameterField
        'disVal = New ParameterDiscreteValue

        'pField.ParameterFieldName = "nprogramacion"
        'disVal.Value = eEntidad.DESCRIPCION          'Set the discrete Value
        'pField.CurrentValues.Add(disVal)

        'pFields.Add(pField)

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
