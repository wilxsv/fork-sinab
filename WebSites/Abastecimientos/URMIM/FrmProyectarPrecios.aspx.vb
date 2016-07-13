Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class frmProyectarPrecios
    Inherits System.Web.UI.Page

    Private mComponente As New cCATALOGOPRODUCTOS
    Private mEntidad As New CATALOGOPRODUCTOS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Master.ControlMenu.Visible = False

        If Not Page.IsPostBack Then
            Me.TxtBuscar.Visible = False
            Me.BtnRestaurar.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.DdlSUBGRUPOS1.Visible = False
            Me.DdlSUMINISTROS1.Visible = False
            Me.DdlPresentacion.Visible = True

            CargarDatos()
        End If
    End Sub

    Private Sub CargarDatos()

        Me.DgLista.DataSource = Me.mComponente.FiltrarCatalogoProductos("", 0, 0)

        Try
            Me.DgLista.DataBind()
        Catch ex As Exception
            Me.DgLista.CurrentPageIndex = 0
            Me.DgLista.DataBind()
        End Try

        Me.DdlSUMINISTROS1.RecuperarListaFiltrada(1)
        Me.DdlGRUPOS1.Recuperar()
        Me.DdlSUBGRUPOS1.Recuperar()
        Me.lblTipoFiltro.Text = "Lista completa"
    End Sub

    Private Sub CargarDatosFiltrados()

        Dim sTextoBusqueda As String
        Dim iTipoFiltro As Int16
        sTextoBusqueda = ""

        Select Case Me.DdlPresentacion.SelectedItem.Value
            Case Is = 0
                iTipoFiltro = 0
                Me.lblTipoFiltro.Text = "Lista completa"
            Case Is = 1
                iTipoFiltro = 1
                sTextoBusqueda = Me.DdlSUMINISTROS1.SelectedItem.Value
                Me.lblTipoFiltro.Text = "Suministro: " & Me.DdlSUMINISTROS1.SelectedItem.Text
            Case Is = 2
                iTipoFiltro = 2
                sTextoBusqueda = Me.DdlGRUPOS1.SelectedItem.Value
                Me.lblTipoFiltro.Text = "Grupo: " & Me.DdlGRUPOS1.SelectedItem.Text
            Case Is = 3
                iTipoFiltro = 3
                sTextoBusqueda = Me.DdlSUBGRUPOS1.SelectedItem.Value
                Me.lblTipoFiltro.Text = "Subgrupo: " & Me.DdlSUBGRUPOS1.SelectedItem.Text
            Case Is = 4
                iTipoFiltro = 4
                sTextoBusqueda = Me.TxtBuscar.Text
        End Select

        If sTextoBusqueda = "" And Me.DdlPresentacion.SelectedValue > 0 Then
            MsgBox1.ShowAlert("Seleccione un criterio de presentación de la información", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            If Me.chkMostrarCero.Checked = True Then
                Me.DgLista.DataSource = mComponente.FiltrarCatalogoProductos(sTextoBusqueda, iTipoFiltro, 1)
            Else
                Me.DgLista.DataSource = mComponente.FiltrarCatalogoProductos(sTextoBusqueda, iTipoFiltro, 0)
            End If

            Try
                Me.DgLista.DataBind()
            Catch ex As Exception
                Me.DgLista.CurrentPageIndex = 0
                Me.DgLista.DataBind()
            End Try

        End If

        Me.PnlNuevoPrecio.Visible = False
        Me.DgLista.SelectedIndex = -1
    End Sub

    Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgLista.PageIndexChanged
        Me.DgLista.CurrentPageIndex = e.NewPageIndex
        Me.CargarDatosFiltrados()
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        CargarDatosFiltrados()
    End Sub

    Protected Sub DdlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSUMINISTROS1.SelectedIndexChanged
        Try
            Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.DdlSUMINISTROS1.SelectedItem.Value)
            Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedValue)
        Catch ex As Exception
            Return
        End Try
    End Sub

    Protected Sub ddlPresentacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlPresentacion.SelectedIndexChanged
        Me.TxtBuscar.Text = ""
        Select Case DdlPresentacion.SelectedItem.Value
            Case Is = 0
                Me.DdlGRUPOS1.Visible = False
                Me.DdlSUBGRUPOS1.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BtnFiltrar.Visible = True
                Me.BtnRestaurar.Visible = False
                Me.chkMostrarCero.Checked = False
                CargarDatos()
            Case Is = 1
                Me.DdlSUMINISTROS1.Visible = True
                Me.DdlGRUPOS1.Visible = False
                Me.DdlSUBGRUPOS1.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BtnFiltrar.Visible = True
                Me.BtnRestaurar.Visible = True
            Case Is = 2
                Me.DdlSUMINISTROS1.Visible = True
                Me.DdlGRUPOS1.Visible = True
                Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.DdlSUMINISTROS1.SelectedValue)
                Me.DdlSUBGRUPOS1.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BtnFiltrar.Visible = True
                Me.BtnRestaurar.Visible = True
            Case Is = 3
                Me.DdlSUMINISTROS1.Visible = True
                Me.DdlGRUPOS1.Visible = True
                Me.DdlSUBGRUPOS1.Visible = True
                Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedValue)
                Me.TxtBuscar.Visible = False
                Me.BtnFiltrar.Visible = True
                Me.BtnRestaurar.Visible = True
            Case Is = 4
                Me.DdlSUMINISTROS1.Visible = False
                Me.DdlGRUPOS1.Visible = False
                Me.DdlSUBGRUPOS1.Visible = False
                Me.TxtBuscar.Visible = True
                Me.BtnFiltrar.Visible = True
                Me.BtnRestaurar.Visible = True
        End Select
    End Sub

    Protected Sub DdlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlGRUPOS1.SelectedIndexChanged
        Try
            Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedItem.Value)
        Catch ex As Exception
            Return
        End Try

    End Sub

    Protected Sub DgLista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgLista.SelectedIndexChanged
        If Val(Me.DgLista.SelectedItem.Cells(3).Text) > 0 Then
            MsgBox1.ShowAlert("El producto ya posee un precio asignado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            Me.PnlNuevoPrecio.Visible = True
            Me.LblCodigo.Text = Me.DgLista.SelectedItem.Cells(1).Text
            Me.LblNombre.Text = Me.DgLista.SelectedItem.Cells(2).Text
        End If
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim mEntProductos As New CATALOGOPRODUCTOS
        If Me.TxtNuevoPrecio.Text = "" Then
            MsgBox1.ShowAlert("Debe especificar el precio del producto para poder finalizar la operación", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtNuevoPrecio.Focus()
            Return
        End If

        mEntProductos.IDPRODUCTO = Me.DgLista.SelectedItem.Cells(0).Text
        mComponente.ObtenerCatalogoProductos(mEntProductos)
        mEntProductos.PRECIOACTUAL = Me.TxtNuevoPrecio.Text
        mEntProductos.ESTASINCRONIZADA = 0

        If mComponente.ActualizarCATALOGOPRODUCTOS(mEntProductos) = 1 Then
            MsgBox1.ShowAlert("La precio del producto fue actualizado correctamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            MsgBox1.ShowAlert("El valor especificado excede el precio maximo imponible a un producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If

        Me.PnlNuevoPrecio.Visible = False

        CargarDatos()
    End Sub

    Protected Sub BtnRestaurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRestaurar.Click
        Me.DdlPresentacion.SelectedIndex = 0
        Me.DdlSUMINISTROS1.Visible = False
        Me.DdlGRUPOS1.Visible = False
        Me.DdlSUBGRUPOS1.Visible = False
        Me.TxtBuscar.Visible = False
        Me.BtnFiltrar.Visible = True
        Me.BtnRestaurar.Visible = False
        Me.PnlNuevoPrecio.Visible = False
        CargarDatos()
        Me.DgLista.SelectedIndex = -1
        Me.lblTipoFiltro.Text = "Lista completa"
        Me.chkMostrarCero.Checked = False
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
