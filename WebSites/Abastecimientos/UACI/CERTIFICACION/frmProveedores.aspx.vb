Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Linq
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.CertificacionHelpers

Partial Class UACI_CERTIFICACION_frmProveedores
    Inherits System.Web.UI.Page
    Private _idproveedor As Integer
    Public Property Idproveedor() As Integer
        Get
            Return CType(ViewState("idproveedor"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("idproveedor") = value

        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim ds = Procesos.Obtener(CType(Request.QueryString("idp"), Decimal), CType(Request.QueryString("idtp"), Decimal))
            Me.Label3.Text = ds.NumeroProceso

            cargardatos()

        End If

    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Public Sub cargardatos()

        Me.GridView1.DataSource = ProveedoresProceso.ObtenerTodos(CType(Request.QueryString("idp"), Decimal), CType(Request.QueryString("idtp"), Decimal)) 'cx.ObtenerDataSetProveedores(Request.QueryString("idp"), Request.QueryString("idtp"))
        Me.GridView1.DataBind()

    End Sub


#Region "primero"
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.mdlPopup.Show()
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.mdlPopup.Hide()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Idproveedor = CType(Me.GridView2.DataKeys(row.RowIndex).Values(0), Integer)


        Dim ds2 = ProveedoresProceso.ObtenerTodos(CType(Request.QueryString("idp"), Decimal), CType(Request.QueryString("idtp"), Decimal))


        If Not ds2.Any(Function(pp) pp.IdProveedor = Idproveedor) Then
            Dim pp = New SAB_CP_PROVEEDORESPROCESO With {
                .IdProceso = CType(Request.QueryString("idp"), Integer),
                .IdTipoProducto = CType(Request.QueryString("idtp"), Integer),
                .Id = Idproveedor}
            ProveedoresProceso.Agregar(pp)
            'cx.AgregarProveedorProceso(, Idproveedor)

            Me.mdlPopup.Hide()
            Response.Redirect("~/UACI/CERTIFICACION/frmProveedores.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&estado=0")
        Else
            'Me.mdlPopup.Hide()
            SINAB_Utils.MessageBox.Alert("Este proveedor ya ha sido agregado")
        End If

    End Sub

#End Region




    Protected Sub Eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Idproveedor = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)

        'Dim cpro As New cProcesoCP
        'cpro.EliminarUnProveedor(CType(Request.QueryString("idp"), Integer), CType(Request.QueryString("idtp"), Integer), Idproveedor)
        Try
            ProveedoresProceso.Eliminar(Idproveedor)
            cargardatos()
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert("Operación no finalizada. Error: " & ex.Message)
        End Try
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Response.Redirect(CType(("~/UACI/CERTIFICACION/frmProveedores.aspx?idp=" & Me.GridView1.DataKeys(row.RowIndex).Values(1) & "&idtp=" & Me.GridView1.DataKeys(row.RowIndex).Values(2)), String))

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex


        If RadioButtonListFiltro.SelectedValue = 0 Then
            GridView1.DataSource = ProveedoresProceso.ObtenerTodosPorNit(CType(Request.QueryString("idp"), Decimal), CType(Request.QueryString("idtp"), Decimal), Me.TextBoxFiltro.Text)
        Else
            GridView1.DataSource = ProveedoresProceso.ObtenerTodosPorNombre(CType(Request.QueryString("idp"), Decimal), CType(Request.QueryString("idtp"), Decimal), Me.TextBoxFiltro.Text)
        End If

        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        ' Dim b As Button = e.Row.FindControl("button3")
        Dim lnEditar As LinkButton = CType(e.Row.FindControl("lnkEditar"), LinkButton)
        Dim lnConsultar As LinkButton = CType(e.Row.FindControl("lnkConsultar"), LinkButton)

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            If Request.QueryString("estado") = 0 Then

                'b.Visible = True
                Me.GridView1.Columns(4).Visible = True
                lnEditar.Visible = True
                lnConsultar.Visible = False
            Else
                'b.Visible = False
                Me.GridView1.Columns(4).Visible = False
                lnEditar.Visible = False
                lnConsultar.Visible = True
            End If
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        GridView2.DataSource = Helpers.CatalogoHelpers.Proveedores.ObtenerTodos(TextBox4.Text)

        Me.GridView2.DataBind()


    End Sub

    Protected Sub Button5_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Response.Redirect("~/UACI/CERTIFICACION/frmProcesos.aspx")
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.RadioButtonList1.SelectedValue = 0 Then
            Me.TextBox4.MaxLength = 14
        Else
            Me.TextBox4.MaxLength = 200
        End If
    End Sub

    Protected Sub Editar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Idproveedor = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)

        Response.Redirect("~/UACI/CERTIFICACION/frmProductos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & idproveedor & "&e=1")
    End Sub

    Protected Sub Consultar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Idproveedor = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        Response.Redirect("~/UACI/CERTIFICACION/frmProductos.aspx?idp=" & Request.QueryString("idp") & "&idtp=" & Request.QueryString("idtp") & "&idprov=" & idproveedor & "&e=0")
    End Sub

    Protected Sub ButtonFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFiltro.Click
        If RadioButtonListFiltro.SelectedValue = 0 Then
            GridView1.DataSource = ProveedoresProceso.ObtenerTodosPorNit(CType(Request.QueryString("idp"), Decimal), CType(Request.QueryString("idtp"), Decimal), Me.TextBoxFiltro.Text)
        Else
            GridView1.DataSource = ProveedoresProceso.ObtenerTodosPorNombre(CType(Request.QueryString("idp"), Decimal), CType(Request.QueryString("idtp"), Decimal), Me.TextBoxFiltro.Text)
        End If
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        Dim b3 As Button = CType(e.Row.FindControl("btnSave"), Button)

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If e.Row.Cells(0).Text = "-" Then
                b3.Visible = False
            End If
        End If
    End Sub
End Class
