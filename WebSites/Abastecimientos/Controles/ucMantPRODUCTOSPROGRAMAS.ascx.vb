
Partial Class ucMantPRODUCTOSPROGRAMAS
    Inherits System.Web.UI.UserControl

    Public Function CargarDatos() As Integer

        Try
            If Me.ucListaPRODUCTOSPROGRAMAS1.CargarDatos() <> 1 Then Return -1
        Catch ex As Exception
            Return -1
        End Try

        Return 1

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim bPermiteEditar As Boolean = clsObtenerDatos.OpcionPermiteEditar(Session.Item("IdRol"), Request.AppRelativeCurrentExecutionFilePath)

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = True
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucListaPRODUCTOSPROGRAMAS1.PermitirEliminar = bPermiteEditar

            Me.CargarDatos()

        End If

    End Sub

    Private Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/Catalogos/wfDetaMantPRODUCTOSPROGRAMAS.aspx?id=0")
    End Sub

End Class
