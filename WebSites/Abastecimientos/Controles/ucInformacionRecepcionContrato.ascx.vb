Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucInformacionRecepcionContrato
    Inherits System.Web.UI.UserControl

    Public Event SeleccionarRenglon()

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _IDALMACEN As Integer
    Private _IDDETALLE As Integer
    Private _RENGLON As Integer
    Private _IDUNIDADMEDIDA As Integer
    Private _IDPRODUCTO As Integer
    Private _CANTIDADARECIBIR As Decimal
    Private _PRECIO As Decimal
    Private _CANTIDADDECIMAL As Integer

#Region "Propiedades"

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
        End Set
    End Property

    Public Property IDDETALLE() As Integer
        Get
            Return _IDDETALLE
        End Get
        Set(ByVal value As Integer)
            _IDDETALLE = value
        End Set
    End Property

    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Integer)
            _RENGLON = value
        End Set
    End Property

    Public Property IDUNIDADMEDIDA() As Integer
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Integer)
            _IDUNIDADMEDIDA = value
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.ViewState.Remove("IDUNIDADMEDIDA")
            Me.ViewState.Add("IDUNIDADMEDIDA", value)
        End Set
    End Property

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

    Public Property CANTIDADARECIBIR() As Decimal
        Get
            Return _CANTIDADARECIBIR
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADARECIBIR = value
            If Not Me.ViewState("CANTIDADARECIBIR") Is Nothing Then Me.ViewState.Remove("CANTIDADARECIBIR")
            Me.ViewState.Add("CANTIDADARECIBIR", value)
        End Set
    End Property

    Public Property PRECIO() As Decimal
        Get
            Return _PRECIO
        End Get
        Set(ByVal value As Decimal)
            _PRECIO = value
            If Not Me.ViewState("PRECIO") Is Nothing Then Me.ViewState.Remove("PRECIO")
            Me.ViewState.Add("PRECIO", value)
        End Set
    End Property

    Public ReadOnly Property NumeroContrato() As String
        Get
            Return Me.txtNoContratoOrdenCompra.Text
        End Get
    End Property

    Public Property CANTIDADDECIMAL() As Integer
        Get
            Return _CANTIDADDECIMAL
        End Get
        Set(ByVal value As Integer)
            _CANTIDADDECIMAL = value
            If Not Me.ViewState("CANTIDADDECIMAL") Is Nothing Then Me.ViewState.Remove("CANTIDADDECIMAL")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.IDUNIDADMEDIDA = Me.ViewState("IDUNIDADMEDIDA")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("CANTIDADARECIBIR") Is Nothing Then Me.CANTIDADARECIBIR = Me.ViewState("CANTIDADARECIBIR")
            If Not Me.ViewState("PRECIO") Is Nothing Then Me.PRECIO = Me.ViewState("PRECIO")

            If Not Me.ViewState("CANTIDADDECIMAL") Is Nothing Then Me.CANTIDADDECIMAL = Me.ViewState("CANTIDADDECIMAL")
        End If
    End Sub

    Public Sub CargarDatos()
        Dim eC As New CONTRATOS
        Dim cC As New cCONTRATOS

        eC = cC.obtenerDatosContrato2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

        If Not eC Is Nothing Then

            Me.txtModalidadCompra.Text = eC.DESCRIPCIONMODALIDADCOMPRA
            Me.txtNoModalidadCompra.Text = eC.NUMEROMODALIDADCOMPRA
            Me.txtFuenteFinanciamiento.Text = eC.FUENTESFINANCIAMIENTO
            Me.txtResponsableDistribucion.Text = eC.RESPONSABLEDISTRIBUCION
            Me.txtResolucionAdjudicacion.Text = eC.RESOLUCIONADJUDICACION
            Me.txtNoContratoOrdenCompra.Text = eC.NUMEROCONTRATO
            Me.txtProveedor.Text = eC.NOMBREPROVEEDOR
            Me.txtFechaDistribucion.Text = Format(eC.FECHADISTRIBUCION, "dd/MM/yyyy")

            Me.gvRenglones.DataSource = cC.ObtenerRenglonesPendientesTotales2(IDESTABLECIMIENTO, IDALMACEN, IDPROVEEDOR, IDCONTRATO)
            Me.gvRenglones.DataBind()

        End If
    End Sub

    Protected Sub gvRenglones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvRenglones.SelectedIndexChanged

        IDESTABLECIMIENTO = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDESTABLECIMIENTO")
        IDPROVEEDOR = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDPROVEEDOR")
        IDCONTRATO = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDCONTRATO")
        IDALMACEN = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDALMACENENTREGA")
        RENGLON = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("RENGLON")
        IDPRODUCTO = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDPRODUCTO")
        IDUNIDADMEDIDA = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDUNIDADMEDIDA")
        CANTIDADARECIBIR = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("CANTIDADPENDIENTE")
        PRECIO = CDec(Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("PRECIOUNITARIO"))
        CANTIDADDECIMAL = CDec(Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("CANTIDADDECIMAL"))

        Me.txtNoRenglon.Text = RENGLON
        Me.txtCodigo.Text = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("CORRPRODUCTO")
        Me.txtNombre.Text = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("DESCLARGO")
        Me.txtDescProv.Text = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("DESCRIPCIONPROVEEDOR")
        Me.txtCantidadRecibir.Text = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("CANTIDADPENDIENTE")
        Me.txtUM.Text = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("UNIDADMEDIDA")
        Me.txtPrecioUnitario.Text = String.Format("{0:c}", Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("PRECIOUNITARIO").ToString)

        plRenglon.Visible = True

        RaiseEvent SeleccionarRenglon()

    End Sub

    Public Sub Limpiar()

        Me.IDESTABLECIMIENTO = 0
        Me.IDPROVEEDOR = 0
        Me.IDCONTRATO = 0
        Me.IDALMACEN = 0
        Me.RENGLON = 0
        Me.IDPRODUCTO = 0
        Me.IDUNIDADMEDIDA = 0
        Me.CANTIDADARECIBIR = 0
        Me.PRECIO = 0

        gvRenglones.DataSource = Nothing
        gvRenglones.DataBind()
        gvRenglones.SelectedIndex = -1

        Me.txtNoRenglon.Text = String.Empty
        Me.txtCodigo.Text = String.Empty
        Me.txtNombre.Text = String.Empty
        Me.txtDescProv.Text = String.Empty
        Me.txtCantidadRecibir.Text = String.Empty
        Me.txtUM.Text = String.Empty
        Me.txtPrecioUnitario.Text = String.Empty
        Me.plRenglon.Visible = False

    End Sub

End Class
