'REPORTES GERENCIALES DEL MODULO ESTABLECIMIENTOS
'CU-ESTA007
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario a utilizar para desplegar las opciones de reportes gerenciales del modulo establecimiento

Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class FrmReportesGerencialesEstablecimientos
    Inherits System.Web.UI.Page

    'INICIALIZAR VARIABLES
    Dim FechaReferencia As Date
    Dim producto As Int32
    Dim zona As Int32
    Dim todosEstablecimientos As String
    Dim todosRegiones As String
    Dim todosProductos As String
    Dim todosProveedores As String
    Dim establecimiento As Int32
    Dim año As Integer
    Dim operador As String
    Dim proveedor As Int32
    Dim establecimientoGenerador As String
    Dim regionGenerador As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EVENTO AL INICIAR PAGINA

        Me.Master.ControlMenu.Visible = False 'oculta menu
        If Not IsPostBack Then
            MostrarOpciones(True) 'muestra opciones de reporte
            Me.UcFiltroReporteEstablecimientos1.Visible = False 'oculta filtro de reportes
        End If
    End Sub
    Private Sub InicializarControlFiltro()
        'INICIALIZA LOS OBJETOS DEL CONTROL DE USUARIO FILTRO
        Me.UcFiltroReporteEstablecimientos1.inicializarControles()
    End Sub

    Private Sub MostrarOpciones(ByVal edicion As Boolean)
        'DESPLEGAR OPCIONES DE REPORTE
        'quitar comentarios una vez conexion con SAFI-----------
        'Me.Lnkopc1.Visible = edicion  'MONITOREO DE EJECUCION PRESUPUESTARIA 
        '-------------------------------------------------------
        Me.Lnkopc2.Visible = edicion    'DISTRIBUCION DE PRODUCTOS POR ESTABLECIMIENTO
        Me.Lnkopc3.Visible = edicion    'REPORTE GERENCIAL DE PRODUCTOS PROXIMOS A VENCERSE
        Me.Lnkopc4.Visible = edicion    'REPORTE DE INVENTARIO GENERAL
        Me.Lnkopc5.Visible = edicion    'REPORTE GERENCIAL DE PRODUCTOS CON MOVIMIENTO LENTO
        Me.Lnkopc6.Visible = edicion     'REPORTE GERENCIAL DE COMPRAS EN TRANSITO
        Me.LnkListado.Visible = Not edicion 'LISTADO DE REPORTES
        Me.BttGenerar.Visible = Not edicion ' BOTON DE GENERACION DE REPORTES
    End Sub

    Private Sub MostrarEstablecimientos()
        'Se muestra por defecto el establecimiento al cual ingreso el usuario, si el establecimiento es una region
        'entonces podra seleccionar cualquier de los hospitales de la region, o ver todos los hospitales

        Me.UcFiltroReporteEstablecimientos1.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
      

        If Session.Item("IdEstablecimiento") = 619 Then ' MSPAS CENTRAl (619)
            ' es el establecimiento MSPAS central
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionRegion(True)
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionEstablecimientos(True)
            Me.lblTipoEstabG.Text = "MSPAS"
        End If

        If Session.Item("idTipoEstablecimiento") = "2" Then  ' sibasi o region (2)
            Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionEstablecimientos(True)
            Me.lblTipoEstabG.Text = "REGION"
        End If

        If Session.Item("IdEstablecimiento") <> 619 And Session.Item("idTipoEstablecimiento") <> "2" Then  ' no es MSPAS(619) Central ni sibasi o region (2)
            If Session.Item("Nivel") = "3" Or Session.Item("Nivel") = "2" Then ' es un hospital
                Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text = False
                Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text = False
                Me.UcFiltroReporteEstablecimientos1.TODOSPROVEEDORES.Text = False
                Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text = False
            Else
                MsgBox1.ShowAlert("Este Reporte es unicamente para el MSPAS central, regiones y hospitales de la region", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.UcFiltroReporteEstablecimientos1.Visible = False
                Me.BttGenerar.Visible = False
                Me.lblTipoEstabG.Text = "HOSPITAL"
            End If
        End If
    End Sub

    Protected Sub Lnkopc1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc1.Click
        'MONITOREO DE EJECUCION PRESUPUESTARIA
        'Para la realizacion de este reporte es necesario la informacion proporcionada por el SAFI

        'quitar comentarios una vez conexion con SAFI
        '--------------------------------------------

        'InicializarControlFiltro()
        'Me.UcFiltroReporteEstablecimientos1.MostrarAñoFiscal(True)
        'Me.UcFiltroReporteEstablecimientos1.Visible = True
        'MostrarOpciones(False)
        'MostrarEstablecimientos()
        'Me.lblTitulo.Text = "Monitoreo de Ejecuci&oacuten presupuestaria"
        'Me.LblReporte.Text = "1" 'opcion de reporte
    End Sub

    Protected Sub Lnkopc2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc2.Click
        'DISTRIBUCION DE PRODUCTOS POR ESTABLECIMIENTO
        InicializarControlFiltro() 'INICIALIZAR Y MOSTRAR FILTRO DE REPORTE
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        Me.UcFiltroReporteEstablecimientos1.MostrarCamposProducto(True)
        MostrarOpciones(False)
        MostrarEstablecimientos()
        Me.lblTitulo.Text = " Distribuci&oacuten de productos por establecimiento"
        Me.LblReporte.Text = "2" 'opcion de reporte
    End Sub

    Protected Sub Lnkopc3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc3.Click
        'REPORTE GERENCIAL DE PRODUCTOS PROXIMOS A VENCERSE
        InicializarControlFiltro() 'INICIALIZAR Y MOSTRAR FILTRO DE REPORTE
        Me.UcFiltroReporteEstablecimientos1.MostrarFechaReferencia(True)
        Me.UcFiltroReporteEstablecimientos1.MostrarOperador(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        MostrarOpciones(False)
        MostrarEstablecimientos()
        Me.lblTitulo.Text = " Reporte de Productos proximos a vencer"
        Me.LblReporte.Text = "3" 'opcion de reporte
    End Sub

    Protected Sub Lnkopc4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc4.Click
        'REPORTE DE INVENTARIO GENERAL
        InicializarControlFiltro() 'INICIALIZAR Y MOSTRAR FILTRO DE REPORTE
        Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionProducto(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        MostrarOpciones(False)
        MostrarEstablecimientos()
        Me.lblTitulo.Text = "Reporte General de inventario"
        Me.LblReporte.Text = "4" 'opcion de reporte
    End Sub

    Protected Sub Lnkopc5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc5.Click
        'REPORTE GERENCIAL DE PRODUCTOS CON MOVIMIENTO LENTO
        InicializarControlFiltro() 'INICIALIZAR Y MOSTRAR FILTRO DE REPORTE
        Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionProducto(True)
        Me.UcFiltroReporteEstablecimientos1.MostrarFechaReferencia(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        MostrarOpciones(False)
        MostrarEstablecimientos()
        Me.lblTitulo.Text = "Reporte de productos con movimiento lento"
        Me.LblReporte.Text = "5" 'opcion de reporte
    End Sub

    Protected Sub Lnkopc6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkopc6.Click
        'REPORTE GERENCIAL DE COMPRAS EN TRANSITO
        MostrarOpciones(False)
        InicializarControlFiltro() 'INICIALIZAR Y MOSTRAR FILTRO DE REPORTE
        Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionProducto(True)
        Me.UcFiltroReporteEstablecimientos1.MostrarSeleccionProveedor(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = True
        MostrarEstablecimientos()
        Me.lblTitulo.Text = "Reporte de compras en transito"
        Me.LblReporte.Text = "6" 'opcion de reporte
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'REDIRECCIONA NUEVAMENTE AL MENU Y ALA PAGINA PRINCIPAL
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub LnkListado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkListado.Click
        'MOSTRAR LISTADO DE REPORTES
        InicializarControlFiltro()
        MostrarOpciones(True)
        Me.UcFiltroReporteEstablecimientos1.Visible = False
    End Sub

    Protected Sub BttGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttGenerar.Click
        'GENERACION DE REPORTE Y ASIGNACION DE VALORES DE VARIABLES DE SESION DE LO REPORTES
        establecimiento = Me.UcFiltroReporteEstablecimientos1.IDESTABLECIMIENTOSELECCIONADO.Text
        establecimientoGenerador = Me.UcFiltroReporteEstablecimientos1.ESTABLECIMIENTOGENERADOR.Text
        regionGenerador = Me.UcFiltroReporteEstablecimientos1.REGIONESTABLECIMIENTOGENERADOR.Text

        '----------------------------------------------
        'Quitar comentarios una vez conexion con safi
        '-------------------------------------------------
        'If Me.LblReporte.Text = "1" Then 'Gerencial Monitoreo de ejecucion presupuestaria
        '    'Para la realizacion de este reporte es necesario la informacion proporcionada por el SAFI

        '    'recuperacion de region
        '    If Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text <> "" Then
        '        zona = Me.UcFiltroReporteEstablecimientos1.IDREGIONSELECCIONADA.Text
        '    End If
        '    If Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text <> "" Then
        '        todosRegiones = Me.UcFiltroReporteEstablecimientos1.TODASREGIONES.Text

        '        If Session.Item("idTipoEstablecimiento") = "2" Then  ' sibasi o region (2)
        '            Session.Item("RptZona") = Session.Item("IdZona")
        '        Else
        '            If todosRegiones = True Then
        '                Session.Item("RptZona") = 0 ' todas las regiones
        '            Else
        '                Session.Item("RptZona") = zona ' una region en especifico
        '            End If
        '        End If
        '    End If
        '    'recuperacion de establecimiento
        '    If Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text <> "" Then
        '        todosEstablecimientos = Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text
        '        If todosEstablecimientos = True Then
        '            Session.Item("RptEstab") = 0 ' todos los establecimientos
        '        Else
        '            Session.Item("RptEstab") = establecimiento ' un establecimiento en especifico
        '        End If
        '    End If
        '    'recuperacion de año de ejercicio
        '    If Me.UcFiltroReporteEstablecimientos1.AÑOSELECCIONADO.Text <> "" Then
        '        año = Me.UcFiltroReporteEstablecimientos1.AÑOSELECCIONADO.Text
        '    End If


        '    Session.Item("RptAño") = año
        '    Session.Item("RptEstabGenerador") = establecimientoGenerador
        '    Session.Item("RptRegionGenerador") = regionGenerador
        '   'LLAMADA A REPORTE
        '    Page.RegisterStartupScript("vistaPrevia", "<script language='jscript'> window.open('Reportes/FrmRptEstMonitoreoEjecucionPresupuestaria.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        'End If
        '---------------------------------------------------------------------------------------

        If Me.LblReporte.Text = "2" Then  ' Gerencial Distribucion de productos por establecimiento
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
                        Session.Item("RptZona") = 0 ' todas las regiones
                    Else
                        Session.Item("RptZona") = zona ' una region en especifico
                    End If
                End If
            End If
            'recuperacion de establecimiento
            If Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text <> "" Then
                todosEstablecimientos = Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text
                If todosEstablecimientos = True Then
                    Session.Item("RptEstab") = 0 'todos los estbalecimientos 
                Else
                    Session.Item("RptEstab") = establecimiento ' un establecimiento en especifico
                End If
            End If
            'recuperacion de producto
            If Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text <> "" Then
                producto = Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text
            End If
            Session.Item("RptProducto") = producto
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador
            'Llamada a reporte
            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptEstDistribucionProductoEstablecimiento.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

        End If
        '------------------------------------------------------------------
        If Me.LblReporte.Text = "3" Then 'Gerencial proximos a vencerse
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
                        Session.Item("RptZona") = 0 'todas las zonas
                    Else
                        Session.Item("RptZona") = zona 'una zona en especifico
                    End If
                End If
            End If
            'recuperacion de establecimiento
            If Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text <> "" Then
                todosEstablecimientos = Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text
                If todosEstablecimientos = True Then
                    Session.Item("RptEstab") = 0 'todos los establecimientos
                Else
                    Session.Item("RptEstab") = establecimiento 'un establecimiento en especificio
                End If
            End If
            'recuperacion de operador

            If Me.UcFiltroReporteEstablecimientos1.OPERADORSELECCIONADO.Text <> "" Then
                operador = Me.UcFiltroReporteEstablecimientos1.OPERADORSELECCIONADO.Text
            End If

            'recuperacion de fecha referencia
            If Me.UcFiltroReporteEstablecimientos1.FECHAREFERENCIASELECCIONADA.Text <> "" Then
                FechaReferencia = Me.UcFiltroReporteEstablecimientos1.FECHAREFERENCIASELECCIONADA.Text
            End If

            Session.Item("RptTipoEstabGenerador") = Me.lblTipoEstabG.Text
            Session.Item("RptOperador") = operador
            Session.Item("RptFechaReferencia") = FechaReferencia
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador
            'llamada de reporte
            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptEstProductosProximoVencerse.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
            '-----------------------------------------------------------------------

        End If
        If Me.LblReporte.Text = "4" Then   'Gerencial de inventario general
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
                        Session.Item("RptZona") = 0 'todas la regiones
                    Else
                        Session.Item("RptZona") = zona 'una region en especifico
                    End If
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

            'recuperacion de producto
            If Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text <> "" Then
                producto = Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text
            End If

            If Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text <> "" Then
                todosProductos = Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text
                If todosProductos = True Then
                    Session.Item("RptProducto") = 0 'todos los productos
                Else
                    Session.Item("RptProducto") = producto 'un producto en especificio
                End If
            End If

            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador

            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptEstInventarioGeneral.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End If

        '---------------------------------------------------------------------------------------------------------
        If Me.LblReporte.Text = "5" Then  ' Gerencial de Productos con movimiento lento
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
                        Session.Item("RptZona") = 0 'todas las zonas o regiones
                    Else
                        Session.Item("RptZona") = zona 'una zona en especifico
                    End If
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

            'recuperacion de producto
            If Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text <> "" Then
                producto = Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text
            End If

            If Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text <> "" Then
                todosProductos = Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text
                If todosProductos = True Then
                    Session.Item("RptProducto") = 0 'todos los productos
                Else
                    Session.Item("RptProducto") = producto 'un producto en especifico
                End If
            End If
            'recuperacion de fecha de referencia
            If Me.UcFiltroReporteEstablecimientos1.FECHAREFERENCIASELECCIONADA.Text <> "" Then
                FechaReferencia = Me.UcFiltroReporteEstablecimientos1.FECHAREFERENCIASELECCIONADA.Text
            End If
            Session.Item("RptTipoEstabGenerador") = Me.lblTipoEstabG.Text
            Session.Item("RptFechaReferencia") = FechaReferencia
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador
            'llamada a reporte
            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptEstProductosMovimientoLento.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

        End If
        '--------------------------------------------------------------------------------------
        If Me.LblReporte.Text = "6" Then  ' Gerencial de compras en transito
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
                        Session.Item("RptZona") = 0 'todas las regiones
                    Else
                        Session.Item("RptZona") = zona  'una region en especifico
                    End If
                End If
            End If
            'recuperacion de establecimiento
            If Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text <> "" Then
                todosEstablecimientos = Me.UcFiltroReporteEstablecimientos1.TODOSESTABLECIMIENTOS.Text
                If todosEstablecimientos = True Then
                    Session.Item("RptEstab") = 0 'todos los establecimientos
                Else
                    Session.Item("RptEstab") = establecimiento  'un establecimiento en especifico
                End If
            End If

            'recuperacion de producto
            If Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text <> "" Then
                producto = Me.UcFiltroReporteEstablecimientos1.IDPRODUCTOSELECCIONADO.Text
            End If

            If Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text <> "" Then
                todosProductos = Me.UcFiltroReporteEstablecimientos1.TODOSPRODUCTOS.Text
                If todosProductos = True Then
                    Session.Item("RptProducto") = 0 'todos los productos
                Else
                    Session.Item("RptProducto") = producto 'un producto en especifico
                End If
            End If
            'recuperacion de proveedor
            If Me.UcFiltroReporteEstablecimientos1.IDPROVEEDORSELECCIONADO.Text <> "" Then
                proveedor = Me.UcFiltroReporteEstablecimientos1.IDPROVEEDORSELECCIONADO.Text
            End If

            If Me.UcFiltroReporteEstablecimientos1.TODOSPROVEEDORES.Text <> "" Then
                todosProveedores = Me.UcFiltroReporteEstablecimientos1.TODOSPROVEEDORES.Text
                If todosProveedores = True Then
                    Session.Item("RptProveedor") = 0 'todos los proveedores
                Else
                    Session.Item("RptProveedor") = proveedor 'un proveedor en especifico
                End If
            End If
            Session.Item("RptTipoEstabGenerador") = Me.lblTipoEstabG.Text
            Session.Item("RptEstabGenerador") = establecimientoGenerador
            Session.Item("RptRegionGenerador") = regionGenerador

            'llamada a reporte
            Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptEstComprasTransito.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

        End If

    End Sub
End Class
