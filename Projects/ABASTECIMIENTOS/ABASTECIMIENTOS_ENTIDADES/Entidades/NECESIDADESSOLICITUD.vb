''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.NECESIDADESSOLICITUD
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSNECESIDADESSOLICITUD en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class NECESIDADESSOLICITUD
    Inherits entidadBase

#Region " Propiedades "

    Private _IDESTABLECIMIENTOSOLICITUD As Int32
    Public Property IDESTABLECIMIENTOSOLICITUD() As Int32
        Get
            Return _IDESTABLECIMIENTOSOLICITUD
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTOSOLICITUD = value
        End Set
    End Property

    Private _IDESTABLECIMIENTONECESIDAD As Int32
    Public Property IDESTABLECIMIENTONECESIDAD() As Int32
        Get
            Return _IDESTABLECIMIENTONECESIDAD
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTONECESIDAD = value
        End Set
    End Property

    Private _IDNECESIDAD As Int64
    Public Property IDNECESIDAD() As Int64
        Get
            Return _IDNECESIDAD
        End Get
        Set(ByVal value As Int64)
            _IDNECESIDAD = value
        End Set
    End Property

    Private _IDSOLICITUD As Int64
    Public Property IDSOLICITUD() As Int64
        Get
            Return _IDSOLICITUD
        End Get
        Set(ByVal value As Int64)
            _IDSOLICITUD = value
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
