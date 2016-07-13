'CONTROL DE USUARIO INGRESO DE CONSUMO
'UTILIZADO EN CU-ESTA002
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que forma parte del ingreso de consumos de los establecimientos
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class Controles_ucVistaDetalleConsumo
    Inherits System.Web.UI.UserControl
    'declaracion e incializacion de variables
    'Private _IDCONSUMO As Int64
    'Private _Enabled As Boolean = True
    'Private _sError As String
    'Private _nuevo As Boolean = False
    'Protected WithEvents dsDatos As System.Data.DataSet
    'Private mComponente As New cCONSUMOS
    'Private mEntidad As New CONSUMOS
    'Private mCompEstados As New cESTADOS
    'Private mcompEmpleado As New cEMPLEADOS
    'Private mCompDetalleConsumoOrigen As New cDETALLECONSUMOS
    'Private mEntDetalleConsumoOrigen As New DETALLECONSUMOS
    'Private mCompDetalleConsumoDestino As New cDETALLECONSUMOS
    'Private mEntDetalleConsumoDestino As New DETALLECONSUMOS
    'Private mCompEstablecimientos As New cESTABLECIMIENTOS
    'Public Event NumeroConsumo(ByVal NumConsumo As String)
    'Public Event ErrorEvent(ByVal errorMessage As String)
    'Dim mes As Integer
    'Dim año As String
    'Dim Year As Integer

    'Public ReadOnly Property sError() As String 'error
    '    Get
    '        Return _sError
    '    End Get
    'End Property

    'Public Property IDCONSUMO() As Int64 'identificador de consumo
    '    Get
    '        Return Me._IDCONSUMO
    '    End Get
    '    Set(ByVal Value As Int64)
    '        Me._IDCONSUMO = Value

    '        'llenar combo año
    '        Me.DdlAño.Items.Clear()

    '        Year = mComponente.año_Consumos(Session.Item("IdEstablecimiento"))
    '        For y As Integer = Year - 2 To Year
    '            Me.DdlAño.Items.Add(y)
    '        Next y
    '        '''''

    '        If Me._IDCONSUMO > 0 Then
    '            Me.CargarDatos()
    '            habilitarCambiarEstado(False)
    '        Else
    '            Me.Nuevo()

    '            Me.DdlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")
    '            habilitarCambiarEstado(False)
    '            Me.HabilitarEdicion(Me._Enabled)
    '            Me.DdlESTABLECIMIENTOS1.SelectedValue = Session.Item("IdEstablecimiento")

    '            mes = mComponente.Mes_Consumos(Session.Item("IdEstablecimiento"), Year)

    '            If mes > 12 Then
    '                mes = mes - 12
    '                Year = Year + 1
    '                Me.DdlAño.Items.Add(Year)
    '            End If


    '            ''llenar combo mes

    '            Me.DdlMes.Items.Clear()
    '            For m As Integer = 1 To mes
    '                Me.DdlMes.Items.Add(New ListItem(MonthName(m), m))
    '            Next m


    '            Me.DdlMes.SelectedValue = mes
    '            Me.DdlAño.SelectedValue = Year
    '            Me.txtIDCONSUMO.Visible = False
    '            Me.lblIDCONSUMO.Visible = False

    '        End If

    '        If Session.Item("TipoConsumo") = "D" Then
    '            Me.CalendarDias.Visible = False
    '            Me.DdlTiempoConsumo.SelectedValue = Session.Item("TipoConsumo")
    '        Else
    '            Me.CalendarDias.Visible = False
    '            Me.DdlTiempoConsumo.SelectedValue = Session.Item("TipoConsumo")
    '        End If

    '        If mComponente.ExistenConsumosEstablecimiento(Session.Item("IdEstablecimiento")) Then
    '            Me.DdlMes.Enabled = False
    '            Me.DdlAño.Enabled = False
    '        Else
    '            Me.DdlMes.Enabled = True
    '            Me.DdlAño.Enabled = True
    '        End If
    '    End Set
    'End Property

    'Public Property Enabled() As Boolean 'habilitar
    '    Get
    '        Return Me._Enabled
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        Me._Enabled = Value
    '        Me.HabilitarEdicion(Me._Enabled)
    '    End Set
    'End Property

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'al cargar pagina
    '    Me.CalendarDias.ShowTitle = False

    '    If Not IsPostBack Then
    '        Me.DdlESTABLECIMIENTOS1.Recuperar()
    '        Me.DdlEMPLEADOS1.RecuperarCodigo()
    '        Me.DdlESTADOSCONSUMOS1.Recuperar()
    '    End If

    '    If Not Me.ViewState("nuevo") Is Nothing Then
    '        Me._nuevo = Me.ViewState("nuevo")
    '        Me.BttGenerarNuevo.Visible = False
    '    End If
    '    If Session.Item("Nivel") > 1 Then
    '        Me.CalendarDias.Enabled = False
    '        Me.CalendarDias.Visible = False
    '        Me.lblDia.Enabled = False

    '    Else
    '        Me.CalendarDias.Enabled = True
    '        Me.lblDia.Enabled = False
    '        Me.lblDia.Text = 1
    '        Me.CalendarDias.Visible = False
    '        Me.lblDia.Visible = False
    '    End If
    'End Sub

    'Sub Set_Calendar(ByVal Sender As Object, ByVal E As EventArgs)

    '    'despliega calendario mes año       
    '    Me.CalendarDias.TodaysDate = CDate("1/" & Me.DdlMes.SelectedItem.Value & "/" & Me.DdlAño.SelectedItem.Value)

    'End Sub
    'Sub Set_CalendarYear(ByVal Sender As Object, ByVal E As EventArgs)

    '    'DESPLIEGA CALENDARIO MES AÑO     
    '    Me.CalendarDias.TodaysDate = CDate("1/" & Me.DdlMes.SelectedItem.Value & "/" & Me.DdlAño.SelectedItem.Value)


    '    Dim Year1 As Integer
    '    Dim Year2 As Integer
    '    Year = mComponente.año_Consumos(Session.Item("IdEstablecimiento"))
    '    Year2 = Me.DdlAño.SelectedItem.Value

    '    If Year2 < Year1 Or Year2 > Year1 Then
    '        Me.DdlMes.Items.Clear()
    '        For m As Integer = 1 To 12
    '            Me.DdlMes.Items.Add(New ListItem(MonthName(m), m))
    '        Next m
    '    Else
    '        Me.DdlMes.Items.Clear()

    '        For m As Integer = 1 To CInt(Session.Item("mestemporal"))
    '            Me.DdlMes.Items.Add(New ListItem(MonthName(m), m))
    '        Next m
    '    End If


    'End Sub
    'Private Sub CargarDatos()

    '    'CARGAR LOS DATOS CUANDO YA EXISTE


    '    mEntidad = New CONSUMOS
    '    mEntidad.IDCONSUMO = IDCONSUMO
    '    mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

    '    If mComponente.ObtenerCONSUMOS(mEntidad) <> 1 Then

    '        RaiseEvent ErrorEvent("Error al obtener Registro.")

    '        Return
    '    End If

    '    If mEntidad.IDESTADO > 1 Then
    '        Me.BttGenerarNuevo.Visible = True
    '    Else
    '        Me.BttGenerarNuevo.Visible = False
    '    End If

    '    ''llenar combo mes
    '    Me.DdlMes.Items.Clear()
    '    For m As Integer = 1 To mEntidad.MESCONSUMO
    '        Me.DdlMes.Items.Add(New ListItem(MonthName(m), m))
    '    Next m


    '    Me.txtIDCONSUMO.Text = mEntidad.IDCONSUMO
    '    Me.DdlESTABLECIMIENTOS1.Recuperar()
    '    Me.DdlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
    '    Me.CalendarFechaIngreso.SelectedDate = IIf(Not mEntidad.FECHAINGRESO = Nothing, Format(mEntidad.FECHAINGRESO, "dd/MM/yyyy"), "")
    '    Me.DdlTiempoConsumo.SelectedValue = Session.Item("TipoConsumo")
    '    Me.DdlMes.SelectedValue = mEntidad.MESCONSUMO

    '    Me.DdlAño.SelectedValue = mEntidad.ANIOCONSUMO
    '    If Session.Item("TipoConsumo") = "D" Then 'diario
    '        Me.CalendarDias.TodaysDate = CDate(mEntidad.DIACONSUMO & "/" & Me.DdlMes.SelectedItem.Value & "/" & Me.DdlAño.SelectedItem.Value)
    '        Me.lblDia.Text = mEntidad.DIACONSUMO
    '    End If
    '    Me.DdlEMPLEADOS1.RecuperarCodigo()
    '    Me.DdlEMPLEADOS1.SelectedValue = mEntidad.IDEMPLEADO
    '    Me.DdlESTADOSCONSUMOS1.Recuperar()
    '    Me.DdlESTADOSCONSUMOS1.SelectedValue = mEntidad.IDESTADO



    'End Sub

    'Private Sub HabilitarEdicion(ByVal edicion As Boolean)
    '    'Me.DdlESTABLECIMIENTOS1.Enabled = edicion
    '    'Me.CalendarFechaIngreso.Enabled = edicion
    '    'Me.DdlTiempoConsumo.Enabled = edicion
    '    'Me.DdlMes.Enabled = edicion
    '    'Me.DdlAño.Enabled = edicion
    '    'Me.ddlDias.Enabled = edicion
    '    'Me.DdlEMPLEADOS1.Enabled = edicion
    'End Sub
    'Private Sub habilitarCambiarEstado(ByVal edicion As Boolean)
    '    'HABILITAR PODER CAMBIAR DE ESTADO
    '    Me.DdlESTADOSCONSUMOS1.Enabled = edicion
    'End Sub
    'Private Sub Nuevo()
    '    'NUEVO
    '    Me._nuevo = True
    '    If Me.ViewState("nuevo") Is Nothing Then
    '        Me.ViewState.Add("nuevo", Me._nuevo)
    '    Else
    '        Me.ViewState("nuevo") = Me._nuevo
    '    End If
    'End Sub
    'Private Sub Grabado()
    '    'GRABADO
    '    Me._nuevo = False
    '    If Me.ViewState("nuevo") Is Nothing Then
    '        Me.ViewState.Add("nuevo", Me._nuevo)
    '    Else
    '        Me.ViewState("nuevo") = Me._nuevo
    '    End If
    'End Sub

    'Public Function Actualizar() As String
    '    'AL MOMENTO DE ACTUALIZAR ENCABEZADO SOLICITUD


    '    mEntidad = New CONSUMOS


    '    If Me._nuevo Then
    '        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '        mEntidad.IDCONSUMO = mComponente.id_Consumos(mEntidad)
    '        Session.Item("idDoc") = mEntidad.IDCONSUMO
    '        Me.txtIDCONSUMO.Text = mEntidad.IDCONSUMO
    '        Me.txtIDCONSUMO.Visible = True
    '        Me.lblIDCONSUMO.Visible = True

    '    Else
    '        mEntidad.IDCONSUMO = CInt(Me.txtIDCONSUMO.Text)
    '        mEntidad.IDESTABLECIMIENTO = Me.DdlESTABLECIMIENTOS1.SelectedValue
    '    End If


    '    mEntidad.FECHAINGRESO = Me.CalendarFechaIngreso.SelectedDate
    '    mEntidad.MESCONSUMO = CInt(Me.DdlMes.SelectedValue)
    '    mEntidad.ANIOCONSUMO = CInt(Me.DdlAño.SelectedItem.Value)

    '    mEntidad.DIACONSUMO = Me.lblDia.Text
    '    mEntidad.IDEMPLEADO = Me.DdlEMPLEADOS1.SelectedValue
    '    mEntidad.IDESTADO = Me.DdlESTADOSCONSUMOS1.SelectedValue

    '    If mEntidad.AUUSUARIOCREACION = Nothing Then
    '        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '    End If
    '    If mEntidad.AUFECHACREACION = Nothing Then
    '        mEntidad.AUFECHACREACION = Now()
    '    End If
    '    mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '    mEntidad.AUFECHAMODIFICACION = Now()
    '    mEntidad.ESTASINCRONIZADA = 0


    '    If Me.CalendarDias.TodaysDate > DateTime.Now.Date And Session.Item("TipoConsumo") = "D" Then
    '        RaiseEvent ErrorEvent("el dia y el mes de consumo no pueden ser mayor a la fecha actual")
    '    Else

    '        If CInt(Me.DdlMes.SelectedValue) >= DateTime.Now.Month And CInt(Me.DdlAño.SelectedValue) >= DateTime.Now.Year And Session.Item("TipoConsumo") = "M" Then
    '            RaiseEvent ErrorEvent("El mes de ingreso de consumo no puede ser mayor al mes en curso")
    '        Else
    '            If Me._nuevo Then
    '                If mComponente.AgregarConsumos(mEntidad) <> 1 Then
    '                    Return "Error al Guardar registro."
    '                Else
    '                    Me.Grabado()
    '                    RaiseEvent NumeroConsumo(Session.Item("idDoc"))
    '                End If
    '            Else
    '                If mComponente.ActualizarCONSUMOS(mEntidad) <> 1 Then
    '                    Return "Error al Guardar registro."
    '                Else
    '                    RaiseEvent NumeroConsumo(Me.txtIDCONSUMO.Text)
    '                End If
    '            End If
    '        End If
    '    End If


    'End Function

    'Protected Sub BttGenerarNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttGenerarNuevo.Click
    '    'al momento de seleccionar generar nuevo en base a uno anterior


    '    Dim codigoNuevoConsumo As Integer
    '    Dim codigoBaseConsumo As Integer


    '    Dim i As Integer

    '    codigoBaseConsumo = Me.txtIDCONSUMO.Text
    '    mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '    codigoNuevoConsumo = mComponente.id_Consumos(mEntidad)
    '    mEntidad.IDCONSUMO = codigoNuevoConsumo
    '    Me.lblid.Text = codigoNuevoConsumo

    '    mEntidad.FECHAINGRESO = Me.CalendarFechaIngreso.SelectedDate

    '    Year = mComponente.año_Consumos(Session.Item("IdEstablecimiento"))
    '    mes = mComponente.Mes_Consumos(Session.Item("IdEstablecimiento"), Year)

    '    If mes > 12 Then
    '        mes = mes - 12
    '        Year = Year + 1
    '        Me.DdlAño.Items.Add(Year)
    '    End If

    '    If mes >= DateTime.Now.Month And Year >= DateTime.Now.Year And Session.Item("TipoConsumo") = "M" Then
    '        RaiseEvent ErrorEvent("El mes de ingreso de consumo no puede ser mayor al mes en curso")
    '    Else


    '        mEntidad.MESCONSUMO = mes
    '        mEntidad.ANIOCONSUMO = Year
    '        If Session.Item("TipoConsumo") = "D" Then

    '            mEntidad.DIACONSUMO = Me.lblDia.Text
    '        Else
    '            mEntidad.DIACONSUMO = 1
    '        End If
    '        mEntidad.IDEMPLEADO = Me.DdlEMPLEADOS1.SelectedValue
    '        mEntidad.IDESTADO = 1
    '        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '        mEntidad.AUFECHACREACION = Now()
    '        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '        mEntidad.AUFECHAMODIFICACION = Now()
    '        mEntidad.ESTASINCRONIZADA = 0
    '        mComponente.AgregarConsumos(mEntidad)

    '        Dim dsDetalle As DataSet
    '        dsDetalle = mCompDetalleConsumoOrigen.ObtenerDataSetPorId(Session.Item("IdEstablecimiento"), codigoBaseConsumo)

    '        For i = 0 To (dsDetalle.Tables(0).Rows.Count - 1)

    '            mEntDetalleConsumoDestino.IDCONSUMO = codigoNuevoConsumo
    '            mEntDetalleConsumoDestino.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '            mEntDetalleConsumoDestino.IDDETALLE = mCompDetalleConsumoDestino.IdDetalleConsumo(mEntDetalleConsumoDestino)
    '            mEntDetalleConsumoDestino.IDPRODUCTO = dsDetalle.Tables(0).Rows(i).Item("IDPRODUCTO")
    '            mEntDetalleConsumoDestino.IDUNIDADMEDIDA = dsDetalle.Tables(0).Rows(i).Item("IDUNIDADMEDIDA")
    '            mEntDetalleConsumoDestino.CANTIDADCONSUMIDA = dsDetalle.Tables(0).Rows(i).Item("CANTIDADCONSUMIDA")
    '            mEntDetalleConsumoDestino.DEMANDAINSATISFECHA = dsDetalle.Tables(0).Rows(i).Item("DEMANDAINSATISFECHA")
    '            mEntDetalleConsumoDestino.EXISTENCIAACTUAL = dsDetalle.Tables(0).Rows(i).Item("EXISTENCIAACTUAL")
    '            mEntDetalleConsumoDestino.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '            mEntDetalleConsumoDestino.AUFECHACREACION = Now()
    '            mEntDetalleConsumoDestino.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '            mEntDetalleConsumoDestino.AUFECHAMODIFICACION = Now()
    '            mEntDetalleConsumoDestino.ESTASINCRONIZADA = 0
    '            mCompDetalleConsumoDestino.AgregarDETALLECONSUMOS(mEntDetalleConsumoDestino)
    '        Next i

    '        Response.Redirect("~/ESTABLECIMIENTOS/FrmDetaMantConsumos.aspx?id= " + Me.lblid.Text & "&estado= 1")
    '        HabilitarEdicion(True)
    '        habilitarCambiarEstado(False)
    '        Me.BttGenerarNuevo.Visible = False
    '    End If
    'End Sub
End Class
