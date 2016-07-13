Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Entidades.Helpers
Partial Class UACI_CERTIFICACION_frmProcesos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CatalogoHelpers.Suministros.CargarALista(DropDownList1)
            
            Me.DropDownList1.Items.Insert(0, New ListItem("(Todos)", "0"))

            cargardatos()
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Public Sub cargardatos()
        Dim cx As New cListaCP

        NuevoProceso.CargarDatos()
        'Dim cp As New cProcesoCP
        Me.GridView1.DataSource = CertificacionHelpers.Procesos.ObtenerTodos()
        Me.GridView1.DataBind()

    End Sub
#Region "primero"
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        NuevoProceso.LimpiarDatos()
        Me.mdlPopup.Show()
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.mdlPopup.Hide()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim cx As New cProcesoCP
        Dim ds As New Data.DataSet
        ds = cx.BuscarEstadoTipoProducto(CType(NuevoProceso.IdTipoProducto, Integer))
        Dim i As Integer
        Dim h As Integer = 0
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item(0) = 0 Then
                Me.lblError.Text = "Existe un proceso abierto para este tipo de producto."
                Me.lblError.Visible = True
                h = 1
                Me.mdlPopup.Show()
                Exit For
            End If
        Next

        If h = 0 Then

            Dim x As New PROCESOCP
            x.IDPROCESO = 0
            x.NUMPROCESO = NuevoProceso.NumeroProceso
            x.IDTIPOPRODUCTO = CType(NuevoProceso.IdTipoProducto, Integer)
            x.FECHAINICIO = CDate(NuevoProceso.FechaInicio & " 00:00:00 AM")
            x.ESTADO = 0
            x.COMENTARIO = NuevoProceso.Comentario
            cx.ActualizarProceso(x)

            Me.mdlPopup.Hide()
            cargardatos()
        End If


    End Sub

#End Region


#Region "segundo"
    Protected Sub Cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim c As New cProcesoCP
        Dim ds As New Data.DataSet

        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        ds = c.ObtenerDataSetPorId2(Me.GridView1.DataKeys(row.RowIndex).Values(0), Me.GridView1.DataKeys(row.RowIndex).Values(1))

        Me.Label12.Text = ds.Tables(0).Rows(0).Item("NUMPROCESO")
        Me.Label31.Text = ds.Tables(0).Rows(0).Item("TIPOPRODUCTO")
        Me.Label21.Text = ds.Tables(0).Rows(0).Item("FECHAINICIO")
        Me.Label1.Text = ds.Tables(0).Rows(0).Item("IDPROCESO")
        Me.Label2.Text = ds.Tables(0).Rows(0).Item("IDTIPOPRODUCTO")
        Me.TextBox31.Text = ""
        Me.TextBox11.Text = ""
        Me.Modalpopupextender1.Show()
    End Sub
    Protected Sub btnClose2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Modalpopupextender1.Hide()
    End Sub
    Protected Sub btnSave2_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim cx As New cProcesoCP
        Dim x As New PROCESOCP
        x.IDPROCESO = Me.Label1.Text
        x.IDTIPOPRODUCTO = Me.Label2.Text
        x.FECHAFIN = CDate(Me.TextBox31.Text & " 00:00:00 AM")
        x.COMENTARIO = Me.TextBox11.Text.ToString
        x.ESTADO = 1
        cx.ActualizarProceso(x)

        cargardatos()
        Me.Modalpopupextender1.Hide()
    End Sub
#End Region



    Protected Sub Consultar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Response.Redirect(CType(("~/UACI/CERTIFICACION/frmProveedores.aspx?idp=" & Me.GridView1.DataKeys(row.RowIndex).Values(0) & "&idtp=" & Me.GridView1.DataKeys(row.RowIndex).Values(1) & "&estado=1"), String))
    End Sub

    Protected Sub Editar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Response.Redirect(CType(("~/UACI/CERTIFICACION/frmProveedores.aspx?idp=" & Me.GridView1.DataKeys(row.RowIndex).Values(0) & "&idtp=" & Me.GridView1.DataKeys(row.RowIndex).Values(1) & "&estado=0"), String))

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        Dim c As New cProcesoCP
        Dim ds As New Data.DataSet
        ds = c.ObtenerPROCESOFiltrados(Me.DropDownList1.SelectedValue, Me.RadioButtonList1.SelectedValue)

        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim lnConsultar As LinkButton = CType(e.Row.FindControl("lnkConsultar"), LinkButton)
        Dim lnEditar As LinkButton = CType(e.Row.FindControl("lnkEditar"), LinkButton)
        Dim lnCerrar As LinkButton = CType(e.Row.FindControl("lnkCerrar"), LinkButton)

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            If (e.Row.Cells(4).Text = "Cerrado") Then
                lnConsultar.Visible = True
                lnEditar.Visible = False
                lnCerrar.Visible = False
            Else
                lnConsultar.Visible = False
                lnEditar.Visible = True
                lnCerrar.Visible = True
            End If
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c As New cProcesoCP
        Dim ds As New Data.DataSet
        ds = c.ObtenerPROCESOFiltrados(Me.DropDownList1.SelectedValue, Me.RadioButtonList1.SelectedValue)

        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

    End Sub
End Class
