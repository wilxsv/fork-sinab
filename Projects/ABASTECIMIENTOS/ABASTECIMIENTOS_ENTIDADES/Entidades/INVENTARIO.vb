''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.INVENTARIO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSINVENTARIO en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class INVENTARIO
    Inherits entidadBase

#Region " Propiedades "
    Private _IDALMACEN As Int32
    Public Property IDALMACEN() As Int32
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Int32)
            _IDALMACEN = value
        End Set
    End Property

    Private _IDINVENTARIO As Int32
    Public Property IDINVENTARIO() As Int32
        Get
            Return _IDINVENTARIO
        End Get
        Set(ByVal value As Int32)
            _IDINVENTARIO = value
        End Set
    End Property

    Private _FECHAINICIO As DateTime
    Public Property FECHAINICIO() As DateTime
        Get
            Return _FECHAINICIO
        End Get
        Set(ByVal value As DateTime)
            _FECHAINICIO = value
        End Set
    End Property

    Private _FECHACIERRE As DateTime
    Public Property FECHACIERRE() As DateTime
        Get
            Return _FECHACIERRE
        End Get
        Set(ByVal value As DateTime)
            _FECHACIERRE = value
        End Set
    End Property

    Private _FECHACIERREEXISTENCIA As DateTime
    Public Property FECHACIERREEXISTENCIA() As DateTime
        Get
            Return _FECHACIERREEXISTENCIA
        End Get
        Set(ByVal value As DateTime)
            _FECHACIERREEXISTENCIA = value
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

    Private _IDFUENTEFINANCIAMIENTO As Int32
    Public Property IDFUENTEFINANCIAMIENTO() As Int32
        Get
            Return _IDFUENTEFINANCIAMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDFUENTEFINANCIAMIENTO = value
        End Set
    End Property

    Private _IDRESPONSABLEDISTRIBUCION As Int32
    Public Property IDRESPONSABLEDISTRIBUCION() As Int32
        Get
            Return _IDRESPONSABLEDISTRIBUCION
        End Get
        Set(ByVal value As Int32)
            _IDRESPONSABLEDISTRIBUCION = value
        End Set
    End Property

    Private _ESTACERRADO As Byte
    Public Property ESTACERRADO() As Byte
        Get
            Return _ESTACERRADO
        End Get
        Set(ByVal value As Byte)
            _ESTACERRADO = value
        End Set
    End Property

    Private _CONSIDERARFUENTE As Byte
    Public Property CONSIDERARFUENTE() As Byte
        Get
            Return _CONSIDERARFUENTE
        End Get
        Set(ByVal value As Byte)
            _CONSIDERARFUENTE = value
        End Set
    End Property

    Private _CONSIDERARRESPONSABLE As Byte
    Public Property CONSIDERARRESPONSABLE() As Byte
        Get
            Return _CONSIDERARRESPONSABLE
        End Get
        Set(ByVal value As Byte)
            _CONSIDERARRESPONSABLE = value
        End Set
    End Property

    Private _CONSIDERARVENCIDOS As Byte
    Public Property CONSIDERARVENCIDOS() As Byte
        Get
            Return _CONSIDERARVENCIDOS
        End Get
        Set(ByVal value As Byte)
            _CONSIDERARVENCIDOS = value
        End Set
    End Property

    Private _CONSIDERARNODISPONIBLES As Byte
    Public Property CONSIDERARNODISPONIBLES() As Byte
        Get
            Return _CONSIDERARNODISPONIBLES
        End Get
        Set(ByVal value As Byte)
            _CONSIDERARNODISPONIBLES = value
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

    Private _CONSIDERARDISPONIBLES As Byte
    Public Property CONSIDERARDISPONIBLES() As Byte
        Get
            Return _CONSIDERARDISPONIBLES
        End Get
        Set(ByVal value As Byte)
            _CONSIDERARDISPONIBLES = value
        End Set
    End Property

#End Region

End Class
