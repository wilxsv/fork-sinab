''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.FUENTEFINANCIAMIENTOSOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSFUENTEFINANCIAMIENTOSOLICITUDES en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class FUENTEFINANCIAMIENTOSOLICITUDES
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

    Private _IDFUENTEFINANCIAMIENTO As Int32
    Public Property IDFUENTEFINANCIAMIENTO() As Int32
        Get
            Return _IDFUENTEFINANCIAMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDFUENTEFINANCIAMIENTO = value
        End Set
    End Property

    Private _MONTOPARTICIPACION As Decimal
    Public Property MONTOPARTICIPACION() As Decimal
        Get
            Return _MONTOPARTICIPACION
        End Get
        Set(ByVal value As Decimal)
            _MONTOPARTICIPACION = value
        End Set
    End Property

    Private _PORCENTAJEPARTICIPACION As Decimal
    Public Property PORCENTAJEPARTICIPACION() As Decimal
        Get
            Return _PORCENTAJEPARTICIPACION
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJEPARTICIPACION = value
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
