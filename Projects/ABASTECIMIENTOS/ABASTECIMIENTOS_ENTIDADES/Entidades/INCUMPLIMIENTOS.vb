Public Class INCUMPLIMIENTOS

    Private _idEstablecimiento As Int32
    Public Property idEstablecimiento() As Int32
        Get
            Return _idEstablecimiento
        End Get
        Set(ByVal value As Int32)
            _idEstablecimiento = value
        End Set
    End Property

    Private _idProveedor As Int32
    Public Property idProveedor() As Int32
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As Int32)
            _idProveedor = value
        End Set
    End Property

    Private _idContrato As Int64
    Public Property idContrato() As Int64
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Int64)
            _idContrato = value
        End Set
    End Property

    Private _fechaDistribucion As Date
    Public Property fechaDistribucion() As Date
        Get
            Return _fechaDistribucion
        End Get
        Set(ByVal value As Date)
            _fechaDistribucion = value
        End Set
    End Property

    Private _cantidadTotal As Double
    Public Property cantidadTotal() As Double
        Get
            Return _cantidadTotal
        End Get
        Set(ByVal value As Double)
            _cantidadTotal = value
        End Set
    End Property

    Private _precioUnitario As Decimal
    Public Property precioUnitario() As Decimal
        Get
            Return _precioUnitario
        End Get
        Set(ByVal value As Decimal)
            _precioUnitario = value
        End Set
    End Property

    Private _numeroEntrega As Int16
    Public Property numeroEntrega() As Int16
        Get
            Return _numeroEntrega
        End Get
        Set(ByVal value As Int16)
            _numeroEntrega = value
        End Set
    End Property

    Private _plazoEntrega As Int16
    Public Property plazoEntrega() As Int16
        Get
            Return _plazoEntrega
        End Get
        Set(ByVal value As Int16)
            _plazoEntrega = value
        End Set
    End Property

    Private _porcentajeEngrega As Decimal
    Public Property porcentajeEngrega() As Decimal
        Get
            Return _porcentajeEngrega
        End Get
        Set(ByVal value As Decimal)
            _porcentajeEngrega = value
        End Set
    End Property

    Private _idProducto As Int32
    Public Property idProducto() As Int32
        Get
            Return _idProducto
        End Get
        Set(ByVal value As Int32)
            _idProducto = value
        End Set
    End Property

    Private _fechaLimite As Date
    Public Property fechaLimite() As Date
        Get
            Return _fechaLimite
        End Get
        Set(ByVal value As Date)
            _fechaLimite = value
        End Set
    End Property

    Private _idAlmacen As Int32
    Public Property idAlmacen() As Int32
        Get
            Return _idAlmacen
        End Get
        Set(ByVal value As Int32)
            _idAlmacen = value
        End Set
    End Property

    Private _cantidadSolicitadaAlmacen As Double
    Public Property cantidadSolicitadaAlmacen() As Double
        Get
            Return _cantidadSolicitadaAlmacen
        End Get
        Set(ByVal value As Double)
            _cantidadSolicitadaAlmacen = value
        End Set
    End Property

    Private _nombreProducto As String
    Public Property nombreProducto() As String
        Get
            Return _nombreProducto
        End Get
        Set(ByVal value As String)
            _nombreProducto = value
        End Set
    End Property

    Private _nombreAlmacen As String
    Public Property nombreAlmacen() As String
        Get
            Return _nombreAlmacen
        End Get
        Set(ByVal value As String)
            _nombreAlmacen = value
        End Set
    End Property

    Private _nombreProveedor As String
    Public Property nombreProveedor() As String
        Get
            Return _nombreProveedor
        End Get
        Set(ByVal value As String)
            _nombreProveedor = value
        End Set
    End Property

    Private _unidadMedida As String
    Public Property unidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property

    Private _renglon As Int32
    Public Property renglon() As Int32
        Get
            Return _renglon
        End Get
        Set(ByVal value As Int32)
            _renglon = value
        End Set
    End Property

    Private _numeroContrato As String
    Public Property numeroContrato() As String
        Get
            Return _numeroContrato
        End Get
        Set(ByVal value As String)
            _numeroContrato = value
        End Set
    End Property

    Private _codigoProducto As String
    Public Property codigoProducto() As String
        Get
            Return _codigoProducto
        End Get
        Set(ByVal value As String)
            _codigoProducto = value
        End Set
    End Property

    Private _cantidadEntregadaAlmacen As Double
    Public Property cantidadEntregadaAlmacen() As Double
        Get
            Return _cantidadEntregadaAlmacen
        End Get
        Set(ByVal value As Double)
            _cantidadEntregadaAlmacen = value
        End Set
    End Property

    Private _cantidadAtrasoAlmacen As Double
    Public Property cantidadAtrasoAlmacen() As Double
        Get
            Return _cantidadAtrasoAlmacen
        End Get
        Set(ByVal value As Double)
            _cantidadAtrasoAlmacen = value
        End Set
    End Property

    Private _tiempoAtraso As Int16
    Public Property tiempoAtraso() As Int16
        Get
            Return _tiempoAtraso
        End Get
        Set(ByVal value As Int16)
            _tiempoAtraso = value
        End Set
    End Property

    Private _identificador As Int32
    Public Property identificador() As Int32
        Get
            Return _identificador
        End Get
        Set(ByVal value As Int32)
            _identificador = value
        End Set
    End Property

    Private _totalEntregas As Int32
    Public Property totalEntregas() As Int32
        Get
            Return _totalEntregas
        End Get
        Set(ByVal value As Int32)
            _totalEntregas = value
        End Set
    End Property

End Class

