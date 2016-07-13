'CALCULO DE NECESIDADES ESTABLECIMIENTO
'CU-ESTA0003
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario encabezado de calculo de necesidades
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Controles_ucVistaDetalleNecesidadesEstablecimientos
    Inherits System.Web.UI.UserControl
    'declaracion e incializacion de variables
    Private _IDNECESIDAD As Int32
    Private _Enabled As Boolean = True
    Private _sError As String
    Private _nuevo As Boolean = False
    Private _grabado As Boolean = False
    Protected WithEvents dsDatos As System.Data.DataSet
    Public Event Actualizado(ByVal CODIGOENZABEZADODOCUMENTO As Int32, ByVal CODIGOSUMINISTRO As Int32)
    Private mComponente As New cNECESIDADESTABLECIMIENTOS
    Private mEntidad As New NECESIDADESTABLECIMIENTOS
    Private mEntEstablecimientos As New ESTABLECIMIENTOS
    Private mCompEstablecimientos As New cESTABLECIMIENTOS
    Private mEntEmpleados As New EMPLEADOS
    Private mCompEmpleados As New cEMPLEADOS
    Dim año As String
    Dim propuesta As Integer
    Dim mes As Integer
    Dim m2 As Integer
    Dim Year, Year2 As Integer
    Public Event ErrorEvent(ByVal errorMessage As String)
    Public Event Suministro(ByVal idsuministro As Integer)
    Public Event sobrepasoPropuesta()
    Public Event NumeroSolicitud(ByVal NumSolicitud As String, ByVal Presupuesto As Double, ByVal MONTO As Double)

    Public ReadOnly Property sError() As String 'error
        Get
            Return _sError
        End Get
    End Property
    Public ReadOnly Property PRESUPUESTO() As TextBox 'presupuesto aignado
        Get
            Return Me.txtPRESUPUESTOASIGNADO
        End Get
    End Property
    Public ReadOnly Property MONTO() As TextBox 'monto asignado
        Get
            Return Me.txtMONTONECESIDADAJUSTADA
        End Get
    End Property
    Public Property IDNECESIDAD() As Int32 'identificador de programa de compras
        Get
            Return Me._IDNECESIDAD
        End Get
        Set(ByVal Value As Int32)
            Me._IDNECESIDAD = Value
            If Me._IDNECESIDAD > 0 Then
                Me.CargarDatos()
                habilitarCambiarEstado(False)
            Else
                Me.Nuevo()
                inicializarNuevo()
            End If
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Private Sub inicializarNuevo() 'al momento de un nuevo progrma de compras
        habilitarCambiarEstado(False)
        Me.HabilitarEdicion(Me._Enabled)
        Me.txtPRESUPUESTOASIGNADO.Text = "0"
        Me.txtMONTONECESIDADREAL.Text = "0"
        Me.txtMONTONECESIDADAJUSTADA.Text = "0"
        Me.DdlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")

        Me.DdlESTABLECIMIENTOS1.SelectedValue = Session.Item("IdEstablecimiento")
        mEntEstablecimientos.IDESTABLECIMIENTO = CInt(Session.Item("IdEstablecimiento"))
        mCompEstablecimientos.ObtenerESTABLECIMIENTOS(mEntEstablecimientos)
        Me.TxtNivel.Text = mEntEstablecimientos.NIVEL

        mEntidad.IDESTABLECIMIENTO = CInt(Session.Item("IdEstablecimiento"))
        año = DateTime.Now.ToString("yyyy")
        Me.lblaño.Text = año

        Me.DdlPeriodoUtilizacion.SelectedValue = 12

        ''llenar combo mes y año inicial
        llenarmesanioinicialNuevo()
        ''llenar combo mes Final
        llenarmesfinalNuevo()
        ''''''
        mEntidad.ANIOFINPERIODO = Me.DdlAñoFinal.SelectedValue
        propuesta = mComponente.ObtenerPropuesta(mEntidad)
        If propuesta <= 3 Then  'Verificacion de numeros de propuesta
            Me.ddlPropuesta.SelectedValue = propuesta
        Else
            RaiseEvent sobrepasoPropuesta()
        End If
    End Sub
    Private Sub llenarmesanioinicialNuevo()
        'llena combos de año y mes al ser un programa de compras nuevo
        Year = DateTime.Now.Year

        mes = DateTime.Now.Month

        Me.ddlAñoInicio.Items.Clear()
        Me.DdlAñoFinal.Items.Clear()
        Me.DdlMesInicio.Items.Clear()
        Me.ddlMesFinal.Items.Clear()

        If mes = 12 Then
            Me.ddlAñoInicio.Items.Add(Year + 1)
            For m As Integer = 1 To 11
                Me.DdlMesInicio.Items.Add(New ListItem(MonthName(m), m))
            Next m

        Else
            Me.ddlAñoInicio.Items.Add(Year)
            For m As Integer = (mes + 1) To 12
                Me.DdlMesInicio.Items.Add(New ListItem(MonthName(m), m))
            Next m
        End If

    End Sub

    Private Sub llenarmesfinalNuevo() 'una vez seleecionado mes inicial llena mes final
        m2 = Me.DdlMesInicio.SelectedValue
        m2 = m2 + Val(Me.DdlPeriodoUtilizacion.SelectedValue) - 1

        If m2 > 12 Then
            m2 = m2 - 12
            Me.ddlMesFinal.Items.Add(New ListItem(MonthName(m2), m2))
            Year2 = Val(Me.ddlAñoInicio.SelectedValue) + 1
            Me.DdlAñoFinal.Items.Clear()
            Me.DdlAñoFinal.Items.Add(Year2)

        Else
            Year2 = Me.ddlAñoInicio.SelectedValue
            Me.ddlMesFinal.Items.Add(New ListItem(MonthName(m2), m2))
            Me.DdlAñoFinal.Items.Clear()
            Me.DdlAñoFinal.Items.Add(Year2)

        End If

    End Sub
    Public Property Enabled() As Boolean 'habilita edicion
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina
        If Not IsPostBack Then 'la primera vez que carga
            Me.DdlALMACENES1.RecuperarAlmacenEstablecimiento(CInt(Session.Item("IdEstablecimiento")))
            Me.DdlSUMINISTROS1.RecuperarListaFiltrada(1)
            Me.DdlESTADOSNECESIDADES1.Recuperar()
            Me.DdlESTABLECIMIENTOS1.RecuperarCodigoEstablecimiento()
            Me.DdlEMPLEADOS1.RecuperarNombreCompletoXEstablecimiento(CInt(Session.Item("IdEstablecimiento")))
        End If

        moneda(True)

        If Not Me.ViewState("nuevo") Is Nothing Then
            Me._nuevo = Me.ViewState("nuevo")

        End If

    End Sub
    Private Sub iniciarmesanio()
        'mes y año inicial de trabajo
        Year = Val(mEntidad.ANIOINICIOPERIODO)
        mes = Val(mEntidad.MESINICIOPERIODO)

        Me.ddlAñoInicio.Items.Clear()
        Me.DdlAñoFinal.Items.Clear()
        Me.DdlMesInicio.Items.Clear()
        Me.ddlMesFinal.Items.Clear()

        If mes = 12 Then
            Me.ddlAñoInicio.Items.Add(Year + 1)
            For m As Integer = 1 To 11
                Me.DdlMesInicio.Items.Add(New ListItem(MonthName(m), m))
            Next m

        Else
            Me.ddlAñoInicio.Items.Add(Year)
            For m As Integer = (mes) To 12
                Me.DdlMesInicio.Items.Add(New ListItem(MonthName(m), m))
            Next m
        End If

        '''''
    End Sub
    Private Sub CargarDatos()
        'carga datos si ya esta grabada
        mEntidad = New NECESIDADESTABLECIMIENTOS
        mEntidad.IDNECESIDAD = IDNECESIDAD
        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

        If mComponente.ObtenerNECESIDADESTABLECIMIENTOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            MsgBox1.ShowAlert("Error al obtener registro", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return
        End If

        If mEntidad.IDESTADO > 1 Then
            HabilitarEdicion(False)
            habilitarCambiarEstado(False)

        End If
        ''llenar combo mes y año inicial

        iniciarmesanio()


        Me.DdlESTABLECIMIENTOS1.RecuperarCodigoEstablecimiento()
        Me.DdlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
        Me.txtIDNECESIDAD.Text = mEntidad.IDNECESIDAD
        Session.Item("idDoc") = mEntidad.IDNECESIDAD
        Me.ddlPropuesta.SelectedValue = mEntidad.PROPUESTA
        Me.txtCORRELATIVO.Text = mEntidad.CORRELATIVO
        Me.DdlESTADOSNECESIDADES1.Recuperar()
        Me.DdlESTADOSNECESIDADES1.SelectedValue = mEntidad.IDESTADO
        Me.CalendarFecha.SelectedDate = IIf(Not mEntidad.FECHAELABORACION = Nothing, Format(mEntidad.FECHAELABORACION, "dd/MM/yyyy"), "")
        Me.DdlPeriodoUtilizacion.SelectedValue = mEntidad.PERIODOUTILIZACION

        Me.DdlAñoFinal.Items.Clear()
        Me.ddlMesFinal.Items.Clear()
        Me.DdlAñoFinal.Items.Add(mEntidad.ANIOFINPERIODO)
        Me.ddlMesFinal.Items.Add(New ListItem(MonthName(mEntidad.MESFINPERIODO), mEntidad.MESFINPERIODO))

        Me.DdlMesInicio.SelectedValue = mEntidad.MESINICIOPERIODO
        Me.ddlAñoInicio.SelectedValue = mEntidad.ANIOINICIOPERIODO

        Me.lblaño.Text = Me.DdlAñoFinal.SelectedValue

        Me.ddlMesFinal.SelectedValue = mEntidad.MESFINPERIODO
        Me.DdlAñoFinal.SelectedValue = mEntidad.ANIOFINPERIODO

        Me.DdlEMPLEADOS1.RecuperarNombreCompletoXEstablecimiento(CInt(Session.Item("IdEstablecimiento")))
        Me.DdlEMPLEADOS1.SelectedValue = mEntidad.IDEMPLEADO
        Me.DdlALMACENES1.Recuperar()
        Me.DdlALMACENES1.SelectedValue = mEntidad.IDALMACENENTREGA
        Me.DdlSUMINISTROS1.RecuperarListaFiltrada(1)
        Me.DdlSUMINISTROS1.SelectedValue = mEntidad.IDSUMINISTRO
        Me.DdlSUMINISTROS1.Enabled = False
        RaiseEvent Suministro(Me.DdlSUMINISTROS1.SelectedValue)
        Me.txtPRESUPUESTOASIGNADO.Text = mEntidad.PRESUPUESTOASIGNADO

        Me.txtMONTONECESIDADREAL.Text = mEntidad.MONTONECESIDADREAL
        Me.txtMONTONECESIDADAJUSTADA.Text = mEntidad.MONTONECESIDADAJUSTADA

        Me.txtOBSERVACION.Text = mEntidad.OBSERVACION
        Datos()
    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'habilita los camppos de edicion
        Me.txtCORRELATIVO.Enabled = edicion

        Me.DdlPeriodoUtilizacion.Enabled = edicion
        Me.DdlMesInicio.Enabled = edicion
        Me.ddlAñoInicio.Enabled = edicion
        Me.DdlALMACENES1.Enabled = edicion
        Me.txtPRESUPUESTOASIGNADO.Enabled = edicion
        Me.txtOBSERVACION.Enabled = edicion
    End Sub
    Private Sub habilitarCambiarEstado(ByVal edicion As Boolean)
        'habilita los campos para permitir cambiar de estado
        Me.DdlESTADOSNECESIDADES1.Enabled = edicion
    End Sub
    Private Sub Nuevo()
        'si es nuevo registro
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

    End Sub

    Public Property Grabado() As Boolean 'si esta grabado
        Get
            Return Me._grabado
        End Get
        Set(ByVal Value As Boolean)
            Me._grabado = Value
            Me._nuevo = Not Value
            If Me._grabado Then
                Me.ViewState("nuevo") = Me._nuevo
            End If
        End Set
    End Property

    Public Function Actualizar() As String

        'funcion de actualizar encabezado de programa de compra
        Dim añofin, añoinicio As Integer

        mEntidad = New NECESIDADESTABLECIMIENTOS
        añofin = Me.DdlAñoFinal.SelectedValue
        añoinicio = Me.ddlAñoInicio.SelectedValue

        If Me._nuevo Then 'si es nuevo

            añofin = Me.DdlAñoFinal.SelectedValue
            mEntidad.ANIOINICIOPERIODO = Me.ddlAñoInicio.SelectedValue
            mEntidad.ANIOFINPERIODO = Me.DdlAñoFinal.SelectedValue
            Me.lblaño.Text = Me.DdlAñoFinal.SelectedValue
            mEntidad.IDESTABLECIMIENTO = Me.DdlESTABLECIMIENTOS1.SelectedValue
            mEntidad.IDNECESIDAD = mComponente.ObtenerID(mEntidad)
            Session.Item("idDoc") = mEntidad.IDNECESIDAD
            Me.txtIDNECESIDAD.Text = mEntidad.IDNECESIDAD
            Me.txtCORRELATIVO.Text = mComponente.ObtenerCorrelativo(mEntidad)
            mEntidad.CORRELATIVO = Me.txtCORRELATIVO.Text

            propuesta = mComponente.ObtenerPropuesta(mEntidad)

            If propuesta <= 3 Then 'verificacion de numero de propuesta
                Me.ddlPropuesta.SelectedValue = propuesta
                mEntidad.PROPUESTA = Me.ddlPropuesta.SelectedValue
            Else

                MsgBox1.ShowAlert("Ha sobrepasado numero de propuestas del periodo", "error4", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                RaiseEvent ErrorEvent("Error al guardar Registro.")
                Return "Error al Guardar registro."

            End If
        Else 'si ya existe
            mEntidad.IDNECESIDAD = CInt(Me.txtIDNECESIDAD.Text)
            mEntidad.IDESTABLECIMIENTO = Me.DdlESTABLECIMIENTOS1.SelectedValue
            mEntidad.CORRELATIVO = Me.txtCORRELATIVO.Text
            mEntidad.ANIOINICIOPERIODO = Me.ddlAñoInicio.SelectedValue

            If Me.lblaño.Text = añofin Then
                mEntidad.ANIOFINPERIODO = Me.DdlAñoFinal.SelectedValue
                mEntidad.PROPUESTA = Me.ddlPropuesta.SelectedValue
            Else
                mEntidad.ANIOFINPERIODO = Me.DdlAñoFinal.SelectedValue
                propuesta = mComponente.ObtenerPropuesta(mEntidad)

                If propuesta <= 3 Then
                    Me.ddlPropuesta.SelectedValue = propuesta
                    mEntidad.PROPUESTA = Me.ddlPropuesta.SelectedValue
                Else
                    MsgBox1.ShowAlert("Ha sobrepasado numero de propuestas del periodo", "error3", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    RaiseEvent ErrorEvent("Error al guardar Registro.")
                    Return "Error al Guardar registro."
                End If
            End If
        End If

        moneda(False)
        'campos comunes para nuevo o existente programa de compra
        mEntidad.IDESTADO = Me.DdlESTADOSNECESIDADES1.SelectedValue
        mEntidad.FECHAELABORACION = Me.CalendarFecha.SelectedDate
        mEntidad.PERIODOUTILIZACION = Me.DdlPeriodoUtilizacion.SelectedValue
        mEntidad.MESINICIOPERIODO = Me.DdlMesInicio.SelectedValue
        mEntidad.MESFINPERIODO = Me.ddlMesFinal.SelectedValue
        mEntidad.ANIOFINPERIODO = Me.DdlAñoFinal.SelectedValue
        mEntidad.IDEMPLEADO = Me.DdlEMPLEADOS1.SelectedValue
        If Me.DdlALMACENES1.SelectedValue = Nothing Or Me.DdlALMACENES1.SelectedValue Is DBNull.Value Then
            RaiseEvent ErrorEvent("No se puede completar operacion porque no existe almacenes de entrega asociado a este establecimiento")
        Else
            mEntidad.IDALMACENENTREGA = Me.DdlALMACENES1.SelectedValue
        End If

        mEntidad.IDSUMINISTRO = Me.DdlSUMINISTROS1.SelectedValue
        mEntidad.MONTONECESIDADREAL = Me.txtMONTONECESIDADREAL.Text
        mEntidad.MONTONECESIDADAJUSTADA = Me.txtMONTONECESIDADAJUSTADA.Text
        mEntidad.PRESUPUESTOASIGNADO = Me.txtPRESUPUESTOASIGNADO.Text
        mEntidad.OBSERVACION = Me.txtOBSERVACION.Text
        If mEntidad.AUUSUARIOCREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0

        'actualizar
        If CDbl(Me.txtPRESUPUESTOASIGNADO.Text) >= CDbl(Me.txtMONTONECESIDADAJUSTADA.Text) Then

            If Me.DdlALMACENES1.SelectedValue = Nothing Or Me.DdlALMACENES1.SelectedValue Is DBNull.Value Then
                'no hay almacen asociado al establecimiento
            Else

                If Me._nuevo Then
                    If mComponente.AgregarNECESIDADESTABLECIMIENTOS(mEntidad) <> 1 Then
                        moneda(True)
                        RaiseEvent ErrorEvent("Error al guardar Registro.")
                        Return "Error al Guardar registro."
                    Else
                        Grabado = True
                        RaiseEvent Suministro(Me.DdlSUMINISTROS1.SelectedValue)
                        Me.DdlSUMINISTROS1.Enabled = False
                        Me.DdlPeriodoUtilizacion.Enabled = False
                    End If
                Else
                    If mComponente.ActualizarNECESIDADESTABLECIMIENTOS(mEntidad) <> 1 Then
                        moneda(True)
                        RaiseEvent ErrorEvent("Error al guardar Registro.")
                        Return "Error al Guardar registro."
                    Else
                        RaiseEvent Suministro(Me.DdlSUMINISTROS1.SelectedValue)
                    End If
                End If

            End If

        End If
        RaiseEvent NumeroSolicitud(Me.txtIDNECESIDAD.Text, Me.txtPRESUPUESTOASIGNADO.Text, Me.txtMONTONECESIDADAJUSTADA.Text)
        RaiseEvent Actualizado(CInt(Session.Item("idDoc")), Me.DdlSUMINISTROS1.SelectedValue)
        moneda(True)
        Return ""
    End Function
    Private Sub Datos() 'obtiene el nivel del establecimiento
        mEntEstablecimientos.IDESTABLECIMIENTO = Me.DdlESTABLECIMIENTOS1.SelectedValue
        mCompEstablecimientos.ObtenerESTABLECIMIENTOS(mEntEstablecimientos)
        Me.TxtNivel.Text = mEntEstablecimientos.NIVEL
    End Sub
    Public Sub moneda(ByVal edicion As Boolean) 'habilita el signo de moneda a los campos
        Me.txtMONTONECESIDADREAL.AutoFormatCurrency = edicion
        Me.txtMONTONECESIDADAJUSTADA.AutoFormatCurrency = edicion
        Me.txtPRESUPUESTOASIGNADO.AutoFormatCurrency = edicion
    End Sub

    Public Sub AsignarMontoNecesidad(ByVal MontoReal As Double, ByVal MontoAjustado As Double)
        'asigna el calculo del monto al encabezado del programa de compra
        mEntidad = New NECESIDADESTABLECIMIENTOS
        Dim cEntidad As New cNECESIDADESTABLECIMIENTOS

        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntidad.IDNECESIDAD = CInt(Me.txtIDNECESIDAD.Text)
        cEntidad.ObtenerNECESIDADESTABLECIMIENTOS(mEntidad)
        mEntidad.MONTONECESIDADREAL = MontoReal
        mEntidad.MONTONECESIDADAJUSTADA = MontoAjustado

        Me.txtMONTONECESIDADREAL.Text = MontoReal
        Me.txtMONTONECESIDADAJUSTADA.Text = MontoAjustado

        If mEntidad.AUUSUARIOCREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0
        mComponente.ActualizarNECESIDADESTABLECIMIENTOS(mEntidad)


    End Sub

    Protected Sub DdlALMACENES1_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlALMACENES1.ErrorEvent
        'al ocurrir un error
        MsgBox1.ShowAlert("No existe almacenes para este establecimiento", "error2", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub DdlMesInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlMesInicio.SelectedIndexChanged
        ''llenar combo mes Final cuando se seleciona mes inicial
        Me.ddlMesFinal.Items.Clear()

        m2 = Me.DdlMesInicio.SelectedValue
        m2 = m2 + Val(Me.DdlPeriodoUtilizacion.SelectedValue) - 1

        If m2 > 12 Then
            m2 = m2 - 12
            Me.ddlMesFinal.Items.Add(New ListItem(MonthName(m2), m2))
            Year2 = Me.ddlAñoInicio.SelectedValue + 1
            Me.DdlAñoFinal.Items.Clear()
            Me.DdlAñoFinal.Items.Add(Year2)

        Else
            Me.ddlMesFinal.Items.Add(New ListItem(MonthName(m2), m2))

        End If

        ''''''
    End Sub

    Protected Sub DdlPeriodoUtilizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlPeriodoUtilizacion.SelectedIndexChanged
        ''llenar combo mes Final cuado se seleccione periodo
        Me.ddlMesFinal.Items.Clear()

        m2 = Me.DdlMesInicio.SelectedValue
        m2 = m2 + Val(Me.DdlPeriodoUtilizacion.SelectedValue) - 1

        If m2 > 12 Then
            m2 = m2 - 12
            Me.ddlMesFinal.Items.Add(New ListItem(MonthName(m2), m2))
            Year2 = Val(Me.ddlAñoInicio.SelectedValue) + 1
            Me.DdlAñoFinal.Items.Clear()
            Me.DdlAñoFinal.Items.Add(Year2)

        Else
            Year2 = Me.ddlAñoInicio.SelectedValue
            Me.ddlMesFinal.Items.Add(New ListItem(MonthName(m2), m2))
            Me.DdlAñoFinal.Items.Clear()
            Me.DdlAñoFinal.Items.Add(Year2)

        End If

        ''''''
    End Sub
End Class
