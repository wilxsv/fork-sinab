'CONTROL DE USUARIO INGRESO DE CONSUMO
'UTILIZADO EN CU-ESTA002
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que forma parte del ingreso de consumos de los establecimientos

Partial Class Controles_ucConsumo
    Inherits System.Web.UI.UserControl
    'INICIALIZACION DE VARIABLES

    'Public Event NumeroConsumo(ByVal NumConsumo As String)
    'Public Event GuardoDetalle()
    'Public Event EliminoDetalle()
    'Public Event ErrorEvent(ByVal errorMessage As String)

    ''INICIALIZACION DE PROPIEDADES

    'Public Property CODIGOENCABEZADODOCUMENTO() As Int32 ' NUMERO DE CONSUMO
    '    Get
    '        Return Me.UcVistaDetalleConsumo1.IDCONSUMO
    '    End Get
    '    Set(ByVal Value As Int32)

    '        Me.UcVistaDetalleConsumo1.IDCONSUMO = Value
    '        Me.UcDesgloceDetalleConsumo1.ObtenerDetalleDocumento(Value)
    '    End Set
    'End Property
    'Public Property Consulta() As Boolean ' SI ES UNA CONSULTA DE CONSUMO
    '    Get
    '        Return Me.UcVistaDetalleConsumo1.Enabled
    '    End Get
    '    Set(ByVal Value As Boolean)

    '        Me.UcVistaDetalleConsumo1.Enabled = Value
    '        Me.UcDesgloceDetalleConsumo1.Enabled = Value
    '        Me.BttProductos.Visible = False

    '    End Set
    'End Property
    'Public Property Nuevo() As Boolean ' SI ES UN CONSUMO NUEVO
    '    Get
    '        Return Me.UcVistaDetalleConsumo1.Enabled
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        Me.UcVistaDetalleConsumo1.Enabled = Value
    '        Me.BttProductos.Visible = True
    '        Me.UcDesgloceDetalleConsumo1.Visible = False

    '    End Set
    'End Property

    'Public Property grabado() As Boolean ' SI EL CONSUMO ESTA EN ESTADO DE GRABADO
    '    Get
    '        Return Me.UcVistaDetalleConsumo1.Enabled
    '    End Get
    '    Set(ByVal Value As Boolean)

    '        Me.UcVistaDetalleConsumo1.Enabled = Value
    '        Me.BttProductos.Visible = False
    '        Me.UcDesgloceDetalleConsumo1.Visible = True

    '    End Set
    'End Property

    'Public Function Actualizar() As String '
    '    'EVENTO ATUALIZAR UN CONSUMO

    '    Dim sError As String = ""
    '    sError = Me.UcVistaDetalleConsumo1.Actualizar()
    '    If sError <> "" Then
    '        Return sError
    '    Else
    '        RaiseEvent NumeroConsumo(Session.Item("idDoc"))
    '    End If
    '    Return Me.UcDesgloceDetalleConsumo1.Actualizar()
    'End Function

    'Protected Sub UcDesgloceDetalleConsumo1_Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Integer) Handles UcDesgloceDetalleConsumo1.Eliminado
    '    'AL ELMINAR UN PRODUCTO DEL DETALLE DE CONSUMO

    '    Me.UcVistaDetalleConsumo1.IDCONSUMO = CODIGOENZABEZADODOCUMENTO
    '    RaiseEvent EliminoDetalle()
    'End Sub

    'Protected Sub BttProductos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttProductos.Click
    '    'AL PRESIONAR EL BOTON DE AGREFGAR PRODUCTOS AL CONSUMO
    '    Actualizar()
    '    Me.UcDesgloceDetalleConsumo1.Visible = True
    '    Me.UcDesgloceDetalleConsumo1.Agregar()
    '    Me.BttProductos.Visible = False
    'End Sub

    'Protected Sub UcVistaDetalleConsumo1_ErrorEvent(ByVal errorMessage As String) Handles UcVistaDetalleConsumo1.ErrorEvent
    '    'AL MOMENTO DE OCURRIR UN EVENTO DE ERROR

    '    RaiseEvent ErrorEvent(errorMessage)

    'End Sub

    'Protected Sub UcDesgloceDetalleConsumo1_GuardoDetalle() Handles UcDesgloceDetalleConsumo1.GuardoDetalle
    '    'AL MOMENTO DE GUARDAR UN PRODUCTO EN EL DETALLE DEL CONSUMO
    '    RaiseEvent GuardoDetalle()
    'End Sub

    'Protected Sub UcVistaDetalleConsumo1_NumeroConsumo(ByVal NumConsumo As String) Handles UcVistaDetalleConsumo1.NumeroConsumo
    '    'EVENTO AL ASIGNAR NUMERO DE CONSUMO EN VISTA DETALLE
    '    Session.Item("idDoc") = NumConsumo
    'End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    deshabilitarDobleClickBotones()
    'End Sub

    'Protected Sub deshabilitarDobleClickBotones()
    '    BttProductos.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttProductos, Nothing) + ";"
    'End Sub

End Class
