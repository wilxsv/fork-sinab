Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmReporteCorreccionesExistencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = "Número de documento de corrección"

            Me.ucFiltrosReportesAlmacen1.VerFechaDesde = True
            Me.ucFiltrosReportesAlmacen1.VerFechaHasta = True
            Me.ucFiltrosReportesAlmacen1.FechasRequeridas = True
            ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim cCA As New cCORRECCIONESALMACENES
        Dim ds As Data.DataSet
        ds = cCA.ObtenerListaCorreccionesAlmacen(Session("IdAlmacen"), ucFiltrosReportesAlmacen1.FECHADESDE, ucFiltrosReportesAlmacen1.FECHAHASTA, ucFiltrosReportesAlmacen1.Documento)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Me.gvLista.Visible = True

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lb As LinkButton = CType(e.Row.FindControl("lbVer"), LinkButton)
            Dim cad = String.Format("/Reportes/FrmRptCorreccionExistencias.aspx?IdA={0}&A={1}&IdC={2}", gvLista.DataKeys(e.Row.RowIndex).Item("IDALMACEN"), gvLista.DataKeys(e.Row.RowIndex).Item("ANIO"), gvLista.DataKeys(e.Row.RowIndex).Item("IDCORRECCION"))

            'Dim s As New StringBuilder

            's.Append("window.open('")
            's.Append(Request.ApplicationPath)
            's.Append("/Reportes/FrmRptCorreccionExistencias.aspx?")
            's.Append("IdA=")
            's.Append(Me..ToString())
            's.Append("&A=")
            's.Append(Me..ToString())
            's.Append("&IdC=")
            's.Append(Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDCORRECCION").ToString())
            ' s.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); return;")

            lb.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)

            's.ToString()

        End If

    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_SelectedIndexChanged() Handles ucFiltrosReportesAlmacen1.SelectedIndexChanged
        Me.gvLista.Visible = False
    End Sub

End Class
