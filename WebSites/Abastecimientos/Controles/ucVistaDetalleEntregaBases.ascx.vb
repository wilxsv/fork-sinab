Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucVistaDetalleEntregaBases
    Inherits System.Web.UI.UserControl

    Private mComponente As New cENTREGABASES

    Private _IDPROCESOCOMPRA As Int64
    Private _IDPROVEEDOR As Int64
    Private _PAGINA As String

    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Public Property PAGINA() As String
        Get
            Return _PAGINA
        End Get
        Set(ByVal value As String)
            _PAGINA = value
            If Not Me.ViewState("PAGINA") Is Nothing Then Me.ViewState.Remove("PAGINA")
            Me.ViewState.Add("PAGINA", value)
        End Set
    End Property

    Public Sub Consultar()
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerDataSetPorIDwPROVEEDOR(Me.IDPROCESOCOMPRA, Session("IdEstablecimiento")) 'TODO: IDESTABLECIMIENTO, modificar el estado por la variable apropiada

        If ds.Tables(0).Rows.Count > 0 Then
            Me.gvProveedores.DataSource = ds
            Me.gvProveedores.DataBind()
        Else
            Me.lblMsgError.Text = "No hay registro de bases entregadas"
        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'Me.UcBarraNavegacion1.Navegacion = False
            'Me.UcBarraNavegacion1.PermitirGuardar = False
            'Me.UcBarraNavegacion1.PermitirConsultar = False
            'Me.UcBarraNavegacion1.PermitirImprimir = False


        Else
            btGuardar.Visible = False
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("PAGINA") Is Nothing Then Me.PAGINA = Me.ViewState("PAGINA")
        End If

        Dim cPC As New cPROCESOCOMPRAS
        Dim ds As New Data.DataSet
        cPC.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Me.IDPROCESOCOMPRA, ds)

        Me.lblProcesoCompra.Text = ds.Tables(0).Rows(0).Item(1)
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As System.EventArgs) Handles btGuardar.Click
        Response.Redirect(PAGINA & "?est=n&idProc=" & Me.IDPROCESOCOMPRA)
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As System.EventArgs) Handles btCancelar.Click
        Response.Redirect("~/UACI/FrmEntregaBases.aspx")
    End Sub

    

    Protected Sub dgProveedores_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProveedores.PageIndexChanging
        Me.gvProveedores.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvProveedores.RowDeleting
        IDPROVEEDOR = Me.gvProveedores.DataKeys(e.RowIndex).Item("IDPROVEEDOR")
        Me.MsgBox1.ShowConfirm("¿Desea Eliminar el proveedor del listado?", "ELIMINAR", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub dgProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProveedores.SelectedIndexChanged
        IDPROVEEDOR = Me.gvProveedores.DataKeys(Me.gvProveedores.SelectedIndex).Item("IDPROVEEDOR")
        Response.Redirect(PAGINA & "?est=m&idProc=" & Me.IDPROCESOCOMPRA & "&idProv=" & IDPROVEEDOR)
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "ELIMINAR" Then
            mComponente.EliminarENTREGABASES(Session("IdEstablecimiento"), Me.IDPROCESOCOMPRA, IDPROVEEDOR)
            Me.CargarDatos()
        End If
    End Sub

   
End Class
