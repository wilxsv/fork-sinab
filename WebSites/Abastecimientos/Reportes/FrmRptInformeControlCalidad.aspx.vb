Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Linq
Imports SINAB_Entidades.Helpers

Partial Class Reportes_FrmRptInformeControlCalidad
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportpath As String = ""

        Dim idestablecimiento, idinforme, idtipoinforme As Integer
        idestablecimiento = CType(Request.QueryString("idE"), Integer)
        idinforme = CType(Request.QueryString("idI"), Integer)
        idtipoinforme = CType(Request.QueryString("idT"), Integer)

        Select Case idtipoinforme
            Case 1
                'reportpath = Server.MapPath("RptInformeMuestrasAceptacion.rpt")
                reportpath = Server.MapPath("RptInformeControlCalidad.rpt")
            Case 2
                reportpath = Server.MapPath("RptInformeMuestrasNoAceptacion.rpt")
            Case 3
                reportpath = Server.MapPath("RptInformeMuestrasNoInspeccion.rpt")
            Case Else
                'error
        End Select

        Reporte.Load(reportpath)

        Dim ds = LabHelpres.Notificaciones.ObtenerTodos(idinforme, idestablecimiento).ToList() 'cIM.RptInformeMuestras2(IDESTABLECIMIENTO, IDINFORME)
        Dim primero = ds.FirstOrDefault()

        Dim pFields As New ParameterFields()

        'Dim pField1 As New ParameterField()
        'Dim pDiscreteValue1 As New ParameterDiscreteValue()
        'pField1.ParameterFieldName = "COMPROBANTECREDITOFISCAL"
        'pDiscreteValue1.Value = primero.COMPROBANTECREDITOFISCAL ' ds.Tables(0).Rows(0).Item("COMPROBANTECREDITOFISCAL")
        'pField1.CurrentValues.Add(pDiscreteValue1)
        'pFields.Add(pField1)

        'Dim pField2 As New ParameterField()
        'Dim pDiscreteValue2 As New ParameterDiscreteValue()
        'pField2.ParameterFieldName = "LUGARINSPECCION"
        'pDiscreteValue2.Value = primero.LUGARINSPECCION 'ds.Tables(0).Rows(0).Item("LUGARINSPECCION")
        'pField2.CurrentValues.Add(pDiscreteValue2)
        'pFields.Add(pField2)

        If Not String.IsNullOrEmpty(primero.FECHANOTIFICACION) Then
            Dim pField3 As New ParameterField()
            Dim pDiscreteValue3 As New ParameterDiscreteValue()
            pField3.ParameterFieldName = "fechaNoti"
            pDiscreteValue3.Value = primero.FECHANOTIFICACION ' ds.Tables(0).Rows(0).Item("FECHANOTIFICACION")
            pField3.CurrentValues.Add(pDiscreteValue3)
            pFields.Add(pField3)
        End If

        Dim pField15 As New ParameterField()
        Dim pDiscreteValue15 As New ParameterDiscreteValue()
        pField15.ParameterFieldName = "fechaFab"
        If Not String.IsNullOrEmpty(primero.FECHAFABRICACION) Then
            pDiscreteValue15.Value = String.Format("{0:MM/yyyy}", CDate(primero.FECHAFABRICACION)) 'ds.Tables(0).Rows(0).Item("numerocssp")           
        Else
            pDiscreteValue15.Value = "--"
        End If
        pField15.CurrentValues.Add(pDiscreteValue15)
        pFields.Add(pField15)

        Dim pField25 As New ParameterField()
        Dim pDiscreteValue25 As New ParameterDiscreteValue()
        pField25.ParameterFieldName = "fechaVen"
        If Not String.IsNullOrEmpty(primero.FECHAVENCIMIENTO) Then
            pDiscreteValue25.Value = String.Format("{0:MM/yyyy}", CDate(primero.FECHAVENCIMIENTO)) 'ds.Tables(0).Rows(0).Item("numerocssp")
        Else
            pDiscreteValue25.Value = "--"
        End If
        pField25.CurrentValues.Add(pDiscreteValue25)
        pFields.Add(pField25)

        Reporte.SetDataSource(ds)

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
