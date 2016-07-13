''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.CATALOGOPRODUCTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCATALOGOPRODUCTOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CATALOGOPRODUCTOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDPRODUCTO As Int64
    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            _IDPRODUCTO = value
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

    Private _IDTIPOPRODUCTO As Int32
    Public Property IDTIPOPRODUCTO() As Int32
        Get
            Return _IDTIPOPRODUCTO
        End Get
        Set(ByVal value As Int32)
            _IDTIPOPRODUCTO = value
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

    Private _NOMBRE As String
    Public Property NOMBRE() As String
        Get
            Return _NOMBRE
        End Get
        Set(ByVal value As String)
            _NOMBRE = value
        End Set
    End Property

    Private _NIVELUSO As Byte
    Public Property NIVELUSO() As Byte
        Get
            Return _NIVELUSO
        End Get
        Set(ByVal value As Byte)
            _NIVELUSO = value
        End Set
    End Property

    Private _CONCENTRACION As String
    Public Property CONCENTRACION() As String
        Get
            Return _CONCENTRACION
        End Get
        Set(ByVal value As String)
            _CONCENTRACION = value
        End Set
    End Property

    Private _FORMAFARMACEUTICA As String
    Public Property FORMAFARMACEUTICA() As String
        Get
            Return _FORMAFARMACEUTICA
        End Get
        Set(ByVal value As String)
            _FORMAFARMACEUTICA = value
        End Set
    End Property

    Private _PRESENTACION As String
    Public Property PRESENTACION() As String
        Get
            Return _PRESENTACION
        End Get
        Set(ByVal value As String)
            _PRESENTACION = value
        End Set
    End Property

    Private _PRIORIDAD As Int16
    Public Property PRIORIDAD() As Int16
        Get
            Return _PRIORIDAD
        End Get
        Set(ByVal value As Int16)
            _PRIORIDAD = value
        End Set
    End Property

    Private _PRECIOACTUAL As Decimal
    Public Property PRECIOACTUAL() As Decimal
        Get
            Return _PRECIOACTUAL
        End Get
        Set(ByVal value As Decimal)
            _PRECIOACTUAL = value
        End Set
    End Property

    Private _APLICALOTE As Byte
    Public Property APLICALOTE() As Byte
        Get
            Return _APLICALOTE
        End Get
        Set(ByVal value As Byte)
            _APLICALOTE = value
        End Set
    End Property

    Private _EXISTENCIAACTUAL As Decimal
    Public Property EXISTENCIAACTUAL() As Decimal
        Get
            Return _EXISTENCIAACTUAL
        End Get
        Set(ByVal value As Decimal)
            _EXISTENCIAACTUAL = value
        End Set
    End Property

    Private _ESPECIFICACIONESTECNICAS As String
    Public Property ESPECIFICACIONESTECNICAS() As String
        Get
            Return _ESPECIFICACIONESTECNICAS
        End Get
        Set(ByVal value As String)
            _ESPECIFICACIONESTECNICAS = value
        End Set
    End Property

    Private _CODIGONACIONESUNIDAS As String
    Public Property CODIGONACIONESUNIDAS() As String
        Get
            Return _CODIGONACIONESUNIDAS
        End Get
        Set(ByVal value As String)
            _CODIGONACIONESUNIDAS = value
        End Set
    End Property

    Private _PERTENECELISTADOOFICIAL As Byte
    Public Property PERTENECELISTADOOFICIAL() As Byte
        Get
            Return _PERTENECELISTADOOFICIAL
        End Get
        Set(ByVal value As Byte)
            _PERTENECELISTADOOFICIAL = value
        End Set
    End Property

    Private _ESTADOPRODUCTO As Byte
    Public Property ESTADOPRODUCTO() As Byte
        Get
            Return _ESTADOPRODUCTO
        End Get
        Set(ByVal value As Byte)
            _ESTADOPRODUCTO = value
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

    Private _IDESTABLECIMIENTO As Int32
    Public Property IDESTABLECIMIENTO() As Int16
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int16)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Private _CLASIFICACION As String
    Public Property CLASIFICACION() As String
        Get
            Return _CLASIFICACION
        End Get
        Set(ByVal value As String)
            _CLASIFICACION = value
        End Set
    End Property

    Private _AREATECNICA As Integer
    Public Property AREATECNICA() As Integer
        Get
            Return _AREATECNICA
        End Get
        Set(ByVal value As Integer)
            _AREATECNICA = value
        End Set
    End Property

    Private _TIPOUACI As Integer
    Public Property TIPOUACI() As Integer
        Get
            Return _TIPOUACI
        End Get
        Set(ByVal value As Integer)
            _TIPOUACI = value
        End Set
    End Property

    Private _IDESPECIFICOGASTO As Integer
    Public Property IDESPECIFICOGASTO() As Integer
        Get
            Return _IDESPECIFICOGASTO
        End Get
        Set(ByVal value As Integer)
            _IDESPECIFICOGASTO = value
        End Set
    End Property

#End Region

#Region " Propiedades agregadas "

    Private _CANTIDADDECIMAL As Byte
    Public Property CANTIDADDECIMAL() As Byte
        Get
            Return _CANTIDADDECIMAL
        End Get
        Set(ByVal value As Byte)
            _CANTIDADDECIMAL = value
        End Set
    End Property

#End Region

End Class
