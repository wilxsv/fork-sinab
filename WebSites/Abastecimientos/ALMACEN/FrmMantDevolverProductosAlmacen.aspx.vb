Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports Cooperator.Framework.Web.Controls
Partial Class FrmMantDevolverProductosAlmacen
    Inherits System.Web.UI.Page
    Private mCompMovimientos As New cMOVIMIENTOS
    Private mCompVale As New cVALESSALIDA
    Private mCompDetalleMovimientos As New cDETALLEMOVIMIENTOS
    Private mEntMovimientos As New MOVIMIENTOS
    Private mEntVale As New VALESSALIDA
    Friend Shared IdTipoMovimiento As New Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False

        If Not Page.IsPostBack Then
            IdTipoMovimiento = 3
            CargarTodos()
        End If
    End Sub

    Private Sub CargarTodos()
        Dim dsMovimientos As Data.DataSet

        dsMovimientos = mCompMovimientos.ObtenerDsMovimientosFiltrado(Session.Item("IdEstablecimiento"), IdTipoMovimiento, 0, Session.Item("IdAlmacen"), Session.Item("IdDependencia"), 2)

        dgLista.DataSource = dsMovimientos
        dgLista.DataBind()

    End Sub

    Public Sub EliminarMovimiento(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As New LinkButton
        Dim dsDetalle As Data.DataSet

        b = sender

        'Verificando el estado actual del movimiento
        If b.CommandArgument = "4" Then
            MsgBox1.ShowAlert("Un documento con estado de CERRADO no puede ser eliminado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End If

        'Recuperando detalle del movimiento
        dsDetalle = mCompDetalleMovimientos.ObtenerDataSetPorId(Session.Item("IdEstablecimiento"), IdTipoMovimiento, b.CommandName)
        If dsDetalle.Tables(0).Rows.Count = 0 Then
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = IdTipoMovimiento
            mEntMovimientos.IDMOVIMIENTO = b.CommandName
            mEntMovimientos.ANIO = b.ToolTip
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

            'Eliminando el vale de salida asociado a este movimiento
            mCompVale.EliminarVALESSALIDA(mEntMovimientos.IDALMACEN, mEntMovimientos.ANIO, mEntMovimientos.IDDOCUMENTO)

            'Eliminando detalle de movimientos
            mCompMovimientos.EliminarMOVIMIENTOS(Session.Item("IdEstablecimiento"), IdTipoMovimiento, b.CommandName)
            CargarTodos() 'Llamada a la función que carga nuevamente los datos de los movimientos
        Else
            MsgBox1.ShowAlert("El documento no puede ser eliminado porque posee productos asignados", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If

    End Sub

    Protected Sub ImgbAgregarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbAgregarDocumento.Click
        Response.Redirect("~/ALMACEN/FrmDetaMantDevProAlmacen.aspx?IdMov=0&IdTipTran=3")

    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
End Class