
Partial Class Controles_Uploader
    Inherits System.Web.UI.UserControl

    Dim _idproducto As Integer
    Private _idsolicitud As Integer
    Dim _renglon As Integer
    Private _idestablecimiento As Integer

    Public Property IdProducto() As Integer
        Set(value As Integer)
            _idproducto = value

        End Set
        Get
            Return _idproducto
        End Get
    End Property

    Public Property Renglon() As Integer
        Set(value As Integer)
            _renglon = value

        End Set
        Get
            Return _renglon
        End Get
    End Property

    Public Property IdSolicitud() As Integer
        Set(value As Integer)
            _idsolicitud = value
        End Set
        Get
            Return _idsolicitud
        End Get
    End Property

    Public Property IdEstablecimiento() As Integer
        Set(value As Integer)
            _idestablecimiento = value
        End Set
        Get
            Return _idestablecimiento
        End Get
    End Property
End Class
