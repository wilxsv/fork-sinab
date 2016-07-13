
Namespace Controles
    Partial Class Controles_AdministradoresContrato
        Inherits System.Web.UI.UserControl

        

        
        Public Property NombreAdmin() As String
            Set(value As String)
                tbNombreAdmin.Text = value
            End Set
            Get
                Return tbNombreAdmin.Text
            End Get
        End Property

        Public Property CargoAdmin() As String
            Set(value As String)
                tbCargoAdmin.Text = value
            End Set
            Get
                Return tbCargoAdmin.Text
            End Get
        End Property

      

        Public Event RemoverAdministrador As EventHandler


        Protected Sub lnkDelete_Click(sender As Object, e As System.EventArgs) Handles lnkDelete.Click
            RaiseEvent RemoverAdministrador(sender, e)
        End Sub
    End Class
End Namespace