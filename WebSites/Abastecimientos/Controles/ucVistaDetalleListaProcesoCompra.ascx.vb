
Partial Class Controles_ucVistaDetalleListaProcesoCompra
    Inherits System.Web.UI.UserControl

    Dim EVAL_FEC_REC As Boolean
    Dim EVAL_FEC_RET As Boolean
    Dim ESTADO, IDESTABLECIMIENTO As Int64
    Friend Shared PAGINA, PAGINA_CONSULTA As String

    Public WriteOnly Property _ESTADO() As Integer
        Set(ByVal value As Integer)
            ESTADO = value
        End Set
    End Property

    Public WriteOnly Property _IDESTABLECIMIENTO() As Integer
        Set(ByVal value As Integer)
            IDESTABLECIMIENTO = value
        End Set
    End Property

    Public WriteOnly Property _PAGINA_REDIREC() As String
        Set(ByVal value As String)
            PAGINA = value
        End Set
    End Property

    Public WriteOnly Property _PAGINA_CONSULTA() As String
        Set(ByVal value As String)
            PAGINA_CONSULTA = value
        End Set
    End Property

    Public WriteOnly Property _EVAL_FEC_RET() As Boolean
        Set(ByVal value As Boolean)
            EVAL_FEC_RET = value
        End Set
    End Property

    Public WriteOnly Property _EVAL_FEC_REC() As Boolean
        Set(ByVal value As Boolean)
            EVAL_FEC_REC = value
        End Set
    End Property

    Public Sub cargarDatos(ByVal IDEMPLEADO As Integer)
        With Me.UcVistaDetalleProcesoCompra1
            .ESTADO = ESTADO
            .IDESTABLECIMIENTO = IDESTABLECIMIENTO
            .PaginaRedirect = PAGINA
            .EVAL_FEC_RET = EVAL_FEC_RET
            .EVAL_FEC_REC = EVAL_FEC_REC
            .IDENCARGADO = IDEMPLEADO
            .Consultar()
        End With
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcBarraNavegacion1.PermitirEditar = False
        Me.UcBarraNavegacion1.PermitirGuardar = False
        Me.UcBarraNavegacion1.HabilitarEdicion(False)
        Me.UcBarraNavegacion1.PermitirEditar = False
        Me.UcBarraNavegacion1.Consulta_ToolTip("Consultar Bases Entregadas")
        Me.UcBarraNavegacion1.PermitirAgregar = False
        Me.UcBarraNavegacion1.PermitirConsultar = False
        Me.UcBarraNavegacion1.PermitirImprimir = False
        Me.UcBarraNavegacion1.Navegacion = False
        'If Not IsPostBack Then
        '    Me.UcBarraNavegacion1.PermitirAgregar = False
        'End If
    End Sub

    Protected Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Agregar
        If Me.UcVistaDetalleProcesoCompra1.IDPROCESO <> 0 Then
            Response.Redirect(PAGINA & "?idProc=" & Me.UcVistaDetalleProcesoCompra1.IDPROCESO)
        End If
    End Sub

    Protected Sub UcBarraNavegacion1_Consultar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Consultar
        'If Me.UcVistaDetalleProcesoCompra1._IDPROCESO <> 0 Then
        '    Response.Redirect(PAGINA_CONSULTA & "?idProc=" & Me.UcVistaDetalleProcesoCompra1._IDPROCESO)
        'End If

    End Sub

   
End Class
