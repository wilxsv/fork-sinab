Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Entidades.EnumHelpers

Partial Class FrmMantRequisicionAlmacen
    Inherits System.Web.UI.Page

    Private mCompMovimientos As New cMOVIMIENTOS
    Private mCompDetalleMovimientos As New cDETALLEMOVIMIENTOS
    Private mEntMovimientos As New MOVIMIENTOS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()
        Dim ds As Data.DataSet
        ds = mCompMovimientos.ObtenerDsMovimientosFiltrado(Session.Item("IdEstablecimiento"), TiposTransaccion.RequisicionProductos, 0, Session.Item("IdAlmacen"), Session.Item("IdDependencia"), 2, 0)
        dgLista.DataSource = ds
        dgLista.DataBind()
    End Sub

    Public Sub EliminarMovimiento(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As New LinkButton
        Dim dsDetalle As Data.DataSet

        b = sender

        dsDetalle = mCompDetalleMovimientos.ObtenerDataSetPorId(Session.Item("IdEstablecimiento"), TiposTransaccion.RequisicionProductos, b.CommandName)
        If dsDetalle.Tables(0).Rows.Count = 0 Then
            mCompMovimientos.EliminarMOVIMIENTOS(Session.Item("IdEstablecimiento"), TiposTransaccion.RequisicionProductos, b.CommandName)
            CargarDatos()
        Else
            MsgBox1.ShowAlert("El documento no puede ser eliminado porque posee productos asignados", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If

    End Sub

    Protected Sub ImgbAgregarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbAgregarDocumento.Click
        Response.Redirect("~/ALMACEN/frmDetMantRequisicionAlmacen.aspx?IdMov=0&IdTipTran=1", False)

    End Sub

End Class
