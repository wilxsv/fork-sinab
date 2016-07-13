Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades.Helpers.CertificacionHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Tipos
Imports SINAB_Entidades.Helpers
Imports System.Transactions


Partial Class UACI_CERTIFICACION_frmProductos
    Inherits System.Web.UI.Page

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Master.ControlMenu.Visible = False

            Dim proceso = Procesos.Obtener(IdProceso, IdTipoProducto)
            Label3.Text = proceso.NumeroProceso

            Dim proveedor = CatalogoHelpers.Proveedores.Obtener(IdProceso, IdTipoProducto, IdProveedor)
            Label1.Text = proveedor.NIT
            Label2.Text = proveedor.NOMBRE

            Cargardatos()

            mvProducto.ActiveViewIndex = 0
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Public Sub Cargardatos()
        ' Dim cx As New cProcesoCP
        'cx.ObtenerDataSetProductos(IdProceso, IdTipoProducto, IdProveedor)
        GridView1.DataSource = ProductosProveedores.ObtenerTodos(IdProveedor, IdProceso)
        GridView1.DataBind()

    End Sub

#Region "primero"
    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

    '    mdlPopup.Show()
    'End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        mvProducto.ActiveViewIndex = 0
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim idProducto = CType(GridView2.DataKeys(row.RowIndex).Values(0), Integer)

        Dim cp As New SAB_CP_PRODUCTOSPROVEEDORES With {
           .IdProceso = IdProceso,
        .IdProducto = idProducto,
        .IdProveedorProceso = IdProveedor
           }
        Try
            'obtiene el Id de la lista a la que corresponde
            Dim lista = Listas.Obtener(cp.IdProducto, IdTipoProducto)
            cp.IdLista = lista.Id
            ProductosProveedores.Agregar(cp)

            ProveedoresProceso.Actualizar(IdProveedor, EnumHelpers.EstadoProductoProveedor.NoCertificado)
            Response.Redirect(String.Format("~/UACI/CERTIFICACION/frmProducto.aspx?idp={0}&idtp={1}&idprov={2}&idproducto={3}&idpp={4}", IdProceso, IdTipoProducto, IdProveedor, idProducto, cp.Id))
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert("No se ha podido guardar la información del producto. Error: " & ex.Message, "Error")
        End Try
    End Sub

#End Region



    Protected Sub Borrar_Click(ByVal sender As Object, ByVal e As EventArgs)
        'eliminar
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim idpp = CType(GridView1.DataKeys(row.RowIndex).Values(0), Integer)

        Try

            Using trans As New TransactionScope
                Try
                    Using db As New SinabEntities
                        Dim pp = ProductosProveedores.Obtener(db, idpp)
                        Dim estado = EstadoProductos.Obtener(db, idpp)
                        ProveedoresProceso.ActualizarPorBorrado(db, IdProceso, CType(estado.estado, Decimal))
                        ProductosProveedores.Eliminar(db, pp)
                    End Using
                    trans.Complete()
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using
            If RadioButtonListFiltro.SelectedValue = 0 Then
                GridView1.DataSource = ProductosProveedores.ObtenerTodosPorCodigo(IdProveedor, IdProceso, TextBoxFiltro.Text)
            Else
                GridView1.DataSource = ProductosProveedores.ObtenerTodosPorDesc(IdProveedor, IdProceso, TextBoxFiltro.Text)
            End If

            GridView1.DataBind()
            TextBoxFiltro.Text = ""

        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert("Error al eliminar registro. Error: " & ex.Message)
        End Try

        'c.EliminarUnProducto(IdProceso, IdTipoProducto, IdProveedor, IdProducto, IdProductoProceso)




    End Sub
    Protected Sub Editar_Click(ByVal sender As Object, ByVal e As EventArgs)
        'editar
        Dim btnDetails As LinkButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim idProducto = CType(GridView1.DataKeys(row.RowIndex).Values(1), Integer)
        Dim id = CType(GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        Response.Redirect(String.Format("~/UACI/CERTIFICACION/frmProducto.aspx?idp={0}&idtp={1}&idprov={2}&idproducto={3}&idpp={4}", IdProceso, IdTipoProducto, IdProveedor, idProducto, id))

    End Sub





    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex

        If RadioButtonListFiltro.SelectedValue = 0 Then
            GridView1.DataSource = ProductosProveedores.ObtenerTodosPorCodigo(IdProveedor, IdProceso, TextBoxFiltro.Text)
        Else
            GridView1.DataSource = ProductosProveedores.ObtenerTodosPorDesc(IdProveedor, IdProceso, TextBoxFiltro.Text)
        End If
        GridView1.DataBind()
        TextBoxFiltro.Text = ""
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim b As LinkButton = CType(e.Row.FindControl("lnkBorrar"), LinkButton)
        Dim b2 As LinkButton = CType(e.Row.FindControl("lnkEditar"), LinkButton)
        Dim b3 As LinkButton = CType(e.Row.FindControl("lnkConsultar"), LinkButton)

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            If Request.QueryString("estado") = 0 Then
                'b.Visible = True
                ' GridView1.Columns(4).Visible = True
                b.Visible = True
                b2.Visible = True

            Else
                'b.Visible = False
                'GridView1.Columns(4).Visible = False
                b.Visible = False
                b2.Visible = False

            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c As New cProcesoCP
        'Dim x As New cCATALOGOPRODUCTOS
        Dim ds As New Data.DataSet


        Dim productos As List(Of BaseProductos)
        If rblBuscarPor.SelectedValue = 0 Then
            productos = CertificacionHelpers.Productos.ObneterTodosPorCodigo(tbBuscar.Text)
        Else
            productos = CertificacionHelpers.Productos.ObneterTodosPorDesc(tbBuscar.Text)
        End If


        GridView2.DataSource = productos

        GridView2.DataBind()

        GridView1.Visible = False
        btnClose.Visible = True


        '  GridView2.DataSource = ds
        '  GridView2.DataBind()

        tbBuscar.Text = ""
    End Sub

    Protected Sub btnVformBack_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVformBack.Click
        Response.Redirect("~/UACI/CERTIFICACION/frmProveedores.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp"))
    End Sub

    Protected Sub RadioButtonListFiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If rblBuscarPor.SelectedValue = 0 Then
            TextBoxFiltro.MaxLength = 8
        Else
            TextBoxFiltro.MaxLength = 150
        End If
    End Sub

    Protected Sub Button4_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim idpv As Integer = GridView1.DataKeys(row.RowIndex).Values(2)
        Response.Redirect("~/UACI/CERTIFICACION/frmProductos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & idpv & "&e=1")
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim idpv As Integer = GridView1.DataKeys(row.RowIndex).Values(2)
        Response.Redirect("~/UACI/CERTIFICACION/frmProductos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & idpv & "&e=0")
    End Sub

    Protected Sub ButtonFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFiltro.Click

        If RadioButtonListFiltro.SelectedValue = 0 Then
            GridView1.DataSource = ProductosProveedores.ObtenerTodosPorCodigo(IdProveedor, IdProceso, TextBoxFiltro.Text)
        Else
            GridView1.DataSource = ProductosProveedores.ObtenerTodosPorDesc(IdProveedor, IdProceso, TextBoxFiltro.Text)
        End If

        GridView1.DataBind()
        TextBoxFiltro.Text = ""
    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        mvProducto.ActiveViewIndex = 1

    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim l As LinkButton = CType(e.Row.FindControl("lnkSave"), LinkButton)

            Dim current As ScriptManager = ScriptManager.GetCurrent(Page)
            If current IsNot Nothing Then
                current.RegisterPostBackControl(l)
            End If

        End If


    End Sub


    Public Property codigo As String

    '    Throw New NotImplementedException
    'End Function

    'Private Function NOMBRE() As Object
    '    Throw New NotImplementedException
    'End Function

End Class
