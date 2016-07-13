Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmAsignacionProveedoresAnalista
    Inherits System.Web.UI.Page

    Private mComponente As New cANALISTAPROVEEDORES

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            'Me.ddlEMPLEADOS1.RecuperarEmpleadosPorDependencia(Session("IdEstablecimiento"), Session("IdDependencia"), Session("IdEmpleado"))
            Me.ddlEMPLEADOS1.RecuperarEmpleadosPorDependenciaAnalistaJuridico(Session("IdEstablecimiento"), Session("IdDependencia"), Session("IdEmpleado"))

            ObtenerProveedoresNoAsignados()
            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()
        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerProveedoresAsignados(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.ddlEMPLEADOS1.SelectedValue)

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

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDESTABLECIMIENTO As Integer = Session("IdEstablecimiento")
        Dim IDPROCESOCOMPRA As Integer = Request.QueryString("idProc")
        Dim IDPROVEEDOR As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDANALISTA As Integer = Me.ddlEMPLEADOS1.SelectedValue

        If Me.mComponente.EliminarANALISTAPROVEEDORES(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDANALISTA) = 0 Then
            'Si se cometio un error
        Else
            ObtenerProveedoresNoAsignados()
            CargarDatos()
        End If
    End Sub

    Protected Sub btnAsociar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsociar.Click
        Dim mEntidad As New ANALISTAPROVEEDORES

        Dim IDANALISTA As Integer = Me.ddlEMPLEADOS1.SelectedValue
        Dim IDPROVEEDOR As Integer = Me.ddlPROVEEDORES1.SelectedValue

        mEntidad.IDANALISTA = IDANALISTA
        mEntidad.IDPROVEEDOR = IDPROVEEDOR
        mEntidad.IDESTABLECIMIENTO = Me.Session("IdEstablecimiento")
        mEntidad.IDPROCESOCOMPRA = Me.Request.QueryString("IdProc")
        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHACREACION = Today

        mComponente.AgregarANALISTAPROVEEDORES(mEntidad)

        ObtenerProveedoresNoAsignados()
        CargarDatos()

    End Sub

    Protected Sub ddlEMPLEADOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS1.SelectedIndexChanged
        CargarDatos()
    End Sub

    Private Sub ObtenerProveedoresNoAsignados()

        Me.ddlPROVEEDORES1.ObtenerProveedoresNoAsignados(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        If Me.ddlPROVEEDORES1.Items.Count > 0 Then
            Me.ddlPROVEEDORES1.Visible = True
            Me.lblProveedoresAsignados.Visible = False
            Me.btnAsociar.Enabled = True
        Else
            Me.ddlPROVEEDORES1.Visible = False
            Me.lblProveedoresAsignados.Visible = True
            Me.btnAsociar.Enabled = False
        End If

    End Sub

End Class
