
Imports SINAB_Entidades.Helpers.CertificacionHelpers

Partial Class UACI_CERTIFICACION_frmReporte8
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            rFiltros.CargarDatos()
            rFiltros.MostarEstado = False
            rFiltros.MostrarProducto = True
            rFiltros.MostarFechaLimite = False
            rFiltros.FijarProveedor = True
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'Dim c As New cProcesoCP
        Dim ds = ProductosProveedores.ObtenerReporte(rFiltros.IdProceso, rFiltros.IdTipoProducto, rFiltros.Nit, "", rFiltros.Producto, 1)
        If rFiltros.PorProducto Then
            Me.GridView1.DataSource = ds
            Me.GridView1.DataBind()
        Else
            SINAB_Utils.Utils.MostrarVentana(String.Format("/UACI/CERTIFICACION/Reportes/FrmReporteTodasObservaciones.aspx?idpc={0}&idtp={1}&nit={2}&prd={3}", rFiltros.IdProceso, rFiltros.IdTipoProducto, rFiltros.Nit, rFiltros.Producto))
        End If
        '      End If

    End Sub

    Protected Sub lnkReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim idproceso = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        Dim idtipoproducto = CType(Me.GridView1.DataKeys(row.RowIndex).Values(1), Integer)
        Dim idproveedor = CType(Me.GridView1.DataKeys(row.RowIndex).Values(2), Integer)
        Dim idpp = CType(Me.GridView1.DataKeys(row.RowIndex).Values(3), Integer)

        'If rFiltros.PorProducto Then
        SINAB_Utils.Utils.MostrarVentana(String.Format("/UACI/CERTIFICACION/Reportes/FrmReporteObservaciones.aspx?idpc={0}&idtp={1}&idprv={2}&idpp={3}", idproceso, idtipoproducto, idproveedor, idpp))

        '        Else
        '   SINAB_Utils.Utils.MostrarVentana(String.Format("/UACI/CERTIFICACION/Reportes/FrmProximosVencer.aspx?idpc={0}&idtp={1}&nit={2}&fecha={3}", rFiltros.IdProceso, rFiltros.IdTipoProducto, rFiltros.Nit, rFiltros.FechaLimite))

        '       End If
    End Sub
End Class

