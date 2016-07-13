Imports SINAB_Entidades.Helpers.CertificacionHelpers

Partial Class UACI_CERTIFICACION_frmReporte1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            rFiltros.CargarDatos()

        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub



    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Not rFiltros.ExisteProceso Then
            Exit Sub
        End If

        Dim ds = ProductosProveedores.ObtenerReporte(rFiltros.IdProceso, rFiltros.IdTipoProducto, rFiltros.Nit, rFiltros.Producto, rFiltros.Estado)
        'c.ObtenerReporte1(Me.DropDownList2.SelectedValue, Me.DropDownList1.SelectedValue, IIf(Me.TextBox1.Text = "", "nohay", Me.TextBox1.Text), IIf(Me.TextBox2.Text = "", "nohay", Me.TextBox2.Text))

        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()
    End Sub

    Protected Sub lnkDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        '----

        Dim idproceso = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        Dim idtipoproducto = CType(Me.GridView1.DataKeys(row.RowIndex).Values(1), Integer)
        Dim idproveedor = CType(Me.GridView1.DataKeys(row.RowIndex).Values(2), Integer)
        Dim idpp = CType(Me.GridView1.DataKeys(row.RowIndex).Values(3), Integer)


        SINAB_Utils.Utils.MostrarVentana(String.Format("/UACI/CERTIFICACION/Reportes/FrmReporteComision.aspx?idpc={0}&idtp={1}&idprv={2}&idpp={3}", idproceso, idtipoproducto, idproveedor, idpp))


        '----
    End Sub
End Class
