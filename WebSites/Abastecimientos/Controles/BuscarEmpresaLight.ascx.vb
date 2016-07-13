
Partial Class Controles_BuscarEmpresaLight
    Inherits System.Web.UI.UserControl


    Public ReadOnly Property ProviderId() As Int32
        Get
            Return CType(hfId.Value, Integer)
        End Get
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
