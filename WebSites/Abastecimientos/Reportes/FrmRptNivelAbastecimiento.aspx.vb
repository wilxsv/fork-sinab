Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils


Partial Class FrmRptNivelAbastecimiento
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptNivelEstablecimiento.rpt")
        Reporte.Load(reportPath)

        Dim idsemana, idsuministro, anio, idprograma As Integer

        idsemana = CType(Request.QueryString("idSe"), Integer)
        idsuministro = CType(Request.QueryString("idS"), Integer)
        anio = CType(Request.QueryString("idA"), Integer)
        idprograma = CType(Request.QueryString("idP"), Integer)

        'Dim CS As New cSUMINISTROS
        Dim cA As New cALMACENES

        Dim pFields As New ParameterFields()

        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "SUMINISTRO"
        pDiscreteValue1.Value = Suministros.Obtener(idsuministro).DESCRIPCION
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "SEMANA"
        pDiscreteValue2.Value = Semana.ObtenerInformacion(anio, idsemana)
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim inicioSemana = Semana.FechaInicio(anio, idsemana)
        Dim ds = New List(Of prc_DesabastecimientoAlmacenLocal_Result)
        Dim res = Almacen.ObtenerTodosConCuandroBasico()

        If Not IsNothing(idprograma) And idprograma > 0 Then
            ds.AddRange(From itm In res Select obj = ProductoAlmacen.ObtenerDesabastecimiento(itm.IdAlmacen, idsuministro, idprograma, idsemana, inicioSemana, anio).FirstOrDefault() Where Not IsNothing(obj))
        Else
            ds.AddRange(From itm In res Select obj = ProductoAlmacen.ObtenerDesabastecimiento(itm.IdAlmacen, idsuministro, idsemana, inicioSemana, anio).FirstOrDefault() Where Not IsNothing(obj))
        End If


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
