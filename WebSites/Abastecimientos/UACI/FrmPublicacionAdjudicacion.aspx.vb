Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmPublicacionAdjudicacion
    Inherits System.Web.UI.Page

    Private mComponenteProcesoCompra As New cPROCESOCOMPRAS
    Private mEntidadProcesoCompra As New PROCESOCOMPRAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDatos()

            Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
            Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False

        End If

    End Sub

    Private Sub CargarDatos()

        mEntidadProcesoCompra.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadProcesoCompra.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        If mComponenteProcesoCompra.ObtenerPROCESOCOMPRAS(mEntidadProcesoCompra) <> 1 Then
            'Dim e As EventArgs
            'RaiseEvent ErrorEvent("Error al obtener Registro.")
            ' Return
        End If

        Me.lblNoProcesoCompra.Text = mEntidadProcesoCompra.CODIGOLICITACION
        Me.FechaInicioProcCompra.Text = mEntidadProcesoCompra.FECHAINICIOPROCESOCOMPRA.ToShortDateString
        Me.FechaExamen.Text = mEntidadProcesoCompra.FECHAFINEXAMEN.ToShortDateString
        Me.FechaRecomendacion.Text = mEntidadProcesoCompra.FECHAFINRECOMENDACION.ToShortDateString


        Me.rvNotificacion.MinimumValue = CDate(Me.FechaRecomendacion.Text).ToShortDateString
        Me.rvNotificacion.MaximumValue = Today.ToShortDateString

        Me.rvLimite.MinimumValue = Today.ToShortDateString
        Me.rvLimite.MaximumValue = DateAdd(DateInterval.Month, 3, Today).ToShortDateString

        Me.rvPublicacion.MinimumValue = CDate(Me.FechaRecomendacion.Text).ToShortDateString
        Me.rvPublicacion.MaximumValue = Today.ToShortDateString


        '''''' para modificar
        If mEntidadProcesoCompra.FECHANOTIFICACION.Year > 1900 Then
            Me.CPFechaNotificacion.SelectedDate = mEntidadProcesoCompra.FECHANOTIFICACION
        Else
            Me.CPFechaNotificacion.SelectedDate = Today
        End If

        If mEntidadProcesoCompra.FECHALIMITEACEPTACION.Year > 1900 Then
            Me.CPFechaLimite.SelectedDate = mEntidadProcesoCompra.FECHALIMITEACEPTACION
        Else
            Me.CPFechaLimite.SelectedDate = Today
        End If

        If mEntidadProcesoCompra.FECHAPUBLICACIONRESOLUCION.Year > 1900 Then
            Me.CPFechaPublicacion.SelectedDate = mEntidadProcesoCompra.FECHAPUBLICACIONRESOLUCION
        Else
            Me.CPFechaPublicacion.SelectedDate = Today
        End If

        Me.txtMediosDivulgacion.Text = mEntidadProcesoCompra.MEDIOSDIVULGACION


        Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcVistaDetalleSolicProcesCompra1.Consultar()
    End Sub

    Private Sub Actualizar()
        mEntidadProcesoCompra.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadProcesoCompra.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadProcesoCompra.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION
        mComponenteProcesoCompra.ObtenerPROCESOCOMPRAS(mEntidadProcesoCompra)
        Dim bandera As Integer
        bandera = 1
        'If Me.CPFechaNotificacion.SelectedDate <= Today Then
        '    mEntidadProcesoCompra.FECHANOTIFICACION = Me.CPFechaNotificacion.SelectedDate
        'Else
        '    '    Me.lblMensaje.Text = "La fecha de notificación no puede ser mayor a la actual"
        '    bandera = 0
        'End If

        'If Me.CPFechaLimite.SelectedDate >= Today Then
        '    mEntidadProcesoCompra.FECHALIMITEACEPTACION = Me.CPFechaLimite.SelectedDate
        'Else
        '    '   Me.lblMensaje.Text = "<br>La fecha para recepción de notas y recursos debe ser mayor a la fecha actual"
        '    bandera = 0
        'End If

        If Me.CPFechaPublicacion.SelectedDate <= Today Then
            mEntidadProcesoCompra.FECHAPUBLICACIONRESOLUCION = Me.CPFechaPublicacion.SelectedDate
        Else
            '    Me.lblMensaje.Text = "<br>La fecha de publicación no puede ser mayor a la actual"
            bandera = 0
        End If
        If Me.txtMediosDivulgacion.Text <> "" Then
            mEntidadProcesoCompra.MEDIOSDIVULGACION = Me.txtMediosDivulgacion.Text
        ElseIf Me.txtMediosDivulgacion.Text = "" And mEntidadProcesoCompra.MEDIOSDIVULGACION <> "" Then
            '  Me.lblMensaje.Text = "<br>El campo medios de divulgación no puede quedar vacío"
            bandera = 0
        End If
        If bandera = 1 Then
            'If mEntidadProcesoCompra.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA Then
            '    mEntidadProcesoCompra.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION
            'End If
            mComponenteProcesoCompra.ActualizarPROCESOCOMPRAS(mEntidadProcesoCompra)
            Me.lblMensaje.Text = "Datos guardados satisfactoriamente"
            Me.MsgBox1.ShowAlert("Datos guardados satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            'MsgBox("Datos guardados satisfactoriamente", MsgBoxStyle.Information, "Sistema de Abastecimiento")

        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Actualizar()
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "A" Then
            Me.Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub
End Class
