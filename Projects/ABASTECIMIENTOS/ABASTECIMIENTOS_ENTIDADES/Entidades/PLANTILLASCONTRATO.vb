''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.PLANTILLASCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSPLANTILLASCONTRATO en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	16/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class PLANTILLASCONTRATO
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

    Private _IDSUMINISTRO As Int32
    Public Property IDSUMINISTRO() As Int32
        Get
            Return _IDSUMINISTRO
        End Get
        Set(ByVal value As Int32)
            _IDSUMINISTRO = value
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

    Private _PERSONERIAJURIDICA As String
    Public Property PERSONERIAJURIDICA() As String
        Get
            Return _PERSONERIAJURIDICA
        End Get
        Set(ByVal value As String)
            _PERSONERIAJURIDICA = value
        End Set
    End Property

    Private _IDTIPOCOMPRA As Int32
    Public Property IDTIPOCOMPRA() As Int32
        Get
            Return _IDTIPOCOMPRA
        End Get
        Set(ByVal value As Int32)
            _IDTIPOCOMPRA = value
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

    Private _MODIFICATIVA As Byte
    Public Property MODIFICATIVA() As Byte
        Get
            Return _MODIFICATIVA
        End Get
        Set(ByVal value As Byte)
            _MODIFICATIVA = value
        End Set
    End Property

#End Region

End Class
