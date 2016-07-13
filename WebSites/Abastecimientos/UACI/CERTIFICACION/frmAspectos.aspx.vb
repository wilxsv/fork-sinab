Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Windows.Forms
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.CertificacionHelpers
Partial Class UACI_CERTIFICACION_frmAspectos
    Inherits System.Web.UI.Page

    Public Property IdAspecto() As Integer
        Get
            Return CType(ViewState("ida"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("ida") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim idp = CType(Request.QueryString("idp"), Decimal)
            Dim idpp = CType(Request.QueryString("idpp"), Decimal)
            Dim idtp = CType(Request.QueryString("idtp"), Decimal)
            Dim idprov = CType(Request.QueryString("idprov"), Decimal)

            Try
                Dim datos = Procesos.Obtener(idp, idtp)
                Me.Label3.Text = datos.NumeroProceso 'ds.Tables(0).Rows(0).Item("NUMPROCESO")

                Dim proveedor = Proveedores.Obtener(idp, idtp, idprov)
                Me.Label1.Text = proveedor.NIT '
                Me.Label2.Text = proveedor.NOMBRE

                Dim infoProducto = Helpers.Productos.ObtenerPorProveedor(idpp)
                Me.Label8.Text = infoProducto.CorrProducto
                Me.Label9.Text = infoProducto.DescLargo
                Me.Label10.Text = infoProducto.Nombre

                Cargardatos()
                mvAspectos.ActiveViewIndex = 0
            Catch ex As Exception
                SINAB_Utils.MessageBox.Alert("Error al cargar datos de los aspectos a evaluar. Error: " & ex.Message)
            End Try


        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Public Sub Cargardatos()

        'aspectos y lista
        Dim cp = ProductosProveedores.Obtener(CType(Request.QueryString("idpp"), Integer))
        Me.GridView1.DataSource = Aspectos.ObtenerTodos(cp)
        Me.GridView1.DataBind()

    End Sub
    
#Region "segundo"

    Protected Sub btnClose2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose2.Click
        mvAspectos.ActiveViewIndex = 0
    End Sub
    Protected Sub btnSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave2.Click

        Dim ap = New SAB_CP_ASPECTOSPRODUCTOS With {
        .IdAspectos = IdAspecto,
        .IdProductoProveedores = CType(Request.QueryString("idpp"), Integer),
        .estado = CType(rlEstado.SelectedValue, Integer),
        .Comentario = tbComnetarion.Text
        }

        If Not chbFechaEmision.Checked Then
            ap.fechaemision = CDate(tbFechaEmision.Text)
        End If

        If Not CheckBox1.Checked Then
            ap.fechavto = CDate(Me.tbFechaVenicimiento.Text)
        End If

        Try
            Dim aspectopp = AspectosProductos.Obtener(ap.IdAspectos, ap.IdProductoProveedores)
            If Not IsNothing(aspectopp) Then
                AspectosProductos.Actualizar(ap)
            Else
                AspectosProductos.Agregar(ap)
            End If
            Cargardatos()
            mvAspectos.ActiveViewIndex = 0
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert("Error al guardar nuevo estado. Error: " & ex.Message)
        End Try
    End Sub
#End Region

    Protected Sub Editar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'editar
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        
        IdAspecto = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        Dim idlista = CType(Me.GridView1.DataKeys(row.RowIndex).Values(1), Integer)
        Dim idpp = CType(Request.QueryString("idpp"), Integer)
       

        Dim aspectopp = AspectosProductos.Obtener(idaspecto, idpp)

        If IsNothing(aspectopp) Then
            aspectopp = New SAB_CP_ASPECTOSPRODUCTOS With {
                .IdAspectos = idaspecto,
                .IdProductoProveedores = idpp,
                .estado = EnumHelpers.EstadoAspectos.NoAplica
                }
            Dim aspecto = Aspectos.Obtener(idlista, idaspecto)
            Label4.Text = aspecto.nombre
            Label7.Text = aspecto.orden.ToString()
        Else
            Me.Label4.Text = aspectopp.Nombre
            Label7.Text = CType(aspectopp.SAB_CP_CAT_ASPECTOS.orden, String)
        End If

        

        If (Not IsNothing(aspectopp.fechaemision)) Then
            Me.chbFechaEmision.Checked = False
            Me.tbFechaEmision.Enabled = True
            Me.tbFechaEmision.Text = aspectopp.fechaemision.Value.ToShortDateString()
            Me.rfvFechaEmision.Enabled = True
            Me.rfvFechaEmision.Visible = True
            Me.cfvFechaEmision.Enabled = True
            Me.cfvFechaEmision.Visible = True
        Else
            Me.chbFechaEmision.Checked = True
            Me.tbFechaEmision.Text = ""
            Me.tbFechaEmision.Enabled = False
            Me.rfvFechaEmision.Enabled = False
            Me.rfvFechaEmision.Visible = False
            Me.cfvFechaEmision.Enabled = False
            Me.cfvFechaEmision.Visible = False
        End If

        If (Not IsNothing(aspectopp.fechavto)) Then
            Me.CheckBox1.Checked = False
            Me.tbFechaVenicimiento.Enabled = True
            Me.tbFechaVenicimiento.Text = aspectopp.fechavto.Value.ToShortDateString()
            Me.RequiredFieldValidator2.Enabled = True
            Me.RequiredFieldValidator2.Visible = True
            Me.CompareValidator1.Enabled = True
            Me.CompareValidator1.Visible = True

        Else
            Me.CheckBox1.Checked = True
            Me.tbFechaVenicimiento.Text = ""
            Me.tbFechaVenicimiento.Enabled = False
            Me.RequiredFieldValidator2.Enabled = False
            Me.RequiredFieldValidator2.Visible = False
            Me.CompareValidator1.Enabled = False
            Me.CompareValidator1.Visible = False
        End If

        Me.tbComnetarion.Text = aspectopp.Comentario
        Me.rlEstado.SelectedValue = CType(aspectopp.Estado, Integer).ToString()
        ' Me.TextBox8.Text = aspectopp.Pc

        mvAspectos.ActiveViewIndex = 1
    End Sub


    Protected Sub chbFechaEmision_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEmision.CheckedChanged
        If Me.chbFechaEmision.Checked Then
            Me.tbFechaEmision.Enabled = False
            Me.tbFechaEmision.Text = ""
            Me.rfvFechaEmision.Enabled = False
            Me.rfvFechaEmision.Visible = False
        Else
            Me.tbFechaEmision.Enabled = True
            Me.rfvFechaEmision.Enabled = True
            Me.rfvFechaEmision.Visible = True
        End If
    End Sub


    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked Then
            Me.tbFechaVenicimiento.Enabled = False
            Me.tbFechaVenicimiento.Text = ""
            Me.RequiredFieldValidator2.Enabled = False
            Me.RequiredFieldValidator2.Visible = False
        Else
            Me.tbFechaVenicimiento.Enabled = True
            Me.RequiredFieldValidator2.Enabled = True
            Me.RequiredFieldValidator2.Visible = True
        End If
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Response.Redirect("~/UACI/CERTIFICACION/frmProducto.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & Request.QueryString("idprov") & "&idproducto=" & Request.QueryString("idproducto") & "&idpp=" & Request.QueryString("idpp"))
    End Sub


    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

    '    Me.mdlPopup.Show()
    'End Sub

    'Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    Me.pnlPopup.Visible = False
    '    Me.Panel4.Visible = False
    '    Me.GridView1.Visible = True
    '    Me.PanelFiltro.Visible = True
    '    Me.btnClose.Visible = False
    '    Me.Button55.Visible = True
    '    idproducto = 0
    'End Sub

    'Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim btnDetails As Button = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

    '    idproducto = Me.GridView2.DataKeys(row.RowIndex).Values(0)

    '    Dim cx As New cProcesoCP
    '    cx.AgregarProductoProveedor(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto, HttpContext.Current.User.Identity.Name)


    '    Dim c As New cCATALOGOPRODUCTOS
    '    Me.Label4.Text = c.DevolverCodigoProducto(idproducto).ToString
    '    Me.Label5.Text = c.DevolverNombreProducto(idproducto).ToString

    '    Me.Label6.Text = cx.ObtenerIdLista(idproducto, Request.QueryString("idtp")).Tables(0).Rows(0).Item(1).ToString


    '    Me.GridView3.DataSource = cx.ObtenerEstadosProductos(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto)
    '    Me.GridView3.DataBind()
    '    Me.Label7.Text = cx.ObtenerUltimoEstado(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto)

    '    Me.Button55.Visible = False
    '    Me.PanelFiltro.Visible = False
    '    Me.GridView1.Visible = False
    '    Me.Panel4.Visible = True
    '    Me.Panel5.Visible = True

    '    Me.btnClose.Visible = False
    '    Me.pnlPopup.Visible = False


    'End Sub

    'Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'consultar
    '    Dim btnDetails As Button = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

    '    idproducto = Me.GridView1.DataKeys(row.RowIndex).Values(3)

    '    Dim c As New cCATALOGOPRODUCTOS
    '    Me.Label4.Text = c.DevolverCodigoProducto(idproducto).ToString
    '    Me.Label5.Text = c.DevolverNombreProducto(idproducto).ToString

    '    Dim cx As New cProcesoCP
    '    Me.Label6.Text = cx.ObtenerIdLista(idproducto, Request.QueryString("idtp")).Tables(0).Rows(0).Item(1).ToString

    '    Dim ds As New Data.DataSet
    '    ds = cx.ObtenerDatosProductosProveedores(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto)
    '    Me.TextBox1.Text = ds.Tables(0).Rows(0).Item(0)
    '    If ds.Tables(0).Rows(0).Item(1) = "" Then
    '        Me.CheckBox1.Checked = True
    '        Me.TextBox2.Enabled = False
    '    Else
    '        Me.CheckBox1.Checked = False
    '        Me.TextBox2.Enabled = True
    '        Me.TextBox2.Text = ds.Tables(0).Rows(0).Item(1)
    '    End If
    '    If ds.Tables(0).Rows(0).Item(2) = "" Then
    '        Me.CheckBox2.Checked = True
    '        Me.TextBox3.Enabled = False
    '    Else
    '        Me.CheckBox2.Checked = False
    '        Me.TextBox3.Enabled = True
    '        Me.TextBox3.Text = ds.Tables(0).Rows(0).Item(2)
    '    End If
    '    Me.TextBox5.Text = ds.Tables(0).Rows(0).Item(3)
    '    Me.DropDownList1.SelectedValue = ds.Tables(0).Rows(0).Item(4)
    '    Me.TextBox6.Text = ds.Tables(0).Rows(0).Item(5)
    '    Me.TextBox7.Text = ds.Tables(0).Rows(0).Item(6)


    '    Me.GridView3.DataSource = cx.ObtenerEstadosProductos(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto)
    '    Me.GridView3.DataBind()
    '    Me.Label7.Text = cx.ObtenerUltimoEstado(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto)

    '    Me.GridView4.DataSource = cx.ObtenerProcesoCompra(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto)
    '    Me.GridView4.DataBind()

    '    Me.Button55.Visible = False
    '    Me.PanelFiltro.Visible = False
    '    Me.GridView1.Visible = False
    '    Me.Panel4.Visible = True
    '    Me.Panel5.Visible = True

    '    Me.btnClose.Visible = False
    '    Me.pnlPopup.Visible = False

    '    'no edicion
    '    Me.Button9.Enabled = False
    '    Me.Button8.Enabled = False
    '    Me.Button10.Enabled = False
    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim c As New cProcesoCP
    '    Dim ds As New Data.DataSet

    '    Select Case Me.RadioButtonList1.SelectedValue
    '        Case Is = 0
    '            If Me.TextBox4.Text <> "" Then
    '                ds = c.ObtenerProductosSINAB(Me.TextBox4.Text.ToString, "---")
    '            Else
    '                ds = c.ObtenerProductosSINAB("---", "---")
    '            End If

    '        Case Is = 1
    '            If Me.TextBox4.Text <> "" Then
    '                ds = c.ObtenerProductosSINAB("nohay", Me.TextBox4.Text.ToString)
    '            Else
    '                ds = c.ObtenerProductosSINAB("---", "---")
    '            End If

    '    End Select

    '    Me.GridView2.DataSource = ds
    '    Me.GridView2.DataBind()

    '    Me.Panel2.Visible = True
    '    Me.TextBox4.Text = ""
    'End Sub

    'Protected Sub Button4_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim btnDetails As Button = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
    '    Dim idproveedor As Integer = Me.GridView1.DataKeys(row.RowIndex).Values(2)
    '    Response.Redirect("~/UACI/CERTIFICACION/frmProductos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & idproveedor & "&e=1")
    'End Sub

    'Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim btnDetails As Button = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
    '    Dim idproveedor As Integer = Me.GridView1.DataKeys(row.RowIndex).Values(2)
    '    Response.Redirect("~/UACI/CERTIFICACION/frmProductos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & idproveedor & "&e=0")
    'End Sub

    'Protected Sub ButtonFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFiltro.Click
    '    Dim c As New cProcesoCP

    '    Dim ds As New Data.DataSet

    '    Select Case Me.RadioButtonListFiltro.SelectedValue
    '        Case Is = 0
    '            If Me.TextBoxFiltro.Text <> "" Then
    '                ds = c.ObtenerDataSetProductos(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), Me.TextBoxFiltro.Text.ToString, "")
    '            Else
    '                ds = c.ObtenerDataSetProductos(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"))
    '            End If

    '        Case Is = 1
    '            If Me.TextBoxFiltro.Text <> "" Then
    '                ds = c.ObtenerDataSetProductos(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), "", Me.TextBoxFiltro.Text.ToString)
    '            Else
    '                ds = c.ObtenerDataSetProductos(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"))
    '            End If

    '    End Select


    '    Me.GridView1.DataSource = ds
    '    Me.GridView1.DataBind()
    '    Me.TextBoxFiltro.Text = ""
    'End Sub


    'Protected Sub Button55_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button55.Click
    '    Dim c As New cProcesoCP
    '    Me.GridView2.DataSource = c.ObtenerProductosSINAB("xyz", "---")
    '    Me.GridView2.DataBind()
    '    Me.Panel2.Visible = True
    '    Me.pnlPopup.Visible = True
    '    Me.Panel4.Visible = False
    '    Me.GridView1.Visible = False
    '    Me.PanelFiltro.Visible = False
    '    Me.btnClose.Visible = True
    '    Me.Button55.Visible = False
    '    Me.updPnlCustomerDetail.Visible = True
    'End Sub

    'Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
    '    Me.Button55.Visible = True
    '    Me.Panel5.Visible = False
    '    Me.PanelFiltro.Visible = True
    '    Me.GridView1.Visible = True
    '    Me.Panel4.Visible = False
    '    idproducto = 0
    '    limpiar()
    '    cargardatos()
    'End Sub
    'Public Sub limpiar()
    '    Me.TextBox1.Text = ""
    '    Me.TextBox2.Text = ""
    '    Me.TextBox3.Text = ""
    '    Me.TextBox5.Text = ""
    '    Me.TextBox6.Text = ""
    '    Me.DropDownList1.SelectedValue = 1
    '    Me.RadioButtonList2.SelectedIndex = -1
    '    Me.TextBox9.Text = ""
    '    Me.TextBox10.Text = ""
    '    Me.TextBox7.Text = ""
    '    Me.TextBox8.Text = ""
    'End Sub
    'Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
    '    'update de productosproveedores

    '    Try
    '        Dim cx As New cProcesoCP
    '        cx.ActualizarProductosProveedores(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto, Me.TextBox1.Text, IIf(Me.CheckBox1.Checked, "", Me.TextBox2.Text), IIf(Me.CheckBox2.Checked, "", Me.TextBox3.Text), Me.TextBox5.Text, Me.DropDownList1.SelectedValue, Me.TextBox6.Text, Me.TextBox7.Text.ToString)

    '        idproducto = 0
    '        Me.Button55.Visible = True
    '        Me.Panel5.Visible = False
    '        Me.PanelFiltro.Visible = True
    '        Me.GridView1.Visible = True
    '        Me.Panel4.Visible = False

    '        cargardatos()
    '        limpiar()
    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Protected Sub BtnViewDetails2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim btnDetails As ImageButton = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

    '    Dim CX As New cProcesoCP
    '    CX.EliminarProcesoCompra(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto, Me.GridView4.DataKeys(row.RowIndex).Values(0))

    '    Me.GridView4.DataSource = CX.ObtenerProcesoCompra(Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), idproducto)
    '    Me.GridView4.DataBind()

    'End Sub

    'Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim l As Button
    '        l = CType(e.Row.FindControl("boton"), Button)

    '        Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
    '        If current IsNot Nothing Then
    '            current.RegisterPostBackControl(l)
    '        End If

    '    End If


    'End Sub


   
End Class
