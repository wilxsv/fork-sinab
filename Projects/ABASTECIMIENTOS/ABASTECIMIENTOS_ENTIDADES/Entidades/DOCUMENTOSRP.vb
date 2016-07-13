
Public Class DOCUMENTOSRP
    Inherits entidadBase

#Region " Propiedades "

    Private _IDDOCUMENTO As Int32
    Public Property IDDOCUMENTO() As Int32
        Get
            Return _IDDOCUMENTO
        End Get
        Set(ByVal value As Int32)
            _IDDOCUMENTO = value
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

    Private _C1 As Int32
    Public Property C1() As Int32
        Get
            Return _C1
        End Get
        Set(ByVal value As Int32)
            _C1 = value
        End Set
    End Property

    Private _C2 As Int32
    Public Property C2() As Int32
        Get
            Return _C2
        End Get
        Set(ByVal value As Int32)
            _C2 = value
        End Set
    End Property
#End Region

End Class
