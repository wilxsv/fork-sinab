''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.MOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSMOVIMIENTOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	06/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class MOVIMIENTOS
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

    Private _IDTIPOTRANSACCION As Int32
    Public Property IDTIPOTRANSACCION() As Int32
        Get
            Return _IDTIPOTRANSACCION
        End Get
        Set(ByVal value As Int32)
            _IDTIPOTRANSACCION = value
        End Set
    End Property

    Private _IDMOVIMIENTO As Int64
    Public Property IDMOVIMIENTO() As Int64
        Get
            Return _IDMOVIMIENTO
        End Get
        Set(ByVal value As Int64)
            _IDMOVIMIENTO = value
        End Set
    End Property

    Private _IDTIPODOCREF As Int32
    Public Property IDTIPODOCREF() As Int32
        Get
            Return _IDTIPODOCREF
        End Get
        Set(ByVal value As Int32)
            _IDTIPODOCREF = value
        End Set
    End Property

    Private _NUMERODOCREF As String
    Public Property NUMERODOCREF() As String
        Get
            Return _NUMERODOCREF
        End Get
        Set(ByVal value As String)
            _NUMERODOCREF = value
        End Set
    End Property

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

    Private _IDDOCUMENTO As Int32
    Public Property IDDOCUMENTO() As Int32
        Get
            Return _IDDOCUMENTO
        End Get
        Set(ByVal value As Int32)
            _IDDOCUMENTO = value
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

    Private _FECHAMOVIMIENTO As DateTime
    Public Property FECHAMOVIMIENTO() As DateTime
        Get
            Return _FECHAMOVIMIENTO
        End Get
        Set(ByVal value As DateTime)
            _FECHAMOVIMIENTO = value
        End Set
    End Property

    Private _IDESTABLECIMIENTODESTINO As Int32
    Public Property IDESTABLECIMIENTODESTINO() As Int32
        Get
            Return _IDESTABLECIMIENTODESTINO
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTODESTINO = value
        End Set
    End Property

    Private _IDALMACENDESTINO As Int32
    Public Property IDALMACENDESTINO() As Int32
        Get
            Return _IDALMACENDESTINO
        End Get
        Set(ByVal value As Int32)
            _IDALMACENDESTINO = value
        End Set
    End Property

    Private _IDUNIDADSOLICITA As Int32
    Public Property IDUNIDADSOLICITA() As Int32
        Get
            Return _IDUNIDADSOLICITA
        End Get
        Set(ByVal value As Int32)
            _IDUNIDADSOLICITA = value
        End Set
    End Property

    Private _TOTALMOVIMIENTO As Decimal
    Public Property TOTALMOVIMIENTO() As Decimal
        Get
            Return _TOTALMOVIMIENTO
        End Get
        Set(ByVal value As Decimal)
            _TOTALMOVIMIENTO = value
        End Set
    End Property

    Private _IDEMPLEADOSOLICITA As Int32
    Public Property IDEMPLEADOSOLICITA() As Int32
        Get
            Return _IDEMPLEADOSOLICITA
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADOSOLICITA = value
        End Set
    End Property

    Private _IDEMPLEADOAUTORIZA As Int32
    Public Property IDEMPLEADOAUTORIZA() As Int32
        Get
            Return _IDEMPLEADOAUTORIZA
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADOAUTORIZA = value
        End Set
    End Property

    Private _IDEMPLEADOALMACEN As Int32
    Public Property IDEMPLEADOALMACEN() As Int32
        Get
            Return _IDEMPLEADOALMACEN
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADOALMACEN = value
        End Set
    End Property

    Private _EMPLEADOALMACEN As String
    Public Property EMPLEADOALMACEN() As String
        Get
            Return _EMPLEADOALMACEN
        End Get
        Set(ByVal value As String)
            _EMPLEADOALMACEN = value
        End Set
    End Property

    Private _IDEMPLEADODESPACHA As Int32
    Public Property IDEMPLEADODESPACHA() As Int32
        Get
            Return _IDEMPLEADODESPACHA
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADODESPACHA = value
        End Set
    End Property

    Private _IDEMPLEADORECIBE As Int32
    Public Property IDEMPLEADORECIBE() As Int32
        Get
            Return _IDEMPLEADORECIBE
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADORECIBE = value
        End Set
    End Property

    Private _IDEMPLEADOPREPARA As Int32
    Public Property IDEMPLEADOPREPARA() As Int32
        Get
            Return _IDEMPLEADOPREPARA
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADOPREPARA = value
        End Set
    End Property

    Private _IDEMPLEADOENVIADO As Int32
    Public Property IDEMPLEADOENVIADO() As Int32
        Get
            Return _IDEMPLEADOENVIADO
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADOENVIADO = value
        End Set
    End Property

    Private _CLASIFICACIONMOVIMIENTO As Byte
    Public Property CLASIFICACIONMOVIMIENTO() As Byte
        Get
            Return _CLASIFICACIONMOVIMIENTO
        End Get
        Set(ByVal value As Byte)
            _CLASIFICACIONMOVIMIENTO = value
        End Set
    End Property

    Private _SUBCLASIFICACIONMOVIMIENTO As Byte
    Public Property SUBCLASIFICACIONMOVIMIENTO() As Byte
        Get
            Return _SUBCLASIFICACIONMOVIMIENTO
        End Get
        Set(ByVal value As Byte)
            _SUBCLASIFICACIONMOVIMIENTO = value
        End Set
    End Property

    Private _RESPONSABLEDISTRIBUCION As String
    Public Property RESPONSABLEDISTRIBUCION() As String
        Get
            Return _RESPONSABLEDISTRIBUCION
        End Get
        Set(ByVal value As String)
            _RESPONSABLEDISTRIBUCION = value
        End Set
    End Property

    Private _MOTIVO As String
    Public Property MOTIVO() As String
        Get
            Return _MOTIVO
        End Get
        Set(ByVal value As String)
            _MOTIVO = value
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

    Private _EMPLEADOPREPARA As String
    Public Property EMPLEADOPREPARA() As String
        Get
            Return _EMPLEADOPREPARA
        End Get
        Set(ByVal value As String)
            _EMPLEADOPREPARA = value
        End Set
    End Property
    Private _ID_LUGAR_ENTREGA_HOSPITAL As Int32
    Public Property ID_LUGAR_ENTREGA_HOSPITAL() As Int32
        Get
            Return _ID_LUGAR_ENTREGA_HOSPITAL
        End Get
        Set(ByVal value As Int32)
            _ID_LUGAR_ENTREGA_HOSPITAL = value
        End Set
    End Property
#End Region

End Class
