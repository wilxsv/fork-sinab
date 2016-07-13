Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Collections.Generic
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports System.Linq

Partial Class FrmReporteRecibosRecepcion
    Inherits System.Web.UI.Page

    Private cRR As New cRECIBOSRECEPCION

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            With ucFiltrosReportesAlmacen1
                .VerDocumento = "Número de recibo de recepción"
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
        Dim ds As New List(Of BaseRecibosRecepcion)
        With ucFiltrosReportesAlmacen1


            If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then
                ds = AlmacenHelpers.RecibosRecepcion.ObtenerTodos(.IDALMACEN, .IDESTABLECIMIENTO2, .IDPROVEEDOR, CType(.FECHADESDE, Date), CType(.FECHAHASTA, Date), .IDGRUPOFUENTEFINANCIAMIENTO, .IDFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, .IDESTADO, CType(.Documento, Integer), 0, .IDSUMINISTRO)
            Else
                ds = AlmacenHelpers.RecibosRecepcion.ObtenerTodos(Membresia.ObtenerUsuario().Almacen.IDALMACEN, 0, .IDPROVEEDOR, CType(.FECHADESDE, Date), CType(.FECHAHASTA, Date), .IDGRUPOFUENTEFINANCIAMIENTO, .IDFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, .IDESTADO, CType(.Documento, Integer), 0, .IDSUMINISTRO)
            End If

           
            gvLista.DataSource = ds
        End With
        Try
            gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            gvLista.DataBind()
        End Try

        gvLista.Visible = True

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lb As LinkButton = CType(e.Row.FindControl("lbVer"), LinkButton)

            Dim idEstab =gvLista.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTO") 
            Dim idTipo = gvLista.DataKeys(e.Row.RowIndex).Item("IDTIPOTRANSACCION")
            Dim idMov = gvLista.DataKeys(e.Row.RowIndex).Item("IDMOVIMIENTO")
            Dim idEMov = gvLista.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTOMOVIMIENTO")
            Dim idP = gvLista.DataKeys(e.Row.RowIndex).Item("IDPROVEEDOR")
            Dim idC = gvLista.DataKeys(e.Row.RowIndex).Item("IDCONTRATO")
            dim cad =  string.Format("/Reportes/FrmRptReciboRecepcion.aspx?IdEMov={0}&IdTT={1}&IdMov={2}&IdE={3}&IdP={4}&IdC={5}", idEMov, idTipo, idMov, idEstab, idP,idC)
          
            lb.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)

            Dim IDALMACEN As Integer = CType(Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDALMACEN"), Integer)
            Dim ANIO As Integer = CType(Me.gvLista.DataKeys(e.Row.RowIndex).Item("ANIO"), Integer)
            Dim IDRECIBO As Integer = CType(Me.gvLista.DataKeys(e.Row.RowIndex).Item("IDRECIBO"), Integer)

            Dim ds As Data.DataSet
            Dim gv As GridView

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
