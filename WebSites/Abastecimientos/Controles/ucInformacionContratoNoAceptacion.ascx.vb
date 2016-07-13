Partial Class Controles_ucInformacionContratoNoAceptacion
    Inherits System.Web.UI.UserControl

    Public Event SeleccionarRenglon()

    Private idEstablecimiento As Integer
    Private idProveedor As Integer
    Private idContrato As Integer
    Private idAlmacen As Integer
    Private renglon As Integer
    Private iddetalle As Integer

    Public Property _idEstablecimiento() As Integer
        Get
            Return idEstablecimiento
        End Get
        Set(ByVal value As Integer)
            idEstablecimiento = value
        End Set
    End Property

    Public Property _idProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Property _idContrato() As Integer
        Get
            Return idContrato
        End Get
        Set(ByVal value As Integer)
            idContrato = value
        End Set
    End Property

    Public Property _idAlmacen() As Integer
        Get
            Return idAlmacen
        End Get
        Set(ByVal value As Integer)
            idAlmacen = value
        End Set
    End Property
    Public Property _iddetalle() As Integer
        Get
            Return iddetalle
        End Get
        Set(ByVal value As Integer)
            iddetalle = value
        End Set
    End Property
    Public ReadOnly Property _renglon() As Integer
        Get
            Return renglon
        End Get
    End Property
    Public ReadOnly Property NumeroContrato() As String
        Get
            Return Me.lblNoContrato.Text
        End Get
    End Property
    Public ReadOnly Property NumRecibo() As String
        Get
            Return Me.txtNoRecepcion.Text
        End Get
    End Property
    Public ReadOnly Property FechaRecepcion() As Date
        Get
            Return Me.dtRecepcion.SelectedDate
        End Get
    End Property
    Public ReadOnly Property Guardaalmacen() As String
        Get
            Return Me.txtGuardalmacen.Text
        End Get
    End Property
    Public ReadOnly Property Transportista() As String
        Get
            Return Me.txtTransportista.Text
            If Not Me.ViewState("Transportista") Is Nothing Then Me.ViewState.Remove("Transportista")
            Me.ViewState.Add("Transportista", Me.txtTransportista.Text)
        End Get
    End Property
    Public ReadOnly Property IdDocumento() As String
        Get
            Return Me.txtNoRecepcion.Text
            If Not Me.ViewState("IdDocumento") Is Nothing Then Me.ViewState.Remove("IdDocumento")
            Me.ViewState.Add("IdDocumento", Me.txtNoRecepcion.Text)
        End Get
    End Property
    Public Sub EsconderColSeleccion(ByVal valor As Boolean)
        Me.gvRenglones.Columns(0).Visible = valor
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.dtRecepcion.UpperBoundDate = Now

        If IsPostBack Then
            If Not Me.ViewState("Transportista") Is Nothing Then Me.txtTransportista.Text = Me.ViewState("Transportista")

        End If

    End Sub
    Public Sub Cargar()
        Dim eEntidad As ABASTECIMIENTOS.ENTIDADES.CONTRATOS
        Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cCONTRATOS

        Dim eEntidadRecibo As New ABASTECIMIENTOS.ENTIDADES.RECIBOSRECEPCION
        Dim cEntidadRecibo As New ABASTECIMIENTOS.NEGOCIO.cRECIBOSRECEPCION

        eEntidad = cEntidad.obtenerDatosContrato2(idEstablecimiento, idProveedor, idContrato)

        If Not eEntidad Is Nothing Then

            Me.lblModCompra.Text = eEntidad.DESCRIPCIONMODALIDADCOMPRA
            Me.lblNoModCompra.Text = eEntidad.NUMEROMODALIDADCOMPRA
            Me.lblFuenteFinanc.Text = eEntidad.FUENTESFINANCIAMIENTO
            Me.lblRespDist.Text = eEntidad.RESPONSABLEDISTRIBUCION
            Me.lblResAdjud.Text = eEntidad.RESOLUCIONADJUDICACION
            Me.lblNoContrato.Text = eEntidad.NUMEROCONTRATO
            Me.lblProveedor.Text = eEntidad.NOMBREPROVEEDOR
            Me.lblFchDist.Text = Format(eEntidad.FECHADISTRIBUCION, "dd/MM/yyyy")

            Me.dtRecepcion.SelectedDate = Now

            eEntidadRecibo.IDALMACEN = idAlmacen
            eEntidadRecibo.ANIO = Now.Year

            Me.txtNoRecepcion.Text = cEntidadRecibo.ObtenerID(eEntidadRecibo)

            Me.gvRenglones.DataSource = cEntidad.obtenerRenglonesContrato(idEstablecimiento, idProveedor, idContrato, idAlmacen)
            Me.gvRenglones.DataBind()

        End If
    End Sub
    Protected Sub gvRenglones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvRenglones.SelectedIndexChanged

        renglon = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("RENGLON")
        idEstablecimiento = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDESTABLECIMIENTO")
        idProveedor = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDPROVEEDOR")
        idContrato = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDCONTRATO")
        idAlmacen = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDALMACENENTREGA")
        'iddetalle = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDDETALLE")

        RaiseEvent SeleccionarRenglon()

    End Sub
End Class
