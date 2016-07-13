Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptProgramacion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("idProceso") Is Nothing Or Request.QueryString("idEstablecimiento") Is Nothing Or _
           Request.QueryString("m") Is Nothing Or Request.QueryString("n") Is Nothing Or Request.QueryString("tipo") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        'If Session.Item("idEstablecimiento") <> Request.QueryString("idEstablecimiento") Then
        '    Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        'End If

        Dim idProceso As Integer = Request.QueryString("idProceso")
        Dim idEstablecimiento As Integer = Request.QueryString("idEstablecimiento")
        Dim m As Integer = Request.QueryString("m")
        Dim n As Integer = Request.QueryString("n")
        Dim tipo As Integer = Request.QueryString("tipo")

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

        'Obtenemos el detalle del proceso de compras
        Dim cEntidad As New cPROGRAMACION
        Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(idProceso)

        Dim ds As Data.DataSet
        ds = x.obtenerProgramacionProductosDetalle(idProceso, idEstablecimiento, m, n, IIf(tipo > 4, 2, IIf(tipo = 4, 3, 1)), IIf(tipo = 3, True, False))
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

        'Programacion
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
        disVal.Value = ""           'Set the discrete Value
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
