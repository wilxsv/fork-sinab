Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ALMACEN_FrmBusquedaCodigos
    Inherits System.Web.UI.Page

    Private cCP As New cCATALOGOPRODUCTOS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.ddlSUMINISTROS1.Recuperar()
            Me.Master.ControlMenu.Visible = False
        End If
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Me.TextBox2.Text = "" And Me.TextBox2.Enabled = True Then
            Me.Label1.Text = "Escriba un parámetro de búsqueda."
            Exit Sub
        Else
            Me.Label1.Text = ""
        End If

        If Me.DropDownList1.SelectedValue = 0 And Me.TextBox2.Enabled = True Then
            If Me.TextBox2.Text.Length <> 8 Then
                Me.Label1.Text = "El código del producto debe ser de 8 dígitos"
                Exit Sub
            Else
                Me.Label1.Text = ""
            End If
        End If
        If Me.ddlSUMINISTROS1.SelectedIndex = -1 Then
            Me.Label1.Text = "Seleccione una clase de suministro."
            Exit Sub
        End If

        Dim ds As Data.DataSet
        ds = cCP.ObtenerCatalogoProductosCompletoOficial(Me.ddlSUMINISTROS1.SelectedValue, Me.TextBox2.Text)

        Me.gvProductos.DataSource = ds
        Me.gvProductos.DataBind()
        Me.gvProductos.Visible = True
        Me.gvProductos.SelectedIndex = -1
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
