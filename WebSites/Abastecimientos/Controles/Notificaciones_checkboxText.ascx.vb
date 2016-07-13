
Partial Class Controles_Notificaciones_checkboxText
    Inherits System.Web.UI.UserControl
    Public Property Title() As String
        Get
            Return ltTitle.Text
        End Get
        Set(value As String)
            ltTitle.Text = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return tbText.Text
        End Get
        Set(value As String)
            tbText.Text = value
        End Set
    End Property

    Public Property SelectedValue() As Integer
        Get
            Return CType(rbList.SelectedValue, Integer)
        End Get
        Set(value As Integer)
            rbList.SelectedValue = value.ToString()
            If value = 1 Then
                tbText.Visible = True
            End If
        End Set
    End Property

    Public Property Enabled() As Boolean
    get
            Return rbList.Enabled
    End Get
    Set(value As Boolean)
            rbList.Enabled = value
            tbText.Enabled = value
    End Set
    End Property

    Protected Sub rbList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbList.SelectedIndexChanged
        If rbList.SelectedValue = 1 Then
            tbText.Visible = True
        Else
            tbText.Text = ""
            tbText.Visible = False
        End If

    End Sub


End Class
