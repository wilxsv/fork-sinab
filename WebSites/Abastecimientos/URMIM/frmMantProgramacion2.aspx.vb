Imports ABASTECIMIENTOS.NEGOCIO

Partial Class URMIM_frmMantProgramacion2
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

        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION

        ds = mComponente.obtenerDsProgramacion()

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
        Response.Redirect("~/URMIM/frmDetaMantProgramacion2.aspx?id=0", False) 'redirecciona a formulario conteniendo detalle
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) > 1 Then
                Dim lbl As HyperLink
                'Dim lbl2 As HyperLink
                'Dim lbl3 As HyperLink

                lbl = e.Row.FindControl("hpProductos")

                ' lbl = e.Row.FindControl("hpEntregas")
                'lbl2 = e.Row.FindControl("hpObsReg")
                'lbl3 = e.Row.FindControl("hpObsAj")

                'If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) >= 2 Then
                '    lbl2.Visible = True
                '    lbl3.Visible = True
                'End If

                If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) > 2 Then
                    lbl.Visible = True
                End If

                If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) >= 4 Then
                    lbl.Text = "Consultar"
                End If

            End If
        End If
    End Sub
End Class
