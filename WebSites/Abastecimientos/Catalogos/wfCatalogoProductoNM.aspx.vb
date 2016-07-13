Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class wfCatalogoProductoNM
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

        If mComponente.ObtenerCatalogoProductos(mEntidad) <> 1 Then
            MsgBox1.ShowAlert("Error al obtener registro.", "error", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
            Return
        End If

        Me.txtCODIGO.Text = Left(mEntidad.CODIGO, 5)
        Me.txtCORRELATIVO.Text = Right(mEntidad.CODIGO, 3)
        'IDTIPOPRODUCTO
        Me.ddlUNIDADMEDIDAS1.SelectedValue = mEntidad.IDUNIDADMEDIDA
        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.ddlNIVELESUSO1.SelectedValue = mEntidad.NIVELUSO
        'CONCENTRACION
        'FORMAFARMACEUTICA
        'PRESENTACION
        'PRIORIDAD
        Me.nbPRECIOACTUAL.Text = mEntidad.PRECIOACTUAL
        Me.cbAPLICALOTE.Checked = IIf(mEntidad.APLICALOTE = 1, True, False)
        'EXISTENCIAACTUAL
        'ESPECIFICACIONESTECNICAS
        'CODIGONACIONESUNIDAS
        Me.txtCodONU.Text = mEntidad.CODIGONACIONESUNIDAS


        'If Not mEntidad.CODIGONACIONESUNIDAS Is Nothing Then
        '    txtCodONU.Text = mEntidad.CODIGONACIONESUNIDAS.ToString()
        'End If

        'Me.txtCodONU.Text = mEntidad.CODIGONACIONESUNIDAS
        Me.cbPerteneceListadoOficial.Checked = IIf(mEntidad.PERTENECELISTADOOFICIAL = 1, True, False)
        Me.cbESTADOPRODUCTO.Checked = IIf(mEntidad.ESTADOPRODUCTO = 1, True, False)
        Me.txtOBSERVACION.Text = mEntidad.OBSERVACION
        Me.ddlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
        'CLASIFICACION
        Me.ddlAreaTecnica1.SelectedValue = mEntidad.AREATECNICA
        Me.ddlTipoUaci.SelectedValue = mEntidad.TIPOUACI
        Me.ddlESPECIFICOSGASTO1.SelectedValue = mEntidad.IDESPECIFICOGASTO

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtCODIGO.Enabled = edicion
        Me.txtCORRELATIVO.Enabled = edicion
        'IDTIPOPRODUCTO
        Me.ddlUNIDADMEDIDAS1.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
        Me.ddlNIVELESUSO1.Enabled = edicion
        'CONCENTRACION
        'FORMAFARMACEUTICA
        'PRESENTACION
        'PRIORIDAD
        Me.nbPRECIOACTUAL.Enabled = edicion
        Me.cbAPLICALOTE.Enabled = edicion
        'EXISTENCIAACTUAL
        'ESPECIFICACIONESTECNICAS
        'CODIGONACIONESUNIDAS
        Me.txtCodONU.Enabled = edicion
        Me.cbPerteneceListadoOficial.Enabled = edicion
        Me.cbESTADOPRODUCTO.Enabled = edicion
        Me.txtOBSERVACION.Enabled = edicion
        Me.ddlESTABLECIMIENTOS1.Enabled = edicion
        'CLASIFICACION
        Me.ddlAreaTecnica1.Enabled = edicion
        Me.ddlTipoUaci.Enabled = edicion
        Me.ddlESPECIFICOSGASTO1.Enabled = edicion
    End Sub

    Public Sub Actualizar()

        If Me.txtNOMBRE.Text.Trim = String.Empty Then
            Me.MsgBox1.ShowAlert("Nombre es requerido.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        If Len(Me.txtCORRELATIVO.Text.Trim) <> 3 Then
            Me.MsgBox1.ShowAlert("Correlativo debe tener 3 caracteres.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        If mComponente.ExisteCodigo(Me.txtCODIGO.Text + Me.txtCORRELATIVO.Text, Me.IDPRODUCTO) Then
            Me.MsgBox1.ShowAlert("El código asignado ya existe.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
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
        mEntidad.CONCENTRACION = 0
        mEntidad.FORMAFARMACEUTICA = 0
        mEntidad.PRESENTACION = 0
        mEntidad.PRIORIDAD = 0
        mEntidad.PRECIOACTUAL = CDec(Me.nbPRECIOACTUAL.Text)
        mEntidad.APLICALOTE = IIf(Me.cbAPLICALOTE.Checked, 1, 0)
        mEntidad.EXISTENCIAACTUAL = 0
        mEntidad.ESPECIFICACIONESTECNICAS = 0
        'mEntidad.CODIGONACIONESUNIDAS = String.Empty
        mEntidad.PERTENECELISTADOOFICIAL = IIf(Me.cbPerteneceListadoOficial.Checked, 1, 0)
        mEntidad.ESTADOPRODUCTO = IIf(Me.cbESTADOPRODUCTO.Checked, 1, 0)
        mEntidad.OBSERVACION = Me.txtOBSERVACION.Text
        mEntidad.CODIGONACIONESUNIDAS = txtCodONU.Text
        mEntidad.ESTASINCRONIZADA = 0
        mEntidad.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
        mEntidad.CLASIFICACION = 0
        mEntidad.AREATECNICA = Me.ddlAreaTecnica1.SelectedValue
        mEntidad.TIPOUACI = Me.ddlTipoUaci.SelectedValue
        mEntidad.IDESPECIFICOGASTO = Me.ddlESPECIFICOSGASTO1.SelectedValue

        If mComponente.ActualizarCATALOGOPRODUCTOS(mEntidad) = 1 Then
            Limpiar()
            CargarProductos()
        Else
            MsgBox1.ShowAlert("Error al guardar el registro.", "error", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        End If

    End Sub

    Private Sub CargarDDLs()
        Me.ddlUNIDADMEDIDAS1.Recuperar()
        Me.ddlNIVELESUSO1.Recuperar()
        Me.ddlSUMINISTROS1.RecuperarListaFiltrada(1, 1)
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

        Me.gvLista.DataSource = dsL

        Try
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
        'CONCENTRACION
        'FORMAFARMACEUTICA
        'PRESENTACION
        'PRIORIDAD
        Me.nbPRECIOACTUAL.Text = 0
        Me.cbAPLICALOTE.Checked = False
        'EXISTENCIAACTUAL
        'ESPECIFICACIONESTECNICAS
        'CODIGONACIONESUNIDAS
        Me.cbPerteneceListadoOficial.Checked = False
        Me.cbESTADOPRODUCTO.Checked = False
        Me.txtOBSERVACION.Text = String.Empty
        Me.ddlESTABLECIMIENTOS1.ClearSelection()
        'CLASIFICACION
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

End Class
