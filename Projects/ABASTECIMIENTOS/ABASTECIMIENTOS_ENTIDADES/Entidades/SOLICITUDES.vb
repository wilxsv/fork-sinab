''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.SOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSSOLICITUDES en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class SOLICITUDES
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

    Private _IDSOLICITUD As Int64
    Public Property IDSOLICITUD() As Int64
        Get
            Return _IDSOLICITUD
        End Get
        Set(ByVal value As Int64)
            _IDSOLICITUD = value
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

    Private _FECHASOLICITUD As DateTime
    Public Property FECHASOLICITUD() As DateTime
        Get
            Return _FECHASOLICITUD
        End Get
        Set(ByVal value As DateTime)
            _FECHASOLICITUD = value
        End Set
    End Property

    Private _PLAZOENTREGA As Int32
    Public Property PLAZOENTREGA() As Int32
        Get
            Return _PLAZOENTREGA
        End Get
        Set(ByVal value As Int32)
            _PLAZOENTREGA = value
        End Set
    End Property

    Private _IDCLASESUMINISTRO As Int32
    Public Property IDCLASESUMINISTRO() As Int32
        Get
            Return _IDCLASESUMINISTRO
        End Get
        Set(ByVal value As Int32)
            _IDCLASESUMINISTRO = value
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

    Private _MONTOSOLICITADO As Decimal
    Public Property MONTOSOLICITADO() As Decimal
        Get
            Return _MONTOSOLICITADO
        End Get
        Set(ByVal value As Decimal)
            _MONTOSOLICITADO = value
        End Set
    End Property

    Private _MONTODISPONIBLE As Decimal
    Public Property MONTODISPONIBLE() As Decimal
        Get
            Return _MONTODISPONIBLE
        End Get
        Set(ByVal value As Decimal)
            _MONTODISPONIBLE = value
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

    Private _IDSOLICITANTE As Int32
    Public Property IDSOLICITANTE() As Int32
        Get
            Return _IDSOLICITANTE
        End Get
        Set(ByVal value As Int32)
            _IDSOLICITANTE = value
        End Set
    End Property

    Private _IDAREATECNICA As Int32
    Public Property IDAREATECNICA() As Int32
        Get
            Return _IDAREATECNICA
        End Get
        Set(ByVal value As Int32)
            _IDAREATECNICA = value
        End Set
    End Property

    Private _CIFRADOPRESUPUESTARIO As String
    Public Property CIFRADOPRESUPUESTARIO() As String
        Get
            Return _CIFRADOPRESUPUESTARIO
        End Get
        Set(ByVal value As String)
            _CIFRADOPRESUPUESTARIO = value
        End Set
    End Property

    Private _RESERVAFONDO As Decimal
    Public Property RESERVAFONDO() As Decimal
        Get
            Return _RESERVAFONDO
        End Get
        Set(ByVal value As Decimal)
            _RESERVAFONDO = value
        End Set
    End Property

    Private _FECHAAUTORIZACION As DateTime
    Public Property FECHAAUTORIZACION() As DateTime
        Get
            Return _FECHAAUTORIZACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAAUTORIZACION = value
        End Set
    End Property

    Private _MONTOAUTORIZADO As Decimal
    Public Property MONTOAUTORIZADO() As Decimal
        Get
            Return _MONTOAUTORIZADO
        End Get
        Set(ByVal value As Decimal)
            _MONTOAUTORIZADO = value
        End Set
    End Property

    Private _CODRESERVAFONDO As String
    Public Property CODRESERVAFONDO() As String
        Get
            Return _CODRESERVAFONDO
        End Get
        Set(ByVal value As String)
            _CODRESERVAFONDO = value
        End Set
    End Property

    Private _IDCERTIFICA As Int32
    Public Property IDCERTIFICA() As Int32
        Get
            Return _IDCERTIFICA
        End Get
        Set(ByVal value As Int32)
            _IDCERTIFICA = value
        End Set
    End Property

    Private _IDAUTORIZA As Int32
    Public Property IDAUTORIZA() As Int32
        Get
            Return _IDAUTORIZA
        End Get
        Set(ByVal value As Int32)
            _IDAUTORIZA = value
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

    Private _IDDEPENDENCIASOLICITANTE As Int32
    Public Property IDDEPENDENCIASOLICITANTE() As Int32
        Get
            Return _IDDEPENDENCIASOLICITANTE
        End Get
        Set(ByVal value As Int32)
            _IDDEPENDENCIASOLICITANTE = value
        End Set
    End Property

    Private _IDTIPOCOMPRASOLICITADO As Int32
    Public Property IDTIPOCOMPRASOLICITADO() As Int32
        Get
            Return _IDTIPOCOMPRASOLICITADO
        End Get
        Set(ByVal value As Int32)
            _IDTIPOCOMPRASOLICITADO = value
        End Set
    End Property

    Private _IDTIPOCOMPRASUGERIDO As Int32
    Public Property IDTIPOCOMPRASUGERIDO() As Int32
        Get
            Return _IDTIPOCOMPRASUGERIDO
        End Get
        Set(ByVal value As Int32)
            _IDTIPOCOMPRASUGERIDO = value
        End Set
    End Property

    Private _IDTIPOCOMPRAEJECUTAR As Int32
    Public Property IDTIPOCOMPRAEJECUTAR() As Int32
        Get
            Return _IDTIPOCOMPRAEJECUTAR
        End Get
        Set(ByVal value As Int32)
            _IDTIPOCOMPRAEJECUTAR = value
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

    Private _COMPRACONJUNTA As Byte
    Public Property COMPRACONJUNTA() As Byte
        Get
            Return _COMPRACONJUNTA
        End Get
        Set(ByVal value As Byte)
            _COMPRACONJUNTA = value
        End Set
    End Property

    Private _NUMCORR As Int32
    Public Property NUMCORR() As Int32
        Get
            Return _NUMCORR
        End Get
        Set(ByVal value As Int32)
            _NUMCORR = value
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
    Private _EMPLEADOAREATECNICA As String
    Public Property EMPLEADOAREATECNICA() As String
        Get
            Return _EMPLEADOAREATECNICA
        End Get
        Set(ByVal value As String)
            _EMPLEADOAREATECNICA = value
        End Set
    End Property
    Private _EMPLEADOSOLICITANTE As String
    Public Property EMPLEADOSOLICITANTE() As String
        Get
            Return _EMPLEADOSOLICITANTE
        End Get
        Set(ByVal value As String)
            _EMPLEADOSOLICITANTE = value
        End Set
    End Property
    Private _EMPLEADOAUTORIZA As String
    Public Property EMPLEADOAUTORIZA() As String
        Get
            Return _EMPLEADOAUTORIZA
        End Get
        Set(ByVal value As String)
            _EMPLEADOAUTORIZA = value
        End Set
    End Property
    Private _IDESTABLECIMIENTOENTREGA As Integer
    Public Property IDESTABLECIMIENTOENTREGA() As Integer
        Get
            Return _IDESTABLECIMIENTOENTREGA
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTOENTREGA = value
        End Set
    End Property
    Private _ENTREGAS As Int32
    Public Property ENTREGAS() As Int32
        Get
            Return _ENTREGAS
        End Get
        Set(ByVal value As Int32)
            _ENTREGAS = value
        End Set
    End Property
    Private _CARGOSOLICITANTE As String
    Public Property CARGOSOLICITANTE() As String
        Get
            Return _CARGOSOLICITANTE
        End Get
        Set(ByVal value As String)
            _CARGOSOLICITANTE = value
        End Set
    End Property
    Private _IDSOLICITUDEPENDENCIA As Int32
    Public Property IDSOLICITUDEPENDENCIA() As Int32
        Get
            Return _IDSOLICITUDEPENDENCIA
        End Get
        Set(ByVal value As Int32)
            _IDSOLICITUDEPENDENCIA = value
        End Set
    End Property
    Private _IDUNIDADTECNICA As Int32
    Public Property IDUNIDADTECNICA() As Int32
        Get
            Return _IDUNIDADTECNICA
        End Get
        Set(ByVal value As Int32)
            _IDUNIDADTECNICA = value
        End Set
    End Property
    Private _GRUPOUACI As Int32
    Public Property GRUPOUACI() As Int32
        Get
            Return _grupouaci
        End Get
        Set(ByVal value As Int32)
            _GRUPOUACI = value
        End Set
    End Property
    Private _IDESPECIFICACION As Int32
    Public Property IDESPECIFICACION() As Int32
        Get
            Return _IDESPECIFICACION
        End Get
        Set(ByVal value As Int32)
            _IDESPECIFICACION = value
        End Set
    End Property
#End Region

End Class
