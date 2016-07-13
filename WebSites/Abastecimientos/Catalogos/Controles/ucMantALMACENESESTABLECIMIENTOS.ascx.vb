
Partial Class ucMantALMACENESEStableCIMIENTOS
    Inherits System.Web.UI.UserControl

    Public Function CargarDatos() As Integer

        Try
            If Me.ucListaALMACENESESTABLECIMIENTOS1.CargarDatos() <> 1 Then Return -1
        Catch ex As Exception
            Return -1
        End Try

        Return 1

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim bPermiteEditar As Boolean = clsObtenerDatos.OpcionPermiteEditar(Session.Item("IdRol"), Request.AppRelativeCurrentExecutionFilePath)

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = bPermiteEditar
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucListaALMACENESESTABLECIMIENTOS1.PermiteEliminar = bPermiteEditar

            Me.CargarDatos()

        End If

    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/Catalogos/wfDetaMantALMACENESESTABLECIMIENTOS.aspx?id=0", False)
    End Sub

End Class
