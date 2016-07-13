'Mantenimiento de opciones del sistema
'CUA0002 seguridad
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de opciones del sistema
Partial Class FrmDetaMantOpcionesSistema
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar la pagina

        If Not Page.IsPostBack Then 'al cargar primera vez
            Me.Master.ControlMenu.Visible = False 'oculta menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            Dim lId As Int32 = Request.QueryString("id") 'identificador de opcion del sistema
            Me.ucVistaDetalleOpcionesSistema1.IDOPCIONSISTEMA = lId
        End If
    End Sub

    Private Sub BarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'al momento de cancelar
        Response.Redirect("~/SEGURIDAD/FrmMantOpcionesSistema.aspx", False)
    End Sub

    Private Sub BarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'al momento de guardar
        Dim sError As String
        sError = Me.ucVistaDetalleOpcionesSistema1.Actualizar()
        If sError <> "" Then 'error al guardar
            Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If

        Response.Redirect("~/SEGURIDAD/FrmMantOpcionesSistema.aspx", False)
    End Sub

    Private Sub ucVistaDetalleOpcionesSistema1_ErrorEvent(ByVal errorMessage As String) Handles ucVistaDetalleOpcionesSistema1.ErrorEvent
        'evento error
        Me.MsgBox1.ShowAlert(errorMessage, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

End Class
