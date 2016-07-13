''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.CANCELACIONPRODUCTO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCANCELACIONPRODUCTO en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	09/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CANCELACIONPRODUCTO
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

    Private _RENGLON As Int64
    Public Property RENGLON() As Int64
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Int64)
            _RENGLON = value
        End Set
    End Property

    Private _IDCANCELACION As Int16
    Public Property IDCANCELACION() As Int16
        Get
            Return _IDCANCELACION
        End Get
        Set(ByVal value As Int16)
            _IDCANCELACION = value
        End Set
    End Property

    Private _FECHACANCELACION As DateTime
    Public Property FECHACANCELACION() As DateTime
        Get
            Return _FECHACANCELACION
        End Get
        Set(ByVal value As DateTime)
            _FECHACANCELACION = value
        End Set
    End Property

    Private _MOTIVOCANCELACION As String
    Public Property MOTIVOCANCELACION() As String
        Get
            Return _MOTIVOCANCELACION
        End Get
        Set(ByVal value As String)
            _MOTIVOCANCELACION = value
        End Set
    End Property

    Private _FECHAANULACION As DateTime
    Public Property FECHAANULACION() As DateTime
        Get
            Return _FECHAANULACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAANULACION = value
        End Set
    End Property

    Private _MOTIVOANULACION As String
    Public Property MOTIVOANULACION() As String
        Get
            Return _MOTIVOANULACION
        End Get
        Set(ByVal value As String)
            _MOTIVOANULACION = value
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
