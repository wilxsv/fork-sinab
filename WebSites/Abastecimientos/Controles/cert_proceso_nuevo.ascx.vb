Imports SINAB_Entidades.Helpers
Partial Class Controles_cert_proceso_nuevo
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property IdTipoProducto() As String
        Get
            Return DD1.SelectedValue
        End Get
    End Property

    ' x.NUMPROCESO = Me.TextBox2.Text
    Public ReadOnly Property NumeroProceso() As String
        Get
            Return TextBox2.Text
        End Get
    End Property

    ' x.FECHAINICIO = CDate(Me.TextBox3.Text
    Public ReadOnly Property FechaInicio() As String
        Get
            Return TextBox3.Text
        End Get
    End Property

    ' x.COMENTARIO = Me.TextBox1.Text.ToString
    Public ReadOnly Property Comentario() As String
        Get
            Return TextBox1.Text
        End Get
    End Property

    Public Sub CargarDatos()
        CatalogoHelpers.Suministros.CargarALista(DD1, False)

    End Sub

    Public Sub LimpiarDatos()
        Me.TextBox2.Text = ""
        Me.DD1.SelectedIndex = -1
        Me.TextBox3.Text = ""
        Me.TextBox1.Text = ""
    End Sub
End Class
