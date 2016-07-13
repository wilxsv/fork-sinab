Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class wfCatalogoProductoM
    Inherits System.Web.UI.Page

    Private _IDPRODUCTO As Int64

    Private mComponente As New cCATALOGOPRODUCTOS
    Private mEntidad As CATALOGOPRODUCTOS

#Region " Propiedades "

    Public Property IDPRODUCTO() As Int64
        Get
            Return Me._IDPRODUCTO
        End Get
        Set(ByVal value As Int64)
            Me._IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            'Dim bPermiteEditar As Boolean = clsObtenerDatos.OpcionPermiteEditar(Session.Item("IdRol"), Request.AppRelativeCurrentExecutionFilePath)

            CargarDDLs()
            Me.plDatos.Visible = False
        Else
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarDatos(ByVal IDPRODUCTO As Integer)

        mEntidad = New CATALOGOPRODUCTOS

        mEntidad.IDPRODUCTO = Me.IDPRODUCTO

        If mComponente.ObtenerCATALOGOPRODUCTOS(mEntidad) <> 1 Then
            MessageBox.Alert("Error al obtener registro.", "error")
            '' MsgBox1.ShowAlert("Error al obtener registro.", "error", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
            Return
        End If

        Me.txtCODIGO.Text = Left(mEntidad.CODIGO, 5)
        Me.txtCORRELATIVO.Text = Right(mEntidad.CODIGO, 3)
        'IDTIPOPRODUCTO
        Me.ddlUNIDADMEDIDAS1.SelectedValue = mEntidad.IDUNIDADMEDIDA
        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.ddlNIVELESUSO1.SelectedValue = mEntidad.NIVELUSO
        Me.txtCONCENTRACION.Text = mEntidad.CONCENTRACION
        Me.txtFORMAFARMACEUTICA.Text = mEntidad.FORMAFARMACEUTICA
        Me.txtPRESENTACION.Text = mEntidad.PRESENTACION
        'PRIORIDAD
        Me.nbPRECIOACTUAL.Text = mEntidad.PRECIOACTUAL
        Me.cbAPLICALOTE.Checked = IIf(mEntidad.APLICALOTE = 1, True, False)
        'EXISTENCIAACTUAL
        'ESPECIFICACIONESTECNICAS
        Me.txtCODIGONACIONESUNIDAS.Text = mEntidad.CODIGONACIONESUNIDAS
        Me.cbPerteneceListadoOficial.Checked = IIf(mEntidad.PERTENECELISTADOOFICIAL = 1, True, False)
        Me.cbESTADOPRODUCTO.Checked = IIf(mEntidad.ESTADOPRODUCTO = 1, True, False)
        Me.txtOBSERVACION.Text = mEntidad.OBSERVACION
        Me.ddlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
        Me.ddlClasificacion.SelectedValue = mEntidad.CLASIFICACION
        Me.ddlAreaTecnica1.SelectedValue = mEntidad.AREATECNICA
        Me.ddlTipoUaci.SelectedValue = mEntidad.TIPOUACI
        Me.ddlESPECIFICOSGASTO1.SelectedValue = mEntidad.IDESPECIFICOGASTO

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtCODIGO.Enabled = edicion
        Me.txtCORRELATIVO.Enabled = edicion
        Me.ddlSUBGRUPOS1.Enabled = edicion
        Me.ddlUNIDADMEDIDAS1.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
        Me.ddlNIVELESUSO1.Enabled = edicion
        Me.txtCONCENTRACION.Enabled = edicion
        Me.txtFORMAFARMACEUTICA.Enabled = edicion
        Me.txtPRESENTACION.Enabled = edicion
        'PRIORIDAD
        Me.nbPRECIOACTUAL.Enabled = edicion
        Me.cbAPLICALOTE.Enabled = edicion
        'EXISTENCIAACTUAL
        'ESPECIFICACIONESTECNICAS
        Me.txtCODIGONACIONESUNIDAS.Enabled = edicion
        Me.cbPerteneceListadoOficial.Enabled = edicion
        Me.cbESTADOPRODUCTO.Enabled = edicion
        Me.txtOBSERVACION.Enabled = edicion
        Me.ddlESTABLECIMIENTOS1.Enabled = edicion
        Me.ddlClasificacion.Enabled = edicion
        Me.ddlAreaTecnica1.Enabled = edicion
        Me.ddlTipoUaci.Enabled = edicion
        Me.ddlESPECIFICOSGASTO1.Enabled = edicion
    End Sub

    Public Sub Actualizar()

        If Me.txtNOMBRE.Text.Trim = String.Empty Then
            ' Me.MsgBox1.ShowAlert("Nombre es requerido.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            MessageBox.Alert("Nombre es requerido.", "Requerido")
            Exit Sub
        End If

        If Len(Me.txtCORRELATIVO.Text.Trim) <> 3 Then
            'Me.MsgBox1.ShowAlert("Correlativo debe tener 3 caracteres.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            MessageBox.Alert("Correlativo debe tener 3 caracteres.", "Requerido")
            Exit Sub
        End If

        If mComponente.ExisteCodigo(Me.txtCODIGO.Text + Me.txtCORRELATIVO.Text, Me.IDPRODUCTO) Then
            '' Me.MsgBox1.ShowAlert("El código asignado ya existe.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            MessageBox.Alert("El código asignado ya existe.", "Error")
            Exit Sub
        End If

        mEntidad = New CATALOGOPRODUCTOS
        mEntidad.IDPRODUCTO = Me.IDPRODUCTO

        If Me.IDPRODUCTO = 0 Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now
        Else
            mComponente.ObtenerCatalogoProductos(mEntidad)
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now
        End If

        mEntidad.CODIGO = Me.txtCODIGO.Text + Me.txtCORRELATIVO.Text
        mEntidad.IDTIPOPRODUCTO = Me.ddlSUBGRUPOS1.SelectedValue
        mEntidad.IDUNIDADMEDIDA = Me.ddlUNIDADMEDIDAS1.SelectedValue
        mEntidad.NOMBRE = Me.txtNOMBRE.Text.Trim
        mEntidad.NIVELUSO = Me.ddlNIVELESUSO1.SelectedValue
        mEntidad.CONCENTRACION = Me.txtCONCENTRACION.Text
        mEntidad.FORMAFARMACEUTICA = Me.txtFORMAFARMACEUTICA.Text
        mEntidad.PRESENTACION = Me.txtPRESENTACION.Text
        mEntidad.PRIORIDAD = 0
        mEntidad.PRECIOACTUAL = CDec(Me.nbPRECIOACTUAL.Text)
        mEntidad.APLICALOTE = IIf(Me.cbAPLICALOTE.Checked, 1, 0)
        mEntidad.EXISTENCIAACTUAL = 0
        mEntidad.ESPECIFICACIONESTECNICAS = 0
        mEntidad.CODIGONACIONESUNIDAS = Me.txtCODIGONACIONESUNIDAS.Text
        mEntidad.PERTENECELISTADOOFICIAL = IIf(Me.cbPerteneceListadoOficial.Checked, 1, 0)
        mEntidad.ESTADOPRODUCTO = IIf(Me.cbESTADOPRODUCTO.Checked, 1, 0)
        mEntidad.OBSERVACION = Me.txtOBSERVACION.Text

        mEntidad.ESTASINCRONIZADA = 0
        mEntidad.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
        mEntidad.CLASIFICACION = Me.ddlClasificacion.SelectedValue
        mEntidad.AREATECNICA = Me.ddlAreaTecnica1.SelectedValue
        mEntidad.TIPOUACI = Me.ddlTipoUaci.SelectedValue
        mEntidad.IDESPECIFICOGASTO = Me.ddlESPECIFICOSGASTO1.SelectedValue

        If mComponente.ActualizarCATALOGOPRODUCTOS(mEntidad) = 1 Or mComponente.ActualizarCATALOGOPRODUCTOS(mEntidad) = 2 Then
            Limpiar()
            CargarProductos()
        Else
            MessageBox.Alert("Error al guardar el registro.", "Error")
            ''  MsgBox1.ShowAlert("Error al guardar el registro.", "error", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        End If

    End Sub

    Private Sub CargarDDLs()
        Me.ddlUNIDADMEDIDAS1.Recuperar()
        Me.ddlNIVELESUSO1.Recuperar()
        Me.ddlSUMINISTROS1.RecuperarListaFiltrada(1)
        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Dim IDGRUPO As Integer
        If Me.ddlGRUPOS1.Items.Count = 0 Then
            Me.ddlGRUPOS1.Visible = False
        Else
            IDGRUPO = Me.ddlGRUPOS1.SelectedValue
            Me.ddlGRUPOS1.Visible = True
        End If
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(IDGRUPO)
        If Me.ddlSUBGRUPOS1.Items.Count = 0 Then
            Me.ddlSUBGRUPOS1.Visible = False
        Else
            Me.ddlSUBGRUPOS1.Visible = True
        End If

        Dim item As New ListItem("(Sin selección)", 0)

        Me.ddlClasificacion.Items.Insert(0, item)

        Me.ddlAreaTecnica1.ObtenerAreaTecnica()
        Me.ddlAreaTecnica1.Items.Insert(0, item)

        Me.ddlESTABLECIMIENTOS1.RecuperarEstablecimientos()
        Me.ddlESTABLECIMIENTOS1.Items.Insert(0, item)

        Dim cc As New cCATALOGOPRODUCTOS
        Dim ddTipoUaci, ddEspecificoGasto As DropDownList

        ddTipoUaci = Me.ddlTipoUaci
        ddTipoUaci.DataSource = cc.ObtenerTipoUACI
        ddTipoUaci.DataValueField = "IDGRUPO"
        ddTipoUaci.DataTextField = "GRUPOUACI"
        ddTipoUaci.DataBind()

        Me.ddlESPECIFICOSGASTO1.RecuperarEspecificos()
        Me.ddlESPECIFICOSGASTO1.Items.Insert(0, item)

        CargarProductos()
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Dim IDGRUPO As Integer
        If Me.ddlGRUPOS1.Items.Count = 0 Then
            Me.ddlGRUPOS1.Visible = False
        Else
            IDGRUPO = Me.ddlGRUPOS1.SelectedValue
            Me.ddlGRUPOS1.Visible = True
        End If
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(IDGRUPO)
        If Me.ddlSUBGRUPOS1.Items.Count = 0 Then
            Me.ddlSUBGRUPOS1.Visible = False
        Else
            Me.ddlSUBGRUPOS1.Visible = True
        End If
        CargarProductos()
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
        If Me.ddlSUBGRUPOS1.Items.Count = 0 Then
            Me.ddlSUBGRUPOS1.Visible = False
        Else
            Me.ddlSUBGRUPOS1.Visible = True
        End If
        CargarProductos()
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        CargarProductos()
    End Sub

    Private Sub CargarProductos()

        Dim IDSUBGRUPO As Integer = IIf(Me.ddlSUBGRUPOS1.Items.Count = 0, 0, Me.ddlSUBGRUPOS1.SelectedValue)

        Dim cCP As New cCATALOGOPRODUCTOS

        'SE MODIFICA PARA CHEQUEAR EN EL GV QUE EL PRODUCTO PERTENECE O NO AL LISTADO OFICIAL
        'MAYRA MARTINEZ 15/FEBRERO/2011

        Dim dsL As System.Data.DataSet
        dsL = cCP.ObtenerCatalogoProductosCompletoPorSubgrupo(IDSUBGRUPO)

        dsL.Tables(0).Columns.Add("PERTENECELISTADOOFICIALCHK", System.Type.GetType("System.Boolean"))

        For Each fila As System.Data.DataRow In dsL.Tables(0).Rows
            If fila("PERTENECELISTADOOFICIAL") = 0 Then
                fila.BeginEdit()
                fila("PERTENECELISTADOOFICIALCHK") = False
                fila.EndEdit()
            Else
                fila.BeginEdit()
                fila("PERTENECELISTADOOFICIALCHK") = True
                fila.EndEdit()
            End If

        Next
        dsL.Tables(0).TableName = "vv_CATALOGOPRODUCTOS"
        Session("dsCatalogoProducto") = dsL.Tables(0)
        Me.gvLista.DataSource = CType(Session("dsCatalogoProducto"), Data.DataTable) ' dsL

        Try
            If dsL.Tables(0).Rows.Count = 0 Then
                ImgBtnRpt.Visible = False
            Else
                ImgBtnRpt.Visible = True
            End If
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Me.gvLista.SelectedIndex = -1
        Me.plDatos.Visible = False
        Me.btnAgregar.Visible = True

    End Sub

    Public Sub AgregarProducto()
        Me.IDPRODUCTO = 0
        Me.plDatos.Visible = True
        Limpiar()
    End Sub

    Protected Sub gvLista_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvLista.SelectedIndexChanging
        Me.IDPRODUCTO = Me.gvLista.DataKeys(e.NewSelectedIndex).Values.Item("IDPRODUCTO")

        CargarDatos(Me.IDPRODUCTO)
        Me.plDatos.Visible = True
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Actualizar()
    End Sub

    Private Sub Limpiar()
        Me.gvLista.SelectedIndex = -1

        Me.txtCODIGO.Text = String.Empty
        Me.txtCORRELATIVO.Text = String.Empty
        'IDTIPOPRODUCTO
        Me.ddlUNIDADMEDIDAS1.ClearSelection()
        Me.txtNOMBRE.Text = String.Empty
        Me.ddlNIVELESUSO1.ClearSelection()
        Me.txtCONCENTRACION.Text = String.Empty
        Me.txtFORMAFARMACEUTICA.Text = String.Empty
        Me.txtPRESENTACION.Text = String.Empty
        'PRIORIDAD
        Me.nbPRECIOACTUAL.Text = 0
        Me.cbAPLICALOTE.Checked = False
        'EXISTENCIAACTUAL
        'ESPECIFICACIONESTECNICAS
        Me.txtCODIGONACIONESUNIDAS.Text = String.Empty
        Me.cbPerteneceListadoOficial.Checked = False
        Me.cbESTADOPRODUCTO.Checked = False
        Me.txtOBSERVACION.Text = String.Empty
        Me.ddlESTABLECIMIENTOS1.ClearSelection()
        Me.ddlClasificacion.ClearSelection()
        Me.ddlAreaTecnica1.ClearSelection()
        Me.ddlTipoUaci.ClearSelection()
        Me.ddlESPECIFICOSGASTO1.ClearSelection()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        Me.btnAgregar.Visible = False

        AgregarProducto()

        Dim cS As New cSUMINISTROS
        Dim cG As New cGRUPOS
        Dim cSG As New cSUBGRUPOS

        Dim IDSUMINISTRO As Integer = Me.ddlSUMINISTROS1.SelectedValue
        Dim IDGRUPO As Integer = Me.ddlGRUPOS1.SelectedValue
        Dim IDSUBGRUPO As Integer = Me.ddlSUBGRUPOS1.SelectedValue

        Me.txtCODIGO.Text = cS.DevolverCorrSuministro(IDSUMINISTRO) & cG.DevolverCorrGrupo(IDGRUPO) & cSG.DevolverCorrSubgrupo(IDSUBGRUPO)

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()
        Me.btnAgregar.Visible = True
        Me.plDatos.Visible = False
    End Sub

    Protected Sub ImgBtnRpt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnRpt.Click
        'Dim popup As New StringBuilder
        'popup.Append("<script language='javascript'>")
        'popup.Append("window.open('" & Request.ApplicationPath & "/")
        'popup.Append("Reportes/Visores/frmRptCatalogoProductos.aspx', 'popup', ")
        'popup.Append("'scrollbars=1, resizable=1, width=800, height=600')")
        'popup.Append("</script>")

        'Page.ClientScript.RegisterStartupScript(Me.GetType, "PopupScript", popup.ToString)
        SINAB_Utils.Utils.MostrarVentana("Reportes/Visores/frmRptCatalogoProductos.aspx")
    End Sub
End Class
