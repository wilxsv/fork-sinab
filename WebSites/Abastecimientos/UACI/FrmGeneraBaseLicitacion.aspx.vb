
Partial Class frmGeneraBaseLicitacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try




            Me.Master.ControlMenu.Visible = False

            Me.lblPlantilla.Text = "Plantilla seleccionada: " & Session("PLANTILLA")
            Me.lblModalidadCompra.Text = Session("MODALIDAD")
            Me.UcGenerarBases1.IDPROCESOCOMPRA = Session("IdProcesoCompra")
            Me.UcGenerarBases1.IDPLANTILLA = Session("IDPLANTILLA")

            Dim mComponente As New ABASTECIMIENTOS.NEGOCIO.cPLANTILLAS
            Dim ds As New Data.DataSet
            ds = mComponente.ObtenerDataSetPlantillas(Session("IDPLANTILLA"))

            Me.UcGenerarBases1.CODIGOFUENTE = ds.Tables(0).Rows(0).Item("CODIGOFUENTE")
            'Session("CODIGOFUENTE")
            Me.UcGenerarBases1.IDMODALIDADCOMPRA = Session("IDMODALIDADCOMPRA")
            Me.UcGenerarBases1.CargaDatos()
            UcGenerarBases1.VpnlPaso1(True)

            Me.btnPlantillas.Visible = False
        Catch ex As Exception
            Response.Redirect("~/UACI/FrmSeleccioneProcesoCompra.aspx?id=GenerarBases")
        End Try
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub btnPlantillas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlantillas.Click
        Response.Redirect("~/UACI/frmGenerarBasesPlantilla.aspx?idProc=" & Session("IdProcesoCompra"))
    End Sub

End Class
