
Partial Class FrmInformeMuestras
    Inherits System.Web.UI.Page

    Private _IDPROCESOCOMPRA As Integer
    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _RENGLON As Integer
    Private _IDPRODUCTO As Integer
    Private _IDINFORME As Integer
    Private _IDESTADO As Integer
    Private _IDTIPOINFORME As Integer
    Private _nuevo As Boolean = False
    Private _IDESTABLECIMIENTOCONTRATO As Integer

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
    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property
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
    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Integer)
            _RENGLON = value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", value)
        End Set
    End Property
    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property
    Public Property IDINFORME() As Integer
        Get
            Return _IDINFORME
        End Get
        Set(ByVal value As Integer)
            _IDINFORME = value
            If Not Me.ViewState("IDINFORME") Is Nothing Then Me.ViewState.Remove("IDINFORME")
            Me.ViewState.Add("IDINFORME", value)
        End Set
    End Property
    Public Property IDESTADO() As Integer
        Get
            Return _IDESTADO
        End Get
        Set(ByVal Value As Integer)
            Me._IDESTADO = Value
            If Not Me.ViewState("IDESTADO") Is Nothing Then Me.ViewState.Remove("IDESTADO")
            Me.ViewState.Add("IDESTADO", Value)
        End Set
    End Property
    Public Property IDTIPOINFORME() As Integer
        Get
            Return _IDTIPOINFORME
        End Get
        Set(ByVal Value As Integer)
            Me._IDTIPOINFORME = Value
            If Not Me.ViewState("IDTIPOINFORME") Is Nothing Then Me.ViewState.Remove("IDTIPOINFORME")
            Me.ViewState.Add("IDTIPOINFORME", Value)
        End Set
    End Property
    Public Property IDESTABLECIMIENTOCONTRATO() As Integer
        Get
            Return _IDESTABLECIMIENTOCONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDESTABLECIMIENTOCONTRATO = Value
            If Not Me.ViewState("IDESTABLECIMIENTOCONTRATO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTOCONTRATO")
            Me.ViewState.Add("IDESTABLECIMIENTOCONTRATO", Value)
        End Set
    End Property
    Public Event ErrorEvent(ByVal errorMessage As String)
    Public Event Guardar(ByVal errorMessage As String)
    Public Event Cancelar()
    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Dim dPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
            Me.GridView1.DataSource = dPC.ObtenerProcesoCompraAdjudicados()
            Me.GridView1.DataBind()
        Else
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.RENGLON = Me.ViewState("RENGLON")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("IDINFORME") Is Nothing Then Me.IDINFORME = Me.ViewState("IDINFORME")
            If Not Me.ViewState("IDESTADO") Is Nothing Then Me._IDESTADO = Me.ViewState("IDESTADO")
            If Not Me.ViewState("IDTIPOINFORME") Is Nothing Then Me._IDTIPOINFORME = Me.ViewState("IDTIPOINFORME")
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDESTABLECIMIENTOCONTRATO") Is Nothing Then Me._nuevo = Me.ViewState("IDESTABLECIMIENTOCONTRATO")
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Me.pnProveedores.Visible = True
        Dim cP As New ABASTECIMIENTOS.NEGOCIO.cPROVEEDORES
        IDPROCESOCOMPRA = Me.GridView1.DataKeys(e.NewSelectedIndex).Values(1)
        IDESTABLECIMIENTO = Me.GridView1.DataKeys(e.NewSelectedIndex).Values(0)

        Me.lblEstablecimiento.Text = Server.HtmlDecode(Me.GridView1.Rows(e.NewSelectedIndex).Cells(3).Text)
        Me.lblNPC.Text = Server.HtmlDecode(CType(Me.GridView1.Rows(e.NewSelectedIndex).FindControl("Linkbutton1"), LinkButton).Text)
        Me.lblPC.Text = Server.HtmlDecode(Me.GridView1.Rows(e.NewSelectedIndex).Cells(1).Text)

        Me.GridView2.DataSource = cP.obtenerProveedoresAdj(IDESTABLECIMIENTO, IDPROCESOCOMPRA, True, Session.Item("IdEmpleado"))
        Me.GridView2.DataBind()



        Me.GridView2.SelectedIndex = -1
        Me.GridView3.SelectedIndex = -1
        Me.pnRenglones.Visible = False
    End Sub

    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView2.SelectedIndexChanging
        Me.pnRenglones.Visible = True
        Dim cA As New ABASTECIMIENTOS.NEGOCIO.cADJUDICACION
        IDPROVEEDOR = Me.GridView2.DataKeys(e.NewSelectedIndex).Values(0)
        IDCONTRATO = Me.GridView2.DataKeys(e.NewSelectedIndex).Values(1)
        IDESTABLECIMIENTOCONTRATO = Me.GridView2.DataKeys(e.NewSelectedIndex).Values(2)
        Me.lblProveedor.Text = Server.HtmlDecode(CType(Me.GridView2.Rows(e.NewSelectedIndex).FindControl("Linkbutton1"), LinkButton).Text)
        Me.lblNoDoc.Text = Server.HtmlDecode(Me.GridView2.Rows(e.NewSelectedIndex).Cells(1).Text)

        Me.GridView3.DataSource = cA.ObtenerRenglonesAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, Session.Item("IdEmpleado"))
        Me.GridView3.DataBind()
    End Sub

    Protected Sub GridView3_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView3.SelectedIndexChanging
        Me.lblRenglon.Text = Server.HtmlDecode(CType(Me.GridView3.Rows(e.NewSelectedIndex).FindControl("Linkbutton1"), LinkButton).Text)
        RENGLON = Me.lblRenglon.Text
        Me.lblProducto.Text = Server.HtmlDecode(Me.GridView3.Rows(e.NewSelectedIndex).Cells(1).Text) & " - " & Server.HtmlDecode(Me.GridView3.Rows(e.NewSelectedIndex).Cells(2).Text)
        Me.Label4.Text = Server.HtmlDecode(Me.GridView3.Rows(e.NewSelectedIndex).Cells(2).Text)
        Me.txtUM2.Text = Me.GridView3.DataKeys(e.NewSelectedIndex).Values.Item("UNIDAD_MEDIDA")
        Me.txtUM3.Text = Me.GridView3.DataKeys(e.NewSelectedIndex).Values.Item("UNIDAD_MEDIDA")
        IDPRODUCTO = Me.GridView3.DataKeys(e.NewSelectedIndex).Values.Item("IDPRODUCTO")

        Me.pnRenglones.Visible = False
        Me.pnProveedores.Visible = False
        Me.pnPC.Visible = False
        Me.pnMan.Visible = True

        'Me.ddlUNIDADMEDIDAS1.RecuperarPorSuministro(1)
        'Me.DdlUNIDADMEDIDAS2.RecuperarPorSuministro(1)
        Me.Button1.Visible = False
        Me.Button2.Visible = False

        Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Me.GridView4.DataSource = cIM.ObtenerLotesNotificados(IDESTABLECIMIENTO, IDPROVEEDOR, Me.lblRenglon.Text, IDPROCESOCOMPRA, IDCONTRATO, Session("IdEmpleado"))
        Me.GridView4.DataBind()



    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Me.pnRenglones.Visible = True
        Me.pnProveedores.Visible = True
        Me.pnPC.Visible = True
        Me.pnMan.Visible = False
        Me.Panel1.Visible = False

        Me.GridView3.SelectedIndex = -1
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Me.Panel1.Visible = True
    'End Sub

    'Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    Me.Panel1.Visible = False
    '    Me.GridView4.SelectedIndex = -1
    'End Sub

    'Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
    '    Dim IM As New ABASTECIMIENTOS.ENTIDADES.INFORMEMUESTRAS
    '    'validaciones
    '    If Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Then
    '        Me.lblLaboratorioFa.Text = "El nombre comercial/Laboratorio fabricante/No.de lote son requeridos."
    '        Exit Sub
    '    End If
    '    If CDate((Me.DropDownList3.SelectedValue & Me.DropDownList4.SelectedValue)) < Now Then
    '        Me.lblLaboratorioFa.Text = "La fecha de vencimiento debe ser posterior a la fecha actual."
    '        Exit Sub
    '    End If

    '    Try

    '        IM.IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '        IM.IDINFORME = 0
    '        IM.IDTIPOINFORME = eTIPOINFORME.ACEPTACION
    '        'im.NUMEROINFORME =
    '        IM.IDESTADO = 1
    '        IM.IDESTABLECIMIENTOCONTRATO = IDESTABLECIMIENTO
    '        IM.IDPROVEEDOR = IDPROVEEDOR
    '        IM.IDCONTRATO = IDCONTRATO
    '        IM.RENGLON = RENGLON
    '        IM.NOMBREMEDICAMENTO = Me.Label4.Text
    '        IM.NOMBRECOMERCIAL = Me.TextBox2.Text
    '        IM.LABORATORIOFABRICANTE = Me.TextBox3.Text
    '        IM.PROVEEDOR = Me.lblProveedor.Text
    '        IM.LOTE = Me.TextBox4.Text
    '        IM.FECHAFABRICACION = Me.DropDownList1.SelectedValue & Me.DropDownList2.SelectedValue
    '        IM.FECHAVENCIMIENTO = Me.DropDownList3.SelectedValue & Me.DropDownList4.SelectedValue
    '        IM.NUMEROUNIDADES = Me.GridView4.DataKeys(Me.GridView4.SelectedIndex).Values(2)
    '        IM.CANTIDADREMITIDA = Me.NumericBox1.Text
    '        IM.ESTABLECIMIENTOREMITE = ""
    '        'im.NUMERORECEPCION =
    '        'im.GUIAAEREA =
    '        'im.DESCRIPCIONEMPAQUE =
    '        IM.LEYENDAREQUERIDA = 0
    '        IM.NUMEROREGISTRO = 0
    '        IM.VIAADMINISTRACION = 0
    '        IM.FORMADISOLUCION = 0
    '        IM.CONDICIONESALMACENAMIENTO = 0
    '        IM.NUMEROLOTE = 0
    '        IM.FECHAEXPIRACION = 0
    '        IM.OTROSEMPAQUES = 0
    '        'im.DESCRIPCIONOTROSEMPAQUES =
    '        'im.DESCRIPCIONPRODUCTO =
    '        IM.CANTIDADFISICOQUIMICO = 0
    '        IM.CANTIDADMICROBIOLOGIA = 0
    '        IM.CANTIDADRETENCION = 0

    '        IM.IDINSPECTOR = Session("IdEmpleado")
    '        IM.FECHAELABORACIONINFORME = Now
    '        IM.IDCOORDINADOR = 0

    '        IM.AUUSUARIOCREACION = User.Identity.Name
    '        IM.AUFECHACREACION = Now
    '        IM.ESTASINCRONIZADA = 0

    '        IM.FECHANOTIFICACION = Me.CalendarPopup1.SelectedDate
    '        IM.NUMERONOTIFICACION = Me.TextBox1.Text
    '        IM.CANTIDADAENTREGAR = Me.NumericBox2.Text
    '        IM.IdProcesoCompra = IdProcesoCompra
    '        IM.IDPRODUCTO = IDPRODUCTO

    '        If Me.GridView4.SelectedIndex <> -1 Then
    '            IM.IDINFORME = Me.GridView4.DataKeys(Me.GridView4.SelectedIndex).Values(0)
    '        End If
    '        cIM.ActualizarINFORMEMUESTRAS(IM)

    '        Me.Panel1.Visible = False
    '        Me.lblLaboratorioFa.Text = ""
    '        Me.GridView4.DataSource = cIM.ObtenerLotesNotificados(IDESTABLECIMIENTO, IDPROVEEDOR, Me.lblRenglon.Text, IdProcesoCompra, IDCONTRATO, Session("IdEmpleado"))
    '        Me.GridView4.SelectedIndex = -1
    '        Me.GridView4.DataBind()
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Protected Sub GridView4_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView4.RowDeleting
    '    Dim IDINFORME As Integer = Me.GridView4.DataKeys(e.RowIndex).Values(0)

    '    Dim CIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
    '    Try
    '        CIM.EliminarINFORMEMUESTRAS(IDESTABLECIMIENTO, IDINFORME)
    '    Catch ex As Exception

    '    End Try
    '    Me.GridView4.DataSource = CIM.ObtenerLotesNotificados(IDESTABLECIMIENTO, IDPROVEEDOR, Me.lblRenglon.Text, IdProcesoCompra, IDCONTRATO)
    '    Me.GridView4.SelectedIndex = -1
    '    Me.GridView4.DataBind()

    'End Sub

    'Protected Sub GridView4_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView4.SelectedIndexChanging

    '    Me.TextBox2.Text = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(2).Text)
    '    Me.TextBox3.Text = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(3).Text)
    '    Me.TextBox4.Text = Server.HtmlDecode(CType(Me.GridView4.Rows(e.NewSelectedIndex).FindControl("Linkbutton3"), LinkButton).Text)


    '    Me.DropDownList1.SelectedValue = CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(5).Text)).Day & "/" & CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(5).Text)).Month
    '    Me.DropDownList2.SelectedValue = "/" & CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(5).Text)).Year

    '    Me.DropDownList3.SelectedValue = CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(6).Text)).Day & "/" & CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(6).Text)).Month
    '    Me.DropDownList4.SelectedValue = "/" & CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(6).Text)).Year

    '    Me.NumericBox2.Text = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(4).Text)
    '    Me.CalendarPopup1.SelectedDate = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(1).Text)
    '    Me.TextBox1.Text = Me.GridView4.DataKeys(e.NewSelectedIndex).Values(1)

    '    If String.IsNullOrEmpty(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(7).Text)) Then
    '        Me.NumericBox1.Text = 0
    '    Else
    '        Me.NumericBox1.Text = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(7).Text)
    '    End If

    '    Me.Panel1.Visible = True

    'End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    If Me.GridView4.Rows.Count <> 0 Then
    '        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptNotificacionLotes.aspx?Renglon=" & Me.lblRenglon.Text & "&IdE=" & IDESTABLECIMIENTO & "&idProveedor=" & IDPROVEEDOR & "&IdP=" & IdProcesoCompra & "&idContrato=" & IDCONTRATO & "&um=" & Me.lblNombrecomercial2.Text & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")
    '    Else

    '    End If

    'End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)


        Me.DropDownList1.Enabled = edicion
        Me.DropDownList2.Enabled = edicion

        Me.DropDownList3.Enabled = edicion
        Me.DropDownList4.Enabled = edicion

        Me.RadioButtonList1.Enabled = edicion
        Me.DropDownList5.Enabled = edicion

        Me.txtESTABLECIMIENTOREMITE.Enabled = edicion
        Me.rfvESTABLECIMIENTOREMITE.Visible = edicion

        Me.txtDESCRIPCIONEMPAQUE.Enabled = edicion
        Me.rfvDESCRIPCIONEMPAQUE.Visible = edicion

        Me.cbLEYENDAREQUERIDA.Enabled = edicion
        Me.cbNUMEROREGISTRO.Enabled = edicion
        Me.cbVIAADMINISTRACION.Enabled = edicion
        Me.cbFORMADISOLUCION.Enabled = edicion
        Me.cbCONDICIONESALMACENAMIENTO.Enabled = edicion
        Me.cbNUMEROLOTE.Enabled = edicion
        Me.cbFECHAEXPIRACION.Enabled = edicion
        Me.cbOTROSEMPAQUES.Enabled = edicion
        Me.txtDESCRIPCIONOTROSEMPAQUES.Enabled = edicion
        Me.txtDescripcionDilucion.Enabled = edicion

        Me.txtDESCRIPCIONPRODUCTO.Enabled = edicion
        Me.rfvDESCRIPCIONPRODUCTO.Visible = edicion

        Me.nbCANTIDADFISICOQUIMICO.Enabled = edicion
        Me.rfvCANTIDADFISICOQUIMICO.Visible = edicion

        Me.nbCANTIDADMICROBIOLOGIA.Enabled = edicion
        Me.rfvCANTIDADMICROBIOLOGIA.Visible = edicion

        Me.nbCANTIDADRETENCION.Enabled = edicion
        Me.rfvCANTIDADRETENCION.Visible = edicion

        Me.txtDESCRIPCIONCONDICIONESALMACENAMIENTO.Enabled = edicion

        Me.txtMOTIVOSNOINSPECCION.Enabled = edicion
        Me.rfvMOTIVOSNOINSPECCION.Visible = edicion

        Me.txtMotivoNoAceptacion.Enabled = edicion
        Me.rfvMotivosNoAceptacion.Enabled = edicion

        Me.txtREPRESENTANTEPROVEEDOR.Enabled = edicion
        Me.rfvREPRESENTANTEPROVEEDOR.Visible = edicion

        Me.txtOBSERVACION.Enabled = edicion

        Me.cpFECHAELABORACIONINFORME.Enabled = edicion
        Me.rfvFECHAELABORACIONINFORME.Visible = edicion
        'Me.cvFECHAELABORACIONINFORME1.Visible = edicion
        Me.cvFECHAELABORACIONINFORME2.Visible = edicion

        Me.ddlCOORDINADORCC.Enabled = edicion

        Me.txtCCF.Enabled = edicion
        Me.TextBox6.Enabled = edicion
        Me.TextBox5.Enabled = edicion
        Me.TextBox4.Enabled = edicion
        Me.TextBox3.Enabled = edicion
        Me.TextBox2.Enabled = edicion
        Me.TextBox7.Enabled = edicion
        Me.TextBox8.Enabled = edicion
        Me.TextBox9.Enabled = edicion
        Me.TextBox10.Enabled = edicion
        Me.TextBox11.Enabled = edicion
        Me.CheckBoxList1.Enabled = edicion
        Me.RequiredFieldValidator6.Enabled = edicion
    End Sub

    Private Sub TipoInforme(ByVal TIPOINFORME As Integer)

        Select Case TIPOINFORME

            Case eTIPOINFORME.ACEPTACION

                Me.plRechazo.Visible = False
                Me.plNoInspeccion.Visible = False
                Me.plRepresentanteProveedor.Visible = False
                Me.plDatosFinales.Visible = True

                Me.plBotones.Visible = True
                If Me.ViewState("nuevo") Then
                    HabilitarEdicion(True)
                End If

            Case eTIPOINFORME.RECHAZO

                Me.plRechazo.Visible = True
                Me.plNoInspeccion.Visible = False
                Me.plRepresentanteProveedor.Visible = True
                Me.plDatosFinales.Visible = True

                Me.plBotones.Visible = True

            Case eTIPOINFORME.NOINSPECCION

                Me.plRechazo.Visible = False
                Me.plNoInspeccion.Visible = True
                Me.plRepresentanteProveedor.Visible = True
                Me.plDatosFinales.Visible = True

                Me.plBotones.Visible = True

            Case Else
                'error
        End Select

    End Sub

    Dim mEntidad As ABASTECIMIENTOS.ENTIDADES.INFORMEMUESTRAS
    Dim Certificacion As Boolean = False

    Private Sub CargarDatos()

        mEntidad = New ABASTECIMIENTOS.ENTIDADES.INFORMEMUESTRAS

        Dim mComponente As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        mEntidad.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
        mEntidad.IDINFORME = Me.IDINFORME

        If mComponente.ObtenerInformeMuestrasContrato2(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener registro.")
            Return
        End If

        Me.IDESTADO = mEntidad.IDESTADO
        Me.IDTIPOINFORME = mEntidad.IDTIPOINFORME
        Dim cad = "/Reportes/FrmRptInformeMuestras.aspx?idE=" + Me.IDESTABLECIMIENTO.ToString + "&idI=" + Me.IDINFORME.ToString + "&idTI=" + Me.IDTIPOINFORME.ToString + "&C=" + Certificacion.ToString.ToLower
        Me.btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
        '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptInformeMuestras.aspx?idE=" + Me.IDESTABLECIMIENTO.ToString + "&idI=" + Me.IDINFORME.ToString + "&idTI=" + Me.IDTIPOINFORME.ToString + "&C=" + Certificacion.ToString.ToLower + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

        Me.btnImprimir.Visible = True

        TipoInforme(mEntidad.IDTIPOINFORME)

        Dim IDEMPLEADO As Integer = Session.Item("IdEmpleado")
        If mEntidad.IDINSPECTOR = IDEMPLEADO Then
            Me.ddlCOORDINADORCC.Items.Remove(Me.ddlCOORDINADORCC.Items.FindByValue(IDEMPLEADO))
            Me.ddlCOORDINADORCC.Visible = True
            Me.txtCOORDINADORCC.Visible = False
            btnCerrar.Visible = False

        Else
            Me.ddlCOORDINADORCC.Visible = False
            Me.txtCOORDINADORCC.Visible = True
            btnCerrar.Visible = True

        End If

        If mEntidad.IDCOORDINADOR = IDEMPLEADO Then
            btnCerrar.Visible = True
        End If


        Me.btnCorregir.Visible = False
        Me.btnGuardar.Visible = True

        Select Case mEntidad.IDESTADO
            Case 1

            Case 2
                HabilitarEdicion(False)
        End Select
        Me.btnCorregir.Visible = False

        Me.txtUM4.Text = mEntidad.UNIDADMEDIDA
        Me.txtUM5.Text = mEntidad.UNIDADMEDIDA
        Me.txtUM6.Text = mEntidad.UNIDADMEDIDA


        'Me.ddlTIPOINFORMES1.SelectedValue = mentidad.IDTIPOINFORME

        Me.IDCONTRATO = mEntidad.IDCONTRATO
        Me.IDPROVEEDOR = mEntidad.IDPROVEEDOR
        Me.RENGLON = mEntidad.RENGLON

        Me.RadioButtonList1.SelectedValue = mEntidad.ORIGENPRODUCTO
        Me.DropDownList5.SelectedValue = mEntidad.TIPOPRODUCTO

        lblNombrecomercial2.Text = mEntidad.NOMBRECOMERCIAL
        Me.txtNOMBREMEDICAMENTO.Text = mEntidad.NOMBREMEDICAMENTO
        Me.lblLaboratorioFa.Text = mEntidad.LABORATORIOFABRICANTE
        Me.txtPROVEEDOR.Text = mEntidad.PROVEEDOR
        Me.lblLote2.Text = mEntidad.LOTE


        Me.lblFF.Text = mEntidad.FECHAFABRICACION.Month.ToString & "/" & mEntidad.FECHAFABRICACION.Year.ToString
        Me.lblFV.Text = mEntidad.FECHAVENCIMIENTO.Month & "/" & mEntidad.FECHAVENCIMIENTO.Year

        Me.lblNumeroUnidades2.Text = mEntidad.NUMEROUNIDADES
        Me.lblCantidadRemitida2.Text = mEntidad.CANTIDADREMITIDA
        Me.txtESTABLECIMIENTOREMITE.Text = mEntidad.ESTABLECIMIENTOREMITE

        Me.txtDESCRIPCIONEMPAQUE.Text = mEntidad.DESCRIPCIONEMPAQUE
        Me.cbLEYENDAREQUERIDA.Checked = IIf(mEntidad.LEYENDAREQUERIDA = 1, True, False)
        Me.cbNUMEROREGISTRO.Checked = IIf(mEntidad.NUMEROREGISTRO = 1, True, False)
        Me.cbVIAADMINISTRACION.Checked = IIf(mEntidad.VIAADMINISTRACION = 1, True, False)
        Me.cbFORMADISOLUCION.Checked = IIf(mEntidad.FORMADISOLUCION = 1, True, False)
        Me.cbCONDICIONESALMACENAMIENTO.Checked = IIf(mEntidad.CONDICIONESALMACENAMIENTO = 1, True, False)
        Me.cbNUMEROLOTE.Checked = IIf(mEntidad.NUMEROLOTE = 1, True, False)
        Me.cbFECHAEXPIRACION.Checked = IIf(mEntidad.FECHAEXPIRACION = 1, True, False)
        Me.cbOTROSEMPAQUES.Checked = IIf(mEntidad.OTROSEMPAQUES = 1, True, False)
        Me.txtDESCRIPCIONOTROSEMPAQUES.Text = mEntidad.DESCRIPCIONOTROSEMPAQUES
        Me.txtDescripcionDilucion.Text = mEntidad.DESCRIPCIONDISOLUCION

        Me.txtDESCRIPCIONPRODUCTO.Text = mEntidad.DESCRIPCIONPRODUCTO

        Me.nbCANTIDADFISICOQUIMICO.Text = mEntidad.CANTIDADFISICOQUIMICO
        Me.nbCANTIDADMICROBIOLOGIA.Text = mEntidad.CANTIDADMICROBIOLOGIA
        Me.nbCANTIDADRETENCION.Text = mEntidad.CANTIDADRETENCION

        Me.txtDESCRIPCIONCONDICIONESALMACENAMIENTO.Text = mEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO
        Me.txtOBSERVACION.Text = mEntidad.OBSERVACION

        Me.txtMotivoNoAceptacion.Text = mEntidad.MOTIVONOACEPTACION
        Me.txtMOTIVOSNOINSPECCION.Text = mEntidad.MOTIVOSNOINSPECCION

        Me.txtREPRESENTANTEPROVEEDOR.Text = mEntidad.REPRESENTANTEPROVEEDOR

        ' Me.IDINSPECTOR = mentidad.IDINSPECTOR
        Me.txtINSPECTOR.Text = mEntidad.INSPECTOR
        Me.txtCODIGOINSPECTOR.Text = mEntidad.CODIGOINSPECTOR
        'Me.ddlCOORDINADORCC.SelectedValue = mentidad.IDCOORDINADOR
        'Me.txtCOORDINADORCC.Text = mentidad.COORDINADOR
        'Me.txtCODIGOCOORDINADORCC.Text = mentidad.CODIGOCOORDINADOR

        'If Certificacion And mentidad.IDJEFELABORATORIO = Nothing Then
        '    Me.txtJEFELABORATORIO.Text = Session("NombreUsuario")
        '    Me.txtCODIGOJEFELABORATORIO.Text = Session.Item("CodigoEmpleado")
        'Else
        '    Me.txtJEFELABORATORIO.Text = mentidad.JEFELABORATORIO
        '    Me.txtCODIGOJEFELABORATORIO.Text = mentidad.CODIGOJEFELABORATORIO
        'End If

        'Me.cpFECHAELABORACIONINFORME.SelectedDate = mentidad.FECHAELABORACIONINFORME

        'Me.IDJEFELABORATORIO = mentidad.IDJEFELABORATORIO

        'Me.txtOBSERVACIONCERTIFICACION2.Text = mentidad.OBSERVACIONCERTIFICACION
        'Me.txtOBSERVACIONCERTIFICACION2.Text = Me.txtOBSERVACIONCERTIFICACION2.Text.Replace(Me.txtOBSERVACIONCERTIFICACION1.Text + " ", "")
        'Me.cpFECHACERTIFICACION.SelectedDate = mentidad.FECHACERTIFICACION

        ' Me.ddlResultadoInspeccion.SelectedValue = mentidad.RESULTADOINSPECCION

        'If Certificacion Then
        '    Me.ddlResultadoInspeccion.Visible = True
        'Else
        '    Me.lblResultadoInspeccion.Visible = False
        '    Me.ddlResultadoInspeccion.Visible = False
        'End If


        Me.txtCCF.Text = mEntidad.COMPROBANTECREDITOFISCAL
        Me.TextBox6.Text = mEntidad.DESCRIPCIONEMPAQUECOLECTIVO
        Me.TextBox5.Text = mEntidad.NUMEROEMPAQUECOLECTIVO
        Me.TextBox4.Text = mEntidad.DESCRIPCIONEMPAQUESECUNDARIO
        Me.TextBox3.Text = mEntidad.NUMEROEMPAQUESECUNDARIO
        Me.TextBox2.Text = mEntidad.NUMEROEMPAQUEPRIMARIO
        Me.TextBox7.Text = mEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS
        Me.TextBox8.Text = mEntidad.NUMEROUNIDADESAMUESTREAR
        Me.TextBox9.Text = mEntidad.NIVELCALIDADACEPTABLE
        Me.TextBox10.Text = mEntidad.RANGOACEPTACIONRECHAZO
        Me.TextBox11.Text = mEntidad.CALCULOS
        Me.RadioButtonList1.SelectedValue = mEntidad.NIVELINSPECCIONUTILIZABLE
        'If mEntidad.IDTIPOINFORME = eTIPOINFORME.RECHAZO Then
        '    Dim cMNAI As New cMOTIVOSNOACEPTACIONINFORME
        '    ds = cMNAI.ObtenerMOTIVOSNOACEPTACIONINFORME(mEntidad.IDESTABLECIMIENTO, mEntidad.IDINFORME)

        '    '   CrearTablaMotivosNoAceptacion(ds.Tables(0))
        'End If
    End Sub

    Private Sub Nuevo()
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If


        'OcultarPanelesDetalle()

        'ObtenerProveedores()

        Me.txtINSPECTOR.Text = Session("NombreUsuario")
        Me.txtCODIGOINSPECTOR.Text = Session.Item("CodigoEmpleado")

        Dim IDEMPLEADO As Integer = Session.Item("IdEmpleado")
        Me.ddlCOORDINADORCC.Items.Remove(Me.ddlCOORDINADORCC.Items.FindByValue(IDEMPLEADO))

        Me.IDESTADO = 1

        Me.btnImprimir.Visible = False

    End Sub

    Public Function Actualizar() As String

        If Me.IDTIPOINFORME = eTIPOINFORME.ACEPTACION Or Me.IDTIPOINFORME = eTIPOINFORME.RECHAZO Then
            If cbOTROSEMPAQUES.Checked Then
                If Trim(txtDESCRIPCIONOTROSEMPAQUES.Text) = "" Then
                    Return "Debe ingresar la descripción de los otros empaques."
                End If
            End If

            If (CDec(nbCANTIDADFISICOQUIMICO.Text) + CDec(nbCANTIDADMICROBIOLOGIA.Text) + CDec(nbCANTIDADRETENCION.Text)) > CDec(Me.lblCANTIDADREMITIDA.Text) Then
                Return "La suma de las cantidades distribuidas no puede superar el total remitido."
            End If
            If Not Me.cbFORMADISOLUCION.Checked Then
                If Trim(Me.txtDescripcionDilucion.Text) = "" Then
                    Return "Debe ingresar una observacion a la forma de disolución."
                End If
            End If
        End If

        'If Me.IDTIPOINFORME = eTIPOINFORME.RECHAZO Then
        '    Dim emptyRow As Data.DataRow = dtMotivosNoAceptacion.Rows.Find(0)
        '    If Not IsNothing(emptyRow) And dtMotivosNoAceptacion.Rows.Count = 1 Then
        '        Return "Debe ingresar al menos un motivo de rechazo."
        '    End If
        'End If

        mEntidad = New ABASTECIMIENTOS.ENTIDADES.INFORMEMUESTRAS
        ' Dim lista As New listaMOTIVOSNOACEPTACIONINFORME

        mEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        If Me._nuevo Then
            mEntidad.IDINFORME = 0
            mEntidad.IDINSPECTOR = Session("IdEmpleado")
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now
        Else
            mEntidad.IDINFORME = IDINFORME
            mEntidad.IDINSPECTOR = Session("IdEmpleado")
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now
        End If

        mEntidad.FECHARECOLECCIONMUESTRA = Me.cpFECHAELABORACIONINFORME.SelectedDate

        mEntidad.IDESTADO = Me.IDESTADO

        mEntidad.IDTIPOINFORME = Me.ddlTIPOINFORMES1.SelectedValue

        mEntidad.IDESTABLECIMIENTOCONTRATO = Me.IDESTABLECIMIENTOCONTRATO
        mEntidad.IDPROVEEDOR = Me.IDPROVEEDOR
        mEntidad.IDCONTRATO = Me.IDCONTRATO
        mEntidad.RENGLON = Me.RENGLON

        mEntidad.ORIGENPRODUCTO = Me.RadioButtonList1.SelectedValue
        mEntidad.TIPOPRODUCTO = Me.DropDownList5.SelectedValue

        mEntidad.NOMBREMEDICAMENTO = Me.txtNOMBREMEDICAMENTO.Text
        mEntidad.NOMBRECOMERCIAL = Me.lblNombrecomercial2.Text
        mEntidad.LABORATORIOFABRICANTE = Me.lblLaboratorioFa.Text
        mEntidad.PROVEEDOR = Me.txtPROVEEDOR.Text
        mEntidad.LOTE = Me.lblLote2.Text

        mEntidad.FECHAFABRICACION = Me.DropDownList1.SelectedValue & Me.DropDownList2.SelectedValue
        mEntidad.FECHAVENCIMIENTO = Me.DropDownList3.SelectedValue & Me.DropDownList4.SelectedValue

        mEntidad.NUMEROUNIDADES = Me.lblNumeroUnidades2.Text
        mEntidad.CANTIDADREMITIDA = Me.lblCantidadRemitida2.Text
        mEntidad.ESTABLECIMIENTOREMITE = Me.txtESTABLECIMIENTOREMITE.Text

        Select Case mEntidad.IDTIPOINFORME

            Case eTIPOINFORME.ACEPTACION

                mEntidad.DESCRIPCIONEMPAQUE = Me.txtDESCRIPCIONEMPAQUE.Text

                mEntidad.LEYENDAREQUERIDA = IIf(Me.cbLEYENDAREQUERIDA.Checked, 1, 0)
                mEntidad.NUMEROREGISTRO = IIf(Me.cbNUMEROREGISTRO.Checked, 1, 0)
                mEntidad.VIAADMINISTRACION = IIf(Me.cbVIAADMINISTRACION.Checked, 1, 0)
                mEntidad.FORMADISOLUCION = IIf(Me.cbFORMADISOLUCION.Checked, 1, 0)
                mEntidad.CONDICIONESALMACENAMIENTO = IIf(Me.cbCONDICIONESALMACENAMIENTO.Checked, 1, 0)
                mEntidad.NUMEROLOTE = IIf(Me.cbNUMEROLOTE.Checked, 1, 0)
                mEntidad.FECHAEXPIRACION = IIf(Me.cbFECHAEXPIRACION.Checked, 1, 0)
                mEntidad.OTROSEMPAQUES = IIf(Me.cbOTROSEMPAQUES.Checked, 1, 0)
                mEntidad.DESCRIPCIONOTROSEMPAQUES = Me.txtDESCRIPCIONOTROSEMPAQUES.Text
                mEntidad.DESCRIPCIONDISOLUCION = Me.txtDescripcionDilucion.Text
                mEntidad.DESCRIPCIONPRODUCTO = Me.txtDESCRIPCIONPRODUCTO.Text
                mEntidad.CANTIDADFISICOQUIMICO = Me.nbCANTIDADFISICOQUIMICO.Text
                mEntidad.CANTIDADMICROBIOLOGIA = Me.nbCANTIDADMICROBIOLOGIA.Text
                mEntidad.CANTIDADRETENCION = Me.nbCANTIDADRETENCION.Text

                mEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = Me.txtDESCRIPCIONCONDICIONESALMACENAMIENTO.Text

                mEntidad.COMPROBANTECREDITOFISCAL = Me.txtCCF.Text
                mEntidad.DESCRIPCIONEMPAQUECOLECTIVO = Me.TextBox6.Text
                mEntidad.NUMEROEMPAQUECOLECTIVO = Me.TextBox5.Text
                mEntidad.DESCRIPCIONEMPAQUESECUNDARIO = Me.TextBox4.Text
                mEntidad.NUMEROEMPAQUESECUNDARIO = Me.TextBox3.Text
                mEntidad.NUMEROEMPAQUEPRIMARIO = Me.TextBox2.Text
                mEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = Me.TextBox7.Text
                mEntidad.NIVELINSPECCIONUTILIZABLE = Me.CheckBoxList1.SelectedValue
                mEntidad.NUMEROUNIDADESAMUESTREAR = Me.TextBox8.Text
                mEntidad.NIVELCALIDADACEPTABLE = Me.TextBox9.Text
                mEntidad.RANGOACEPTACIONRECHAZO = Me.TextBox10.Text
                mEntidad.CALCULOS = Me.TextBox11.Text

            Case eTIPOINFORME.RECHAZO

                mEntidad.DESCRIPCIONEMPAQUE = Me.txtDESCRIPCIONEMPAQUE.Text

                mEntidad.LEYENDAREQUERIDA = IIf(Me.cbLEYENDAREQUERIDA.Checked, 1, 0)
                mEntidad.NUMEROREGISTRO = IIf(Me.cbNUMEROREGISTRO.Checked, 1, 0)
                mEntidad.VIAADMINISTRACION = IIf(Me.cbVIAADMINISTRACION.Checked, 1, 0)
                mEntidad.FORMADISOLUCION = IIf(Me.cbFORMADISOLUCION.Checked, 1, 0)
                mEntidad.CONDICIONESALMACENAMIENTO = IIf(Me.cbCONDICIONESALMACENAMIENTO.Checked, 1, 0)
                mEntidad.NUMEROLOTE = IIf(Me.cbNUMEROLOTE.Checked, 1, 0)
                mEntidad.FECHAEXPIRACION = IIf(Me.cbFECHAEXPIRACION.Checked, 1, 0)
                mEntidad.OTROSEMPAQUES = IIf(Me.cbOTROSEMPAQUES.Checked, 1, 0)
                mEntidad.DESCRIPCIONOTROSEMPAQUES = Me.txtDESCRIPCIONOTROSEMPAQUES.Text
                mEntidad.DESCRIPCIONDISOLUCION = Me.txtDescripcionDilucion.Text
                mEntidad.DESCRIPCIONPRODUCTO = Me.txtDESCRIPCIONPRODUCTO.Text
                mEntidad.CANTIDADFISICOQUIMICO = Me.nbCANTIDADFISICOQUIMICO.Text
                mEntidad.CANTIDADMICROBIOLOGIA = Me.nbCANTIDADMICROBIOLOGIA.Text
                mEntidad.CANTIDADRETENCION = Me.nbCANTIDADRETENCION.Text

                mEntidad.COMPROBANTECREDITOFISCAL = Me.txtCCF.Text
                mEntidad.DESCRIPCIONEMPAQUECOLECTIVO = Me.TextBox6.Text
                mEntidad.NUMEROEMPAQUECOLECTIVO = Me.TextBox5.Text
                mEntidad.DESCRIPCIONEMPAQUESECUNDARIO = Me.TextBox4.Text
                mEntidad.NUMEROEMPAQUESECUNDARIO = Me.TextBox3.Text
                mEntidad.NUMEROEMPAQUEPRIMARIO = Me.TextBox2.Text
                mEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = Me.TextBox7.Text
                mEntidad.NIVELINSPECCIONUTILIZABLE = Me.CheckBoxList1.SelectedValue
                mEntidad.NUMEROUNIDADESAMUESTREAR = Me.TextBox8.Text
                mEntidad.NIVELCALIDADACEPTABLE = Me.TextBox9.Text
                mEntidad.RANGOACEPTACIONRECHAZO = Me.TextBox10.Text
                mEntidad.CALCULOS = Me.TextBox11.Text

                mEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = Me.txtDESCRIPCIONCONDICIONESALMACENAMIENTO.Text

                mEntidad.MOTIVONOACEPTACION = Me.txtMotivoNoAceptacion.Text
                'For Each row As Data.DataRow In dtMotivosNoAceptacion.Rows
                '    Dim eMNAI As New MOTIVOSNOACEPTACIONINFORME
                '    eMNAI.IDMOTIVONOACEPTACION = row("IDMOTIVONOACEPTACION")
                '    If Not IsDBNull(eMNAI.IDMOTIVONOACEPTACION) Then
                '        eMNAI.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                '        eMNAI.AUFECHACREACION = Now
                '        lista.Add(eMNAI)
                '    End If
                'Next

                mEntidad.REPRESENTANTEPROVEEDOR = "" 'Me.txtREPRESENTANTEPROVEEDOR.Text
                mEntidad.COMPROBANTECREDITOFISCAL = Me.txtCCF.Text
                mEntidad.DESCRIPCIONEMPAQUECOLECTIVO = Me.TextBox6.Text
                mEntidad.NUMEROEMPAQUECOLECTIVO = Me.TextBox5.Text
                mEntidad.DESCRIPCIONEMPAQUESECUNDARIO = Me.TextBox4.Text
                mEntidad.NUMEROEMPAQUESECUNDARIO = Me.TextBox3.Text
                mEntidad.NUMEROEMPAQUEPRIMARIO = Me.TextBox2.Text
                mEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = Me.TextBox7.Text
                mEntidad.NIVELINSPECCIONUTILIZABLE = Me.CheckBoxList1.SelectedValue
                mEntidad.NUMEROUNIDADESAMUESTREAR = Me.TextBox8.Text
                mEntidad.NIVELCALIDADACEPTABLE = Me.TextBox9.Text
                mEntidad.RANGOACEPTACIONRECHAZO = Me.TextBox10.Text
                mEntidad.CALCULOS = Me.TextBox11.Text

            Case eTIPOINFORME.NOINSPECCION

                ' mEntidad.NUMEROINFORME = Nothing

                mEntidad.MOTIVOSNOINSPECCION = Me.txtMOTIVOSNOINSPECCION.Text
                mEntidad.REPRESENTANTEPROVEEDOR = "" 'Me.txtREPRESENTANTEPROVEEDOR.Text

        End Select

        mEntidad.OBSERVACION = Me.txtOBSERVACION.Text
        mEntidad.IDCOORDINADOR = Me.ddlCOORDINADORCC.SelectedValue
        mEntidad.FECHAELABORACIONINFORME = Me.cpFECHAELABORACIONINFORME.SelectedDate

        mEntidad.IDJEFELABORATORIO = Nothing

        mEntidad.RESULTADOINSPECCION = Nothing

        mEntidad.ESTASINCRONIZADA = 0
        Dim mcomponente As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        If mcomponente.ActualizarINFORMEMUESTRAS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        Me.ddlTIPOINFORMES1.Recuperar()
        Me.ddlCOORDINADORCC.RecuperarEmpleadosPorDependenciaCoordinador(Session("IdEstablecimiento"), Session("IdDependencia"))
    End Sub

    Protected Sub GridView4_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView4.SelectedIndexChanging
        IDINFORME = Me.GridView4.DataKeys(e.NewSelectedIndex).Values.Item("IDINFORME")
        Me.lblTIPOINFORME.Visible = True
        Me.ddlTIPOINFORMES1.Visible = True
        Me.btnAceptar.Visible = True
        CargarDDLs()
        cvFECHAELABORACIONINFORME2.ValueToCompare = Now.Date
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Page.IsValid Then
            Dim sError As String
            sError = Actualizar() 'Grabado

            RaiseEvent Guardar(sError)
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        MsgBox1.ShowConfirm("Una vez enviado el informe, ya no podrá ser modificado.  ¿Confirma que desea enviarlo?", "Cerrar", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        Dim sError As String

        Select Case e.Key
            Case "Cerrar"
                If Certificacion Then
                    Me.IDESTADO = 3
                Else
                    Me.IDESTADO = 2
                End If

            Case "Corregir"
                Me.IDESTADO = 1
        End Select

        sError = Actualizar()

        RaiseEvent Guardar(sError)

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        RaiseEvent Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.IDTIPOINFORME = Me.ddlTIPOINFORMES1.SelectedValue
        TipoInforme(ddlTIPOINFORMES1.SelectedValue)
        Me.btnCerrar.Visible = False
        Me.btnCorregir.Visible = False

        Me.Panel1.Visible = True

        Me.txtNOMBREMEDICAMENTO.Text = Me.lblProducto.Text
        Me.lblNombrecomercial2.Text = Server.HtmlDecode(Me.GridView4.SelectedRow.Cells(2).Text)
        Me.lblLaboratorioFa.Text = Server.HtmlDecode(Me.GridView4.SelectedRow.Cells(3).Text)
        Me.txtPROVEEDOR.Text = Me.lblProveedor.Text
        Me.lblLote2.Text = Server.HtmlDecode(Me.GridView4.SelectedRow.Cells(0).Text)
        'Me.lblFF.Text
        CargarDatos()
    End Sub

End Class
