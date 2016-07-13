
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades.Clases.UACI
Imports SINAB_Entidades.Helpers.UACIHelpers

Partial Class FrmReporteCuadroDistribucionEstablecimiento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()

        'Dim cPD As New cPROGRAMADISTRIBUCION
        'Dim ds As Data.DataSet
        'ds = cPD.ObtenerProcesosCompra(Session.Item("IdEstablecimiento").ToString)

        Me.gvProcesosCompra.DataSource = ProcesoCompras.ObtenerTodosPrc(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, 0)

        Try
            Me.gvProcesosCompra.DataBind()
        Catch ex As Exception
            Me.gvProcesosCompra.PageIndex = 0
            Me.gvProcesosCompra.DataBind()
        End Try

    End Sub

    Protected Sub gvProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProcesosCompra.PageIndexChanging
        Me.gvProcesosCompra.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvProcesosCompra_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProcesosCompra.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lb As LinkButton = CType(e.Row.FindControl("lbVer"), LinkButton)
            Dim cad = String.Format("/Reportes/FrmRptCuadroDistribucion.aspx?idE={0}&idPC={1}", gvProcesosCompra.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTO"), gvProcesosCompra.DataKeys(e.Row.RowIndex).Item("IdProcesoCompra"))
            'Dim s As New StringBuilder

            's.Append("window.open('")
            's.Append(Request.ApplicationPath)
            's.Append("/Reportes/FrmRptCuadroDistribucion.aspx")
            's.Append("?idE=")
            's.Append(Me.gvProcesosCompra.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTO").ToString())
            's.Append("&idPC=")
            ' s.Append(Me.gvProcesosCompra.DataKeys(e.Row.RowIndex).Item("IdProcesoCompra").ToString())
            's.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); return false;")

            lb.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            ' s.ToString

        End If
    End Sub

End Class
