''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.HISTORICOPRECIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSHISTORICOPRECIOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class HISTORICOPRECIOS
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

    Private _CORRELATIVO As Int64
    Public Property CORRELATIVO() As Int64
        Get
            Return _CORRELATIVO
        End Get
        Set(ByVal value As Int64)
            _CORRELATIVO = value
        End Set
    End Property

    Private _FECHA As DateTime
    Public Property FECHA() As DateTime
        Get
            Return _FECHA
        End Get
        Set(ByVal value As DateTime)
            _FECHA = value
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

    Private _CODIGOLICITACION As String
    Public Property CODIGOLICITACION() As String
        Get
            Return _CODIGOLICITACION
        End Get
        Set(ByVal value As String)
            _CODIGOLICITACION = value
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
