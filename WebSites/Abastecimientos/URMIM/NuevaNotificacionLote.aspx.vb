Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports SINAB_Entidades.Tipos
Imports SINAB_Utils

Partial Class URMIM_NuevaNotificacionLote
    Inherits System.Web.UI.Page

    Protected Property IdEstablecimiento As Integer
        Get
            Return CType(ViewState("ides"), Integer)
        End Get
        Set(value As Integer)
            ViewState("ides") = value
        End Set
    End Property

    Protected Property IdProcesocompra As Integer
        Get
            Return CType(ViewState("idpc"), Integer)
        End Get
        Set(value As Integer)
            ViewState("idpc") = value
        End Set
    End Property

    Protected Property IdProveedor As Integer
        Get
            Return CType(ViewState("idprv"), Integer)
        End Get
        Set(value As Integer)
            ViewState("idprv") = value
        End Set
    End Property

    Protected Property IdContrato As Integer
        Get
            Return CType(ViewState("idct"), Integer)
        End Get
        Set(value As Integer)
            ViewState("idct") = value
        End Set
    End Property

    Protected Property Producto() As BaseProductos
        Get
            Return CType(ViewState("re"), BaseProductos)
        End Get
        Set(value As BaseProductos)
            ViewState("re") = value
        End Set
    End Property

    Protected Property Grupo As Integer
        Get
            Return CType(ViewState("nono"), Integer)
        End Get
        Set(value As Integer)
            ViewState("nono") = value
        End Set
    End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            ProcesoCompras.CargarAdjudicadosALista(ddlProcesos)
            ddlProcesos.Items.Insert(0, New ListItem("", String.Empty))
            For Each itm As ListItem In ddlProcesos.Items
                itm.Attributes.Add("title", itm.Text)
            Next
            ddlProcesos.Attributes.Add("onmouseover", "this.title=this.options[this.selectedIndex].title")

        Else
            If MessageBox.ConfirmTarget = "Guardado" Then
                LimpiarSeguir()

            End If
        End If
    End Sub

    Private Sub LimpiarSeguir()

        Response.Redirect("~/URMIM/NotificacionLotes.aspx", True)

    End Sub

    Private Sub LimpiarRegistroNotificacion()
        CargarNumeracion()
        gvLotes.SelectedIndex = -1
        gvLotes.DataSource = Notificaciones.ObtenerTodos(IdProveedor, IdProcesocompra, IdEstablecimiento, IdContrato, 1)
        gvLotes.DataBind()

        CargarDatosRenglones()
    End Sub

    Protected Sub ddlProcesos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProcesos.SelectedIndexChanged
        If Not String.IsNullOrEmpty(ddlProcesos.SelectedValue) Then
            Dim ids = ddlProcesos.SelectedValue.Split(CType(",", Char))
            IdEstablecimiento = CType(ids(0), Integer)
            IdProcesocompra = CType(ids(1), Integer)
            pnlProveedores.Visible = True
            Adjudicacion.CargarProveedoresAdjudicadosALista(IdEstablecimiento, IdProcesocompra, ddlProveedores)
            ddlProveedores.Items.Insert(0, New ListItem("", String.Empty))
        Else
            IdProcesocompra = 0
            IdProveedor = 0
            pnlProveedores.Visible = False
        End If
    End Sub

    Protected Sub ddlProveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProveedores.SelectedIndexChanged
        If Not String.IsNullOrEmpty(ddlProveedores.SelectedValue) Then
            Dim ids = ddlProveedores.SelectedValue.Split(CType(",", Char))
            IdProveedor = CType(ids(0), Integer)
            IdContrato = CType(ids(1), Integer)
            pnlForm.Visible = True
            CargarDatos()
        Else
            IdProveedor = 0
            IdContrato = 0
            pnlForm.Visible = False

        End If

    End Sub

    Private Sub CargarDatos()
        Dim titulos = ddlProveedores.SelectedItem.Text.Split(CType("|", Char()))
        ltContrato.Text = titulos(1).TrimStart()
        Grupo = Notificaciones.ObtenerMaxGrupo(IdEstablecimiento, IdProveedor, IdContrato, IdProcesocompra)
        CargarNumeracion()
        Try
            gvLotes.DataSource = Notificaciones.ObtenerTodos(IdProveedor, IdProcesocompra, IdEstablecimiento, IdContrato, 1)
        gvLotes.DataBind()
        Catch ex As Exception
            MessageBox.Alert("Error: " + ex.Message)
        End Try
        

        CargarDatosRenglones()
    End Sub

    Private Sub CargarNumeracion()
        Dim nunot = Notificaciones.ObtenerCountNotificacion(IdProveedor, IdProcesocompra, IdEstablecimiento, IdContrato, 1).ToString()

        If nunot > 1 Then
            ltPreNotificacion.Text = " Notificaciones"
        Else
            If nunot = 0 Then
                ltPreNotificacion.Text = ": No hay notificaciones"

            Else
                ltPreNotificacion.Text = " Notificación"
            End If
        End If
        ltNotificacion.Text = nunot.ToString()
    End Sub

    Private Sub CargarDatosRenglones()

        RenglonesAdjudicados.CargarALista(IdProveedor, IdEstablecimiento, IdProcesocompra, IdContrato, ddlRenglones)
        ddlRenglones.Items.Insert(0, New ListItem("", String.Empty))
        pnlNuevaNotifiacion.Visible = False
        pnlRenglones.Visible = True
    End Sub

    Protected Sub ddlRenglones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRenglones.SelectedIndexChanged
        If Not String.IsNullOrEmpty(ddlRenglones.SelectedValue) Then
            Producto = RenglonesAdjudicados.Obtener(IdProveedor, IdEstablecimiento, IdProcesocompra, IdContrato, CType(ddlRenglones.SelectedValue, Decimal))
            pnlNuevaNotifiacion.Visible = True
            nnForm.NombreComercial = Producto.DescripcionProveedor
            nnForm.LaboraTorioFabricante = Producto.CasaRepresentada
            nnForm.Limpiar()
        Else
            pnlNuevaNotifiacion.Visible = False
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        If nnForm.FechaFabricacion > nnForm.FechaVencimiento Then
            MessageBox.Alert("La fecha de Fabricación debe ser mayor que la fecha de Vencimiento")

        Else

            Dim im As New SAB_LAB_INFORMEMUESTRAS With {
      .IDESTABLECIMIENTO = IdEstablecimiento,
      .IDPROCESOCOMPRA = IdProcesocompra,
      .IDINFORME = nnForm.IdNotificacion,
      .IDTIPOINFORME = CType(EnumHelpers.TipoInformes.Aceptacion, Short),
      .IDESTADO = EnumHelpers.EstadoNotificacion.Creada,
      .IDESTABLECIMIENTOCONTRATO = IdEstablecimiento,
      .IDPROVEEDOR = IdProveedor,
      .IDCONTRATO = IdContrato,
      .IDPRODUCTO = Producto.IdProducto,
      .RENGLON = CType(Producto.Renglon, Integer),
      .PROVEEDOR = Proveedores.Obtener(IdProveedor).NOMBRE,
      .NOMBREMEDICAMENTO = Producto.DescLargo,
      .NOMBRECOMERCIAL = nnForm.NombreComercial,
      .LABORATORIOFABRICANTE = nnForm.LaboraTorioFabricante,
      .LOTE = nnForm.Lote,
      .NUMEROUNIDADES = nnForm.LoteSize,
      .CANTIDADAENTREGAR = nnForm.Cantidad,
      .FECHANOTIFICACION = nnForm.FechaNotificacion,
      .AUUSUARIOCREACION = Membresia.ObtenerUsuario().NombreUsuario,
      .AUFECHACREACION = DateTime.Now,
      .NUMERONOTIFICACION = Grupo}

            If Not IsNothing(nnForm.FechaFabricacion) Then
                Dim dff = CType(nnForm.FechaFabricacion, Date)
                im.FECHAFABRICACION = New DateTime(dff.Year, dff.Month, DateTime.DaysInMonth(dff.Year, dff.Month))
            End If

            If Not IsNothing(nnForm.FechaVencimiento) Then
                Dim dfv = CType(nnForm.FechaVencimiento, Date)
                im.FECHAVENCIMIENTO = New DateTime(dfv.Year, dfv.Month, DateTime.DaysInMonth(dfv.Year, dfv.Month))
            End If

            Try

                Using db As New SinabEntities
                    If Not IsNothing(im.IDINFORME) And im.IDINFORME > 0 Then
                        Notificaciones.ActualizarPaso1(db, im)
                    Else
                        im.IDINFORME = Notificaciones.ObtenerMaxNotificcion(IdEstablecimiento)
                        Notificaciones.Agregar(db, im)
                    End If

                    Dim historico As New SAB_LAB_HISTORICONOTIFICACION With {
                        .IDESTABLECIMIENTO = im.IDESTABLECIMIENTO,
                        .IDINFORME = im.IDINFORME,
                        .NOMBRECOMERCIAL = im.NOMBRECOMERCIAL,
                        .LABORATORIOFABRICANTE = im.LABORATORIOFABRICANTE,
                        .LOTE = im.LOTE,
                        .NUMEROUNIDADES = im.NUMEROUNIDADES,
                        .FECHAFABRICACION = im.FECHAFABRICACION,
                        .FECHAVENCIMIENTO = im.FECHAVENCIMIENTO,
                        .CANTIDADAENTREGAR = im.CANTIDADAENTREGAR}
                    HistoricoNotificacion.Agregar(db, historico)
                    LimpiarRegistroNotificacion()
                    MessageBox.Confirm("La notificación se ha guardado exitosamente. ¿Desea registrar otro renglón?", "Guardado", MessageBox.OptionPostBack.NotPostBack)

                End Using

            Catch ex As Exception
                MessageBox.Alert("Error al guardar notificación. Error: " + ex.Message)
            End Try

        End If

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CargarDatosRenglones()
        gvLotes.SelectedIndex = -1
    End Sub


    Protected Sub gvLotes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvLotes.SelectedIndexChanged
        Dim row = gvLotes.SelectedRow
        Dim idInforme = gvLotes.DataKeys(row.RowIndex).Values(0)
        Dim idProducto = gvLotes.DataKeys(row.RowIndex).Values(2)

        ddlRenglones.SelectedValue = idProducto.ToString()
        pnlNuevaNotifiacion.Visible = True
        Dim notificacion = Notificaciones.Obtener(CType(idInforme, Integer), IdEstablecimiento)
        nnForm.CargarDatos(notificacion)
    End Sub

    Protected Sub gvLotes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvLotes.RowDeleting
        Dim idInforme = CType(gvLotes.DataKeys(e.RowIndex).Values(0), Integer)
        Try
            Notificaciones.Borrar(IdEstablecimiento, idInforme)
            LimpiarRegistroNotificacion()
            MessageBox.Alert("El registro se ha borrado exitosamente")
        Catch ex As Exception
            MessageBox.Alert("Error: " + ex.Message)
        End Try

    End Sub
End Class
