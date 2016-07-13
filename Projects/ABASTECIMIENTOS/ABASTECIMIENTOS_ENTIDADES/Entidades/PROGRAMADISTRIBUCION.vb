''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.PROGRAMADISTRIBUCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla SAB_UACI_PROGRAMADISTRIBUCION en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	29/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class PROGRAMADISTRIBUCION
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

    Private _IDESTABLECIMIENTOSOLICITA As Int32
    Public Property IDESTABLECIMIENTOSOLICITA() As Int32
        Get
            Return _IDESTABLECIMIENTOSOLICITA
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTOSOLICITA = value
        End Set
    End Property

    Private _IDSOLICITUD As Int64
    Public Property IDSOLICITUD() As Int64
        Get
            Return _IDSOLICITUD
        End Get
        Set(ByVal value As Int64)
            _IDSOLICITUD = value
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

    Private _IDALMACEN As Int32
    Public Property IDALMACEN() As Int32
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Int32)
            _IDALMACEN = value
        End Set
    End Property

    Private _CANTIDADSOLICITADA As Decimal
    Public Property CANTIDADSOLICITADA() As Decimal
        Get
            Return _CANTIDADSOLICITADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADSOLICITADA = value
        End Set
    End Property

    Private _CANTIDADADJUDICADA As Decimal
    Public Property CANTIDADADJUDICADA() As Decimal
        Get
            Return _CANTIDADADJUDICADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADADJUDICADA = value
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

    Public Property IDFUENTEFINANCIAMIENTO As Int16

End Class
