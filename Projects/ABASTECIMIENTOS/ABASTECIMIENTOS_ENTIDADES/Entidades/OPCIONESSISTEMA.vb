''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.OPCIONESSISTEMA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSOPCIONESSISTEMA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	13/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class OPCIONESSISTEMA
    Inherits entidadBase

#Region " Propiedades "

    Private _IDOPCIONSISTEMA As Int32
    Public Property IDOPCIONSISTEMA() As Int32
        Get
            Return _IDOPCIONSISTEMA
        End Get
        Set(ByVal value As Int32)
            _IDOPCIONSISTEMA = value
        End Set
    End Property

    Private _DESCRIPCION As String
    Public Property DESCRIPCION() As String
        Get
            Return _DESCRIPCION
        End Get
        Set(ByVal value As String)
            _DESCRIPCION = value
        End Set
    End Property

    Private _URL As String
    Public Property URL() As String
        Get
            Return _URL
        End Get
        Set(ByVal value As String)
            _URL = value
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

    Private _IDPADRE As Int32
    Public Property IDPADRE() As Int32
        Get
            Return _IDPADRE
        End Get
        Set(ByVal value As Int32)
            _IDPADRE = value
        End Set
    End Property

    Private _ORDEN As Int16
    Public Property ORDEN() As Int16
        Get
            Return _ORDEN
        End Get
        Set(ByVal value As Int16)
            _ORDEN = value
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
