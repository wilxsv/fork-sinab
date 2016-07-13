'CONTROL DE USUARIO BARRA DE NAVEGACION
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que nos permite la manipulacion de eventos sobre los registros de datos

'Importacion
Partial Class ucBarraNavegacion
    Inherits System.Web.UI.UserControl

    Public Event Guardar As EventHandler
    Public Event Agregar As EventHandler
    Public Event Editar As EventHandler
    Public Event Consultar As EventHandler
    Public Event Cancelar As EventHandler
    Public Event Eliminar As EventHandler
    Public Event Inicio As EventHandler
    Public Event Anterior As EventHandler
    Public Event Siguiente As EventHandler
    Public Event Imprimir As EventHandler
    Public Event Fin As EventHandler

    'INICIALIZCION DE PROPIEDADES
    Public Property PermitirAgregar() As Boolean
        Get
            Return Me.ibtnAgregar.Visible
        End Get
        Set(ByVal Value As Boolean)
            Me.ibtnAgregar.Visible = Value
        End Set
    End Property

    Public Property PermitirEditar() As Boolean
        Get
            Return Me.ibtnEditarCancelar.Visible
        End Get
        Set(ByVal Value As Boolean)
            Me.ibtnEditarCancelar.Visible = Value
            If Value Then
                Me.PermitirGuardar = True
            End If
        End Set
    End Property

    Public Property PermitirGuardar() As Boolean
        Get
            Return Me.ibtnGuardar.Visible
        End Get
        Set(ByVal Value As Boolean)
            Me.ibtnGuardar.Visible = Value
        End Set
    End Property

    Public Property PermitirImprimir() As Boolean
        Get
            Return Me.ibtnImprimir.Visible
        End Get
        Set(ByVal Value As Boolean)
            Me.ibtnImprimir.Visible = Value
        End Set
    End Property

    Public Property PermitirConsultar() As Boolean
        Get
            Return Me.ibtnConsultar.Visible
        End Get
        Set(ByVal Value As Boolean)
            Me.ibtnConsultar.Visible = Value
        End Set
    End Property

    Public WriteOnly Property PermitirCancelar() As Boolean
        Set(ByVal value As Boolean)
            Me.ibtnEditarCancelar.Enabled = value
            Me.ibtnEditarCancelar.Visible = value
        End Set
    End Property

    Public Property Navegacion() As Boolean
        'MUESTRAS OBJETOS PARA LA NAVEGACION DE REGISTROS
        Get
            Return True
        End Get
        Set(ByVal Value As Boolean)
            If Not Value Then
                Me.ibtnInicio.Visible = False
                Me.ibtnAnterior.Visible = False
                Me.ibtnSiguiente.Visible = False
                Me.ibtnFin.Visible = False
                Me.lblDe.Visible = False
                Me.lblRegistroActual.Visible = False
                Me.lblRegistros.Visible = False
                Me.lblTotalRegistros.Visible = False
            Else
                Me.ibtnInicio.Visible = True
                Me.ibtnAnterior.Visible = True
                Me.ibtnSiguiente.Visible = True
                Me.ibtnFin.Visible = True
                Me.lblDe.Visible = True
                Me.lblRegistroActual.Visible = True
                Me.lblRegistros.Visible = True
                Me.lblTotalRegistros.Visible = True
            End If
        End Set
    End Property

    Public Property Indice() As Integer 'INDICE DE REGISTROS
        Get
            Return CInt(Me.lblRegistroActual.Text)
        End Get
        Set(ByVal Value As Integer)
            Me.lblRegistroActual.Text = CStr(Value)
        End Set
    End Property

    Public Property Total() As Integer 'TOTAL DE REGISTROS
        Get
            Return CInt(Me.lblTotalRegistros.Text)
        End Get
        Set(ByVal Value As Integer)
            Me.lblTotalRegistros.Text = CStr(Value)
            If Value = 0 Then
                Me.Indice = 0
                Me.ibtnEditarCancelar.Enabled = False
                Me.ibtnGuardar.Enabled = False
            End If
            Me.HabilitarNavegacion()
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AL CARGAR PAGINA
        'deshabilitarDobleClickBotones()
    End Sub

    Private Sub ibtnAgregar_Click(sender As Object, e As System.EventArgs) Handles ibtnAgregar.Click
        'Evento al presionar Agregar
        Me.HabilitarEdicion(True)
        RaiseEvent Agregar(sender, e)
    End Sub

    Private Sub ibtnConsultar_Click(sender As Object, e As System.EventArgs) Handles ibtnConsultar.Click
        'Evento al presionar Consultar
        Me.HabilitarEdicion(True)
        RaiseEvent Consultar(sender, e)
    End Sub

    Private Sub ibtnEditarCancelar_Click(sender As Object, e As System.EventArgs) Handles ibtnEditarCancelar.Click
        'Evento al presionar Cancelar
        Me.HabilitarEdicion(True)
        RaiseEvent Cancelar(sender, e)
    End Sub

    Protected Sub ibtnGuardar_Click(sender As Object, e As System.EventArgs) Handles ibtnGuardar.Click
        'Evento al presionar Guardar
        RaiseEvent Guardar(sender, e)
    End Sub

   

    Protected Sub ibtnImprimir_Click(sender As Object, e As System.EventArgs) Handles ibtnImprimir.Click
        'EVENTO DEL BOTON IMPRIMIR
        RaiseEvent Imprimir(sender, e)
    End Sub

    Private Sub HabilitarNavegacion()
        'FUNCION DE HABILITACION DE NAVEGACION DE REGISTROS
        If CInt(Me.lblTotalRegistros.Text) > 1 Then
            If CInt(Me.lblRegistroActual.Text) = 1 Then
                Me.ibtnAnterior.Enabled = False
                Me.ibtnInicio.Enabled = False
                Me.ibtnSiguiente.Enabled = True
                Me.ibtnFin.Enabled = True
            End If
            If CInt(Me.lblRegistroActual.Text) = CInt(Me.lblTotalRegistros.Text) Then
                Me.ibtnAnterior.Enabled = True
                Me.ibtnInicio.Enabled = True
                Me.ibtnSiguiente.Enabled = False
                Me.ibtnFin.Enabled = False
            End If
        Else
            Me.ibtnAnterior.Enabled = False
            Me.ibtnInicio.Enabled = False
            Me.ibtnSiguiente.Enabled = False
            Me.ibtnFin.Enabled = False
        End If
    End Sub

    Public Sub HabilitarEdicion(ByVal edicion As Boolean)
        'FUNCION DE HABILITACION DEL EVENTO EDITAR
        If edicion Then
            Me.ibtnEditarCancelar.CssClass = "opCancelar"
        Else
            Me.ibtnEditarCancelar.CssClass = "opEditar"
        End If
        Me.ibtnEditarCancelar.Enabled = True
        Me.ibtnAgregar.Enabled = Not edicion
        Me.ibtnGuardar.Enabled = edicion
    End Sub

    Private Sub ibtnInicio_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnInicio.Click
        'EVENTO BOTON INICIO
        Me.Indice = 1
        RaiseEvent Inicio(sender, e)
    End Sub

    Private Sub ibtnAnterior_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnAnterior.Click
        'EVENTO BOTON ANTERIOR
        Me.Indice -= 1
        RaiseEvent Anterior(sender, e)
    End Sub

    Private Sub ibtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSiguiente.Click
        'EVENTO BOTON SIGUIENTE

        If Me.Total > Me.Indice Then
            Me.Indice += 1
            RaiseEvent Siguiente(sender, e)
        End If
    End Sub

    Private Sub ibtnFin_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnFin.Click
        'EVENTO FUNCION FIN

        Me.Indice = Me.Total
        RaiseEvent Fin(sender, e)
    End Sub

    Public Sub Consulta_ToolTip(ByVal mensaje As String)
        'ASIGNACION DE MENSAJE EN TOOL TIP DE BOTON CONSULTA
        Me.ibtnConsultar.ToolTip = mensaje
    End Sub

   

    'Protected Sub deshabilitarDobleClickBotones()
    '    'CausesValidation=true
    '    ibtnAgregar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(ibtnAgregar, Nothing) + ";"
    '    ibtnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(ibtnGuardar, Nothing) + ";"

    '    'CausesValidation=false
    '    ibtnEditarCancelar.OnClientClick = "this.disabled=true; " + Page.ClientScript.GetPostBackEventReference(ibtnEditarCancelar, Nothing) + ";"
    '    ibtnConsultar.OnClientClick = "this.disabled=true; " + Page.ClientScript.GetPostBackEventReference(ibtnConsultar, Nothing) + ";"
    'End Sub

    Public WriteOnly Property ibtnImprimirOnClientClick() As String
        Set(ByVal value As String)
            Me.ibtnImprimir.OnClientClick = value
        End Set
    End Property

    
End Class
