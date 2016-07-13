''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.FUENTEFINANCIAMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSFUENTEFINANCIAMIENTOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class FUENTEFINANCIAMIENTOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDFUENTEFINANCIAMIENTO As Int32
    Public Property IDFUENTEFINANCIAMIENTO() As Int32
        Get
            Return _IDFUENTEFINANCIAMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDFUENTEFINANCIAMIENTO = value
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

    Private _MONTO As Decimal
    Public Property MONTO() As Decimal
        Get
            Return _MONTO
        End Get
        Set(ByVal value As Decimal)
            _MONTO = value
        End Set
    End Property

    Private _REALIZADONACIONES As Byte
    Public Property REALIZADONACIONES() As Byte
        Get
            Return _REALIZADONACIONES
        End Get
        Set(ByVal value As Byte)
            _REALIZADONACIONES = value
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

    Private _IDGRUPO As Int16
    Public Property IDGRUPO() As Int16
        Get
            Return _IDGRUPO
        End Get
        Set(ByVal value As Int16)
            _IDGRUPO = value
        End Set
    End Property

#End Region

End Class
