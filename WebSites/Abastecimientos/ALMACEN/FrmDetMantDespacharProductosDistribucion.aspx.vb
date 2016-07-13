
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils.MessageBox
Imports SINAB_Entidades.Tipos
Imports System.Data
Imports System.Reflection
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Reflection.Emit
Imports SINAB_Entidades.EnumHelpers

Partial Class ALMACEN_FrmDetMantDespacharProductosDistribucion
    Inherits System.Web.UI.Page


#Region "Propiedades"

    Public Property Movimiento() As SAB_ALM_MOVIMIENTOS
        Get
            Return ViewState("MOVIMIENTO")
        End Get
        Set(ByVal value As SAB_ALM_MOVIMIENTOS)
            ViewState("MOVIMIENTO") = value
            Try
                Dim cad As String = "/Reportes/FrmRptValeSalida.aspx?IdEMov=" + Session.Item("IdEstablecimiento").ToString + "&IdMov=" + Movimiento.IDMOVIMIENTO.ToString
                btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
                '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValeSalida.aspx?IdEMov=" + Session.Item("IdEstablecimiento").ToString + "&IdMov=" + Movimiento.IDMOVIMIENTO.ToString + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return;"
            Catch ex As Exception
                Response.Redirect("~/FrmPrincipal.aspx", False)
            End Try

        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _idalmacen
        End Get
        Set(ByVal value As Integer)
            _idalmacen = value
            If Not ViewState("IDALMACEN") Is Nothing Then ViewState.Remove("IDALMACEN")
            ViewState.Add("IDALMACEN", value)
        End Set
    End Property

    Public Property ANIO() As Integer
        Get
            Return _anio
        End Get
        Set(ByVal value As Integer)
            _anio = value
            If Not ViewState("ANIO") Is Nothing Then ViewState.Remove("ANIO")
            ViewState.Add("ANIO", value)
        End Set
    End Property

    Public Property Vale() As SAB_ALM_VALESSALIDA
        Get
            Return ViewState("VALE")
        End Get
        Set(ByVal value As SAB_ALM_VALESSALIDA)

            ViewState("VALE") = value
        End Set
    End Property

    Public Property joker() As Integer
        Get
            Return _joker
        End Get
        Set(ByVal value As Integer)
            _joker = value
            If Not ViewState("joker") Is Nothing Then ViewState.Remove("joker")
            ViewState.Add("joker", value)
        End Set
    End Property

    Public Property esFarmacia() As Boolean
        Get
            Return ViewState("EsFarmacia")
        End Get
        Set(ByVal value As Boolean)
            ViewState("EsFarmacia") = value
        End Set
    End Property
#End Region

#Region "Eventos"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim usr = Membresia.ObtenerUsuario()
            Master.ControlMenu.Visible = False
            Dim idmovimiento = CType(Request.QueryString("IdMov"), Integer)
            IDALMACEN = CType(Request.QueryString("IdAlm"), Integer)
            cpFechaDespacho.Text = Now.Date.ToShortDateString()
            cvFechaDespacho.ValueToCompare = Now.Date.ToShortDateString()
            DeshabilitarDobleClickBotones()
            CargarListas()


            If idmovimiento = 0 Then
                Movimiento = New SAB_ALM_MOVIMIENTOS()
                Vale = New SAB_ALM_VALESSALIDA()
                ddlSUMINISTROS1.SelectedValue = CType(usr.SUMINISTRO.IDSUMINISTRO, String)
                btnCerrar.Enabled = False

                If usr.EmpleadoAlmacenes.FirstOrDefault().ESGUARDAALMACEN Then
                    txtEmpleadoAlmacen.Text = String.Format("{0} {1}", usr.Empleado.NOMBRE, usr.Empleado.APELLIDO)
                Else
                    Dim guarda = New GuardaAlmacen().Obtener(usr.Almacen.IDALMACEN)
                    txtEmpleadoAlmacen.Text = guarda.Nombre
                End If

                'seleccionar la primera opción
                lblTipoDespachoIndividual.Visible = True
                ddlTIPOMOVIMIENTOS1.Visible = True

                plBuscarDistribucion.Visible = False
                plEncabezado.Visible = True
                gvLista.Visible = True
                plGenerales.Visible = True

                plAgregarProducto.Visible = True
                Limpiar()

                ddlESTABLECIMIENTOS1.Focus()


                Me.DropDownList2.SelectedValue = 0

            Else
                CargarDatos(idmovimiento)
            End If

        Else
            If Not ViewState("IDALMACEN") Is Nothing Then _idalmacen = CType(ViewState("IDALMACEN"), Integer)
            If Not ViewState("ANIO") Is Nothing Then _anio = CType(ViewState("ANIO"), Integer)
            If Not ViewState("joker") Is Nothing Then _joker = CType(ViewState("joker"), Integer)
        End If

        If IsPostBack Then
            If ConfirmTarget = "Nuevo" Then AfterUserConfirmationHandler(ConfirmArgument)
            If ConfirmTarget = "Guardar" Then GuardarOSalirConfirmacion(ConfirmArgument)

        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        CerrarVale()
    End Sub



    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged

        RestablecerCriterio()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Limpiar(False)
        Buscar(0, txtProducto.Text)
    End Sub

    Protected Sub ddlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCATALOGOPRODUCTOS1.SelectedIndexChanged
        Limpiar()
        Buscar(ddlCATALOGOPRODUCTOS1.SelectedValue)
    End Sub

    Protected Sub btnAgregarLote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarLote.Click

        If lblDESCLARGO.Text = String.Empty Then
            Alert("No se ha especificado ningun producto")
            'MsgBox1.ShowAlert("No se ha especificado ningun producto", "w", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            If txtProducto.Visible Then txtProducto.Focus()
            Exit Sub
        End If

        If gvLotes.Rows.Count = 0 Then
            Alert("No se ha especificado lote")
            'MsgBox1.ShowAlert("No se ha especificado lote", "w", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            If txtProducto.Visible Then txtProducto.Focus()
            Exit Sub
        End If

        'verificar que la cantidad no sea mayor que la ingresada en los lotes
        Dim cantidadlotes As Integer = 0
        For Each row As GridViewRow In From row1 As GridViewRow In gvLotes.Rows Where CType(Me.gvLotes.Rows(row1.RowIndex).FindControl("nbCantidad"), TextBox).Text.Trim <> String.Empty
            cantidadlotes = cantidadlotes + CType(CType(gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), TextBox).Text, Decimal)
        Next
        If cantidadlotes > CInt(Me.Label4.Text) Then
            Alert("La suma de las cantidades en lotes es mayor a la cantidad a distribuir del producto.", "Advertencia")
            Exit Sub
        End If

        Try
            'si no se ha guardado el movimiento y el vale
            If Movimiento.IDMOVIMIENTO = 0 And Vale.IDVALE = 0 Then
                GuardarValeMovimiento()
                Alert("Se ha generado el vale " + txtNroVale.Text + " satisfactoriamente.  ")
            End If

            'si existe algun dublicado se sale de la funcion
            If VerificarDuplicado() Then Exit Sub

            'recuperando los detalles del movimiento y guardandolos en la db
            Dim usr = Membresia.ObtenerUsuario()

            For Each row As GridViewRow In From row1 As GridViewRow In gvLotes.Rows Where CType(Me.gvLotes.Rows(row1.RowIndex).FindControl("nbCantidad"), TextBox).Text.Trim <> String.Empty
                Dim detalleMov As New SAB_ALM_DETALLEMOVIMIENTOS
                With detalleMov
                    .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
                    .IDTIPOTRANSACCION = EnumHelpers.TiposTransaccion.Salida
                    .IDMOVIMIENTO = Movimiento.IDMOVIMIENTO
                    .IDPRODUCTO = CType(gvLotes.DataKeys(row.RowIndex).Item("IDPRODUCTO"), Long)
                    .IDALMACEN = IDALMACEN
                    .IDLOTE = CType(gvLotes.DataKeys(row.RowIndex).Item("IDLOTE"), Long?)
                    .CANTIDAD = CType(CType(gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), TextBox).Text, Decimal)
                    .MONTO = 0
                    .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    .AUFECHACREACION = Now
                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    .AUFECHAMODIFICACION = Now
                End With

                Dim operacionLote As New OperacionesLotes

                With operacionLote
                    .CantidadReservada = 1
                    Select Case ddlTIPOMOVIMIENTOS1.SelectedValue
                        Case 3 'vencida
                            .CantidadVencida = 2
                        Case 4 'no disponible
                            .CantidadNoDisponible = 2
                            detalleMov.CANTIDADNODISPONIBLE = 1
                        Case 5 'temporal
                            .CantidadTemporal = 2
                        Case Else 'disponible
                            .CantidadDisponible = 2
                    End Select
                End With
                'Si existe un error hace un rollback y envía el error
                Try
                    Using db As New SinabEntities
                        SINAB_Entidades.Helpers.AlmacenHelpers.Lotes.Actualizar(db, detalleMov, operacionLote)
                        DetallesMovimiento.Agregar(detalleMov, db)
                        db.SaveChanges()
                    End Using
                Catch ex As Exception
                    Throw New Exception("Error al actualizar Lotes y guardar el Detalle:" + ex.Message)
                End Try
            Next

            'Carga del detalle del movimiento en el datagrid
            gvLista.Visible = CargarListaProductos()
            btnCerrar.Enabled = gvLista.Visible
            btnImprimir.Enabled = gvLista.Visible

            Limpiar(False)
            plDatosProducto.Visible = False
            If txtProducto.Visible Then txtProducto.Focus()

        Catch ex As Exception
            Limpiar(True)
            Alert(" Error al actualizar: " + ex.Message)
        End Try


        ModalPup.Hide()

    End Sub

    Private Function CargarListaProductos() As Boolean
        Dim usr = Membresia.ObtenerUsuario()

        Dim ds = Documentos.ObtenerDetalleProductos(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO, CType(Movimiento.IDMOVIMIENTO, Integer), EnumHelpers.TiposTransaccion.Salida)
        If ds.Any() Then
            gvLista.DataSource = ds
            gvLista.DataBind()
            Return True
        End If

        gvLista.DataSource = Nothing
        gvLista.DataBind()
        Return False
    End Function

    Private Function VerificarDuplicado() As Boolean
        Dim encontrado = False
        For Each row As GridViewRow In gvLotes.Rows
            If CType(gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), TextBox).Text.Trim <> String.Empty Then
                encontrado = gvLista.DataKeys.Cast(Of System.Web.UI.WebControls.DataKey)().Any(Function(item) item("IDLOTE") = gvLotes.DataKeys(row.RowIndex).Item("IDLOTE"))
            End If

            If encontrado Then
                Alert("Lote " + gvLotes.DataKeys(row.RowIndex).Item("CODIGO").ToString + " ya ingresado.")
                gvLotes.Rows(0).Focus()
                Exit For
            End If
        Next
        Return encontrado
    End Function

    Protected Sub rbTipoDespacho_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbTipoDespacho.SelectedIndexChanged

        Select Case rbTipoDespacho.SelectedValue
            Case 1
                lblTipoDespachoIndividual.Visible = True
                ddlTIPOMOVIMIENTOS1.Visible = True

                plBuscarDistribucion.Visible = False
                plEncabezado.Visible = True
                gvLista.Visible = True
                plGenerales.Visible = True

                plAgregarProducto.Visible = True
                Limpiar()

            Case 2
                lblTipoDespachoIndividual.Visible = False
                ddlTIPOMOVIMIENTOS1.Visible = False

                plBuscarDistribucion.Visible = True

                ddlFUENTEFINANCIAMIENTOS1.Recuperar()
                ddlESTABLECIMIENTOS2.RecuperarOrdenada(1)

            Case 3
                lblTipoDespachoIndividual.Visible = False
                ddlTIPOMOVIMIENTOS1.Visible = False
                plBuscarDistribucion.Visible = False
                Response.Redirect("~/ALMACEN/FrmDetMantDespachoRequisicionI.aspx")
        End Select

        rbTipoDespacho.Visible = False

    End Sub

    Protected Sub btnBuscarDistribucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarDistribucion.Click

        Dim cPD As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMADISTRIBUCION

        Dim ds As Data.DataSet
        ds = cPD.BuscarProgramaParaDespacho(ddlESTABLECIMIENTOS2.SelectedValue, ddlFUENTEFINANCIAMIENTOS1.SelectedValue, ddlSUMINISTROS1.SelectedValue)

        If ds.Tables(0).Rows.Count = 0 Then
            Alert("No se encontró ningún programa de distribución pendiente para el criterio de búsqueda seleccionado.")
            'MsgBox1.ShowAlert("No se encontró ningún programa de distribución pendiente para el criterio de búsqueda seleccionado.", "w", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            plBuscarDistribucion.Visible = False
            plEncabezado.Visible = True
            plGenerales.Visible = True
            gvProgramaDistribucion.DataSource = ds
            gvProgramaDistribucion.DataBind()
            gvProgramaDistribucion.Columns(0).Visible = False
        End If
    End Sub

    Protected Sub ddlESTABLECIMIENTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlESTABLECIMIENTOS1.SelectedIndexChanged
        RecuperarAlmacenEstablecimiento(ddlESTABLECIMIENTOS1.SelectedValue)
        'si es farmacia
        If ddlESTABLECIMIENTOS1.SelectedItem.Text.ToLower.Contains("farmacia") Then
            esFarmacia = True
            'btnCerrar.Visible = False
            'btnProcesar.Visible = True
        Else
            esFarmacia = False
            'btnCerrar.Visible = True
            'btnProcesar.Visible = False
        End If

        'filtrar los productos q se distribuiran a ese establecimiento basado en una distribucion
        Dim cD As New ABASTECIMIENTOS.NEGOCIO.cDistribucion
        Me.GridView1.DataSource = cD.ListaProductosPorEstabyDistribucion(Me.DropDownList2.SelectedValue, Session("IdEstablecimiento"), Me.ddlESTABLECIMIENTOS1.SelectedValue)
        Me.GridView1.DataBind()
        Me.GridView1.Visible = True

    End Sub

    Protected Sub btnActivarFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActivarFiltro.Click
        Limpiar()
        If btnActivarFiltro.Text = "Activar filtro para selección" Then
            plFiltroSeleccion.Visible = True
            ddlTIPOSUMINISTROS1.Recuperar()
            ddlGRUPOS1.RecuperarListaFiltrada(ddlTIPOSUMINISTROS1.SelectedValue)
            ddlSUBGRUPOS1.RecuperarListaFiltrada(ddlGRUPOS1.SelectedValue)
            ddlCATALOGOPRODUCTOS1.RecuperarProductosConExistencia(IDALMACEN, ddlSUBGRUPOS1.SelectedValue)
            btnActivarFiltro.Text = "Ocultar filtro para selección"
        Else
            rdblCriterio.SelectedValue = 0
            ddlCATALOGOPRODUCTOS1.Visible = False
            txtProducto.Visible = True
            btnBuscar.Visible = True
            'btnActivarFiltro.Visible = False
            plFiltroSeleccion.Visible = False
            ddlCATALOGOPRODUCTOS1.RecuperarProductosConExistencia(IDALMACEN)
        End If
    End Sub

    Protected Sub ddlTIPOSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTIPOSUMINISTROS1.SelectedIndexChanged
        ddlGRUPOS1.RecuperarListaFiltrada(ddlTIPOSUMINISTROS1.SelectedValue)
        ddlSUBGRUPOS1.RecuperarListaFiltrada(ddlGRUPOS1.SelectedValue)
        ddlCATALOGOPRODUCTOS1.RecuperarProductosConExistencia(IDALMACEN, ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        ddlSUBGRUPOS1.RecuperarListaFiltrada(ddlGRUPOS1.SelectedValue)
        ddlCATALOGOPRODUCTOS1.RecuperarProductosConExistencia(IDALMACEN, ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        ddlCATALOGOPRODUCTOS1.RecuperarProductosConExistencia(IDALMACEN, ddlSUBGRUPOS1.SelectedValue)
    End Sub

    Protected Sub gvLotes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLotes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("id", e.Row.ClientID)

            Dim nb As TextBox = CType(e.Row.FindControl("nbCantidad"), TextBox)

            nb.Attributes.Add("onFocus", e.Row.ClientID + ".className = 'GridListHighLight'")

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    nb.Attributes.Add("onBlur", e.Row.ClientID + ".className = '" + sender.RowStyle.CssClass + "'")
                Case DataControlRowState.Alternate
                    nb.Attributes.Add("onBlur", e.Row.ClientID + ".className = '" + sender.AlternatingRowStyle.CssClass + "'")
                Case DataControlRowState.Selected
            End Select
        End If
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            _total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(8).Text = "Total:"
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(9).Text = _total.ToString("c4")
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
        End If

    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim obj = gvLista.DataKeys(e.RowIndex).Values
        Dim operacionlote As New OperacionesLotes
        Dim usr = Membresia.ObtenerUsuario()
        Dim detalleMovimiento = New SAB_ALM_DETALLEMOVIMIENTOS

        With detalleMovimiento
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDTIPOTRANSACCION = TiposTransaccion.Salida
            .IDMOVIMIENTO = Movimiento.IDMOVIMIENTO
            .IDDETALLEMOVIMIENTO = CType(obj.Item("IDDETALLEMOVIMIENTO"), Long)
            .IDALMACEN = usr.Almacen.IDALMACEN
            .IDLOTE = CType(obj.Item("IDLOTE"), Long?)
            .CANTIDAD = CType(obj.Item("CANTIDAD"), Decimal)
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .AUFECHAMODIFICACION = Now
        End With

        With operacionlote
            Select Case ddlTIPOMOVIMIENTOS1.SelectedValue
                Case 3 'Buscar solamente lotes con cantidad vencidas.
                    .CantidadVencida = 1
                Case 4 'Buscar solamante lotes con cantidad no disponible.
                    .CantidadNoDisponible = 1
                Case 5 'Buscar solamente lotes con cantidad en almacenamiento temporal.
                    .CantidadTemporal = 1
                Case Else 'Buscar solamente lotes con cantidad disponible.
                    .CantidadDisponible = 1
            End Select
            .CantidadReservada = 2
        End With


        'Elimina el detalle de detallesmovimiento y actualiza las cantidades, luego guarda en la db
        Try
            Using db As New SinabEntities
                DetallesMovimiento.Eliminar(db, detalleMovimiento)
                SINAB_Entidades.Helpers.AlmacenHelpers.Lotes.Actualizar(db, detalleMovimiento, operacionlote)

                'guarda los resultados en la based de datos
                db.SaveChanges()

                'Carga del detalle del movimiento en el datagrid
                gvLista.Visible = CargarListaProductos()
                btnCerrar.Enabled = gvLista.Visible
                If Not gvLista.Visible Then
                    ddlSUMINISTROS1.Enabled = True
                End If

                Limpiar(False)
                If txtProducto.Visible Then txtProducto.Focus()
            End Using
        Catch ex As Exception
            Alert("Error: " + ex.Message)
        End Try
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click

        If gvLista.Rows.Count > 0 And Movimiento IsNot Nothing Then
            Confirm("El vale no ha sido guardado. ¿Confirma que desea salir sin guardar?", "Guardar", OptionPostBack.YesPostBack)
            'MsgBox1.ShowConfirm("", "s", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)
        Else
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub

    Protected Sub cbVerTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        Dim usr = Membresia.ObtenerUsuario()
        Using db As New SinabEntities
            If cbVerTodos.Checked Then
                CatalogoHelpers.Establecimientos.CargarPorZonaAlmacenALista(db, IDALMACEN, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                RecuperarAlmacenEstablecimiento(CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer))
                joker = 0
            Else
                If usr.TIPOESTABLECIMIENTO.IDTIPOESTABLECIMIENTO = 3 Or usr.TIPOESTABLECIMIENTO.IDTIPOESTABLECIMIENTO = 8 Then
                    LugaresEntrega.CargarLugaresEntregaHospitalALista(db, IDALMACEN, ddlESTABLECIMIENTOS1)
                    RecuperarAlmacenEstablecimiento(0)
                    joker = 1
                Else
                    Helpers.CatalogoHelpers.Establecimientos.CargarPorZonaAlmacenALista(db, IDALMACEN, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                    RecuperarAlmacenEstablecimiento(CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer))
                    joker = 0
                End If

            End If
        End Using
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        RestablecerCriterio()
    End Sub


#End Region

#Region "Metodos protegidos"
    Protected Sub GuardarOSalirConfirmacion(ByVal argumento As Object)
        If Convert.ToBoolean(argumento) Then
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub

    Protected Sub AfterUserConfirmationHandler(ByVal eventArgument As Object)
        If Convert.ToBoolean(ConfirmArgument) Then
            Response.Redirect("~/ALMACEN/FrmDetMantDespacharProductosDistribucion.aspx?IdMov=0" + "&IdAlm=" + IDALMACEN.ToString, False)
        Else
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub


    Protected Sub ActualizarDatosVale()

        With Vale
            .IDTIPOIDENTIFICACION = CType(ddlTIPOIDENTIFICACION1.SelectedValue, Short?)
            .NUMEROIDENTIFICACION = txtNumeroDocumento.Text
            .OBSERVACION = txtObservacion.Text
            .TRANSPORTISTA = txtTransportista.Text
            .MATRICULAVEHICULO = txtMatricula.Text
            .PERSONARECIBE = txtRecibe.Text
        End With

        AlmacenHelpers.ValesSalida.Actualizar(Vale)
    End Sub

    Protected Sub ActualizarDatosMovimiento()
        Dim usr = Membresia.ObtenerUsuario()

        With Movimiento
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDUNIDADSOLICITA = usr.Dependencia.IDDEPENDENCIA
            .FECHAMOVIMIENTO = Date.Parse(cpFechaDespacho.Text)
            .IDTIPOTRANSACCION = TiposTransaccion.Salida
            .EMPLEADOALMACEN = txtEmpleadoAlmacen.Text
            .EMPLEADOPREPARA = txtEMPLEADOPREPARA.Text
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        End With

        If Session.Item("idTipoEstablecimiento") = 3 Or Session.Item("idTipoEstablecimiento") = 8 Then
            If joker = 1 Then
                Movimiento.ID_LUGAR_ENTREGA_HOSPITAL = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
                Movimiento.IDESTABLECIMIENTODESTINO = Nothing
            Else
                Movimiento.ID_LUGAR_ENTREGA_HOSPITAL = Nothing
                Movimiento.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
            End If
            Movimiento.IDALMACENDESTINO = CType(IIf(ddlALMACENES1.Visible, ddlALMACENES1.SelectedValue, Nothing), Integer?)
        Else
            Movimiento.IDESTABLECIMIENTODESTINO = CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer?)
            Movimiento.IDALMACENDESTINO = CType(ddlALMACENES1.SelectedValue, Integer?)
        End If

        'actualizar movimiento en db
        'todo: check about actualizar
        AlmacenHelpers.Movimientos.Actualizar(Movimiento)
    End Sub

    Protected Sub DeshabilitarDobleClickBotones()
        btnAgregarLote.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnAgregarLote.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnAgregarLote, Nothing) + ";"
        btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnGuardar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnGuardar, Nothing) + ";"
        btnCerrar.OnClientClick = "if(!confirm('Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?')) return false; if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnCerrar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnCerrar, Nothing) + ";"
        'btnImprimir.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnCerrarConteo, Nothing) + ";"
    End Sub
#End Region

#Region "Metodos Privados"
    Private Sub CerrarVale()

        If Movimiento Is Nothing And Vale Is Nothing Then
            Alert("No existe Documento asociado, Guarde el documento antes de procesarlo")
        End If


        Try
            'actualizar el movimiento
            Movimiento.AUFECHAMODIFICACION = Now
            Movimiento.IDESTADO = EstadosMovimiento.Cerrado
            ActualizarDatosMovimiento()

            'actualizar el vale de salida
            With Vale
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .AUFECHAMODIFICACION = Now
                '.IDVALE = CType(Movimiento.IDDOCUMENTO, Integer)
            End With
            ActualizarDatosVale()

            ddlTIPOMOVIMIENTOS1.Enabled = False

            CrearValeEntradaXTransferencia()


            'verificar si lista de distribucion pasa a finalizado
            Dim x As New cDistribucion
            Dim dsv As New DataSet
            dsv = x.verificarLista(Me.Label3.Text, Session("IdEstablecimiento"))
            If dsv.Tables(0).Rows.Count = 0 Then
                'cambiar estado a FINALIZADO
                x.actualizarEstadoDistribucion(Label3.Text, Session("IdEstablecimiento"), 4, "abas", 0)
            End If


            Confirm("El vale ha sido cerrado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", OptionPostBack.YesNotPostBack)
        Catch ex As Exception
            Alert("Error:" & ex.Message)
        End Try

    End Sub

    Public Sub CrearValeEntradaXTransferencia()
        Dim eRR As New ABASTECIMIENTOS.ENTIDADES.RECIBOSRECEPCION
        Dim cRR As New cRECIBOSRECEPCION
        Dim eM As New ABASTECIMIENTOS.ENTIDADES.MOVIMIENTOS
        Dim cM As New cMOVIMIENTOS
        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim cL As New cLOTES
        Dim cU As New cUBICACIONESPRODUCTOS
        Dim cAEC As New cALMACENESENTREGACONTRATOS

        'RECIBOSRECEPCION
        eRR.IDALMACEN = Me.ddlALMACENES1.SelectedValue
        eRR.ANIO = Date.Now.Year
        eRR.IDRECIBO = 0
        eRR.RESPONSABLEPROVEEDOR = ""
        eRR.NUMEROACTA = 0
        eRR.OBSERVACION = ""
        eRR.IDALMACENVALE = 42
        eRR.NUMEROVALE = Vale.IDVALE.ToString
        eRR.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eRR.AUFECHACREACION = Now()

        cRR.ActualizarRECIBOSRECEPCION(eRR)

        Dim anio, idrecibo As Integer
        anio = eRR.ANIO
        idrecibo = eRR.IDRECIBO

        'MOVIMIENTOS
        eM.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
        eM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionPorTransferencia
        eM.IDMOVIMIENTO = 0

        eM.IDALMACEN = Me.ddlALMACENES1.SelectedValue
        eM.ANIO = anio
        eM.IDDOCUMENTO = idrecibo

        eM.IDESTADO = eESTADOSMOVIMIENTOS.Grabado

        eM.FECHAMOVIMIENTO = Date.Now

        eM.CLASIFICACIONMOVIMIENTO = 1
        eM.SUBCLASIFICACIONMOVIMIENTO = 1

        eM.EMPLEADOALMACEN = ""

        eM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eM.AUFECHACREACION = Now()

        cM.ActualizarMOVIMIENTOS(eM)

        Dim idmov As Integer
        idmov = eM.IDMOVIMIENTO


        Dim CDist As New cDistribucion
        'barrido por producto
        For Each DataRow As GridViewRow In Me.gvLista.Rows


            Dim FechaVto As Date
            FechaVto = New Date(Year(gvLista.DataKeys(DataRow.RowIndex).Values(4)), Month(gvLista.DataKeys(DataRow.RowIndex).Values(4)), 1)
            FechaVto = DateAdd(DateInterval.Month, 1, FechaVto)
            FechaVto = DateAdd(DateInterval.Day, -1, FechaVto)

            Dim eL As New ABASTECIMIENTOS.ENTIDADES.LOTES
            Dim eUP As New ABASTECIMIENTOS.ENTIDADES.UBICACIONESPRODUCTOS
            Dim cUP As New cUBICACIONESPRODUCTOS
            Dim eDM As New DETALLEMOVIMIENTOS


            eL.IDALMACEN = Me.ddlALMACENES1.SelectedValue
            eL.IDLOTE = 0

            'LOTES
            Dim u As New cCATALOGOPRODUCTOS
            eL.IDPRODUCTO = gvLista.DataKeys(DataRow.RowIndex).Values(2)
            eL.IDUNIDADMEDIDA = u.DevolverIDUMProducto(gvLista.DataKeys(DataRow.RowIndex).Values(2))
            eL.CODIGO = gvLista.DataKeys(DataRow.RowIndex).Values(5)
            eL.DETALLE = ""
            eL.PRECIOLOTE = CDec(DataRow.Cells(8).Text)
            eL.FECHAVENCIMIENTO = FechaVto

            Dim lo As New cLOTES
            Dim dsRF As New DataSet
            dsRF = lo.ObtenerRespyFF(42, gvLista.DataKeys(DataRow.RowIndex).Values(2), gvLista.DataKeys(DataRow.RowIndex).Values(0))
            eL.IDRESPONSABLEDISTRIBUCION = dsRF.Tables(0).Rows(0).Item(0)
            eL.IDFUENTEFINANCIAMIENTO = dsRF.Tables(0).Rows(0).Item(1)
            eL.CANTIDADDISPONIBLE = gvLista.DataKeys(DataRow.RowIndex).Values(3)
            eL.ESTADISPONIBLE = 0
            eL.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eL.AUFECHACREACION = Now

            cL.ActualizarLOTES(eL)

            'DETALLEMOVIMIENTOS
            eDM.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
            eDM.IDTIPOTRANSACCION = eTIPOTRANSACCION.RecepcionPorTransferencia
            eDM.IDMOVIMIENTO = idmov
            eDM.IDDETALLEMOVIMIENTO = 0

            eDM.IDALMACEN = Me.ddlALMACENES1.SelectedValue
            eDM.IDLOTE = eL.IDLOTE
            eDM.IDPRODUCTO = eL.IDPRODUCTO
            eDM.CANTIDAD = eL.CANTIDADDISPONIBLE
            eDM.MONTO = 0

            eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eDM.AUFECHACREACION = Now

            cDM.ActualizarDETALLEMOVIMIENTOS(eDM)

            'UBICACIONESPRODUCTOS
            eUP.IDALMACEN = Me.ddlALMACENES1.SelectedValue
            eUP.IDPRODUCTO = eL.IDPRODUCTO
            eUP.IDUBICACION = 0
            eUP.UBICACION = ""
            eUP.IDLOTE = eL.IDLOTE
            eUP.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eUP.AUFECHACREACION = Now()

            cUP.ActualizarUBICACIONESPRODUCTOS(eUP)

            'ACTUALIZAR CANTIDADDISTRIBUIDA y fecha DE SAB_EST_DISTRIBUCIONESCERRADAS
            CDist.ActualizarCantidadDistribuida(Me.Label3.Text, Session("IdEstablecimiento"), Me.ddlESTABLECIMIENTOS1.SelectedValue, eL.IDPRODUCTO, eL.CANTIDADDISPONIBLE)

            'INSERTAR EN TABLA TRAZABILIDAD
            CDist.ActualizarTrazabilidad(Me.DropDownList2.SelectedValue, Session("IdEstablecimiento"), 42, eL.IDPRODUCTO, Vale.IDVALE, Date.Now.ToString("dd/MM/yyyy"), eL.CANTIDADDISPONIBLE, Me.ddlALMACENES1.SelectedValue, idrecibo, Date.Now.ToString("dd/MM/yyyy"), eL.CANTIDADDISPONIBLE, Vale.IDVALE.ToString)


        Next


    End Sub

    Private Sub DDLAlamcenesVisible()
        ddlALMACENES1.Visible = cbVerTodos.Checked
        lblNoAlmacenAsociado.Visible = Not cbVerTodos.Checked
    End Sub

    Private Sub CargarDatos(ByVal IDMOVIMIENTO As Integer)
        Try


            Dim usr = Membresia.ObtenerUsuario()

            Movimiento = AlmacenHelpers.Movimientos.Obtener(IDMOVIMIENTO, TiposTransaccion.Salida, usr.ESTABLECIMIENTO.IDESTABLECIMIENTO) 'CType(Session.Item("IdEstablecimiento"), Integer))
            Dim suministros As New CatalogoHelpers.Suministros

            'todo: comprobar que dss y ds devuelvan los mismos datos
            Dim dss = suministros.ObtenerPorMovimiento(Movimiento.IDESTABLECIMIENTO, Movimiento.IDTIPOTRANSACCION, CType(Movimiento.IDMOVIMIENTO, Integer))
            'Dim ds As Data.DataSet
            'Dim detallesMovimiento As New cDETALLEMOVIMIENTOS
            'ds = detallesMovimiento.ObtenerSuministrosMovimiento(Movimiento.IDESTABLECIMIENTO, Movimiento.IDTIPOTRANSACCION, CType(Movimiento.IDMOVIMIENTO, Integer))

            If dss > 0 Then
                'ddlSUMINISTROS1.SelectedValue = ds.Tables(0).Rows(0).Item("IDSUMINISTRO")
                ddlSUMINISTROS1.SelectedValue = CType(dss, String)
                ddlSUMINISTROS1.Enabled = False
            Else
                ddlSUMINISTROS1.SelectedValue = CType(usr.SUMINISTRO.IDSUMINISTRO, String)
            End If

            If rbTipoDespacho.Visible Then
                rbTipoDespacho.SelectedValue = CType(Movimiento.CLASIFICACIONMOVIMIENTO, String)
            End If

            ddlTIPOMOVIMIENTOS1.SelectedValue = CType(Movimiento.SUBCLASIFICACIONMOVIMIENTO, String)
            lblTipoDespachoIndividual.Visible = True
            ddlTIPOMOVIMIENTOS1.Enabled = False
            ddlTIPOMOVIMIENTOS1.Visible = True


            cpFechaDespacho.Text = CType(Movimiento.FECHAMOVIMIENTO, String)
            Dim lugar = Movimiento.ID_LUGAR_ENTREGA_HOSPITAL
            If Movimiento.IDESTABLECIMIENTODESTINO Is Nothing Then Movimiento.IDESTABLECIMIENTODESTINO = 0
            If Movimiento.IDALMACENDESTINO Is Nothing Then Movimiento.IDALMACENDESTINO = 0
            Using db As New SinabEntities
                If Not usr.TIPOESTABLECIMIENTO.IDTIPOESTABLECIMIENTO = 3 Or usr.TIPOESTABLECIMIENTO.IDTIPOESTABLECIMIENTO = 8 Then

                    If ddlESTABLECIMIENTOS1.Items.FindByValue(CType(Movimiento.IDESTABLECIMIENTODESTINO, String)) Is Nothing Then
                        cbVerTodos.Checked = True
                        CatalogoHelpers.Establecimientos.CargarPorZonaAlmacenALista(db, IDALMACEN, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                    End If
                    ddlESTABLECIMIENTOS1.SelectedValue = CType(Movimiento.IDESTABLECIMIENTODESTINO, String)
                    RecuperarAlmacenEstablecimiento(CType(Movimiento.IDESTABLECIMIENTODESTINO, Integer))
                    ddlALMACENES1.SelectedValue = CType(Movimiento.IDALMACENDESTINO, String)
                Else

                    If ddlESTABLECIMIENTOS1.Items.FindByValue(CType(lugar, String)) Is Nothing Then
                        cbVerTodos.Checked = True
                        CatalogoHelpers.Establecimientos.CargarPorZonaAlmacenALista(db, IDALMACEN, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                        ddlESTABLECIMIENTOS1.SelectedValue = CType(Movimiento.IDESTABLECIMIENTODESTINO, String)
                        RecuperarAlmacenEstablecimiento(CType(Movimiento.IDESTABLECIMIENTODESTINO, Integer))
                        ddlALMACENES1.SelectedValue = CType(Movimiento.IDALMACENDESTINO, String)
                    Else
                        joker = 1
                        cbVerTodos.Checked = False
                        LugaresEntrega.CargarLugaresEntregaHospitalALista(db, IDALMACEN, ddlESTABLECIMIENTOS1)
                        ddlESTABLECIMIENTOS1.SelectedValue = CType(lugar, String)
                        RecuperarAlmacenEstablecimiento(0)
                    End If

                End If
            End Using

            If Not IsNothing(Request.QueryString("IdDis")) Then
                Me.DropDownList2.SelectedValue = Request.QueryString("IdDis")
                Me.Label3.Text = Me.DropDownList2.SelectedValue

                Dim cD As New ABASTECIMIENTOS.NEGOCIO.cDistribucion
                Me.GridView1.DataSource = cD.ListaProductosPorEstabyDistribucion(Me.DropDownList2.SelectedValue, Session("IdEstablecimiento"), Me.ddlESTABLECIMIENTOS1.SelectedValue)
                Me.GridView1.DataBind()
                Me.GridView1.Visible = True
            End If

            txtEmpleadoAlmacen.Text = Movimiento.EMPLEADOALMACEN
            txtEMPLEADOPREPARA.Text = Movimiento.EMPLEADOPREPARA

            'Carga la información del vale de salida asociado

            Vale = AlmacenHelpers.ValesSalida.Obtener(CType(Movimiento.IDDOCUMENTO, Integer), CType(Movimiento.IDALMACEN, Integer), CType(Movimiento.ANIO, Integer))

            txtNroVale.Text = Vale.IDVALE.ToString + "/" + Vale.ANIO.ToString
            lblNroVale.Visible = True
            txtNroVale.Visible = True
            boton.Visible = False

            txtObservacion.Text = Vale.OBSERVACION
            txtTransportista.Text = Vale.TRANSPORTISTA
            txtMatricula.Text = Vale.MATRICULAVEHICULO
            ddlTIPOIDENTIFICACION1.SelectedValue = CType(Vale.IDTIPOIDENTIFICACION, String)
            txtNumeroDocumento.Text = Vale.NUMEROIDENTIFICACION
            txtRecibe.Text = Vale.PERSONARECIBE



            If ddlESTABLECIMIENTOS1.SelectedItem.Text.ToLower.Contains("farmacia") Then
                esFarmacia = True
                'btnCerrar.Visible = False

                If Movimiento.IDESTADO = EstadosMovimiento.EnProceso Then
                    btnGuardar.Enabled = False
                    ddlESTABLECIMIENTOS1.Enabled = False
                    cbVerTodos.Enabled = False
                    btnCerrar.Visible = False
                ElseIf Movimiento.IDESTADO = EstadosMovimiento.AceptadoPorDependecia Then
                    btnCerrar.Visible = True
                    ddlESTABLECIMIENTOS1.Enabled = False
                    btnGuardar.Enabled = False
                    cbVerTodos.Enabled = False
                    btnCerrar.Visible = False
                End If

            End If

            If Movimiento.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado Then

                ddlESTABLECIMIENTOS1.Enabled = False
                ddlALMACENES1.Enabled = False
                cbVerTodos.Enabled = False
                cpFechaDespacho.Enabled = False

                plAgregarProducto.Visible = False
                plDatosProducto.Visible = False

                txtEMPLEADOPREPARA.Enabled = False
                txtTransportista.Enabled = False
                txtMatricula.Enabled = False
                txtRecibe.Enabled = False
                ddlTIPOIDENTIFICACION1.Enabled = False
                txtNumeroDocumento.Enabled = False
                txtEmpleadoAlmacen.Enabled = False
                txtObservacion.Enabled = False

                btnGuardar.Visible = False
                btnCerrar.Visible = False

                btnImprimir.Enabled = True

                'Carga del detalle del movimiento en el datagrid
                gvLista.Visible = CargarListaProductos()


            ElseIf Movimiento.IDESTADO = eESTADOSMOVIMIENTOS.Grabado Or Movimiento.IDESTADO = eESTADOSMOVIMIENTOS.En_proceso Then
                plAgregarProducto.Visible = True
                btnCerrar.Visible = True
                btnImprimir.Enabled = True
                txtProducto.Focus()

                'Carga del detalle del movimiento en el datagrid
                gvLista.Visible = CargarListaProductos()
                btnCerrar.Enabled = gvLista.Visible

            End If



            plEncabezado.Visible = True
            plGenerales.Visible = True
        Catch ex As Exception
            Alert(ex.Message)
        End Try
    End Sub

    Private Sub GuardarValeMovimiento()
        Try
            If Movimiento.IDMOVIMIENTO = 0 Then
                'Creacion del vale de salida
                With Vale
                    .IDALMACEN = IDALMACEN
                    .ANIO = CType(DateTime.Parse(cpFechaDespacho.Text).Year, Short)
                    .IDVALE = 0
                    .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    .AUFECHACREACION = Now()
                    .ESTASINCRONIZADA = 0

                End With
                ActualizarDatosVale()

                'movimiento
                With Movimiento
                    .IDMOVIMIENTO = 0
                    .IDALMACEN = Vale.IDALMACEN
                    .ANIO = Vale.ANIO
                    .IDDOCUMENTO = Vale.IDVALE
                    .CLASIFICACIONMOVIMIENTO = CType(rbTipoDespacho.SelectedValue, Byte)
                    .SUBCLASIFICACIONMOVIMIENTO = CType(ddlTIPOMOVIMIENTOS1.SelectedValue, Byte)
                    .AUFECHACREACION = Now()
                    .ESTASINCRONIZADA = 0
                End With

                Movimiento.IDESTADO = EstadosMovimiento.Grabado

                ActualizarDatosMovimiento()

                ddlSUMINISTROS1.Enabled = False
                txtNroVale.Text = Vale.IDVALE.ToString + "/" + Vale.ANIO.ToString
                lblNroVale.Visible = True
                txtNroVale.Visible = True
                boton.Visible = False

                'actualizar vales salida en tabla distribucionvalesalida
                Dim cx As New cDistribucion
                cx.InsertarValeSalidaDistribucion(Me.DropDownList2.SelectedValue, Vale.IDVALE)

            Else
                'actualizar el movimiento
                Movimiento.AUFECHAMODIFICACION = Now
                Movimiento.IDESTADO = EstadosMovimiento.Grabado
                ActualizarDatosMovimiento()

                'actualizar el vale de salida
                With Vale
                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    .AUFECHAMODIFICACION = Now
                    .IDVALE = CType(Movimiento.IDDOCUMENTO, Integer)
                End With
                ActualizarDatosVale()
            End If

            ddlTIPOMOVIMIENTOS1.Enabled = False
        Catch ex As Exception
            Throw New Exception("Error al generar Vale de salida:" & ex.Message)
        End Try
    End Sub



    Private Sub RestablecerCriterio()

        Limpiar()

        If rdblCriterio.SelectedValue = 0 Then
            ddlCATALOGOPRODUCTOS1.Visible = False
            txtProducto.Visible = True
            btnBuscar.Visible = True
            'btnActivarFiltro.Visible = False
            plFiltroSeleccion.Visible = False
        Else
            txtProducto.Visible = False
            btnBuscar.Visible = False
            ddlCATALOGOPRODUCTOS1.RecuperarProductosConExistencia(IDALMACEN, CType(ddlSUMINISTROS1.SelectedValue, Integer))
            ddlCATALOGOPRODUCTOS1.Visible = True
            lblCORRPRODUCTO.Visible = False
            lblDESCLARGO.Visible = False

            If ddlCATALOGOPRODUCTOS1.Items.Count > 0 Then
                Buscar(CType(ddlCATALOGOPRODUCTOS1.SelectedValue, Integer))
            End If

            'btnActivarFiltro.Visible = True
            'buscarOpcion1()
        End If

    End Sub

    Private Sub Limpiar(Optional ByVal limpiarProducto As Boolean = True)

        If limpiarProducto Then txtProducto.Text = String.Empty

        lblCORRPRODUCTO.Text = String.Empty
        lblDESCLARGO.Text = String.Empty

        gvLotes.DataSource = Nothing
        gvLotes.DataBind()

        plDatosProducto.Visible = False

    End Sub

    Private Sub CargarListas()
        Dim usr = Membresia.ObtenerUsuario()
        Dim dba As New ABASTECIMIENTOS.NEGOCIO.cDistribucion
        Try
            Using db As New SinabEntities

                CatalogoHelpers.Suministros.CargarALista(db, ddlSUMINISTROS1)
                TiposMovimiento.CargarPorTipoTransaccionALista(db, TiposTransaccion.Salida, ddlTIPOMOVIMIENTOS1)
                TiposIdentificacion.CargarALista(db, ddlTIPOIDENTIFICACION1)

                If usr.Establecimiento.IDESTABLECIMIENTO = 3 Or usr.Establecimiento.IDESTABLECIMIENTO = 8 Then
                    LugaresEntrega.CargarLugaresEntregaHospitalALista(db, IDALMACEN, ddlESTABLECIMIENTOS1)
                    RecuperarAlmacenEstablecimiento(0)
                    joker = 1
                Else
                    CatalogoHelpers.Establecimientos.CargarPorZonaAlmacenALista(db, IDALMACEN, cbVerTodos.Checked, ddlESTABLECIMIENTOS1)
                    RecuperarAlmacenEstablecimiento(CType(ddlESTABLECIMIENTOS1.SelectedValue, Integer))
                End If

            End Using

            Me.ddlAnioAbas.DataSource = dba.AniosDistribuciones()
            Me.ddlAnioAbas.DataTextField = "anio"
            Me.ddlAnioAbas.DataValueField = "anio"
            Me.ddlAnioAbas.DataBind()
            Me.ddlAnioAbas.SelectedValue = Now.Year

            Me.DropDownList2.DataSource = dba.ListaDistribucionesCerradas(Me.ddlAnioAbas.SelectedValue, Session("idestablecimiento"))
            Me.DropDownList2.DataTextField = "DESCRIPCION"
            Me.DropDownList2.DataValueField = "IDDISTRIBUCION"
            Me.DropDownList2.DataBind()

            Me.DropDownList2.Items.Insert(0, "(Seleccione distribución)")

        Catch ex As Exception
            Alert("Error en cargar listas de Lugares o Almacenes: " + ex.Message)
        End Try

    End Sub

    Private Sub RecuperarAlmacenEstablecimiento(ByVal idestablecimiento As Integer)
        Dim usr = Membresia.ObtenerUsuario()
        ddlALMACENES1.Items.Clear()

        If usr.Establecimiento.IDESTABLECIMIENTO <> 3 And usr.Establecimiento.IDESTABLECIMIENTO <> 8 And idestablecimiento > 0 Then
            CatalogoHelpers.Almacenes.CargarAlmacenesEstablecimientosALista(idestablecimiento, ddlALMACENES1)
        End If

        If ddlALMACENES1.Items.Count = 0 Then
            ddlALMACENES1.Visible = False
            lblNoAlmacenAsociado.Visible = True
            cpFechaDespacho.Focus()
        Else
            ddlALMACENES1.Visible = True
            lblNoAlmacenAsociado.Visible = False
            ddlALMACENES1.Focus()
        End If

    End Sub

    Private Sub Buscar(ByVal idproducto As Integer, Optional ByVal codigo As String = "0")

        Dim iTipo As Int16 = 0
        Select Case ddlTIPOMOVIMIENTOS1.SelectedValue
            Case 1 'Buscar solamente lotes con cantidad disponible.
                iTipo = 1
            Case 2 'Buscar lotes con cantidad disponible o vencida
                iTipo = 6
            Case 3 'Buscar solamente lotes con cantidad vencidas.
                iTipo = 3
            Case 4 'Buscar solamante lotes con cantidad no disponible.
                iTipo = 2
            Case 5 'Buscar solamente lotes con cantidad en almacenamiento temporal.
                iTipo = 5
        End Select
        'todo: checkar obtenerlotesfiltradospordistribucion con param  Me.DropDownList2.SelectedValue
        Dim ds = AlmacenHelpers.Lotes.ObtenerLotesFiltrados(IDALMACEN, CType(ddlSUMINISTROS1.SelectedValue, Integer), idproducto, codigo, iTipo)

        'Dim dt As New DataSet
        'dt = GetDataSetHacked(ds)

        'Dim c As New cDistribucion
        'Dim dt2 As New DataSet
        'dt2 = c.ObtenerLotesDistribucion(Me.DropDownList2.SelectedValue, Session("IdEstablecimiento"), idproducto, IDALMACEN)
        'Dim dtt As New DataTable
        'dtt = dt2.Tables(0).Copy

        'Dim ds2 As New DataSet
        'ds2.Tables.Add(dt.Tables(0))
        'ds2.Tables.Add(dtt)
        'ds2.Relations.Add("TheRelation", dt.Tables(0).Columns("idlote"), dtt.Columns("idlote"))


        'dt2.Columns.Add("b", [GetType](System.[String]), "Parent.b")

        If ds.Any() Then
            'gvLotes.DataSource = ds2.Tables(0)
            gvLotes.DataSource = ds
            gvLotes.DataBind()
            plDatosProducto.Visible = True
            lblCORRPRODUCTO.Text = CType(gvLotes.DataKeys(0).Values.Item("CORRPRODUCTO"), String)
            lblCORRPRODUCTO.Visible = True
            lblDESCLARGO.Text = CType(gvLotes.DataKeys(0).Values.Item("DESCLARGO"), String)
            lblDESCLARGO.Visible = True
            gvLotes.Rows(0).Focus()
            ModalPup.Show()
        Else
            Alert("No se encontró ningún lote disponible para este producto.")
            If txtProducto.Visible Then txtProducto.Focus()
        End If

    End Sub
#End Region

    Private _idalmacen As Integer
    Private _anio As Integer
    Private _joker As Integer
    Private _total As Decimal = 0


    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            GuardarValeMovimiento()
            Limpiar()
            CargarDatos(CType(Movimiento.IDMOVIMIENTO, Integer))

            btnCerrar.Enabled = True
            btnImprimir.Enabled = True
            If txtProducto.Visible Then txtProducto.Focus()

            Confirm("El vale " + txtNroVale.Text + " se ha guardado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", OptionPostBack.YesNotPostBack)
        Catch ex As Exception
            Alert("Error al guardar Documento: " + ex.Message)
        End Try

        'MsgBox1.ShowConfirm("El vale " + txtNroVale.Text + " se ha guardado satisfactoriamente. ¿Desea crear uno nuevo?", "Nuevo", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)

        'End If
    End Sub

    Protected Sub ddlAnioAbas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAnioAbas.SelectedIndexChanged
        Dim dba As New ABASTECIMIENTOS.NEGOCIO.cDistribucion
        Me.DropDownList2.DataSource = dba.ListaDistribucionesCerradas(Me.ddlAnioAbas.SelectedValue, Session("idestablecimiento"))
        Me.DropDownList2.DataTextField = "DESCRIPCION"
        Me.DropDownList2.DataValueField = "IDDISTRIBUCION"
        Me.DropDownList2.DataBind()
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        ' filtrar suministro de la distribucion seleccionada
        Dim dba As New ABASTECIMIENTOS.NEGOCIO.cDistribucion
        Me.ddlSUMINISTROS1.SelectedValue = dba.ObtenerSuministroDistribucion(Me.DropDownList2.SelectedValue, Session("idestablecimiento"))
        Me.Label3.Text = Me.DropDownList2.SelectedValue

        'filtrar establecimientos segun la distribucion seleccionada

        Me.ddlESTABLECIMIENTOS1.DataSource = dba.ListaEstablecimientosPorDistribucion(Me.DropDownList2.SelectedValue, Session("idestablecimiento"))
        Me.ddlESTABLECIMIENTOS1.DataTextField = "nombre"
        Me.ddlESTABLECIMIENTOS1.DataValueField = "idestablecimiento"
        Me.ddlESTABLECIMIENTOS1.DataBind()

        Me.ddlESTABLECIMIENTOS1.Items.Insert(0, "Seleccione un establecimiento")

    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
    '    Dim idproducto As Integer
    '    idproducto = Me.GridView1.SelectedDataKey("IDPRODUCTO")


    'End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

        Dim btn As Button = TryCast(sender, Button)

        Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)

        Dim IDPRODUCTO As Integer = GridView1.DataKeys(row.RowIndex).Values(0).ToString()

        Me.Label4.Text = GridView1.Rows(row.RowIndex).Cells(3).Text
        Buscar(IDPRODUCTO)

    End Sub
    Public Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As New DataTable()
        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

    Private Function GetDataSetHacked(Of T)(ByVal _
         list As List(Of T)) As DataSet
        Dim _resultDataSet As New DataSet()
        Dim _resultDataTable As New DataTable("results")
        Dim _resultDataRow As DataRow = Nothing
        Dim _itemProperties() As PropertyInfo = list.Item(0).GetType().GetProperties()
        Dim _callPropertyValue(_itemProperties.Length()) As _getPropertyDelegate(Of T)

        '
        ' Meta Data.
        ' Each item property becomes a column in the table 
        ' Build an array of Property Getters, one for each Property 
        ' in the item class. Can pass anything as [item] it is just a 
        ' place holder parameter, later we will invoke it with the
        ' correct item. This code assumes the runtime does not change
        ' the ORDER in which the proprties are returned.
        '
        _itemProperties = list.Item(0).GetType().GetProperties()
        Dim i As Integer = 0

        For Each p As PropertyInfo In _itemProperties
            _callPropertyValue(i) = CreateGetPropertyValueDelegate(CType(list.Item(0), T), p.Name)
            _resultDataTable.Columns.Add(p.Name, p.GetGetMethod.ReturnType())
            i += 1
        Next
        '    
        ' Data    
        '
        For Each item As T In list
            '
            ' Get the data from this item into a DataRow
            ' then add the DataRow to the DataTable.
            ' Eeach items property becomes a colunm.
            '
            _itemProperties = item.GetType().GetProperties()
            _resultDataRow = _resultDataTable.NewRow()
            i = 0
            For Each p As PropertyInfo In _itemProperties
                _resultDataRow(p.Name) = _
                   _callPropertyValue(i).Invoke(item)
                i += 1
            Next
            _resultDataTable.Rows.Add(_resultDataRow)
        Next
        '    
        ' Add the DataTable to the DataSet, We are DONE!
        '
        _resultDataSet.Tables.Add(_resultDataTable)
        Return _resultDataSet


    End Function
    '
    ' Delegate to call DynamicMethod
    '
    Private Delegate Function _
           _getPropertyDelegate(Of T)(ByVal _
           item As T) As Object
    '
    ' Builds a Dynamic Method to read the peoperty of an object
    '
    Private Function CreateGetPropertyValueDelegate(Of T)(ByVal _
            item As T, ByVal itemName As Object) As  _
            _getPropertyDelegate(Of T)

        Dim _arg() As Type = {GetType(T)}
        Dim _propertyInfo As PropertyInfo = _
            item.GetType().GetProperty(itemName, _
            BindingFlags.Public Or BindingFlags.Instance)
        Dim _getPropertyValue As DynamicMethod = Nothing
        Dim _ilGenerator As ILGenerator = Nothing

        '
        ' Create the funciton
        '
        _getPropertyValue = New DynamicMethod("_getPropertyValue", _
                            GetType(Object), _arg, _
                            GetType(Integer).Module)
        '
        ' Write the body of the function.
        '
        _ilGenerator = _getPropertyValue.GetILGenerator()
        _ilGenerator.Emit(OpCodes.Ldarg_0)
        _ilGenerator.Emit(OpCodes.Callvirt, _propertyInfo.GetGetMethod())
        ' Box value types.
        If Not _propertyInfo.PropertyType.IsClass Then

        End If
        _ilGenerator.Emit(OpCodes.Box, _
                     _propertyInfo.GetGetMethod.ReturnType())
        _ilGenerator.Emit(OpCodes.Ret)
        '
        ' Return the Delegate
        '
        Return CType(_getPropertyValue.CreateDelegate(GetType(_getPropertyDelegate(Of T))),  _
                 _getPropertyDelegate(Of T))
    End Function
End Class
