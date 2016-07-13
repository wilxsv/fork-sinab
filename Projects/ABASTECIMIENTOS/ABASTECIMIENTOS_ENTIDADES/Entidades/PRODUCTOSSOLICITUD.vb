Public Class PRODUCTOSSOLICITUD

    Private _IDESTABLECIMIENTO As Integer
    Private _IDSOLICITUD As Integer
    Private _IDPRODUCTO As Integer
    Private _IDENTREGA As Int16
    Private _OBSERVACION As String
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As Date
    Private _AUUSUARIOMODIFICACION As String
    Private _AUFECHAMODIFICACION As Date
    Private _IDDEPENDENCIA As Integer
    Private _CANTIDAD As Integer
    Private _IDESPECIFICACION As Integer
    Private _RENGLON As Integer
    Private _PRECIOUNITARIO As Decimal
    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Integer)
            _IDESTABLECIMIENTO = Value
        End Set
    End Property
    Public Property IDSOLICITUD() As Integer
        Get
            Return _IDSOLICITUD
        End Get
        Set(ByVal Value As Integer)
            _IDSOLICITUD = Value
        End Set
    End Property

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal Value As Integer)
            _IDPRODUCTO = Value
        End Set
    End Property
    Public Property IDENTREGA() As Int16
        Get
            Return _IDENTREGA
        End Get
        Set(ByVal Value As Int16)
            _IDENTREGA = Value
        End Set
    End Property
    Public Property OBSERVACION() As String
        Get
            Return _OBSERVACION
        End Get
        Set(ByVal Value As String)
            _OBSERVACION = Value
        End Set
    End Property
    Public Property AUUSUARIOCREACION() As String
        Get
            Return _AUUSUARIOCREACION
        End Get
        Set(ByVal Value As String)
            _AUUSUARIOCREACION = Value
        End Set
    End Property

    Public Property AUFECHACREACION() As DateTime
        Get
            Return _AUFECHACREACION
        End Get
        Set(ByVal Value As DateTime)
            _AUFECHACREACION = Value
        End Set
    End Property

    Public Property AUUSUARIOMODIFICACION() As String
        Get
            Return _AUUSUARIOMODIFICACION
        End Get
        Set(ByVal Value As String)
            _AUUSUARIOMODIFICACION = Value
        End Set
    End Property

    Public Property AUFECHAMODIFICACION() As DateTime
        Get
            Return _AUFECHAMODIFICACION
        End Get
        Set(ByVal Value As DateTime)
            _AUFECHAMODIFICACION = Value
        End Set
    End Property
    Public Property IDDEPENDENCIA() As Integer
        Get
            Return _IDDEPENDENCIA
        End Get
        Set(ByVal Value As Integer)
            _IDDEPENDENCIA = Value
        End Set
    End Property
    Public Property CANTIDAD() As Integer
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal Value As Integer)
            _CANTIDAD = Value
        End Set
    End Property
    Public Property IDESPECIFICACION() As Integer
        Get
            Return _IDESPECIFICACION
        End Get
        Set(ByVal Value As Integer)
            _IDESPECIFICACION = Value
        End Set
    End Property
    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal Value As Integer)
            _RENGLON = Value
        End Set
    End Property
    Public Property PRECIOUNITARIO() As Decimal
        Get
            Return _PRECIOUNITARIO
        End Get
        Set(ByVal Value As Decimal)
            _PRECIOUNITARIO = Value
        End Set
    End Property
End Class
