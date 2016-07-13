Public Class eDatosFiltro

    Private _encabezado As String
    Private _dataBind As String

    Public Property encabezado() As String
        Get
            Return _encabezado
        End Get
        Set(ByVal value As String)
            _encabezado = value
        End Set
    End Property

    Public Property dataBind() As String
        Get
            Return _dataBind
        End Get
        Set(ByVal value As String)
            _dataBind = value
        End Set
    End Property

    Public Sub New(ByVal encabezado As String, ByVal campoEnlazar As String)

        _encabezado = encabezado
        _dataBind = campoEnlazar

    End Sub

End Class
