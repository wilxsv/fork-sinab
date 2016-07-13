
Partial Class Controles_BuscarProductosLight
    Inherits System.Web.UI.UserControl
    PUblic WriteOnly Property SetFocus() as Boolean
    Set(value As Boolean)
            tbProductos.Focus()
    End Set
    End Property

    Public ReadOnly Property ProductId() As String
        Get
            Return hfId.Value
        End Get
    End Property

    Public ReadOnly Property ProductCorrelative() As String
        Get
            Return hfCorrelativo.Value
        End Get
    End Property

    Public Property Almacen() As Integer
        Get
            Return CType(Session("_almacen"), Integer)
        End Get
        Set(value As Integer)
            Session("_almacen") = value
        End Set
    End Property

    Public Property Suministro() As Integer
        Get
            Return CType(Session("_suministro"), Integer)
        End Get
        Set(value As Integer)
            Session("_suministro") = value
        End Set
    End Property

    Public Property SearchingText() As String
        Get
            Return tbProductos.Text
        End Get
        Set(value As String)
            tbProductos.Text = value
        End Set
    End Property

    

End Class
