
Partial Class ucOfertasPorRenglonProcesoCompra
    Inherits System.Web.UI.UserControl

    Private mComponente As New ABASTECIMIENTOS.NEGOCIO.cDETALLEOFERTA

    Private _IDESTABLECIMIENTO As Int32
    Private _IDPROCESOCOMPRA As Int64
    Private _IDPRODUCTO As Int64
    Private _RENGLON As Int32
    Private _IDDETALLEOFERTA As Int64
    Private _IDDETALLEPROCESOCOMPRA As Int64
    Private _IDPROVEEDOR As Int32

    Private _CantidadOferta As Decimal
    Private _CantidadRecomendada As Decimal
    Private _CantidadAdjudicada As Decimal
    Private _CantidadAdjudicadaEnFirme As Decimal
    Private _PlazoEntrega As String
    Private _UnidadMedida As String
    Private _CantidadDecimalesUnidadMedida As Integer
    Private _VerCantidadRecomendada As Boolean
    Private _VerCantidadAdjudicada As Boolean
    Private _VerCantidadAdjudicadaFirme As Boolean
    Private _VerBotonNoAdjudicar As Boolean
    Private _TipoCantidad As Integer

    Private _NumRegistros As Integer = 0

    Public Event SelectedIndexChanged()
    Public Event NoAdjudicar()

#Region " Propiedades "

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return Me._IDPROCESOCOMPRA
        End Get
        Set(ByVal Value As Int64)
            Me._IDPROCESOCOMPRA = Value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", Value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int32
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROVEEDOR = Value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", Value)
        End Set
    End Property

    Public Property IDDETALLEOFERTA() As Int64
        Get
            Return Me._IDDETALLEOFERTA
        End Get
        Set(ByVal Value As Int64)
            Me._IDDETALLEOFERTA = Value
            If Not Me.ViewState("IDDETALLEOFERTA") Is Nothing Then Me.ViewState.Remove("IDDETALLEOFERTA")
            Me.ViewState.Add("IDDETALLEOFERTA", Value)
        End Set
    End Property

    Public Property IDDETALLEPROCESOCOMPRA() As Int64
        Get
            Return _IDDETALLEPROCESOCOMPRA
        End Get
        Set(ByVal Value As Int64)
            _IDDETALLEPROCESOCOMPRA = Value
            If Not Me.ViewState("IDDETALLEPROCESOCOMPRA") Is Nothing Then Me.ViewState.Remove("IDDETALLEPROCESOCOMPRA")
            Me.ViewState.Add("IDDETALLEPROCESOCOMPRA", Value)
        End Set
    End Property

    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal Value As Int64)
            _IDPRODUCTO = Value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", Value)
        End Set
    End Property

    Public Property RENGLON() As Int32
        Get
            Return Me._RENGLON
        End Get
        Set(ByVal Value As Int32)
            Me._RENGLON = Value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", Value)
        End Set
    End Property

    Public Property CantidadOferta() As Decimal
        Get
            Return Me._CantidadOferta
        End Get
        Set(ByVal Value As Decimal)
            Me._CantidadOferta = Value
            If Not Me.ViewState("CantidadOferta") Is Nothing Then Me.ViewState.Remove("CantidadOferta")
            Me.ViewState.Add("CantidadOferta", Value)
        End Set
    End Property

    Public Property CantidadRecomendada() As Decimal
        Get
            Return Me._CantidadRecomendada
        End Get
        Set(ByVal Value As Decimal)
            Me._CantidadRecomendada = Value
            If Not Me.ViewState("CantidadRecomendada") Is Nothing Then Me.ViewState.Remove("CantidadRecomendada")
            Me.ViewState.Add("CantidadRecomendada", Value)
        End Set
    End Property

    Public Property CantidadAdjudicada() As Decimal
        Get
            Return Me._CantidadAdjudicada
        End Get
        Set(ByVal Value As Decimal)
            Me._CantidadAdjudicada = Value
            If Not Me.ViewState("CantidadAdjudicada") Is Nothing Then Me.ViewState.Remove("CantidadAdjudicada")
            Me.ViewState.Add("CantidadAdjudicada", Value)
        End Set
    End Property

    Public Property CantidadAdjudicadaEnFirme() As Decimal
        Get
            Return Me._CantidadAdjudicadaEnFirme
        End Get
        Set(ByVal Value As Decimal)
            Me._CantidadAdjudicadaEnFirme = Value
            If Not Me.ViewState("CantidadAdjudicadaEnFirme") Is Nothing Then Me.ViewState.Remove("CantidadAdjudicadaEnFirme")
            Me.ViewState.Add("CantidadAdjudicadaEnFirme", Value)
        End Set
    End Property

    Public Property PlazoEntrega() As String
        Get
            Return Me._PlazoEntrega
        End Get
        Set(ByVal Value As String)
            Me._PlazoEntrega = Value
        End Set
    End Property

    Public Property UnidadMedida() As String
        Get
            Return Me._UnidadMedida
        End Get
        Set(ByVal Value As String)
            Me._UnidadMedida = Value
        End Set
    End Property

    Public Property VerCantidadRecomendada() As Boolean
        Get
            Return _VerCantidadRecomendada
        End Get
        Set(ByVal Value As Boolean)
            _VerCantidadRecomendada = Value
        End Set
    End Property

    Public Property VerCantidadAdjudicada() As Boolean
        Get
            Return _VerCantidadAdjudicada
        End Get
        Set(ByVal Value As Boolean)
            _VerCantidadAdjudicada = Value
        End Set
    End Property

    Public Property VerCantidadAdjudicadaFirme() As Boolean
        Get
            Return _VerCantidadAdjudicadaFirme
        End Get
        Set(ByVal Value As Boolean)
            _VerCantidadAdjudicadaFirme = Value
        End Set
    End Property

    Public Property VerBotonNoAdjudicar() As Boolean
        Get
            Return _VerBotonNoAdjudicar
        End Get
        Set(ByVal Value As Boolean)
            _VerBotonNoAdjudicar = Value
        End Set
    End Property

    Public Property CantidadDecimalesUnidadMedida() As Integer
        Get
            Return _CantidadDecimalesUnidadMedida
        End Get
        Set(ByVal Value As Integer)
            _CantidadDecimalesUnidadMedida = Value
        End Set
    End Property

    Public Property TipoCantidad() As Integer
        Get
            Return _TipoCantidad
        End Get
        Set(ByVal Value As Integer)
            _TipoCantidad = Value
            If Not Me.ViewState("TipoCantidad") Is Nothing Then Me.ViewState.Remove("TipoCantidad")
            Me.ViewState.Add("TipoCantidad", Value)
        End Set
    End Property

    Public Property NumRegistros() As Integer
        Get
            Return _NumRegistros
        End Get
        Set(ByVal Value As Integer)
            _NumRegistros = Value
            If Not Me.ViewState("NumRegistros") Is Nothing Then Me.ViewState.Remove("NumRegistros")
            Me.ViewState.Add("NumRegistros", Value)
        End Set
    End Property

#End Region

    Private Sub ColumnasVisible(ByVal Value As Boolean)
        Me.gvOfertas.Columns(7).Visible = Value
        Me.gvOfertas.Columns(11).Visible = Value

        Me.gvOfertas.Columns(13).Visible = IIf(Value, True, Me.VerCantidadRecomendada)
        Me.gvOfertas.Columns(14).Visible = IIf(Value, True, Me.VerCantidadAdjudicada)
        Me.gvOfertas.Columns(15).Visible = IIf(Value, True, Me.VerCantidadAdjudicadaFirme)
    End Sub

    Public Sub CargarDatos()
        ColumnasVisible(True)

        Me.gvOfertas.DataSource = Me.mComponente.ObtenerOfertasPorRenglonProcesoCompra(Me.IDPROCESOCOMPRA, Me.IDESTABLECIMIENTO, Me.RENGLON, Me.IDPROVEEDOR, Me.IDDETALLEOFERTA)
        Me.gvOfertas.DataBind()

        ColumnasVisible(False)

        If NumRegistros = 0 Then
            NumRegistros = gvOfertas.Rows.Count
        End If

        If gvOfertas.Rows.Count = 0 Then
            Me.lblSeleccioneUnProveedor.Visible = False
            Me.btnNoAdjudicar.Visible = False
        Else
            Me.lblSeleccioneUnProveedor.Visible = True
            Me.btnNoAdjudicar.Visible = VerBotonNoAdjudicar
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me._IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDDETALLEOFERTA") Is Nothing Then Me._IDDETALLEOFERTA = Me.ViewState("IDDETALLEOFERTA")
            If Not Me.ViewState("IDDETALLEPROCESOCOMPRA") Is Nothing Then Me._IDDETALLEPROCESOCOMPRA = Me.ViewState("IDDETALLEPROCESOCOMPRA")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me._RENGLON = Me.ViewState("RENGLON")
            If Not Me.ViewState("TipoCantidad") Is Nothing Then Me._TipoCantidad = Me.ViewState("TipoCantidad")

            If Not Me.ViewState("NumRegistros") Is Nothing Then Me._NumRegistros = Me.ViewState("NumRegistros")
        End If

        Me.btnNoAdjudicar.Attributes.Add("onclick", "if (!window.confirm('¿Confirma que no adjudica el renglón seleccionado a ningún ofertante?')){return false;}")

    End Sub

    Protected Sub gvOfertas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvOfertas.SelectedIndexChanged

        Select Case gvOfertas.Rows.Count
            Case Is = 1
                If NumRegistros = 1 Then
                    If Me.IDDETALLEOFERTA = 0 Then
                        Me.IDPROVEEDOR = Me.gvOfertas.DataKeys(gvOfertas.SelectedIndex).Values(0)
                        Me.IDDETALLEOFERTA = Me.gvOfertas.DataKeys(gvOfertas.SelectedIndex).Values(1)

                        Me.UnidadMedida = gvOfertas.SelectedRow.Cells(6).Text
                        Me.CantidadDecimalesUnidadMedida = CInt(gvOfertas.SelectedRow.Cells(7).Text)
                        Me.CantidadOferta = CDec(gvOfertas.SelectedRow.Cells(8).Text)
                        Me.PlazoEntrega = gvOfertas.SelectedRow.Cells(11).Text

                        Me.CantidadRecomendada = CDec(gvOfertas.SelectedRow.Cells(13).Text)
                        Me.CantidadAdjudicada = CDec(gvOfertas.SelectedRow.Cells(14).Text)
                        Me.CantidadAdjudicadaEnFirme = CDec(gvOfertas.SelectedRow.Cells(15).Text)

                        Me.gvOfertas.SelectedIndex = 1
                    Else
                        LimpiarOfertas()
                        Me.gvOfertas.SelectedIndex = -1
                    End If
                Else
                    LimpiarOfertas()
                    Me.gvOfertas.SelectedIndex = -1
                End If

            Case Is > 1
                Me.IDPROVEEDOR = Me.gvOfertas.DataKeys(gvOfertas.SelectedIndex).Values(0)
                Me.IDDETALLEOFERTA = Me.gvOfertas.DataKeys(gvOfertas.SelectedIndex).Values(1)

                Me.UnidadMedida = gvOfertas.SelectedRow.Cells(6).Text
                Me.CantidadDecimalesUnidadMedida = CInt(gvOfertas.SelectedRow.Cells(7).Text)
                Me.CantidadOferta = CDec(gvOfertas.SelectedRow.Cells(8).Text)
                Me.PlazoEntrega = gvOfertas.SelectedRow.Cells(11).Text

                Me.CantidadRecomendada = CDec(gvOfertas.SelectedRow.Cells(13).Text)
                Me.CantidadAdjudicada = CDec(gvOfertas.SelectedRow.Cells(14).Text)
                Me.CantidadAdjudicadaEnFirme = CDec(gvOfertas.SelectedRow.Cells(15).Text)

                Me.gvOfertas.SelectedIndex = 1
        End Select

        RaiseEvent SelectedIndexChanged()

    End Sub

    Protected Sub btnNoAdjudicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoAdjudicar.Click
        Dim cA As New ABASTECIMIENTOS.NEGOCIO.cADJUDICACION
        Dim eA As New ABASTECIMIENTOS.ENTIDADES.ADJUDICACION
        Dim eDPC As New ABASTECIMIENTOS.ENTIDADES.DETALLEPROCESOCOMPRA

        eA.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
        eA.IDPROCESOCOMPRA = Me.IDPROCESOCOMPRA
        eA.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eA.AUFECHAMODIFICACION = Now
        eA.ESTASINCRONIZADA = 0

        eDPC.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
        eDPC.IDPROCESOCOMPRA = Me.IDPROCESOCOMPRA
        eDPC.IDPRODUCTO = Me.IDPRODUCTO
        eDPC.IDDETALLE = Me.IDDETALLEPROCESOCOMPRA
        eDPC.RENGLON = Me.RENGLON
        eDPC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eDPC.AUFECHAMODIFICACION = Now
        eDPC.ESTASINCRONIZADA = 0

        cA.EliminarCantidadesYEntregasPorRenglon(eA, eDPC, Me.TipoCantidad)

        RaiseEvent NoAdjudicar()

    End Sub

    Public Sub LimpiarOfertas()
        NumRegistros = 0
        gvOfertas.PageIndex = 0
        Me.IDDETALLEOFERTA = 0
        Me.IDPROVEEDOR = 0
    End Sub

End Class
