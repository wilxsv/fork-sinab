Imports CrystalDecisions.Web.Services
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
'Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRptNivelAbastecimientoProductos
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptNivelEstablecimientoProductos.rpt")
        Reporte.Load(reportPath)

        Dim idsemana, idsuministro, idhospital, idprograma As Integer

        idsemana = CType(Request.QueryString("idSe"), Integer)
        idsuministro = CType(Request.QueryString("idS"), Integer)
        idhospital = CType(Request.QueryString("idH"), Integer)

        Dim establecimiento = Establecimientos.Obtener(idhospital).FirstOrDefault().NOMBRE
        'Dim CS As New cSUMINISTROS
        'Dim cA As New cALMACENES

        Dim pFields As New ParameterFields()

        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "SUMINISTRO"
        pDiscreteValue1.Value = Suministros.Obtener(idsuministro).DESCRIPCION 'CS.DevolverDescSuministro(idsuministro)
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "SEMANA"
        'pDiscreteValue2.Value = "Semana " & cA.ObtenerSemana(DateTime.Now) - 1 & ": " & cA.ObtenerDatosSemana(IDSEMANA)
        pDiscreteValue2.Value = SINAB_Utils.Semana.ObtenerInformacion(DateTime.Now.Year, idsemana)
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim usr = Membresia.ObtenerUsuario()
        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "HOSPITAL"
        pDiscreteValue3.Value = establecimiento
        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)

        Dim ds = ProductoSinExistencia.ReporteDesabastecidos(idhospital, idsuministro, DateTime.Now.Year, idsemana)

        ' ds = cA.ObtenerNivelAbastecimientoProductos(IDSEMANA, IDSUMINISTRO, IDHOSPITAL)

        Me.crvPrincipal.ParameterFieldInfo = pFields

        Reporte.SetDataSource(ds)

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
