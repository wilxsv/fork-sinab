''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.CRITERIOSEVALUACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCRITERIOSEVALUACION en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CRITERIOSEVALUACION
    Inherits entidadBase

#Region " Propiedades "

    Private _IDCRITERIOEVALUACION As Int16
    Public Property IDCRITERIOEVALUACION() As Int16
        Get
            Return _IDCRITERIOEVALUACION
        End Get
        Set(ByVal value As Int16)
            _IDCRITERIOEVALUACION = value
        End Set
    End Property

    Private _IDTIPOCRITERIO As Int16
    Public Property IDTIPOCRITERIO() As Int16
        Get
            Return _IDTIPOCRITERIO
        End Get
        Set(ByVal value As Int16)
            _IDTIPOCRITERIO = value
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

    Private _PORCENTAJE As Decimal
    Public Property PORCENTAJE() As Decimal
        Get
            Return _PORCENTAJE
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJE = value
        End Set
    End Property

    Private _ESGLOBAL As Byte
    Public Property ESGLOBAL() As Byte
        Get
            Return _ESGLOBAL
        End Get
        Set(ByVal value As Byte)
            _ESGLOBAL = value
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