Imports ABASTECIMIENTOS.NEGOCIO

Partial Class URMIM_frmConsumoUniversoMedicamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.ucBarraNavegacion1.Visible = False
            Me.Master.ControlMenu.Visible = False 'ocultar menu
            Me.lnkSalir.NavigateUrl = "~/FrmPrincipal.aspx"

            Me.txtCodigo.Text = ""

            Me.tblaDatos.Visible = False

        End If

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.btnAceptar.Enabled = True
        Me.txtCodigo.Enabled = True
        Me.txtCodigo.Text = ""
        Me.btnCancelar.Enabled = False

        Me.gvLista.DataSource = Nothing
        Me.gvLista.DataBind()
        Me.gvLista.Visible = False
        Me.tblaDatos.Visible = False

        Me.lblUM.Text = ""
        Me.lblDescripcion.Text = ""
        Me.lblCodigo.Text = ""

    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.txtCodigo.Text.Trim = "" Then Exit Sub

        Me.tblaDatos.Visible = False

        Me.lblUM.Text = ""
        Me.lblDescripcion.Text = ""
        Me.lblCodigo.Text = ""

        Dim idEstablecimiento As Integer = 0

        Me.btnAceptar.Enabled = False
        Me.txtCodigo.Enabled = False
        Me.btnCancelar.Enabled = True

        Dim cEntidad As New cCONSUMOS

        Me.gvLista.Visible = True

        Dim ds As Data.DataSet = cEntidad.listaUniversoCapturaMedicamento(Me.txtCodigo.Text.Trim)

        If Not ds Is Nothing Then

            If ds.Tables(0).Rows.Count > 0 Then

                Me.tblaDatos.Visible = True

                Me.lblCodigo.Text = ds.Tables(0).Rows(0).Item(1)
                Me.lblDescripcion.Text = ds.Tables(0).Rows(0).Item(2)
                Me.lblUM.Text = ds.Tables(0).Rows(0).Item(3)

            End If

        End If

        Me.gvLista.DataSource = ds
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
