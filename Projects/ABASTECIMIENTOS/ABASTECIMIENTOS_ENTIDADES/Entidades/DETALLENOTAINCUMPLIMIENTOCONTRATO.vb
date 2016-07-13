''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLENOTAINCUMPLIMIENTOCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLENOTAINCUMPLIMIENTOCONTRATO en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	18/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLENOTAINCUMPLIMIENTOCONTRATO
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

    Private _IDNOTA As Int32
    Public Property IDNOTA() As Int32
        Get
            Return _IDNOTA
        End Get
        Set(ByVal value As Int32)
            _IDNOTA = value
        End Set
    End Property

    Private _IDDETALLENOTAINCUMPLIMIENTOCONTRATO As Int64
    Public Property IDDETALLENOTAINCUMPLIMIENTOCONTRATO() As Int64
        Get
            Return _IDDETALLENOTAINCUMPLIMIENTOCONTRATO
        End Get
        Set(ByVal value As Int64)
            _IDDETALLENOTAINCUMPLIMIENTOCONTRATO = value
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

    Private _CANTIDADENTREGADAATRASO As Decimal
    Public Property CANTIDADENTREGADAATRASO() As Decimal
        Get
            Return _CANTIDADENTREGADAATRASO
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADENTREGADAATRASO = value
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

    Private _MONTOATRASO As Decimal
    Public Property MONTOATRASO() As Decimal
        Get
            Return _MONTOATRASO
        End Get
        Set(ByVal value As Decimal)
            _MONTOATRASO = value
        End Set
    End Property

    Private _DIASATRASO As Int16
    Public Property DIASATRASO() As Int16
        Get
            Return _DIASATRASO
        End Get
        Set(ByVal value As Int16)
            _DIASATRASO = value
        End Set
    End Property

    Private _PORCENTAJEINCLUMPLIMIENTO As Decimal
    Public Property PORCENTAJEINCLUMPLIMIENTO() As Decimal
        Get
            Return _PORCENTAJEINCLUMPLIMIENTO
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJEINCLUMPLIMIENTO = value
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
