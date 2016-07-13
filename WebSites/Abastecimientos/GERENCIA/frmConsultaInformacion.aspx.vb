
Partial Class GERENCIA_FrmConsultaInformacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False

        If Not IsPostBack Then
            'cargar filtros

            Me.DdlDEPENDENCIAS1.Recuperar(1)
            Me.DdlDEPENDENCIAS1.SelectedIndex = 0

            'suministro:
            Me.ddlSUMINISTROS1.RecuperarPorUnidadTecnica(DdlDEPENDENCIAS1.SelectedValue)
            Me.ddlSUMINISTROS1.SelectedIndex = 0
            'grupo:
            Me.ddlGRUPOS1.RecuperarListaFiltradaPorUT(Me.ddlSUMINISTROS1.SelectedValue, DdlDEPENDENCIAS1.SelectedValue)
            Me.ddlGRUPOS1.SelectedIndex = 0
            'subgrupo:
            Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, DdlDEPENDENCIAS1.SelectedValue)
            Me.ddlSUBGRUPOS1.SelectedIndex = 0
            'producto
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, DdlDEPENDENCIAS1.SelectedValue)

            Button1.Visible = False
            DropDownList3.Visible = False
            DropDownList2.Visible = False
            DropDownList1.Visible = False
            RadioButtonList4.Visible = False
            RadioButtonList3.Visible = False
            RadioButtonList2.Visible = False
            Label5.Visible = False
            CheckBox5.Visible = False
            CheckBox4.Visible = False
            CheckBox2.Visible = False
            CheckBox1.Visible = False
            Label6.Visible = False

            GridView1.Visible = False
            DdlCATALOGOPRODUCTOS1.Visible = False
            ddlSUBGRUPOS1.Visible = False
            ddlGRUPOS1.Visible = False
            ddlSUMINISTROS1.Visible = False
            DdlDEPENDENCIAS1.Visible = False
            Label4.Visible = False
            Label3.Visible = False
            Label2.Visible = False
            Label1.Visible = False

        Else

        End If

    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedValue = 0 Then
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.ddlSUMINISTROS1.Visible = False
            Me.ddlGRUPOS1.Visible = False
            Me.ddlSUBGRUPOS1.Visible = False
            Me.DdlDEPENDENCIAS1.Visible = False

            Me.TxtProducto.Visible = True
            Me.TxtProducto.Text = String.Empty
            Me.BtnBuscar.Visible = True
            
            Me.Label1.Visible = False
            Me.Label2.Visible = False
            Me.Label3.Visible = False
            Me.Label4.Visible = False

            Me.GridView1.Visible = False
            Me.Label6.Visible = False
            Me.CheckBox1.Visible = False
            Me.CheckBox2.Visible = False
            Me.CheckBox4.Visible = False
            Me.CheckBox5.Visible = False

            Me.RadioButtonList2.Visible = False
            Me.RadioButtonList3.Visible = False
            Me.RadioButtonList4.Visible = False

            Me.DropDownList1.Visible = False
            Me.DropDownList2.Visible = False
            Me.DropDownList3.Visible = False

            Me.Label5.Visible = False
            Me.Button1.Visible = False

        Else
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.LblCodigo.Text = "Producto"

            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.ddlSUMINISTROS1.Visible = True
            Me.ddlGRUPOS1.Visible = True
            Me.ddlSUBGRUPOS1.Visible = True
            Me.DdlDEPENDENCIAS1.Visible = True

            BuscarProductoLista()
            Me.Label1.Visible = True
            Me.Label2.Visible = True
            Me.Label3.Visible = True
            Me.Label4.Visible = True
        End If
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim dsCatalogoProductos As Data.DataSet
        Dim mcompcatalogoproductos As New ABASTECIMIENTOS.NEGOCIO.cCATALOGOPRODUCTOS

        dsCatalogoProductos = mcompcatalogoproductos.FiltrarProductoDS(Me.TxtProducto.Text, 2, 1)

        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            Button1.Visible = False
            DropDownList3.Visible = False
            DropDownList2.Visible = False
            DropDownList1.Visible = False
            RadioButtonList4.Visible = False
            RadioButtonList3.Visible = False
            RadioButtonList2.Visible = False
            Label5.Visible = False
            CheckBox5.Visible = False
            CheckBox4.Visible = False
            CheckBox2.Visible = False
            CheckBox1.Visible = False
            Label6.Visible = False
        Else
            Button1.Visible = True
            'DropDownList3.Visible = True
            'DropDownList2.Visible = True
            'DropDownList1.Visible = True
            RadioButtonList4.Visible = True
            RadioButtonList3.Visible = True
            RadioButtonList2.Visible = True
            Label5.Visible = True
            CheckBox5.Visible = True
            CheckBox4.Visible = True
            CheckBox2.Visible = True
            CheckBox1.Visible = True
            Label6.Visible = True

        End If


        Me.GridView1.DataSource = dsCatalogoProductos
        Me.GridView1.DataBind()
        Me.GridView1.Visible = True
        Me.TxtProducto.Text = ""
        Me.TxtProducto.Focus()

        If dsCatalogoProductos.Tables(0).Rows.Count <> 0 Then
            Dim ds1 As New Data.DataSet
            Me.Label7.Text = dsCatalogoProductos.Tables(0).Rows(0).Item(11)
            ds1 = mcompcatalogoproductos.ObtenerListaSolicitudesxProducto(dsCatalogoProductos.Tables(0).Rows(0).Item(11))

            If ds1.Tables(0).Rows.Count <> 0 Then
                Me.DropDownList1.DataSource = ds1
                Me.DropDownList1.DataTextField = "correlativo"
                Me.DropDownList1.DataValueField = "idsolicitud"
                Me.DropDownList1.DataBind()
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.DropDownList1.SelectedIndex = 0
                    Me.DropDownList1.Visible = True
                Else
                    Me.DropDownList1.Visible = False
                End If
                Me.CheckBox1.Enabled = True
                Me.RadioButtonList2.Enabled = True
                Me.CheckBox1.Checked = True
            Else
                Me.CheckBox1.Enabled = False
                Me.CheckBox1.Checked = False
                Me.RadioButtonList2.Enabled = False
            End If
            
            Dim ds2 As New Data.DataSet
            ds2 = mcompcatalogoproductos.ObtenerListaPCxProducto(dsCatalogoProductos.Tables(0).Rows(0).Item(9))
            If ds2.Tables(0).Rows.Count <> 0 Then
                Me.DropDownList2.DataSource = ds2
                Me.DropDownList2.DataTextField = "codigo"
                Me.DropDownList2.DataValueField = "IdProcesoCompra"
                Me.DropDownList2.DataBind()
                If ds2.Tables(0).Rows.Count > 0 Then
                    Me.DropDownList2.SelectedIndex = 0
                    Me.DropDownList2.Visible = True
                Else
                    Me.DropDownList2.Visible = False
                End If

                Me.CheckBox2.Enabled = True
                Me.CheckBox4.Enabled = True
                Me.RadioButtonList3.Enabled = True
                Me.CheckBox2.Checked = True
                Me.CheckBox4.Checked = True
            Else
                Me.CheckBox2.Enabled = False
                Me.CheckBox4.Enabled = False
                Me.CheckBox2.Checked = False
                Me.CheckBox4.Checked = False
                Me.RadioButtonList3.Enabled = False
            End If

            Dim ds3 As New Data.DataSet
            ds3 = mcompcatalogoproductos.ObtenerListaEstablecimientoxProducto(dsCatalogoProductos.Tables(0).Rows(0).Item(9))
            If ds3.Tables(0).Rows.Count <> 0 Then
                Me.DropDownList3.DataSource = ds3
                Me.DropDownList3.DataTextField = "nombre"
                Me.DropDownList3.DataValueField = "idalmacen"
                Me.DropDownList3.DataBind()
                If ds3.Tables(0).Rows.Count > 0 Then
                    Me.DropDownList3.SelectedIndex = 0
                    Me.DropDownList3.Visible = True
                Else
                    Me.DropDownList3.Visible = False
                End If

                Me.RadioButtonList4.Enabled = True
            Else
                Me.RadioButtonList4.Enabled = False
            End If

        End If

    End Sub
    Private Function BuscarProductoLista() As Int16
        Dim dsCatalogoProductos As Data.DataSet
        Dim mcompcatalogoproductos As New ABASTECIMIENTOS.NEGOCIO.cCATALOGOPRODUCTOS
        dsCatalogoProductos = mcompcatalogoproductos.FiltrarProductoDSUT(Me.DdlCATALOGOPRODUCTOS1.SelectedValue, 1, Me.DdlDEPENDENCIAS1.SelectedValue)

        Me.GridView1.DataSource = dsCatalogoProductos
        Me.GridView1.DataBind()
        Me.GridView1.Visible = True
        If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
            Button1.Visible = False

            If Me.RadioButtonList2.SelectedValue = 0 Then
                DropDownList1.Visible = False
            Else
                DropDownList1.Visible = True
            End If

            If Me.RadioButtonList3.SelectedValue = 0 Then
                DropDownList2.Visible = False
            Else
                DropDownList1.Visible = True
            End If

            If Me.RadioButtonList4.SelectedValue = 0 Then
                DropDownList3.Visible = False
            Else
                DropDownList3.Visible = True
            End If


            RadioButtonList4.Visible = False
            RadioButtonList3.Visible = False
            RadioButtonList2.Visible = False
            Label5.Visible = False
            CheckBox5.Visible = False
            CheckBox4.Visible = False
            CheckBox2.Visible = False
            CheckBox1.Visible = False
            Label6.Visible = False
        Else

            Me.RadioButtonList2.SelectedValue = 0
            Me.RadioButtonList3.SelectedValue = 0
            Me.RadioButtonList4.SelectedValue = 0

            Button1.Visible = True
            If Me.RadioButtonList2.SelectedValue = 0 Then
                DropDownList1.Visible = False
            Else
                DropDownList1.Visible = True
            End If

            If Me.RadioButtonList3.SelectedValue = 0 Then
                DropDownList2.Visible = False
            Else
                DropDownList1.Visible = True
            End If

            If Me.RadioButtonList4.SelectedValue = 0 Then
                DropDownList3.Visible = False
            Else
                DropDownList3.Visible = True
            End If
            RadioButtonList4.Visible = True
            RadioButtonList3.Visible = True
            RadioButtonList2.Visible = True
            Label5.Visible = True
            CheckBox5.Visible = True
            CheckBox4.Visible = True
            CheckBox2.Visible = True
            CheckBox1.Visible = True
            Label6.Visible = True

        End If

        Dim ds1 As New Data.DataSet

        Me.Label7.Text = dsCatalogoProductos.Tables(0).Rows(0).Item(9)
        ds1 = mcompcatalogoproductos.ObtenerListaSolicitudesxProducto(dsCatalogoProductos.Tables(0).Rows(0).Item(11))

        Me.DropDownList1.DataSource = ds1
        Me.DropDownList1.DataTextField = "correlativo"
        Me.DropDownList1.DataValueField = "idsolicitud"
        Me.DropDownList1.DataBind()
        If Me.DropDownList1.Items.Count > 0 Then
            Me.DropDownList1.SelectedIndex = 0
            Me.CheckBox1.Checked = True
            Me.CheckBox1.Enabled = True
            Me.RadioButtonList2.Enabled = True
            Me.DropDownList1.Visible = True
        Else
            Me.CheckBox1.Checked = False
            Me.CheckBox1.Enabled = False
            Me.RadioButtonList2.SelectedValue = 0
            Me.RadioButtonList2.Enabled = False
            Me.DropDownList1.Visible = False
        End If

        Dim ds2 As New Data.DataSet
        ds2 = mcompcatalogoproductos.ObtenerListaPCxProducto(dsCatalogoProductos.Tables(0).Rows(0).Item(11))

        Me.DropDownList2.DataSource = ds2
        Me.DropDownList2.DataTextField = "codigo"
        Me.DropDownList2.DataValueField = "IdProcesoCompra"
        Me.DropDownList2.DataBind()
        If Me.DropDownList2.Items.Count > 0 Then
            Me.DropDownList2.SelectedIndex = 0
            Me.CheckBox2.Checked = True
            Me.CheckBox2.Enabled = True
            Me.RadioButtonList3.Enabled = True
            Me.DropDownList2.Visible = True

            Me.CheckBox4.Checked = True
            Me.CheckBox4.Enabled = True
        Else
            Me.CheckBox2.Checked = False
            Me.CheckBox2.Enabled = False
            Me.RadioButtonList3.SelectedValue = 0
            Me.RadioButtonList3.Enabled = False
            Me.DropDownList2.Visible = False

            Me.CheckBox4.Checked = False
            Me.CheckBox4.Enabled = False

        End If

        Dim ds3 As New Data.DataSet
        ds3 = mcompcatalogoproductos.ObtenerListaEstablecimientoxProducto(dsCatalogoProductos.Tables(0).Rows(0).Item(11))

        Me.DropDownList3.DataSource = ds3
        Me.DropDownList3.DataTextField = "nombre"
        Me.DropDownList3.DataValueField = "idalmacen"
        Me.DropDownList3.DataBind()
        If Me.DropDownList3.Items.Count > 0 Then
            Me.DropDownList3.SelectedIndex = 0
            Me.RadioButtonList4.Enabled = True
            Me.DropDownList3.Visible = True
        Else
            Me.RadioButtonList4.Enabled = False
            Me.DropDownList3.Visible = False

        End If


    End Function

    Protected Sub DdlDEPENDENCIAS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlDEPENDENCIAS1.SelectedIndexChanged
        'suministro:
        Me.ddlSUMINISTROS1.RecuperarPorUnidadTecnica(Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.ddlSUMINISTROS1.SelectedIndex = 0
        'grupo:
        Me.ddlGRUPOS1.RecuperarListaFiltradaPorUT(Me.ddlSUMINISTROS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.ddlGRUPOS1.SelectedIndex = 0
        'subgrupo:
        Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.ddlSUBGRUPOS1.SelectedIndex = 0
        'producto
        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.DdlCATALOGOPRODUCTOS1.SelectedIndex = 0

        BuscarProductoLista()
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        'grupo:
        Me.ddlGRUPOS1.RecuperarListaFiltradaPorUT(Me.ddlSUMINISTROS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.ddlGRUPOS1.SelectedIndex = 0
        'subgrupo:
        Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.ddlSUBGRUPOS1.SelectedIndex = 0
        'producto
        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.DdlCATALOGOPRODUCTOS1.SelectedIndex = 0

        BuscarProductoLista()
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        'subgrupo:
        Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.ddlSUBGRUPOS1.SelectedIndex = 0
        'producto
        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.DdlCATALOGOPRODUCTOS1.SelectedIndex = 0

        BuscarProductoLista()
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        'producto
        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXUT(Me.ddlSUBGRUPOS1.SelectedValue, Me.DdlDEPENDENCIAS1.SelectedValue)
        Me.DdlCATALOGOPRODUCTOS1.SelectedIndex = 0

        BuscarProductoLista()
    End Sub

    Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
        BuscarProductoLista()
    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        If Me.RadioButtonList2.SelectedValue = 1 Then
            Me.DropDownList1.Visible = True
        Else
            Me.DropDownList1.Visible = False
        End If
    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList3.SelectedIndexChanged
        If Me.RadioButtonList3.SelectedValue = 1 Then
            Me.DropDownList2.Visible = True
        Else
            Me.DropDownList2.Visible = False
        End If
    End Sub

    Protected Sub RadioButtonList4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList4.SelectedIndexChanged
        If Me.RadioButtonList4.SelectedValue = 1 Then
            Me.DropDownList3.Visible = True
        Else
            Me.DropDownList3.Visible = False
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.CheckBox1.Checked = False And Me.CheckBox2.Checked = False And Me.CheckBox5.Checked = False And Me.CheckBox4.Checked = False Then
            Exit Sub
        End If
        Dim cc As New ABASTECIMIENTOS.NEGOCIO.cCATALOGOPRODUCTOS
        'parametros
        Dim idproducto, mSC, mPC, mPE, mD, vSc, vPc, vE As Integer
        'idproducto
        idproducto = Me.Label7.Text
        'solicitud de compra
        If Me.CheckBox1.Checked Then
            mSC = 1
            If Me.RadioButtonList2.SelectedValue = 0 Then
                'todas las solicitudes
                vSc = 0
            Else
                ' una solicitud
                vSc = Me.DropDownList1.SelectedValue
            End If
        Else
            ' SIN SOLICITUD
            mSC = 0
        End If
        'proceso de compra
        If Me.CheckBox2.Checked Then
            mPC = 1
            If Me.RadioButtonList3.SelectedValue = 0 Then
                'todos los procesos de compra
                vPc = 0
            Else
                ' un PC
                vPc = Me.DropDownList2.SelectedValue
            End If
        Else
            'SIN PROCESO DE COMPRA
            mPC = 0
        End If
        'pendiente de entrega
        If Me.CheckBox4.Checked Then
            'con entregas
            mPE = 1
        Else
            'sin entregas
            mPE = 0
        End If
        'disponible
        If Me.CheckBox5.Checked Then
            'con disponible
            mD = 1
        Else
            ' sin disponible
            mD = 0
        End If
        'establecimiento
        If Me.RadioButtonList4.SelectedValue = 0 Then
            'todos los establecimientos
            vE = 0
        Else
            'establecimiento
            vE = Me.DropDownList3.SelectedValue
        End If

        Dim s As New StringBuilder

        s.Append("<script language='javascript'> window.open('")
        s.Append(Request.ApplicationPath)
        s.Append("/Reportes/FrmRptInformacionSINAB.aspx")
        s.Append("?idProducto=")
        s.Append(idproducto)
        s.Append("&mSC=")
        s.Append(mSC)
        s.Append("&mPC=")
        s.Append(mPC)
        s.Append("&mPE=")
        s.Append(mPE)
        s.Append("&mD=")
        s.Append(mD)
        s.Append("&vSc=")
        s.Append(vSc)
        s.Append("&vPC=")
        s.Append(vPc)
        s.Append("&vE=")
        s.Append(vE)
        s.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');</script>")

        Page.ClientScript.RegisterStartupScript(Me.GetType, "rpt", s.ToString)

    End Sub
End Class
