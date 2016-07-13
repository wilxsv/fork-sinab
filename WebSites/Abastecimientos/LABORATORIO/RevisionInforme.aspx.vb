Imports System.Linq
Imports CrystalDecisions.Shared
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports SINAB_Entidades.Tipos

Partial Class RevisionInforme
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
    Public Property Grupo() As Integer
        Get
            Return CType(ViewState("grp"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("grp") = value
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
   
   

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Private Function CargarConteoNotificaciones() As Integer
        Dim nunot = Notificaciones.ObtenerCountNotificacion(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, EnumHelpers.EstadoNotificacion.Distribucion)

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
    Private Sub CargarInspectores(ByVal ddl As DropDownList)

        Dim usr = Membresia.ObtenerUsuario()
        CatalogoHelpers.Empleados.CargarInspectoresALista(ddl, usr.Establecimiento.IDESTABLECIMIENTO)
        'Me.ddlInspectores.RecuperarEmpleadosPorDependenciaInspector(usr.Establecimiento.IDESTABLECIMIENTO)


        ddl.Items.Insert(0, New ListItem("Seleccione un inspector...", "0"))
        ddl.SelectedIndex = 0
        ltNotificacion.Text = CargarConteoNotificaciones().ToString()
    End Sub

    Protected Sub RecargarEncabezado(ByVal sender As Object, ByVal e As EventArgs) Handles ctrlLabRechazo.EstadoActualizado
        
        Me.gvEncabezado.DataSource = ContratosAdjudicados.ObtenerTodos(4, "")
        Me.gvEncabezado.DataBind()
        pnlAsignacion.Visible = False
        MessageBox.Alert("La notificación ha sido rechazada", "Rechazada")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.gvEncabezado.DataSource = ContratosAdjudicados.ObtenerTodos(EnumHelpers.EstadoNotificacion.Distribucion, "")
            Me.gvEncabezado.DataBind()
        End If
    End Sub

    Protected Sub gvEncabezado_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvEncabezado.RowCommand

        Try
            Dim index As Integer = CType(e.CommandArgument, Integer)
            Me.gvEncabezado.SelectedIndex = index
            Me.gvAsignacion.SelectedIndex = -1
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
        Catch ex As Exception
        End Try
    End Sub

    Public Sub eventoGvEncabezado(ByVal src As Object, ByVal e As GridViewCommandEventArgs)
        Dim obj = Notificaciones.Obtener(IdInforme, IdEstablecimiento)
        Select Case e.CommandName
            Case Is = "Editar"
                Try
                    Editar(obj)
                Catch ex As Exception
                    MessageBox.Alert("Ocurrió un error al mostrar la asignación. Error: " + ex.Message + " Intentelo nuevamente o pongase en contácto con soporte técnico.", "Error")
                End Try
                'Case Is = "Deshacer"
                '    "/laboratorio/FrmObservacionRechazo.aspx?idI=" & IdInforme & "&idE=" & IdEstablecimiento & "&OA=" & Me.lblObservacion.Text & "', 'popup' ,'scrollbars= 0 ,resizable= 0 ,width= 600 ,height= 215 ');</script>")
           
                '"/Reportes/FrmRptVerInformeMuestras.aspx?idI=" & IdInforme & "&idE=" & IdEstablecimiento & "&idT=0', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")
        End Select
    End Sub

    Private Sub EvaluarInspectores(ByVal obj As SAB_LAB_INFORMEMUESTRAS)
        CargarInspectores(ddlEMPLEADOS1)
        Dim ds = Notificaciones.ObtenerTodos(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, 4)
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

        Me.txtNUMEROINFORME.Text = If(obj.NUMEROINFORME, "")
        Me.nbCANTIDADFISICOQUIMICO.Text = CType(If(obj.CANTIDADFISICOQUIMICO, 0), String)
        Me.nbCANTIDADMICROBIOLOGIA.Text = CType(If(obj.CANTIDADMICROBIOLOGIA, 0), String)
        Me.nbCANTIDADRETENCION.Text = CType(If(obj.CANTIDADRETENCION, 0), String)
       
    End Sub

    Private Sub Editar(ByVal obj As SAB_LAB_INFORMEMUESTRAS)
        pnlAsignacion.Visible = True
      
        pnlRevision.Visible = False
        EvaluarInspectores(obj)
    End Sub

    Private Sub EditarEvaluacion()
        Dim im = Notificaciones.Obtener(IdInforme, IdEstablecimiento)
        If IsNothing(im.FECHASOLICITUDINSPECCION) Or (Not im.FECHASOLICITUDINSPECCION.HasValue()) Then
            lblFechaRegistro.Text = "--"
        Else
            lblFechaRegistro.Text = im.FECHASOLICITUDINSPECCION.Value.ToShortDateString()
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

        lblNombreMedicamentoInspeccion.Text = im.NOMBREINSPECCION

        Me.lblNombreComercial.Text = im.NOMBRECOMERCIAL

        Me.lblLabFab.Text = im.LABORATORIOFABRICANTE

        Me.lblSuministrante.Text = im.PROVEEDOR

        Me.lblLote.Text = im.LOTE

        If Not IsNothing(im.FECHAFABRICACION) Then
            Me.lblFechaFab.Text = CType(im.FECHAFABRICACION, String)
        Else
            Me.lblFechaFab.Text = "--"
        End If

        If Not IsNothing(im.FECHAVENCIMIENTO) Then
            Me.lblFechaVence.Text = CType(im.FECHAVENCIMIENTO, String)
        Else
            Me.lblFechaVence.Text = "--"
        End If

        Me.lblNoUnidades.Text = CType(If(im.CANTIDADAENTREGAR, 0), String)

         Me.lblCantRemitida.Text = CType(im.CANTIDADREMITIDA, String)
       ltCantidadRemitida.Text = lblCantRemitida.Text

        Dim prd = Productos.Obtener(CType(im.IDPRODUCTO, Integer))

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

        Me.lblComprobanteCredito.Text = im.COMPROBANTECREDITOFISCAL

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

        Me.lblCondicionesRecomendadas.Text = im.CONDICIONESALMACENAMIENTORECOMENDADAS

        Me.lblCondicionesEncontradas.Text = im.DESCRIPCIONCONDICIONESALMACENAMIENTO

        Me.lblDescProducto.Text = im.DESCRIPCIONPRODUCTO

        If im.IDINFORME = 1 Then
            lbltipoinforme.Text = "Aceptado"
        Else
            lbltipoinforme.Text = "Rechazado"
        End If

        lblObservaciones.Text = im.OBSERVACION


        ' Me.TextBox15.Text = IIf(IsDBNull(im.OBSERVACIONCOORDINADOR), "", im.OBSERVACIONCOORDINADOR)

        Me.pnlRevision.Visible = True
    End Sub

    Protected Sub gvAsignacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAsignacion.RowCommand
        Dim index = CType(e.CommandArgument, Integer)
        Me.gvAsignacion.SelectRow(index)
        IdInforme = CType(Me.gvAsignacion.DataKeys(index).Values(0), Integer)
        
    End Sub

    Public Sub EventoGvAsignacion(ByVal src As Object, ByVal e As GridViewCommandEventArgs)
        Select Case e.CommandName
            Case Is = "Editar"
                Try
                    EditarEvaluacion()
                Catch ex As Exception
                    MessageBox.Alert("Ocurrió un error al presentar la revisión. Error: " + ex.Message + " Intentelo nuevamente o pongase en contácto con soporte técnico.", "Error")
                End Try
                 Case Is = "Reporte"
                Utils.MostrarVentana(String.Format("~/Reportes/FrmRptVerInformeMuestras.aspx?idI={0}&idE={1}&idT=0", IdInforme, IdEstablecimiento))
            Case Is = "Rechazar"
                With ctrlLabRechazo
                    .IdEstablecimiento = IdEstablecimiento
                    .IdInforme = IdInforme
                    .Aestado = EnumHelpers.EstadoNotificacion.Revision 'estado al que va a ser asignado (actual -1)
                    .CargarDatos()
                End With
            Case Is = "Cerrar"
                Try
                    Notificaciones.Actualizar(IdInforme, IdEstablecimiento, EnumHelpers.EstadoNotificacion.Certificacion)
                    try
                         Me.gvEncabezado.DataSource = ContratosAdjudicados.ObtenerTodos(EnumHelpers.EstadoNotificacion.Distribucion, "")
                Me.gvEncabezado.DataBind()
                pnlAsignacion.Visible = False
                    Catch ex As Exception
                        Throw New Exception("La notificación ha sido cerrada con exito pero no se ha podido refrescar el resultado, pruebe recargar la página nuevamente. Error: "+ex.Message)
                    End Try
               
                Catch ex As Exception
                    MessageBox.Alert("La notificación no ha sido cerrada. Error: "+ex.Message)
                End Try
                
        End Select
    End Sub

    'Boton Guardar Información Coordinador de inspeccion
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        'Dim IM As New ABASTECIMIENTOS.ENTIDADES.INFORMEMUESTRAS

        If Notificaciones.ExisteNumeroInforme(IdInforme, IdEstablecimiento, txtNUMEROINFORME.Text) Then
            MessageBox.Alert("El número de informe ya existe.  Por favor verifíquelo.")
            Exit Sub
        End If
        Dim suma = CDec(nbCANTIDADFISICOQUIMICO.Text) + CDec(nbCANTIDADMICROBIOLOGIA.Text) + CDec(nbCANTIDADRETENCION.Text)
        If  suma > CDec(Me.lblCantRemitida.Text) Then
            'Me.MsgBox1.ShowAlert("La suma de las cantidades distribuidas no puede superar el total remitido.", "cc", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            MessageBox.Alert(String.Format("La suma de las cantidades distribuidas no puede superar el total remitido.<br/> Sumatoria: {0}, Cantidad Remitida: {1}",suma,ltCantidadRemitida.Text))
            Exit Sub
        End If

        Try
            Using db As New SinabEntities()
                Dim im = Notificaciones.Obtener(db, IdInforme, IdEstablecimiento)
                With im
                    .NUMEROINFORME = Me.txtNUMEROINFORME.Text
                    .CANTIDADFISICOQUIMICO = CType(Me.nbCANTIDADFISICOQUIMICO.Text, Decimal?)
                    .CANTIDADMICROBIOLOGIA = CType(Me.nbCANTIDADMICROBIOLOGIA.Text, Decimal?)
                    .CANTIDADRETENCION = CType(Me.nbCANTIDADRETENCION.Text, Decimal?)
                    .IDCOORDINADOR = Membresia.ObtenerUsuario().IDEMPLEADO
                    'IM.OBSERVACIONCOORDINADOR = Me.TextBox15.Text
                    .AUUSUARIOMODIFICACION = User.Identity.Name
                    .AUFECHAMODIFICACION = DateTime.Now
                End With
                db.SaveChanges()
            End Using

            Me.gvAsignacion.SelectedIndex = -1
           
            pnlRevision.Visible = False
            'Me.MsgBox1.ShowAlert("El información se ha guardado satisfactoriamente", "o", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            MessageBox.Alert("El información se ha guardado satisfactoriamente")
        Catch ex As Exception
            MessageBox.Alert("Error al agregar información adicional. Inténtelo nuevamente o póngase en contacto con soporte técnico. Error: " +ex.Message)
        End Try

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        pnlRevision.Visible = False
        Me.pnlAsignacion.Visible = False
        pnlAsignacion.Visible = False
        Me.gvAsignacion.SelectedIndex = -1
    End Sub

End Class
