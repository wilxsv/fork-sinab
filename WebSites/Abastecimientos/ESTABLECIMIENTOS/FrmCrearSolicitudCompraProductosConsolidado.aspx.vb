Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class ESTABLECIMIENTOS_FrmCrearSolicitudCompraProductosConsolidado
    Inherits System.Web.UI.Page
    Private _idsol As Integer
    Public Property idsol() As Integer
        Get
            Return Me._idsol
        End Get
        Set(ByVal value As Integer)
            Me._idsol = value
            If Not Me.ViewState("idsol") Is Nothing Then Me.ViewState.Remove("idsol")
            Me.ViewState.Add("idsol", value)
        End Set
    End Property
    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            idsol = Request.QueryString("id")
            Dim idsuministro As Integer
            idsuministro = Request.QueryString("idsu")
            ' Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXSuministro(idsuministro)

            Dim ds As New Data.DataSet
            'cargar el grid de productos
            Dim cds As New cDETALLESOLICITUDES
            ds = cds.obtenerProductosSolicitud(Session("IdEstablecimiento"), idsol)

            If ds.Tables(0).Rows.Count = 0 Then

                Me.dgLista.DataSource = cds.ObtenerSolicitudesAConsolidar(idsuministro, 2)
                Me.dgLista.DataBind()
                Me.Panel3.Visible = False
                Me.Panel10.Visible = True

            Else
                Me.gvLista.DataSource = ds
                gvLista.DataBind()
                Me.Panel3.Visible = True
                Me.Panel10.Visible = False
            End If

            'suministro:
            Me.ddlSUMINISTROS1.RecuperarPorUnidadTecnica(idsuministro)
            Me.ddlSUMINISTROS1.SelectedIndex = 0
            'grupo:
            Me.ddlGRUPOS1.RecuperarListaFiltradaPorUT(Me.ddlSUMINISTROS1.SelectedValue, idsuministro)
            Me.ddlGRUPOS1.SelectedIndex = 0
            'subgrupo:
            Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, idsuministro)
            Me.ddlSUBGRUPOS1.SelectedIndex = 0
            'producto
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, idsuministro)

        Else
            If Not Me.ViewState("idsol") Is Nothing Then Me.idsol = Me.ViewState("idsol")
        End If
    End Sub

    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        If Me.rdblCriterio.SelectedValue = 0 Then
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.ddlSUMINISTROS1.Visible = False
            Me.ddlGRUPOS1.Visible = False
            Me.ddlSUBGRUPOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.TxtProducto.Text = String.Empty
            Me.BtnBuscar.Visible = True
            Me.LblDescripcionCompleta.Text = ""

            Me.Label1.Visible = False
            Me.Label2.Visible = False
            Me.Label3.Visible = False

        Else
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.LblCodigo.Text = "Producto"
            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.ddlSUMINISTROS1.Visible = True
            Me.ddlGRUPOS1.Visible = True
            Me.ddlSUBGRUPOS1.Visible = True
            BuscarProductoLista()
            Me.Label1.Visible = True
            Me.Label2.Visible = True
            Me.Label3.Visible = True
        End If
    End Sub
    Private Function BuscarProductoLista() As Int16
        Dim dsCatalogoProductos As Data.DataSet
        Dim mcompcatalogoproductos As New cCATALOGOPRODUCTOS
        dsCatalogoProductos = mcompcatalogoproductos.FiltrarProductoDSUT(Me.DdlCATALOGOPRODUCTOS1.SelectedValue, 1, Request.QueryString("idsu"))

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else
            Me.Label4.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
            Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
            Me.LblDescripcionCompleta.Visible = True
        End If
    End Function

    Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
        Dim dsCatalogoProductos As Data.DataSet
        Dim mCompCatalogoProductos As New cCATALOGOPRODUCTOS
        dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.DdlCATALOGOPRODUCTOS1.SelectedValue, 1)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else
            'SeleccionarLote()
            '  Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
            Me.Label4.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
            Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
            Me.LblDescripcionCompleta.Visible = True
        End If
    End Sub
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click



        Dim dsCatalogoProductos As Data.DataSet
        Dim mcompcatalogoproductos As New cCATALOGOPRODUCTOS

        dsCatalogoProductos = mcompcatalogoproductos.FiltrarProductoDSUT(Me.TxtProducto.Text, 2, Request.QueryString("idsu"), 1)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else
            Try
                'Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                Me.Label4.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                Me.LblDescripcionCompleta.Visible = True
            Catch ex As Exception
                MsgBox1.ShowAlert("El código de producto no fue encontrado.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                Me.TxtProducto.Text = ""
                Me.TxtProducto.Focus()
            End Try

        End If
    End Sub
    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Try
            'evento guardar
            Dim sError As String
            sError = Me.actualizarProductos()
        Catch ex As Exception

        End Try

        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatosP2()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            'If Request.QueryString("cj") <> 0 Then
            '    'ES CONJUNTA
            '    'aqui me quede
            '    Dim nb As New eWorld.UI.NumericBox
            '    nb = e.Row.FindControl("NumericBox5")
            '    nb.Text = Me.gvLista.DataKeys(e.Row.RowIndex).Values(5)

            'Else
            '    ' ES INDIVIDUAL
            Dim cds3 As New cENTREGASOLICITUDES

            Dim maxentregas As Integer = cds3.ObtenerNumeroEntregas(idsol, Session("IdEstablecimiento"))

            Dim entregas1 As Decimal
            entregas1 = Me.gvLista.DataKeys(e.Row.RowIndex).Values(1)

            Dim txtAd As New DropDownList
            txtAd = e.Row.FindControl("cboEntr")

            If maxentregas = 1 Then
                txtAd.Items.Add("1")
            ElseIf maxentregas = 2 Then
                txtAd.Items.Add("1")
                txtAd.Items.Add("2")
            ElseIf maxentregas = 3 Then
                txtAd.Items.Add("1")
                txtAd.Items.Add("2")
                txtAd.Items.Add("3")
            End If

            txtAd.SelectedItem.Text = CInt(entregas1)
            'End If



            'Chequear si ya existe especificacion
            Dim lb As LinkButton
            lb = e.Row.FindControl("LinkButton11")

            Dim idproducto, idespecificacion As Integer
            idproducto = Me.gvLista.DataKeys(e.Row.RowIndex).Values(0)

            idespecificacion = IIf(IsDBNull(Me.gvLista.DataKeys(e.Row.RowIndex).Values(2)), 0, Me.gvLista.DataKeys(e.Row.RowIndex).Values(2))
            Dim cds As New cDETALLESOLICITUDES
            If cds.ExisteEspecificacion(Session("IdEstablecimiento"), idproducto, idespecificacion) > 0 Then
                lb.Text = Me.gvLista.DataKeys(e.Row.RowIndex).Values(3)
                lb.Visible = True
            Else
                lb.Text = "Adicionar >>"
                lb.Visible = True
            End If

        End If
    End Sub
    Private Sub CargarDatosP2() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cDETALLESOLICITUDES

        ds = mComponente.obtenerProductosSolicitud(Session("IdEstablecimiento"), idsol)
        'lo de compra conjunta o individual
        'If Me.DropDownList3.SelectedValue = 0 Then
        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try
        'Else
        'Me.GridView4.DataSource = ds

        'Try
        '    Me.GridView4.DataBind()
        'Catch ex As Exception
        '    GridView4.PageIndex = 0
        '    Me.GridView4.DataBind()
        'End Try
        'End If


    End Sub

    Private Function actualizarProductos() As String

        Dim arr As New ArrayList

        For Each row As GridViewRow In gvLista.Rows

            Dim eComponente As New PRODUCTOSSOLICITUD

            eComponente.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            eComponente.IDSOLICITUD = idsol
            eComponente.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values(0)
            'eComponente.IDENTREGA = Me.gvLista.DataKeys(row.RowIndex).Values(1)
            If Me.gvLista.Columns(5).Visible = True Then
                eComponente.IDENTREGA = CInt(CType(row.Cells(5).Controls(1), DropDownList).SelectedItem.Text)
            Else
                eComponente.CANTIDAD = CInt(CType(row.Cells(6).Controls(1), eWorld.UI.NumericBox).Text)
            End If

            'eComponente.OBSERVACION = Me.gvLista.DataKeys(row.RowIndex).Values(2)
            eComponente.IDDEPENDENCIA = Session("IdDependencia")
            eComponente.RENGLON = Me.gvLista.DataKeys(row.RowIndex).Values(4)
            eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eComponente.AUFECHAMODIFICACION = Now

            arr.Add(eComponente)

        Next

        If arr.Count > 0 Then

            Dim cComponente As New cDETALLESOLICITUDES
            If cComponente.actualizarProductoSolicitud(arr) = -1 Then
                Return "Error al guardar el registro. Intente nuevamente"
            End If

        End If

        Return ""

    End Function

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim idproducto As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim iddependencia As Integer = Session("IdDependencia")
        Dim idespecificacion As Integer
        If IsDBNull(Me.gvLista.DataKeys(e.RowIndex).Values(2)) Then
            idespecificacion = 0
        Else
            idespecificacion = Me.gvLista.DataKeys(e.RowIndex).Values(2)
        End If

        ' validar que no existan datos con cantidades <>0 en AES
        Dim caes As New cALMACENESENTREGASOLICITUD
        'If caes.ExistenRegistrosAES(idsol, Session("IdEstablecimiento"), idproducto) <> 0 Then
        '    'existen registros con distribuciones de cantidad en aes
        '    Me.MsgBox1.ShowAlert("No se puede eliminar este producto ya que tiene una distribución de cantidades ingresada, proceda a eliminar esta distribución antes de eliminar el producto de esta solicitud.", "Exito", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        '    Exit Sub
        'End If
        Try
            caes.borrarAlmacenesEntregaSolicitudyPS(idsol, Session("IdEstablecimiento"), idproducto, iddependencia, idespecificacion)

            CargarDatosP2()
        Catch ex As Exception
            MsgBox1.ShowAlert("Se produujo un error al eliminar el producto.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End Try



    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Me.LblDescripcionCompleta.Text = "" Then
            MsgBox1.ShowAlert("La operación no puede ser realizada por que no se ha especificado ningun producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Focus()
            Exit Sub
        End If

        Dim eComponente As New PRODUCTOSSOLICITUD
        Dim cComponente As New cDETALLESOLICITUDES

        eComponente.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        eComponente.IDSOLICITUD = idsol
        eComponente.IDPRODUCTO = Me.Label4.Text
        eComponente.IDENTREGA = 1
        eComponente.OBSERVACION = ""
        eComponente.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eComponente.AUFECHACREACION = Now
        eComponente.CANTIDAD = 0
        eComponente.IDDEPENDENCIA = Session.Item("IdDependencia")

        If cComponente.agregarProductossolicitud(eComponente) < 1 Then
            Me.MsgBox1.ShowAlert("Error al guardar el registro.  Verifique que el producto seleccionado no exista en la solicitud.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call borrar(sender, e)

        Call CargarDatosP2()

    End Sub
    Private Sub borrar(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.rdblCriterio.SelectedIndex = 0
        Call rdblCriterio_SelectedIndexChanged(sender, e)
        Me.LblDescripcionCompleta.Visible = False
        Me.TxtProducto.Text = String.Empty
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        borrar(sender, e)
    End Sub

   
    Public Sub cargarlosdatos(ByVal idestablecimiento As Integer, ByVal idsol As Integer)
        Dim cds As New cDETALLESOLICITUDES
        Me.gvLista.DataSource = cds.obtenerProductosSolicitud(idestablecimiento, idsol)
        gvLista.DataBind()
    End Sub



   
    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Response.Redirect("~/ESTABLECIMIENTOS/FrmAdicionarEspecificacion.aspx?idprod=" & Me.gvLista.DataKeys(row.RowIndex).Values(0) & "&renglon=" & Me.gvLista.DataKeys(row.RowIndex).Values(4) & "&idesp=" & Me.gvLista.DataKeys(row.RowIndex).Values(2) & "&btndet=" & btnDetails.Text & "&idsol=" & idsol & "&idsu=" & Request.QueryString("idsu") & "&cj=1")

    End Sub


    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
        'evento guardar
        If Me.gvLista.Rows.Count > 0 Then

            Dim sError As String

            'validar dos productos iguales sin especificacion tecnica
            Dim idprod As Integer = 0
            Dim ides As Integer = 0
            For Each row As GridViewRow In gvLista.Rows
                If idprod = Me.gvLista.DataKeys(row.RowIndex).Values(0) And ides = IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(2)), 0, Me.gvLista.DataKeys(row.RowIndex).Values(2)) Then
                    Me.MsgBox1.ShowAlert("Existen dos productos iguales sin especificaciones técnicas", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Exit Sub
                End If
                idprod = Me.gvLista.DataKeys(row.RowIndex).Values(0)
                ides = IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(2)), 0, Me.gvLista.DataKeys(row.RowIndex).Values(2))
            Next

            If Me.gvLista.Columns(5).Visible = True Then
                sError = Me.actualizarProductos()
            Else
                Dim cant As Integer
                For Each row As GridViewRow In gvLista.Rows

                    cant = CType(Me.gvLista.Rows(row.RowIndex).Cells(6).Controls(1), eWorld.UI.NumericBox).Text 'DataKeys(row.RowIndex).Values(5)

                    If cant = 0 Or IsDBNull(cant) Then
                        Me.MsgBox1.ShowAlert("Existen Productos sin una cantidad ingresada.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Exit Sub
                    End If
                Next
                sError = Me.actualizarProductos()
            End If

            If sError <> "" Then
                Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Return
            Else
                If Me.gvLista.Columns(5).Visible = True Then
                    Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompraDistribucion.aspx?idsol=" & idsol & "&idsu=" & Request.QueryString("idsu") & "&cj=" & Request.QueryString("cj"))
                Else

                    'codigo para actualizar el monto en la tabla solicitud
                    Dim MONTO As Decimal = 0
                    For Each row As GridViewRow In Me.gvLista.Rows
                        Dim cp As New cCATALOGOPRODUCTOS
                        Dim PRECIO As Decimal = cp.DevolverPrecioProducto(Me.gvLista.DataKeys(row.RowIndex).Values(0))
                        MONTO += PRECIO * CInt(CType(Me.gvLista.Rows(row.RowIndex).Cells(6).Controls(1), eWorld.UI.NumericBox).Text)
                    Next
                    Dim cds As New cSOLICITUDES
                    Dim S As New SOLICITUDES
                    S.MONTOSOLICITADO = MONTO
                    S.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    S.IDSOLICITUD = idsol
                    cds.ActualizarMontoSolicitado(S)

                    Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudesConsolidadas.aspx", True) '?idsol=" & idsol & "&idsu=" & Request.QueryString("idsu"))
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        'Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?idsol=" & idsol & "&R=0")
        Me.Panel3.Visible = False
        Me.Panel10.Visible = True
    End Sub

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        'solicitud
        For Each row As GridViewRow In dgLista.Rows

            If CType(row.FindControl("Checkbox1"), CheckBox).Checked() Then

                Dim idsolicitudd As Integer = Me.dgLista.DataKeys(row.RowIndex).Values(0)
                Dim iddependencia As Integer = Me.dgLista.DataKeys(row.RowIndex).Values(1)

                Dim cds As New cDETALLESOLICITUDES

                Dim ds As New Data.DataSet

                ds = cds.obtenerProductosSolicitudConsolidar(Session("IdEstablecimiento"), idsolicitudd, iddependencia)

                'productos
                Dim dr As Data.DataRow

                For Each dr In ds.Tables(0).Rows

                    'buscar si el producto ya existe
                    Dim valor As Integer
                    valor = cds.ExisteProductosolicitud2(Session("IdEstablecimiento"), idsol, dr("IdProducto"), IIf(IsDBNull(dr("IdEspecificacion")), 0, dr("IdEspecificacion")))
                    If valor > 0 Then

                        Dim cps As New cDETALLESOLICITUDES
                        Dim ds1 As New Data.DataSet
                        ds1 = cps.obtenerUnProductosSolicitud(Session("IdEstablecimiento"), idsol, dr("idproducto"), IIf(IsDBNull(dr("IdEspecificacion")), 0, dr("IdEspecificacion")))

                        Dim ps As New PRODUCTOSSOLICITUD
                        ps.CANTIDAD = ds1.Tables(0).Rows(0).Item(0) + dr("cantidad")
                        ps.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        ps.IDSOLICITUD = idsol
                        ps.IDPRODUCTO = dr("idproducto")
                        'ps.IDESPECIFICACION = dr("IdEspecificacion")
                        ps.RENGLON = ds1.Tables(0).Rows(0).Item(1)
                        cds.actualizarProductoSolicitud2(ps)
                    Else
                        Dim ps As New PRODUCTOSSOLICITUD
                        ps.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                        ps.IDSOLICITUD = idsol
                        ps.IDPRODUCTO = dr("idproducto")
                        ps.IDENTREGA = dr("identrega")
                        ps.OBSERVACION = " "
                        ps.AUUSUARIOCREACION = User.Identity.Name
                        ps.AUFECHACREACION = Date.Now
                        ps.IDDEPENDENCIA = Session("IdDependencia")
                        ps.CANTIDAD = dr("cantidad")
                        If Not IsDBNull(dr("IdEspecificacion")) Then
                            ps.IDESPECIFICACION = dr("IdEspecificacion")
                        Else
                            ps.IDESPECIFICACION = 0
                        End If
                        cds.agregarProductossolicitud(ps)
                    End If
                Next

            End If

        Next

        'actualizar el estado de las solicitudes seleccionadas a 3 Autorizada
        For Each row As GridViewRow In dgLista.Rows
            If CType(row.FindControl("Checkbox1"), CheckBox).Checked() Then
                Dim idsolicitudd As Integer = Me.dgLista.DataKeys(row.RowIndex).Values(0)
                Dim iddependencia As Integer = Me.dgLista.DataKeys(row.RowIndex).Values(1)
                Dim cs As New cSOLICITUDES
                Dim s As New SOLICITUDES
                s.IDSOLICITUD = idsolicitudd
                s.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                s.IDESTADO = 3 ' autorizada
                s.AUUSUARIOCREACION = User.Identity.Name
                s.AUUSUARIOMODIFICACION = User.Identity.Name
                s.AUFECHACREACION = DateTime.Now
                s.AUFECHAMODIFICACION = DateTime.Now
                cs.ActualizarEstado(s)
            End If
        Next

        Me.dgLista.Enabled = False
        Me.Button11.Enabled = False

        Me.MsgBox1.ShowAlert("La consolidación se realizó de forma exitosa.", "f", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

    End Sub

    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click
        Me.Panel3.Visible = True
        Me.Panel10.Visible = False

        Dim cds As New cDETALLESOLICITUDES
        Me.gvLista.DataSource = cds.obtenerProductosSolicitud(Session("IdEstablecimiento"), idsol)
        gvLista.DataBind()


    End Sub

    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click
        Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?id=" & idsol & "&R=0&c=1&cj=" & Request.QueryString("cj"))
    End Sub



    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        'consultar solicitud

        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim t As String
        t = Me.dgLista.DataKeys(row.RowIndex).Values(2)

       

        Dim alerta As String = CType(("/ESTABLECIMIENTOS/FrmFiltroEspecificacion.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "&t=" & t), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)

        'Mostrar el reporte

    End Sub


    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'Actualizar el estado en una solicitud
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim cs As New cSOLICITUDES
        'cs.EliminarTodaLaSOLICITUD(Session("IdEstablecimiento"), Me.dgLista.DataKeys(row.RowIndex).Values(0))
        Dim s As New SOLICITUDES
        s.IDSOLICITUD = Me.dgLista.DataKeys(row.RowIndex).Values(0)
        s.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        s.IDESTADO = 1 ' grabada
        s.AUUSUARIOCREACION = User.Identity.Name
        s.AUUSUARIOMODIFICACION = User.Identity.Name
        s.AUFECHACREACION = DateTime.Now
        s.AUFECHAMODIFICACION = DateTime.Now
        cs.ActualizarEstado(s)

        Dim cds As New cDETALLESOLICITUDES
        'TODO: cambiar el estado al correcto
        Me.dgLista.DataSource = cds.ObtenerSolicitudesAConsolidar(Request.QueryString("idsu"), 2)
        Me.dgLista.DataBind()
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.ddlGRUPOS1.RecuperarListaFiltradaPorUT(Me.ddlSUMINISTROS1.SelectedValue, Request.QueryString("idsu"))

        Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Request.QueryString("idsu"))

        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Request.QueryString("idsu"))
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Request.QueryString("idsu"))

        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Request.QueryString("idsu"))
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Request.QueryString("idsu"))
    End Sub
End Class
