
Partial Class Controles_ucGeneraContrato1
    Inherits System.Web.UI.UserControl

    Private _ESTADO As Integer
    Public Property ESTADO() As Integer
        Get
            Return _ESTADO
        End Get
        Set(ByVal value As Integer)
            _ESTADO = value
            If Not Me.ViewState("ESTADO") Is Nothing Then Me.ViewState.Remove("ESTADO")
            Me.ViewState.Add("ESTADO", value)
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("ESTADO") Is Nothing Then Me._ESTADO = Me.ViewState("ESTADO")
        End If
    End Sub

    Public Sub Iniciar()

        With UcVistaDetalleListaProcesoCompra1
            ._ESTADO = ESTADO
            ._EVAL_FEC_REC = False
            ._EVAL_FEC_RET = False
            ._IDESTABLECIMIENTO = Session("IdEstablecimiento")
            ._PAGINA_CONSULTA = ""
            ._PAGINA_REDIREC = ""
            .cargarDatos(Session.Item("IdEmpleado"))
        End With

    End Sub

End Class
