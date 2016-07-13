
Namespace Controles
    Partial Class Controles_Dialogo
        Inherits System.Web.UI.UserControl
        Public WriteOnly Property OcultarCerrar As Boolean
            Set(value As Boolean)

                If value Then
                    cerrar.Visible = False
                Else
                    cerrar.Visible = True
                End If
            End Set
        End Property

        Public WriteOnly Property Tipo() As TiposMensaje
            Set(value As TiposMensaje)

                If value = TiposMensaje.Problema Then
                    Clase = "ui-state-error"
                    Icono = "ui-icon-alert"
                Else
                    Clase = "ui-state-highlight"
                    Icono = "ui-icon-info"
                End If
            End Set
        End Property


        Public Property Mensaje() As String
            Get
                Return errorMsj.Text
            End Get
            Set(value As String)
                errorMsj.Text = value
            End Set
        End Property

        Protected Sub cerrar_Click(sender As Object, e As System.EventArgs) Handles cerrar.Click
            errorContent.Parent.Visible = False
        End Sub


        Protected Clase As String
        Protected Icono As String
    End Class

    Public Enum TiposMensaje
        Alerta = 0
        Problema = 1
    End Enum
End Namespace