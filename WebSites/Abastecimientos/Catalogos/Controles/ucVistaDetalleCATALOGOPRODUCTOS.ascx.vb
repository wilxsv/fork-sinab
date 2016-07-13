Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleCATALOGOPRODUCTOS
    Inherits System.Web.UI.UserControl

    Private _IDPRODUCTO As Int64

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cCATALOGOPRODUCTOS
    Private mEntidad As CATALOGOPRODUCTOS

    Public Event ErrorEvent(ByVal errorMessage As String)

#Region " Propiedades "

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal value As Boolean)
            Me.HabilitarEdicion(value)
        End Set
    End Property

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

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

        If Not IsPostBack Then
            CargarDDLs()
            Me.plDatos.Visible = False
        Else
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
        End If

    End Sub

    Private Sub CargarDatos(ByVal IDPRODUCTO As Integer)

        mEntidad = New CATALOGOPRODUCTOS

        mEntidad.IDPRODUCTO = IDPRODUCTO

        If mComponente.ObtenerCatalogoProductos(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If

        Me.txtCODIGO.Text = Left(mEntidad.CODIGO, 5)
        Me.txtCORRELATIVO.Text = Right(mEntidad.CODIGO, 3)
        Me.ddlSUBGRUPOS1.SelectedValue = mEntidad.IDTIPOPRODUCTO
        Me.ddlUNIDADMEDIDAS1.SelectedValue = mEntidad.IDUNIDADMEDIDA
        Me.ddlNIVELESUSO1.SelectedValue = mEntidad.NIVELUSO
        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.nbPRECIOACTUAL.Text = mEntidad.PRECIOACTUAL
        Me.cbAPLICALOTE.Checked = IIf(mEntidad.APLICALOTE = 1, True, False)

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtCODIGO.Enabled = edicion
        Me.txtCORRELATIVO.Enabled = edicion
        Me.ddlSUBGRUPOS1.Enabled = edicion
        Me.ddlUNIDADMEDIDAS1.Enabled = edicion
        Me.ddlNIVELESUSO1.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
        Me.nbPRECIOACTUAL.Enabled = edicion
        Me.cbAPLICALOTE.Enabled = edicion
    End Sub

    Private Sub Nuevo()

        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If
    End Sub

    Public Sub Actualizar()

        If Me.txtNOMBRE.Text.Trim = String.Empty Then
            'Me.MsgBox1.ShowAlert("Este código ya existe para un producto.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        If Len(Me.txtCORRELATIVO.Text.Trim) <> 3 Then
            'Me.MsgBox1.ShowAlert("Este código ya existe para un producto.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        If mComponente.ExisteCodigo(Me.txtCODIGO.Text + Me.txtCORRELATIVO.Text, Me.IDPRODUCTO) Then
            'Me.MsgBox1.ShowAlert("Este código ya existe para un producto.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        mEntidad = New CATALOGOPRODUCTOS

        If Me._nuevo Then
            mEntidad.IDPRODUCTO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDPRODUCTO = Me.IDPRODUCTO
            mComponente.ObtenerCatalogoProductos(mEntidad)
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.CODIGO = Me.txtCODIGO.Text + Me.txtCORRELATIVO.Text
        mEntidad.IDTIPOPRODUCTO = Me.ddlSUBGRUPOS1.SelectedValue
        mEntidad.IDUNIDADMEDIDA = Me.ddlUNIDADMEDIDAS1.SelectedValue
        mEntidad.NIVELUSO = Me.ddlNIVELESUSO1.SelectedValue
        mEntidad.NOMBRE = Me.txtNOMBRE.Text.Trim
        mEntidad.PRECIOACTUAL = CDec(Me.nbPRECIOACTUAL.Text)
        mEntidad.APLICALOTE = IIf(Me.cbAPLICALOTE.Checked, 1, 0)
        mEntidad.ESTADOPRODUCTO = IIf(Me.cbESTADOPRODUCTO.Checked, 1, 0)

        mComponente.ActualizarCATALOGOPRODUCTOS(mEntidad)

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
        Me.gvLista.DataSource = cCP.ObtenerCatalogoProductosCompletoPorSubgrupo(IDSUBGRUPO)

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Me.gvLista.SelectedIndex = -1
        Me.plDatos.Visible = False

    End Sub

    Public Sub AgregarProducto()
        Me.IDPRODUCTO = 0
        Nuevo()
        Me.plDatos.Visible = True
        Limpiar()
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        CargarProductos()
    End Sub

    Protected Sub gvLista_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvLista.SelectedIndexChanging

        Me.IDPRODUCTO = Me.gvLista.DataKeys(e.NewSelectedIndex).Values.Item("IDPRODUCTO")

        CargarDatos(Me.IDPRODUCTO)
        Me.plDatos.Visible = True

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Actualizar()
        CargarProductos()
    End Sub

    Private Sub Limpiar()
        Me.txtCODIGO.Text = String.Empty
        Me.txtCORRELATIVO.Text = String.Empty
        Me.txtNOMBRE.Text = String.Empty
        Me.nbPRECIOACTUAL.Text = String.Empty
        Me.cbAPLICALOTE.Checked = False
        Me.cbESTADOPRODUCTO.Checked = False
        Me.txtOBSERVACION.Text = String.Empty
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Me.btnAgregar.Visible = False
        AgregarProducto()
    End Sub

End Class
