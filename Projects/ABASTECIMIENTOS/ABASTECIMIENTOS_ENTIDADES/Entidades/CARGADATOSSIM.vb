''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.CARGADATOSSIM
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCARGADATOSSIM en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CARGADATOSSIM
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

    Private _IDCARGA As Int32
    Public Property IDCARGA() As Int32
        Get
            Return _IDCARGA
        End Get
        Set(ByVal value As Int32)
            _IDCARGA = value
        End Set
    End Property

    Private _FECHACARGA As DateTime
    Public Property FECHACARGA() As DateTime
        Get
            Return _FECHACARGA
        End Get
        Set(ByVal value As DateTime)
            _FECHACARGA = value
        End Set
    End Property

    Private _FECHAINICIAL As DateTime
    Public Property FECHAINICIAL() As DateTime
        Get
            Return _FECHAINICIAL
        End Get
        Set(ByVal value As DateTime)
            _FECHAINICIAL = value
        End Set
    End Property

    Private _FECHAFINAL As DateTime
    Public Property FECHAFINAL() As DateTime
        Get
            Return _FECHAFINAL
        End Get
        Set(ByVal value As DateTime)
            _FECHAFINAL = value
        End Set
    End Property

    Private _IDEMPLEADO As Int32
    Public Property IDEMPLEADO() As Int32
        Get
            Return _IDEMPLEADO
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADO = value
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
