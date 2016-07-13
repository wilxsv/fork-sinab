'Mantenimiento de roles
'CUA0003 seguridad
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de roles del sistema
Partial Class FrmDetaMantRoles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then 'la primer vez que carga
            Me.Master.ControlMenu.Visible = False 'oculta menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            Dim lId As Int32 = Request.QueryString("id") 'identificador del rol
            Me.ucVistaDetalleRoles1.IDROL = lId
        End If
    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'al momento de cancelar
        Response.Redirect("~/SEGURIDAD/FrmMantRoles.aspx", False)
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'al momento de guardar
        Dim sError As String
        sError = Me.ucVistaDetalleRoles1.Actualizar()
        If sError <> "" Then 'error al guardar
            Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
        Response.Redirect("~/SEGURIDAD/FrmMantRoles.aspx", False)
    End Sub

    Private Sub ucVistaDetalleRoles1_ErrorEvent(ByVal errorMessage As String) Handles ucVistaDetalleRoles1.ErrorEvent
        'al generar evento de errror
        Me.MsgBox1.ShowAlert(errorMessage, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

End Class
