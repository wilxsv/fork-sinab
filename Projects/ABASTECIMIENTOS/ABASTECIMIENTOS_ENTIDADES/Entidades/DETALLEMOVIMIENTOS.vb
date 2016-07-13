''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLEMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLEMOVIMIENTOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	12/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLEMOVIMIENTOS
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

    Private _IDDETALLEMOVIMIENTO As Int64
    Public Property IDDETALLEMOVIMIENTO() As Int64
        Get
            Return _IDDETALLEMOVIMIENTO
        End Get
        Set(ByVal value As Int64)
            _IDDETALLEMOVIMIENTO = value
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

    Private _IDLOTE As Int64
    Public Property IDLOTE() As Int64
        Get
            Return _IDLOTE
        End Get
        Set(ByVal value As Int64)
            _IDLOTE = value
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

    Private _RENGLON As Int64
    Public Property RENGLON() As Int64
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Int64)
            _RENGLON = value
        End Set
    End Property

    Private _CANTIDAD As Decimal
    Public Property CANTIDAD() As Decimal
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal value As Decimal)
            _CANTIDAD = value
        End Set
    End Property

    Private _CANTIDADRECHAZADA As Decimal
    Public Property CANTIDADRECHAZADA() As Decimal
        Get
            Return _CANTIDADRECHAZADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADRECHAZADA = value
        End Set
    End Property

    Private _CANTIDADANTERIOR As Decimal
    Public Property CANTIDADANTERIOR() As Decimal
        Get
            Return _CANTIDADANTERIOR
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADANTERIOR = value
        End Set
    End Property

    Private _NUMEROFACTURA As String
    Public Property NUMEROFACTURA() As String
        Get
            Return _NUMEROFACTURA
        End Get
        Set(ByVal value As String)
            _NUMEROFACTURA = value
        End Set
    End Property

    Private _FECHAFACTURA As DateTime
    Public Property FECHAFACTURA() As DateTime
        Get
            Return _FECHAFACTURA
        End Get
        Set(ByVal value As DateTime)
            _FECHAFACTURA = value
        End Set
    End Property

    Private _MONTO As Decimal
    Public Property MONTO() As Decimal
        Get
            Return _MONTO
        End Get
        Set(ByVal value As Decimal)
            _MONTO = value
        End Set
    End Property

    Private _NUMEROINFORMECONTROLCALIDAD As String
    Public Property NUMEROINFORMECONTROLCALIDAD() As String
        Get
            Return _NUMEROINFORMECONTROLCALIDAD
        End Get
        Set(ByVal value As String)
            _NUMEROINFORMECONTROLCALIDAD = value
        End Set
    End Property

    Private _IDDETALLEENTREGA As Int32
    Public Property IDDETALLEENTREGA() As Int32
        Get
            Return _IDDETALLEENTREGA
        End Get
        Set(ByVal value As Int32)
            _IDDETALLEENTREGA = value
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

    Private _NOENVIO As String
    Public Property NOENVIO() As String
        Get
            Return _NOENVIO
        End Get
        Set(ByVal value As String)
            _NOENVIO = value
        End Set
    End Property

    Private _IDTIPODOCUMENTO As Int32
    Public Property IDTIPODOCUMENTO() As Int32
        Get
            Return _IDTIPODOCUMENTO
        End Get
        Set(ByVal value As Int32)
            _IDTIPODOCUMENTO = value
        End Set
    End Property

    Private _CANTIDADNODISPONIBLE As Int16
    Public Property CANTIDADNODISPONIBLE() As Int16
        Get
            Return _CANTIDADNODISPONIBLE
        End Get
        Set(ByVal value As Int16)
            _CANTIDADNODISPONIBLE = value
        End Set
    End Property

#End Region

End Class
