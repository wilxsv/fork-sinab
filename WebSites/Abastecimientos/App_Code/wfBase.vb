Imports System.Web.UI.WebControls


Public Class wfBase
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Request.IsAuthenticated Then
            Response.Redirect("wfPrincipal.aspx?")
        End If
    End Sub

    Public Sub AsignarMensaje(ByVal asMensaje As String, Optional ByVal EsError As Boolean = False, Optional ByVal EsAlerta As Boolean = False)
        Dim myLabel As Label

        myLabel = Master.FindControl("LblMensaje")


        If myLabel Is Nothing Then Return

        If EsAlerta Then
            If EsError Then
                Response.Write("<script language='JavaScript'>alert('Error : " + asMensaje + "')</script>")
            Else
                Response.Write("<script language='JavaScript'>alert('" + asMensaje + "')</script>")
            End If
        End If

        If EsError Then
            myLabel.CssClass = "MensajeError"
        Else
            myLabel.CssClass = "MensajeInformativo"
        End If

        myLabel.Text = asMensaje

    End Sub

    Public Function ObtenerUsuario() As String
        Return Context.User.Identity.Name
    End Function

End Class
