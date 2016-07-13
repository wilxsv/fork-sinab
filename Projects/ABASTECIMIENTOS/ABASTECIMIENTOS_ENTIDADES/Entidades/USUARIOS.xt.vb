Partial Public Class USUARIOS

#Region " Propiedades Agregadas "

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
