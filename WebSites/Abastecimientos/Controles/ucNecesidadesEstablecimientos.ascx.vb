'CONTROL DE USUARIO PARA CALCULO DE NECESIDADES ESTABLECIMIENTO
'UTILIZADO EN CU-ESTA003
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que forma parte del calculo de necesidades de los establecimientos

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class Controles_ucNecesidadesEstablecimientos
    Inherits System.Web.UI.UserControl
    'INICIALIZAR VARIABLES

    Public Event ErrorEvent(ByVal errorMessage As String)
    Public Event MontoSolicitud(ByVal MontoSolicitud As Double, ByVal PresupuestoSolicitud As Double)
    Public Event NumeroSolicitud(ByVal NumSolicitud As String, ByVal Presupuesto As Double, ByVal MONTO As Double)
    Public Event GuardoDetalle()
    Public Event EliminoDetalle()
    Public Event SobrepasoPropuesta()
    Dim mCompEstablecimiento As New cESTABLECIMIENTOS
    Dim mCompInstitucion As New cINSTITUCIONES
    Dim mComponente As New cNECESIDADESTABLECIMIENTOS
    Dim mEntidad As New NECESIDADESTABLECIMIENTOS
    Dim mCompConsumo As New cCONSUMOS
    Dim mEntConsumo As New CONSUMOS


    'INICIALIZAR PROPIEDADES

    Public Property CODIGOENCABEZADODOCUMENTO() As Int32 'NUMERO DE DOCUMENTO
        Get
            Return Me.UcVistaDetalleNecesidadesEstablecimientos1.IDNECESIDAD
        End Get
        Set(ByVal Value As Int32)

            Me.UcVistaDetalleNecesidadesEstablecimientos1.IDNECESIDAD = Value
            Me.lblID.Text = Value
            Me.UcDesgloceNecesidadesEstablecimientos1.ObtenerDetalleDocumento(Value)
        End Set
    End Property
    Public Property Consulta() As Boolean ' AL MOMENTO DE UNA CONSULTA
        Get
            Return Me.UcVistaDetalleNecesidadesEstablecimientos1.Enabled
        End Get
        Set(ByVal Value As Boolean)

            Me.UcVistaDetalleNecesidadesEstablecimientos1.Enabled = Value
            Me.UcDesgloceNecesidadesEstablecimientos1.Enabled = Value
            Me.BttProductos.Visible = False
            Me.UcDesgloceNecesidadesEstablecimientos1.PermitirAgregar = False
            Me.UcDesgloceNecesidadesEstablecimientos1.PermitirObservaciones = False
            Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadFinal = False
            Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadAjustada = True
        End Set
    End Property
    Public Property Nuevo() As Boolean 'AL MOMENTO DE UNA NECESIDAD O PROGRAMA DE COMPRAS NEUEVO
        Get
            Return Me.UcVistaDetalleNecesidadesEstablecimientos1.Enabled
        End Get
        Set(ByVal Value As Boolean)

            Me.UcVistaDetalleNecesidadesEstablecimientos1.Enabled = Value

            If Session.Item("idTipoEstablecimiento") = "9" Then
                Me.BttProductos.Visible = True
                Me.BttCalcularNecesidades.Visible = False
                Me.UcDesgloceNecesidadesEstablecimientos1.Enabled = Value
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirAgregar = True
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirObservaciones = False
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadFinal = False
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadAjustada = True
                Me.UcDesgloceNecesidadesEstablecimientos1.ESESPECIAL = True

            Else
                Me.BttProductos.Visible = False
                Me.BttCalcularNecesidades.Visible = True
                Me.UcDesgloceNecesidadesEstablecimientos1.Enabled = Value
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirAgregar = True
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirObservaciones = False
                Me.UcDesgloceNecesidadesEstablecimientos1.ESESPECIAL = False
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadFinal = False
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadAjustada = True


            End If

            Me.UcDesgloceNecesidadesEstablecimientos1.Visible = False

        End Set
    End Property

    Public Property grabado(ByVal permitirVerObservaciones As Boolean, Optional ByVal idestado As Int32 = 0) As Boolean
        'AL MOMENTO DE UN PROGRAMA DE COMPRAS NUEVO
        Get
            Return Me.UcVistaDetalleNecesidadesEstablecimientos1.Enabled
        End Get
        Set(ByVal Value As Boolean)

            Me.UcVistaDetalleNecesidadesEstablecimientos1.Enabled = Value
            Me.lblidestado.Text = idestado
            Me.UcDesgloceNecesidadesEstablecimientos1.Estado = Me.lblidestado.Text

            If Session.Item("idTipoEstablecimiento") = "9" Then 'ESTABLECIMIENTO ESPECIAL (9)
                Me.BttProductos.Visible = False
                Me.BttCalcularNecesidades.Visible = False
                Me.UcDesgloceNecesidadesEstablecimientos1.Enabled = Value
                Me.UcDesgloceNecesidadesEstablecimientos1.Visible = True
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirAgregar = True
                Me.UcDesgloceNecesidadesEstablecimientos1.ESESPECIAL = True

            Else ' NO ES ESPECIAL
                Me.BttProductos.Visible = False
                Me.BttCalcularNecesidades.Visible = False
                Me.UcDesgloceNecesidadesEstablecimientos1.Enabled = Value
                Me.UcDesgloceNecesidadesEstablecimientos1.Visible = True
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirAgregar = True
                Me.UcDesgloceNecesidadesEstablecimientos1.ESESPECIAL = False
            End If

            If permitirVerObservaciones Then ' PERMITE VER OBSERVACIONES CUANDO HA SIDO ASESORADA
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirObservaciones = True
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadFinal = True
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadAjustada = False
            Else
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirObservaciones = False
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadFinal = False
                Me.UcDesgloceNecesidadesEstablecimientos1.PermitirNecesidadAjustada = True
            End If

        End Set
    End Property

    Public Function Actualizar() As String
        'FUNCION AL ACTUALIZAR NECESIDAD

        Dim sError As String
        If Validaciones() Then
            sError = Me.UcVistaDetalleNecesidadesEstablecimientos1.Actualizar()
            If sError <> "" Then
                MsgBox1.ShowAlert("Error al intentar guardar el programa de compra", "error2", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Return sError
            Else
                'exitoso
            End If
        Else
            sError = "error"
            Return sError
        End If
        Return Me.UcDesgloceNecesidadesEstablecimientos1.Actualizar()
    End Function

    Private Function Validaciones() As Boolean
        'verificar que monto no supere presupuesto
        If CDbl(Me.UcVistaDetalleNecesidadesEstablecimientos1.MONTO.Text) > CDbl(Me.UcVistaDetalleNecesidadesEstablecimientos1.PRESUPUESTO.Text) Then
            MsgBox1.ShowAlert("El monto de la nececidad ajustada supera el monto del presupuesto asignado", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return False
        Else
            Return True
        End If
    End Function
    Protected Sub UcDesgloceNecesidadesEstablecimientos1_AgregoDetalle(ByVal MONTOREAL As Double, ByVal MONTOAJUSTADO As Double) Handles UcDesgloceNecesidadesEstablecimientos1.AgregoDetalle
        'EVENTO AL AGREGAR UN PRODUCTO EN EL DETALLE DE NECESIDADES

        Me.LblMontoReal.Text = MONTOREAL
        Me.LblMontoAjustado.Text = MONTOAJUSTADO
        Me.UcVistaDetalleNecesidadesEstablecimientos1.AsignarMontoNecesidad(MONTOREAL, MONTOAJUSTADO)
        Session.Item("presupuesto") = Me.UcVistaDetalleNecesidadesEstablecimientos1.PRESUPUESTO.Text
        RaiseEvent MontoSolicitud(MONTOAJUSTADO, Session.Item("presupuesto"))
        Me.UcDesgloceNecesidadesEstablecimientos1.habilitarfiltro(True)
    End Sub

    Protected Sub UcDesgloceNecesidadesEstablecimientos1_Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Integer) Handles UcDesgloceNecesidadesEstablecimientos1.Eliminado
        'EVENTO AL ELIMINAR UN PRODUCTO DEL DETALLE DE NECESIDADES

        Me.UcVistaDetalleNecesidadesEstablecimientos1.IDNECESIDAD = CODIGOENZABEZADODOCUMENTO
        RaiseEvent EliminoDetalle()
    End Sub

    Protected Sub BttProductos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttProductos.Click
        'EVENTO AL PRESIONAR BOTON DE AGREGAR PRODUCTOS A LA NECESIDAD

        Actualizar()
        Me.UcDesgloceNecesidadesEstablecimientos1.Visible = True
        Me.UcDesgloceNecesidadesEstablecimientos1.Agregar()
        Me.BttProductos.Visible = False
        Me.BttCalcularNecesidades.Visible = False
        Me.UcDesgloceNecesidadesEstablecimientos1.habilitarfiltro(False)
    End Sub

    Protected Sub BttCalcularNecesidades_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttCalcularNecesidades.Click

        'EVENTO AL PRESIONAR CALCULAR NECESIDADES
        Me.BttCalcularNecesidades.Enabled = False
        Me.BttProductos.Visible = False

        Actualizar() 'GRABA ENCABEZADO
        Dim mEntDetalle As New DETALLENECESIDADESTABLECIMIENTOS
        Dim mCompDetalle As New cDETALLENECESIDADESTABLECIMIENTOS
        Dim mEntCatalogo As New CATALOGOPRODUCTOS
        Dim mCompCatalogo As New cCATALOGOPRODUCTOS
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
        Dim Existencianovence As Double
        Dim ComprasTransito As Double
        Dim ExistenciaEstimada As Double
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

        mesinicio = mComponente.ObtenerMesInicial(Session.Item("IdEstablecimiento"), CInt(Me.lblID.Text))
        mesfin = mComponente.ObtenerMesFinal(Session.Item("IdEstablecimiento"), CInt(Me.lblID.Text))
        añoinicio = mComponente.ObtenerAñoInicial(Session.Item("IdEstablecimiento"), CInt(Me.lblID.Text))
        añofin = mComponente.ObtenerAñoFinal(Session.Item("IdEstablecimiento"), CInt(Me.lblID.Text))
        fechainicio = CDate("01/" & mesinicio & "/" & añoinicio)
        fechafin = CDate("01/" & mesfin & "/" & añofin)

        reserva = mCompInstitucion.ObtenerPorcentajeReserva
        PeriodoUtilizacion = mComponente.ObtenerPeriododeCompras(Session.Item("IdEstablecimiento"), CInt(Me.lblID.Text))
        ConsumoAnual = 0
        ConsumoPromedioMensual = 0
        DemandaInsatisfecha = 0
        ExistenciaAlmacen = 0
        Existencianovence = 0
        ComprasTransito = 0
        PresupuestoReal = 0
        DemandaPromedioMensual = 0

        Dim r1 As DataRow

        Dim fecha As Date = Now.Date
        Dim consumoMensual As Double
        Dim DemandaMensual As Double

        Dim year As Integer = Now.Year
        Dim month As Integer = Now.Month
        Dim mes As Integer
        Dim año As Integer

        mes = month - 1
        If mes = 0 Then
            mes = 12
            year = year - 1
        End If
        año = year

        Dim dsDetalle As DataSet
        If lblsuministro.Text = "1" Then
            dsDetalle = mCompCatalogo.ObtenerCatalogoProductosCompletoHabilitadoXsuministro(lblsuministro.Text, Session.Item("IdEstablecimiento"))
        Else
            dsDetalle = mCompCatalogo.ObtenerCatalogoProductosCompletoXsuministro(lblsuministro.Text)
        End If
        If Session.Item("idTipoEstablecimiento") = "2" Then  ' calculo para una SIBASI para todos los establecimientos del nivel 1
            For Each r1 In dsDetalle.Tables(0).Rows
                For i = 1 To 12
                    consumoMensual = mComponente.ObtenerConsumoMensualSibasi(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), mes, año)
                    ConsumoAnual = ConsumoAnual + consumoMensual
                    DemandaMensual = mComponente.ObtenerDemandaMensualSibasi(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), mes, año)
                    DemandaInsatisfecha = DemandaInsatisfecha + DemandaMensual

                    mes = mes - 1

                    If mes = 0 Then
                        mes = 12
                        year = year - 1
                    End If

                    año = year

                Next i

                mes = month - 1
                year = Now.Year
                If mes = 0 Then
                    mes = 12
                    year = year - 1
                End If

                año = year

                ConsumoPromedioMensual = ConsumoAnual / 12
                DemandaPromedioMensual = DemandaInsatisfecha / 12
                If PeriodoUtilizacion < 12 Then
                    ConsumoAnual = (ConsumoPromedioMensual * PeriodoUtilizacion)
                    DemandaInsatisfecha = (DemandaPromedioMensual * PeriodoUtilizacion)
                End If

                ExistenciaAlmacen = ExistenciaAlmacen + mComponente.ObtenerExistenciasMensualSibasi(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), mes, año)
                ComprasTransito = mComponente.ObtenerComprasTransitoEstablecimiento(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), fecha)
                ReservaIncremento = (ConsumoAnual + DemandaInsatisfecha) * (reserva / 100)
                NecesidadTotal = ConsumoAnual + DemandaInsatisfecha + ReservaIncremento
                ExistenciaTotal = ExistenciaAlmacen + ComprasTransito
                ExistenciaEstimada = ExistenciaTotal - NecesidadTotal


                If ExistenciaEstimada < 0 Then ExistenciaEstimada = 0


                NecesidadReal = NecesidadTotal - ExistenciaEstimada

                mEntDetalle.IDNECESIDAD = CInt(Me.lblID.Text)
                mEntDetalle.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                mEntDetalle.IDPRODUCTO = r1("IDPRODUCTO")
                mEntDetalle.IDUNIDADMEDIDA = r1("IDUNIDADMEDIDA")
                mEntDetalle.CONSUMOANUAL = ConsumoAnual
                mEntDetalle.DEMANDAINSATISFECHA = DemandaInsatisfecha
                mEntDetalle.RESERVAESTABLECIMIENTO = ReservaIncremento
                mEntDetalle.RESERVATOTAL = NecesidadTotal
                mEntDetalle.EXISTENCIAESTIMADA = ExistenciaEstimada
                mEntDetalle.COMPRASENTRANSITO = ComprasTransito
                mEntDetalle.NECESIDADAJUSTADA = CInt(NecesidadReal)
                mEntDetalle.NECESIDADFINAL = CInt(NecesidadReal)
                mEntDetalle.NECESIDADREAL = CInt(NecesidadReal)
                mEntDetalle.PRECIOUNITARIO = r1("PRECIOACTUAL")
                mEntDetalle.COSTOTOTALREAL = r1("PRECIOACTUAL") * CInt(NecesidadReal)
                mEntDetalle.COSTOTOTALAJUSTADO = r1("PRECIOACTUAL") * CInt(NecesidadReal)
                mEntDetalle.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                mEntDetalle.AUFECHACREACION = Now
                mEntDetalle.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntDetalle.AUFECHAMODIFICACION = Now
                mEntDetalle.ESTASINCRONIZADA = 0

                ConsumoAnual = 0
                consumoMensual = 0
                ConsumoPromedioMensual = 0
                DemandaInsatisfecha = 0
                DemandaMensual = 0
                ExistenciaAlmacen = 0
                ComprasTransito = 0
                PresupuestoReal = 0
                DemandaPromedioMensual = 0

                mCompDetalle.AgregarDETALLENECESIDADESTABLECIMIENTOS(mEntDetalle)
            Next r1

        End If

        If Session.Item("Nivel") = 2 Or Session.Item("Nivel") = 3 Then  ' calculo para establecimientos del 2 y 3 nivel

            For Each r1 In dsDetalle.Tables(0).Rows
                For i = 1 To 12
                    consumoMensual = mComponente.ObtenerConsumoMensualEstablecimiento(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), mes, año)
                    ConsumoAnual = ConsumoAnual + consumoMensual
                    DemandaMensual = mComponente.ObtenerDemandaMensualEstablecimiento(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), mes, año)
                    DemandaInsatisfecha = DemandaInsatisfecha + DemandaMensual

                    mes = mes - 1
                    If mes = 0 Then
                        mes = 12
                        year = year - 1
                    End If
                    año = year
                Next i

                mes = month - 1
                year = Now.Year

                If mes = 0 Then
                    mes = 12
                    year = year - 1
                End If
                año = year
                ConsumoPromedioMensual = ConsumoAnual / 12
                DemandaPromedioMensual = DemandaInsatisfecha / 12
                If PeriodoUtilizacion < 12 Then
                    ConsumoAnual = (ConsumoPromedioMensual * PeriodoUtilizacion)
                    DemandaInsatisfecha = (DemandaPromedioMensual * PeriodoUtilizacion)
                End If


                Existencianovence = mComponente.ObtenerExistenciaDisponibleNoVencida(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), fecha, fechafin)
                dsVencidos = mComponente.ObtenerExistenciaVencePlazoCompra(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), fecha, fechainicio, fechafin)

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
                ComprasTransito = mComponente.ObtenerComprasTransitoEstablecimiento(Session.Item("IdEstablecimiento"), r1("IDPRODUCTO"), fecha)

                ReservaIncremento = (ConsumoAnual + DemandaInsatisfecha) * (reserva / 100)
                NecesidadTotal = ConsumoAnual + DemandaInsatisfecha + ReservaIncremento
                ExistenciaTotal = ExistenciaAlmacen + ComprasTransito
                ExistenciaEstimada = ExistenciaTotal - NecesidadTotal

                If ExistenciaEstimada < 0 Then ExistenciaEstimada = 0



                NecesidadReal = NecesidadTotal - ExistenciaEstimada


                mEntDetalle.IDNECESIDAD = CInt(Me.lblID.Text)
                mEntDetalle.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                mEntDetalle.IDPRODUCTO = r1("IDPRODUCTO")
                mEntDetalle.IDUNIDADMEDIDA = r1("IDUNIDADMEDIDA")
                mEntDetalle.CONSUMOANUAL = ConsumoAnual
                mEntDetalle.DEMANDAINSATISFECHA = DemandaInsatisfecha
                mEntDetalle.RESERVAESTABLECIMIENTO = ReservaIncremento
                mEntDetalle.RESERVATOTAL = NecesidadTotal
                mEntDetalle.EXISTENCIAESTIMADA = ExistenciaEstimada
                mEntDetalle.COMPRASENTRANSITO = ComprasTransito
                mEntDetalle.NECESIDADAJUSTADA = CInt(NecesidadReal)
                mEntDetalle.NECESIDADFINAL = CInt(NecesidadReal)
                mEntDetalle.NECESIDADREAL = CInt(NecesidadReal)
                mEntDetalle.PRECIOUNITARIO = r1("PRECIOACTUAL")
                mEntDetalle.COSTOTOTALREAL = r1("PRECIOACTUAL") * CInt(NecesidadReal)
                mEntDetalle.COSTOTOTALAJUSTADO = r1("PRECIOACTUAL") * CInt(NecesidadReal)
                mEntDetalle.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                mEntDetalle.AUFECHACREACION = Now
                mEntDetalle.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntDetalle.AUFECHAMODIFICACION = Now
                mEntDetalle.ESTASINCRONIZADA = 0

                ConsumoAnual = 0
                consumoMensual = 0
                ConsumoPromedioMensual = 0
                DemandaInsatisfecha = 0
                Existencianovence = 0
                DemandaMensual = 0
                ExistenciaAlmacen = 0
                ComprasTransito = 0
                PresupuestoReal = 0
                DemandaPromedioMensual = 0

                mCompDetalle.AgregarDETALLENECESIDADESTABLECIMIENTOS(mEntDetalle)
            Next r1

        End If

        If Session.Item("idTipoEstablecimiento") <> "2" And Session.Item("Nivel") = 1 Then
            'SI ES UN ESTABLECIMIENTO DE PRIMER NIVEL QUE NO ES SIBASI
            MsgBox1.ShowAlert("El calculo de necesidades debe ser realizado por el Sibasi al cual pertenece", "eroorx", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.BttCalcularNecesidades.Visible = False

        Else
            If Session.Item("idTipoEstablecimiento") <> "2" And Session.Item("Nivel") = 0 Then
                'SI ES EL MSPAS o Almacen El Paraiso
                MsgBox1.ShowAlert("El calculo de necesidades debe ser realizado por un Sibasi o un hospital", "eroory", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.BttCalcularNecesidades.Visible = False

            Else
                'AL FINALIZAR CALCULO DE NECESIDADES
                Me.UcDesgloceNecesidadesEstablecimientos1.Visible = True
                Me.UcDesgloceNecesidadesEstablecimientos1.ObtenerDetalleDocumento(CInt(Me.lblID.Text))
                Me.BttCalcularNecesidades.Visible = False
                Me.UcDesgloceNecesidadesEstablecimientos1.calcular_monto()
                MsgBox1.ShowAlert("El calculo ha terminado satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.BttCalcularNecesidades.Visible = False

            End If
        End If
    End Sub

    Protected Sub UcVistaDetalleNecesidadesEstablecimientos1_Actualizado1(ByVal CODIGOENZABEZADODOCUMENTO As Integer, ByVal CODIGOSUMINISTRO As Integer) Handles UcVistaDetalleNecesidadesEstablecimientos1.Actualizado
        'EVENTO AL ACTUALIZAR LA NECESIDAD
        Me.lblID.Text = CODIGOENZABEZADODOCUMENTO
        Me.lblsuministro.Text = CODIGOSUMINISTRO

    End Sub

    Protected Sub UcDesgloceNecesidadesEstablecimientos1_GuardoDetalle() Handles UcDesgloceNecesidadesEstablecimientos1.GuardoDetalle
        'EVENTO AL MOMENTO DE GUARDAR UN PRODUCTO EN EL DETALLE
        RaiseEvent GuardoDetalle()
    End Sub

    Protected Sub UcVistaDetalleNecesidadesEstablecimientos1_ErrorEvent(ByVal errorMessage As String) Handles UcVistaDetalleNecesidadesEstablecimientos1.ErrorEvent
        RaiseEvent ErrorEvent(errorMessage)
    End Sub

    Protected Sub UcVistaDetalleNecesidadesEstablecimientos1_NumeroSolicitud(ByVal NumSolicitud As String, ByVal Presupuesto As Double, ByVal MONTO As Double) Handles UcVistaDetalleNecesidadesEstablecimientos1.NumeroSolicitud
        'EVENTO AL MOMENTO DE ASIGNAR UN NUMERO EN LA SOLICITUD

        Session.Item("idDoc") = NumSolicitud
        Me.lblID.Text = NumSolicitud
        Session.Item("presupuesto") = Me.UcVistaDetalleNecesidadesEstablecimientos1.PRESUPUESTO.Text
        Session.Item("monto") = Me.UcVistaDetalleNecesidadesEstablecimientos1.MONTO.Text
        RaiseEvent MontoSolicitud(Session.Item("monto"), Session.Item("presupuesto"))
        RaiseEvent NumeroSolicitud(NumSolicitud, Presupuesto, MONTO)
    End Sub

    Protected Sub UcVistaDetalleNecesidadesEstablecimientos1_sobrepasoPropuesta() Handles UcVistaDetalleNecesidadesEstablecimientos1.sobrepasoPropuesta
        'EVENTO AL MOMENTO DE SOBREPASAR PRESUPUESTO DE PROGRAMA DE COMPRAS
        RaiseEvent SobrepasoPropuesta()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        deshabilitarDobleClickBotones()
    End Sub

    Protected Sub deshabilitarDobleClickBotones()
        BttCalcularNecesidades.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttCalcularNecesidades, Nothing) + ";"
        BttProductos.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttProductos, Nothing) + ";"
    End Sub

    Protected Sub UcVistaDetalleNecesidadesEstablecimientos1_Suministro(ByVal idsuministro As Integer) Handles UcVistaDetalleNecesidadesEstablecimientos1.Suministro
        Me.lblsuministro.Text = idsuministro
        Me.UcDesgloceNecesidadesEstablecimientos1.ObtenerSuministro(idsuministro)
    End Sub
End Class
