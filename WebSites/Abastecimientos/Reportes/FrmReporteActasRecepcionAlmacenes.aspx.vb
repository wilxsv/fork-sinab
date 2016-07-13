
Imports System.Activities.Expressions
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports CrystalDecisions.CrystalReports.Engine
Imports SINAB_Utils

Partial Class Reportes_FrmReporteActasRecepcionAlmacenes
    Inherits System.Web.UI.Page
    Private Reporte As ReportDocument


    ReadOnly Property IdAlmacen As Integer
        Get
            Return CType(Request.QueryString("a"), Integer)
        End Get
    End Property

    ReadOnly Property IdEstablecimiento() As Integer
        Get
            Return CType(Request.QueryString("e"), Integer)
        End Get
    End Property
    ReadOnly Property DateIni() As DateTime
        Get
            Return CType(Request.QueryString("di"), Date)
        End Get
    End Property

    ReadOnly Property DateEnd As DateTime
        Get
            Return CType(Request.QueryString("df"), Date)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
        End If
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ConfigureCrystalReports()

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument
        Reporte.Load(Server.MapPath("~/Reportes/rpt/ActaRecepcion.rpt"))
        Using db As New SinabEntities
            Dim almacen = CatalogoHelpers.Almacenes.Obtener(db, IdAlmacen)
            Dim ds = DetallesMovimiento.ObtenerActaPorAlmacen(db, IdEstablecimiento, DateIni, DateEnd, IdAlmacen)
            Reporte.SetDataSource(ds)
            crvPrincipal.ReportSource = Reporte
            If almacen Is Nothing Then
                Reporte.SetParameterValue("NombreAlmacen", "Todos los Almacenes")
            Else
                Reporte.SetParameterValue("NombreAlmacen", almacen.NOMBRE)
            End If

            Reporte.SetParameterValue("LogoSrc", Server.MapPath(Config.LogoUrl))
        End Using
       

       
    End Sub


End Class
