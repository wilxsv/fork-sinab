Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptCapturaCEHospital
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim mesesArr() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("fecha") Is Nothing Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        End If

        'If Session.Item("idEstablecimiento") <> Request.QueryString("idEstablecimiento") Then
        '    Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        'End If

        Dim fecha As String = Request.QueryString("fecha")

        If fecha.IndexOf("/") <= 0 Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        End If

        Dim s() As String = fecha.Split("/")

        If Not IsNumeric(s(0)) Or Not IsNumeric(s(1)) Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False)
        End If

        If CInt(s(0)) < 1 Or CInt(s(0)) > 12 Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False)
        End If

        Reporte = New ReportDocument
        Dim reportPath As String

        reportPath = Server.MapPath("rptCapturaCEHospital.rpt")

        Reporte.Load(reportPath)

        Dim cEntidad As New cCONSUMOS

        'Obtenemos el detalle del proceso de compras

        Dim ds As Data.DataSet

        Dim fecha1 As Date = New Date(s(1), s(0), 1)
        Dim fecha2 As Date = DateAdd(DateInterval.Month, -2, fecha1)

        ds = cEntidad.obtenerCodigosCapturadosConsumoIntervalo(fecha1)
        Reporte.SetDataSource(ds.Tables(0))

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        ''Establecimiento
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "periodo"
        disVal.Value = mesesArr(fecha2.Month - 1) & "/" & fecha2.Year & " a " & mesesArr(fecha1.Month - 1) & "/" & fecha1.Year
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)

        ''Programacion
        'pField = New ParameterField
        'disVal = New ParameterDiscreteValue

        'pField.ParameterFieldName = "nprogramacion"
        'disVal.Value = eEntidad.DESCRIPCION          'Set the discrete Value
        'pField.CurrentValues.Add(disVal)

        'pFields.Add(pField)

        ''Ultimo parametro
        'pField = New ParameterField
        'disVal = New ParameterDiscreteValue

        'pField.ParameterFieldName = "nprograma"
        'disVal.Value = ""           'Set the discrete Value
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
