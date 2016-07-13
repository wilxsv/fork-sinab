Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Activities.Expressions
Imports System.Collections.Generic
Imports System.Web.UI.WebControls.Expressions
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports SINAB_Utils
Imports SINAB_Entidades.Tipos
Imports System.Linq

Partial Class FrmProgramaEntregasalaFechaXDocumento
    Inherits System.Web.UI.Page

    ' Private _dsTemp As Data.DataSet

    Private mComponente As New cCONTRATOS

    'Private dbContext As SinabEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            CargarDDLs()
            CargarDatos()
        End If

    End Sub

    'Protected Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload
    '    dbContext.Connection.Close()
    '    dbContext.Dispose()
    'End Sub



    Private Sub CargarDDLs()
        Dim enrol = False

        If Membresia.EsUsuarioRol("Consulta Almacen I") Or Membresia.EsUsuarioRol("AdministracionAlmacenes") Then
            enrol = True
            'ddlEstablecimiento.Visible = False
            'ltEstablecimiento.Text = Membresia.ObtenerUsuario().ESTABLECIMIENTO.NOMBRE
            'ltEstablecimiento.Visible = True
        Else
            enrol = False
            ' Establecimientos.CargarHospitalesYRegionesALista(ddlEstablecimiento)
            ' ddlEstablecimiento.Visible = True

        End If
        ltEstablecimiento.Text = Membresia.ObtenerUsuario().ESTABLECIMIENTO.NOMBRE
        ddlEstablecimiento.Visible = False
        ltEstablecimiento.Visible = True

        If enrol Then
            ddlALMACENES1.Visible = True
            ltAlmacenes.Text = String.Empty
            Almacenes.CargarAlmacenesEstablecimientosALista(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, ddlALMACENES1)
            ddlALMACENES1.Items.Insert(0, New ListItem("(Todos)", "0"))
            AlmacenesEntregaContrato.CargarAListaProveedoresAlmacenesEntregaContrato(ddlPROVEEDORES1, CType(ddlALMACENES1.SelectedValue, Integer))

        Else
            '  Almacenes.CargarAlmacenesEstablecimientosALista(CType(ddlEstablecimiento.SelectedValue, Integer), ddlALMACENES1)
            ltAlmacenes.Text = Membresia.ObtenerUsuario().Almacen.NOMBRE
            ddlALMACENES1.Visible = False
            AlmacenesEntregaContrato.CargarAListaProveedoresAlmacenesEntregaContrato(ddlPROVEEDORES1, Membresia.ObtenerUsuario().Almacen.IDALMACEN)
        End If
        'Me.


        ' ddlALMACENES1.Enabled = False
        ' If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then
        '     ddlALMACENES1.Enabled = True
        ' Else
        '     ddlALMACENES1.Enabled = False
        ' End If




        Suministros.CargarALista(ddlSUMINISTROS1, True)

        TiposCompra.CargarALista(ddlTIPOCOMPRAS1, True)

        TiposDocumentoContrato.CargarALista(ddlTIPODOCUMENTOCONTRATO1, True)


        Dim item As New ListItem("(Todos)", 0)

        Me.ddlTIPODOCUMENTOCONTRATO1.Items.Insert(0, item)
        Me.ddlTIPOCOMPRAS1.Items.Insert(0, item)
        Me.ddlPROVEEDORES1.Items.Insert(0, item)
        Me.ddlSUMINISTROS1.Items.Insert(0, item)

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        ' dbContext = New SinabEntities()
        Dim idtipodocumento As Integer = 0
        Dim numerodocumento As String = String.Empty
        Dim idmodalidad As Integer = 0

        Dim idtiposuministro As Integer = 0

        Dim producto As String = String.Empty

        idtipodocumento = CType(Me.ddlTIPODOCUMENTOCONTRATO1.SelectedValue, Integer)
        numerodocumento = Me.txtContrato.Text.Trim
        idmodalidad = CType(Me.ddlTIPOCOMPRAS1.SelectedValue, Integer)
        Dim idproveedor = CType(Me.ddlPROVEEDORES1.SelectedValue, Integer)
        idtiposuministro = CType(Me.ddlSUMINISTROS1.SelectedValue, Integer)
        producto = Me.txtProducto.Text.Trim

        'Dim ds As Data.DataSet
        Dim ds As List(Of BaseContratos)
        Dim sAlmacenes = 0
        Dim sEntregas = 0
        If Not String.IsNullOrEmpty(ddlALMACENES1.SelectedValue) Then
            sAlmacenes = CType(ddlALMACENES1.SelectedValue, Integer)
        End If

        If Not String.IsNullOrEmpty(rblEntregas.SelectedValue) Then
            sEntregas = CType(Me.rblEntregas.SelectedValue, Integer)
        End If
        If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then
            ds = Contratos.ObtenerTodos(0, sAlmacenes, idtipodocumento, idmodalidad, idproveedor, sEntregas, producto)
            '      ds = mComponente.ObtenerDatasetContratosyOtrosDoc2(idtipodocumento, numerodocumento, idmodalidad, CType(ddlALMACENES1.SelectedValue, Integer), idtiposuministro, _idproveedor, producto, CType(Me.rblEntregas.SelectedValue, Integer), Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO)
        Else
            ds = Contratos.ObtenerTodos(0, Membresia.ObtenerUsuario().Almacen.IDALMACEN, idtipodocumento, idmodalidad, idproveedor, sEntregas, producto)
            'ds = mComponente.ObtenerDatasetContratosyOtrosDoc2(idtipodocumento, numerodocumento, idmodalidad, Membresia.ObtenerUsuario().ALMACEN.IDALMACEN, idtiposuministro, _idproveedor, producto, CType(Me.rblEntregas.SelectedValue, Integer))
        End If

        Me.gvContratos.SelectedIndex = -1

        Me.gvContratos.DataSource = ds

        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try
        Me.lblProgramadas.Text = String.Empty


    End Sub

    Protected Sub gvContratos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvContratos.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim obj As BaseContratos = CType(e.Row.DataItem, BaseContratos)

            Dim idestablecimiento = obj.IDESTABLECIMIENTO
            Dim idproveedor = obj.IDPROVEEDOR
            Dim idcontrato = CType(obj.IDCONTRATO, Integer)

            Dim lff As Label = CType(e.Row.FindControl("lblFuentesFinanciamiento"), Label)
            Dim lts As Label = CType(e.Row.FindControl("lblTiposSuministro"), Label)
            Dim lc = CType(e.Row.FindControl("ltCompras"), Literal)
            Dim gRenglones As GridView = DirectCast(e.Row.FindControl("gvRenglones"), GridView)

            If String.IsNullOrEmpty(obj.TipoCompra) Or String.IsNullOrEmpty(obj.NumeroCompra) Then
                If String.IsNullOrEmpty(obj.TipoCompra) And (Not String.IsNullOrEmpty(obj.NumeroCompra)) Then
                    lc.Text = obj.NumeroCompra.ToString()
                ElseIf (Not String.IsNullOrEmpty(obj.TipoCompra)) And String.IsNullOrEmpty(obj.NumeroCompra) Then
                    lc.Text = obj.TipoCompra.ToString()
                Else
                    lc.Text = ""
                End If
            Else
                lc.Text = obj.TipoCompra.ToString + "<br />" + obj.NumeroCompra.ToString
            End If

            ' Dim cFFC As New cFUENTEFINANCIAMIENTOSCONTRATOS
            lff.Text = String.Join(", ", obj.FuentesFinanciamiento) 'cFFC.ObtenerFuentesFinanciamientoContrato(_idestablecimiento, _idproveedor, _idcontrato)

            'Dim cPC As New cPRODUCTOSCONTRATO
            lts.Text = String.Join(", ", obj.Suministros) 'cPC.ObtenerTiposSuministroContrato(_idestablecimiento, _idproveedor, _idcontrato)

            Dim lnkPrint As HyperLink = CType(e.Row.FindControl("lnkPrint"), HyperLink)
            Dim cad = "/Reportes/FrmRptProgramacionEntregasalaFecha.aspx?IdE=" + idestablecimiento.ToString + "&IdP=" + idproveedor.ToString + "&IdC=" + idcontrato.ToString + "&IdA=" + Membresia.ObtenerUsuario().Almacen.IDALMACEN.ToString
            lnkPrint.Attributes.Add("onClick", Utils.ReferirVentana(cad))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptProgramacionEntregasalaFecha.aspx?IdE=" + idestablecimiento.ToString + "&IdP=" + idproveedor.ToString + "&IdC=" + idcontrato.ToString + "&IdA=" + Membresia.ObtenerUsuario().ALMACEN.FirstOrDefault().IDALMACEN.ToString + "','', 'scrollbars=1, resizable=1, width=800, height=600'); return false;")


            Try
                '  gRenglones.DataSource = mComponente.ObtenerDatasetRenglonesContratoOtrosDoc3(idestablecimiento, idproveedor, idcontrato, Membresia.ObtenerUsuario().ALMACEN.FirstOrDefault().IDALMACEN)
                gRenglones.DataSource = AlmacenesEntregaContrato.ObtenerTodosRenglones(idestablecimiento, idproveedor, idcontrato, Membresia.ObtenerUsuario().Almacen.IDALMACEN)
                gRenglones.DataBind()
            Catch ex As Exception
                gRenglones.DataSource = Nothing
                gRenglones.DataBind()
            End Try
        End If
    End Sub


    Protected Sub gvContratos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvContratos.PageIndexChanging
        Me.gvContratos.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    'Private Sub LlenarRenglones(grenglones As GridView, idEstablecimiento As Integer, idProveedor As Integer, idContrato As Integer, idAlmacenEntrega As Integer)
    '    Dim ds As Data.DataSet
    '    ds = mComponente.ObtenerDatasetRenglonesContratoOtrosDoc3(idEstablecimiento, idProveedor, idContrato, idAlmacenEntrega)

    '    grenglones.DataSource = ds
    '    Try
    '        grenglones.DataBind()
    '    Catch ex As Exception
    '        grenglones.PageIndex = 0
    '        grenglones.DataBind()
    '    End Try

    'End Sub

    Protected Sub gvRenglones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

            'Dim obj As BaseAlmacenesEntregaContrato = CType(e.Row.DataItem, BaseAlmacenesEntregaContrato)
            'Dim idestablecimiento = obj.IdEstablecimiento
            'Dim idproveedor = obj.IdProveedor
            'Dim idcontrato = CType(obj.IdContrato, Integer)
            'Dim renglon = obj.Renglon

            Dim obj As GridView = CType(sender, GridView)
            Dim idestablecimiento = CType(obj.DataKeys(e.Row.RowIndex).Item("IdEstablecimiento"), Integer)
            Dim idproveedor = CType(TryCast(e.Row.NamingContainer, GridView).DataKeys(e.Row.RowIndex).Item("IdProveedor"), Integer)
            Dim idcontrato = CType(TryCast(e.Row.NamingContainer, GridView).DataKeys(e.Row.RowIndex).Item("IdContrato"), Integer)
            Dim renglon = Convert.ToInt32(TryCast(e.Row.NamingContainer, GridView).DataKeys(e.Row.RowIndex).Item("Renglon"))

            Dim gvProgramadas As GridView = TryCast(e.Row.FindControl("gvProgramadas"), GridView)
            Try
                gvProgramadas.DataSource = AlmacenesEntregaContrato.ObtenerTodosEntregas(idestablecimiento, idproveedor, idcontrato, renglon, Membresia.ObtenerUsuario().Almacen.IDALMACEN)
                '  gvProgramadas.DataSource = mComponente.ObtenerEntregasProgramadas(idestablecimiento, idproveedor, idcontrato, renglon, Membresia.ObtenerUsuario().ALMACEN.FirstOrDefault().IDALMACEN)
                gvProgramadas.DataBind()
            Catch ex As Exception
                gvProgramadas.DataSource = Nothing
                gvProgramadas.DataBind()
            End Try

        End If

    End Sub


    Protected Sub gvProgramadas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

            'Dim obj As BaseAlmacenesEntregaContrato = CType(e.Row.DataItem, BaseAlmacenesEntregaContrato)
            'Dim idestablecimiento = obj.IdEstablecimiento
            'Dim idproveedor = obj.IdProveedor
            'Dim idcontrato = CType(obj.IdContrato, Integer)
            'Dim renglon As Integer = CType(obj.Renglon, Integer)

            Dim obj As GridView = CType(sender, GridView)
            Dim idestablecimiento = CType(obj.DataKeys(e.Row.RowIndex).Item("IdEstablecimiento"), Integer)
            Dim idproveedor = CType(TryCast(e.Row.NamingContainer, GridView).DataKeys(e.Row.RowIndex).Item("IdProveedor"), Integer)
            Dim idcontrato = CType(TryCast(e.Row.NamingContainer, GridView).DataKeys(e.Row.RowIndex).Item("IdContrato"), Integer)
            Dim renglon = Convert.ToInt32(TryCast(e.Row.NamingContainer, GridView).DataKeys(e.Row.RowIndex).Item("Renglon"))

            Dim gv As GridView = CType(e.Row.FindControl("gvDetalleEntregas"), GridView)

            'gv.DataSource = mComponente.ObtenerDetalleEntregasContratoRenglon2(idestablecimiento, idproveedor, idcontrato, Membresia.ObtenerUsuario().ALMACEN.FirstOrDefault().IDALMACEN, _dsTemp, renglon)
            gv.DataSource = AlmacenesEntregaContrato.ObtenerTodosDetalles(idestablecimiento, idproveedor, idcontrato, Membresia.ObtenerUsuario().Almacen.IDALMACEN, renglon)
            gv.DataBind()





        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    'Protected Sub lnkFiltros_Click(sender As Object, e As EventArgs) Handles lnkFiltros.Click
    '    If pnlFiltros.Visible Then
    '        pnlFiltros.Visible = False
    '        lnkFiltros.Text = "Filtrar búsqueda »"
    '    Else
    '        pnlFiltros.Visible = True
    '        lnkFiltros.Text = "« Ocultar filtros"
    '    End If
    'End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/Almacen/FrmReportesAlmacenes.aspx")
    End Sub
End Class
