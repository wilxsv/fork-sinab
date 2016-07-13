
Imports ABASTECIMIENTOS.NEGOCIO

Imports System.Linq
Imports SINAB_Entidades.Helpers.CertificacionHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers

Partial Class UACI_CERTIFICACION_FrmProducto
    Inherits System.Web.UI.Page

    Public Property ProductoProveedor() As SAB_CP_PRODUCTOSPROVEEDORES
        Get
            Return CType(ViewState("pp"), SAB_CP_PRODUCTOSPROVEEDORES)
        End Get
        Set(value As SAB_CP_PRODUCTOSPROVEEDORES)
            ViewState("pp") = value
        End Set
    End Property

    Public ReadOnly Property IdProceso() As Integer
        Get
            Return CType(Request.QueryString("idp"), Integer)
        End Get
    End Property

    Public ReadOnly Property IdTipoProducto() As Integer
        Get
            Return CType(Request.QueryString("idtp"), Integer)
        End Get
    End Property

    Public ReadOnly Property IdProveedor() As Integer
        Get
            Return CType(Request.QueryString("idprov"), Integer)
        End Get
    End Property

    Public ReadOnly Property IdProducto() As Integer
        Get
            Return CType(Request.QueryString("idproducto"), Integer)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Master.ControlMenu.Visible = False

            ProductoProveedor = ProductosProveedores.Obtener(CType(Request.QueryString("idpp"), Integer))

            Dim proc = Procesos.Obtener(IdProceso, IdTipoProducto)
            Label3.Text = proc.NumeroProceso

            Dim proveedor = CatalogoHelpers.Proveedores.Obtener(IdProceso, IdTipoProducto, IdProveedor)
            Label1.Text = proveedor.NIT
            Label2.Text = proveedor.NOMBRE

            Paises.CargarALista(DropDownList1)



            'obtenemos los estados
            ctEstados.ProductoProveedor = ProductoProveedor
            ctEstados.CardarDatos()

            CargarDatosPC()

            Dim cw = Helpers.Productos.Obtener(ProductoProveedor.Id)
            Label4.Text = cw.CorrProducto
            Label5.Text = cw.DescLargo

            'Dim cx As New cProcesoCP
            Label6.Text = CertificacionHelpers.Productos.ObtenerPorLista(IdTipoProducto, CType(cw.IdProducto, Integer)).Nombre ' cx.ObtenerIdLista(Proceso.IdProducto, Proceso.IdTipoProducto).Tables(0).Rows(0).Item(1).ToString
            'Dim ds As New Data.DataSet
            Try
                If Not String.IsNullOrEmpty(Request.QueryString("idpp")) Then
                    ProductoProveedor.Id = CType(Request.QueryString("idpp"), Integer)

                End If
                'id
                'cx.ObtenerDatosProductosProveedores(Proceso.IdProceso, Proceso.IdTipoProducto, Proceso.IdProveedor, Proceso.IdProducto, Proceso.Id)
                'Dim pp = ProductosProveedores.Obtener(Proceso.IdProceso, Proceso.IdTipoProducto, Proceso.IdProveedor, Proceso.IdProducto)
                TextBox1.Text = ProductoProveedor.NombreComercial

                ' IsDBNull(ds.Tables(0).Rows(0).Item(1))
                If IsNothing(ProductoProveedor.NumeroCSSP) Then

                    CheckBox1.Checked = True
                    TextBox2.Enabled = False
                    RequiredFieldValidator2.Enabled = False
                    RequiredFieldValidator2.Visible = False
                Else
                    If ProductoProveedor.NumeroCSSP = "" Then
                        CheckBox1.Checked = True
                        TextBox2.Enabled = False
                        RequiredFieldValidator2.Enabled = False
                        RequiredFieldValidator2.Visible = False
                    Else
                        CheckBox1.Checked = False
                        TextBox2.Enabled = True
                        TextBox2.Text = ProductoProveedor.NumeroCSSP
                        RequiredFieldValidator2.Enabled = True
                        RequiredFieldValidator2.Visible = True
                    End If
                End If

                If IsNothing(ProductoProveedor.CPFOMS) Then
                    CheckBox2.Checked = True
                    TextBox3.Enabled = False
                    RequiredFieldValidator3.Enabled = False
                    RequiredFieldValidator3.Visible = False
                Else
                    If ProductoProveedor.CPFOMS = "" Then
                        CheckBox2.Checked = True
                        TextBox3.Enabled = False
                        RequiredFieldValidator3.Enabled = False
                        RequiredFieldValidator3.Visible = False
                    Else
                        CheckBox2.Checked = False
                        TextBox3.Enabled = True
                        TextBox3.Text = ProductoProveedor.CPFOMS
                        RequiredFieldValidator3.Enabled = True
                        RequiredFieldValidator3.Visible = True
                    End If
                End If

                TextBox5.Text = ProductoProveedor.Marca
                DropDownList1.SelectedValue = CType(IIf(IsNothing(ProductoProveedor.IdPais), 0, ProductoProveedor.IdPais), String)
                TextBox6.Text = ProductoProveedor.NombreFab
                TextBox7.Text = ProductoProveedor.Comentarios

                Button8.Enabled = True
                Button10.Enabled = True

            Catch ex As Exception
                SINAB_Utils.MessageBox.Alert("No se pudo cargar la información del producto. Error: " & ex.Message)
            End Try
        Else
            If SINAB_Utils.MessageBox.ConfirmTarget = "Guardado" Then
                Response.Redirect(String.Format("~/UACI/CERTIFICACION/frmProductos.aspx?idp={0}&idtp={1}&idprov={2}&e=1", IdProceso, IdTipoProducto, IdProveedor))
            End If
        End If
    End Sub

    Protected Sub lnkDelCpc_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim cp As New SAB_CP_PC With {
           .Id = CType(GridView4.DataKeys(row.RowIndex).Values(0), Integer)
           }

        ProcesosCertificacion.Eliminar(cp)
        CargarDatosPC()
    End Sub

    Private Sub CargarDatosPC()
        GridView4.DataSource = ProcesosCertificacion.ObtenerTodos(ProductoProveedor.Id)
        GridView4.DataBind()
    End Sub


    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click

        'If GridView4.Rows.Count = 0 Then
        Dim cp As New SAB_CP_PC With {
            .IdProductoProveedor = ProductoProveedor.Id,
            .ProcesoCompra = TextBox8.Text
            }


        ProcesosCertificacion.Agregar(cp)
        CargarDatosPC()

        TextBox8.Text = ""

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.Enabled = False
            RequiredFieldValidator2.Enabled = False
            RequiredFieldValidator2.Visible = False
        Else
            TextBox2.Enabled = True
            RequiredFieldValidator2.Enabled = True
            RequiredFieldValidator2.Visible = True
        End If
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            TextBox3.Enabled = False
            RequiredFieldValidator3.Enabled = False
            RequiredFieldValidator3.Visible = False
        Else
            TextBox3.Enabled = True
            RequiredFieldValidator3.Enabled = True
            RequiredFieldValidator3.Visible = True
        End If
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Response.Redirect("~/UACI/CERTIFICACION/frmAspectos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & Request.QueryString("idprov") & "&idproducto=" & Request.QueryString("idproducto") & "&idpp=" & ProductoProveedor.Id)
    End Sub

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click

        Response.Redirect(String.Format("~/UACI/CERTIFICACION/frmProductos.aspx?idp={0}&idtp={1}&idprov={2}&e=1", IdProceso, IdTipoProducto, IdProveedor))
    End Sub
    Public Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        DropDownList1.SelectedValue = 1

        TextBox7.Text = ""
        TextBox8.Text = ""

        ctEstados.Limpiar()
    End Sub
    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
       
        Try


            Dim pp = New SAB_CP_PRODUCTOSPROVEEDORES With {
                .IdProceso = CType(Request.QueryString("idp"), Integer),
                .IdProveedorProceso = CType(Request.QueryString("idprov"), Integer),
                .Id = ProductoProveedor.Id,
                .NombreComercial = TextBox1.Text,
                .NumeroCSSP = CType(IIf(CheckBox1.Checked, "", TextBox2.Text), String),
                .CPFOMS = CType(IIf(CheckBox2.Checked, "", TextBox3.Text), String),
                .Marca = TextBox5.Text,
                .IdPais = CType(DropDownList1.SelectedValue, Integer),
                .NombreFab = TextBox6.Text,
            .Comentarios = TextBox7.Text.ToString
                }
            ProductosProveedores.Actualizar(pp)
            SINAB_Utils.MessageBox.AlertSubmit("La información del producto se ha guardado con exito", "Guardado")
            '  Response.Redirect(String.Format("~/UACI/CERTIFICACION/frmProductos.aspx?idp={0}&idtp={1}&idprov={2}&e=1", Proceso.IdProceso, Proceso.IdTipoProducto, Proceso.IdProveedor))
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert("No se pudo actualizar la información de este Producto. Error:" & ex.Message)
        End Try
    End Sub
End Class
