'REPORTES DEL MODULO UFI
'CU-UFI003
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario que muestra los reportes que se han considerado para el modulo de la UFI
'--------------------------------------------------------------------------
'Este formulario hace uso de la conexion con el SAFI para su funcionamiento
'-------------------------------------------------------------------------
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class FrmReportesModuloUFI
    Inherits System.Web.UI.Page
    Dim FechaInicioPeriodo As Date
    Dim FechaFinPeriodo As Date
    Dim FechaReferencia As Date
    Dim producto As Int32
    Dim establecimiento As Int32
    Dim todosEstablecimientos As String
    Dim todosRegiones As String
    Dim todosProductos As String
    Dim todosProveedores As String
    Dim proveedor As Int32
    Dim establecimientoGenerador As String
    Dim regionGenerador As String
    Dim año As Integer
    Dim zona As Int32
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EVENTO INICIALIZAR PAGINA

        Me.Master.ControlMenu.Visible = False 'Oculta menu
        If Not IsPostBack Then 'la primera vez que carga la pagina
            MostrarOpciones(True) 'muestra opciones
            Me.UcFiltroReporteEstablecimientos1.Visible = False 'oculta filtro

        End If
    End Sub

    Private Sub InicializarControlFiltro()
        'INICIALIZA LOS OBJETOS DEL CONTROL DE USUARIO FILTRO
        Me.UcFiltroReporteEstablecimientos1.inicializarControles()
    End Sub

    Private Sub MostrarOpciones(ByVal edicion As Boolean)
        'DESPLEGAR OPCIONES DE REPORTE
        Me.Lnkopc1.Visible = edicion    'REPORTE DE DISTRIBUCION PRESUPUESTARIA POR RUBRO
        Me.Lnkopc2.Visible = edicion    'REPORTE DE SITUACION DE COMPROMISOS EN PROCESO

        Me.LnkListado.Visible = Not edicion
        Me.BttGenerar.Visible = Not edicion
    End Sub

    Private Sub MostrarEstablecimientos()
        'Se muestra por defecto el establecimiento al cual ingreso el usuario, si el establecimiento es una region
        'entonces podra seleccionar cualquier de los hospitales de la region, o ver todos los hospitales

        Me.UcFiltroReporteEstablecimientos1.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

        If Session.Item("IdEstablecimiento") = 619 Then ' MSPAS CENTRAl (619)
            ' es el establecimiento MSPAS central
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionRegion(True)
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionEstablecimientos(True)
        End If

        If Session.Item("idTipoEstablecimiento") = "2" Then  ' sibasi o region (2)
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionEstablecimientos(True)
        End If
    End Sub

    Protected Sub Lnkopc1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc1.Click
        'REPORTE DE DISTRIBUCION PRESUPUESTARIA POR RUBRO

        InicializarControlFiltro() 'inicializa control de usuario filtro y desplega opciones a utilizar
        MostrarEstablecimientos()
        Me.UcFiltroReporteEstablecimientos1.MostrarAñoFiscal(True)
        Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionProveedor(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        MostrarOpciones(False)
        Me.lblTitulo.Text = "Reporte de distribucion presupuestaria por rubro"
        Me.LblReporte.Text = "1" 'opcion de reporte
    End Sub

    Protected Sub Lnkopc2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc2.Click
        'REPORTE DE SITUACION DE COMPROMISOS EN PROCESO

        InicializarControlFiltro() 'inicializa control de usuario filtro y desplega opciones a utilizar
        MostrarEstablecimientos()
        Me.UcFiltroReporteEstablecimientos1.MostrarFechaReferencia(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        MostrarOpciones(False)
        Me.lblTitulo.Text = " Reporte de situacion de compromiso en proceso"
        Me.LblReporte.Text = "2" 'opcion de reporte
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'REDIRECCIONA NUEVAMENTE AL MENU Y PAGINA PRINCIPAL
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub LnkListado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkListado.Click
        'MOSTRAR LISTADO DE REPORTES
        InicializarControlFiltro()
        MostrarOpciones(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = False
    End Sub

    Protected Sub BttGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttGenerar.Click
        'GENERACION DE REPORTE Y ASIGNACION DE VALORES A LAS VARIABLES DE SESION DE LOS REPORTES

        'establecimiento del establecimiento generador del reporte

        establecimiento = Me.UcFiltroReporteEstablecimientos1.IDESTABLECIMIENTOSELECCIONADO.Text
        establecimientoGenerador = Me.UcFiltroReporteEstablecimientos1.ESTABLECIMIENTOGENERADOR.Text
        regionGenerador = Me.UcFiltroReporteEstablecimientos1.REGIONESTABLECIMIENTOGENERADOR.Text

        '----------------------------------------------------------------------
        If Me.LblReporte.Text = "1" Then 'Reporte de distribucion presupuestaria por rubro
            'recuperacion de region
            If Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text <> "" Then
                zona = Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text
            End If
            If Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text <> "" Then
                todosRegiones = Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text
                If todosRegiones = True Then
                    Session.Item("RptZona") = 0 'todas las zona
                Else
                    Session.Item("RptZona") = zona ' una zona especifica
                End If
            End If

            'recuperacion de establecimiento

            If Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text <> "" Then
                todosEstablecimientos = Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text
                If todosEstablecimientos = True Then
                    Session.Item("RptEstab") = 0 'todos los establecimientos
                Else
                    Session.Item("RptEstab") = establecimiento ' un establecimiento en especifico
                End If
            End If

            'recuperacion de proveedor
            If Me.UcFiltroReporteEstablecimientos1.IDPROVEEDORSELECCIONADO.Text <> "" Then
                proveedor = Me.UcFiltroReporteEstablecimientos1.IDPROVEEDORSELECCIONADO.Text
                If todosProveedores = True Then
                    Session.Item("RptProveedor") = 0 'todos los proveedores
                Else
                    Session.Item("RptProveedor") = proveedor 'un proveedor en especifico
                End If
            End If

            'recuperacion de año de ejercicio
            If Me.UcFiltroReporteEstablecimientos1.AÑOSELECCIONADO.Text <> "" Then
                año = Me.UcFiltroReporteEstablecimientos1.AÑOSELECCIONADO.Text
            End If

            Session.Item("RptAño") = año
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador

            'llamada a reporte
            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptUfiDistribucionPresupuestaria.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End If

        '------------------------------------------------------------------------------
        If Me.LblReporte.Text = "2" Then 'Reporte de situacion de compromiso en proceso
            'recuperacion de region
            If Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text <> "" Then
                zona = Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text
            End If
            If Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text <> "" Then
                todosRegiones = Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text
                If todosRegiones = True Then
                    Session.Item("RptZona") = 0 'todas laas zonas
                Else
                    Session.Item("RptZona") = zona 'una zona en especifico
                End If
            End If

            'recuperacion de establecimiento

            If Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text <> "" Then
                todosEstablecimientos = Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text
                If todosEstablecimientos = True Then
                    Session.Item("RptEstab") = 0 'todos los establecimientos
                Else
                    Session.Item("RptEstab") = establecimiento 'un establecimiento en especifico
                End If
            End If

            'recuperacion de fecha de referencia
            If Me.UcFiltroReporteEstablecimientos1.FECHAREFERENCIASELECCIONADA.Text <> "" Then
                FechaReferencia = Me.UcFiltroReporteEstablecimientos1.FECHAREFERENCIASELECCIONADA.Text
            End If


            Session.Item("RptFechaReferencia") = FechaReferencia
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador

            'inicializa control de usuario filtro y desplega opciones a utilizar
            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptUfiSituacionCompromiso.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End If

    End Sub
End Class
