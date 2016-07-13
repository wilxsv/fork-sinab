
Partial Class FrmMantIniciaProcesoCompraLG
    Inherits System.Web.UI.Page

    'Private _IDESTABLECIMIENTO As Int32
    ''Private _ucVistaListadoSolicitudCompraLG As Object

    'Public Property IDESTABLECIMIENTO() As Int32
    '    Get
    '        Return Me._IDESTABLECIMIENTO
    '    End Get
    '    Set(ByVal value As Int32)
    '        Me._IDESTABLECIMIENTO = value
    '        If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
    '        Me.ViewState.Add("IDESTABLECIMIENTO", value)
    '    End Set
    'End Property

    'Private Property ucVistaListadoSolicitudCompraLG As Object
    '    Get
    '        Return _ucVistaListadoSolicitudCompraLG
    '    End Get
    '    Set(value As Object)
    '        _ucVistaListadoSolicitudCompraLG = value
    '    End Set
    'End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.Master.ControlMenu.Visible = False

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
        End If

        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        With Me.UcVistaListadoSolicitudCompra1

            ._CRITERIO = "IDESTADO"
            ._PAGINA_REDIRECT = "FrmDetMantIniciaProcesoCompraLG.aspx"
            ._FILTRO = "7"  'TODO: el Estado debe modificarse a 5 = ENVIADA A UFI
            ._OPERADOR = "="
            '._IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .consultar()
        End With

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub




End Class
