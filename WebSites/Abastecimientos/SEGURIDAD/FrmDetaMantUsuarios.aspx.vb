'Mantenimiento de usuarios
'CUA0004 seguridad
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de usuarios del sistema
Partial Class FrmDetaMantUsuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then 'la primera vez que carga
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            Me.VistaDetalleUsuarios1.IDUSUARIO = lId
        End If

    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/SEGURIDAD/FrmMantUsuarios.aspx", False)
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'evento guardar
        Dim sError As String
        sError = Me.VistaDetalleUsuarios1.Actualizar()
        If sError <> "" Then
            Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
        Response.Redirect("~/SEGURIDAD/FrmMantUsuarios.aspx", False)
    End Sub

    Private Sub VistaDetalleUSUARIOS1_ErrorEvent(ByVal errorMessage As String) Handles VistaDetalleUsuarios1.ErrorEvent
        'evento al generarse error
        Me.MsgBox1.ShowAlert(errorMessage, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub VistaDetalleUsuarios1_InhabilitarGuardar() Handles VistaDetalleUsuarios1.InhabilitarGuardar
        'inhabilitar el podr guardar
        Me.ucBarraNavegacion1.PermitirGuardar = False
    End Sub

End Class
