Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.IO
Imports System.ServiceModel.Channels
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils

Partial Class Controles_ucGenerarBases
    Inherits System.Web.UI.UserControl

    Private _IDPLANTILLASEL As Integer
    Private _DOCJURIDICOSEL As New ArrayList
    Private _MODO As String = "NEW"
    Private _TITULOLICITACION, _CODIGOLICITACION As String
    Private _IDPROCESOCOMPRA As Integer
    Private _IDPLANTILLA As Integer
    Private _CORRECTO As Integer
    Private _CODIGOFUENTE As String
    Private _CODIGOLICITA As String
    Private _IDMODALIDADCOMPRA As Integer
    Private _IDTIPOCOMPRA As Integer

    Friend Shared dsEvalTec As New Data.DataSet

    Private cPC As New cPROCESOCOMPRAS

#Region " Propiedades "

    Public Property IDPLANTILLASEL() As Integer
        Get
            Return _IDPLANTILLASEL
        End Get
        Set(ByVal value As Integer)
            _IDPLANTILLASEL = value
            If Not Me.ViewState("IDPLANTILLASEL") Is Nothing Then Me.ViewState.Remove("IDPLANTILLASEL")
            Me.ViewState.Add("IDPLANTILLASEL", value)
        End Set
    End Property
    Public Property IDTIPOCOMPRA() As Integer
        Get
            Return _IDTIPOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDTIPOCOMPRA = value
            If Not Me.ViewState("IDTIPOCOMPRA") Is Nothing Then Me.ViewState.Remove("IDTIPOCOMPRA")
            Me.ViewState.Add("IDTIPOCOMPRA", value)
        End Set
    End Property
    Public Property DOCJURIDICOSEL() As ArrayList
        Get
            Return _DOCJURIDICOSEL
        End Get
        Set(ByVal value As ArrayList)
            _DOCJURIDICOSEL = value
            If Not Me.ViewState("DOCJURIDICOSEL") Is Nothing Then Me.ViewState.Remove("DOCJURIDICOSEL")
            Me.ViewState.Add("DOCJURIDICOSEL", value)
        End Set
    End Property

    Public Property MODO() As String
        Get
            Return _MODO
        End Get
        Set(ByVal value As String)
            _MODO = value
            If Not Me.ViewState("MODO") Is Nothing Then Me.ViewState.Remove("MODO")
            Me.ViewState.Add("MODO", value)
        End Set
    End Property

    Public Property TITULOLICITACION() As String
        Get
            Return _TITULOLICITACION
        End Get
        Set(ByVal value As String)
            _TITULOLICITACION = value
            If Not Me.ViewState("TITULOLICITACION") Is Nothing Then Me.ViewState.Remove("TITULOLICITACION")
            Me.ViewState.Add("TITULOLICITACION", value)
        End Set
    End Property

    Public Property CODIGOLICITACION() As String
        Get
            Return _CODIGOLICITACION
        End Get
        Set(ByVal value As String)
            _CODIGOLICITACION = value
            If Not Me.ViewState("CODIGOLICITACION") Is Nothing Then Me.ViewState.Remove("CODIGOLICITACION")
            Me.ViewState.Add("CODIGOLICITACION", value)
            cbl11.CodigoLicita = CType(ViewState("CODIGOLICITACION"), String)
        End Set
    End Property

    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDPROCESOCOMPRA = value
            Me.ViewState.Add("IdProcesoCompra", value)
        End Set
    End Property

    Public Property IDPLANTILLA() As Integer
        Get
            Return _IDPLANTILLA
        End Get
        Set(ByVal value As Integer)
            _IDPLANTILLA = value
            If Not Me.ViewState("IDPLANTILLA") Is Nothing Then Me.ViewState.Remove("IDPLANTILLA")
            Me.ViewState.Add("IDPLANTILLA", value)
        End Set
    End Property

    Public Property CORRECTO() As Integer
        Get
            Return _CORRECTO
        End Get
        Set(ByVal value As Integer)
            _CORRECTO = value
            If Not Me.ViewState("CORRECTO") Is Nothing Then Me.ViewState.Remove("CORRECTO")
            Me.ViewState.Add("CORRECTO", value)
        End Set
    End Property

    Public Property CODIGOFUENTE() As String
        Get
            Return _CODIGOFUENTE
        End Get
        Set(ByVal value As String)
            _CODIGOFUENTE = value
            If Not Me.ViewState("CODIGOFUENTE") Is Nothing Then Me.ViewState.Remove("CODIGOFUENTE")
            Me.ViewState.Add("CODIGOFUENTE", value)
        End Set
    End Property

    Public Property CODIGOLICITA() As String
        Get
            Return _CODIGOLICITA
        End Get
        Set(ByVal value As String)
            _CODIGOLICITA = value
            If Not Me.ViewState("CODIGOLICITA") Is Nothing Then Me.ViewState.Remove("CODIGOLICITA")
            Me.ViewState.Add("CODIGOLICITA", value)
        End Set
    End Property

    Public Property IDMODALIDADCOMPRA() As Integer
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDMODALIDADCOMPRA = value
            If Not Me.ViewState("IDMODALIDADCOMPRA") Is Nothing Then Me.ViewState.Remove("IDMODALIDADCOMPRA")
            Me.ViewState.Add("IDMODALIDADCOMPRA", value)
        End Set
    End Property

#End Region

    Public Sub VpnlPaso1(ByVal ESTADO As Boolean)
        If Not IsPostBack Then
            Me.pnlPaso1.Visible = ESTADO
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("IDPLANTILLASEL") Is Nothing Then Me._IDPLANTILLASEL = CType(Me.ViewState("IDPLANTILLASEL"), Integer)
            If Not Me.ViewState("DOCJURIDICOSEL") Is Nothing Then Me._DOCJURIDICOSEL = Me.ViewState("DOCJURIDICOSEL")
            If Not Me.ViewState("MODO") Is Nothing Then Me._MODO = Me.ViewState("MODO").ToString()
            If Not Me.ViewState("TITULOLICITACION") Is Nothing Then Me._TITULOLICITACION = Me.ViewState("TITULOLICITACION")
            If Not Me.ViewState("IDPLANTILLA") Is Nothing Then Me._IDPLANTILLA = CType(Me.ViewState("IDPLANTILLA"), Integer)
            If Not Me.ViewState("CORRECTO") Is Nothing Then Me._CORRECTO = CType(Me.ViewState("CORRECTO"), Integer)
            If Not Me.ViewState("CODIGOFUENTE") Is Nothing Then Me._CODIGOFUENTE = Me.ViewState("CODIGOFUENTE").ToString()
            If Not Me.ViewState("CODIGOLICITA") Is Nothing Then Me._CODIGOLICITA = Me.ViewState("CODIGOLICITA").ToString()
            If Not Me.ViewState("IDMODALIDADCOMPRA") Is Nothing Then Me._IDMODALIDADCOMPRA = CType(Me.ViewState("IDMODALIDADCOMPRA"), Integer)
            If Not Me.ViewState("IDTIPOCOMPRA") Is Nothing Then Me._IDTIPOCOMPRA = CType(Me.ViewState("IDTIPOCOMPRA"), Integer)

            If SINAB_Utils.MessageBox.ConfirmTarget = "LIBERAR BASE" Then ConfirmarLiberar()
            If SINAB_Utils.MessageBox.ConfirmTarget = "Modificado" Then Response.Redirect("~/UACI/FrmGenerarBases.aspx")
        End If

        Dim clsDetProcesoCompra As New cDETALLEPROCESOCOMPRA
        Dim intTipoSuministro As Integer
        intTipoSuministro = clsDetProcesoCompra.EsCompraMedicamentos(_idEstablecimiento, IDPROCESOCOMPRA)
        If intTipoSuministro = 0 Then
            Me.Panel5.Visible = False
        End If
    End Sub

    Public Sub CargaDatos()
        validacionEstadoProceso()
        IDPLANTILLASEL = IDPLANTILLA

        If Not IsPostBack Then
            '  Response.Write("IDTIPOCOMPRA: " & Session("IDTIPOCOMPRA"))
            IDTIPOCOMPRA = Session("IDTIPOCOMPRA")
            MODO = Request.QueryString("mod")

            Me.DdlESTABLECIMIENTOS1.Recuperar()
            Me.DdlESTABLECIMIENTOS1.SelectedValue = _idEstablecimiento
            buscarDireccionMunicipio()

            buscarPrefijoBase()

            Me.ddlIDTITULAR.RecuperarNombre(_idEstablecimiento, 1)
            Me.DdlMUNICIPIOS1.RecuperarNombreMunicipio()
            Me.DdlMUNICIPIOS2.RecuperarNombreMunicipio()
            obtenerCargoEmpleado()

            cbl5.IdProcesoCompra = IDPROCESOCOMPRA
            cbl5.CargarDocumentos(MODO)

            cbl6.IdProcesoCompra = IDPROCESOCOMPRA
            cbl6.IdEstablecimiento = _idEstablecimiento
            cbl6.ObtenerAspectoTecnico(MODO)

            obtenerEvaluacionTecnica()
            obtenerEvaluacionFinanciera()

            cbl9.IdProcesoCompra = IDPROCESOCOMPRA
            cbl9.ObtenerTotalsolicitud()
            cbl9.ObtenerProductos()

            cbl11.IdProcesoCompra = IDPROCESOCOMPRA
            cbl11.FechaFirma = DateTime.Now.ToShortDateString


            obtenerLugarPlazoEntrega()

            If Request.QueryString("mod") = "EDIT" Then
                cargarDatos()
                cbl11.VerGenerarDocumento = True
            ElseIf Request.QueryString("mod") = "CONS" Then
                cargarDatos()
                Me.dgEvaluacionTecnica.Enabled = False

                cbl5.HabilitarPersonaNaturalNacional = False
                cbl5.HabilitarPersonaJuridicaNacional = False

                cbl6.HabilitarAspectos = False

                cbl11.VerGenerarDocumento = True
                cbl11.VerLiberarBase = False
                lnkGuardar.Visible = False
                DESHABILITAR()
            End If

        End If

    End Sub
    Protected Sub ConfirmarLiberar()

        'MessageBox.Confirm("Una vez que haya liberado la base no podrá realizar modificaciones en los registros de la base de datos, ¿desea liberar la base de licitación?", "CONFIRMA LIBERABASE")
        Dim lEntidad As New PROCESOCOMPRAS
        With lEntidad
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .IDESTABLECIMIENTO = _idEstablecimiento
            .IDESTADOPROCESOCOMPRA = 2
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .AUFECHAMODIFICACION = Now
            .ESTASINCRONIZADA = 0
            .FECHAELABORACIONBASE = Now
        End With

        If cPC.ActualizarEstado(lEntidad, 0) = 1 Then
            lnkGuardar.Visible = False
            SINAB_Utils.MessageBox.AlertSubmit("El registro se modificó satisfactoriamente", "Modificado")
            'Me.MsgBox1.ShowAlert("El registro se modificó satisfactoriamente", "OK", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            SINAB_Utils.MessageBox.Alert("Error en la actualización, Consulte con su administrador", "Error")
            ' Me.MsgBox1.ShowAlert("Error en la actualización, Consulte con su administrador", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If
    End Sub
    Private Sub validacionEstadoProceso()

        Dim directorio As String
        Dim base As String

        directorio = "EST" & _idEstablecimiento & "_PROC" & IDPROCESOCOMPRA
        CODIGOLICITA = Replace(CODIGOLICITACION, "/", "-")
        CODIGOLICITA = Replace(CODIGOLICITA, " ", "_")
        Session("IdProcesoCompra") = IDPROCESOCOMPRA
        base = "B" & CODIGOLICITA & ".htm"

        If File.Exists(Server.MapPath(directorio & "\BASES\" & base)) Then
            Me.paso1.Visible = True
            Me.paso2.Visible = True
            Me.paso3.Visible = True
            Me.paso4.Visible = True
            Me.paso5.Visible = True
            Me.paso6.Visible = True
            Me.paso7.Visible = True
            Me.paso8.Visible = True
            Me.paso9.Visible = True
            Me.paso10.Visible = True
            Me.paso11.Visible = True

            Me.lblMensaje.Text = "La base está generada "
        Else
            Me.lblMensaje.Text = ""
        End If

    End Sub

    Private Sub buscarPrefijoBase()
        'Dim mComTipoCompra As New cTIPOCOMPRAS
        Me.txtCODIGOLICITACION.Text = "" 'mComTipoCompra.obtenerTipoCompraxMODALIDAD(IDMODALIDADCOMPRA).Tables(0).Rows(0).Item("PREFIJOBASE")
    End Sub

    Private Sub DESHABILITAR()
        Me.txtCODIGOLICITACION.Enabled = False
        Me.txtTITULOLICITACION.Enabled = False
        Me.txtDESCRIPCIONLICITACION.Enabled = False
        Me.txtLUGARRECEPCIONOFERTA.Enabled = False
        Me.txtDIRECCIONRECEPCIONOFERTA.Enabled = False
        Me.DdlMUNICIPIOS1.Enabled = False
        Me.txtFECHAINICIORECEPCION.Enabled = False
        Me.txtHORAINICIORECEPCION.Enabled = False
        Me.txtFECHAFINRECEPCION.Enabled = False
        Me.txtHORAFINRECEPCION.Enabled = False
        Me.txtLUGARAPERTURABASE.Enabled = False
        Me.txtDIRECCIONAPERTURABASE.Enabled = False
        Me.DdlMUNICIPIOS2.Enabled = False
        txtFECHAINICIOAPERTURA.Enabled = False
        txtHORAINICIOAPERTURA.Enabled = False
        txtFECHAFINAPERTURA.Enabled = False
        txtHORAFINAPERTURA.Enabled = False
        Me.txtFechaInicioConsultasAclaraciones.Enabled = False
        Me.txtFechaFinConsultasAclaraciones.Enabled = False
        Me.txtGlobalFinanciero.Enabled = False
        Me.txtPocentajeCapital.Enabled = False
        Me.txtIndiceEndeudamiento.Enabled = False
        Me.txtReferenciaBancaria.Enabled = False
        Me.txtIndiceSolvencia.Enabled = False
        Me.txtGARANTIAMNTTOVIGENCIA.Enabled = False
        Me.txtLUGARMNTTO.Enabled = False
        Me.txtGARANTIACUMPLIMIENTOVALOR.Enabled = False
        Me.txtGARANTIACUMPLIMIENTOENTREGA.Enabled = False
        Me.txtGARANTIACUMPLIMIENTOVIGENCIA.Enabled = False
        Me.txtLUGARCUMPLIMIENTO.Enabled = False
        Me.txtGARANTIACALIDADVALOR.Enabled = False
        Me.txtGARANTIACALIDADENTREGA.Enabled = False
        Me.txtGARANTIACALIDADVIGENCIA.Enabled = False
        Me.txtLUGARCALIDAD.Enabled = False
        Me.txtGARANTIAANTICIPOENTREGAS.Enabled = False
        Me.txtGARANTIAANTICIPOVALOR.Enabled = False
        Me.txtGARANTIAANTICIPOVIGENCIA.Enabled = False
        Me.txtLUGARANTICIPO.Enabled = False

    End Sub

    Private Sub buscarDireccionMunicipio()

        Dim ds As Data.DataSet
        Dim mComponente As New cESTABLECIMIENTOS
        ds = mComponente.ObtenerUbicacionEstablecimiento(Me.DdlESTABLECIMIENTOS1.SelectedValue)

        Me.lblDireccionUACI.Text = ds.Tables(0).Rows(0).Item("DIRECCION")
        Me.lblMunicipio.Text = ds.Tables(0).Rows(0).Item("NOMBRE")

    End Sub

    Private Sub obtenerLugarPlazoEntrega()

        Dim lEntidad As New PROCESOCOMPRAS

        Dim i As Integer
        Dim dsDetalle As Data.DataSet
        Dim pn As New Panel
        Dim dg As New DataGrid

        Dim ds As Data.DataSet
        ds = cPC.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, _idEstablecimiento)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As Data.DataRow = ds.Tables(0).NewRow

            For Each dr In ds.Tables(0).Rows
                Select Case dr("identrega")
                    Case Is = 1
                        dsDetalle = cPC.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, _idEstablecimiento, 1)
                        pn = pnlPaso10.FindControl("pnlE" & 1)
                        pn.Visible = True
                        dg = pn.FindControl("dg" & 1)
                        dg.DataSource = dsDetalle
                        dg.DataBind()
                    Case Is = 2
                        dsDetalle = cPC.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, _idEstablecimiento, 2)
                        pn = pnlPaso10.FindControl("pnlE" & 2)
                        pn.Visible = True
                        dg = pn.FindControl("dg" & 2)
                        dg.DataSource = dsDetalle
                        dg.DataBind()
                    Case Is = 3
                        dsDetalle = cPC.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, _idEstablecimiento, 3)
                        pn = pnlPaso10.FindControl("pnlE" & 3)
                        pn.Visible = True
                        dg = pn.FindControl("dg" & 3)
                        dg.DataSource = dsDetalle
                        dg.DataBind()
                End Select

                'If dsDetalle.Tables(0).Rows.Count > 0 Then
                '    pn = pnlPaso10.FindControl("pnlE" & i)
                '    pn.Visible = True
                '    dg = pn.FindControl("dg" & i)
                '    dg.DataSource = dsDetalle
                '    dg.DataBind()
                'End If
            Next
        End If
    End Sub



    Private Sub obtenerEvaluacionTecnica()

        Dim mComponentePlantilla As New cCRITERIOSPLANTILLAS

        If MODO = "NEW" Then
            Dim mComponente As New cCRITERIOSEVALUACION
            dsEvalTec = mComponente.ObtenerDataSetPorTipoCriterio(1)  '1: Tipo criterio Aspecto Técnico
            dgEvaluacionTecnica.DataSource = dsEvalTec
            dgEvaluacionTecnica.DataBind()

        Else
            dsEvalTec = mComponentePlantilla.ObtenerDataSetCriteroPlanilla(IDPLANTILLASEL, 1, _idEstablecimiento, IDPROCESOCOMPRA)

            If dsEvalTec.Tables(0).Rows.Count > 0 Then
                dgEvaluacionTecnica.DataSource = dsEvalTec
                dgEvaluacionTecnica.DataBind()
            Else
                Dim mComponente As New cCRITERIOSEVALUACION
                dsEvalTec = mComponente.ObtenerDataSetPorTipoCriterio(1)  '1: Tipo criterio Aspecto Técnico
                dgEvaluacionTecnica.DataSource = dsEvalTec
                dgEvaluacionTecnica.DataBind()
            End If

        End If

    End Sub

    Private Sub obtenerEvaluacionFinanciera()

        Dim mComponente As New cCRITERIOSEVALUACION

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSetPorTipoCriterio(2)  '2: Tipo criterio Aspecto Financiero
        Dim comTipoCriterio As New cTIPOCRITERIO
        Dim MaxSuma As Decimal
        MaxSuma = comTipoCriterio.ObtenerDataSetPorIdxTIPO(ViewState("IDTIPOCOMPRA")).Tables(0).Rows(1).Item("PORCENTAJE")
        '   With ds.Tables(0)
        Me.txtIndiceSolvencia.Text = MaxSuma / 4 '.Rows(0).Item(3)
        Me.txtPocentajeCapital.Text = MaxSuma / 4 '.Rows(1).Item(3)
        Me.txtIndiceEndeudamiento.Text = MaxSuma / 4 '.Rows(2).Item(3)
        Me.txtReferenciaBancaria.Text = MaxSuma / 4 '.Rows(3).Item(3)
        Me.txtGlobalFinanciero.Text = MaxSuma '.Rows(4).Item(3)
        'End With

    End Sub

    Private Function obtenerDocumentos(ByVal tipoDocumento As Int64) As Data.DataSet

        Dim mComponenteDocPlantilla As New cDOCUMENTOSBASEPLANTILLA

        Return mComponenteDocPlantilla.ObtenerDataSetDocumentosPlantilla(tipoDocumento, _idEstablecimiento, IDPROCESOCOMPRA) '1: para documentos Juridicos de acuerdo a la tabla

    End Function

    
    'Private Sub obtenerDocLegFinJuridico()
    '    Dim chk As New CheckBox
    '    Dim aSeleccionado As Boolean = False
    '    Dim i As Integer = 0
    '    Dim j As Integer = 0
    '    Dim mComponente As New cDOCUMENTOSBASE
    '    Dim mComponenteDocPlantilla As New cDOCUMENTOSBASEPLANTILLA
    '    Dim idDoc As Integer
    '    If MODO = "NEW" Then
    '        Me.dgLegalFinanJuridico.DataSource = mComponente.ObtenerDataSetPorTipoDocumento(1) '1: para documentos Juridicos de acuerdo a la tabla
    '        Me.dgLegalFinanJuridico.DataBind()
    '    Else

    '        Me.dgLegalFinanJuridico.DataSource = mComponente.ObtenerDataSetPorTipoDocumento(1) '1: para documentos Juridicos de acuerdo a la tabla
    '        Me.dgLegalFinanJuridico.DataBind()

    '        Dim ds As Data.DataSet
    '        ds = mComponenteDocPlantilla.ObtenerDataSetDocumentosPlantilla(1, _idEstablecimiento, IDPROCESOCOMPRA) '1: para documentos Juridicos de acuerdo a la tabla

    '        If ds.Tables(0).Rows.Count > 0 Then
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                For Each a As DataGridItem In Me.dgLegalFinanJuridico.Items
    '                    chk = a.FindControl("chkSeleccionado")
    '                    idDoc = CInt(Me.dgLegalFinanJuridico.Items(a.ItemIndex).Cells(1).Text)
    '                    If idDoc = ds.Tables(0).Rows(i).Item("IDDOCUMENTOBASE") Then
    '                        chk.Checked = True
    '                    End If
    '                Next
    '            Next
    '        End If
    '    End If

    'End Sub
    
    
    

    Private Sub obtenerDatosPlantilla()
        Dim mComponente As New cPLANTILLAPROCESOCOMPRA
        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSetPorId(_idEstablecimiento, IDPROCESOCOMPRA, IDPLANTILLA)
        If ds.Tables(0).Rows.Count > 0 Then
            MODO = "EDIT"
            cargarDatos()
        Else
            MODO = "NEW"
        End If
    End Sub

    Private Sub cargarDatos()

        Dim lEntidad As New PROCESOCOMPRAS
        Dim ds As Data.DataSet

        With lEntidad
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
        End With

        ds = cPC.recuperarDatosProcesoCompra(lEntidad)

        With ds.Tables(0).Rows(0)
            Me.txtCODIGOLICITACION.Text = .Item("CODIGOLICITACION").ToString()
            Try
                'cbl11.FechaFirma = Format(.Item("FECHAAPROBACIONBASE"), "dd/MM/yyyy")
            Catch ex As Exception
                cbl11.FechaFirma = Date.Today.ToShortDateString()
            End Try

            Me.txtTITULOLICITACION.Text = .Item("TITULOLICITACION").ToString
            Me.txtDESCRIPCIONLICITACION.Text = .Item("DESCRIPCIONLICITACION").ToString
            ddlIDTITULAR.SelectedValue = .Item("IDTITULAR").ToString
            Try
                Me.txtLUGARRECEPCIONOFERTA.Text = .Item("LUGARRECEPCIONOFERTA").ToString
            Catch ex As Exception
                Me.txtLUGARRECEPCIONOFERTA.Text = ""
            End Try
            Try
                Me.txtDIRECCIONRECEPCIONOFERTA.Text = .Item("DIRECCIONRECEPCIONOFERTA").ToString
            Catch ex As Exception
                Me.txtDIRECCIONRECEPCIONOFERTA.Text = ""
            End Try
            Try
                Me.DdlMUNICIPIOS1.Text = .Item("IDMUNICIPIORECEPCION").ToString()
            Catch ex As Exception

            End Try

            Try
                Me.txtFECHAINICIORECEPCION.Text = CStr(Format(.Item("FECHAHORAINICIORECEPCION"), "dd/MM/yyyy"))
            Catch ex As Exception
                Me.txtFECHAINICIORECEPCION.Text = CStr(Format(Date.Now, "dd/MM/yyyy"))
            End Try
            Try
                Me.txtHORAINICIORECEPCION.Text = Format(.Item("FECHAHORAINICIORECEPCION"), "hh:mm tt")
            Catch ex As Exception
                Me.txtHORAINICIORECEPCION.Text = CStr(Format(Date.Now, "hh:mm tt"))
            End Try
            Try
                Me.txtFECHAFINRECEPCION.Text = Format(.Item("FECHAHORAFINRECEPCION"), "dd/MM/yyyy")
            Catch ex As Exception
                Me.txtFECHAFINRECEPCION.Text = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                Me.txtHORAFINRECEPCION.Text = Format(.Item("FECHAHORAFINRECEPCION"), "hh:mm tt")
            Catch ex As Exception
                Me.txtHORAFINRECEPCION.Text = CStr(Format(Date.Now, "hh:mm tt"))
            End Try
            Try
                Me.txtLUGARAPERTURABASE.Text = .Item("LUGARAPERTURABASE").ToString()
            Catch ex As Exception
                Me.txtLUGARAPERTURABASE.Text = ""
            End Try
            Try
                Me.txtDIRECCIONAPERTURABASE.Text = .Item("DIRECCIONAPERTURABASE").ToString()
            Catch ex As Exception
                Me.txtDIRECCIONAPERTURABASE.Text = ""
            End Try
            Try
                Me.DdlMUNICIPIOS2.SelectedValue = .Item("IDMUNICIPIOAPERTURA").ToString()
            Catch ex As Exception

            End Try

            Try
                txtFECHAINICIOAPERTURA.Text = Format(.Item("FECHAHORAINICIOAPERTURA"), "dd/MM/yyyy")
            Catch ex As Exception
                txtFECHAINICIOAPERTURA.Text = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                txtHORAINICIOAPERTURA.Text = Format(.Item("FECHAHORAINICIOAPERTURA"), "hh:mm tt")
            Catch ex As Exception
                txtHORAINICIOAPERTURA.Text = "0:00"
            End Try

            Try
                txtFECHAFINAPERTURA.Text = Format(.Item("FECHAHORAFINAPERTURA"), "dd/MM/yyyy")
            Catch ex As Exception
                txtFECHAFINAPERTURA.Text = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                txtHORAFINAPERTURA.Text = Format(.Item("FECHAHORAFINAPERTURA"), "hh:mm tt")
            Catch ex As Exception
                txtHORAFINAPERTURA.Text = "0:00"
            End Try

            Try
                Me.txtFechaInicioConsultasAclaraciones.Text = Format(.Item("FECHAINICIOACLARACIONES"), "dd/MM/yyyy")
            Catch ex As Exception
                Me.txtFechaInicioConsultasAclaraciones.Text = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                Me.txtFechaFinConsultasAclaraciones.Text = Format(.Item("FECHAFINACLARACIONES"), "dd/MM/yyyy")
            Catch ex As Exception
                Me.txtFechaFinConsultasAclaraciones.Text = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                If Not .Item("PORCENTAJEFINANCIERO") = "0" Then
                    Me.txtGlobalFinanciero.Text = .Item("PORCENTAJEFINANCIERO")
                End If
            Catch ex As Exception

            End Try
            Try
                If Not .Item("PORCENTAJECAPITALTRABAJO") = "0" Then
                    Me.txtPocentajeCapital.Text = .Item("PORCENTAJECAPITALTRABAJO")
                End If
            Catch ex As Exception

            End Try
            Try
                If Not .Item("PORCENTAJEENDEUDAMIENTO") = "0" Then
                    Me.txtIndiceEndeudamiento.Text = .Item("PORCENTAJEENDEUDAMIENTO")
                End If
            Catch ex As Exception

            End Try
            Try
                If Not .Item("PORCENTAJEREFERENCIASBANC") = "0" Then
                    Me.txtReferenciaBancaria.Text = .Item("PORCENTAJEREFERENCIASBANC")
                End If

            Catch ex As Exception

            End Try
            Try
                If Not .Item("PORCENTAJEINDICESOLVENCIA") = "0" Then
                    Me.txtIndiceSolvencia.Text = .Item("PORCENTAJEINDICESOLVENCIA")
                End If
            Catch ex As Exception

            End Try
            Try
                Me.txtGARANTIAMNTTOVIGENCIA.Text = .Item("GARANTIAMTTOVIGENCIA")
            Catch ex As Exception

            End Try

            Try
                Me.txtLUGARMNTTO.Text = .Item("LUGARMTTO")
            Catch ex As Exception
                Me.txtLUGARMNTTO.Text = ""
            End Try
            Try
                Me.txtGARANTIACUMPLIMIENTOVALOR.Text = .Item("GARANTIACUMPLIMIENTOVALOR")
            Catch ex As Exception

            End Try
            Try
                Me.txtGARANTIACUMPLIMIENTOENTREGA.Text = .Item("GARANTIACUMPLIMIENTOENTREGA")
            Catch ex As Exception

            End Try
            Try
                Me.txtGARANTIACUMPLIMIENTOVIGENCIA.Text = .Item("GARANTIACUMPLIMIENTOVIGENCIA")
            Catch ex As Exception

            End Try

            Try
                Me.txtLUGARCUMPLIMIENTO.Text = .Item("LUGARCUMPLIMIENTO")
            Catch ex As Exception
                Me.txtLUGARCUMPLIMIENTO.Text = ""
            End Try
            Try
                Me.txtGARANTIACALIDADVALOR.Text = .Item("GARANTIACALIDADVALOR")
            Catch ex As Exception

            End Try
            Try
                Me.txtGARANTIACALIDADENTREGA.Text = .Item("GARANTIACALIDADENTREGA")
            Catch ex As Exception

            End Try
            Try
                Me.txtGARANTIACALIDADVIGENCIA.Text = .Item("GARANTIACALIDADVIGENCIA")
            Catch ex As Exception

            End Try

            Try
                Me.txtLUGARCALIDAD.Text = .Item("LUGARCALIDAD")
            Catch ex As Exception
                Me.txtLUGARCALIDAD.Text = ""
            End Try

            Try

                Me.txtGARANTIAANTICIPOENTREGAS.Text = .Item("GARANTIAANTICIPOENTREGAS")
            Catch ex As Exception
            End Try
            Try
                Me.txtGARANTIAANTICIPOVALOR.Text = .Item("GARANTIAANTICIPOVALOR")
            Catch ex As Exception

            End Try
            Try
                Me.txtGARANTIAANTICIPOVIGENCIA.Text = .Item("GARANTIAANTICIPOVIGENCIA")
            Catch ex As Exception

            End Try
            Try
                Me.txtLUGARANTICIPO.Text = .Item("LUGARANTICIPO").ToString
            Catch ex As Exception
                Me.txtLUGARANTICIPO.Text = ""
            End Try

        End With

    End Sub



    Protected Sub lbSiguiente1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSiguiente1.Click
        Me.pnlPaso1.Visible = False
        Me.pnlPaso2.Visible = True
        'guardarBaseLic()
        guardarProcesoCompra(1)
        guardarPlantillaProcesoCompra()
    End Sub

    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
        Me.pnlPaso1.Visible = True
        Me.pnlPaso2.Visible = False
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If validacionFechasRecepcion() = False Then
            Me.pnlPaso2.Visible = False
            Me.pnlPaso3.Visible = True
            'guardarBaseLic()
            guardarProcesoCompra(2)
        End If
    End Sub

    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click
        Me.pnlPaso2.Visible = True
        Me.pnlPaso3.Visible = False
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        If validaFechasApertura() = False Then
            Me.pnlPaso3.Visible = False
            Me.pnlPaso4.Visible = True
            'guardarBaseLic()
            guardarProcesoCompra(3)
        End If

    End Sub

    Private Function validaFechasApertura() As Boolean

        Dim hayError As Boolean = False

        If CDate(Me.txtFECHAINICIOAPERTURA.Text) < CDate(Me.txtFECHAFINRECEPCION.Text) Then
            RequiredFieldValidator13.ErrorMessage = "La fecha debe ser mayor que la fecha de fin de retiro de ofertas"
            RequiredFieldValidator13.IsValid = False
            hayError = True
        End If

        If CDate(Me.txtFECHAINICIOAPERTURA.Text) = CDate(Me.txtFECHAFINRECEPCION.Text) Then
            If CDate(Me.txtHORAINICIOAPERTURA.Text) < CDate(Me.txtHORAFINRECEPCION.Text) Then
                RequiredFieldValidator14.ErrorMessage = "La hora de inicio de apertura debe ser mayor que la hora de fin de retiro de ofertas"
                RequiredFieldValidator14.IsValid = False
                hayError = True
            End If

        End If

        If CDate(Me.txtFECHAFINAPERTURA.Text) < Date.Today Then
            RequiredFieldValidator27.ErrorMessage = "La fecha debe ser mayor que la fecha de fin de retiro de ofertas"
            RequiredFieldValidator27.IsValid = False
            hayError = True
        End If

        If CDate(Me.txtFECHAFINAPERTURA.Text) < CDate(Me.txtFECHAINICIOAPERTURA.Text) Then
            RequiredFieldValidator27.ErrorMessage = "La fecha debe ser mayor o igual que la de inicio de apertura"
            RequiredFieldValidator27.IsValid = False
            hayError = True
        End If
        If CDate(Me.txtFECHAFINAPERTURA.Text) = CDate(Me.txtFECHAINICIOAPERTURA.Text) Then
            'If Me.txtHORAINICIOAPERTURA.SelectedTime > Me.txtHORAFINAPERTURA.SelectedTime Then
            '    RequiredFieldValidator28.ErrorMessage = "La hora debe ser mayor que la de inicio de apertura"
            '    RequiredFieldValidator28.IsValid = False
            '    hayError = True
            'End If
        End If

        Return hayError
    End Function

    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click
        Me.pnlPaso3.Visible = True
        Me.pnlPaso4.Visible = False
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        If validarFechasConsultas() = False Then
            Me.pnlPaso4.Visible = False
            Me.pnlPaso5.Visible = True
            'guardarBaseLic()
            guardarProcesoCompra(4)
        End If
    End Sub

    Private Function validarFechasConsultas() As Boolean

        Dim hayError As Boolean = False

        

        Return hayError

    End Function

    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton11.Click
        Me.pnlPaso4.Visible = True
        Me.pnlPaso5.Visible = False
        cbl5.ActualizaDocumentos()
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Me.pnlPaso5.Visible = False
        Me.pnlPaso6.Visible = True
        'guardarBaseLic()
        cbl5.ActualizaDocumentos()
    End Sub

    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton12.Click
        Me.pnlPaso5.Visible = True
        Me.pnlPaso6.Visible = False
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        Me.pnlPaso6.Visible = False
        Me.pnlPaso7.Visible = True
        'guardarBaseLic()
        cbl6.ActualizaDocumentoAspectotecnico()
    End Sub

    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
        Me.pnlPaso6.Visible = True
        Me.pnlPaso7.Visible = False
    End Sub

    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        Dim chk As New CheckBox
        Dim suma As Decimal = 0
        For Each a As DataGridItem In Me.dgEvaluacionTecnica.Items
            Dim textbox As TextBox = CType(a.FindControl("txtPorcentaje"), TextBox)
            chk = a.FindControl("chkCriterio")
            If chk.Checked And (a.ItemIndex < dgEvaluacionTecnica.Items.Count - 1) Then
                suma += textbox.Text
            End If

        Next

        Dim suma2 As Decimal

        suma2 = CDec(txtIndiceSolvencia.Text) + CDec(txtPocentajeCapital.Text) + CDec(txtIndiceEndeudamiento.Text) + CDec(txtReferenciaBancaria.Text)

        Dim suma3 As Decimal

        suma3 = suma + suma2

        If suma3 <> 100 Then
            RequiredFieldValidator17.ErrorMessage = "La suma de todos los criterios debe ser igual a 100"
            RequiredFieldValidator17.IsValid = False
        Else
            Me.pnlPaso7.Visible = False
            Me.pnlPaso8.Visible = True
        End If

        'guardarBaseLic()
        guardarProcesoCompra(7)
        guardarPorcentajeEvaluacion()

    End Sub


    Protected Sub DdlEMPLEADOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIDTITULAR.SelectedIndexChanged
        obtenerCargoEmpleado()
    End Sub

    Private Sub obtenerCargoEmpleado()
        Dim mComponente As New cEMPLEADOS
        Try
            Me.lblCargoTitular.Text = mComponente.ObtenerDataSetporCargo(_idEstablecimiento, Me.ddlIDTITULAR.SelectedValue).Tables(0).Rows(0).Item("DESCRIPCION")
        Catch ex As Exception
            Me.lblCargoTitular.Text = "No hay cargo configurado"
        End Try
    End Sub

    Protected Sub btnGuardar_Base(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl11.Guardar
        guardarProcesoCompra(1)
        guardarProcesoCompra(2)
        guardarProcesoCompra(3)
        guardarProcesoCompra(4)
        guardarProcesoCompra(7)
        guardarProcesoCompra(8)
        guardarProcesoCompra(10)

        cbl5.ActualizaDocumentos()

        cbl6.ActualizaDocumentoAspectotecnico()
        guardarPorcentajeEvaluacion()

        cbl9.GuardarGarantiasProducto()

        guardarPlantillaProcesoCompra()

        cbl11.VerGenerarDocumento = True
        cbl11.Resultado = "La base ha sido guardada satisfactoriamente, a continuación deberá generar las bases"
    End Sub

    Private Sub guardarPlantillaProcesoCompra()
        Dim mComponente As New cPLANTILLAPROCESOCOMPRA
        Dim lEntidad As New PLANTILLAPROCESOCOMPRA

        With lEntidad
            .IDESTABLECIMIENTO = CType(_idEstablecimiento, Integer)
            .IDPLANTILLA = IDPLANTILLA
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .ESTASINCRONIZADA = 1
            If MODO = "NEW" Then
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .AUFECHACREACION = Now
            Else
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .AUFECHAMODIFICACION = Now
            End If

        End With

        mComponente.AgregarPLANTILLAPROCESOCOMPRA(lEntidad)

    End Sub

    Private Sub guardarPorcentajeEvaluacion()

        Dim mComponente As New cCRITERIOPROCESOCOMPRA
        Dim lEntidad As New CRITERIOPROCESOCOMPRA
        Dim text As New TextBox
        Dim chk As New CheckBox
        Dim dsEvalTec1 As Data.DataSet

        For Each a As DataGridItem In Me.dgEvaluacionTecnica.Items
            With lEntidad
                chk = a.FindControl("chkCriterio")
                text = a.FindControl("txtPorcentaje")
                If chk.Checked = True Or a.ItemIndex = Me.dgEvaluacionTecnica.Items.Count - 1 Then
                    If text.Text <> "" Then
                        With lEntidad
                            .IDCRITERIOEVALUACION = Me.dgEvaluacionTecnica.Items(a.ItemIndex).Cells(1).Text
                            .IDESTABLECIMIENTO = _idEstablecimiento
                            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                            .PORCENTAJE = text.Text
                        End With

                        Dim mComponentePlantilla As New cCRITERIOSPLANTILLAS
                        dsEvalTec1 = mComponentePlantilla.ObtenerDataSetporCriteroPlanilla(IDPLANTILLASEL, 1, _idEstablecimiento, IDPROCESOCOMPRA, Me.dgEvaluacionTecnica.Items(a.ItemIndex).Cells(1).Text)

                        If dsEvalTec1.Tables(0).Rows.Count > 0 Then
                            mComponente.ActualizarCRITERIOPROCESOCOMPRA(lEntidad)
                        Else
                            mComponente.AgregarCRITERIOPROCESOCOMPRA(lEntidad)
                        End If
                    Else
                        Dim IDCRITERIOEVALUACION As Integer
                        IDCRITERIOEVALUACION = Me.dgEvaluacionTecnica.Items(a.ItemIndex).Cells(1).Text
                        mComponente.EliminarCRITERIOPROCESOCOMPRA(_idEstablecimiento, IDPROCESOCOMPRA, IDCRITERIOEVALUACION)
                    End If
                Else
                    Dim IDCRITERIOEVALUACION As Integer
                    IDCRITERIOEVALUACION = Me.dgEvaluacionTecnica.Items(a.ItemIndex).Cells(1).Text
                    mComponente.EliminarCRITERIOPROCESOCOMPRA(_idEstablecimiento, IDPROCESOCOMPRA, IDCRITERIOEVALUACION)
                End If

            End With
        Next
    End Sub



    Private Sub guardarProcesoCompra(ByVal flag As Integer)

        Dim lEntidad As New PROCESOCOMPRAS

        With lEntidad

            Select Case flag
                Case Is = 1
                    .IDENTIDADSOLICITA = Me.DdlESTABLECIMIENTOS1.SelectedValue
                    .IDTITULAR = Me.ddlIDTITULAR.SelectedValue
                    .CODIGOLICITACION = Me.txtCODIGOLICITACION.Text
                    .TITULOLICITACION = Me.txtTITULOLICITACION.Text
                    .DESCRIPCIONLICITACION = Me.txtDESCRIPCIONLICITACION.Text
                Case Is = 2
                    .LUGARRECEPCIONOFERTA = Me.txtLUGARRECEPCIONOFERTA.Text
                    .DIRECCIONRECEPCIONOFERTA = Me.txtDIRECCIONRECEPCIONOFERTA.Text
                    .IDMUNICIPIORECEPCION = CType(Me.DdlMUNICIPIOS1.SelectedValue, Short)
                    .FECHAHORAINICIORECEPCION = CDate(Me.txtFECHAINICIORECEPCION.Text & " " & Me.txtHORAINICIORECEPCION.Text)
                    .FECHAHORAFINRECEPCION = CDate(Me.txtFECHAFINRECEPCION.Text & " " & txtHORAFINRECEPCION.Text)
                Case Is = 3
                    .LUGARAPERTURABASE = Me.txtLUGARAPERTURABASE.Text
                    .DIRECCIONAPERTURABASE = Me.txtDIRECCIONAPERTURABASE.Text
                    .IDMUNICIPIOAPERTURA = Me.DdlMUNICIPIOS2.SelectedValue
                    .FECHAHORAINICIOAPERTURA = CDate(Me.txtFECHAINICIOAPERTURA.Text & " " & Me.txtHORAINICIOAPERTURA.Text)
                    .FECHAHORAFINAPERTURA = CDate(Me.txtFECHAFINAPERTURA.Text & " " & Me.txtHORAFINAPERTURA.Text)
                Case Is = 4
                    .FECHAINICIOACLARACIONES = CDate(Me.txtFechaInicioConsultasAclaraciones.Text)
                    .FECHAFINACLARACIONES = CDate(Me.txtFechaFinConsultasAclaraciones.Text)
                    .FECHAINICIOCONSULTA = CDate(Me.txtFechaInicioConsultasAclaraciones.Text)
                    .FECHAFINCONSULTA = CDate(Me.txtFechaFinConsultasAclaraciones.Text)
                Case Is = 7
                    .PORCENTAJEFINANCIERO = CDec(txtGlobalFinanciero.Text)
                    .PORCENTAJEINDICESOLVENCIA = txtIndiceSolvencia.Text
                    .PORCENTAJECAPITALTRABAJO = Me.txtPocentajeCapital.Text
                    .PORCENTAJEENDEUDAMIENTO = txtIndiceEndeudamiento.Text
                    .PORCENTAJEREFERENCIASBANC = Me.txtReferenciaBancaria.Text
                Case Is = 8
                    .GARANTIAMTTOVIGENCIA = Me.txtGARANTIAMNTTOVIGENCIA.Text
                    .LUGARMTTO = Me.txtLUGARMNTTO.Text
                    .GARANTIACUMPLIMIENTOVALOR = Me.txtGARANTIACUMPLIMIENTOVALOR.Text
                    .GARANTIACUMPLIMIENTOENTREGA = 1
                    .GARANTIACUMPLIMIENTOVIGENCIA = Me.txtGARANTIACUMPLIMIENTOVIGENCIA.Text
                    .GARANTIAANTICIPOENTREGAS = Me.txtGARANTIAANTICIPOENTREGAS.Text
                    .GARANTIAANTICIPOVALOR = CDec(Me.txtGARANTIAANTICIPOVALOR.Text.ToString)
                    .GARANTIAANTICIPOVIGENCIA = CInt(Me.txtGARANTIAANTICIPOVIGENCIA.Text.ToString)
                    .LUGARANTICIPO = Me.txtLUGARANTICIPO.Text.ToString
                    .LUGARCUMPLIMIENTO = Me.txtLUGARCUMPLIMIENTO.Text
                    .GARANTIACALIDADVALOR = Me.txtGARANTIACALIDADVALOR.Text
                    .GARANTIACALIDADENTREGA = Me.txtGARANTIACALIDADENTREGA.Text
                    .GARANTIACALIDADVIGENCIA = Me.txtGARANTIACALIDADVIGENCIA.Text
                    .LUGARCALIDAD = Me.txtLUGARCALIDAD.Text
                Case Is = 10
                    .FECHAAPROBACIONBASE = CDate(cbl11.FechaFirma)
            End Select

            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .IDESTABLECIMIENTO = _idEstablecimiento

            .AUFECHACREACION = Date.Today
            .AUFECHAMODIFICACION = Date.Today
        End With

        cPC.ActualizarValores_GenerarBases(lEntidad, flag)

    End Sub

    Private Function validacionFechasRecepcion() As Boolean

        Dim hayError As Boolean = False

        If CDate(Me.txtFECHAINICIORECEPCION.Text) < Date.Today Then
            RequiredFieldValidator7.ErrorMessage = "La fecha debe ser mayor que la actual"
            RequiredFieldValidator7.IsValid = False
            hayError = True
        End If

        If CDate(Me.txtFECHAFINRECEPCION.Text) < Date.Today Then
            RequiredFieldValidator9.ErrorMessage = "La fecha debe ser mayor que la actual"
            RequiredFieldValidator9.IsValid = False
            hayError = True
        End If

        If CDate(Me.txtFECHAINICIORECEPCION.Text) > Date.Today.AddDays(30) Then
            RequiredFieldValidator7.ErrorMessage = "Advertencia: La fecha debe ser menor a 30 días"
            RequiredFieldValidator7.IsValid = False
        End If

        If CDate(Me.txtFECHAFINRECEPCION.Text) < CDate(Me.txtFECHAINICIORECEPCION.Text) Then
            RequiredFieldValidator9.ErrorMessage = "La fecha debe ser mayor que la de inicio de recepción"
            RequiredFieldValidator9.IsValid = False
            hayError = True
        End If

        If CDate(Me.txtFECHAFINRECEPCION.Text) = CDate(Me.txtFECHAINICIORECEPCION.Text) Then
            If CDate(Me.txtHORAINICIORECEPCION.Text) > CDate(Me.txtHORAFINRECEPCION.Text) Then
                RequiredFieldValidator10.ErrorMessage = "La hora debe ser mayor que la de inicio de recepción"
                RequiredFieldValidator10.IsValid = False
                hayError = True
            End If
        End If

        Return hayError

    End Function

    Protected Sub LinkButton14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton14.Click
        Me.pnlPaso7.Visible = True
        Me.pnlPaso8.Visible = False
    End Sub

    Protected Sub LinkButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton7.Click
        Me.pnlPaso9.Visible = True
        Me.pnlPaso8.Visible = False
        '        guardarBaseLic()
        guardarProcesoCompra(8)
    End Sub

    Protected Sub LinkButton16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton16.Click
        Me.pnlPaso10.Visible = True
        Me.pnlPaso9.Visible = False
        'guardarBaseLic()
        cbl9.GuardarGarantiasProducto()
    End Sub

    Protected Sub LinkButton15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton15.Click
        Me.pnlPaso9.Visible = False
        Me.pnlPaso8.Visible = True
    End Sub

    Protected Sub LinkButton18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton18.Click
        Me.pnlPlantilla.Visible = True
        Me.pnlPaso10.Visible = False
        cbl11.VerGenerarDocumento = True
        cbl11.Resultado = "La base ha sido guardada satisfactoriamente, a continuación deberá generar las bases"
        'guardarBaseLic()
    End Sub

    Protected Sub LinkButton17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton17.Click
        Me.pnlPaso10.Visible = False
        Me.pnlPaso9.Visible = True
    End Sub

    Protected Sub LinkButton19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton19.Click
        Me.pnlPaso10.Visible = True
        Me.pnlPlantilla.Visible = False
    End Sub



    Protected Sub btnGeneraDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl11.GenerarDocumento
        'guardarBaseLic()
        guardarProcesoCompra(10)
        Dim chk As New CheckBox
        Dim suma As Decimal = 0
        If Me.txtLUGARMNTTO.Text = "" Then
            CORRECTO = 0
        Else
            CORRECTO = 1
        End If

        For Each a As DataGridItem In Me.dgEvaluacionTecnica.Items
            Dim textbox As TextBox = CType(a.FindControl("txtPorcentaje"), TextBox)
            chk = a.FindControl("chkCriterio")
            If chk.Checked And (a.ItemIndex < dgEvaluacionTecnica.Items.Count - 1) Then
                suma += textbox.Text
            End If

        Next

        Dim suma2 As Decimal

        suma2 = CDec(txtIndiceSolvencia.Text) + CDec(txtPocentajeCapital.Text) + CDec(txtIndiceEndeudamiento.Text) + CDec(txtReferenciaBancaria.Text)

        Dim suma3 As Decimal

        suma3 = suma + suma2

        If suma3 <> 100 Then
            SINAB_Utils.MessageBox.Alert("No se pudo guardar por que hay pasos pendiente", "Aviso")
            'Me.MsgBox1.ShowAlert("No se pudo guardar por que hay pasos pendiente", "b", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            'RequiredFieldValidator17.ErrorMessage = "La suma de todos los criterios debe ser igual a 100"
            'RequiredFieldValidator17.IsValid = False
            CORRECTO = 0
        Else
            CORRECTO = 1
        End If

        If CORRECTO = 1 Then
            generarDocumento()
            If MODO <> "CONS" Then
                cbl11.VerLiberarBase = True
            End If
        End If
        cbl11.VerSubirBase = True

    End Sub

    Private Sub generarDocumento()

        Dim lEntidad As New PROCESOCOMPRAS
        Dim ds As Data.DataSet
        Dim i As Integer
        Dim mDocumento As New Text.StringBuilder
        Dim mEtiqueta As String
        Dim codigoFuentePlantilla As New Text.StringBuilder
        codigoFuentePlantilla.Append(CODIGOFUENTE) '

        mDocumento.Append(codigoFuentePlantilla.ToString)

        With lEntidad
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .IDESTABLECIMIENTO = _idEstablecimiento
        End With

        ds = cPC.recuperarDatosProcesoCompra(lEntidad)

        Dim mComponenteEtiqueta As New cETIQUETASCAMPOS

        ' TABLA: PROCESOCOMPRAS

        Dim dsEtiqueta As Data.DataSet
        dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("PROCESOCOMPRAS")

        For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
            If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
                If dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA") = "$TITULOLICITACION$" Then
                    TITULOLICITACION = ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO"))
                End If
                If dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA") = "$CODIGOLICITACION$" Then
                    CODIGOLICITACION = ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO"))
                End If

                Try
                    If dsEtiqueta.Tables(0).Rows(i).Item("CAMPO") = "FECHAAPROBACIONBASE" Then
                        Dim fechaAprobacion As String
                        Dim fecha As DateTime

                        fecha = CDate(ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))

                        fechaAprobacion = fecha.Day & " de " & MonthName(fecha.Month) & " de " & fecha.Year

                        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), fechaAprobacion)

                    ElseIf dsEtiqueta.Tables(0).Rows(i).Item("CAMPO") = "FECHAINICIOACLARACIONES" Then

                        Dim fechaAprobacion As String
                        Dim fecha As DateTime

                        fecha = CDate(ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))

                        fechaAprobacion = fecha.Day & " de " & MonthName(fecha.Month) & " de " & fecha.Year

                        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), fechaAprobacion)

                    ElseIf dsEtiqueta.Tables(0).Rows(i).Item("CAMPO") = "FECHAFINACLARACIONES" Then

                        Dim fechaAprobacion As String
                        Dim fecha As DateTime

                        fecha = CDate(ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))

                        fechaAprobacion = fecha.Day & " de " & MonthName(fecha.Month) & " de " & fecha.Year

                        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), fechaAprobacion)

                    ElseIf dsEtiqueta.Tables(0).Rows(i).Item("CAMPO") = "FECHAHORAINICIORECEPCION" Then

                        Dim fechaAprobacion As String
                        Dim fecha As DateTime

                        fecha = CDate(ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))

                        fechaAprobacion = fecha.Day & " de " & MonthName(fecha.Month) & " de " & fecha.Year

                        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), fechaAprobacion)

                    ElseIf dsEtiqueta.Tables(0).Rows(i).Item("CAMPO") = "FECHAHORAINICIOAPERTURA" Then

                        Dim fechaAprobacion As String
                        Dim fecha As DateTime

                        fecha = CDate(ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))

                        fechaAprobacion = fecha.Day & " de " & MonthName(fecha.Month) & " de " & fecha.Year

                        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), fechaAprobacion)

                    Else
                        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
                    End If
                Catch ex As Exception
                    mEtiqueta = dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")
                End Try
                'mDocumento = Replace(mDocumento.ToString, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
            End If
        Next

        'TABLA: GARANTIABUENACALIDAD

        dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("GARANTIABUENACALIDAD")


        For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
            If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
                'mDocumento.Replace(mDocumento.ToString, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
                mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
            End If
        Next

        'OBTENIENDO NOMBRE DE ESTABLECIMIENTO

        mDocumento.Replace("$NOMBRE_ESTABLECIMIENTO$", Session.Item("UsuarioEstablecimiento"))

        'OBTENIENDO LOS DATOS DEL ESTABLECIMIENTO
        Dim mComEst As New cESTABLECIMIENTOS
        Dim dsUbicacion As Data.DataSet
        dsUbicacion = mComEst.ObtenerUbicacionEstablecimiento(_idEstablecimiento)

        mDocumento.Replace("$DIRECCION_ESTABLECIMIENTO$", dsUbicacion.Tables(0).Rows(0).Item("DIRECCION").ToString)
        mDocumento.Replace("$MUNICIPIO_ESTABLECIMIENTO$", dsUbicacion.Tables(0).Rows(0).Item("NOMBRE").ToString)

        'OBTENIENDO EL TITULAR
        Dim nombreTitular As String
        Dim nombreCargo As String
        nombreTitular = cPC.obtenerTitular(_idEstablecimiento, IDPROCESOCOMPRA).Tables(0).Rows(0).Item("TITULAR")
        nombreCargo = cPC.obtenerTitular(_idEstablecimiento, IDPROCESOCOMPRA).Tables(0).Rows(0).Item("CARGO")
        mDocumento.Replace("$TITULAR$", nombreTitular)
        mDocumento.Replace("$CARGOTITULAR$", nombreCargo)

        Dim tipoCompra As String
        tipoCompra = cPC.obtenerTipoProcesoCompra(_idEstablecimiento, IDPROCESOCOMPRA).Tables(0).Rows(0).Item("DESCRIPCION")
        mDocumento.Replace("$TIPO_COMPRA$", tipoCompra)

        Dim lEntPC As New PROCESOCOMPRAS
        lEntPC = cPC.ObtenerPROCESOCOMPRAS(_idEstablecimiento, IDPROCESOCOMPRA)

        Dim horaInicioRecepcion As String
        horaInicioRecepcion = Format(lEntPC.FECHAHORAINICIORECEPCION, "hh:mm tt") & " "
        mDocumento.Replace("$HORAINICIORECEPCION$", horaInicioRecepcion)

        Dim horaFinRecepcion As String
        horaFinRecepcion = Format(lEntPC.FECHAHORAFINRECEPCION, "hh:mm tt") & " "
        mDocumento.Replace("$HORAFINRECEPCION$", horaFinRecepcion)

        Dim horaInicioApertura As String
        horaInicioApertura = Format(lEntPC.FECHAHORAINICIOAPERTURA, "hh:mm tt") & " "
        mDocumento.Replace("$HORAINICIOAPERTURA$", horaInicioApertura)

        Dim horaFinApertura As String
        horaFinApertura = Format(lEntPC.FECHAHORAFINAPERTURA, "HH") & " "
        mDocumento.Replace("$HORAFINAPERTURA$", horaFinApertura)

        'TABLA: GARANTIACUMPLIMIENTO
        dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("GARANTIACUMPLIMIENTO")

        For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
            If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
                'mDocumento = Replace(mDocumento, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
                mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
            End If
        Next

        'TABLA: GARANTIAMANTTOOFERTA
        dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("GARANTIAMANTTOOFERTA")

        For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
            If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
                'mDocumento = Replace(mDocumento, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
                Try
                    mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
                Catch ex As Exception
                    mEtiqueta = dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")
                End Try

            End If
        Next

        'TABLA: GARANTIAANTICIPO
        dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("GARANTIAANTICIPO")

        For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
            If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
                'mDocumento = Replace(mDocumento, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
                Try
                    mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
                Catch ex As Exception
                    mEtiqueta = dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")
                End Try

            End If
        Next

        'TABLA: CRITERIO OFERTA TECNICA
        Dim mComponenteCriterio As New cCRITERIOPROCESOCOMPRA

        Dim tabla As New Text.StringBuilder

        Dim dsCriterio As Data.DataSet
        dsCriterio = mComponenteCriterio.ObtenerDataSetCriteriosProcesoCompra(_idEstablecimiento, IDPROCESOCOMPRA, 1)

        tabla.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        tabla.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        tabla.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Criterio para oferta técnica</p></td>")
        tabla.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Porcentaje evaluación</p></td></tr>")

        If dsCriterio.Tables(0).Rows.Count > 0 Then
            For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
                tabla.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
                tabla.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsCriterio.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td>")
                tabla.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsCriterio.Tables(0).Rows(i).Item("PORCENTAJE") & "%</p></td></tr>")
            Next
        End If
        tabla.Append("</table>")

        mDocumento.Replace("$CRITERIO_OFERTA_TECNICA$", tabla.ToString)

        'TABLA: CRITERIO FINANCIERO
        Dim tablaFinanciero As New Text.StringBuilder

        dsCriterio = mComponenteCriterio.ObtenerDataSetCriteriosFinancieroProcesoCompra(_idEstablecimiento, IDPROCESOCOMPRA)
        tablaFinanciero.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        tablaFinanciero.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>Indice de Solvencia</p></td>")
        tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>Capital de trabajo</p></td>")
        tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>Endeudamiento</p></td>")
        tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>Referencia Bancaria</p></td>")
        tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>Financiero</p></td></tr><tr>")

        If dsCriterio.Tables(0).Rows.Count > 0 Then
            'For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
            tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJEINDICESOLVENCIA") & "%</p></td>")
            tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJECAPITALTRABAJO") & "%</p></td>")
            tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJEENDEUDAMIENTO") & "%</p></td>")
            tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJEREFERENCIASBANC") & "%</p></td>")
            tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJEFINANCIERO") & "%</p></td>")
            'Next
        End If
        tablaFinanciero.Append("</tr></table>")

        'mDocumento = Replace(mDocumento, "$CRITERIO_ASPECTO_FINANCIERO$", tablaFinanciero.ToString)
        mDocumento.Replace("$CRITERIO_ASPECTO_FINANCIERO$", tablaFinanciero.ToString)

        'CRITERIOS TECNICOS
        Dim Etiqueta As String
        Dim EtiquetaT As String
        Dim Porcentaje As Decimal

        dsCriterio = mComponenteCriterio.ObtenerDataSetCriteriosProcesoCompra(_idEstablecimiento, IDPROCESOCOMPRA, 1)

        For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
            Etiqueta = CType(mComponenteCriterio.EtiquetaCriterioTecnico("CRITERIO_TEC", CType(dsCriterio.Tables(0).Rows(i).Item("DESCRIPCION"), String)).Tables(0).Rows(0).Item("ETIQUETA"), String)
            EtiquetaT = CType(mComponenteCriterio.EtiquetaCriterioTecnico("CRITERIO_TEC", CType(dsCriterio.Tables(0).Rows(i).Item("DESCRIPCION"), String)).Tables(0).Rows(1).Item("ETIQUETA"), String)
            Porcentaje = CType(dsCriterio.Tables(0).Rows(i).Item("PORCENTAJE"), Decimal)
            mDocumento.Replace(Etiqueta, Porcentaje & "%")
            mDocumento.Replace(EtiquetaT, clsUtilitarios.Num2Text(Porcentaje) & " POR CIENTO (" & Porcentaje & "%)")
        Next

        'CRITERIOS FINANCIEROS
        dsCriterio = mComponenteCriterio.ObtenerDataSetCriteriosFinancieroProcesoCompra(_idEstablecimiento, IDPROCESOCOMPRA)


        With dsCriterio.Tables(0).Rows(0)
            mDocumento.Replace("$CAPITAL_TRABAJO$", .Item("PORCENTAJECAPITALTRABAJO").ToString())
            mDocumento.Replace("$INDICE_ENDEUDAMIENTO$", .Item("PORCENTAJEENDEUDAMIENTO").ToString())
            mDocumento.Replace("$INDICE_SOLVENCIA$", .Item("PORCENTAJEINDICESOLVENCIA").ToString())
            mDocumento.Replace("$PORCENTAJE_GLOBAL_FINANCIERO$", .Item("PORCENTAJEFINANCIERO").ToString() & "%")
            mDocumento.Replace("$REFERENCIAS_BANCARIAS$", .Item("PORCENTAJEREFERENCIASBANC").ToString())
        End With

        'DOCUMENTOS LEGAL JURIDICO
        Dim mComponenteDoc As New cDOCUMENTOSPROCESOSCOMPRA
        Dim tablaDocJuridico As New Text.StringBuilder

        Dim dsDocumento As Data.DataSet
        dsDocumento = mComponenteDoc.ObtenerDataSetPorTipoDocumento(_idEstablecimiento, IDPROCESOCOMPRA, 1)

        If dsDocumento.Tables(0).Rows.Count > 0 Then

            tablaDocJuridico.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
            tablaDocJuridico.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaDocJuridico.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; font-weight:bold; '>Documentación legal y financiera si es persona jurídica nacional</p></td></tr>")

            If dsCriterio.Tables(0).Rows.Count > 0 Then
                For i = 0 To dsDocumento.Tables(0).Rows.Count - 1
                    tablaDocJuridico.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td></tr>")
                Next
            End If
            tablaDocJuridico.Append("</table>")

            mDocumento.Replace("$LISTA_DOCUMENTO_LEGAL_JURIDICA$", tablaDocJuridico.ToString)

        End If

        'DOCUMENTOS LEGAL JURIDICO EXTRANJERO
        Dim tablaDocJuridicoExtranjero As New Text.StringBuilder

        dsDocumento = mComponenteDoc.ObtenerDataSetPorTipoDocumento(_idEstablecimiento, IDPROCESOCOMPRA, 8)

        If dsDocumento.Tables(0).Rows.Count > 0 Then


            tablaDocJuridicoExtranjero.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
            tablaDocJuridicoExtranjero.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaDocJuridicoExtranjero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; font-weight:bold; '>Documentación legal y financiera si es persona jurídica extranjera</p></td></tr>")


            If dsCriterio.Tables(0).Rows.Count > 0 Then


                For i = 0 To dsDocumento.Tables(0).Rows.Count - 1
                    tablaDocJuridicoExtranjero.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td></tr>")
                Next
            End If
            tablaDocJuridicoExtranjero.Append("</table>")

            mDocumento.Replace("$LISTA_DOCUMENTO_LEGAL_JURIDICA_EXTRANJERA$", tablaDocJuridicoExtranjero.ToString)

        End If

        'DOCUMENTOS LEGAL NATURAL
        Dim tablaDocNatural As New Text.StringBuilder

        dsDocumento = mComponenteDoc.ObtenerDataSetPorTipoDocumento(_idEstablecimiento, IDPROCESOCOMPRA, 2)
        If dsDocumento.Tables(0).Rows.Count > 0 Then


            tablaDocNatural.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
            tablaDocNatural.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaDocNatural.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; font-weight:bold; '>Documentación legal y financiera si es persona natural nacional</p></td></tr>")


            If dsCriterio.Tables(0).Rows.Count > 0 Then


                For i = 0 To dsDocumento.Tables(0).Rows.Count - 1
                    tablaDocNatural.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td></tr>")
                Next
            End If
            tablaDocNatural.Append("</table>")

            mDocumento.Replace("$LISTA_DOCUMENTO_LEGAL_NATURAL$", tablaDocNatural.ToString)

        End If
        'DOCUMENTOS LEGAL NATURAL Extranjero
        Dim tablaDocNaturalExtranjero As New Text.StringBuilder

        dsDocumento = mComponenteDoc.ObtenerDataSetPorTipoDocumento(_idEstablecimiento, IDPROCESOCOMPRA, 9)
        If dsDocumento.Tables(0).Rows.Count > 0 Then


            tablaDocNaturalExtranjero.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
            tablaDocNaturalExtranjero.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaDocNaturalExtranjero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; font-weight:bold; '>Documentación legal y financiera si es persona natural extranjera</p></td></tr>")


            If dsCriterio.Tables(0).Rows.Count > 0 Then


                For i = 0 To dsDocumento.Tables(0).Rows.Count - 1
                    tablaDocNaturalExtranjero.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td></tr>")
                Next
            End If
            tablaDocNaturalExtranjero.Append("</table>")

            mDocumento.Replace("$LISTA_DOCUMENTO_LEGAL_NATURAL_EXTRANJERA$", tablaDocNaturalExtranjero.ToString)

        End If

        'DOCUMENTOS ASPECTO TECNICO
        Dim tablaDocTecnico As New Text.StringBuilder

        dsDocumento = mComponenteDoc.ObtenerDataSetPorTipoDocumento(_idEstablecimiento, IDPROCESOCOMPRA, 3)
        If dsDocumento.Tables(0).Rows.Count > 0 Then


            tablaDocTecnico.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
            tablaDocTecnico.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaDocTecnico.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P ass=MsoNormal style='MARGIN: 0cm 0cm 0pt; font-weight:bold; '>Documentación a solicitar de aspecto técnico</p></td></tr>")


            If dsCriterio.Tables(0).Rows.Count > 0 Then


                For i = 0 To dsDocumento.Tables(0).Rows.Count - 1
                    tablaDocTecnico.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 516.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td></tr>")
                Next
            End If
            tablaDocTecnico.Append("</table>")

            'tablaDocTecnico.Append("<table><tr><td>Documentación a solicitar de aspecto técnico</td></tr>")
            'If dsCriterio.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
            '        tablaDocTecnico.Append("<tr><td>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</td></tr>")
            '    Next
            'End If
            'tablaDocTecnico.Append("</tabla>")

            'mDocumento = Replace(mDocumento, "$LISTA_DOCUMENTOS_ASPECTO_TECNICO$", tablaDocTecnico.ToString)
            mDocumento.Replace("$LISTA_DOCUMENTOS_ASPECTO_TECNICO$", tablaDocTecnico.ToString)


        End If

        'PROGRAMA DE DISTRIBUCION
        Dim dsPD As Data.DataSet
        Dim dsRPC As Data.DataSet
        Dim tablaPD As New StringBuilder
        Dim k As Integer

        dsRPC = cPC.obtenerRenglonesProcesoCompra(_idEstablecimiento, IDPROCESOCOMPRA)

        tablaPD.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        tablaPD.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=3><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><center>Programa de distribución de compra</center></P></TD></tr>")

        For k = 0 To dsRPC.Tables(0).Rows.Count - 1
            tablaPD.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'><b>" & dsRPC.Tables(0).Rows(k).Item("RENGLON") & "</b></P></TD>")
            tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'><b>" & dsRPC.Tables(0).Rows(k).Item("DESCRIPCION") & "</b></P></TD></tr>")

            dsPD = cPC.obtenerProgramaDistribucion(_idEstablecimiento, IDPROCESOCOMPRA, dsRPC.Tables(0).Rows(k).Item("RENGLON"))

            tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'>")
            tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'><b>Establecimiento</b></P></TD>")
            tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'><b>Almacen</b></P></TD>")
            tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'><b>Cantidad Solicitada</b></P></TD></TR>")

            For i = 0 To dsPD.Tables(0).Rows.Count - 1
                tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsPD.Tables(0).Rows(i).Item("ESTABLECIMIENTO_SOLICITA") & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsPD.Tables(0).Rows(i).Item("ALMACEN") & "</P></td>")
                tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsPD.Tables(0).Rows(i).Item("CANTIDADSOLICITADA") & "</P></td></tr>")
            Next

        Next

        tablaPD.Append("</table>")

        mDocumento.Replace("$PROGRAMA_DISTRIBUCION$", tablaPD.ToString)

        'OBTENIENDO LISTA DE PRODUCTOS CON GARANTIA DE MANTENIMIENTO DE OFERTA


        Dim tablaGtiaMtto As New Text.StringBuilder
        Dim total As Int64

        Dim dsGarantiaMtto As Data.DataSet
        dsGarantiaMtto = cPC.obtenerGarantiaMttoProducto(_idEstablecimiento, IDPROCESOCOMPRA)

        tablaGtiaMtto.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        tablaGtiaMtto.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Renglon</p></td>")
        'tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Código</p></td>")
        'tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Producto</p></td>")
        'tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Unidad de Medida</p></td>")
        tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Garantia de mantenimiento de Oferta</p></td></tr>")


        If dsGarantiaMtto.Tables(0).Rows.Count > 0 Then
            For i = 0 To dsGarantiaMtto.Tables(0).Rows.Count - 1
                tablaGtiaMtto.Append("<tr><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsGarantiaMtto.Tables(0).Rows(i).Item("Renglon") & "</p></td>")
                'tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsGarantiaMtto.Tables(0).Rows(i).Item("Codigo") & "</p></td>")
                'tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsGarantiaMtto.Tables(0).Rows(i).Item("Nombre") & "</p></td>")
                'tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsGarantiaMtto.Tables(0).Rows(i).Item("unidad_medida") & "</p></td>")
                tablaGtiaMtto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>$" & Format(dsGarantiaMtto.Tables(0).Rows(i).Item("garantia_mtto"), "###,###,###.00") & "</p></td></tr>")
                total = total + dsGarantiaMtto.Tables(0).Rows(i).Item("GARANTIA_MTTO")
            Next
        End If
        tablaGtiaMtto.Append("</tr></table>")

        'mDocumento = Replace(mDocumento, "$CRITERIO_ASPECTO_FINANCIERO$", tablaFinanciero.ToString)
        mDocumento.Replace("$GARANTIAMTTOVALOR_PRODUCTO$", tablaGtiaMtto.ToString)
        mDocumento.Replace("$TOTALGARANTIAMTTOVALOR_PRODUCTO$", clsUtilitarios.Num2Text(total) & " 00/100 " & "( $" & total & ".00)")


        'PRODUCTOS

        Dim mComponenteProd As New cDETALLEPROCESOCOMPRA

        Dim tablaProducto As New Text.StringBuilder

        Dim dsProductos As Data.DataSet
        dsProductos = mComponenteProd.ObtenerDataListaProductos(IDPROCESOCOMPRA, _idEstablecimiento)

        ' If dsDocumento.Tables(0).Rows.Count > 0 Then

        tablaProducto.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        tablaProducto.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Detalle de Productos a solicitar</P></TD></tr>")

        tablaProducto.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Renglon</P></TD>")
        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Código</P></TD>")
        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Descripción</P></TD>")
        'tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Especificaciones</P></TD>")
        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Unidad de Medida</P></TD>")
        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Cantidad</P></TD>")
        tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Center'>Entregas</P></TD></TR>")

        If dsProductos.Tables(0).Rows.Count > 0 Then

            For i = 0 To dsProductos.Tables(0).Rows.Count - 1
                tablaProducto.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsProductos.Tables(0).Rows(i).Item("RENGLON") & "</P></td>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsProductos.Tables(0).Rows(i).Item("CODIGO") & "</P></td>")
                tablaProducto.Append("<TD style='BORDER-RIGHT:windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsProductos.Tables(0).Rows(i).Item("DESCRIPCIONNOMBRE") & "</P></td>")
                'tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("ESPECIFICACIONESTECNICAS") & "</P></td>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("DESCRIPCION") & "</P></td>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top; hAlign=right><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & Format(dsProductos.Tables(0).Rows(i).Item("CANTIDAD"), "###,###,###.00") & "</P></td>")
                tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsProductos.Tables(0).Rows(i).Item("NUMEROENTREGAS") & "</P></td></tr>")
            Next
        End If
        tablaProducto.Append("</table>")

        'mDocumento = Replace(mDocumento, "$LISTADO_PRODUCTOS$", tablaProducto.ToString)
        mDocumento.Replace("$LISTADO_PRODUCTOS$", tablaProducto.ToString)


        'End If

        'ENTREGAS
        Dim lEntidadEntregas As New PROCESOCOMPRAS

        Dim dsDetalleEntrega As Data.DataSet
        Dim tablaEntrega As New Text.StringBuilder
        Dim j As Integer

        Dim dsEntregas As Data.DataSet
        dsEntregas = cPC.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, _idEstablecimiento)

        If dsEntregas.Tables(0).Rows.Count > 0 Then
            For i = 1 To dsEntregas.Tables(0).Rows.Count
                dsDetalleEntrega = cPC.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, _idEstablecimiento, i)

                tablaEntrega.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
                tablaEntrega.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
                tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Plazos y porcentajes de entrega de los productos para " & i & " entrega(s)</P></TD></tr>")

                tablaEntrega.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'>")
                tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Plazo</P></TD>")
                tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Porcentaje</P></TD></TR>")

                If dsDetalleEntrega.Tables(0).Rows.Count > 0 Then
                    For j = 0 To dsDetalleEntrega.Tables(0).Rows.Count - 1
                        tablaEntrega.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Left'>" & dsDetalleEntrega.Tables(0).Rows(j).Item("DIAS") & "</P></td>")
                        tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt; TEXT-ALIGN: Right'>" & dsDetalleEntrega.Tables(0).Rows(j).Item("Porcentaje") & "</P></td></tr>")
                    Next
                End If
                tablaEntrega.Append("</table>")
            Next
        End If

        'DETALLE DE ENTREGAS

        Dim mComSolicitud As New cSOLICITUDESPROCESOCOMPRAS
        Dim dsDetEntrega As Data.DataSet
        Dim dtDetEntrega As New Data.DataTable

        Dim dsSolProc As Data.DataSet
        dsSolProc = mComSolicitud.ObtenerSolicitudesProcesoCompra(IDPROCESOCOMPRA, _idEstablecimiento)

        Dim mComDetEntrega As New cNECESIDADESSOLICITUD

        For i = 0 To dsSolProc.Tables(0).Rows.Count - 1
            dsDetEntrega = mComDetEntrega.ObtenerDataSetDistribucion(_idEstablecimiento, dsSolProc.Tables(0).Rows(i).Item("IDSOLICITUD"))
        Next

        'mDocumento = Replace(mDocumento, "$PLAZOS_ENTREGAS$", tablaEntrega.ToString)
        mDocumento.Replace("$PLAZOS_ENTREGAS$", tablaEntrega.ToString)



        mDocumento.Replace("<?xml:namespace prefix = o ns = " & Chr(34) & "urn:schemas-microsoft-com:office:office" & Chr(34) & " />", "")

        mDocumento.Replace("<DIV class=Section1><SPAN lang=ES-GT><o:p><FONT face=Tahoma size=3>&nbsp; ", "")
        mDocumento.Replace("<DIV class=Section1>", "")


        'REEMPLAZANDO "<<F12>>, <<F11>>, <<yape>> <<año>> " invento de Cevallos

        mDocumento = mDocumento.Replace("«f12»", Date.Today.Year - 2)
        mDocumento = mDocumento.Replace("«f11»", Date.Today.Year - 1)
        mDocumento = mDocumento.Replace("«yape»", Date.Today.Year)

        mDocumento = mDocumento.Replace("«año»", Date.Today.Year)

        mDocumento = mDocumento.Replace("<<f12>>", Date.Today.Year - 2)
        mDocumento = mDocumento.Replace("<<f11>>", Date.Today.Year - 1)
        mDocumento = mDocumento.Replace("<<yape>>", Date.Today.Year)

        mDocumento = mDocumento.Replace("<<año>>", Date.Today.Year)


        'File.Create("c:\pruebaPlantilla\prueba.doc")

        'File.AppendAllText("c:\pruebaPlantilla\prueba.doc", "<html>" & mDocumento.ToString & "</html>")

        Dim directorio As String
        Dim Base As String

        directorio = "EST" & _idEstablecimiento & "_PROC" & IDPROCESOCOMPRA



        CODIGOLICITA = Replace(CODIGOLICITACION, "/", "-")
        Me.CODIGOLICITA = Replace(Me.CODIGOLICITA, " ", "_")

        Base = "B" & CODIGOLICITA & ".htm"

        If File.Exists(Server.MapPath(directorio & "\BASES\" & Base)) Then
            File.Delete(Server.MapPath(directorio & "\BASES\" & Base))
            File.AppendAllText(Server.MapPath(directorio & "\BASES\" & Base), "<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" & mDocumento.ToString & "</html>")
        Else
            Directory.CreateDirectory(Server.MapPath(directorio & "\BASES"))
            File.AppendAllText(Server.MapPath(directorio & "\BASES\" & Base), "<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" & mDocumento.ToString & "</html>")
        End If

        cbl11.VerResultadoGenerarBase = True


    End Sub



    Protected Sub txtCODIGOLICITACION_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCODIGOLICITACION.TextChanged

        Try
            If Me.txtCODIGOLICITACION.Text <> "" Then

                If validarExistenciaCodigoLicitacion(Me.txtCODIGOLICITACION.Text) = True Then

                    'lonPrefijo = Len(Me.lblPrefijoBase.Text)
                    'If Len(Me.txtCODIGOLICITACION.Text) < lonPrefijo Then
                    '    RequiredFieldValidator1.ErrorMessage = "El prefijo que debe utilizar para el código de la licitación esta base es: " & Me.lblPrefijoBase.Text & ", verifique sus datos"
                    '    RequiredFieldValidator1.IsValid = False
                    'Else
                    '    If Me.txtCODIGOLICITACION.Text.Substring(0, lonPrefijo) <> Me.lblPrefijoBase.Text Then
                    '        RequiredFieldValidator1.ErrorMessage = "El prefijo que debe utilizar para el código de la licitación esta base es: " & Me.lblPrefijoBase.Text & ", verifique sus datos"
                    '        RequiredFieldValidator1.IsValid = False
                    '    End If
                    'End If

                    'Dim pos As Integer
                    'Dim annio As Integer
                    'pos = InStr(Me.txtCODIGOLICITACION.Text, "/")
                    'If pos > 0 Then
                    '    annio = CInt(Me.txtCODIGOLICITACION.Text.Substring(pos))
                    '    If annio < Today.Year Then
                    '        RequiredFieldValidator1.ErrorMessage = "Debe ingresar el año actual o el siguiente"
                    '        RequiredFieldValidator1.IsValid = False
                    '    End If
                    'Else
                    '    RequiredFieldValidator1.ErrorMessage = "En el formato de Código de Licitación debe utilizar un correlativo seguido del caracter / y a continuación el año actual o el año siguiente"
                    '    RequiredFieldValidator1.IsValid = False
                    'End If
                    RequiredFieldValidator1.ErrorMessage = "Este codigo de este proceso de compra ya existe"
                    RequiredFieldValidator1.IsValid = False
                Else
                    'RequiredFieldValidator1.ErrorMessage = "Ya existe el codigo para otro proveedor, debe ingresar un nuevo codigo"
                    'RequiredFieldValidator1.IsValid = False
                End If
            Else
                RequiredFieldValidator1.ErrorMessage = "Ingrese el codigo para este proceso de compra " '& Me.lblPrefijoBase.Text & "."
                RequiredFieldValidator1.IsValid = False
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Function validarExistenciaCodigoLicitacion(ByVal CODIGOLICITACION As String) As Boolean
        Return cPC.validarExistenciaCodigoLicitacion2(_idEstablecimiento, CODIGOLICITACION)
    End Function

    Protected Sub DdlESTABLECIMIENTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlESTABLECIMIENTOS1.SelectedIndexChanged
        buscarDireccionMunicipio()
    End Sub



    Protected Sub lnkGuardar_Click(sender As Object, e As EventArgs) Handles lnkGuardar.Click
        If Me.txtCODIGOLICITACION.Text <> "" Then
            guardarBaseLic()
            SINAB_Utils.MessageBox.Alert("La base ha sido guardada satisfactoriamente", "Guardado")
            'Me.MsgBox2.ShowAlert("La base ha sido guardada satisfactoriamente", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            RequiredFieldValidator1.ErrorMessage = "Requerido"
            RequiredFieldValidator1.IsValid = False
        End If
    End Sub

    Private Sub guardarBaseLic()
        cbl11.VerGenerarDocumento = True
        cbl11.Resultado = "La base ha sido guardada satisfactoriamente, a continuación deberá generar las bases"
    End Sub

    Protected Sub dgEvaluacionTecnica_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgEvaluacionTecnica.ItemCreated
        If dsEvalTec.Tables(0).Rows.Count > 0 Then
            If dsEvalTec.Tables(0).Rows.Count - 1 = e.Item.ItemIndex Then
                Dim button1 As Button = CType(e.Item.FindControl("btnCalcularTotal1"), Button)
                Dim TextBox1 As TextBox = CType(e.Item.FindControl("txtPorcentaje"), TextBox)
                Dim chk As CheckBox = CType(e.Item.FindControl("chkCriterio"), CheckBox)
                ' button1.Visible = True
                TextBox1.Enabled = False
                chk.Visible = False
            End If
        Else
            Dim mComponente As New cCRITERIOSEVALUACION
            dsEvalTec = mComponente.ObtenerDataSetPorTipoCriterio(1)  '1: Tipo criterio Aspecto Técnico
            dgEvaluacionTecnica.DataSource = dsEvalTec
            dgEvaluacionTecnica.DataBind()
            Me.txtOcultototal.Text = 0
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        calcularRequerimentosTecnicos()
        CalcularRequerimientosFinancieros()
    End Sub
    Private Function CalcularRequerimientosFinancieros() As Boolean
        Dim valido As Boolean = False
        Dim suma As Decimal

        Dim comTipoCriterio As New cTIPOCRITERIO
        Dim MaxSuma As Decimal
        MaxSuma = comTipoCriterio.ObtenerDataSetPorIdxTIPO(ViewState("IDTIPOCOMPRA")).Tables(0).Rows(1).Item("PORCENTAJE")

        suma = CDec(txtIndiceSolvencia.Text) + CDec(txtPocentajeCapital.Text) + CDec(txtIndiceEndeudamiento.Text) + CDec(txtReferenciaBancaria.Text)

        If suma > MaxSuma Then
            RequiredFieldValidator17.ErrorMessage = "El valor no debe exceder de " & MaxSuma & " %"
            RequiredFieldValidator17.IsValid = False
        ElseIf suma < MaxSuma Then
            RequiredFieldValidator17.ErrorMessage = "El valor no debe ser menor que " & MaxSuma & "%"
            RequiredFieldValidator17.IsValid = False
        ElseIf suma = MaxSuma Then
            txtGlobalFinanciero.Text = suma
            valido = True
        End If
        Return valido
    End Function

    Private Function calcularRequerimentosTecnicos() As Boolean
        Dim valido As Boolean = False
        Dim i As Integer
        Dim suma As Decimal = 0

        Dim comTipoCriterio As New cTIPOCRITERIO
        Dim MaxSuma As Decimal
        MaxSuma = comTipoCriterio.ObtenerDataSetPorIdxTIPO(ViewState("IDTIPOCOMPRA")).Tables(0).Rows(0).Item("PORCENTAJE")

        For i = 0 To dgEvaluacionTecnica.Items.Count - 2
            Dim textbox As TextBox = CType(Me.dgEvaluacionTecnica.Items(i).FindControl("txtPorcentaje"), TextBox)
            Dim chk As CheckBox = CType(Me.dgEvaluacionTecnica.Items(i).FindControl("chkCriterio"), CheckBox)
            If chk.Checked Then
                suma += textbox.Text
            Else
                textbox.Text = "0"
            End If
        Next

        Dim total As TextBox = CType(Me.dgEvaluacionTecnica.Items(dgEvaluacionTecnica.Items.Count - 1).FindControl("txtPorcentaje"), TextBox)

        If suma > MaxSuma Then
            Dim lblRequired As RequiredFieldValidator = CType(Me.dgEvaluacionTecnica.Items(dgEvaluacionTecnica.Items.Count - 1).FindControl("RequiredFieldValidator29"), RequiredFieldValidator)
            Me.lblErrorSuma30.Text = "La suma no puede exceder " & MaxSuma & "%"
        ElseIf suma < MaxSuma Then
            Me.lblErrorSuma30.Text = "La suma no puede ser menor que " & MaxSuma & "%"
            total.Text = suma
        ElseIf suma = MaxSuma Then
            total.Text = suma
            Me.lblErrorSuma30.Text = ""
            valido = True
        End If
        Me.txtOcultototal.Text = total.Text
        Return valido
    End Function
    Protected Sub btnCalcularTotal_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        calcularRequerimentosTecnicos()

    End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
    '    If e.Key = "OK" Then
    '        Response.Redirect("~/UACI/FrmGenerarBases.aspx")
    '    End If
    '    If e.Key = "LIBERABASE" Then
    '        Me.MsgBox2.ShowConfirm("Una vez que haya liberado la base no podrá realizar modificaciones en los registros de la base de datos, ¿desea liberar la base de licitación?", "CONFIRMALIBERABASE", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    '    End If
    'End Sub

    Protected Sub paso11_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso11.Click
        Aparecer(Me.pnlPlantilla)
    End Sub

    Protected Sub MsgBox2_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.YesChosen

        If e.Key = "CONFIRMALIBERABASE" Then
            Dim lEntidad As New PROCESOCOMPRAS
            With lEntidad
                .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                .IDESTABLECIMIENTO = _idEstablecimiento
                .IDESTADOPROCESOCOMPRA = 2
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .AUFECHAMODIFICACION = Now
                .ESTASINCRONIZADA = 0
                .FECHAELABORACIONBASE = Now
            End With

            If cPC.ActualizarEstado(lEntidad, 0) = 1 Then
                lnkGuardar.Visible = False
                SINAB_Utils.MessageBox.AlertSubmit("El registro se modificó satisfactoriamente", "Modificado")
                'Me.MsgBox1.ShowAlert("El registro se modificó satisfactoriamente", "OK", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Else
                SINAB_Utils.MessageBox.Alert("Error en la actualización, Consulte con su administrador", "Error")
                'Me.MsgBox1.ShowAlert("Error en la actualización, Consulte con su administrador", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        End If

    End Sub

    Protected Sub paso1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso1.Click
        Aparecer(Me.pnlPaso1)
    End Sub

    Protected Sub paso2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso2.Click
        Aparecer(Me.pnlPaso2)
    End Sub

    Protected Sub paso3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso3.Click
        Aparecer(Me.pnlPaso3)
    End Sub

    Public Sub Aparecer(ByVal panel As Panel)

        Me.pnlPaso1.Visible = False
        Me.pnlPaso2.Visible = False
        Me.pnlPaso3.Visible = False
        Me.pnlPaso4.Visible = False
        Me.pnlPaso5.Visible = False
        Me.pnlPaso6.Visible = False
        Me.pnlPaso7.Visible = False
        Me.pnlPaso8.Visible = False
        Me.pnlPaso9.Visible = False
        Me.pnlPaso10.Visible = False
        Me.pnlPlantilla.Visible = False

        panel.Visible = True

    End Sub

    Protected Sub paso4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso4.Click
        Aparecer(Me.pnlPaso4)
    End Sub

    Protected Sub paso5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso5.Click
        Aparecer(Me.pnlPaso5)
    End Sub

    Protected Sub paso6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso6.Click
        Aparecer(Me.pnlPaso6)
    End Sub

    Protected Sub paso7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso7.Click
        Aparecer(Me.pnlPaso7)
    End Sub

    Protected Sub paso8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso8.Click
        Aparecer(Me.pnlPaso8)
    End Sub

    Protected Sub paso9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso9.Click
        Aparecer(Me.pnlPaso9)
    End Sub

    Protected Sub paso10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles paso10.Click
        Aparecer(Me.pnlPaso10)
    End Sub


    Private ReadOnly _idEstablecimiento As Integer = Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO



End Class
