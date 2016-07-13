Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmConsultarContratosOtrosDoc
    Inherits System.Web.UI.Page

    Dim TRenglones As New Data.DataTable

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Dim mComponente As New cCONTRATOS

        Dim IDALMACEN As Integer = 0
        Dim IDTIPODOCUMENTO As Integer = 0
        Dim NUMERODOCUMENTO As String = String.Empty
        Dim FECHADOCUMENTO As Date = Date.MinValue
        Dim IDMODALIDAD As Integer = 0
        Dim NUMEROMODALIDAD As String = String.Empty
        Dim IDFUENTE As Integer = 0
        Dim IDRESPONSABLE As Integer = 0
        Dim IDTIPOSUMINISTRO As Integer = 0
        Dim PRODUCTO As String = String.Empty
        Dim IDPROVEEDOR As Integer = 0
        Dim ENTREGA As Integer = 0

        IDALMACEN = Me.ddlALMACENES1.SelectedValue
        IDTIPODOCUMENTO = Me.ddlTIPODOCUMENTOCONTRATO1.SelectedValue
        NUMERODOCUMENTO = Me.txtContrato.Text.Trim
        FECHADOCUMENTO = Me.cpFechaDocumento.SelectedDate.ToShortDateString
        IDMODALIDAD = Me.ddlTIPOCOMPRAS1.SelectedValue
        NUMEROMODALIDAD = Me.txtModalidad.Text.Trim
        IDFUENTE = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue
        IDRESPONSABLE = Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue
        IDTIPOSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
        PRODUCTO = Me.txtProducto.Text.Trim
        IDPROVEEDOR = Me.ddlPROVEEDORES1.SelectedValue
        ENTREGA = Me.rblEntregas.SelectedValue

        Dim ds As Data.DataSet = mComponente.ObtenerDatasetContratosyOtrosDoc(IDTIPODOCUMENTO, NUMERODOCUMENTO, FECHADOCUMENTO, IDMODALIDAD, NUMEROMODALIDAD, IDFUENTE, IDRESPONSABLE, IDALMACEN, IDTIPOSUMINISTRO, PRODUCTO, IDPROVEEDOR, ENTREGA)

        Me.gvDocumentos.DataSource = ds
        Me.gvDocumentos.DataBind()

        Me.lblDetalle.Text = String.Empty
        Me.lblRelacionados.Text = String.Empty

        Me.gvRenglones.DataSource = Nothing
        Me.gvRenglones.DataBind()

        Me.gvRelacionados.DataSource = Nothing
        Me.gvRelacionados.DataBind()

        Me.btnImprimir.Visible = False

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Dim cFF As New cFUENTEFINANCIAMIENTOS
            Dim cA As New cALMACENES
            Dim cP As New cPROVEEDORES
            Dim cRR As New cRESPONSABLEDISTRIBUCION
            Dim cS As New cSUMINISTROS
            Dim cTC As New cTIPOCOMPRAS
            Dim cTD As New cTIPODOCUMENTOCONTRATO

            Me.ddlALMACENES1.DataSource = cA.RecuperarOrdenada
            Me.ddlALMACENES1.DataTextField = "NOMBRE"
            Me.ddlALMACENES1.DataValueField = "IDALMACEN"
            Me.ddlALMACENES1.DataBind()

            Me.ddlALMACENES1.SelectedValue = Me.Session("IdAlmacen")

            Me.ddlFUENTEFINANCIAMIENTOS1.DataSource = cFF.RecuperarOrdenada
            Me.ddlFUENTEFINANCIAMIENTOS1.DataTextField = "NOMBRE"
            Me.ddlFUENTEFINANCIAMIENTOS1.DataValueField = "IDFUENTEFINANCIAMIENTO"
            Me.ddlFUENTEFINANCIAMIENTOS1.DataBind()

            'JOSE CHAVEZ DA ERROR POR ESO LE PUSE COMENTARIO
            '5 DE ABRIL
            Me.ddlPROVEEDORES1.DataSource = cP.ProveedoresConContratosDistribuidos
            Me.ddlPROVEEDORES1.DataTextField = "NOMBRE"
            Me.ddlPROVEEDORES1.DataValueField = "IDPROVEEDOR"
            Me.ddlPROVEEDORES1.DataBind()

            Me.ddlRESPONSABLEDISTRIBUCION1.DataSource = cRR.RecuperarOrdenada
            Me.ddlRESPONSABLEDISTRIBUCION1.DataTextField = "NOMBRE"
            Me.ddlRESPONSABLEDISTRIBUCION1.DataValueField = "IDRESPONSABLEDISTRIBUCION"
            Me.ddlRESPONSABLEDISTRIBUCION1.DataBind()

            Me.ddlSUMINISTROS1.DataSource = cS.RecuperarOrdenada
            Me.ddlSUMINISTROS1.DataTextField = "DESCRIPCION"
            Me.ddlSUMINISTROS1.DataValueField = "IDSUMINISTRO"
            Me.ddlSUMINISTROS1.DataBind()

            Me.ddlTIPOCOMPRAS1.DataSource = cTC.RecuperarOrdenada
            Me.ddlTIPOCOMPRAS1.DataTextField = "DESCRIPCION"
            Me.ddlTIPOCOMPRAS1.DataValueField = "IDTIPOCOMPRA"
            Me.ddlTIPOCOMPRAS1.DataBind()

            Me.ddlTIPODOCUMENTOCONTRATO1.DataSource = cTD.RecuperarOrdenada
            Me.ddlTIPODOCUMENTOCONTRATO1.DataTextField = "DESCRIPCION"
            Me.ddlTIPODOCUMENTOCONTRATO1.DataValueField = "IDTIPODOCUMENTO"
            Me.ddlTIPODOCUMENTOCONTRATO1.DataBind()

            Dim item As New ListItem("(Todos)", 0)

            Me.ddlFUENTEFINANCIAMIENTOS1.Items.Insert(0, item)
            Me.ddlPROVEEDORES1.Items.Insert(0, item)
            Me.ddlRESPONSABLEDISTRIBUCION1.Items.Insert(0, item)
            Me.ddlSUMINISTROS1.Items.Insert(0, item)
            Me.ddlTIPOCOMPRAS1.Items.Insert(0, item)
            Me.ddlTIPODOCUMENTOCONTRATO1.Items.Insert(0, item)

        End If

    End Sub

    Private Sub ObtenerDetalleContrato()

        Dim cC As New cCONTRATOS

        Dim ds As Data.DataSet
        ds = cC.ObtenerDatasetRenglonesContratoOtrosDoc(Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Item("IDESTABLECIMIENTO").ToString, _
        Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Item("IDCONTRATO").ToString, _
        Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Item("IDPROVEEDOR").ToString, _
        Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Item("IDALMACENENTREGA").ToString)

        Dim dr As Data.DataRow = ds.Tables(0).NewRow

        CrearTablaRenglones()

        For Each dr In ds.Tables(0).Rows
            Dim RF As Data.DataRow = Me.TRenglones.NewRow

            RF(0) = dr(0)
            RF(1) = dr(1)
            RF(2) = dr(2)
            RF(3) = dr(3)
            RF(4) = dr(4)
            RF(5) = dr(5)
            RF(6) = dr(6)
            RF(7) = dr(7)
            RF(8) = dr(8)
            RF(9) = dr(9)
            RF(10) = dr(10)
            RF(12) = dr(11)

            Dim dsRenglon As Data.DataSet
            dsRenglon = cC.ObtenerDatasetPlazosEntregaRenglonContrato(dr(0), dr(2), dr(1), dr(4))

            Dim RR As Data.DataRow = dsRenglon.Tables(0).NewRow

            For Each RR In dsRenglon.Tables(0).Rows
                RF(11) += CStr(RR(0)) + " días " + CStr(RR(1)) + "% - "
            Next

            TRenglones.Rows.Add(RF)

        Next

        Me.gvRenglones.DataSource = TRenglones
        Me.gvRenglones.DataBind()

        If TRenglones.Rows.Count > 0 Then
            Me.lblDetalle.Text = "Detalle de renglones"
        Else
            Me.lblDetalle.Text = "No hay renglones para el documento seleccionado"
        End If

        Dim dsr As Data.DataSet
        dsr = cC.ObtenerDatasetDocumentosRelacionados(Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Item("IDESTABLECIMIENTO").ToString, _
                        Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Item("IDPROVEEDOR").ToString, _
                        Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Item("IDCONTRATO").ToString)

        Me.gvRelacionados.DataSource = dsr
        Me.gvRelacionados.DataBind()

        If dsr.Tables(0).Rows.Count > 0 Then
            Me.lblRelacionados.Text = "Documentos relacionados"
        Else
            Me.lblRelacionados.Text = "No hay documentos relacionados para el documento seleccionado"
        End If

        If TRenglones.Rows.Count > 0 Or dsr.Tables(0).Rows.Count > 0 Then
            Me.btnImprimir.Visible = True
        Else
            Me.btnImprimir.Visible = False
        End If

    End Sub

    Private Sub CrearTablaRenglones()

        Dim ColumIDESTABLECIMIENTO As New Data.DataColumn("IDESTABLECIMIENTO", System.Type.GetType("System.Int32"))
        Dim ColumIDPROVEEDOR As New Data.DataColumn("IDPROVEEDOR", System.Type.GetType("System.Int32"))
        Dim ColumIDCONTRATO As New Data.DataColumn("IDCONTRATO", System.Type.GetType("System.Int32"))
        Dim ColumIDALMACENENTREGA As New Data.DataColumn("IDALMACENENTREGA", System.Type.GetType("System.Int32"))
        Dim ColumRENGLON As New Data.DataColumn("RENGLON", System.Type.GetType("System.Int32"))
        Dim ColumPRODUCTO As New Data.DataColumn("PRODUCTO", System.Type.GetType("System.String"))
        Dim ColumUM As New Data.DataColumn("UM", System.Type.GetType("System.String"))
        Dim ColumCANTIDAD As New Data.DataColumn("CANTIDAD", System.Type.GetType("System.Double"))
        Dim ColumPRECIOUNITARIO As New Data.DataColumn("PRECIOUNITARIO", System.Type.GetType("System.Double"))
        Dim ColumENTREGAS As New Data.DataColumn("ENTREGAS", System.Type.GetType("System.Int32"))
        Dim ColumDESCRIPCIONPROVEEDOR As New Data.DataColumn("DESCRIPCIONPROVEEDOR", System.Type.GetType("System.String"))
        Dim ColumPLAZOS As New Data.DataColumn("PLAZOS", System.Type.GetType("System.String"))
        Dim columCodigo As New Data.DataColumn("CORRPRODUCTO", System.Type.GetType("System.String"))

        TRenglones.Columns.Add(ColumIDESTABLECIMIENTO)
        TRenglones.Columns.Add(ColumIDPROVEEDOR)
        TRenglones.Columns.Add(ColumIDCONTRATO)
        TRenglones.Columns.Add(ColumIDALMACENENTREGA)
        TRenglones.Columns.Add(ColumRENGLON)
        TRenglones.Columns.Add(ColumPRODUCTO)
        TRenglones.Columns.Add(ColumUM)
        TRenglones.Columns.Add(ColumCANTIDAD)
        TRenglones.Columns.Add(ColumPRECIOUNITARIO)
        TRenglones.Columns.Add(ColumENTREGAS)
        TRenglones.Columns.Add(ColumDESCRIPCIONPROVEEDOR)
        TRenglones.Columns.Add(ColumPLAZOS)
        TRenglones.Columns.Add(columCodigo)

    End Sub

    Protected Sub gvDocumentos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDocumentos.PageIndexChanging
        Me.gvDocumentos.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub gvDocumentos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDocumentos.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim cC As New cCONTRATOS

            Dim gv As GridView = CType(e.Row.FindControl("GridView2"), GridView)

            If e.Row.RowIndex > -1 Then
                gv.DataSource = cC.ObtenerDatasetFuentesFinanciamientoContrato(Me.gvDocumentos.DataKeys(e.Row.RowIndex).Values.Item("IDESTABLECIMIENTO").ToString(), _
                       Me.gvDocumentos.DataKeys(e.Row.RowIndex).Values.Item("IDPROVEEDOR").ToString(), _
                       Me.gvDocumentos.DataKeys(e.Row.RowIndex).Values.Item("IDCONTRATO").ToString())
                gv.DataBind()
            End If

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

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvDocumentos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDocumentos.SelectedIndexChanged
        Me.gvRelacionados.PageIndex = 0
        Me.gvRenglones.PageIndex = 0
        ObtenerDetalleContrato()
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.Session("rptEstablecimiento") = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("IDESTABLECIMIENTO").ToString()
        Me.Session("rptCONTRATO") = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("IDCONTRATO").ToString
        Me.Session("rptPROVEEDOR") = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Values.Item("IDPROVEEDOR").ToString()
        Me.Session("rptALMACENENTREGA") = Me.gvDocumentos.DataKeys(Me.gvDocumentos.SelectedIndex).Item("IDALMACENENTREGA").ToString

        'Response.Write("<script language=javascript>")
        'Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/FrmRptContratosOtrosDocRenglones.aspx');")
        'Response.Write("</script>")

        SINAB_Utils.Utils.MostrarVentana("/Reportes/FrmRptContratosOtrosDocRenglones.aspx")

    End Sub

    Protected Sub gvRenglones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRenglones.PageIndexChanging
        Me.gvRenglones.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub gvRelacionados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRelacionados.PageIndexChanging
        Me.gvRelacionados.PageIndex = e.NewPageIndex
    End Sub

End Class
