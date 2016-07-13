Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers

Partial Class FrmReporteActasRecepcion
    Inherits System.Web.UI.Page

    Private cRR As New cRECIBOSRECEPCION

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            With ucFiltrosReportesAlmacen1

                .VerDocumento = "Número de acta de recepción"

                .VerFechaDesde = True
                .VerFechaHasta = True
                .FechasRequeridas = True
                .VerGrupoFuenteFinanciamiento = True
                .VerFuenteFinanciamiento = True
                .VerResponsableDistribucion = True
                .VerProveedor = True
                .b = 0
                .VerTipoSuministro = True
                .TipoSuministroTodos = True

                If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then

                    .VerEstablecimientoTodos = True
                    .VerAlmacen = True
                End If
                 .IniciarDatos()
            End With
              CargarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim ds As Data.DataSet
        ds = cRR.ObtenerListaRecibosRecepcionActas(Session("IdAlmacen"), ucFiltrosReportesAlmacen1.IDPROVEEDOR, ucFiltrosReportesAlmacen1.FECHADESDE, ucFiltrosReportesAlmacen1.FECHAHASTA, ucFiltrosReportesAlmacen1.IDFUENTEFINANCIAMIENTO, ucFiltrosReportesAlmacen1.IDRESPONSABLEDISTRIBUCION, eESTADOSMOVIMIENTOS.Cerrado, 0, ucFiltrosReportesAlmacen1.IDGRUPOFUENTEFINANCIAMIENTO, ucFiltrosReportesAlmacen1.Documento, ucFiltrosReportesAlmacen1.IDSUMINISTRO)

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
        CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lb As LinkButton = CType(e.Row.FindControl("lbVer"), LinkButton)

            
            Dim idEMov = gvLista.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTOMOVIMIENTO")
            Dim idTt = gvLista.DataKeys(e.Row.RowIndex).Item("IDTIPOTRANSACCION")
            Dim idMov = gvLista.DataKeys(e.Row.RowIndex).Item("IDMOVIMIENTO")
            Dim idE =gvLista.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTO")
            Dim idP = gvLista.DataKeys(e.Row.RowIndex).Item("IDPROVEEDOR")
            Dim idC = gvLista.DataKeys(e.Row.RowIndex).Item("IDCONTRATO")
            Dim cad = string.Format("/Reportes/FrmRptReciboRecepcion.aspx?IdEMov={0}&IdTT={1}&IdMov={2}&IdE={3}&IdP={4}&IdC={5}",idEMov,idTt,idMov, idE, idP, idC)
            

            lb.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)

            Dim ds As Data.DataSet
            Dim gv As GridView

            Dim IDALMACEN As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDALMACEN")
            Dim ANIO As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Item("ANIO")
            Dim IDRECIBO As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDRECIBO")

            ds = cRR.ObtenerFuentesRecibosRecepcionActas(IDALMACEN, ANIO, IDRECIBO)

            gv = CType(e.Row.FindControl("gvDetalleFuentes"), GridView)
            gv.DataSource = ds
            gv.DataBind()

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    gv.RowStyle.CssClass = sender.RowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.RowStyle.CssClass
                Case DataControlRowState.Alternate
                    gv.RowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                Case DataControlRowState.Selected
                    gv.RowStyle.CssClass = sender.SelectedRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.SelectedRowStyle.CssClass
            End Select

            ds = cRR.ObtenerResponsablesDistribucionRecibosRecepcionActas(IDALMACEN, ANIO, IDRECIBO)

            gv = CType(e.Row.FindControl("gvDetalleResponsables"), GridView)
            gv.DataSource = ds
            gv.DataBind()

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    gv.RowStyle.CssClass = sender.RowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.RowStyle.CssClass
                Case DataControlRowState.Alternate
                    gv.RowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                Case DataControlRowState.Selected
                    gv.RowStyle.CssClass = sender.SelectedRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.SelectedRowStyle.CssClass
            End Select

        End If

    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_SelectedIndexChanged() Handles ucFiltrosReportesAlmacen1.SelectedIndexChanged
        Me.gvLista.Visible = False
    End Sub

   

End Class
