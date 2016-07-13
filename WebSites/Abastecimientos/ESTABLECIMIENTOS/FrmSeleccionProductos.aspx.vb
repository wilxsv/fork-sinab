Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils.MessageBox

Partial Class ESTABLECIMIENTOS_FrmSeleccionProductos
    Inherits System.Web.UI.Page

    Private mCompCatalogoProductos As New cCATALOGOPRODUCTOS

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

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


            CargarDatos()

            'Panel para agregar productos
            'Me.DdlCATALOGOPRODUCTOS1.DataSource = cEntidad.obtenerProgramacionProductos2(lId, Session.Item("idTipoEstablecimiento"))
            'Me.DdlCATALOGOPRODUCTOS1.DataTextField = "DESCLARGO"
            'Me.DdlCATALOGOPRODUCTOS1.DataValueField = "IDPRODUCTO"
            'Me.DdlCATALOGOPRODUCTOS1.DataBind()

            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXSuministro(1)
            Me.DdlUNIDADMEDIDAS1.Recuperar()

            Me.rdblCriterio.SelectedIndex = 0
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.TxtProducto.Text = Nothing
            Me.BtnBuscar.Visible = True
            Me.LblDescripcionCompleta.Text = Nothing

            'dim cEntidad as New bpro

            'If cEntidad2.obtenerEstadoProgramacionEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO) <> 1 Then
            '    Me.gvLista.Enabled = False
            '    Me.ucBarraNavegacion1.PermitirGuardar = False
            '    Me.PnlAgregarProducto.Enabled = False
            'End If

        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim bEntidad As New cPRODUCTOSESTABLECIMIENTOS
        Me.gvLista.DataSource = bEntidad.obtenerListaProductosEstablecimientos(Session.Item("idEstablecimiento"))
        Me.gvLista.DataBind()

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
            Alert("El código del producto no fue encontrado")
            ' MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
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
        Dim cEntidad As New cPRODUCTOSESTABLECIMIENTOS
        dsCatalogoProductos = cEntidad.obtenerCodigoProductoEstablecimiento(Me.TxtProducto.Text)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            Alert("El código del producto no fue encontrado.")
            'MsgBox1.ShowAlert("El código del producto no fue encontrado.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
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
                Alert("El código de producto no fue encontrado o no esta disponible para este establecimiento")
                'MsgBox1.ShowAlert("El código de producto no fue encontrado o no esta disponible para este establecimiento", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                Me.TxtProducto.Text = ""
                Me.TxtProducto.Focus()
            End Try

        End If
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Call borrar(sender, e)
    End Sub

    Private Sub Borrar(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.rdblCriterio.SelectedIndex = 0
        Call rdblCriterio_SelectedIndexChanged(sender, e)
        Me.LblDescripcionCompleta.Visible = False
        Me.TxtProducto.Text = String.Empty
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        'Agregamos un nuevo producto a la lista en caso que no exista
        'Si existe mostramos el dialogo

        If Me.LblDescripcionCompleta.Text = "" Then
            Alert("La operación no puede ser realizada por que no se ha especificado ningun producto")
            'MsgBox1.ShowAlert("La operación no puede ser realizada por que no se ha especificado ningun producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Focus()
            Exit Sub
        End If


        'chequear si existe registro de consumos del mes anterior
        Dim mComponente As New cCONSUMOS
        Dim x As New cALMACENESESTABLECIMIENTOS
        Dim idalmacen As Integer
        idalmacen = x.BuscarAlmacenFarmacia(Session.Item("IdEstablecimiento"))
        If mComponente.ChequearCYEMEsAnterior(Session.Item("IdEstablecimiento"), idalmacen, Date.Now.Year & "/" & Date.Now.Month & "/01", 0) = 0 Then
            'no hay datos de consumos mes anterior, no se puede continuar
            Alert("Para adicionar un producto al establecimiento, se deberá tener ingresado los registros de consumo y existencias del mes anterior.", "Error")
            Exit Sub
        Else
            Dim cComponente As New cPRODUCTOSESTABLECIMIENTOS

            If cComponente.agregarProductoEstablecimiento(Session.Item("idEstablecimiento"), Me.DdlCATALOGOPRODUCTOS1.SelectedValue) < 1 Then
                Alert("Error al guardar el registro.  Verifique que el producto seleccionado no exista en el listado.")
                'Me.MsgBox1.ShowAlert("Error al guardar el registro.  Verifique que el producto seleccionado no exista en el listado.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub
            Else
                'si hay datos de consumos del mes anterior, por lo que se insertará un registro con el nuevo producto.
                Dim cconsumos As New cCONSUMOS
                cconsumos.IngresarConsumoExistenciaCero(Session.Item("idEstablecimiento"), idalmacen, Me.DdlCATALOGOPRODUCTOS1.SelectedValue, Date.Now)
            End If
        End If

        
        Call Borrar(sender, e)

        Call CargarDatos()

    End Sub

    Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
        BuscarProductoLista()
    End Sub

    Protected Sub gvLista_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles gvLista.RowDeleted

    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cComponente As New cPRODUCTOSESTABLECIMIENTOS

        'al eliminar un registro del gridview
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDESTABLECIMIENTO As Integer = Session.Item("idEstablecimiento")

        If cComponente.quitarPRODUCTOSESTABLECIMIENTOS(IDESTABLECIMIENTO, IDPRODUCTO) < 1 Then
            Alert("Error al eliminar el registro.")
            'Me.MsgBox1.ShowAlert("Error al eliminar el registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call CargarDatos()

    End Sub






    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    Me.Master.ControlMenu.Visible = False 'ocultar menu
    '    'Form the script that is to be registered at client side.
    '    'Dim scriptString As String = "<link rel='stylesheet' type='text/css' media='screen' href='../css/themes/basic/grid.css' />"
    '    'ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "css1", scriptString)
    '    'scriptString = "<link rel='stylesheet' type='text/css' media='screen' href='../css/themes/jqModal.css' />"
    '    'ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "css2", scriptString)
    '    'scriptString = "<link rel='Stylesheet' type='text/css' href='../css/smoothness/jquery-ui-1.7.2.custom.css' />"
    '    'ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "css3", scriptString)



    'End Sub

    Protected Sub btnAlmacen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlmacen.Click
        GenerarHoja(0)
    End Sub

    Protected Sub btnFarmacia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFarmacia.Click
        GenerarHoja(1)
    End Sub

    Private Sub GenerarHoja(ByVal tipo As Integer)

        Dim alerta As String = "/Reportes/frmRptProductosConsumo.aspx?tipo=" & tipo
        SINAB_Utils.Utils.MostrarVentana(alerta)

    End Sub

End Class
