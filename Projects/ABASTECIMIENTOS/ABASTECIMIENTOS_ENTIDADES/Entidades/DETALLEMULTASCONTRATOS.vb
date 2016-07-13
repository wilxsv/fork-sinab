''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLEMULTASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLEMULTASCONTRATOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLEMULTASCONTRATOS
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

    Private _IDMULTA As Int64
    Public Property IDMULTA() As Int64
        Get
            Return _IDMULTA
        End Get
        Set(ByVal value As Int64)
            _IDMULTA = value
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

    Private _RENGLON As Int64
    Public Property RENGLON() As Int64
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Int64)
            _RENGLON = value
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

    Private _CANTIDADCONTRATADA As Decimal
    Public Property CANTIDADCONTRATADA() As Decimal
        Get
            Return _CANTIDADCONTRATADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADCONTRATADA = value
        End Set
    End Property

    Private _CANTIDADENTREGAATRASO As Decimal
    Public Property CANTIDADENTREGAATRASO() As Decimal
        Get
            Return _CANTIDADENTREGAATRASO
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADENTREGAATRASO = value
        End Set
    End Property

    Private _FECHAENTREGAPROGRAMADA As DateTime
    Public Property FECHAENTREGAPROGRAMADA() As DateTime
        Get
            Return _FECHAENTREGAPROGRAMADA
        End Get
        Set(ByVal value As DateTime)
            _FECHAENTREGAPROGRAMADA = value
        End Set
    End Property

    Private _FECHAENTREGAREAL As DateTime
    Public Property FECHAENTREGAREAL() As DateTime
        Get
            Return _FECHAENTREGAREAL
        End Get
        Set(ByVal value As DateTime)
            _FECHAENTREGAREAL = value
        End Set
    End Property

    Private _DIASATRASO As Int32
    Public Property DIASATRASO() As Int32
        Get
            Return _DIASATRASO
        End Get
        Set(ByVal value As Int32)
            _DIASATRASO = value
        End Set
    End Property

    Private _MONTOINCUMPLIDO As Decimal
    Public Property MONTOINCUMPLIDO() As Decimal
        Get
            Return _MONTOINCUMPLIDO
        End Get
        Set(ByVal value As Decimal)
            _MONTOINCUMPLIDO = value
        End Set
    End Property

    Private _PORCENTAJECALCULO As Decimal
    Public Property PORCENTAJECALCULO() As Decimal
        Get
            Return _PORCENTAJECALCULO
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJECALCULO = value
        End Set
    End Property

    Private _ENTREGA As Int32
    Public Property ENTREGA() As Int32
        Get
            Return _ENTREGA
        End Get
        Set(ByVal value As Int32)
            _ENTREGA = value
        End Set
    End Property

    Private _TIPOINCUMPLIMIENTO As Int16
    Public Property TIPOINCUMPLIMIENTO() As Int16
        Get
            Return _TIPOINCUMPLIMIENTO
        End Get
        Set(ByVal value As Int16)
            _TIPOINCUMPLIMIENTO = value
        End Set
    End Property

    Private _JUSTIFICACION As String
    Public Property JUSTIFICACION() As String
        Get
            Return _JUSTIFICACION
        End Get
        Set(ByVal value As String)
            _JUSTIFICACION = value
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
