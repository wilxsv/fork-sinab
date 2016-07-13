
Public Class LISTACP
    Inherits entidadBase

#Region " Propiedades "

    Private _IDLISTA As Int32
    Public Property IDLISTA() As Int32
        Get
            Return _IDLISTA
        End Get
        Set(ByVal value As Int32)
            _IDLISTA = value
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

    Private _IDSUMINISTRO As Int32
    Public Property IDSUMINISTRO() As Int32
        Get
            Return _IDSUMINISTRO
        End Get
        Set(ByVal value As Int32)
            _IDSUMINISTRO = value
        End Set
    End Property

#End Region

End Class
