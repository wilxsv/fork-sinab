''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.QUEDANS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSQUEDANS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	24/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class QUEDANS
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

    Private _IDPROVEEDOR As Int32
    Public Property IDPROVEEDOR() As Int32
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int32)
            _IDPROVEEDOR = value
        End Set
    End Property

    Private _IDCONTRATO As Int64
    Public Property IDCONTRATO() As Int64
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Int64)
            _IDCONTRATO = value
        End Set
    End Property

    Private _IDTIPOGARANTIA As Int16
    Public Property IDTIPOGARANTIA() As Int16
        Get
            Return _IDTIPOGARANTIA
        End Get
        Set(ByVal value As Int16)
            _IDTIPOGARANTIA = value
        End Set
    End Property

    Private _IDGARANTIACONTRATO As Int32
    Public Property IDGARANTIACONTRATO() As Int32
        Get
            Return _IDGARANTIACONTRATO
        End Get
        Set(ByVal value As Int32)
            _IDGARANTIACONTRATO = value
        End Set
    End Property

    Private _IDQUEDAN As Int16
    Public Property IDQUEDAN() As Int16
        Get
            Return _IDQUEDAN
        End Get
        Set(ByVal value As Int16)
            _IDQUEDAN = value
        End Set
    End Property

    Private _FECHAINGRESO As DateTime
    Public Property FECHAINGRESO() As DateTime
        Get
            Return _FECHAINGRESO
        End Get
        Set(ByVal value As DateTime)
            _FECHAINGRESO = value
        End Set
    End Property

    Private _FECHAVENCIMIENTO As DateTime
    Public Property FECHAVENCIMIENTO() As DateTime
        Get
            Return _FECHAVENCIMIENTO
        End Get
        Set(ByVal value As DateTime)
            _FECHAVENCIMIENTO = value
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
