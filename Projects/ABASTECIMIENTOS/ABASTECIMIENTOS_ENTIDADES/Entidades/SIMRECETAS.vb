''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.SIMRECETAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSSIMRECETAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class SIMRECETAS
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

    Private _NUMRE As String
    Public Property NUMRE() As String
        Get
            Return _NUMRE
        End Get
        Set(ByVal value As String)
            _NUMRE = value
        End Set
    End Property

    Private _CODMED As String
    Public Property CODMED() As String
        Get
            Return _CODMED
        End Get
        Set(ByVal value As String)
            _CODMED = value
        End Set
    End Property

    Private _CODDEP As String
    Public Property CODDEP() As String
        Get
            Return _CODDEP
        End Get
        Set(ByVal value As String)
            _CODDEP = value
        End Set
    End Property

    Private _FECHA As DateTime
    Public Property FECHA() As DateTime
        Get
            Return _FECHA
        End Get
        Set(ByVal value As DateTime)
            _FECHA = value
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
