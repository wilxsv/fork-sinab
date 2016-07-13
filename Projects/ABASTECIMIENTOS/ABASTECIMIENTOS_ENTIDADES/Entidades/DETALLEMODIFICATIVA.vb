''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLEMODIFICATIVA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLEMODIFICATIVA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLEMODIFICATIVA
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

    Private _IDMODIFICATIVA As Int64
    Public Property IDMODIFICATIVA() As Int64
        Get
            Return _IDMODIFICATIVA
        End Get
        Set(ByVal value As Int64)
            _IDMODIFICATIVA = value
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

    Private _DESCRIPCION As String
    Public Property DESCRIPCION() As String
        Get
            Return _DESCRIPCION
        End Get
        Set(ByVal value As String)
            _DESCRIPCION = value
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

    Private _CANTIDADCONTRATADA As Decimal
    Public Property CANTIDADCONTRATADA() As Decimal
        Get
            Return _CANTIDADCONTRATADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADCONTRATADA = value
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
