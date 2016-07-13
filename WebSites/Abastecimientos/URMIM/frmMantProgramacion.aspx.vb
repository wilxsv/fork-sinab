Imports ABASTECIMIENTOS.NEGOCIO

Partial Class URMIM_frmMantProgramacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página
            'ocultar menu
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False

            CargarDatos()

            Filtros()
        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION

        If Me.ViewState("DS_gvLista") Is Nothing Then
            'ds = mComponente.ObtenerListapor_ESTADO(lENTIDAD, _EVAL_FEC_RET, _EVAL_FEC_REC, ESTADOS, USUARIOCOMISION)
            ds = mComponente.obtenerDsProgramacion()
            'Response.Write(lENTIDAD.IDESTABLECIMIENTO.ToString & "-" & lENTIDAD.IDESTADOPROCESOCOMPRA.ToString & "-" & lENTIDAD.IDENCARGADO.ToString & "-" & USUARIOCOMISION)
            Me.ViewState.Add("DS_gvLista", ds)
            'Else
            '    Me.ViewState("DS_ProcesoCompra") = ds
        End If
        ds = CType(Me.ViewState("DS_gvLista"), Data.DataSet)
        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try
        Vista()

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/URMIM/frmDetaMantProgramacion.aspx?id=0", False) 'redirecciona a formulario conteniendo detalle
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) > 1 Then
                Dim lbl As HyperLink
                Dim lbl2 As HyperLink
                Dim lbl3 As HyperLink

                lbl = e.Row.FindControl("hpProductos")

                lbl = e.Row.FindControl("hpEntregas")
                lbl2 = e.Row.FindControl("hpObsReg")
                lbl3 = e.Row.FindControl("hpObsAj")

                If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) >= 2 Then
                    lbl2.Visible = True
                    lbl3.Visible = True
                End If

                If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) > 2 Then
                    lbl.Visible = True
                End If

                If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) >= 4 Then
                    lbl.CssClass = "GridCuadroDist"
                    lbl.ToolTip = "Consultar"
                Else
                    lbl.CssClass = "GridEditar"
                    lbl.ToolTip = "Editar"
                End If

            End If
        End If
    End Sub

    Public Sub Filtros()
        LlenaFiltros()
    End Sub
    Private Sub LlenaFiltros()
        Dim dsFiltro As New Data.DataSet("DSFILTROS")
        dsFiltro.Tables.Add("FILTROS")
        dsFiltro.Tables("FILTROS").Columns.Add("DESCRIPCION")
        dsFiltro.Tables("FILTROS").Columns.Add("CAMPO")

        For Each dc As Object In Me.gvLista.Columns
            If TypeOf dc Is BoundField Then
                Dim FILA As Data.DataRow = dsFiltro.Tables("FILTROS").NewRow
                FILA("CAMPO") = CType(dc, BoundField).DataField
                FILA("DESCRIPCION") = CType(dc, BoundField).HeaderText
                dsFiltro.Tables("FILTROS").Rows.Add(FILA)
            End If
        Next
        ddlFiltro.DataSource = dsFiltro.Tables("FILTROS")

        ddlFiltro.DataTextField = "DESCRIPCION"
        ddlFiltro.DataValueField = "CAMPO"
        ddlFiltro.DataBind()
    End Sub
    Private Sub Vista()
        Dim dvPC As New Data.DataView(CType(Me.ViewState("DS_gvLista"), Data.DataSet).Tables(0))
        dvPC.Sort = "FECHAPROGRAMACION DESC"
        If Not ddlFiltro.SelectedValue = "" Then
            dvPC.RowFilter = "convert(" & ddlFiltro.SelectedValue & " , 'System.String') LIKE '%" & txtFiltro.Text & "%'"
        End If
        gvLista.DataSource = dvPC
        gvLista.DataBind()
    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Vista()
    End Sub
End Class
