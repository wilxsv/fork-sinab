Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.EnumHelpers

Partial Class ucSeleccionDocumentoRecepcion
    Inherits System.Web.UI.UserControl

    Public Event SeleccionarDocumento()

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _IDALMACEN As Integer
    Private _ANIO As Integer
    Private _IDRECIBO As Integer

    Private _IDMOVIMIENTO As Integer

#Region "Propiedades"

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
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

    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.ViewState.Remove("IDALMACEN")
            Me.ViewState.Add("IDALMACEN", value)
        End Set
    End Property

    Public Property ANIO() As Integer
        Get
            Return _ANIO
        End Get
        Set(ByVal value As Integer)
            _ANIO = value
            If Not Me.ViewState("ANIO") Is Nothing Then Me.ViewState.Remove("ANIO")
            Me.ViewState.Add("ANIO", value)
        End Set
    End Property

    Public Property IDRECIBO() As Integer
        Get
            Return _IDRECIBO
        End Get
        Set(ByVal value As Integer)
            _IDRECIBO = value
            If Not Me.ViewState("IDRECIBO") Is Nothing Then Me.ViewState.Remove("IDRECIBO")
            Me.ViewState.Add("IDRECIBO", value)
        End Set
    End Property

    Public Property IDMOVIMIENTO() As Integer
        Get
            Return _IDMOVIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDMOVIMIENTO = value
            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me.ViewState.Remove("IDMOVIMIENTO")
            Me.ViewState.Add("IDMOVIMIENTO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.IDALMACEN = Session.Item("IdAlmacen")
            ddlALMACENESESTABLECIMIENTOS1.RecuperarListaSubAlmacenes(Session.Item("IdEstablecimiento"))

            If ddlALMACENESESTABLECIMIENTOS1.Items.Count > 1 Then
                Me.plAlmacen.Visible = True
                ddlALMACENESESTABLECIMIENTOS1.SelectedValue = Me.IDALMACEN
            Else
                Me.plAlmacen.Visible = False
            End If

            CargarDatos()

        Else
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me._IDALMACEN = Me.ViewState("IDALMACEN")

            If Not Me.ViewState("ANIO") Is Nothing Then Me._ANIO = Me.ViewState("ANIO")
            If Not Me.ViewState("IDRECIBO") Is Nothing Then Me._IDRECIBO = Me.ViewState("IDRECIBO")

            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me._IDMOVIMIENTO = Me.ViewState("IDMOVIMIENTO")
        End If

    End Sub

    Protected Sub gvDocumentos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDocumentos.SelectedIndexChanged

        IDESTABLECIMIENTO = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("IDESTABLECIMIENTO")
        IDPROVEEDOR = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("IDPROVEEDOR")
        IDCONTRATO = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("IDCONTRATO")
        ANIO = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("ANIO")
        IDRECIBO = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("IDRECIBO")
        IDMOVIMIENTO = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("IDMOVIMIENTO")

        RaiseEvent SeleccionarDocumento()
    End Sub

    Protected Sub ddlAlmancenes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlALMACENESESTABLECIMIENTOS1.SelectedIndexChanged

        Me.IDALMACEN = Me.ddlALMACENESESTABLECIMIENTOS1.SelectedValue

        CargarDatos()

    End Sub

    Public Sub CargarDatos()

        Dim cRR As New cRECIBOSRECEPCION

        Me.gvDocumentos.DataSource = cRR.ObtenerRecepciones(Me.IDALMACEN, TiposTransaccion.RecepcionProductos, eESTADOSMOVIMIENTOS.Grabado)

        Try
            Me.gvDocumentos.DataBind()
        Catch ex As Exception
            Me.gvDocumentos.PageIndex = 0
            Me.gvDocumentos.DataBind()
        End Try

    End Sub

    Public Sub Limpiar()
        Me.gvDocumentos.DataSource = Nothing
        Me.gvDocumentos.DataBind()
        Me.gvDocumentos.SelectedIndex = -1
    End Sub

End Class
