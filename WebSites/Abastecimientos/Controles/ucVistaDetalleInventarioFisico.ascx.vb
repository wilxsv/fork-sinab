'INVENTARIO FISICO
'CU-ALMACEN012
'Ing. Yessenia Pennelope Henriquez Duran
'INVENTARIO FISICO DEL ESTABLECIMIENTO
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleInventarioFisico
    Inherits System.Web.UI.UserControl

    'declarar e incializar variables
    Private _IDALMACEN As Int32
    Private _IDINVENTARIO As Int32
    Private _ESTADO As Byte

    Private _Enabled As Boolean = True
    Private _sError As String
    Private _nuevo As Boolean = False
    Private _cerrado As Boolean = False
    Private _grabado As Boolean = False
    Private mComponente As New cINVENTARIO
    Private mEntidad As INVENTARIO
    Public Event actualizoInventario(ByVal idInventario As Int32, ByVal idAlmacen As Int32, ByVal idsuministro As Int32, ByVal idfuente As Int32, ByVal idRespionsabe As Int32, ByVal Cierreexistencia As Date)
    Public Event considerarInventario(ByVal fuente As Int32, ByVal repsonsable As Int32, ByVal vencidos As Int32, ByVal nodisponible As Int32)
    Public Event ErrorEvent(ByVal errorMessage As String)

    Public ReadOnly Property sError() As String 'error
        Get
            Return _sError
        End Get
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.ViewState.Remove("IDALMACEN")
            Me.ViewState.Add("IDALMACEN", value)
        End Set
    End Property

    Public Property IDINVENTARIO() As Int32 'identificador de inventario
        Get
            Return Me._IDINVENTARIO
        End Get
        Set(ByVal Value As Int32)
            Me._IDINVENTARIO = Value
            CargarDDLs()
            If Me._IDINVENTARIO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Public Property ESTADO() As Byte
        Get
            Return _ESTADO
        End Get
        Set(ByVal value As Byte)
            _ESTADO = value
            If Not Me.ViewState("ESTADO") Is Nothing Then Me.ViewState.Remove("ESTADO")
            Me.ViewState.Add("ESTADO", value)
        End Set
    End Property

    Public Property Enabled() As Boolean 'habilitado
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Public Property InventarioCerrado() As Boolean 'inventario cerrado
        Get
            Return Me._cerrado
        End Get
        Set(ByVal Value As Boolean)
            Me._cerrado = Value
            Me.HabilitarCamposCierre(Me._cerrado)
        End Set
    End Property

    Public Property InventarioGrabado() As Boolean 'inventario grabado
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina
        If Not Me.ViewState("nuevo") Is Nothing Then 'si es nuevo
            Me._nuevo = Me.ViewState("nuevo")
        End If

        If Not IsPostBack Then 'la primera vez que carga
            Me.ddlFUENTEFINANCIAMIENTOS1.Recuperar()
            Me.ddlRESPONSABLEDISTRIBUCION1.Recuperar()
            Me.ddlALMACENES1.Recuperar()
            Me.ddlSUMINISTROS1.Recuperar()
            Me.ddlALMACENES1.SelectedValue = Session.Item("IdAlmacen")
            Me.IDALMACEN = Me.ddlALMACENES1.SelectedValue
            Me.lblAlmacen.Text = Me.ddlALMACENES1.SelectedItem.Text
        End If

    End Sub

    Private Sub CargarDatos()
        'al cargar datos una vez que exista

        mEntidad = New INVENTARIO
        mEntidad.IDALMACEN = Me.IDALMACEN
        mEntidad.IDINVENTARIO = Me.IDINVENTARIO

        If mComponente.ObtenerINVENTARIO(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If

        Me.ddlALMACENES1.SelectedValue = mEntidad.IDALMACEN
        Me.lblAlmacen.Text = Me.ddlALMACENES1.SelectedItem.Text

        Me.CalendarInicio.SelectedDate = mEntidad.FECHAINICIO
        Me.CalendarFinal.SelectedDate = mEntidad.FECHACIERRE
        Me.CalendarCierreExistencias.SelectedDate = mEntidad.FECHACIERREEXISTENCIA

        If mEntidad.ESTACERRADO = 1 Then
            Me.CalendarFinal.SelectedValue = mEntidad.FECHACIERRE
            HabilitarCamposCierre(True)
        Else
            HabilitarCamposCierre(False)
        End If

        Me.ddlSUMINISTROS1.SelectedValue = mEntidad.IDSUMINISTRO

        Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue = mEntidad.IDFUENTEFINANCIAMIENTO
        Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue = mEntidad.IDRESPONSABLEDISTRIBUCION

        If mEntidad.ESTACERRADO = 1 Then Me.ChbCerrado.Checked = True
        If mEntidad.ESTACERRADO = 0 Then Me.ChbCerrado.Checked = False

        Me.ESTADO = mEntidad.ESTACERRADO

        If mEntidad.CONSIDERARFUENTE = 1 Then
            cblOpciones.Items(0).Selected = True
            ConsiderarFuenteFinanciamiento(True)
        Else
            cblOpciones.Items(0).Selected = False
            ConsiderarFuenteFinanciamiento(False)
        End If

        If mEntidad.CONSIDERARRESPONSABLE = 1 Then
            cblOpciones.Items(1).Selected = True
            ConsiderarResponsableDistribucion(True)
        Else
            cblOpciones.Items(1).Selected = False
            ConsiderarResponsableDistribucion(False)
        End If

        If mEntidad.CONSIDERARVENCIDOS = 1 Then
            cblOpciones.Items(2).Selected = True
            ConsiderarVencidos(True)
        Else
            cblOpciones.Items(2).Selected = False
            ConsiderarVencidos(False)
        End If

        If mEntidad.CONSIDERARNODISPONIBLES = 1 Then
            cblOpciones.Items(3).Selected = True
            ConsiderarNoDisponibles(True)
        Else
            cblOpciones.Items(3).Selected = False
            ConsiderarNoDisponibles(False)
        End If

        RaiseEvent actualizoInventario(Me.IDINVENTARIO, Me.IDALMACEN, Me.ddlSUMINISTROS1.SelectedValue, Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue, Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue, Me.CalendarCierreExistencias.SelectedDate)
        RaiseEvent considerarInventario(Me.cfuente.Text, Me.cResponsable.Text, Me.cVencidos.Text, Me.cNoDisponible.Text)

    End Sub

    Public Sub habilitarInventario(ByVal edicion As Boolean)
        'habilitar campos inventario
        HabilitarEdicion(edicion)
        HabilitarCamposCierre(edicion)
        Me.ddlFUENTEFINANCIAMIENTOS1.Enabled = edicion
        Me.ddlRESPONSABLEDISTRIBUCION1.Enabled = edicion
        Me.cblOpciones.Enabled = edicion
    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'habilitar campos de edicion
        Me.CalendarInicio.Enabled = edicion
        Me.CalendarCierreExistencias.Enabled = edicion
        Me.ddlSUMINISTROS1.Enabled = edicion
    End Sub

    Public Sub HabilitarCamposCierre(ByVal edicion As Boolean)
        'habilitar campos de cierre
        Me.ChbCerrado.Enabled = False
        Me.ChbCerrado.Visible = edicion
        Me.CalendarFinal.Enabled = False
        Me.CalendarFinal.Visible = edicion
        Me.lblFECHACIERRE.Visible = edicion
        Me.lblESTACERRADO.Visible = edicion
    End Sub

    Private Sub ConsiderarFuenteFinanciamiento(ByVal edicion As Boolean)
        'habilitar campos de fuente de financiamiento
        Me.ddlFUENTEFINANCIAMIENTOS1.Visible = edicion
        Me.lblIDFUENTEFINANCIAMIENTO.Visible = edicion
        If edicion Then Me.cfuente.Text = 1 Else Me.cfuente.Text = 0
    End Sub

    Private Sub ConsiderarResponsableDistribucion(ByVal edicion As Boolean)
        'habilitar campos de responsable de distribucion
        Me.ddlRESPONSABLEDISTRIBUCION1.Visible = edicion
        Me.lblIDRESPONSABLEDISTRIBUCION.Visible = edicion
        If edicion Then Me.cResponsable.Text = 1 Else Me.cResponsable.Text = 0
    End Sub

    Private Sub ConsiderarVencidos(ByVal edicion As Boolean)
        'considerar vencidos
        If edicion Then Me.cVencidos.Text = 1 Else Me.cVencidos.Text = 0
    End Sub

    Private Sub ConsiderarNoDisponibles(ByVal edicion As Boolean)
        'considerar no disponibles
        If edicion Then Me.cNoDisponible.Text = 1 Else Me.cNoDisponible.Text = 0
    End Sub

    Private Sub Nuevo() 'inventario nuevo
        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

        Me.ConsiderarFuenteFinanciamiento(False)
        Me.ConsiderarResponsableDistribucion(False)
        Me.ConsiderarVencidos(False)
        Me.ConsiderarNoDisponibles(False)
        Me.ESTADO = "0"

    End Sub

    Public Function Actualizar() As String
        'al momento de actualizar

        mEntidad = New INVENTARIO

        mEntidad.IDALMACEN = Me.IDALMACEN

        If Me._nuevo Then
            Me.IDINVENTARIO = mComponente.ObtenerID(mEntidad)
            mEntidad.IDINVENTARIO = Me.IDINVENTARIO

            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDINVENTARIO = Me.IDINVENTARIO

            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.FECHAINICIO = Me.CalendarInicio.SelectedDate
        mEntidad.FECHACIERRE = Me.CalendarFinal.SelectedDate
        mEntidad.IDSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
        mEntidad.IDFUENTEFINANCIAMIENTO = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue
        mEntidad.IDRESPONSABLEDISTRIBUCION = Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue
        mEntidad.FECHACIERREEXISTENCIA = Me.CalendarCierreExistencias.SelectedDate
        mEntidad.ESTACERRADO = Me.ESTADO 'IIf(Me.ChbCerrado.Checked, 1, 0)

        mEntidad.CONSIDERARFUENTE = Me.cfuente.Text
        mEntidad.CONSIDERARRESPONSABLE = Me.cResponsable.Text
        mEntidad.CONSIDERARVENCIDOS = Me.cVencidos.Text
        mEntidad.CONSIDERARNODISPONIBLES = Me.cNoDisponible.Text

        mEntidad.ESTASINCRONIZADA = 0

        If Me._nuevo Then
            If mComponente.AgregarINVENTARIO(mEntidad) <> 1 Then
                Return "Error al Guardar registro."
            Else
                InventarioGrabado = True
            End If
        Else
            If mComponente.ActualizarINVENTARIO(mEntidad) <> 1 Then
                Return "Error al Guardar registro."
            End If
        End If

        RaiseEvent actualizoInventario(Me.IDINVENTARIO, Me.IDALMACEN, Me.ddlSUMINISTROS1.SelectedValue, Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue, Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue, Me.CalendarCierreExistencias.SelectedDate)
        RaiseEvent considerarInventario(Me.cfuente.Text, Me.cResponsable.Text, Me.cVencidos.Text, Me.cNoDisponible.Text)
    End Function

    Public Sub CerrarInventario()
        'al momento de cerrar inventario
        mEntidad = New INVENTARIO

        mEntidad.IDINVENTARIO = Me.IDINVENTARIO
        mEntidad.IDALMACEN = Me.IDALMACEN
        mComponente.ObtenerINVENTARIO(mEntidad)
        mEntidad.FECHACIERRE = Now
        Me.CalendarFinal.SelectedDate = Now
        mEntidad.ESTACERRADO = 1 'cerrado
        Me.ChbCerrado.Checked = True
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        Me.ESTADO = 1
        mComponente.ActualizarINVENTARIO(mEntidad)

    End Sub

    Public Sub cerrarConteo()
        'al momento de cerrar conteo
        mEntidad = New INVENTARIO

        mEntidad.IDINVENTARIO = Me.IDINVENTARIO
        mEntidad.IDALMACEN = Me.IDALMACEN
        mComponente.ObtenerINVENTARIO(mEntidad)
        mEntidad.ESTACERRADO = 2 'cerrar conteo
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        Me.ESTADO = 2 'cerrar conteo
        mComponente.ActualizarINVENTARIO(mEntidad)

    End Sub

    Public Sub SeleccionOpciones()
        'al momento de seleccionar los criterios a tomar en cuenta en el inventario

        Dim Items As String
        ConsiderarFuenteFinanciamiento(False)
        ConsiderarResponsableDistribucion(False)
        ConsiderarVencidos(False)
        ConsiderarNoDisponibles(False)

        For Each l As ListItem In cblOpciones.Items
            If l.Selected Then
                Items = l.Value
                If Items = "1" Then ConsiderarFuenteFinanciamiento(True)
                If Items = "2" Then ConsiderarResponsableDistribucion(True)
                If Items = "3" Then ConsiderarVencidos(True)
                If Items = "4" Then ConsiderarNoDisponibles(True)
            End If
        Next
    End Sub

    Protected Sub cblOpciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cblOpciones.SelectedIndexChanged
        'al seleccionar criterio a tomar en cuenta en el inventario
        SeleccionOpciones()
    End Sub

    Private Sub CargarDDLs()
        Me.ddlALMACENES1.Recuperar()
        Me.ddlSUMINISTROS1.Recuperar()
        Me.ddlFUENTEFINANCIAMIENTOS1.Recuperar()
        Me.ddlRESPONSABLEDISTRIBUCION1.Recuperar()
    End Sub

End Class
