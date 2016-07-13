''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.MUNICIPIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSMUNICIPIOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class MUNICIPIOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDMUNICIPIO As Int16
    Public Property IDMUNICIPIO() As Int16
        Get
            Return _IDMUNICIPIO
        End Get
        Set(ByVal value As Int16)
            _IDMUNICIPIO = value
        End Set
    End Property

    Private _CODIGOMUNICIPIO As String
    Public Property CODIGOMUNICIPIO() As String
        Get
            Return _CODIGOMUNICIPIO
        End Get
        Set(ByVal value As String)
            _CODIGOMUNICIPIO = value
        End Set
    End Property

    Private _IDDEPARTAMENTO As Int16
    Public Property IDDEPARTAMENTO() As Int16
        Get
            Return _IDDEPARTAMENTO
        End Get
        Set(ByVal value As Int16)
            _IDDEPARTAMENTO = value
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

#End Region

End Class
