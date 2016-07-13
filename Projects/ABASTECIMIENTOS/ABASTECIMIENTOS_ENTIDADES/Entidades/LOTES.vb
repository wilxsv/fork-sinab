''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.LOTES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSLOTES en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class LOTES
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

    Private _IDLOTE As Int64
    Public Property IDLOTE() As Int64
        Get
            Return _IDLOTE
        End Get
        Set(ByVal value As Int64)
            _IDLOTE = value
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

    Private _CODIGO As String
    Public Property CODIGO() As String
        Get
            Return _CODIGO
        End Get
        Set(ByVal value As String)
            _CODIGO = value
        End Set
    End Property

    Private _PRECIOLOTE As Decimal
    Public Property PRECIOLOTE() As Decimal
        Get
            Return _PRECIOLOTE
        End Get
        Set(ByVal value As Decimal)
            _PRECIOLOTE = value
        End Set
    End Property

    Private _FECHAVENCIMIENTO As DateTime
    Public Property FECHAVENCIMIENTO() As DateTime
        Get
            Return _FECHAVENCIMIENTO
        End Get
        Set(ByVal value As DateTime)
            _FECHAVENCIMIENTO = value
        End Set
    End Property

    Private _IDFUENTEFINANCIAMIENTO As Int32
    Public Property IDFUENTEFINANCIAMIENTO() As Int32
        Get
            Return _IDFUENTEFINANCIAMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDFUENTEFINANCIAMIENTO = value
        End Set
    End Property

    Private _IDRESPONSABLEDISTRIBUCION As Int32
    Public Property IDRESPONSABLEDISTRIBUCION() As Int32
        Get
            Return _IDRESPONSABLEDISTRIBUCION
        End Get
        Set(ByVal value As Int32)
            _IDRESPONSABLEDISTRIBUCION = value
        End Set
    End Property

    Private _IDESTABLECIMIENTO As Int32
    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Private _IDINFORMECONTROLCALIDAD As Int32
    Public Property IDINFORMECONTROLCALIDAD() As Int32
        Get
            Return _IDINFORMECONTROLCALIDAD
        End Get
        Set(ByVal value As Int32)
            _IDINFORMECONTROLCALIDAD = value
        End Set
    End Property

    Private _NUMEROINFORMECONTROLCALIDAD As String
    Public Property NUMEROINFORMECONTROLCALIDAD() As String
        Get
            Return _NUMEROINFORMECONTROLCALIDAD
        End Get
        Set(ByVal value As String)
            _NUMEROINFORMECONTROLCALIDAD = value
        End Set
    End Property

    Private _FECHAINFORMECONTROLCALIDAD As DateTime
    Public Property FECHAINFORMECONTROLCALIDAD() As DateTime
        Get
            Return _FECHAINFORMECONTROLCALIDAD
        End Get
        Set(ByVal value As DateTime)
            _FECHAINFORMECONTROLCALIDAD = value
        End Set
    End Property

    Private _CANTIDADDISPONIBLE As Decimal
    Public Property CANTIDADDISPONIBLE() As Decimal
        Get
            Return _CANTIDADDISPONIBLE
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADDISPONIBLE = value
        End Set
    End Property

    Private _CANTIDADNODISPONIBLE As Decimal
    Public Property CANTIDADNODISPONIBLE() As Decimal
        Get
            Return _CANTIDADNODISPONIBLE
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADNODISPONIBLE = value
        End Set
    End Property

    Private _CANTIDADVENCIDA As Decimal
    Public Property CANTIDADVENCIDA() As Decimal
        Get
            Return _CANTIDADVENCIDA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADVENCIDA = value
        End Set
    End Property

    Private _CANTIDADRESERVADA As Decimal
    Public Property CANTIDADRESERVADA() As Decimal
        Get
            Return _CANTIDADRESERVADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADRESERVADA = value
        End Set
    End Property

    Private _CANTIDADTEMPORAL As Decimal
    Public Property CANTIDADTEMPORAL() As Decimal
        Get
            Return _CANTIDADTEMPORAL
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADTEMPORAL = value
        End Set
    End Property

    Private _ESTADISPONIBLE As Byte
    Public Property ESTADISPONIBLE() As Byte
        Get
            Return _ESTADISPONIBLE
        End Get
        Set(ByVal value As Byte)
            _ESTADISPONIBLE = value
        End Set
    End Property

    Private _IDALMACENORIGEN As Int32
    Public Property IDALMACENORIGEN() As Int32
        Get
            Return _IDALMACENORIGEN
        End Get
        Set(ByVal value As Int32)
            _IDALMACENORIGEN = value
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

    Private _DETALLE As String
    Public Property DETALLE() As String
        Get
            Return _DETALLE
        End Get
        Set(ByVal value As String)
            _DETALLE = value
        End Set
    End Property

#End Region

End Class
