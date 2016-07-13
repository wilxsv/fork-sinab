
Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Tipos
Imports SINAB_Utils
Imports Enumerable = System.Linq.Enumerable

Partial Class Controles_CifradosPresupuestarios
    Inherits System.Web.UI.UserControl

    Public Property ProductoSeleccionado() As ProductosSolicitudCorrelativo
        Get
            Return CType(ViewState("seleccionado"), ProductosSolicitudCorrelativo)
        End Get
        Set(value As ProductosSolicitudCorrelativo)
            ViewState("seleccionado") = value
        End Set
    End Property

    Private ReadOnly Property MontoSuma() As Double
        Get
            Return ProductoSeleccionado.Cifrados.Sum(Function(sm) sm.Monto)
        End Get
    End Property

    Private ReadOnly Property CantidadSuma() As Double
        Get
            Return ProductoSeleccionado.Cifrados.Sum(Function(cm) cm.Cantidad)
        End Get
    End Property

    Private Property CifradoSeleccionado() As SAB_EST_CIFRADOPRODUCTOSSOLICITUDES
        Set(value As SAB_EST_CIFRADOPRODUCTOSSOLICITUDES)
            ViewState("cf") = value
        End Set
        Get
            Return CType(ViewState("cf"), SAB_EST_CIFRADOPRODUCTOSSOLICITUDES)
        End Get
    End Property




    Private Sub LimpiarCifrado()
        tbAnio.Text = ""
        tbCodigo.Text = ""
        tbArea.Text = ""
        tbUnidad.Text = ""
        tbLinea.Text = ""
        tbClasificador.Text = ""
        tbFuente.Text = ""
        tbEspecifico.Text = ""
        tbCantidad.Text = ""
        tbMonto.Text = ""
        gvAdministradoresContrato.SelectedIndex = -1

    End Sub
    Public Sub LeerCifrados()
        With ProductoSeleccionado
            gvAdministradoresContrato.DataSource = .Cifrados
            gvAdministradoresContrato.DataBind()
        End With
    End Sub



    Public Sub CargarCifrados()
        With ProductoSeleccionado
            gvAdministradoresContrato.DataSource = CifradoProductoSolicitud.ObtenerTodos(.IDSOLICITUD, .IDESTABLECIMIENTO, CType(.IDPRODUCTO, Integer), .RENGLON)
            gvAdministradoresContrato.DataBind()
        End With
       
    End Sub


    Protected Sub lnkAgregar_Click(sender As Object, e As EventArgs) Handles lnkAgregar.Click
        Try
            If Not IsNothing(CifradoSeleccionado) Then
                CifradoProductoSolicitud.Eliminar(CifradoSeleccionado)
                CifradoSeleccionado = Nothing
                lnkAgregar.CssClass = "GridAgregar"
                lnkAgregar.ToolTip = "Agregar Cifrado Presupuestario"
                RecargarProducto()
                gvAdministradoresContrato.SelectedIndex = -1
            End If
           

            Dim cifrado = New SAB_EST_CIFRADOPRODUCTOSSOLICITUDES
        With cifrado
            .IdSolicitud = ProductoSeleccionado.IdSolicitud

            .IdProducto = ProductoSeleccionado.IdProducto

            .Renglon = ProductoSeleccionado.Renglon
            .IdEstablecimiento = ProductoSeleccionado.IdEstablecimiento
            .Anio = tbAnio.Text
            .CodigoInstitucion = tbCodigo.Text
            .AreaGestion = tbArea.Text
            .UnidadPresupuestaria = tbUnidad.Text
            .LineaTrabajo = tbLinea.Text
            .ClasificadorGastos = tbClasificador.Text
            .FuenteFinanciamiento = tbFuente.Text
            .ObjetoEspecificoGastos = tbEspecifico.Text
            .Cantidad = CType(tbCantidad.Text, Long)
            .Monto = CType(tbMonto.Text, Double)
        End With


            Dim limiteMonto = Math.Round(ProductoSeleccionado.Cantidad * ProductoSeleccionado.PrecioActual, 2)
        Dim limiteCantidad = ProductoSeleccionado.Cantidad

            Dim tempMonto = Math.Round(MontoSuma + cifrado.Monto, 2)
            Dim tempCantidad = Math.Round(CantidadSuma + cifrado.Cantidad, 2)

        If (tempMonto > limiteMonto Or tempCantidad > limiteCantidad) Then
                Throw New Exception("No se ha podido agregar el Cifrado: Cantidad o Monto mayor que el límite.")
            End If

           

        Using db As New SinabEntities
            Helpers.EstablecimientoHelpers.CifradoProductoSolicitud.Agregar(db, cifrado)
            RecargarProducto(db)
        End Using

        gvAdministradoresContrato.DataSource = ProductoSeleccionado.Cifrados
            gvAdministradoresContrato.DataBind()
        Catch ex As Exception
            MessageBox.Alert(ex.Message, "Error")
        End Try
    End Sub

    Private Sub RecargarProducto(ByVal db As SinabEntities)
        ProductoSeleccionado = ProductoSolicitud.ObtenerConCifrados(db, CType(ProductoSeleccionado.IdSolicitud, Integer), ProductoSeleccionado.IdEstablecimiento, CType(ProductoSeleccionado.Renglon, Integer), CType(ProductoSeleccionado.IdProducto, Integer))
    End Sub

    Private Sub RecargarProducto()
        ProductoSeleccionado = ProductoSolicitud.Obtener(CType(ProductoSeleccionado.IdSolicitud, Integer), ProductoSeleccionado.IdEstablecimiento, CType(ProductoSeleccionado.Renglon, Integer), CType(ProductoSeleccionado.IdProducto, Integer))
    End Sub


    Protected Sub gvAdministradoresContrato_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvAdministradoresContrato.RowDeleting

        Dim cifradoUnificado = CType(gvAdministradoresContrato.DataKeys(e.RowIndex).Values(1), String)
        'DataKeyNames="IdCifrado, IdSolicitud, IdEstablecimiento, IdProducto, IdDependencia"
        Try
            Dim delitem = ProductoSeleccionado.Cifrados.FirstOrDefault(Function(c) c.CifradoUnificado = cifradoUnificado)
            If Not IsNothing(delitem) Then
                CifradoProductoSolicitud.Eliminar(delitem)
                RecargarProducto()
                LeerCifrados()
            End If
            'CifradoProductoSolicitud.Eliminar(id, idSolicitud, idEstablecimiento, idProducto)
            'CargarCifrados()
        Catch ex As Exception
            MessageBox.Alert("Error al intentar eliminar Cifrado : " & ex.Message)
        End Try
    End Sub

    Protected Sub gvAdministradoresContrato_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvAdministradoresContrato.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataRow = CType(e.Row.DataItem, SAB_EST_CIFRADOPRODUCTOSSOLICITUDES)
            Dim ltCifrado As Literal = CType(e.Row.FindControl("ltCifrado"), Literal)
            With dataRow
                ltCifrado.Text = String.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7} Cantidad: {8}, US$: {9}", .Anio, .CodigoInstitucion, .AreaGestion, .UnidadPresupuestaria, .LineaTrabajo, .ClasificadorGastos, .FuenteFinanciamiento, .ObjetoEspecificoGastos, .Cantidad, .Monto)
            End With
        End If
    End Sub

    Protected Sub gvAdministradoresContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvAdministradoresContrato.SelectedIndexChanged
        Dim datakeys = gvAdministradoresContrato.DataKeys(gvAdministradoresContrato.SelectedIndex)
        Dim id As Integer = CType(datakeys.Values(0), Integer)
        CifradoSeleccionado = CifradoProductoSolicitud.Obtener(id)
        With CifradoSeleccionado
            tbAnio.Text = .Anio
            tbCodigo.Text = .CodigoInstitucion
            tbArea.Text = .AreaGestion
            tbUnidad.Text = .UnidadPresupuestaria
            tbLinea.Text = .LineaTrabajo
            tbClasificador.Text = .ClasificadorGastos
            tbFuente.Text = .FuenteFinanciamiento
            tbEspecifico.Text = .ObjetoEspecificoGastos
            tbCantidad.Text = String.Format("{0:N2}", .Cantidad)
            tbMonto.Text = String.Format("{0:N2}", .Monto)
        End With
        lnkAgregar.CssClass = "GridActualizar"
        lnkAgregar.ToolTip = "Actualizar Cifrado Presupuestario"
    End Sub

    Protected Sub lnkLimpiar_Click(sender As Object, e As EventArgs) Handles lnkLimpiar.Click
        LimpiarCifrado()
        lnkAgregar.CssClass = "GridAgregar"
        lnkAgregar.ToolTip = "Agregar Cifrado Presupuestario"
    End Sub
End Class
