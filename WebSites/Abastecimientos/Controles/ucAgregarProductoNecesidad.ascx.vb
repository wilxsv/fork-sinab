'CONTROL DE USUARIO PARA AGREGAR PRODUCTOS AL CALCULO DE NECESIDADES ESTABLECIMIENTO
'UTILIZADO EN CU-ESTA003
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que forma parte del calculo de necesidades de los establecimientos
'el cual permite agregar un producto al detalle del calculo de necesidades
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class Controles_ucAgregarProductoNecesidad
    Inherits System.Web.UI.UserControl

    'inicializar variables

    Private _IDESTABLECIMIENTO As Int32
    Private _Enabled As Boolean = True
    Private _ESESPECIAL As Boolean = False
    Private _sError As String
    Private _nuevo As Boolean = False
    Public Event Cancelar As EventHandler
    Public Event Agregar As EventHandler
    Protected WithEvents dsDatos As System.Data.DataSet
    Private mComponente As New cDETALLENECESIDADESTABLECIMIENTOS
    Dim mCompInstitucion As New cINSTITUCIONES
    Dim mCompNecesidades As New cNECESIDADESTABLECIMIENTOS
    Private mEntidad As DETALLENECESIDADESTABLECIMIENTOS
    Private mCompProductos As New cCATALOGOPRODUCTOS
    Private mEntProductos As New CATALOGOPRODUCTOS
    Public Event ErrorEvent(ByVal errorMessage As String)


    'INICIALIZAR PROPIEDADES
    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
            Me.Nuevo()
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property
    Public Property ESESPECIAL() As Boolean
        Get
            Return Me._ESESPECIAL
        End Get
        Set(ByVal Value As Boolean)
            Me._ESESPECIAL = Value
            Me.lblEsespecial.Text = Me._ESESPECIAL
            If Me.lblEsespecial.Text = True Then
                HabilitarEdicion(True)
            Else
                HabilitarEdicion(False)
            End If
        End Set
    End Property
    Public Sub ObtenerSuministro(ByVal idSUMINISTRO As Int32)
        'obtien el suministro del encabezado y verifico el tipo de suministro al que pertenece
        Me.idSuministro.Text = idSUMINISTRO
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EVENTO AL CARGAR PAGINA


        If Not IsPostBack Then 'LA PRIMERA VEZ

            Me.DdlUNIDADMEDIDAS1.Recuperar()
            Me.txtCONSUMOANUAL.Text = 0
            Me.txtDEMANDAINSATISFECHA.Text = 0
            Me.txtEXISTENCIA.Text = 0
            Me.txtCOSTOTOTALREAL.Text = 0
            Me.txtCOSTOTOTALAJUSTADO.Text = 0
            Me.LblDescripcionCompleta.Text = ""
            Me.lblproducto.Text = ""
            Me.TxtProducto.Text = ""
        End If

        If Not Me.ViewState("nuevo") Is Nothing Then ' AL SER NUEVO
            Me._nuevo = Me.ViewState("nuevo")
        End If

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'HABILITAR LOS OBJETOS DEL CONTROL DE USUARIO NECESARIOS PARA LOS ESTABLECIMIENTOS ESPECIALES
        Me.txtCONSUMOANUAL.Visible = edicion
        Me.lblCONSUMOANUAL.Visible = edicion
        Me.txtDEMANDAINSATISFECHA.Visible = edicion
        Me.lblDEMANDAINSATISFECHA.Visible = edicion
        Me.txtEXISTENCIA.Visible = edicion
        Me.LblEXISTENCIA.Visible = edicion
    End Sub
    Private Sub Nuevo()
        'HABILITAR COMO NUEVO
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If
    End Sub

    Public Function Actualizar() As String
        'FUNCION PARA ACTUALIZAR LOS DATOS EN LA BASE DE DATOS
        mEntidad = New DETALLENECESIDADESTABLECIMIENTOS

        '------------------------------------------------------------
        If Me.lblEsespecial.Text = True Then  'Es establecimiento especial
            '----------------------------------------------------------------
            If Me.txtCONSUMOANUAL.Text = "" Or Me.txtDEMANDAINSATISFECHA.Text = "" Or Me.txtEXISTENCIA.Text = "" Then
                MsgBox1.ShowAlert("No puede estar en blanco los campos", "errorx", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Else
                'inicializacion de variables
                Dim reserva As Double
                Dim ConsumoAnual As Double
                Dim DemandaInsatisfecha As Double
                Dim PeriodoUtilizacion As Integer
                Dim ReservaIncremento As Double
                Dim NecesidadTotal As Double
                Dim ExistenciaTotal As Double
                Dim ExistenciaAlmacen As Double
                Dim ComprasTransito As Double
                Dim ExistenciaEstimada As Double
                Dim NecesidadReal As Double



                'calculo de necesidad
                reserva = mCompInstitucion.ObtenerPorcentajeReserva
                PeriodoUtilizacion = mCompNecesidades.ObtenerPeriododeCompras(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"))
                ConsumoAnual = Me.txtCONSUMOANUAL.Text
                DemandaInsatisfecha = Me.txtDEMANDAINSATISFECHA.Text
                ExistenciaAlmacen = Me.txtEXISTENCIA.Text
                ComprasTransito = 0

                ReservaIncremento = (ConsumoAnual + DemandaInsatisfecha) * (reserva / 100)
                NecesidadTotal = ConsumoAnual + DemandaInsatisfecha + ReservaIncremento
                ExistenciaTotal = ExistenciaAlmacen + ComprasTransito
                ExistenciaEstimada = ExistenciaTotal - NecesidadTotal
                NecesidadReal = NecesidadTotal - ExistenciaEstimada

                If ExistenciaEstimada < 0 Then ExistenciaEstimada = 0

                'asignacion de valores a entidad
                mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                mEntidad.IDNECESIDAD = Session.Item("IdEncabezado")
                mEntidad.IDPRODUCTO = Me.lblproducto.Text
                mEntidad.IDUNIDADMEDIDA = Me.DdlUNIDADMEDIDAS1.SelectedValue
                mEntidad.PRECIOUNITARIO = Me.LblPrecio.Text

                mEntidad.CONSUMOANUAL = Me.txtCONSUMOANUAL.Text
                mEntidad.DEMANDAINSATISFECHA = Me.txtDEMANDAINSATISFECHA.Text
                mEntidad.RESERVAESTABLECIMIENTO = ReservaIncremento
                mEntidad.RESERVATOTAL = NecesidadTotal
                mEntidad.EXISTENCIAESTIMADA = ExistenciaEstimada
                mEntidad.COMPRASENTRANSITO = ComprasTransito
                mEntidad.NECESIDADREAL = CInt(NecesidadReal)
                mEntidad.NECESIDADAJUSTADA = CInt(NecesidadReal)
                mEntidad.NECESIDADFINAL = CInt(NecesidadReal)
                Me.txtCOSTOTOTALREAL.Text = Me.LblPrecio.Text * CInt(NecesidadReal)
                Me.txtCOSTOTOTALAJUSTADO.Text = Me.LblPrecio.Text * CInt(NecesidadReal)
                mEntidad.COSTOTOTALREAL = Me.txtCOSTOTOTALREAL.Text
                mEntidad.COSTOTOTALAJUSTADO = Me.txtCOSTOTOTALAJUSTADO.Text
                If mEntidad.AUUSUARIOCREACION = Nothing Then
                    mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                End If
                If mEntidad.AUFECHACREACION = Nothing Then
                    mEntidad.AUFECHACREACION = Now()
                End If
                mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHAMODIFICACION = Now()
                mEntidad.ESTASINCRONIZADA = 0

                'Agregar producto
                If mComponente.AgregarDETALLENECESIDADESTABLECIMIENTOS(mEntidad) <> 1 Then 'AGREGA PRODUCTO

                    MsgBox1.ShowAlert("Error al guardar el registro", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Return "Error al Guardar registro."

                End If
            End If

            '------------------------------
        Else ' no es especial
            '--------------------------------
            Dim i As Integer
            Dim reserva As Double
            Dim PeriodoUtilizacion As Integer
            Dim ConsumoAnual As Double
            Dim ConsumoPromedioMensual As Double
            Dim DemandaInsatisfecha As Double
            Dim ReservaIncremento As Double
            Dim NecesidadTotal As Double
            Dim ExistenciaTotal As Double
            Dim ExistenciaAlmacen As Double
            Dim ComprasTransito As Double
            Dim ExistenciaEstimada As Double
            Dim Existencianovence As Double
            Dim NecesidadReal As Double
            Dim PresupuestoReal As Double
            Dim mesinicio As Integer
            Dim añoinicio As Integer
            Dim mesfin As Integer
            Dim añofin As Integer
            Dim fechainicio As Date
            Dim fechafin As Date
            Dim dsVencidos As DataSet
            Dim rvenc As DataRow
            Dim ExistenciaVence As Double
            Dim mesesFaltaVencerse As Double
            Dim VencimientoAnterior As Date
            Dim DemandaPromedioMensual As Double

            mesinicio = mCompNecesidades.ObtenerMesInicial(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"))
            mesfin = mCompNecesidades.ObtenerMesFinal(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"))
            añoinicio = mCompNecesidades.ObtenerAñoInicial(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"))
            añofin = mCompNecesidades.ObtenerAñoFinal(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"))
            fechainicio = CDate("01/" & mesinicio & "/" & añoinicio)
            fechafin = CDate("01/" & mesfin & "/" & añofin)

            reserva = mCompInstitucion.ObtenerPorcentajeReserva
            PeriodoUtilizacion = mCompNecesidades.ObtenerPeriododeCompras(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"))
            ConsumoAnual = 0
            ConsumoPromedioMensual = 0
            DemandaInsatisfecha = 0
            ExistenciaAlmacen = 0
            ComprasTransito = 0
            PresupuestoReal = 0
            Existencianovence = 0
            DemandaPromedioMensual = 0

            Dim year As Integer = Now.Year
            Dim month As Integer = Now.Month
            Dim fecha As Date = Now.Date
            Dim consumoMensual As Double
            Dim DemandaMensual As Double
            Dim mes As Integer
            Dim año As Integer

            mes = month - 1
            If mes = 0 Then
                mes = 12
                year = year - 1
            End If
            año = year
            '--------------------------------------------------------------------------------------
            If Session.Item("idTipoEstablecimiento") = 2 Then  ' calculo para una SIBASI(2) para todos los establecimientos del n1vel 1
                '--------------------------------------------------------------------------
                'calculo de necesidad
                For i = 1 To 12
                    consumoMensual = mCompNecesidades.ObtenerConsumoMensualSibasi(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, mes, año)
                    ConsumoAnual = ConsumoAnual + consumoMensual
                    DemandaMensual = mCompNecesidades.ObtenerDemandaMensualSibasi(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, mes, año)
                    DemandaInsatisfecha = DemandaInsatisfecha + DemandaMensual

                    mes = mes - 1

                    If mes = 0 Then
                        mes = 12
                        año = year - 1
                    End If
                    año = year

                Next i

                mes = month - 1
                year = Now.Year

                If mes = 0 Then
                    mes = 12
                    año = year - 1
                End If
                año = year

                ConsumoPromedioMensual = ConsumoAnual / 12
                DemandaPromedioMensual = DemandaInsatisfecha / 12
                If PeriodoUtilizacion < 12 Then
                    ConsumoAnual = (ConsumoPromedioMensual * PeriodoUtilizacion)
                    DemandaInsatisfecha = (DemandaPromedioMensual * PeriodoUtilizacion)
                End If
                ExistenciaAlmacen = ExistenciaAlmacen + mCompNecesidades.ObtenerExistenciasMensualSibasi(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, mes, año)
                ComprasTransito = mCompNecesidades.ObtenerComprasTransitoEstablecimiento(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, fecha)
                ReservaIncremento = (ConsumoAnual + DemandaInsatisfecha) * (reserva / 100)
                NecesidadTotal = ConsumoAnual + DemandaInsatisfecha + ReservaIncremento
                ExistenciaTotal = ExistenciaAlmacen + ComprasTransito
                ExistenciaEstimada = ExistenciaTotal - NecesidadTotal

                If ExistenciaEstimada < 0 Then ExistenciaEstimada = 0

                NecesidadReal = NecesidadTotal - ExistenciaEstimada

                'asignacion de valores a entidad
                mEntidad.IDNECESIDAD = Session.Item("IdEncabezado")
                mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                mEntidad.IDPRODUCTO = Me.lblproducto.Text
                mEntidad.IDUNIDADMEDIDA = Me.DdlUNIDADMEDIDAS1.SelectedValue
                mEntidad.CONSUMOANUAL = ConsumoAnual
                mEntidad.DEMANDAINSATISFECHA = DemandaInsatisfecha
                mEntidad.RESERVAESTABLECIMIENTO = ReservaIncremento
                mEntidad.RESERVATOTAL = NecesidadTotal
                mEntidad.EXISTENCIAESTIMADA = ExistenciaEstimada
                mEntidad.COMPRASENTRANSITO = ComprasTransito
                mEntidad.NECESIDADAJUSTADA = CInt(NecesidadReal)
                mEntidad.NECESIDADFINAL = CInt(NecesidadReal)
                mEntidad.NECESIDADREAL = CInt(NecesidadReal)
                mEntidad.PRECIOUNITARIO = Me.LblPrecio.Text
                mEntidad.COSTOTOTALREAL = Me.LblPrecio.Text * CInt(NecesidadReal)
                mEntidad.COSTOTOTALAJUSTADO = Me.LblPrecio.Text * CInt(NecesidadReal)
                mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHACREACION = Now
                mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHAMODIFICACION = Now
                mEntidad.ESTASINCRONIZADA = 0

                ConsumoAnual = 0
                consumoMensual = 0
                DemandaMensual = 0
                DemandaInsatisfecha = 0
                ExistenciaAlmacen = 0
                ComprasTransito = 0
                PresupuestoReal = 0
                DemandaPromedioMensual = 0

                'agregar producto
                If mComponente.AgregarDETALLENECESIDADESTABLECIMIENTOS(mEntidad) <> 1 Then 'AGREGA PRODUCTO

                    MsgBox1.ShowAlert("Error al guardar el registro", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Return "Error al Guardar registro."

                End If
            End If
            '--------------------------------------------------------------------------------------
            If Session.Item("Nivel") = 2 Or Session.Item("Nivel") = 3 Then  ' calculo para establecimientos del 2 y 3 nivel
                '---------------------------------------------------------------------------------------

                'calculo de necesidades
                For i = 1 To 12
                    consumoMensual = mCompNecesidades.ObtenerConsumoMensualEstablecimiento(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, mes, año)
                    ConsumoAnual = ConsumoAnual + consumoMensual
                    DemandaMensual = mCompNecesidades.ObtenerDemandaMensualEstablecimiento(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, mes, año)
                    DemandaInsatisfecha = DemandaInsatisfecha + DemandaMensual

                    mes = mes - 1

                    If mes = 0 Then
                        mes = 12
                        año = year - 1
                    End If
                    año = year

                Next i

                mes = month - 1
                year = Now.Year

                If mes = 0 Then
                    mes = 12
                    año = year - 1
                End If
                año = year

                ConsumoPromedioMensual = ConsumoAnual / 12
                DemandaPromedioMensual = DemandaInsatisfecha / 12
                If PeriodoUtilizacion < 12 Then
                    ConsumoAnual = (ConsumoPromedioMensual * PeriodoUtilizacion)
                    DemandaInsatisfecha = (DemandaPromedioMensual * PeriodoUtilizacion)
                End If

                Existencianovence = mCompNecesidades.ObtenerExistenciaDisponibleNoVencida(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, fecha, fecha)

                dsVencidos = mCompNecesidades.ObtenerExistenciaVencePlazoCompra(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, fecha, fechainicio, fechafin)

                Dim filas As Integer = 0
                For Each rvenc In dsVencidos.Tables(0).Rows
                    If filas = 0 Then mesesFaltaVencerse = DateDiff("m", rvenc("FECHAVENCIMIENTO"), fechafin)
                    If filas <> 0 Then mesesFaltaVencerse = DateDiff("m", VencimientoAnterior, fechafin)
                    mesesFaltaVencerse = DateDiff("m", rvenc("FECHAVENCIMIENTO"), fechafin)
                    ExistenciaVence = ExistenciaVence + rvenc("EXISTENCIA") - (mesesFaltaVencerse * ConsumoPromedioMensual)
                    VencimientoAnterior = rvenc("FECHAVENCIMIENTO")
                    filas = filas + 1
                Next rvenc

                ExistenciaAlmacen = ExistenciaAlmacen + Existencianovence + ExistenciaVence
                ComprasTransito = mCompNecesidades.ObtenerComprasTransitoEstablecimiento(Session.Item("IdEstablecimiento"), Me.lblproducto.Text, fecha)
                ReservaIncremento = (ConsumoAnual + DemandaInsatisfecha) * (reserva / 100)
                NecesidadTotal = ConsumoAnual + DemandaInsatisfecha + ReservaIncremento
                ExistenciaTotal = ExistenciaAlmacen + ComprasTransito
                ExistenciaEstimada = ExistenciaTotal - NecesidadTotal

                If ExistenciaEstimada < 0 Then ExistenciaEstimada = 0

                NecesidadReal = NecesidadTotal - ExistenciaEstimada

                'asignacion de valores a entidad
                mEntidad.IDNECESIDAD = Session.Item("IdEncabezado")
                mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                mEntidad.IDPRODUCTO = Me.lblproducto.Text
                mEntidad.IDUNIDADMEDIDA = Me.DdlUNIDADMEDIDAS1.SelectedValue
                mEntidad.CONSUMOANUAL = ConsumoAnual
                mEntidad.DEMANDAINSATISFECHA = DemandaInsatisfecha
                mEntidad.RESERVAESTABLECIMIENTO = ReservaIncremento
                mEntidad.RESERVATOTAL = NecesidadTotal
                mEntidad.EXISTENCIAESTIMADA = ExistenciaEstimada
                mEntidad.COMPRASENTRANSITO = ComprasTransito
                mEntidad.NECESIDADAJUSTADA = CInt(NecesidadReal)
                mEntidad.NECESIDADFINAL = CInt(NecesidadReal)
                mEntidad.NECESIDADREAL = CInt(NecesidadReal)
                mEntidad.PRECIOUNITARIO = Me.LblPrecio.Text
                mEntidad.COSTOTOTALREAL = Me.LblPrecio.Text * CInt(NecesidadReal)
                mEntidad.COSTOTOTALAJUSTADO = Me.LblPrecio.Text * CInt(NecesidadReal)
                mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHACREACION = Now
                mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHAMODIFICACION = Now
                mEntidad.ESTASINCRONIZADA = 0

                ConsumoAnual = 0
                consumoMensual = 0
                DemandaMensual = 0
                ConsumoPromedioMensual = 0
                DemandaInsatisfecha = 0
                Existencianovence = 0
                ExistenciaAlmacen = 0
                ComprasTransito = 0
                PresupuestoReal = 0
                DemandaPromedioMensual = 0

                'agregar producto
                If mComponente.AgregarDETALLENECESIDADESTABLECIMIENTOS(mEntidad) <> 1 Then 'AGREGA PRODUCTO

                    MsgBox1.ShowAlert("Error al guardar el registro", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Return "Error al Guardar registro."

                End If
            End If

            If Session.Item("idTipoEstablecimiento") <> "2" And Session.Item("Nivel") = 1 Then
                'SI ES UN ESTABLECIMIENTO DE PRIMER NIVEL QUE NO ES SIBASI
                MsgBox1.ShowAlert("El calculo de necesidades debe ser realizado por el Sibasi al cual pertenece", "eroorx", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If

            If Session.Item("idTipoEstablecimiento") <> "2" And Session.Item("Nivel") = 0 Then
                'SI ES EL MSPAS o Almacen El Paraiso
                MsgBox1.ShowAlert("El calculo de necesidades debe ser realizado por un Sibasi o un hospital", "eroory", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If

        End If

    End Function


    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        'EVENTO AL SELECIONAR UNO DE LOS CRITERIO DE FILTRO PARA LA BUSQUEDA DE UN PRODUCTO

        If Me.rdblCriterio.SelectedValue = 0 Then 'Busqueda por codigo
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.BtnBuscar.Visible = True
            Me.BtnBuscar.Text = "Buscar"
            Me.DdlGRUPOS1.Visible = False
            Me.bttgenerar.Visible = False
        End If
        If Me.rdblCriterio.SelectedValue = 1 Then 'Busqueda por seleccion
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = True
            Me.BtnBuscar.Text = "Aceptar"
            If Me.idSuministro.Text = "1" Then
                Me.DdlCATALOGOPRODUCTOS1.RecuperarHabilitadosxCodigoXSuministro(Me.idSuministro.Text, Session.Item("IdEstablecimiento"))
            Else
                Me.DdlCATALOGOPRODUCTOS1.RecuperarListaNoMedicosXCodigoMSPAS(Me.idSuministro.Text)
            End If
            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.bttgenerar.Visible = False
        End If
        If Me.rdblCriterio.SelectedValue = 2 Then  'Busqueda por grupo terapeutico
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.idSuministro.Text)
            Me.DdlGRUPOS1.Visible = True
            Me.bttgenerar.Visible = True
            Me.LblDescripcionCompleta.Visible = False
        End If
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'EVENTO AL PRESIONAR BUSCAR UN PRODUCTO
        Me.rdblCriterio.ClearSelection()
        Dim dsCatalogoProductos As DataSet

        Dim dsProductosNecesidad As DataSet
        dsProductosNecesidad = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)

        'VERIFICACION SI EL PRODUCTO YA ESTA EN EL CALCULO DE NECESIDADES
        If dsProductosNecesidad.Tables(0).Rows.Count > 0 Then
            MsgBox1.ShowAlert("Este producto ya fu ingresado al programa de compras", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.TxtProducto.Text = ""
            Me.lblproducto.Text = ""
            Me.LblDescripcionCompleta.Text = ""
            Me.TxtProducto.Focus()
        Else
            If Me.BtnBuscar.Text = "Aceptar" Then  ' AL PRESIONAR ACEPTAR UN PRODUCTO
                Me.TxtProducto.Text = Me.DdlCATALOGOPRODUCTOS1.SelectedValue
                If Me.idSuministro.Text = "1" Then
                    dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(Me.TxtProducto.Text, Session.Item("IdEstablecimiento"), Me.idSuministro.Text)
                Else
                    dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoXSuministro(Me.TxtProducto.Text, Me.idSuministro.Text)
                End If

                dsProductosNecesidad = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)
                If dsProductosNecesidad.Tables(0).Rows.Count > 0 Then
                    MsgBox1.ShowAlert("Este producto ya fue ingresado al programa de compras", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Me.TxtProducto.Text = ""
                    Me.lblproducto.Text = ""
                    Me.LblDescripcionCompleta.Text = ""
                    LblDescripcionCompleta.Focus()
                Else
                    If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
                        MsgBox1.ShowAlert("El código del producto es incorrecto o no existe", "C", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Me.TxtProducto.Text = ""
                        Me.lblproducto.Text = ""
                        Me.LblDescripcionCompleta.Text = ""
                        Me.TxtProducto.Focus()
                    Else
                        Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
                        Me.LblUnidad.Text = Me.DdlUNIDADMEDIDAS1.SelectedItem.Text
                        Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("CORRPRODUCTO")
                        Me.lblproducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                        Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                        Me.LblDescripcionCompleta.Visible = True
                        Me.LblPrecio.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
                    End If
                End If
            Else  ' AL PRESIONAR BUSCAR UN PRODUCTO
                If Me.idSuministro.Text = "1" Then
                    dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(Me.TxtProducto.Text, Session.Item("IdEstablecimiento"), Me.idSuministro.Text)
                Else
                    dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoXSuministro(Me.TxtProducto.Text, Me.idSuministro.Text)
                End If
                dsProductosNecesidad = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)
                If dsProductosNecesidad.Tables(0).Rows.Count > 0 Then
                    MsgBox1.ShowAlert("Este producto ya fue ingresado al programa de compras", "D", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Me.TxtProducto.Text = ""
                    Me.lblproducto.Text = ""
                    Me.LblDescripcionCompleta.Text = ""
                    LblDescripcionCompleta.Focus()
                Else
                    If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
                        MsgBox1.ShowAlert("El código del producto es incorrecto o no existe", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Me.TxtProducto.Text = ""
                        Me.lblproducto.Text = ""
                        Me.LblDescripcionCompleta.Text = ""
                        Me.TxtProducto.Focus()
                    Else
                        Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
                        Me.LblUnidad.Text = Me.DdlUNIDADMEDIDAS1.SelectedItem.Text
                        Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("CORRPRODUCTO")
                        Me.lblproducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                        Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                        Me.LblDescripcionCompleta.Visible = True
                        Me.LblPrecio.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
                    End If
                End If

            End If

        End If

    End Sub

    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click

        'EVENTO AL PRESIONAR IMAGEN DE GUARDAR Y VALIDACIONES REALIZADAS AL MOMENTO DE GUARDAR PRODUCTO


        If Me.lblproducto.Text = "" Then
            MsgBox1.ShowAlert("Favor agregue un producto", "F", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Actualizar()
            Me.txtCONSUMOANUAL.Text = 0
            Me.txtDEMANDAINSATISFECHA.Text = 0
            Me.txtEXISTENCIA.Text = 0
            Me.txtCOSTOTOTALREAL.Text = 0
            Me.txtCOSTOTOTALAJUSTADO.Text = 0
            Me.LblDescripcionCompleta.Text = ""
            Me.lblproducto.Text = ""
            Me.TxtProducto.Text = ""
            Me.rdblCriterio.SelectedValue = 0
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.BtnBuscar.Visible = True
            Me.BtnBuscar.Text = "Buscar"
            Me.bttgenerar.Visible = False
            RaiseEvent Agregar(sender, e)
        End If
    End Sub

    Protected Sub ImgbCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar.Click

        'EVENTO AL PRESIONAR LA IMAGEN DE CANCELAR

        Me.txtCONSUMOANUAL.Text = 0
        Me.txtDEMANDAINSATISFECHA.Text = 0
        Me.txtEXISTENCIA.Text = 0
        Me.txtCOSTOTOTALREAL.Text = 0
        Me.txtCOSTOTOTALAJUSTADO.Text = 0
        Me.LblDescripcionCompleta.Text = ""
        Me.lblproducto.Text = ""
        Me.TxtProducto.Text = ""
        Me.rdblCriterio.SelectedValue = 0
        Me.DdlCATALOGOPRODUCTOS1.Visible = False
        Me.DdlGRUPOS1.Visible = False
        Me.TxtProducto.Visible = True
        Me.BtnBuscar.Visible = True
        Me.BtnBuscar.Text = "Buscar"
        Me.bttgenerar.Visible = False
        RaiseEvent Cancelar(sender, e)
    End Sub

    Protected Sub bttgenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttgenerar.Click

        'EVENTO AL PRESIONAR BOTON PARA FILTRAR POR GRUPO TERAPEUTICO
        Me.rdblCriterio.ClearSelection()
        Me.TxtProducto.Visible = False
        Me.BtnBuscar.Visible = True
        Me.BtnBuscar.Text = "Aceptar"
        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXCodigoMSPASxgrupo(CInt(Me.DdlGRUPOS1.SelectedValue))
        Me.DdlCATALOGOPRODUCTOS1.Visible = True
        Me.LblDescripcionCompleta.Visible = False
        Me.DdlGRUPOS1.Visible = False
        Me.bttgenerar.Visible = False

    End Sub
End Class
