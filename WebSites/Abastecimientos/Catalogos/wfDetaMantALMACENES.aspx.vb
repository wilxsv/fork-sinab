
Partial Class wfDetaMantALMACENES
    Inherits System.Web.UI.Page

    Private URLwfMant As String = "~/Catalogos/wfMantALMACENES.aspx"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Dim bPermiteEditar As Boolean = clsObtenerDatos.OpcionPermiteEditar(Session.Item("IdRol"), URLwfMant)

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirCancelar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirGuardar = bPermiteEditar
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucVistaDetalleALMACENES1.Enabled = bPermiteEditar

            Dim lId As Int32 = Request.QueryString("id")
            Me.ucVistaDetalleALMACENES1.IDALMACEN = lId
        End If
    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        Response.Redirect(URLwfMant, False)
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        Dim sError As String
        sError = Me.ucVistaDetalleALMACENES1.Actualizar()
        If sError <> "" Then
            MsgBox1.ShowAlert(sError, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
        Response.Redirect(URLwfMant, False)
    End Sub

    Private Sub ucVistaDetalleALMACENES1_ErrorEvent(ByVal errorMessage As String) Handles ucVistaDetalleALMACENES1.ErrorEvent
        MsgBox1.ShowAlert(errorMessage, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
