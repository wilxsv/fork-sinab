''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.ETIQUETASCLAUSULAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSETIQUETASCLAUSULAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ETIQUETASCLAUSULAS
    Inherits entidadBase

#Region " Propiedades "

    Private _TABLA As String
    Public Property TABLA() As String
        Get
            Return _TABLA
        End Get
        Set(ByVal value As String)
            _TABLA = value
        End Set
    End Property

    Private _CAMPO As String
    Public Property CAMPO() As String
        Get
            Return _CAMPO
        End Get
        Set(ByVal value As String)
            _CAMPO = value
        End Set
    End Property

    Private _ETIQUETA As String
    Public Property ETIQUETA() As String
        Get
            Return _ETIQUETA
        End Get
        Set(ByVal value As String)
            _ETIQUETA = value
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

    Private _MODIFICATIVA As Int16
    Public Property MODIFICATIVA() As Int16
        Get
            Return _MODIFICATIVA
        End Get
        Set(ByVal value As Int16)
            _MODIFICATIVA = value
        End Set
    End Property
#End Region

End Class
