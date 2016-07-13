Imports SINAB_Entidades.EnumHelpers

Partial Class frmRecepcionAnticipos
    Inherits System.Web.UI.Page

    Protected Sub Wuc_SeleccionarRenglon() Handles UcInformacionRecepcionAnticipo1.SeleccionarRenglon
        'Aqui va la captura del establecimiento, proveedor, contrato y renglon

        Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cCONTRATOS
        Me.Label1.Visible = False

        Dim ds As Data.DataSet = cEntidad.ObtenerRenglonesPendientesTotales2(Me.UcInformacionRecepcionAnticipo1._idEstablecimiento, Me.UcInformacionRecepcionAnticipo1._idAlmacen, Me.UcInformacionRecepcionAnticipo1._idProveedor, Me.UcInformacionRecepcionAnticipo1._idContrato, Me.UcInformacionRecepcionAnticipo1._renglon)

        If Not ds Is Nothing Then

            If ds.Tables(0).Rows.Count = 1 Then
                Dim cantidad As Double = ds.Tables(0).Rows(0).Item(13) - ds.Tables(0).Rows(0).Item(14)

                Dim dsMemoria As Data.DataSet

                dsMemoria = Session("dsRecepcion")

                Dim cantRecibida As Double = 0

                If Not dsMemoria Is Nothing Then
                    If Not dsMemoria.Tables(0).Compute("Sum(Cantidad)", "Renglon = " & Me.UcInformacionRecepcionAnticipo1._renglon & "") Is DBNull.Value Then
                        cantRecibida = dsMemoria.Tables(0).Compute("Sum(Cantidad)", "Renglon = " & Me.UcInformacionRecepcionAnticipo1._renglon & "")
                    End If

                    If cantRecibida >= cantidad Then
                        Me.Label1.Visible = True
                        Exit Sub
                    End If

                End If

                Me.pnlInfReg.Visible = True
                Me.UcInformacionRecepcionRenglon1.Visible = True

                With Me.UcInformacionRecepcionRenglon1
                    .IDESTABLECIMIENTO = Me.UcInformacionRecepcionAnticipo1._idEstablecimiento
                    .IDPROVEEDOR = Me.UcInformacionRecepcionAnticipo1._idProveedor
                    .IDCONTRATO = Me.UcInformacionRecepcionAnticipo1._idContrato
                    .IDALMACEN = Me.UcInformacionRecepcionAnticipo1._idAlmacen
                    .RENGLON = Me.UcInformacionRecepcionAnticipo1._renglon
                    '.CANTIDADarec = cantRecibida
                    .CargarDatos()
                    .Resetear()
                End With

            End If

        Else
            Exit Sub
        End If

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Function generarEstrucDs() As Data.DataSet

        Dim ds As New Data.DataSet

        Dim table As New Data.DataTable()
        ds.Tables.Add(table)

        Dim campo As Data.DataColumn = New Data.DataColumn("NOFACTURA")
        campo.DataType = System.Type.GetType("System.String")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("NOENVIO")
        campo.DataType = System.Type.GetType("System.String")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("FCHDOCUMENTO")
        campo.DataType = System.Type.GetType("System.DateTime")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("RENGLON")
        campo.DataType = System.Type.GetType("System.Int32")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("LOTE")
        campo.DataType = System.Type.GetType("System.String")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("FCHVENCIMIENTO")
        campo.DataType = System.Type.GetType("System.DateTime")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("NOINFCC")
        campo.DataType = System.Type.GetType("System.String")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("FECHAELABORACIONINFORME")
        campo.DataType = System.Type.GetType("System.DateTime")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("CANTIDAD")
        campo.DataType = System.Type.GetType("System.Decimal")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("UBICACION")
        campo.DataType = System.Type.GetType("System.String")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("IDESTCC")
        campo.DataType = System.Type.GetType("System.Int32")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("IDINFCC")
        campo.DataType = System.Type.GetType("System.Int32")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("IDTIPCC")
        campo.DataType = System.Type.GetType("System.Int32")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("PROVIENE")
        campo.DataType = System.Type.GetType("System.Int32")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("IMPORTE")
        campo.DataType = System.Type.GetType("System.Decimal")
        ds.Tables(0).Columns.Add(campo)

        'campo = New Data.DataColumn("IDDETALLE")
        'campo.DataType = System.Type.GetType("System.Int32")
        'ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("IDPRODUCTO")
        campo.DataType = System.Type.GetType("System.Int32")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("UM")
        campo.DataType = System.Type.GetType("System.Int32")
        ds.Tables(0).Columns.Add(campo)

        campo = New Data.DataColumn("PRECIO")
        campo.DataType = System.Type.GetType("System.Decimal")
        ds.Tables(0).Columns.Add(campo)

        Return ds

    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As Data.DataSet

        If Not Page.IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            Session.Remove("dsRecepcion")

            ds = generarEstrucDs()

            Session.Add("dsRecepcion", ds)

            Me.UcSeleccionContratoAnticipo1.IdEstablecimiento = Session.Item("IdEstablecimiento")

        Else

            Try
                ds = Session("dsRecepcion")
                Me.gvTemp.DataSource = ds
                Me.gvTemp.DataBind()
            Catch ex As Exception

            End Try

            Try

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        If ds.Tables(0).Rows.Count > 0 Then
                            Me.titReng.Visible = True
                            Me.pnUltimo.Visible = True
                        Else
                            Me.titReng.Visible = False
                            Me.pnUltimo.Visible = False
                        End If
                    Else
                        Me.titReng.Visible = False
                        Me.pnUltimo.Visible = False
                    End If
                Else
                    Me.titReng.Visible = False
                    Me.pnUltimo.Visible = False
                End If
            Catch ex As Exception

            End Try

            'Dim dr As Data.DataRow = ds.Tables(0).NewRow
            'Dim cantidadTotal As Integer = 0
            'For Each dr In ds.Tables(0).Rows
            '    cantidadTotal += dr(2)
            'Next

            'Me.lblCantidadTotal.Text = cantidadTotal
            'Me.lblImporteTotal.Text = "$"
        End If


    End Sub

    Protected Sub UcSeleccionContratoRecepcion1_gvDoc_SelectedIndexChanged() Handles UcSeleccionContratoAnticipo1.gvDoc_SelectedIndexChanged

        Me.UcInformacionRecepcionAnticipo1._idEstablecimiento = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
        Me.UcInformacionRecepcionAnticipo1._idProveedor = Me.UcSeleccionContratoAnticipo1.IdProveedor
        Me.UcInformacionRecepcionAnticipo1._idContrato = Me.UcSeleccionContratoAnticipo1.IdContrato
        Me.UcInformacionRecepcionAnticipo1._idAlmacen = Me.UcSeleccionContratoAnticipo1.IdAlmacen
        Me.UcInformacionRecepcionAnticipo1.Cargar()
        Me.Panel1.Visible = True
        Me.UcSeleccionContratoAnticipo1.Visible = False
        Me.UcInformacionRecepcionRenglon1.Visible = False

        Me.UcInformacionRecepcionAnticipo1.Visible = True
        Me.LinkButton1.Visible = True

        Me.pnlInfReg.Visible = False
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.UcSeleccionContratoAnticipo1.Visible = True
        Me.UcInformacionRecepcionRenglon1.Visible = False
        Me.UcInformacionRecepcionAnticipo1.Visible = False
        Me.pnlInfReg.Visible = False
        Me.LinkButton1.Visible = False
        Me.UcSeleccionContratoAnticipo1.invisible()
        Session.Remove("dsRecepcion")
        Me.gvTemp.DataSource = Nothing
        Me.gvTemp.DataBind()
    End Sub

    Protected Sub gvTemp_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvTemp.RowCommand

        Try
            If e.CommandName = "eliminar" Then
                Me.titReng.Visible = False
                Dim index As Integer = CType(e.CommandArgument, Integer)
                Dim ds As Data.DataSet = Session.Item("dsRecepcion")
                ds.Tables(0).Rows(index).Delete()
                Session("dsRecepcion") = ds
                Me.gvTemp.DataSource = Session("dsRecepcion")
                Me.gvTemp.DataBind()
                If ds.Tables(0).Rows.Count = 0 Then
                    Me.titReng.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gvTemp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvTemp.SelectedIndexChanged

        Dim nofactura As String
        Dim noenvio As String
        Dim fchdocumento As Date
        Dim renglon As Integer
        Dim lote As String
        Dim fchvencimiento As Date
        Dim noinfcc As String
        Dim fechaelaboracioninforme As Date
        Dim cantidad As Double
        Dim ubicacion As String
        Dim idestcc As Integer
        Dim idinfcc As Integer
        Dim idtipcc As Integer
        Dim proviene As Integer
        Dim importe As Double
        'Dim iddetalle As Integer
        Dim idproducto As Integer
        Dim idunidadmedida As Integer
        Dim precio As Decimal

        nofactura = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("NOFACTURA")
        noenvio = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("NOENVIO")
        fchdocumento = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("FCHDOCUMENTO")
        renglon = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("RENGLON")
        lote = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("LOTE")
        fchvencimiento = IIf(Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("FCHVENCIMIENTO") Is DBNull.Value, Nothing, Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("FCHVENCIMIENTO"))
        noinfcc = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("NOINFCC")
        fechaelaboracioninforme = IIf(Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("FECHAELABORACIONINFORME") Is DBNull.Value, Nothing, Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("FECHAELABORACIONINFORME"))
        cantidad = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("CANTIDAD")
        ubicacion = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("UBICACION")
        idestcc = IIf(Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("IDESTCC") Is DBNull.Value, Nothing, Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("IDESTCC"))
        idinfcc = IIf(Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("IDINFCC") Is DBNull.Value, Nothing, Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("IDINFCC"))
        idtipcc = IIf(Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("IDTIPCC") Is DBNull.Value, Nothing, Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("IDTIPCC"))
        proviene = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("PROVIENE")
        importe = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("IMPORTE")
        ' iddetalle = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("iddetalle")
        idproducto = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("idproducto")
        idunidadmedida = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("iddunidadmedida")
        precio = Me.gvTemp.DataKeys(Me.gvTemp.SelectedIndex).Values.Item("precio")

        Me.pnlInfReg.Visible = True
        Me.UcInformacionRecepcionRenglon1.Visible = True

        With Me.UcInformacionRecepcionRenglon1

            .IDESTABLECIMIENTO = Me.UcInformacionRecepcionAnticipo1._idEstablecimiento
            .IDPROVEEDOR = Me.UcInformacionRecepcionAnticipo1._idProveedor
            .IDCONTRATO = Me.UcInformacionRecepcionAnticipo1._idContrato
            .IDALMACEN = Me.UcInformacionRecepcionAnticipo1._idAlmacen
            .RENGLON = Me.UcInformacionRecepcionAnticipo1._renglon
            '._fchDoc = fchdocumento
            '._noFactura = nofactura
            '._noEnvio = noenvio
            '.CANTIDADARECIBIR = cantidad
            '._importe = importe
            '._ubicacion = ubicacion
            '._proviene = proviene
            '._lote = lote
            '._fechaVenc = fchvencimiento
            '._informeCC = noinfcc
            '._fechaCC = fechaelaboracioninforme
            '._iddetalle = iddetalle
            '.CargarDatos()
            '.llenarModificar()

        End With

        Me.gvTemp.Enabled = False


    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' CREACION DE ENCABEZADO Y RECIBO
        Dim eMovimientos As New ABASTECIMIENTOS.ENTIDADES.MOVIMIENTOS
        Dim cMovimientos As New ABASTECIMIENTOS.NEGOCIO.cMOVIMIENTOS
        Dim eRecibo As New ABASTECIMIENTOS.ENTIDADES.RECIBOSRECEPCION
        Dim cRecibo As New ABASTECIMIENTOS.NEGOCIO.cRECIBOSRECEPCION
        Dim idmov As Integer
        Try
            eMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eMovimientos.IDTIPOTRANSACCION = TiposTransaccion.RecepcionProductos
            eMovimientos.IDMOVIMIENTO = 0

            eMovimientos.IDTIPODOCREF = eTIPODOCUMENTOREFERENCIAS.Contrato
            'eMovimientos.NUMERODOCREF = Me.UcInformacionRecepcionAnticipo1.NumeroContrato
            eMovimientos.IDALMACEN = Session.Item("IdAlmacen") 'Me.UcInformacionRecepcionContrato1._idAlmacen
            eMovimientos.ANIO = Now.Year

            eMovimientos.IDDOCUMENTO = Me.UcInformacionRecepcionAnticipo1.NumRecibo
            eMovimientos.IDESTADO = eESTADOSMOVIMIENTOS.Grabado

            eMovimientos.FECHAMOVIMIENTO = Me.UcInformacionRecepcionAnticipo1.FechaRecepcion
            eMovimientos.IDESTABLECIMIENTODESTINO = Nothing

            eMovimientos.IDALMACENDESTINO = Session.Item("IdAlmacen")
            eMovimientos.IDUNIDADSOLICITA = Session.Item("IdDependencia")
            eMovimientos.TOTALMOVIMIENTO = 0

            eMovimientos.IDEMPLEADOSOLICITA = Session.Item("IdEmpleado")
            eMovimientos.EMPLEADOALMACEN = Me.UcInformacionRecepcionAnticipo1.Guardaalmacen
            eMovimientos.IDEMPLEADOALMACEN = Nothing

            eMovimientos.CLASIFICACIONMOVIMIENTO = 1
            eMovimientos.SUBCLASIFICACIONMOVIMIENTO = 1

            eMovimientos.RESPONSABLEDISTRIBUCION = Nothing

            If eMovimientos.AUUSUARIOCREACION = Nothing Then
                eMovimientos.AUUSUARIOCREACION = User.Identity.Name
            End If
            If eMovimientos.AUFECHACREACION = Nothing Then
                eMovimientos.AUFECHACREACION = Now()
            End If
            eMovimientos.AUUSUARIOMODIFICACION = User.Identity.Name
            eMovimientos.AUFECHAMODIFICACION = Now()
            eMovimientos.ESTASINCRONIZADA = 0


            idmov = cMovimientos.ActualizarMOVIMIENTOS(eMovimientos)

            If idmov > 0 Then

                eRecibo.IDALMACEN = Session.Item("IdAlmacen")
                eRecibo.ANIO = Now.Year
                eRecibo.IDRECIBO = eMovimientos.IDDOCUMENTO

                If cRecibo.ExisteRecibo(eRecibo) = 0 Then
                    eRecibo.IDALMACEN = Session.Item("IdAlmacen")
                    eRecibo.ANIO = Now.Year
                    eRecibo.IDRECIBO = eMovimientos.IDDOCUMENTO
                    eRecibo.IDESTABLECIMIENTO = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
                    eRecibo.IDPROVEEDOR = Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR
                    eRecibo.IDCONTRATO = Me.UcInformacionRecepcionRenglon1.IDCONTRATO
                    eRecibo.RESPONSABLEPROVEEDOR = Me.UcInformacionRecepcionAnticipo1.Transportista
                    eRecibo.NUMEROACTA = eMovimientos.IDDOCUMENTO
                    eRecibo.OBSERVACION = Me.TextBox1.Text
                    If eRecibo.AUUSUARIOCREACION = Nothing Then
                        eRecibo.AUUSUARIOCREACION = User.Identity.Name
                    End If
                    If eRecibo.AUFECHACREACION = Nothing Then
                        eRecibo.AUFECHACREACION = Now()
                    End If
                    eRecibo.AUUSUARIOMODIFICACION = User.Identity.Name
                    eRecibo.AUFECHAMODIFICACION = Now()
                    eRecibo.ESTASINCRONIZADA = 0

                    cRecibo.AgregarRECIBOSRECEPCION(eRecibo)
                Else
                    eRecibo.IDALMACEN = Session.Item("IdAlmacen")
                    eRecibo.ANIO = Now.Year
                    eRecibo.IDRECIBO = eMovimientos.IDDOCUMENTO
                    eRecibo.IDESTABLECIMIENTO = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
                    eRecibo.IDPROVEEDOR = Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR
                    eRecibo.IDCONTRATO = Me.UcInformacionRecepcionRenglon1.IDCONTRATO
                    eRecibo.RESPONSABLEPROVEEDOR = Me.UcInformacionRecepcionAnticipo1.Transportista
                    eRecibo.NUMEROACTA = eMovimientos.IDDOCUMENTO
                    eRecibo.OBSERVACION = Me.TextBox1.Text
                    If eRecibo.AUUSUARIOCREACION = Nothing Then
                        eRecibo.AUUSUARIOCREACION = User.Identity.Name
                    End If
                    If eRecibo.AUFECHACREACION = Nothing Then
                        eRecibo.AUFECHACREACION = Now()
                    End If
                    eRecibo.AUUSUARIOMODIFICACION = User.Identity.Name
                    eRecibo.AUFECHAMODIFICACION = Now()
                    eRecibo.ESTASINCRONIZADA = 0

                    cRecibo.ActualizarRECIBOSRECEPCION(eRecibo)
                End If


            End If




            'CREACION DE LOTES Y PROGRAMAS DE DISTRIBUCION
            Dim eDetalleMovimientos As New ABASTECIMIENTOS.ENTIDADES.DETALLEMOVIMIENTOS
            Dim cDetalleMovimientos As New ABASTECIMIENTOS.NEGOCIO.cDETALLEMOVIMIENTOS

            Dim eLote As New ABASTECIMIENTOS.ENTIDADES.LOTES
            Dim cLote As New ABASTECIMIENTOS.NEGOCIO.cLOTES

            Dim idproducto As Integer
            Dim cantidad As Integer
            Dim monto As Decimal
            Dim renglon As Integer
            Dim um As Integer
            Dim codigolote As String
            Dim precio As Decimal
            Dim fecVe As Date
            Dim idinformecc As Integer
            Dim ubicacion As String
            Dim numerofactura As String
            Dim fechafac As Date
            Dim numeroenvio As String
            '  Dim iddetalle As Integer
            Dim c As Integer = 0
            Dim row As GridViewRow

            For Each row In Me.gvTemp.Rows

                idproducto = Me.gvTemp.DataKeys(c).Values.Item("idproducto")
                cantidad = Me.gvTemp.DataKeys(c).Values.Item("CANTIDAD")
                monto = Me.gvTemp.DataKeys(c).Values.Item("IMPORTE")
                renglon = Me.gvTemp.DataKeys(c).Values.Item("RENGLON")
                um = Me.gvTemp.DataKeys(c).Values.Item("um")
                codigolote = Me.gvTemp.DataKeys(c).Values.Item("LOTE")
                precio = Me.gvTemp.DataKeys(c).Values.Item("precio")
                fecVe = Me.gvTemp.DataKeys(c).Values.Item("FCHVENCIMIENTO")

                If IsDBNull(Me.gvTemp.DataKeys(c).Values.Item("IDINFCC")) Then
                    idinformecc = 0
                Else
                    idinformecc = Me.gvTemp.DataKeys(c).Values.Item("IDINFCC")
                End If

                ubicacion = Me.gvTemp.DataKeys(c).Values.Item("UBICACION")
                numerofactura = Me.gvTemp.DataKeys(c).Values.Item("NOFACTURA")
                fechafac = Me.gvTemp.DataKeys(c).Values.Item("FCHDOCUMENTO")
                numeroenvio = Me.gvTemp.DataKeys(c).Values.Item("NOENVIO")
                '  iddetalle = Me.gvTemp.DataKeys(c).Values.Item("iddetalle")

                'DETALLE MOVIMIENTOS
                eDetalleMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                eDetalleMovimientos.IDTIPOTRANSACCION = TiposTransaccion.RecepcionProductos

                Dim eMov As New ABASTECIMIENTOS.ENTIDADES.MOVIMIENTOS
                eMov.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                eMov.IDTIPOTRANSACCION = TiposTransaccion.RecepcionProductos

                eDetalleMovimientos.IDMOVIMIENTO = idmov
                eDetalleMovimientos.IDDETALLEMOVIMIENTO = 0
                eDetalleMovimientos.IDALMACEN = Session.Item("IdAlmacen")
                eDetalleMovimientos.IDPRODUCTO = idproducto
                eDetalleMovimientos.CANTIDAD = cantidad
                eDetalleMovimientos.NUMEROFACTURA = numerofactura
                eDetalleMovimientos.NOENVIO = numeroenvio
                eDetalleMovimientos.FECHAFACTURA = fechafac
                eDetalleMovimientos.MONTO = monto
                eDetalleMovimientos.RENGLON = renglon
                eDetalleMovimientos.ESTASINCRONIZADA = 0 'iddetalle 'Me.TxtIdDetalle.Text   'Guardamos el IDDETALLE de la entrega

                eLote.IDALMACEN = eDetalleMovimientos.IDALMACEN
                eDetalleMovimientos.IDLOTE = cLote.ObtenerID(eLote)

                If eDetalleMovimientos.AUUSUARIOCREACION = Nothing Then
                    eDetalleMovimientos.AUUSUARIOCREACION = User.Identity.Name
                End If
                If eDetalleMovimientos.AUFECHACREACION = Nothing Then
                    eDetalleMovimientos.AUFECHACREACION = Now()
                End If
                eDetalleMovimientos.AUUSUARIOMODIFICACION = User.Identity.Name
                eDetalleMovimientos.AUFECHAMODIFICACION = Now()

                cDetalleMovimientos.ActualizarDETALLEMOVIMIENTOS(eDetalleMovimientos)

                'LOTES

                eLote.IDLOTE = eDetalleMovimientos.IDLOTE
                eLote.IDPRODUCTO = eDetalleMovimientos.IDPRODUCTO
                eLote.IDUNIDADMEDIDA = um
                eLote.CODIGO = codigolote
                eLote.PRECIOLOTE = precio
                eLote.FECHAVENCIMIENTO = fecVe
                eLote.IDRESPONSABLEDISTRIBUCION = Nothing
                eLote.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

                If idinformecc <> 0 Then
                    eLote.IDINFORMECONTROLCALIDAD = idinformecc ' IIf(IsNumeric(Me.TxtNoInformeCalidad.Text), Me.TxtNoInformeCalidad.Text, 1)
                Else
                    eLote.IDINFORMECONTROLCALIDAD = Nothing
                End If

                eLote.IDRESPONSABLEDISTRIBUCION = 1 'UTMIM cuando es contrato
                Select Case Me.UcSeleccionContratoAnticipo1.IdAlmacen
                    Case 42
                        eLote.IDFUENTEFINANCIAMIENTO = 1 ' GOES
                    Case 43
                        eLote.IDFUENTEFINANCIAMIENTO = 6 ' FOSALUD
                    Case Else
                        eLote.IDFUENTEFINANCIAMIENTO = 1
                End Select

                eLote.CANTIDADDISPONIBLE = 0
                eLote.ESTADISPONIBLE = 0

                If eLote.AUUSUARIOCREACION = Nothing Then
                    eLote.AUUSUARIOCREACION = User.Identity.Name
                End If
                If eLote.AUFECHACREACION = Nothing Then
                    eLote.AUFECHACREACION = Now()
                End If
                eLote.AUUSUARIOMODIFICACION = User.Identity.Name
                eLote.AUFECHAMODIFICACION = Now()
                eLote.ESTASINCRONIZADA = 0

                cLote.Agregar(eLote)

                'AGREGAR UBICACION
                Dim eUbicacion As New ABASTECIMIENTOS.ENTIDADES.UBICACIONESPRODUCTOS
                Dim cUbicacion As New ABASTECIMIENTOS.NEGOCIO.cUBICACIONESPRODUCTOS

                eUbicacion.IDALMACEN = Session.Item("IdAlmacen")
                eUbicacion.IDPRODUCTO = idproducto
                eUbicacion.IDUBICACION = 0
                eUbicacion.UBICACION = ubicacion
                eUbicacion.IDLOTE = eLote.IDLOTE
                If eUbicacion.AUUSUARIOCREACION = Nothing Then
                    eUbicacion.AUUSUARIOCREACION = User.Identity.Name
                End If
                If eUbicacion.AUFECHACREACION = Nothing Then
                    eUbicacion.AUFECHACREACION = Now()
                End If
                eUbicacion.AUUSUARIOMODIFICACION = User.Identity.Name
                eUbicacion.AUFECHAMODIFICACION = Now()
                eUbicacion.ESTASINCRONIZADA = 0

                cUbicacion.ActualizarUBICACIONESPRODUCTOS(eUbicacion)


                'Cargamos la información del programa de distribución en la entidad para ser actualizada.
                'TIPO DE RECEPCION = 1 --> CONTRATO
                'Select Case Me.DdlTipoRecepcion.SelectedValue
                '    Case Is = 1

                Dim eProgramaDistribucion As New ABASTECIMIENTOS.ENTIDADES.PROGRAMADISTRIBUCION
                Dim cProgramaDistribucion As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMADISTRIBUCION

                Dim mCompContratoProceso As New ABASTECIMIENTOS.NEGOCIO.cCONTRATOSPROCESOCOMPRA
                Dim mEntContratoProceso As New ABASTECIMIENTOS.ENTIDADES.CONTRATOSPROCESOCOMPRA

                mEntContratoProceso.IDESTABLECIMIENTO = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
                mEntContratoProceso.IDPROVEEDOR = Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR
                mEntContratoProceso.IDCONTRATO = Me.UcInformacionRecepcionRenglon1.IDCONTRATO

                'mCompContratoProceso.ObtenerCONTRATOSPROCESOCOMPRA2(mEntContratoProceso)


                eProgramaDistribucion.IDESTABLECIMIENTO = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
                eProgramaDistribucion.IDPROCESOCOMPRA = mEntContratoProceso.IDPROCESOCOMPRA
                eProgramaDistribucion.RENGLON = renglon
                eProgramaDistribucion.IDESTABLECIMIENTOSOLICITA = Session.Item("IdEstablecimiento")
                eProgramaDistribucion.IDALMACEN = eDetalleMovimientos.IDALMACEN
                eProgramaDistribucion.AUUSUARIOMODIFICACION = User.Identity.Name
                eProgramaDistribucion.AUFECHAMODIFICACION = Now
                cProgramaDistribucion.ObtenerPROGRAMADISTRIBUCION2(eProgramaDistribucion)
                eProgramaDistribucion.CANTIDADENTREGADA = eProgramaDistribucion.CANTIDADENTREGADA + Val(cantidad)

                cProgramaDistribucion.ActualizarCantidadEntregada(eProgramaDistribucion)

                'ACTUALIZAR LAS CANTIDADES EN CADA ENTREGA

                Dim AEC As New ABASTECIMIENTOS.ENTIDADES.ALMACENESENTREGACONTRATOS
                Dim cAEC As New ABASTECIMIENTOS.NEGOCIO.cALMACENESENTREGACONTRATOS


                Dim ds As Data.DataSet
                ds = cAEC.ObtenerDsEntregas(Me.UcSeleccionContratoAnticipo1.IdEstablecimiento, Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR, Me.UcInformacionRecepcionRenglon1.IDCONTRATO, renglon, Session.Item("IdAlmacen"))


                Dim dr As Data.DataRow = ds.Tables(0).NewRow
                Dim c2 As Integer = 0
                For Each dr In ds.Tables(0).Rows

                    If dr(2) = 0 Then
                        If Val(cantidad) > dr(1) Then
                            dr(2) = dr(1)
                            cantidad = Val(cantidad) - dr(1)
                            AEC.IDESTABLECIMIENTO = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
                            AEC.IDPROVEEDOR = Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR
                            AEC.IDCONTRATO = Me.UcInformacionRecepcionRenglon1.IDCONTRATO
                            AEC.RENGLON = renglon
                            AEC.IDALMACENENTREGA = Session.Item("IdAlmacen")
                            AEC.IDDETALLE = dr(0)
                            AEC.CANTIDADENTREGADA = dr(2)
                            AEC.AUUSUARIOMODIFICACION = User.Identity.Name
                            AEC.AUFECHAMODIFICACION = Now

                            cAEC.ActualizarCantidadEntregada(AEC)
                        Else
                            ' Val(cantidad) <= dr(1) Then
                            dr(2) = Val(cantidad)
                            AEC.IDESTABLECIMIENTO = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
                            AEC.IDPROVEEDOR = Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR
                            AEC.IDCONTRATO = Me.UcInformacionRecepcionRenglon1.IDCONTRATO
                            AEC.RENGLON = renglon
                            AEC.IDALMACENENTREGA = Session.Item("IdAlmacen")
                            AEC.IDDETALLE = dr(0)
                            AEC.CANTIDADENTREGADA = dr(2)
                            AEC.AUUSUARIOMODIFICACION = User.Identity.Name
                            AEC.AUFECHAMODIFICACION = Now

                            cAEC.ActualizarCantidadEntregada(AEC)
                            Exit For
                        End If
                    Else
                        If dr(1) = dr(2) Then
                        Else

                            If dr(1) < (dr(2) + Val(cantidad)) Then
                                c2 = dr(2)
                                dr(2) = dr(1)

                                cantidad = Val(cantidad) - dr(1) + c2


                                AEC.IDESTABLECIMIENTO = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
                                AEC.IDPROVEEDOR = Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR
                                AEC.IDCONTRATO = Me.UcInformacionRecepcionRenglon1.IDCONTRATO
                                AEC.RENGLON = renglon
                                AEC.IDALMACENENTREGA = Session.Item("IdAlmacen")
                                AEC.IDDETALLE = dr(0)
                                AEC.CANTIDADENTREGADA = dr(2)
                                AEC.AUUSUARIOMODIFICACION = User.Identity.Name
                                AEC.AUFECHAMODIFICACION = Now

                                cAEC.ActualizarCantidadEntregada(AEC)
                                c2 = 0
                            Else
                                ' dr(1) > (dr(2) + Val(cantidad)) Then
                                dr(2) = dr(2) + Val(cantidad)
                                AEC.IDESTABLECIMIENTO = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
                                AEC.IDPROVEEDOR = Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR
                                AEC.IDCONTRATO = Me.UcInformacionRecepcionRenglon1.IDCONTRATO
                                AEC.RENGLON = renglon
                                AEC.IDALMACENENTREGA = Session.Item("IdAlmacen")
                                AEC.IDDETALLE = dr(0)
                                AEC.CANTIDADENTREGADA = dr(2)
                                AEC.AUUSUARIOMODIFICACION = User.Identity.Name
                                AEC.AUFECHAMODIFICACION = Now

                                cAEC.ActualizarCantidadEntregada(AEC)
                                Exit For
                            End If
                        End If
                    End If

                Next

                c += 1
            Next

            Me.Button3.Enabled = True
            Me.MsgBox1.ShowAlert("La recepción de los productos se ha guardado satisfactoriamente. Puede imprimir el recibo de recepción.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Catch ex As Exception
            Me.MsgBox1.ShowAlert("Error:" & ex.Message, "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End Try

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.MsgBox1.ShowConfirm("Si la recepción es cerrada, esta ya no podra ser modificada. Desea continuar?", "Cerrar", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Session.Item("Contrato") = Me.UcInformacionRecepcionRenglon1.IDCONTRATO
        Session.Item("Proveedor") = Me.UcInformacionRecepcionRenglon1.IDPROVEEDOR
        Session.Item("Establecimiento") = Me.UcSeleccionContratoAnticipo1.IdEstablecimiento
        Dim iddocumento As String = Me.UcInformacionRecepcionAnticipo1.IdDocumento

        If Me.Button3.Text = "Impresión de Recibo" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptReciboRecepcion.aspx?IdMov=" & iddocumento & "&IdAnio=" & Now.Year.ToString & "&IdAlmacen=" & Session.Item("IdAlmacen").ToString & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'>window.open('" + Request.ApplicationPath + "/Reportes/FrmRptActaRecepcion.aspx?IdMov=" & iddocumento & "&IdAnio=" + Now.Year.ToString + "&Establecimiento=" & Session.Item("Establecimiento") & "&Proveedor=" & Session.Item("Proveedor") & "&Contrato=" & Session.Item("Contrato") & "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); </script>")
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "Cerrar" Then

            Dim eMov As New ABASTECIMIENTOS.ENTIDADES.MOVIMIENTOS
            Dim cMov As New ABASTECIMIENTOS.NEGOCIO.cMOVIMIENTOS

            Try
                eMov.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                eMov.IDTIPOTRANSACCION = TiposTransaccion.RecepcionProductos
                eMov.IDDOCUMENTO = Me.UcInformacionRecepcionAnticipo1.IdDocumento
                eMov.IDALMACEN = Session.Item("IdAlmacen")
                eMov.ANIO = DateTime.Now.Year

                cMov.Recuperar2(eMov)

                eMov.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
                eMov.AUUSUARIOMODIFICACION = User.Identity.Name
                eMov.AUFECHAMODIFICACION = Now()

                cMov.ActualizarMOVIMIENTOS(eMov)

                Dim dsDetLotes As Data.DataSet

                Dim cDMov As New ABASTECIMIENTOS.NEGOCIO.cDETALLEMOVIMIENTOS

                dsDetLotes = cDMov.ObtenerDataSetPorId(eMov.IDESTABLECIMIENTO, TiposTransaccion.RecepcionProductos, eMov.IDMOVIMIENTO)

                Dim cUt As New ABASTECIMIENTOS.NEGOCIO.cUTILERIAS

                For i As Integer = 0 To dsDetLotes.Tables(0).Rows.Count - 1
                    cUt.ActualizarCantidadDisponible(eMov.IDALMACEN, dsDetLotes.Tables(0).Rows(i).Item("IDLOTE"), 0, dsDetLotes.Tables(0).Rows(i).Item("CANTIDAD"))
                Next

                Dim eRecibo As New ABASTECIMIENTOS.ENTIDADES.RECIBOSRECEPCION
                Dim cRecibo As New ABASTECIMIENTOS.NEGOCIO.cRECIBOSRECEPCION
                'Asignamos la información necesaria para poder obtener la información del recibo de recepción.
                eRecibo.IDALMACEN = Session.Item("IdAlmacen")
                eRecibo.ANIO = Now.Year
                eRecibo.IDRECIBO = Me.UcInformacionRecepcionAnticipo1.IdDocumento

                'Invocamos el método de recuperación del registro existente.
                cRecibo.ObtenerRECIBOSRECEPCION(eRecibo)

                'Actualizamos la nueva información a la entidad de datos.
                eRecibo.RESPONSABLEPROVEEDOR = Me.UcInformacionRecepcionAnticipo1.Transportista
                eRecibo.AUUSUARIOMODIFICACION = User.Identity.Name
                eRecibo.AUFECHAMODIFICACION = Now()
                eRecibo.ESTASINCRONIZADA = 0

                'Invocamos el método de actualización de datos.
                cRecibo.ActualizarRECIBOSRECEPCION(eRecibo)

                Me.Button1.Enabled = False
                Me.Button2.Enabled = False
                Me.Button3.Text = "Impresión de Acta"
                Me.Button3.Enabled = True
            Catch ex As Exception
                Me.MsgBox1.ShowAlert("Error:" & ex.Message, "ee", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End Try

        End If
    End Sub

End Class
