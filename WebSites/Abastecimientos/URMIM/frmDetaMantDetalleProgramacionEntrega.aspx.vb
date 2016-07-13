Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Utils

Partial Class URMIM_frmDetaMantDetalleProgramacionEntrega
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _ENTREGAS As Integer
    Private _IDESTADO As Integer

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        AddHandler ucFiltrarDatos1.filtrar, AddressOf filtro_cargar
    End Sub

    Public Property IDPROGRAMACION() As Integer 'identificador de programacion
        Get
            Return Me._IDPROGRAMACION
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMACION = Value
            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me.ViewState.Remove("IDPROGRAMACION")
            Me.ViewState.Add("IDPROGRAMACION", Value)
        End Set
    End Property

    Public Property ENTREGAS() As Integer 'identificador de programacion
        Get
            Return Me._ENTREGAS
        End Get
        Set(ByVal Value As Integer)
            Me._ENTREGAS = Value
            If Not Me.ViewState("ENTREGAS") Is Nothing Then Me.ViewState.Remove("ENTREGAS")
            Me.ViewState.Add("ENTREGAS", Value)
        End Set
    End Property

    Public Property IDESTADO() As Integer 'identificador de programacion
        Get
            Return Me._IDESTADO
        End Get
        Set(ByVal Value As Integer)
            Me._IDESTADO = Value
            If Not Me.ViewState("IDESTADO") Is Nothing Then Me.ViewState.Remove("IDESTADO")
            Me.ViewState.Add("IDESTADO", Value)
        End Set
    End Property

    Sub filtro_cargar()

        If Not ViewState.Item("valorFiltro") Is Nothing Then ViewState.Remove("valorFiltro")
        If Not ViewState.Item("columnaFiltro") Is Nothing Then ViewState.Remove("columnaFiltro")
        If Not ViewState.Item("posicionFiltro") Is Nothing Then ViewState.Remove("posicionFiltro")

        If ucFiltrarDatos1.posicionFiltro > 0 Then
            ViewState.Add("valorFiltro", ucFiltrarDatos1.valorFiltro)
            ViewState.Add("columnaFiltro", ucFiltrarDatos1.columnaFiltro)
            ViewState.Add("posicionFiltro", ucFiltrarDatos1.posicionFiltro)
        End If

        CargarDatos()

    End Sub

    Private Function filtro() As ArrayList

        Dim e_E As ABASTECIMIENTOS.ENTIDADES.eDatosFiltro
        Dim columnas As New ArrayList

        e_E = New ABASTECIMIENTOS.ENTIDADES.eDatosFiltro("Código", "CORRPRODUCTO")
        columnas.Add(e_E)
        e_E = New ABASTECIMIENTOS.ENTIDADES.eDatosFiltro("Nombre", "DESCLARGO")
        columnas.Add(e_E)

        Return columnas

    End Function

    Protected Sub mostrarFiltro()

        If Not ViewState.Item("posicionFiltro") Is Nothing Then
            ucFiltrarDatos1.posicionFiltro = CType(ViewState.Item("posicionFiltro"), Integer)
        End If

        ucFiltrarDatos1.dataGridMostrar = filtro()

    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = False

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            Me.IDPROGRAMACION = lId

            Dim cComponente As New cPROGRAMACION
            Dim eComponente As New PROGRAMACION
            eComponente = cComponente.obtenerProgramacionPorID(lId)

            Me.IDESTADO = eComponente.ESTADO
            Me.ENTREGAS = eComponente.ENTREGAS

            If eComponente.ESTADO >= 4 Then
                Me.btnConsolidad.Enabled = False
                Me.btnGuardar.Enabled = False
            End If

            mostrarFiltro()
            CargarDatos()

        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
            If Not Me.ViewState("ENTREGAS") Is Nothing Then Me._ENTREGAS = Me.ViewState("ENTREGAS")
        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACIONPRODUCTO

        ds = mComponente.obtenerDetalleEntregaProductos(Me.ViewState("IDPROGRAMACION"))

        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If Not Me.ViewState("columnaFiltro") Is Nothing Then

            Dim columnaFiltro As String = CType(Me.ViewState("columnaFiltro"), String)
            Dim valorFiltro As String = CType(Me.ViewState("valorFiltro"), String)

            dsVista.RowFilter = columnaFiltro & " LIKE '%" & valorFiltro & "%'"

        End If

        Me.gvLista.DataSource = dsVista

        mostrarFiltro()

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Call btnGuardar_Click(sender, e)
        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim cb As DropDownList
            Dim txt As TextBox
            cb = e.Row.FindControl("cboEntr")
            txt = e.Row.FindControl("txtObsr")
            cb.Items.Add("No incluir")
            cb.Font.Size = "8"

            If Me.ViewState("ENTREGAS") > 0 Then
                For i As Integer = 1 To Me.ViewState("ENTREGAS")
                    cb.Items.Add(i)
                Next
            End If

            cb.SelectedIndex = Me.gvLista.DataKeys(e.Row.RowIndex).Values(2)
            txt.Text = IIf(Me.gvLista.DataKeys(e.Row.RowIndex).Values(3) Is DBNull.Value, "", Me.gvLista.DataKeys(e.Row.RowIndex).Values(3))

            If Me.ViewState("IDESTADO") >= 4 Then
                cb.Enabled = False
                txt.Enabled = False
            End If

        End If

    End Sub

    Protected Sub btnEntregas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEntregas.Click
        Response.Redirect("~/URMIM/frmDetaMantProgramacionEntrega.aspx?id=" & Me.ViewState("IDPROGRAMACION"), False)
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim arr As New ArrayList

        For Each row As GridViewRow In gvLista.Rows

            Dim eComponente As New ENTREGAPROGRAMACION
            Dim cbo As DropDownList
            Dim txt As TextBox
            cbo = row.FindControl("cboEntr")
            txt = row.FindControl("txtObsr")

            Dim texto As String = IIf(Me.gvLista.DataKeys(row.RowIndex).Values(3) Is DBNull.Value, "", Me.gvLista.DataKeys(row.RowIndex).Values(3))


            If (cbo.SelectedIndex <> Me.gvLista.DataKeys(row.RowIndex).Values(2)) Or _
               (txt.Text.Trim <> texto) Then

                eComponente.IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
                eComponente.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values(1)
                eComponente.IDENTREGA = cbo.SelectedIndex
                eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eComponente.AUFECHAMODIFICACION = Now
                eComponente.OBSERVACION = txt.Text

                arr.Add(eComponente)

            End If

        Next

        If arr.Count > 0 Then

            Dim cComponente As New cPROGRAMACION

            If cComponente.actualizarEntregasProgramacionProducto(Me.ViewState("IDPROGRAMACION"), arr) = -1 Then
                ' Me.MsgBox1.ShowAlert("Error al guardar los registros", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                MessageBox.Alert("Error al guardar los registros", "Error")
                Exit Sub
            End If

        End If

        Call CargarDatos()

    End Sub

    Protected Sub btnConsolidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsolidad.Click

        Dim cComponente As New cPROGRAMACION
        Dim IDPROGRAMACION As Integer = Me.ViewState("IDPROGRAMACION")
        Dim usuario As String = HttpContext.Current.User.Identity.Name

        'Se verifican 2 cosas. 1, que por lo menos un producto se distribuya, y 2, que esten bien definidas las entregas
        Dim entregas As Integer = Me.ViewState("ENTREGAS")
        Dim entregasTotales As Integer = cComponente.obtenerTotalEntregas(Me.ViewState("IDPROGRAMACION"))

        Dim entregas3 As Integer = cComponente.obtenerRenglonesEntrega(Me.ViewState("IDPROGRAMACION"))

        If (entregas <> entregasTotales) Or entregas3 = 0 Then
            ' Me.MsgBox1.ShowAlert("Error al cambiar el estado. Verifique que por lo menos un medicamento sea especificado y que toda la estructura de entregas se encuentre bien definida", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            MessageBox.Alert("Error al cambiar el estado. Verifique que por lo menos un medicamento sea especificado y que toda la estructura de entregas se encuentre bien definida", "Error")
            Exit Sub
        Else

            If cComponente.actualizarEstadoProgramacion(IDPROGRAMACION, 4, usuario) = -1 Then
                ' Me.MsgBox1.ShowAlert("Error al cambiar el estado.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                MessageBox.Alert("Error al cambiar el estado.", "Error")
                Exit Sub
            Else
                ' Me.MsgBox1.ShowAlert("Se ha cambiado exitosamente el estado de la programacion de compras.", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                MessageBox.Alert("Se ha cambiado exitosamente el estado de la programacion de compras.", "Aviso")

                Response.Redirect("frmDetaMantDetalleProgramacionEntrega.aspx?id=" & Me.ViewState("IDPROGRAMACION"))
            End If

        End If

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim alerta As String = CType(("/Reportes/frmRptProgramacionPorProductoDistribucion.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION") & "&idTipo=0"), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim alerta As String = CType(("/Reportes/frmRptProgramacionPorProductoDistribucion.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION") & "&idTipo=1"), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub btnInc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInc.Click
        Response.Redirect("~/URMIM/frmMantProgramacionInconsistencias.aspx?id=" & Me.ViewState("IDPROGRAMACION") & "&tipo=2", False)
    End Sub
    'nuevo reporte consolidado por producto
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim alerta As String = CType(("/Reportes/frmRptProgramacionPorProductoDistribucionConsolidada.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION") & "&idTipo=0"), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub
End Class
