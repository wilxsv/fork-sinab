Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ESTABLECIMIENTOS_frmMantProgramacion
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
            Me.ucBarraNavegacion1.PermitirAgregar = False
            CargarDatos()

        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION
        'aki adicionar rol por tipo de suministro para obtener programacion finalizada
        If Me.Session("idrol") <> 47 Then

        End If
        'obtenerDsProgramacionEstablecimientoOtros()
        ds = mComponente.obtenerDsProgramacionEstablecimiento(Session.Item("idEstablecimiento"), 2, Session("IdRol"))
        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
       
            Response.Redirect("~/ESTABLECIMIENTOS/frmDetaMantProgramacion.aspx?id=0", False) 'redirecciona a formulario conteniendo detalle

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim valor As Integer

            Dim hp1 As HyperLink = e.Row.FindControl("HyperLinkDetalle1")
            Dim hp2 As HyperLink = e.Row.FindControl("HyperLinkDetalle2")
            Dim hp3 As HyperLink = e.Row.FindControl("HyperLinkDetalle3")

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(2) > 2 Then
                hp1.Enabled = False
            End If

            valor = Me.gvLista.DataKeys(e.Row.RowIndex).Values(1)

            If valor = 0 Then
                hp2.Visible = False
                hp3.Visible = False
            ElseIf valor = 1 Then
                hp3.Visible = False
            ElseIf valor = 2 Then
                hp1.Text = "Consultar"
                hp2.Text = "Consultar"
            Else
                hp1.Text = "Consultar"
                hp2.Text = "Consultar"
                hp3.Text = "Consultar"
            End If

        End If
    End Sub

End Class
