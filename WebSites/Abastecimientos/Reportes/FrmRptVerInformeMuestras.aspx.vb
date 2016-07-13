Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports SINAB_Entidades.Helpers

Partial Class Reportes_FrmRptVerInformeMuestras
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = ""

        Dim IDESTABLECIMIENTO, IDINFORME, IDTIPOINFORME As Integer
        Dim ESTABLECIMIENTOREMITE As String
        ESTABLECIMIENTOREMITE = Request.QueryString("lins")
       
        IDESTABLECIMIENTO = CType(Request.QueryString("idE"), Integer)
        IDINFORME = CType(Request.QueryString("idI"), Integer)
        'IDTIPOINFORME = Request.QueryString("idT")
        Dim ds = LabHelpres.Notificaciones.ObtenerTodos(IDINFORME, IDESTABLECIMIENTO).ToList() 'cIM.RptInformeMuestras2(IDESTABLECIMIENTO, IDINFORME)
        Dim primero = ds.FirstOrDefault()
        IDTIPOINFORME = primero.IDTIPOINFORME
       
        Select Case IDTIPOINFORME
            Case eTIPOINFORME.ACEPTACION
                ''reportPath = Server.MapPath("RptInformeMuestrasAceptacion2.rpt")
                reportPath = Server.MapPath("RptInformeMuestrasAceptacion.rpt")
            Case eTIPOINFORME.RECHAZO
                reportPath = Server.MapPath("RptInformeMuestrasrechazado.rpt")
                'reportPath = Server.MapPath("RptInformeMuestrasNoAceptacion3.rpt")
            Case eTIPOINFORME.NOINSPECCION
                reportPath = Server.MapPath("RptInformeMuestrasNoInspeccion.rpt")
            Case 0
                ''reportPath = Server.MapPath("RptInformeMuestras2.rpt")
                reportPath = Server.MapPath("RptInformeMuestrasAceptacion.rpt")

            Case Else
                'error
                Return
        End Select


        Reporte.Load(reportPath)

        ' Dim cIM As New cINFORMEMUESTRAS
        Dim pFields As New ParameterFields()

        Dim modificativas = LabHelpres.Notificaciones.ObtenerModificativas(IDESTABLECIMIENTO, IDINFORME) 'cIM.ObtenerModificativas(IDESTABLECIMIENTO, IDINFORME)
        If Not IsNothing(modificativas) Then
            Dim pField1 As New ParameterField()
            Dim pDiscreteValue1 As New ParameterDiscreteValue()
            pField1.ParameterFieldName = "MODIFICATIVAS"
            pDiscreteValue1.Value = modificativas
            pField1.CurrentValues.Add(pDiscreteValue1)
            pFields.Add(pField1)

            Dim pField2 As New ParameterField()
            Dim pDiscreteValue2 As New ParameterDiscreteValue()
            pField2.ParameterFieldName = "Usuario"
            pDiscreteValue2.Value = Session.Item("NombreUsuario")
            pField2.CurrentValues.Add(pDiscreteValue2)
            pFields.Add(pField2)
        End If
        
        ''Dim ds As Data.DataSet
        ''ds = cIM.RptInformeMuestras2(IDESTABLECIMIENTO, IDINFORME)
         If Not String.IsNullOrEmpty(primero.IDPROVEEDOR) Then
            Dim pField7 As New ParameterField()
            Dim pDiscreteValue7 As New ParameterDiscreteValue()
            pField7.ParameterFieldName = "proveedor"
            pDiscreteValue7.Value = catalogohelpers.proveedores.Obtener(primero.IDPROVEEDOR).Nombre 'ds.Tables(0).Rows(0).Item("FECHAELABORACIONINFORME")
            pField7.CurrentValues.Add(pDiscreteValue7)
            pFields.Add(pField7)
        End If

        If Not String.IsNullOrEmpty(primero.COMPROBANTECREDITOFISCAL) Then
            Dim pField4 As New ParameterField()
            Dim pDiscreteValue4 As New ParameterDiscreteValue()
            pField4.ParameterFieldName = "COMPROBANTECREDITOFISCAL"
            pDiscreteValue4.Value = primero.COMPROBANTECREDITOFISCAL 'ds.Tables(0).Rows(0).Item("COMPROBANTECREDITOFISCAL")
            pField4.CurrentValues.Add(pDiscreteValue4)
            pFields.Add(pField4)
        End If
        
        If Not String.IsNullOrEmpty(primero.FECHANOTIFICACION) Then
            Dim pField3 As New ParameterField()
            Dim pDiscreteValue3 As New ParameterDiscreteValue()
            pField3.ParameterFieldName = "FECHANOTIFICACION"
            pDiscreteValue3.Value = string.format("{0:dd/MM/yyyy}",primero.FECHANOTIFICACION)  
            pField3.CurrentValues.Add(pDiscreteValue3)
            pFields.Add(pField3)
        End If

        If Not String.IsNullOrEmpty(primero.NUMEROCSSP) Then
            Dim pField5 As New ParameterField()
            Dim pDiscreteValue5 As New ParameterDiscreteValue()
            pField5.ParameterFieldName = "numerocssp"
            pDiscreteValue5.Value = primero.NUMEROCSSP 'ds.Tables(0).Rows(0).Item("numerocssp")
            pField5.CurrentValues.Add(pDiscreteValue5)
            pFields.Add(pField5)
        End If

         Dim pField15 As New ParameterField()
            Dim pDiscreteValue15 As New ParameterDiscreteValue()
            pField15.ParameterFieldName = "fechafabricacion"
         If Not String.IsNullOrEmpty(primero.FECHAFABRICACION) Then           
            pDiscreteValue15.Value = string.format("{0:MM/yyyy}",cdate(primero.FECHAFABRICACION)) 'ds.Tables(0).Rows(0).Item("numerocssp")           
            else
            pDiscreteValue15.Value ="--"
        End If
        pField15.CurrentValues.Add(pDiscreteValue15)
        pFields.Add(pField15)

         Dim pField25 As New ParameterField()
            Dim pDiscreteValue25 As New ParameterDiscreteValue()
            pField25.ParameterFieldName = "fechavencimiento"
        If Not String.IsNullOrEmpty(primero.FECHAVENCIMIENTO) Then           
            pDiscreteValue25.Value = string.format("{0:MM/yyyy}",cdate(primero.FECHAVENCIMIENTO)) 'ds.Tables(0).Rows(0).Item("numerocssp")
           else
            pDiscreteValue25.Value ="--"
        End If
         pField25.CurrentValues.Add(pDiscreteValue25)
            pFields.Add(pField25)

        If Not String.IsNullOrEmpty(primero.NOMBREINSPECCION) Then
            Dim pField6 As New ParameterField()
            Dim pDiscreteValue6 As New ParameterDiscreteValue()
            pField6.ParameterFieldName = "nombreinspeccion"
            pDiscreteValue6.Value = primero.NOMBREINSPECCION 'ds.Tables(0).Rows(0).Item("nombreinspeccion")
            pField6.CurrentValues.Add(pDiscreteValue6)
            pFields.Add(pField6)
        End If

         If Not String.IsNullOrEmpty(primero.FECHASOLICITUDINSPECCION) Then
            Dim pField7 As New ParameterField()
            Dim pDiscreteValue7 As New ParameterDiscreteValue()
            pField7.ParameterFieldName = "fechainspeccion"
            pDiscreteValue7.Value = string.format("{0:dd/MM/yyyy}",primero.FECHASOLICITUDINSPECCION)   'ds.Tables(0).Rows(0).Item("FECHAELABORACIONINFORME")
            pField7.CurrentValues.Add(pDiscreteValue7)
            pFields.Add(pField7)
        End If
        
        If Not String.IsNullOrEmpty(primero.FECHAELABORACIONINFORME) Then
            Dim pField7 As New ParameterField()
            Dim pDiscreteValue7 As New ParameterDiscreteValue()
            pField7.ParameterFieldName = "FechaElaboracion"
            pDiscreteValue7.Value = primero.FECHAELABORACIONINFORME 'ds.Tables(0).Rows(0).Item("FECHAELABORACIONINFORME")
            pField7.CurrentValues.Add(pDiscreteValue7)
            pFields.Add(pField7)
        End If
        

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
