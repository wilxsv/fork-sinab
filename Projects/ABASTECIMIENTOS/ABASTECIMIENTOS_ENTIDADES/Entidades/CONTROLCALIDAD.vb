Public Class CONTROLCALIDAD
    Inherits entidadBase

    Private _numeroInforme As String
    Public Property numeroInforme() As String
        Get
            Return _numeroInforme
        End Get
        Set(ByVal value As String)
            _numeroInforme = value
        End Set
    End Property

    Private _fechaSolicitudInspeccion As Date
    Public Property fechaSolicitudInspeccion() As Date
        Get
            Return _fechaSolicitudInspeccion
        End Get
        Set(ByVal value As Date)
            _fechaSolicitudInspeccion = value
        End Set
    End Property

    Private _fechaCertificacion As Date
    Public Property fechaCertificacion() As Date
        Get
            Return _fechaCertificacion
        End Get
        Set(ByVal value As Date)
            _fechaCertificacion = value
        End Set
    End Property

    Private _fechaVencimiento As Date
    Public Property fechaVencimiento() As Date
        Get
            Return _fechaVencimiento
        End Get
        Set(ByVal value As Date)
            _fechaVencimiento = value
        End Set
    End Property

    Private _lote As String
    Public Property lote() As String
        Get
            Return _lote
        End Get
        Set(ByVal value As String)
            _lote = value
        End Set
    End Property

    Private _factura As String
    Public Property factura() As String
        Get
            Return _factura
        End Get
        Set(ByVal value As String)
            _factura = value
        End Set
    End Property
    Private _acta As String
    Public Property acta() As String
        Get
            Return _acta
        End Get
        Set(ByVal value As String)
            _acta = value
        End Set
    End Property

    Private _fechaRecepcion As String
    Public Property fechaRecepcion() As String
        Get
            Return _fechaRecepcion
        End Get
        Set(ByVal value As String)
            _fechaRecepcion = value
        End Set
    End Property

    Private _cantidad As String
    Public Property cantidad() As String
        Get
            Return _cantidad
        End Get
        Set(ByVal value As String)
            _cantidad = value
        End Set
    End Property

    Private _contador As String
    Public Property contador() As String
        Get
            Return _contador
        End Get
        Set(ByVal value As String)
            _contador = value
        End Set
    End Property

    Private _cantidadentregadarecepcion As Int32
    Public Property cantidadentregadarecepcion() As Int32
        Get
            Return _cantidadentregadarecepcion
        End Get
        Set(ByVal value As Int32)
            _cantidadentregadarecepcion = value
        End Set
    End Property
End Class
