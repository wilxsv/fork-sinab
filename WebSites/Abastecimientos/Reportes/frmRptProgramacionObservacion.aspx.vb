Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptProgramacionObservacion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        If Session.Item("UsuarioRol") Is Nothing Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        End If

        If Request.QueryString("idProceso") Is Nothing Or Request.QueryString("idEstablecimiento") Is Nothing Or _
           Request.QueryString("idProducto") Is Nothing Or Request.QueryString("tipo") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        If (Not IsNumeric(Request.QueryString("idProceso"))) Or (Not IsNumeric(Request.QueryString("idEstablecimiento"))) Or _
           (Not IsNumeric(Request.QueryString("idProducto"))) Or (Not IsNumeric(Request.QueryString("tipo"))) Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idProceso As Integer = Request.QueryString("idProceso")
        Dim idEstablecimiento As Integer = Request.QueryString("idEstablecimiento")
        Dim idProducto As Integer = Request.QueryString("idProducto")
        Dim tipo As Integer = Request.QueryString("tipo")

        Dim Entidad As New PROGRAMACIONPRODUCTO
        Dim cEntidad As New cPROGRAMACION
        Entidad.IDESTABLECIMIENTO = idEstablecimiento
        Entidad.IDPROGRAMACION = idProceso
        Entidad.IDPRODUCTO = idProducto
        Entidad.TIPOOBSERVACION = tipo

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptObservacionProgramacion.rpt")

        Reporte.Load(reportPath)

        Dim x As New cPROGRAMACIONPRODUCTO
        Dim x2 As New cPROGRAMACION

        'Obtenemos el detalle del proceso de compras
        Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(idProceso)

        Dim ds As Data.DataSet
        ds = x2.obtenerListaObservaciones(Entidad)
        Reporte.SetDataSource(ds.Tables(0))

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        'Programacion
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "nprogramacion"
        disVal.Value = eEntidad.DESCRIPCION          'Set the discrete Value
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
