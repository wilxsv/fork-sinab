Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.IO

Partial Class frmGenerarModificativaContratosPlantilla
    Inherits System.Web.UI.Page

    Friend Shared IDDETALLEENTREGA, IDALMACENENTREGA As Integer
    Friend Shared IDACCION As Integer = 0
    Friend Shared IDTIPOSUMINISTRO As Integer
    Friend Shared IDPROVEEDOR As Integer
    Friend Shared IDPLANTILLA As Integer
    Friend Shared idClausula As Integer
    Friend Shared IDCONTRATO As Integer
    Friend Shared MODO As String = "NEW"
    Friend Shared flagSaveClausula As Integer = 0
    Friend Shared codigoLicita As String
    Friend Shared IDPROCESOCOMPRA As Integer
    Private _IDESTADOCONTRATO As Integer = 1
    Friend Shared tipo As Integer  'Este campo se utiliza para diferenciar el tipo de plantilla a mostrar

#Region " Propiedades "

    Public Property IDESTADOCONTRATO() As Integer
        Get
            Return _IDESTADOCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDESTADOCONTRATO = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me.UcVistaDetalleSolicProcesCompra1
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPROCESOCOMPRA = Request.QueryString("IdProc")
            IDTIPOSUMINISTRO = .ConsultarTipoSuministro()
            .BtnAnularProcesoEnabled = False
            .BtnQuitarSolicitudEnabled = False
        End With
        If Not IsPostBack Then
            Me.ViewState.Add("ESTADO", "NEW")
        End If

        obtenerParametros()
        tipo = 1
        'cargarProveedores()
        Me.UcVistaDetalleSolicProcesCompra1.PermiteSeleccionar = False
        Me.UcVistaDetalleSolicProcesCompra1.ocultaSeleccion()
        Me.obtenerPlantillasContrato(Request.QueryString("idTC"), IDTIPOSUMINISTRO)
    End Sub

    Private Sub obtenerParametros()
        Dim mComponente As New cPROCESOCOMPRAS
        Dim ds As Data.DataSet
        ds = mComponente.obtenerParametrosGeneraContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

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
        'If MODO = "EDIT" Then
        '    Dim mComponente As New cCONTRATOS
        '    ds = mComponente.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPROVEEDOR)
        'Else
        Dim mComponente As New cPLANTILLASCONTRATO
        ds = mComponente.ObtenerPLANTILLASCONTRATO(Session("IDESTABLECIMIENTO"), IDTIPOCOMPRA, IDSUMINISTRO, tipo)
        'End If

        Me.dgPlantillaContrato.DataSource = ds
        Me.dgPlantillaContrato.DataBind()
        If ds.Tables(0).Rows.Count > 0 Then
            If Not IsPostBack Then
                If MODO = "NEW" Then
                    Me.txtPersoneriaJuridica.Text = ds.Tables(0).Rows(0).Item("PERSONERIAJURIDICA")
                Else
                    obtenerPersoneriajuridica()
                End If
            End If
        End If

    End Sub

    Private Sub obtenerPersoneriajuridica()
        Dim mComponente As New cCONTRATOS
        'If Not IsPostBack Then
        Me.txtPersoneriaJuridica.Text = mComponente.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text).Tables(0).Rows(0).Item("PERSONERIAJURIDICA")
        'End If
    End Sub


    Protected Sub dgPlantillaContrato_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPlantillaContrato.SelectedIndexChanged
        Me.LinkButton3.Enabled = True
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        obtenerContratos()
        Me.Panel3.Visible = True
        Me.Panel1.Visible = False
    End Sub

    Private Sub obtenerContratos()
        Dim mComContratos As New cCONTRATOS
        Me.dgContratos.DataSource = mComContratos.obtenerContratoModificativa(Session("IdEstablecimiento"), Request.QueryString("IdProc"))
        Me.dgContratos.DataBind()
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        Dim mComProdContrato As New cPRODUCTOSCONTRATO
        Me.DataGrid1.DataSource = mComProdContrato.obtenerProductosAdjudicadosContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(2).Text, Me.dgContratos.SelectedItem.Cells(3).Text)
        Me.DataGrid1.DataBind()
        Panel3.Visible = False
        Panel6.Visible = True
        Me.ViewState("ESTADO") = "EDIT"
        Me.txtNoModificativa.Text = Me.dgModificativa.SelectedItem.Cells(2).Text
        Me.txtNoModificativa.ReadOnly = True

        lblIdModificativa.Text = obtenerModificativaContrato()

    End Sub

    Protected Sub dgContratos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContratos.SelectedIndexChanged
        Dim mComModifContrato As New cMODIFICATIVASCONTRATO
        Dim ds As Data.DataSet
        ds = mComModifContrato.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.Label29.Visible = True
            Me.dgModificativa.Visible = True
            Me.dgModificativa.DataSource = ds
            Me.dgModificativa.DataBind()
        End If

        'LinkButton5.Enabled = True
    End Sub

    Protected Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        If e.CommandName = "EditarPlazos" Then
            Me.Panel9.Visible = True
            Me.Panel7.Visible = False
            Dim cComEntregaContrato As New cENTREGACONTRATO
            Dim renglon As Integer
            renglon = e.Item.Cells(1).Text
            Me.lblRenglon.Text = renglon
            Me.dgPlazoEntrega.DataSource = cComEntregaContrato.obtenerPlazoEntregaContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, renglon)
            Me.dgPlazoEntrega.DataBind()
        End If
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Me.Panel7.Visible = True
        Me.txtProducto.Text = Me.DataGrid1.SelectedItem.Cells(3).Text
        Me.txtCantidad.Text = Me.DataGrid1.SelectedItem.Cells(4).Text
        Me.txtPrecioUnitario.Text = Me.DataGrid1.SelectedItem.Cells(5).Text

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DataGrid1.SelectedItem.Cells(3).Text = Me.txtProducto.Text
        Me.DataGrid1.SelectedItem.Cells(4).Text = Me.txtCantidad.Text
        Me.DataGrid1.SelectedItem.Cells(5).Text = Me.txtPrecioUnitario.Text
        guardarModificativaProductos()
        actualizaModificativaContrato()
        Me.Panel7.Visible = False
    End Sub

    Private Sub actualizaModificativaContrato()
        Dim mComMC As New cMODIFICATIVASCONTRATO
        Dim lEntidad As New MODIFICATIVASCONTRATO

        With lEntidad
            .AUFECHACREACION = Date.Now
            .AUFECHAMODIFICACION = Date.Now
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .FECHAMODIFICATIVA = Date.Now
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDMODIFICATIVA = lblIdModificativa.Text
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .NUMEROMODIFICATIVA = Me.txtNoModificativa.Text
        End With

        mComMC.ActualizarMODIFICATIVASCONTRATO(lEntidad)

    End Sub

    Private Sub guardarModificativaProductos()
        Dim mComModContratoProd As New cMODIFICATIVASCONTRATOPRODUCTO
        Dim lEntidad As New MODIFICATIVASCONTRATOPRODUCTO

        With lEntidad
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHAMODIFICACION = Date.Today
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .CANTIDADCONTRATADA = Me.txtCantidad.Text
            .DESCRIPCION = Me.txtProducto.Text
            .ESTASINCRONIZADA = 0
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDMODIFICATIVA = Me.lblIdModificativa.Text
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .PRECIOUNITARIO = Me.txtPrecioUnitario.Text
            .RENGLON = Me.DataGrid1.SelectedItem.Cells(1).Text
        End With

        If CInt(Me.lblIdModificativa.Text) = CInt(Me.DataGrid1.SelectedItem.Cells(7).Text) Then
            mComModContratoProd.ActualizarMODIFICATIVASCONTRATOPRODUCTO(lEntidad)
        Else
            mComModContratoProd.AgregarMODIFICATIVASCONTRATOPRODUCTO(lEntidad)
        End If





    End Sub

    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click

        If Me.ViewState("ESTADO") = "EDIT" Then
            obtenerPersoneriajuridica()
        End If



        obtenerClausulasPlantilla()
        obtenerClausulasPlantilla()

        Me.Panel2.Visible = True
        Me.Panel6.Visible = False

        If Me.IDESTADOCONTRATO = 2 Then
            Me.ImageButton2.Visible = False
            Me.txtPersoneriaJuridica.ReadOnly = True
            Me.dgClausulas.Columns.Item(0).HeaderText = "Ver"
            Me.dgClausulas.Columns(4).Visible = False
            Me.txtOrden.ReadOnly = True
            'Me.rteContenido.ReadOnly = True
            Me.ImageButton1.Visible = False
        Else
            Me.ImageButton2.Visible = True
            Me.txtPersoneriaJuridica.ReadOnly = False
            Me.dgClausulas.Columns.Item(0).HeaderText = "Editar"
            Me.dgClausulas.Columns(4).Visible = True
            Me.txtOrden.ReadOnly = False
            'Me.rteContenido.ReadOnly = False
            Me.ImageButton1.Visible = True
        End If
    End Sub

    Private Function obtenerModificativaContrato() As Integer
        Dim mComModificativaContrato As New cMODIFICATIVASCONTRATO
        Dim lEntidad As New MODIFICATIVASCONTRATO

        Return mComModificativaContrato.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text).Tables(0).Rows(0).Item("IDMODIFICATIVA")

    End Function


    Private Sub obtenerClausulasPlantilla()
        Dim mComponente As New cCLAUSULASPLANTILLA
        Me.dgClausulas.DataSource = mComponente.obtenerClausulasPlantillaDs(Session("IdEstablecimiento"), Me.dgPlantillaContrato.SelectedItem.Cells(1).Text, Me.dgContratos.SelectedItem.Cells(2).Text, Me.dgContratos.SelectedItem.Cells(3).Text, tipo, Me.txtNoModificativa.Text)
        Me.dgClausulas.DataBind()

        Dim i As Integer

        For i = 0 To dgClausulas.Items.Count - 1
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
        ds = mComClauPlantilla.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.dgPlantillaContrato.SelectedItem.Cells(1).Text, IDCLAUSULA)

        Dim mComponente As New cCLAUSULASCONTRATOS
        Dim lEntidad As New CLAUSULASCONTRATOS

        With lEntidad
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = ds.Tables(0).Rows(0).Item("ESTASINCRONIZADA")
            .ORDEN = ds.Tables(0).Rows(0).Item("ORDEN")
            .ENCABEZADOCLAUSULA = ds.Tables(0).Rows(0).Item("CONTENIDO")
            .IDCLAUSULA = IDCLAUSULA
            .IDMODIFICATIVA = Me.lblIdModificativa.Text
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
        End With

        mComponente.ActualizarCLAUSULASCONTRATOS(lEntidad)

    End Sub

    Protected Sub dgPlazoEntrega_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPlazoEntrega.SelectedIndexChanged
        Me.Panel10.Visible = True
        Me.txtCantEntregas.Text = Me.dgPlazoEntrega.SelectedItem.Cells(1).Text
        Me.txtPlazo.Text = Me.dgPlazoEntrega.SelectedItem.Cells(2).Text
        Me.txtEntrega.Text = Me.dgPlazoEntrega.SelectedItem.Cells(3).Text
        IDDETALLEENTREGA = Me.dgPlazoEntrega.SelectedItem.Cells(4).Text
        Try
            IDALMACENENTREGA = Me.dgPlazoEntrega.SelectedItem.Cells(5).Text
        Catch ex As Exception
            IDALMACENENTREGA = 0
        End Try
        If Me.dgPlazoEntrega.SelectedItem.Cells(6).Text = "&nbsp;" Then
            Me.btnGuardaPlazo.Enabled = True
            Me.btnEliminar.Enabled = True
            'btnDistribuirEntregas.Enabled = True
            Me.lblEntrega.Text = ""
        Else
            If Me.dgPlazoEntrega.SelectedItem.Cells(6).Text > 0 Then
                Me.btnGuardaPlazo.Enabled = True
                Me.btnEliminar.Enabled = True
                'btnDistribuirEntregas.Enabled = True
                Me.lblEntrega.Text = ""
            Else
                Me.btnGuardaPlazo.Enabled = True
                Me.btnEliminar.Enabled = True
                'btnDistribuirEntregas.Enabled = True
                Me.lblEntrega.Text = ""
            End If
        End If

        IDACCION = 0
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.MsgBox2.ShowConfirm("¿Desea eliminar esta entrega para el renglon seleccionado?", "EliminaEntrega", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        Me.txtCantEntregas.Text = CInt(Me.dgPlazoEntrega.Items(dgPlazoEntrega.Items.Count - 1).Cells(1).Text) + 1
        'Me.txtCantEntregas.Text = ""
        Me.txtEntrega.Text = ""
        Me.txtPlazo.Text = ""
        Me.Panel10.Visible = True
        'Me.btnNuevo.Enabled = False
        IDACCION = 1
    End Sub

    Protected Sub btnGuardaPlazo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardaPlazo.Click

        Dim lEntregaContrato As New ENTREGACONTRATO

        If IDACCION = 0 Then
            Me.dgPlazoEntrega.SelectedItem.Cells(1).Text = Me.txtCantEntregas.Text
            Me.dgPlazoEntrega.SelectedItem.Cells(2).Text = Me.txtPlazo.Text
            Me.dgPlazoEntrega.SelectedItem.Cells(3).Text = Me.txtEntrega.Text
            lEntregaContrato.IDDETALLE = IDDETALLEENTREGA
        End If

        Dim mComEntregaContrato As New cENTREGACONTRATO


        With lEntregaContrato
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ENTREGA = Me.txtCantEntregas.Text
            .ESTAHABILITADA = 1
            .ESTASINCRONIZADA = 0
            .FECHACONTEO = 1
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            '.IDDETALLE = IDDETALLEENTREGA
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDMODIFICATIVA = 1
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .PLAZOENTREGA = Me.txtPlazo.Text
            .PORCENTAJEENTREGA = Me.txtEntrega.Text
            .RENGLON = lblRenglon.Text

        End With

        mComEntregaContrato.ActualizarENTREGACONTRATO(lEntregaContrato)

        With lEntregaContrato
            '.AUFECHAMODIFICACION = Date.Today
            '.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            ''.ENTREGA = Me.txtCantEntregas.Text
            '.ESTAHABILITADA = 0
            '.ESTASINCRONIZADA = 0
            ''.FECHACONTEO = 1
            '.IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .IDDETALLE = IDDETALLEENTREGA
            '.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            ''.IDMODIFICATIVA = 1
            '.IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            ''.PLAZOENTREGA = Me.txtPlazo.Text
            ''.PORCENTAJEENTREGA = Me.txtEntrega.Text
            '.RENGLON = lblRenglon.Text
        End With

        mComEntregaContrato.ActualizarHabilitados(lEntregaContrato)

        Dim cComEntregaContrato As New cENTREGACONTRATO
        Me.dgPlazoEntrega.DataSource = cComEntregaContrato.obtenerPlazoEntregaContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, lblRenglon.Text)
        Me.dgPlazoEntrega.DataBind()
        Me.Panel10.Visible = False
        actualizaModificativaContrato()
        'End If
    End Sub

    Protected Sub MsgBox2_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MsgBox2.Disposed

    End Sub

    Protected Sub MsgBox2_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.YesChosen
        Dim cComEntregaContrato As New cENTREGACONTRATO
        Select Case e.Key
            Case Is = "EliminaEntrega"
                Dim cComAlmEntContrato As New cALMACENESENTREGACONTRATOS

                Dim lEntregaContrato As New ENTREGACONTRATO

                With lEntregaContrato
                    .AUFECHAMODIFICACION = Date.Today
                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    '.ENTREGA = Me.txtCantEntregas.Text
                    .ESTAHABILITADA = 0
                    .ESTASINCRONIZADA = 0
                    '.FECHACONTEO = 1
                    .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
                    .IDDETALLE = IDDETALLEENTREGA
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    '.IDMODIFICATIVA = 1
                    .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
                    '.PLAZOENTREGA = Me.txtPlazo.Text
                    '.PORCENTAJEENTREGA = Me.txtEntrega.Text
                    .RENGLON = lblRenglon.Text
                End With

                cComEntregaContrato.ActualizarHabilitados(lEntregaContrato)
                'cComAlmEntContrato.EliminarALMACENESENTREGACONTRATOS(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, lblRenglon.Text, IDDETALLEENTREGA, IDALMACENENTREGA)


                'cComEntregaContrato.EliminarENTREGACONTRATO(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, lblRenglon.Text, IDDETALLEENTREGA)

                Me.dgPlazoEntrega.DataSource = cComEntregaContrato.obtenerPlazoEntregaContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, lblRenglon.Text)
                Me.dgPlazoEntrega.DataBind()
                Me.Panel10.Visible = False
            Case Is = "DISTRIBUIR"
                'Redistribución de productos
                Dim mComUtileria As New cUTILERIAS

                mComUtileria.calcularDistribucionEntregasProveedor(Session("IdEstablecimiento"), Request.QueryString("IdProc"), HttpContext.Current.User.Identity.Name, Me.dgContratos.SelectedItem.Cells(3).Text, lblRenglon.Text, Me.dgContratos.SelectedItem.Cells(2).Text)

                Me.dgPlazoEntrega.DataSource = cComEntregaContrato.obtenerPlazoEntregaContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, lblRenglon.Text)
                Me.dgPlazoEntrega.DataBind()
                Me.MsgBox2.ShowAlert("La reasignación se realizó satisfactoriamente", "REASIGNAR", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End Select
    End Sub

    Protected Sub btnDistribuirEntregas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDistribuirEntregas.Click
        Dim i As Integer
        Dim suma As Decimal = 0
        For i = 0 To dgPlazoEntrega.Items.Count - 1
            suma += Me.dgPlazoEntrega.Items(i).Cells(3).Text
        Next
        If suma < 100 Then
            Me.MsgBox2.ShowAlert("La suma de los porcentajes debe ser igual a 100%", "PORCENTAJE", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        ElseIf suma > 100 Then
            Me.MsgBox2.ShowAlert("La suma de los porcentajes debe ser igual a 100%", "PORCENTAJE", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        Else
            Me.MsgBox2.ShowConfirm("¿Desea distribuir las entregas deacuerdo a las modificaciones realizadas para el renglon seleccionado?", "DISTRIBUIR", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If


    End Sub

    Protected Sub btnGenerarContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarContrato.Click
        Dim textoContrato As New Text.StringBuilder
        textoContrato = ElaborarContrato()
        reemplazarEtiquetas(textoContrato)

        'Me.fuContrato.Visible = True
        'Me.btnCargarArchivo.Visible = True

    End Sub

    Private Function ElaborarContrato() As StringBuilder
        Dim mComponente As New cCONTRATOS
        Dim lEntidad As New CONTRATOS
        Dim ds As Data.DataSet
        Dim textoContrato As New Text.StringBuilder
        Dim i As Integer
        Dim ordenClausula As String
        ds = mComponente.ElaboraModificativaContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, Request.QueryString("IdProc"))
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0)
                'PERSONERIAJURIDICA
                textoContrato.Append(ds.Tables(0).Rows(0).Item("PERSONERIAJURIDICA"))
                'CLAUSULAS
                For i = 0 To .Rows.Count - 1
                    ordenClausula = obtenerClausula(i + 1)
                    textoContrato.Append("<b> CLAUSULA " & ordenClausula & ": " & .Rows(i).Item("NOMBRE") & ".- <b>" & .Rows(i).Item("CONTENIDO") & " ")
                Next
            End With
        End If
        Return textoContrato
    End Function

    Private Function obtenerClausula(ByVal pos As Integer) As String

        Dim numeroCLAUSULA As String = String.Empty

        If pos > 10 And pos < 20 Then
            numeroCLAUSULA = "DECIMO "
            pos = pos - 10
        End If

        If pos > 20 And pos < 30 Then
            numeroCLAUSULA = "VIGECIMO "
            pos = pos - 20
        End If

        If pos > 30 And pos < 40 Then
            numeroCLAUSULA = "TRIGECIMO "
            pos = pos - 30
        End If

        If pos > 40 And pos < 50 Then
            numeroCLAUSULA = "CUADRAGECIMO "
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
                numeroCLAUSULA += "SEPTIMA"
            Case Is = 8
                numeroCLAUSULA += "OCTAVA"
            Case Is = 9
                numeroCLAUSULA += "NOVENA"
            Case Is = 10
                numeroCLAUSULA += "DECIMA"
            Case Is = 20
                numeroCLAUSULA = "VIGESIMA"
            Case Is = 30
                numeroCLAUSULA = "TRIGESIMA"
            Case Is = 40
                numeroCLAUSULA = "CUADRAGESIMA"
            Case Is = 50
                numeroCLAUSULA = "QUINCUAGESIMA"

        End Select

        Return numeroCLAUSULA

    End Function

    Private Sub reemplazarEtiquetas(ByVal textoContrato As StringBuilder)
        Dim textoReemplazado As String
        'OBTENIENDO AL CONTRATISTA

        Dim mComProveedor As New cPROVEEDORES
        Dim lEntProveedor As New PROVEEDORES

        lEntProveedor = mComProveedor.ObtenerPROVEEDORES(Me.dgContratos.SelectedItem.Cells(3).Text)

        textoReemplazado = Replace(textoContrato.ToString, "$CONTRATISTA$", lEntProveedor.REPRESENTANTELEGAL)

        'OBTENIENDO EL NOMBRE DEL PROVEEDOR

        textoReemplazado = Replace(textoReemplazado.ToString, "$PROVEEDOR$", lEntProveedor.NOMBRE)

        mComProveedor = Nothing
        lEntProveedor = Nothing

        'OBTENIENDO LA FECHA DE DISTRIBUCION

        Dim mComContratos As New cCONTRATOS
        Dim lEntContratos As New CONTRATOS

        Dim dsContratos As Data.DataSet
        dsContratos = mComContratos.ObtenerDataSetPorId(Session("IdEstablecimiento"), dgContratos.SelectedItem.Cells(3).Text, dgContratos.SelectedItem.Cells(2).Text)


        With dsContratos.Tables(0).Rows(0)

            textoReemplazado = Replace(textoReemplazado.ToString, "$FECHA_DISTRIBUCION$", .Item("FECHADISTRIBUCION"))
            textoReemplazado = Replace(textoReemplazado.ToString, "$CODIGO_CONTRATO$", .Item("NUMEROCONTRATO"))
            textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_CONTRATO_ORIGINAL$", .Item("MONTOCONTRATO"))
            'Falta la $MONTO_CONTRATO_INCREMENTO$ hay que calcularlo

        End With

        'OBTENIENDO NUMERO MODIFICATIVA

        Dim mComModContrato As New cMODIFICATIVASCONTRATO
        Dim dsModContrato As Data.DataSet
        dsModContrato = mComModContrato.ObtenerDataSetPorId(Session("IdEstablecimiento"), dgContratos.SelectedItem.Cells(3).Text, dgContratos.SelectedItem.Cells(2).Text)


        textoReemplazado = Replace(textoReemplazado.ToString, "$NUMERO_MODIFICATIVA$", dsModContrato.Tables(0).Rows(0).Item("NUMEROMODIFICATIVA"))

        'OBTENIENDO CODIGO DE LICITACION / IDTITULAR  /  TITULO LICITACION

        Dim mComProcesoCompraMod As New cPROCESOCOMPRAS

        Dim dsProcesoCompra As Data.DataSet
        dsProcesoCompra = mComProcesoCompraMod.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        With dsProcesoCompra.Tables(0).Rows(0)

            codigoLicita = dsProcesoCompra.Tables(0).Rows(0).Item("CODIGOLICITACION")
            textoReemplazado = Replace(textoReemplazado.ToString, "$CODIGO_LICITACION$", dsProcesoCompra.Tables(0).Rows(0).Item("CODIGOLICITACION"))

            textoReemplazado = Replace(textoReemplazado.ToString, "$TITULOLICITACION$", dsProcesoCompra.Tables(0).Rows(0).Item("TITULOLICITACION"))

        End With


        'OBTENIENDO EL TITULAR 
        Dim dsTitular As Data.DataSet
        dsTitular = mComProcesoCompraMod.obtenerTitular(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        textoReemplazado = Replace(textoReemplazado.ToString, "$CONTRATANTE$", dsTitular.Tables(0).Rows(0).Item("TITULAR"))

        'OBTENIENDO LISTADO DE PRODUCTOS CON MODIFICATIVA
        Dim mComModProdCon As New cMODIFICATIVASCONTRATOPRODUCTO
        Dim tablaProductos As New Text.StringBuilder
        Dim i As Integer

        Dim dsRenglonesModificativa As Data.DataSet
        dsRenglonesModificativa = mComModProdCon.obtenerProductoModificativa(Session("IdEstablecimiento"), dgContratos.SelectedItem.Cells(3).Text, dgContratos.SelectedItem.Cells(2).Text, Me.lblIdModificativa.Text)

        tablaProductos.Append("<br><TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        tablaProductos.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        tablaProductos.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Renglón</b></P></TD>")
        tablaProductos.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Código</b></P></TD>")
        tablaProductos.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Nombre del producto</b></P></TD></tr>")

        For i = 0 To dsRenglonesModificativa.Tables(0).Rows.Count - 1

            tablaProductos.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaProductos.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsRenglonesModificativa.Tables(0).Rows(i).Item("RENGLON") & "</P></TD>")
            tablaProductos.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsRenglonesModificativa.Tables(0).Rows(i).Item("CODIGO") & "</P></TD>")
            tablaProductos.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsRenglonesModificativa.Tables(0).Rows(i).Item("DESCRIPCION") & "</P></TD></tr>")

        Next

        tablaProductos.Append("</table><br>")

        'SUSTITUYENDO LA ETIQUETA DE LISTADO DE PRODUCTOS
        textoReemplazado = Replace(textoReemplazado.ToString, "$LISTADO_PRODUCTOS_MODIFICATIVA$", tablaProductos.ToString)

        'OBTENIENDO LOS RENGLONES ADJUDICADOS
        dsRenglonesModificativa = mComModProdCon.obtenerProductoModificativa(Session("IdEstablecimiento"), dgContratos.SelectedItem.Cells(3).Text, dgContratos.SelectedItem.Cells(2).Text, Me.lblIdModificativa.Text)

        i = 0
        Dim j, RENGLON As Integer
        Dim PRODUCTO As String

        Dim tablaEntrega As New Text.StringBuilder

        For i = 0 To dsRenglonesModificativa.Tables(0).Rows.Count - 1

            RENGLON = dsRenglonesModificativa.Tables(0).Rows(i).Item("RENGLON")
            PRODUCTO = dsRenglonesModificativa.Tables(0).Rows(i).Item("DESCRIPCION")

            'OBTENIENDO LOS PLAZOS DE ENTREGA

            Dim mComEntregaContrato As New cMODIFICATIVASCONTRATOPRODUCTO

            Dim lEntidadEntrega As New PROCESOCOMPRAS
            Dim dsEntregas As Data.DataSet
            dsEntregas = mComEntregaContrato.obtenerDetalleEntregaModificativa(Session("IdEstablecimiento"), dgContratos.SelectedItem.Cells(3).Text, dgContratos.SelectedItem.Cells(2).Text, RENGLON)

            'dsEntregas = mComponenteEntregas.obtenerNumntregasProveedor(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)

            tablaEntrega.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
            tablaEntrega.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Renglón</P></TD>")
            tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Nombre del producto</P></TD></tr>")

            tablaEntrega.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>" & RENGLON & "</b></P></TD>")
            tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>" & PRODUCTO & "</b></P></TD></tr>")

            tablaEntrega.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'>")
            tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Entrega</b></P></TD>")
            tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Porcentaje</b></P></TD>")
            tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Días</b></P></TD>")
            tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Cantidad</b></P></TD></TR>")

            If dsEntregas.Tables(0).Rows.Count > 0 Then
                For j = 0 To dsEntregas.Tables(0).Rows.Count - 1
                    tablaEntrega.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'>")
                    tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsEntregas.Tables(0).Rows(j).Item("ENTREGA") & "</P></TD>")
                    tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsEntregas.Tables(0).Rows(j).Item("PORCENTAJEENTREGA") & "</P></TD>")
                    tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsEntregas.Tables(0).Rows(j).Item("PLAZOENTREGA") & "</P></TD>")
                    tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsEntregas.Tables(0).Rows(j).Item("CANTIDAD") & "</P></TD></TR>")
                Next
            End If

            tablaEntrega.Append("</table><br>")

        Next

        'SISTITUYENDO LA ETIQUETA PLAZOS DE ENTREGA
        textoReemplazado = Replace(textoContrato.ToString, "$PLAZOS_ENTREGAS_MODIFICATIVA$", tablaEntrega.ToString)

        ''OBTENIENDO LA DISTRIBUCION DE PRODUCTOS

        ''PASO 1: OBTENER LA LISTA DE PRODUCTOS ADJUDICADOS

        'Dim mComponenteEntregas1 As New cENTREGAADJUDICACION
        'Dim dsProductos As New Data.DataSet

        'dsProductos = mComponenteEntregas1.obtenerRenglosAdjudicados(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)

        'Dim cComEntregaAlmacen As New cALMACENESENTREGAADJUDICACION
        'Dim dsAlmacen As New Data.DataSet
        'Dim ALMACEN As String
        'Dim IDALMACEN As Integer
        'Dim k As Integer
        'Dim tablaDistribucion As New Text.StringBuilder
        'Dim IDDETALLE As Integer

        'Dim dsDistribucion As New Data.DataSet

        'For i = 0 To dsProductos.Tables(0).Rows.Count - 1
        '    IDDETALLE = dsProductos.Tables(0).Rows(i).Item("IDDETALLE")
        '    RENGLON = dsProductos.Tables(0).Rows(i).Item("RENGLON")
        '    tablaDistribucion.Append("<br><TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        '    tablaDistribucion.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '    tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Renglón</P></TD>")
        '    tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Nombre del producto</P></TD>")
        '    tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Cantidad</P></TD></TR>")
        '    tablaDistribucion.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '    tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("RENGLON") & "</P></TD>")
        '    tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("NOMBRE") & "</P></TD>")
        '    tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("CANTIDADFIRME") & "</P></TD></tr>")
        '    dsAlmacen = cComEntregaAlmacen.obtenerAlmacenesAdjudicacion(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDDETALLE)
        '    For j = 0 To dsAlmacen.Tables(0).Rows.Count - 1
        '        IDALMACEN = dsAlmacen.Tables(0).Rows(j).Item("IDALMACEN")
        '        ALMACEN = dsAlmacen.Tables(0).Rows(j).Item("ALMACEN")
        '        tablaDistribucion.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '        tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=3><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><center><b>Almacen: " & ALMACEN & "</b></center></P></TD></tr>")
        '        tablaDistribucion.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '        tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Cantidad</b></P></TD>")
        '        tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Dias</b></P></TD></tr>")
        '        'tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'><b>Porcentaje</b></P></TD></tr>")
        '        dsDistribucion = cComEntregaAlmacen.obtenerDistribucionProducto(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDALMACEN, RENGLON)
        '        For k = 0 To dsDistribucion.Tables(0).Rows.Count - 1
        '            tablaDistribucion.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '            tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDistribucion.Tables(0).Rows(k).Item("CANTIDAD") & "</P></TD>")
        '            tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDistribucion.Tables(0).Rows(k).Item("DIAS") & "</P></TD></tr>")
        '            'tablaDistribucion.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=1><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDistribucion.Tables(0).Rows(k).Item("PORCENTAJE") & "</P></TD></tr>")
        '        Next
        '    Next
        '    tablaDistribucion.Append("</table><br>")
        'Next

        'textoReemplazado = Replace(textoReemplazado.ToString, "$PROGRAMA_DISTRIBUCION$", tablaDistribucion.ToString)





        ''OBTENIENDO EL MONTO DEL CONTRATO

        'Dim mComContrato2 As New cCONTRATOS
        'Dim lEntidadContrato2 As New CONTRATOS
        'Dim dsContrato As New Data.DataSet
        'Dim montoContrato As Decimal

        'dsContrato = mComContrato2.obtenerMontoContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, IDCONTRATO)
        'montoContrato = dsContrato.Tables(0).Rows(0).Item("MONTOCONTRATO")
        'textoReemplazado = Replace(textoReemplazado.ToString, "$MONTO_CONTRATO$", montoContrato)


        ''OBTENIENDO LAS GARANTIAS PARA LOS CONTRATOS

        'Dim mComGarantia As New cGARANTIASCONTRATOS
        'Dim dsGarantia As New Data.DataSet

        ''MONTO GARANTIA FIEL CUMPLIMIENTO


        'dsGarantia = mComGarantia.obtenerDatosGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 1)

        'Replace(textoReemplazado.ToString, "$MONTO_FIEL_CUMPLIMIENTO$", dsGarantia.Tables(0).Rows(0).Item("MONTO"))

        'Replace(textoReemplazado.ToString, "$PORCENTAJE_FIEL_CUMPLIMIENTO$", dsGarantia.Tables(0).Rows(0).Item("PORCENTAJE"))

        'Replace(textoReemplazado.ToString, "$VIGENCIA_FIEL_CUMPLIMIENTO$", dsGarantia.Tables(0).Rows(0).Item("VIGENCIA"))


        'dsGarantia = mComGarantia.obtenerDatosGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 2)

        'Replace(textoReemplazado.ToString, "$MONTO_GARANTIA_CALIDAD$", dsGarantia.Tables(0).Rows(0).Item("MONTO"))

        'Replace(textoReemplazado.ToString, "$PORCENTAJE_GARANTIA_CALIDAD$", dsGarantia.Tables(0).Rows(0).Item("PORCENTAJE"))

        'Replace(textoReemplazado.ToString, "$VIGENCIA_GARANTIA_CALIDAD$", dsGarantia.Tables(0).Rows(0).Item("VIGENCIA"))


        'dsGarantia = mComGarantia.obtenerDatosGarantia(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, 7)

        'Replace(textoReemplazado.ToString, "$MONTO_GARANTIA_MANTENIMIENTO_OFERTA$", dsGarantia.Tables(0).Rows(0).Item("MONTO"))

        'Replace(textoReemplazado.ToString, "$VIGENCIA_GARANTIA_MANTENIMIENTO$", dsGarantia.Tables(0).Rows(0).Item("VIGENCIA"))


        ''Obteniendo el código de la licitación

        'pos = InStr(textoContrato.ToString, "$CODIGO_LICITACION$")

        'If pos > 0 Then
        '    textoReemplazado = Replace(textoReemplazado.ToString, "$CODIGO_LICITACION$", Me.lblCodigoBase.Text)
        'End If

        ''Obteniendo el titulo de licitacion

        'Dim mComProcesoCompra As New cPROCESOCOMPRAS
        'Dim ds As New Data.DataSet
        'Dim lEntProcesoCompra As New PROCESOCOMPRAS

        'With lEntProcesoCompra
        '    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
        '    .IdProcesoCompra = Request.QueryString("IdProc")
        'End With

        'ds = mComProcesoCompra.recuperarDatosProcesoCompra(lEntProcesoCompra)

        ''Titulo de Licitación

        'textoReemplazado = Replace(textoReemplazado, "$TITULOLICITACION$", ds.Tables(0).Rows(0).Item("TITULOLICITACION"))

        'textoReemplazado = Replace(textoReemplazado, "$TIEMPO_ENTREGA_GARANTIA_CUMPLIMIENTO$", ds.Tables(0).Rows(0).Item("GARANTIACUMPLIMIENTOENTREGA"))

        'Try
        '    textoReemplazado = Replace(textoReemplazado, "$NUMERO_RESOLUCION$", ds.Tables(0).Rows(0).Item("NUMERORESOLUCION"))
        'Catch ex As Exception
        '    textoReemplazado = Replace(textoReemplazado, "$NUMERO_RESOLUCION$", "PENDIENTE NUMERO RESOLUCION")
        'End Try


        'textoReemplazado = Replace(textoReemplazado, "$GARANTIACALIDADENTREGA$", ds.Tables(0).Rows(0).Item("GARANTIACALIDADENTREGA"))

        'textoReemplazado = Replace(textoReemplazado, "$GARANTIAMTTOENTREGA$", ds.Tables(0).Rows(0).Item("GARANTIAMTTOENTREGA"))



        ''TIPO DE COMPRAS

        'Dim mComTipoCompra As New cTIPOCOMPRAS
        'Dim lEntTipoCompras As New TIPOCOMPRAS

        'lEntTipoCompras = mComTipoCompra.ObtenerTIPOCOMPRAS(ds.Tables(0).Rows(0).Item("IDTIPOCOMPRAEJECUTAR"))


        'textoReemplazado.Replace("$TIPO_COMPRA$", lEntTipoCompras.DESCRIPCION)

        textoReemplazado.Replace("<?xml:namespace prefix = o ns = " & Chr(34) & "urn:schemas-microsoft-com:office:office" & Chr(34) & " />", "")

        textoReemplazado.Replace("<DIV class=Section1><SPAN lang=ES-GT><o:p><FONT face=Tahoma size=3>&nbsp; ", "")
        textoReemplazado.Replace("<DIV class=Section1>", "")


        'File.Create("c:\pruebaPlantilla\prueba.doc")

        'File.AppendAllText("c:\pruebaPlantilla\prueba.doc", "<html>" & mDocumento.ToString & "</html>")



        IDPROCESOCOMPRA = Request.QueryString("IdProc")

        codigoLicita = Replace(codigoLicita, "/", "-")
        codigoLicita = Replace(codigoLicita, " ", "_")



        Dim directorio As String
        Dim contrato As String

        contrato = "MODC" & dgContratos.SelectedItem.Cells(2).Text & "PROV" & dgContratos.SelectedItem.Cells(3).Text & ".htm"

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & IDPROCESOCOMPRA

        If File.Exists(Server.MapPath(directorio & "\CONTRATOS\" & contrato)) Then
            File.Delete(Server.MapPath(directorio & "\CONTRATOS\" & contrato))
            File.AppendAllText(Server.MapPath(directorio & "\CONTRATOS\" & contrato), "<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" & textoReemplazado.ToString & "</html>")
        Else
            File.AppendAllText(Server.MapPath(directorio & "\CONTRATOS\" & contrato), "<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" & textoReemplazado.ToString & "</html>")
        End If


        btnCargarArchivo.Visible = True
        Me.fuContrato.Visible = True
        Me.Label18.Visible = True
        Me.lbVerContrato.Visible = True



    End Sub

    Protected Sub LinkButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton7.Click
        Me.pnlPaso8.Visible = True
        Me.Panel2.Visible = False
        obtenerGarantias()
    End Sub

    Private Function guardarModificativaContrato() As Integer

        Dim mComModifContrato As New cMODIFICATIVASCONTRATO
        Dim lEntidad As New MODIFICATIVASCONTRATO

        With lEntidad
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .FECHAMODIFICATIVA = Date.Today
            .ESTASINCRONIZADA = 0
            .NUMEROMODIFICATIVA = Me.txtNoModificativa.Text
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End With

        Return mComModifContrato.ActualizarMODIFICATIVASCONTRATO(lEntidad)

    End Function

    Private Sub obtenerGarantias()
        Dim cGarantiaContrato As New cGARANTIASCONTRATOS
        Dim ds As Data.DataSet
        ds = cGarantiaContrato.obtenerGarantiaContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(2).Text, Me.dgContratos.SelectedItem.Cells(3).Text, 1)

        Me.lblMonto.Text = ds.Tables(0).Rows(0).Item("MONTOCONTRATO")

        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)
                txtGARANTIACUMPLIMIENTOVALOR.Text = .Item("PORCENTAJE").ToString
                txtGARANTIACUMPLIMIENTOENTREGA.Text = .Item("ENTREGA").ToString
                txtGARANTIACUMPLIMIENTOVIGENCIA.Text = .Item("VIGENCIA").ToString
            End With

        End If

        ds = cGarantiaContrato.obtenerGarantiaContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(2).Text, Me.dgContratos.SelectedItem.Cells(3).Text, 2)

        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                txtGARANTIACALIDADVALOR.Text = .Item("PORCENTAJE").ToString
                txtGARANTIACALIDADENTREGA.Text = .Item("ENTREGA").ToString
                txtGARANTIACALIDADVIGENCIA.Text = .Item("VIGENCIA").ToString

            End With

        End If

        ds = cGarantiaContrato.obtenerGarantiaContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(2).Text, Me.dgContratos.SelectedItem.Cells(3).Text, 7)

        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)
                txtGARANTIAMTTOENTREGA.Text = .Item("ENTREGA").ToString
                txtGARANTIAMNTTOVIGENCIA.Text = .Item("VIGENCIA").ToString
            End With

        End If

    End Sub

    Protected Sub dgClausulas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgClausulas.SelectedIndexChanged
        Me.Panel2.Visible = False
        idClausula = dgClausulas.SelectedItem.Cells(5).Text
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
            ds = mComponente.verificaExistencia(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(2).Text, Me.dgContratos.SelectedItem.Cells(3).Text, idClausula)
            'desde aqui
            If flagSaveClausula = 0 Then
                With ds.Tables(0).Rows(0)
                    Me.txtOrden.Text = .Item("ORDEN")
                    Me.txtValidaOrden.Text = .Item("ORDEN")
                    'Else
                    'Me.txtOrden.Text = mComponente.obtenerOrden(Session("IdEstablecimiento"), IDPLANTILLA, idClausula)
                    'End If
                    'If imbOK.Visible = True Then
                    If idOrigen = "B" Then
                        Me.rteContenido.Text = .Item("ENCABEZADOCLAUSULA")
                    Else
                        Me.rteContenido.Text = .Item("CONTENIDO")
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
        Me.dgEtiqueta.DataSource = mComponente.ObtenerDataSetPorTipo(tipo)
        Me.dgEtiqueta.DataBind()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim mComponente As New cCLAUSULASCONTRATOS
        Dim lEntidad As New CLAUSULASCONTRATOS

        With lEntidad
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .IDCLAUSULACONTRATO = Me.dgClausulas.SelectedItem.Cells(7).Text
            .IDMODIFICATIVA = Me.lblIdModificativa.Text
            .ORDEN = Me.txtOrden.Text
            .ENCABEZADOCLAUSULA = Me.rteContenido.Text
            .IDCLAUSULA = Me.dgClausulas.SelectedItem.Cells(5).Text
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
        End With


        flagSaveClausula = 0

        If mComponente.ActualizarCLAUSULASCONTRATOS(lEntidad) <> 1 Then

            Me.MsgBox1.ShowAlert("El registro no ha sido almacenado, verifique sus datos o informe al administrador", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        Else
            Me.MsgBox1.ShowAlert("El registro se ha almacenado satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End If


    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Panel4.Visible = False
        Me.Panel2.Visible = True
        Me.obtenerClausulasPlantilla()
        Me.dgClausulas.CurrentPageIndex = 0
        Me.dgClausulas.SelectedIndex = -1
        flagSaveClausula = 0
    End Sub

    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click

        guardarGarantias(IDCONTRATO, CDec(Me.lblMonto.Text)) 'montoContrato)
        Me.pnlPaso8.Visible = False
        Me.Panel5.Visible = True
    End Sub

    Private Sub guardarGarantias(ByVal IDCONTRATO As Integer, ByVal montoContrato As Decimal)

        Dim mComProcesoCompra As New cPROCESOCOMPRAS
        Dim ds As Data.DataSet

        ds = mComProcesoCompra.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        Dim GARANTIAMTTOENTREGA As Integer
        Dim GARANTIAMTTOVIGENCIA As Integer
        Dim GARANTIACUMPLIMIENTOVALOR As Decimal
        Dim GARANTIACUMPLIMIENTOENTREGA As Integer
        Dim GARANTIACUMPLIMIENTOVIGENCIA As Integer
        Dim GARANTIACALIDADVALOR As Decimal
        Dim GARANTIACALIDADENTREGA As Integer
        Dim GARANTIACALIDADVIGENCIA As Integer


        With ds.Tables(0).Rows(0)
            GARANTIAMTTOENTREGA = Me.txtGARANTIAMTTOENTREGA.Text
            GARANTIAMTTOVIGENCIA = Me.txtGARANTIAMNTTOVIGENCIA.Text
            GARANTIACUMPLIMIENTOVALOR = Me.txtGARANTIACUMPLIMIENTOVALOR.Text
            GARANTIACUMPLIMIENTOENTREGA = Me.txtGARANTIACUMPLIMIENTOENTREGA.Text
            GARANTIACUMPLIMIENTOVIGENCIA = Me.txtGARANTIACUMPLIMIENTOVIGENCIA.Text
            GARANTIACALIDADVALOR = Me.txtGARANTIACALIDADVALOR.Text
            GARANTIACALIDADENTREGA = Me.txtGARANTIACALIDADENTREGA.Text
            GARANTIACALIDADVIGENCIA = Me.txtGARANTIACALIDADVIGENCIA.Text
        End With


        Dim mComContrato As New cCONTRATOS

        Dim mComGarantiaContrato As New cGARANTIASCONTRATOS
        Dim lEntGarantiaContrato As New GARANTIASCONTRATOS

        With lEntGarantiaContrato
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .IDMODIFICATIVA = CDec(lblIdModificativa.Text)
            .IDTIPOGARANTIA = 1
            .NUMEROGARANTIA = ""
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .ENTREGA = GARANTIACUMPLIMIENTOENTREGA
            .IDESTADOGARANTIA = 1
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .FECHAENTREGA = mComContrato.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text).Tables(0).Rows(0).Item("FECHAINICIOENTREGA")
            .VIGENCIA = GARANTIACUMPLIMIENTOVIGENCIA
            .PORCENTAJE = GARANTIACUMPLIMIENTOVALOR
            .MONTO = (montoContrato * (GARANTIACUMPLIMIENTOVALOR / 100))
        End With

        Dim IDGARANTIACONTRATO As Integer

        Try
            IDGARANTIACONTRATO = mComGarantiaContrato.validaExistenciaGarantiaModificativa(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, 1, Me.lblIdModificativa.Text)
        Catch ex As Exception
            IDGARANTIACONTRATO = 0
        End Try


        lEntGarantiaContrato.IDGARANTIACONTRATO = IDGARANTIACONTRATO


        mComGarantiaContrato.ActualizarGARANTIASCONTRATOS(lEntGarantiaContrato)

        'If ViewState("ESTADO") = "NEW" Then
        '    lEntGarantiaContrato.IDGARANTIACONTRATO = 0
        'End If


        With lEntGarantiaContrato
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .IDMODIFICATIVA = CDec(lblIdModificativa.Text)
            .IDTIPOGARANTIA = 2
            .ENTREGA = GARANTIACALIDADENTREGA
            .NUMEROGARANTIA = ""
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDESTADOGARANTIA = 1
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .FECHAENTREGA = mComContrato.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text).Tables(0).Rows(0).Item("FECHAINICIOENTREGA")
            .VIGENCIA = GARANTIACALIDADVIGENCIA
            .PORCENTAJE = GARANTIACALIDADVALOR
            .MONTO = (montoContrato * (GARANTIACALIDADVALOR / 100))
        End With


        Try
            IDGARANTIACONTRATO = mComGarantiaContrato.validaExistenciaGarantiaModificativa(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, 2, Me.lblIdModificativa.Text)
        Catch ex As Exception
            IDGARANTIACONTRATO = 0
        End Try

        lEntGarantiaContrato.IDGARANTIACONTRATO = IDGARANTIACONTRATO

        mComGarantiaContrato.ActualizarGARANTIASCONTRATOS(lEntGarantiaContrato)

        'If ViewState("ESTADO") = "NEW" Then
        '    lEntGarantiaContrato.IDGARANTIACONTRATO = 0
        'End If

        With lEntGarantiaContrato
            .IDCONTRATO = Me.dgContratos.SelectedItem.Cells(2).Text
            .IDPROVEEDOR = Me.dgContratos.SelectedItem.Cells(3).Text
            .IDMODIFICATIVA = CDec(lblIdModificativa.Text)
            .IDTIPOGARANTIA = 7
            .ENTREGA = GARANTIAMTTOENTREGA
            .NUMEROGARANTIA = ""
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDESTADOGARANTIA = 1
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            .FECHAENTREGA = mComContrato.ObtenerDataSetPorId(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text).Tables(0).Rows(0).Item("FECHAINICIOENTREGA")
            .VIGENCIA = GARANTIAMTTOVIGENCIA
            .MONTO = mComGarantiaContrato.obtenerGARANTIAMNTTOVALOR(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgContratos.SelectedItem.Cells(3).Text)
        End With

        Try
            IDGARANTIACONTRATO = mComGarantiaContrato.validaExistenciaGarantiaModificativa(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(3).Text, Me.dgContratos.SelectedItem.Cells(2).Text, 7, Me.lblIdModificativa.Text)
        Catch ex As Exception
            IDGARANTIACONTRATO = 0
        End Try

        ViewState("ESTADO") = "EDIT"
        lEntGarantiaContrato.IDGARANTIACONTRATO = IDGARANTIACONTRATO

        mComGarantiaContrato.ActualizarGARANTIASCONTRATOS(lEntGarantiaContrato)


    End Sub

    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
        Me.pnlPaso8.Visible = True
        Me.Panel5.Visible = False
        Me.ViewState("ESTADO") = "EDIT"
    End Sub

    Protected Sub dgModificativa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgModificativa.SelectedIndexChanged

        LinkButton5.Enabled = True
    End Sub

    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton12.Click
        Dim mComProdContrato As New cPRODUCTOSCONTRATO
        Me.DataGrid1.DataSource = mComProdContrato.obtenerProductosAdjudicadosContrato(Session("IdEstablecimiento"), Me.dgContratos.SelectedItem.Cells(2).Text, Me.dgContratos.SelectedItem.Cells(3).Text)
        Me.DataGrid1.DataBind()
        Panel3.Visible = False
        Panel6.Visible = True
        Me.ViewState("ESTADO") = "NEW"

        lblIdModificativa.Text = guardarModificativaContrato()

        Me.txtNoModificativa.ReadOnly = False
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click

    End Sub

    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click

    End Sub

    Protected Sub lbContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbContrato.Click
        descargarArchivo()
        Me.fuContrato.Visible = True
        Me.btnCargarArchivo.Visible = True
    End Sub

    Private Sub descargarArchivo()

        Dim contrato, directorio As String

        contrato = "MODC" & dgContratos.SelectedItem.Cells(2).Text & "PROV" & dgContratos.SelectedItem.Cells(3).Text & ".doc"

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

    Protected Sub btnCargarArchivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarArchivo.Click

        Dim contrato, directorio As String

        contrato = "MODC" & dgContratos.SelectedItem.Cells(3).Text & "PROV" & dgContratos.SelectedItem.Cells(3).Text & ".htm"

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
                Me.lblCargaArchivo.Text = "El archivo se cargó satisfactoriamente"
            Catch ex As Exception
                Me.lblCargaArchivo.Text = "ERROR: " & ex.Message.ToString()
            End Try
        Else
            Label1.Text = "You have not specified a file."
        End If

    End Sub

    Protected Sub lbVerContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVerContrato.Click

        Dim contrato, directorio As String
        contrato = "MODC" & dgContratos.SelectedItem.Cells(2).Text & "PROV" & dgContratos.SelectedItem.Cells(3).Text & ".htm"

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & IDPROCESOCOMPRA

        Dim openWindow As String
        openWindow = "<script type=text/javascript> window.open('" & directorio & "/CONTRATOS/" & contrato & "',  '_blank') </script>"

        Response.Write(openWindow)

    End Sub

End Class
