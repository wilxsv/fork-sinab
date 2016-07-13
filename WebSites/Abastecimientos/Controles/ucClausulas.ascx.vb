Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Controles_ucClausulas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me.UcBarraNavegacion1
            .PermitirImprimir = False
            .PermitirAgregar = False
            .PermitirConsultar = False
            .PermitirEditar = True
            .HabilitarEdicion(True)
            .Navegacion = False
        End With
        CargarEtiqueta()
        If Request.QueryString("tipoMod") = 1 Then
            Me.ddlTipoClausula.Visible = True
            Me.Label5.Visible = True
        End If
        Select Case Request.QueryString("mod")
            Case Is = "NEW"
            Case Is = "EDIT"
                If Not IsPostBack Then
                    obtenerDatos()
                End If
        End Select
    End Sub

    Private Sub obtenerDatos()
        Dim id As Integer
        id = Request.QueryString("id")
        Dim mComponente As New cCLAUSULAS
        Dim lEntidad As New CLAUSULAS

        Dim ds As Data.DataSet

        ds = mComponente.ObtenerDataSetPorId(id)

        With ds.Tables(0).Rows(0)
            Me.txtNombreClausula.Text = .Item("NOMBRE")
            If .Item("ESREQUERIDA") = 1 Then
                Me.chkRequerida.Checked = True
            Else
                Me.chkRequerida.Checked = False
            End If
            Me.rteContenido.Text = .Item("CONTENIDO")
        End With
    End Sub

    Private Sub CargarEtiqueta()
        Dim mComponente As New cETIQUETASCLAUSULAS
        Dim lEntidad As New ETIQUETASCLAUSULAS

        Me.dgEtiqueta.DataSource = mComponente.ObtenerDataSetPorTipo(Request.QueryString("tipoMod"))
        Me.dgEtiqueta.DataBind()

    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        Response.Redirect("~/UACI/frmMantClausula.aspx")
    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        Dim mComponente As New cCLAUSULAS
        Dim lEntidad As New CLAUSULAS

        With lEntidad
            If Request.QueryString("mod") = "EDIT" Then
                .IDCLAUSULA = Request.QueryString("id")
            End If
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .NOMBRE = Me.txtNombreClausula.Text
            If Request.QueryString("tipoMod") = 1 Then
                .ESTASINCRONIZADA = Me.ddlTipoClausula.SelectedValue
            Else
                .ESTASINCRONIZADA = 0
            End If
            .CONTENIDO = Me.rteContenido.Text
            If Me.chkRequerida.Checked Then
                .ESREQUERIDA = 1
            Else
                .ESREQUERIDA = 0
            End If
        End With

        If mComponente.ActualizarCLAUSULAS(lEntidad) <> 1 Then
            Me.lblMensaje.Text = "El registro no ha sido almacenado, verifique sus datos o informe al administrador"
        Else
            Me.MsgBox1.ShowAlert("El registro se ha almacenado satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End If


    End Sub

    Protected Sub dgEtiqueta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEtiqueta.SelectedIndexChanged
        Response.Write("<script languaje=javascript>javascript:cpS(" & dgEtiqueta.SelectedItem.Cells(2).Text & ");</script>")
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        Response.Redirect("~/UACI/FrmMantClausula.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.MsgBox1.ShowConfirm("¿Desea eliminar la clausula?", "ELIMINAR", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "ELIMINAR" Then
            Dim mComponente As New cCLAUSULAS
            Dim lEntidad As New CLAUSULAS
            mComponente.EliminarCLAUSULAS(Request.QueryString("id"))
            Response.Redirect("~/UACI/frmMantClausula.aspx")
        End If
    End Sub
End Class
