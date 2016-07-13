''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.CLAUSULASPLANTILLA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCLAUSULASPLANTILLA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	16/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CLAUSULASPLANTILLA
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

    Private _IDPLANTILLA As Int32
    Public Property IDPLANTILLA() As Int32
        Get
            Return _IDPLANTILLA
        End Get
        Set(ByVal value As Int32)
            _IDPLANTILLA = value
        End Set
    End Property

    Private _IDCLAUSULA As Int32
    Public Property IDCLAUSULA() As Int32
        Get
            Return _IDCLAUSULA
        End Get
        Set(ByVal value As Int32)
            _IDCLAUSULA = value
        End Set
    End Property

    Private _ORDEN As Byte
    Public Property ORDEN() As Byte
        Get
            Return _ORDEN
        End Get
        Set(ByVal value As Byte)
            _ORDEN = value
        End Set
    End Property

    Private _CONTENIDO As String
    Public Property CONTENIDO() As String
        Get
            Return _CONTENIDO
        End Get
        Set(ByVal value As String)
            _CONTENIDO = value
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
