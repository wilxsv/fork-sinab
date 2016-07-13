Public Class CONSUMOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDESTABLECIMIENTO As Integer
    Private _IDALMACEN As Integer
    Private _IDPRODUCTO As Integer
    Private _FECHACONSUMO As Date
    Private _CONSUMOREAL As Decimal
    Private _CONSUMOAJUSTADO As Decimal
    Private _EXISTENCIA As Decimal
    Private _DIASDESABASTECIDOS As Integer
    Private _DEMANDAINSATISFECHA As Decimal
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As Date
    Private _AUUSUARIOMODIFICACION As String
    Private _AUFECHAMODIFICACION As Date
    Private _EXISTENCIAAJUSTADA As Decimal
    Private _MOTIVOEXISTENCIAAJUSTADA As String

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
        End Set
    End Property

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
        End Set
    End Property

    Public Property FECHACONSUMO() As Date
        Get
            Return _FECHACONSUMO
        End Get
        Set(ByVal value As Date)
            _FECHACONSUMO = value
        End Set
    End Property

    Public Property CONSUMOREAL() As Decimal
        Get
            Return _CONSUMOREAL
        End Get
        Set(ByVal value As Decimal)
            _CONSUMOREAL = value
        End Set
    End Property

    Public Property CONSUMOAJUSTADO() As Decimal
        Get
            Return _CONSUMOAJUSTADO
        End Get
        Set(ByVal value As Decimal)
            _CONSUMOAJUSTADO = value
        End Set
    End Property

    Public Property EXISTENCIA() As Decimal
        Get
            Return _EXISTENCIA
        End Get
        Set(ByVal value As Decimal)
            _EXISTENCIA = value
        End Set
    End Property
    Public Property EXISTENCIAAJUSTADA() As Decimal
        Get
            Return _EXISTENCIAAJUSTADA
        End Get
        Set(ByVal value As Decimal)
            _EXISTENCIAAJUSTADA = value
        End Set
    End Property
    Public Property MOTIVOEXISTENCIAAJUSTADA() As String
        Get
            Return _MOTIVOEXISTENCIAAJUSTADA
        End Get
        Set(ByVal value As String)
            _MOTIVOEXISTENCIAAJUSTADA = value
        End Set
    End Property
    Public Property DIASDESABASTECIDOS() As Integer
        Get
            Return _DIASDESABASTECIDOS
        End Get
        Set(ByVal value As Integer)
            _DIASDESABASTECIDOS = value
        End Set
    End Property

    Public Property DEMANDAINSATISFECHA() As Decimal
        Get
            Return _DEMANDAINSATISFECHA
        End Get
        Set(ByVal value As Decimal)
            _DEMANDAINSATISFECHA = value
        End Set
    End Property

    Public Property AUUSUARIOCREACION() As String
        Get
            Return _AUUSUARIOCREACION
        End Get
        Set(ByVal value As String)
            _AUUSUARIOCREACION = value
        End Set
    End Property

    Public Property AUFECHACREACION() As DateTime
        Get
            Return _AUFECHACREACION
        End Get
        Set(ByVal value As DateTime)
            _AUFECHACREACION = value
        End Set
    End Property

    Public Property AUUSUARIOMODIFICACION() As String
        Get
            Return _AUUSUARIOMODIFICACION
        End Get
        Set(ByVal value As String)
            _AUUSUARIOMODIFICACION = value
        End Set
    End Property

    Public Property AUFECHAMODIFICACION() As DateTime
        Get
            Return _AUFECHAMODIFICACION
        End Get
        Set(ByVal value As DateTime)
            _AUFECHAMODIFICACION = value
        End Set
    End Property

#End Region

End Class
