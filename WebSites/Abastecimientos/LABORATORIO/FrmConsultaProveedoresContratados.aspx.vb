Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmConsultaProveedoresContratados
    Inherits System.Web.UI.Page

    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer

#Region "propertys"

    Public Property IDPROVEEDOR() As Integer
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            Me._IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return Me._IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            Me._IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDatos()
        Else
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
        End If

    End Sub

    Private Sub CargarDatos()
        Dim cC As New cCONTRATOS
        Dim ds As Data.DataSet
        ds = cC.obtenerProveedoresContratados()

        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If UcFiltrarDatos1.CampoFiltro <> "" And UcFiltrarDatos1.ValorFiltro <> "" Then
            Select Case dsVista.Table.Columns(UcFiltrarDatos1.CampoFiltro).DataType.Name
                Case "String"
                    dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " LIKE '%" & UcFiltrarDatos1.ValorFiltro & "%'"
            End Select
        End If

        Me.gvContratos.DataSource = dsVista

        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            Me.gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try

        If Not Page.IsPostBack Then
            UcFiltrarDatos1.AddColumnasExcluidas(gvContratos.Columns(5).HeaderText)
            UcFiltrarDatos1.AddColumnasExcluidas(gvContratos.Columns(6).HeaderText)
            UcFiltrarDatos1.ValorColumnas = gvContratos.Columns
        End If

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cI As New cINFORMEMUESTRAS
            Dim g As GridView = CType(e.Row.Cells(7).Controls(1), GridView)
            g.DataSource = cI.ObtenerInformacionProveedores(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO, e.Row.Cells(0).Text)
            g.DataBind()
        End If

    End Sub

    Protected Sub gvContratos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvContratos.PageIndexChanging
        Me.gvContratos.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvContratos.SelectedIndexChanging
        IDPROVEEDOR = Me.gvContratos.DataKeys(e.NewSelectedIndex).Values(0)
        IDCONTRATO = Me.gvContratos.DataKeys(e.NewSelectedIndex).Values(1)

        Dim cP As New cPROVEEDORES
        Me.GridView2.DataSource = cP.DetalleProveedoresContratados(Session("IdEstablecimiento"), IDPROVEEDOR, IDCONTRATO)
        Me.GridView2.DataBind()

        Session("NoContrato") = Me.gvContratos.Rows(e.NewSelectedIndex).Cells(2).Text
        Session("CodProveedor") = Me.gvContratos.Rows(e.NewSelectedIndex).Cells(3).Text
        Session("Proveedor") = Me.gvContratos.Rows(e.NewSelectedIndex).Cells(4).Text
        Session("MontoContratado") = Me.gvContratos.Rows(e.NewSelectedIndex).Cells(5).Text
        Session("Fecha") = Me.gvContratos.Rows(e.NewSelectedIndex).Cells(6).Text

        Me.btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptProveedoresContratados.aspx?idC=" & IDCONTRATO.ToString & "&idP=" & IDPROVEEDOR.ToString)
        '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptProveedoresContratados.aspx?idC=" & IDCONTRATO.ToString & "&idP=" & IDPROVEEDOR.ToString & " ', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"
        Me.btnImprimir.Visible = True

    End Sub

    Protected Sub UcFiltrarDatos1_Buscar() Handles UcFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

End Class
