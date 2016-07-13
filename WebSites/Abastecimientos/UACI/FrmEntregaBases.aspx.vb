Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmEntregaBases
    Inherits System.Web.UI.Page

    Private mComponente As New cPROCESOCOMPRAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            'Me.ucBarraNavegacion1.Navegacion = False
            'Me.ucBarraNavegacion1.PermitirEditar = False
            'Me.ucBarraNavegacion1.PermitirGuardar = False
            cargardatos()
        End If

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub cargardatos()
        With Me.UcVistaDetalleListaProcesoCompra1
            ._ESTADO = 3   'TODO: Cambiar estado a 4 o el correspondiente de BASE PUBLICADA 
            ._PAGINA_REDIREC = "FrmDetaMantEntregaBases.aspx"
            ._PAGINA_CONSULTA = "FrmDetaMantEntregaBases.aspx"
            ._IDESTABLECIMIENTO = Session("IdEstablecimiento")
            ._EVAL_FEC_RET = True
            ._EVAL_FEC_REC = False
            .cargarDatos(0)
        End With
    End Sub





End Class
