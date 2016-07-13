''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.MENSAJES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSALMACENES en memoria
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	17/12/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class MENSAJES
    Inherits entidadBase

#Region " Propiedades "

    Private _IDMENSAJE As Int32
    Public Property IDMENSAJE() As Int32
        Get
            Return _IDMENSAJE
        End Get
        Set(ByVal value As Int32)
            _IDMENSAJE = value
        End Set
    End Property

    Private _FECHAINICIO As DateTime

    Public Property FECHAINICIO() As DateTime
        Get
            Return _FECHAINICIO
        End Get
        Set(ByVal value As DateTime)
            _FECHAINICIO = value
        End Set
    End Property

    Private _FECHAFIN As DateTime
    Public Property FECHAFIN() As DateTime
        Get
            Return _FECHAFIN
        End Get
        Set(ByVal value As DateTime)
            _FECHAFIN = value
        End Set
    End Property

    Private _MENSAJE As String
    Public Property MENSAJE() As String
        Get
            Return _MENSAJE
        End Get
        Set(ByVal value As String)
            _MENSAJE = value
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
