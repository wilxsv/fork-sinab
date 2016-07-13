Public Class PROGRAMACIONPRODUCTO
    Inherits PROGRAMACION

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPRODUCTO As Integer
    Private _PRECIO As Decimal
    Private _COMPRATRANSITO As Decimal
    Private _CANTIDADALMACEN As Decimal
    Private _CANTIDADREGION As Decimal
    Private _CONSUMOPROMEDIO As Decimal
    Private _CANTIDADCOMPRAR As Decimal
    Private _DIASDESABASTECIDOS As Integer
    Private _DEMANDAINSATISFECHA As Decimal
    Private _OBSERVACION As String
    Private _TIPOOBSERVACION As Integer
    Private _IDOBSERVACION As Integer

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Integer)
            _IDESTABLECIMIENTO = Value
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

    Public Property PRECIO() As Decimal
        Get
            Return _PRECIO
        End Get
        Set(ByVal Value As Decimal)
            _PRECIO = Value
        End Set
    End Property

    Public Property COMPRATRANSITO() As Decimal
        Get
            Return _COMPRATRANSITO
        End Get
        Set(ByVal Value As Decimal)
            _COMPRATRANSITO = Value
        End Set
    End Property

    Public Property CANTIDADALMACEN() As Decimal
        Get
            Return _CANTIDADALMACEN
        End Get
        Set(ByVal Value As Decimal)
            _CANTIDADALMACEN = Value
        End Set
    End Property

    Public Property CANTIDADREGION() As Decimal
        Get
            Return _CANTIDADREGION
        End Get
        Set(ByVal Value As Decimal)
            _CANTIDADREGION = Value
        End Set
    End Property

    Public Property CONSUMOPROMEDIO() As Decimal
        Get
            Return _CONSUMOPROMEDIO
        End Get
        Set(ByVal Value As Decimal)
            _CONSUMOPROMEDIO = Value
        End Set
    End Property

    Public Property CANTIDADCOMPRAR() As Decimal
        Get
            Return _CANTIDADCOMPRAR
        End Get
        Set(ByVal Value As Decimal)
            _CANTIDADCOMPRAR = Value
        End Set
    End Property

    Public Property DIASDESABASTECIDOS() As Integer
        Get
            Return _DIASDESABASTECIDOS
        End Get
        Set(ByVal Value As Integer)
            _DIASDESABASTECIDOS = Value
        End Set
    End Property

    Public Property DEMANDAINSATISFECHA() As Decimal
        Get
            Return _DEMANDAINSATISFECHA
        End Get
        Set(ByVal Value As Decimal)
            _DEMANDAINSATISFECHA = Value
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

    Public Property TIPOOBSERVACION() As Integer
        Get
            Return _TIPOOBSERVACION
        End Get
        Set(ByVal Value As Integer)
            _TIPOOBSERVACION = Value
        End Set
    End Property

    Public Property IDOBSERVACION() As Integer
        Get
            Return _IDOBSERVACION
        End Get
        Set(ByVal Value As Integer)
            _IDOBSERVACION = Value
        End Set
    End Property

End Class
