Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmMantUsuariosRoles
    Inherits System.Web.UI.Page

    Private mComponente As New cUSUARIOS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = True
            Me.ucBarraNavegacion1.ibtnImprimirOnClientClick = ReporteUsuariosRoles()

            Me.ddlROLES1.RecuperarListaRolesHabilitados()

            If Request.QueryString.HasKeys Then
                Dim lId As Int32 = Request.QueryString("idRol")
                Me.ddlROLES1.SelectedValue = lId
            End If

            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerListaPorRol(CInt(Me.ddlROLES1.SelectedValue))
        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try
    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/SEGURIDAD/FrmDetaMantUsuariosRoles.aspx?idRol=" & Me.ddlROLES1.SelectedValue & "&rol=" & Me.ddlROLES1.SelectedItem.Text, False)
    End Sub

    Protected Sub DdlROLES1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlROLES1.SelectedIndexChanged
        CargarDatos()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDUSUARIO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)

        If Me.mComponente.EliminarUsuarioRol(IDUSUARIO, Me.ddlROLES1.SelectedValue) = 0 Then
            'Si se cometio un error
        Else
            Me.CargarDatos()
        End If
    End Sub

    Private Function ReporteUsuariosRoles() As String
        Dim cad = "/Reportes/ FrmRptRolesUsuarios.aspx"

        'Dim s As New StringBuilder
        ''s.Append("window.open('")
        ''s.Append(Request.ApplicationPath)
        's.Append("/Reportes/FrmRptRolesUsuarios.aspx")
        ''s.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

        Return SINAB_Utils.Utils.ReferirVentana(cad)
        's.ToString()
    End Function

End Class
