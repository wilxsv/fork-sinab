Imports ABASTECIMIENTOS.NEGOCIO
Partial Class FrmReportesDistribucion1
    Inherits System.Web.UI.Page
    Private cCP As New cCATALOGOPRODUCTOS
    Private cdis As New cDistribucion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ddlSUMINISTROS1.DataSource = cdis.ListaDistribucionesCerradas(Year(Date.Now), Session("IdEstablecimiento"))
            Me.ddlSUMINISTROS1.DataTextField = "DESCRIPCION"
            Me.ddlSUMINISTROS1.DataValueField = "IDDISTRIBUCION"
            Me.ddlSUMINISTROS1.DataBind()
            Me.ddlSUMINISTROS1.Items.Insert(0, "Seleccione una distribución")
            Me.ddlSUMINISTROS1.SelectedValue = 0

        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
       
        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptReporteDistribucion1.aspx?id=" & ddlSUMINISTROS1.SelectedValue
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub
End Class
