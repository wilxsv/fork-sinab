Public Class PROGRAMACION
    Inherits entidadBase

    'Variables
    Private _FECHAPROGRAMACION As Date
    Private _FECHAPROYECCION As Date
    Private _FECHACORTE As Date
    Private _IDPROGRAMACION As Integer
    Private _DESCRIPCION As String
    Private _MESESCPM As Integer
    Private _MESESPLANEACION As Integer
    Private _INDICEINFLACION As Decimal
    Private _ESTADO As Integer
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As Date
    Private _AUUSUARIOMODIFICACION As String
    Private _AUFECHAMODIFICACION As Date
    Private _PRESUPUESTOREAL As Decimal
    Private _IDSUMINISTRO As Integer
    Private _ENTREGAS As Integer
    Private _IDPROGRAMA As Integer

    Public Property FECHAPROGRAMACION() As Date
        Get
            Return _FECHAPROGRAMACION
        End Get
        Set(ByVal Value As Date)
            _FECHAPROGRAMACION = Value
        End Set
    End Property

    Public Property FECHAPROYECCION() As Date
        Get
            Return _FECHAPROYECCION
        End Get
        Set(ByVal Value As Date)
            _FECHAPROYECCION = Value
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

    Public Property IDPROGRAMACION() As Integer
        Get
            Return _IDPROGRAMACION
        End Get
        Set(ByVal Value As Integer)
            _IDPROGRAMACION = Value
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
    Public Property DESCRIPCION() As String
        Get
            Return _DESCRIPCION
        End Get
        Set(ByVal Value As String)
            _DESCRIPCION = Value
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

    Public Property MESESPLANEACION() As Integer
        Get
            Return _MESESPLANEACION
        End Get
        Set(ByVal Value As Integer)
            _MESESPLANEACION = Value
        End Set
    End Property

    Public Property INDICEINFLACION() As Decimal
        Get
            Return _INDICEINFLACION
        End Get
        Set(ByVal Value As Decimal)
            _INDICEINFLACION = Value
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

    Public Property PRESUPUESTOREAL() As Decimal
        Get
            Return _PRESUPUESTOREAL
        End Get
        Set(ByVal Value As Decimal)
            _PRESUPUESTOREAL = Value
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

    Public Property ENTREGAS() As Integer
        Get
            Return _ENTREGAS
        End Get
        Set(ByVal Value As Integer)
            _ENTREGAS = Value
        End Set
    End Property

End Class
