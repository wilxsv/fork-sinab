'CONTROL DE USUARIO PARA FILTROS DE REPORTES DEL MODULO DE ESTABLECIMIENTO Y UFI
'UTILIZADO EN CU-ESTA006,CU-ESTA007, CU-UFI003, CU-UFI002
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario a utilizar para desplegar los parametros a ingresar para los reportes del modulo establecimiento y UFI
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Data

Partial Class Controles_ucFiltroReporteEstablecimientos
    Inherits System.Web.UI.UserControl

    'INICIALIZACION DE VARIABLES

    Private _IDESTABLECIMIENTO As Int64

    Private mCompProductos As New cCATALOGOPRODUCTOS
    Private mEntProductos As New CATALOGOPRODUCTOS
    Private mEntSuministros As New SUMINISTROS
    Private mCompSuministros As New cSUMINISTROS


    Dim hoy As Date = Now.Date

    'INICIALIZACION DE PROPIEDADES
    Public Property IDESTABLECIMIENTO() As Int64
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int64)
            Me._IDESTABLECIMIENTO = Value
            Me.lblidestablecimiento.Text = Me._IDESTABLECIMIENTO
            Me.DdlestablecimientosInicial.Recuperar()
            Me.DdlestablecimientosInicial.SelectedValue = Me.lblidestablecimiento.Text
            Me.LblEstablecimiento.Text = Me.DdlestablecimientosInicial.SelectedItem.Text
            Me.lblidestabseleccionado.Text = Me.DdlestablecimientosInicial.SelectedValue
        End Set
    End Property

    Public Sub ObtenerSuministro(ByVal SUMINISTRO As Int32)
        Me.lblSuministro.Text = SUMINISTRO
        mEntSuministros.IDSUMINISTRO = SUMINISTRO
        mCompSuministros.ObtenerSUMINISTROS(mEntSuministros)
        Me.lblTipoSuministro.Text = mEntSuministros.IDTIPOSUMINISTRO
    End Sub
    Public ReadOnly Property REGIONESTABLECIMIENTOGENERADOR() As Label
        Get
            Return Me.LblZona
        End Get
    End Property
    Public ReadOnly Property ESTABLECIMIENTOGENERADOR() As Label
        Get
            Return Me.LblEstablecimiento
        End Get
    End Property
    Public ReadOnly Property FECHAINICIALRANGOSELECCIONADA() As Label
        Get
            Return Me.FechaIniSelecionada
        End Get
    End Property
    Public ReadOnly Property FECHAFINALRANGOSELECCIONADA() As Label
        Get
            Return Me.fechaFinSelecionada
        End Get
    End Property
    Public ReadOnly Property FECHAREFERENCIASELECCIONADA() As Label
        Get
            Return Me.FechaRefSeleccionada
        End Get
    End Property
    Public ReadOnly Property IDSERVICIOSELECCIONADO() As Label
        Get
            Return Me.servcioseleccionado
        End Get
    End Property
    Public ReadOnly Property IDESTABLECIMIENTOSELECCIONADO() As Label
        Get
            Return Me.lblidestabseleccionado
        End Get
    End Property
    Public ReadOnly Property IDREGIONSELECCIONADA() As Label
        Get
            Return Me.RegionSeleccionada
        End Get
    End Property
    Public ReadOnly Property AÑOSELECCIONADO() As Label
        Get
            Return Me.año
        End Get
    End Property
    Public ReadOnly Property IDPRODUCTOSELECCIONADO() As Label
        Get
            Return Me.ProductoSeleccionado
        End Get
    End Property
    Public ReadOnly Property OPERADORSELECCIONADO() As Label
        Get
            Return Me.OperSeleccionado
        End Get
    End Property
    Public ReadOnly Property IDPROVEEDORSELECCIONADO() As Label
        Get
            Return Me.ProveedorSeleccionado
        End Get
    End Property

    Public ReadOnly Property TODOSPRODUCTOS() As Label
        Get
            Return Me.TodosLosProductos
        End Get
    End Property
    Public ReadOnly Property TODOSPROVEEDORES() As Label
        Get
            Return Me.TodosLosProveedores
        End Get
    End Property
    Public ReadOnly Property TODASREGIONES() As Label
        Get
            Return Me.TodasLasRegiones
        End Get
    End Property
    Public ReadOnly Property TODOSESTABLECIMIENTOS() As Label
        Get
            Return Me.TodosLosEstablecimientos
        End Get
    End Property
    Public Sub inicializarControles()

        'FUNCIONES PARA INICALIZAR TODOS LOS CONTRLES DE PARAMETROS
        MostrarRegion(False)
        MostrarEstablecimiento(False)
        MostrarAñoFiscal(False)
        MostrarSeleccionProducto(False)
        MostrarFechaReferencia(False)
        MostrarOperador(False)
        MostrarSeleccionProveedor(False)
        MostrarCamposProveedor(False)
        MostrarCamposProducto(False)
        MostrarCamposFiltroProducto(False)
        MostrarServicioHospitalario(False)
        MostrarRangoFechas(False)
        MostrarCamposFiltroProveedor(False)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'EVENTO AL CARGAR PAGINA
        If Not IsPostBack Then
            inicializarControles()
            Me.DdlZONAS1.Recuperar()
            Me.RegionSeleccionada.Text = Me.DdlZONAS1.SelectedValue
            Me.LblZona.Text = Session.Item("NombreZona")
            Me.TodasLasRegiones.Text = True ' verdadero
        End If
    End Sub

    Public Sub MostrarSeleccionRegion(ByVal edicion As Boolean)

        'PERMITE ELEGIR SI UNA O TODAS LAS REGIONES
        Me.RblRegiones.Visible = edicion
        MostrarRegion(False)
        If edicion Then
            Me.TodasLasRegiones.Text = True ' verdadero
        End If
    End Sub
    Public Sub MostrarRegion(ByVal edicion As Boolean)

        'MUESTRA CAMPOS PARA SELECCION DE REGION
        Me.lblRegion.Visible = edicion
        Me.DdlZONAS1.Visible = edicion
    End Sub
    Public Sub MostrarSeleccionEstablecimientos(ByVal edicion As Boolean)
        'PERMITE ELIGIR SI UNO O TODOS LOS ESTABLECIMIENTOS

        Me.RblEstablecimientos.Visible = edicion
        MostrarEstablecimiento(False)
        If edicion Then
            Me.TodosLosEstablecimientos.Text = True ' verdadero
        End If
    End Sub

    Public Sub MostrarEstablecimiento(ByVal edicion As Boolean)
        'MOSTRAR CAMPOS PARA LA SELECCION DE UN ESTABLECIMIENTOS ESPECIFICO, FILTRADO POR REGION
        Me.lblestab.Visible = edicion
        Me.DdlESTABLECIMIENTOS1.Visible = edicion

        If edicion Then
            If Session.Item("idTipoEstablecimiento") = 2 Then ' Sibasi o region (2)
                Me.DdlESTABLECIMIENTOS1.RecuperarEstablecimientosZonaETZ(Me.DdlZONAS1.SelectedValue)
                Me.lblidestabseleccionado.Text = Me.DdlESTABLECIMIENTOS1.SelectedValue
                Me.TodasLasRegiones.Text = True

            End If

            If Session.Item("idTipoEstablecimiento") = 619 Then  ' MSPAS central (619)
                Me.DdlESTABLECIMIENTOS1.RecuperarEstablecimientosZonaETZ(Me.DdlZONAS1.SelectedValue)
                Me.lblidestabseleccionado.Text = Me.DdlESTABLECIMIENTOS1.SelectedValue
            End If
        End If
    End Sub
    Public Sub MostrarAñoFiscal(ByVal edicion As Boolean)
        'MOSTRAR CAMPOS PARA LA SELECCION DEL AÑO FISCAL

        Me.lblEjercicio.Visible = edicion
        Me.ddlAñoInicio.Visible = edicion

        If edicion Then
            Dim Year As Integer
            Me.ddlAñoInicio.Items.Clear()
            Year = DateTime.Now.Year

            For y As Integer = Year - 2 To Year
                Me.ddlAñoInicio.Items.Add(y)
            Next y

            Me.ddlAñoInicio.SelectedValue = Year
            Me.año.Text = Me.ddlAñoInicio.SelectedValue

        End If
    End Sub
    Public Sub MostrarSeleccionProveedor(ByVal edicion As Boolean)
        'PERMITE SELECIONAR SY UNO O TODOS LOS PROVEEDORES

        Me.RdbProveedor.Visible = edicion
        MostrarCamposProveedor(False)
        If edicion Then
            Me.TodosLosProveedores.Text = True ' verdadero
        End If
    End Sub
    Public Sub MostrarSeleccionProducto(ByVal edicion As Boolean)
        'PERMITE SELECIONAR SI UNO O TODOS LOS PRODUCTOS 
        Me.rdbProducto.Visible = edicion
        MostrarCamposProducto(False)
        If edicion Then
            Me.TodosLosProductos.Text = True
        End If
    End Sub
    Public Sub MostrarFechaReferencia(ByVal edicion As Boolean)
        'MUESTR LOS CAMPOS DE LA FECHA DE REFERENCIA
        Me.lblfecha.Visible = edicion
        Me.FechaReferencia.Visible = edicion
        Me.FechaReferencia.SelectedDate = hoy
        Me.FechaRefSeleccionada.Text = hoy
    End Sub
    Public Sub MostrarOperador(ByVal edicion As Boolean)
        'MUESTRA EL OPERADOR AL MOMENTO DE DEFINIR LA FECHA DE VENCIMIENTO
        Me.LblOperador.Visible = edicion
        Me.DdlOperadorBusqueda.Visible = edicion
        OperSeleccionado.Text = Me.DdlOperadorBusqueda.SelectedValue
    End Sub
    Public Sub MostrarServicioHospitalario(ByVal edicion As Boolean)
        'MUESTRA LOS SERVICIOS HOSPITALARIOS DEL ESTABLECIMIENTO SELECCIONADO

        Me.lblServicioH.Visible = edicion
        Me.DdlSERVICIOSHOSPITALARIOS1.Visible = edicion
        If edicion Then
            Me.DdlSERVICIOSHOSPITALARIOS1.RecuperarListaOrdenada(Me.lblidestablecimiento.Text)
            servcioseleccionado.Text = Me.DdlSERVICIOSHOSPITALARIOS1.SelectedValue
        End If
    End Sub
    Public Sub MostrarRangoFechas(ByVal edicion As Boolean)
        'MOSTRAR CAMPOS PARA RANGO DE FECHAS

        Me.lblFechaInicialRango.Visible = edicion
        Me.lblFechaFinalRango.Visible = edicion
        Me.FechaInicialRango.Visible = edicion
        Me.FechaFinalRango.Visible = edicion
        Me.FechaInicialRango.SelectedDate = hoy
        Me.FechaFinalRango.SelectedDate = hoy
        Me.FechaIniSelecionada.Text = hoy
        Me.fechaFinSelecionada.Text = hoy
    End Sub
    Private Sub MostrarCamposProveedor(ByVal edicion As Boolean)
        'MOSTRAR CAMPOS PARA LA SELECCION DEL PROVEEDOR
        Me.LblProveedor.Visible = edicion
        Me.DdlPROVEEDORES1.Visible = edicion
        Me.Bttaceptarproveedor.Visible = edicion
        If edicion Then
            Me.DdlPROVEEDORES1.RecuperarNombre()
            Me.ProveedorSeleccionado.Text = Me.DdlPROVEEDORES1.SelectedValue
        End If
    End Sub
    Private Sub MostrarCamposFiltroProveedor(ByVal edicion As Boolean)
        'MUESTRA EL NOMBRE DEL PROVEEDOR SELECCIONADO
        Me.LblDescripcionProveedor.Visible = edicion
    End Sub
    Public Sub MostrarCamposProducto(ByVal edicion As Boolean)
        'MOSTRAR CAMPOS PARA LA BUSQUEDA DEL PRODUCTO
        Me.lblIDPRODUCTO.Visible = edicion
        Me.rdblCriterio.Visible = edicion
        Me.TxtProducto.Visible = edicion
        Me.BtnBuscar.Visible = edicion
    End Sub
    Private Sub MostrarCamposFiltroProducto(ByVal edicion As Boolean)
        'MOSTRAR EL FILTRO DE BUSQUEDA DE PRODUCTO
        Me.DdlGRUPOS1.Visible = edicion
        Me.DdlCATALOGOPRODUCTOS1.Visible = edicion
        Me.DdlSUMINISTROS1.Visible = edicion
        Me.bttFiltrarGrupo.Visible = edicion
        Me.bttFiltrarSuministro.Visible = edicion
        Me.LblDescripcionCompleta.Visible = edicion
    End Sub

    Protected Sub RdbProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdbProveedor.SelectedIndexChanged
        'EVENTO AL SELECIONA UNO O TODOS LOS PROVEEDORES

        If RdbProveedor.SelectedValue = 1 Then 'UN PROVEEDOR
            MostrarCamposProveedor(True)
            Me.LblDescripcionProveedor.Visible = False
            Me.LblDescripcionProveedor.Text = ""
            Me.TodosLosProveedores.Text = False
        Else
            MostrarCamposProveedor(False) 'TODOS LOS PROVEEDORES
            Me.LblDescripcionProveedor.Visible = False
            Me.LblDescripcionProveedor.Text = ""
            Me.TodosLosProveedores.Text = True
        End If
    End Sub

    Protected Sub rdbProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbProducto.SelectedIndexChanged
        'EVENTO AL SELECIONAR UNO O TODOS LOS PRODUCTOS

        If rdbProducto.SelectedValue = 1 Then ' UN PRODUCTO
            MostrarCamposProducto(True)
            Me.TodosLosProductos.Text = False
        Else
            MostrarCamposProducto(False) 'TODOS LOS PRODUCTOS
            Me.TodosLosProductos.Text = True
        End If
    End Sub

    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        'EVENTO AL SELECIONAR UNO DE LOS CRITERIO DE FILTRO PARA LA BUSQUEDA DE UN PRODUCTO

        If Me.rdblCriterio.SelectedValue = 0 Then 'Busqueda por codigo
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.BtnBuscar.Visible = True
            Me.BtnBuscar.Text = "Buscar"
            Me.DdlGRUPOS1.Visible = False
            Me.DdlSUMINISTROS1.Visible = False
            Me.bttFiltrarGrupo.Visible = False
            Me.bttFiltrarSuministro.Visible = False
            Me.LblDescripcionCompleta.Visible = False
            Me.LblDescripcionCompleta.Text = ""

        End If
        If Me.rdblCriterio.SelectedValue = 1 Then 'Busqueda por seleccion
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = True
            Me.BtnBuscar.Text = "Aceptar"
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaHabilitadoXCodigoMSPAS(Session.Item("IdEstablecimiento"))
            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.DdlGRUPOS1.Visible = False
            Me.DdlSUMINISTROS1.Visible = False
            Me.bttFiltrarGrupo.Visible = False
            Me.bttFiltrarSuministro.Visible = False
            Me.LblDescripcionCompleta.Visible = False
            Me.LblDescripcionCompleta.Text = ""
        End If
        If Me.rdblCriterio.SelectedValue = 2 Then 'Busqueda por grupo terapeutico
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.lblSuministro.Text)
            Me.DdlGRUPOS1.Visible = True
            Me.DdlSUMINISTROS1.Visible = False
            Me.bttFiltrarGrupo.Visible = True
            Me.bttFiltrarSuministro.Visible = False
            Me.LblDescripcionCompleta.Visible = False
            Me.LblDescripcionCompleta.Text = ""
        End If
        If Me.rdblCriterio.SelectedValue = 3 Then 'Busqueda por suministro
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.DdlSUMINISTROS1.Recuperar()
            Me.DdlSUMINISTROS1.Visible = True
            Me.bttFiltrarGrupo.Visible = False
            Me.bttFiltrarSuministro.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            Me.LblDescripcionCompleta.Text = ""
        End If

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'EVENTO AL PRESIONAR BUSCAR PRODUCTO

        Me.rdblCriterio.ClearSelection()
        Dim dsCatalogoProductos As DataSet

        If Me.BtnBuscar.Text = "Aceptar" Then 'AL MOMENTO DE PRESIONAR ACEPTAR PRODUCTO
            Me.TxtProducto.Text = Me.DdlCATALOGOPRODUCTOS1.SelectedValue

            If Me.lblTipoSuministro.Text = "1" Or Me.lblTipoSuministro.Text = "" Then 'medico
                dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProducto(Me.TxtProducto.Text)
            Else 'no medico
                dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoNoMedico(Me.TxtProducto.Text, Me.lblTipoSuministro.Text)
            End If

            If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
                MsgBox1.ShowAlert("El código del producto no esta habilitado para este establecimiento, es incorrecto o no existe", "C", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.TxtProducto.Text = ""
                Me.lblproducto.Text = ""
                Me.LblDescripcionCompleta.Visible = False
                Me.TxtProducto.Focus()
            Else
                Me.ProductoSeleccionado.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                MostrarCamposProducto(False)
                MostrarCamposFiltroProducto(False)
                Me.rdblCriterio.Visible = True
                Me.LblDescripcionCompleta.Visible = True
                Me.BtnBuscar.Visible = False
            End If

        Else 'AL MOMENTO DE LA BUSQUEDA DEL PRODUCTO
            If Me.lblTipoSuministro.Text = "1" Or Me.lblTipoSuministro.Text = "" Then 'medico
                dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProducto(Me.TxtProducto.Text)
            Else 'no medico
                dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoNoMedico(Me.TxtProducto.Text, Me.lblTipoSuministro.Text)
            End If

            If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
                MsgBox1.ShowAlert("El código del producto no esta habilitado para este establecimiento, es incorrecto o no existe", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.TxtProducto.Text = ""
                Me.lblproducto.Text = ""
                Me.LblDescripcionCompleta.Visible = False
                Me.TxtProducto.Focus()
            Else
                Me.ProductoSeleccionado.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                MostrarCamposProducto(False)
                MostrarCamposFiltroProducto(False)
                Me.rdblCriterio.Visible = True
                Me.LblDescripcionCompleta.Visible = True
                Me.BtnBuscar.Visible = False
            End If
        End If
    End Sub

    Protected Sub DdlZONAS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlZONAS1.SelectedIndexChanged
        'EVENTO AL SELECCIONAR UNA REGION O ZONA
        Me.DdlESTABLECIMIENTOS1.RecuperarEstablecimientosZonaETZ(Me.DdlZONAS1.SelectedValue)
        Me.RegionSeleccionada.Text = Me.DdlZONAS1.SelectedValue
    End Sub

    Protected Sub DdlESTABLECIMIENTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlESTABLECIMIENTOS1.SelectedIndexChanged
        'EVENTO AL SELECCIONAR UN ESTABLECIMIENTO
        Me.lblidestabseleccionado.Text = Me.DdlESTABLECIMIENTOS1.SelectedValue
    End Sub

    Protected Sub ddlAñoInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAñoInicio.SelectedIndexChanged
        'EVENTO AL SELECCIONAL EL AÑO DEL EJERCICIO FISCAL
        Me.año.Text = Me.ddlAñoInicio.SelectedValue
    End Sub

    Protected Sub DdlOperadorBusqueda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlOperadorBusqueda.SelectedIndexChanged
        'EVENTO AL SELECCIONAR OPERADOR DE COMPARACION

        OperSeleccionado.Text = Me.DdlOperadorBusqueda.SelectedValue
    End Sub

    Protected Sub FechaReferencia_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FechaReferencia.DateChanged
        'EVENTO AL SELECCIONAR FECHA DE REFERENCIA
        If Me.FechaReferencia.SelectedDate > hoy Then
            MsgBox1.ShowAlert("La Fecha no puede ser mayor a la fecha actual", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.FechaReferencia.SelectedDate = hoy
        Else
            Me.FechaRefSeleccionada.Text = Me.FechaReferencia.SelectedDate
        End If
    End Sub
    Protected Sub bttFiltrarGrupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttFiltrarGrupo.Click
        'EVENTO DEL BOTON FILTRAR PRODUCTOS

        Me.rdblCriterio.ClearSelection()
        Me.TxtProducto.Visible = False
        Me.BtnBuscar.Visible = True
        Me.BtnBuscar.Text = "Aceptar"

        If Me.lblTipoSuministro.Text = "1" Or Me.lblTipoSuministro.Text = "" Then 'medico
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaHabilitadoXCodigoMSPASxGrupo(CInt(Me.DdlGRUPOS1.SelectedValue), Session.Item("IdEstablecimiento"))
        Else ' no medico
            If Me.lblTipoSuministro.Text <> "1" Then Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXCodigoMSPASxgrupoNoMedico(CInt(Me.DdlGRUPOS1.SelectedValue), Me.lblTipoSuministro.Text)
        End If

        Me.DdlCATALOGOPRODUCTOS1.Visible = True
        Me.DdlGRUPOS1.Visible = False
        Me.DdlSUMINISTROS1.Visible = False
        Me.bttFiltrarGrupo.Visible = False
        Me.bttFiltrarSuministro.Visible = False
        Me.LblDescripcionCompleta.Visible = False
    End Sub

    Protected Sub bttFiltrarSuministro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttFiltrarSuministro.Click
        'EVENTO DEL BOTON FILTRAR SUMINISTRO

        ObtenerSuministro(Me.DdlSUMINISTROS1.SelectedValue)
        Me.rdblCriterio.ClearSelection()
        Me.TxtProducto.Visible = False
        Me.BtnBuscar.Visible = True
        Me.BtnBuscar.Text = "Aceptar"
        If Me.lblTipoSuministro.Text = "1" Or Me.lblTipoSuministro.Text = "" Then 'medico
            Me.DdlCATALOGOPRODUCTOS1.RecuperarHabilitadosxCodigoXSuministro(CInt(Me.DdlSUMINISTROS1.SelectedValue), Me.lblidestabseleccionado.Text)
        Else 'no medico
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXSuministro(CInt(Me.DdlSUMINISTROS1.SelectedValue))
        End If

        Me.DdlCATALOGOPRODUCTOS1.Visible = True
        Me.DdlGRUPOS1.Visible = False
        Me.DdlSUMINISTROS1.Visible = False
        Me.bttFiltrarGrupo.Visible = False
        Me.bttFiltrarSuministro.Visible = False
        Me.LblDescripcionCompleta.Visible = False
    End Sub

    Protected Sub DdlSERVICIOSHOSPITALARIOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSERVICIOSHOSPITALARIOS1.SelectedIndexChanged
        'EVENTO AL SELECCIONAR UN SERVICIO HOSPITALARIO

        servcioseleccionado.Text = Me.DdlSERVICIOSHOSPITALARIOS1.SelectedValue
    End Sub

    Protected Sub FechaInicialRango_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FechaInicialRango.DateChanged
        'EVENTO AL SELLECIONAR FECHA INICIAL DE RANGO

        If Me.FechaInicialRango.SelectedDate > hoy Then
            MsgBox1.ShowAlert("La Fecha no puede ser mayor a la fecha actual", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.FechaInicialRango.SelectedDate = hoy
        Else
            If Me.FechaInicialRango.SelectedDate > Me.FechaFinalRango.SelectedDate Then
                MsgBox1.ShowAlert("La Fecha inicial no puede ser mayor a la fecha final del periodo", "D", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.FechaInicialRango.SelectedDate = Me.FechaFinalRango.SelectedDate
            Else
                Me.FechaIniSelecionada.Text = Me.FechaInicialRango.SelectedDate
            End If
        End If
    End Sub

    Protected Sub FechaFinalRango_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FechaFinalRango.DateChanged
        'EVENTO AL SELECCIONAR FECHA FINAL DEL RANGO

        If Me.FechaFinalRango.SelectedDate > hoy Then
            MsgBox1.ShowAlert("La Fecha no puede ser mayor a la fecha actual", "C", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.FechaFinalRango.SelectedDate = hoy

        Else
            If Me.FechaInicialRango.SelectedDate > Me.FechaFinalRango.SelectedDate Then
                MsgBox1.ShowAlert("La Fecha inicial no puede ser mayor a la fecha final del periodo", "D", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.FechaInicialRango.SelectedDate = Me.FechaFinalRango.SelectedDate
            Else
                Me.fechaFinSelecionada.Text = Me.FechaFinalRango.SelectedDate
            End If
        End If
    End Sub

    Protected Sub Bttaceptarproveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bttaceptarproveedor.Click
        'EVENTO AL MOMENTO DE´PRESIONAR EL BOTON DE ACEPTAR UN PROVEEDOR
        Me.ProveedorSeleccionado.Text = Me.DdlPROVEEDORES1.SelectedValue
        Me.LblDescripcionProveedor.Text = Me.DdlPROVEEDORES1.SelectedItem.Text
        MostrarCamposProveedor(True)
        MostrarCamposFiltroProveedor(True)
    End Sub

    Protected Sub RblRegiones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblRegiones.SelectedIndexChanged
        'EVENTO AL SELECCIONAR UNA REGION O TODAS LAS REGIONES O ZONAS
        If RblRegiones.SelectedValue = 1 Then 'UNA REGION
            MostrarRegion(True)
            Me.TodasLasRegiones.Text = False
        Else
            MostrarRegion(False) 'TODAS LAS REGIONES
            Me.TodasLasRegiones.Text = True
            Me.DdlESTABLECIMIENTOS1.RecuperarEstablecimientosZonaETZ()
            Me.lblidestabseleccionado.Text = Me.DdlESTABLECIMIENTOS1.SelectedValue
        End If
    End Sub

    Protected Sub RblEstablecimientos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblEstablecimientos.SelectedIndexChanged
        'EVENTO AL SELECCIONAR UN ESTABLECIMIENTO O TODOS LOS ESTABLECIMIENTOS
        If RblEstablecimientos.SelectedValue = 1 Then 'UN ESTABLECIMIENTO 
            MostrarEstablecimiento(True)
            Me.TodosLosEstablecimientos.Text = False
            Me.DdlESTABLECIMIENTOS1.RecuperarEstablecimientosZonaETZ(Me.DdlZONAS1.SelectedValue)
            Me.lblidestabseleccionado.Text = Me.DdlESTABLECIMIENTOS1.SelectedValue
        Else
            MostrarEstablecimiento(False) 'TODOS LOS ESTABLECIMIENTOS
            Me.TodosLosEstablecimientos.Text = True
            Me.DdlESTABLECIMIENTOS1.RecuperarEstablecimientosZonaETZ()
            Me.lblidestabseleccionado.Text = Me.DdlESTABLECIMIENTOS1.SelectedValue
        End If
    End Sub

End Class
