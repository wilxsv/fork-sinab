
Public Class ALMACENESENTREGASOLICITUD
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

    Private _IDSOLICITUD As Int64
    Public Property IDSOLICITUD() As Int64
        Get
            Return _IDSOLICITUD
        End Get
        Set(ByVal value As Int64)
            _IDSOLICITUD = value
        End Set
    End Property
    Private _IDENTREGA As Int64
    Public Property IDENTREGA() As Int64
        Get
            Return _IDENTREGA
        End Get
        Set(ByVal value As Int64)
            _IDENTREGA = value
        End Set
    End Property
    Private _NUMEROENTREGA As Int64
    Public Property NUMEROENTREGA() As Int64
        Get
            Return _NUMEROENTREGA
        End Get
        Set(ByVal value As Int64)
            _NUMEROENTREGA = value
        End Set
    End Property
    Private _RENGLON As Int64
    Public Property RENGLON() As Int64
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Int64)
            _RENGLON = value
        End Set
    End Property
    Private _IDPRODUCTO As Integer
    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
        End Set
    End Property
    Private _IDALMACENENTREGA As Integer
    Public Property IDALMACENENTREGA() As Integer
        Get
            Return _IDALMACENENTREGA
        End Get
        Set(ByVal value As Integer)
            _IDALMACENENTREGA = value
        End Set
    End Property
    Private _IDUNIDADMEDIDA As Integer
    Public Property IDUNIDADMEDIDA() As Integer
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Integer)
            _IDUNIDADMEDIDA = value
        End Set
    End Property
    Private _IDFUENTEFINANCIAMIENTO As Integer
    Public Property IDFUENTEFINANCIAMIENTO() As Integer
        Get
            Return _IDFUENTEFINANCIAMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDFUENTEFINANCIAMIENTO = value
        End Set
    End Property
    Private _CANTIDAD As Decimal
    Public Property CANTIDAD() As Decimal
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal value As Decimal)
            _CANTIDAD = value
        End Set
    End Property
    Private _PRECIOUNITARIO As Decimal
    Public Property PRECIOUNITARIO() As Decimal
        Get
            Return _PRECIOUNITARIO
        End Get
        Set(ByVal value As Decimal)
            _PRECIOUNITARIO = value
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
    Private _IDESPECIFICACION As Integer
    Public Property IDESPECIFICACION() As Integer
        Get
            Return _IDESPECIFICACION
        End Get
        Set(ByVal value As Integer)
            _IDESPECIFICACION = value
        End Set
    End Property
#End Region

End Class
