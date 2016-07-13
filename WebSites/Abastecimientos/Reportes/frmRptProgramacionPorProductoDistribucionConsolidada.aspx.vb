Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class Reportes_frmRptProgramacionPorProductoDistribucion
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()


        If Request.QueryString("idProceso") Is Nothing Or Request.QueryString("idTipo") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idProceso As Integer = Request.QueryString("idProceso")
        Dim idTipo As Integer = Request.QueryString("idTipo")

        Reporte = New ReportDocument
        Dim reportPath As String

        If idTipo = 0 Then
            'reportPath = Server.MapPath("RptProgramacionCompra10.rpt")
            reportPath = Server.MapPath("RptProgramacionCompra10no.rpt")
        Else
            reportPath = Server.MapPath("RptProgramacionCompra10no.rpt")
        End If

        Reporte.Load(reportPath)

        Dim x As New cPROGRAMACIONPRODUCTO

        Dim ds As Data.DataSet
        If Not Page.IsPostBack Then
            If idTipo = 0 Then
                ds = x.obtenerDistribucionProgramacion(idProceso, idTipo)
            Else
                ds = x.obtenerDistribucionProgramacion2(idProceso, idTipo)
            End If
            ' ViewState.Add("ds_rpt", ds)
            'Session("ds_rpt") = ViewState("ds_rpt")
            Session("ds_rpt") = ds
        Else

            'If Session("ds_rpt") Is Nothing Then


            '    Me.Session.Add("ds_rpt", ds)
            'End If

        End If



        'Obtenemos el detalle del proceso de compras
        Dim cEntidad As New cPROGRAMACION
        Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(idProceso)

        'Reporte.SetDataSource(ds.Tables(0))
        Reporte.SetDataSource(CType(Session("ds_rpt"), Data.DataSet).Tables(0))
        'Reporte.SetDataSource(CType(ViewState("ds_rpt"), Data.DataSet).Tables(0))

        Dim pFields As New ParameterFields()
        Dim pField As New ParameterField()
        Dim disVal As New ParameterDiscreteValue()

        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "nprogramacion"
        disVal.Value = eEntidad.DESCRIPCION          'Set the discrete Value
        pField.CurrentValues.Add(disVal)

        pFields.Add(pField)

        'Ultimo parametro
        pField = New ParameterField
        disVal = New ParameterDiscreteValue

        pField.ParameterFieldName = "nprograma"
        disVal.Value = IIf(eEntidad.ESTADO > 3, "", "1")           'Set the discrete Value
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
        ' Session("ds_rpt") = Nothing
    End Sub

End Class
