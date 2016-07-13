Public Class DetalleCompraDisco
    Inherits entidadBase

    Private _RENGLON As Int32
    Public Property RENGLON() As Int32
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Int32)
            _RENGLON = value
        End Set
    End Property

    Private _U_M As String
    Public Property U_M() As String
        Get
            Return _U_M
        End Get
        Set(ByVal value As String)
            _U_M = value
        End Set
    End Property

    Private _PRECIO As String
    Public Property PRECIO() As Double
        Get
            Return _PRECIO
        End Get
        Set(ByVal value As Double)
            _PRECIO = value
        End Set
    End Property

    Private _CANTIDAD As Int32
    Public Property CANTIDAD() As Int32
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal value As Int32)
            _CANTIDAD = value
        End Set
    End Property

    Private _COD_ESTA As String
    Public Property COD_ESTA() As String
        Get
            Return _COD_ESTA
        End Get
        Set(ByVal value As String)
            _COD_ESTA = value
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

    Private _ENTREGA As Int16
    Public Property ENTREGA() As Int16
        Get
            Return _ENTREGA
        End Get
        Set(ByVal value As Int16)
            _ENTREGA = value
        End Set
    End Property
    Private _IDESTABLECIMIENTO As Int16
    Public Property IDESTABLECIMIENTO() As Int16
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int16)
            _IDESTABLECIMIENTO = value
        End Set
    End Property
    Private _IDALMACEN As Int16
    Public Property IDALMACEN() As Int16
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Int16)
            _IDALMACEN = value
        End Set
    End Property
    Private _IDFF As Int16
    Public Property IDFF() As Int16
        Get
            Return _IDFF
        End Get
        Set(ByVal value As Int16)
            _IDFF = value
        End Set
    End Property
End Class
