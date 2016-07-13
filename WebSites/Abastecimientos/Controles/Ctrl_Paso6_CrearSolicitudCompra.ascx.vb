
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Tipos
Imports SINAB_Entidades.Helpers
Imports System.Linq
Imports SINAB_Utils.MessageBox
Partial Class Controles_Ctrl_Paso6_CrearSolicitudCompra
    Inherits System.Web.UI.UserControl

#Region "Propiedades"
    Public Property VerificarCifrado As Boolean
        Get
            Return CType(ViewState("vc"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("vc") = value
        End Set
    End Property

    Public Property Titulo() As String
        Get
            Return ltTitle.Text
        End Get
        Set(value As String)
            ltTitle.Text = value
        End Set
    End Property

    Public Property Solicitud As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("_solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(value As SAB_EST_SOLICITUDES)
            ViewState("_solicitud") = value
        End Set
    End Property

    Public ReadOnly Property EstaCompleto() As Boolean
        Get
            Return (From row As GridViewRow In gvProductos.Rows Where row.RowType = DataControlRowType.DataRow Select CType(row.FindControl("divChecked"), Panel)).All(Function(imgOk) imgOk.CssClass = "checkedInfo")
        End Get
    End Property

#End Region

#Region "Handlers"
    Public Event ActualizarEstado As EventHandler

    Public Event VerDistribucionProducto As EventHandler
#End Region

    Public Sub CargarDatos(lista As List(Of ProductoSolicitudVistaProductos))
        gvProductos.DataSource = lista
        gvProductos.DataBind()
    End Sub

#Region "Eventos"
    Protected Sub gvProductos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProductos.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            'validacion si existe distribucion o no
            Dim imgOk As Panel = CType(e.Row.FindControl("divChecked"), Panel)
            Dim lnkSelect As LinkButton = CType(e.Row.FindControl("lnkselect"), LinkButton)

            Dim detalle As SAB_EST_DETALLESOLICITUDES = ObtenerDetalle(e.Row)


            Dim producto = CType(e.Row.DataItem, ProductoSolicitudVistaProductos)
            _suma += producto.MontoRenglon
            If Not VerificarCifrado Then
                Dim existe = AlmacenesEntregaSolicitud.ExisteDistribucion(detalle)
                imgOk.CssClass = CType(IIf(existe, "checkedInfo", ""), String)
                lnkSelect.CssClass = CType(IIf(existe, "GridEditar", "GridAgregar"), String)
            Else
                Dim conCifrado = CifradoProductoSolicitud.Existe(detalle.IDSOLICITUD, detalle.IDESTABLECIMIENTO, CType(detalle.IDPRODUCTO, Integer), detalle.RENGLON)
                imgOk.CssClass = CType(IIf(conCifrado, "checkedInfo", ""), String)
                lnkSelect.ToolTip = "Agregar / Editar Cifrado Presupuestario"
                lnkSelect.CssClass = CType(IIf(conCifrado, "GridEditar", "GridAgregar"), String)
            End If
           

        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            Dim lblTotal As Label = CType(e.Row.FindControl("lblTotalMonto"), Label)
            lblTotal.Text = String.Format("US$ {0:0.0000}", _suma)


            If _suma > Solicitud.MONTOAUTORIZADO Then
                RaiseEvent ActualizarEstado(True, New EventArgs()) 'btn.Enabled = False
                Alert(String.Format("El Monto de compra excede el monto autorizado : {0:c}", Solicitud.MONTOAUTORIZADO))
            Else : RaiseEvent ActualizarEstado(False, New EventArgs()) 'btn.Enabled = True
            End If
        End If
    End Sub

    Protected Sub gvProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProductos.SelectedIndexChanged 'todo: para que es esto? , gvProductosSolicitud.SelectedIndexChanged
        Try
            CargarDatosPsd()
            'Redirigir   ModalPup.Show()
        Catch ex As Exception
            Alert("Error al recuperar datos de producto para distribución. Error:" & ex.Message)
        End Try
    End Sub
#End Region

#Region "Métodos Privados"
    Private Function ObtenerDetalle(row As GridViewRow) As SAB_EST_DETALLESOLICITUDES
        Dim producto = CType(row.DataItem, ProductoSolicitudVistaProductos)

        Dim detalle = New SAB_EST_DETALLESOLICITUDES
        With detalle
            .IDESTABLECIMIENTO = Solicitud.IDESTABLECIMIENTO
            .IDSOLICITUD = Solicitud.IDSOLICITUD
            .IDPRODUCTO = producto.IdProducto
            .RENGLON = CType(producto.Renglon, Long)
            .ESPECIFICACIONTECNICA = producto.RutaEspecificacion
            .AUUSUARIOCREACION = Membresia.ObtenerUsuario().NombreUsuario
            .PRESUPUESTOUNITARIO = producto.PrecioActual
            .CANTIDAD = 0
            .ESTASINCRONIZADA = 0
            .PRESUPUESTOTOTAL = 0
            .AUFECHACREACION = DateTime.Now
            .NUMEROENTREGAS = producto.Entrega
            .Correlativo = producto.Correlativo
        End With
        Return detalle
    End Function



    Private Sub CargarDatosPsd()

        Dim sp = New ProductosSolicitudCorrelativo
        With sp
            .IdProducto = (CType(gvProductos.DataKeys(gvProductos.SelectedIndex).Values(0), Long))
            .Renglon = CType(gvProductos.DataKeys(gvProductos.SelectedIndex).Values(1), Long)
            .RutaEspecificacion = CType(gvProductos.DataKeys(gvProductos.SelectedIndex).Values(4), String)
            .Precio = CType(gvProductos.DataKeys(gvProductos.SelectedIndex).Values(5), Long)
            .Descripcion = gvProductos.DataKeys(gvProductos.SelectedIndex).Values(6).ToString()
            .NumeroEntrega = CType(gvProductos.DataKeys(gvProductos.SelectedIndex).Values(7), Short)
            .Correlativo = CType(gvProductos.DataKeys(gvProductos.SelectedIndex).Values(8), Short)
        End With

        If VerificarCifrado Then
            Response.Redirect(String.Format("~/ESTABLECIMIENTOS/EditarCifradosSolicitud.aspx?id={0}&r={1}&idp={2}", Solicitud.IDSOLICITUD, sp.Renglon, sp.IdProducto))
        Else
            RaiseEvent VerDistribucionProducto(sp, New EventArgs())
        End If


    End Sub

    Dim _suma As Decimal = 0
#End Region
End Class
