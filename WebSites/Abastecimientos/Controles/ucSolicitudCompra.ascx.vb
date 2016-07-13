'CONTROL DE USUARIO SOLICITUD DE COMPRAS
'UTILIZADO EN CU-ESTA001
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que forma parte de la solicitud de productos de los establecimientos
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucSolicitudCompra
    Inherits System.Web.UI.UserControl
    'INICIALIZAR VARIABLES

    Public Event ErrorEvent(ByVal errorMessage As String)
    Public Event MontoSolicitud(ByVal MontoSolicitud As Double)
    Public Event NumeroSolicitud(ByVal NumSolicitud As String)
    Public Event GuardoDetalle()
    Public Event GuardoFuente()
    Public Event EliminoDetalle()
    Public Event EliminoFuente()
    Private mCompFuentes As New cFUENTEFINANCIAMIENTOSOLICITUDES
    Private mCompEntregas As New cENTREGASOLICITUDES
    Private mCompDetalleSolicitud As New cDETALLESOLICITUDES
    Dim montoReal As Double
    Dim montototal As Double
    Private _SUMINISTRO As Int32

    'INICIALIZAR PROPIEDADES
    Public Property CODIGOENCABEZADODOCUMENTO() As Int32 'NUMERO DE DOCUMENTO
        Get
            Return Me.UcVistaDetalleSolicitudCompras1.IDSOLICITUD
        End Get
        Set(ByVal Value As Int32)
            Me.UcVistaDetalleSolicitudCompras1.IDSOLICITUD = Value
            Me.UcDetalleFuenteFinanciamientoSolicitud1.ObtenerDetalleDocumento(Value)
            Me.UcDesgloceArticulosSolicituCompra1.ObtenerDetalleDocumento(Value)
            Me.Label_CODIGOENCABEZADODOCUMENTO.Text = Value
        End Set
    End Property

    Public Property SUMINISTRO() As Int32 'NUMERO DE DOCUMENTO
        Get
            Return Me._SUMINISTRO
        End Get
        Set(ByVal Value As Int32)
            Me._SUMINISTRO = Value
            Me.lblSuministro.Text = Value
            Me.UcDesgloceArticulosSolicituCompra1.ObtenerSuministro(Value)
        End Set
    End Property

    Public Property Nuevo() As Boolean 'NUEVA SOLICITUD
        Get
            Return Me.UcVistaDetalleSolicitudCompras1.Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me.UcVistaDetalleSolicitudCompras1.Enabled = Value
            Me.BttFuente.Visible = False
            Me.BttProductos.Visible = True
            Me.UcDesgloceArticulosSolicituCompra1.Visible = False
            Me.UcDetalleFuenteFinanciamientoSolicitud1.Visible = False
            Me.UcDesgloceArticulosSolicituCompra1.Enabled = True
        End Set
    End Property

    Public Property grabado() As Boolean 'SOLICITUD EN ESTADO DE GRABADO
        Get
            Return Me.UcVistaDetalleSolicitudCompras1.Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me.UcVistaDetalleSolicitudCompras1.Enabled = Value
            Me.UcVistaDetalleSolicitudCompras1.HabilitarSuministro(False)
            Me.BttFuente.Visible = False
            Me.BttProductos.Visible = False
            Me.UcDesgloceArticulosSolicituCompra1.Visible = True
            Me.UcDetalleFuenteFinanciamientoSolicitud1.Visible = True
            Me.UcDetalleFuenteFinanciamientoSolicitud1.PermitirAgregar = True
            Me.UcDesgloceArticulosSolicituCompra1.Enabled = Value

            montototal = mCompDetalleSolicitud.CalcularMontoTotalSolicitud(CInt(Label_CODIGOENCABEZADODOCUMENTO.Text), CInt(Session.Item("IdEstablecimiento")))
            Me.LblMonto.Text = montototal
            'Me.UcVistaDetalleSolicitudCompras1.AsignarMontoSolicitud(montototal)
        End Set
    End Property

    Public Property Consulta() As Boolean 'CONSULTA DE SOLICITUDES
        Get
            Return Me.UcVistaDetalleSolicitudCompras1.Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me.UcVistaDetalleSolicitudCompras1.Enabled = Value
            Me.UcVistaDetalleSolicitudCompras1.HabilitarSuministro(Value)
            Me.UcDesgloceArticulosSolicituCompra1.Enabled = Value
            Me.UcDetalleFuenteFinanciamientoSolicitud1.Enabled = Value
            Me.BttFuente.Visible = False
            Me.BttProductos.Visible = False
        End Set
    End Property

    Public Property Autoriza() As Boolean 'AUTORIZAR SOLICITUDES UFI
        Get
            Return Me.UcVistaDetalleSolicitudCompras1.Enabled
        End Get
        Set(ByVal Value As Boolean)

            Me.UcVistaDetalleSolicitudCompras1.Autoriza = Value
            Me.UcDesgloceArticulosSolicituCompra1.Enabled = False
            Me.UcDetalleFuenteFinanciamientoSolicitud1.Enabled = False
            Me.UcVistaDetalleSolicitudCompras1.HabilitarSuministro(False)
            Me.BttFuente.Visible = False
            Me.BttProductos.Visible = False

            montoReal = Me.mCompFuentes.CalcularMontoTotalFuenteSolicitud(Me.Label_CODIGOENCABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            Me.LblMonto.Text = montoReal
            RaiseEvent MontoSolicitud(montoReal)

        End Set
    End Property

    Public Property conjunta() As Boolean 'SOLICITUD CONJUNTA
        Get
            Return Me.UcVistaDetalleSolicitudCompras1.Enabled
        End Get
        Set(ByVal Value As Boolean)

            Me.UcVistaDetalleSolicitudCompras1.Conjunta = Not Value
            Me.UcDesgloceArticulosSolicituCompra1.HabilitarEdicionConjunta(Value)
            Me.UcDesgloceArticulosSolicituCompra1.CalcularMonto(True)
            Me.UcDesgloceArticulosSolicituCompra1.PermitirAgregar = False
            Me.UcDesgloceArticulosSolicituCompra1.PermitirEliminar = False
            Me.UcDesgloceArticulosSolicituCompra1.PermitirGuardar = True
            Me.UcDetalleFuenteFinanciamientoSolicitud1.Visible = True
            Me.UcDetalleFuenteFinanciamientoSolicitud1.PermitirAgregar = True

            Me.BttFuente.Visible = False
            Me.BttProductos.Visible = False
        End Set
    End Property

    Public Sub MostrarCamposCertificacionFondosConsulta(ByVal edicion As Boolean)
        Me.UcVistaDetalleSolicitudCompras1.MostrarCamposCertificacionFondosConsulta(edicion)
    End Sub

    Public Function Actualizar() As String
        'FUNCION DE ACTUALIZAR SOLICITUD
        Dim sError As String
        sError = Me.UcVistaDetalleSolicitudCompras1.Actualizar()
        If sError <> "" Then
            Return sError
        Else
            RaiseEvent NumeroSolicitud(Session.Item("idDoc"))
        End If

        Me.UcDesgloceArticulosSolicituCompra1.Actualizar()

    End Function

    Private Sub CalcularMonto(ByVal MONTO As Double)
        'FUNCION DE CALCULO DE MONTO TOTAL DE SOLICITUD
        Me.LblMonto.Text = MONTO
        Me.UcVistaDetalleSolicitudCompras1.AsignarMontoSolicitud(MONTO)
        Me.UcDetalleFuenteFinanciamientoSolicitud1.asignarmonto(MONTO)

        RaiseEvent MontoSolicitud(MONTO)
    End Sub

    Protected Sub UcDesgloceArticulosSolicituCompra1_AgregoDetalle1(ByVal MONTO As Double) Handles UcDesgloceArticulosSolicituCompra1.AgregoDetalle
        'AL MOMENTO DE AGREGAR UN PRODCTO A LA SOLICITUD
        Me.UcVistaDetalleSolicitudCompras1.HabilitarSuministro(False)
        Me.UcDetalleFuenteFinanciamientoSolicitud1.PermitirAgregar = True
        Me.UcDetalleFuenteFinanciamientoSolicitud1.RecalcularPorcentaje()
        CalcularMonto(MONTO)
        Me.BttFuente.Visible = True
    End Sub

    Protected Sub UcDesgloceArticulosSolicituCompra1_CalculoMonto1(ByVal MONTO As Double, ByVal flag As Boolean) Handles UcDesgloceArticulosSolicituCompra1.CalculoMonto
        'AL MOMENTO DE CALCULAR MONTO EN EL DETALLE DE LA SOLICITUD
        Me.LblMonto.Text = MONTO
        If flag = False Then
            Me.UcVistaDetalleSolicitudCompras1.AsignarMontoSolicitud(MONTO)
        End If
        RaiseEvent MontoSolicitud(MONTO)
    End Sub

    Protected Sub UcDesgloceArticulosSolicituCompra1_Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Integer) Handles UcDesgloceArticulosSolicituCompra1.Eliminado
        'AL MOMENTO DE ELIMINAR UN PRODUCTO DEL DETALLE DE LA SOLISITUD
        Me.UcVistaDetalleSolicitudCompras1.IDSOLICITUD = CODIGOENZABEZADODOCUMENTO
        Me.UcDetalleFuenteFinanciamientoSolicitud1.RecalcularPorcentaje()
        RaiseEvent EliminoDetalle()
    End Sub

    Protected Sub BttProductos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttProductos.Click
        'EVENTO AL PRESIONAR AGREGAR PRODUCTOS A LA SOLICITUD
        If Me.mCompEntregas.ValidarExistenciaEntregasSolicitud(CInt(Label_CODIGOENCABEZADODOCUMENTO.Text), CInt(Session.Item("IdEstablecimiento"))) Then
            Actualizar()
            Me.UcVistaDetalleSolicitudCompras1.CargarArbolEntregas()
            Me.UcVistaDetalleSolicitudCompras1.IMPRIMIRPROGRAMA(False)
            Me.UcDesgloceArticulosSolicituCompra1.Visible = True
            Me.UcDesgloceArticulosSolicituCompra1.Agregar()
            Me.UcDetalleFuenteFinanciamientoSolicitud1.PermitirAgregar = True
            Me.BttProductos.Visible = False
        Else
            MsgBox1.ShowAlert("Debe detallar entregas y plazos de entregas", "error6", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub BttFuente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttFuente.Click
        'EVENTO AL PRESIONAR AGREGAR FUENTES A LA SOLICITUD

        If Me.mCompEntregas.ValidarExistenciaEntregasSolicitud(CInt(Label_CODIGOENCABEZADODOCUMENTO.Text), CInt(Session.Item("IdEstablecimiento"))) Then
            Actualizar()
            Me.UcDetalleFuenteFinanciamientoSolicitud1.Visible = True
            Me.UcDetalleFuenteFinanciamientoSolicitud1.Agregar()
            Me.BttFuente.Visible = False
        Else
            MsgBox1.ShowAlert("Debe detallar entregas y plazos de entregas", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub UcVistaDetalleSolicitudCompras1_esconjunta(ByVal edicion As Boolean) Handles UcVistaDetalleSolicitudCompras1.esconjunta
        'EVENTO AL SER UNA SOLICITUD CONJUNTA
        Me.UcDesgloceArticulosSolicituCompra1.PermitirAgregar = edicion
    End Sub

    Protected Sub UcDesgloceArticulosSolicituCompra1_GuardoDetalle() Handles UcDesgloceArticulosSolicituCompra1.GuardoDetalle
        'EVENTO AL GUARDAR DETALLE DE LA SOLICITUD
        Me.UcDetalleFuenteFinanciamientoSolicitud1.RecalcularPorcentaje()
        RaiseEvent GuardoDetalle()
    End Sub

    Protected Sub UcDetalleFuenteFinanciamientoSolicitud1_Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Integer) Handles UcDetalleFuenteFinanciamientoSolicitud1.Eliminado
        'EVENTO AL ELIMINAR UNA FUENTE DE DINANCIAMIENTO DE LA SOLICITUD
        RaiseEvent EliminoFuente()
    End Sub

    Protected Sub UcDetalleFuenteFinanciamientoSolicitud1_GuardoFuente() Handles UcDetalleFuenteFinanciamientoSolicitud1.GuardoFuente
        'EVENTE AL MOMENTO DE AGREGAR UNA FUENTE DE FINANCIMAIENTO A LA SOLICITUD
        RaiseEvent GuardoFuente()
    End Sub

    Protected Sub UcVistaDetalleSolicitudCompras1_NumeroSolicitud1(ByVal NumSolicitud As String, ByVal suministro As String) Handles UcVistaDetalleSolicitudCompras1.NumeroSolicitud
        'EVENTO AL ASIGNAR NUMERO DE SOLICITUD
        Label_CODIGOENCABEZADODOCUMENTO.Text = NumSolicitud
        Me.lblSuministro.Text = suministro
        Me.UcDesgloceArticulosSolicituCompra1.ObtenerSuministro(suministro)
        Session.Item("idDoc") = NumSolicitud
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        deshabilitarDobleClickBotones()
    End Sub

    Protected Sub deshabilitarDobleClickBotones()
        BttProductos.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttProductos, Nothing) + ";"
        BttFuente.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttFuente, Nothing) + ";"
    End Sub

End Class
