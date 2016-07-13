'REPORTES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA006
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario a utilizar para desplegar las opciones de reportes del modulo establecimiento

Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class FrmReportesModuloEstablecimientos
    Inherits System.Web.UI.Page
    'INICIALIZAR VARIABLES
    Dim FechaInicioPeriodo As Date
    Dim FechaFinPeriodo As Date
    Dim producto As Int32
    Dim servicio As Int32
    Dim establecimiento As Int32
    Dim todosEstablecimientos As String
    Dim todosRegiones As String
    Dim todosProductos As String
    Dim todoProveedores As String
    Dim establecimientoGenerador As String
    Dim regionGenerador As String
    Dim zona As Int32

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EVENTO INICIALIZAR PAGINA

        Me.Master.ControlMenu.Visible = False 'Oculta menu
        If Not IsPostBack Then ' la primera vez que carga la pagina
            MostrarOpciones(True) 'muestra opciones de reporte
            Me.UcFiltroReporteEstablecimientos1.Visible = False 'oculta el control de filtro
        End If
    End Sub

    Private Sub InicializarControlFiltro()
        'INICIALIZA LOS OBJETOS DEL CONTROL DE USUARIO FILTRO
        Me.UcFiltroReporteEstablecimientos1.inicializarControles()
    End Sub

    Private Sub MostrarOpciones(ByVal edicion As Boolean)
        'DESPLEGAR OPCIONES DE REPORTE
        Me.Lnkopc1.Visible = edicion     'REPORTE DE MEDICAMENTOS POR SERVICIO HOSPITALARIO Y POR MEDICO
        Me.Lnkopc2.Visible = edicion     'REPORTE DE PRODUCTOS CONSUMIDOS POR SERVICIOS HOSPITALARIOS

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

        If Session.Item("IdEstablecimiento") <> 619 And Session.Item("idTipoEstablecimiento") <> "2" Then ' no es MSPAS CENTRAl (619) ni sibasi o region (2)
            If Session.Item("Nivel") = "3" Or Session.Item("Nivel") = "2" Then ' es un hospital
                Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text = False
                Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text = False
            Else
                MsgBox1.ShowAlert("Este Reporte es unicamente para el MSPAS central, regiones y hospitales de la region", "errorA", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        End If

    End Sub

    Protected Sub Lnkopc1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc1.Click
        'REPORTE DE MEDICAMENTOS POR SERVICIO HOSPITALARIO Y POR MEDICO

        InicializarControlFiltro() 'inicializar filtro de reportes 
        MostrarEstablecimientos()
        Me.UcFiltroReporteEstablecimientos1.MostrarCamposProducto(True)
        Me.UcFiltroReporteEstablecimientos1.MostrarRangoFechas(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        MostrarOpciones(False)
        Me.lblTitulo.Text = "Reporte de medicamentos por servicios hospitalarios y por medico"
        Me.LblReporte.Text = "1" 'opcion de reporte
    End Sub

    Protected Sub Lnkopc2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc2.Click
        'REPORTE DE PRODUCTOS CONSUMIDOS POR SERVICIOS HOSPITALARIOS

        InicializarControlFiltro()
        MostrarEstablecimientos()
        Me.UcFiltroReporteEstablecimientos1.MostrarServicioHospitalario(True)
        Me.UcFiltroReporteEstablecimientos1.MostrarRangoFechas(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        MostrarOpciones(False)
        Me.lblTitulo.Text = " Reporte de productos consumidos por servicios hospitalario"
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
        'GENERACION DE REPORTE Y ASIGNACION DE VALORES A LAS VARIABLES DE SESION DEL REPORTE

        FechaInicioPeriodo = Me.UcFiltroReporteEstablecimientos1.FECHAINICIALRANGOSELECCIONADA.Text
        FechaFinPeriodo = Me.UcFiltroReporteEstablecimientos1.FECHAFINALRANGOSELECCIONADA.Text
        establecimiento = Me.UcFiltroReporteEstablecimientos1.IDESTABLECIMIENTOSELECCIONADO.Text
        establecimientoGenerador = Me.UcFiltroReporteEstablecimientos1.ESTABLECIMIENTOGENERADOR.Text
        regionGenerador = Me.UcFiltroReporteEstablecimientos1.REGIONESTABLECIMIENTOGENERADOR.Text

        '----------------------------------------------------------------------
        If Me.LblReporte.Text = "1" Then 'Medicamentos por servicio hospitalario
            'recuperacion de region
            If Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text <> "" Then
                zona = Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text
            End If
            If Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text <> "" Then
                todosRegiones = Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text
                If Session.Item("idTipoEstablecimiento") = "2" Then  ' sibasi o region (2)
                    Session.Item("RptZona") = Session.Item("IdZona")
                Else
                    If todosRegiones = True Then
                        Session.Item("RptZona") = 0 'Todas las zonas y regiones
                    Else
                        Session.Item("RptZona") = zona ' una zona en especifico
                    End If
                End If
            End If

            'recuperacion de establecimiento

            If Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text <> "" Then
                todosEstablecimientos = Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text
                If todosEstablecimientos = True Then
                    Session.Item("RptEstab") = 0 ' todos los establecimientos
                Else
                    Session.Item("RptEstab") = establecimiento ' un establecimiento en esecifico
                End If
            End If

            'recuperacion de producto
            If Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text <> "" Then
                producto = Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text
            End If

            If Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text <> "" Then
                todosProductos = Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text
                If todosProductos = True Then
                    Session.Item("RptProducto") = 0 ' todos los productos 
                Else
                    Session.Item("RptProducto") = producto ' un producto en especifico
                End If
            End If

            Session.Item("RptFechaInicio") = FechaInicioPeriodo
            Session.Item("RptFechaFin") = FechaFinPeriodo
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador


            'llamada al reporte
            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptMedicamentosSHospMedico.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End If

        '------------------------------------------------------------------------------
        If Me.LblReporte.Text = "2" Then 'Productos consumidos por servicio hospitalario
            'recuperacion de region
            If Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text <> "" Then
                zona = Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text
            End If
            If Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text <> "" Then
                todosRegiones = Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text
                If todosRegiones = True Then
                    Session.Item("RptZona") = 0 'todas las zonas
                Else
                    Session.Item("RptZona") = zona 'zona especifica
                End If
            End If

            'recuperacion de establecimiento

            If Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text <> "" Then
                todosEstablecimientos = Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text
                If todosEstablecimientos = True Then
                    Session.Item("RptEstab") = 0 'todos los establecimientos
                Else
                    Session.Item("RptEstab") = establecimiento 'establecimiento en especifico
                End If
            End If

            If Me.UcFiltroReporteEstablecimientos1.IDSERVICIOSELECCIONADO.Text <> "" Then
                servicio = Me.UcFiltroReporteEstablecimientos1.IDSERVICIOSELECCIONADO.Text
            End If

            Session.Item("RptServicio") = servicio
            Session.Item("RptFechaInicio") = FechaInicioPeriodo
            Session.Item("RptFechaFin") = FechaFinPeriodo
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador

            'llamada al reporte
            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptProductosConsumidosSHosp.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/ESTABLECIMIENTOS/FrmExistenciaFarmacia.aspx")
    End Sub
End Class
