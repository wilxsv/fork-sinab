Imports ABASTECIMIENTOS.NEGOCIO

Partial Class URMIM_frmConsumoUniversoHospital
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.ucBarraNavegacion1.Visible = False
            Me.Master.ControlMenu.Visible = False 'ocultar menu
            Me.lnkSalir.NavigateUrl = "~/FrmPrincipal.aspx"

            Dim cEntidad As New cCONSUMOS
            Me.cboEstablecimientos.Items.Add("[Seleccione un Hospital]")
            Me.cboEstablecimientos.DataSource = cEntidad.listaHospitalesCaptura
            Me.cboEstablecimientos.DataTextField = "nombre"
            Me.cboEstablecimientos.DataValueField = "idEstablecimiento"

            Me.cboEstablecimientos.DataBind()

        End If

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.btnAceptar.Enabled = True
        Me.cboEstablecimientos.Enabled = True
        Me.btnCancelar.Enabled = False

        Me.gvLista.DataSource = Nothing
        Me.gvLista.DataBind()
        Me.gvLista.Visible = False

    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.cboEstablecimientos.SelectedIndex = 0 Then Exit Sub

        Dim idEstablecimiento As Integer = 0

        Me.btnAceptar.Enabled = False
        Me.cboEstablecimientos.Enabled = False
        Me.btnCancelar.Enabled = True

        idEstablecimiento = Me.cboEstablecimientos.SelectedItem.Value

        Dim cEntidad As New cCONSUMOS

        Me.gvLista.Visible = True

        Me.gvLista.DataSource = cEntidad.listaUniversoCapturaHospital(idEstablecimiento)

        Me.gvLista.DataBind()

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Me.gvLista.PageIndex = e.NewPageIndex

        Dim cEntidad As New cCONSUMOS
        Me.gvLista.DataSource = cEntidad.listaUniversoCapturaHospital(Me.cboEstablecimientos.SelectedItem.Value)
        Me.gvLista.DataBind()

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim img As New Image

            img = e.Row.FindControl("imgOK")

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(0) = 0 Then
                img.ImageUrl = "~/Imagenes/exclamation.png"
                'img.Visible = False
            End If

        End If

    End Sub



End Class
