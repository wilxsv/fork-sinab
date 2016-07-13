Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.IO
Imports SINAB_Utils.MessageBox

Partial Class FrmGenerarContratosPlantilla
    Inherits System.Web.UI.Page

    Private _IDTIPOSUMINISTRO As Integer
    Private _IDPLANTILLA As Integer
    Private _IDCLAUSULA As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer

    Private _flagSaveClausula As Integer = 0
    Private _codigoLicita As String
    Private _IDPROCESOCOMPRA As Integer
    Private _IDESTADOCONTRATO As Integer = 1
    Private _tipo As Integer = 0 'Este campo se utiliza para diferenciar el tipo de plantilla a mostrar

    Private cC As New cCONTRATOS
    Private cPC As New cPROCESOCOMPRAS

    Dim textoParaEntregas() As String = {"PRIMERA ENTREGA: ", "SEGUNDA ENTREGA: ", "TERCERA ENTREGA: ", "CUARTA ENTREGA: "}

#Region " Propiedades "

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property

    Public Property IDTIPOSUMINISTRO() As Integer
        Get
            Return _IDTIPOSUMINISTRO
        End Get
        Set(ByVal value As Integer)
            _IDTIPOSUMINISTRO = value
            If Not Me.ViewState("IDTIPOSUMINISTRO") Is Nothing Then Me.ViewState.Remove("IDTIPOSUMINISTRO")
            Me.ViewState.Add("IDTIPOSUMINISTRO", value)
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

    Public Property IDCLAUSULA() As Integer
        Get
            Return _IDCLAUSULA
        End Get
        Set(ByVal value As Integer)
            _IDCLAUSULA = value
            If Not Me.ViewState("IDCLAUSULA") Is Nothing Then Me.ViewState.Remove("IDCLAUSULA")
            Me.ViewState.Add("IDCLAUSULA", value)
        End Set
    End Property

    Public Property flagSaveClausula() As Integer
        Get
            Return _flagSaveClausula
        End Get
        Set(ByVal value As Integer)
            _flagSaveClausula = value
            If Not Me.ViewState("flagSaveClausula") Is Nothing Then Me.ViewState.Remove("flagSaveClausula")
            Me.ViewState.Add("flagSaveClausula", value)
        End Set
    End Property

    Public Property codigoLicita() As String
        Get
            Return _codigoLicita
        End Get
        Set(ByVal value As String)
            _codigoLicita = value
            If Not Me.ViewState("codigoLicita") Is Nothing Then Me.ViewState.Remove("codigoLicita")
            Me.ViewState.Add("codigoLicita", value)
        End Set
    End Property

    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", value)
        End Set
    End Property

    Public Property IDESTADOCONTRATO() As Integer
        Get
            Return _IDESTADOCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDESTADOCONTRATO = value
            If Not Me.ViewState("IDESTADOCONTRATO") Is Nothing Then Me.ViewState.Remove("IDESTADOCONTRATO")
            Me.ViewState.Add("IDESTADOCONTRATO", value)
        End Set
    End Property

    Public Property tipo() As Integer
        Get
            Return _tipo
        End Get
        Set(ByVal value As Integer)
            _tipo = value
            If Not Me.ViewState("tipo") Is Nothing Then Me.ViewState.Remove("tipo")
            Me.ViewState.Add("tipo", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            With Me.UcVistaDetalleSolicProcesCompra1
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                .IDPROCESOCOMPRA = Request.QueryString("IdProc")
                IDTIPOSUMINISTRO = .ConsultarTipoSuministro()
                .BtnAnularProcesoEnabled = False
                .BtnQuitarSolicitudEnabled = False
            End With

            Me.ddlTIPODOCUMENTOCONTRATO1.ObtenerTipoDocumentosClasificados(0)
            Me.ViewState("MODO") = "NEW"
        Else
            If Not Me.ViewState("IDTIPOSUMINISTRO") Is Nothing Then Me._IDTIPOSUMINISTRO = Me.ViewState("IDTIPOSUMINISTRO")
            If Not Me.ViewState("IDPLANTILLA") Is Nothing Then Me._IDPLANTILLA = Me.ViewState("IDPLANTILLA")
            If Not Me.ViewState("IDCLAUSULA") Is Nothing Then Me._IDCLAUSULA = Me.ViewState("IDCLAUSULA")
            If Not Me.ViewState("flagSaveClausula") Is Nothing Then Me._flagSaveClausula = Me.ViewState("flagSaveClausula")
            If Not Me.ViewState("codigoLicita") Is Nothing Then Me._codigoLicita = Me.ViewState("codigoLicita")
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me._IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDESTADOCONTRATO") Is Nothing Then Me._IDESTADOCONTRATO = Me.ViewState("IDESTADOCONTRATO")
            If Not Me.ViewState("tipo") Is Nothing Then Me._tipo = Me.ViewState("tipo")
            If Not Me.ViewState("IDPROVEEDOR") Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then
                Dim cad = "/Reportes/FrmRptAnexo1.aspx?id=" & Request.QueryString("IdProc") & "&Pr=" & Me.ViewState("IDPROVEEDOR").ToString & "&CON=" & Me.ViewState("IDCONTRATO").ToString
                btnAnexo1.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
                ' "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptAnexo1.aspx?id=" & Request.QueryString("IdProc") & "&Pr=" & Me.ViewState("IDPROVEEDOR").ToString & "&CON=" & Me.ViewState("IDCONTRATO").ToString & "');return;"
            End If
        End If

        lblCargaArchivo.ForeColor = Drawing.Color.Black
        obtenerParametros()

        cargarProveedores()
        Me.UcVistaDetalleSolicProcesCompra1.PermiteSeleccionar = False
        Me.UcVistaDetalleSolicProcesCompra1.ocultaSeleccion()
        Me.obtenerPlantillasContrato(Request.QueryString("idTC"), IDTIPOSUMINISTRO)

        Me.cargarRenglones()

    End Sub

    Private Sub cargarProveedores()
        Me.dgProveedor.DataSource = cPC.obtenerProveedoresContratoDS(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Session("IdEmpleado"))
        Me.dgProveedor.DataBind()
    End Sub

    Private Sub obtenerParametros()

        Dim ds As Data.DataSet
        ds = cPC.obtenerParametrosGeneraContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        With ds.Tables(0).Rows(0)
            Me.lblCodigoBase.Text = .Item("CODIGOLICITACION")
            Try
                Me.lblFechaAdjudicacion.Text = .Item("FECHAFIRMAACEPTACION")
            Catch ex As Exception
                Me.lblFechaAdjudicacion.Text = ""
            End Try

            Me.lblProcesoCompra.Text = Request.QueryString("IdProc")
        End With
    End Sub

    Private Sub obtenerPlantillasContrato(ByVal IDTIPOCOMPRA As Integer, ByVal IDSUMINISTRO As Integer)
        Dim ds As Data.DataSet
        Dim mComponente As New cPLANTILLASCONTRATO
        ds = mComponente.ObtenerPLANTILLASCONTRATO(Session("IDESTABLECIMIENTO"), IDTIPOCOMPRA, IDSUMINISTRO, tipo)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.dgPlantillaContrato.DataSource = ds
            Me.dgPlantillaContrato.DataBind()
            If Not IsPostBack Then
                If Me.ViewState("MODO") = "NEW" Then
                    Me.txtPersoneriaJuridica.Text = ds.Tables(0).Rows(0).Item("PERSONERIAJURIDICA")
                Else
                    ObtenerPersoneriaJuridicaActaNotarial()
                End If
            End If
        Else
            Me.MsgBox2.ShowAlert("No hay plantillas definidas, consulte al administrador del sistema", "PLANTILLAS", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
            Exit Sub
        End If

    End Sub

    Private Sub cargarRenglones()
        Dim mComponente As New cCATALOGOPRODUCTOS
        Dim ds As Data.DataSet
        ds = mComponente.obtenerRenglonesAdjudicadosOferta(Session("IdEstablecimiento"), Request.QueryString("IdProc"))
        Me.dgRenglon.DataSource = ds
        Me.dgProveedor.DataBind()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = "P"
                cargarProveedores()
                Me.dgProveedor.Visible = True
                Me.dgRenglon.Visible = False
            Case Is = "R"
                cargarRenglones()
                Me.dgProveedor.Visible = False
                Me.dgRenglon.Visible = True
        End Select
    End Sub

    Protected Sub dgProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProveedor.SelectedIndexChanged
        Me.Panel6.Visible = True
        IDCONTRATO = 0
        IDPROVEEDOR = Me.dgProveedor.SelectedItem.Cells(3).Text
        LinkButton5.Enabled = True
        'If IsDBNull(Me.dgProveedor.SelectedItem.Cells(7).Text) Or Me.dgProveedor.SelectedItem.Cells(7).Text = "" Then
        '    Me.lblRepresentanteLegal.Text = Me.dgProveedor.SelectedItem.Cells(2).Text
        'Else
        '    Me.lblRepresentanteLegal.Text = Me.dgProveedor.SelectedItem.Cells(7).Text
        'End If
        If IsDBNull(Me.dgProveedor.SelectedItem.Cells(4).Text) Then
            Me.lblRepresentanteLegal.Text = ""
        Else
            Me.lblRepresentanteLegal.Text = Me.dgProveedor.SelectedItem.Cells(4).Text
        End If

        consultaContrato()

        If Me.IDESTADOCONTRATO = 2 Then

            Dim directorio As String
            Dim contrato As String

            contrato = "C" & IDCONTRATO & "PROV" & IDPROVEEDOR & ".doc"

            directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & Request.QueryString("IdProc")

            If File.Exists(Server.MapPath(directorio & "\CONTRATOS\" & contrato)) Then
                Me.Label19.Visible = True
                Me.lbDescargarArchivo.Visible = True
            End If
        End If

    End Sub

    Private Sub consultaContrato()

        Dim lEntidad As New CONTRATOS
        Dim ds As Data.DataSet
        ds = cC.obtenerDatosContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)

        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                Me.txtNumContrato.Text = .Item("NUMEROCONTRATO")
                Me.ddlTIPODOCUMENTOCONTRATO1.SelectedValue = .Item("IDTIPODOCUMENTO")
                rblTipoPersona.SelectedValue = .Item("TIPOPERSONA")
                lblRepresentanteLegal.Text = .Item("REPRESENTANTELEGAL")
                IDCONTRATO = .Item("IDCONTRATO")
                Me.ViewState("MODO") = "EDIT"
                IDESTADOCONTRATO = .Item("IDESTADOCONTRATO")
            End With
        Else
            Me.ViewState("MODO") = "NEW"
            Me.txtNumContrato.Text = ""
            Me.ddlTIPODOCUMENTOCONTRATO1.SelectedValue = 1
            rblTipoPersona.SelectedValue = "N"
        End If

    End Sub

    Protected Sub dgPlantillaContrato_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPlantillaContrato.SelectedIndexChanged
        IDPLANTILLA = Me.dgPlantillaContrato.SelectedItem.Cells(1).Text
        LinkButton3.Enabled = True
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Me.Panel2.Visible = False
        Me.Panel3.Visible = True

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("~/UACI/frmGenerarContratos.aspx", False)
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Me.Panel2.Visible = True
        Me.Panel3.Visible = False
        Me.Panel6.Visible = False
        LinkButton5.Enabled = False
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        Me.LinkButton5.Enabled = False
        If Me.ViewState("MODO") = "EDIT" Then
            ObtenerPersoneriaJuridicaActaNotarial()
        End If

        If guardarContrato() = 1 Then
            guardarResponsableDistribucion()
            guardarFuenteFinanciamiento()
            obtenerClausulasPlantilla()
            obtenerFFContrato()

            Me.Panel1.Visible = True
            Me.Panel3.Visible = False

            If Me.IDESTADOCONTRATO = 2 Then
                Me.dgFuenteFinanciamiento.Enabled = False
                Me.txtPersoneriaJuridica.ReadOnly = True
                Me.dgClausulas.Columns.Item(0).HeaderText = "Ver"
                Me.dgClausulas.Columns(4).Visible = False
                Me.txtACTANOTARIAL.ReadOnly = True
                Me.txtOrden.ReadOnly = True
                Me.rteContenido.ReadOnly = True
                Me.ImageButton1.Visible = False
            Else
                Me.dgFuenteFinanciamiento.Enabled = True
                Me.txtPersoneriaJuridica.ReadOnly = False
                Me.dgClausulas.Columns.Item(0).HeaderText = "Editar"
                Me.dgClausulas.Columns(4).Visible = True
                Me.txtACTANOTARIAL.ReadOnly = False
                Me.txtOrden.ReadOnly = False
                Me.rteContenido.ReadOnly = False
                Me.ImageButton1.Visible = True
            End If
        End If

    End Sub
    '  Private TMonto As Data.DataTable
    'Private Sub CrearTablaMontos()

    '    TMonto = New Data.DataTable

    '    ' Dim ColumSeleccion As New Data.DataColumn("SELECCION", System.Type.GetType("System.Int32"))
    '    Dim ColumFF As New Data.DataColumn("NOMBRE", System.Type.GetType("System.String"))
    '    Dim ColumMonto As New Data.DataColumn("MONTO", System.Type.GetType("System.Decimal"))
    '    Dim ColumIdFF As New Data.DataColumn("IDFUENTEFINANCIAMIENTO", System.Type.GetType("System.Int32"))
    '    Dim ColumCHK As New Data.DataColumn("CHK", System.Type.GetType("System.Int32"))

    '    '     TMonto.Columns.Add(ColumSeleccion)
    '    TMonto.Columns.Add(ColumFF)
    '    TMonto.Columns.Add(ColumMonto)
    '    TMonto.Columns.Add(ColumIdFF)
    '    TMonto.Columns.Add(ColumCHK)

    '    'If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
    '    'Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)

    'End Sub
    Private Sub obtenerFFContrato()
        Dim mComFFC As New cFUENTEFINANCIAMIENTOSCONTRATOS
        Dim ds As New Data.DataSet
        ds = mComFFC.obtenerMontoFFContrato(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR)
        'TODO : PROCESO 21 _tambien QUEMADO 
        ' If Request.QueryString("IdProc") = 23 Or Request.QueryString("IdProc") = 27 Then
        ' CrearTablaMontos()
            Dim Row As Data.DataRow = ds.Tables(0).NewRow
        'Dim x As New cFUENTEFINANCIAMIENTOSCONTRATOS
            Dim MontoTotalon As Decimal = 0
        Dim c As Integer = 0
            For Each Row In ds.Tables(0).Rows
            'Dim drMonto As Data.DataRow = TMonto.NewRow

            '' drMonto("SELECCION") = 
            'drMonto("NOMBRE") = Row("NOMBRE")

            'Select Case Row("IDFUENTEFINANCIAMIENTO")
            '    Case Is = 3
            '        drMonto("MONTO") = x.obtenerMontoGOES(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR, Request.QueryString("IdProc"))
            '        Me.Label24.Text = drMonto("MONTO")
            '        Me.Label27.Text = Row("NOMBRE")


            If c = 0 Then
                Me.Label24.Text = Row("MONTO")
                Me.Label27.Text = Row("NOMBRE")
            End If
            If c = 1 Then
                Me.Label25.Text = Row("MONTO")
                        Me.Label28.Text = Row("NOMBRE")
            End If
            If c = 2 Then
                Me.Label26.Text = Row("MONTO")
                        Me.Label29.Text = Row("NOMBRE")
            End If

            MontoTotalon += Row("MONTO")
            c += 1
            '    Case Is = 49
            'drMonto("MONTO") = x.obtenerMontoPEIS(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR, Request.QueryString("IdProc"))
            'Me.Label25.Text = drMonto("MONTO")
            'Me.Label28.Text = Row("NOMBRE")
            'MontoTotalon += drMonto("MONTO")
            '    Case Is = 50
            'drMonto("MONTO") = x.obtenerMontoPEISCobertura(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR, Request.QueryString("IdProc"))
            'Me.Label26.Text = drMonto("MONTO")
            'Me.Label29.Text = Row("NOMBRE")
            'MontoTotalon += drMonto("MONTO")
            'End Select

            'drMonto("IDFUENTEFINANCIAMIENTO") = Row("IDFUENTEFINANCIAMIENTO")
            'drMonto("CHK") = Row("CHK")

            'TMonto.Rows.Add(drMonto)
            Next
            Try
                lblMontoTotalCalc.Text = FormatCurrency(MontoTotalon)
            Catch ex As Exception
                Me.lblMontoTotalCalc.Text = " $0.0"
            End Try
            'Me.dgFuenteFinanciamiento.DataSource = mComFFC.obtenerMontoFFContrato(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR)
        'Me.dgFuenteFinanciamiento.DataSource = TMonto

        'Me.dgFuenteFinanciamiento.DataBind()
        '  Else
            Me.dgFuenteFinanciamiento.DataSource = ds.Tables(0)
            Me.dgFuenteFinanciamiento.DataBind()
        '  End If
       
    End Sub

    Private Sub guardarFuenteFinanciamiento()
       
        'TODO : PROCESO 21 _tambien QUEMADO 
        'If Request.QueryString("IdProc") = 23 Or Request.QueryString("IdProc") = 27 Then
        'Dim x As New cFUENTEFINANCIAMIENTOSCONTRATOS
        'Dim a, b, c As Decimal
        'a = x.obtenerMontoGOES(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR, Request.QueryString("IdProc"))
        'b = x.obtenerMontoPEIS(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR, Request.QueryString("IdProc"))
        'c = x.obtenerMontoPEISCobertura(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR, Request.QueryString("IdProc"))

        ''------ FUENTE GOES
        'Dim mComFFC As New cFUENTEFINANCIAMIENTOSCONTRATOS
        'Dim lEntidad As New FUENTEFINANCIAMIENTOSCONTRATOS

        'lEntidad.AUFECHACREACION = Date.Today
        'lEntidad.AUFECHAMODIFICACION = CDate("01/01/1900")
        'lEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        'lEntidad.ESTASINCRONIZADA = 0
        'lEntidad.IDCONTRATO = IDCONTRATO
        'lEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        'lEntidad.IDFUENTEFINANCIAMIENTO = 3
        'lEntidad.IDPROVEEDOR = IDPROVEEDOR
        'lEntidad.MONTOCONTRATADO = a

        'If mComFFC.validaExisteFuenteFinaciamientoContrato(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 3) > 0 Then
        '    mComFFC.ActualizarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
        'Else
        '    mComFFC.AgregarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
        'End If

        ''---- FUENTE PEIS
        'Dim mComFFC2 As New cFUENTEFINANCIAMIENTOSCONTRATOS
        'Dim lEntidad2 As New FUENTEFINANCIAMIENTOSCONTRATOS

        'lEntidad2.AUFECHACREACION = Date.Today
        'lEntidad2.AUFECHAMODIFICACION = CDate("01/01/1900")
        'lEntidad2.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        'lEntidad2.ESTASINCRONIZADA = 0
        'lEntidad2.IDCONTRATO = IDCONTRATO
        'lEntidad2.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        'lEntidad2.IDFUENTEFINANCIAMIENTO = 49
        'lEntidad2.IDPROVEEDOR = IDPROVEEDOR
        'lEntidad2.MONTOCONTRATADO = b

        'If mComFFC2.validaExisteFuenteFinaciamientoContrato(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 49) > 0 Then
        '    mComFFC2.ActualizarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
        'Else
        '    mComFFC2.AgregarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
        'End If

        ''---- FUENTE PEIS COBERTURA
        'Dim mComFFC3 As New cFUENTEFINANCIAMIENTOSCONTRATOS
        'Dim lEntidad3 As New FUENTEFINANCIAMIENTOSCONTRATOS

        'lEntidad3.AUFECHACREACION = Date.Today
        'lEntidad3.AUFECHAMODIFICACION = CDate("01/01/1900")
        'lEntidad3.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        'lEntidad3.ESTASINCRONIZADA = 0
        'lEntidad3.IDCONTRATO = IDCONTRATO
        'lEntidad3.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        'lEntidad3.IDFUENTEFINANCIAMIENTO = 50
        'lEntidad3.IDPROVEEDOR = IDPROVEEDOR
        'lEntidad3.MONTOCONTRATADO = c

        'If mComFFC3.validaExisteFuenteFinaciamientoContrato(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 50) > 0 Then
        '    mComFFC3.ActualizarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
        'Else
        '    mComFFC3.AgregarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
        'End If
        'Else
            Dim mComFFC As New cFUENTEFINANCIAMIENTOSCONTRATOS
            Dim lEntidad As New FUENTEFINANCIAMIENTOSCONTRATOS
            Dim i As Integer

            Dim ds As Data.DataSet

        ds = mComFFC.obtenerFuenteFinanciamientoSolcitud(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO)

            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                lEntidad.AUFECHACREACION = Now
                lEntidad.AUFECHAMODIFICACION = Now
                    lEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    lEntidad.ESTASINCRONIZADA = 0
                    lEntidad.IDCONTRATO = IDCONTRATO
                    lEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    lEntidad.IDFUENTEFINANCIAMIENTO = ds.Tables(0).Rows(i).Item("IDFUENTEFINANCIAMIENTO")
                    lEntidad.IDPROVEEDOR = IDPROVEEDOR
                    lEntidad.MONTOCONTRATADO = ds.Tables(0).Rows(i).Item("MONTO")

                    If mComFFC.validaExisteFuenteFinaciamientoContrato(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, ds.Tables(0).Rows(i).Item("IDFUENTEFINANCIAMIENTO")) > 0 Then
                        mComFFC.ActualizarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
                    Else
                        mComFFC.AgregarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
                    End If
                Next

            End If
        'End If
    End Sub

    Private Sub guardarResponsableDistribucion()
        Dim mComRespDist As New cRESPONSABLEDISTRIBUCIONCONTRATO
        Dim lEntidad As New RESPONSABLEDISTRIBUCIONCONTRATO
        Dim ds As Data.DataSet
        Dim i As Integer

        ds = mComRespDist.obtenerResponsablesDistribucion(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        If ds.Tables(0).Rows.Count > 0 Then

            For i = 0 To ds.Tables(0).Rows.Count - 1
                lEntidad.AUFECHACREACION = Now
                lEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                lEntidad.ESTASINCRONIZADA = 0
                lEntidad.AUFECHAMODIFICACION = Now
                lEntidad.IDCONTRATO = IDCONTRATO
                lEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                lEntidad.IDPROVEEDOR = IDPROVEEDOR

                If ds.Tables(0).Rows(i).Item("IDCLASESUMINISTRO") = 1 Then
                    lEntidad.IDRESPONSABLEDISTRIBUCION = 1
                Else
                    lEntidad.IDRESPONSABLEDISTRIBUCION = ds.Tables(0).Rows(i).Item("IDDEPENDENCIASOLICITANTE")
                End If

                If mComRespDist.obtenerResponsablesIngresados(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, lEntidad.IDRESPONSABLEDISTRIBUCION).Tables(0).Rows.Count > 0 Then
                    mComRespDist.ActualizarRESPONSABLEDISTRIBUCIONCONTRATO(lEntidad)
                Else
                    mComRespDist.AgregarRESPONSABLEDISTRIBUCIONCONTRATO(lEntidad)
                End If
            Next

        End If

    End Sub

    Private Sub ObtenerPersoneriaJuridicaActaNotarial()
        Dim eC As CONTRATOS
        eC = cC.ObtenerCONTRATOS(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO)
        Me.txtPersoneriaJuridica.Text = eC.PERSONERIAJURIDICA
        Me.txtACTANOTARIAL.Text = eC.ACTANOTARIAL
    End Sub

    Private Function validarExistenciaNumContrato() As Boolean
        Dim resultado As Integer
        resultado = cC.validadNumContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDCONTRATO)

        If resultado > 0 Then

            Return False
        Else
            Return True
        End If
    End Function

    Private Function guardarContrato() As Integer
        Dim lEntidad As New CONTRATOS
        Dim ds As New Data.DataSet
        Dim montoContrato As Decimal
        Dim validaExisNumContrato As Boolean = True

        If Me.ViewState("MODO") = "NEW" Then
            validaExisNumContrato = validarExistenciaNumContrato()
        End If

        If validaExisNumContrato = True Then
            cPC.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("IdProc"), ds)

            With lEntidad

                .CODIGOLICITACION = ds.Tables(0).Rows(0).Item("CODIGOLICITACION")
                If Me.ViewState("MODO") = "EDIT" Then
                    .IDCONTRATO = IDCONTRATO
                End If
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                .IDESTADOCONTRATO = IDESTADOCONTRATO
                .IDPLANTILLA = IDPLANTILLA
                .IDPROVEEDOR = IDPROVEEDOR
                .IDTIPODOCUMENTO = Me.ddlTIPODOCUMENTOCONTRATO1.SelectedValue
                If Me.ViewState("MODO") = "NEW" Then
                    .MONTOCONTRATO = montoContrato
                Else
                    Try
                        .MONTOCONTRATO = cC.obtenerTotalMontoContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDCONTRATO).Tables(0).Rows(0).Item(0)
                    Catch
                        .MONTOCONTRATO = 0
                    End Try

                End If
                .NUMEROCONTRATO = Me.txtNumContrato.Text
                .IDMODALIDADCOMPRA = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
                .NUMEROMODALIDADCOMPRA = ds.Tables(0).Rows(0).Item("CODIGOLICITACION")
                .TIPOPERSONA = Me.rblTipoPersona.SelectedValue
                .REPRESENTANTELEGAL = Me.lblRepresentanteLegal.Text
                .PERSONERIAJURIDICA = Me.txtPersoneriaJuridica.Text
                .ACTANOTARIAL = Me.txtACTANOTARIAL.Text

                If Me.ViewState("MODO") = "NEW" Then
                    .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    .AUFECHACREACION = Now

                    .AUFECHAMODIFICACION = Nothing
                    .AUUSUARIOMODIFICACION = Nothing
                Else
                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    .AUFECHAMODIFICACION = Now
                End If
                .FECHAAPROBACION = Now
                .FECHADISTRIBUCION = Now
                .FECHAGENERACION = Now
                .FECHAINICIOENTREGA = Now
                .ESTASINCRONIZADA = 0
            End With
            cC.ActualizarRetornaEntidad(lEntidad)
            IDCONTRATO = lEntidad.IDCONTRATO

            If Me.ViewState("MODO") = "NEW" Then
                Dim ccProceso As New cCONTRATOSPROCESOCOMPRA
                Dim lEntContratoProceso As New CONTRATOSPROCESOCOMPRA
                With lEntContratoProceso
                    .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    .AUFECHACREACION = Now
                    .ESTASINCRONIZADA = 0
                    .IDCONTRATO = lEntidad.IDCONTRATO
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    .IDPROCESOCOMPRA = Request.QueryString("idProc")
                    .IDPROVEEDOR = lEntidad.IDPROVEEDOR
                End With
                ccProceso.AgregarCONTRATOSPROCESOCOMPRA(lEntContratoProceso)

                montoContrato = cC.obtenerTotalMontoContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDCONTRATO).Tables(0).Rows(0).Item(0)

                lEntidad.MONTOCONTRATO = montoContrato

                cC.ActualizarCONTRATOS(lEntidad)

                'Almacenando los productos adjudicados al proveedor TABLA: SA_UACI_PRODUCTOSCONTRATO

                guardarProductos(IDCONTRATO)
                ' AQUI ESTABA EL STORE PROCEDURE
                Try
                    cC.copiarDatosEntregaProductosContrato(Session("IdEstablecimiento"), lEntidad.IDPROVEEDOR, Request.QueryString("IdProc"), lEntidad.IDCONTRATO, HttpContext.Current.User.Identity.Name, Date.Today, "T")
                Catch ex As Exception

                End Try
                Dim ds1 As Data.DataSet
                ds1 = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))
                If ds1.Tables(0).Rows(0).Item(0) <> 3 Then
                    guardarGarantias(IDCONTRATO, montoContrato, lEntidad.IDPROVEEDOR)
                End If

            Else

                Dim ds1 As Data.DataSet
                ds1 = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))
                If ds1.Tables(0).Rows(0).Item(0) <> 3 Then
                    montoContrato = lEntidad.MONTOCONTRATO
                    guardarGarantias(IDCONTRATO, montoContrato, lEntidad.IDPROVEEDOR)
                End If
            End If

            Return 1
        Else
            Me.MsgBox2.ShowAlert("El número de contrato ya existe, debe ingresar otro número", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
            Return 0
        End If

    End Function

    Private Sub guardarGarantias(ByVal IDCONTRATO As Integer, ByVal montoContrato As Decimal, ByVal IDPROVEEDOR As Integer)

        Dim ds As Data.DataSet
        ds = cPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        Dim GARANTIAMTTOENTREGA As Integer
        Dim GARANTIAMTTOVIGENCIA As Integer
        Dim GARANTIACUMPLIMIENTOVALOR As Decimal
        Dim GARANTIACUMPLIMIENTOENTREGA As Integer
        Dim GARANTIACUMPLIMIENTOVIGENCIA As Integer
        Dim GARANTIACALIDADVALOR As Decimal
        Dim GARANTIACALIDADENTREGA As Integer
        Dim GARANTIACALIDADVIGENCIA As Integer

        With ds.Tables(0).Rows(0)
            If IsDBNull(.Item("GARANTIAMTTOENTREGA")) Then
                GARANTIAMTTOENTREGA = 0
            Else
                GARANTIAMTTOENTREGA = .Item("GARANTIAMTTOENTREGA")
            End If
            GARANTIAMTTOVIGENCIA = .Item("GARANTIAMTTOVIGENCIA")
            GARANTIACUMPLIMIENTOVALOR = .Item("GARANTIACUMPLIMIENTOVALOR")

            If IsDBNull(.Item("GARANTIACUMPLIMIENTOENTREGA")) Then
                GARANTIACUMPLIMIENTOENTREGA = 0
            Else
                GARANTIACUMPLIMIENTOENTREGA = .Item("GARANTIACUMPLIMIENTOENTREGA")
            End If

            GARANTIACUMPLIMIENTOVIGENCIA = .Item("GARANTIACUMPLIMIENTOVIGENCIA")
            GARANTIACALIDADVALOR = .Item("GARANTIACALIDADVALOR")
            GARANTIACALIDADENTREGA = .Item("GARANTIACALIDADENTREGA")
            GARANTIACALIDADVIGENCIA = .Item("GARANTIACALIDADVIGENCIA")
        End With

        Dim mComGarantiaContrato As New cGARANTIASCONTRATOS
        Dim lEntGarantiaContrato As New GARANTIASCONTRATOS

        Dim IDGARANTIACONTRATO As Integer

        If Not IsDBNull(mComGarantiaContrato.validaExistenciaGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 1)) Then
            IDGARANTIACONTRATO = mComGarantiaContrato.validaExistenciaGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 1)
        Else
            IDGARANTIACONTRATO = 0
        End If

        With lEntGarantiaContrato
            .IDCONTRATO = IDCONTRATO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDGARANTIACONTRATO = IDGARANTIACONTRATO
            .IDMODIFICATIVA = 0
            .IDTIPOGARANTIA = 1
            .NUMEROGARANTIA = ""
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDESTADOGARANTIA = 1
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .FECHAENTREGA = cC.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO).Tables(0).Rows(0).Item("FECHAINICIOENTREGA")
            .VIGENCIA = GARANTIACUMPLIMIENTOVIGENCIA
            .ENTREGA = GARANTIACUMPLIMIENTOENTREGA
            .PORCENTAJE = GARANTIACUMPLIMIENTOVALOR
            .MONTO = (montoContrato * (GARANTIACUMPLIMIENTOVALOR / 100))
        End With

        mComGarantiaContrato.ActualizarGARANTIASCONTRATOS(lEntGarantiaContrato)

        If Not IsDBNull(mComGarantiaContrato.validaExistenciaGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 2)) Then
            IDGARANTIACONTRATO = mComGarantiaContrato.validaExistenciaGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 2)
        Else
            IDGARANTIACONTRATO = 0
        End If

        With lEntGarantiaContrato
            .IDCONTRATO = IDCONTRATO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDMODIFICATIVA = 0
            .IDGARANTIACONTRATO = IDGARANTIACONTRATO
            .IDTIPOGARANTIA = 2
            .NUMEROGARANTIA = ""
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDESTADOGARANTIA = 1
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .FECHAENTREGA = cC.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO).Tables(0).Rows(0).Item("FECHAINICIOENTREGA")
            .VIGENCIA = GARANTIACALIDADVIGENCIA
            .ENTREGA = GARANTIACALIDADENTREGA
            .PORCENTAJE = GARANTIACALIDADVALOR
            .MONTO = (montoContrato * (GARANTIACALIDADVALOR / 100))
        End With

        mComGarantiaContrato.ActualizarGARANTIASCONTRATOS(lEntGarantiaContrato)

        If Not IsDBNull(mComGarantiaContrato.validaExistenciaGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 7)) Then
            IDGARANTIACONTRATO = mComGarantiaContrato.validaExistenciaGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 7)
        Else
            IDGARANTIACONTRATO = 0
        End If

        With lEntGarantiaContrato
            .IDCONTRATO = IDCONTRATO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDGARANTIACONTRATO = IDGARANTIACONTRATO
            .IDMODIFICATIVA = 0
            .IDTIPOGARANTIA = 7
            .NUMEROGARANTIA = ""
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDESTADOGARANTIA = 1
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .FECHAENTREGA = cC.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO).Tables(0).Rows(0).Item("FECHAINICIOENTREGA")
            .VIGENCIA = GARANTIAMTTOVIGENCIA
            .ENTREGA = GARANTIAMTTOENTREGA
            .MONTO = mComGarantiaContrato.obtenerGARANTIAMNTTOVALOR(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)
        End With

        mComGarantiaContrato.ActualizarGARANTIASCONTRATOS(lEntGarantiaContrato)

    End Sub

    Private Sub guardarProductos(ByVal IDCONTRATO As Integer)

        Dim ds As Data.DataSet
        ds = cC.obtenerProductosAdjudicadosProveedor(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim mComProductoContrato As New cPRODUCTOSCONTRATO
            Dim lEntProductoContrato As New PRODUCTOSCONTRATO

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                With lEntProductoContrato
                    .AUFECHACREACION = Date.Today
                    .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    .CANTIDAD = ds.Tables(0).Rows(i).Item("CANTIDADFIRME")
                    .DESCRIPCIONPROVEEDOR = ds.Tables(0).Rows(i).Item("DESCRIPCIONPROVEEDOR")
                    .ESTAHABILITADO = 1
                    .ESTASINCRONIZADA = 0
                    .IDCONTRATO = IDCONTRATO
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    .IDPRODUCTO = ds.Tables(0).Rows(i).Item("IDPRODUCTO")
                    .IDPROVEEDOR = IDPROVEEDOR
                    .IDUNIDADMEDIDA = ds.Tables(0).Rows(i).Item("IDUNIDADMEDIDA")
                    .OBSERVACION = ""
                    .PRECIOUNITARIO = ds.Tables(0).Rows(i).Item("PRECIOUNITARIO")
                    .RENGLON = ds.Tables(0).Rows(i).Item("RENGLON")
                End With
                mComProductoContrato.AgregarPRODUCTOSCONTRATO(lEntProductoContrato)
            Next

        End If

    End Sub

    Private Sub obtenerClausulasPlantilla()

        Dim mComponente As New cCLAUSULASPLANTILLA
        Me.dgClausulas.DataSource = mComponente.obtenerClausulasPlantillaDs(Session("IdEstablecimiento"), IDPLANTILLA, IDCONTRATO, IDPROVEEDOR, tipo, 0)
        Me.dgClausulas.DataBind()

        For i As Integer = 0 To dgClausulas.Items.Count - 1
            Dim chkReq As CheckBox = CType(dgClausulas.Items(i).FindControl("chkRequerido"), CheckBox)
            Dim imbCheck As ImageButton = CType(dgClausulas.Items(i).FindControl("imbCheck"), ImageButton)
            Dim imbOk As ImageButton = CType(dgClausulas.Items(i).FindControl("imbOk"), ImageButton)
            If chkReq.Checked = True Then
                imbCheck.Visible = False
                imbOk.Visible = True
                imbOk.Enabled = False
                If dgClausulas.Items(i).Cells(6).Text = "A" Then
                    If verificaExistenciaClausula(dgClausulas.Items(i).Cells(5).Text) = 0 Then
                        guardarClausulaRequerida(dgClausulas.Items(i).Cells(5).Text)
                        dgClausulas.Items(i).Cells(6).Text = "B"
                    End If
                End If
            Else
                If dgClausulas.Items(i).Cells(6).Text = "B" Then
                    imbOk.Visible = True
                    imbCheck.Visible = False
                End If
            End If

        Next

    End Sub

    Private Function verificaExistenciaClausula(ByVal IDCLAUSULA As Integer) As Integer

        Dim mComClauPlantilla As New cCLAUSULASCONTRATOS
        Dim lEntClauPlantilla As New CLAUSULASCONTRATOS
        Return mComClauPlantilla.verificaExistencia(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR, IDCLAUSULA).Tables(0).Rows.Count

    End Function

    Private Sub guardarClausulaRequerida(ByVal IDCLAUSULA As Integer)

        Dim mComClauPlantilla As New cCLAUSULASPLANTILLA
        Dim lEntClauPlantilla As New CLAUSULASPLANTILLA
        Dim ds As Data.DataSet
        ds = mComClauPlantilla.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPLANTILLA, IDCLAUSULA)

        Dim mComponente As New cCLAUSULASCONTRATOS
        Dim lEntidad As New CLAUSULASCONTRATOS

        With lEntidad
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .IDMODIFICATIVA = 0
            .ORDEN = ds.Tables(0).Rows(0).Item("ORDEN")
            .ENCABEZADOCLAUSULA = ds.Tables(0).Rows(0).Item("CONTENIDO")
            .IDCLAUSULA = IDCLAUSULA
            .IDCONTRATO = IDCONTRATO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
        End With

        mComponente.ActualizarCLAUSULASCONTRATOS(lEntidad)

    End Sub

    Protected Sub dgClausulas_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgClausulas.ItemCommand


        Dim imbCheck As ImageButton = CType(dgClausulas.Items(e.Item.ItemIndex).FindControl("imbCheck"), ImageButton)
        Dim imbOk As ImageButton = CType(dgClausulas.Items(e.Item.ItemIndex).FindControl("imbOK"), ImageButton)
        Me.lblMensaje.Text = ""
        Select Case e.CommandName
            Case Is = "OK"
                EliminarClausula(dgClausulas.Items(e.Item.ItemIndex).Cells(5).Text, dgClausulas.Items(e.Item.ItemIndex).Cells(7).Text)
                obtenerClausulasPlantilla()
                imbOk.Visible = False
                imbCheck.Visible = True
            Case Is = "noOk"
                imbOk.Visible = True
                imbCheck.Visible = False
                If verificaExistenciaClausula(dgClausulas.Items(e.Item.ItemIndex).Cells(5).Text) = 0 Then
                    guardarClausulaRequerida(dgClausulas.Items(e.Item.ItemIndex).Cells(5).Text)
                End If
                obtenerClausulasPlantilla()
        End Select
    End Sub

    Private Sub EliminarClausula(ByVal IDCLAUSULA As Integer, ByVal IDCLAUSULACONTRATO As Integer)
        'Me.MsgBox1.ShowConfirm("¿Desea eliminar la clausula del Contrato?", "ELIMINARCLAUSULA", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)

        Dim mComponente As New cCLAUSULASCONTRATOS
        mComponente.EliminarCLAUSULASCONTRATOS(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, IDCLAUSULA, IDCLAUSULACONTRATO)

    End Sub

    Protected Sub dgClausulas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgClausulas.SelectedIndexChanged
        Me.Panel3.Visible = False

        IDCLAUSULA = dgClausulas.SelectedItem.Cells(5).Text
        lblClausula.Text = Me.dgClausulas.SelectedItem.Cells(1).Text
        'NoClausula = idClausula

        Dim ds As Data.DataSet
        Dim idOrigen As String = Me.dgClausulas.SelectedItem.Cells(6).Text
        'Dim imbOK As ImageButton = CType(Me.dgClausulas.SelectedItem.FindControl("imbOK"), ImageButton)
        'If imbOK.Visible = True Then
        If idOrigen = "B" Then
            Me.lblMensaje.Text = ""
            Dim mComponente As New cCLAUSULASCONTRATOS
            Dim lEntidad As New CLAUSULASCONTRATOS
            Me.CargarEtiqueta()
            Me.Panel4.Visible = True
            Me.Panel1.Visible = False
            ds = mComponente.verificaExistencia(Session("IdEstablecimiento"), IDCONTRATO, IDPROVEEDOR, IDCLAUSULA)
            'desde aqui
            If flagSaveClausula = 0 Then
                With ds.Tables(0).Rows(0)
                    Me.txtOrden.Text = .Item("ORDEN")
                    Me.txtOrdenAnt.Text = .Item("ORDEN")
                    Me.txtValidaOrden.Text = .Item("ORDEN")
                    'Else
                    'Me.txtOrden.Text = mComponente.obtenerOrden(Session("IdEstablecimiento"), IDPLANTILLA, idClausula)
                    'End If
                    'If imbOK.Visible = True Then
                    If idOrigen = "B" Then
                        Me.rteContenido.Text = .Item("ENCABEZADOCLAUSULA")
                        'Me.txtOrden.ReadOnly = True
                    Else
                        Me.rteContenido.Text = .Item("CONTENIDO")
                        'Me.txtOrden.ReadOnly = False
                    End If

                End With
                flagSaveClausula = 1
            End If


            Me.Panel4.Visible = True
            'hasta aqui
        Else
            Me.lblMensaje.Text = "Antes de editar debe seleccionar la clausula que desea incluir en el contrato"
            'Dim mComponente As New cCLAUSULASPLANTILLA
            'Dim lEntidad As New CLAUSULASPLANTILLA

            'ds = mComponente.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPLANTILLA, idClausula)
        End If


        'If flagSaveClausula = 0 Then
        '    With ds.Tables(0).Rows(0)
        '        Me.txtOrden.Text = .Item("ORDEN")
        '        Me.txtValidaOrden.Text = .Item("ORDEN")
        '        'Else
        '        'Me.txtOrden.Text = mComponente.obtenerOrden(Session("IdEstablecimiento"), IDPLANTILLA, idClausula)
        '        'End If
        '        'If imbOK.Visible = True Then
        '        If idOrigen = "B" Then
        '            Me.rteContenido.Text = .Item("ENCABEZADOCLAUSULA")
        '        Else
        '            Me.rteContenido.Text = .Item("CONTENIDO")
        '        End If

        '    End With
        '    flagSaveClausula = 1
        'End If


        'Me.Panel4.Visible = True
    End Sub

    Private Sub CargarEtiqueta()
        Dim mComponente As New cETIQUETASCLAUSULAS
        Dim lEntidad As New ETIQUETASCLAUSULAS

        Me.dgEtiqueta.DataSource = mComponente.ObtenerDataSetPorId()
        Me.dgEtiqueta.DataBind()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim mComponente As New cCLAUSULASCONTRATOS
        Dim lEntidad As New CLAUSULASCONTRATOS

        If validaOrden() = False Then
            With lEntidad
                .AUFECHACREACION = Date.Today
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .ESTASINCRONIZADA = 0
                .IDMODIFICATIVA = 0
                .IDCLAUSULACONTRATO = Me.dgClausulas.SelectedItem.Cells(7).Text

                .ORDEN = Me.txtOrden.Text
                .ENCABEZADOCLAUSULA = Me.rteContenido.Text
                .IDCLAUSULA = Me.dgClausulas.SelectedItem.Cells(5).Text
                .IDCONTRATO = IDCONTRATO
                .IDPROVEEDOR = IDPROVEEDOR
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            End With

            flagSaveClausula = 0

            validaOrden()

            If mComponente.ActualizarCLAUSULASCONTRATOS(lEntidad) <> 1 Then

                Me.MsgBox1.ShowAlert("El registro no ha sido almacenado, verifique sus datos o informe al administrador", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            Else
                Me.MsgBox1.ShowAlert("El registro se ha almacenado satisfactoriamente, a continuación regresará al listado de clausulas.", "MODCLAU", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            End If

        Else
            Me.MsgBox1.ShowAlert("El número de orden ya existe favor verificar.", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Private Function validaOrden() As Boolean
        Dim mComClausulaContrato As New cCLAUSULASCONTRATOS
        If Me.txtOrden.Text <> Me.txtOrdenAnt.Text Then
            If mComClausulaContrato.validaOrden(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, Me.txtOrden.Text).Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub GuardarPaso4()
        Dim lEntidad As New CONTRATOS

        With lEntidad
            .PERSONERIAJURIDICA = Me.txtPersoneriaJuridica.Text
            .ACTANOTARIAL = Me.txtACTANOTARIAL.Text
            .AUFECHAMODIFICACION = Now
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDCONTRATO = IDCONTRATO
            .IDPROVEEDOR = IDPROVEEDOR
        End With

        If cC.ActualizarPersoneriaJuridicaActaNotarial(lEntidad) = 1 Then
            'Me.MsgBox1.ShowAlert("El registro se ha almacenado satisfactoriamente", "EXITO", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Me.MsgBox1.ShowAlert("El registro no ha sido almacenado, verifique sus datos o informe al administrador", "ERROR", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen

        If e.Key = "EXITO" Then
            Me.Panel4.Visible = False
            Me.Panel1.Visible = True
            obtenerClausulasPlantilla()
        ElseIf e.Key = "ELIMINARCLAUSULA" Then
        ElseIf e.Key = "MODCLAU" Then
            Me.Panel4.Visible = False
            Me.Panel1.Visible = True
            Me.obtenerClausulasPlantilla()
            Me.dgClausulas.CurrentPageIndex = 0
            Me.dgClausulas.SelectedIndex = -1
            flagSaveClausula = 0

        ElseIf e.Key = "LIBERAR" Then

            Dim lEntidad As New CONTRATOS

            With lEntidad
                .AUFECHAMODIFICACION = Date.Today
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .ESTASINCRONIZADA = 0

                .IDCONTRATO = IDCONTRATO
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                .IDESTADOCONTRATO = 2 ' Contrato Cerrado
                .IDPROVEEDOR = IDPROVEEDOR
            End With

            cC.ActualizarEstadoContrato(lEntidad)
            IDCONTRATO = lEntidad.IDCONTRATO
            Me.fuContrato.Visible = False
            Me.btnCargarArchivo.Visible = False
            Me.lblCargaArchivo.Text = "El contrato fue liberado satisfactoriamente, desde este momento solo podrá realizar consultas al contrato generado."
            Label17.Text = "El contrato ya fue liberado para este proveedor, puede descargarlo en el siguiente opción"
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Panel4.Visible = False
        Me.Panel1.Visible = True
        Me.obtenerClausulasPlantilla()
        Me.dgClausulas.CurrentPageIndex = 0
        Me.dgClausulas.SelectedIndex = -1
        flagSaveClausula = 0
    End Sub

    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        Me.Panel1.Visible = False
        Me.Panel3.Visible = True
        flagSaveClausula = 0
    End Sub

    Protected Sub btnGenerarContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarContrato.Click
        Dim textoContrato As New Text.StringBuilder
        textoContrato = ElaborarContrato()
        reemplazarEtiquetas(textoContrato)

        Me.fuContrato.Visible = True
        Me.btnCargarArchivo.Visible = True

        cC.actualizaFechaGeneracion(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, Format(Me.cpFechaAprobacion.SelectedDate, "dd/MM/yyyy"))

        Me.btnAnexo1.Visible = True
        Me.Button3.Visible = True
    End Sub

    Private Function ElaborarContrato() As StringBuilder
        Dim lEntidad As New CONTRATOS
        Dim ds As Data.DataSet
        Dim textoContrato As New Text.StringBuilder
        Dim textoCompleto As New Text.StringBuilder
        Dim i As Integer
        Dim ordenClausula As String
        ds = cC.ElaboraContrato(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, Request.QueryString("IdProc"), IDPLANTILLA)

        ' Dim Encabezado As New Text.StringBuilder
        '  Encabezado.Append("<body><table cellspacing=1 cellpadding=2 width=100% border=0><tbody><tr><td></td><td style='text-align: right;'><strong>Contrato No. $CODIGO_CONTRATO$</strong></td></tr><tr><td><strong>$NOMBRE_ESTABLECIMIENTO$</strong></td><td style='text-align: right;'><strong>$TIPO_COMPRA$ No. $CODIGO_LICITACION$</strong></td></tr><tr><td></td><td style='text-align: right;'><strong>" & Server.HtmlEncode("Resolución de Adjudicación No. ") & "$NUMERORESOLUCION$</strong></td></tr><tr><td></td><td style='text-align: right;'><strong>Fondos $FUENTE_FINANCIAMIENTO$</strong></td></tr></TBODY></table>")

        ' textoContrato.Append(Encabezado.ToString)

        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0)
                'PERSONERIAJURIDICA
                textoContrato.Append("<table style='font-family:Times New Roman; text-align:justify; width:100%'><tr><td>")
                'textoContrato.Append(Server.HtmlEncode(ds.Tables(0).Rows(0).Item("PERSONERIAJURIDICA")))

                'CLAUSULAS
                For i = 0 To .Rows.Count - 1
                    'If i = 0 Then
                    '    textoContrato.Append("<BR><BR>")
                    'End If
                    ordenClausula = obtenerClausula(i + 1)

                    textoContrato.Append("<b>  <U>" & Server.HtmlEncode("CLÁUSULA " & ordenClausula) & ":</U> " & Server.HtmlEncode(.Rows(i).Item("NOMBRE")) & ".- </b>" & .Rows(i).Item("CONTENIDO"))
                Next
                textoContrato.Append("</td></tr><tr><td>")

                'textoContrato.Append(Server.HtmlEncode(ds.Tables(0).Rows(0).Item("ACTANOTARIAL")))
                textoContrato.Append("</td></tr></table>")

            End With
        End If
        'textoCompleto.Append(Replace(textoContrato.ToString, "<BR>", ""))
        'Return textoCompleto
        Return textoContrato
    End Function

    Private Sub reemplazarEtiquetas(ByVal textoContrato As StringBuilder)
        Try
            Dim textoReemplazado As String

            'OBTENIENDO LOS RENGLONES ADJUDICADOS
            Dim mComAdjudicacion As New cADJUDICACION
            Dim dsAdjudicacion As Data.DataSet
            'Dim dsEntregaAdjudicacion As Data.DataSet
            Dim tablaEntrega As New Text.StringBuilder
            dsAdjudicacion = mComAdjudicacion.ObtenerRenglonesAdjudicados(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)

            Dim i, j, RENGLON As Integer

            RENGLON = dsAdjudicacion.Tables(0).Rows(i).Item("RENGLON")
            'PRODUCTO = dsAdjudicacion.Tables(0).Rows(i).Item("NOMBRE")
            'UNIDADMEDIDA = dsAdjudicacion.Tables(0).Rows(i).Item("UNIDAD_MEDIDA")

            'OBTENIENDO LOS PLAZOS DE ENTREGA
            Dim mComEntregaAdjudicacion As New cENTREGAADJUDICACION
            Dim mComponenteEntregas As New cENTREGAADJUDICACION
            Dim lEntidadEntregas As New PROCESOCOMPRAS


            Dim arr As ArrayList = mComEntregaAdjudicacion.obtenerEntregasProveedor2(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)

            Dim entregaRenglon As Integer = 0
            Dim entregasText As New StringBuilder
            Dim entregasDias As New StringBuilder

            If arr.Count > 0 Then

                For k As Integer = 0 To arr.Count - 1

                    Dim s() As String = arr.Item(k)

                    If s(0) <> entregaRenglon Then 'Cambiamos de numeros de entrega, vamos a buscar los plazos

                        If entregaRenglon <> 0 Then
                            entregasText.Append("</u>: ")
                            entregasText.Append("<b>")
                            entregasText.Append(entregasDias)
                            entregasText.Append("</b>")
                        End If

                        entregasDias = New StringBuilder

                        Dim arr2 As ArrayList
                        arr2 = mComponenteEntregas.obtenerNumntregasProveedor2(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, s(1))


                        If arr2.Count = 1 Then
                            For l As Integer = 0 To arr2.Count - 1
                                Dim s2() As String = arr2.Item(l)
                                entregasDias.Append(s2(0))
                                entregasDias.Append("% a ")
                                entregasDias.Append(s2(1))
                                entregasDias.Append(" días. ")
                            Next
                        Else
                            For l As Integer = 0 To arr2.Count - 1
                                Dim s2() As String = arr2.Item(l)
                                entregasDias.Append(textoParaEntregas(l))
                                entregasDias.Append(s2(0))
                                entregasDias.Append("% a ")
                                entregasDias.Append(s2(1))
                                entregasDias.Append(" días. ")
                            Next
                        End If



                        entregasText.Append("<u>Para los renglones ")
                        entregasText.Append(s(1))
                        entregaRenglon = s(0)
                    Else
                        entregasText.Append(", ")
                        entregasText.Append(s(1))
                    End If

                Next

                entregasText.Append("</u>: ")
                entregasText.Append("<b>")
                entregasText.Append(entregasDias)
                entregasText.Append("</b>")

            End If



            'Dim PRODUCTO As String
            'Dim UNIDADMEDIDA As String

            'For i = 0 To dsAdjudicacion.Tables(0).Rows.Count - 1

            '    RENGLON = dsAdjudicacion.Tables(0).Rows(i).Item("RENGLON")
            '    'PRODUCTO = dsAdjudicacion.Tables(0).Rows(i).Item("NOMBRE")
            '    'UNIDADMEDIDA = dsAdjudicacion.Tables(0).Rows(i).Item("UNIDAD_MEDIDA")

            '    'OBTENIENDO LOS PLAZOS DE ENTREGA
            '    Dim mComEntregaAdjudicacion As New cENTREGAADJUDICACION
            '    Dim mComponenteEntregas As New cENTREGAADJUDICACION
            '    Dim lEntidadEntregas As New PROCESOCOMPRAS

            '    dsEntregaAdjudicacion = mComEntregaAdjudicacion.obtenerEntregasProveedor(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, RENGLON)

            '    'dsEntregas = mComponenteEntregas.obtenerNumntregasProveedor(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)
            '    tablaEntrega.Append("<table style='border-right: medium none; border-top: medium none; border-left: medium none; border-bottom: medium none; border-collapse: collapse' cellspacing=0 cellpadding=0 border=1>")
            '    tablaEntrega.Append("<tr>")
            '    '  tablaEntrega.Append("<td>Renglón</td>")
            '    'tablaEntrega.Append("<td>Nombre del producto</td>")
            '    'tablaEntrega.Append("<td>U/M</td></tr>")

            '    tablaEntrega.Append("<tr>")
            '    tablaEntrega.Append("<td><b>" & RENGLON & "</b></td>")
            '    'tablaEntrega.Append("<td><b>" & Server.HtmlEncode(PRODUCTO) & "</b></td>")
            '    'tablaEntrega.Append("<td><b>" & Server.HtmlEncode(UNIDADMEDIDA) & "</b></td></tr>")

            '    tablaEntrega.Append("<tr>")
            '    tablaEntrega.Append("<td><b>Entrega</b></td>")
            '    tablaEntrega.Append("<td><b>Porcentaje</b></td>")
            '    tablaEntrega.Append("<td><b>Días</b></td>")
            '    'tablaEntrega.Append("<td><b>Cantidad</b></td></tr>")

            '    If dsEntregaAdjudicacion.Tables(0).Rows.Count > 0 Then
            '        For j = 0 To dsEntregaAdjudicacion.Tables(0).Rows.Count - 1

            '            tablaEntrega.Append("<tr>")
            '            tablaEntrega.Append("<td>" & dsEntregaAdjudicacion.Tables(0).Rows(j).Item("IDENTREGA") & "</td>")
            '            tablaEntrega.Append("<td>" & dsEntregaAdjudicacion.Tables(0).Rows(j).Item("PORCENTAJE") & "</td>")
            '            tablaEntrega.Append("<td>" & dsEntregaAdjudicacion.Tables(0).Rows(j).Item("DIAS") & "</td>")

            '            'SE MODIFICA A PETICION DE LA UACI (NESTOR) Y SE MUESTRA CANTIDAD ENTERA
            '            'MAYRA MARTINEZ 140709
            '            ' tablaEntrega.Append("<td  align=right>" & CInt(dsEntregaAdjudicacion.Tables(0).Rows(j).Item("CANTIDAD")) & "</td></tr>")

            '            'If dsDetalleEntrega.Tables(0).Rows.Count > 0 Then
            '            '    For j = 0 To dsDetalleEntrega.Tables(0).Rows.Count - 1
            '            '        tablaEntrega.Append("<tr><td>" & dsDetalleEntrega.Tables(0).Rows(j).Item("DIAS") & "</td>")
            '            '        tablaEntrega.Append("<td>" & dsDetalleEntrega.Tables(0).Rows(j).Item("Porcentaje") & "</td></tr>")
            '            '    Next
            '            'End If

            '        Next
            '    End If
            tablaEntrega.Append("<font style='font-family:Times New Roman;FONT-SIZE: 12pt;'")
            tablaEntrega.Append(entregasText)
            tablaEntrega.Append("</font>")
            'Next

            'SISTITUYENDO LA ETIQUETA PLAZOS DE ENTREGA
            textoReemplazado = Replace(textoContrato.ToString, "$PLAZOS_ENTREGAS$", tablaEntrega.ToString)

            'OBTENIENDO NOMBRE ESTABLECIMIENTO
            textoReemplazado = Replace(textoReemplazado.ToString, "$NOMBRE_ESTABLECIMIENTO$", Server.HtmlEncode(Session.Item("UsuarioEstablecimiento").ToString))

            'OBTENIENDO CODIGO CONTRATO
            textoReemplazado = Replace(textoReemplazado.ToString, "$CODIGO_CONTRATO$", Server.HtmlEncode(Me.txtNumContrato.Text))

            'OBTENIENDO LA FUENTE DE FINANCIAMIENTO
            Dim ccs As New cFUENTEFINANCIAMIENTOSCONTRATOS
            Dim fuentefinanciamiento As String

            fuentefinanciamiento = ccs.ObtenerFuentesFinanciamientoContrato(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO)

            'SUSTITUYENDO FUENTE FINANCIAMIENTO
            textoReemplazado = Replace(textoReemplazado.ToString, "$FUENTE_FINANCIAMIENTO$", Server.HtmlEncode(fuentefinanciamiento))

            'OBTENIENDO DATOS DEL CONTRATANTE
            Dim Contratante As String
            Contratante = cPC.obtenerTitularAdjudicacion(Session("IdEstablecimiento"), Request.QueryString("IdProc")).Tables(0).Rows(0).Item("TITULAR")

            'SUSTITUYENDO NOMBRE DE CONTRATANTE
            textoReemplazado = Replace(textoReemplazado.ToString, "$CONTRATANTE$", Server.HtmlEncode(Contratante))

            'OBTENIENDO DIRECCION DEL CONTRATANTE
            Dim mComEst As New cESTABLECIMIENTOS

            Dim dsEst As Data.DataSet
            dsEst = mComEst.ObtenerUbicacionEstablecimiento(Session("IdEstablecimiento"))

            'SUSTITUYENDO UBICACION DEL CONTRATANTE
            textoReemplazado = Replace(textoReemplazado.ToString, "$DIRECCION_ESTABLECIMIENTO$", Server.HtmlEncode(dsEst.Tables(0).Rows(0).Item("DIRECCION").ToString))
            textoReemplazado = Replace(textoReemplazado.ToString, "$MUNICIPIO_ESTABLECIMIENTO$", Server.HtmlEncode(dsEst.Tables(0).Rows(0).Item("NOMBRE").ToString))

            Dim ds1 As Data.DataSet
            ds1 = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))
            If ds1.Tables(0).Rows(0).Item(0) <> 3 Then
                'OBTENIENDO EL CIFRADOPRESUPUESTARIO
                Dim CIFRADOPRESUPUESTARIO As String
                CIFRADOPRESUPUESTARIO = cPC.obtenerCifradoPresupuestario(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

                'SUSTITUYENDO CIFRADO PRESUPUESTARIO
                textoReemplazado = Replace(textoReemplazado.ToString, "$CIFRADO_PRESUPUESTARIO$", CIFRADOPRESUPUESTARIO)
            End If

            'OBTENER PARAMETROS DE FECHA DE FIRMA DE CONTRATO

            'obteniendo DIA 
            Dim lEntidadContrato As New CONTRATOS

            lEntidadContrato = cC.ObtenerCONTRATOS(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO)

            Dim DIA, MES, AÑO As String
            DIA = clsUtilitarios.Num2Text(CDate(lEntidadContrato.FECHAAPROBACION).Day)
            MES = MonthName(CDate(lEntidadContrato.FECHAAPROBACION).Month).ToUpper
            AÑO = clsUtilitarios.Num2Text(CDate(lEntidadContrato.FECHAAPROBACION).Year)

            'SUSTITUYENDO 
            textoReemplazado = Replace(textoReemplazado.ToString, "$DIA_FIRMA$", DIA)
            textoReemplazado = Replace(textoReemplazado.ToString, "$MES_FIRMA$", MES)
            textoReemplazado = Replace(textoReemplazado.ToString, "$AÑO_FIRMA$", AÑO)

            'OBTENIENDO DATOS DEL CONTRATISTA
            Dim mComProveedor As New cPROVEEDORES
            Dim lEntProveedor As New PROVEEDORES

            lEntProveedor = mComProveedor.ObtenerPROVEEDORES(IDPROVEEDOR)

            'SUSTITUYENDO DATOS DEL CONTRATISTA
            textoReemplazado = Replace(textoReemplazado.ToString, "$CONTRATISTA$", Server.HtmlEncode(lEntProveedor.REPRESENTANTELEGAL))
            textoReemplazado = Replace(textoReemplazado.ToString, "$DIRECCION_PROVEEDOR$", Server.HtmlEncode(lEntProveedor.DIRECCION))
            textoReemplazado = Replace(textoReemplazado.ToString, "$TELEFONO_PROVEEDOR$", Server.HtmlEncode(lEntProveedor.TELEFONO))
            textoReemplazado = Replace(textoReemplazado.ToString, "$CORREO_PROVEEDOR$", Server.HtmlEncode(lEntProveedor.CORREO))

            'OBTENIENDO EL NUMERO DE RESOLUCION
            Dim NUMERORESOLUCION As String
            NUMERORESOLUCION = cPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc")).Tables(0).Rows(0).Item("NUMERORESOLUCION").ToString

            If NUMERORESOLUCION = "" Then
                NUMERORESOLUCION = "N/D"
            End If

            'REEMPLEZANDO EL NUMERORESOLUCION
            textoReemplazado = Replace(textoReemplazado.ToString, "$NUMERORESOLUCION$", Server.HtmlEncode(NUMERORESOLUCION))

            'OBTENIENDO LA DESCRIPCION DEL PROCESO DE COMPRA
            Dim descLicitacion As String
            descLicitacion = cPC.ObtenerPROCESOCOMPRAS(Session("IdEstablecimiento"), Request.QueryString("IdProc")).DESCRIPCIONLICITACION

            'REEMPLEZANDO  LA DESCRIPCION DEL PROCESO DE COMPRA
            textoReemplazado = Replace(textoReemplazado.ToString, "$DESCRIPCION_PROCESO_COMPRA$", Server.HtmlEncode(descLicitacion))

            'OBTENIENDO EL LISTADO DE PRODUCTOS
            Dim cComAdjudicacion As New cADJUDICACION
            Dim dsRenglonesAdjudicados As Data.DataSet
            Dim tablaProductos As New Text.StringBuilder

            dsRenglonesAdjudicados = cComAdjudicacion.ObtenerRenglonesAdjudicados(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)

            'tablaProductos.Append("<table style='border-right: medium none; border-top: medium none; border-left: medium none; border-bottom: medium none; border-collapse: collapse; width: 100%;' cellspacing=0 cellpadding=0 border=1>")
            'tablaProductos.Append("<tr style='vertical-align: top;'>")
            'tablaProductos.Append("<td><b>Renglón</b></td>")
            'tablaProductos.Append("<td><b>Código</b></td>")
            'tablaProductos.Append("<td><b>Nombre del producto</b></td>")
            'tablaProductos.Append("<td><b>U/M</b></td>")
            'tablaProductos.Append("<td><b>Cantidad contratada</b></td>")
            'tablaProductos.Append("<td><b>Precio unitario (USD$)</b></td>")
            'tablaProductos.Append("<td><b>Valor total (USD$)</b></td></tr>")


            tablaProductos.Append("<table style='border-right: medium none; border-top: medium none; border-left: medium none; border-bottom: medium none; border-collapse: collapse; width: 100%;' cellspacing=0 cellpadding=0 border=1>")
            tablaProductos.Append("<tr style='vertical-align: top;'>")
            tablaProductos.Append("<td><b>Renglón</b></td>")
            tablaProductos.Append("<td><b>Código</b></td>")
            tablaProductos.Append("<td><b>U/M</b></td>")
            tablaProductos.Append("<td><b>Cantidad contratada</b></td>")
            tablaProductos.Append("<td><b>Precio unitario (USD$)</b></td>")
            tablaProductos.Append("<td><b>Valor total (USD$)</b></td></tr>")
            tablaProductos.Append("<tr><td></td>")
            tablaProductos.Append("<td><b>Nombre del producto</b></td>")
            tablaProductos.Append("<td colspan = '4'>&nbsp</td></tr> ")


            Dim total As Decimal

            For i = 0 To dsRenglonesAdjudicados.Tables(0).Rows.Count - 1
                tablaProductos.Append("<tr>")
                tablaProductos.Append("<td style='text-align: right'>" & dsRenglonesAdjudicados.Tables(0).Rows(i).Item("RENGLON") & "</td>")
                tablaProductos.Append("<td>" & dsRenglonesAdjudicados.Tables(0).Rows(i).Item("CODIGO") & "</td>")
                tablaProductos.Append("<td colspan = '4'>&nbsp</td></tr> ")
                tablaProductos.Append("<tr><td></td>")
                tablaProductos.Append("<td>" & Server.HtmlEncode(dsRenglonesAdjudicados.Tables(0).Rows(i).Item("NOMBRE").ToString) & "</td>")
                tablaProductos.Append("<td style='text-align: right'>" & Server.HtmlEncode(dsRenglonesAdjudicados.Tables(0).Rows(i).Item("UNIDAD_MEDIDA").ToString) & "</td>")

                'modificacion solicitada por Nestor UACI, 140709
                'modificacion revertida nuevamente por UACI, 07102011
                tablaProductos.Append("<td style='text-align: right'>" & Format(CDec(dsRenglonesAdjudicados.Tables(0).Rows(i).Item("CANTIDADFIRME")), "###,###.00") & "</td>")
                'tablaProductos.Append("<td style ='text-align: right'>" & Format(CInt(dsRenglonesAdjudicados.Tables(0).Rows(i).Item("CANTIDADFIRME")), "###,###") & "</td>")

                tablaProductos.Append("<td style='text-align: right'>" & CDec(dsRenglonesAdjudicados.Tables(0).Rows(i).Item("PRECIOUNITARIO")).ToString("###,##0.0000") & "</td>")
                tablaProductos.Append("<td style='text-align: right'>" & FormatCurrency(CDec(dsRenglonesAdjudicados.Tables(0).Rows(i).Item("VALORTOTAL")).ToString("###,##0.00")) & "</td></tr>")

                tablaProductos.Append("<tr><td/><td>" & Server.HtmlEncode(dsRenglonesAdjudicados.Tables(0).Rows(i).Item("DESCRIPCIONPROVEEDOR").ToString) & "</td><td/><td/><td/><td/></tr>")

                total += CDec(dsRenglonesAdjudicados.Tables(0).Rows(i).Item("VALORTOTAL"))
            Next

            tablaProductos.Append("<tr style='vertical-align: top;'>")
            tablaProductos.Append("<td></td>")
            tablaProductos.Append("<td></td>")
            tablaProductos.Append("<td></td>")
            tablaProductos.Append("<td></td>")
            tablaProductos.Append("<td><b>TOTAL (USD$)</b></td>")
            tablaProductos.Append("<td><b>" & FormatCurrency(total, , , TriState.True, TriState.True) & "</b></td></tr>")

            tablaProductos.Append("</table>")

            'SUSTITUYENDO LA ETIQUETA DE LISTADO DE PRODUCTOS
            textoReemplazado = Replace(textoReemplazado.ToString, "$LISTADO_PRODUCTOS$", tablaProductos.ToString)

            'OBTENIENDO LA DISTRIBUCION DE PRODUCTOS

            'PASO 1: OBTENER LA LISTA DE PRODUCTOS ADJUDICADOS
            Dim mComponenteEntregas1 As New cENTREGAADJUDICACION
            Dim dsProductos As Data.DataSet
            dsProductos = mComponenteEntregas1.obtenerRenglosAdjudicados(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)

            Dim cComEntregaAlmacen As New cALMACENESENTREGAADJUDICACION
            Dim tablaDistribucion As New Text.StringBuilder
            Dim IDDETALLE As Integer

            For i = 0 To dsProductos.Tables(0).Rows.Count - 1
                IDDETALLE = dsProductos.Tables(0).Rows(i).Item("IDDETALLE")
                RENGLON = dsProductos.Tables(0).Rows(i).Item("RENGLON")
                tablaDistribucion.Append("<table style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; ' cellSpacing=0 cellPadding=0 border=1>")
                tablaDistribucion.Append("<tr>")
                tablaDistribucion.Append("<td>Renglón</td>")
                tablaDistribucion.Append("<td>Nombre del producto</td>")
                tablaDistribucion.Append("<td>Cantidad</td></tr>")
                tablaDistribucion.Append("<tr>")
                tablaDistribucion.Append("<td style='text-align: right'>" & dsProductos.Tables(0).Rows(i).Item("RENGLON") & "</td>")
                tablaDistribucion.Append("<td>" & dsProductos.Tables(0).Rows(i).Item("NOMBRE") & "</td>")
                tablaDistribucion.Append("<td style='text-align: right'>" & dsProductos.Tables(0).Rows(i).Item("CANTIDADFIRME") & "</td></tr>")

                'dsAlmacen = cComEntregaAlmacen.obtenerAlmacenesAdjudicacion(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDDETALLE)

                'For j = 0 To dsAlmacen.Tables(0).Rows.Count - 1
                '    IDALMACEN = dsAlmacen.Tables(0).Rows(j).Item("IDALMACEN")
                '    ALMACEN = dsAlmacen.Tables(0).Rows(j).Item("ALMACEN")
                '    tablaDistribucion.Append("<tr>")
                '    tablaDistribucion.Append("<td style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; ' vAlign=top colspan=3><P style='MARGIN: 0cm 0cm 0pt'><center><b>Almacen: " & ALMACEN & "</b></center></td></tr>")
                '    tablaDistribucion.Append("<tr>")
                '    tablaDistribucion.Append("<td><b>Cantidad</b></td>")
                '    tablaDistribucion.Append("<td style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; ' vAlign=top colspan=2><P style='MARGIN: 0cm 0cm 0pt'><b>Dias</b></td></tr>")
                '    'tablaDistribucion.Append("<td><b>Porcentaje</b></td></tr>")
                '    dsDistribucion = cComEntregaAlmacen.obtenerDistribucionProducto(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDALMACEN, RENGLON)

                '    For k = 0 To dsDistribucion.Tables(0).Rows.Count - 1
                '        tablaDistribucion.Append("<tr>")
                '        tablaDistribucion.Append("<td>" & dsDistribucion.Tables(0).Rows(k).Item("CANTIDAD") & "</td>")
                '        tablaDistribucion.Append("<td style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; ' vAlign=top colspan=2><P style='MARGIN: 0cm 0cm 0pt'>" & dsDistribucion.Tables(0).Rows(k).Item("DIAS") & "</td></tr>")
                '        'tablaDistribucion.Append("<td>" & dsDistribucion.Tables(0).Rows(k).Item("PORCENTAJE") & "</td></tr>")
                '    Next
                'Next
                tablaDistribucion.Append("</table>")
            Next

            textoReemplazado = Replace(textoReemplazado.ToString, "$PROGRAMA_DISTRIBUCION$", tablaDistribucion.ToString)

            'OBTENIENDO EL MONTO DEL CONTRATO
            Dim dsContrato As Data.DataSet

            Dim MontoContrato As Decimal
            dsContrato = cC.obtenerMontoContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDCONTRATO)
            MontoContrato = dsContrato.Tables(0).Rows(0).Item("MONTOCONTRATO")

            MontoContrato = Decimal.Round(MontoContrato, 2, MidpointRounding.AwayFromZero)
            Dim MontoSinDecimales As Decimal = Fix(MontoContrato)
            Dim Decimales As Decimal = (MontoContrato - MontoSinDecimales) * 100

            textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_CONTRATO(Letras)$", clsUtilitarios.Num2Text(MontoSinDecimales))
            textoReemplazado = Replace(textoReemplazado.ToString, "$CENTAVOS_MONTO_CONTRATO$", clsUtilitarios.Num2Text(Decimales))
            textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_CONTRATO$", FormatCurrency(MontoContrato))


            If Me.Label27.Text <> "" Then
                Dim MontoSinDecimales1 As Decimal = Fix(CDec(Me.Label24.Text))
                Dim Decimales1 As Decimal = (CDec(Me.Label24.Text) - MontoSinDecimales1) * 100
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F1(Letras)$", clsUtilitarios.Num2Text(MontoSinDecimales1))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F1(Centavos)$", clsUtilitarios.Num2Text(Decimales1))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F1$", FormatCurrency(CDec(Me.Label24.Text)))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F1(Nombre)$", Me.Label27.Text)
            End If

            If Me.Label28.Text <> "" Then
                Dim MontoSinDecimales2 As Decimal = Fix(CDec(Me.Label25.Text))
                Dim Decimales2 As Decimal = (CDec(Me.Label25.Text) - MontoSinDecimales2) * 100
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F2(Letras)$", clsUtilitarios.Num2Text(MontoSinDecimales2))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F2(Centavos)$", clsUtilitarios.Num2Text(Decimales2))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F2$", FormatCurrency(CDec(Me.Label25.Text)))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F2(Nombre)$", Me.Label28.Text)
            End If

            If Me.Label29.Text <> "" Then
                Dim MontoSinDecimales3 As Decimal = Fix(CDec(Me.Label26.Text))
                Dim Decimales3 As Decimal = (CDec(Me.Label26.Text) - MontoSinDecimales3) * 100
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F3(Letras)$", clsUtilitarios.Num2Text(MontoSinDecimales3))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F3(Centavos)$", clsUtilitarios.Num2Text(Decimales3))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F3$", FormatCurrency(CDec(Me.Label26.Text)))
                textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F3(Nombre)$", Me.Label29.Text)
            End If

            'TODO : PROCESO 21 _tambien QUEMADO 
            'If Request.QueryString("IdProc") = 23 Or Request.QueryString("IdProc") = 27 Then
            '    Dim MontoSinDecimales1 As Decimal = Fix(CDec(Me.Label24.Text))
            '    Dim Decimales1 As Decimal = (CDec(Me.Label24.Text) - MontoSinDecimales1) * 100
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F1(Letras)$", clsUtilitarios.Num2Text(MontoSinDecimales1))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F1(Centavos)$", clsUtilitarios.Num2Text(Decimales1))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F1$", FormatCurrency(CDec(Me.Label24.Text)))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F1(Nombre)$", Me.Label27.Text)

            '    Dim MontoSinDecimales2 As Decimal = Fix(CDec(Me.Label25.Text))
            '    Dim Decimales2 As Decimal = (CDec(Me.Label25.Text) - MontoSinDecimales2) * 100
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F2(Letras)$", clsUtilitarios.Num2Text(MontoSinDecimales2))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F2(Centavos)$", clsUtilitarios.Num2Text(Decimales2))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F2$", FormatCurrency(CDec(Me.Label25.Text)))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F2(Nombre)$", Me.Label28.Text)

            '    Dim MontoSinDecimales3 As Decimal = Fix(CDec(Me.Label26.Text))
            '    Dim Decimales3 As Decimal = (CDec(Me.Label26.Text) - MontoSinDecimales3) * 100
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F3(Letras)$", clsUtilitarios.Num2Text(MontoSinDecimales3))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F3(Centavos)$", clsUtilitarios.Num2Text(Decimales3))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F3$", FormatCurrency(CDec(Me.Label26.Text)))
            '    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_F3(Nombre)$", Me.Label29.Text)
            'End If






            'OBTENIENDO LAS GARANTIAS PARA LOS CONTRATOS
            Dim ds2 As Data.DataSet
            ds2 = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            'VALIDAR SI ES LG O LP
            If ds2.Tables(0).Rows(0).Item(0) <> 3 Then
                Dim mComGarantia As New cGARANTIASCONTRATOS
                Dim dsGarantia As Data.DataSet

                'MONTO GARANTIA FIEL CUMPLIMIENTO
                dsGarantia = mComGarantia.obtenerDatosGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 1)

                Dim montoGcdec As Decimal
                Dim montosGdec As Decimal = 0
                Dim decMontoG As String = String.Empty

                If Not dsGarantia.Tables(0).Rows.Count = 0 Then
                    montosGdec = Fix(dsGarantia.Tables(0).Rows(0).Item("MONTO"))

                    If (CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")) - montosGdec) > 0 Then
                        montoGcdec = CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")) - MontoSinDecimales
                        decMontoG = montoGcdec & "/100"
                    End If

                    decMontoG = Replace(decMontoG, "0.", "")

                    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_FIEL_CUMPLIMIENTO$", clsUtilitarios.Num2Text(Format(CDec(MontoSinDecimales))) & " " & IIf(MontoSinDecimales > 0, Decimales, "") & " ( $" & Format(CDec(MontoContrato), "##,###.00") & ") DOLARES DE LOS ESTADOS UNIDOS DE AMERICA ")

                    'textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_FIEL_CUMPLIMIENTO$", Format(CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")), "###,###.00"))
                    'textoReemplazado = Replace(textoReemplazado.ToString, "$PORCENTAJE_FIEL_CUMPLIMIENTO$", clsUtilitarios.Num2Text(Format(CDec(dsGarantia.Tables(0).Rows(0).Item("PORCENTAJE")), "###.00")) & " (" & Format(CDec(dsGarantia.Tables(0).Rows(0).Item("PORCENTAJE")), "###.00") & ") por ciento ")
                    textoReemplazado = Replace(textoReemplazado.ToString, "$VIGENCIA_FIEL_CUMPLIMIENTO$", dsGarantia.Tables(0).Rows(0).Item("VIGENCIA"))
                Else

                End If

                dsGarantia = mComGarantia.obtenerDatosGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 2)

                montoGcdec = 0
                montosGdec = 0
                decMontoG = 0
                If Not dsGarantia.Tables(0).Rows.Count = 0 Then
                    montosGdec = Fix(dsGarantia.Tables(0).Rows(0).Item("MONTO"))

                    If (CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")) - montosGdec) > 0 Then
                        montoGcdec = CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")) - MontoSinDecimales
                        decMontoG = montoGcdec & "/100"
                    End If

                    decMontoG = Replace(decMontoG, "0.", "")

                    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_GARANTIA_CALIDAD$", clsUtilitarios.Num2Text(Format(CDec(MontoSinDecimales))) & " " & IIf(MontoSinDecimales > 0, Decimales, "") & " ( $" & Format(CDec(MontoContrato), "##,###.00") & ") DOLARES DE LOS ESTADOS UNIDOS DE AMERICA ")

                    'textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_GARANTIA_CALIDAD$", Format(CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")), "###,###.00"))

                    ''se comenta para verificar error Mayra 030809
                    'textoReemplazado = Replace(textoReemplazado.ToString, "$PORCENTAJE_GARANTIA_CALIDAD$", clsUtilitarios.Num2Text(Format(CDec(dsGarantia.Tables(0).Rows(0).Item("PORCENTAJE")), "###.00")) & " (" & Format(CDec(dsGarantia.Tables(0).Rows(0).Item("PORCENTAJE")), "###.00") & ") por ciento ")
                    textoReemplazado = Replace(textoReemplazado.ToString, "$VIGENCIA_GARANTIA_CALIDAD$", dsGarantia.Tables(0).Rows(0).Item("VIGENCIA"))
                Else

                End If

                dsGarantia = mComGarantia.obtenerDatosGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 7)

                montoGcdec = 0
                montosGdec = 0
                decMontoG = 0

                If Not dsGarantia.Tables(0).Rows.Count = 0 Then
                    montosGdec = Fix(dsGarantia.Tables(0).Rows(0).Item("MONTO"))

                    If (CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")) - montosGdec) > 0 Then
                        montoGcdec = CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")) - MontoSinDecimales
                        decMontoG = montoGcdec & "/100"
                    End If

                    decMontoG = Replace(decMontoG, "0.", "")

                    textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_GARANTIA_MANTENIMIENTO_OFERTA$", clsUtilitarios.Num2Text(Format(CDec(MontoSinDecimales))) & " " & IIf(MontoSinDecimales > 0, Decimales, "") & " ( $" & Format(CDec(MontoContrato), "##,###.00") & ") DOLARES DE LOS ESTADOS UNIDOS DE AMERICA ")

                    'textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_GARANTIA_MANTENIMIENTO_OFERTA$", Format(CDec(dsGarantia.Tables(0).Rows(0).Item("MONTO")), "###,###.00"))
                    textoReemplazado = Replace(textoReemplazado.ToString, "$VIGENCIA_GARANTIA_MANTENIMIENTO$", dsGarantia.Tables(0).Rows(0).Item("VIGENCIA"))
                Else

                End If
            End If

            'Obteniendo el código de la licitación
            textoReemplazado = Replace(textoReemplazado.ToString, "$CODIGO_LICITACION$", Server.HtmlEncode(Me.lblCodigoBase.Text))

            'Obteniendo el titulo de licitacion
            Dim ds As Data.DataSet
            Dim lEntProcesoCompra As New PROCESOCOMPRAS

            With lEntProcesoCompra
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                .IDPROCESOCOMPRA = Request.QueryString("IdProc")
            End With

            ds = cPC.recuperarDatosProcesoCompra(lEntProcesoCompra)

            'Titulo de Licitación
            textoReemplazado = Replace(textoReemplazado, "$TITULOLICITACION$", Server.HtmlEncode(ds.Tables(0).Rows(0).Item("TITULOLICITACION")))
            textoReemplazado = Replace(textoReemplazado, "$DESCRIPCION_LICITACION$", Server.HtmlEncode(ds.Tables(0).Rows(0).Item("DESCRIPCIONLICITACION")))

            'TODO: CAMBIO PORQUE LLEGA NULO
            If IsDBNull(ds.Tables(0).Rows(0).Item("GARANTIACUMPLIMIENTOENTREGA")) Then
                textoReemplazado = Replace(textoReemplazado, "$TIEMPO_ENTREGA_GARANTIA_CUMPLIMIENTO$", 0)
            Else
                textoReemplazado = Replace(textoReemplazado, "$TIEMPO_ENTREGA_GARANTIA_CUMPLIMIENTO$", ds.Tables(0).Rows(0).Item("GARANTIACUMPLIMIENTOENTREGA"))
            End If

            Try
                textoReemplazado = Replace(textoReemplazado, "$NUMERO_RESOLUCION$", Server.HtmlEncode(ds.Tables(0).Rows(0).Item("NUMERORESOLUCION")))
            Catch ex As Exception
                textoReemplazado = Replace(textoReemplazado, "$NUMERO_RESOLUCION$", "PENDIENTE NUMERO RESOLUCION")
            End Try

            Try
                textoReemplazado = Replace(textoReemplazado, "$GARANTIACALIDADENTREGA$", ds.Tables(0).Rows(0).Item("GARANTIACALIDADENTREGA"))
            Catch ex As Exception
                textoReemplazado = Replace(textoReemplazado, "$GARANTIACALIDADENTREGA$", 0)
            End Try

            'TODO: CAMBIO PORQUE LLEGA NULO 2
            If IsDBNull(ds.Tables(0).Rows(0).Item("GARANTIAMTTOENTREGA")) Then
                textoReemplazado = Replace(textoReemplazado, "$GARANTIAMTTOENTREGA$", 0)
            Else
                textoReemplazado = Replace(textoReemplazado, "$GARANTIAMTTOENTREGA$", ds.Tables(0).Rows(0).Item("GARANTIAMTTOENTREGA"))
            End If


            'TIPO DE COMPRAS
            Dim mComTipoCompra As New cTIPOCOMPRAS
            Dim lEntTipoCompras As New TIPOCOMPRAS

            lEntTipoCompras = mComTipoCompra.ObtenerTIPOCOMPRAS(ds.Tables(0).Rows(0).Item("IDTIPOCOMPRAEJECUTAR"))

            'textoReemplazado = Replace(textoReemplazado, "$TIPO_COMPRA$", Server.HtmlEncode(lEntTipoCompras.DESCRIPCION))
            ''textoReemplazado.Replace("$TIPO_COMPRA$", lEntTipoCompras.DESCRIPCION)
            ''textoReemplazado.Replace("<?xml:namespace prefix = o ns = " & Chr(34) & "urn:schemas-microsoft-com:office:office" & Chr(34) & " />", "")
            'textoReemplazado.Replace("<DIV class=Section1><SPAN lang=ES-GT><o:p><FONT face=Tahoma size=3>&nbsp; ", "")
            'textoReemplazado.Replace("<DIV class=Section1>", "")

            ''textoReemplazado = Replace(textoReemplazado, "<P align=justify>", "<font align=justify>")
            ''textoReemplazado = Replace(textoReemplazado, "</P>", "</font>")

            IDPROCESOCOMPRA = Request.QueryString("IdProc")

            'codigoLicita = Replace(Me.lblCodigoBase.Text, "/", "-")
            'codigoLicita = Replace(Me.lblCodigoBase.Text, " ", "_")

            Dim directorio As String
            Dim contrato As String


            contrato = "C" & IDCONTRATO & "PROV" & IDPROVEEDOR & ".htm"

            directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & IDPROCESOCOMPRA

            If Directory.Exists(Server.MapPath(directorio)) = False Then
                Alert("Verifique la configuración en el servidor, la carpeta " & directorio & " no ha sido creada", "Error")
                'Me.MsgBox2.ShowAlert("Verifique la configuración en el servidor, la carpeta " & directorio & " no ha sido creada", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
            Else
                If Directory.Exists(Server.MapPath(directorio & "\CONTRATOS\")) = False Then
                    Alert("Verifique la configuración en el servidor, la carpeta CONTRATOS de la carpeta " & directorio & " no ha sido creada", "Error")
                    'Me.MsgBox2.ShowAlert("Verifique la configuración en el servidor, la carpeta CONTRATOS de la carpeta " & directorio & " no ha sido creada", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                Else
                    If File.Exists(Server.MapPath(directorio & "\CONTRATOS\" & contrato)) Then
                        File.Delete(Server.MapPath(directorio & "\CONTRATOS\" & contrato))
                    End If

                    File.AppendAllText(Server.MapPath(directorio & "\CONTRATOS\" & contrato), "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><title></title></head>" & textoReemplazado.ToString & "</body></html>")

                    btnCargarArchivo.Visible = True
                    Me.fuContrato.Visible = True
                    Alert("El contrato se generó satisfactoriamente", "Exito!")
                    'Me.MsgBox2.ShowAlert("El contrato se generó satisfactoriamente", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                    'Me.Label18.Visible = True
                    Me.lbVerContrato.Visible = True
                End If
            End If

        Catch ex As Exception
            Me.MsgBox2.ShowAlert(ex.ToString, "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

        End Try


    End Sub

    Private Function obtenerClausula(ByVal pos As Integer) As String

        Dim numeroCLAUSULA As String = ""

        If pos > 10 And pos < 20 Then
            numeroCLAUSULA = "DÉCIMA "
            pos = pos - 10
        End If

        If pos > 20 And pos < 30 Then
            numeroCLAUSULA = "VIGÉSIMA "
            pos = pos - 20
        End If

        If pos > 30 And pos < 40 Then
            numeroCLAUSULA = "TRIGÉSIMA "
            pos = pos - 30
        End If

        If pos > 40 And pos < 50 Then
            numeroCLAUSULA = "CUADRAGÉSIMA "
            pos = pos - 40
        End If

        Select Case pos
            Case Is = 1
                numeroCLAUSULA += "PRIMERA"
            Case Is = 2
                numeroCLAUSULA += "SEGUNDA"
            Case Is = 3
                numeroCLAUSULA += "TERCERA"
            Case Is = 4
                numeroCLAUSULA += "CUARTA"
            Case Is = 5
                numeroCLAUSULA += "QUINTA"
            Case Is = 6
                numeroCLAUSULA += "SEXTA"
            Case Is = 7
                numeroCLAUSULA += "SÉPTIMA"
            Case Is = 8
                numeroCLAUSULA += "OCTAVA"
            Case Is = 9
                numeroCLAUSULA += "NOVENA"
            Case Is = 10
                numeroCLAUSULA += "DÉCIMA"
            Case Is = 20
                numeroCLAUSULA = "VIGÉSIMA"
            Case Is = 30
                numeroCLAUSULA = "TRIGÉSIMA"
            Case Is = 40
                numeroCLAUSULA = "CUADRAGÉSIMA"
            Case Is = 50
                numeroCLAUSULA = "QUINCUAGÉSIMA"

        End Select

        Return numeroCLAUSULA

    End Function

    Protected Sub LinkButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton7.Click

        GuardarPaso4()
        Me.LinkButton9.Enabled = True
        Me.Panel1.Visible = False
        Me.Panel7.Visible = True
        Me.Label9.Enabled = True
        Dim directorio As String
        Dim contrato As String

        ''TODO : PROCESO 21 _tambien QUEMADO 
        'If Request.QueryString("IdProc") = 23 Or Request.QueryString("IdProc") = 27 Then

        'Else
        '    Try
        '        'TODO :  Escribir codigo para que sume los montos del grid

        '        Me.lblMontoTotalCalc.Text = cC.obtenerMontoContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDCONTRATO).Tables(0).Rows(0).Item("MONTOCONTRATO")
        '    Catch ex As Exception
        '        Me.lblMontoTotalCalc.Text = "0.0"
        '    End Try
        'End If

        Me.lblCargaArchivo.ForeColor = Drawing.Color.Black

        contrato = "C" & IDCONTRATO & "PROV" & IDPROVEEDOR & ".doc"

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & Request.QueryString("IdProc")

        If File.Exists(Server.MapPath(directorio & "\CONTRATOS\" & contrato)) Then
            btnGenerarContrato.Visible = True
            Label18.Visible = False
            lbVerContrato.Visible = False
            fuContrato.Visible = False
            btnCargarArchivo.Visible = False
            btnLiberaContrato.Visible = True
            Me.btnAnexo1.Visible = True
            Me.Button3.Visible = True
            If Me.IDESTADOCONTRATO = 1 Then
                Me.fuContrato.Visible = True
                Me.btnCargarArchivo.Visible = True
                Label17.Text = "El contrato ya fue generado para este proveedor, puede descargarlo en el siguiente opción"
            Else
                Me.Label20.Visible = False
                Me.cpFechaAprobacion.Visible = False
                btnGenerarContrato.Visible = False
                Me.btnLiberaContrato.Visible = False
                Label17.Text = "El contrato ya fue liberado para este proveedor, puede descargarlo en el siguiente opción"
            End If
        Else
            lbContrato.Visible = False
        End If
        'habilita panel de contratos
        Me.Panel5.Visible = True
        Me.Panel7.Visible = False
        Button1_Click(sender, e)
        ' termina habilita panel de contratos
    End Sub

    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
        Me.Panel7.Visible = True
        Me.Panel5.Visible = False
        Me.obtenerClausulasPlantilla()
        Me.dgClausulas.CurrentPageIndex = 0
        Me.dgClausulas.SelectedIndex = -1
        flagSaveClausula = 0
    End Sub

    Protected Sub lbVerContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVerContrato.Click

        Dim contrato, directorio As String

        contrato = "C" & IDCONTRATO & "PROV" & IDPROVEEDOR & ".htm"

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & IDPROCESOCOMPRA

        Dim openWindow As String

        openWindow = "<script type=text/javascript> window.open('" & directorio & "/CONTRATOS/" & contrato & "',  '_blank') </script>"

        Response.Write(openWindow)
    End Sub

    Protected Sub btnCargarArchivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarArchivo.Click

        Dim contrato, directorio As String

        contrato = "C" & IDCONTRATO & "PROV" & IDPROVEEDOR & ".htm"

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & Request.QueryString("IdProc")

        If fuContrato.HasFile Then
            Try
                fuContrato.SaveAs(Server.MapPath(directorio & "\CONTRATOS\" & fuContrato.FileName))
                Label1.Text = "File name: " & _
                   fuContrato.PostedFile.FileName & "<br>" & _
                   "File Size: " & _
                   fuContrato.PostedFile.ContentLength & " kb<br>" & _
                   "Content type: " & _
                   fuContrato.PostedFile.ContentType
                btnLiberaContrato.Visible = True
                Me.MsgBox2.ShowAlert("El archivo se cargó satisfactoriamente", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                'Me.lblCargaArchivo.Text = "El archivo se cargó satisfactoriamente"
                'lblCargaArchivo.ForeColor = Drawing.Color.Red
            Catch ex As Exception
                Me.lblCargaArchivo.Text = "ERROR: " & ex.Message.ToString()
            End Try
        Else
            lblCargaArchivo.ForeColor = Drawing.Color.Black
            Label1.Text = "Debe especificar el archivo a cargar."
        End If

    End Sub

    Protected Sub lbContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbContrato.Click
        descargarArchivo()
        Me.fuContrato.Visible = True
        Me.btnCargarArchivo.Visible = True
    End Sub

    Private Sub descargarArchivo()

        Dim contrato, directorio As String

        contrato = "C" & IDCONTRATO & "PROV" & IDPROVEEDOR & ".doc"

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & Request.QueryString("IdProc")

        Dim path As String = Server.MapPath(directorio & "\CONTRATOS\" & contrato) 'get file object as FileInfo
        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server
        If file.Exists Then 'set appropriate headers
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            Response.AddHeader("Content-Length", file.Length.ToString())
            'Response.ContentType = "application/octet-stream"
            Response.ContentType = "application/octet-stream"
            'Response.
            Response.WriteFile(file.FullName)

            'Response.End() 'if file does not exist
        Else
            Response.Write("El archivo no existe, consulte con su administrador")
        End If 'nothing in the URL as HTTP GET

    End Sub

    Protected Sub btnLiberaContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLiberaContrato.Click
        MsgBox2.ShowConfirm("¿Desea liberar el contrato?, una vez liberado no podrá realizar modificaciones.", "LIBERAR", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub MsgBox2_YesChosen1(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.YesChosen
        Select Case e.Key
            Case Is = "LIBERAR"
                Dim lEntidad As New CONTRATOS

                With lEntidad
                    .AUFECHAMODIFICACION = Date.Today
                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    .ESTASINCRONIZADA = 0
                    .IDCONTRATO = IDCONTRATO
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    .IDESTADOCONTRATO = 2 ' Contrato Cerrado
                    .IDPROVEEDOR = IDPROVEEDOR

                End With
                cC.ActualizarEstadoContrato(lEntidad)
                IDCONTRATO = lEntidad.IDCONTRATO
                Me.Label20.Visible = False
                Me.cpFechaAprobacion.Visible = False
                Me.fuContrato.Visible = False
                Me.btnCargarArchivo.Visible = False
                btnGenerarContrato.Visible = False
                Me.lblCargaArchivo.Text = "El contrato fue liberado satisfactoriamente, desde este momento solo podrá realizar consultas al contrato generado."
                Me.lblCargaArchivo.ForeColor = Drawing.Color.Red
                Label17.Text = "El contrato ya fue liberado para este proveedor, puede descargarlo en el siguiente opción"
                Response.Redirect("~/UACI/FrmGenerarContratos.aspx")
        End Select
    End Sub

    Protected Sub lbDescargarArchivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbDescargarArchivo.Click
        descargarArchivo()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub dgRenglon_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRenglon.SelectedIndexChanged
        Me.Panel6.Visible = True
    End Sub

    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click
        Me.Panel1.Visible = True
        Me.Panel7.Visible = False
    End Sub

    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click
        'TODO TAMBIEN VERIFICAR
        'If sumar() = True Then
        'guardarFFC()
        Me.Panel5.Visible = True
        Me.Panel7.Visible = False
        Button1_Click(sender, e)
        'End If
    End Sub

    'Private Sub guardarFFC()

    '    Dim mComponente As New cFUENTEFINANCIAMIENTOSCONTRATOS
    '    Dim lEntidad As New FUENTEFINANCIAMIENTOSCONTRATOS
    '    Dim text As New TextBox
    '    Dim chk As New CheckBox

    '    For Each a As DataGridItem In Me.dgFuenteFinanciamiento.Items
    '        With lEntidad
    '            chk = a.FindControl("chkFF")
    '            text = a.FindControl("txtMonto")
    '            If chk.Checked = True Then
    '                If text.Text <> "" Then
    '                    With lEntidad
    '                        .IDCONTRATO = IDCONTRATO
    '                        .IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '                        .IDFUENTEFINANCIAMIENTO = Me.dgFuenteFinanciamiento.Items(a.ItemIndex).Cells(3).Text
    '                        .IDPROVEEDOR = IDPROVEEDOR
    '                        .MONTOCONTRATADO = CDec(text.Text)
    '                        .AUFECHACREACION = Date.Today
    '                        .AUFECHAMODIFICACION = Date.Today
    '                        .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '                        .ESTASINCRONIZADA = 0
    '                        .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '                    End With

    '                    Dim mComFFC As New cFUENTEFINANCIAMIENTOSCONTRATOS
    '                    Dim indice As Integer

    '                    indice = mComFFC.validaExisteFuenteFinaciamientoContrato(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, Me.dgFuenteFinanciamiento.Items(a.ItemIndex).Cells(3).Text)

    '                    If indice > 0 Then
    '                        mComponente.ActualizarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
    '                    Else
    '                        mComponente.AgregarFUENTEFINANCIAMIENTOSCONTRATOS(lEntidad)
    '                    End If

    '                End If
    '            Else
    '                Dim IDFFC As Integer
    '                IDFFC = Me.dgFuenteFinanciamiento.Items(a.ItemIndex).Cells(3).Text
    '                mComponente.EliminarFUENTEFINANCIAMIENTOSCONTRATOS(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, IDFFC)
    '            End If

    '        End With
    '    Next

    'End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim i As Integer
        'Dim suma As Decimal

        'For i = 0 To Me.dgFuenteFinanciamiento.Items.Count - 1
        '    Dim textbox As TextBox = CType(Me.dgFuenteFinanciamiento.Items(i).FindControl("txtMonto"), TextBox)
        '    Dim chk As CheckBox = CType(Me.dgFuenteFinanciamiento.Items(i).FindControl("chkFF"), CheckBox)

        '    If chk.Checked Then
        '        If textbox.Text = "" Then
        '            textbox.Text = "0"
        '        End If
        '        suma += CDec(textbox.Text)
        '    Else
        '        textbox.Text = "0"
        '    End If
        'Next

        'Dim cc As New cCONTRATOS

        'Dim montoContrato As Decimal
        'montoContrato = cc.obtenerMontoContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDCONTRATO).Tables(0).Rows(0).Item("MONTOCONTRATO")

        'If suma > montoContrato Then
        '    Me.MsgBox2.ShowAlert("La suma no puede ser mayor que el monto del contrato asignado, el monto del contrato es $" & Format(CDec(montoContrato), "###,###.00"), "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        '    Me.lblError.Text = "No es válido"
        'ElseIf suma < montoContrato Then
        '    Me.MsgBox2.ShowAlert("La suma no puede ser menor que el monto del contrato asignado, el monto del contrato es $" & Format(CDec(montoContrato), "###,###.00"), "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        '    Me.lblError.Text = "No es válido"

        'Else
        '    Me.lblError.Text = ""
        '    Me.LinkButton9.Enabled = True
        'End If

        'Me.lblMontoTotal.Text = "$" & CStr(suma)
        sumar()
    End Sub

    Private Function sumar() As Boolean
        'Dim i As Integer
        'Dim suma As Decimal
        'Dim RESULTADO As Boolean = True
        ''TODO: QUEMADO PROCESO 21 _tambien
        'If Request.QueryString("IdProc") = 23 Or Request.QueryString("IdProc") = 27 Then

            If Label24.Text = "" Then
                Me.Label24.Text = "0"
            End If
            If Label25.Text = "" Then
                Me.Label25.Text = "0"
            End If
            If Label26.Text = "" Then
                Me.Label26.Text = "0"
            End If


        '    If CDec(lblMontoTotalCalc.Text) > CDec(Me.Label24.Text) + CDec(Me.Label25.Text) + CDec(Me.Label26.Text) Then
        '        Me.MsgBox2.ShowAlert("La suma no puede ser mayor que el monto del contrato asignado, el monto del contrato es $" & Format(CDec(lblMontoTotalCalc.Text), "###,###.00"), "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
            '    Me.lblError.Text = "No es válido"
            '    RESULTADO = False
        '    ElseIf CDec(lblMontoTotalCalc.Text) < CDec(Me.Label24.Text) + CDec(Me.Label25.Text) + CDec(Me.Label26.Text) Then
        '        Me.MsgBox2.ShowAlert("La suma no puede ser menor que el monto del contrato asignado, el monto del contrato es $" & Format(CDec(lblMontoTotalCalc.Text), "###,###.00"), "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
            '    Me.lblError.Text = "No es válido"
            '    RESULTADO = False
            'Else
            '    Me.lblError.Text = ""
        '        Me.LinkButton9.Enabled = True
        '        RESULTADO = True
        '    End If
        '    Me.lblMontoTotal.Text = "$" & CStr(lblMontoTotalCalc.Text)
        '    Return RESULTADO
        '    Me.lblMontoTotal.Text = "$" & CStr(lblMontoTotalCalc.Text)
        '    Return RESULTADO
        'Else
        '    For i = 0 To Me.dgFuenteFinanciamiento.Items.Count - 1
        '        Dim textbox As TextBox = CType(Me.dgFuenteFinanciamiento.Items(i).FindControl("txtMonto"), TextBox)
        '        Dim chk As CheckBox = CType(Me.dgFuenteFinanciamiento.Items(i).FindControl("chkFF"), CheckBox)

        '        If chk.Checked Then
        '            If textbox.Text = "" Then
        '                textbox.Text = "0"
        '            End If
        '            suma += CDec(textbox.Text)
        '            'Else
        '            '    textbox.Text = "0"
        '        End If
        '    Next

        '    Dim montoContrato As Decimal
        '    'Try
        '    montoContrato = cC.obtenerMontoContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDCONTRATO).Tables(0).Rows(0).Item("MONTOCONTRATO")
        '    'Catch ex As Exception
        '    'montoContrato = 0
        '    'End Try
        '    'If suma > montoContrato Then
        '    '    Me.MsgBox2.ShowAlert("La suma no puede ser mayor que el monto del contrato asignado, el monto del contrato es $" & Format(CDec(montoContrato), "###,###.00"), "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        '    '    Me.lblError.Text = "No es válido"
        '    '    RESULTADO = False
        '    'ElseIf suma < montoContrato Then
        '    '    Me.MsgBox2.ShowAlert("La suma no puede ser menor que el monto del contrato asignado, el monto del contrato es $" & Format(CDec(montoContrato), "###,###.00"), "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        '    '    Me.lblError.Text = "No es válido"
        '    '    RESULTADO = False
        '    'Else
        '    '    Me.lblError.Text = ""
        '    Me.LinkButton9.Enabled = True
        '    RESULTADO = True
        '    'End If
        '    'Me.lblMontoTotal.Text = "$" & CStr(suma)
        '    Me.lblMontoTotal.Text = "$" & montoContrato
        '    Return RESULTADO
            'End If

    End Function

    Protected Sub chkFF_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.LinkButton9.Enabled = False
        Me.lblMontoTotal.Text = "$0"
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Response.Write("<script language=javascript>")
        'Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/frmRptDistribucionAdjudicadoXProveedor2.aspx?id=" & Request.QueryString("IdProc") & "&Pr=" & IDPROVEEDOR & "');")
        'Response.Write("</script>")
        Dim cad = "/Reportes/frmRptDistribucionAdjudicadoXProveedor2.aspx?id=" & Request.QueryString("IdProc") & "&Pr=" & IDPROVEEDOR
        SINAB_Utils.Utils.MostrarVentana(cad)
    End Sub


End Class
