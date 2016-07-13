
Public Class MODALIDADCOMPRACG
    Inherits entidadBase

#Region " Propiedades "

    Private _IDMODALIDAD As Int32
    Public Property IDMODALIDAD() As Int32
        Get
            Return _IDMODALIDAD
        End Get
        Set(ByVal value As Int32)
            _IDMODALIDAD = value
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



#End Region

End Class
