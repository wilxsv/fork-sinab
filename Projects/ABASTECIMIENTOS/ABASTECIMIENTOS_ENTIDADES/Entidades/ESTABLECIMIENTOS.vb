''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.ESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSESTABLECIMIENTOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ESTABLECIMIENTOS
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

    Private _CODIGOESTABLECIMIENTO As String
    Public Property CODIGOESTABLECIMIENTO() As String
        Get
            Return _CODIGOESTABLECIMIENTO
        End Get
        Set(ByVal value As String)
            _CODIGOESTABLECIMIENTO = value
        End Set
    End Property

    Private _IDMUNICIPIO As Int16
    Public Property IDMUNICIPIO() As Int16
        Get
            Return _IDMUNICIPIO
        End Get
        Set(ByVal value As Int16)
            _IDMUNICIPIO = value
        End Set
    End Property

    Private _IDTIPOESTABLECIMIENTO As Byte
    Public Property IDTIPOESTABLECIMIENTO() As Byte
        Get
            Return _IDTIPOESTABLECIMIENTO
        End Get
        Set(ByVal value As Byte)
            _IDTIPOESTABLECIMIENTO = value
        End Set
    End Property

    Private _IDZONA As Int32
    Public Property IDZONA() As Int32
        Get
            Return _IDZONA
        End Get
        Set(ByVal value As Int32)
            _IDZONA = value
        End Set
    End Property

    Private _IDINSTITUCION As Int32
    Public Property IDINSTITUCION() As Int32
        Get
            Return _IDINSTITUCION
        End Get
        Set(ByVal value As Int32)
            _IDINSTITUCION = value
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

    Private _DIRECCION As String
    Public Property DIRECCION() As String
        Get
            Return _DIRECCION
        End Get
        Set(ByVal value As String)
            _DIRECCION = value
        End Set
    End Property

    Private _TELEFONO As String
    Public Property TELEFONO() As String
        Get
            Return _TELEFONO
        End Get
        Set(ByVal value As String)
            _TELEFONO = value
        End Set
    End Property

    Private _FAX As String
    Public Property FAX() As String
        Get
            Return _FAX
        End Get
        Set(ByVal value As String)
            _FAX = value
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

    Private _NIVEL As Int32
    Public Property NIVEL() As Int32
        Get
            Return _NIVEL
        End Get
        Set(ByVal value As Int32)
            _NIVEL = value
        End Set
    End Property

    Private _TIPOCONSUMO As String
    Public Property TIPOCONSUMO() As String
        Get
            Return _TIPOCONSUMO
        End Get
        Set(ByVal value As String)
            _TIPOCONSUMO = value
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
