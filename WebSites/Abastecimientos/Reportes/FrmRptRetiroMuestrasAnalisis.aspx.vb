Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.LabHelpres

Partial Class Reportes_FrmRptRetiroMuestrasAnalisis
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Dim reportPath As String = ""

        Dim idprocesocompra, idestablecimiento, idproveedor, ni As Integer
        idprocesocompra = CType(Request.QueryString("IdPC"), Integer)
        idestablecimiento = CType(Request.QueryString("IdE"), Integer)
        idproveedor = CType(Request.QueryString("IdP"), Integer)
        ni = CType(Request.QueryString("NI"), Integer)
        reportPath = Server.MapPath("RptRetiroMuestras.rpt")

        Reporte.Load(reportPath)
        
        Dim cIM As New cINFORMEMUESTRAS
        
        Dim ds = Notificaciones.ObtenerReporteRetiroMuestras(idestablecimiento, idprocesocompra, idproveedor,  Membresia.ObtenerUsuario().IDEMPLEADO, ni) 
        Dim primero = ds.FirstOrDefault()
'As Data.DataSet
        
'DS = cIM.ObtenerRptRetiroMuestras(idestablecimiento, idprocesocompra, Session.Item("IdEmpleado"), idproveedor, ni)

        Dim CPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
        Dim ds1 As New Data.DataSet
        CPC.ObtenerCodigoyTipoLicitacion(idestablecimiento, idprocesocompra, ds1)

        Dim pFields As New ParameterFields()
        Dim pField1 As New ParameterField()
        Dim pDiscreteValue1 As New ParameterDiscreteValue()
        pField1.ParameterFieldName = "TIPOCOMPRA"
        pDiscreteValue1.Value = ds1.Tables(0).Rows(0).Item(0)
        pField1.CurrentValues.Add(pDiscreteValue1)
        pFields.Add(pField1)

        Dim pField2 As New ParameterField()
        Dim pDiscreteValue2 As New ParameterDiscreteValue()
        pField2.ParameterFieldName = "CODIGOLICITACION"
        pDiscreteValue2.Value = ds1.Tables(0).Rows(0).Item(1)
        pField2.CurrentValues.Add(pDiscreteValue2)
        pFields.Add(pField2)

        Dim pField3 As New ParameterField()
        Dim pDiscreteValue3 As New ParameterDiscreteValue()
        pField3.ParameterFieldName = "DESCRIPCIONLICITACION"
        pDiscreteValue3.Value = ds1.Tables(0).Rows(0).Item(4)
        pField3.CurrentValues.Add(pDiscreteValue3)
        pFields.Add(pField3)

        Dim pField4 As New ParameterField()
        Dim pDiscreteValue4 As New ParameterDiscreteValue()
        pField4.ParameterFieldName = "FECHANOTIFICACION"
        pDiscreteValue4.Value = primero.FechaNotificacion
        pField4.CurrentValues.Add(pDiscreteValue4)
        pFields.Add(pField4)

        Dim pField5 As New ParameterField()
        Dim pDiscreteValue5 As New ParameterDiscreteValue()
        pField5.ParameterFieldName = "NUMERONOTIFICACION"
        pDiscreteValue5.Value = primero.NumeroNotificacion
        pField5.CurrentValues.Add(pDiscreteValue5)
        pFields.Add(pField5)

          If primero.IdProveedor>0 Then
            Dim pField7 As New ParameterField()
            Dim pDiscreteValue7 As New ParameterDiscreteValue()
            pField7.ParameterFieldName = "proveedor"
            pDiscreteValue7.Value = catalogohelpers.proveedores.Obtener(primero.IDPROVEEDOR).Nombre 'ds.Tables(0).Rows(0).Item("FECHAELABORACIONINFORME")
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

        Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

        Me.crvPrincipal.EnableDatabaseLogonPrompt = False
        Me.crvPrincipal.EnableParameterPrompt = False

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
