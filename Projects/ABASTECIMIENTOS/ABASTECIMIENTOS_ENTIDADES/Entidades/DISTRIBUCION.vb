Public Class DISTRIBUCION
    Inherits entidadBase

    'Variables
    Private _IDESTABLECIMIENTO As Integer
    Private _FECHADISTRIBUCION As Date
    Private _IDDISTRIBUCION As Integer
    Private _IDSUMINISTRO As Integer
    Private _IDALMACEN As Integer
    Private _NOMBREALMACEN As String
    Private _DESCRIPCION As String
    Private _FECHACORTE As Date
    Private _MESESCPM As Integer
    Private _MESESCOBERTURA As Integer
    Private _MESESADMINCPM As Integer
    Private _MESESSEGURIDADCPM As Integer
    Private _ESTADO As Integer
    Private _IDTIPOESTABLECIMIENTO As Integer
    Private _SUMINISTRO As String
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime
    Private _AUUSUARIOMODIFICACION As String
    Private _AUFECHAMODIFICACION As DateTime
    Private _IDPROGRAMA As Integer

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Integer)
            _IDESTABLECIMIENTO = Value
        End Set
    End Property

    Public Property FECHADISTRIBUCION() As Date
        Get
            Return _FECHADISTRIBUCION
        End Get
        Set(ByVal Value As Date)
            _FECHADISTRIBUCION = Value
        End Set
    End Property

    Public Property IDDISTRIBUCION() As Integer
        Get
            Return _IDDISTRIBUCION
        End Get
        Set(ByVal Value As Integer)
            _IDDISTRIBUCION = Value
        End Set
    End Property

    Public Property IDSUMINISTRO() As Integer
        Get
            Return _IDSUMINISTRO
        End Get
        Set(ByVal Value As Integer)
            _IDSUMINISTRO = Value
        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal Value As Integer)
            _IDALMACEN = Value
        End Set
    End Property

    Public Property NOMBREALMACEN() As String
        Get
            Return _NOMBREALMACEN
        End Get
        Set(ByVal Value As String)
            _NOMBREALMACEN = Value
        End Set
    End Property

    Public Property DESCRIPCION() As String
        Get
            Return _DESCRIPCION
        End Get
        Set(ByVal Value As String)
            _DESCRIPCION = Value
        End Set
    End Property

    Public Property FECHACORTE() As Date
        Get
            Return _FECHACORTE
        End Get
        Set(ByVal Value As Date)
            _FECHACORTE = Value
        End Set
    End Property

    Public Property MESESCPM() As Integer
        Get
            Return _MESESCPM
        End Get
        Set(ByVal Value As Integer)
            _MESESCPM = Value
        End Set
    End Property

    Public Property MESESCOBERTURA() As Integer
        Get
            Return _MESESCOBERTURA
        End Get
        Set(ByVal Value As Integer)
            _MESESCOBERTURA = Value
        End Set
    End Property

    Public Property MESESADMINCPM() As Integer
        Get
            Return _MESESADMINCPM
        End Get
        Set(ByVal Value As Integer)
            _MESESADMINCPM = Value
        End Set
    End Property

    Public Property MESESSEGURIDADCPM() As Integer
        Get
            Return _MESESSEGURIDADCPM
        End Get
        Set(ByVal Value As Integer)
            _MESESSEGURIDADCPM = Value
        End Set
    End Property

    Public Property ESTADO() As Integer
        Get
            Return _ESTADO
        End Get
        Set(ByVal Value As Integer)
            _ESTADO = Value
        End Set
    End Property

    Public Property IDTIPOESTABLECIMIENTO() As Integer
        Get
            Return _IDTIPOESTABLECIMIENTO
        End Get
        Set(ByVal Value As Integer)
            _IDTIPOESTABLECIMIENTO = Value
        End Set
    End Property

    Public Property SUMINISTRO() As String
        Get
            Return _SUMINISTRO
        End Get
        Set(ByVal Value As String)
            _SUMINISTRO = Value
        End Set
    End Property

    Public Property AUUSUARIOCREACION() As String
        Get
            Return _AUUSUARIOCREACION
        End Get
        Set(ByVal Value As String)
            _AUUSUARIOCREACION = Value
        End Set
    End Property

    Public Property AUFECHACREACION() As DateTime
        Get
            Return _AUFECHACREACION
        End Get
        Set(ByVal Value As DateTime)
            _AUFECHACREACION = Value
        End Set
    End Property

    Public Property AUUSUARIOMODIFICACION() As String
        Get
            Return _AUUSUARIOMODIFICACION
        End Get
        Set(ByVal Value As String)
            _AUUSUARIOMODIFICACION = Value
        End Set
    End Property

    Public Property AUFECHAMODIFICACION() As DateTime
        Get
            Return _AUFECHAMODIFICACION
        End Get
        Set(ByVal Value As DateTime)
            _AUFECHAMODIFICACION = Value
        End Set
    End Property
    Public Property IDPROGRAMA() As Integer
        Get
            Return _IDPROGRAMA
        End Get
        Set(ByVal Value As Integer)
            _IDPROGRAMA = Value
        End Set
    End Property
End Class
