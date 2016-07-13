Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_FrmRptConsumo
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument
    Private fechas() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("mes") Is Nothing Or Request.QueryString("anio") Is Nothing Or Session.Item("idEstablecimiento") Is Nothing Or _
           Request.QueryString("tipo") Is Nothing Or Request.QueryString("est") Is Nothing Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        End If

        If Not IsNumeric(Request.QueryString("mes")) Or Not IsNumeric(Request.QueryString("anio")) Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False)
        End If

        If CInt(Request.QueryString("mes")) < 1 Or CInt(Request.QueryString("mes")) > 12 Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False)
        End If

        Dim fecha As Date = New Date(Request.QueryString("anio"), Request.QueryString("mes"), 1)
        Dim idEstablecimiento As Integer = Session.Item("idEstablecimiento")
        Dim idAlmacen As Integer = Request.QueryString("est")
        Dim tipo As Integer = Request.QueryString("tipo")
        Dim idprograma As Integer = Request.QueryString("idprog")
        Dim ds2 As Data.DataSet

        If idAlmacen <> 0 Then
            Dim cEntidadA As New cALMACENES
            ds2 = cEntidadA.FiltroAlmacenPorId(idAlmacen)

            If ds2 Is Nothing Then
                Response.Write("No tiene permisos para ver el reportes")
                Exit Sub
            End If

            If ds2.Tables(0).Rows.Count = 0 Then
                Response.Write("No tiene permisos para ver el reportes")
                Exit Sub
            End If
        End If


        Reporte = New ReportDocument

        Dim reportPath As String

        If tipo = 0 Then
            reportPath = Server.MapPath("rptConsumoAlmacen.rpt")
        ElseIf tipo = -1 Then
            If Not Request.QueryString("c") Is Nothing Then
                reportPath = Server.MapPath("rptConsumosCobertura.rpt")
            Else
            reportPath = Server.MapPath("rptConsumos.rpt")
            End If
        Else
            reportPath = Server.MapPath("rptConsumoFarmacia.rpt")
        End If

        Reporte.Load(reportPath)

        Dim cEntidad As New cCONSUMOS

        Dim ds As Data.DataSet
        'Arreglar despues
        If tipo <> -1 Then
            ds = cEntidad.obtenerConsumoEstablecimientoFecha(Session.Item("idEstablecimiento"), idAlmacen, fecha, idAlmacen, "inner", idprograma)
        Else
            ds = cEntidad.obtenerConsumoTotalFecha(Session.Item("idEstablecimiento"), fecha, "inner", idprograma)
        End If

        Reporte.SetDataSource(ds.Tables(0))

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        'Establecimiento
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "establecimiento"
        disVal.Value = Session.Item("UsuarioEstablecimiento")         'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)

        'Fecha
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "fecha"
        disVal.Value = fechas(CInt(Request.QueryString("mes")) - 1) & "/" & Request.QueryString("anio")          'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)

        'Almacen
        If tipo <> -1 Then
            pField = New ParameterField
            disVal = New ParameterDiscreteValue

            pField.ParameterFieldName = "almacen"
            disVal.Value = ds2.Tables(0).Rows(0).Item("NOMBRE")
            pField.CurrentValues.Add(disVal)

            pFields.Add(pField)
        End If

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
