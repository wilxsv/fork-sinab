Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports eWorld.UI

Partial Class ALMACEN_FrmRegistroFechasEntrega
    Inherits System.Web.UI.Page

    Private cCP As New cCATALOGOPRODUCTOS
    Private cdis As New cDistribucion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr = Membresia.ObtenerUsuario()
            'Me.ddlSUMINISTROS1.DataSource = cdis.ListaDistribucionesCerradas(Year(Date.Now), Session("IdEstablecimiento"))
            'Me.ddlSUMINISTROS1.DataTextField = "DESCRIPCION"
            'Me.ddlSUMINISTROS1.DataValueField = "IDDISTRIBUCION"
            'Me.ddlSUMINISTROS1.DataBind()
            Distribucion.CargarCerradosTodosALista(ddlSUMINISTROS1, usr.Establecimiento.IDESTABLECIMIENTO, Year(Date.Now))
            Me.ddlSUMINISTROS1.Items.Insert(0, "Seleccione una distribución")
            Me.ddlSUMINISTROS1.SelectedValue = 0
            Me.Master.ControlMenu.Visible = False
        End If
    End Sub

    'Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
    '    If Me.TextBox2.Text = "" And Me.TextBox2.Enabled = True Then
    '        Me.Label1.Text = "Escriba un parámetro de búsqueda."
    '        Exit Sub
    '    Else
    '        Me.Label1.Text = ""
    '    End If

    '    If Me.DropDownList1.SelectedValue = 0 And Me.TextBox2.Enabled = True Then
    '        If Me.TextBox2.Text.Length <> 8 Then
    '            Me.Label1.Text = "El código del producto debe ser de 8 dígitos"
    '            Exit Sub
    '        Else
    '            Me.Label1.Text = ""
    '        End If
    '    End If
    '    If Me.ddlSUMINISTROS1.SelectedIndex = -1 Then
    '        Me.Label1.Text = "Seleccione una clase de suministro."
    '        Exit Sub
    '    End If

    '    Dim ds As Data.DataSet
    '    ds = cCP.ObtenerCatalogoProductosCompletoOficial(Me.ddlSUMINISTROS1.SelectedValue, Me.TextBox2.Text)

    '    Me.gvProductos.DataSource = ds
    '    Me.gvProductos.DataBind()
    '    Me.gvProductos.Visible = True
    '    Me.gvProductos.SelectedIndex = -1
    'End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.gvProductos.DataSource = cdis.ListaDistribucionFechaEntrega(Me.ddlSUMINISTROS1.SelectedValue, Session("IdEstablecimiento"))
        Me.gvProductos.DataBind()
        Me.gvProductos.Visible = True

        If gvProductos.Rows.Count > 0 Then
            Me.Button7.Visible = True
            Me.Button9.Visible = True
        Else
            Me.Button7.Visible = False
            Me.Button9.Visible = False
        End If

        Me.Label1.Visible = False
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try

            'cdis.EliminarFechasEntrega(Me.ddlSUMINISTROS1.SelectedValue, Session("IdEstablecimiento"))
            For Each row As GridViewRow In gvProductos.Rows
                If IIf(IsDBNull(Me.gvProductos.DataKeys(row.RowIndex).Values(3)), Date.Now, Me.gvProductos.DataKeys(row.RowIndex).Values(3)) <> CDate(CType(row.Cells(2).FindControl("cpFechaDesde"), TextBox).Text) Then
                    cdis.ActualizarFechasEntrega(Me.ddlSUMINISTROS1.SelectedValue, Me.gvProductos.DataKeys(row.RowIndex).Values(1), Me.gvProductos.DataKeys(row.RowIndex).Values(2), Me.gvProductos.DataKeys(row.RowIndex).Values(0), CDate(CType(row.Cells(2).Controls(1), eWorld.UI.CalendarPopup).SelectedDate.ToShortDateString), CStr(CType(row.Cells(3).Controls(1), TextBox).Text))
                End If
            Next

            'cambiar lista de distribucion a estado pendiente
            Dim c As New cDistribucion
            c.actualizarEstadoDistribucion(Me.ddlSUMINISTROS1.SelectedValue, Session("idestablecimiento"), 3, User.Identity.Name, 0)

            Me.gvProductos.DataSource = cdis.ListaDistribucionFechaEntrega(Me.ddlSUMINISTROS1.SelectedValue, Session("IdEstablecimiento"))
            Me.gvProductos.DataBind()

            Me.Label1.Visible = True
            Me.Label1.Text = "Las fechas de entrega se han actualizado. El sistema enviará notificación a los establecimientos."
            Me.Button8.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gvProductos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvProductos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim fecha As TextBox
            'fecha = sender.FindControl("cpFechaDesde")
            fecha = CType(e.Row.Cells(1).FindControl("cpFechaDesde"), TextBox)

            fecha.Text = CDate(IIf(IsDBNull(Me.gvProductos.DataKeys(e.Row.RowIndex).Values(3)), Date.Now, Me.gvProductos.DataKeys(e.Row.RowIndex).Values(3))).ToShortDateString()
            
            Dim obs As New TextBox
            obs = CType(e.Row.Cells(2).FindControl(("Textbox3")), TextBox)

            obs.Text = CType(Me.gvProductos.DataKeys(e.Row.RowIndex).Values(4), String)

        End If

    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim IDDISTRIBUCION As Integer = Me.ddlSUMINISTROS1.SelectedValue

        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptDistribucionFechaEntrega.aspx?id=" & IDDISTRIBUCION
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim c As New cDistribucion
        c.actualizarEstadoDistribucion(Me.ddlSUMINISTROS1.SelectedValue, Session("idestablecimiento"), 5, User.Identity.Name, 0)
        Me.Label1.Visible = True
        Me.Label1.Text = "La lista de distribución se ha suspendido."

        Me.Button9.Enabled = False
        Me.Button7.Enabled = False
    End Sub

    Protected Sub gvProductos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvProductos.RowDeleting
        Dim iddistribucion As Integer = CType(Me.ddlSUMINISTROS1.SelectedValue, Integer)
        Dim idestablecimiento As Integer = CType(Me.gvProductos.DataKeys(e.RowIndex).Values(0), Integer)

        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptDistribucion.aspx?id=" & iddistribucion & "&tipo=0&est=" & idestablecimiento & "&prod=0&guarda=1"
        SINAB_Utils.Utils.MostrarVentana(alerta)

        'Dim iddistribucion As Integer = CType(Me.DropDownList2.SelectedValue, Integer)
        'Dim idestablecimientodistribucion As Integer = Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO

        'Dim idestablecimiento = Distribucion.ObtenerCerrados(iddistribucion, idestablecimientodistribucion).IDESTABLECIMIENTO

        'Dim tipo As Integer
        'tipo = 0

        ''Mostrar el reporte
        'Dim alerta As String = "/Reportes/frmRptDistribucion.aspx?id=" & iddistribucion & "&tipo=" & tipo & "&est=" & idestablecimiento & "&prod=0&elaborodist=true"

        'SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub
End Class
