Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class UACI_CERTIFICACION_frmProveedores
    Inherits System.Web.UI.Page
    Private _idproveedor As Integer
    Public Property idproveedor() As Integer
        Get
            Return Me._idproveedor
        End Get
        Set(ByVal value As Integer)
            Me._idproveedor = value
            If Not Me.ViewState("idproveedor") Is Nothing Then Me.ViewState.Remove("idproveedor")
            Me.ViewState.Add("idproveedor", value)
        End Set
    End Property
    Private _idproducto As Integer
    Public Property idproducto() As Integer
        Get
            Return Me._idproducto
        End Get
        Set(ByVal value As Integer)
            Me._idproducto = value
            If Not Me.ViewState("idproducto") Is Nothing Then Me.ViewState.Remove("idproducto")
            Me.ViewState.Add("idproducto", value)
        End Set
    End Property
    Private _idDOCUMENTO As Integer
    Public Property idDOCUMENTO() As Integer
        Get
            Return Me._idDOCUMENTO
        End Get
        Set(ByVal value As Integer)
            Me._idDOCUMENTO = value
            If Not Me.ViewState("idDOCUMENTO") Is Nothing Then Me.ViewState.Remove("idDOCUMENTO")
            Me.ViewState.Add("idDOCUMENTO", value)
        End Set
    End Property
    'Private _idEstado As Integer
    'Public Property idEstado() As Integer
    '    Get
    '        Return Me._idEstado
    '    End Get
    '    Set(ByVal value As Integer)
    '        Me._idEstado = value
    '        If Not Me.ViewState("idEstado") Is Nothing Then Me.ViewState.Remove("idEstado")
    '        Me.ViewState.Add("idEstado", value)
    '    End Set
    'End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            MostrarPanel(P1)
            cargardatosProveedores()
            'Me.pnlPopup.Visible = False
        Else
            If Not Me.ViewState("idproveedor") Is Nothing Then Me.idproveedor = Me.ViewState("idproveedor")
            If Not Me.ViewState("idproducto") Is Nothing Then Me.idproducto = Me.ViewState("idproducto")
            If Not Me.ViewState("idDOCUMENTO") Is Nothing Then Me.idDOCUMENTO = Me.ViewState("idDOCUMENTO")
            ' If Not Me.ViewState("idEstado") Is Nothing Then Me.idEstado = Me.ViewState("idEstado")
        End If
    End Sub
    Public Sub MostrarPanel(ByVal id As Object)
        Me.P1.Visible = False
        Me.P11.Visible = False
        Me.P2.Visible = False
        Me.P3.Visible = False
        Me.P4.Visible = False
        Me.P5.Visible = False
        Me.P6.Visible = False
        Me.P7.Visible = False

        Dim panel As New Object
        panel = id
        panel.Visible = True

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Public Sub cargardatosProveedores()
        Dim cx As New cRegistroProveedores
        Me.GridView1.DataSource = cx.ObtenerProveedores()
        Me.GridView1.DataBind()

    End Sub


#Region "primero"
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        MostrarPanel(P2)
        Me.Button6.Enabled = False
        Me.Button7.Enabled = False
        Me.Button8.Enabled = False
        Me.Button9.Enabled = False
        Me.P11.Visible = False
        idproveedor = 0
    End Sub

    'Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.mdlPopup.Hide()
    'End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim idprod As Integer = Me.GridView2.DataKeys(row.RowIndex).Values(0)

        Dim CX As New cRegistroProveedores
        CX.AgregarProductosProveedores(idprod, idproveedor)
        'cargardatos()
        'Me.updPnlCustomerDetail.Update()
        Dim x As New cRegistroProveedores
        Me.GridView2a.DataSource = x.ObtenerProductosProveedor(idproveedor)
        Me.GridView2a.DataBind()

        Me.Panel8.Visible = True
        Me.Panel1.Visible = False

    End Sub

#End Region


#Region "segundo"
    'Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim c As New cProcesoCP
    '    Dim ds As New Data.DataSet

    '    Dim btnDetails As Button = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

    '    ds = c.ObtenerDataSetPorId2(Me.GridView1.DataKeys(row.RowIndex).Values(0), Me.GridView1.DataKeys(row.RowIndex).Values(1))

    '    'Me.Label12.Text = ds.Tables(0).Rows(0).Item("NUMPROCESO")
    '    'Me.Label31.Text = ds.Tables(0).Rows(0).Item("TIPOPRODUCTO")
    '    'Me.Label21.Text = ds.Tables(0).Rows(0).Item("FECHAINICIO")
    '    'Me.Label1.Text = ds.Tables(0).Rows(0).Item("IDPROCESO")
    '    'Me.Label2.Text = ds.Tables(0).Rows(0).Item("IDTIPOPRODUCTO")
    '    'Me.TextBox31.Text = ""
    '    'Me.TextBox11.Text = ""
    '    Me.Modalpopupextender1.Show()
    'End Sub
    Protected Sub btnClose2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Modalpopupextender1.Hide()
    End Sub
    Protected Sub btnSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim cpro As New cProcesoCP
        cpro.EliminarUnProveedor(Request.QueryString("idp"), Request.QueryString("idtp"), idproveedor)

        'cargardatos()

        Me.Modalpopupextender1.Hide()
    End Sub
#End Region

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        idproducto = Me.GridView2a.DataKeys(row.RowIndex).Values(0)

        Me.ModalPopupExtender5.Show()

    End Sub
    Protected Sub Button3A_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        idDOCUMENTO = Me.GridView3.DataKeys(row.RowIndex).Values(0)

        Me.Label5.Text = Me.GridView3.DataKeys(row.RowIndex).Values(1)
        Dim c As New cRegistroProveedores
        Dim DS As New Data.DataSet
        DS = c.ObtenerUnDocumentoProveedores(idproveedor, idDOCUMENTO)
        If DS.Tables(0).Rows.Count > 0 Then
            Me.TextBox16.Text = DS.Tables(0).Rows(0).Item(0)
            Me.TextBox17.Text = IIf(DS.Tables(0).Rows(0).Item(1) = "01/01/1900", "", DS.Tables(0).Rows(0).Item(1))
            If DS.Tables(0).Rows(0).Item(1) = "01/01/1900" Then
                Me.CheckBox1.Checked = True
            Else
                Me.CheckBox1.Checked = False
            End If
            Me.TextBox1b.Text = IIf(DS.Tables(0).Rows(0).Item(2) = "01/01/1900", "", DS.Tables(0).Rows(0).Item(2))
            Me.TextBox18a.Text = DS.Tables(0).Rows(0).Item(3)
            Me.TextBox19a.Text = DS.Tables(0).Rows(0).Item(4)

        End If

        Me.Panel10.Visible = False
        Me.Panel4.Visible = True

    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Response.Redirect("~/UACI/CERTIFICACION/frmProveedores.aspx?idp=" & Me.GridView1.DataKeys(row.RowIndex).Values(0) & "&idtp=" & Me.GridView1.DataKeys(row.RowIndex).Values(1))

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex

        cargardatosProveedores()
        
    End Sub

    'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    ' Dim b As Button = e.Row.FindControl("button3")
    '    Dim b2 As Button = e.Row.FindControl("button4")
    '    Dim b3 As Button = e.Row.FindControl("button6")

    '    If (e.Row.RowType = DataControlRowType.DataRow) Then

    '        If Request.QueryString("estado") = 0 Then

    '            'b.Visible = True
    '            Me.GridView1.Columns(4).Visible = True
    '            b2.Visible = True
    '            b3.Visible = False
    '        Else
    '            'b.Visible = False
    '            Me.GridView1.Columns(4).Visible = False
    '            b2.Visible = False
    '            b3.Visible = True
    '        End If
    '    End If

    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim c As New cProcesoCP
    '    Dim ds As New Data.DataSet

    '    Select Case Me.RadioButtonList1.SelectedValue
    '        Case Is = 0
    '            If Me.TextBox4.Text <> "" Then
    '                ds = c.ObtenerProveedoresSINAB(Me.TextBox4.Text.ToString, "")
    '            Else
    '                ds = c.ObtenerProveedoresSINAB("", "")
    '            End If

    '        Case Is = 1
    '            If Me.TextBox4.Text <> "" Then
    '                ds = c.ObtenerProveedoresSINAB("nohay", Me.TextBox4.Text.ToString)
    '            Else
    '                ds = c.ObtenerProveedoresSINAB("", "")
    '            End If

    '    End Select

    '    Me.GridView2.DataSource = ds
    '    Me.GridView2.DataBind()

    '    Me.Panel2.Visible = True

    'End Sub

    Protected Sub Button5_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        MostrarPanel(P3)
        Dim x As New cRegistroProveedores
        Dim ds As New Data.DataSet
        ds = x.ObtenerUnProveedores(idproveedor)

        If ds.Tables(0).Rows.Count = 0 Then
            'adicionar nuevo proveedor
            Me.TextBox1.Text = ""
            Me.TextBox2.Text = ""
            Me.TextBox3.Text = ""
            Me.TextBox5.Text = ""
            Me.TextBox6.Text = ""
            Me.TextBox7.Text = ""
            Me.TextBox8.Text = ""
            Me.TextBox9.Text = ""
            Me.TextBox10.Text = ""
            Me.TextBox11.Text = ""
            Me.TextBox12.Text = ""
            Me.TextBox13.Text = ""
            Me.TextBox14.Text = ""

            Me.RadioButtonList2.SelectedIndex = -1
            Me.RadioButtonList3.SelectedIndex = -1
            Me.RadioButtonList4.SelectedIndex = -1

            Me.CheckBoxList1.Items(0).Selected = False
            Me.CheckBoxList1.Items(1).Selected = False
            Me.CheckBoxList1.Items(2).Selected = False

            Me.TextBox1.Enabled = True
        Else
            ' actualizar proveedor
            Me.TextBox1a.Text = ds.Tables(0).Rows(0).Item(19)
            Me.TextBox2.Text = ds.Tables(0).Rows(0).Item(0)
            Me.TextBox3.Text = ds.Tables(0).Rows(0).Item(11)
            Me.TextBox5.Text = ds.Tables(0).Rows(0).Item(1)
            Me.TextBox6.Text = ds.Tables(0).Rows(0).Item(2)
            Me.TextBox7.Text = ds.Tables(0).Rows(0).Item(3)
            Me.TextBox8.Text = ds.Tables(0).Rows(0).Item(4)
            Me.TextBox9.Text = ds.Tables(0).Rows(0).Item(18)
            Me.TextBox10.Text = ds.Tables(0).Rows(0).Item(5)
            Me.TextBox11.Text = ds.Tables(0).Rows(0).Item(6)
            Me.TextBox12.Text = ds.Tables(0).Rows(0).Item(7)
            Me.TextBox13.Text = ds.Tables(0).Rows(0).Item(8)
            Me.TextBox14.Text = ds.Tables(0).Rows(0).Item(9)
            Me.TextBox15.Text = ds.Tables(0).Rows(0).Item(10)

            If Not IsDBNull(ds.Tables(0).Rows(0).Item(13)) Then
                Me.RadioButtonList2.SelectedValue = ds.Tables(0).Rows(0).Item(13)
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item(12)) Then
                Me.RadioButtonList3.SelectedValue = ds.Tables(0).Rows(0).Item(12)
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(14)) Then
                Me.RadioButtonList4.SelectedValue = ds.Tables(0).Rows(0).Item(14)
            End If


            If Not IsDBNull(ds.Tables(0).Rows(0).Item(15)) Then
                Me.CheckBoxList1.Items(0).Selected = IIf(ds.Tables(0).Rows(0).Item(15) = 1, True, False)
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(16)) Then
                Me.CheckBoxList1.Items(1).Selected = IIf(ds.Tables(0).Rows(0).Item(16) = 2, True, False)
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(17)) Then
                Me.CheckBoxList1.Items(2).Selected = IIf(ds.Tables(0).Rows(0).Item(17) = 3, True, False)
            End If

            Me.TextBox1.Enabled = False
        End If



    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedValue = 0 Then
            Me.TextBox4.MaxLength = 14
        Else
            Me.TextBox4.MaxLength = 200
        End If
    End Sub

    'Protected Sub Button4_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim btnDetails As Button = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
    '    Dim idproveedor As Integer = Me.GridView1.DataKeys(row.RowIndex).Values(2)
    '    Response.Redirect("~/UACI/CERTIFICACION/frmProductos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & idproveedor & "&e=1")
    'End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim idproveedor As Integer = Me.GridView1.DataKeys(row.RowIndex).Values(2)
        Response.Redirect("~/UACI/CERTIFICACION/frmProductos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & idproveedor & "&e=0")
    End Sub

    Protected Sub ButtonFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFiltro.Click
        Dim c As New cRegistroProveedores

        Dim ds As New Data.DataSet

        Select Case Me.RadioButtonListFiltro.SelectedValue
            Case Is = 0
                If Me.TextBoxFiltro.Text <> "" Then
                    ds = c.ObtenerProveedoresFiltrados(Me.TextBoxFiltro.Text.ToString, "")
                Else
                    ds = c.ObtenerProveedoresFiltrados("", "")
                End If

            Case Is = 1
                If Me.TextBoxFiltro.Text <> "" Then
                    ds = c.ObtenerProveedoresFiltrados("", Me.TextBoxFiltro.Text.ToString)
                Else
                    ds = c.ObtenerProveedoresFiltrados("", "")
                End If

        End Select


        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        Dim b3 As Button = e.Row.FindControl("btnSave")

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If e.Row.Cells(0).Text = "-" Then
                b3.Visible = False
            End If
        End If
    End Sub

    Protected Sub Button4_Click2(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        idproveedor = Me.GridView1.DataKeys(row.RowIndex).Values(0)

        MostrarPanel(P2)
        Me.P11.Visible = True
        Dim c As New cRegistroProveedores

        Dim DS As New Data.DataSet
        DS = c.ObtenerDatosProveedor(idproveedor)

        If IsDBNull(DS.Tables(0).Rows(0).Item(2)) Then 'Or DS.Tables(0).Rows(0).Item(0) = "" Or DS.Tables(0).Rows(0).Item(0) = "11111111111111" Then
            Me.Button6.Enabled = False
            Me.Button7.Enabled = False
            Me.Button8.Enabled = False
            Me.Button9.Enabled = False
        Else
            Me.Button6.Enabled = True
            Me.Button7.Enabled = True
            Me.Button8.Enabled = True
            Me.Button9.Enabled = True
        End If
        Me.Label1a.Text = IIf(IsDBNull(DS.Tables(0).Rows(0).Item(0)), "", DS.Tables(0).Rows(0).Item(0))
        Me.Label2.Text = DS.Tables(0).Rows(0).Item(1)
        Me.Label3.Text = IIf(IsDBNull(DS.Tables(0).Rows(0).Item(3)), "Deshabilitado", DS.Tables(0).Rows(0).Item(3))

    End Sub

    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        idproveedor = 0
        MostrarPanel(P1)
    End Sub

    Protected Sub Button19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button19.Click
        Me.Label6.Text = ""
        MostrarPanel(P2)
        Me.P11.Visible = True
    End Sub

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            Dim c As New cRegistroProveedores
            Dim p As New PROVEEDORESRG
            If idproveedor = 0 Then
                'nuevo proveedor
                'chequear NIT
                Dim x As New cPROVEEDORES
                If x.ValidarNIT(Me.TextBox1a.Text, 0) > 0 Then
                    Me.Label6.Text = "El NIT ya esta asociado a un proveedor. Favor verificar el Número."
                    Exit Sub
                Else
                    Me.Label6.Text = ""
                End If
                p.NIT = Me.TextBox1a.Text
                'crear codigoproveedor
                p.IDPROVEEDOR = CInt(x.ObtenerULTIMOID()) + 1

                p.CODIGOPROVEEDOR = CStr(CInt(x.ObtenerUltimoCodigoProveedor) + 1)

                p.NOMBRE = Me.TextBox2.Text
                p.C1 = Me.RadioButtonList2.SelectedValue
                p.PROCEDENCIA = Me.RadioButtonList3.SelectedValue
                p.C3 = Me.RadioButtonList4.SelectedValue
                p.NOMBREABR = Me.TextBox3.Text
                p.DIRECCION = Me.TextBox5.Text
                p.REPRESENTANTELEGAL = Me.TextBox6.Text
                p.REPRESENTANTELEGAL2 = Me.TextBox7.Text
                p.REPRESENTANTELEGAL3 = Me.TextBox8.Text
                p.MATRICULA = Me.TextBox9.Text
                p.TELEFONO = Me.TextBox10.Text
                p.TELEFONO2 = Me.TextBox11.Text
                p.TELEFONO3 = Me.TextBox12.Text
                p.FAX = Me.TextBox13.Text
                p.CORREO = Me.TextBox14.Text
                p.GIRO = Me.TextBox15.Text
                p.TP1 = IIf(Me.CheckBoxList1.Items(0).Selected, 1, 0)
                p.TP2 = IIf(Me.CheckBoxList1.Items(1).Selected, 2, 0)
                p.TP3 = IIf(Me.CheckBoxList1.Items(2).Selected, 3, 0)
                p.AUUSUARIOCREACION = User.Identity.Name
                p.AUFECHACREACION = DateTime.Now
                p.AUUSUARIOMODIFICACION = User.Identity.Name
                p.AUFECHAMODIFICACION = DateTime.Now

                c.AgregarProveedores(p)

                idproveedor = p.IDPROVEEDOR
            Else
                'actualizacion proveedor
                p.NOMBRE = Me.TextBox2.Text
                p.C1 = Me.RadioButtonList2.SelectedValue
                p.PROCEDENCIA = Me.RadioButtonList3.SelectedValue
                p.C3 = Me.RadioButtonList4.SelectedValue
                p.NOMBREABR = Me.TextBox3.Text
                p.DIRECCION = Me.TextBox5.Text
                p.REPRESENTANTELEGAL = Me.TextBox6.Text
                p.REPRESENTANTELEGAL2 = Me.TextBox7.Text
                p.REPRESENTANTELEGAL3 = Me.TextBox8.Text
                p.MATRICULA = Me.TextBox9.Text
                p.TELEFONO = Me.TextBox10.Text
                p.TELEFONO2 = Me.TextBox11.Text
                p.TELEFONO3 = Me.TextBox12.Text
                p.FAX = Me.TextBox13.Text
                p.CORREO = Me.TextBox14.Text
                p.GIRO = Me.TextBox15.Text
                p.TP1 = IIf(Me.CheckBoxList1.Items(0).Selected, 1, 0)
                p.TP2 = IIf(Me.CheckBoxList1.Items(1).Selected, 2, 0)
                p.TP3 = IIf(Me.CheckBoxList1.Items(2).Selected, 3, 0)
                p.AUUSUARIOMODIFICACION = User.Identity.Name
                p.AUFECHAMODIFICACION = DateTime.Now

                p.IDPROVEEDOR = idproveedor

                c.ActualizarProveedores(p)

            End If

            Dim DS As New Data.DataSet
            DS = c.ObtenerDatosProveedor(idproveedor)

            Me.Button6.Enabled = True
            Me.Button7.Enabled = True
            Me.Button8.Enabled = True
            Me.Button9.Enabled = True

            Me.Label1.Text = IIf(IsDBNull(DS.Tables(0).Rows(0).Item(0)), "", DS.Tables(0).Rows(0).Item(0))
            Me.Label2.Text = DS.Tables(0).Rows(0).Item(1)
            Me.Label3.Text = IIf(IsDBNull(DS.Tables(0).Rows(0).Item(3)), "Deshabilitado", DS.Tables(0).Rows(0).Item(3))
            Me.P11.Visible = True

            Me.Label6.Text = "Proveedor registrado/actualizado satisfactoriamente"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button6_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        MostrarPanel(P4)
        Me.P11.Visible = True

        Dim c As New cRegistroProveedores
        Me.GridView2a.DataSource = c.ObtenerProductosProveedor(idproveedor)
        Me.GridView2a.DataBind()

    End Sub

    Protected Sub Button1a_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1a.Click, Button1.Click, Button13a.Click, Button13.Click
        MostrarPanel(P2)
    End Sub

    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim c As New cSUMINISTROS
        Me.DropDownList1.DataSource = c.obtenerSuministroOrdenado
        Me.DropDownList1.DataTextField = "DESCRIPCION"
        Me.DropDownList1.DataValueField = "IDSUMINISTRO"
        Me.DropDownList1.DataBind()
        Me.DropDownList1.SelectedIndex = 0

        Me.Panel8.Visible = False
        Me.Panel1.Visible = True


    End Sub

    'Protected Sub Button1b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim c As New cRegistroProveedores
    '    Dim x As New cCATALOGOPRODUCTOS
    '    Dim ds As New Data.DataSet

    '    Select Case Me.RadioButtonList1.SelectedValue
    '        Case Is = 0
    '            If Me.TextBox4.Text <> "" Then
    '                'chequeo listado oficial
    '                If x.DevolverIDProducto(Me.TextBox4.Text) <> 0 Then

    '                    'si existe
    '                    If c.chequearListadoOficial(x.DevolverIDProducto(Me.TextBox4.Text), Me.DropDownList1.SelectedValue) = 0 Then
    '                        Me.Label8.Text = "El producto no pertenece al Listado Oficial o no pertenece a este tipo de suministro."
    '                        Me.Label8.Visible = True
    '                        Me.GridView2.Visible = False
    '                        Exit Sub
    '                    End If

    '                Else
    '                    'no existe
    '                    ds = c.ObtenerProductosSINAB(Me.TextBox4.Text.ToString, "---")
    '                    Me.Label8.Visible = False
    '                    Me.GridView2.Visible = True
    '                End If
    '            Else
    '                ds = c.ObtenerProductosSINAB("---", "---")
    '                Me.Label8.Visible = False
    '                Me.GridView2.Visible = True
    '            End If

    '        Case Is = 1
    '            If Me.TextBox4.Text <> "" Then
    '                ds = c.ObtenerProductosSINAB("nohay", Me.TextBox4.Text.ToString)
    '                Me.Label8.Visible = False
    '                Me.GridView2.Visible = True
    '            Else
    '                ds = c.ObtenerProductosSINAB("---", "---")
    '                Me.Label8.Visible = False
    '                Me.GridView2.Visible = True
    '            End If

    '    End Select

    '    Me.GridView2.DataSource = ds
    '    Me.GridView2.DataBind()

    '    Me.Panel2.Visible = True
    '    Me.TextBox4.Text = ""
    'End Sub

    Protected Sub btnClose2b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopupExtender5.Hide()
    End Sub

    Protected Sub btnSave2b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cpro As New cRegistroProveedores
        cpro.EliminarProductoProveedor(idproveedor, idproducto)

        Me.Modalpopupextender1.Hide()

        Me.GridView2a.DataSource = cpro.ObtenerProductosProveedor(idproveedor)
        Me.GridView2a.DataBind()
        'Response.Redirect("~/UACI/REGPROV/frmProveedores.aspx")
    End Sub

    'Protected Sub btnClosea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClosea.Click
    '    Me.Panel8.Visible = True
    '    Me.pnlPopup.Visible = False
    'End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        MostrarPanel(P5)
        Me.P11.Visible = True

        Dim x As New cRegistroProveedores
        Me.GridView3.DataSource = x.ObtenerDocumentosProveedores(idproveedor)
        Me.GridView3.DataBind()

    End Sub

    Protected Sub btnCloseb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseb.Click
        Me.Panel10.Visible = True
        Me.Panel4.Visible = False
    End Sub

    Protected Sub btnSaveb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveb.Click
        Try
            Dim c As New cRegistroProveedores
            c.AgregarDocumentosProveedores(idDOCUMENTO, idproveedor, Me.TextBox16.Text, IIf(Me.TextBox17.Text = "", "01/01/1900", Me.TextBox17.Text), IIf(Me.TextBox1b.Text = "", "01/01/1900", Me.TextBox1b.Text), Me.TextBox18a.Text, TextBox19a.Text)

            TextBox16.Text = ""
            TextBox17.Text = ""
            TextBox1b.Text = ""
            TextBox18a.Text = ""
            TextBox19a.Text = ""

            Dim x As New cRegistroProveedores
            Me.GridView3.DataSource = x.ObtenerDocumentosProveedores(idproveedor)
            Me.GridView3.DataBind()

            Me.Panel10.Visible = True
            Me.Panel4.Visible = False
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.CheckBox1.Checked Then
            Me.TextBox17.Enabled = False
            Me.RequiredFieldValidator9.Enabled = False
            Me.RequiredFieldValidator9.Visible = False
        Else
            Me.TextBox17.Enabled = True
            Me.RequiredFieldValidator9.Enabled = True
            Me.RequiredFieldValidator9.Visible = True
        End If
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        MostrarPanel(P6)
        Me.P11.Visible = True
        Dim x As New cRegistroProveedores
        Me.GridView4.DataSource = x.ObtenerEstadosProveedores(idproveedor)
        Me.GridView4.DataBind()

        If x.ObtenerUltimoEstado(idproveedor) = 99 Then
            Me.Label4.Text = "INHABILITADO"
        Else
            Me.Label4.Text = IIf(x.ObtenerUltimoEstado(idproveedor) = 0, "HABILITADO", "INHABILITADO")
        End If


    End Sub

    Protected Sub Button14a_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14a.Click
        Dim c As New cRegistroProveedores
        Me.DropDownList2a.DataSource = c.ObtenerCausas
        Me.DropDownList2a.DataTextField = "nombre"
        Me.DropDownList2a.DataValueField = "Idcausa"
        Me.DropDownList2a.DataBind()
        Me.DropDownList2a.SelectedIndex = 0

        Me.TextBox1c.Text = CStr(Format(Date.Now, "dd/MM/yy"))
        Me.TextBox18c.Text = ""
        Me.TextBox19c.Text = ""
        Me.TextBox20c.Text = ""

        Me.Panel5.Visible = True
        Me.Panel11.Visible = False

    End Sub

    Protected Sub btnClosec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClosec.Click
        Me.Panel5.Visible = False
        Me.Panel11.Visible = True
    End Sub

    Protected Sub btnSavec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSavec.Click
        Try
            Dim x As New cRegistroProveedores
            x.AgregarEstadosProveedores(idproveedor, Me.RadioButtonList5.SelectedValue, Me.TextBox1c.Text, Me.DropDownList2a.SelectedValue, IIf(Me.TextBox18c.Text = "", "01/01/1900", Me.TextBox18c.Text), IIf(Me.TextBox19c.Text = "", "01/01/1900", Me.TextBox19c.Text), Me.TextBox20c.Text)

            Me.GridView4.DataSource = x.ObtenerEstadosProveedores(idproveedor)
            Me.GridView4.DataBind()

            Me.Label4.Text = IIf(x.ObtenerUltimoEstado(idproveedor) = 0, "HABILITADO", "INHABILITADO")
            Me.Label3.Text = IIf(x.ObtenerUltimoEstado(idproveedor) = 0, "HABILITADO", "INHABILITADO")

            Me.Panel5.Visible = False
            Me.Panel11.Visible = True
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim x As New cRegistroProveedores
        Me.DropDownList2.DataSource = x.ObtenerTiposSanciones
        Me.DropDownList2.DataTextField = "NOMBRE"
        Me.DropDownList2.DataValueField = "IDTIPOSANCION"
        Me.DropDownList2.DataBind()
        Me.DropDownList2.SelectedIndex = 0

        Me.TextBox1.Text = ""
        Me.TextBox18.Text = ""
        Me.CheckBox2.Checked = False
        Me.CheckBox3.Checked = False
        Me.TextBox19.Text = ""
        Me.TextBox21.Text = ""
        Me.TextBox22.Text = ""
        Me.TextBox23.Text = ""
        Me.TextBox24.Text = ""
        Me.TextBox20.Text = ""

        Me.Panel6.Visible = True
        Me.Panel13.Visible = False
    End Sub

    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        MostrarPanel(P7)
        Me.P11.Visible = True

        Dim x As New cRegistroProveedores
        Me.GridView5.DataSource = x.ObtenerSancionesProveedores(idproveedor)
        Me.GridView5.DataBind()
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked Then
            Me.TextBox1.Enabled = False
            Me.RequiredFieldValidator10.Enabled = False
            Me.RequiredFieldValidator10.Visible = False
        Else
            Me.TextBox1.Enabled = True
            Me.RequiredFieldValidator10.Enabled = True
            Me.RequiredFieldValidator10.Visible = True
        End If
    End Sub

    Protected Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.CheckBox3.Checked Then
            Me.TextBox21.Enabled = False
        Else
            Me.TextBox21.Enabled = True
        End If
    End Sub

    Protected Sub btnClosed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClosed.Click
        Me.Panel6.Visible = False
        Me.Panel13.Visible = True
    End Sub

    Protected Sub btnSaved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaved.Click
        Try
            Dim x As New cRegistroProveedores
            x.AgregarSancionesProveedores(idproveedor, Me.DropDownList2.SelectedValue, Me.TextBox18.Text, Me.TextBox19.Text, IIf(Me.TextBox21.Text = "", "01/01/1900", Me.TextBox21.Text), IIf(Me.TextBox22.Text = "", "", Me.TextBox22.Text), IIf(Me.TextBox23.Text = "", "", Me.TextBox23.Text), IIf(Me.TextBox24.Text = "", "", Me.TextBox24.Text), IIf(Me.TextBox20.Text = "", "", Me.TextBox20.Text), IIf(Me.TextBox1.Text = "", 0, Me.TextBox1.Text))

            Me.GridView5.DataSource = x.ObtenerSancionesProveedores(idproveedor)
            Me.GridView5.DataBind()

            Me.Panel6.Visible = False
            Me.Panel13.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnSave2a_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'borrar un proveedor
        Dim x As New cRegistroProveedores
        If x.EliminarProveedor(idproveedor) = 0 Then
            Me.Label7.Text = "Existe este proveedor como Oferta/Contrato en los procesos de compra."
        Else
            Me.Label7.Text = ""
            Me.Modalpopupextender1.Hide()
        End If
    End Sub

    Protected Sub btnClose2a_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Modalpopupextender1.Hide()
    End Sub

    Protected Sub Button3h_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        idproveedor = Me.GridView1.DataKeys(row.RowIndex).Values(0)
        Me.Modalpopupextender1.Show()

    End Sub

    Protected Sub GridView2a_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2a.PageIndexChanging
        Me.GridView2a.PageIndex = e.NewPageIndex

        Dim c As New cRegistroProveedores
        Me.GridView2a.DataSource = c.ObtenerProductosProveedor(idproveedor)
        Me.GridView2a.DataBind()
    End Sub

    Protected Sub GridView3_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView3.PageIndexChanging
        Me.GridView3.PageIndex = e.NewPageIndex

        Dim x As New cRegistroProveedores
        Me.GridView3.DataSource = x.ObtenerDocumentosProveedores(idproveedor)
        Me.GridView3.DataBind()
    End Sub

    Protected Sub GridView4_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView4.PageIndexChanging
        Me.GridView4.PageIndex = e.NewPageIndex
        Dim x As New cRegistroProveedores
        Me.GridView4.DataSource = x.ObtenerEstadosProveedores(idproveedor)
        Me.GridView4.DataBind()

    End Sub

    Protected Sub GridView5_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView5.PageIndexChanging
        Me.GridView5.PageIndex = e.NewPageIndex
        Dim x As New cRegistroProveedores
        Me.GridView5.DataSource = x.ObtenerSancionesProveedores(idproveedor)
        Me.GridView5.DataBind()
    End Sub

    Protected Sub Button20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button20.Click
        Dim c As New cRegistroProveedores
        Dim x As New cCATALOGOPRODUCTOS
        Dim ds As New Data.DataSet

        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = 0
                If Me.TextBox4.Text <> "" Then
                    'chequeo listado oficial
                    If x.DevolverIDProducto(Me.TextBox4.Text) <> 0 Then

                        'si existe
                        If c.chequearListadoOficial(x.DevolverIDProducto(Me.TextBox4.Text), Me.DropDownList1.SelectedValue) = 0 Then
                            Me.Label8.Text = "El producto no pertenece al Listado Oficial o no pertenece a este tipo de suministro."
                            Me.Label8.Visible = True
                            Me.GridView2.Visible = False
                            Me.Panel9.Visible = False
                            Exit Sub
                        End If

                    Else
                        'no existe
                        ds = c.ObtenerProductosSINAB(Me.TextBox4.Text.ToString, "---")
                        Me.Label8.Visible = False
                        Me.GridView2.Visible = True
                        Me.Panel9.Visible = True
                    End If
                Else
                    ds = c.ObtenerProductosSINAB("---", "---")
                    Me.Label8.Visible = False
                    Me.GridView2.Visible = True
                    Me.Panel9.Visible = True
                End If

            Case Is = 1
                If Me.TextBox4.Text <> "" Then
                    ds = c.ObtenerProductosSINAB("nohay", Me.TextBox4.Text.ToString)
                    Me.Label8.Visible = False
                    Me.GridView2.Visible = True
                    Me.Panel9.Visible = True
                Else
                    ds = c.ObtenerProductosSINAB("---", "---")
                    Me.Label8.Visible = False
                    Me.GridView2.Visible = True
                    Me.Panel9.Visible = True
                End If

        End Select

        Me.GridView2.DataSource = ds
        Me.GridView2.DataBind()

        Me.Panel2.Visible = True
        Me.TextBox4.Text = ""
    End Sub

    Protected Sub Button21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button21.Click
        Me.Panel8.Visible = True
        Me.Panel1.Visible = False
    End Sub


    Protected Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(2).Text = "01/01/1900" Then
                e.Row.Cells(2).Text = "-"
            End If
        End If

    End Sub

    Protected Sub GridView4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(3).Text = "01/01/1900" Then
                e.Row.Cells(3).Text = "-"
            End If
            If e.Row.Cells(4).Text = "01/01/1900" Then
                e.Row.Cells(4).Text = "-"
            End If
        End If
    End Sub

    Protected Sub GridView5_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(4).Text = "01/01/1900" Then
                e.Row.Cells(4).Text = "-"
            End If
        End If
    End Sub
End Class
