''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLENECESIDADESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLENECESIDADESTABLECIMIENTOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLENECESIDADESTABLECIMIENTOS
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

    Private _IDPRODUCTO As Int64
    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            _IDPRODUCTO = value
        End Set
    End Property

    Private _IDUNIDADMEDIDA As Int32
    Public Property IDUNIDADMEDIDA() As Int32
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Int32)
            _IDUNIDADMEDIDA = value
        End Set
    End Property

    Private _CONSUMOANUAL As Decimal
    Public Property CONSUMOANUAL() As Decimal
        Get
            Return _CONSUMOANUAL
        End Get
        Set(ByVal value As Decimal)
            _CONSUMOANUAL = value
        End Set
    End Property

    Private _DEMANDAINSATISFECHA As Decimal
    Public Property DEMANDAINSATISFECHA() As Decimal
        Get
            Return _DEMANDAINSATISFECHA
        End Get
        Set(ByVal value As Decimal)
            _DEMANDAINSATISFECHA = value
        End Set
    End Property

    Private _RESERVAESTABLECIMIENTO As Decimal
    Public Property RESERVAESTABLECIMIENTO() As Decimal
        Get
            Return _RESERVAESTABLECIMIENTO
        End Get
        Set(ByVal value As Decimal)
            _RESERVAESTABLECIMIENTO = value
        End Set
    End Property

    Private _RESERVATOTAL As Decimal
    Public Property RESERVATOTAL() As Decimal
        Get
            Return _RESERVATOTAL
        End Get
        Set(ByVal value As Decimal)
            _RESERVATOTAL = value
        End Set
    End Property

    Private _EXISTENCIAESTIMADA As Decimal
    Public Property EXISTENCIAESTIMADA() As Decimal
        Get
            Return _EXISTENCIAESTIMADA
        End Get
        Set(ByVal value As Decimal)
            _EXISTENCIAESTIMADA = value
        End Set
    End Property

    Private _PRECIOUNITARIO As Decimal
    Public Property PRECIOUNITARIO() As Decimal
        Get
            Return _PRECIOUNITARIO
        End Get
        Set(ByVal value As Decimal)
            _PRECIOUNITARIO = value
        End Set
    End Property

    Private _NECESIDADREAL As Decimal
    Public Property NECESIDADREAL() As Decimal
        Get
            Return _NECESIDADREAL
        End Get
        Set(ByVal value As Decimal)
            _NECESIDADREAL = value
        End Set
    End Property

    Private _NECESIDADAJUSTADA As Decimal
    Public Property NECESIDADAJUSTADA() As Decimal
        Get
            Return _NECESIDADAJUSTADA
        End Get
        Set(ByVal value As Decimal)
            _NECESIDADAJUSTADA = value
        End Set
    End Property

    Private _NECESIDADFINAL As Decimal
    Public Property NECESIDADFINAL() As Decimal
        Get
            Return _NECESIDADFINAL
        End Get
        Set(ByVal value As Decimal)
            _NECESIDADFINAL = value
        End Set
    End Property

    Private _PRESUPUESTOREAL As Decimal
    Public Property PRESUPUESTOREAL() As Decimal
        Get
            Return _PRESUPUESTOREAL
        End Get
        Set(ByVal value As Decimal)
            _PRESUPUESTOREAL = value
        End Set
    End Property

    Private _PRESUPUESTOAJUSTADO As Decimal
    Public Property PRESUPUESTOAJUSTADO() As Decimal
        Get
            Return _PRESUPUESTOAJUSTADO
        End Get
        Set(ByVal value As Decimal)
            _PRESUPUESTOAJUSTADO = value
        End Set
    End Property

    Private _PRESUPUESTOFINAL As Decimal
    Public Property PRESUPUESTOFINAL() As Decimal
        Get
            Return _PRESUPUESTOFINAL
        End Get
        Set(ByVal value As Decimal)
            _PRESUPUESTOFINAL = value
        End Set
    End Property

    Private _COSTOTOTALREAL As Decimal
    Public Property COSTOTOTALREAL() As Decimal
        Get
            Return _COSTOTOTALREAL
        End Get
        Set(ByVal value As Decimal)
            _COSTOTOTALREAL = value
        End Set
    End Property

    Private _COSTOTOTALAJUSTADO As Decimal
    Public Property COSTOTOTALAJUSTADO() As Decimal
        Get
            Return _COSTOTOTALAJUSTADO
        End Get
        Set(ByVal value As Decimal)
            _COSTOTOTALAJUSTADO = value
        End Set
    End Property
    Private _COMPRASENTRANSITO As Decimal
    Public Property COMPRASENTRANSITO() As Decimal
        Get
            Return _COMPRASENTRANSITO
        End Get
        Set(ByVal value As Decimal)
            _COMPRASENTRANSITO = value
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
