''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.USUARIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSUSUARIOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	05/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class USUARIOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDUSUARIO As Int32
    Public Property IDUSUARIO() As Int32
        Get
            Return _IDUSUARIO
        End Get
        Set(ByVal value As Int32)
            _IDUSUARIO = value
        End Set
    End Property

    Private _USUARIO As String
    Public Property USUARIO() As String
        Get
            Return _USUARIO
        End Get
        Set(ByVal value As String)
            _USUARIO = value
        End Set
    End Property

    Private _CLAVE As String
    Public Property CLAVE() As String
        Get
            Return _CLAVE
        End Get
        Set(ByVal value As String)
            _CLAVE = value
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

    Private _ESTAHABILITADO As Byte
    Public Property ESTAHABILITADO() As Byte
        Get
            Return _ESTAHABILITADO
        End Get
        Set(ByVal value As Byte)
            _ESTAHABILITADO = value
        End Set
    End Property

    Private _ESTAELIMINADO As Int32
    Public Property ESTAELIMINADO() As Int32
        Get
            Return _ESTAELIMINADO
        End Get
        Set(ByVal value As Int32)
            _ESTAELIMINADO = value
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

    Private _AUUSUARIOELIMINACION As String
    Public Property AUUSUARIOELIMINACION() As String
        Get
            Return _AUUSUARIOELIMINACION
        End Get
        Set(ByVal value As String)
            _AUUSUARIOELIMINACION = value
        End Set
    End Property

    Private _AUFECHAELIMINACION As DateTime
    Public Property AUFECHAELIMINACION() As DateTime
        Get
            Return _AUFECHAELIMINACION
        End Get
        Set(ByVal value As DateTime)
            _AUFECHAELIMINACION = value
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
