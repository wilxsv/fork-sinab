
Partial Class FrmReporteCertificadosControlCalidad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarDatos()

        Dim IDTIPOINFORME() As Byte = {eTIPOINFORME.ACEPTACION, eTIPOINFORME.NOINSPECCION, eTIPOINFORME.RECHAZO}

        Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Dim ds As Data.DataSet
        ds = cIM.ObtenerListaInformes(Session("IdEstablecimiento"), 3, IDTIPOINFORME)

        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If UcFiltrarDatos1.CampoFiltro <> "" And UcFiltrarDatos1.ValorFiltro <> "" Then
            Select Case dsVista.Table.Columns(UcFiltrarDatos1.CampoFiltro).DataType.Name
                Case "String"
                    dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " LIKE '%" & UcFiltrarDatos1.ValorFiltro & "%'"
            End Select
        End If

        Me.gvLista.DataSource = dsVista

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        If Not Page.IsPostBack Then
            UcFiltrarDatos1.AddColumnasExcluidas(gvLista.Columns(3).HeaderText)
            UcFiltrarDatos1.ValorColumnas = gvLista.Columns
        End If

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lb As LinkButton = CType(e.Row.FindControl("lbVer"), LinkButton)
            Dim cad = String.Format("/Reportes/FrmRptInformeMuestras.aspx?idE{0}&idI={1}&idTI={2}&C={3}", gvLista.DataKeys(e.Row.RowIndex).Values(0), gvLista.DataKeys(e.Row.RowIndex).Values(1), gvLista.DataKeys(e.Row.RowIndex).Values(2))


            'Dim s As New StringBuilder

            's.Append("window.open('")
            's.Append(Request.ApplicationPath)
            's.Append("/Reportes/FrmRptInformeMuestras.aspx")
            's.Append("?idE=")
            's.Append(Me.gvLista.DataKeys(e.Row.RowIndex).Values(0).ToString())
            's.Append("&idI=")
            's.Append(Me.gvLista.DataKeys(e.Row.RowIndex).Values(1).ToString())
            's.Append("&idTI=")
            's.Append(Me.gvLista.DataKeys(e.Row.RowIndex).Values(2).ToString())
            's.Append("&C=")
            's.Append(Boolean.TrueString.ToLower)
            's.Append("', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return false;")

            lb.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            's.ToString

        End If
    End Sub

    Protected Sub UcFiltrarDatos1_Buscar() Handles UcFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

End Class
