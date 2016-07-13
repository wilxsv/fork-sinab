
Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades
Imports ABASTECIMIENTOS.DATOS
Imports Cooperator.Framework.Web.Controls

Partial Class ALMACEN_frmDetaMantDespacharProductosPreOrdenados
    Inherits System.Web.UI.Page

    Protected Sub lnkMenu_Click(sender As Object, e As System.EventArgs) Handles lnkMenu.Click
        'If Me.gvLista.Rows.Count > 0 And Me.IDMOVIMIENTO = 0 Then
        '    Me.MsgBox1.ShowConfirm("El vale no ha sido guardado. ¿Confirma que desea salir sin guardar?", "s", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)
        'Else
        Response.Redirect("~/FrmPrincipal.aspx", False)
        'End If
    End Sub

#Region "Propiedades Públicas"
    Public Property Suministro As SAB_CAT_SUMINISTROS
        Get
            Return _suministro
        End Get
        Set(value As SAB_CAT_SUMINISTROS)
            _suministro = value
            If Not Me.ViewState("SUMINISTRO") Is Nothing Then Me.ViewState.Remove("SUMINISTRO")
            Me.ViewState.Add("SUMINISTRO", _suministro)
        End Set
    End Property

    Public Property Establecimiento As SAB_CAT_ESTABLECIMIENTOS
        Get
            Return _establecimiento
        End Get
        Set(value As SAB_CAT_ESTABLECIMIENTOS)
            _establecimiento = value
            If Not Me.ViewState("ESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("ESTABLECIMIENTO")
            Me.ViewState.Add("ESTABLECIMIENTO", _establecimiento)
        End Set
    End Property

    Public Property Almacen As SAB_CAT_ALMACENES
        Get
            Return _almacen
        End Get
        Set(value As SAB_CAT_ALMACENES)
            _almacen = value
            If Not Me.ViewState("ALMACEN") Is Nothing Then Me.ViewState.Remove("ALMACEN")
            Me.ViewState.Add("ALMACEN", _almacen)
        End Set
    End Property

    Public Property ValeSalida As SAB_ALM_VALESSALIDA
        Get
            Return _valesalida
        End Get
        Set(value As SAB_ALM_VALESSALIDA)
            _valesalida = value
            If Not Me.ViewState("VALESSALIDA") Is Nothing Then Me.ViewState.Remove("VALESSALIDA")
            Me.ViewState.Add("VALESSALIDA", _valesalida)
        End Set
    End Property

    Public Property Movimiento As SAB_ALM_MOVIMIENTOS
        Get
            Return _movimiento
        End Get
        Set(value As SAB_ALM_MOVIMIENTOS)
            _movimiento = value
            If Not Me.ViewState("MOVIMIENTO") Is Nothing Then Me.ViewState.Remove("MOVIMIENTO")
            Me.ViewState.Add("MOVIMIENTO", _movimiento)
        End Set
    End Property


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db = New SinabEntities

        If Not IsPostBack Then
            Me.cpFechaDespacho.Text = Now.Date.ToShortDateString
            Me.cvFechaDespacho.ValueToCompare = Now.Date
        End If
    End Sub

    Protected Sub Buscar_Click(sender As Object, e As System.EventArgs) Handles Buscar.Click
        Using db As New SinabEntities
            Dim idAlmacen As Decimal = Decimal.Parse(Session.Item("IdAlmacen"))
            Dim detalles As New List(Of SAB_FARM_DETALLEREQUISICION)
            Try
                Dim req As List(Of SAB_FARM_REQUISICION) = db.SAB_FARM_REQUISICION.Where(Function(r) r.CodigoRequisicion = Me.tbBuscador.Text And r.IdAlmacen = idAlmacen).ToList

                If req IsNot Nothing Then
                    'requisicion de referencia, se toma la primera de todas las q puedan existir
                    Dim requisicion As SAB_FARM_REQUISICION = req.FirstOrDefault

                    Suministro = db.SAB_CAT_SUMINISTROS.FirstOrDefault(Function(m) m.IDSUMINISTRO = 1)
                    Dim dsmovimientos = db.SAB_CAT_TIPOMOVIMIENTOS.Where(Function(x) x.IDTIPOTRANSACCION = eTIPOTRANSACCION.Salida)

                    lblSuministro.Text = Suministro.DESCRIPCION

                    With Me.ddlMovimientos
                        .DataSource = dsmovimientos
                        .DataTextField = "DESCRIPCION"
                        .DataValueField = "IDTIPOMOVIMIENTO"
                        .DataBind()
                    End With

                    With ddlTIPOIDENTIFICACION1
                        .DataSource = db.SAB_CAT_TIPOIDENTIFICACION
                        .DataTextField = "DESCRIPCION"
                        .DataValueField = "IDTIPOIDENTIFICACION"
                    End With


                    Establecimiento = db.SAB_CAT_ESTABLECIMIENTOS.FirstOrDefault(Function(es) es.CODIGOESTABLECIMIENTO = requisicion.CodigoEstablecimiento)
                    Me.lbEstablecimiento.Text = Establecimiento.NOMBRE

                    Almacen = db.SAB_CAT_ALMACENES.FirstOrDefault(Function(al) al.IDALMACEN = requisicion.IdAlmacen)
                    Me.lblAlmacenAsociado.Text = Almacen.NOMBRE

                   

                    'recupera el detalle de la requisicion
                    For Each d As SAB_FARM_REQUISICION In req
                        detalles.AddRange(d.SAB_FARM_DETALLEREQUISICION)
                    Next
                    If Me.GuardarMovimiento(db) = 1 Then
                        Me.MsgBox1.ShowAlert("Se ha generado el vale " + Me.txtNroVale.Text + " satisfactoriamente.  Puede continuar ingresando productos.", "i", Cooperator.Framework.Web.Controls.AlertOption.NoAction, AlertType.Information)
                    End If


                    'If Me.GuardarMovimiento(db) = 1 Then
                    '    'buscar si ya fue ingresado
                    '    Dim encontrado As Boolean

                    '    For Each detalle As SAB_FARM_DETALLEREQUISICION In detalles
                    '        Dim producto = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(Function(p) p.CORRPRODUCTO = detalle.Codigo)

                    '        Dim eDM = New SAB_ALM_DETALLEMOVIMIENTOS
                    '        With eDM
                    '            .IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                    '            .IDTIPOTRANSACCION = eTIPOTRANSACCION.Salida
                    '            .IDMOVIMIENTO = Movimiento.IDMOVIMIENTO

                    '            .IDPRODUCTO = producto.IDPRODUCTO
                    '            .IDALMACEN = Almacen.IDALMACEN
                    '            .IDLOTE = producto. ' Me.gvLotes.DataKeys(row.RowIndex).Item("IDLOTE")
                    '            .CANTIDAD = CType(Me.gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), eWorld.UI.NumericBox).Text
                    '            .MONTO = 0

                    '            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    '            .AUFECHACREACION = Now
                    '            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    '            .AUFECHAMODIFICACION = Now
                    '        End With




                    '        Dim OPERACIONCANTIDADDISPONIBLE, OPERACIONCANTIDADNODISPONIBLE, OPERACIONCANTIDADVENCIDA, OPERACIONCANTIDADTEMPORAL As Int16

                    '        Select Case Me.ddlTIPOMOVIMIENTOS1.SelectedValue
                    '            Case 3 'vencida
                    '                OPERACIONCANTIDADVENCIDA = 2
                    '            Case 4 'no disponible
                    '                OPERACIONCANTIDADNODISPONIBLE = 2
                    '                eDM.CANTIDADNODISPONIBLE = 1
                    '            Case 5 'temporal
                    '                OPERACIONCANTIDADTEMPORAL = 2
                    '            Case Else 'disponible
                    '                OPERACIONCANTIDADDISPONIBLE = 2
                    '        End Select


                    '        If cDM.ActualizarCantidades(eDM, OPERACIONCANTIDADDISPONIBLE, OPERACIONCANTIDADNODISPONIBLE, 1, OPERACIONCANTIDADVENCIDA, OPERACIONCANTIDADTEMPORAL) = 1 Then
                    '            'ok
                    '        Else
                    '            errorActualizacion = True
                    '        End If



                    '    Next

                    '    Dim ds As Data.DataSet
                    '    ds = cDM.ObtenerDetalleMovimientosDS(Session.Item("IdEstablecimiento"), eTIPOTRANSACCION.Salida, Me.IDMOVIMIENTO)

                    '    Me.gvLista.DataSource = ds
                    '    Me.gvLista.DataBind()

                    '    Me.btnCerrar.Enabled = True
                    '    Me.btnImprimir.Enabled = True

                    '    Limpiar(Not errorActualizacion)

                    '    Me.plDatosProducto.Visible = False

                    '    If Me.txtProducto.Visible Then Me.txtProducto.Focus()

                    '    If continuar = 1 Then Me.MsgBox1.ShowAlert("Se ha generado el vale " + Me.txtNroVale.Text + " satisfactoriamente.  " + IIf(errorActualizacion, "  Error al actualizar, verifique las cantidades ingresadas.", " Puede continuar ingresando productos."), "i", Cooperator.Framework.Web.Controls.AlertOption.NoAction, IIf(errorActualizacion, Cooperator.Framework.Web.Controls.AlertType.Exclamation, Cooperator.Framework.Web.Controls.AlertType.Information))


                    'End If

                End If
            Catch ex As NullReferenceException
                'todo
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' crea un nuevo vale de salida y lo guarda en la db
    ''' </summary>
    ''' <param name="db">datacontext, acceso a las entidades</param>
    ''' <returns>vale de salida creado</returns>
    ''' <remarks>SINAB DEV 12/04/2013</remarks>
    Private Function CrearValeSalida(ByVal db As SinabEntities) As SAB_ALM_VALESSALIDA
        'Creacion del vale de salida
        Dim eVS = New SAB_ALM_VALESSALIDA
        With eVS
            .IDALMACEN = Almacen.IDALMACEN
            .ANIO = DateTime.Parse(Me.cpFechaDespacho.Text).Year
            .IDVALE = 1
            .OBSERVACION = Me.txtObservacion.Text
            .TRANSPORTISTA = Me.txtTransportista.Text
            .MATRICULAVEHICULO = Me.txtMatricula.Text
            .IDTIPOIDENTIFICACION = Me.ddlTIPOIDENTIFICACION1.SelectedValue
            .NUMEROIDENTIFICACION = Me.txtNumeroDocumento.Text
            .PERSONARECIBE = Me.txtRecibe.Text
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = Now()
            .ESTASINCRONIZADA = 0
        End With

        'asigna el id del último vale de salida del año en curso mas 1 (si existe)
        Dim ultimoVale = db.SAB_ALM_VALESSALIDA.Where(Function(v) v.IDALMACEN = Almacen.IDALMACEN And v.ANIO = eVS.ANIO).OrderByDescending(Function(v) v.IDVALE).FirstOrDefault()

        If ultimoVale IsNot Nothing Then
            eVS.IDVALE = ultimoVale.IDVALE + 1
        End If

        'guarda el vale de salida en la base de datos
        db.SAB_ALM_VALESSALIDA.AddObject(eVS)
        db.SaveChanges()
        Return eVS

    End Function

    ''' <summary>
    ''' crea un nuevo movimiento y lo guarda en la db
    ''' </summary>
    ''' <param name="db">datacontext, acceso a las entidades</param>
    ''' <returns>movimiento creado</returns>
    ''' <remarks>SINAB DEV 12/04/2013</remarks>
    Private Function CrearMovimiento(ByVal db As SinabEntities) As SAB_ALM_MOVIMIENTOS
        'crea el movimiento
        Dim eM = New SAB_ALM_MOVIMIENTOS
        With eM
            .IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            .IDTIPOTRANSACCION = eTIPOTRANSACCION.Salida
            .IDMOVIMIENTO = 1
            .IDALMACEN = ValeSalida.IDALMACEN
            .ANIO = ValeSalida.ANIO
            .IDDOCUMENTO = ValeSalida.IDVALE
            .FECHAMOVIMIENTO = DateTime.Parse(Me.cpFechaDespacho.Text)
            .IDUNIDADSOLICITA = Session.Item("IdDependencia")
            .CLASIFICACIONMOVIMIENTO = 3 'Despachar productos a partir de una requisición proveniente de otro almacén
            .SUBCLASIFICACIONMOVIMIENTO = Me.ddlMovimientos.SelectedValue
            .EMPLEADOALMACEN = Me.txtEmpleadoAlmacen.Text
            .EMPLEADOPREPARA = Me.txtEMPLEADOPREPARA.Text
            .IDESTADO = eESTADOSMOVIMIENTOS.Grabado
            .ID_LUGAR_ENTREGA_HOSPITAL = Nothing
            .IDESTABLECIMIENTODESTINO = Establecimiento.IDESTABLECIMIENTO
            .IDALMACENDESTINO = Almacen.IDALMACEN
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = Now()
            .ESTASINCRONIZADA = 0
        End With

        'asigna el id del último movimiento del año en curso mas 1 (si existe)
        Dim ultimoMovimiento = db.SAB_ALM_MOVIMIENTOS.Where(Function(m) m.IDESTABLECIMIENTO = eM.IDESTABLECIMIENTO And m.IDTIPOTRANSACCION = m.IDTIPOTRANSACCION).OrderByDescending(Function(m) m.IDMOVIMIENTO).FirstOrDefault()
        If ultimoMovimiento IsNot Nothing Then
            eM.IDMOVIMIENTO = ultimoMovimiento.IDMOVIMIENTO + 1
        End If

        'guarda el movimiento en la base de datos
        db.SAB_ALM_MOVIMIENTOS.AddObject(eM)
        db.SaveChanges()
        Return eM

    End Function

    ''' <summary>
    ''' Genera el Vale de salida y el movimiento para la requisicion en curso
    ''' </summary>
    ''' <param name="db">datacontext, acceso a las entidades</param>
    ''' <returns>??</returns>
    ''' <remarks>SINAB DEV 12/04/2013</remarks>
    Private Function GuardarMovimiento(ByVal db As SinabEntities) As Integer

        Dim resultado As Integer

        Try
            'asigna nuevo vale de salida
            ValeSalida = CrearValeSalida(db)

            Me.txtNroVale.Text = String.Format("{0}/{1}", ValeSalida.IDVALE, ValeSalida.ANIO)

            'movimiento
            Movimiento = CrearMovimiento(db)

        Catch ex As Exception
            Me.MsgBox1.ShowAlert("Error:" & ex.Message, "e", AlertOption.NoAction, AlertType.Stop)
        End Try

        Return resultado

    End Function

    'Private Sub GenerarMovimiento()


    '    Dim continuar As Integer = 0


    '    If Me.GuardarMovimiento() = 1 Then
    '        continuar = 1
    '    End If


    '    If continuar > 0 Then

    '        'buscar si ya fue ingresado
    '        Dim encontrado As Boolean

    '        For Each row As GridViewRow In gvLotes.Rows

    '            If CType(Me.gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), eWorld.UI.NumericBox).Text.Trim <> String.Empty Then

    '                encontrado = False

    '                For Each item As DataKey In gvLista.DataKeys
    '                    If item("IDLOTE") = Me.gvLotes.DataKeys(row.RowIndex).Item("IDLOTE") Then
    '                        encontrado = True
    '                        Exit For
    '                    End If
    '                Next

    '            End If

    '            If encontrado Then
    '                Me.MsgBox1.ShowAlert("Lote " + Me.gvLotes.DataKeys(row.RowIndex).Item("CODIGO").ToString + " ya ingresado.", "w", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
    '                Me.gvLotes.Rows(0).Focus()
    '                Exit Sub
    '            End If

    '        Next

    '        Dim cDM As New cDETALLEMOVIMIENTOS

    '        Dim errorActualizacion As Boolean

    '        For Each row As GridViewRow In gvLotes.Rows

    '            If CType(Me.gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), eWorld.UI.NumericBox).Text.Trim <> String.Empty Then

    '                Dim eDM As New DETALLEMOVIMIENTOS
    '                eDM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '                eDM.IDTIPOTRANSACCION = eTIPOTRANSACCION.Salida
    '                eDM.IDMOVIMIENTO = Me.IDMOVIMIENTO

    '                eDM.IDPRODUCTO = Me.gvLotes.DataKeys(row.RowIndex).Item("IDPRODUCTO")
    '                eDM.IDALMACEN = Me.IDALMACEN
    '                eDM.IDLOTE = Me.gvLotes.DataKeys(row.RowIndex).Item("IDLOTE")
    '                eDM.CANTIDAD = CType(Me.gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), eWorld.UI.NumericBox).Text
    '                eDM.MONTO = 0

    '                eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '                eDM.AUFECHACREACION = Now
    '                eDM.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '                eDM.AUFECHAMODIFICACION = Now

    '                Dim OPERACIONCANTIDADDISPONIBLE, OPERACIONCANTIDADNODISPONIBLE, OPERACIONCANTIDADVENCIDA, OPERACIONCANTIDADTEMPORAL As Int16

    '                Select Case Me.ddlTIPOMOVIMIENTOS1.SelectedValue
    '                    Case 3 'vencida
    '                        OPERACIONCANTIDADVENCIDA = 2
    '                    Case 4 'no disponible
    '                        OPERACIONCANTIDADNODISPONIBLE = 2
    '                        eDM.CANTIDADNODISPONIBLE = 1
    '                    Case 5 'temporal
    '                        OPERACIONCANTIDADTEMPORAL = 2
    '                    Case Else 'disponible
    '                        OPERACIONCANTIDADDISPONIBLE = 2
    '                End Select


    '                If cDM.ActualizarCantidades(eDM, OPERACIONCANTIDADDISPONIBLE, OPERACIONCANTIDADNODISPONIBLE, 1, OPERACIONCANTIDADVENCIDA, OPERACIONCANTIDADTEMPORAL) = 1 Then
    '                    'ok
    '                Else
    '                    errorActualizacion = True
    '                End If

    '            End If

    '        Next

    '        Dim ds As Data.DataSet
    '        ds = cDM.ObtenerDetalleMovimientosDS(Session.Item("IdEstablecimiento"), eTIPOTRANSACCION.Salida, Me.IDMOVIMIENTO)

    '        Me.gvLista.DataSource = ds
    '        Me.gvLista.DataBind()

    '        Me.btnCerrar.Enabled = True
    '        Me.btnImprimir.Enabled = True

    '        Limpiar(Not errorActualizacion)

    '        Me.plDatosProducto.Visible = False

    '        If Me.txtProducto.Visible Then Me.txtProducto.Focus()

    '        If continuar = 1 Then Me.MsgBox1.ShowAlert("Se ha generado el vale " + Me.txtNroVale.Text + " satisfactoriamente.  " + IIf(errorActualizacion, "  Error al actualizar, verifique las cantidades ingresadas.", " Puede continuar ingresando productos."), "i", Cooperator.Framework.Web.Controls.AlertOption.NoAction, IIf(errorActualizacion, Cooperator.Framework.Web.Controls.AlertType.Exclamation, Cooperator.Framework.Web.Controls.AlertType.Information))

    '    End If
    'End Sub

#Region "Variables Privadas"
    Private _suministro As SAB_CAT_SUMINISTROS
    Private _establecimiento As SAB_CAT_ESTABLECIMIENTOS
    Private _almacen As SAB_CAT_ALMACENES
    Private _valesalida As SAB_ALM_VALESSALIDA
    Private _movimiento As SAB_ALM_MOVIMIENTOS
#End Region

End Class
