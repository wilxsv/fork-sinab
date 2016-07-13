
Partial Class Controles_BuscarLugarEntrega
    Inherits System.Web.UI.UserControl


    Public ReadOnly Property IdAlmacen() As String
        Get
            Return hfId.Value
        End Get
    End Property

    Public Property SearchingText() As String
        Get
            Return tbAlmacenEntrega.Text
        End Get
        Set(value As String)
            tbAlmacenEntrega.Text = value
        End Set
    End Property

    Public Property IdSolicitud() As Long
        Get
            Return CType(Session("_idsolicitud"), Long)
        End Get
        Set(value As Long)
            Session("_idsolicitud") = value
        End Set
    End Property

    Public Property IdEstablecimiento() As Integer
        Get
            Return CType(Session("_idestablecimiento"), Integer)
        End Get
        Set(value As Integer)
            Session("_idestablecimiento") = value
        End Set
    End Property
End Class
