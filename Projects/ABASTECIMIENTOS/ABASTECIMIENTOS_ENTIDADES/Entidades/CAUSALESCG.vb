
Public Class CAUSALESCG
    Inherits entidadBase

#Region " Propiedades "

    Private _IDCAUSAL As Int32
    Public Property IDCAUSAL() As Int32
        Get
            Return _IDCAUSAL
        End Get
        Set(ByVal value As Int32)
            _IDCAUSAL = value
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

    Private _IDTIPOGARANTIA As Int32
    Public Property IDTIPOGARANTIA() As Int32
        Get
            Return _IDTIPOGARANTIA
        End Get
        Set(ByVal value As Int32)
            _IDTIPOGARANTIA = value
        End Set
    End Property

#End Region

End Class
