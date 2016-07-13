
Public Class ENTIDADFINANCIERA
    Inherits entidadBase

#Region " Propiedades "

    Private _IDENTIDAD As Int32
    Public Property IDENTIDAD() As Int32
        Get
            Return _IDENTIDAD
        End Get
        Set(ByVal value As Int32)
            _IDENTIDAD = value
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
