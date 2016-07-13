Public Class eFiltro

    Private _campo As String

    Private _valorTexto As String
    Private _valorFecha As Date
    Private _valorFecha2 As Date

    Private _valorNumero As Double
    Private _valorNumero2 As Double

    Private _operador As String
    Private _tipo As Data.DbType

    Private _nomParam1 As String
    Private _nomParam2 As String

    Public Property campo() As String
        Get
            Return _campo
        End Get
        Set(ByVal value As String)
            _campo = value
        End Set
    End Property

    Public Property valorTexto() As String
        Get
            Return _valorTexto
        End Get
        Set(ByVal value As String)
            _valorTexto = value
        End Set
    End Property

    Public Property valorFecha() As Date
        Get
            Return _valorFecha
        End Get
        Set(ByVal value As Date)
            _valorFecha = value
        End Set
    End Property

    Public Property valorFecha2() As Date
        Get
            Return _valorFecha2
        End Get
        Set(ByVal value As Date)
            _valorFecha2 = value
        End Set
    End Property

    Public Property valorNumero() As Double
        Get
            Return _valorNumero
        End Get
        Set(ByVal value As Double)
            _valorNumero = value
        End Set
    End Property

    Public Property valorNumero2() As Double
        Get
            Return _valorNumero2
        End Get
        Set(ByVal value As Double)
            _valorNumero2 = value
        End Set
    End Property

    Public Property operador() As String
        Get
            Return _operador
        End Get
        Set(ByVal value As String)
            _operador = value
        End Set
    End Property

    Public Property tipo() As Data.DbType
        Get
            Return _tipo
        End Get
        Set(ByVal value As Data.DbType)
            _tipo = value
        End Set
    End Property

    Public Property nomParam1() As String
        Get
            Return _nomParam1
        End Get
        Set(ByVal value As String)
            _nomParam1 = value
        End Set
    End Property

    Public Property nomParam2() As String
        Get
            Return _nomParam2
        End Get
        Set(ByVal value As String)
            _nomParam2 = value
        End Set
    End Property

End Class
