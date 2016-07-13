
Partial Class ucMantCLAUSULAS
    Inherits System.Web.UI.UserControl

    Private _IDMODALIDADCOMPRA As Integer
    Public Property IDMODALIDADCOMPRA() As Integer
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDMODALIDADCOMPRA = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Try
            If Me.ucListaCLAUSULAS1.CargarDatos() <> 1 Then Return -1
        Catch ex As Exception
            Return -1
        End Try

        Return 1

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim bPermiteEditar As Boolean = IIf(clsObtenerDatos.OpcionPermiteEditar(Session.Item("IdRol"), Request.AppRelativeCurrentExecutionFilePath + Request.Url.Query) = 1, True, False)

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = bPermiteEditar
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucListaCLAUSULAS1.PermitirEliminar = bPermiteEditar

            Me.ucListaCLAUSULAS1.IDMODALIDADCOMPRA = Me.IDMODALIDADCOMPRA

            Me.CargarDatos()

        End If

    End Sub

    Private Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/Catalogos/wfDetaMantCLAUSULAS.aspx?IdMod=" + Me.ucListaCLAUSULAS1.IDMODALIDADCOMPRA.ToString + "&id=0", False)
    End Sub

End Class
