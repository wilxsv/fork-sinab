''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.COMISIONESEVALUADORAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCOMISIONESEVALUADORAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	05/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class COMISIONESEVALUADORAS
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

    Private _NOMBRE As String
    Public Property NOMBRE() As String
        Get
            Return _NOMBRE
        End Get
        Set(ByVal value As String)
            _NOMBRE = value
        End Set
    End Property

    Private _FECHACREACION As DateTime
    Public Property FECHACREACION() As DateTime
        Get
            Return _FECHACREACION
        End Get
        Set(ByVal value As DateTime)
            _FECHACREACION = value
        End Set
    End Property

    Private _ESTADO As Int16
    Public Property ESTADO() As Int16
        Get
            Return _ESTADO
        End Get
        Set(ByVal value As Int16)
            _ESTADO = value
        End Set
    End Property

    Private _ESALTONIVEL As Int16
    Public Property ESALTONIVEL() As Int16
        Get
            Return _ESALTONIVEL
        End Get
        Set(ByVal value As Int16)
            _ESALTONIVEL = value
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
    Private _NUMRESOLUCION As String
    Public Property NUMRESOLUCION() As String
        Get
            Return _NUMRESOLUCION
        End Get
        Set(ByVal value As String)
            _NUMRESOLUCION = value
        End Set
    End Property
    Private _FECHARESOLUCION As Date
    Public Property FECHARESOLUCION() As Date
        Get
            Return _FECHARESOLUCION
        End Get
        Set(ByVal value As Date)
            _FECHARESOLUCION = value
        End Set
    End Property
#End Region

End Class
