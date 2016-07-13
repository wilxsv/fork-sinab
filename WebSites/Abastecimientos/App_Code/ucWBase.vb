Imports System.Web.UI.WebControls
Imports System.Text


Public Class ucWBase
    Inherits System.Web.UI.UserControl

    '    Public Overridable Function Inicializar()

    '    End Function

    Public Sub AsignarMensaje(ByVal asMensaje As String, Optional ByVal EsError As Boolean = False, Optional ByVal EsAlerta As Boolean = False)
        Dim myLabel As Label

        myLabel = Page.FindControl("ucEncabezado1").FindControl("Label_Mensaje")

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

    '    Public Function ObtenerUsuario() As String
    '        Return Context.User.Identity.Name
    '    End Function

    '    Public Function ObtenerCodigoEmpleado() As String
    '        Return Context.Items("codigoEmpleado")
    '    End Function

    '    Public Function ObtenerCodigoArea() As String
    '        Return Context.Items("codigoArea")
    '    End Function

    '    Public Sub LimpiarControles()
    '        Dim liCntrl As Integer
    '        Dim Cntrl As System.Web.UI.WebControls.TextBox
    '        Dim DDL As System.Web.UI.WebControls.DropDownList

    '        For liCntrl = 0 To Me.Controls.Count - 1
    '            Select Case Me.Controls(liCntrl).GetType().ToString
    '                Case "System.Web.UI.WebControls.TextBox"
    '                    Cntrl = CType(Me.Controls(liCntrl), TextBox)
    '                    If Cntrl.Visible Then Cntrl.Text = ""
    '                Case "System.Web.UI.WebControls.DropDownList"
    '                    Dim li As System.Web.UI.WebControls.ListItem
    '                    ' Buscar si existe un valor 0 en la lista.  Si existe, seleccionarlo
    '                    DDL = CType(Me.Controls(liCntrl), DropDownList)
    '                    li = DDL.Items.FindByValue("0")

    '                    If Not li Is Nothing Then DDL.SelectedValue = "0"
    '            End Select

    '            If InStr(Me.Controls(liCntrl).GetType().ToString, "ucDDL") > 0 Then
    '                Dim li As System.Web.UI.WebControls.ListItem
    '                ' Buscar si existe un valor 0 en la lista.  Si existe, seleccionarlo
    '                DDL = CType(Me.Controls(liCntrl), DropDownList)
    '                li = DDL.Items.FindByValue("0")

    '                If Not li Is Nothing Then DDL.SelectedValue = "0"
    '            End If
    '        Next
    '    End Sub

End Class
