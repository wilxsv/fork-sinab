Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils.MessageBox

Partial Class FrmRegistrarRecursosRevision
    Inherits System.Web.UI.Page

    Private mComponenteProcesoCompra As New cPROCESOCOMPRAS
    Private mComponenteAdjudicacion As New cADJUDICACION
    Private mComponenteRecursosRevision As New cRECURSOSREVISION
    Private mEntidadProcesoCompra As PROCESOCOMPRAS
    Private mEntidadAdjudicacion As ADJUDICACION
    Friend mEntidadRecursosRevision As New RECURSOSREVISION

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.btnImprimirAdjudicatarios.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/frmRptProveedoresAdjudicados.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idPC=" + Request.QueryString("idProc"))
        ' "window.open('" + Request.ApplicationPath + "/Reportes/frmRptProveedoresAdjudicados.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idPC=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

        Me.btnImprimirRecursos.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/frmRptRecursosRevision.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idPC=" + Request.QueryString("idProc"))
        '"window.open('" + Request.ApplicationPath + "/Reportes/frmRptRecursosRevision.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idPC=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CargarDatos()

            Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
            Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidadProcesoCompra = New PROCESOCOMPRAS
        mEntidadProcesoCompra.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadProcesoCompra.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        If mComponenteProcesoCompra.ObtenerPROCESOCOMPRAS(mEntidadProcesoCompra) <> 1 Then
        End If

        Me.lblNoProcesoCompra.Text = mEntidadProcesoCompra.CODIGOLICITACION
        Me.FechaInicioProcCompra.Text = mEntidadProcesoCompra.FECHAINICIOPROCESOCOMPRA.ToShortDateString
        Me.FechaNotificacionEmpresas.Text = mEntidadProcesoCompra.FECHANOTIFICACION.ToShortDateString
        Me.FechaLimiteAceptacion.Text = mEntidadProcesoCompra.FECHALIMITEACEPTACION.ToShortDateString
        Me.rvFechaRecepcion.MinimumValue = Me.FechaNotificacionEmpresas.Text
        Me.rvFechaRecepcion.MaximumValue = Me.FechaLimiteAceptacion.Text
        Me.CPFechaRecepcion.LowerBoundDate = mEntidadProcesoCompra.FECHANOTIFICACION.ToShortDateString
        Me.CPFechaRecepcion.UpperBoundDate = Today.ToShortDateString

        Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcVistaDetalleSolicProcesCompra1.Consultar()

        mEntidadAdjudicacion = New ADJUDICACION
        mEntidadAdjudicacion.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadAdjudicacion.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        Dim cAP As New cANALISTAPROVEEDORES
        Me.ddlProvedores.DataSource = cAP.ObtenerProveedoresAsignados(mEntidadAdjudicacion.IDESTABLECIMIENTO, mEntidadAdjudicacion.IDPROCESOCOMPRA, Session("IdEmpleado"))

        Me.ddlProvedores.DataTextField = "NOMBRE"
        Me.ddlProvedores.DataValueField = "IDPROVEEDOR"
        Me.ddlProvedores.DataBind()

        mEntidadRecursosRevision.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadRecursosRevision.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ddlRenglon.DataSource = mComponenteRecursosRevision.obtenerRenglonesAdjudicados(Session("IdEstablecimiento"), Request.QueryString("idProc"))
        Me.ddlRenglon.DataValueField = "renglon"
        Me.ddlRenglon.DataTextField = "renglon"
        Me.ddlRenglon.DataBind()
        Me.btnGuardar.Visible = False
        Me.btnAgregar.Visible = False

        If Today > mEntidadProcesoCompra.FECHALIMITEACEPTACION Then
            lblMensaje.Text = "El período para registrar recursos de revisión terminado. Solo se permite consultar."
            txtDescripcion.Enabled = False
            If ddlProvedores.Items.Count = 0 Then
                lblMensaje.Text += ControlChars.NewLine + "No se le han asignado proveedores para el proceso de compra seleccionado."
            End If
        Else
            If ddlProvedores.Items.Count = 0 Then
                lblMensaje.Text = "No se le han asignado proveedores para el proceso de compra seleccionado."
            Else
                btnAgregar.Visible = True
            End If
        End If

        Me.GridView1.DataSource = mComponenteRecursosRevision.obtenerDatasetRecursos(mEntidadRecursosRevision.IDESTABLECIMIENTO, mEntidadRecursosRevision.IDPROCESOCOMPRA)
        Me.GridView1.DataBind()
        Me.GridView2.DataSource = mComponenteAdjudicacion.obtenerDatasetProveedoresAdjudicadosConNotas(mEntidadRecursosRevision.IDESTABLECIMIENTO, mEntidadRecursosRevision.IDPROCESOCOMPRA)
        Me.GridView2.DataBind()
        Me.Panel1.Visible = False

    End Sub

    Private Sub CargarRecurso(ByVal idRecurso As Integer, ByVal IdProveedor As Integer)
        mEntidadRecursosRevision.IDPROVEEDOR = IdProveedor ' Me.ddlProvedoresAdjudicados.SelectedValue
        mEntidadRecursosRevision.IDRECURSO = idRecurso ' Me.ddlProvedoresAdjudicados.SelectedValue
        mEntidadRecursosRevision.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadRecursosRevision.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mComponenteRecursosRevision.ObtenerRECURSOSREVISION(mEntidadRecursosRevision)
        mEntidadRecursosRevision.IDPROVEEDOR = IdProveedor
        Me.lblRecurso.Text = idRecurso
        Me.txtDescripcion.Text = mEntidadRecursosRevision.DESCRIPCION
        Me.lblFechaRecepcion.Text = mEntidadRecursosRevision.FECHAPRESENTACION
        If mEntidadRecursosRevision.ADMITIDO = 0 Then
            Me.RadioButtonList1.SelectedValue = 0
        Else
            Me.RadioButtonList1.SelectedValue = 1
        End If
        Me.txtjustificacion.Text = mEntidadRecursosRevision.JUSTIFICACION
        Me.ddlProvedores.SelectedValue = mEntidadRecursosRevision.IDPROVEEDOR
        Me.lblProveedor.Text = Me.ddlProvedores.SelectedItem.Text
        Me.ddlRenglon.SelectedValue = mEntidadRecursosRevision.ESTASINCRONIZADA
        Me.ddlRenglon.Enabled = False
        Me.Panel1.Visible = True
    End Sub

    Private Sub Actualizar()
        If Me.FechaLimiteAceptacion.Text >= Today Then
            If Me.Session("agregar") = 1 Then
                If Me.CPFechaRecepcion.SelectedDate > Today Then
                    Me.lblMensaje.Text = "La fecha de recepción no puede ser mayor a la fecha actual"
                    'MsgBox(Me.lblMensaje.Text, MsgBoxStyle.Information, "Sistema de Abastecimiento")
                    Exit Sub
                End If
                If Me.txtDescripcion.Text = "" Then
                    Me.lblMensaje.Text = "Debe llenar el campo descripción"
                    Exit Sub
                End If

                mEntidadRecursosRevision.IDPROCESOCOMPRA = Request.QueryString("idProc")
                mEntidadRecursosRevision.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                mEntidadRecursosRevision.IDPROVEEDOR = Me.ddlProvedores.SelectedValue
                mEntidadRecursosRevision.IDRECURSO = 0
                mEntidadRecursosRevision.FECHAPRESENTACION = Me.CPFechaRecepcion.SelectedDate
                mEntidadRecursosRevision.DESCRIPCION = Me.txtDescripcion.Text
                mEntidadRecursosRevision.ADMITIDO = Me.RadioButtonList1.SelectedValue
                mEntidadRecursosRevision.JUSTIFICACION = Me.txtjustificacion.Text
                mEntidadRecursosRevision.ESTASINCRONIZADA = Me.ddlRenglon.SelectedValue
                mComponenteRecursosRevision.ActualizarRECURSOSREVISION(mEntidadRecursosRevision)
                Me.GridView1.DataSource = mComponenteRecursosRevision.obtenerDatasetRecursos(mEntidadRecursosRevision.IDESTABLECIMIENTO, mEntidadRecursosRevision.IDPROCESOCOMPRA)
                Me.GridView1.DataBind()

                Me.btnAgregar.Visible = True
                Me.btnGuardar.Visible = False
                Me.btnCancelar.Visible = False
                Me.ddlProvedores.Visible = False
                Me.CPFechaRecepcion.Visible = False
                Me.lblProveedor.Visible = True
                Me.lblFechaRecepcion.Visible = True
                Me.Panel1.Visible = False
            ElseIf Me.Session("agregar") = 0 Then
                If Me.txtDescripcion.Text = "" Then
                    Me.lblMensaje.Text = "Debe llenar el campo descripción"
                    Exit Sub
                End If
                mEntidadRecursosRevision.IDPROCESOCOMPRA = Request.QueryString("idProc")
                mEntidadRecursosRevision.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                mEntidadRecursosRevision.IDPROVEEDOR = Me.ddlProvedores.SelectedValue
                mEntidadRecursosRevision.IDRECURSO = Me.lblRecurso.Text
                mEntidadRecursosRevision.FECHAPRESENTACION = Me.CPFechaRecepcion.SelectedDate
                mEntidadRecursosRevision.DESCRIPCION = Me.txtDescripcion.Text
                mEntidadRecursosRevision.ADMITIDO = Me.RadioButtonList1.SelectedValue
                mEntidadRecursosRevision.JUSTIFICACION = Me.txtjustificacion.Text
                mEntidadRecursosRevision.ESTASINCRONIZADA = Me.ddlRenglon.SelectedValue
                mComponenteRecursosRevision.ActualizarRECURSOSREVISION(mEntidadRecursosRevision)
                Me.GridView1.DataSource = mComponenteRecursosRevision.obtenerDatasetRecursos(mEntidadRecursosRevision.IDESTABLECIMIENTO, mEntidadRecursosRevision.IDPROCESOCOMPRA)
                Me.GridView1.DataBind()

                Me.btnAgregar.Visible = True
                Me.btnGuardar.Visible = False
                Me.btnCancelar.Visible = False
                Me.ddlProvedores.Visible = False
                Me.CPFechaRecepcion.Visible = False
                Me.lblProveedor.Visible = True
                Me.lblFechaRecepcion.Visible = True
                Me.Panel1.Visible = False
            Else

                Me.lblMensaje.Text = "Acción no permitida"
                Alert(Me.lblMensaje.Text, "Error")
                'Me.MsgBox1.ShowAlert(Me.lblMensaje.Text, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                'MsgBox(Me.lblMensaje.Text, MsgBoxStyle.Information, "Sistema de Abastecimiento")
            End If

        Else
            Me.lblMensaje.Text = "El período permitido para la adición y modificación de recursos ha concluído"
            Alert(Me.lblMensaje.Text, "Aviso")
            'Me.MsgBox1.ShowAlert(Me.lblMensaje.Text, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            'MsgBox(Me.lblMensaje.Text, MsgBoxStyle.Information, "Sistema de Abastecimiento")
        End If
    End Sub

    Private Sub LimpiarCampos()
        Me.lblRecurso.Text = 0
        Me.lblProveedor.Text = ""
        Me.lblMensaje.Text = ""
        Me.lblFechaRecepcion.Text = ""
        Me.txtDescripcion.Text = ""
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Try
            Me.ddlProvedores.SelectedValue = Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values.Item("IDPROVEEDOR").ToString
            Me.lblProveedor.Text = Me.ddlProvedores.SelectedItem.Text
            LimpiarCampos()
            CargarRecurso(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values.Item("IDRECURSO").ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values.Item("IDPROVEEDOR").ToString)
            Me.Session("agregar") = 0

            Me.btnAgregar.Visible = False
            If Me.FechaLimiteAceptacion.Text >= Today Then
                Me.btnGuardar.Visible = True
                Me.btnCancelar.Visible = True
            Else
                Me.btnGuardar.Visible = False
                Me.btnCancelar.Visible = False
            End If
            Me.ddlProvedores.Visible = False
            Me.CPFechaRecepcion.Visible = False
            Me.lblProveedor.Visible = True
            Me.lblFechaRecepcion.Visible = True
            Me.btnProveedoresAfectados.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptproveedoresAfectados.aspx?id=" + Request.QueryString("idProc") + "&renglon=" + Me.ddlRenglon.SelectedItem.Text)
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptproveedoresAfectados.aspx?id=" + Request.QueryString("idProc") + "&renglon=" + Me.ddlRenglon.SelectedItem.Text + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

        Catch ex As Exception
            'MsgBox("El recurso seleccionado pertenece a un proveedor que no le ha sido asignado.", MsgBoxStyle.Information, "")
            'Me.MsgBox1.ShowAlert("El recurso seleccionado pertenece a un proveedor que no le ha sido asignado.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("El recurso seleccionado pertenece a un proveedor que no le ha sido asignado.", "Error")
        End Try

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Me.Session("agregar") = 1
        Try
            Me.ddlRenglon.SelectedIndex = 0
            Me.ddlProvedores.SelectedIndex = 0
            Me.ddlRenglon.Enabled = True
            Me.Panel1.Visible = True
            Me.ddlProvedores.Visible = True
            Me.CPFechaRecepcion.SelectedDate = Today
            Me.CPFechaRecepcion.Visible = True
            Me.txtjustificacion.Text = ""
            Me.txtDescripcion.Text = ""
            Me.btnAgregar.Visible = False
            Me.btnGuardar.Visible = True
            Me.btnCancelar.Visible = True
            Me.ddlProvedores.Visible = True
            Me.CPFechaRecepcion.Visible = True
            Me.lblProveedor.Visible = False
            Me.lblFechaRecepcion.Visible = False

            Me.btnProveedoresAfectados.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptproveedoresAfectados.aspx?id=" + Request.QueryString("idProc") + "&renglon=" + Me.ddlRenglon.SelectedItem.Text)
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptproveedoresAfectados.aspx?id=" + Request.QueryString("idProc") + "&renglon=" + Me.ddlRenglon.SelectedItem.Text + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

        Catch ex As Exception
            Me.Panel1.Visible = True
            Me.ddlProvedores.Visible = True
            Me.ddlRenglon.Enabled = True
            Me.CPFechaRecepcion.SelectedDate = Today
            Me.CPFechaRecepcion.Visible = True
            Me.txtjustificacion.Text = ""
            Me.txtDescripcion.Text = ""
            Me.btnAgregar.Visible = False
            Me.btnGuardar.Visible = True
            Me.btnCancelar.Visible = True
            Me.ddlProvedores.Visible = True
            Me.CPFechaRecepcion.Visible = True
            Me.lblProveedor.Visible = False
            Me.lblFechaRecepcion.Visible = False

            Me.lblMensaje.Text = "No se han presentado ofertas para este proceso de compra"
            Alert(Me.lblMensaje.Text, "Aviso")
            'Me.MsgBox1.ShowAlert(Me.lblMensaje.Text, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Actualizar()
        Me.txtjustificacion.Text = ""
        Me.txtDescripcion.Text = ""
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.btnAgregar.Visible = True
        Me.btnGuardar.Visible = False
        Me.btnCancelar.Visible = False
        Me.lblRecurso.Text = 0
        Me.lblProveedor.Text = ""

        '   Me.lblMensaje.Text = "Acción cancelada"
        Me.lblFechaRecepcion.Text = ""
        Me.txtDescripcion.Text = ""
        Me.txtjustificacion.Text = ""
        Me.RadioButtonList1.SelectedValue = 0
        Me.ddlProvedores.Visible = False
        Me.CPFechaRecepcion.Visible = False
        Me.lblProveedor.Visible = True
        Me.lblFechaRecepcion.Visible = True
        Me.Panel1.Visible = False
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


End Class
