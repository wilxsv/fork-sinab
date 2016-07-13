''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.EXISTENCIASALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSEXISTENCIASALMACENES en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class EXISTENCIASALMACENES
    Inherits entidadBase

#Region " Propiedades "

    Private _IDALMACEN As Int32
    Public Property IDALMACEN() As Int32
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Int32)
            _IDALMACEN = value
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

    Private _MAX As Decimal
    Public Property MAX() As Decimal
        Get
            Return _MAX
        End Get
        Set(ByVal value As Decimal)
            _MAX = value
        End Set
    End Property

    Private _MIN As Decimal
    Public Property MIN() As Decimal
        Get
            Return _MIN
        End Get
        Set(ByVal value As Decimal)
            _MIN = value
        End Set
    End Property

    Private _CANTIDADDISPONIBLE As Decimal
    Public Property CANTIDADDISPONIBLE() As Decimal
        Get
            Return _CANTIDADDISPONIBLE
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADDISPONIBLE = value
        End Set
    End Property

    Private _CANTIDADNODISPONIBLE As Decimal
    Public Property CANTIDADNODISPONIBLE() As Decimal
        Get
            Return _CANTIDADNODISPONIBLE
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADNODISPONIBLE = value
        End Set
    End Property

    Private _CANTIDADRESERVADA As Decimal
    Public Property CANTIDADRESERVADA() As Decimal
        Get
            Return _CANTIDADRESERVADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADRESERVADA = value
        End Set
    End Property

    Private _CANTIDADTEMPORAL As Decimal
    Public Property CANTIDADTEMPORAL() As Decimal
        Get
            Return _CANTIDADTEMPORAL
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADTEMPORAL = value
        End Set
    End Property

    Private _CANTIDADVENCIDA As Decimal
    Public Property CANTIDADVENCIDA() As Decimal
        Get
            Return _CANTIDADVENCIDA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADVENCIDA = value
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
