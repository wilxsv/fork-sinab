
Public Class PROCESOCP
    Inherits entidadBase

#Region " Propiedades "

    Private _IDPROCESO As Int32
    Public Property IDPROCESO() As Int32
        Get
            Return _IDPROCESO
        End Get
        Set(ByVal value As Int32)
            _IDPROCESO = value
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
    Private _FECHAFIN As DateTime
    Public Property FECHAFIN() As DateTime
        Get
            Return _FECHAFIN
        End Get
        Set(ByVal value As DateTime)
            _FECHAFIN = value
        End Set
    End Property
    Private _IDTIPOPRODUCTO As Int32
    Public Property IDTIPOPRODUCTO() As Int32
        Get
            Return _IDTIPOPRODUCTO
        End Get
        Set(ByVal value As Int32)
            _IDTIPOPRODUCTO = value
        End Set
    End Property
    Private _ESTADO As Int32
    Public Property ESTADO() As Int32
        Get
            Return _ESTADO
        End Get
        Set(ByVal value As Int32)
            _ESTADO = value
        End Set
    End Property
    Private _COMENTARIO As String
    Public Property COMENTARIO() As String
        Get
            Return _COMENTARIO
        End Get
        Set(ByVal value As String)
            _COMENTARIO = value
        End Set
    End Property
    Private _NUMPROCESO As String
    Public Property NUMPROCESO() As String
        Get
            Return _NUMPROCESO
        End Get
        Set(ByVal value As String)
            _NUMPROCESO = value
        End Set
    End Property
#End Region

End Class
