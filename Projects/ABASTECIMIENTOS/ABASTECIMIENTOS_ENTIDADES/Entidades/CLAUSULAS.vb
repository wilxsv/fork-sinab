''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.CLAUSULAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCLAUSULAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CLAUSULAS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDCLAUSULA As Int32
    Public Property IDCLAUSULA() As Int32
        Get
            Return _IDCLAUSULA
        End Get
        Set(ByVal value As Int32)
            _IDCLAUSULA = value
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

    Private _CONTENIDO As String
    Public Property CONTENIDO() As String
        Get
            Return _CONTENIDO
        End Get
        Set(ByVal value As String)
            _CONTENIDO = value
        End Set
    End Property

    Private _ESREQUERIDA As Byte
    Public Property ESREQUERIDA() As Byte
        Get
            Return _ESREQUERIDA
        End Get
        Set(ByVal value As Byte)
            _ESREQUERIDA = value
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

    Private _IDMODALIDADCOMPRA As Int16
    Public Property IDMODALIDADCOMPRA() As Int16
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal value As Int16)
            _IDMODALIDADCOMPRA = value
        End Set
    End Property

    Private _MODIFICATIVA As Byte
    Public Property MODIFICATIVA() As Byte
        Get
            Return _MODIFICATIVA
        End Get
        Set(ByVal value As Byte)
            _MODIFICATIVA = value
        End Set
    End Property

#End Region

End Class
