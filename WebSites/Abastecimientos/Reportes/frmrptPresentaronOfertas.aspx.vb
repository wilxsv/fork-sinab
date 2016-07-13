Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.UACIHelpers

Partial Class Reportes_frmrptPresentaronOfertas
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument

    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfiguracionReporte()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptPresentaronOfertas.rpt")
        Reporte.Load(reportPath)

        
        Dim idestablecimiento =Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        Dim idprocesocompra = CType(Request.QueryString("id"), Integer)

    

        dim ds = RecepcionOferta.ObtenerTodos(idestablecimiento, idprocesocompra)
        Dim dspc = ProcesoCompras.ObtenerBase(idestablecimiento, idprocesocompra)

        AgregarParametro("Descripcion", dspc.DescripcionLicitacion)
        AgregarParametro("Modalidad", dspc.Modalidad)
        AgregarParametro("Codigo", dspc.CodigoLicitacion)
        AgregarParametro("fechaHoraInicio", dspc.FechaHoraInicioRecepcion.ToString())
        Agregarparametro("fechaHoraFin", dspc.FechaHoraFinRecepcion.ToString())


        Reporte.SetDataSource(ds.ToList())
        'Reporte.Subreports(0).SetDataSource(ds.Tables(0))

        Me.crvPrincipal.ReportSource = Reporte
        Me.crvPrincipal.ParameterFieldInfo = paramFields

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

    Private Sub AgregarParametro(ByVal nombreParametro As String, ByVal valorparametro As Object)
        paramField = new ParameterField()
        paramField.ParameterFieldName =nombreParametro
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = valorparametro
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfiguracionReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
