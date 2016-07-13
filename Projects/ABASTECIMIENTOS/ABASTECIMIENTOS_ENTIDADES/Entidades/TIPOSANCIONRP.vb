
Public Class TIPOSANCIONRP
    Inherits entidadBase

#Region " Propiedades "

    Private _IDTIPOSANCION As Int32
    Public Property IDTIPOSANCION() As Int32
        Get
            Return _IDTIPOSANCION
        End Get
        Set(ByVal value As Int32)
            _IDTIPOSANCION = value
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
