Public Class ENTREGAPROGRAMACION

    Private _IDPROGRAMACION As Integer
    Private _IDENTREGA As Integer
    Private _NUMEROENTREGA As Integer
    Private _PORCENTAJEENTREGA As Decimal
    Private _DIASENTREGA As Integer
    Private _IDPRODUCTO As Integer
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As Date
    Private _AUUSUARIOMODIFICACION As String
    Private _AUFECHAMODIFICACION As Date
    Private _OBSERVACION As String

    Public Property IDPROGRAMACION() As Integer
        Get
            Return _IDPROGRAMACION
        End Get
        Set(ByVal Value As Integer)
            _IDPROGRAMACION = Value
        End Set
    End Property

    Public Property IDENTREGA() As Integer
        Get
            Return _IDENTREGA
        End Get
        Set(ByVal Value As Integer)
            _IDENTREGA = Value
        End Set
    End Property

    Public Property NUMEROENTREGA() As Integer
        Get
            Return _NUMEROENTREGA
        End Get
        Set(ByVal Value As Integer)
            _NUMEROENTREGA = Value
        End Set
    End Property

    Public Property PORCENTAJEENTREGA() As Decimal
        Get
            Return _PORCENTAJEENTREGA
        End Get
        Set(ByVal Value As Decimal)
            _PORCENTAJEENTREGA = Value
        End Set
    End Property

    Public Property DIASENTREGA() As Integer
        Get
            Return _DIASENTREGA
        End Get
        Set(ByVal Value As Integer)
            _DIASENTREGA = Value
        End Set
    End Property

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal Value As Integer)
            _IDPRODUCTO = Value
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

    Public Property OBSERVACION() As String
        Get
            Return _OBSERVACION
        End Get
        Set(ByVal Value As String)
            _OBSERVACION = Value
        End Set
    End Property

End Class
