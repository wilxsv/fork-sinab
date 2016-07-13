
Partial Class FrmDetaMantOpcionesRoles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            Dim lId As Int32 = Request.QueryString("idRol")
            Me.ucVistaDetalleOpcionesRoles1.IDROL = lId
            Dim rol As String = Request.QueryString("rol")
            Me.ucVistaDetalleOpcionesRoles1.ROL = rol
        End If

    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        Response.Redirect("~/SEGURIDAD/FrmMantOpcionesRoles.aspx?idRol=" & Me.ucVistaDetalleOpcionesRoles1.IDROL.ToString, False)
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        Dim sError As String
        sError = Me.ucVistaDetalleOpcionesRoles1.Actualizar()
        If sError <> "" Then
            Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
        Response.Redirect("~/SEGURIDAD/FrmMantOpcionesRoles.aspx?idRol=" & Me.ucVistaDetalleOpcionesRoles1.IDROL.ToString, False)
    End Sub

    Private Sub VistaDetalleROLES1_ErrorEvent(ByVal errorMessage As String) Handles ucVistaDetalleOpcionesRoles1.ErrorEvent
        Me.MsgBox1.ShowAlert(errorMessage, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub ucVistaDetalleOpcionesRoles1_InhabilitarGuardar() Handles ucVistaDetalleOpcionesRoles1.InhabilitarGuardar
        Me.ucBarraNavegacion1.PermitirGuardar = False
    End Sub

End Class
