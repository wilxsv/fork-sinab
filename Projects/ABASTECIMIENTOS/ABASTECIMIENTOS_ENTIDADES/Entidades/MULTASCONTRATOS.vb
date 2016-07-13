''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.MULTASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSMULTASCONTRATOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	21/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class MULTASCONTRATOS
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

    Private _IDPROVEEDOR As Int32
    Public Property IDPROVEEDOR() As Int32
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int32)
            _IDPROVEEDOR = value
        End Set
    End Property

    Private _IDCONTRATO As Int64
    Public Property IDCONTRATO() As Int64
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Int64)
            _IDCONTRATO = value
        End Set
    End Property

    Private _IDMULTA As Int64
    Public Property IDMULTA() As Int64
        Get
            Return _IDMULTA
        End Get
        Set(ByVal value As Int64)
            _IDMULTA = value
        End Set
    End Property

    Private _IDPLANTILLA As Int32
    Public Property IDPLANTILLA() As Int32
        Get
            Return _IDPLANTILLA
        End Get
        Set(ByVal value As Int32)
            _IDPLANTILLA = value
        End Set
    End Property

    Private _FECHAMULTA As DateTime
    Public Property FECHAMULTA() As DateTime
        Get
            Return _FECHAMULTA
        End Get
        Set(ByVal value As DateTime)
            _FECHAMULTA = value
        End Set
    End Property

    Private _NUMEROINFORMESEGUIMIENTO As String
    Public Property NUMEROINFORMESEGUIMIENTO() As String
        Get
            Return _NUMEROINFORMESEGUIMIENTO
        End Get
        Set(ByVal value As String)
            _NUMEROINFORMESEGUIMIENTO = value
        End Set
    End Property

    Private _NUMEROMULTA As String
    Public Property NUMEROMULTA() As String
        Get
            Return _NUMEROMULTA
        End Get
        Set(ByVal value As String)
            _NUMEROMULTA = value
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

    Private _TIPODOCUMENTO As Int16
    Public Property TIPODOCUMENTO() As Int16
        Get
            Return _TIPODOCUMENTO
        End Get
        Set(ByVal value As Int16)
            _TIPODOCUMENTO = value
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
