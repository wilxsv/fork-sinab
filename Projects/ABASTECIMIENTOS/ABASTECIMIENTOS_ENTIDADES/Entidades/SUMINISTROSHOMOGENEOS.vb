Public Class SUMINISTROSHOMOGENEOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDSUMINISTRO As Int32
    Public Property IDSUMINISTRO() As Int32
        Get
            Return _IDSUMINISTRO
        End Get
        Set(ByVal value As Int32)
            _IDSUMINISTRO = value
        End Set
    End Property

    Private _IDSUMINISTROHOMOGENEO As Int32
    Public Property IDSUMINISTROHOMOGENEO() As Int32
        Get
            Return _IDSUMINISTROHOMOGENEO
        End Get
        Set(ByVal value As Int32)
            _IDSUMINISTROHOMOGENEO = value
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
