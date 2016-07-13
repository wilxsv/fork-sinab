
Partial Class ucMantESTABLECIMIENTOS
    Inherits System.Web.UI.UserControl

    Public WriteOnly Property Reporte() As String
        Set(ByVal value As String)
            Me.ucBarraNavegacion1.ibtnImprimirOnClientClick = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Try
            If Me.ucListaESTABLECIMIENTOS1.CargarDatos() <> 1 Then Return -1
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
            Me.ucBarraNavegacion1.PermitirImprimir = True
            Me.ucListaESTABLECIMIENTOS1.PermitirEliminar = bPermiteEditar

            Me.CargarDatos()

        End If

    End Sub

    Private Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/Catalogos/wfDetaMantESTABLECIMIENTOS.aspx?id=0")
    End Sub

End Class
