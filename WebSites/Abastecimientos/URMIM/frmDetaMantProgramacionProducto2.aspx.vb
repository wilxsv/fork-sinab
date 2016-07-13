Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class URMIM_frmDetaMantProgramacionProducto2
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _ESTADO As Integer

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

    Public Property ESTADO() As Integer 'identificador de estado
        Get
            Return Me._ESTADO
        End Get
        Set(ByVal Value As Integer)
            Me._ESTADO = Value
            If Not Me.ViewState("ESTADO") Is Nothing Then Me.ViewState.Remove("ESTADO")
            Me.ViewState.Add("ESTADO", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/URMIM/frmMantProgramacion2.aspx", False)
    End Sub


    Private Function actualizar() As String

        Dim arr As New ArrayList

        For Each row As GridViewRow In gvLista.Rows

            Dim eComponente As New PROGRAMACIONPRODUCTO

            eComponente.IDPROGRAMACION = Me.gvLista.DataKeys(row.RowIndex).Values(0)
            eComponente.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values(2)
            eComponente.PRECIO = Me.gvLista.DataKeys(row.RowIndex).Values(1)

            eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eComponente.AUFECHAMODIFICACION = Now

            Dim txtAd As eWorld.UI.NumericBox

            txtAd = row.FindControl("txtPRECIO")

            If txtAd.Text <> "" Then

                If Val(txtAd.Text) <> eComponente.PRECIO Then
                    eComponente.PRECIO = Val(txtAd.Text)
                    arr.Add(eComponente)
                End If

            End If

        Next

        If arr.Count > 0 Then

            Dim cComponente As New cPROGRAMACIONPRODUCTO
            If cComponente.actualizarProgramacionProducto(arr) = -1 Then
                Return "Error al guardar el registro. Intente nuevamente"
            End If

        End If

        Return ""

    End Function

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'evento guardar
        Me.ESTADO = Me.ViewState("ESTADO")
        Dim cComponente As New cPROGRAMACION
        Dim sError As String
        sError = Me.actualizar()
        If sError <> "" Then
            Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        Else
            CargarDatos()

            Me.MsgBox1.ShowAlert("Los datos se han actualizado con éxito", "Exito", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            Me.IDPROGRAMACION = lId


            Dim cComponente As New cPROGRAMACION
            Dim eComponente As New PROGRAMACION
            eComponente = cComponente.obtenerProgramacionPorID(lId)

            Me.ESTADO = eComponente.ESTADO

            CargarDatos()

            'Panel para agregar productos

            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXSuministro(eComponente.IDSUMINISTRO)
            Me.DdlUNIDADMEDIDAS1.Recuperar()

            Me.rdblCriterio.SelectedIndex = 0
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.TxtProducto.Text = Nothing
            Me.BtnBuscar.Visible = True
            Me.txtCantidad.Text = 0
            Me.LblDescripcionCompleta.Text = Nothing

            If Me.ESTADO <> 1 Then
                Me.PnlAgregarProducto.Enabled = False
                Me.btnRpt3.Enabled = False
            End If

        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")

        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACIONPRODUCTO

        ds = mComponente.obtenerProgramacionProductos(Me.IDPROGRAMACION)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Try
            'evento guardar
            Dim sError As String
            sError = Me.actualizar()
        Catch ex As Exception

        End Try


        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim precio As Decimal
            precio = Me.gvLista.DataKeys(e.Row.RowIndex).Values(1)

            Dim txtAd As eWorld.UI.NumericBox
            Dim img As ImageButton

            txtAd = e.Row.FindControl("txtPRECIO")
            txtAd.Text = precio

            If Me.ViewState("ESTADO") <> 1 Then
                txtAd.Enabled = False
                img = e.Row.FindControl("ImageButton1")
                img.Enabled = False
            End If


        End If
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

        Me.ESTADO = Me.ViewState("ESTADO")

        Dim dsCatalogoProductos As Data.DataSet
        dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.TxtProducto.Text, 2)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado o no esta disponible para este almacén", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
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
                MsgBox1.ShowAlert("El código de producto no fue encontrado o no esta disponible para este almacén", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                Me.TxtProducto.Text = ""
                Me.TxtProducto.Focus()
            End Try

        End If
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Call borrar(sender, e)
    End Sub

    Private Sub borrar(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.ESTADO = Me.ViewState("ESTADO")

        Me.rdblCriterio.SelectedIndex = 0
        Call rdblCriterio_SelectedIndexChanged(sender, e)
        Me.LblDescripcionCompleta.Visible = False
        Me.txtCantidad.Text = 0
        Me.TxtProducto.Text = String.Empty
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        'Agregamos un nuevo producto a la lista en caso que no exista
        'Si existe mostramos el dialogo

        Me.ESTADO = Me.ViewState("ESTADO")

        If Me.LblDescripcionCompleta.Text = "" Then
            MsgBox1.ShowAlert("La operación no puede ser realizada por que no se ha especificado ningun producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Focus()
            Exit Sub
        End If

        If Me.txtCantidad.Text = "" Or Val(Me.txtCantidad.Text) < 0 Then
            MsgBox1.ShowAlert("Especifique una cantidad valida para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.txtCantidad.Focus()
            Exit Sub
        End If

        Dim eComponente As New PROGRAMACIONPRODUCTO
        Dim cComponente As New cPROGRAMACIONPRODUCTO

        eComponente.IDPROGRAMACION = Me.IDPROGRAMACION
        eComponente.IDPRODUCTO = Me.DdlCATALOGOPRODUCTOS1.SelectedValue
        eComponente.PRECIO = Me.txtCantidad.Text
        eComponente.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eComponente.AUFECHACREACION = Now

        If cComponente.agregarProgramacionProducto(eComponente) < 1 Then
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

        Me.ESTADO = Me.ViewState("ESTADO")

        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(2)

        If cComponente.eliminarProgramacionProducto(IDPROGRAMACION, IDPRODUCTO) < 1 Then
            Me.MsgBox1.ShowAlert("Error al eliminar el registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call CargarDatos()

    End Sub


    Protected Sub btnRpt1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt1.Click


        Call generarReporte(0)

    End Sub

    Private Sub generarReporte(ByVal tipo As Integer)

        Dim alerta As String
        Me.ESTADO = Me.ViewState("ESTADO")

        alerta = "/Reportes/frmRptProgramacionPrecios.aspx?idProceso=" & IDPROGRAMACION & "&tipo=" & tipo
        SINAB_Utils.Utils.MostrarVentana(alerta)

    End Sub

    Protected Sub btnRpt2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt2.Click
        Call generarReporte(1)

    End Sub

    Protected Sub btnRpt3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt3.Click

        Dim cComponente As New cPROGRAMACION
        Dim IDPROGRAMACION As Integer = Me.IDPROGRAMACION
        Dim usuario As String = HttpContext.Current.User.Identity.Name

        Dim cantidad As Integer = cComponente.obtenerTotalProductosCeros(IDPROGRAMACION)
        Dim cantidad2 As Integer = cComponente.obtenerTotalEstablecimientosProgramacion(IDPROGRAMACION)

        Me.ESTADO = Me.ViewState("ESTADO")

        If cantidad <> 0 Or cantidad2 = 0 Then
            Me.MsgBox1.ShowAlert("Error al liberar la programación. Verifique que todos los productos tengan un precio asignado y que se haya definido al menos un establecimiento para la programación.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else

            If cComponente.actualizarEstadoProgramacion(IDPROGRAMACION, 2, usuario) = -1 Then
                Me.MsgBox1.ShowAlert("Error al cambiar el estado.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub
            Else
                Me.MsgBox1.ShowAlert("Se ha cambiado exitosamente el estado de la programacion de compras.", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.btnRpt3.Enabled = False
                Me.PnlAgregarProducto.Enabled = False
                Me.btnEliminarProductos.Enabled = False

                CargarDatos()
            End If

        End If


    End Sub

    Protected Sub ButtonEst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEst.Click
        Response.Redirect("~/URMIM/frmDetaMantProgramacionEstablecimiento.aspx?id=" & Me.ViewState("IDPROGRAMACION"), False)
    End Sub

    Protected Sub btnInc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInc.Click
        Response.Redirect("~/URMIM/frmMantProgramacionInconsistencias.aspx?id=" & Me.ViewState("IDPROGRAMACION") & "&tipo=1", False)
    End Sub

    Protected Sub btnEliminarProductos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarProductos.Click

        Dim cComponente As New cPROGRAMACIONPRODUCTO

        Me.ESTADO = Me.ViewState("ESTADO")

        'Para  eliminar todos los productos del gridview
        'Dim IDPROGRAMACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)

        If cComponente.eliminarProgramacionProductoTODOS(IDPROGRAMACION) < 1 Then
            Me.MsgBox1.ShowAlert("Error al eliminar el registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Me.MsgBox1.ShowAlert("Se han eliminado exitosamente todos los productos.", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.btnRpt3.Enabled = False
            Me.btnEliminarProductos.Enabled = False
            CargarDatos()

        End If

        Call CargarDatos()


    End Sub
End Class
