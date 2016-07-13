Public Class ACLARACIONES
    Inherits entidadBase

#Region " Propiedades "

    Private _IDACLARACION As Int32
    Public Property IDACLARACION() As Int32
        Get
            Return _IDACLARACION
        End Get
        Set(ByVal value As Int32)
            _IDACLARACION = value
        End Set
    End Property

    Private _IDESTABLECIMIENTO As Int32
    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Private _IDPROCESOCOMPRA As Int64
    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Int64)
            _IDPROCESOCOMPRA = value
        End Set
    End Property

    Private _NUMEROACLARACION As String
    Public Property NUMEROACLARACION() As String
        Get
            Return _NUMEROACLARACION
        End Get
        Set(ByVal value As String)
            _NUMEROACLARACION = value
        End Set
    End Property

    Private _FECHAACLARACION As DateTime
    Public Property FECHAACLARACION() As DateTime
        Get
            Return _FECHAACLARACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAACLARACION = value
        End Set
    End Property

    Private _DETALLEACLARACION As String
    Public Property DETALLEACLARACION() As String
        Get
            Return _DETALLEACLARACION
        End Get
        Set(ByVal value As String)
            _DETALLEACLARACION = value
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
#End Region

End Class
