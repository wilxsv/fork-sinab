'CONSULTAR PROGRAMAS DE EJECUCUION PRESUPUESTARIA
'CU-UFI002
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario a utilizar para CONSULTAR LA PROGRAMACION DE LA EJECUCION PRESUPUESTARIA (PEP)
'------------------------------------------------------------------------------------
'Este formulario hace uso de la conexion con el SAFI para su funcionamiento
'------------------------------------------------------------------------------------

Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class FrmUFIConsultarPEP
    Inherits System.Web.UI.Page

    'inicializar variables
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
        If Not IsPostBack Then ' La primera vez que carga la pagina

            Me.UcFiltroReporteEstablecimientos1.Visible = False 'oclta control de filtro

            Me.DdlESTABLECIMIENTOS1.Recuperar()
            Me.DdlESTABLECIMIENTOS1.SelectedValue = Session.Item("IdEstablecimiento")

            'REPORTE DE CONSULTA PEP

            InicializarControlFiltro()
            MostrarEstablecimientos()
            Me.UcFiltroReporteEstablecimientos1.MostrarAñoFiscal(True)
            Me.UcFiltroReporteEstablecimientos1.Visible = True
            Me.BttGenerar.Visible = True
            Me.LblReporte.Text = "1" 'reporte consulta pep
        End If
    End Sub

    Private Sub InicializarControlFiltro()
        'INICIALIZA LOS OBJETOS DEL CONTROL DE USUARIO FILTRO
        Me.UcFiltroReporteEstablecimientos1.inicializarControles()
    End Sub

    Private Sub MostrarEstablecimientos()
        'Se muestra por defecto el establecimiento al cual ingreso el usuario, si el establecimiento es una region
        'entonces podra seleccionar cualquier de los hospitales de la region, o ver todos los hospitales

        Me.UcFiltroReporteEstablecimientos1.IDESTABLECIMIENTO = Me.DdlESTABLECIMIENTOS1.SelectedValue

        If Me.DdlESTABLECIMIENTOS1.SelectedValue = 619 Then ' MSPAS CENTRAl (619)
            ' es el establecimiento MSPAS central
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionRegion(True)
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionEstablecimientos(True)
        End If

        If Session.Item("idTipoEstablecimiento") = "2" Then  ' sibasi o region (2)
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionEstablecimientos(True)
        End If
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'REDIRECCIONA NUEVAMENTE AL MENU Y PAGINA PRINCIPAL
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub BttGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttGenerar.Click
        'GENERACION DE REPORTE Y ASIGNACION DE VALORES A LAS VARIABLES DE SESION DE LOS REPORTES

        establecimiento = Me.UcFiltroReporteEstablecimientos1.IDESTABLECIMIENTOSELECCIONADO.Text
        establecimientoGenerador = Me.UcFiltroReporteEstablecimientos1.ESTABLECIMIENTOGENERADOR.Text
        regionGenerador = Me.UcFiltroReporteEstablecimientos1.REGIONESTABLECIMIENTOGENERADOR.Text

        '----------------------------------------------------------------------
        If Me.LblReporte.Text = "1" Then 'Reporte de consulta PEP
            'recuperacion de region
            If Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text <> "" Then
                zona = Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text
            End If
            If Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text <> "" Then
                todosRegiones = Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text
                If todosRegiones = True Then
                    Session.Item("RptZona") = 0 'todas las zonas o reguiones
                Else
                    Session.Item("RptZona") = zona 'una zona o region especifica
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

            'recuperacion de año de ejercicio
            If Me.UcFiltroReporteEstablecimientos1.AÑOSELECCIONADO.Text <> "" Then
                año = Me.UcFiltroReporteEstablecimientos1.AÑOSELECCIONADO.Text
            End If

            Session.Item("RptAño") = año
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador

            'llamda a reporte

            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptUfiConsultaPEP.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

        End If
        '------------------------------------------------------------------------------
    End Sub
End Class
