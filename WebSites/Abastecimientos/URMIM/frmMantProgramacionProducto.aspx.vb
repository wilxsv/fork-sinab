Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES


Partial Class URMIM_frmMantProgramacionProducto
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _M As Integer
    Private _N As Integer
    Private _CPM As Integer

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

    Public Property M() As Integer
        Get
            Return Me._M
        End Get
        Set(ByVal Value As Integer)
            Me._M = Value
            If Not Me.ViewState("M") Is Nothing Then Me.ViewState.Remove("M")
            Me.ViewState.Add("M", Value)
        End Set
    End Property

    Public Property N() As Integer
        Get
            Return Me._N
        End Get
        Set(ByVal Value As Integer)
            Me._N = Value
            If Not Me.ViewState("N") Is Nothing Then Me.ViewState.Remove("N")
            Me.ViewState.Add("N", Value)
        End Set
    End Property

    Public Property CPM() As Integer
        Get
            Return Me._CPM
        End Get
        Set(ByVal Value As Integer)
            Me._CPM = Value
            If Not Me.ViewState("CPM") Is Nothing Then Me.ViewState.Remove("CPM")
            Me.ViewState.Add("CPM", Value)
        End Set
    End Property

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
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = True
            Me.ucBarraNavegacion1.PermitirCancelar = True


            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            IDPROGRAMACION = lId

            Dim cEntidad As New cPROGRAMACION
            Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(lId)

            Dim m1 As Integer = DateDiff(DateInterval.Month, eEntidad.FECHAPROGRAMACION, eEntidad.FECHAPROYECCION) + 1
            If m1 < 0 Then m1 = 0

            CPM = eEntidad.MESESCPM
            M = m1
            N = eEntidad.MESESPLANEACION

            'CargarDatos()

            Dim bEntidad As New cESTABLECIMIENTOS

            Me.cboEstablecimientos.DataTextField = "nombre"
            Me.cboEstablecimientos.DataValueField = "idEstablecimiento"
            Me.cboEstablecimientos.Items.Add("[Seleccione un establecimiento]")
            Me.cboEstablecimientos.DataSource = bEntidad.obtenerEstablecimientosProgramacion(lId)
            Me.cboEstablecimientos.DataBind()





        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
            If Not Me.ViewState("M") Is Nothing Then Me._M = Me.ViewState("M")
            If Not Me.ViewState("N") Is Nothing Then Me._N = Me.ViewState("N")

        End If

    End Sub

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

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACIONPRODUCTO
        Dim mComponente2 As New cPROGRAMACION
        Dim eEntidad As New PROGRAMACION

        eEntidad = mComponente2.obtenerProgramacionPorID(Me.IDPROGRAMACION)

        ds = mComponente.obtenerProgramacionProductosDetalle(Me.IDPROGRAMACION, Me.cboEstablecimientos.SelectedItem.Value, M, N, 0, False)
        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If Not Me.ViewState("columnaFiltro") Is Nothing Then

            Dim columnaFiltro As String = CType(Me.ViewState("columnaFiltro"), String)
            Dim valorFiltro As String = CType(Me.ViewState("valorFiltro"), String)

            dsVista.RowFilter = columnaFiltro & " LIKE '%" & valorFiltro & "%'"

        End If

        Me.gvLista.DataSource = dsVista

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        mostrarFiltro()

        Dim total As Decimal

        If ds.Tables(0).Rows.Count = 0 Then
            total = 0
        Else
            total = ds.Tables(0).Compute("SUM(MONTOTOTAL)", "")
        End If

        Me.lblMT.Text = Math.Round(total, 2)

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Me.gvLista.PageIndex = e.NewPageIndex
        Call CargarDatos()
    End Sub

    Protected Sub btnRpt1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt1.Click
        SINAB_Utils.MessageBox.Alert("alerta")
        generarReporte(1)

    End Sub

    Protected Sub btnRpt2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt2.Click

        generarReporte(2)

    End Sub

    Protected Sub btnRpt3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt3.Click

        generarReporte(3)

    End Sub

    Protected Sub btnRpt4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt4.Click

        Dim alerta As String = "/Reportes/frmRptProgramacion2.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Me.cboEstablecimientos.SelectedItem.Value & "&m=" & M
        SINAB_Utils.Utils.MostrarVentana(alerta)

        'alerta = "<script language='JavaScript'>" & _
        '         "window.open('" & Request.ApplicationPath & "/Reportes/frmRptProgramacion2.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Me.cboEstablecimientos.SelectedItem.Value & "&m=" & M & "', 'Programacion1', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _
        '         "</script>"

        'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)

    End Sub

    Private Sub generarReporte(ByVal tipo As Integer)
        Dim cadena As String = "/Reportes/frmRptProgramacion.aspx?idProceso=" & IDPROGRAMACION & "&idEstablecimiento=" & Me.cboEstablecimientos.SelectedItem.Value & "&m=" & M & "&n=" & N & "&tipo=" & tipo
        SINAB_Utils.Utils.MostrarVentana(cadena)

    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.cboEstablecimientos.SelectedIndex > 0 Then

            Dim cEntidad As New cPROGRAMACION

            Me.lblEstadoPC.Text = cEntidad.obtenerEstadoProgramacionEstablecimiento(Me.ViewState("IDPROGRAMACION"), Me.cboEstablecimientos.SelectedItem.Value)

            If Me.lblEstadoPC.Text <> "1" Then
                Me.lblTextoPC.Text = "* No se pueden hacer observaciones a la programación por el estado en que se encuentra."
            Else
                Me.lblTextoPC.Text = ""
            End If

            Call CargarDatos()
            Me.btnAceptar.Enabled = False
            Me.btnCancelar.Enabled = True
            Me.pnlRpts.Visible = True
            Me.pnlMT.Visible = True
            Me.pnlGrid.Visible = True
            Me.cboEstablecimientos.Enabled = False
            Me.ucFiltrarDatos1.Visible = True
            mostrarFiltro()
        End If

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.btnAceptar.Enabled = True
        Me.btnCancelar.Enabled = False
        Me.cboEstablecimientos.SelectedIndex = 0
        Me.gvLista.DataSource = Nothing
        Me.gvLista.DataBind()
        Me.pnlGrid.Visible = False
        Me.pnlRpts.Visible = False
        Me.pnlMT.Visible = False
        Me.cboEstablecimientos.Enabled = True
        Me.ucFiltrarDatos1.Visible = False
        Me.lblTextoPC.Text = ""

        ViewState.Remove("valorFiltro")
        ViewState.Remove("columnaFiltro")
        ViewState.Remove("posicionFiltro")
        Me.ucFiltrarDatos1.borrar()

    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim btnDetails As ImageButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Me.lblIdPrograma.Text = Me.gvLista.DataKeys(row.RowIndex).Values(0)
        Me.lblIdProducto.Text = Me.gvLista.DataKeys(row.RowIndex).Values(1)
        Me.lblIdEst.Text = Me.gvLista.DataKeys(row.RowIndex).Values(2)

        Me.txtObservacion.Text = ""

        'Datos del producto
        Dim bEntidad1 As New cCATALOGOPRODUCTOS
        Dim eEntidad As CATALOGOPRODUCTOS = bEntidad1.devolverEntidadVista(Me.lblIdProducto.Text)

        Me.lblCodProd.Text = eEntidad.CODIGO
        Me.lblUM.Text = eEntidad.CONCENTRACION
        Me.lblNomProd.Text = eEntidad.NOMBRE

        'Datos del establecimiento
        Dim bEntidad2 As New cESTABLECIMIENTOS
        Me.lblNomEst.Text = bEntidad2.ObtenerNomEstablecimiento(Me.lblIdEst.Text)


        Me.updPnlCustomerDetail.Update()
        Me.mdlPopup.Show()

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.lblError.Text = ""
        If Me.txtObservacion.Text.Trim = "" Then
            Me.lblError.Text = "Debe especificar una observación"
            Exit Sub
        End If

        Dim eEntidad As New PROGRAMACIONPRODUCTO
        Dim cEntidad As New cPROGRAMACION

        eEntidad.IDPROGRAMACION = Me.lblIdPrograma.Text
        eEntidad.IDPRODUCTO = Me.lblIdProducto.Text
        eEntidad.IDESTABLECIMIENTO = Me.lblIdEst.Text
        eEntidad.TIPOOBSERVACION = 1
        eEntidad.OBSERVACION = Me.txtObservacion.Text.Trim
        eEntidad.AUUSUARIOCREACION = Session.Item("NombreUsuario")
        eEntidad.AUFECHACREACION = Now

        If cEntidad.agregarObservacion(eEntidad) = -1 Then
            Me.lblError.Text = "Error al agregar la observación"
            Exit Sub
        End If


        Me.lblError.Text = ""
        Me.mdlPopup.Hide()
        Call CargarDatos()
        Me.updatePanel.Update()

    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.mdlPopup.Hide()

    End Sub


    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim t As ImageButton = e.Row.FindControl("btnCom")

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(3) > 0 Then
                t.Visible = True
            End If

            t = e.Row.FindControl("BtnViewDetails")
            If Me.lblEstadoPC.Text <> "1" Then
                t.Enabled = False
            End If

        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)
        Dim IDESTABLECIMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(2)

        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptProgramacionObservacion.aspx?idProceso=" & IDPROGRAMACION & "&idProducto=" & IDPRODUCTO & "&idEstablecimiento=" & IDESTABLECIMIENTO & "&tipo=1"
        SINAB_Utils.Utils.MostrarVentana(alerta)

        'alerta = "<script language='JavaScript'>" & _
        '         "window.open('" & Request.ApplicationPath & "/Reportes/frmRptProgramacionObservacion.aspx?idProceso=" & IDPROGRAMACION & "&idProducto=" & IDPRODUCTO & "&idEstablecimiento=" & IDESTABLECIMIENTO & "&tipo=1', 'ProgramacionPr2', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=750, height=500');" & _
        '         "</script>"


        'ScriptManager.RegisterStartupScript(Page, Page.GetType, "Startup", alerta, False)
    End Sub

    Protected Sub btnRpt5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt5.Click

        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.ViewState("IDPROGRAMACION")
        Dim IDPRODUCTO As Integer = 0
        Dim IDESTABLECIMIENTO As Integer = Me.cboEstablecimientos.SelectedItem.Value

        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptProgramacionObservacion.aspx?idProceso=" & IDPROGRAMACION & "&idProducto=" & IDPRODUCTO & "&idEstablecimiento=" & IDESTABLECIMIENTO & "&tipo=1"
        SINAB_Utils.Utils.MostrarVentana(alerta)

        'alerta = "<script language='JavaScript'>" & _
        '         "window.open('" & Request.ApplicationPath & "/Reportes/frmRptProgramacionObservacion.aspx?idProceso=" & IDPROGRAMACION & "&idProducto=" & IDPRODUCTO & "&idEstablecimiento=" & IDESTABLECIMIENTO & "&tipo=1', 'ProgramacionPr2', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=750, height=500');" & _
        '         "</script>"


        'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)

    End Sub
End Class
