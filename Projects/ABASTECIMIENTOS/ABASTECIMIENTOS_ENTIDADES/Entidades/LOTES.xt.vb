Partial Public Class LOTES

#Region " Propiedades Agregadas "

    Private _UNIDADMEDIDA As String
    Public Property UNIDADMEDIDA() As String
        Get
            Return _UNIDADMEDIDA
        End Get
        Set(ByVal value As String)
            _UNIDADMEDIDA = value
        End Set
    End Property

    Private _CANTIDADDECIMAL As Byte
    Public Property CANTIDADDECIMAL() As Byte
        Get
            Return _CANTIDADDECIMAL
        End Get
        Set(ByVal value As Byte)
            _CANTIDADDECIMAL = value
        End Set
    End Property

    Private _DESCLARGO As String
    Public Property DESCLARGO() As String
        Get
            Return _DESCLARGO
        End Get
        Set(ByVal value As String)
            _DESCLARGO = value
        End Set
    End Property

#End Region

End Class
