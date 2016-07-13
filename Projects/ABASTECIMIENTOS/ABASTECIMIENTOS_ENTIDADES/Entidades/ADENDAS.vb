Public Class ADENDAS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDADENDA As Int32
    Public Property IDADENDA() As Int32
        Get
            Return _IDADENDA
        End Get
        Set(ByVal value As Int32)
            _IDADENDA = value
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

    Private _NUMEROADENDA As String
    Public Property NUMEROADENDA() As String
        Get
            Return _NUMEROADENDA
        End Get
        Set(ByVal value As String)
            _NUMEROADENDA = value
        End Set
    End Property

    Private _FECHAADENDA As DateTime
    Public Property FECHAADENDA() As DateTime
        Get
            Return _FECHAADENDA
        End Get
        Set(ByVal value As DateTime)
            _FECHAADENDA = value
        End Set
    End Property

    Private _DETALLEADENDA As String
    Public Property DETALLEADENDA() As String
        Get
            Return _DETALLEADENDA
        End Get
        Set(ByVal value As String)
            _DETALLEADENDA = value
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
