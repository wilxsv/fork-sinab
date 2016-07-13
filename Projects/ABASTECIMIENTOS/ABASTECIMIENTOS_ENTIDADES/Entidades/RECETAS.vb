''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.RECETAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSRECETAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class RECETAS
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

    Private _IDCARGA As Int32
    Public Property IDCARGA() As Int32
        Get
            Return _IDCARGA
        End Get
        Set(ByVal value As Int32)
            _IDCARGA = value
        End Set
    End Property

    Private _IDRECETA As Int32
    Public Property IDRECETA() As Int32
        Get
            Return _IDRECETA
        End Get
        Set(ByVal value As Int32)
            _IDRECETA = value
        End Set
    End Property

    Private _NUMERORECETA As String
    Public Property NUMERORECETA() As String
        Get
            Return _NUMERORECETA
        End Get
        Set(ByVal value As String)
            _NUMERORECETA = value
        End Set
    End Property

    Private _IDSERVICIOHOSPITALARIO As Int32
    Public Property IDSERVICIOHOSPITALARIO() As Int32
        Get
            Return _IDSERVICIOHOSPITALARIO
        End Get
        Set(ByVal value As Int32)
            _IDSERVICIOHOSPITALARIO = value
        End Set
    End Property

    Private _FECHARECETA As DateTime
    Public Property FECHARECETA() As DateTime
        Get
            Return _FECHARECETA
        End Get
        Set(ByVal value As DateTime)
            _FECHARECETA = value
        End Set
    End Property

    Private _MEDICO As String
    Public Property MEDICO() As String
        Get
            Return _MEDICO
        End Get
        Set(ByVal value As String)
            _MEDICO = value
        End Set
    End Property

    Private _DESPACHADO As Byte
    Public Property DESPACHADO() As Byte
        Get
            Return _DESPACHADO
        End Get
        Set(ByVal value As Byte)
            _DESPACHADO = value
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
