''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.PRODUCTOSCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSPRODUCTOSCONTRATO en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	23/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class PRODUCTOSCONTRATO
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

    Private _RENGLON As Int64
    Public Property RENGLON() As Int64
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Int64)
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

    Private _IDUNIDADMEDIDA As Int32
    Public Property IDUNIDADMEDIDA() As Int32
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Int32)
            _IDUNIDADMEDIDA = value
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

    Private _PRECIOUNITARIO As Decimal
    Public Property PRECIOUNITARIO() As Decimal
        Get
            Return _PRECIOUNITARIO
        End Get
        Set(ByVal value As Decimal)
            _PRECIOUNITARIO = value
        End Set
    End Property

    Private _DESCRIPCIONPROVEEDOR As String
    Public Property DESCRIPCIONPROVEEDOR() As String
        Get
            Return _DESCRIPCIONPROVEEDOR
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONPROVEEDOR = value
        End Set
    End Property

    Private _ESTAHABILITADO As Byte
    Public Property ESTAHABILITADO() As Byte
        Get
            Return _ESTAHABILITADO
        End Get
        Set(ByVal value As Byte)
            _ESTAHABILITADO = value
        End Set
    End Property

    Private _FECHADESHABILITACION As DateTime
    Public Property FECHADESHABILITACION() As DateTime
        Get
            Return _FECHADESHABILITACION
        End Get
        Set(ByVal value As DateTime)
            _FECHADESHABILITACION = value
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
