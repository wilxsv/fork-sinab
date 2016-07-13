
Partial Class frmGeneraSolicitudContratacionDirecta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcGenerarBasesContratacionDirecta1._IDPROCESOCOMPRA = Session("IdProcesoCompra")

        Me.UcGenerarBasesContratacionDirecta1._IDMODALIDADCOMPRA = Session("IDMODALIDADCOMPRA")
        Me.lblPlantilla.Text = "Plantilla seleccionada: " & Session("PLANTILLA")
        Me.lblModalidadCompra.Text = Session("MODALIDAD")
        Me.UcGenerarBasesContratacionDirecta1._IDPLANTILLA = Session("IDPLANTILLA")
        Me.UcGenerarBasesContratacionDirecta1._CODIGOFUENTE = Session("CODIGOFUENTE")

        Me.UcGenerarBasesContratacionDirecta1.ActivarPaso1()
        Me.UcGenerarBasesContratacionDirecta1.cargarDatos()
        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub btnPlantillas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlantillas.Click
        Response.Redirect("~/UACI/frmGenerarBasesPlantilla.aspx?idProc=" & Session("IdProcesoCompra"))
    End Sub

End Class
