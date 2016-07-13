''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.NOTASINCUMPLIMIENTOCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSNOTASINCUMPLIMIENTOCONTRATO en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class NOTASINCUMPLIMIENTOCONTRATO
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

    Private _IDNOTA As Int32
    Public Property IDNOTA() As Int32
        Get
            Return _IDNOTA
        End Get
        Set(ByVal value As Int32)
            _IDNOTA = value
        End Set
    End Property

    Private _NOMBREPERSONADIRIGIDA As String
    Public Property NOMBREPERSONADIRIGIDA() As String
        Get
            Return _NOMBREPERSONADIRIGIDA
        End Get
        Set(ByVal value As String)
            _NOMBREPERSONADIRIGIDA = value
        End Set
    End Property

    Private _CARGOPERSONADIRIGIDA As String
    Public Property CARGOPERSONADIRIGIDA() As String
        Get
            Return _CARGOPERSONADIRIGIDA
        End Get
        Set(ByVal value As String)
            _CARGOPERSONADIRIGIDA = value
        End Set
    End Property

    Private _IDEMPLEADOENVIA As Int32
    Public Property IDEMPLEADOENVIA() As Int32
        Get
            Return _IDEMPLEADOENVIA
        End Get
        Set(ByVal value As Int32)
            _IDEMPLEADOENVIA = value
        End Set
    End Property

    Private _TITULONOTA As String
    Public Property TITULONOTA() As String
        Get
            Return _TITULONOTA
        End Get
        Set(ByVal value As String)
            _TITULONOTA = value
        End Set
    End Property

    Private _FECHAENTREGA As DateTime
    Public Property FECHAENTREGA() As DateTime
        Get
            Return _FECHAENTREGA
        End Get
        Set(ByVal value As DateTime)
            _FECHAENTREGA = value
        End Set
    End Property
    Private _NUMEROINFORME As String
    Public Property NUMEROINFORME() As String
        Get
            Return _NUMEROINFORME
        End Get
        Set(ByVal value As String)
            _NUMEROINFORME = value
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
