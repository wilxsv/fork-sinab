﻿Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Reportes_frmRptProgramacion2
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("idProceso") Is Nothing Or Request.QueryString("idEstablecimiento") Is Nothing Or _
           Request.QueryString("m") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        'If Session.Item("idEstablecimiento") <> Request.QueryString("idEstablecimiento") Then
        '    Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        'End If

        Dim idProceso As Integer = Request.QueryString("idProceso")
        Dim idEstablecimiento As Integer = Request.QueryString("idEstablecimiento")
        Dim m As Integer = Request.QueryString("m")

        Reporte = New ReportDocument
        Dim reportPath As String

 
        reportPath = Server.MapPath("RptProgramacionCompra5.rpt")
 
        Reporte.Load(reportPath)

        'Obtenemos el detalle del proceso de compras
        Dim cEntidad As New cPROGRAMACION
        Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(idProceso)


        Dim x As New cPROGRAMACIONPRODUCTO

        Dim ds As Data.DataSet
        ds = x.obtenerProgramacionProductosDetalle2(idProceso, idEstablecimiento, m)

        Reporte.SetDataSource(ds.Tables(0))

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        'Primer parametro
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "establecimiento"
        disVal.Value = "Establecimiento: " & Session.Item("UsuarioEstablecimiento")         'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)

        'Segundo parametro
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "m"
        disVal.Value = m         'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)

        'Tercer parametro
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
