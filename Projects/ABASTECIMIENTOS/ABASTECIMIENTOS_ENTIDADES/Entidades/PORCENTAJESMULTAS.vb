''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.PORCENTAJESMULTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSPORCENTAJESMULTAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class PORCENTAJESMULTAS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDPORCENTAJE As Byte
    Public Property IDPORCENTAJE() As Byte
        Get
            Return _IDPORCENTAJE
        End Get
        Set(ByVal value As Byte)
            _IDPORCENTAJE = value
        End Set
    End Property

    Private _INICIOPERIODO As Byte
    Public Property INICIOPERIODO() As Byte
        Get
            Return _INICIOPERIODO
        End Get
        Set(ByVal value As Byte)
            _INICIOPERIODO = value
        End Set
    End Property

    Private _FINPERIODO As Byte
    Public Property FINPERIODO() As Byte
        Get
            Return _FINPERIODO
        End Get
        Set(ByVal value As Byte)
            _FINPERIODO = value
        End Set
    End Property

    Private _PORCENTAJE As Decimal
    Public Property PORCENTAJE() As Decimal
        Get
            Return _PORCENTAJE
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJE = value
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
