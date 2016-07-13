Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils
Imports System.Linq

Partial Class ESTABLECIMIENTOS_frmDetaMantDistribucionProducto
    Inherits System.Web.UI.Page

    Private _IDDISTRIBUCION As Integer
    Private _IDALMACEN As Integer
    Private _IDSUMINISTRO As Integer
    Private _IDPROGRAMA As Integer
    Private mCompCatalogoProductos As New cCATALOGOPRODUCTOS

    Public Property IDDISTRIBUCION() As Integer 'identificador de distribución
        Get
            Return Me._IDDISTRIBUCION
        End Get
        Set(ByVal Value As Integer)
            Me._IDDISTRIBUCION = Value
            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me.ViewState.Remove("IDDISTRIBUCION")
            Me.ViewState.Add("IDDISTRIBUCION", Value)
        End Set
    End Property

    Public Property IDALMACEN() As Integer 'identificador de distribución
        Get
            Return Me._IDALMACEN
        End Get
        Set(ByVal Value As Integer)
            Me._IDALMACEN = Value
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.ViewState.Remove("IDALMACEN")
            Me.ViewState.Add("IDALMACEN", Value)
        End Set
    End Property

    Public Property IDSUMINISTRO() As Integer 'identificador de distribución
        Get
            Return Me._IDSUMINISTRO
        End Get
        Set(ByVal Value As Integer)
            Me._IDSUMINISTRO = Value
            If Not Me.ViewState("IDSUMINISTRO") Is Nothing Then Me.ViewState.Remove("IDSUMINISTRO")
            Me.ViewState.Add("IDSUMINISTRO", Value)
        End Set
    End Property
    Public Property IDPROGRAMA() As Integer 'identificador de distribución
        Get
            Return Me._IDPROGRAMA
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMA = Value
            If Not Me.ViewState("IDPROGRAMA") Is Nothing Then Me.ViewState.Remove("IDPROGRAMA")
            Me.ViewState.Add("IDPROGRAMA", Value)
        End Set
    End Property
    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = False

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            IDDISTRIBUCION = lId

            Dim eEntidad As New DISTRIBUCION
            Dim cEntidad As New cDistribucion
            Try
                eEntidad = cEntidad.obtenerDistribucionPorID(lId, Session.Item("IdEstablecimiento"))
                IDSUMINISTRO = eEntidad.IDSUMINISTRO
                IDALMACEN = eEntidad.IDALMACEN
                IDPROGRAMA = eEntidad.IDPROGRAMA


            CargarDatos()

                If eEntidad.ESTADO > 2 Then
                    Me.gvLista.Enabled = False
                    Me.PnlAgregarProducto.Enabled = False
                End If

            Catch ex As Exception
                SINAB_Utils.MessageBox.AlertSubmit("No se ha podido recuperar la Entidad, reintente cargar nuevamente esta distribución: " + ex.Message, "Error de datos")
            End Try
           
            'Panel para agregar productos

            'If IDPROGRAMA <> 0 Then
            '    Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXSuministroDistro(eEntidad.IDSUMINISTRO, eEntidad.IDALMACEN, eEntidad.IDPROGRAMA)
            '    Me.rdblCriterio.Items(2).Enabled = False
            'Else
            '    Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXSuministroDistro(eEntidad.IDSUMINISTRO, eEntidad.IDALMACEN, 0)
            '    Me.rdblCriterio.Items(2).Enabled = True
            'End If

            'Me.DdlUNIDADMEDIDAS1.Recuperar()

            'Me.rdblCriterio.SelectedIndex = 0
            'Me.DdlCATALOGOPRODUCTOS1.Visible = False
            'Me.TxtProducto.Visible = True
            'Me.TxtProducto.Text = Nothing
            'Me.BtnBuscar.Visible = True
            'Me.LblDescripcionCompleta.Text = Nothing
            'Me.lblCod.Text = ""

        Else

            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me._IDDISTRIBUCION = Me.ViewState("IDDISTRIBUCION")
            If Not Me.ViewState("IDSUMINISTRO") Is Nothing Then Me._IDSUMINISTRO = Me.ViewState("IDSUMINISTRO")
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me._IDALMACEN = Me.ViewState("IDALMACEN")

            If MessageBox.ConfirmTarget = "Error de datos" Then Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cDISTRIBUCIONPRODUCTO

        ds = mComponente.obtenerDistribucionProductos(Me.ViewState("IDDISTRIBUCION"), Session.Item("IdEstablecimiento"))

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    'Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
    '    If Me.rdblCriterio.SelectedValue = 0 Then       'Busqueda por codigo
    '        Me.DdlCATALOGOPRODUCTOS1.Visible = False
    '        Me.TxtProducto.Visible = True
    '        Me.TxtProducto.Text = String.Empty
    '        Me.LblDescripcionCompleta.Visible = False
    '        Me.LblDescripcionCompleta.Text = String.Empty
    '        Me.BtnBuscar.Visible = True
    '        Me.lblCod.Text = ""
    '    End If
    '    If Me.rdblCriterio.SelectedValue = 1 Then   'Busqueda por seleccion
    '        Me.TxtProducto.Visible = False
    '        Me.BtnBuscar.Visible = False
    '        Me.DdlCATALOGOPRODUCTOS1.Visible = True
    '        Me.LblDescripcionCompleta.Visible = False
    '        BuscarProductoLista()
    '    End If
    '    If Me.rdblCriterio.SelectedValue = 2 Then   'Busqueda por grupo terapeutico
    '        Me.TxtProducto.Visible = False
    '        Me.BtnBuscar.Visible = False
    '        Me.DdlCATALOGOPRODUCTOS1.Visible = False
    '        Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.idSuministro0.Text)
    '        Me.DdlGRUPOS1.Visible = True
    '        Me.bttgenerar.Visible = True
    '        Me.LblDescripcionCompleta.Visible = False
    '        'yo
    '        ' BuscarProductoLista()
    '    End If
    'End Sub

    'Private Function BuscarProductoLista() As Int16
    '    Dim dsCatalogoProductos As Data.DataSet
    '    dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.DdlCATALOGOPRODUCTOS1.SelectedValue, 1)

    '    If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
    '        MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
    '        Me.TxtProducto.Text = ""
    '        Me.lblCod.Text = ""
    '        Me.TxtProducto.Focus()
    '    Else
    '        'SeleccionarLote()
    '        Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
    '        Me.lblCod.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("CORRPRODUCTO")
    '        Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
    '        Me.LblDescripcionCompleta.Visible = True
    '    End If
    'End Function

    'Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
    '    Dim dsCatalogoProductos As Data.DataSet
    '    Dim cEntidad As New cDISTRIBUCIONPRODUCTO

    '    dsCatalogoProductos = cEntidad.productosSeleccionables(Me.ViewState("IDALMACEN"), Me.ViewState("IDSUMINISTRO"), Me.TxtProducto.Text, Me.ViewState("IDPROGRAMA"))

    '    If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
    '        MsgBox1.ShowAlert("El código del producto no fue encontrado o no esta disponible para este almacén", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
    '        Me.TxtProducto.Text = ""
    '        Me.lblCod.Text = ""
    '        Me.TxtProducto.Focus()
    '    Else
    '        Try
    '            Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
    '            'SeleccionarLote()
    '            Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")

    '            Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
    '            Me.LblDescripcionCompleta.Visible = True
    '            Me.lblCod.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("CORRPRODUCTO")
    '        Catch ex As Exception
    '            MsgBox1.ShowAlert("El código de producto no fue encontrado o no esta disponible para este nivel", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
    '            Me.TxtProducto.Text = ""
    '            Me.lblCod.Text = ""
    '            Me.TxtProducto.Focus()
    '        End Try

    '    End If
    'End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Call borrar(sender, e)
    End Sub

    Private Sub borrar(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.rdblCriterio.SelectedIndex = 0
        'Call rdblCriterio_SelectedIndexChanged(sender, e)
        'Me.LblDescripcionCompleta.Visible = False
        'Me.TxtProducto.Text = String.Empty
        'Me.lblCod.Text = ""
        buscador.SearchingText = ""
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        'Agregamos un nuevo producto a la lista en caso que no exista
        'Si existe mostramos el dialogo

        If buscador.ProductId = "" Then
            SINAB_Utils.MessageBox.Alert("La operación no puede ser realizada por que no se ha especificado ningun producto", "Alerta")
            'MsgBox1.ShowAlert("La operación no puede ser realizada por que no se ha especificado ningun producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            ' Me.TxtProducto.Focus()
            buscador.Focus()
            Exit Sub
        End If

        Dim usr = Membresia.ObtenerUsuario()

        Dim eComponente As New DISTRIBUCIONPRODUCTO
        Dim cComponente As New cDISTRIBUCIONPRODUCTO

        eComponente.IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO 'Session.Item("IdEstablecimiento")
        eComponente.IDDISTRIBUCION = Me.IDDISTRIBUCION
        eComponente.IDPRODUCTO = CType(buscador.ProductId, Integer) ' Me.DdlCATALOGOPRODUCTOS1.SelectedValue
        eComponente.IDALMACEN = usr.Almacen.IDALMACEN ' Me.ViewState("IDALMACEN")
        eComponente.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eComponente.AUFECHACREACION = Now
        eComponente.IDTIPOESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDTIPOESTABLECIMIENTO 'Session.Item("idTipoEstablecimiento")
        eComponente.CODPRODUCTO = buscador.ProductCorrelative

        If cComponente.agregarDistribucionProducto(eComponente) < 1 Then
            SINAB_Utils.MessageBox.Alert("Error al guardar el registro.  Verifique que el producto seleccionado no exista en la distribucion.", "Error")
            'Me.MsgBox1.ShowAlert("Error al guardar el registro.  Verifique que el producto seleccionado no exista en la distribucion.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call borrar(sender, e)

        Call CargarDatos()

    End Sub

    'Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
    '    BuscarProductoLista()
    'End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()

    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cComponente As New cDISTRIBUCIONPRODUCTO

        'al eliminar un registro del gridview
        Dim IDDISTRIBUCION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)

        If cComponente.eliminarDistribucionProducto(IDDISTRIBUCION, IDPRODUCTO, Session.Item("IdEstablecimiento")) <= 0 Then
            SINAB_Utils.MessageBox.Alert("Error al eliminar el registro.", "Error")
            ' Me.MsgBox1.ShowAlert("Error al eliminar el registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call CargarDatos()

    End Sub

    Protected Sub gvLista_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvLista.SelectedIndexChanging

        Dim eEntidad As New DISTRIBUCIONPRODUCTO
        Dim cEntidad As New cDISTRIBUCIONPRODUCTO

        eEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eEntidad.IDDISTRIBUCION = Me.ViewState("IDDISTRIBUCION")
        eEntidad.IDPRODUCTO = Me.gvLista.DataKeys(e.NewSelectedIndex).Values(1)
        eEntidad.IDALMACEN = Me.ViewState("IDALMACEN")

        Me.lblCP.Text = Me.gvLista.DataKeys(e.NewSelectedIndex).Values(1)
        Me.lblLP.Text = Me.gvLista.DataKeys(e.NewSelectedIndex).Values(2)

        'Escondemos el panel de adición y mostramos el grid de lotes y deshabilitamos el grid
        Me.PnlAgregarProducto.Visible = False
        Me.gvLista.Enabled = False

        'Mostramos los lotes
        Me.PnlSeleccionLotes.Visible = True

        Me.gvListaLotes.DataSource = cEntidad.obtenerLotesDistribucion(eEntidad)
        Me.gvListaLotes.DataBind()

    End Sub

    Protected Sub gvListaLotes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvListaLotes.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim chk As CheckBox

            chk = e.Row.FindControl("chkLotes")

            If Me.gvListaLotes.DataKeys(e.Row.RowIndex).Values(3) = 1 AndAlso (Not Me.gvListaLotes.DataKeys(e.Row.RowIndex).Values(4) = 0) Then
                chk.Checked = True
            Else
                With chk
                    .Checked = False
                    .Visible = False
                End With
            End If

        End If

    End Sub

    Protected Sub btnGL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGL.Click

        Dim eEntidad As New DISTRIBUCIONPRODUCTO
        Dim cEntidad As New cDISTRIBUCIONPRODUCTO

        Dim arr As New ArrayList

        eEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eEntidad.IDDISTRIBUCION = Me.ViewState("IDDISTRIBUCION")
        eEntidad.IDALMACEN = Me.ViewState("IDALMACEN")
        eEntidad.IDPRODUCTO = Me.lblCP.Text
        eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name

        For Each row As GridViewRow In Me.gvListaLotes.Rows

            Dim chk As CheckBox

            chk = row.FindControl("chkLotes")

            If chk.Checked Then
                arr.Add(Me.gvListaLotes.DataKeys(row.RowIndex).Values(2))
            End If

        Next

        If cEntidad.actualizarLotes(eEntidad, arr) = -1 Then
            SINAB_Utils.MessageBox.Alert("Error al actualizar los lotes.", "Error")
            'Me.MsgBox1.ShowAlert("Error al actualizar los lotes.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call btnCL_Click(sender, e)

    End Sub

    Protected Sub btnCL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCL.Click
        Me.lblCP.Text = ""
        Me.lblLP.Text = ""


        Me.PnlAgregarProducto.Visible = True
        Me.gvLista.Enabled = True

        'Mostramos los lotes
        Me.PnlSeleccionLotes.Visible = False

        Me.gvLista.SelectedIndex = -1

        Dim inde As Integer = Me.gvLista.PageIndex

        Me.gvListaLotes.PageIndex = inde
        Call CargarDatos()

    End Sub

    Private mCompProductos As New cCATALOGOPRODUCTOS
    Private mEntProductos As New CATALOGOPRODUCTOS

    'Protected Sub btnBus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBus.Click
    '    'EVENTO AL PRESIONAR BUSCAR UN PRODUCTO
    '    Me.rdblCriterio.ClearSelection()
    '    Dim dsCatalogoProductos As Data.DataSet

    '    'Dim dsProductosNecesidad As DataSet
    '    'dsProductosNecesidad = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)

    '    'VERIFICACION SI EL PRODUCTO YA ESTA EN EL CALCULO DE NECESIDADES
    '    'If dsProductosNecesidad.Tables(0).Rows.Count > 0 Then
    '    '    MsgBox1.ShowAlert("Este producto ya fu ingresado al programa de compras", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '    '    Me.TxtProducto.Text = ""
    '    '    Me.lblproducto.Text = ""
    '    '    Me.LblDescripcionCompleta.Text = ""
    '    '    Me.TxtProducto.Focus()
    '    'Else
    '    If Me.btnBus.Text = "Buscar" Then  ' AL PRESIONAR ACEPTAR UN PRODUCTO
    '        Me.TxtProducto.Text = Me.DdlCATALOGOPRODUCTOS1.SelectedValue
    '        If Me.idSuministro0.Text = "1" Then
    '            dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(Me.TxtProducto.Text, Session.Item("IdEstablecimiento"), Me.idSuministro0.Text)
    '        Else
    '            dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoXSuministro(Me.TxtProducto.Text, Me.idSuministro0.Text)
    '        End If

    '        'dsProductosNecesidad = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)
    '        'If dsProductosNecesidad.Tables(0).Rows.Count > 0 Then
    '        '    MsgBox1.ShowAlert("Este producto ya fue ingresado al programa de compras", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        '    Me.TxtProducto.Text = ""
    '        '    Me.lblproducto.Text = ""
    '        '    Me.LblDescripcionCompleta.Text = ""
    '        '    LblDescripcionCompleta.Focus()
    '        'Else
    '        'If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
    '        '    MsgBox1.ShowAlert("El código del producto es incorrecto o no existe", "C", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        '    Me.TxtProducto.Text = ""
    '        '    Me.lblproducto.Text = ""
    '        '    Me.LblDescripcionCompleta.Text = ""
    '        '    Me.TxtProducto.Focus()
    '        'Else
    '        '    Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
    '        '    Me.LblUnidad.Text = Me.DdlUNIDADMEDIDAS1.SelectedItem.Text
    '        '    Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("CORRPRODUCTO")
    '        '    Me.lblproducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
    '        '    Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
    '        '    Me.LblDescripcionCompleta.Visible = True
    '        '    Me.LblPrecio.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
    '        'End If
    '    End If
    '    'Else  ' AL PRESIONAR BUSCAR UN PRODUCTO
    '    If Me.idSuministro0.Text = "1" Then
    '        dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(Me.TxtProducto.Text, Session.Item("IdEstablecimiento"), Me.idSuministro0.Text)
    '    Else
    '        dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoXSuministro(Me.TxtProducto.Text, Me.idSuministro0.Text)
    '    End If
    '    'dsProductosNecesidad = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)
    '    'If dsProductosNecesidad.Tables(0).Rows.Count > 0 Then
    '    'MsgBox1.ShowAlert("Este producto ya fue ingresado al programa de compras", "D", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '    'Me.TxtProducto.Text = ""
    '    'Me.lblproducto.Text = ""
    '    'Me.LblDescripcionCompleta.Text = ""
    '    'LblDescripcionCompleta.Focus()
    '    'Else
    '    '    If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
    '    '        MsgBox1.ShowAlert("El código del producto es incorrecto o no existe", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '    '        Me.TxtProducto.Text = ""
    '    '        Me.lblproducto.Text = ""
    '    '        Me.LblDescripcionCompleta.Text = ""
    '    '        Me.TxtProducto.Focus()
    '    '    Else
    '    '        Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
    '    '        Me.LblUnidad.Text = Me.DdlUNIDADMEDIDAS1.SelectedItem.Text
    '    '        Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("CORRPRODUCTO")
    '    '        Me.lblproducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
    '    '        Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
    '    '        Me.LblDescripcionCompleta.Visible = True
    '    '        Me.LblPrecio.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
    '    '    End If
    '    'End If

    '    'End If

    '    'End If

    '    'End Sub

    'End Sub
End Class
