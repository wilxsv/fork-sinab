''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLECOMISIONEVALUADORA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLECOMISIONEVALUADORA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	26/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLECOMISIONEVALUADORA
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

    Private _IDCOMISION As Int64
    Public Property IDCOMISION() As Int64
        Get
            Return _IDCOMISION
        End Get
        Set(ByVal value As Int64)
            _IDCOMISION = value
        End Set
    End Property

    Private _IDDETALLE As Int64
    Public Property IDDETALLE() As Int64
        Get
            Return _IDDETALLE
        End Get
        Set(ByVal value As Int64)
            _IDDETALLE = value
        End Set
    End Property

    Private _IDEMPLEADO As Int32
    Public Property IDEMPLEADO() As Int32
        Get
            Return _IDEMPLEADO
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADO = value
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

    Private _CARGO As String
    Public Property CARGO() As String
        Get
            Return _CARGO
        End Get
        Set(ByVal value As String)
            _CARGO = value
        End Set
    End Property

    Private _ESTAHABILITADO As Int16
    Public Property ESTAHABILITADO() As Int16
        Get
            Return _ESTAHABILITADO
        End Get
        Set(ByVal value As Int16)
            _ESTAHABILITADO = value
        End Set
    End Property

    Private _IDPADRE As Int64
    Public Property IDPADRE() As Int64
        Get
            Return _IDPADRE
        End Get
        Set(ByVal value As Int64)
            _IDPADRE = value
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
