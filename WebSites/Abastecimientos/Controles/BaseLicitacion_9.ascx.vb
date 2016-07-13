Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Tipos
Imports SINAB_Entidades.Helpers.UACIHelpers

Partial Class Controles_BaseLicitacion_9
    Inherits System.Web.UI.UserControl

    ''' <summary>
    ''' Asigna el identificador del proceso de compra
    ''' </summary>
    ''' <value>Entero</value>
    ''' <returns>Entero</returns>
    ''' <remarks>Esta propiedad es obligatoria</remarks>
    Public Property IdProcesoCompra As Integer
        Set(value As Integer)
            ViewState("idpc") = value
        End Set
        Get
            Return CType(ViewState("idpc"), Integer)
        End Get
    End Property



    ''' <summary>
    ''' Obtiene el detalle del proceso de compras junto con el monto y la garantia y muestra el total de ambos al pié de la tabla
    ''' </summary>
    ''' <remarks>Este método necesita que la propiedad IdProcesoCOmpra este previamente asignada a un valor</remarks>
    Public Sub ObtenerProductos()
        Dim total As Integer = 0
        Dim i = 0

        Dim ds = DetalleProcesoCompras.Obtener(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, IdProcesoCompra)

        dgDetalleProductos.DataSource = ds
        dgDetalleProductos.DataBind()

        For Each detalle As BaseDetalleProcesoCompra In ds
            Dim tbGarantia As TextBox = CType(dgDetalleProductos.Items(i).FindControl("txtValorGarantia"), TextBox)
            tbGarantia.Text = detalle.GarantiaMontoValor.ToString()
            total = CType((total + detalle.GarantiaMontoValor), Integer)
            i += 1
        Next
        If String.IsNullOrEmpty(lblMontoSolicitado.Text)
            lblTotalG.Text = 0
            Else 
            lblTotalG.Text = (CType(lblMontoSolicitado.Text,Decimal) * 0.05).ToString()
        End If
        
        If lblTotalG.Text > total Then
            lblTotalGarantia.Text = CType(total, String)
            lblTotalGarantia.BackColor = Drawing.Color.Green
        Else
            lblTotalGarantia.Text = CType(total, String)
            lblTotalGarantia.BackColor = Drawing.Color.Red
        End If
    End Sub

    ''' <summary>
    ''' Recorre los renglones de la tabla mostrada recuperando el valor de la garantia para luego actualizarla en la tabla sab_uaci_detalleprocesocompra
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GuardarGarantiasProducto()
        Dim lEntidad As New SAB_UACI_DETALLEPROCESOCOMPRA
        Dim text As TextBox
        Dim idEstablecimiento = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        Using db As New SinabEntities


            For Each a As DataGridItem In dgDetalleProductos.Items
                With lEntidad

                    text = CType(a.FindControl("txtValorGarantia"), TextBox)

                    .IDESTABLECIMIENTO = idEstablecimiento
                    .IDPROCESOCOMPRA = IdProcesoCompra
                    .IDPRODUCTO = CType(dgDetalleProductos.Items(a.ItemIndex).Cells(8).Text, Long)
                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    .AUFECHAMODIFICACION = Now

                    If text.Text <> "" Then
                        .GARANTIAMTTOVALOR = CType(text.Text, Decimal?)
                    Else
                        .GARANTIAMTTOVALOR = 0
                    End If

                    DetalleProcesoCompras.ActualizarGarantia(db, lEntidad)
                End With
            Next
        End Using
    End Sub

    Protected Sub btnReplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReplicar.Click
        Dim i As Integer
        Dim valorGarantia As TextBox
        Dim porcentaje As Decimal
        Dim monto, total As Decimal

        If txtPorcentaje.Text > 100 Then
            RequiredFieldValidator31.ErrorMessage = "El valor debe ser menor de 100"
            RequiredFieldValidator31.IsValid = False
        ElseIf txtPorcentaje.Text <= 0 Then
            RequiredFieldValidator31.ErrorMessage = "El valor debe ser mayor que 0"
            RequiredFieldValidator31.IsValid = False
        Else
            porcentaje = CDec(txtPorcentaje.Text) / 100

            For i = 0 To dgDetalleProductos.Items.Count - 1
                monto = CType(dgDetalleProductos.Items(i).Cells(4).Text, Decimal)
                valorGarantia = CType(dgDetalleProductos.Items(i).FindControl("txtValorGarantia"), TextBox)
                valorGarantia.Text = CType(Math.Max(Decimal.One, Decimal.Round(monto * porcentaje, 2, MidpointRounding.AwayFromZero)), String)
                total = total + CDec(valorGarantia.Text)
            Next

            lblTotalG.Text = CType(Decimal.Round(CDec(lblMontoSolicitado.Text) * CDec(0.05), 2, MidpointRounding.AwayFromZero), String)

            If lblTotalG.Text > total Then
                lblTotalGarantia.Text = total
                lblTotalGarantia.BackColor = Drawing.Color.Green
            Else
                lblTotalGarantia.Text = total
                lblTotalGarantia.BackColor = Drawing.Color.Red
            End If
            lblTotalGarantia.ForeColor = Drawing.Color.White
        End If
    End Sub

    Public Sub ObtenerTotalsolicitud()
        Dim total As Decimal
        Using db As New SinabEntities

            Dim pc = EstablecimientoHelpers.SolicitudesProcesoCompras.ObtenerTodos(db, Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, IdProcesoCompra) 'mComponentes.ObtenerSolicitudesProcesoCompra1(IDPROCESOCOMPRA, Session("IdEstablecimiento"))

            For Each det As SAB_EST_SOLICITUDESPROCESOCOMPRAS In pc
                total = CType((total + det.SAB_EST_SOLICITUDES.MONTOSOLICITADO), Decimal)
            Next
        End Using
        lblMontoSolicitado.Text = CType(total, String)

    End Sub
End Class