
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils
Imports SINAB_Entidades

Partial Class Reportes_FrmReporteEntregasProcesoCompra
    Inherits System.Web.UI.Page
    ReadOnly Property IdProcesoCompra As Integer
        Get
            Return CType(Request.QueryString("p"), Integer)
        End Get
    End Property

    ReadOnly Property NompreProcesoCompra() As String
        Get
            Return CType(Request.QueryString("c"), String)
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
        Dim usr = Membresia.ObtenerUsuario()
        Reporte = New ReportDocument
        Reporte.Load(Server.MapPath("~/Reportes/rpt/EntregasProcesoCompra.rpt"))

        Dim ds = Helpers.UACIHelpers.AlmacenesEntregaContrato.ObtenerEntregasProcesoCompra(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO, IdProcesoCompra)
        Reporte.SetDataSource(ds)
        crvPrincipal.ReportSource = Reporte


        Reporte.SetParameterValue("LogoSrc", Server.MapPath(Config.LogoUrl))
        Reporte.SetParameterValue("NombreProcesoCompra", NompreProcesoCompra)



    End Sub

    Private Reporte As ReportDocument
End Class
