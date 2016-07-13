Public Class DISTRIBUCIONPRODUCTO
    Inherits DISTRIBUCION

    Private _IDPRODUCTO As Integer
    Private _CODPRODUCTO As String
    Private _COMPRATRANSITO As Decimal
    Private _CANTIDADALMACEN As Decimal

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal Value As Integer)
            _IDPRODUCTO = Value
        End Set
    End Property

    Public Property CODPRODUCTO() As String
        Get
            Return _CODPRODUCTO
        End Get
        Set(ByVal Value As String)
            _CODPRODUCTO = Value
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

End Class
