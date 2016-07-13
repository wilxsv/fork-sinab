Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptInformeMuestras
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = ""

        Dim IDESTABLECIMIENTO, IDINFORME, IDTIPOINFORME As Integer
        Dim Certificacion As String
        IDESTABLECIMIENTO = Request.QueryString("idE")
        IDINFORME = Request.QueryString("idI")
        IDTIPOINFORME = Request.QueryString("idTI")
        Certificacion = Request.QueryString("C")

        If Certificacion = Boolean.TrueString.ToLower Then
            reportPath = Server.MapPath("RptInformeControlCalidad.rpt")
        Else
            Select Case IDTIPOINFORME
                Case eTIPOINFORME.ACEPTACION
                    reportPath = Server.MapPath("RptInformeMuestrasAceptacion.rpt")
                Case eTIPOINFORME.RECHAZO
                    reportPath = Server.MapPath("RptInformeMuestrasNoAceptacion3.rpt")
                Case eTIPOINFORME.NOINSPECCION
                    reportPath = Server.MapPath("RptInformeMuestrasNoInspeccion.rpt")
                Case 0
                    reportPath = Server.MapPath("RptInformeMuestras.rpt")
                Case Else
                    'error
                    Return
            End Select
        End If

        Reporte.Load(reportPath)

        Dim cIM As New cINFORMEMUESTRAS

        Dim Modificativas As String
        Modificativas = cIM.ObtenerModificativas(IDESTABLECIMIENTO, IDINFORME)

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "MODIFICATIVAS"
        pDiscreteValue1.Value = Modificativas
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "Usuario"
        pDiscreteValue2.Value = Session.Item("NombreUsuario")
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim ds As Data.DataSet
        ds = cIM.RptInformeMuestras(IDESTABLECIMIENTO, IDINFORME)

        'se adiciona para pasar parametro de fecha de notificación de inspección

        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "fechasolins"
        pDiscreteValue3.Value = ds.Tables(0).Rows(0).Item("FECHANOTIFICACION")
        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)




        'If Reporte.Subreports.Count > 0 Then
        '    Reporte.SetDataSource(ds)
        '    Reporte.Subreports.Item(0).SetDataSource(ds.Tables(1))
        'Else
        Reporte.SetDataSource(ds.Tables(0))
        'End If

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

        ' Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

        'Me.crvPrincipal.EnableDatabaseLogonPrompt = False
        'Me.crvPrincipal.EnableParameterPrompt = False

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
