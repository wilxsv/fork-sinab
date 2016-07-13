''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.CLAUSULASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCLAUSULASCONTRATOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CLAUSULASCONTRATOS
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

    Private _IDCLAUSULA As Int32
    Public Property IDCLAUSULA() As Int32
        Get
            Return _IDCLAUSULA
        End Get
        Set(ByVal value As Int32)
            _IDCLAUSULA = value
        End Set
    End Property

    Private _IDCLAUSULACONTRATO As Int16
    Public Property IDCLAUSULACONTRATO() As Int16
        Get
            Return _IDCLAUSULACONTRATO
        End Get
        Set(ByVal value As Int16)
            _IDCLAUSULACONTRATO = value
        End Set
    End Property

    Private _ENCABEZADOCLAUSULA As String
    Public Property ENCABEZADOCLAUSULA() As String
        Get
            Return _ENCABEZADOCLAUSULA
        End Get
        Set(ByVal value As String)
            _ENCABEZADOCLAUSULA = value
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

    Private _IDMODIFICATIVA As Int64
    Public Property IDMODIFICATIVA() As Int64
        Get
            Return _IDMODIFICATIVA
        End Get
        Set(ByVal value As Int64)
            _IDMODIFICATIVA = value
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
