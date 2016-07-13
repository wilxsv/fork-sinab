''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLEINVENTARIO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSDETALLEINVENTARIO en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLEINVENTARIO
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

    Private _IDINVENTARIO As Int32
    Public Property IDINVENTARIO() As Int32
        Get
            Return _IDINVENTARIO
        End Get
        Set(ByVal value As Int32)
            _IDINVENTARIO = value
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

    Private _IDPRODUCTO As Int64
    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            _IDPRODUCTO = value
        End Set
    End Property

    Private _IDLOTE As Int64
    Public Property IDLOTE() As Int64
        Get
            Return _IDLOTE
        End Get
        Set(ByVal value As Int64)
            _IDLOTE = value
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

    Private _PRECIO As Decimal
    Public Property PRECIO() As Decimal
        Get
            Return _PRECIO
        End Get
        Set(ByVal value As Decimal)
            _PRECIO = value
        End Set
    End Property

    Private _CANTIDADDISPONIBLESISTEMA As Decimal
    Public Property CANTIDADDISPONIBLESISTEMA() As Decimal
        Get
            Return _CANTIDADDISPONIBLESISTEMA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADDISPONIBLESISTEMA = value
        End Set
    End Property

    Private _CANTIDADDISPONIBLECAPTURA As Decimal
    Public Property CANTIDADDISPONIBLECAPTURA() As Decimal
        Get
            Return _CANTIDADDISPONIBLECAPTURA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADDISPONIBLECAPTURA = value
        End Set
    End Property

    Private _CANTIDADDISPONIBLEDIFERENCIA As Decimal
    Public Property CANTIDADDISPONIBLEDIFERENCIA() As Decimal
        Get
            Return _CANTIDADDISPONIBLEDIFERENCIA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADDISPONIBLEDIFERENCIA = value
        End Set
    End Property

    Private _CANTIDADNODISPONIBLESISTEMA As Decimal
    Public Property CANTIDADNODISPONIBLESISTEMA() As Decimal
        Get
            Return _CANTIDADNODISPONIBLESISTEMA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADNODISPONIBLESISTEMA = value
        End Set
    End Property

    Private _CANTIDADNODISPONIBLECAPTURA As Decimal
    Public Property CANTIDADNODISPONIBLECAPTURA() As Decimal
        Get
            Return _CANTIDADNODISPONIBLECAPTURA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADNODISPONIBLECAPTURA = value
        End Set
    End Property

    Private _CANTIDADNODISPONIBLEDIFERENCIA As Decimal
    Public Property CANTIDADNODISPONIBLEDIFERENCIA() As Decimal
        Get
            Return _CANTIDADNODISPONIBLEDIFERENCIA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADNODISPONIBLEDIFERENCIA = value
        End Set
    End Property

    Private _CANTIDADVENCIDASISTEMA As Decimal
    Public Property CANTIDADVENCIDASISTEMA() As Decimal
        Get
            Return _CANTIDADVENCIDASISTEMA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADVENCIDASISTEMA = value
        End Set
    End Property

    Private _CANTIDADVENCIDACAPTURA As Decimal
    Public Property CANTIDADVENCIDACAPTURA() As Decimal
        Get
            Return _CANTIDADVENCIDACAPTURA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADVENCIDACAPTURA = value
        End Set
    End Property

    Private _CANTIDADVENCIDADIFERENCIA As Decimal
    Public Property CANTIDADVENCIDADIFERENCIA() As Decimal
        Get
            Return _CANTIDADVENCIDADIFERENCIA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADVENCIDADIFERENCIA = value
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
