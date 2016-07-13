
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades.Helpers

Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades
Imports SINAB_Entidades.Tipos
Imports System.Activities.Statements
Imports System.Windows.Forms.VisualStyles

Partial Class Controles_DistribucionEntregaProductos
    Inherits System.Web.UI.UserControl


    Public Property Solicitud() As SAB_EST_SOLICITUDES
        Private Get
            Return CType(ViewState("solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(ByVal value As SAB_EST_SOLICITUDES)
            ViewState("solicitud") = value
        End Set
    End Property

    Public ReadOnly Property Fuentes As Dictionary(Of Integer, String)
        Get
            Return SolicitudesFuentesFinanciamiento.ObtenerTodos(Solicitud)
        End Get
    End Property

    Public ReadOnly Property Almacenes As Dictionary(Of Integer, String)
        Get
            Return EstablecimientoHelpers.AlmacenesEntrega.ObtenerTodos(Solicitud.IDSOLICITUD, Solicitud.IDESTABLECIMIENTO)
        End Get
    End Property


    Public Property ProductoSeleccionado() As ProductosSolicitudCorrelativo
        Private Get
            Return CType(Session("seleccionado"), ProductosSolicitudCorrelativo)
        End Get
        Set(value As ProductosSolicitudCorrelativo)
            Session("seleccionado") = value
            If Not IsNothing(value) Then ltProducto.Text = "Renglón: " + value.Renglon.ToString() + " - " + value.Descripcion
        End Set
    End Property

    ''' <summary>
    ''' Distribuciones sin procesar
    ''' </summary>
    ''' <value>BaseProducto contenidos en la Solicitud </value>
    ''' <returns>
    ''' Distribuciones con cantidades digitadas
    ''' </returns>
    ''' <remarks>
    ''' Entregas puede ser reiniciada en el flujo de datos y puede contener o no las cantidades digitadas
    ''' </remarks>
    Public Property Distribuciones() As List(Of ProductosSolicitudCorrelativo)
        Get
            Return CType(ViewState("distros"), List(Of ProductosSolicitudCorrelativo))
        End Get
        Set(value As List(Of ProductosSolicitudCorrelativo))
            ViewState("distros") = value
        End Set
    End Property


    ''' <summary>
    ''' Muestra u Oculta el boton "Agrregar" de la Grid gvProdcutosDistribucion.
    ''' </summary>
    ''' <value>booleano</value>
    ''' <returns>booleano</returns>
    ''' <remarks>
    ''' Determina si se pueden agregar mas items del tipo AlmacenesProductoDistribucion a la distribucion
    ''' PASO 6
    ''' </remarks>
    Public Property SeAgrega As Boolean
        Private Get
            Return pnlAgregar.Visible
        End Get
        Set(ByVal value As Boolean)
            pnlAgregar.Visible = value
            pnlNavBar.Visible = value
            'chkCifrado.Visible = value
        End Set
    End Property

    ''' <summary>
    ''' Lleva el conteo de las filas originales en la Grid gvProdcutosDistribucion
    ''' </summary>
    ''' <value>entero</value>
    ''' <returns>número de columnas</returns>
    ''' <remarks>Aplica en PASO 6</remarks>
    Public Property FilasOriginalesCount As Integer
        Get
            Return CType(ViewState("foCount"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("foCount") = value
        End Set
    End Property

    Public ReadOnly Property NumeroEntregas() As Short?
        Get
            If mvEntregas.ActiveViewIndex = 0 Then
                Return CType(ddlEntregas.SelectedValue, Integer)
            End If
            Return EntregasProductos2.Entregas
        End Get
    End Property

    Private Property Editando As Boolean
        Get
            Return lnkActualizar.Visible
        End Get
        Set(value As Boolean)
            lnkAgregar.Visible = Not value
            lnkCancelar.Visible = value
            lnkActualizar.Visible = value
        End Set
    End Property

    Private Property ItemSeleccionado() As BaseProductos
        Get
            Return CType(Session("itmseleccionado"), BaseProductos)
        End Get
        Set(value As BaseProductos)
            Session("itmseleccionado") = value
        End Set
    End Property

    Public Function ObtenerEntregasProcesadas() As List(Of SAB_EST_ENTREGAS)
        Return EntregasProductos2.ObtenerEntregas()
    End Function

    Public Sub CargarDatos()
        DetalleSolicitud = ObtenerDetalle()
        ltProducto.Text = ProductoSeleccionado.DescLargo

        'Entregas de producto
        If Solicitud.EntregaUniforme Then
            ddlEntregas.Items.Clear()
            Dim count = 1
            For Each ent As SAB_EST_ENTREGAS In Solicitud.SAB_EST_ENTREGAS
                ddlEntregas.Items.Add(count.ToString())
                count += 1
            Next
            If Not DetalleSolicitud.NUMEROENTREGAS Is Nothing And DetalleSolicitud.NUMEROENTREGAS > 0 Then
                ddlEntregas.SelectedValue = DetalleSolicitud.NUMEROENTREGAS.ToString()
            ElseIf Solicitud.SAB_EST_ENTREGAS.Any() Then
                ddlEntregas.SelectedValue = CType(Solicitud.SAB_EST_ENTREGAS.Max(Function(en) en.IDENTREGA), String)
            End If
            mvEntregas.ActiveViewIndex = 0
        Else
            EntregasProductos2.ProductoSeleccionado = ProductoSeleccionado
            EntregasProductos2.Solicitud = Solicitud
            EntregasProductos2.CargarEntregas()
            mvEntregas.ActiveViewIndex = 1
        End If
        With ddlFuentes
            .DataSource = Fuentes
            .DataTextField = "Value"
            .DataValueField = "Key"
            .DataBind()
        End With
        With ddlLugar
            .DataSource = Almacenes
            .DataTextField = "Value"
            .DataValueField = "Key"
            .DataBind()
        End With
        If Distribuciones.Count() >= Limite Then
            SeAgrega = False
        Else
            SeAgrega = True
        End If
        CargarDistribuciones()
        gvProdcutosDistribucion.SelectedIndex = -1
        Editando = False
    End Sub

    Protected Sub gvProdcutosDistribucion_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProdcutosDistribucion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataRow = CType(e.Row.DataItem, BaseProductos)
            Dim ltFuentes As Literal = CType(e.Row.FindControl("ltFuentes"), Literal)
            Dim ltLugar As Literal = CType(e.Row.FindControl("ltLugar"), Literal)
            Dim ltCifrado As Literal = CType(e.Row.FindControl("ltCifrado"), Literal)

            'si existe un id seleccionan los datos
            If dataRow.IdAlmacen > 0 Then ltLugar.Text = Almacenes.FirstOrDefault(Function(obj) obj.Key = dataRow.IdAlmacen).Value
            If dataRow.IdFuenteFinanciamiento > 0 Then ltFuentes.Text = Fuentes.FirstOrDefault(Function(obj) obj.Key = dataRow.IdFuenteFinanciamiento).Value

            Try
                If dataRow.Cifrados.Any() Then
                    ltCifrado.Text = "<br />Cifrado(s):"
                    For Each cifrado As SAB_EST_CIFRADOPRODUCTOSSOLICITUDES In dataRow.Cifrados
                        With cifrado
                            ltCifrado.Text += String.Format("<br /> {0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}", .Anio, .CodigoInstitucion, .AreaGestion, .UnidadPresupuestaria, .LineaTrabajo, .ClasificadorGastos, .FuenteFinanciamiento, .ObjetoEspecificoGastos)
                        End With
                    Next

                Else : ltCifrado.Text = ""
                End If
            Catch ex As Exception
                dataRow.Cifrados = Nothing
                ltCifrado.Text = ""
            End Try
        End If
    End Sub

    Protected Sub gvProdcutosDistribucion_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvProdcutosDistribucion.RowDeleting
        Dim datakeys = gvProdcutosDistribucion.DataKeys(e.RowIndex)
        Dim fuentes = datakeys.Item(3)
        Dim almacen = datakeys.Item(4)

        Distribuciones.Remove(Distribuciones.FirstOrDefault(Function(en) en.IdFuenteFinanciamiento = fuentes And en.IdAlmacen = almacen))
        SeAgrega = True
        CargarDistribuciones()
    End Sub

    Protected Sub gvProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvProdcutosDistribucion.SelectedIndexChanged
        ItemSeleccionado = Nothing
        Dim datakeys = gvProdcutosDistribucion.DataKeys(gvProdcutosDistribucion.SelectedIndex)
        Dim tempitem = New BaseProductos()
        With tempitem
            .IdProducto = CType(datakeys.Item(0), Long)
            .Renglon = CType(datakeys.Item(1), Long)
            .IdFuenteFinanciamiento = CType(datakeys.Item(3), Integer)
            .IdAlmacen = CType(datakeys.Item(4), Integer)
        End With

        ItemSeleccionado = Distribuciones.FirstOrDefault(Function(i) i.IdProducto = tempitem.IdProducto And i.Renglon = tempitem.Renglon And i.IdFuenteFinanciamiento = tempitem.IdFuenteFinanciamiento And i.IdAlmacen = tempitem.IdAlmacen)
        Try
            SeAgrega = True
            ddlFuentes.SelectedValue = ItemSeleccionado.IdFuenteFinanciamiento.ToString()
            ddlLugar.SelectedValue = ItemSeleccionado.IdAlmacen.ToString()
            tbcantidad.Text = ItemSeleccionado.Cantidad.ToString()


            'CifradosPresupuestarios.ProductoSeleccionado = ItemSeleccionado
            'If IsNothing(ItemSeleccionado.Cifrados) Then ItemSeleccionado.Cifrados = New List(Of SAB_EST_CIFRADOPRODUCTOSSOLICITUDES)()
            'If ItemSeleccionado.Cifrados.Any() Then
            '    chkCifrado.Checked = True
            '    pnlCifrado.Visible = True
            '    'todo:cargar cifrados
            '    CifradosPresupuestarios.LeerCifrados()

            'Else

            '    LimpiarCifrado()
            'End If

            Editando = True
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert("No se ha podido cargar la información de la distribución.", "Error al editar")
        End Try
    End Sub

    Protected Sub lnkAgregar_Click(sender As Object, e As EventArgs) Handles lnkAgregar.Click
        Dim tempitem As ProductosSolicitudCorrelativo = GetTempitem()
        Distribuciones.Add(tempitem)

        Dim duplicados = Distribuciones.Select(Function(rec) New KeyValuePair(Of Integer, Integer)(rec.IdAlmacen, rec.IdFuenteFinanciamiento)).ToList()
        If duplicados.Count() <> duplicados.Distinct().Count() Then
            Distribuciones.Remove(tempitem)
            SINAB_Utils.MessageBox.Alert("Registro duplicado: No puede agregar registro con almacén de entrega y fondo de financiamiento anteriormente agregado", "Error")
        End If
        RecargarDatos()
    End Sub



    Private Property DetalleSolicitud() As SAB_EST_DETALLESOLICITUDES
        Get
            Return CType(ViewState("detallesolicitud"), SAB_EST_DETALLESOLICITUDES)
        End Get
        Set(ByVal value As SAB_EST_DETALLESOLICITUDES)
            ViewState("detallesolicitud") = value
        End Set
    End Property

    Private ReadOnly Property Limite() As Int32
        Get
            Return Fuentes.Count * Almacenes.Count
        End Get
    End Property

    Public Function ObtenerDetalle() As SAB_EST_DETALLESOLICITUDES

        Dim d = New SAB_EST_DETALLESOLICITUDES
        With d
            .IDESTABLECIMIENTO = Solicitud.IDESTABLECIMIENTO
            .IDSOLICITUD = Solicitud.IDSOLICITUD
            .IDPRODUCTO = ProductoSeleccionado.IdProducto
            .RENGLON = ProductoSeleccionado.Renglon
            .ESPECIFICACIONTECNICA = ProductoSeleccionado.RutaEspecificacion
            .AUUSUARIOCREACION = CType(_usr, String)
            .PRESUPUESTOUNITARIO = ProductoSeleccionado.Precio
            .CANTIDAD = 0
            .ESTASINCRONIZADA = 0
            .PRESUPUESTOTOTAL = 0
            .AUFECHACREACION = DateTime.Now
            .NUMEROENTREGAS = CType(ProductoSeleccionado.NumeroEntrega, Byte?)
            .Correlativo = ProductoSeleccionado.Correlativo
        End With
        Return d
    End Function

    'Protected Sub chkCifrado_CheckedChanged(sender As Object, e As EventArgs) Handles chkCifrado.CheckedChanged
    '    pnlCifrado.Visible = chkCifrado.Checked
    'End Sub


    Protected Sub lnkCancelar_Click(sender As Object, e As EventArgs) Handles lnkCancelar.Click
        gvProdcutosDistribucion.SelectedIndex = -1

        tbcantidad.Text = ""
        ddlFuentes.SelectedIndex = 0
        ddlLugar.SelectedIndex = 0
        RecargarDatos()
    End Sub

    Protected Sub lnkActualizar_Click(sender As Object, e As EventArgs) Handles lnkActualizar.Click
        Try
            If Editando Then
                Dim tempitem As BaseProductos = GetTempitem()
                Dim itemborrar = Distribuciones.FirstOrDefault(Function(i) i.IdProducto = ItemSeleccionado.IdProducto And i.Renglon = ItemSeleccionado.Renglon And i.IdFuenteFinanciamiento = ItemSeleccionado.IdFuenteFinanciamiento And i.IdAlmacen = ItemSeleccionado.IdAlmacen)
                Dim index = Distribuciones.IndexOf(itemborrar)
                Distribuciones.Remove(itemborrar)
                Distribuciones.Insert(index, tempitem)

                RecargarDatos()
            End If
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert("Error al actualizar distribución, no se han realizado los cambios requeridos")
        End Try
    End Sub

    Private Sub CargarDistribuciones()
        With gvProdcutosDistribucion
            .DataSource = Distribuciones
            .DataBind()
        End With
    End Sub

    Private Function GetTempitem() As ProductosSolicitudCorrelativo
        Dim detalle = ObtenerDetalle()
        Dim tempitem = New ProductosSolicitudCorrelativo()
        With tempitem
            .IdSolicitud = detalle.IDSOLICITUD
            .IdEstablecimiento = detalle.IDESTABLECIMIENTO
            .IdProducto = CType(detalle.IDPRODUCTO, Long)
            .Renglon = detalle.RENGLON
            .Cantidad = CType(tbcantidad.Text, Decimal)
            .IdFuenteFinanciamiento = CType(ddlFuentes.SelectedValue, Integer)
            .IdAlmacen = CType(ddlLugar.SelectedValue, Integer)
            .Correlativo = detalle.Correlativo
        End With
        ''si se ha checkeado el cifrado presupuestario entonces se crea el nuevo cifrado
        'If chkCifrado.Checked Then
        '    tempitem.Cifrados = CifradosPresupuestarios.ProductoSeleccionado.Cifrados
        'Else : tempitem.Cifrados = Nothing
        'End If
        If IsNothing(ItemSeleccionado) Then Return tempitem

        If not IsNothing(ItemSeleccionado.Cifrados) Then 
            tempitem.Cifrados = new List(Of SAB_EST_CIFRADOPRODUCTOSSOLICITUDES) 
            tempitem.Cifrados.AddRange(ItemSeleccionado.Cifrados)
        End If
        Return tempitem
    End Function

    Private Sub RecargarDatos()

        If Distribuciones.Count() >= Limite Then
            SeAgrega = False
        Else
            SeAgrega = True
        End If

        CargarDistribuciones()
        tbcantidad.Text = ""

        'If chkCifrado.Checked Then
        '    LimpiarCifrado()
        'End If
        Editando = False
        ItemSeleccionado = Nothing
        '  gvProdcutosDistribucion.SelectedIndex = -1
    End Sub

    'Private Sub LimpiarCifrado()
    '    CifradosPresupuestarios.LimpiarCifrado()
    '    chkCifrado.Checked = False
    '    pnlCifrado.Visible = False
    'End Sub

    ReadOnly _usr As String = Membresia.ObtenerUsuario().NombreUsuario



End Class
