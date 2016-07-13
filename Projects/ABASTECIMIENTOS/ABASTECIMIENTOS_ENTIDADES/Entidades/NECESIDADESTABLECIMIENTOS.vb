''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.NECESIDADESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSNECESIDADESTABLECIMIENTOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class NECESIDADESTABLECIMIENTOS
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

    Private _IDNECESIDAD As Int64
    Public Property IDNECESIDAD() As Int64
        Get
            Return _IDNECESIDAD
        End Get
        Set(ByVal value As Int64)
            _IDNECESIDAD = value
        End Set
    End Property

    Private _PROPUESTA As Byte
    Public Property PROPUESTA() As Byte
        Get
            Return _PROPUESTA
        End Get
        Set(ByVal value As Byte)
            _PROPUESTA = value
        End Set
    End Property

    Private _CORRELATIVO As String
    Public Property CORRELATIVO() As String
        Get
            Return _CORRELATIVO
        End Get
        Set(ByVal value As String)
            _CORRELATIVO = value
        End Set
    End Property

    Private _IDESTADO As Int32
    Public Property IDESTADO() As Int32
        Get
            Return _IDESTADO
        End Get
        Set(ByVal value As Int32)
            _IDESTADO = value
        End Set
    End Property

    Private _FECHAELABORACION As DateTime
    Public Property FECHAELABORACION() As DateTime
        Get
            Return _FECHAELABORACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAELABORACION = value
        End Set
    End Property

    Private _PERIODOUTILIZACION As Int16
    Public Property PERIODOUTILIZACION() As Int16
        Get
            Return _PERIODOUTILIZACION
        End Get
        Set(ByVal value As Int16)
            _PERIODOUTILIZACION = value
        End Set
    End Property

    Private _MESINICIOPERIODO As Int16
    Public Property MESINICIOPERIODO() As Int16
        Get
            Return _MESINICIOPERIODO
        End Get
        Set(ByVal value As Int16)
            _MESINICIOPERIODO = value
        End Set
    End Property

    Private _ANIOINICIOPERIODO As Int16
    Public Property ANIOINICIOPERIODO() As Int16
        Get
            Return _ANIOINICIOPERIODO
        End Get
        Set(ByVal value As Int16)
            _ANIOINICIOPERIODO = value
        End Set
    End Property

    Private _MESFINPERIODO As Int16
    Public Property MESFINPERIODO() As Int16
        Get
            Return _MESFINPERIODO
        End Get
        Set(ByVal value As Int16)
            _MESFINPERIODO = value
        End Set
    End Property

    Private _ANIOFINPERIODO As Int16
    Public Property ANIOFINPERIODO() As Int16
        Get
            Return _ANIOFINPERIODO
        End Get
        Set(ByVal value As Int16)
            _ANIOFINPERIODO = value
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

    Private _IDALMACENENTREGA As Int32
    Public Property IDALMACENENTREGA() As Int32
        Get
            Return _IDALMACENENTREGA
        End Get
        Set(ByVal value As Int32)
            _IDALMACENENTREGA = value
        End Set
    End Property

    Private _IDSUMINISTRO As Int32
    Public Property IDSUMINISTRO() As Int32
        Get
            Return _IDSUMINISTRO
        End Get
        Set(ByVal value As Int32)
            _IDSUMINISTRO = value
        End Set
    End Property

    Private _PRESUPUESTOASIGNADO As Decimal
    Public Property PRESUPUESTOASIGNADO() As Decimal
        Get
            Return _PRESUPUESTOASIGNADO
        End Get
        Set(ByVal value As Decimal)
            _PRESUPUESTOASIGNADO = value
        End Set
    End Property

    Private _MONTONECESIDADREAL As Decimal
    Public Property MONTONECESIDADREAL() As Decimal
        Get
            Return _MONTONECESIDADREAL
        End Get
        Set(ByVal value As Decimal)
            _MONTONECESIDADREAL = value
        End Set
    End Property

    Private _MONTONECESIDADAJUSTADA As Decimal
    Public Property MONTONECESIDADAJUSTADA() As Decimal
        Get
            Return _MONTONECESIDADAJUSTADA
        End Get
        Set(ByVal value As Decimal)
            _MONTONECESIDADAJUSTADA = value
        End Set
    End Property

    Private _MONTONECESIDADFINAL As Decimal
    Public Property MONTONECESIDADFINAL() As Decimal
        Get
            Return _MONTONECESIDADFINAL
        End Get
        Set(ByVal value As Decimal)
            _MONTONECESIDADFINAL = value
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

