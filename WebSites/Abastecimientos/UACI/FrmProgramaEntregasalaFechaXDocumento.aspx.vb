Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class FrmProgramaEntregasalaFechaXDocumento
    Inherits System.Web.UI.Page

    Private dsTemp As Data.DataSet

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _RENGLON As Integer
    Private _IDALMACENENTREGA As Integer

    Private mComponente As New cCONTRATOS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDDLs()
        End If

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim IDTIPODOCUMENTO As Integer = 0
        Dim NUMERODOCUMENTO As String = String.Empty
        Dim IDMODALIDAD As Integer = 0
        Dim IDALMACEN As Integer = 0
        Dim IDTIPOSUMINISTRO As Integer = 0
        Dim IDPROVEEDOR As Integer = 0
        Dim PRODUCTO As String = String.Empty

        If Me.cbAlmacen.Checked Then IDALMACEN = Me.ddlALMACENES1.SelectedValue
        If Me.cbTipoDocumento.Checked Then IDTIPODOCUMENTO = Me.ddlTIPODOCUMENTOCONTRATO1.SelectedValue
        If Me.cbNumeroDocumento.Checked Then NUMERODOCUMENTO = Me.txtContrato.Text.Trim
        If Me.cbModalidadCompra.Checked Then IDMODALIDAD = Me.ddlTIPOCOMPRAS1.SelectedValue
        If Me.cbProveedor.Checked Then IDPROVEEDOR = Me.ddlPROVEEDORES1.SelectedValue
        If Me.cbTipoProducto.Checked Then IDTIPOSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
        If Me.cbCodigoProducto.Checked Then PRODUCTO = Me.txtProducto.Text.Trim

        Dim ds As Data.DataSet

        If Me.rblEntregas.SelectedValue = 0 Then
            ds = mComponente.ObtenerDatasetContratosyOtrosDoc2(IDTIPODOCUMENTO, NUMERODOCUMENTO, IDMODALIDAD, IDALMACEN, IDTIPOSUMINISTRO, IDPROVEEDOR, PRODUCTO, 2, Session.Item("IdEstablecimiento"))
        Else
            ds = mComponente.ObtenerDatasetContratosyOtrosDoc2(IDTIPODOCUMENTO, NUMERODOCUMENTO, IDMODALIDAD, IDALMACEN, IDTIPOSUMINISTRO, IDPROVEEDOR, PRODUCTO, 3, Session.Item("IdEstablecimiento"))
        End If

        Me.gvContratos.SelectedIndex = -1
        Me.gvRenglones.SelectedIndex = -1
        Me.gvProgramadas.SelectedIndex = -1

        Me.gvContratos.DataSource = ds

        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try


        Me.lblDetalle.Text = String.Empty
        Me.lblProgramadas.Text = String.Empty
        Me.gvRenglones.DataSource = Nothing
        Me.gvRenglones.DataBind()
        Me.gvProgramadas.DataSource = Nothing
        Me.gvProgramadas.DataBind()
        Me.btnImprimir.Visible = False

    End Sub

    Private Sub DetalleContrato()

        _IDESTABLECIMIENTO = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Item("IDESTABLECIMIENTO")
        _IDPROVEEDOR = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Item("IDPROVEEDOR")
        _IDCONTRATO = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Item("IDCONTRATO")

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDatasetRenglonesContratoOtrosDoc3(_IDESTABLECIMIENTO, _IDPROVEEDOR, _IDCONTRATO)

        Me.gvRenglones.DataSource = ds

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try
        Dim cad = "/Reportes/FrmRptProgramacionEntregasalaFechaUACI.aspx?IdE=" + _IDESTABLECIMIENTO.ToString + "&IdP=" + _IDPROVEEDOR.ToString + "&IdC=" + _IDCONTRATO.ToString
        btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
        '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptProgramacionEntregasalaFechaUACI.aspx?IdE=" + _IDESTABLECIMIENTO.ToString + "&IdP=" + _IDPROVEEDOR.ToString + "&IdC=" + _IDCONTRATO.ToString + "');return;"

    End Sub

    Private Sub EntregasProgramadas()

        _IDESTABLECIMIENTO = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Item("IDESTABLECIMIENTO")
        _IDPROVEEDOR = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Item("IDPROVEEDOR")
        _IDCONTRATO = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Item("IDCONTRATO")
        _RENGLON = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("RENGLON")

        dsTemp = mComponente.ObtenerEntregasProgramadas(_IDESTABLECIMIENTO, _IDPROVEEDOR, _IDCONTRATO, _RENGLON)

        Me.gvProgramadas.DataSource = dsTemp
        Me.gvProgramadas.DataBind()

        If dsTemp.Tables(0).Rows.Count > 0 Then
            Me.lblProgramadas.Text = "Entregas Programadas"
        Else
            Me.lblProgramadas.Text = "No hay datos de Entregas Programadas"
            MessageBox.Alert("No hay datos de Entregas Programadas", "Aviso")
            ' Me.MsgBox1.ShowAlert("No hay datos de Entregas Programadas", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvContratos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvContratos.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            _IDESTABLECIMIENTO = Me.gvContratos.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTO")
            _IDPROVEEDOR = Me.gvContratos.DataKeys(e.Row.RowIndex).Item("IDPROVEEDOR")
            _IDCONTRATO = Me.gvContratos.DataKeys(e.Row.RowIndex).Item("IDCONTRATO")

            Dim l As Label

            l = CType(e.Row.FindControl("lblFuentesFinanciamiento"), Label)

            Dim cFFC As New cFUENTEFINANCIAMIENTOSCONTRATOS
            l.Text = cFFC.ObtenerFuentesFinanciamientoContrato(_IDESTABLECIMIENTO, _IDPROVEEDOR, _IDCONTRATO)

            l = CType(e.Row.FindControl("lblTiposSuministro"), Label)

            Dim cPC As New cPRODUCTOSCONTRATO
            l.Text = cPC.ObtenerTiposSuministroContrato(_IDESTABLECIMIENTO, _IDPROVEEDOR, _IDCONTRATO)

        End If

    End Sub

    Protected Sub gvProgramadas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProgramadas.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim ENTREGA As Integer = Me.gvProgramadas.DataKeys(e.Row.RowIndex).Item("ENTREGA")
            Dim IDALMACENENTREGA As Integer = Me.gvProgramadas.DataKeys(e.Row.RowIndex).Item("IDALMACENENTREGA")

            Dim ds As Data.DataSet = mComponente.ObtenerDetalleEntregasContratoRenglon2(_IDESTABLECIMIENTO, _IDPROVEEDOR, _IDCONTRATO, IDALMACENENTREGA, dsTemp, _RENGLON)

            Dim dv As New Data.DataView(ds.Tables(0), "ENTREGA=" & ENTREGA, String.Empty, Data.DataViewRowState.CurrentRows)

            Dim gv As GridView = CType(e.Row.FindControl("gvDetalleEntregas"), GridView)
            gv.DataSource = dv
            gv.DataBind()

        End If

    End Sub

    Protected Sub gvContratos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvContratos.SelectedIndexChanged

        DetalleContrato()

        Me.gvProgramadas.DataSource = Nothing
        Me.gvProgramadas.DataBind()
        Me.lblProgramadas.Text = String.Empty

        Me.btnImprimir.Visible = True

        If Me.gvRenglones.Rows.Count = 0 Then
            Me.btnImprimir.Visible = False
            MessageBox.Alert("No hay renglones para el documento seleccionado")
            ' MsgBox1.ShowAlert("No hay renglones para el documento seleccionado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub gvRenglones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvRenglones.SelectedIndexChanged
        EntregasProgramadas()
    End Sub

    Protected Sub gvContratos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvContratos.PageIndexChanging
        Me.gvContratos.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvRenglones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRenglones.PageIndexChanging
        Me.gvRenglones.PageIndex = e.NewPageIndex
        DetalleContrato()
    End Sub

    Protected Sub gvProgramadas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProgramadas.PageIndexChanging
        Me.gvProgramadas.PageIndex = e.NewPageIndex
        EntregasProgramadas()
    End Sub

    Private Sub CargarDDLs()

        Me.ddlALMACENES1.RecuperarListaOrdenada()
        Me.ddlPROVEEDORES1.ObtenerProveedoresContratoEstablecimiento(Session.Item("IdEstablecimiento"))
        Me.ddlSUMINISTROS1.RecuperarOrdenadaPorCorrelativo()
        Me.ddlTIPOCOMPRAS1.RecuperarOrdenada()

        Me.ddlTIPODOCUMENTOCONTRATO1.ObtenerTipoDocumentoFiltrado(0) '0 UACI

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
