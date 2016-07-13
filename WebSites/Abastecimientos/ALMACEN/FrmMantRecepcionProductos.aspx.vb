Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class frmMantRecepcionProductos
    Inherits System.Web.UI.Page
    Private mCompMovimientos As New cMOVIMIENTOS
    Private mEntMovimientos As New MOVIMIENTOS

    Private IdTipoMovimiento As Integer = 12

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False

        If Not Page.IsPostBack Then
            CargarTodos()
        End If
    End Sub

    Private Sub CargarTodos()
        Dim dsMovimientos As Data.DataSet

        dsMovimientos = mCompMovimientos.ObtenerRecepcionesDependenciaPrincipalDS(Session.Item("IdEstablecimiento"), 0)
        If dsMovimientos.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("No existe ningún documento activo", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.PnlPrincipal.Visible = False
        Else
            dgLista.DataSource = dsMovimientos
            dgLista.DataBind()
            Me.PnlPrincipal.Visible = True
        End If

    End Sub

    Protected Sub ImgbAgregarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbAgregarDocumento.Click
        Response.Redirect("~/ALMACEN/FrmDetMantRecepcionDependencias.aspx?IdMov=0&IdClas=0")

    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
End Class
