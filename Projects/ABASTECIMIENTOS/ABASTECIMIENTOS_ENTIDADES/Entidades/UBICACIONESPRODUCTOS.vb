''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.UBICACIONESPRODUCTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSUBICACIONESPRODUCTOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class UBICACIONESPRODUCTOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDALMACEN As Int32
    Public Property IDALMACEN() As Int32
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Int32)
            _IDALMACEN = value
        End Set
    End Property

    Private _IDPRODUCTO As Int64
    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            _IDPRODUCTO = value
        End Set
    End Property

    Private _IDUBICACION As Int32
    Public Property IDUBICACION() As Int32
        Get
            Return _IDUBICACION
        End Get
        Set(ByVal value As Int32)
            _IDUBICACION = value
        End Set
    End Property

    Private _UBICACION As String
    Public Property UBICACION() As String
        Get
            Return _UBICACION
        End Get
        Set(ByVal value As String)
            _UBICACION = value
        End Set
    End Property

    Private _IDLOTE As Int64
    Public Property IDLOTE() As Int64
        Get
            Return _IDLOTE
        End Get
        Set(ByVal value As Int64)
            _IDLOTE = value
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
