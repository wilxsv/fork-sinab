''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.OFERTAPROCESOCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSOFERTAPROCESOCOMPRA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	21/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class OFERTAPROCESOCOMPRA
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

    Private _NOMBREREPRESENTANTE As String
    Public Property NOMBREREPRESENTANTE() As String
        Get
            Return _NOMBREREPRESENTANTE
        End Get
        Set(ByVal value As String)
            _NOMBREREPRESENTANTE = value
        End Set
    End Property

    Private _MONTOOFERTA As Decimal
    Public Property MONTOOFERTA() As Decimal
        Get
            Return _MONTOOFERTA
        End Get
        Set(ByVal value As Decimal)
            _MONTOOFERTA = value
        End Set
    End Property

    Private _MONTOGARANTIA As Decimal
    Public Property MONTOGARANTIA() As Decimal
        Get
            Return _MONTOGARANTIA
        End Get
        Set(ByVal value As Decimal)
            _MONTOGARANTIA = value
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

    Private _OBSERVACION As String
    Public Property OBSERVACION() As String
        Get
            Return _OBSERVACION
        End Get
        Set(ByVal value As String)
            _OBSERVACION = value
        End Set
    End Property

    Private _ACTIVOCIRCULANTE As Decimal
    Public Property ACTIVOCIRCULANTE() As Decimal
        Get
            Return _ACTIVOCIRCULANTE
        End Get
        Set(ByVal value As Decimal)
            _ACTIVOCIRCULANTE = value
        End Set
    End Property

    Private _PASIVOCIRCULANTE As Decimal
    Public Property PASIVOCIRCULANTE() As Decimal
        Get
            Return _PASIVOCIRCULANTE
        End Get
        Set(ByVal value As Decimal)
            _PASIVOCIRCULANTE = value
        End Set
    End Property

    Private _ACTIVOTOTAL As Decimal
    Public Property ACTIVOTOTAL() As Decimal
        Get
            Return _ACTIVOTOTAL
        End Get
        Set(ByVal value As Decimal)
            _ACTIVOTOTAL = value
        End Set
    End Property

    Private _PASIVOTOTAL As Decimal
    Public Property PASIVOTOTAL() As Decimal
        Get
            Return _PASIVOTOTAL
        End Get
        Set(ByVal value As Decimal)
            _PASIVOTOTAL = value
        End Set
    End Property

    Private _PRESENTAREFERENCIASBANCARIAS As Byte
    Public Property PRESENTAREFERENCIASBANCARIAS() As Byte
        Get
            Return _PRESENTAREFERENCIASBANCARIAS
        End Get
        Set(ByVal value As Byte)
            _PRESENTAREFERENCIASBANCARIAS = value
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

    Private _FECHAEXAMEN As DateTime
    Public Property FECHAEXAMEN() As DateTime
        Get
            Return _FECHAEXAMEN
        End Get
        Set(ByVal value As DateTime)
            _FECHAEXAMEN = value
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
