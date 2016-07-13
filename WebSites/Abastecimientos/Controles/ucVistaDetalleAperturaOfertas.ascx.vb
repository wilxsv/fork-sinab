Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Utils.MessageBox
Partial Class Controles_ucVistaDetalleAperturaOfertas
    Inherits System.Web.UI.UserControl

    Dim IDPROCEDIMIENTO, IDESTABLECIMIENTO As Int64
    Friend Shared PAGINA_REDIRECT As String
    Friend Shared MODO As String = "NEW"

    Public WriteOnly Property _IDPROCEDIMIENTO() As Int64
        Set(ByVal value As Int64)
            IDPROCEDIMIENTO = value
        End Set
    End Property

    Public WriteOnly Property _IDESTABLECIMIENTO() As Int64
        Set(ByVal value As Int64)
            IDESTABLECIMIENTO = value
        End Set
    End Property

    Public WriteOnly Property _PAGINA_REDIRECT() As String
        Set(ByVal value As String)
            PAGINA_REDIRECT = value
        End Set
    End Property

    Public Sub consultar()

        validarApertura()

        Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = IDPROCEDIMIENTO
        Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = IDESTABLECIMIENTO

        Me.UcVistaDetalleSolicProcesCompra1.Consultar()
        Me.UcBarraNavegacion1.PermitirConsultar = False
        Me.UcBarraNavegacion1.Navegacion = False
        Me.UcBarraNavegacion1.PermitirAgregar = False
        Me.UcBarraNavegacion1.PermitirImprimir = False

        consultarProcesoCompra()
        consultarEmpresaPresentaOferta()
        consultarEmpleados()
        verificaProcesoAperturado()

        Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
        Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False

        validarApertura()
    End Sub

    Private Sub validarApertura()

        Dim mComProcCompra As New cPROCESOCOMPRAS

        If IsDBNull(mComProcCompra.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPROCEDIMIENTO).Tables(0).Rows(0).Item("FECHAREALIZADAAPERTURA")) Then
            Me.UcBarraNavegacion1.PermitirAgregar = False
            Me.UcBarraNavegacion1.PermitirImprimir = False
            btnFinalizarApertura.Enabled = False
        Else
            Me.UcBarraNavegacion1.PermitirAgregar = False
            Me.UcBarraNavegacion1.PermitirImprimir = True
            btnFinalizarApertura.Enabled = True
            'Me.txtNoActa.ReadOnly = True
        End If


    End Sub

    Private Sub verificaProcesoAperturado()
        Dim mComProcCompra As New cPROCESOCOMPRAS

        Dim ds As Data.DataSet
        ds = mComProcCompra.ObtenerDataSetPorId(IDESTABLECIMIENTO, IDPROCEDIMIENTO)

        With ds.Tables(0).Rows(0)
            Me.txtLugarApertura.Text = .Item("LUGARAPERTURABASE")
            Try
                cpFechaRealizadoProceso.Text = Format(.Item("FECHAREALIZADAAPERTURA"), "dd/MM/yyyy")
                tpHoraRealizadoProceso.Text = Format(.Item("FECHAREALIZADAAPERTURA"), "hh:mm tt")
            Catch ex As Exception

            End Try

        End With

        Dim cRO As New cRECEPCIONOFERTAS

        Dim dsOferta As Data.DataSet
        dsOferta = cRO.ObtenerDataSet_OfertasRecibidas(IDPROCEDIMIENTO, Session("IdEstablecimiento"))

        If dsOferta.Tables(0).Rows.Count > 0 Then
            Me.dgEmpresaPresentaOferta.DataSource = dsOferta
            Me.dgEmpresaPresentaOferta.DataBind()
            Me.btnFinalizarApertura.Enabled = True
            Me.UcBarraNavegacion1.PermitirImprimir = True
        End If

    End Sub

    Private Sub consultarEmpleados()
        Dim mComponenteRAC As New cREPRESENTANTEAPERTURAPROCESOS
        Dim lEntidadRAC As New REPRESENTANTEAPERTURAPROCESOS

        Dim dsRAC As Data.DataSet
        dsRAC = mComponenteRAC.ObtenerRepresentantes(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text)

        If dsRAC.Tables(0).Rows.Count = 0 Then

        Else

            Dim dr As Data.DataRow = dsRAC.Tables(0).NewRow
            Dim i As Integer = 0
            For Each dr In dsRAC.Tables(0).Rows
                Select Case i
                    Case 0
                        Me.lblId1.Text = dr(2)
                        Me.txtNombre1.Text = dr(3)
                        Me.txtCargo1.Text = dr(4)
                    Case 1
                        Me.lblId2.Text = dr(2)
                        Me.txtNombre2.Text = dr(3)
                        Me.txtCargo2.Text = dr(4)
                    Case 2
                        Me.lblId3.Text = dr(2)
                        Me.txtNombre3.Text = dr(3)
                        Me.txtCargo3.Text = dr(4)
                    Case 3
                        Me.lblId4.Text = dr(2)
                        Me.txtNombre4.Text = dr(3)
                        Me.txtCargo4.Text = dr(4)
                End Select
                i += 1
            Next

            'Select Case iTotal

            '    Case 1
            '        Me.lblId1.Text = dsRAC.Tables(0).Rows(1).Item("iddetalle")
            '        Me.txtNombre1.Text = dsRAC.Tables(0).Rows(1).Item("Nombre")
            '        Me.txtCargo1.Text = dsRAC.Tables(0).Rows(1).Item("Cargo")
            '    Case 2
            '        Me.lblId1.Text = dsRAC.Tables(0).Rows(1).Item("iddetalle")
            '        Me.txtNombre1.Text = dsRAC.Tables(0).Rows(1).Item("Nombre")
            '        Me.txtCargo1.Text = dsRAC.Tables(0).Rows(1).Item("Cargo")
            '        Me.lblId2.Text = dsRAC.Tables(0).Rows(2).Item("IDDETALLE")
            '        Me.txtNombre2.Text = dsRAC.Tables(0).Rows(2).Item("Nombre")
            '        Me.txtCargo2.Text = dsRAC.Tables(0).Rows(2).Item("Cargo")
            '    Case 3
            '        Me.lblId1.Text = dsRAC.Tables(0).Rows(1).Item("iddetalle")
            '        Me.txtNombre1.Text = dsRAC.Tables(0).Rows(1).Item("Nombre")
            '        Me.txtCargo1.Text = dsRAC.Tables(0).Rows(1).Item("Cargo")
            '        Me.lblId2.Text = dsRAC.Tables(0).Rows(2).Item("IDDETALLE")
            '        Me.txtNombre2.Text = dsRAC.Tables(0).Rows(2).Item("Nombre")
            '        Me.txtCargo2.Text = dsRAC.Tables(0).Rows(2).Item("Cargo")
            '        Me.lblId3.Text = dsRAC.Tables(0).Rows(3).Item("IDDETALLE")
            '        Me.txtNombre3.Text = dsRAC.Tables(0).Rows(3).Item("Nombre")
            '        Me.txtCargo3.Text = dsRAC.Tables(0).Rows(3).Item("Cargo")
            '    Case 4
            '        Me.lblId1.Text = dsRAC.Tables(0).Rows(1).Item("iddetalle")
            '        Me.txtNombre1.Text = dsRAC.Tables(0).Rows(1).Item("Nombre")
            '        Me.txtCargo1.Text = dsRAC.Tables(0).Rows(1).Item("Cargo")
            '        Me.lblId2.Text = dsRAC.Tables(0).Rows(2).Item("IDDETALLE")
            '        Me.txtNombre2.Text = dsRAC.Tables(0).Rows(2).Item("Nombre")
            '        Me.txtCargo2.Text = dsRAC.Tables(0).Rows(2).Item("Cargo")
            '        Me.lblId3.Text = dsRAC.Tables(0).Rows(3).Item("IDDETALLE")
            '        Me.txtNombre3.Text = dsRAC.Tables(0).Rows(3).Item("Nombre")
            '        Me.txtCargo3.Text = dsRAC.Tables(0).Rows(3).Item("Cargo")
            '        Me.lblId4.Text = dsRAC.Tables(0).Rows(4).Item("IDDETALLE")
            '        Me.txtNombre4.Text = dsRAC.Tables(0).Rows(4).Item("Nombre")
            '        Me.txtCargo4.Text = dsRAC.Tables(0).Rows(4).Item("Cargo")
            'End Select


            'Dim dsOPC As Data.DataSet
            'dsOPC = mComponenteRAC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text, DSRAC.Tables(0).ROWS(i).ITEM("IDDETALLE"), DSRAC.Tables(0).ROWS(I).ITEM("NOMBRE"), DSRAC.TABLES(0)ROWS(I).ITEM("CARGO"))


            'If dsRAC.Tables(0).Rows.Count = 0 Then
            '    mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
            'Else
            '    mComponenteRAC.ActualizarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
            'End If

            'mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)

            'mComponenteRAC.ActualizarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)

        End If


        'Dim mComponente As New cEMPLEADOS
        ''Me.DgEmpleados.DataSource = mComponente.ObtenerDataSetporEstablecimientoDependencia(Session("IdEstablecimiento"), 2)
        ''    Me.dgEmpleados.DataBind()

        'Dim mComDependencia As New cDEPENDENCIAS
        'Dim lEntDependencia As New DEPENDENCIAS

        ''lEntDependencia = mComDependencia.ObtenerDEPENDENCIAS(2)

        ''Me.lblDependencia.Text = lEntDependencia.NOMBRE

    End Sub


    Private Sub consultarProcesoCompra()
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS

        With lEntidad
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPROCESOCOMPRA = IDPROCEDIMIENTO
        End With

        Dim ds As Data.DataSet
        ds = mComponente.recuperarDatosProcesoCompra(lEntidad)

        With ds.Tables(0).Rows(0)
            Me.lblCodigoProcesoCompra.Text = .Item("IdProcesoCompra")
            Try
                Me.lblCodigoBase.Text = .Item("CODIGOLICITACION")
                Me.lblCodigoLicitacion.Text = .Item("CODIGOLICITACION")
            Catch ex As Exception
                Me.lblCodigoBase.Text = ""
                Me.lblCodigoLicitacion.Text = ""
            End Try
            Try
                Me.txtNoActa.Text = .Item("ACTAAPERTURA")
                Me.txtNoActa.ReadOnly = True
            Catch ex As Exception
                Me.txtNoActa.ReadOnly = False
                Me.txtNoActa.Text = ""
            End Try

            Me.lblFechaPublicacion.Text = CType(.Item("FECHAPUBLICACION"), String)
            Me.lblFechaIniciadoProceso.Text = CType(.Item("FECHAINICIOPROCESOCOMPRA"), String)
            Me.cpFechaRecepcionOferta.Text =(CDate(.Item("FECHAHORAINICIORECEPCION"))).ToShortDateString()
            Me.tpHoraRecepcionOferta.Text = String.Format("{0:hh:mm:ss tt}",CDate(.Item("FECHAHORAINICIORECEPCION"))) 
            Me.txtObservacionesActa.Text = .Item("OBSERVACIONESACTA").ToString
            Try
                Me.lblTituloLicitacion.Text = CType(.Item("TITULOLICITACION"), String)
            Catch ex As Exception
                Me.lblTituloLicitacion.Text = ""
            End Try
        End With
    End Sub

    Private Sub consultarEmpresaPresentaOferta()
        Dim mComponenteRO As New cRECEPCIONOFERTAS
        Dim ds As Data.DataSet
        ds = mComponenteRO.ObtenerDataSet_OfertasRecibidas(Me.lblCodigoProcesoCompra.Text, Session("IdEstablecimiento"))
        If ds.Tables(0).Rows.Count > 0 Then
            Me.dgEmpresaPresentaOferta.DataSource = ds
            Me.dgEmpresaPresentaOferta.DataBind()
        End If
    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        Response.Redirect(PAGINA_REDIRECT)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcBarraNavegacion2.Navegacion = False
        Me.UcBarraNavegacion2.PermitirAgregar = True
        Me.UcBarraNavegacion2.PermitirConsultar = False
        Me.UcBarraNavegacion2.PermitirEditar = False
        Me.UcBarraNavegacion2.HabilitarEdicion(False)
        Me.UcBarraNavegacion2.PermitirGuardar = False
        Me.UcBarraNavegacion2.PermitirImprimir = False
        If IsPostBack Then
            If ConfirmTarget = "FINAPERTURA" Then ProcesarConfirmacion()
            If ConfirmTarget = "FINALIZAR" Then Response.Redirect("~/UACI/FrmMantAperturaOferta.aspx")
        End If
    End Sub

    Private Sub ProcesarConfirmacion()
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS

        Dim mComProcesoCompra As New cPROCESOCOMPRAS
        Dim lEntProcesoCompra As New PROCESOCOMPRAS

        'Valida que no haya presentado ofertas y quedan desiertos
        verificarDesiertos()

        'Buscar productos de proveedores antes de finalizar

        lEntProcesoCompra = mComProcesoCompra.ObtenerPROCESOCOMPRAS(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text)

        Dim fechaApertura As String

        fechaApertura = DateTime.Now 'Format(cpFechaRealizadoProceso.SelectedDate, "dd/MM/yyyy") & " " & Format(tpHoraRealizadoProceso.SelectedTime, "HH:mm")

        'If CDate(fechaApertura) >= CDate(lEntProcesoCompra.FECHAHORAFINRECEPCION) Then
        'Ingresa valores en PROCESOCOMPRAS
        With lEntidad
            .FECHAREALIZADAAPERTURA = DateTime.Now 'Me.cpFechaRealizadoProceso.SelectedDate & " " & Me.tpHoraRealizadoProceso.SelectedTime.TimeOfDay.ToString
            .LUGARAPERTURABASE = Me.txtLugarApertura.Text
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPROCESOCOMPRA = Me.lblCodigoProcesoCompra.Text
            .IDESTADOPROCESOCOMPRA = 5 'pasa a consolidación de ofertas
        End With
        Try
            mComponente.ActualizarPROCESOCOMPRASAperturaBase(lEntidad)
            Me.UcBarraNavegacion1.PermitirGuardar = False
            AlertSubmit("La apertura de ofertas ha finalizado satisfactoriamente", "FINALIZAR")
        Catch ex As Exception
            Alert("No se pudo finalizar Apertura de Oferta. Error: " & ex.Message)
        End Try

        'Me.MsgBox1.ShowAlert("La apertura de ofertas ha finalizado satisfactoriamente", "FINALIZAR", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

    End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
    '    Select Case e.Key
    '        Case Is = "FINAPERTURA"
    '            Dim mComponente As New cPROCESOCOMPRAS
    '            Dim lEntidad As New PROCESOCOMPRAS

    '            Dim mComProcesoCompra As New cPROCESOCOMPRAS
    '            Dim lEntProcesoCompra As New PROCESOCOMPRAS

    '            'Valida que no haya presentado ofertas y quedan desiertos
    '            verificarDesiertos()

    '            'Buscar productos de proveedores antes de finalizar

    '            lEntProcesoCompra = mComProcesoCompra.ObtenerPROCESOCOMPRAS(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text)

    '            Dim fechaApertura As String

    '            fechaApertura = DateTime.Now 'Format(cpFechaRealizadoProceso.SelectedDate, "dd/MM/yyyy") & " " & Format(tpHoraRealizadoProceso.SelectedTime, "HH:mm")

    '            'If CDate(fechaApertura) >= CDate(lEntProcesoCompra.FECHAHORAFINRECEPCION) Then
    '            'Ingresa valores en PROCESOCOMPRAS
    '            With lEntidad
    '                .FECHAREALIZADAAPERTURA = DateTime.Now 'Me.cpFechaRealizadoProceso.SelectedDate & " " & Me.tpHoraRealizadoProceso.SelectedTime.TimeOfDay.ToString
    '                .LUGARAPERTURABASE = Me.txtLugarApertura.Text
    '                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '                .IDPROCESOCOMPRA = Me.lblCodigoProcesoCompra.Text
    '                .IDESTADOPROCESOCOMPRA = 5 'pasa a consolidación de ofertas
    '            End With
    '            mComponente.ActualizarPROCESOCOMPRASAperturaBase(lEntidad)
    '            Me.UcBarraNavegacion1.PermitirGuardar = False
    '            Alert("La apertura de ofertas ha finalizado satisfactoriamente", "FINALIZAR")
    '            'Me.MsgBox1.ShowAlert("La apertura de ofertas ha finalizado satisfactoriamente", "FINALIZAR", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
    '            Response.Redirect("~/UACI/FrmMantAperturaOferta.aspx")
    '    End Select
    'End Sub

    Protected Sub dgEmpresaPresentaOferta_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgEmpresaPresentaOferta.ItemCommand

        Dim mComponenteOPC As New cOFERTAPROCESOCOMPRA
        Dim lEntidadOPC As New OFERTAPROCESOCOMPRA

        If e.CommandName = "Update" Then
            Dim c, d As Decimal
            Dim a As String = e.Item.Cells(4).Text
            Dim b As String = CType(e.Item.Cells(5).Controls(1), System.Web.UI.WebControls.TextBox).Text
            c = CType(e.Item.Cells(6).Controls(3), eWorld.UI.NumericBox).Text
            d = CType(e.Item.Cells(7).Controls(3), eWorld.UI.NumericBox).Text

            If c < d Then
                Alert("El monto de la garantía no debe ser mayor que el monto de la oferta", "Error")
                ' Me.MsgBox1.ShowAlert("El monto de la garantía no debe ser mayor que el monto de la oferta", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
            Else

                If b = "" Then
                    Alert("Debe Ingresar Nombre de Representante o Ausente sino esta presente", "Error")
                    'Me.MsgBox1.ShowAlert("Debe Ingresar Nombre de Representante o Ausente sino esta presente", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)

                End If

                'Me.dgEmpresaPresentaOferta.SelectedItem.Cells(9).Text = 1
                'If Me.ddlEstadoOferta.SelectedValue = 1 Then
                'Me.dgEmpresaPresentaOferta.SelectedItem.Cells(9).Text = Me.txtObservaciones.Text
                'Else
                'Me.dgEmpresaPresentaOferta.SelectedItem.Cells(10).Text = ""
                'End If
                'Me.txtObservaciones.Visible = False
                'Me.lblObservaciones.Visible = False
                'Me.ddlEstadoOferta.SelectedIndex = 1

                With lEntidadOPC
                    '.NOMBREREPRESENTANTE = Me.dgEmpresaPresentaOferta.Items(a.ItemIndex).Cells(5).Text
                    .NOMBREREPRESENTANTE = b
                    '.MONTOGARANTIA = Me.dgEmpresaPresentaOferta.Items(a.ItemIndex).Cells(7).Text
                    .MONTOOFERTA = c
                    .MONTOGARANTIA = d
                    '.MONTOOFERTA = Me.dgEmpresaPresentaOferta.Items(a.ItemIndex).Cells(6).Text

                    '.IDPROVEEDOR = Me.dgEmpresaPresentaOferta.Items(a.ItemIndex).Cells(4).Text
                    .IDPROVEEDOR = a
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    .IDPROCESOCOMPRA = Me.lblCodigoProcesoCompra.Text
                    '.IDPROVEEDOR = Me.dgEmpresaPresentaOferta.Items(a.ItemIndex).Cells(4).Text

                    .ESTAHABILITADO = 1
                    .OBSERVACION = ""
                    .ESTASINCRONIZADA = 0
                End With

                Dim dsOPC As Data.DataSet
                dsOPC = mComponenteOPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text, a)

                If dsOPC.Tables(0).Rows.Count = 0 Then
                    lEntidadOPC.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    lEntidadOPC.AUFECHACREACION = Now

                    mComponenteOPC.AgregarOFERTAPROCESOCOMPRA(lEntidadOPC)
                Else
                    lEntidadOPC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    lEntidadOPC.AUFECHAMODIFICACION = Now

                    mComponenteOPC.ActualizarMontos(lEntidadOPC)
                End If

            End If
        End If

    End Sub

    'Protected Sub dgEmpresaPresentaOferta_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgEmpresaPresentaOferta.PageIndexChanged
    '    Me.dgEmpresaPresentaOferta.CurrentPageIndex = e.NewPageIndex

    '    Dim mComponenteRO As New cRECEPCIONOFERTAS
    '    Dim lEntidadRO As New RECEPCIONOFERTAS
    '    Dim dsOferta As Data.DataSet
    '    dsOferta = mComponenteRO.ObtenerDataSet_OfertasRecibidas(Me.lblCodigoProcesoCompra.Text, Session("IdEstablecimiento"))
    '    Me.dgEmpresaPresentaOferta.DataSource = dsOferta
    '    Me.dgEmpresaPresentaOferta.DataBind()

    'End Sub

    'Protected Sub dgEmpresaPresentaOferta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEmpresaPresentaOferta.SelectedIndexChanged



    '    Me.dgEmpresaPresentaOferta.SelectedItem.Cells(8).Visible = True



    '    'Me.txtNombreEmpresa.Text = Me.dgEmpresaPresentaOferta.SelectedItem.Cells(1).Text
    '    'btnActualizarDatos.Visible = True
    '    'dgEmpresaPresentaOferta_ItemCommand.visible = True


    '    If Me.dgEmpresaPresentaOferta.SelectedItem.Cells(5).Text = " " Then

    '        Me.MsgBox1.ShowAlert("Debe Ingresar Nombre de Representante o Ausente sino esta presente", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
    '    Else

    '        'txtNombreRepresentante.Text = Me.dgEmpresaPresentaOferta.SelectedItem.Cells(5).Text
    '    End If
    '    If Me.dgEmpresaPresentaOferta.SelectedItem.Cells(6).Text = "&nbsp;" Then

    '        Me.MsgBox1.ShowAlert("Debe Ingresar Monto de Oferta", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)

    '        'Me.txtMontoOferta.Text = ""


    '        'Else
    '        '    Me.txtMontoOferta.Text = Me.dgEmpresaPresentaOferta.SelectedItem.Cells(6).Text
    '        'End If

    '        'Me.txtMontoGarantia.Text = IIf(Me.dgEmpresaPresentaOferta.SelectedItem.Cells(7).Text = "&nbsp;", "", Me.dgEmpresaPresentaOferta.SelectedItem.Cells(7).Text)

    '        ''Me.ddlEstadoOferta.SelectedValue = IIf(Me.dgEmpresaPresentaOferta.SelectedItem.Cells(8).Text = "&nbsp;", 1, Me.dgEmpresaPresentaOferta.SelectedItem.Cells(8).Text)

    '        'Me.ddlEstadoOferta.SelectedValue = IIf(Me.dgEmpresaPresentaOferta.SelectedItem.Cells(9).Text = "&nbsp;", 1, Me.dgEmpresaPresentaOferta.SelectedItem.Cells(8).Text)
    '        'If Me.ddlEstadoOferta.SelectedValue = 0 Then
    '        '    Me.txtObservaciones.Visible = True
    '        '    Me.lblObservaciones.Visible = True
    '    End If
    '    'Me.txtObservaciones.Text = IIf(Me.dgEmpresaPresentaOferta.SelectedItem.Cells(10).Text = "&nbsp;", "", Me.dgEmpresaPresentaOferta.SelectedItem.Cells(9).Text)
    'End Sub


    'Protected Sub UcBarraNavegacion2_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion2.Agregar

    'End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS

        'Valida fecha de apertura contra fecha de fin de recepción de ofertas

        Dim mComProcesoCompra As New cPROCESOCOMPRAS
        Dim lEntProcesoCompra As New PROCESOCOMPRAS

        'For Each a As DataGridItem In Me.dgEmpresaPresentaOferta.Items

        '    If Not IsNumeric(Me.dgEmpresaPresentaOferta.Items(a.ItemIndex).Cells(8).Text) Then
        '        Me.MsgBox1.ShowAlert("Debe ingresar los montos de oferta y garantia para todos los proveedores antes de proceder a guardar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        '        Exit Sub
        '    End If
        'Next


        lEntProcesoCompra = mComProcesoCompra.ObtenerPROCESOCOMPRAS(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text)

        Dim fechaApertura As String
        Dim fechaAperturaInicio As String
        Dim fechaAperturaFin As String

        fechaApertura =cpFechaRealizadoProceso.Text & " " & tpHoraRealizadoProceso.Text

        fechaAperturaInicio = lEntProcesoCompra.FECHAHORAINICIOAPERTURA
        fechaAperturaFin = lEntProcesoCompra.FECHAHORAFINAPERTURA

        If CDate(fechaApertura) < CDate(fechaAperturaInicio) Then
            Alert("La fecha y hora de inicio apertura debe estar en el siguiente rango: " & fechaAperturaInicio & " y " & fechaAperturaFin & ", verifique sus datos", "FECHA")
            'Me.MsgBox1.ShowAlert("La fecha y hora de inicio apertura debe estar en el siguiente rango: " & fechaAperturaInicio & " y " & fechaAperturaFin & ", verifique sus datos", "FECHA", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
            Exit Sub
        End If

        'If CDate(fechaApertura) > CDate(fechaAperturaFin) Then
        '    Me.MsgBox1.ShowAlert("La fecha y hora de fin apertura debe estar en el siguiente rango: " & fechaAperturaInicio & " y " & fechaAperturaFin & ", verifique sus datos", "FECHA", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        '    Exit Sub
        'End If

        If validaActaApertura() = True Then
            If CDate(fechaApertura) >= CDate(lEntProcesoCompra.FECHAHORAFINRECEPCION) Then
                'Ingresa valores en PROCESOCOMPRAS
                With lEntidad
                    .ACTAAPERTURA = Me.txtNoActa.Text
                    .FECHAREALIZADAAPERTURA = Cdate(Me.cpFechaRealizadoProceso.Text & " " & Me.tpHoraRealizadoProceso.Text)
                    .LUGARAPERTURABASE = Me.txtLugarApertura.Text
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    .IDPROCESOCOMPRA = Me.lblCodigoProcesoCompra.Text
                    .IDESTADOPROCESOCOMPRA = 3 'Permanece en Aperturar ofertas.
                    .OBSERVACIONESACTA = Me.txtObservacionesActa.Text
                End With
                If mComponente.ActualizarPROCESOCOMPRASAperturaBase(lEntidad) = 1 Then
                    Me.txtNoActa.ReadOnly = True
                    Dim mComponenteOPC As New cOFERTAPROCESOCOMPRA
                    Dim lEntidadOPC As New OFERTAPROCESOCOMPRA
                    'Inserta valores en OFERTAPROCESOCOMPRA
                    Me.UcBarraNavegacion1.PermitirAgregar = False
                    'dgProveedorRetiraBase

                    If Me.dgEmpresaPresentaOferta.Items.Count > 0 Then
                        For Each a As DataGridItem In Me.dgEmpresaPresentaOferta.Items


                            'If Not IsNumeric(Me.dgEmpresaPresentaOferta.Items(a.ItemIndex).Cells(6).Text) Or Not IsNumeric(Me.dgEmpresaPresentaOferta.Items(a.ItemIndex).Cells(7).Text) Then
                            '    Me.MsgBox1.ShowAlert("Debe ingresar los montos de oferta y garantia para todos los proveedores antes de proceder a guardar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                            '    Exit Sub
                            'End If


                        Next




                        'Inserta valores en REPRESENTANTEAPERTURAPROCESOS

                        Dim mComponenteRAC As New cREPRESENTANTEAPERTURAPROCESOS
                        Dim lEntidadRAC As New REPRESENTANTEAPERTURAPROCESOS

                        Dim dsAP As Data.DataSet
                        dsAP = mComponenteRAC.ObtenerRepresentantes(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text)

                        If dsAP.Tables(0).Rows.Count = 0 Then

                            'NO EXISTEN REGISTROS EN LA TABLA
                            lEntidadRAC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            lEntidadRAC.IDPROCESOCOMPRA = Me.lblCodigoProcesoCompra.Text

                            If Not Me.txtNombre1.Text = Nothing Then
                                lEntidadRAC.IDDETALLE = 1
                                lEntidadRAC.NOMBRE = Me.txtNombre1.Text
                                lEntidadRAC.CARGO = Me.txtCargo1.Text
                                mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                            End If

                            If Not Me.txtNombre2.Text = Nothing Then
                                lEntidadRAC.IDDETALLE = 2
                                lEntidadRAC.NOMBRE = Me.txtNombre2.Text
                                lEntidadRAC.CARGO = Me.txtCargo2.Text
                                mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                            End If

                            If Not Me.txtNombre3.Text = Nothing Then
                                lEntidadRAC.IDDETALLE = 3
                                lEntidadRAC.NOMBRE = Me.txtNombre3.Text
                                lEntidadRAC.CARGO = Me.txtCargo3.Text
                                mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                            End If

                            If Not Me.txtNombre4.Text = Nothing Then
                                lEntidadRAC.IDDETALLE = 4
                                lEntidadRAC.NOMBRE = Me.txtNombre4.Text
                                lEntidadRAC.CARGO = Me.txtCargo4.Text
                                mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                            End If

                        Else ' EXISTEN REGISTROS EN LA TABLA
                            mComponenteRAC.EliminarTodos(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text)

                            lEntidadRAC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            lEntidadRAC.IDPROCESOCOMPRA = Me.lblCodigoProcesoCompra.Text

                            If Not Me.txtNombre1.Text = Nothing Then
                                lEntidadRAC.IDDETALLE = 1
                                lEntidadRAC.NOMBRE = Me.txtNombre1.Text
                                lEntidadRAC.CARGO = Me.txtCargo1.Text
                                mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                            End If

                            If Not Me.txtNombre2.Text = Nothing Then
                                lEntidadRAC.IDDETALLE = 2
                                lEntidadRAC.NOMBRE = Me.txtNombre2.Text
                                lEntidadRAC.CARGO = Me.txtCargo2.Text
                                mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                            End If

                            If Not Me.txtNombre3.Text = Nothing Then
                                lEntidadRAC.IDDETALLE = 3
                                lEntidadRAC.NOMBRE = Me.txtNombre3.Text
                                lEntidadRAC.CARGO = Me.txtCargo3.Text
                                mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                            End If

                            If Not Me.txtNombre4.Text = Nothing Then
                                lEntidadRAC.IDDETALLE = 4
                                lEntidadRAC.NOMBRE = Me.txtNombre4.Text
                                lEntidadRAC.CARGO = Me.txtCargo4.Text
                                mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                            End If

                        End If

                        'If dsAP.Tables(0).Rows.Count = 0 Then
                        '    Dim i As Integer

                        '    If Me.txtNombre1.Text = "" And Me.txtNombre2.Text = "" And Me.txtNombre3.Text = "" And Me.txtNombre4.Text = "" Then


                        '    End If


                        '    For i = 1 To 4
                        '        lEntidadRAC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        '        lEntidadRAC.IdProcesoCompra = Me.lblCodigoProcesoCompra.Text
                        '        lEntidadRAC.IDDETALLE = i
                        '        lEntidadRAC.NOMBRE = Me.txtNombre1.Text
                        '    Next
                        'End If

                        'Dim chk As New CheckBox
                        'Dim aSeleccionado As Boolean = False
                        'If MODO = "EDIT" Then
                        '    mComponenteRAC.EliminarTodos(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text)
                        '    mComponenteRAC.ActualizarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                        'End If



                        ''For Each a As DataGridItem In Me.dgEmpleados.Items
                        ''    chk = a.FindControl("chkSeleccionada")
                        ''    If chk.Checked = True Then
                        ''        Me.lblMsg.Text = ""
                        ''        aSeleccionado = True


                        'With lEntidadRAC

                        '    '    .IDDETALLE = CInt(Me.dgEmpleados.Items(a.ItemIndex).Cells(3).Text)
                        '    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        '    .IdProcesoCompra = Me.lblCodigoProcesoCompra.Text
                        'End With

                        'If Not Me.txtNombre1.Text = Nothing Then
                        '    lEntidadRAC.IDDETALLE = Me.lblId1.Text
                        '    lEntidadRAC.NOMBRE = Me.txtNombre1.Text
                        '    lEntidadRAC.CARGO = Me.txtCargo1.Text
                        '    mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                        'End If

                        'If Not Me.txtNombre2.Text = Nothing Then
                        '    lEntidadRAC.IDDETALLE = Me.lblId2.Text
                        '    lEntidadRAC.NOMBRE = Me.txtNombre2.Text
                        '    lEntidadRAC.CARGO = Me.txtCargo2.Text
                        '    mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                        'End If

                        'If Not Me.txtNombre3.Text = Nothing Then
                        '    lEntidadRAC.IDDETALLE = Me.lblId3.Text
                        '    lEntidadRAC.NOMBRE = Me.txtNombre3.Text
                        '    lEntidadRAC.CARGO = Me.txtCargo3.Text
                        '    mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                        'End If

                        'If Not Me.txtNombre4.Text = Nothing Then
                        '    lEntidadRAC.IDDETALLE = Me.lblId4.Text
                        '    lEntidadRAC.NOMBRE = Me.txtNombre4.Text
                        '    lEntidadRAC.CARGO = Me.txtCargo4.Text
                        '    mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                        'End If


                        'mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                        '    End If
                        'Next
                        'If aSeleccionado <> True Then
                        '    Me.lblMsg.Text = "Debe seleccionar un empleado"
                        'Else
                        If Me.lblMsg.Text = "El registro se ha guardado satisfactoriamente, Imprima el Acta de Recepción y Apertura" Then
                            Me.UcBarraNavegacion1.PermitirGuardar = False
                            Me.UcBarraNavegacion2.PermitirAgregar = False
                            Me.UcBarraNavegacion1.PermitirImprimir = True
                        End If
                    End If
                    Me.btnFinalizarApertura.Enabled = True

                Else
                    Alert("Debe ingresar los montos por proveedor", "Error")
                    'Me.MsgBox1.ShowAlert("Debe ingresar los montos por proveedor", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)

                End If



            Else
                Alert("La fecha de apertura debe ser mayor o igual a la fecha de fin de recepción", "VALIDAR FECHA")
                'Me.MsgBox1.ShowAlert("La fecha de apertura debe ser mayor o igual a la fecha de fin de recepción", "VALIDAFECHA", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
            End If
        End If

    End Sub

    Private Function validaActaApertura() As Boolean

        If Me.txtNoActa.ReadOnly = False Then
            Dim mComProcesoCompra As New cPROCESOCOMPRAS
            Dim ds As Data.DataSet

            ds = mComProcesoCompra.ObtenerNoActaApertura(Session("IdEstablecimiento"), Me.txtNoActa.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                Alert("El número de acta ya existe", "Error")
                ' Me.MsgBox1.ShowAlert("El número de acta ya existe", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If

    End Function

    Private Sub verificarDesiertos()
        Dim mComponente As New cPROCESOCOMPRAS
        mComponente.verificarDesiertos(Session("IdEstablecimiento"), Me.lblCodigoProcesoCompra.Text)
    End Sub

    Protected Sub UcBarraNavegacion1_Imprimir(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Imprimir
        'Response.Write("<script language=javascript>")
        'Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/FrmRptActaAperturaOferta.aspx?idProc=" & Me.lblCodigoProcesoCompra.Text & "&noACTA=" & Me.txtNoActa.Text & " ');")
        'Response.Write("</script>")
        SINAB_Utils.Utils.MostrarVentana(String.Format("/Reportes/FrmRptActaAperturaOferta.aspx?idProc={0}&noACTA={1}", Me.lblCodigoProcesoCompra.Text, Me.txtNoActa.Text))
    End Sub

    Protected Sub btnFinalizarApertura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalizarApertura.Click

        'Me.MsgBox1.ShowConfirm("Para finalizar la apertura de oferta debera haber ingresado los productos de la oferta para cada proveedor, es importante que verifique el ingreso de los productos para los proveedores antes de finalizar la apertura de ofertas. ¿Desea finalizar la apertura de oferta?", "FINAPERTURA", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        Confirm("Para finalizar la apertura de oferta debera haber ingresado los productos de la oferta para cada proveedor, es importante que verifique el ingreso de los productos para los proveedores antes de finalizar la apertura de ofertas. ¿Desea finalizar la apertura de oferta?", "FINAPERTURA", OptionPostBack.YesPostBack)
        UcBarraNavegacion1_Imprimir(sender, e)

    End Sub

    

    Protected Sub ibtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnGuardar.Click
        UcBarraNavegacion1_Guardar(sender, e)

    End Sub

    Protected Sub UcBarraNavegacion1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Load

    End Sub

    Protected Sub ibtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnImprimir.Click
        UcBarraNavegacion1_Imprimir(sender, e)
    End Sub

   
  
End Class
