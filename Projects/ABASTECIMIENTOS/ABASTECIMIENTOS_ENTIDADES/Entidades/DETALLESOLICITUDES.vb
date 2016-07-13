''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLESOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLESOLICITUDES en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLESOLICITUDES
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

    Private _IDDETALLE As Int64
    Public Property IDDETALLE() As Int64
        Get
            Return _IDDETALLE
        End Get
        Set(ByVal value As Int64)
            _IDDETALLE = value
        End Set
    End Property

    Private _RENGLON As Int32
    Public Property RENGLON() As Int32
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Int32)
            _RENGLON = value
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

    Private _CANTIDAD As Int64
    Public Property CANTIDAD() As Int64
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal value As Int64)
            _CANTIDAD = value
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

    Private _PRESUPUESTOUNITARIO As Decimal
    Public Property PRESUPUESTOUNITARIO() As Decimal
        Get
            Return _PRESUPUESTOUNITARIO
        End Get
        Set(ByVal value As Decimal)
            _PRESUPUESTOUNITARIO = value
        End Set
    End Property

    Private _PRESUPUESTOTOTAL As Decimal
    Public Property PRESUPUESTOTOTAL() As Decimal
        Get
            Return _PRESUPUESTOTOTAL
        End Get
        Set(ByVal value As Decimal)
            _PRESUPUESTOTOTAL = value
        End Set
    End Property

    Private _NUMEROENTREGAS As Byte
    Public Property NUMEROENTREGAS() As Byte
        Get
            Return _NUMEROENTREGAS
        End Get
        Set(ByVal value As Byte)
            _NUMEROENTREGAS = value
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
    Private _IDESPECIFICACION As Integer
    Public Property IDESPECIFICACION() As Integer
        Get
            Return _IDESPECIFICACION
        End Get
        Set(ByVal value As Integer)
            _IDESPECIFICACION = value
        End Set
    End Property
#End Region

End Class
