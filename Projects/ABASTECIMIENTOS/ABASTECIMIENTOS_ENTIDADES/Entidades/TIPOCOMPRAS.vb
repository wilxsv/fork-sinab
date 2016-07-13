''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.TIPOCOMPRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSTIPOCOMPRAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	21/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class TIPOCOMPRAS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDTIPOCOMPRA As Int32
    Public Property IDTIPOCOMPRA() As Int32
        Get
            Return _IDTIPOCOMPRA
        End Get
        Set(ByVal value As Int32)
            _IDTIPOCOMPRA = value
        End Set
    End Property

    Private _IDMODALIDADCOMPRA As Byte
    Public Property IDMODALIDADCOMPRA() As Byte
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal value As Byte)
            _IDMODALIDADCOMPRA = value
        End Set
    End Property

    Private _DESCRIPCION As String
    Public Property DESCRIPCION() As String
        Get
            Return _DESCRIPCION
        End Get
        Set(ByVal value As String)
            _DESCRIPCION = value
        End Set
    End Property

    Private _MIN As Decimal
    Public Property MIN() As Decimal
        Get
            Return _MIN
        End Get
        Set(ByVal value As Decimal)
            _MIN = value
        End Set
    End Property

    Private _MAX As Decimal
    Public Property MAX() As Decimal
        Get
            Return _MAX
        End Get
        Set(ByVal value As Decimal)
            _MAX = value
        End Set
    End Property

    Private _REQUIERECALIFICACION As Byte
    Public Property REQUIERECALIFICACION() As Byte
        Get
            Return _REQUIERECALIFICACION
        End Get
        Set(ByVal value As Byte)
            _REQUIERECALIFICACION = value
        End Set
    End Property

    Private _PREFIJOBASE As String
    Public Property PREFIJOBASE() As String
        Get
            Return _PREFIJOBASE
        End Get
        Set(ByVal value As String)
            _PREFIJOBASE = value
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
