''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLEOFERTA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLEOFERTA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	12/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLEOFERTA
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

    Private _IDPROCESOCOMPRA As Int64
    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Int64)
            _IDPROCESOCOMPRA = value
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

    Private _CORRELATIVORENGLON As Int16
    Public Property CORRELATIVORENGLON() As Int16
        Get
            Return _CORRELATIVORENGLON
        End Get
        Set(ByVal value As Int16)
            _CORRELATIVORENGLON = value
        End Set
    End Property

    Private _CASAREPRESENTADA As String
    Public Property CASAREPRESENTADA() As String
        Get
            Return _CASAREPRESENTADA
        End Get
        Set(ByVal value As String)
            _CASAREPRESENTADA = value
        End Set
    End Property

    Private _MARCA As String
    Public Property MARCA() As String
        Get
            Return _MARCA
        End Get
        Set(ByVal value As String)
            _MARCA = value
        End Set
    End Property

    Private _ORIGEN As String
    Public Property ORIGEN() As String
        Get
            Return _ORIGEN
        End Get
        Set(ByVal value As String)
            _ORIGEN = value
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

    Private _VENCIMIENTO As String
    Public Property VENCIMIENTO() As String
        Get
            Return _VENCIMIENTO
        End Get
        Set(ByVal value As String)
            _VENCIMIENTO = value
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

    Private _CANTIDAD As Int64
    Public Property CANTIDAD() As Int64
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal value As Int64)
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

    Private _PLAZOENTREGA As String
    Public Property PLAZOENTREGA() As String
        Get
            Return _PLAZOENTREGA
        End Get
        Set(ByVal value As String)
            _PLAZOENTREGA = value
        End Set
    End Property

    Private _NUMEROCSSP As String
    Public Property NUMEROCSSP() As String
        Get
            Return _NUMEROCSSP
        End Get
        Set(ByVal value As String)
            _NUMEROCSSP = value
        End Set
    End Property

    Private _VIGENCIA As String
    Public Property VIGENCIA() As String
        Get
            Return _VIGENCIA
        End Get
        Set(ByVal value As String)
            _VIGENCIA = value
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

    Private _OBSERVACIONDOCUMENTO As String
    Public Property OBSERVACIONDOCUMENTO() As String
        Get
            Return _OBSERVACIONDOCUMENTO
        End Get
        Set(ByVal value As String)
            _OBSERVACIONDOCUMENTO = value
        End Set
    End Property

    Private _IDESTADOCALIFICACION As Byte
    Public Property IDESTADOCALIFICACION() As Byte
        Get
            Return _IDESTADOCALIFICACION
        End Get
        Set(ByVal value As Byte)
            _IDESTADOCALIFICACION = value
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
