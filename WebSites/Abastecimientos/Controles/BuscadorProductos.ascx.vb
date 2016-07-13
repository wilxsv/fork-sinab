Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades

Imports SINAB_Utils
Imports SINAB_Utils.MessageBox

Imports SINAB_Entidades.Helpers.UACIHelpers
Imports System.Linq

Partial Class Controles_BuscadorProductos
    Inherits System.Web.UI.UserControl

#Region "PROPIEDADES PRIVADAS"


    Dim _total As Decimal = 0
#End Region

#Region "PROPIEDADES PUBLICAS"
    Public Property Base() As SAB_UACI_CONTRATOS
        Get
            Return CType(Session("BaseContrato"), SAB_UACI_CONTRATOS)
        End Get
        Set(value As SAB_UACI_CONTRATOS)
            Session("BaseContrato") = value
        End Set
    End Property

    Public Property Producto() As vv_CATALOGOPRODUCTOS
        Get
            Return CType(ViewState("seAgrega"), vv_CATALOGOPRODUCTOS)
        End Get
        Protected Set(ByVal value As vv_CATALOGOPRODUCTOS)
            ViewState("seAgrega") = value
        End Set

    End Property



    Public ReadOnly Property ConteoProductos() As Integer
        Get
            Return gvLista.Rows.Count
        End Get
    End Property

    Public ReadOnly Property Renglon() As Long
        Get
            Return CType(txtRenglon.Text, Long)
        End Get
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mvProductos.ActiveViewIndex = 0
            Me.ddlUNIDADMEDIDAS1.Recuperar()
            mvDetalleProducto.ActiveViewIndex = 0
            mvMainProducto.ActiveViewIndex = 0
        End If
    End Sub

    Public Sub CargarDatos()
        If IsNothing(Base) Then Response.Redirect("~/ALMACEN/FrmMantIngresoComprasNoUACI.aspx")

        gvLista.DataSource = UACIHelpers.ProductosContrato.Obtener(Base)
        gvLista.DataBind()

    End Sub

    Public Sub Limpiar()
        txtRenglon.Text = String.Empty
        txtDescripcion.Text = String.Empty
        nbCantidad.Text = String.Empty
        nbPrecioUnitario.Text = String.Empty
        nbNumeroEntregas.Text = 1
    End Sub

    Public Sub AgregarProducto()
        txtRenglon.Text = String.Empty
        LblCodigo.Visible = True
        plProducto.Visible = False
        Limpiar()
    End Sub

    Public Sub PrepararDatos()
        'DdlCATALOGOPRODUCTOS1.RecuperarListaXSubgrupo2(Me.ddlSUBGRUPOS1.SelectedValue)
        Limpiar()

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            _total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(5).Text = "Total:"
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).Text = _total.ToString("c4")
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
        End If

    End Sub


    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        'Procedimiento para eliminar una fila del detalle de la compra no UACI.

        Dim reng = CType(gvLista.DataKeys(e.RowIndex).Values.Item("RENGLON"), Long)
        Try
            If ProductosContrato.ExisteProducto(Base, reng) Then
                ProductosContrato.EliminarProducto(Base, reng)
                CargarDatos()
            Else
                Alert("Información insuficiente para poder eliminar este producto, favor consultar con el departamento de soporte técnico")
            End If
        Catch ex As Exception
            Alert("Ocurrió un error al tratar de eliminar un producto, consulte al departamento técnico. Error: " + ex.Message)
        End Try

    End Sub


    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If txtRenglon.Text.Trim = String.Empty Or Integer.Parse(Me.txtRenglon.Text.Trim) = 0 Then

            Alert("El número de renglón es obligatorio.")
            txtRenglon.Focus()
            Exit Sub
        End If

        If lblDescripcionCompleta2.Text = String.Empty Then
            Alert("La operación no puede ser realizada por que no se ha especificado ningun producto.")
            ' txtProducto.Focus()
            Exit Sub
        End If

        If nbCantidad.Text.Trim = String.Empty Or Decimal.Parse(Me.nbCantidad.Text.Trim) = 0 Then
            Alert("Especifique una cantidad valida para continuar.")
            nbCantidad.Focus()
            Exit Sub
        End If

        If nbPrecioUnitario.Text = String.Empty Then
            Alert("El precio debe ser mayor a cero.")
            nbPrecioUnitario.Focus()
            Exit Sub
        End If

        If nbNumeroEntregas.Text = String.Empty Or Val(Me.nbNumeroEntregas.Text) = 0 Then
            Alert("El número de entregas debe ser mayor a cero.")
            nbNumeroEntregas.Focus()
            Exit Sub
        End If

        Dim productoContrato As New SAB_UACI_PRODUCTOSCONTRATO
        With productoContrato
            .IDESTABLECIMIENTO = Base.IDESTABLECIMIENTO
            .IDPROVEEDOR = Base.IDPROVEEDOR
            .IDCONTRATO = Base.IDCONTRATO
            .RENGLON = Integer.Parse(txtRenglon.Text.Trim)
            .IDPRODUCTO = Producto.IDPRODUCTO
            .IDUNIDADMEDIDA = CType(ddlUNIDADMEDIDAS1.SelectedValue, Integer)
            .CANTIDAD = CType(nbCantidad.Text, Decimal)
            .PRECIOUNITARIO = CType(nbPrecioUnitario.Text, Decimal)
            .ESTAHABILITADO = 1
            .DESCRIPCIONPROVEEDOR = txtDescripcion.Text
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = Now()
            .IDALMACENENTREGA = CType(ddlAlmacenesEntrega.SelectedValue, Integer?)
        End With


        'Validamos la utilizacion del número del renglon
        If UACIHelpers.ProductosContrato.ExisteRenglon(productoContrato) Then 'cPC.ValidarRenglonNoUaci(ePC) > 0 Then
            Alert("El número de renglón ya ha sido utilizado, indique otro para poder continuar con la operación.")
            Exit Sub
        End If

        'Validamos si el producto ya fue agregado al detalle
        If UACIHelpers.ProductosContrato.ExisteProducto(productoContrato) Then 'cPC.ValidarProductoNoUaci(ePC) > 0 Then
            Alert("El producto seleccionado ya fue agregado al detalle de productos, seleccione otro para continuar con la operación, o elimine la definición actual para poder reemplazarla.")
            Exit Sub
        End If

        'Invocamos el metodo de actualizacion de datos
        Try
            UACIHelpers.ProductosContrato.AgregarProducto(productoContrato)
        Catch ex As Exception
            Alert("Error al agregar producto al contrato, por favor contate con el área de soporte. Error: " + ex.Message)
            Exit Sub
        End Try
        'cPC.AgregarPRODUCTOSCONTRATO(ePC)

        CargarDatos()
        'muestra las entregas
        mvDetalleProducto.ActiveViewIndex = 1

        CargarEntregas()


    End Sub
    Protected Sub CargarEntregas()


        Try
            For i = 1 To Val(nbNumeroEntregas.Text)
                Dim entregaProducto As New SAB_UACI_ENTREGACONTRATO

                With entregaProducto
                    .IDESTABLECIMIENTO = Base.IDESTABLECIMIENTO
                    .IDPROVEEDOR = Base.IDPROVEEDOR
                    .IDCONTRATO = Base.IDCONTRATO
                    .RENGLON = CType(txtRenglon.Text, Long)
                    .FECHACONTEO = 1
                    .ESTAHABILITADA = 1
                    .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    .AUFECHACREACION = Now()
                    .IDDETALLE = 0
                    .ENTREGA = i


                    If Val(nbNumeroEntregas.Text) = 1 Then
                        .PLAZOENTREGA = 30
                        .PORCENTAJEENTREGA = 100
                    End If
                End With

                EntregasContrato.GuardarEntrega(entregaProducto)
            Next
        Catch ex As Exception
            Alert("Error al guardar entregas de producto, póngase en contácto con el área técnica. Error: " + ex.Message)
        End Try

        gvEntregas.DataSource = EntregasContrato.Obtener(Base, CType(txtRenglon.Text, Long))
        gvEntregas.DataBind()
        gvEntregas.Focus()
    End Sub

    Protected Sub btnGuardarEntregas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarEntregas.Click
        Dim usr = Membresia.ObtenerUsuario()
        Select Case ValidarEntregas()
            Case Is = 0

                For i As Int16 = 0 To gvEntregas.Rows.Count - 1
                    Dim entregaProducto As New SAB_UACI_ENTREGACONTRATO
                    With entregaProducto
                        .IDESTABLECIMIENTO = Base.IDESTABLECIMIENTO
                        .IDPROVEEDOR = Base.IDPROVEEDOR
                        .IDCONTRATO = Base.IDCONTRATO
                        .RENGLON = Renglon
                        .IDDETALLE = CType(gvEntregas.Rows(i).Cells(0).Text, Long)
                    End With

                    entregaProducto = EntregasContrato.ObtenerEntrega(entregaProducto)
                    With entregaProducto
                        .PLAZOENTREGA = CType(CType(gvEntregas.Rows(i).FindControl("TxtPlazo"), TextBox).Text, Short)
                        .PORCENTAJEENTREGA = CType(CType(gvEntregas.Rows(i).FindControl("TxtPorcentaje"), TextBox).Text, Decimal)
                        .AUUSUARIOMODIFICACION = usr.NombreUsuario
                        .AUFECHAMODIFICACION = Now()
                    End With

                    EntregasContrato.GuardarEntrega(entregaProducto)

                    'cEC.ActualizarENTREGACONTRATO(eEC)
                Next

                plProducto.Visible = False

                AgregarProducto()
                ResetSeleccionarProducto()
                mvProductos.ActiveViewIndex = 0
                mvMainProducto.ActiveViewIndex = 0

                Alert("Las entregas fueron almacenadas satisfactoriamente.")
            Case Is = 1
                Alert("Debe respetar la serie de los dias en los plazos de entrega")
            Case Is = 2
                Alert("La suma de los porcentajes debe ser igual a 100")
            Case Is = 3
                Alert("Cero no es un valor valido para utilizar en los porcentajes de entrega")
        End Select

    End Sub

    Private Function ValidarEntregas() As Int16

        Dim iRegistro As Integer = 0
        Dim iValorActual As Integer = 0
        Dim iValorPorcentaje As Decimal = 0
        Dim iTotalPorcentaje As Decimal = 0


        Dim entregas As Integer = Me.gvEntregas.Rows.Count

        iValorActual = CType(Val(CType(Me.gvEntregas.Rows(0).FindControl("TxtPlazo"), TextBox).Text), Integer)

        For iRegistro = 1 To entregas - 1
            If Val(CType(Me.gvEntregas.Rows(iRegistro).FindControl("TxtPlazo"), TextBox).Text) <= iValorActual Then
                Return 1
            Else
                iValorActual = CType(Val(CType(Me.gvEntregas.Rows(iRegistro).FindControl("TxtPlazo"), TextBox).Text), Integer)
            End If
        Next

        For iRegistro = 0 To entregas - 1
            iValorPorcentaje = CType(Val(CType(Me.gvEntregas.Rows(iRegistro).FindControl("TxtPorcentaje"), TextBox).Text), Decimal)

            If iValorPorcentaje = 0 Then
                Return 3
            End If
            iTotalPorcentaje = iTotalPorcentaje + iValorPorcentaje
        Next

        If iTotalPorcentaje <> 100 Then
            Return 2
        Else
            Return 0
        End If

    End Function


    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        If rdblCriterio.SelectedValue = 0 Then
            mvProductos.ActiveViewIndex = 0
        Else
            Suministros.CargarAListavv(ddlSUMINISTROS1)
            mvProductos.ActiveViewIndex = 1
        End If
        ResetSeleccionarProducto()
    End Sub

    Private Sub ResetSeleccionarProducto()
        tbProductos.Text = String.Empty
        If ddlSUMINISTROS1.Items.Count > 0 Then
            ddlSUMINISTROS1.SelectedIndex = 0
        End If

        ResetList(ddlGRUPOS1)
        ResetList(ddlSUBGRUPOS1)
        ResetList(DdlCATALOGOPRODUCTOS1)
        plProducto.Visible = False
    End Sub

    Private Sub ResetList(list As DropDownList)
        list.Items.Clear()
        list.Enabled = False
    End Sub

#Region "BUSQUEDA POR SELECCION"

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        ddlGRUPOS1.Items.Clear()
        If ddlSUMINISTROS1.SelectedIndex <> 0 Then
            Suministros.CargarGruposALista(CType(ddlSUMINISTROS1.SelectedValue, Integer), ddlGRUPOS1)
            ddlGRUPOS1.Enabled = True
        Else
            ddlGRUPOS1.Items.Add(New ListItem("[SELECCIONE GRUPO]", String.Empty))
            ddlGRUPOS1.Enabled = False
        End If
        If ddlGRUPOS1.Items.Count > 0 Then ddlGRUPOS1.SelectedIndex = 0
        If ddlSUBGRUPOS1.Items.Count > 0 Then ddlSUBGRUPOS1.SelectedIndex = 0
        If DdlCATALOGOPRODUCTOS1.Items.Count > 0 Then DdlCATALOGOPRODUCTOS1.SelectedIndex = 0
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        ddlSUBGRUPOS1.Items.Clear()
        If ddlGRUPOS1.SelectedIndex <> 0 Then
            Suministros.CargarSubGruposALista(CType(ddlGRUPOS1.SelectedValue, Integer), ddlSUBGRUPOS1)
            ddlSUBGRUPOS1.Enabled = True
        Else
            ddlSUBGRUPOS1.Items.Add(New ListItem("[SELECCIONE SUBGRUPO]", String.Empty))
            ddlSUBGRUPOS1.Enabled = False
        End If

        If ddlSUBGRUPOS1.Items.Count > 0 Then ddlSUBGRUPOS1.SelectedIndex = 0
        If DdlCATALOGOPRODUCTOS1.Items.Count > 0 Then DdlCATALOGOPRODUCTOS1.SelectedIndex = 0
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        DdlCATALOGOPRODUCTOS1.Items.Clear()
        If ddlSUBGRUPOS1.SelectedIndex <> 0 Then
            Suministros.CargarProductosALista(CType(ddlSUBGRUPOS1.SelectedValue, Integer), DdlCATALOGOPRODUCTOS1)
            DdlCATALOGOPRODUCTOS1.Enabled = True
        Else
            DdlCATALOGOPRODUCTOS1.Items.Add(New ListItem("[SELECCIONE PRODUCTO]", String.Empty))
            DdlCATALOGOPRODUCTOS1.Enabled = False
        End If

        If DdlCATALOGOPRODUCTOS1.Items.Count > 0 Then DdlCATALOGOPRODUCTOS1.SelectedIndex = 0
    End Sub

    Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
        If DdlCATALOGOPRODUCTOS1.SelectedIndex <> 0 Then
            Producto = Helpers.Productos.Buscar(CType(DdlCATALOGOPRODUCTOS1.SelectedValue, Long), 1)
            If Producto IsNot Nothing Then
                lblDescripcionCompleta2.Text = Producto.CORRPRODUCTO + " - " + Producto.DESCLARGO
                MostrarDetalle()
            Else
                OcultarDetalle()
            End If
        End If
    End Sub

    Protected Sub lblDescripcionCompleta_TextChanged(sender As Object, e As System.EventArgs) Handles lblDescripcionCompleta.TextChanged
        tbProductos.Text = lblDescripcionCompleta.Text
        lblDescripcionCompleta2.Text = lblDescripcionCompleta.Text
        If Not String.IsNullOrEmpty(hfId.Value) Then
            Producto = Helpers.Productos.Buscar(CType(hfId.Value, Long))
            If Producto IsNot Nothing Then
                MostrarDetalle()
            Else
                OcultarDetalle()
            End If
        End If
    End Sub
#End Region

    Private Sub OcultarDetalle()
        If mvProductos.ActiveViewIndex = 0 Then
            tbProductos.Text = String.Empty
            hfId.Value = String.Empty
            tbProductos.Focus()
        Else
            mvProductos.ActiveViewIndex = 0
        End If
        Alert("El código del producto no fue encontrado.", "No Encontrado")
        plProducto.Visible = False
    End Sub

    Private Sub MostrarDetalle()
        mvDetalleProducto.ActiveViewIndex = 0
        ddlUNIDADMEDIDAS1.SelectedItem.Text = Producto.UNIDADMEDIDA
        'nbCantidad.DecimalPlaces = Producto.CANTIDADDECIMAL
        nbCantidad.CssClass = CType(IIf(UnidadMedida.EsDecimal(Producto.UNIDADMEDIDA), "double", "numeric"), String)
        plProducto.Visible = True
        txtRenglon.Text = ProductosContrato.ObtenerSiguienteRenglon(Me.Base).ToString()
        nbPrecioUnitario.Text = Producto.PRECIOACTUAL.ToString()
        txtDescripcion.Text = Producto.DESCLARGO
        Dim alm = Membresia.ObtenerUsuario().Almacen
        Try
            Almacenes.CargarAlmacenesEstablecimientosALista(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, ddlAlmacenesEntrega)

        Catch ex As Exception
            ddlAlmacenesEntrega.Items.Add(New ListItem(alm.NOMBRE, alm.IDALMACEN.ToString()))
            ddlAlmacenesEntrega.SelectedValue = alm.IDALMACEN.ToString()
        End Try

        If alm Is Nothing Then
            ddlAlmacenesEntrega.Enabled = False
        Else
            Try
                ddlAlmacenesEntrega.Enabled = True
                ddlAlmacenesEntrega.SelectedValue = alm.IDALMACEN.ToString()
            Catch ex As Exception
                Alert("No se encontró el almacen en la lista de almacenes", "Almacen no encontrado")
                ddlAlmacenesEntrega.Enabled = False
            End Try

        End If


        txtRenglon.Focus()
    End Sub


    Protected Sub btnAgregarProducto_Click(sender As Object, e As System.EventArgs) Handles btnAgregarProducto.Click
        mvMainProducto.ActiveViewIndex = 1
    End Sub
End Class
