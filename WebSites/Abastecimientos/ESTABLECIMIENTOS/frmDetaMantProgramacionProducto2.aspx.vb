Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class ESTABLECIMIENTOS_frmDetaMantProgramacionProducto2
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _IDESTABLECIMIENTO As Integer
    Private mCompCatalogoProductos As New cCATALOGOPRODUCTOS

    Public Property IDPROGRAMACION() As Integer 'identificador de programacion
        Get
            Return Me._IDPROGRAMACION
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMACION = Value
            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me.ViewState.Remove("IDPROGRAMACION")
            Me.ViewState.Add("IDPROGRAMACION", Value)
        End Set
    End Property

    Public Property IDESTABLECIMIENTO() As Integer 'identificador de establecimiento
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Integer)
            Me._IDESTABLECIMIENTO = Value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/ESTABLECIMIENTOS/frmMantProgramacion2.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantProgramacion2.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantProgramacion2.aspx", False)
            End If

            'Quiero el id del tipo de establecimiento para verificar si existen productos. Si no existen, creamos su universo.
            'Verificamos el tipo de establecimiento, para ver que universo de datos asignamos

            'Session.Item("idTipoEstablecimiento") : 3 y 8 son Hospitales, 10 son Regiones
            'Session.Item("idEstablecimiento")

            'Verificamos el total de productos
            Dim cEntidad As New cPROGRAMACIONPRODUCTO
            Dim cEntidad2 As New cPROGRAMACION

            If cEntidad.numeroRegistrosEstablecimiento2(Request.QueryString("id")) = 0 Then

                'Obtenemos el detalle de la programacion de compras
                Dim cEntidadProg As New cPROGRAMACION
                Dim eEntidadProg As PROGRAMACION = cEntidadProg.obtenerProgramacionPorID(Request.QueryString("id"))

                'Creamos nuestro universo de datos para el establecimiento según su tipo
                cEntidad.agregarProgramacionProductoRegion(Request.QueryString("id"), Session.Item("idEstablecimiento"), Session.Item("idTipoEstablecimiento"), HttpContext.Current.User.Identity.Name, eEntidadProg)

                'SCMS Modificacion
                'para establecimiento 620=paraiso, se modifica CPM y Existencia desde tablas de programacion. Tambien
                ' se valida que la programacion de compra sea de productos de un programa.
                If Session.Item("idEstablecimiento") = 620 Then

                End If


            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(False)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirCancelar = True


            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            IDPROGRAMACION = lId
            IDESTABLECIMIENTO = Session.Item("idEstablecimiento")

            CargarDatos()

            Dim eEntidad As PROGRAMACION
            eEntidad = cEntidad2.obtenerProgramacionPorID(lId)


            'Panel para agregar productos
            Me.DdlCATALOGOPRODUCTOS1.DataSource = cEntidad.obtenerProgramacionProductos2(lId, Session.Item("idTipoEstablecimiento"), eEntidad.IDSUMINISTRO)
            Me.DdlCATALOGOPRODUCTOS1.DataTextField = "DESCLARGO"
            Me.DdlCATALOGOPRODUCTOS1.DataValueField = "IDPRODUCTO"
            Me.DdlCATALOGOPRODUCTOS1.DataBind()

            'Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXSuministro(1)
            Me.DdlUNIDADMEDIDAS1.Recuperar()

            Me.rdblCriterio.SelectedIndex = 0
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.TxtProducto.Text = Nothing
            Me.BtnBuscar.Visible = True
            Me.LblDescripcionCompleta.Text = Nothing

            'dim cEntidad as New bpro

            If cEntidad2.obtenerEstadoProgramacionEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO) <> 1 Then
                Me.gvLista.Enabled = False
                Me.ucBarraNavegacion1.PermitirGuardar = False
                Me.PnlAgregarProducto.Enabled = False
            End If


        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")

        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACIONPRODUCTO

        ds = mComponente.obtenerProgramacionProductosEstablecimiento(Me.IDPROGRAMACION, Me.IDESTABLECIMIENTO)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub


    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        If Me.rdblCriterio.SelectedValue = 0 Then
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.TxtProducto.Text = String.Empty
            Me.LblDescripcionCompleta.Visible = False
            Me.LblDescripcionCompleta.Text = String.Empty
            Me.BtnBuscar.Visible = True
        Else
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            BuscarProductoLista()
        End If
    End Sub

    Private Function BuscarProductoLista() As Int16
        Dim dsCatalogoProductos As Data.DataSet
        dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.DdlCATALOGOPRODUCTOS1.SelectedValue, 1)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else
            'SeleccionarLote()
            Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")

            Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
            Me.LblDescripcionCompleta.Visible = True
        End If
    End Function

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim dsCatalogoProductos As Data.DataSet
        Dim cEntidad As New cPROGRAMACIONPRODUCTO
        Dim cEntidad2 As New cPROGRAMACION
        Dim eEntidad As PROGRAMACION

        eEntidad = cEntidad2.obtenerProgramacionPorID(Me.IDPROGRAMACION)

        dsCatalogoProductos = cEntidad.obtenerCodigoProductoProgramacion(Me.IDPROGRAMACION, Me.TxtProducto.Text, Session.Item("idTipoEstablecimiento"), eEntidad.IDSUMINISTRO)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado o no esta disponible para este establecimiento", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else
            Try
                Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                'SeleccionarLote()
                Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")

                Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                Me.LblDescripcionCompleta.Visible = True
            Catch ex As Exception
                MsgBox1.ShowAlert("El código de producto no fue encontrado o no esta disponible para este establecimiento", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                Me.TxtProducto.Text = ""
                Me.TxtProducto.Focus()
            End Try

        End If
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Call borrar(sender, e)
    End Sub

    Private Sub borrar(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.rdblCriterio.SelectedIndex = 0
        Call rdblCriterio_SelectedIndexChanged(sender, e)
        Me.LblDescripcionCompleta.Visible = False
        Me.TxtProducto.Text = String.Empty
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        'Agregamos un nuevo producto a la lista en caso que no exista
        'Si existe mostramos el dialogo

        If Me.LblDescripcionCompleta.Text = "" Then
            MsgBox1.ShowAlert("La operación no puede ser realizada por que no se ha especificado ningun producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Focus()
            Exit Sub
        End If

        Dim eComponente As New PROGRAMACIONPRODUCTO
        Dim cComponente As New cPROGRAMACIONPRODUCTO

        Dim cEntidadProg As New cPROGRAMACION
        Dim eEntidadProg As PROGRAMACION = cEntidadProg.obtenerProgramacionPorID(Request.QueryString("id"))


        eComponente.IDPROGRAMACION = Me.IDPROGRAMACION
        eComponente.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
        eComponente.IDPRODUCTO = Me.DdlCATALOGOPRODUCTOS1.SelectedValue
        eComponente.FECHACORTE = eEntidadProg.FECHACORTE
        eComponente.FECHAPROYECCION = eEntidadProg.FECHAPROYECCION
        eComponente.FECHAPROGRAMACION = eEntidadProg.FECHAPROGRAMACION
        eComponente.MESESCPM = eEntidadProg.MESESCPM
        eComponente.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eComponente.AUFECHACREACION = Now
        eComponente.IDSUMINISTRO = eEntidadProg.IDSUMINISTRO

        If cComponente.agregarProgramacionProductoEstablecimiento(eComponente, Session.Item("idTipoEstablecimiento")) < 1 Then
            Me.MsgBox1.ShowAlert("Error al guardar el registro.  Verifique que el producto seleccionado no exista en la programacion.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call borrar(sender, e)

        Call CargarDatos()

    End Sub

    Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
        BuscarProductoLista()
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cComponente As New cPROGRAMACIONPRODUCTO

        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(2)
        Dim IDESTABLECIMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(3)

        If cComponente.eliminarProgramacionProductoEstablecimiento(IDPROGRAMACION, IDPRODUCTO, IDESTABLECIMIENTO) < 1 Then
            Me.MsgBox1.ShowAlert("Error al eliminar el registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call CargarDatos()

    End Sub

End Class
