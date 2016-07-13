'Notificar incumplimientos de documentacion
'CU-UACI011
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario que muestra los proceso de compras listros pa notificar el incumplimiento de documentacion
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmGenerarNotasIncumplimientos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then ' primera vez que carga
            Me.Master.ControlMenu.Visible = False 'oculta menu

            CargarDatosProcesoCompra()
        End If

    End Sub

    Private Sub CargarDatosProcesoCompra()

        Dim mComponente As New cPROCESOCOMPRAS

        'carga datos con los procesos de compra que se encuentren en estado de examen preliminar (6)
        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSetEstado(Session.Item("IdEstablecimiento"), eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS) 'Examen preliminar

        Me.gvLista.DataSource = ds

        'carga grid
        Try
            Me.gvLista.DataBind()
        Catch ex As Exception 'al momento de error de pagineo
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        'al cambiar el numero de indice de pagina del grid
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatosProcesoCompra()
    End Sub

End Class
