
Public Class CAUSASRP
    Inherits entidadBase

#Region " Propiedades "

    Private _IDCAUSA As Int32
    Public Property IDCAUSA() As Int32
        Get
            Return _IDCAUSA
        End Get
        Set(ByVal value As Int32)
            _IDCAUSA = value
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
