''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.ENTREGABASES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSENTREGABASES en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ENTREGABASES
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

    Private _IDPROVEEDOR As Int32
    Public Property IDPROVEEDOR() As Int32
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int32)
            _IDPROVEEDOR = value
        End Set
    End Property

    Private _NUMERORECIBO As String
    Public Property NUMERORECIBO() As String
        Get
            Return _NUMERORECIBO
        End Get
        Set(ByVal value As String)
            _NUMERORECIBO = value
        End Set
    End Property

    Private _NUMEROFACTURA As String
    Public Property NUMEROFACTURA() As String
        Get
            Return _NUMEROFACTURA
        End Get
        Set(ByVal value As String)
            _NUMEROFACTURA = value
        End Set
    End Property

    Private _PERSONARECIBE As String
    Public Property PERSONARECIBE() As String
        Get
            Return _PERSONARECIBE
        End Get
        Set(ByVal value As String)
            _PERSONARECIBE = value
        End Set
    End Property

    Private _FECHAHORAENTREGA As DateTime
    Public Property FECHAHORAENTREGA() As DateTime
        Get
            Return _FECHAHORAENTREGA
        End Get
        Set(ByVal value As DateTime)
            _FECHAHORAENTREGA = value
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

    Private _ORDEN As Int16
    Public Property ORDEN() As Int16
        Get
            Return _ORDEN
        End Get
        Set(ByVal value As Int16)
            _ORDEN = value
        End Set
    End Property

#End Region

End Class
