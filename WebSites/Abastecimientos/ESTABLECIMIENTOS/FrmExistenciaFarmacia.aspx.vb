Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmExistenciaFarmacia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False
        If Not Page.IsPostBack Then
            Me.DdlALMACENES1.RecuperarFarmaciasEstablecimiento(Session.Item("IdEstablecimiento"))
            Me.DdlALMACENES1.SelectedValue = Session.Item("IdAlmacen")
        End If
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Busqueda()
    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/ESTABLECIMIENTOS/FrmReportesModuloEstablecimientos.aspx")
    End Sub

    Private Sub Busqueda()
        Session.Item("IdAlmacenP") = Me.DdlALMACENES1.SelectedValue
        Session.Item("IdSuministroP") = 1
        Session.Item("IdFuenteP") = 0
        Session.Item("IdResponsableP") = 0
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExistenciasFarmaciaEstab.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'REDIRECCIONA NUEVAMENTE AL MENU Y PAGINA PRINCIPAL
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
End Class
