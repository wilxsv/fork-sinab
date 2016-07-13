''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.RECIBOSRECEPCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSRECIBOSRECEPCION en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	06/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class RECIBOSRECEPCION
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

    Private _ANIO As Int16
    Public Property ANIO() As Int16
        Get
            Return _ANIO
        End Get
        Set(ByVal value As Int16)
            _ANIO = value
        End Set
    End Property

    Private _IDRECIBO As Int32
    Public Property IDRECIBO() As Int32
        Get
            Return _IDRECIBO
        End Get
        Set(ByVal value As Int32)
            _IDRECIBO = value
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

    Private _RESPONSABLEPROVEEDOR As String
    Public Property RESPONSABLEPROVEEDOR() As String
        Get
            Return _RESPONSABLEPROVEEDOR
        End Get
        Set(ByVal value As String)
            _RESPONSABLEPROVEEDOR = value
        End Set
    End Property

    Private _NUMEROACTA As Int32
    Public Property NUMEROACTA() As Int32
        Get
            Return _NUMEROACTA
        End Get
        Set(ByVal value As Int32)
            _NUMEROACTA = value
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

    Private _IDALMACENVALE As Int32
    Public Property IDALMACENVALE() As Int32
        Get
            Return _IDALMACENVALE
        End Get
        Set(ByVal value As Int32)
            _IDALMACENVALE = value
        End Set
    End Property

    Private _ANIOVALE As Int16
    Public Property ANIOVALE() As Int16
        Get
            Return _ANIOVALE
        End Get
        Set(ByVal value As Int16)
            _ANIOVALE = value
        End Set
    End Property

    Private _IDVALE As Int32
    Public Property IDVALE() As Int32
        Get
            Return _IDVALE
        End Get
        Set(ByVal value As Int32)
            _IDVALE = value
        End Set
    End Property

    Private _NUMEROVALE As String
    Public Property NUMEROVALE() As String
        Get
            Return _NUMEROVALE
        End Get
        Set(ByVal value As String)
            _NUMEROVALE = value
        End Set
    End Property

    Private _IDESTABLECIMIENTODEVOLUCION As Int32
    Public Property IDESTABLECIMIENTODEVOLUCION() As Int32
        Get
            Return _IDESTABLECIMIENTODEVOLUCION
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTODEVOLUCION = value
        End Set
    End Property
    Private _ADMCONTRATO As String

    Public Property ADMCONTRATO() As String
        Get
            Return _ADMCONTRATO
        End Get
        Set(ByVal value As String)
            _ADMCONTRATO = value
        End Set
    End Property

#End Region

End Class
