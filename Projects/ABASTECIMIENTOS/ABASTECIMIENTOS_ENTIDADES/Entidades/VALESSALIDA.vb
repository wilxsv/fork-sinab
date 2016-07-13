''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.VALESSALIDA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSVALESSALIDA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	06/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class VALESSALIDA
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

    Private _ANIO As Int16
    Public Property ANIO() As Int16
        Get
            Return _ANIO
        End Get
        Set(ByVal value As Int16)
            _ANIO = value
        End Set
    End Property

    Private _IDVALE As Int32
    Public Property IDVALE() As Int32
        Get
            Return _IDVALE
        End Get
        Set(ByVal value As Int32)
            _IDVALE = value
        End Set
    End Property

    Private _TRANSPORTISTA As String
    Public Property TRANSPORTISTA() As String
        Get
            Return _TRANSPORTISTA
        End Get
        Set(ByVal value As String)
            _TRANSPORTISTA = value
        End Set
    End Property

    Private _MATRICULAVEHICULO As String
    Public Property MATRICULAVEHICULO() As String
        Get
            Return _MATRICULAVEHICULO
        End Get
        Set(ByVal value As String)
            _MATRICULAVEHICULO = value
        End Set
    End Property

    Private _PERSONARECIBE As String
    Public Property PERSONARECIBE() As String
        Get
            Return _PERSONARECIBE
        End Get
        Set(ByVal value As String)
            _PERSONARECIBE = value
        End Set
    End Property

    Private _IDTIPOIDENTIFICACION As Int16
    Public Property IDTIPOIDENTIFICACION() As Int16
        Get
            Return _IDTIPOIDENTIFICACION
        End Get
        Set(ByVal value As Int16)
            _IDTIPOIDENTIFICACION = value
        End Set
    End Property

    Private _NUMEROIDENTIFICACION As String
    Public Property NUMEROIDENTIFICACION() As String
        Get
            Return _NUMEROIDENTIFICACION
        End Get
        Set(ByVal value As String)
            _NUMEROIDENTIFICACION = value
        End Set
    End Property

    Private _OBSERVACION As String
    Public Property OBSERVACION() As String
        Get
            Return _OBSERVACION
        End Get
        Set(ByVal value As String)
            _OBSERVACION = value
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
