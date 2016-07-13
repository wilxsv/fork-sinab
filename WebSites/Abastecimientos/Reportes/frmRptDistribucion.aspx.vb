Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports CrystalDecisions.Shared.Json
Imports SINAB_Entidades.Helpers

Partial Class Reportes_frmRptDistribucion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("id") Is Nothing Or Request.QueryString("tipo") Is Nothing Or Request.QueryString("est") Is Nothing Or Request.QueryString("prod") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idDistribucion As Integer = CType(Request.QueryString("id"), Integer)
        Dim tipo As Integer = CType(Request.QueryString("tipo"), Integer)
        Dim idEst As Integer = CType(Request.QueryString("est"), Integer)
        Dim idProd As Integer = CType(Request.QueryString("prod"), Integer)
        Dim idguarda As Integer = CType(Request.QueryString("guarda"), Integer)
        Dim elaboroDist As Boolean = False
        If Not String.IsNullOrEmpty(Request.QueryString("elaborodist")) Then
            elaboroDist = CType(Request.QueryString("elaborodist"), Boolean)
        End If


        Reporte = New ReportDocument
        Dim reportPath As String

        Select Case tipo
            Case 11
                reportPath = Server.MapPath("rptDistribucionEstablecimientos22.rpt")
            Case 1
                'reportPath = Server.MapPath("rptDistribucionProductos.rpt")
                reportPath = Server.MapPath("rptDistribucionEstablecimientos2.rpt")
            Case Else
                reportPath = Server.MapPath("rptDistribucionEstablecimientos2.rpt")

        End Select

        If idguarda <> 0 Then
            reportPath = Server.MapPath("rptDistribucionEstablecimientos2.rpt")
        End If

        Reporte.Load(reportPath)

        Dim x As New cDistribucion

        'Obtenemos el detalle del proceso de compras

        Dim ds As Data.DataSet


        'todo : el establecimiento esta fijo a 620, se cambiara por el establecimiento del usuario
        Dim usr = Membresia.ObtenerUsuario()
        If idguarda <> 0 Then
            Dim df = EstablecimientoHelpers.DistribucionFechaEntrega.ObtenerFecha(idDistribucion, usr.Establecimiento.IDESTABLECIMIENTO, idEst)

            ds = x.obtenerRptDistribucion(idDistribucion, usr.Establecimiento.IDESTABLECIMIENTO, tipo, idProd, idEst)
            Dim pField As New ParameterField()
            Dim disVal As New ParameterDiscreteValue()
            If Not IsNothing(ds) Then
                disVal.Value = df
            Else
                disVal = Nothing
            End If
            'x.ObtenerFechaEntregaDistribucion(idDistribucion, usr.Establecimiento.IDESTABLECIMIENTO, idEst)
            pField.ParameterFieldName = "FechaEntrega"
            pField.CurrentValues.Add(disVal)
            crvPrincipal.ParameterFieldInfo.Add(pField)
        Else
            If elaboroDist Then
                ds = x.obtenerRptDistribucion(idDistribucion, idEst, tipo, idProd, usr.Establecimiento.IDESTABLECIMIENTO)
            Else
                ds = x.obtenerRptDistribucion(idDistribucion, usr.Establecimiento.IDESTABLECIMIENTO, tipo, idProd, idEst)
            End If

        End If

        Reporte.SetDataSource(ds.Tables(0))

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
