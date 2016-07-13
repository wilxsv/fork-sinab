''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.ENTREGASOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSENTREGASOLICITUDES en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ENTREGASOLICITUDES
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

    Private _IDSOLICITUD As Int64
    Public Property IDSOLICITUD() As Int64
        Get
            Return _IDSOLICITUD
        End Get
        Set(ByVal value As Int64)
            _IDSOLICITUD = value
        End Set
    End Property
    Private _IDPRODUCTO As Integer
    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
        End Set
    End Property
    'Private _IDDETALLE As Integer
    'Public Property IDDETALLE() As Integer
    '    Get
    '        Return _IDDETALLE
    '    End Get
    '    Set(ByVal value As Integer)
    '        _IDDETALLE = value
    '    End Set
    'End Property
    'Private _PLAZOENTREGA As Integer
    'Public Property PLAZOENTREGA() As Integer
    '    Get
    '        Return _PLAZOENTREGA
    '    End Get
    '    Set(ByVal value As Integer)
    '        _PLAZOENTREGA = value
    '    End Set
    'End Property
    'Private _PORCENTAJEENTREGA As Decimal
    'Public Property PORCENTAJEENTREGA() As Decimal
    '    Get
    '        Return _PORCENTAJEENTREGA
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _PORCENTAJEENTREGA = value
    '    End Set
    'End Property
    Private _IDENTREGA As Integer
    Public Property IDENTREGA() As Integer
        Get
            Return _IDENTREGA
        End Get
        Set(ByVal value As Integer)
            _IDENTREGA = value
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
