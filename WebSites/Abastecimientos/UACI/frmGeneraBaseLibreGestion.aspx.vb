
Partial Class frmGeneraBaseLibreGestion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UcGenerarBasesLibreGestion1._IDPROCESOCOMPRA = Session("IdProcesoCompra")
        Me.UcGenerarBasesLibreGestion1._IDMODALIDADCOMPRA = Session("IDMODALIDADCOMPRA")
        Me.lblPlantilla.Text = "Plantilla seleccionada: " & Session("PLANTILLA")
        Me.lblModalidadCompra.Text = Session("MODALIDAD")
        Me.UcGenerarBasesLibreGestion1._IDPLANTILLA = Session("IDPLANTILLA")
        Me.UcGenerarBasesLibreGestion1._CODIGOFUENTE = Session("CODIGOFUENTE")
        UcGenerarBasesLibreGestion1.ActivarPaso1()
        UcGenerarBasesLibreGestion1.cargarDatos()
        Me.Master.ControlMenu.Visible = False
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub btnPlantillas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlantillas.Click
        Response.Redirect("~/UACI/frmGenerarBasesPlantilla.aspx?idProc=" & Session("IdProcesoCompra"))
    End Sub
End Class
