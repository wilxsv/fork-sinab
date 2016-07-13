
Imports System.Collections.Generic
Imports System.Linq
Imports CrystalDecisions.Shared
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.CertificacionHelpers
Imports CrystalDecisions.CrystalReports.Engine
Imports SINAB_Entidades.Tipos

Partial Class Reportes_FrmConstanciaRegistrados
    Inherits System.Web.UI.Page
     Private Reporte As ReportDocument

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'al inicializar
        ConfigureCrystalReports()
    End Sub

    Private Sub ConfigureCrystalReports()
        Reporte = New ReportDocument()
        Dim idProceso As Integer = CType(Request.QueryString("idpc"), Integer)
        Dim idTipoProducto As Integer = CType(Request.QueryString("idtp"), Integer)
        Dim nitProveedor As String = Request.QueryString("nit")
        'Dim fechaLimite As DateTime = CDate(Request.QueryString("fecha"))

        Dim reportPath As String = Server.MapPath("~/UACI/CERTIFICACION/Reportes/Fuentes/reporte5.rpt")
        Reporte.Load(reportPath)

        Dim ds = ProductosProveedores.ObtenerReporte(idProceso, idTipoProducto, nitProveedor, 2)
       
        Dim dsaspectos = New List(Of BaseAspectoProducto)
        Using db As New SinabEntities()

            For Each itm As BaseProductosProveedores In ds
                If itm.Estado = EnumHelpers.EstadoProductoProveedor.NoCertificado
                   dsaspectos.AddRange(AspectosProductos.ObtenerTodos(db, itm.Id, EnumHelpers.EstadoAspectos.NoAplica))
                End If
            Next
        End Using
        
        If ds.Any() Then
            Reporte.SetDataSource(ds)
            Reporte.Subreports.Item(0).SetDataSource(dsaspectos)
        End If
        
        'Dim proceso = ProcesosCertificacion.Obtener()
        'Dim procesoNombre = ""
        'If Not IsNothing(proceso) Then procesoNombre = proceso.ProcesoCompra
        'Dim param = New ParameterDiscreteValue()
        'param.Value = procesoNombre
        'Reporte.SetParameterValue(0, param)
        
        'muestra reeporte
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

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'al cerrar pagina
        Reporte.Close()
        Reporte.Dispose()
    End Sub
End Class
