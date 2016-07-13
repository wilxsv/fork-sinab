Public Class TRANSACCIONSINAB
    Inherits entidadBase
#Region "Propiedades"

    Private _idTransaccion As Double
    Public Property IdTransaccion() As Double
        Get
            Return _idTransaccion
        End Get
        Set(ByVal value As Double)
            _idTransaccion = value
        End Set
    End Property

    Private _idEstado As Char
    Public Property IdEstado() As Char
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Char)
            _idEstado = value
        End Set
    End Property

    Private _idModalidad As Integer
    Public Property IdModalidad() As Integer
        Get
            Return _idModalidad
        End Get
        Set(ByVal value As Integer)
            _idModalidad = value
        End Set
    End Property

    Private _idUsuarioReg As Double
    Public Property IdUsuarioReg() As Double
        Get
            Return _idUsuarioReg
        End Get
        Set(ByVal value As Double)
            _idUsuarioReg = value
        End Set
    End Property

    Private _idUsuarioMod As Double
    Public Property IdUsuarioMod() As Double
        Get
            Return _idUsuarioMod
        End Get
        Set(ByVal value As Double)
            _idUsuarioMod = value
        End Set
    End Property

    Private _vale As String
    Public Property Vale() As String
        Get
            Return _vale
        End Get
        Set(ByVal value As String)
            _vale = value
        End Set
    End Property

    Private _motivoRechazo As String
    Public Property MotivoRechazo() As String
        Get
            Return _motivoRechazo
        End Get
        Set(ByVal value As String)
            _motivoRechazo = value
        End Set
    End Property

    Private _FechaReg As Date
    Public Property FechaReg() As Date
        Get
            Return _FechaReg
        End Get
        Set(ByVal value As Date)
            _FechaReg = value
        End Set
    End Property

    Private _FechaMod As Date
    Public Property FechaMod() As Date
        Get
            Return _FechaMod
        End Get
        Set(ByVal value As Date)
            _FechaMod = value
        End Set
    End Property
#End Region
End Class
