''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.EMPLEADOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSEMPLEADOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class EMPLEADOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDEMPLEADO As Int32
    Public Property IDEMPLEADO() As Int32
        Get
            Return _IDEMPLEADO
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADO = value
        End Set
    End Property

    Private _IDDEPENDENCIA As Int32
    Public Property IDDEPENDENCIA() As Int32
        Get
            Return _IDDEPENDENCIA
        End Get
        Set(ByVal value As Int32)
            _IDDEPENDENCIA = value
        End Set
    End Property

    Private _NOMBRECORTO As String
    Public Property NOMBRECORTO() As String
        Get
            Return _NOMBRECORTO
        End Get
        Set(ByVal value As String)
            _NOMBRECORTO = value
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

    Private _APELLIDO As String
    Public Property APELLIDO() As String
        Get
            Return _APELLIDO
        End Get
        Set(ByVal value As String)
            _APELLIDO = value
        End Set
    End Property

    Private _IDCARGO As Int32
    Public Property IDCARGO() As Int32
        Get
            Return _IDCARGO
        End Get
        Set(ByVal value As Int32)
            _IDCARGO = value
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

    Private _TITULAR As Byte
    Public Property TITULAR() As Byte
        Get
            Return _TITULAR
        End Get
        Set(ByVal value As Byte)
            _TITULAR = value
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
