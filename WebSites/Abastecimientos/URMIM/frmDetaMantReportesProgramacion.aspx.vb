Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class URMIM_frmDetaMantReportesProgramacion
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _IDPROGRAMA As Integer

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

    Public Property IDPROGRAMA() As Integer 'identificador de programacion
        Get
            Return Me._IDPROGRAMA
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMA = Value
            If Not Me.ViewState("IDPROGRAMA") Is Nothing Then Me.ViewState.Remove("IDPROGRAMA")
            Me.ViewState.Add("IDPROGRAMA", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        AddHandler ucFiltrarDatos1.filtrar, AddressOf filtro_cargar
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

            'Cargar dropdown de programas
            Dim cComponente2 As New cPROGRAMAS
            Me.cboProgramas.DataSource = cComponente2.ObtenerLista
            Me.cboProgramas.DataBind()

            Me.IDPROGRAMA = 0

            Dim cComponente As New cPROGRAMACION
            Dim eComponente As New PROGRAMACION
            eComponente = cComponente.obtenerProgramacionPorID(lId)

            If eComponente.IDSUMINISTRO <> 1 Then
                Me.lblProgramas.Visible = False
                Me.cboProgramas.Visible = False
            End If

            If eComponente.ESTADO > 2 Then
                Me.btnConsolidad.Enabled = False
                'adicinar boton alternativas Mayra Martínez 16-Agosto-2011
                Me.btnAlternativas.Enabled = False
            End If

            CargarDatos()

        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")
            If Not Me.ViewState("IDPROGRAMA") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMA")
        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACIONPRODUCTO

        ds = mComponente.obtenerProgramacionProductos(Me.ViewState("IDPROGRAMACION"), False, Me.ViewState("IDPROGRAMA"))

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

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cComponente As New cPROGRAMACIONPRODUCTO

        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)

        'Mostrar el reporte
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionPorProducto.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION") & "&idProducto=" & IDPRODUCTO), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)

    End Sub


    Protected Sub btnRpt1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt1.Click

        Call generarReporte(2)

    End Sub

    Private Sub generarReporte(ByVal tipo As Integer)

        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionConsolidado.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION") & "&tipo=" & tipo & "&IdPrograma=" & Me.ViewState("IDPROGRAMA")), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)

    End Sub

    Protected Sub btnRpt2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt2.Click
        'Call 
        generarReporte(3)

    End Sub

    Protected Sub btnRpt3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt3.Click
        Call generarReporte(5)
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionPorProducto.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION") & "&idProducto=" & 0 & "&IdPrograma=" & Me.ViewState("IDPROGRAMA")), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub btnRpt4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt4.Click


        Dim cEntidad As New cPROGRAMACION
        Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(Me.ViewState("IDPROGRAMACION"))


        Dim m As Integer = DateDiff(DateInterval.Month, eEntidad.FECHAPROGRAMACION, eEntidad.FECHAPROYECCION) + 1
        If m < 0 Then m = 0

        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionDesabastecimiento.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION") & "&m=" & m & "&tipo=1&IdPrograma=" & Me.ViewState("IDPROGRAMA")), String)

        SINAB_Utils.Utils.MostrarVentana(alerta)

    End Sub

    Protected Sub btnRpt5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRpt5.Click

        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionDetalle.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION")), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub cboProgramas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProgramas.SelectedIndexChanged

        If Not Me.ViewState("IDPROGRAMA") Is Nothing Then Me.ViewState.Remove("IDPROGRAMA")
        Me.ViewState.Add("IDPROGRAMA", Me.cboProgramas.SelectedItem.Value)

        Call CargarDatos()

    End Sub

    Protected Sub btnConsolidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsolidad.Click


        Dim cComponente As New cPROGRAMACION
        Dim IDPROGRAMACION As Integer = Me.ViewState("IDPROGRAMACION")
        Dim usuario As String = HttpContext.Current.User.Identity.Name

        Dim cantidad As Integer = cComponente.obtenerEstablecimientosAbiertos(IDPROGRAMACION)

        If cantidad <> 0 Then
            Me.MsgBox1.ShowAlert("Error al cambiar el estado. Verifique que todos los establecimientos han finalizado su programación", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else

            If cComponente.actualizarEstadoProgramacion(IDPROGRAMACION, 3, usuario) = -1 Then
                Me.MsgBox1.ShowAlert("Error al cambiar el estado.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub
            Else
                Me.MsgBox1.ShowAlert("Se ha cambiado exitosamente el estado de la programacion de compras.", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.btnConsolidad.Enabled = False
            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionPorProducto.aspx?idProceso=" & Me.ViewState("IDPROGRAMACION") & "&idProducto=" & 0 & "&IdPrograma=" & Me.ViewState("IDPROGRAMA")), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub btnAlternativas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlternativas.Click

        Dim cComponente As New cPROGRAMACION
        Dim IDPROGRAMACION As Integer = Me.ViewState("IDPROGRAMACION")
        Dim usuario As String = HttpContext.Current.User.Identity.Name
        Dim cComponenteAlternativa As New cPROGRAMACIONPRODUCTO
        Dim entidad As New PROGRAMACIONPRODUCTO
        entidad.AUFECHACREACION = Now
        entidad.IDPROGRAMACION = IDPROGRAMACION
        entidad.AUUSUARIOCREACION = usuario

        '  entidad = cComponenteAlternativa.obtenerProgramacionProductos(IDPROGRAMACION)
        Dim cantidad As Integer = cComponente.obtenerEstablecimientosAbiertos(IDPROGRAMACION)

        If cantidad <> 0 Then
            Me.MsgBox1.ShowAlert("Error al adicionar alternativas. Verifique que todos los establecimientos han finalizado su programación", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Try
                Dim NumReg As Integer
                NumReg = cComponenteAlternativa.agregarProgramacionProductoAlternativa(entidad)
                If Not NumReg = 0 Then
                    Me.MsgBox1.ShowAlert("Se han adicionado exitosamente las Alternativas. Estamos listos para consolidar", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Me.btnConsolidad.Enabled = True
                    Me.btnAlternativas.Enabled = False
                Else
                    Me.MsgBox1.ShowAlert("Sin registros encontrados, para ingresar ", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                End If

            Catch ex As Exception
                Me.MsgBox1.ShowAlert("Error al insertar las alternativas", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

            End Try
           

        End If


    End Sub
End Class
