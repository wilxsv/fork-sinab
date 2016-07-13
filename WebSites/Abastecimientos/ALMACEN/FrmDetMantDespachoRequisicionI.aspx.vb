Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmDetMantDespachoRequisicionI
    Inherits System.Web.UI.Page
    Private mCompMovimientos As New cMOVIMIENTOS
    Private mCompDetalleMovimientos As New cDETALLEMOVIMIENTOS
    Private mCompVale As New cVALESSALIDA
    Private mEntMovimientos As New MOVIMIENTOS
    Private IdTipoMovimiento As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False
        If Not Page.IsPostBack Then
            IdTipoMovimiento = 1
            CargarRequisicionesPendientes()
        End If

    End Sub

    Private Sub CargarRequisicionesPendientes()
        Dim dsMovimientos As Data.DataSet

        dsMovimientos = mCompMovimientos.ObtenerRequisicionesFiltradas(0, Session.Item("IdAlmacen"), 0, 3, 0)
        If dsMovimientos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("No se encontro ninguna requisición pendiente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.PnlPrincipal.Visible = False
        Else
            Me.dgLista.DataSource = dsMovimientos
            Me.dgLista.DataBind()
            Me.PnlPrincipal.Visible = True
        End If

    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/ALMACEN/FrmMantDespacharProductos.aspx")
    End Sub

    Protected Sub dgLista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLista.SelectedIndexChanged

    End Sub
End Class
