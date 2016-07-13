Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmRegistrarNotasAceptacionySolvencias
    Inherits System.Web.UI.Page

    Private mComponenteProcesoCompra As New cPROCESOCOMPRAS
    Private mComponenteAdjudicacion As New cADJUDICACION
    Private mComponenteNotasAceptacion As New cNOTASACEPTACION
    Private mEntidadProcesoCompra As PROCESOCOMPRAS
    Private mEntidadAdjudicacion As ADJUDICACION
    Private mEntidadNotasAceptacion As New NOTASACEPTACION

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            Dim cad = "/Reportes/frmRptProveedoresAdjudicados.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idPC=" + Request.QueryString("idProc")
            Me.btnInformeNotas.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            '"window.open('" + Request.ApplicationPath + "/Reportes/frmRptProveedoresAdjudicados.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idPC=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

            cad = "/Reportes/frmRptSolvencias.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idPC=" + Request.QueryString("idProc")
            Me.btnInformeSolvencias.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            '"window.open('" + Request.ApplicationPath + "/Reportes/frmRptSolvencias.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idPC=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

            CargarDatos()

            Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
            Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False

            Me.rvFechaRecepcionConfia.MaximumValue = Today.ToShortDateString
            Me.rvFechaRecepcionCrecer.MaximumValue = Today.ToShortDateString
            Me.rvFechaRecepcionAlcaldia.MaximumValue = Today.ToShortDateString
            Me.rvFechaRecepcionIPFA.MaximumValue = Today.ToShortDateString
            Me.rvFechaRecepcionISSS1.MaximumValue = Today.ToShortDateString
            Me.rvFechaRecepcionISSS2.MaximumValue = Today.ToShortDateString
            Me.rvFechaRecepcionIva.MaximumValue = Today.ToShortDateString

            Dim fecha As Date
            fecha = DateAdd(DateInterval.Year, 2, Today)

            Me.rvFechaVigenciaConfia.MaximumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaCrecer.MaximumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaAlcaldia.MaximumValue = fecha.ToShortDateString
            Me.rvFechVigenciaIPFA.MaximumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaISSS1.MaximumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaISSS2.MaximumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaIVA.MaximumValue = fecha.ToShortDateString

            Me.CPFechaVigenciaAlcaldia.UpperBoundDate = fecha
            Me.CPFechaVigenciaConfia.UpperBoundDate = fecha
            Me.CPFechaVigenciaCrecer.UpperBoundDate = fecha
            Me.CPFechaVigenciaISSS1.UpperBoundDate = fecha
            Me.CPFechaVigenciaISSS2.UpperBoundDate = fecha
            Me.CPFechaVigenciaIVA.UpperBoundDate = fecha
            Me.CPFechVigenciaIPFA.UpperBoundDate = fecha

            fecha = DateAdd(DateInterval.Year, -2, Today)

            Me.rvFechaVigenciaConfia.MinimumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaCrecer.MinimumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaAlcaldia.MinimumValue = fecha.ToShortDateString
            Me.rvFechVigenciaIPFA.MinimumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaISSS1.MinimumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaISSS2.MinimumValue = fecha.ToShortDateString
            Me.rvFechaVigenciaIVA.MinimumValue = fecha.ToShortDateString

            Me.CPFechaVigenciaAlcaldia.LowerBoundDate = fecha
            Me.CPFechaVigenciaConfia.LowerBoundDate = fecha
            Me.CPFechaVigenciaCrecer.LowerBoundDate = fecha
            Me.CPFechaVigenciaISSS1.LowerBoundDate = fecha
            Me.CPFechaVigenciaISSS2.LowerBoundDate = fecha
            Me.CPFechaVigenciaIVA.LowerBoundDate = fecha
            Me.CPFechVigenciaIPFA.LowerBoundDate = fecha

        End If

    End Sub

    Private Sub CargarDatos()

        mEntidadProcesoCompra = New PROCESOCOMPRAS
        mEntidadProcesoCompra.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadProcesoCompra.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        If mComponenteProcesoCompra.ObtenerPROCESOCOMPRAS(mEntidadProcesoCompra) <> 1 Then
            'Dim e As EventArgs
            'RaiseEvent ErrorEvent("Error al obtener Registro.")
            ' Return
        End If

        Me.lblNoProcesoCompra.Text = mEntidadProcesoCompra.CODIGOLICITACION
        If mEntidadProcesoCompra.FECHAINICIOPROCESOCOMPRA.Year > 1900 Then
            Me.FechaInicioProcCompra.Text = mEntidadProcesoCompra.FECHAINICIOPROCESOCOMPRA.ToShortDateString
        Else
            Me.FechaInicioProcCompra.Text = ""
        End If

        If mEntidadProcesoCompra.FECHANOTIFICACION.Year > 1900 Then
            Me.FechaNotificacionEmpresas.Text = mEntidadProcesoCompra.FECHANOTIFICACION.ToShortDateString
            Me.rvFechaRecepcionAlcaldia.MinimumValue = Me.FechaNotificacionEmpresas.Text
            Me.rvFechaRecepcionConfia.MinimumValue = Me.FechaNotificacionEmpresas.Text
            Me.rvFechaRecepcionCrecer.MinimumValue = Me.FechaNotificacionEmpresas.Text
            Me.rvFechaRecepcionIPFA.MinimumValue = Me.FechaNotificacionEmpresas.Text
            Me.rvFechaRecepcionISSS1.MinimumValue = Me.FechaNotificacionEmpresas.Text
            Me.rvFechaRecepcionISSS1.MinimumValue = Me.FechaNotificacionEmpresas.Text
            Me.rvFechaRecepcionISSS2.MinimumValue = Me.FechaNotificacionEmpresas.Text
            Me.rvFechaRecepcionIva.MinimumValue = Me.FechaNotificacionEmpresas.Text
        Else
            Me.FechaNotificacionEmpresas.Text = ""
            Me.rvFechaRecepcionAlcaldia.MinimumValue = Date.MinValue.ToShortDateString
            Me.rvFechaRecepcionConfia.MinimumValue = Date.MinValue.ToShortDateString
            Me.rvFechaRecepcionCrecer.MinimumValue = Date.MinValue.ToShortDateString
            Me.rvFechaRecepcionIPFA.MinimumValue = Date.MinValue.ToShortDateString
            Me.rvFechaRecepcionISSS1.MinimumValue = Date.MinValue.ToShortDateString
            Me.rvFechaRecepcionISSS2.MinimumValue = Date.MinValue.ToShortDateString
            Me.rvFechaRecepcionIva.MinimumValue = Date.MinValue.ToShortDateString
        End If

        If mEntidadProcesoCompra.FECHALIMITEACEPTACION.Year > 1900 Then
            Me.FechaLimiteAceptacion.Text = mEntidadProcesoCompra.FECHALIMITEACEPTACION.ToShortDateString
        Else
            Me.FechaLimiteAceptacion.Text = ""
        End If

        Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcVistaDetalleSolicProcesCompra1.Consultar()

        mEntidadAdjudicacion = New ADJUDICACION
        mEntidadAdjudicacion.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadAdjudicacion.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ddlProvedoresAdjudicados.DataSource = mComponenteAdjudicacion.obtenerDatasetProveedoresAdjudicados(mEntidadAdjudicacion.IDESTABLECIMIENTO, mEntidadAdjudicacion.IDPROCESOCOMPRA)
        Me.ddlProvedoresAdjudicados.DataTextField = "NOMBRE"
        Me.ddlProvedoresAdjudicados.DataValueField = "IDPROVEEDOR"
        Me.ddlProvedoresAdjudicados.DataBind()

        mEntidadNotasAceptacion.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadNotasAceptacion.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        'If Today > mEntidadProcesoCompra.FECHALIMITEACEPTACION Then
        '    Me.Button2.Visible = False
        '    Me.lblMensaje.Text = "La fecha límite para registrar notas de aceptacion ha caducado. Sólo se permite consultar."
        'Else
        '    Me.Button2.Visible = True
        'End If

        Try
            CargarNotasProveedor(Me.ddlProvedoresAdjudicados.SelectedValue)
        Catch ex As Exception

            Me.btnInformeNotas.Visible = False
            Me.Button2.Visible = False
            Me.btnInformeSolvencias.Visible = False

            Me.MsgBox1.ShowAlert("No hay proveedores adjudicados", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

        End Try

    End Sub

    Private Sub CargarNotasProveedor(ByVal IDPROVEEDOR As Integer)
        mEntidadNotasAceptacion.IDPROVEEDOR = IDPROVEEDOR ' Me.ddlProvedoresAdjudicados.SelectedValue
        mComponenteNotasAceptacion.ObtenerNOTASACEPTACION(mEntidadNotasAceptacion)

        Me.txtPersonaFirma.Text = mEntidadNotasAceptacion.NOMBREPERSONAFIRMA

        If mEntidadNotasAceptacion.PRESENTANOTA = 0 Then
            Me.CheckBox1.Checked = False
        Else
            Me.CheckBox1.Checked = True
            Me.CheckBox1.Enabled = False
        End If

        If mEntidadNotasAceptacion.DUIPERSONAFIRMA <> "" Then
            Me.NBDui.Text = mEntidadNotasAceptacion.DUIPERSONAFIRMA
            Me.CPFechaRecepcion.Enabled = False
        Else
            Me.CPFechaRecepcion.Enabled = True
            Me.NBDui.Text = ""
        End If

        If mEntidadNotasAceptacion.FECHARECEPCION.Year > 1900 Then
            Me.CPFechaRecepcion.SelectedDate = mEntidadNotasAceptacion.FECHARECEPCION
            Me.CheckBox1.Checked = True
            Me.CheckBox1.Enabled = False
            Me.CPFechaRecepcion.Enabled = False
        Else
            Me.CPFechaRecepcion.SelectedDate = Today
            Me.CheckBox1.Checked = False
            Me.CheckBox1.Enabled = True
            Me.CPFechaRecepcion.Enabled = True
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If mEntidadNotasAceptacion.AFPCONFIARECEPCION.Year > 1900 And mEntidadNotasAceptacion.AFPCONFIAVIGENCIA.Year > 1900 Then
            Me.CPFechaRecepcionConfia.SelectedDate = mEntidadNotasAceptacion.AFPCONFIARECEPCION
            Me.CPFechaVigenciaConfia.SelectedDate = mEntidadNotasAceptacion.AFPCONFIAVIGENCIA
            Me.CheckBox2.Checked = True
            Me.CheckBox2.Enabled = False
            Me.CPFechaRecepcionConfia.Enabled = False
            Me.CPFechaVigenciaConfia.Enabled = False
        Else
            Me.CheckBox2.Checked = False
            Me.CheckBox2.Enabled = True
            Me.CPFechaRecepcionConfia.Enabled = True
            Me.CPFechaVigenciaConfia.Enabled = True
            Me.CPFechaRecepcionConfia.SelectedDate = Today
            Me.CPFechaVigenciaConfia.SelectedDate = Today
        End If

        If mEntidadNotasAceptacion.AFPCRECERRECEPCION.Year > 1900 And mEntidadNotasAceptacion.AFPCRECERVIGENCIA.Year > 1900 Then
            Me.CPFechaRecepcionCrecer.SelectedDate = mEntidadNotasAceptacion.AFPCRECERRECEPCION
            Me.CPFechaVigenciaCrecer.SelectedDate = mEntidadNotasAceptacion.AFPCRECERVIGENCIA
            Me.CheckBox3.Checked = True
            Me.CheckBox3.Enabled = False
            Me.CPFechaRecepcionCrecer.Enabled = False
            Me.CPFechaVigenciaCrecer.Enabled = False
        Else
            Me.CheckBox3.Checked = False
            Me.CheckBox3.Enabled = True
            Me.CPFechaRecepcionCrecer.Enabled = True
            Me.CPFechaVigenciaCrecer.Enabled = True
            Me.CPFechaRecepcionCrecer.SelectedDate = Today
            Me.CPFechaVigenciaCrecer.SelectedDate = Today
        End If

        If mEntidadNotasAceptacion.IPFARECEPCION.Year > 1900 And mEntidadNotasAceptacion.IPFAVIGENCIA.Year > 1900 Then
            Me.CPFechaRecepcionIPFA.SelectedDate = mEntidadNotasAceptacion.IPFARECEPCION
            Me.CPFechVigenciaIPFA.SelectedDate = mEntidadNotasAceptacion.IPFAVIGENCIA
            Me.CheckBox4.Checked = True
            Me.CheckBox4.Enabled = False
            Me.CPFechaRecepcionIPFA.Enabled = False
            Me.CPFechVigenciaIPFA.Enabled = False
        Else
            Me.CheckBox4.Checked = False
            Me.CheckBox4.Enabled = True
            Me.CPFechaRecepcionIPFA.Enabled = True
            Me.CPFechVigenciaIPFA.Enabled = True
            Me.CPFechaRecepcionIPFA.SelectedDate = Today
            Me.CPFechVigenciaIPFA.SelectedDate = Today
        End If

        If mEntidadNotasAceptacion.SSRECEPCION.Year > 1900 And mEntidadNotasAceptacion.SSVIGENCIA.Year > 1900 Then
            Me.CPFechaRecepcionISSS1.SelectedDate = mEntidadNotasAceptacion.SSRECEPCION
            Me.CPFechaVigenciaISSS1.SelectedDate = mEntidadNotasAceptacion.SSVIGENCIA
            Me.CheckBox5.Checked = True
            Me.CheckBox5.Enabled = False
            Me.CPFechaRecepcionISSS1.Enabled = False
            Me.CPFechaVigenciaISSS1.Enabled = False

        Else
            Me.CheckBox5.Checked = False
            Me.CheckBox5.Enabled = True
            Me.CPFechaRecepcionISSS1.Enabled = True
            Me.CPFechaVigenciaISSS1.Enabled = True
            Me.CPFechaRecepcionISSS1.SelectedDate = Today
            Me.CPFechaVigenciaISSS1.SelectedDate = Today
        End If

        If mEntidadNotasAceptacion.ISSSRECEPCION.Year > 1900 And mEntidadNotasAceptacion.ISSSVIGENCIA.Year > 1900 Then
            Me.CPFechaRecepcionISSS2.SelectedDate = mEntidadNotasAceptacion.ISSSRECEPCION
            Me.CPFechaVigenciaISSS2.SelectedDate = mEntidadNotasAceptacion.ISSSVIGENCIA
            Me.CheckBox6.Checked = True
            Me.CheckBox6.Enabled = False
            Me.CPFechaRecepcionISSS2.Enabled = False
            Me.CPFechaVigenciaISSS2.Enabled = False
        Else
            Me.CheckBox6.Checked = False
            Me.CheckBox6.Enabled = True
            Me.CPFechaRecepcionISSS2.Enabled = True
            Me.CPFechaVigenciaISSS2.Enabled = True
            Me.CPFechaRecepcionISSS2.SelectedDate = Today
            Me.CPFechaVigenciaISSS2.SelectedDate = Today
        End If

        If mEntidadNotasAceptacion.IMPUESTOSRECEPCION.Year > 1900 And mEntidadNotasAceptacion.IMPUESTOSVIGENCIA.Year > 1900 Then
            Me.CPFechaRecepcionIva.SelectedDate = mEntidadNotasAceptacion.IMPUESTOSRECEPCION
            Me.CPFechaVigenciaIVA.SelectedDate = mEntidadNotasAceptacion.IMPUESTOSVIGENCIA
            Me.CheckBox7.Checked = True
            Me.CheckBox7.Enabled = False
            Me.CPFechaRecepcionIva.Enabled = False
            Me.CPFechaVigenciaIVA.Enabled = False
        Else
            Me.CheckBox7.Checked = False
            Me.CheckBox7.Enabled = True
            Me.CPFechaRecepcionIva.Enabled = True
            Me.CPFechaVigenciaIVA.Enabled = True
            Me.CPFechaRecepcionIva.SelectedDate = Today
            Me.CPFechaVigenciaIVA.SelectedDate = Today
        End If

        If mEntidadNotasAceptacion.ALCALDIARECEPCION.Year > 1900 And mEntidadNotasAceptacion.ALCALDIAVIGENCIA.Year > 1900 Then
            Me.CPFechaRecepcionAlcaldia.SelectedDate = mEntidadNotasAceptacion.ALCALDIARECEPCION
            Me.CPFechaVigenciaAlcaldia.SelectedDate = mEntidadNotasAceptacion.ALCALDIAVIGENCIA
            Me.CheckBox8.Checked = True
            Me.CheckBox8.Enabled = False
            Me.CPFechaRecepcionAlcaldia.Enabled = False
            Me.CPFechaVigenciaAlcaldia.Enabled = False
        Else
            Me.CheckBox8.Checked = False
            Me.CheckBox8.Enabled = True
            Me.CPFechaRecepcionAlcaldia.Enabled = True
            Me.CPFechaVigenciaAlcaldia.Enabled = True
            Me.CPFechaRecepcionAlcaldia.SelectedDate = Today
            Me.CPFechaVigenciaAlcaldia.SelectedDate = Today
        End If

    End Sub

    Private Sub Actualizar()

        Dim bandera As Integer
        mEntidadNotasAceptacion.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadNotasAceptacion.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadNotasAceptacion.IDPROVEEDOR = Me.ddlProvedoresAdjudicados.SelectedValue

        bandera = mComponenteNotasAceptacion.ObtenerNOTASACEPTACION(mEntidadNotasAceptacion) '1 actualizar, 0 agregar

        If Me.CPFechaRecepcion.SelectedDate <= Today And Me.CheckBox1.Checked Then
            mEntidadNotasAceptacion.FECHARECEPCION = Me.CPFechaRecepcion.SelectedDate
        ElseIf Me.CPFechaRecepcion.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.txtPersonaFirma.Text.Length > 0 Then
            mEntidadNotasAceptacion.NOMBREPERSONAFIRMA = Me.txtPersonaFirma.Text
        Else
            Exit Sub
        End If

        If Me.NBDui.Text.Length = 9 Then
            mEntidadNotasAceptacion.DUIPERSONAFIRMA = Me.NBDui.Text
        Else
            Exit Sub
        End If

        If Me.CPFechaRecepcionConfia.SelectedDate <= Today And Me.CheckBox2.Checked Then
            mEntidadNotasAceptacion.AFPCONFIARECEPCION = Me.CPFechaRecepcionConfia.SelectedDate
        ElseIf Me.CPFechaRecepcionConfia.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaVigenciaConfia.SelectedDate >= Me.CPFechaRecepcionConfia.SelectedDate And Me.CheckBox2.Checked Then
            mEntidadNotasAceptacion.AFPCONFIAVIGENCIA = Me.CPFechaVigenciaConfia.SelectedDate
        ElseIf Me.CPFechaRecepcionConfia.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaRecepcionCrecer.SelectedDate <= Today And Me.CheckBox3.Checked Then
            mEntidadNotasAceptacion.AFPCRECERRECEPCION = Me.CPFechaRecepcionCrecer.SelectedDate
        ElseIf Me.CPFechaRecepcionCrecer.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaVigenciaCrecer.SelectedDate >= Me.CPFechaRecepcionCrecer.SelectedDate And Me.CheckBox3.Checked Then
            mEntidadNotasAceptacion.AFPCRECERVIGENCIA = Me.CPFechaVigenciaCrecer.SelectedDate
        ElseIf Me.CPFechaVigenciaCrecer.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaRecepcionIPFA.SelectedDate <= Today And Me.CheckBox4.Checked Then
            mEntidadNotasAceptacion.IPFARECEPCION = Me.CPFechaRecepcionIPFA.SelectedDate
        ElseIf Me.CPFechaRecepcionIPFA.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechVigenciaIPFA.SelectedDate >= Me.CPFechaRecepcionIPFA.SelectedDate And Me.CheckBox4.Checked Then
            mEntidadNotasAceptacion.IPFAVIGENCIA = Me.CPFechVigenciaIPFA.SelectedDate
        ElseIf Me.CPFechVigenciaIPFA.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaRecepcionISSS1.SelectedDate <= Today And Me.CheckBox5.Checked Then
            mEntidadNotasAceptacion.SSRECEPCION = Me.CPFechaRecepcionISSS1.SelectedDate
        ElseIf Me.CPFechaRecepcionISSS1.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaVigenciaISSS1.SelectedDate >= Me.CPFechaRecepcionISSS1.SelectedDate And Me.CheckBox5.Checked Then
            mEntidadNotasAceptacion.SSVIGENCIA = Me.CPFechaVigenciaISSS1.SelectedDate
        ElseIf Me.CPFechaVigenciaISSS1.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaRecepcionISSS2.SelectedDate <= Today And Me.CheckBox6.Checked Then
            mEntidadNotasAceptacion.ISSSRECEPCION = Me.CPFechaRecepcionISSS2.SelectedDate
        ElseIf Me.CPFechaRecepcionISSS2.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaVigenciaISSS2.SelectedDate >= Me.CPFechaRecepcionISSS2.SelectedDate And Me.CheckBox6.Checked Then
            mEntidadNotasAceptacion.ISSSVIGENCIA = Me.CPFechaVigenciaISSS2.SelectedDate
        ElseIf Me.CPFechaVigenciaISSS2.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaRecepcionIva.SelectedDate <= Today And Me.CheckBox7.Checked Then
            mEntidadNotasAceptacion.IMPUESTOSRECEPCION = Me.CPFechaRecepcionIva.SelectedDate
        ElseIf Me.CPFechaRecepcionIva.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaVigenciaIVA.SelectedDate >= Me.CPFechaRecepcionIva.SelectedDate And Me.CheckBox7.Checked Then
            mEntidadNotasAceptacion.IMPUESTOSVIGENCIA = Me.CPFechaVigenciaIVA.SelectedDate
        ElseIf Me.CPFechaVigenciaIVA.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaRecepcionAlcaldia.SelectedDate <= Today And Me.CheckBox8.Checked Then
            mEntidadNotasAceptacion.ALCALDIARECEPCION = Me.CPFechaRecepcionAlcaldia.SelectedDate
        ElseIf Me.CPFechaRecepcionAlcaldia.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CPFechaVigenciaAlcaldia.SelectedDate >= Me.CPFechaRecepcionAlcaldia.SelectedDate And Me.CheckBox8.Checked Then
            mEntidadNotasAceptacion.ALCALDIAVIGENCIA = Me.CPFechaVigenciaAlcaldia.SelectedDate
        ElseIf Me.CPFechaVigenciaAlcaldia.SelectedDate > Today Then
            Exit Sub
        End If

        If Me.CheckBox1.Checked Then
            mEntidadNotasAceptacion.PRESENTANOTA = 1
        Else
            mEntidadNotasAceptacion.PRESENTANOTA = 0
        End If

        If bandera = 1 Then
            mComponenteNotasAceptacion.ActualizarNOTASACEPTACION(mEntidadNotasAceptacion)
        Else
            mComponenteNotasAceptacion.AgregarNOTASACEPTACION(mEntidadNotasAceptacion)
        End If

        CargarNotasProveedor(Me.ddlProvedoresAdjudicados.SelectedValue)

        Me.MsgBox1.ShowAlert("Datos actualizados satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Page.IsValid Then
            If Me.CheckBox1.Checked Then
                Actualizar()
            Else
                Me.MsgBox1.ShowAlert("No se puede guardar si no se presenta la nota de acepación", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        End If
    End Sub

    Protected Sub ddlProvedoresAdjudicados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProvedoresAdjudicados.SelectedIndexChanged
        mEntidadNotasAceptacion.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadNotasAceptacion.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        CargarNotasProveedor(Me.ddlProvedoresAdjudicados.SelectedValue)
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked Then
            Me.CPFechaRecepcion.Enabled = True
        Else
            Me.CPFechaRecepcion.Enabled = False
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
