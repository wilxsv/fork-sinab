''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLEALMACENESENTREGACONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLEALMACENESENTREGACONTRATOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLEALMACENESENTREGACONTRATOS
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

    Private _IDDETALLEENTREGA As Int64
    Public Property IDDETALLEENTREGA() As Int64
        Get
            Return _IDDETALLEENTREGA
        End Get
        Set(ByVal value As Int64)
            _IDDETALLEENTREGA = value
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

    Private _IDDETALLE As Int32
    Public Property IDDETALLE() As Int32
        Get
            Return _IDDETALLE
        End Get
        Set(ByVal value As Int32)
            _IDDETALLE = value
        End Set
    End Property

    Private _CANTIDADENTREGADA As Decimal
    Public Property CANTIDADENTREGADA() As Decimal
        Get
            Return _CANTIDADENTREGADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADENTREGADA = value
        End Set
    End Property

    Private _FECHAENTREGA As DateTime
    Public Property FECHAENTREGA() As DateTime
        Get
            Return _FECHAENTREGA
        End Get
        Set(ByVal value As DateTime)
            _FECHAENTREGA = value
        End Set
    End Property

    Private _ANULADA As Byte
    Public Property ANULADA() As Byte
        Get
            Return _ANULADA
        End Get
        Set(ByVal value As Byte)
            _ANULADA = value
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
