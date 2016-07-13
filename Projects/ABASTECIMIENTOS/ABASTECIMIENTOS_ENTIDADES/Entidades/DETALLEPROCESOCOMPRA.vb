''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.DETALLEPROCESOCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla SAB_UACI_DETALLEPROCESOCOMPRA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DETALLEPROCESOCOMPRA
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

    Private _IDPRODUCTO As Int64
    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            _IDPRODUCTO = value
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

    Private _CANTIDAD As Int64
    Public Property CANTIDAD() As Int64
        Get
            Return _CANTIDAD
        End Get
        Set(ByVal value As Int64)
            _CANTIDAD = value
        End Set
    End Property

    Private _NUMEROENTREGAS As Byte
    Public Property NUMEROENTREGAS() As Byte
        Get
            Return _NUMEROENTREGAS
        End Get
        Set(ByVal value As Byte)
            _NUMEROENTREGAS = value
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

    Private _GARANTIAMTTOVALOR As Decimal
    Public Property GARANTIAMTTOVALOR() As Decimal
        Get
            Return _GARANTIAMTTOVALOR
        End Get
        Set(ByVal value As Decimal)
            _GARANTIAMTTOVALOR = value
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

    Private _OBSERVACION As String
    Public Property OBSERVACION() As String
        Get
            Return _OBSERVACION
        End Get
        Set(ByVal value As String)
            _OBSERVACION = value
        End Set
    End Property

    Private _OBSERVACIONRECOMENDACION As String
    Public Property OBSERVACIONRECOMENDACION() As String
        Get
            Return _OBSERVACIONRECOMENDACION
        End Get
        Set(ByVal value As String)
            _OBSERVACIONRECOMENDACION = value
        End Set
    End Property

    Private _OBSERVACIONADJUDICADA As String
    Public Property OBSERVACIONADJUDICADA() As String
        Get
            Return _OBSERVACIONADJUDICADA
        End Get
        Set(ByVal value As String)
            _OBSERVACIONADJUDICADA = value
        End Set
    End Property

    Private _OBSERVACIONFIRME As String
    Public Property OBSERVACIONFIRME() As String
        Get
            Return _OBSERVACIONFIRME
        End Get
        Set(ByVal value As String)
            _OBSERVACIONFIRME = value
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
