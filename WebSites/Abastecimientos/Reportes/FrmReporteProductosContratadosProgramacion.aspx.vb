
Imports System.Linq
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports CrystalDecisions.CrystalReports.Engine
Imports SINAB_Entidades
Imports SINAB_Utils

Partial Class Reportes_FrmReporteProductosContratadosProgramacion
    Inherits System.Web.UI.Page
    ReadOnly Property IdProgramacionCompra As Integer
        Get
            Return CType(Request.QueryString("p"), Integer)
        End Get
    End Property

    ReadOnly Property EsCantidadAjustada() As Boolean
        Get
            Return CType(Request.QueryString("c"), Boolean)
        End Get
    End Property

    ReadOnly Property NompreProgramacionCompra() As String
        Get
            Return CType(Request.QueryString("n"), String)
        End Get
    End Property
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ConfigureCrystalReports()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Reporte.Load(Server.MapPath("~/Reportes/rpt/ProductosContratadosProgramacion.rpt"))

        Dim ds = Helpers.Productos.ObtenerPorProgramacion(IdProgramacionCompra, EsCantidadAjustada).ToList()
        Reporte.SetDataSource(ds)
        crvPrincipal.ReportSource = Reporte


        Reporte.SetParameterValue("LogoSrc", Server.MapPath(Config.LogoUrl))
        Reporte.SetParameterValue("NombreProgramacion", NompreProgramacionCompra)



    End Sub

    Private Reporte As ReportDocument
End Class
