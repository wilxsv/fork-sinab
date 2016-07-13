Public Class DETALLEINVENTARIOINICIAL
    Inherits entidadBase

#Region "Propiedades"

    Private _IDALMACEN As Int32
    Public Property IDALMACEN() As Int32
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Int32)
            _IDALMACEN = value
        End Set
    End Property

    Private _IDINVENTARIO As Int32
    Public Property IDINVENTARIO() As Int32
        Get
            Return _IDINVENTARIO
        End Get
        Set(ByVal value As Int32)
            _IDINVENTARIO = value
        End Set
    End Property

    Private _IDLOTE As Int64
    Public Property IDLOTE() As Int64
        Get
            Return _IDLOTE
        End Get
        Set(ByVal value As Int64)
            _IDLOTE = value
        End Set
    End Property

    Private _IDPRODUCTO As Int64
    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            _IDPRODUCTO = value
        End Set
    End Property

    Private _IDUNIDADMEDIDA As Int32
    Public Property IDUNIDADMEDIDA() As Int32
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Int32)
            _IDUNIDADMEDIDA = value
        End Set
    End Property

    Private _CODIGO As String
    Public Property CODIGO() As String
        Get
            Return _CODIGO
        End Get
        Set(ByVal value As String)
            _CODIGO = value
        End Set
    End Property

    Private _DETALLE As String
    Public Property DETALLE() As String
        Get
            Return _DETALLE
        End Get
        Set(ByVal value As String)
            _DETALLE = value
        End Set
    End Property

    Private _PRECIOLOTE As Decimal
    Public Property PRECIOLOTE() As Decimal
        Get
            Return _PRECIOLOTE
        End Get
        Set(ByVal value As Decimal)
            _PRECIOLOTE = value
        End Set
    End Property

    Private _FECHAVENCIMIENTO As DateTime
    Public Property FECHAVENCIMIENTO() As DateTime
        Get
            Return _FECHAVENCIMIENTO
        End Get
        Set(ByVal value As DateTime)
            _FECHAVENCIMIENTO = value
        End Set
    End Property

    Private _IDFUENTEFINANCIAMIENTO As Int32
    Public Property IDFUENTEFINANCIAMIENTO() As Int32
        Get
            Return _IDFUENTEFINANCIAMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDFUENTEFINANCIAMIENTO = value
        End Set
    End Property

    Private _IDRESPONSABLEDISTRIBUCION As Int32
    Public Property IDRESPONSABLEDISTRIBUCION() As Int32
        Get
            Return _IDRESPONSABLEDISTRIBUCION
        End Get
        Set(ByVal value As Int32)
            _IDRESPONSABLEDISTRIBUCION = value
        End Set
    End Property

    Private _CANTIDADDISPONIBLE As Decimal
    Public Property CANTIDADDISPONIBLE() As Decimal
        Get
            Return _CANTIDADDISPONIBLE
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADDISPONIBLE = value
        End Set
    End Property

    Private _CANTIDADNODISPONIBLE As Decimal
    Public Property CANTIDADNODISPONIBLE() As Decimal
        Get
            Return _CANTIDADNODISPONIBLE
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADNODISPONIBLE = value
        End Set
    End Property

    Private _CANTIDADVENCIDA As Decimal
    Public Property CANTIDADVENCIDA() As Decimal
        Get
            Return _CANTIDADVENCIDA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADVENCIDA = value
        End Set
    End Property

    Private _UBICACION As String
    Public Property UBICACION() As String
        Get
            Return _UBICACION
        End Get
        Set(ByVal value As String)
            _UBICACION = value
        End Set
    End Property

    Private _AUUSUARIOCREACION As String
    Public Property AUUSUARIOCREACION() As String
        Get
            Return _AUUSUARIOCREACION
        End Get
        Set(ByVal value As String)
            _AUUSUARIOCREACION = value
        End Set
    End Property

    Private _AUFECHACREACION As DateTime
    Public Property AUFECHACREACION() As DateTime
        Get
            Return _AUFECHACREACION
        End Get
        Set(ByVal value As DateTime)
            _AUFECHACREACION = value
        End Set
    End Property

    Private _AUUSUARIOMODIFICACION As String
    Public Property AUUSUARIOMODIFICACION() As String
        Get
            Return _AUUSUARIOMODIFICACION
        End Get
        Set(ByVal value As String)
            _AUUSUARIOMODIFICACION = value
        End Set
    End Property

    Private _AUFECHAMODIFICACION As DateTime
    Public Property AUFECHAMODIFICACION() As DateTime
        Get
            Return _AUFECHAMODIFICACION
        End Get
        Set(ByVal value As DateTime)
            _AUFECHAMODIFICACION = value
        End Set
    End Property

    Private _ESTASINCRONIZADA As Int16
    Public Property ESTASINCRONIZADA() As Int16
        Get
            Return _ESTASINCRONIZADA
        End Get
        Set(ByVal value As Int16)
            _ESTASINCRONIZADA = value
        End Set
    End Property

#End Region

End Class
