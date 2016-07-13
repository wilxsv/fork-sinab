
Partial Class FrmImpresionComision
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Label2.Text = Request.QueryString("NomComision")
            Me.gvComisionEvaluacion.DataSource = Session("ComisionFinal")
            Me.gvComisionEvaluacion.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Write("<script language=javascript>")
        Response.Write("print();")
        Response.Write("</script>")

    End Sub

    Protected Function estaHabilitadoEmpleado(ByVal estahabilitado As Integer) As String
        If estahabilitado = 0 Then
            Return "Si"
        Else
            Return "No"
        End If
    End Function

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Session("ComisionFinal") = Nothing
        Session("NomComision") = Nothing
    End Sub
End Class
