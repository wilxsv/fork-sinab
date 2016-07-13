Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmAnularTransacciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ddlTIPOTRANSACCIONES1.RecuperarTransaccionesAfectanInventario()
        End If

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Dim cM As New cMOVIMIENTOS

        Dim IDESTABLECIMIENTO As Int32 = Session.Item("IdEstablecimiento")
        Dim IDTIPOTRANSACCION As Int16 = Me.ddlTIPOTRANSACCIONES1.SelectedValue
        Dim IDALMACEN As Int32 = Session.Item("IdAlmacen")

        Dim ds As Data.DataSet
        ds = cM.ObtenerMovimientosAnular(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDALMACEN)

        Me.dgLista.DataSource = ds

        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.PageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub

    Protected Sub dgLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgLista.PageIndexChanging
        Me.dgLista.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
