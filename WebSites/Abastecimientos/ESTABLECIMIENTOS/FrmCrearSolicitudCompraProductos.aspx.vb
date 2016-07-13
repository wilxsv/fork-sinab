Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class ESTABLECIMIENTOS_FrmCrearSolicitudCompraProductos
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            idsol = Request.QueryString("id")
            Dim idsuministro, grupouaci As Integer
            idsuministro = Request.QueryString("idsu")
            grupouaci = Request.QueryString("gu")
            Session("IDSUMINISTROCDD") = idsuministro
            Session("GRUPOUACICDD") = grupouaci
            ' Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXSuministro(idsuministro)

            If Request.QueryString("cj") Is Nothing Or Request.QueryString("cj") = "" Then
                Dim cds As New cDETALLESOLICITUDES
                Dim ds As New Data.DataSet
                ds = cds.obtenerProductosSolicitud(Session("IdEstablecimiento"), idsol)
                Dim dv As New Data.DataView
                dv.Table = ds.Tables(0)
                dv.Sort = "CORRPRODUCTO"

                Me.Gridview1.DataSource = dv.Table
                Gridview1.DataBind()
                Me.gvLista.Visible = False
            Else
                Dim cds As New cDETALLESOLICITUDES
                Dim ds As New Data.DataSet
                ds = cds.obtenerProductosSolicitud(Session("IdEstablecimiento"), idsol)
                Dim dv As New Data.DataView
                dv.Table = ds.Tables(0)
                dv.Sort = "CORRPRODUCTO"

                Me.gvLista.DataSource = dv.Table
                gvLista.DataBind()
                Me.Gridview1.Visible = False
            End If

            ''cargar filtros
            ''suministro:
            'Me.ddlSUMINISTROS1.RecuperarPorUnidadTecnicayGU(idsuministro, grupouaci)
            'Me.ddlSUMINISTROS1.SelectedIndex = 0
            ''grupo:
            'If Me.ddlSUMINISTROS1.Items.Count = 0 Then
            '    Me.MsgBox1.ShowAlert("No se encontraron productos asociados a la Unidad Técnica seleccionada y Tipo de Suministro para compra.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            '    Exit Sub
            'End If
            'Me.ddlGRUPOS1.RecuperarListaFiltradaPorUTyGU(Me.ddlSUMINISTROS1.SelectedValue, idsuministro, grupouaci)
            'Me.ddlGRUPOS1.SelectedIndex = 0
            ''subgrupo:
            'Dim idGrupo As Integer = 0
            'If Not Me.ddlGRUPOS1.SelectedValue = "" Then
            '    idGrupo = Me.ddlGRUPOS1.SelectedValue
            'End If

            'Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUTyGU(idGrupo, idsuministro, grupouaci)
            'Me.ddlSUBGRUPOS1.SelectedIndex = 0
            ''producto
            'Dim idSubGrupo As Integer = 0
            'If Not Me.ddlSUBGRUPOS1.SelectedValue = "" Then
            '    idSubGrupo = Me.ddlSUBGRUPOS1.SelectedValue
            'End If
            'Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUTyGU(idSubGrupo, idsuministro, grupouaci)



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
            '   BuscarProductoLista()
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
            Me.lblIDProducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
            Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
            Me.LblDescripcionCompleta.Visible = True
        End If
    End Function

    Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
        'Dim dsCatalogoProductos As Data.DataSet
        'Dim mCompCatalogoProductos As New cCATALOGOPRODUCTOS
        'dsCatalogoProductos = mCompCatalogoProductos.FiltrarProductoDS(Me.DdlCATALOGOPRODUCTOS1.SelectedValue, 1)

        'If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
        '    MsgBox1.ShowAlert("El código del producto no fue encontrado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        '    Me.TxtProducto.Text = ""
        '    Me.TxtProducto.Focus()
        'Else
        '    'SeleccionarLote()
        '    '  Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
        '    Me.Label4.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
        '    Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
        '    Me.LblDescripcionCompleta.Visible = True
        'End If
        lblIDProducto.Text = DdlCATALOGOPRODUCTOS1.SelectedValue
    End Sub
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click


        Dim dsCatalogoProductos As Data.DataSet
        Dim mcompcatalogoproductos As New cCATALOGOPRODUCTOS

        dsCatalogoProductos = mcompcatalogoproductos.FiltrarProductoDSUTyGUSuminitro(Me.TxtProducto.Text, 2, Session("IDSUMINISTROCDD"), Session("GRUPOUACICDD"), 1)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("El código del producto no fue encontrado.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtProducto.Text = ""
            Me.TxtProducto.Focus()
        Else
            Try
                'Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                Me.lblIDProducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
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

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            'ES CONJUNTA

            Me.LinkButton8.Text = "Finalizar"

            Dim nb As New eWorld.UI.NumericBox
            nb = e.Row.FindControl("NumericBox5")
            nb.Text = Me.gvLista.DataKeys(e.Row.RowIndex).Values(5)

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

        If Request.QueryString("cj") Is Nothing Or Request.QueryString("cj") = "" Then
            Me.Gridview1.DataSource = ds

            Try
                Me.Gridview1.DataBind()
            Catch ex As Exception
                Gridview1.PageIndex = 0
                Me.Gridview1.DataBind()
            End Try
        Else
            Me.gvLista.DataSource = ds
            Try
                Me.gvLista.DataBind()
            Catch ex As Exception
                gvLista.PageIndex = 0
                Me.gvLista.DataBind()
            End Try
        End If
    End Sub

    Private Function actualizarProductos() As String

        Dim arr As New ArrayList

        If Request.QueryString("cj") = Nothing Or Request.QueryString("cj") = "" Then
            For Each row As GridViewRow In Gridview1.Rows

                Dim eComponente As New PRODUCTOSSOLICITUD

                eComponente.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                eComponente.IDSOLICITUD = idsol
                eComponente.IDPRODUCTO = Me.Gridview1.DataKeys(row.RowIndex).Values(0)
                'eComponente.IDENTREGA = Me.gvLista.DataKeys(row.RowIndex).Values(1)

                eComponente.IDENTREGA = CInt(CType(row.Cells(5).Controls(1), DropDownList).SelectedItem.Text)

                'eComponente.OBSERVACION = Me.gvLista.DataKeys(row.RowIndex).Values(2)
                eComponente.IDDEPENDENCIA = Session("IdDependencia")
                eComponente.RENGLON = Me.Gridview1.DataKeys(row.RowIndex).Values(4)
                eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eComponente.AUFECHAMODIFICACION = Now
                eComponente.PRECIOUNITARIO = CDec(CType(row.Cells(4).Controls(1), TextBox).Text)
                If Not IsDBNull(Gridview1.DataKeys(row.RowIndex).Values(2)) Then
                    eComponente.IDESPECIFICACION = Me.Gridview1.DataKeys(row.RowIndex).Values(2).ToString
                Else
                    eComponente.IDESPECIFICACION = 0
                End If



                arr.Add(eComponente)

            Next
        Else
            For Each row As GridViewRow In gvLista.Rows

                Dim eComponente As New PRODUCTOSSOLICITUD

                eComponente.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                eComponente.IDSOLICITUD = idsol
                eComponente.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values(0)
                'eComponente.IDENTREGA = Me.gvLista.DataKeys(row.RowIndex).Values(1)

                eComponente.CANTIDAD = CInt(CType(row.Cells(5).Controls(1), eWorld.UI.NumericBox).Text)

                'eComponente.OBSERVACION = Me.gvLista.DataKeys(row.RowIndex).Values(2)
                eComponente.IDDEPENDENCIA = Session("IdDependencia")
                eComponente.RENGLON = Me.gvLista.DataKeys(row.RowIndex).Values(4)
                eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eComponente.AUFECHAMODIFICACION = Now
                eComponente.PRECIOUNITARIO = CDec(CType(row.Cells(4).Controls(1), TextBox).Text)
                If Not IsDBNull(Gridview1.DataKeys(row.RowIndex).Values(2)) Then
                    eComponente.IDESPECIFICACION = Me.Gridview1.DataKeys(row.RowIndex).Values(2).ToString
                Else
                    eComponente.IDESPECIFICACION = 0
                End If
                arr.Add(eComponente)

            Next
        End If



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


        'If Me.LblDescripcionCompleta.Text = "" Then
        '    MsgBox1.ShowAlert("La operación no puede ser realizada por que no se ha especificado ningun producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        '    Me.TxtProducto.Focus()
        '    Exit Sub
        'End If

        Dim eComponente As New PRODUCTOSSOLICITUD
        Dim cComponente As New cDETALLESOLICITUDES

        eComponente.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        eComponente.IDSOLICITUD = idsol
        eComponente.IDPRODUCTO = lblIDProducto.Text ' TxtProducto.Text
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
        If Request.QueryString("cj") <> 0 Then
            Me.gvLista.DataSource = cds.obtenerProductosSolicitud(idestablecimiento, idsol)
            gvLista.DataBind()
        Else
            Me.Gridview1.DataSource = cds.obtenerProductosSolicitud(idestablecimiento, idsol)
            Gridview1.DataBind()
        End If

    End Sub



    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Response.Redirect("~/ESTABLECIMIENTOS/FrmAdicionarEspecificacion.aspx?idprod=" & Me.gvLista.DataKeys(row.RowIndex).Values(0) & "&renglon=" & Me.gvLista.DataKeys(row.RowIndex).Values(4) & "&idesp=" & Me.gvLista.DataKeys(row.RowIndex).Values(2) & "&btndet=" & btnDetails.Text & "&idsol=" & idsol & "&idsu=" & Request.QueryString("idsu") & "&cj=1")

    End Sub

    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Response.Redirect("~/ESTABLECIMIENTOS/FrmAdicionarEspecificacion.aspx?idprod=" & Me.Gridview1.DataKeys(row.RowIndex).Values(0) & "&renglon=" & Me.Gridview1.DataKeys(row.RowIndex).Values(4) & "&idesp=" & Me.Gridview1.DataKeys(row.RowIndex).Values(2) & "&btndet=" & btnDetails.Text & "&idsol=" & idsol & "&idsu=" & Request.QueryString("idsu"))

    End Sub
    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
        'evento guardar

        If Request.QueryString("cj") Is Nothing Or Request.QueryString("cj") = "" Then
            If Me.Gridview1.Rows.Count > 0 Then

                Dim sError As String

                'validar dos productos iguales sin especificacion tecnica
                Dim idprod As Integer = 0
                Dim ides As Integer = 0
                For Each row As GridViewRow In Gridview1.Rows
                    If idprod = Me.Gridview1.DataKeys(row.RowIndex).Values(0) And ides = IIf(IsDBNull(Me.Gridview1.DataKeys(row.RowIndex).Values(2)), 0, Me.Gridview1.DataKeys(row.RowIndex).Values(2)) Then
                        Me.MsgBox1.ShowAlert("Existen dos productos iguales sin especificaciones técnicas", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Exit Sub
                    End If
                    idprod = Me.Gridview1.DataKeys(row.RowIndex).Values(0)
                    ides = IIf(IsDBNull(Me.Gridview1.DataKeys(row.RowIndex).Values(2)), 0, Me.Gridview1.DataKeys(row.RowIndex).Values(2))
                Next


                sError = Me.actualizarProductos()


                If sError <> "" Then
                    Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Return
                Else
                    Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompraDistribucion.aspx?idsol=" & idsol & "&idsu=" & Request.QueryString("idsu") & "&R=" & Request.QueryString("R") & "&gu=" & Request.QueryString("gu"))
                End If
            Else
                Exit Sub
            End If
        Else
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


                Dim cant As Integer
                For Each row As GridViewRow In gvLista.Rows

                    cant = CType(Me.gvLista.Rows(row.RowIndex).Cells(5).Controls(1), eWorld.UI.NumericBox).Text 'DataKeys(row.RowIndex).Values(5)

                    If cant = 0 Or IsDBNull(cant) Then
                        Me.MsgBox1.ShowAlert("Existen Productos sin una cantidad ingresada.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Exit Sub
                    End If
                Next
                sError = Me.actualizarProductos()


                If sError <> "" Then
                    Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Return
                Else

                    'codigo para actualizar el monto en la tabla solicitud
                    Dim MONTO As Decimal = 0
                    For Each row As GridViewRow In Me.gvLista.Rows
                        Dim cp As New cCATALOGOPRODUCTOS
                        Dim PRECIO As Decimal = cp.DevolverPrecioProducto(Me.gvLista.DataKeys(row.RowIndex).Values(0))
                        MONTO += PRECIO * CInt(CType(Me.gvLista.Rows(row.RowIndex).Cells(5).Controls(1), eWorld.UI.NumericBox).Text)
                    Next
                    Dim cds As New cSOLICITUDES
                    Dim S As New SOLICITUDES
                    S.MONTOSOLICITADO = MONTO
                    S.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    S.IDSOLICITUD = idsol
                    cds.ActualizarMontoSolicitado(S)

                    Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx", True) '?idsol=" & idsol & "&idsu=" & Request.QueryString("idsu"))

                End If
            Else
                Exit Sub
            End If
        End If

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

        Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?id=" & idsol & "&R=0&cj=" & Request.QueryString("cj") & "&idsu=" & Request.QueryString("idsu") & "&gu=" & Request.QueryString("gu"))

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gridview1.PageIndexChanging
        Try
            'evento guardar
            Dim sError As String
            sError = Me.actualizarProductos()
        Catch ex As Exception

        End Try

        Me.Gridview1.PageIndex = e.NewPageIndex
        CargarDatosP2()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Gridview1.RowDataBound, gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            ' ES INDIVIDUAL
            Dim cds3 As New cENTREGASOLICITUDES

            Dim maxentregas As Integer = cds3.ObtenerNumeroEntregas(idsol, Session("IdEstablecimiento"))

            Dim entregas1 As Decimal
            entregas1 = Me.Gridview1.DataKeys(e.Row.RowIndex).Values(1)

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

            'Chequear si ya existe especificacion
            Dim lb As LinkButton
            lb = e.Row.FindControl("LinkButton12")

            Dim idproducto, idespecificacion As Integer
            idproducto = Me.Gridview1.DataKeys(e.Row.RowIndex).Values(0)

            idespecificacion = IIf(IsDBNull(Me.Gridview1.DataKeys(e.Row.RowIndex).Values(2)), 0, Me.Gridview1.DataKeys(e.Row.RowIndex).Values(2))
            Dim cds As New cDETALLESOLICITUDES
            If cds.ExisteEspecificacion(Session("IdEstablecimiento"), idproducto, idespecificacion) > 0 Then
                lb.Text = Me.Gridview1.DataKeys(e.Row.RowIndex).Values(3)
                lb.Visible = True
            Else
                lb.Text = "Adicionar >>"
                lb.Visible = True
            End If

        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Gridview1.RowDeleting
        Dim idproducto As Integer = Me.Gridview1.DataKeys(e.RowIndex).Values(0)
        Dim iddependencia As Integer = Session("IdDependencia")
        Dim idespecificacion As Integer
        If IsDBNull(Me.Gridview1.DataKeys(e.RowIndex).Values(2)) Then
            idespecificacion = 0
        Else
            idespecificacion = Me.Gridview1.DataKeys(e.RowIndex).Values(2)
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
            '  GridView1.DataBind()
        Catch ex As Exception
            MsgBox1.ShowAlert("Se produujo un error al eliminar el producto.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Exit Sub
        End Try

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        'Me.ddlGRUPOS1.RecuperarListaFiltradaPorUT(Me.ddlSUMINISTROS1.SelectedValue, Request.QueryString("idsu"))
     
        'Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Request.QueryString("idsu"))
        
        'Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Request.QueryString("idsu"))

    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        'Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Request.QueryString("idsu"))

        'Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Request.QueryString("idsu"))

    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        '  Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Request.QueryString("idsu"))
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "A" Then
            Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx")
        End If
    End Sub
End Class
