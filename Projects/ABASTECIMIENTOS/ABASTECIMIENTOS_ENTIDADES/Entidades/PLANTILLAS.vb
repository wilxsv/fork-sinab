''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.PLANTILLAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSPLANTILLAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class PLANTILLAS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDPLANTILLA As Int32
    Public Property IDPLANTILLA() As Int32
        Get
            Return _IDPLANTILLA
        End Get
        Set(ByVal value As Int32)
            _IDPLANTILLA = value
        End Set
    End Property

    Private _IDTIPOCOMPRA As Int32
    Public Property IDTIPOCOMPRA() As Int32
        Get
            Return _IDTIPOCOMPRA
        End Get
        Set(ByVal value As Int32)
            _IDTIPOCOMPRA = value
        End Set
    End Property

    Private _NOMBRE As String
    Public Property NOMBRE() As String
        Get
            Return _NOMBRE
        End Get
        Set(ByVal value As String)
            _NOMBRE = value
        End Set
    End Property

    Private _CODIGOFUENTE As String
    Public Property CODIGOFUENTE() As String
        Get
            Return _CODIGOFUENTE
        End Get
        Set(ByVal value As String)
            _CODIGOFUENTE = value
        End Set
    End Property

    Private _TIPOPLANTILLA As Byte
    Public Property TIPOPLANTILLA() As Byte
        Get
            Return _TIPOPLANTILLA
        End Get
        Set(ByVal value As Byte)
            _TIPOPLANTILLA = value
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
