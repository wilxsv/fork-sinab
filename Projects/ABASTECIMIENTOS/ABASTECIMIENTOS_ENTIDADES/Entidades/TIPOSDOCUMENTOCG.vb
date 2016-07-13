
Public Class TIPOSDOCUMENTOCG
    Inherits entidadBase

#Region " Propiedades "

    Private _IDTIPODOCUMENTO As Int32
    Public Property IDTIPODOCUMENTO() As Int32
        Get
            Return _IDTIPODOCUMENTO
        End Get
        Set(ByVal value As Int32)
            _IDTIPODOCUMENTO = value
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
