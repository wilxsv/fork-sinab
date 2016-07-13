Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmMantDespachoDependencias
    Inherits System.Web.UI.Page
    Private mCompMovimientos As New cMOVIMIENTOS
    Private mCompDetalleMovimientos As New cDETALLEMOVIMIENTOS
    Private mCompVale As New cVALESSALIDA
    Private mEntMovimientos As New MOVIMIENTOS
    Private IdTipoMovimiento As Integer = 1
    Friend Shared _VISTAACTUAL As Int16

    Public Property VISTAACTUAL() As Int16
        Get
            Return _VISTAACTUAL
        End Get
        Set(ByVal value As Int16)
            _VISTAACTUAL = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False
        If Not Page.IsPostBack Then
            IdTipoMovimiento = 1
            CargarValesPendientes()
            Me.VISTAACTUAL = 1
        End If

    End Sub

    Private Sub CargarRequisicionesPendientes()
        Dim dsMovimientos As Data.DataSet

        dsMovimientos = mCompMovimientos.ObtenerRequisicionesFiltradas(0, Session.Item("IdAlmacen"), 0, 3, 10)
        If dsMovimientos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("No se encontro ninguna requisición pendiente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.PnlPrincipal.Visible = False
        Else
            Me.dgLista.DataSource = dsMovimientos
            Me.dgLista.DataBind()
            Me.PnlPrincipal.Visible = True
        End If

    End Sub

    Private Sub CargarValesPendientes()
        Dim dsMovimientos As Data.DataSet

        dsMovimientos = mCompMovimientos.ObtenerDsMovimientosFiltrado(Session.Item("IdEstablecimiento"), 2, 0, Session.Item("IdAlmacen"), 0, 2, 10)
        If dsMovimientos.Tables(0).Rows.Count = 0 Then
            'MsgBox1.ShowAlert("No se encontro ningún vale de salida pendiente de cierre.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.GvValesPendientes.DataSource = dsMovimientos
            Me.GvValesPendientes.DataBind()
            Me.PnlPrincipal.Visible = False
        Else
            Me.GvValesPendientes.DataSource = dsMovimientos
            Me.GvValesPendientes.DataBind()
            Me.PnlPrincipal.Visible = True
        End If

    End Sub

    Protected Sub BtMostrarRequisiciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtMostrarRequisiciones.Click
        If Me.VISTAACTUAL = 2 Then
            Me.PnlValesSalida.Visible = True
            Me.PnlPrincipal.Visible = False
            Me.ImgbAgregarDocumento.Visible = True
            Me.BtMostrarRequisiciones.Text = "Mostrar requisiciones pendientes"
            Me.VISTAACTUAL = 1
        ElseIf Me.VISTAACTUAL = 1 Then
            Me.PnlPrincipal.Visible = True
            Me.PnlValesSalida.Visible = False
            Me.ImgbAgregarDocumento.Visible = False
            Me.BtMostrarRequisiciones.Text = "Mostrar vales de salida"
            Me.VISTAACTUAL = 2
            CargarRequisicionesPendientes()
        End If
    End Sub

    Public Sub EliminarMovimiento(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As New LinkButton
        Dim dsDetalle As Data.DataSet

        b = sender

        mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntMovimientos.IDTIPOTRANSACCION = 2
        mEntMovimientos.IDMOVIMIENTO = b.CommandName
        mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

        dsDetalle = mCompDetalleMovimientos.ObtenerDataSetPorId(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
        If dsDetalle.Tables(0).Rows.Count = 0 Then
            mCompMovimientos.EliminarMOVIMIENTOS(Session.Item("IdEstablecimiento"), 2, b.CommandName)
            mCompVale.EliminarVALESSALIDA(mEntMovimientos.IDALMACEN, mEntMovimientos.ANIO, mEntMovimientos.IDDOCUMENTO)
            CargarValesPendientes()
        Else
            MsgBox1.ShowAlert("El documento no puede ser eliminado porque posee productos asignados", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If

    End Sub

    Protected Sub ImgbAgregarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbAgregarDocumento.Click
        Response.Redirect("~/ALMACEN/FrmDetMantDespachoDependencias.aspx?IdMov=0&IdTipTran=2")

    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
