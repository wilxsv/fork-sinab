
Partial Class URMIM_CorreccionLotesMuestreados
    Inherits System.Web.UI.Page

    Private _IDPROCESOCOMPRA As Integer
    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _RENGLON As Integer
    Private _IDPRODUCTO As Integer

    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", value)
        End Set
    End Property
    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property
    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property
    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property
    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Integer)
            _RENGLON = value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", value)
        End Set
    End Property
    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Dim dPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
            Me.GridView1.DataSource = dPC.ObtenerProcesoCompraAdjudicados()
            Me.GridView1.DataBind()
        Else
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.RENGLON = Me.ViewState("RENGLON")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.IDPRODUCTO = Me.ViewState("IDPRODUCTO")

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Me.pnProveedores.Visible = True
        Dim cP As New ABASTECIMIENTOS.NEGOCIO.cPROVEEDORES
        IDPROCESOCOMPRA = Me.GridView1.DataKeys(e.NewSelectedIndex).Values(1)
        IDESTABLECIMIENTO = Me.GridView1.DataKeys(e.NewSelectedIndex).Values(0)

        Me.lblEstablecimiento.Text = Server.HtmlDecode(Me.GridView1.Rows(e.NewSelectedIndex).Cells(3).Text)
        Me.lblNPC.Text = Server.HtmlDecode(CType(Me.GridView1.Rows(e.NewSelectedIndex).FindControl("Linkbutton1"), LinkButton).Text)
        Me.lblPC.Text = Server.HtmlDecode(Me.GridView1.Rows(e.NewSelectedIndex).Cells(1).Text)

        Me.GridView2.DataSource = cP.obtenerProveedoresAdj(IDESTABLECIMIENTO, IDPROCESOCOMPRA, True, Session.Item("IdEmpleado"))
        Me.GridView2.DataBind()

        Me.GridView2.SelectedIndex = -1
        Me.GridView3.SelectedIndex = -1
        Me.pnRenglones.Visible = False
    End Sub

    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView2.SelectedIndexChanging
        Me.pnRenglones.Visible = True
        Dim cA As New ABASTECIMIENTOS.NEGOCIO.cADJUDICACION
        IDPROVEEDOR = Me.GridView2.DataKeys(e.NewSelectedIndex).Values(0)
        IDCONTRATO = Me.GridView2.DataKeys(e.NewSelectedIndex).Values(1)

        Me.lblProveedor.Text = Server.HtmlDecode(CType(Me.GridView2.Rows(e.NewSelectedIndex).FindControl("Linkbutton1"), LinkButton).Text)
        Me.lblNoDoc.Text = Server.HtmlDecode(Me.GridView2.Rows(e.NewSelectedIndex).Cells(1).Text)

        Me.GridView3.DataSource = cA.ObtenerRenglonesAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, Session.Item("IdEmpleado"))
        Me.GridView3.DataBind()
    End Sub

    Protected Sub GridView3_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView3.SelectedIndexChanging
        Me.lblRenglon.Text = Server.HtmlDecode(CType(Me.GridView3.Rows(e.NewSelectedIndex).FindControl("Linkbutton1"), LinkButton).Text)
        RENGLON = Me.lblRenglon.Text
        Me.lblProducto.Text = Server.HtmlDecode(Me.GridView3.Rows(e.NewSelectedIndex).Cells(1).Text) & " - " & Server.HtmlDecode(Me.GridView3.Rows(e.NewSelectedIndex).Cells(2).Text)
        Me.Label4.Text = Server.HtmlDecode(Me.GridView3.Rows(e.NewSelectedIndex).Cells(2).Text)
        Me.Label2.Text = Me.GridView3.DataKeys(e.NewSelectedIndex).Values.Item("UNIDAD_MEDIDA")
        Me.Label3.Text = Me.GridView3.DataKeys(e.NewSelectedIndex).Values.Item("UNIDAD_MEDIDA")
        IDPRODUCTO = Me.GridView3.DataKeys(e.NewSelectedIndex).Values.Item("IDPRODUCTO")

        Me.pnRenglones.Visible = False
        Me.pnProveedores.Visible = False
        Me.pnPC.Visible = False
        Me.pnMan.Visible = True

        Me.ddlUNIDADMEDIDAS1.RecuperarPorSuministro(1)
        Me.DdlUNIDADMEDIDAS2.RecuperarPorSuministro(1)

        Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Me.GridView4.DataSource = cIM.ObtenerLotesNotificados(IDESTABLECIMIENTO, IDPROVEEDOR, Me.lblRenglon.Text, IDPROCESOCOMPRA, IDCONTRATO, Session("IdEmpleado"))
        Me.GridView4.DataBind()



    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Me.pnRenglones.Visible = True
        Me.pnProveedores.Visible = True
        Me.pnPC.Visible = True
        Me.pnMan.Visible = False
        Me.Panel1.Visible = False

        Me.GridView3.SelectedIndex = -1
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Panel1.Visible = True
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Panel1.Visible = False
        Me.GridView4.SelectedIndex = -1
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Dim IM As New ABASTECIMIENTOS.ENTIDADES.INFORMEMUESTRAS
        'validaciones
        If Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Then
            Me.Label1.Text = "El nombre comercial/Laboratorio fabricante/No.de lote son requeridos."
            Exit Sub
        End If
        If CDate((Me.DropDownList3.SelectedValue & Me.DropDownList4.SelectedValue)) < Now Then
            Me.Label1.Text = "La fecha de vencimiento debe ser posterior a la fecha actual."
            Exit Sub
        End If

        Try

            IM.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            IM.IDINFORME = 0
            IM.IDTIPOINFORME = eTIPOINFORME.ACEPTACION
            'im.NUMEROINFORME =
            IM.IDESTADO = 1
            IM.IDESTABLECIMIENTOCONTRATO = IDESTABLECIMIENTO
            IM.IDPROVEEDOR = IDPROVEEDOR
            IM.IDCONTRATO = IDCONTRATO
            IM.RENGLON = RENGLON
            IM.NOMBREMEDICAMENTO = Me.Label4.Text
            IM.NOMBRECOMERCIAL = Me.TextBox2.Text
            IM.LABORATORIOFABRICANTE = Me.TextBox3.Text
            IM.PROVEEDOR = Me.lblProveedor.Text
            IM.LOTE = Me.TextBox4.Text
            IM.FECHAFABRICACION = Me.DropDownList1.SelectedValue & Me.DropDownList2.SelectedValue
            IM.FECHAVENCIMIENTO = Me.DropDownList3.SelectedValue & Me.DropDownList4.SelectedValue
            IM.NUMEROUNIDADES = Me.GridView4.DataKeys(Me.GridView4.SelectedIndex).Values(2)
            IM.CANTIDADREMITIDA = Me.NumericBox1.Text
            IM.ESTABLECIMIENTOREMITE = ""
            'im.NUMERORECEPCION =
            'im.GUIAAEREA =
            'im.DESCRIPCIONEMPAQUE =
            IM.LEYENDAREQUERIDA = 0
            IM.NUMEROREGISTRO = 0
            IM.VIAADMINISTRACION = 0
            IM.FORMADISOLUCION = 0
            IM.CONDICIONESALMACENAMIENTO = 0
            IM.NUMEROLOTE = 0
            IM.FECHAEXPIRACION = 0
            IM.OTROSEMPAQUES = 0
            'im.DESCRIPCIONOTROSEMPAQUES =
            'im.DESCRIPCIONPRODUCTO =
            IM.CANTIDADFISICOQUIMICO = 0
            IM.CANTIDADMICROBIOLOGIA = 0
            IM.CANTIDADRETENCION = 0

            IM.IDINSPECTOR = Session("IdEmpleado")
            IM.FECHAELABORACIONINFORME = Now
            IM.IDCOORDINADOR = 0

            IM.AUUSUARIOCREACION = User.Identity.Name
            IM.AUFECHACREACION = Now
            IM.ESTASINCRONIZADA = 0

            IM.FECHANOTIFICACION = Me.CalendarPopup1.SelectedDate
            IM.NUMERONOTIFICACION = Me.Label5.Text 'Me.TextBox1.Text
            IM.CANTIDADAENTREGAR = Me.NumericBox2.Text
            IM.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            IM.IDPRODUCTO = IDPRODUCTO

            If Me.GridView4.SelectedIndex <> -1 Then
                IM.IDINFORME = Me.GridView4.DataKeys(Me.GridView4.SelectedIndex).Values(0)
            End If
            cIM.ActualizarINFORMEMUESTRAS(IM)

            Me.Panel1.Visible = False
            Me.Label1.Text = ""
            Me.GridView4.DataSource = cIM.ObtenerLotesNotificados(IDESTABLECIMIENTO, IDPROVEEDOR, Me.lblRenglon.Text, IDPROCESOCOMPRA, IDCONTRATO, Session("IdEmpleado"))
            Me.GridView4.SelectedIndex = -1
            Me.GridView4.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    'Protected Sub GridView4_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView4.RowDeleting
    '    Dim IDINFORME As Integer = Me.GridView4.DataKeys(e.RowIndex).Values(0)

    '    Dim CIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
    '    Try
    '        CIM.EliminarINFORMEMUESTRAS(IDESTABLECIMIENTO, IDINFORME)
    '    Catch ex As Exception

    '    End Try
    '    Me.GridView4.DataSource = CIM.ObtenerLotesNotificados(IDESTABLECIMIENTO, IDPROVEEDOR, Me.lblRenglon.Text, IdProcesoCompra, IDCONTRATO)
    '    Me.GridView4.SelectedIndex = -1
    '    Me.GridView4.DataBind()

    'End Sub

    Protected Sub GridView4_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView4.SelectedIndexChanging

        Me.TextBox2.Text = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(2).Text)
        Me.TextBox3.Text = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(3).Text)
        Me.TextBox4.Text = Server.HtmlDecode(CType(Me.GridView4.Rows(e.NewSelectedIndex).FindControl("Linkbutton3"), LinkButton).Text)


        Me.DropDownList1.SelectedValue = CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(5).Text)).Day & "/" & CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(5).Text)).Month
        Me.DropDownList2.SelectedValue = "/" & CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(5).Text)).Year

        Me.DropDownList3.SelectedValue = CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(6).Text)).Day & "/" & CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(6).Text)).Month
        Me.DropDownList4.SelectedValue = "/" & CDate(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(6).Text)).Year

        Me.NumericBox2.Text = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(4).Text)
        Me.CalendarPopup1.SelectedDate = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(1).Text)
        Me.Label5.Text = Me.GridView4.DataKeys(e.NewSelectedIndex).Values(1)

        If String.IsNullOrEmpty(Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(7).Text)) Then
            Me.NumericBox1.Text = 0
        Else
            Me.NumericBox1.Text = Server.HtmlDecode(Me.GridView4.Rows(e.NewSelectedIndex).Cells(7).Text)
        End If

        Me.Panel1.Visible = True

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.GridView4.Rows.Count <> 0 Then
            ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptNotificacionLotes.aspx?Renglon=" & Me.lblRenglon.Text & "&IdE=" & IDESTABLECIMIENTO & "&idProveedor=" & IDPROVEEDOR & "&IdP=" & IDPROCESOCOMPRA & "&idContrato=" & IDCONTRATO & "&um=" & Me.Label2.Text & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")
        Else

        End If

    End Sub
End Class
