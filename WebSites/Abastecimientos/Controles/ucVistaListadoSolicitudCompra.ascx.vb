

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports Controles
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Utils.MessageBox
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades.Tipos
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports ProcesoCompras = SINAB_Entidades.Helpers.UACIHelpers.ProcesoCompras
Imports System.Transactions
Imports DetalleEntregasProcesoCompra = SINAB_Entidades.Helpers.UACIHelpers.DetalleEntregasProcesoCompra

Partial Class Controles_ucVistaListadoSolicitudCompra
    Inherits System.Web.UI.UserControl
    Dim strNoCumple As New Text.StringBuilder
    Dim IDESTABLECIMIENTO As Int64
    Friend Shared tem As Integer
    Friend Shared cantidadEntregas As Integer = 0

#Region " Propiedades "
    Public Property SolicitudesSeleccionadas As List(Of SAB_EST_SOLICITUDES)
        Get
            Return CType(ViewState("solSelected"), List(Of SAB_EST_SOLICITUDES))
        End Get
        Set(value As List(Of SAB_EST_SOLICITUDES))
            ViewState("solSelected") = value
            If value.Any() Then
                Dim corrs = value.Select(Function(ob) ob.CORRELATIVO).ToArray()
                ltSeleccionadas.Text = String.Join(", ", corrs)
            Else
                ltSeleccionadas.Text = ""
            End If
            
        End Set
    End Property

   
#End Region

    Public Sub consultar()
        If Not IsPostBack Then
            obtenerDatos()
        End If
    End Sub

    Private Sub obtenerDatos()
        Dim recs = EstablecimientoHelpers.Solicitudes.Licitaciones(IDESTABLECIMIENTO)

        gvSolicitudCompra.DataSource = recs
        gvSolicitudCompra.DataBind()
    End Sub

    'Protected Sub gvSolicitudCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvSolicitudCompra.PageIndexChanging
    '    gvSolicitudCompra.PageIndex = e.NewPageIndex
    '    obtenerDatos()
    'End Sub

    Protected Sub gvSolicitudCompra_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSolicitudCompra.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dato = CType(e.Row.DataItem, SAB_EST_SOLICITUDES)
            Dim ltFuentes As Literal = CType(e.Row.FindControl("ltFuentesFinanciamiento"), Literal)

            For Each fuente In dato.FuentesFinanciamiento
                ltFuentes.Text += String.Format("<li style='text-align:left'>{0}</li>", fuente)
            Next
        End If
    End Sub

    Private Sub consultarEmpleados()
        Me.UcListaEmpleado1.CargarDatos() '.ObtenerDatos()
    End Sub

    'Private Sub consultarEmpleadosAnalistaSuministros()
    '    Me.UcListaEmpleado1.ObtenerListaRecuperarEmpleadosPorDependenciaAnalistaSuministros()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.UcBarraNavegacion1.Navegacion = False
            Me.UcBarraNavegacion1.PermitirAgregar = False
            Me.UcBarraNavegacion1.PermitirConsultar = False
            Me.UcBarraNavegacion1.PermitirEditar = False
            Me.UcBarraNavegacion1.HabilitarEdicion(False)
            Me.UcBarraNavegacion1.PermitirGuardar = False
            Me.UcBarraNavegacion1.PermitirImprimir = False

            SolicitudesSeleccionadas = New List(Of SAB_EST_SOLICITUDES)()

            Me.pnlSeleccion.Visible = True
            Me.pnlIngreso.Visible = False
        End If

        If IsPostBack And pnlIngreso.Visible Then
            If ConfirmTarget = "Espere" Then ProcesarInicioCompra(ConfirmArgument)

        End If

        If IsPostBack And Not pnlIngreso.Visible Then
            If ConfirmTarget = "Confirmar" Then ProcesarRechazoCompra(ConfirmArgument)
            If ConfirmTarget = "Redirigir" Then Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub

    Private Sub ProcesarRechazoCompra(ByVal argument As String)
        Dim chk As New CheckBox
        Dim noSolId As Int32
        Dim aSeleccionado As Boolean = False
        Dim i As Integer = 0
        Dim j As Integer = 0

        consultarEmpleados()

        For Each a As GridViewRow In Me.gvSolicitudCompra.Rows
            chk = a.FindControl("chkSeleccionada")
            noSolId = CType(gvSolicitudCompra.DataKeys(a.RowIndex).Values(1), Integer)
            Dim solicitud As SAB_EST_SOLICITUDES = CType(a.DataItem, SAB_EST_SOLICITUDES)
            ' noSol.IDESTABLECIMIENTO = Me.gvSolicitudCompra.DataKeys(a.RowIndex).Values(0)
            'noSol = CInt(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(11).Text)
            If chk.Checked = True Then

                aSeleccionado = True
                SolicitudesSeleccionadas.Insert(i, solicitud)
                Me.ViewState("totalMonto") += CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(6).Text)
                i += 1     'Lleva el control del número solicitudes seleccionadas
            Else
                If SolicitudesSeleccionadas.Contains(solicitud) Then
                    SolicitudesSeleccionadas.RemoveAt(SolicitudesSeleccionadas.IndexOf(solicitud))
                End If
                If Me.ViewState("totalMonto") > 0 Then
                    Me.ViewState("totalMonto") -= CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(6).Text)
                End If
            End If
        Next

        If aSeleccionado = True Then
            If i > 1 Then
                Alert("Debe seleccionar solamente una solicitud de compra para rechazar", "Aviso")
            Else
                For i = 0 To SolicitudesSeleccionadas.Count - 1
                    Dim lEntidadSp As New SAB_EST_SOLICITUDES
                    lEntidadSp = SolicitudesSeleccionadas.Item(i)

                    With lEntidadSp
                        .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
                        .IDESTADO = 1
                        .ESTASINCRONIZADA = 0
                    End With

                    EstablecimientoHelpers.Solicitud.ActualizarDatosGenerales(lEntidadSp)
                    ' mComponenteSPC.RechazarSolicitud(lEntidadSP)
                    obtenerDatos()
                Next
            End If
        Else
            Alert("Debe seleccionar una solicitud", "Aviso")
            'Me.lblMsgerror.Text = "Debe seleccionar una solicitud"
        End If

    End Sub

    Private Sub ProcesarInicioCompra(ByVal argument As String)

        Dim proceso As New SAB_UACI_PROCESOCOMPRAS
        Dim usr = Membresia.ObtenerUsuario()

        With proceso
            .IDPROCESOCOMPRA = 0
            .FECHAINICIOPROCESOCOMPRA = CType(Me.cpFechaInicio.Text, Date)
            .IDTIPOCOMPRASUGERIDO = Me.UcListaTipoCompra2._VALORACTUAL
            .IDTIPOCOMPRAEJECUTAR = CType(Me.ddlProcesoCompraEjecutar.SelectedValue, Integer)
            .IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.PROCESODECOMPRAINICIADO
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDENCARGADO = CType(Me.UcListaEmpleado1.ObtenerEmpleado, Integer)
            .IDJEFEUACI = usr.EMPLEADO.IDEMPLEADO
            .IDENTIDADSOLICITA = Nothing
            .ESTASINCRONIZADA = 0
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = DateTime.Now
        End With
        Dim options As New TransactionOptions
        options.IsolationLevel = IsolationLevel.ReadCommitted
        options.Timeout = TimeSpan.MaxValue

        Using t As New TransactionScope(TransactionScopeOption.Required, options)

            Try
                MessageContent.Visible = True
               
                'ScriptManager.RegisterStartupScript(Page, Me.GetType(), "alert", "$find('popModal').show()", True)
                Using db As New SinabEntities
                    'Agrega el proceso de compra a SAB_UACI_PROCESOCOMPRAS
                    ProcesoCompras.Agregar(db, proceso)

                    txtNoAsignado.Text = proceso.IDPROCESOCOMPRA.ToString()

                    'Inicio del lazo
                    For Each solic As SAB_EST_SOLICITUDES In SolicitudesSeleccionadas
                        Dim lEntidadSol As New SAB_EST_SOLICITUDES
                        Dim lEntidadSp As New SAB_EST_SOLICITUDESPROCESOCOMPRAS

                        'Agrega entidades a SAB_EST_SOLICITUDESPROCESOCOMPRAS
                        With lEntidadSp
                            .IDESTABLECIMIENTOSOLICITUD = solic.IDESTABLECIMIENTO
                            .IDSOLICITUD = solic.IDSOLICITUD
                            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
                            .IDPROCESOCOMPRA = CType(Me.txtNoAsignado.Text, Long)
                            .ESTASINCRONIZADA = 1
                            .AUFECHACREACION = Date.Now
                            .AUFECHAMODIFICACION = Date.Now
                            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                        End With
                        EstablecimientoHelpers.SolicitudesProcesoCompras.Agregar(db, lEntidadSp)

                        'Actualiza entidades en SAB_EST_SOLICITUDES
                        With lEntidadSol
                            .IDESTADO = 6
                            .IDSOLICITUD = solic.IDSOLICITUD
                            .IDESTABLECIMIENTO = solic.IDESTABLECIMIENTO
                            .ESTASINCRONIZADA = 1
                            .AUFECHAMODIFICACION = Date.Now
                            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                        End With
                        EstablecimientoHelpers.Solicitud.ActualizarDatosGenerales(db, lEntidadSol)
                    Next
                    'Fin del lazo

                    'Agrega observacion de proceso de compra en SAB_UACI_OBSERVACIONPROCESOSCOMPRAS
                    Dim lEntidadOPC As New SAB_UACI_OBSERVACIONPROCESOSCOMPRAS
                    With lEntidadOPC
                        .IDESTADO = 1 'TODO: Vertificar
                        .IDPROCESO = CType(Me.txtNoAsignado.Text, Long)
                        .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
                        .OBSERVACION = Me.txtComentarios.Text
                        .ESTASINCRONIZADA = 1
                        .AUFECHACREACION = Date.Now
                        .AUFECHAMODIFICACION = Date.Now
                        .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                        .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    End With
                    ObservacionProcesoCompras.Agregar(lEntidadOPC)

                    'Agrega o actualiza entidades a SAB_UACI_DETALLEPROCESOCOMPRA
                    Dim tipoCompra = TiposCompra.Obtener(CType(proceso.IDTIPOCOMPRAEJECUTAR, Integer))
                    Dim estadoClasificacion As Integer

                    If tipoCompra.IDMODALIDADCOMPRA = 1 Then estadoClasificacion = 8 Else  : estadoClasificacion = 3

                    DetalleProcesoCompras.AsignaryActualizarVarios(db, proceso.IDESTABLECIMIENTO, proceso.IDPROCESOCOMPRA, CType(estadoClasificacion, Byte), EstablecimientoHelpers.Solicitudes.GenerarDetallesPC(SolicitudesSeleccionadas))

                    'Agrega el programa de distribucion a SAB_UACI_PROGRAMADISTRIBUCION
                    'If SolicitudesSeleccionadas.Count > 1 Then
                    '    UACI.ProgramaDistribucion.Agregar(db, proceso.IDESTABLECIMIENTO, CType(proceso.IDPROCESOCOMPRA, Integer), False)
                    'Else
                    UACI.ProgramaDistribucion.Agregar(db, proceso.IDESTABLECIMIENTO, CType(proceso.IDPROCESOCOMPRA, Integer), True)
                    '  End If
                    
                    'Agrega entregas a SAB_UACI_ENTREGAPROCESOCOMPRA
                    EntregasProcesoCompra.AgregarVarios(db, SolicitudesSeleccionadas, proceso.IDESTABLECIMIENTO, CType(proceso.IDPROCESOCOMPRA, Integer))
                    'Agrega detalle de entregas a SAB_UACI_DETALLEENTREGASPROCESOCOMPRA
                    DetalleEntregasProcesoCompra.AgregarVarios(db, SolicitudesSeleccionadas, proceso.IDESTABLECIMIENTO, CType(proceso.IDPROCESOCOMPRA, Integer))

                    '---------------------------------------------
                    Dim directorio As String

                    directorio = "EST" & usr.Establecimiento.IDESTABLECIMIENTO & "_PROC" & Me.txtNoAsignado.Text

                    Directory.CreateDirectory(Server.MapPath(directorio))
                    Directory.CreateDirectory(Server.MapPath(directorio & "\BASES"))
                    Directory.CreateDirectory(Server.MapPath(directorio & "\CONTRATOS"))
                    Directory.CreateDirectory(Server.MapPath(directorio & "\AUDIENCIAS"))
                    Directory.CreateDirectory(Server.MapPath(directorio & "\MULTAS"))
                    '----------------------------------------------

                    'todo: Borrar despues de la prueba
                    'Throw New Exception("algun error")

                    t.Complete()
                    AlertSubmit("El proceso se efectuó satisfactoriamente", "Redirigir")

                End Using
            Catch ex As Exception
                SINAB_Utils.MessageBox.Alert(ex.Message)
            End Try
        End Using
        'Dim mComponentePCD As New cPROCESOCOMPRAS
        ''Dim resultado As Integer

        'resultado = mComponentePCD.generarProgramaDistribucion(Session("IdEstablecimiento"), Me.txtNoAsignado.Text, CStr(HttpContext.Current.User.Identity.Name), CStr(Date.Now), "T")

        'Dim mComponenteEPC As New cENTREGAPROCESOCOMPRA

        'If mComponenteEPC.AgregarEntregasProcesoCompra2(solSelect, Session("IdEstablecimiento"), Me.txtNoAsignado.Text) <> 1 Then
        '    Me.lblMsgerror.Text = "Error al Guardar registro."
        'Else
        '    Me.lblMsgerror.Text = "El Proceso se ha iniciado satisfactoriamente"

        '    Dim directorio As String

        '    directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & Me.txtNoAsignado.Text

        '    Directory.CreateDirectory(Server.MapPath(directorio))
        '    Directory.CreateDirectory(Server.MapPath(directorio & "\BASES"))
        '    Directory.CreateDirectory(Server.MapPath(directorio & "\CONTRATOS"))
        '    Directory.CreateDirectory(Server.MapPath(directorio & "\AUDIENCIAS"))
        '    Directory.CreateDirectory(Server.MapPath(directorio & "\MULTAS"))

        '    solSelect.Clear()
        'End If
    End Sub
#Region "comentariado"

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

    '    Dim solSelect As New ArrayList

    '    solSelect = Me.ViewState("solSelected")

    '    If e.Key = "rechazar" Then
    '        Dim chk As New CheckBox
    '        Dim noSol As Int16
    '        Dim aSeleccionado As Boolean = False
    '        Dim i As Integer = 0
    '        Dim j As Integer = 0

    '        consultarEmpleados()
    '        For Each a As GridViewRow In Me.gvSolicitudCompra.Rows
    '            chk = a.FindControl("chkSeleccionada")
    '            noSol = CInt(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(11).Text)
    '            If chk.Checked = True Then
    '                Me.lblMsgerror.Text = ""
    '                aSeleccionado = True
    '                solSelect.Insert(i, noSol)
    '                Me.ViewState("totalMonto") += CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(8).Text)
    '                i += 1     'Lleva el control del número solicitudes seleccionadas
    '            Else
    '                If solSelect.Contains(noSol) Then
    '                    solSelect.RemoveAt(solSelect.IndexOf(noSol))
    '                End If
    '                If Me.ViewState("totalMonto") > 0 Then
    '                    Me.ViewState("totalMonto") -= CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(8).Text)
    '                End If
    '            End If
    '        Next
    '        If aSeleccionado = True Then
    '            If i > 1 Then
    '                lblMsgerror.Text = "Debe seleccionar solamente una solicitud de compra para rechazar "
    '            Else
    '                Dim mComponenteSPC As New cSOLICITUDES
    '                Dim lEntidadSP As New SOLICITUDES
    '                For i = 0 To solSelect.Count - 1
    '                    lEntidadSP.IDSOLICITUD = solSelect.Item(i)
    '                    lEntidadSP.IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '                    lEntidadSP.IDESTADO = 1
    '                    lEntidadSP.ESTASINCRONIZADA = 0
    '                    mComponenteSPC.RechazarSolicitud(lEntidadSP)
    '                    obtenerDatos()
    '                Next
    '            End If
    '        Else
    '            Me.MsgBox1.ShowAlert("Debe seleccionar una solicitud", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
    '            'Me.lblMsgerror.Text = "Debe seleccionar una solicitud"
    '        End If
    '    End If
    'End Sub

    'Protected Sub MsgBox3_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox3.YesChosen
    '    Dim lEntidad As New PROCESOCOMPRAS
    '    Dim solSelect As New listaSOLICITUDES
    '    'tem = 0
    '    If e.Key = "B" Then
    '        'If tem = 1 Then
    '        solSelect = Me.ViewState("solSelected")

    '        lEntidad.IDPROCESOCOMPRA = 0
    '        lEntidad.FECHAINICIOPROCESOCOMPRA = Me.cpFechaInicio.SelectedDate
    '        lEntidad.IDTIPOCOMPRASUGERIDO = Me.UcListaTipoCompra2._VALORACTUAL
    '        lEntidad.IDTIPOCOMPRAEJECUTAR = Me.ddlProcesoCompraEjecutar.SelectedValue
    '        lEntidad.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.PROCESODECOMPRAINICIADO
    '        lEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '        lEntidad.IDENCARGADO = Me.UcListaEmpleado1.ObtenerEmpleado
    '        lEntidad.IDJEFEUACI = Session.Item("IdEmpleado")
    '        lEntidad.IDENTIDADSOLICITA = Nothing
    '        lEntidad.ESTASINCRONIZADA = 0
    '        lEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '        lEntidad.AUFECHACREACION = Now

    '        Dim mComponentePC As New cPROCESOCOMPRAS
    '        Dim mComponenteOPC As New cOBSERVACIONPROCESOSCOMPRAS
    '        Dim mComponenteSPC As New cSOLICITUDESPROCESOCOMPRAS

    '        If mComponentePC.ActualizarPROCESOCOMPRAS(lEntidad) = 1 Then

    '            Me.txtNoAsignado.Text = lEntidad.IDPROCESOCOMPRA
    '            Dim lEntidadSP As New SOLICITUDESPROCESOCOMPRAS
    '            Dim mComponenteSol As New cSOLICITUDES
    '            Dim lEntidadSol As New SOLICITUDES

    '            For Each solic As SOLICITUDES In solSelect
    '                lEntidadSP.IDESTABLECIMIENTOSOLICITUD = solic.IDESTABLECIMIENTO
    '                lEntidadSP.IDSOLICITUD = solic.IDSOLICITUD
    '                lEntidadSP.IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '                lEntidadSP.IDPROCESOCOMPRA = Me.txtNoAsignado.Text
    '                lEntidadSP.ESTASINCRONIZADA = 1
    '                lEntidadSP.AUFECHACREACION = Date.Now
    '                lEntidadSP.AUFECHAMODIFICACION = Date.Now
    '                lEntidadSP.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '                lEntidadSP.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name

    '                mComponenteSPC.AgregarSOLICITUDESPROCESOCOMPRAS(lEntidadSP)

    '                With lEntidadSol
    '                    .IDESTADO = 6
    '                    .IDSOLICITUD = solic.IDSOLICITUD
    '                    .IDESTABLECIMIENTO = solic.IDESTABLECIMIENTO
    '                    .ESTASINCRONIZADA = 1
    '                    .AUFECHAMODIFICACION = Date.Now
    '                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '                End With
    '                mComponenteSol.ActualizarEstado(lEntidadSol)
    '            Next

    '            Dim lEntidadOPC As New OBSERVACIONPROCESOSCOMPRAS
    '            With lEntidadOPC
    '                .IDESTADO = 1 'TODO: Vertificar
    '                .IDPROCESO = Me.txtNoAsignado.Text
    '                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '                .OBSERVACION = Me.txtComentarios.Text
    '                .ESTASINCRONIZADA = 1
    '                .AUFECHACREACION = Date.Now
    '                .AUFECHAMODIFICACION = Date.Now
    '                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '            End With

    '            If mComponenteOPC.AgregarOBSERVACIONPROCESOSCOMPRAS(lEntidadOPC) <> 1 Then
    '                Me.lblMsgerror.Text = "Error al Guardar registro."
    '            End If

    '        Else
    '            Me.lblMsgerror.Text = "Error al Guardar registro."
    '        End If

    '        Dim mComponenteDPC As New cDETALLEPROCESOCOMPRA

    '        If mComponenteDPC.AgregarDetalleProcesoCompra(solSelect, Me.txtNoAsignado.Text, Session("IdEstablecimiento")) <> 1 Then
    '            Me.lblMsgerror.Text = "Error al Guardar registro."
    '        End If

    '        Dim mComponentePCD As New cPROCESOCOMPRAS
    '        Dim resultado As Integer

    '        resultado = mComponentePCD.generarProgramaDistribucion(Session("IdEstablecimiento"), Me.txtNoAsignado.Text, CStr(HttpContext.Current.User.Identity.Name), CStr(Date.Now), "T")

    '        Dim mComponenteEPC As New cENTREGAPROCESOCOMPRA

    '        If mComponenteEPC.AgregarEntregasProcesoCompra2(solSelect, Session("IdEstablecimiento"), Me.txtNoAsignado.Text) <> 1 Then
    '            Me.lblMsgerror.Text = "Error al Guardar registro."
    '        Else
    '            Me.lblMsgerror.Text = "El Proceso se ha iniciado satisfactoriamente"

    '            Dim directorio As String

    '            directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & Me.txtNoAsignado.Text

    '            Directory.CreateDirectory(Server.MapPath(directorio))
    '            Directory.CreateDirectory(Server.MapPath(directorio & "\BASES"))
    '            Directory.CreateDirectory(Server.MapPath(directorio & "\CONTRATOS"))
    '            Directory.CreateDirectory(Server.MapPath(directorio & "\AUDIENCIAS"))
    '            Directory.CreateDirectory(Server.MapPath(directorio & "\MULTAS"))

    '            solSelect.Clear()
    '        End If

    '        Response.Redirect("~/FrmPrincipal.aspx", False)

    '    End If

    'End Sub

#End Region

    Private Sub obtenerProcesoSugerido(ByVal monto As Decimal)
        Dim mComponenteTC As New cTIPOCOMPRAS
        Dim idProcesoCompraSG As Integer
        idProcesoCompraSG = mComponenteTC.obtenerListaporMonto(monto).Tables(0).Rows(0).Item(0)

        With UcListaTipoCompra2
            ._ESTABLECEVALOR = idProcesoCompraSG
            .establecerValor()
            ._ENABLED = False
            .habilitarControl()
        End With

    End Sub

    Private Sub mostrarIngreso()
        Me.pnlIngreso.Visible = True
        Me.pnlSeleccion.Visible = False
        Me.Label1.Text = "Ingrese los datos requeridos para las solicitudes seleccionadas"

        With UcBarraNavegacion1
            .PermitirGuardar = True
            .PermitirEditar = True
            .HabilitarEdicion(True)
            .Navegacion = False
            .Visible = True
        End With

        Me.UcListaTipoCompra1.obtenerDatos()
        Me.UcListaTipoCompra2.obtenerDatos()

        validarTipoCompra()

    End Sub

    Public Sub validarTipoCompra()

        Dim tipoCompra As New cTIPOCOMPRAS
        Dim ds As Data.DataSet

        ds = tipoCompra.obtenerTipoCompraporMonto(Me.ViewState("totalMonto"))

        With ddlProcesoCompraEjecutar
            .DataSource = ds
            .DataTextField = "DESCRIPCION"
            .DataValueField = "IDTIPOCOMPRA"
            .DataBind()
        End With
    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        pnlSeleccion.Visible = True
        pnlIngreso.Visible = False
        ViewState("totalMonto") = 0
        UcBarraNavegacion1.Navegacion = False
        UcBarraNavegacion1.Visible = False
        Label1.Text = "Seleccione las solicitudes del siguiente listado"
    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        Confirm("El proceso de compra se va ha iniciar. Favor esperar a que finalice el proceso. ¿Desea continuar?", "Espere", OptionPostBack.YesPostBack)
        'Me.MsgBox3.ShowConfirm("El proceso de compra se va ha iniciar. Favor esperar a que finalice el proceso. Desea continuar", "B",
        '                       Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_CallBackOnNo)
    End Sub

    Protected Sub DdlESTADOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlESTADOS1.SelectedIndexChanged
        obtenerDatos()
        If Me.DdlESTADOS1.SelectedValue = 2 Then
            lbRechazaSolicitud.Visible = True
        Else
            lbRechazaSolicitud.Visible = False
        End If
    End Sub

    Protected Sub lbRechazaSolicitud_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbRechazaSolicitud.Click
        Confirm("¿Desea rechazar la(s) solicitud(es) seleccionada(s)?", "Confirmar", OptionPostBack.YesPostBack)
        'Me.MsgBox1.ShowConfirm("¿Desea rechazar la(s) solicitud(es) seleccionada(s)?", "rechazar",
        '                       Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo,
        '                       Cooperator.Framework.Web.Controls.DefaultButton.No)
    End Sub

    Protected Sub btnIniciaProceso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIniciaProceso.Click


        Dim aSeleccionado As Boolean = False
        Dim i As Integer = 0
        Dim j As Integer = 0
        ' Dim solSelect As New listaSOLICITUDES
        Dim solicitudes As New List(Of SAB_EST_SOLICITUDES)
        'solSelect = Me.ViewState("solSelected")

        consultarEmpleados()

        For Each a As GridViewRow In Me.gvSolicitudCompra.Rows
            Dim noSol = EstablecimientoHelpers.Solicitudes.Obtener(CType(gvSolicitudCompra.DataKeys(a.RowIndex).Values(0), Int32), _
                                                            CType(gvSolicitudCompra.DataKeys(a.RowIndex).Values(1), Long))
            Dim chk As CheckBox = CType(a.FindControl("chkSeleccionada"), CheckBox)
            If chk.Checked = True Then

                aSeleccionado = True
                If Not solicitudes.Contains(noSol) Then
                    solicitudes.Add(noSol)

                    ViewState("totalMonto") += CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(6).Text)
                    i += 1     'Lleva el control del número solicitudes seleccionadas
                Else

                End If

            Else
                If solicitudes.Contains(noSol) = True Then
                    solicitudes.RemoveAt(solicitudes.IndexOf(noSol))
                    If Me.ViewState("totalMonto") > 0 Then
                        Me.ViewState("totalMonto") -= CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(6).Text)
                    End If
                End If
            End If
        Next

        SolicitudesSeleccionadas = solicitudes
        If solicitudes.Count > 0 Then
            If validarSolicitudes(solicitudes) = True Then
                If aSeleccionado = True Then
                    If j > 1 Then

                        Alert("Debe seleccionar solamente una solicitud de compra conjunta ", "Requerido")
                        'MsgBox2.ShowAlert("Debe seleccionar solamente una solicitud de compra conjunta ", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction,
                        '                  Cooperator.Framework.Web.Controls.AlertType.Stop)
                    Else
                        If i > 1 Then
                            If j = 1 Then
                                Alert("Sólo se permite seleccionar una solicitud de compra conjunta", "Error")
                                'MsgBox2.ShowAlert("Sólo se permite seleccionar una solicitud de compra conjunta", "",
                                '                  Cooperator.Framework.Web.Controls.AlertOption.NoAction,
                                '                  Cooperator.Framework.Web.Controls.AlertType.Stop)
                            Else
                                obtenerProcesoSugerido(CType(Me.ViewState("totalMonto"), Decimal))
                                mostrarIngreso()
                            End If
                        Else
                            obtenerProcesoSugerido(Me.ViewState("totalMonto"))
                            mostrarIngreso()
                        End If
                    End If
                Else
                    Alert("Debe seleccionar una solicitud", "Error")
                End If
            Else
                Alert(strNoCumple.ToString, "Error")
                'MsgBox1.ShowAlert(strNoCumple.ToString, "ERROR", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                strNoCumple = Nothing
            End If
        Else
            Alert("Debe seleccionar una solicitud", "Campo Obligatorio")
            'Me.MsgBox1.ShowAlert("Debe seleccionar una solicitud", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        End If


    End Sub

    Private Function validarSolicitudes(ByVal ARR_SOLICITUD As List(Of SAB_EST_SOLICITUDES)) As Boolean

        ' Dim ds As Data.DataSet
        Dim i As Integer
        Dim idSuministro As Integer
        Dim idSuministro_ant As Integer = 0
        Dim mComSolicitud As New cSOLICITUDES

        Dim Solic As SAB_EST_SOLICITUDES
        'todo:URGE REFACTORIZAR ESTE METODO!!
        For i = 0 To ARR_SOLICITUD.Count - 1
            Solic = ARR_SOLICITUD.Item(i)
            If Solic.IDSOLICITUD <> 0 Then
                idSuministro = mComSolicitud.obtenerSuministroSolicitud(Solic.IDESTABLECIMIENTO, Solic.IDSOLICITUD)

                If idSuministro_ant = 0 Then
                    idSuministro_ant = idSuministro
                ElseIf idSuministro <> idSuministro_ant Then
                    Alert("No es posible iniciar el proceso para solicitudes de suministros diferentes", "Error")
                    'MsgBox2.ShowAlert("No es posible iniciar el proceso para solicitudes de suministros diferentes", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                    Return False
                End If
            End If
        Next
        
        If strNoCumple.ToString <> "" Then
            strNoCumple.Append("verifique los datos de las solicitudes.")
            Return False
        Else
            Return True
        End If

    End Function
End Class
