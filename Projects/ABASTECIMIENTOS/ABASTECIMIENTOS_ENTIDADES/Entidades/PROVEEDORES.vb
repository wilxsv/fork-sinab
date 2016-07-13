''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.PROVEEDORES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSPROVEEDORES en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class PROVEEDORES
    Inherits entidadBase

#Region " Propiedades "

    Private _IDPROVEEDOR As Int32
    Public Property IDPROVEEDOR() As Int32
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int32)
            _IDPROVEEDOR = value
        End Set
    End Property

    Private _CODIGOPROVEEDOR As String
    Public Property CODIGOPROVEEDOR() As String
        Get
            Return _CODIGOPROVEEDOR
        End Get
        Set(ByVal value As String)
            _CODIGOPROVEEDOR = value
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

    Private _DIRECCION As String
    Public Property DIRECCION() As String
        Get
            Return _DIRECCION
        End Get
        Set(ByVal value As String)
            _DIRECCION = value
        End Set
    End Property

    Private _REPRESENTANTELEGAL As String
    Public Property REPRESENTANTELEGAL() As String
        Get
            Return _REPRESENTANTELEGAL
        End Get
        Set(ByVal value As String)
            _REPRESENTANTELEGAL = value
        End Set
    End Property

    Private _MATRICULA As String
    Public Property MATRICULA() As String
        Get
            Return _MATRICULA
        End Get
        Set(ByVal value As String)
            _MATRICULA = value
        End Set
    End Property

    Private _TELEFONO As String
    Public Property TELEFONO() As String
        Get
            Return _TELEFONO
        End Get
        Set(ByVal value As String)
            _TELEFONO = value
        End Set
    End Property

    Private _FAX As String
    Public Property FAX() As String
        Get
            Return _FAX
        End Get
        Set(ByVal value As String)
            _FAX = value
        End Set
    End Property

    Private _NIT As String
    Public Property NIT() As String
        Get
            Return _NIT
        End Get
        Set(ByVal value As String)
            _NIT = value
        End Set
    End Property

    Private _GIRO As String
    Public Property GIRO() As String
        Get
            Return _GIRO
        End Get
        Set(ByVal value As String)
            _GIRO = value
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
    Private _CORREO As String
    Public Property CORREO() As String
        Get
            Return _CORREO
        End Get
        Set(ByVal value As String)
            _CORREO = value
        End Set
    End Property
    Private _PROCEDENCIA As Byte
    Public Property PROCEDENCIA() As Byte
        Get
            Return _PROCEDENCIA
        End Get
        Set(ByVal value As Byte)
            _PROCEDENCIA = value
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
