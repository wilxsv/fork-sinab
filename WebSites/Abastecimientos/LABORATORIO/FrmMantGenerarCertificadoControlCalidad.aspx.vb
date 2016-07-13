
Partial Class FrmMantGenerarCertificadoControlCalidad
    Inherits System.Web.UI.Page

    Private mComponente As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()

        Dim IDTIPOINFORME() As Byte = {eTIPOINFORME.ACEPTACION, eTIPOINFORME.RECHAZO, eTIPOINFORME.NOINSPECCION}

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerListaInformes(Session("IdEstablecimiento"), 5, IDTIPOINFORME)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

End Class
