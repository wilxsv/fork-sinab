Imports System.Linq
Imports System.ServiceModel.Channels
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SINAB_Entidades
Imports SINAB_Utils
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports SINAB_Entidades.Tipos

Partial Class CertificacionInforme
    Inherits System.Web.UI.Page


    Public Property IdProcesoCompra() As Integer
        Get
            Return CType(ViewState("IdProcesoCompra"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IdProcesoCompra") = value
        End Set
    End Property
    Public Property IdEstablecimiento() As Integer
        Get
            Return CType(ViewState("IDESTABLECIMIENTO"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IDESTABLECIMIENTO") = value
        End Set
    End Property
    Public Property IdProveedor() As Integer
        Get
            Return CType(ViewState("IDPROVEEDOR"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IDPROVEEDOR") = value
        End Set
    End Property
    Public Property IdContrato() As Integer
        Get
            Return CType(ViewState("IDCONTRATO"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IDCONTRATO") = value
        End Set
    End Property
    Public Property IdInforme() As Integer
        Get
            Return CType(ViewState("iinf"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("iinf") = value
        End Set
    End Property
    Public Property Grupo() As Integer
        Get
            Return CType(ViewState("grp"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("grp") = value
        End Set
    End Property
    'Public Property RENGLON() As Integer
    '    Get
    '        Return _RENGLON
    '    End Get
    '    Set(ByVal value As Integer)
    '        _RENGLON = value
    '        If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
    '        Me.ViewState.Add("RENGLON", value)
    '    End Set
    'End Property
    'Public Property IDPRODUCTO() As Integer
    '    Get
    '        Return _IDPRODUCTO
    '    End Get
    '    Set(ByVal value As Integer)
    '        _IDPRODUCTO = value
    '        If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
    '        Me.ViewState.Add("IDPRODUCTO", value)
    '    End Set
    'End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CargarEncabezado()

        End If
    End Sub

    Private Sub CargarEncabezado()

        Try
            Me.gvEncabezado.DataSource = ContratosAdjudicados.ObtenerTodos(EnumHelpers.EstadoNotificacion.Certificacion, "")
            Me.gvEncabezado.DataBind()
        Catch ex As Exception
            MessageBox.Alert(ex.Message)
        End Try
    End Sub

    Public Sub EventoGvEncabezado(ByVal src As Object, ByVal e As GridViewCommandEventArgs) Handles gvEncabezado.RowCommand

        Try
            Dim index As Integer = CType(e.CommandArgument, Integer)
            Me.gvEncabezado.SelectedIndex = index

            Dim selectedRow As GridViewRow = gvEncabezado.Rows(index)
            IdEstablecimiento = CType(Me.gvEncabezado.DataKeys(index).Values(0), Integer)
            IdProcesoCompra = CType(Me.gvEncabezado.DataKeys(index).Values(1), Integer)
            IdProveedor = CType(Me.gvEncabezado.DataKeys(index).Values(2), Integer)
            IdContrato = CType(Me.gvEncabezado.DataKeys(index).Values(3), Integer)
            IdInforme = CType(Me.gvEncabezado.DataKeys(index).Values(4), Integer)
            Grupo = CType(gvEncabezado.DataKeys(index).Values(5), Integer)

            Me.lblFechaNotificacion.Text = Server.HtmlDecode(selectedRow.Cells(1).Text)
            Me.lblProveedor.Text = Server.HtmlDecode(selectedRow.Cells(2).Text)
            Me.lblPC.Text = Server.HtmlDecode(selectedRow.Cells(3).Text)
            Me.lblNoDoc.Text = Server.HtmlDecode(selectedRow.Cells(4).Text)

            Dim obj = Notificaciones.Obtener(IdInforme, IdEstablecimiento)
            Select Case e.CommandName
                Case Is = "Editar"
                    Editar(obj)


            End Select
        Catch ex As Exception
            MessageBox.Alert("Error al procesar seleccion, intentelo nuevamente. Error: " + ex.Message, "Error")
        End Try
    End Sub

    Private Sub Editar(ByVal im As SAB_LAB_INFORMEMUESTRAS)

        Me.pnlAsignacion.Visible = True

        EvaluarInspectores(im)
    End Sub

    Protected Sub gvAsignacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAsignacion.RowCommand
        Dim index As Integer = CType(e.CommandArgument, Integer)
        Me.gvAsignacion.SelectRow(index)
        IdInforme = CType(Me.gvAsignacion.DataKeys(index).Values(0), Integer)
    End Sub

    Public Sub EventoGvAsignacion(ByVal src As Object, ByVal e As GridViewCommandEventArgs)
        Select Case e.CommandName
            Case Is = "Editar"
                EditarEvaluacion()
            Case Is = "Reporte"
                Utils.MostrarVentana("/Reportes/FrmRptVerInformeMuestras.aspx?idI=" & IdInforme & "&idE=" & IdEstablecimiento)
            Case Is = "Certificado"
                Utils.MostrarVentana("/Reportes/FrmRptInformeControlCalidad.aspx?idI=" & IdInforme & "&idE=" & IdEstablecimiento & "&idT=1")
            Case Is = "Rechazar"
                With ctrlLabRechazo
                    .IdEstablecimiento = IdEstablecimiento
                    .IdInforme = IdInforme
                    .Aestado = EnumHelpers.EstadoNotificacion.Distribucion 'estado al que va a ser asignado (actual -1)
                    .CargarDatos()
                End With
            Case Is = "Cerrar"
                Dim correcto = false
                Try
                    Notificaciones.Actualizar(IdInforme, IdEstablecimiento, EnumHelpers.EstadoNotificacion.Cerrada)
                    correcto = true
                    MessageBox.Alert("La notificación ha sido cerrada", "Cerrada")
                Catch ex As Exception
                    correcto = False
                    MessageBox.Alert("La notificación no ha sido cerrada. Error: "+ ex.Message)
                End Try
                
                If correcto
                    Try
                        CargarEncabezado()
                pnlAsignacion.Visible = False
                    Catch ex As Exception
                        MessageBox.Alert(ex.Message)
                    End Try
                End If
                
        End Select
    End Sub

    Private Sub EditarEvaluacion()
        Dim im = Notificaciones.Obtener(IdInforme, IdEstablecimiento)
        If IsNothing(im.FECHASOLICITUDINSPECCION) Or (Not im.FECHASOLICITUDINSPECCION.HasValue()) Then
            lblFechaInforme.Text = "--"
        Else
            lblFechaInforme.Text = im.FECHASOLICITUDINSPECCION.Value.ToShortDateString()
        End If

        If im.ORIGENPRODUCTO = 0 Then
            lblOrigen.Text = "Nacional"
        Else
            lblOrigen.Text = "Extranjero"
        End If

        Select Case im.TIPOPRODUCTO
            Case 0
                lblTipoMedicamento.Text = "Medicamentos"
            Case 1
                lblTipoMedicamento.Text = "Vacunas"
            Case 2
                lblTipoMedicamento.Text = "Insumos Médicos"
        End Select

        Me.lblNombreMedicamento.Text = im.NOMBREMEDICAMENTO

        Me.lblNombreComercial.Text = im.NOMBRECOMERCIAL

        Me.lblLaboratorioFabricante.Text = im.LABORATORIOFABRICANTE

        Me.lblSuministrante.Text = im.PROVEEDOR

        Me.lblLote.Text = im.LOTE

        If Not IsNothing(im.FECHAFABRICACION) Then
            Me.lblFechaFabricacion.Text = CType(im.FECHAFABRICACION, String)
        Else
            Me.lblFechaFabricacion.Text = "--"
        End If

        If Not IsNothing(im.FECHAVENCIMIENTO) Then
            Me.lblFechaVencimiento.Text = CType(im.FECHAVENCIMIENTO, String)
        Else
            Me.lblFechaVencimiento.Text = "--"
        End If

        Me.lblCantEntregar.Text = CType(If(im.CANTIDADAENTREGAR, 0), String)

        Dim prd = Productos.Obtener(CType(im.IDPRODUCTO, Integer))

        Me.lblCantidadRemitida.Text = CType(im.CANTIDADREMITIDA, String)

        Me.txtUM4.Text = prd.UnidadMedida
        Me.txtUM5.Text = prd.UnidadMedida
        Me.txtUM6.Text = prd.UnidadMedida

        Me.lblRenglonInfo.Text = im.RENGLON & " - " & prd.DescLargo 'im.IDPRODUCTO 'nombre medicamento

        Try
            Dim ptmp = New SAB_UACI_PRODUCTOSCONTRATO With {
           .IDESTABLECIMIENTO = IdEstablecimiento,
           .IDPROVEEDOR = CType(im.IDPROVEEDOR, Integer),
           .IDCONTRATO = CType(im.IDCONTRATO, Long),
           .RENGLON = im.RENGLON}
            lblCantidadContratada.Text = ProductosContrato.Obtener(ptmp).CANTIDAD.ToString()
        Catch ex As Exception
            lblCantidadContratada.Text = "0"
        End Try

        Me.lblLugarInspeccion.Text = im.LUGARINSPECCION

        Me.lblGuia.Text = im.GUIAAEREA

        Me.lblCreditoFiscal.Text = im.COMPROBANTECREDITOFISCAL

        Me.lblDescripcionEmpaque.Text = im.DESCRIPCIONEMPAQUE

        ctlLeyenda.SelectedValue = CType(If(im.LEYENDAREQUERIDA, 0), Integer)
        ctlLeyenda.Text = CType(IIf(IsDBNull(im.OBSERVACIONLEYENDA), "", im.OBSERVACIONLEYENDA), String)

        ctlNumReg.SelectedValue = CType(If(im.NUMEROREGISTRO, 0), Integer)
        ctlNumReg.Text = CType(IIf(IsDBNull(im.OBSERVACIONNREGISTRO), "", im.OBSERVACIONNREGISTRO), String)

        ctlViaAdministracion.SelectedValue = CType(If(im.VIAADMINISTRACION, 0), Integer)
        ctlViaAdministracion.Text = CType(IIf(IsDBNull(im.OBSERVACIONVIAADMON), "", im.OBSERVACIONVIAADMON), String)

        ctlFormaDilucion.SelectedValue = CType(If(im.FORMADISOLUCION, 0), Integer)
        ctlFormaDilucion.Text = CType(IIf(IsDBNull(im.descripciondisolucion), "", im.descripciondisolucion), String)

        ctlCondAlm.SelectedValue = CType(If(im.CONDICIONESALMACENAMIENTO, 0), Integer)
        ctlCondAlm.Text = CType(IIf(IsDBNull(im.OBSERVACIONCONDIALMA), "", im.OBSERVACIONCONDIALMA), String)

        ctlNoLote.SelectedValue = im.NUMEROLOTE
        ctlNoLote.Text = CType(IIf(IsDBNull(im.OBSERVACIONNLOTE), "", im.OBSERVACIONNLOTE), String)

        ctlFechaExp.SelectedValue = CType(If(im.FECHAEXPIRACION, 0), Integer)
        ctlFechaExp.Text = CType(IIf(IsDBNull(im.OBSERVACIONFECHAEXP), "", im.OBSERVACIONFECHAEXP), String)


        Me.lblAlmRecomendadas.Text = im.CONDICIONESALMACENAMIENTORECOMENDADAS

        Me.lblAlmEncontradas.Text = im.DESCRIPCIONCONDICIONESALMACENAMIENTO

        Me.lblDescProducto.Text = im.DESCRIPCIONPRODUCTO

        Me.lblObservacionces2.Text = im.OBSERVACIONCOORDINADOR

        Me.lblNumInforme.Text = im.NUMEROINFORME

        Me.lblFQ.Text = CType(im.CANTIDADFISICOQUIMICO, String)

        Me.lblMi.Text = CType(im.CANTIDADMICROBIOLOGIA, String)

        Me.lblRet.Text = CType(im.CANTIDADRETENCION, String)

        PnlRevision.Visible = True
        rbCriterio.SelectedValue = CType(im.IDTIPOINFORME, String)
        rbResultado.SelectedValue = CType(CType(If(im.RESULTADOINSPECCION, 2), Integer), String)
        tbObservacionCertificacion.Text = im.OBSERVACIONCERTIFICACION

        If Not IsNothing(im.FECHACERTIFICACION) Then
            Me.tbFechaCertificacion.Text = CType(im.FECHACERTIFICACION, String)
        Else
            Me.tbFechaCertificacion.Text = ""
        End If
    End Sub

    Protected Sub RecargarEncabezado(ByVal sender As Object, ByVal e As EventArgs) Handles ctrlLabRechazo.EstadoActualizado
        Me.gvEncabezado.DataSource = ContratosAdjudicados.ObtenerTodos(5, "")
        Me.gvEncabezado.DataBind()
        pnlAsignacion.Visible = False
        MessageBox.Alert("La notificación ha sido rechazada", "Rechazada")
    End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
    '    Dim cim As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
    '    If e.Key = "p" Then
    '        cim.ActualizarEstadoInforme(Session("IdEstablecimiento"), IDINFORME, User.Identity.Name, Now, 4)

    '        Me.gvEncabezado.DataSource = cim.ObtenerNotificacionesCapturadasCoordinador(5, -1)
    '        Me.gvEncabezado.DataBind()

    '    End If
    '    If e.Key = "y" Then
    '        cim.ActualizarEstadoInforme(Session("IdEstablecimiento"), IDINFORME, User.Identity.Name, Now, 6)

    '        Me.gvEncabezado.DataSource = cim.ObtenerNotificacionesCapturadasCoordinador(5, -1)
    '        Me.gvEncabezado.DataBind()
    '    End If
    'End Sub



    Private Sub EvaluarInspectores(obj As SAB_LAB_INFORMEMUESTRAS)
        CargarInspectores(ddlEMPLEADOS1)
        Dim ds = Notificaciones.ObtenerTodos(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, EnumHelpers.EstadoNotificacion.Certificacion)
        If obj.IDINSPECTOR > 0 Then
            Me.lblObservacion.Text = obj.OBSERVACIONASIGNACION
            If Not IsNothing(obj.FECHAASIGNACION) Then
                lblFechaAsignacion.Text = obj.FECHAASIGNACION.Value.ToShortDateString()
            Else
                lblFechaAsignacion.Text = ""
            End If


            'verifica si es el mismo inspector o no
            Dim esIgual As Boolean
            For Each r As BaseInformeMuestra In ds
                If r.IdInspector = obj.IDINSPECTOR Then
                    esIgual = True
                Else
                    esIgual = False
                End If
            Next

            Me.gvAsignacion.DataSource = ds
            Me.gvAsignacion.DataBind()

            If esIgual Then
                Me.ddlEMPLEADOS1.SelectedValue = CType(obj.IDINSPECTOR, String)
                Me.chbVarios.Checked = False
                Me.ddlEMPLEADOS1.Enabled = True
                Me.gvAsignacion.Columns(8).Visible = False
            Else
                Me.lblObservacion.Text = "--"
                Me.ddlEMPLEADOS1.Enabled = False
                Me.chbVarios.Checked = True
                Me.ddlEMPLEADOS1.SelectedIndex = -1
                Me.gvAsignacion.Columns(8).Visible = True
            End If

            For Each ddle In From row As GridViewRow In gvAsignacion.Rows Select CType(row.Cells(8).Controls(1), DropDownList)
                ddle.SelectedValue = CType(obj.IDINSPECTOR, String)
            Next

        Else
            lblFechaAsignacion.Text = DateTime.Now.ToShortDateString()
            Me.gvAsignacion.DataSource = ds
            Me.gvAsignacion.DataBind()
        End If

        chbVarios.Enabled = False
        ddlEMPLEADOS1.Enabled = False
    End Sub

    Private Sub CargarInspectores(ddl As DropDownList)
        Dim usr = Membresia.ObtenerUsuario()
        CatalogoHelpers.Empleados.CargarInspectoresALista(ddl, usr.Establecimiento.IDESTABLECIMIENTO)
        'Me.ddlInspectores.RecuperarEmpleadosPorDependenciaInspector(usr.Establecimiento.IDESTABLECIMIENTO)


        ddl.Items.Insert(0, New ListItem("Seleccione un inspector...", "0"))
        ddl.SelectedIndex = 0
        ltNotificacion.Text = CargarConteoNotificaciones().ToString()
    End Sub

    Private Function CargarConteoNotificaciones() As Object
        Dim nunot = Notificaciones.ObtenerCountNotificacion(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, 5)

        If nunot > 1 Then
            ltPreNotificacion.Text = " Notificaciones"
        Else
            If nunot = 0 Then
                ltPreNotificacion.Text = ": No hay notificaciones"

            Else
                ltPreNotificacion.Text = " Notificación"
            End If
        End If
        Return nunot
    End Function

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PnlRevision.Visible = False

        Me.gvAsignacion.SelectedIndex = -1
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Me.rbResultado.SelectedValue = -1 Then
            MessageBox.Alert("Debe seleccionar un resultado para este informe.", "Error")
            ' Me.MsgBox1.ShowAlert("Debe seleccionar un resultado para este informe.", "s", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Try
            Using db As New SinabEntities()
                Dim im = Notificaciones.Obtener(db, IdInforme, IdEstablecimiento)

                im.AUUSUARIOMODIFICACION = User.Identity.Name
                im.AUFECHAMODIFICACION = DateTime.Now
                im.RESULTADOINSPECCION = CType(Me.rbResultado.SelectedValue, Byte?)
                im.OBSERVACIONCERTIFICACION = Me.tbObservacionCertificacion.Text
                im.IDJEFELABORATORIO = Membresia.ObtenerUsuario().IDEMPLEADO
                im.FECHACERTIFICACION = CType(tbFechaCertificacion.Text, Date?)

                db.SaveChanges()
            End Using

            Me.PnlRevision.Visible = False
            Me.gvAsignacion.SelectedIndex = -1


            MessageBox.Alert("El información se ha guardado satisfactoriamente", "Guardado")

        Catch ex As Exception
            MessageBox.Alert("Error al agregar información adicional. Inténtelo nuevamente o póngase en contacto con soporte técnico. Error: " + ex.Message)
        End Try

    End Sub
End Class
