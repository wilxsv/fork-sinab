Public Class EXISTENCIASINAB
    Inherits entidadBase
#Region "Propiedades"

    Private _idExistencia As Double
    Public Property Existencia() As Double
        Get
            Return _idExistencia
        End Get
        Set(ByVal value As Double)
            _idExistencia = value
        End Set
    End Property

    Private _idTransaccion As Double
    Public Property IdTransaccion() As Double
        Get
            Return _idTransaccion
        End Get
        Set(ByVal value As Double)
            _idTransaccion = value
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

    Private _lote As String
    Public Property Lote() As String
        Get
            Return _lote
        End Get
        Set(ByVal value As String)
            _lote = value
        End Set
    End Property

    Private _codigo As String
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Private _cantidad As Double
    Public Property Cantidad() As Double
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Double)
            _cantidad = value
        End Set
    End Property

    Private _precio As Double
    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Private _fuenteFinanciamiento As Double
    Public Property FuenteFinanciamiento() As Double
        Get
            Return _fuenteFinanciamiento
        End Get
        Set(ByVal value As Double)
            _fuenteFinanciamiento = value
        End Set
    End Property

    Private _fechaVencimiento As Date
    Public Property FechaVencimiento() As Date
        Get
            Return _fechaVencimiento
        End Get
        Set(ByVal value As Date)
            _fechaVencimiento = value
        End Set
    End Property

    Private _fechaReg As Date
    Public Property FechaReg() As Date
        Get
            Return _fechaReg
        End Get
        Set(ByVal value As Date)
            _fechaReg = value
        End Set
    End Property

    Private _fechaMod As Date
    Public Property FechaMod() As Date
        Get
            Return _fechaMod
        End Get
        Set(ByVal value As Date)
            _fechaMod = value
        End Set
    End Property
#End Region
End Class
