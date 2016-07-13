
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.IO

Partial Class Controles_ucVistaListadoSolicitudCompraUACI
    Inherits System.Web.UI.UserControl

    Private mComponente As New cSOLICITUDES
    Dim strNoCumple As New Text.StringBuilder
    Dim Filtro As String
    Dim operador, PAGINA_REDIRECT As String
    Dim criterio As String
    Dim IDESTABLECIMIENTO As Int64
    Friend Shared tem As Integer
    Friend Shared cantidadEntregas As Integer = 0

    Public WriteOnly Property _FILTRO() As String
        Set(ByVal value As String)
            Filtro = value
        End Set
    End Property

    Public WriteOnly Property _IDESTABLECIMIENTO() As Integer
        Set(ByVal value As Integer)
            IDESTABLECIMIENTO = value
        End Set
    End Property

    Public WriteOnly Property _CRITERIO() As String
        Set(ByVal value As String)
            criterio = value
        End Set
    End Property

    Public WriteOnly Property _OPERADOR() As String
        Set(ByVal value As String)
            operador = value
        End Set
    End Property

    Public WriteOnly Property _PAGINA_REDIRECT() As String
        Set(ByVal value As String)
            PAGINA_REDIRECT = value
        End Set
    End Property

    Public Sub consultar()
        If Not IsPostBack Then
            obtenerDatos()
        End If
    End Sub

    Private Sub obtenerDatos()
        Me.gvSolicitudCompra.DataSource = Me.mComponente.Filtrar_VistaSolitudLG(IDESTABLECIMIENTO, 8, criterio, operador, HttpContext.Current.User.Identity.Name)
        Me.gvSolicitudCompra.DataBind()
    End Sub

    Private Sub consultarEmpleados()
        'Me.UcListaEmpleado1.ObtenerDatos()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.UcBarraNavegacion1.Navegacion = False
            Me.UcBarraNavegacion1.PermitirAgregar = False
            Me.UcBarraNavegacion1.PermitirConsultar = False
            Me.UcBarraNavegacion1.PermitirEditar = False
            Me.UcBarraNavegacion1.HabilitarEdicion(False)
            Me.UcBarraNavegacion1.PermitirGuardar = False
            Me.UcBarraNavegacion1.PermitirImprimir = False

            Dim solSelect As New ArrayList
            Me.ViewState("solSelected") = solSelect
            solSelect.Add(0)
            Me.pnlSeleccion.Visible = True
            Me.pnlIngreso.Visible = False

        End If

    End Sub

    Private Sub obtenerProcesoSugerido(ByVal monto As Decimal)
        Dim mComponenteTC As New cTIPOCOMPRAS
        Dim idProcesoCompraSG As Integer
        idProcesoCompraSG = mComponenteTC.obtenerListaporMonto(monto).Tables(0).Rows(0).Item(0)
        
    End Sub

    Private Sub mostrarIngreso()
        Me.pnlIngreso.Visible = True
        Me.pnlSeleccion.Visible = False
        Me.Label1.Text = "Ingrese los datos requeridos para las solicitudes seleccionadas"
        Me.UcBarraNavegacion1.Visible = True
        Me.UcBarraNavegacion1.PermitirGuardar = True
        Me.UcBarraNavegacion1.PermitirEditar = True
        Me.UcBarraNavegacion1.HabilitarEdicion(True)
        Me.UcBarraNavegacion1.Navegacion = False


        'validarTipoCompra()

    End Sub

   

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        Me.pnlSeleccion.Visible = True
        Me.pnlIngreso.Visible = False
        Me.ViewState("totalMonto") = 0
        Me.UcBarraNavegacion1.Navegacion = False
        Me.Label1.Text = "Seleccione las solicitudes del siguiente listado"
    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        Dim Sole As SOLICITUDES = Me.ViewState("solId")
        Dim cs As New cSOLICITUDES
        Dim status = Me.ddListEstados.SelectedValue

        cs.CambioEstadoSolicitudesEstablecimientos(Sole.IDESTABLECIMIENTO, Sole.IDSOLICITUD, status)

        'Me.MsgBox3.ShowConfirm("El proceso de compra ha sido asignado satisfactoriamente, desea continuar", "B", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_CallBackOnNo)

        Response.Redirect("~/UACI/FrmMantIniciaProcesoCompraUACI.aspx")


    End Sub

    Protected Sub DdlESTADOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlESTADOS1.SelectedIndexChanged
        obtenerDatos()
        If Me.DdlESTADOS1.SelectedValue = 2 Then
            'lbRechazaSolicitud.Visible = True
        Else
            'lbRechazaSolicitud.Visible = False
        End If
    End Sub

    'Protected Sub lbRechazaSolicitud_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbRechazaSolicitud.Click
    '    Me.MsgBox1.ShowConfirm("¿Desea rechazar la(s) solicitud(es) seleccionada(s)?", "rechazar", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)
    'End Sub

    Protected Sub btnIniciaProceso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIniciaProceso.Click
        Dim chk As New CheckBox
        Dim noSol As SOLICITUDES
        Dim aSeleccionado As Boolean = False
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim solSelect As New listaSOLICITUDES

        'solSelect = Me.ViewState("solSelected")

        consultarEmpleados()

        For Each a As GridViewRow In Me.gvSolicitudCompra.Rows
            chk = a.FindControl("chkSeleccionada")
            noSol = New SOLICITUDES
            noSol.IDSOLICITUD = Me.gvSolicitudCompra.DataKeys(a.RowIndex).Values(1)
            noSol.IDESTABLECIMIENTO = Me.gvSolicitudCompra.DataKeys(a.RowIndex).Values(0)
            Me.ViewState("solId") = noSol
            If chk.Checked = True Then
                Me.lblMsgerror.Text = ""
                aSeleccionado = True
                If Not solSelect.Contiene(noSol) Then
                    solSelect.Add(noSol)
                    If Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(7).Text = "Si" Or Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(7).Text = "SI" Then
                        j = 1   'Lleva el control del número solicitudes de compra conjunta seleccionadas
                    End If
                    Me.ViewState("totalMonto") += CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(6).Text)
                    i += 1     'Lleva el control del número solicitudes seleccionadas
                Else
                    If Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(7).Text = "Si" Then
                        j = 1   'Lleva el control del número solicitudes de compra conjunta seleccionadas
                    End If
                End If

            Else
                If solSelect.Contiene(noSol) = True Then
                    solSelect.RemoveAt(solSelect.IndiceDe(noSol))
                    If Me.ViewState("totalMonto") > 0 Then
                        Me.ViewState("totalMonto") -= CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(6).Text)
                    End If
                End If
            End If
        Next

        Me.ViewState("solSelected") = solSelect
        If solSelect.Count > 0 Then
            If validarSolicitudes(solSelect) = True Then
                If aSeleccionado = True Then
                    If j > 1 Then
                        'lblMsgerror.Text = "Debe seleccionar solamente una solicitud de compra conjunta "
                        MsgBox2.ShowAlert("Debe seleccionar solamente una solicitud de compra conjunta ", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                    Else
                        If i > 1 Then
                            If j = 1 Then
                                MsgBox2.ShowAlert("Sólo se permite seleccionar una solicitud de compra conjunta", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                            Else
                                obtenerProcesoSugerido(Me.ViewState("totalMonto"))
                                mostrarIngreso()
                            End If
                        Else


                            obtenerProcesoSugerido(Me.ViewState("totalMonto"))
                            mostrarIngreso()
                        End If
                    End If
                Else

                    Me.lblMsgerror.Text = "Debe seleccionar una solicitud"
                End If
            Else
                Me.MsgBox1.ShowAlert(strNoCumple.ToString, "ERROR", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                strNoCumple = Nothing
            End If
        Else
            Me.MsgBox1.ShowAlert("Debe seleccionar una solicitud", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        End If

    End Sub

    Private Function validarSolicitudes(ByVal ARR_SOLICITUD As listaSOLICITUDES) As Boolean
        Dim mComEntregaSol As New cENTREGASOLICITUDES
        Dim mComDetEntregaSol As New cDETALLEENTREGAS
        'Dim ds As Data.DataSet
        Dim i, j, k As Integer
        Dim dias As Integer = 0
        Dim porcentaje As Decimal = 0
        'Dim noEntrega As Integer
        Dim idSuministro As Integer
        Dim idSuministro_ant As Integer = 0
        Dim mComSolicitud As New cSOLICITUDES

        Dim Solic As SOLICITUDES

        For i = 0 To ARR_SOLICITUD.Count - 1
            Solic = ARR_SOLICITUD.Blubber(i)
            If Solic.IDSOLICITUD <> 0 Then
                idSuministro = mComSolicitud.obtenerSuministroSolicitud(Solic.IDESTABLECIMIENTO, Solic.IDSOLICITUD)

                If idSuministro_ant = 0 Then
                    idSuministro_ant = idSuministro
                    Return True
                ElseIf idSuministro <> idSuministro_ant Then
                    MsgBox2.ShowAlert("No es posible iniciar el proceso para solicitudes de suministros diferentes", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                    Return False
                End If
            End If
        Next

        'noEntrega = mComEntregaSol.obtenerMaximoEntregas(ARR_SOLICITUD)

        'For i = 1 To noEntrega
        '    For j = 1 To noEntrega
        '        ds = mComDetEntregaSol.obtenerDiasPorcentaje(i, ARR_SOLICITUD, j)
        '        If ds.Tables(0).Rows.Count > 0 Then
        '            For k = 0 To ds.Tables(0).Rows.Count - 1
        '                If (k + 1) <= ds.Tables(0).Rows.Count - 1 Then
        '                    If ds.Tables(0).Rows(k).Item("DIAS") = ds.Tables(0).Rows(k + 1).Item("DIAS") Then

        '                        If ds.Tables(0).Rows(k).Item("PORCENTAJE") = ds.Tables(0).Rows(k + 1).Item("PORCENTAJE") Then
        '                        Else
        '                            strNoCumple.Append(" La solicitudes no poseen el mismo porcentaje en el detalle de entrega para la  " & j & " entrega. " & Chr(13))

        '                        End If

        '                    Else
        '                        strNoCumple.Append(" La solicitudes no poseen el mismo número de dias de en el detalle de entrega para la  " & j & " entrega. " & Chr(13))
        '                    End If
        '                End If
        '            Next
        '        End If
        '    Next
        'Next

        'If strNoCumple.ToString <> "" Then
        '    strNoCumple.Append("verifique los datos de las solicitudes.")
        '    Return False
        'Else
        '    Return True
        'End If

    End Function

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        Dim solSelect As New ArrayList

        solSelect = Me.ViewState("solSelected")

        If e.Key = "rechazar" Then
            Dim chk As New CheckBox
            Dim noSol As Int16
            Dim aSeleccionado As Boolean = False
            Dim i As Integer = 0
            Dim j As Integer = 0

            consultarEmpleados()
            For Each a As GridViewRow In Me.gvSolicitudCompra.Rows
                chk = a.FindControl("chkSeleccionada")
                noSol = CInt(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(9).Text)
                If chk.Checked = True Then
                    Me.lblMsgerror.Text = ""
                    aSeleccionado = True
                    solSelect.Insert(i, noSol)
                    Me.ViewState("totalMonto") += CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(6).Text)
                    i += 1     'Lleva el control del número solicitudes seleccionadas
                Else
                    If solSelect.Contains(noSol) Then
                        solSelect.RemoveAt(solSelect.IndexOf(noSol))
                    End If
                    If Me.ViewState("totalMonto") > 0 Then
                        Me.ViewState("totalMonto") -= CDec(Me.gvSolicitudCompra.Rows(a.RowIndex).Cells(6).Text)
                    End If
                End If
            Next
            If aSeleccionado = True Then
                If i > 1 Then
                    lblMsgerror.Text = "Debe seleccionar solamente una solicitud de compra para rechazar "
                Else
                    Dim mComponenteSPC As New cSOLICITUDES
                    Dim lEntidadSP As New SOLICITUDES
                    For i = 0 To solSelect.Count - 1
                        lEntidadSP.IDSOLICITUD = solSelect.Item(i)
                        lEntidadSP.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        lEntidadSP.IDESTADO = 3
                        lEntidadSP.ESTASINCRONIZADA = 0
                        mComponenteSPC.RechazarSolicitud(lEntidadSP)
                        obtenerDatos()
                    Next
                End If
            Else
                Me.MsgBox1.ShowAlert("Debe seleccionar una solicitud", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                'Me.lblMsgerror.Text = "Debe seleccionar una solicitud"
            End If
        End If
    End Sub

    Protected Sub gvSolicitudCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvSolicitudCompra.PageIndexChanging
        Me.gvSolicitudCompra.PageIndex = e.NewPageIndex
        Me.obtenerDatos()
    End Sub

    Protected Sub gvSolicitudCompra_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSolicitudCompra.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim cFFS As New cFUENTEFINANCIAMIENTOSOLICITUDES

            Dim IDESTABLECIMIENTOSOLICITUD As Integer = sender.DataKeys(e.Row.RowIndex).Values.Item("IDESTABLECIMIENTO")
            Dim IDSOLICITUD As Integer = sender.DataKeys(e.Row.RowIndex).Values.Item("IDSOLICITUD")

            Dim gv As GridView = CType(e.Row.FindControl("gvFuentesFinanciamiento"), GridView)

            Dim ds As Data.DataSet
            ds = cFFS.ObtenerNombresFuenteFinanciamientoSolicitud(IDESTABLECIMIENTOSOLICITUD, IDSOLICITUD)

            gv.DataSource = ds
            gv.DataBind()

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    gv.RowStyle.CssClass = sender.RowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.RowStyle.CssClass
                Case DataControlRowState.Alternate
                    gv.RowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                Case DataControlRowState.Selected
                    gv.RowStyle.CssClass = sender.SelectedRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.SelectedRowStyle.CssClass
            End Select

        End If

    End Sub

    Protected Sub MsgBox3_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox3.YesChosen
        'Dim lEntidad As New PROCESOCOMPRAS
        'Dim solSelect As listaSOLICITUDES
        ''tem = 0
        'If e.Key = "B" Then
        '    'If tem = 1 Then
        '    solSelect = Me.ViewState("solSelected")

        '    lEntidad.IdProcesoCompra = 0
        '    'lEntidad.FECHAINICIOPROCESOCOMPRA = Me.cpFechaInicio.SelectedDate
        '    lEntidad.IDTIPOCOMPRASUGERIDO = Me.UcListaTipoCompra2._VALORACTUAL
        '    'lEntidad.IDTIPOCOMPRAEJECUTAR = Me.ddlProcesoCompraEjecutar.SelectedValue
        '    lEntidad.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS
        '    lEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        '    lEntidad.IDENCARGADO = Session.Item("IdEmpleado")
        '    lEntidad.IDJEFEUACI = Session.Item("IdEmpleado")

        '    lEntidad.IDENTIDADSOLICITA = Nothing
        '    'lEntidad.FECHAHORAINICIORETIRO = Format(Me.txtFechaInicioRetiroBases.SelectedDate, "dd/MM/yyyy") & " 07:00 a.m. " ' & Format(Me.txtHoraInicioRetiroBases.SelectedTime, "HH:mm")
        '    'lEntidad.FECHAHORAFINRETIRO = Format(Me.txtFechaFinRetiroBases.SelectedDate, "dd/MM/yyyy") & " 03:30 p.m." '& Format(Me.txtHoraFinRetiroBases.SelectedTime, "HH:mm")

        '    'lEntidad.FECHAHORAINICIORECEPCION = Format(Me.txtFECHAINICIORECEPCION.SelectedDate, "dd/MM/yyyy") & " 07:00 a.m. " '& Format(Me.txtHORAINICIORECEPCION.SelectedTime, "HH:mm")
        '    'lEntidad.FECHAHORAFINRECEPCION = Format(Me.txtFECHAFINRECEPCION.SelectedDate, "dd/MM/yyyy") & " 03:30 p.m." '& Format(Me.txtHORAFINRECEPCION.SelectedTime, "HH:mm")

        '    'lEntidad.FECHAHORAINICIOAPERTURA = Format(Me.txtFECHAINICIOAPERTURA.SelectedDate, "dd/MM/yyyy") & " 07:00 a.m. " '& Format(Me.txtHORAINICIOAPERTURA.SelectedTime, "HH:mm")
        '    'lEntidad.FECHAHORAFINAPERTURA = Format(Me.txtFECHAFINAPERTURA.SelectedDate, "dd/MM/yyyy") & " 03:30 p.m." ' & Format(Me.txtHORAFINAPERTURA.SelectedTime, "HH:mm")

        '    'lEntidad.FECHAPUBLICACION = Format(Me.CalendarPopup1.SelectedDate, "dd/MM/yyyy") & " 07:00 a.m." ' & Format(Me.txtHORAFINAPERTURA.SelectedTime, "HH:mm")


        '    'lEntidad.CODIGOLICITACION = Me.txtCODIGOLICITACION.Text
        '    'lEntidad.TITULOLICITACION = Me.txtTITULOLICITACION.Text
        '    'lEntidad.DESCRIPCIONLICITACION = Me.txtDESCRIPCIONLICITACION.Text
        '    'lEntidad.FECHAELABORACIONBASE = Date.Now
        '    'lEntidad.VIGENCIACOTIZACION = Me.txtGARANTIACUMPLIMIENTOVIGENCIA.Text
        '    'lEntidad.GARANTIACUMPLIMIENTOORDENCOMPRA = Me.txtGarantiaCumplimientoOrdenCompra.Text

        '    Dim garantiaCalidadV As Decimal

        '    'If Not IsNumeric(Me.txtGARANTIACALIDADVALOR.Text) Then
        '    '    garantiaCalidadV = 0
        '    'Else
        '    '    garantiaCalidadV = CDec(Me.txtGARANTIACALIDADVALOR.Text)
        '    'End If

        '    lEntidad.GARANTIACALIDADVALOR = garantiaCalidadV

        '    lEntidad.LUGARRETIROBASE = "UACI"
        '    lEntidad.FECHAPUBLICACION = Date.Now

        '    lEntidad.ESTASINCRONIZADA = 0
        '    lEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        '    lEntidad.AUFECHACREACION = Now

        '    Dim mComponentePC As New cPROCESOCOMPRAS
        '    Dim mComponenteOPC As New cOBSERVACIONPROCESOSCOMPRAS
        '    Dim mComponenteSPC As New cSOLICITUDESPROCESOCOMPRAS

        '    If mComponentePC.ActualizarPROCESOCOMPRAS(lEntidad) = 1 Then

        '        'Me.txtNoAsignado.Text = lEntidad.IdProcesoCompra
        '        Dim lEntidadSP As New SOLICITUDESPROCESOCOMPRAS
        '        Dim mComponenteSol As New cSOLICITUDES
        '        Dim lEntidadSol As New SOLICITUDES

        '        For Each solic As SOLICITUDES In solSelect
        '            lEntidadSP.IDESTABLECIMIENTOSOLICITUD = solic.IDESTABLECIMIENTO
        '            lEntidadSP.IDSOLICITUD = solic.IDSOLICITUD
        '            lEntidadSP.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        '            'lEntidadSP.IdProcesoCompra = Me.txtNoAsignado.Text
        '            lEntidadSP.ESTASINCRONIZADA = 1
        '            lEntidadSP.AUFECHACREACION = Date.Now
        '            lEntidadSP.AUFECHAMODIFICACION = Date.Now
        '            lEntidadSP.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        '            lEntidadSP.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name

        '            mComponenteSPC.AgregarSOLICITUDESPROCESOCOMPRAS(lEntidadSP)

        '            With lEntidadSol
        '                .IDESTADO = 6
        '                .IDSOLICITUD = solic.IDSOLICITUD
        '                .IDESTABLECIMIENTO = solic.IDESTABLECIMIENTO
        '                .ESTASINCRONIZADA = 1
        '                .AUFECHAMODIFICACION = Date.Now
        '                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        '            End With
        '            mComponenteSol.ActualizarEstado(lEntidadSol)
        '        Next

        '        Dim lEntidadOPC As New OBSERVACIONPROCESOSCOMPRAS
        '        With lEntidadOPC
        '            .IDESTADO = 1
        '            '.IDPROCESO = Me.txtNoAsignado.Text
        '            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
        '            '.OBSERVACION = Me.txtComentarios.Text
        '            .ESTASINCRONIZADA = 1
        '            .AUFECHACREACION = Date.Now
        '            .AUFECHAMODIFICACION = Date.Now
        '            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        '            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        '        End With

        '        If mComponenteOPC.AgregarOBSERVACIONPROCESOSCOMPRAS(lEntidadOPC) <> 1 Then
        '            Me.lblMsgerror.Text = "Error al Guardar registro."
        '        End If

        '    Else
        '        Me.lblMsgerror.Text = "Error al Guardar registro."
        '    End If

        '    Dim mComponenteDPC As New cDETALLEPROCESOCOMPRA

        '    If mComponenteDPC.AgregarDetalleProcesoCompra(solSelect, Me.txtNoAsignado.Text, Session("IdEstablecimiento")) <> 1 Then
        '        Me.lblMsgerror.Text = "Error al Guardar registro."
        '    End If

        '    Dim mComponentePCD As New cPROCESOCOMPRAS
        '    Dim resultado As Integer

        '    resultado = mComponentePCD.generarProgramaDistribucion(Session("IdEstablecimiento"), Me.txtNoAsignado.Text, CStr(HttpContext.Current.User.Identity.Name), CStr(Date.Now), "T")

        '    Dim mComponenteEPC As New cENTREGAPROCESOCOMPRA

        '    If mComponenteEPC.AgregarEntregasProcesoCompra2(solSelect, Session("IdEstablecimiento"), Me.txtNoAsignado.Text) <> 1 Then
        '        Me.lblMsgerror.Text = "Error al Guardar registro."
        '    Else
        '        Me.lblMsgerror.Text = "El Proceso se ha iniciado satisfactoriamente"

        '        Dim directorio As String

        '        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & Me.txtNoAsignado.Text

        '        Directory.CreateDirectory(Server.MapPath(directorio))
        '        Directory.CreateDirectory(Server.MapPath(directorio & "\BASES"))
        '        Directory.CreateDirectory(Server.MapPath(directorio & "\CONTRATOS"))
        '        Directory.CreateDirectory(Server.MapPath(directorio & "\AUDIENCIAS"))
        '        Directory.CreateDirectory(Server.MapPath(directorio & "\MULTAS"))

        '        solSelect.Clear()
        '    End If

        '    Response.Redirect("~/UACI/FrmMantIniciaProcesoCompraLG.aspx", False)

        'End If

    End Sub

    'Protected Sub txtCODIGOLICITACION_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCODIGOLICITACION.TextChanged

    '    'Try
    '    '    If Me.txtCODIGOLICITACION.Text <> "" Then

    '    '        If validarExistenciaCodigoLicitacion(Me.txtCODIGOLICITACION.Text) = True Then

    '    '            RequiredFieldValidator1.ErrorMessage = "Este codigo de este proceso de compra ya existe"
    '    '            RequiredFieldValidator1.IsValid = False
    '    '        Else

    '    '        End If
    '    '    Else
    '    '        RequiredFieldValidator1.ErrorMessage = "Ingrese el codigo para este proceso de compra " '& Me.lblPrefijoBase.Text & "."
    '    '        RequiredFieldValidator1.IsValid = False
    '    '    End If
    '    'Catch ex As Exception

    '    'End Try

    'End Sub

    Private Function validarExistenciaCodigoLicitacion(ByVal CODIGOLICITACION As String) As Boolean

        Dim cProcesoCompra As New cPROCESOCOMPRAS
        Return cProcesoCompra.validarExistenciaCodigoLicitacion2(Session("IdEstablecimiento"), CODIGOLICITACION)

    End Function

    
End Class
