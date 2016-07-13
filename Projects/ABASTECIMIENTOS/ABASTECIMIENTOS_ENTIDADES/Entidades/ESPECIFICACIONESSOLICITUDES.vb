
Public Class ESPECIFICACIONESSOLICITUDES
    Inherits entidadBase

#Region " Propiedades "

    Private _IDESTABLECIMIENTO As Int32
    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTO = value
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
    Private _IDESPECIFICACION As Int64
    Public Property IDESPECIFICACION() As Int64
        Get
            Return _IDESPECIFICACION
        End Get
        Set(ByVal value As Int64)
            _IDESPECIFICACION = value
        End Set
    End Property
    Private _ESPECIFICACION As String
    Public Property ESPECIFICACION() As String
        Get
            Return _ESPECIFICACION
        End Get
        Set(ByVal value As String)
            _ESPECIFICACION = value
        End Set
    End Property
    Private _NOMBREESPECIFICACION As String
    Public Property NOMBREESPECIFICACION() As String
        Get
            Return _NOMBREESPECIFICACION
        End Get
        Set(ByVal value As String)
            _NOMBREESPECIFICACION = value
        End Set
    End Property
    Private _IDSOLICITUD As Integer
    Public Property IDSOLICITUD() As Integer
        Get
            Return _IDSOLICITUD
        End Get
        Set(ByVal value As Integer)
            _IDSOLICITUD = value
        End Set
    End Property
    Private _PRECIO As Decimal
    Public Property PRECIO() As Decimal
        Get
            Return _PRECIO
        End Get
        Set(ByVal value As Decimal)
            _PRECIO = value
        End Set
    End Property
#End Region

End Class
