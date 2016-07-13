Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucStaClausula
    Inherits System.Web.UI.UserControl
    Private _tipoModificativa As Integer = 0
    Public Property tipoModificativa() As Integer
        Get
            Return _tipoModificativa
        End Get
        Set(ByVal value As Integer)
            _tipoModificativa = value
            If Not Me.ViewState("tipoModificativa") Is Nothing Then Me.ViewState.Remove("tipoModificativa")
            Me.ViewState.Add("tipoModificativa", value)
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("tipoModificativa") Is Nothing Then Me._tipoModificativa = Me.ViewState("tipoModificativa")
        End If
        With Me.UcBarraNavegacion1
            .PermitirAgregar = True
            .PermitirConsultar = False
            .PermitirEditar = False
            .PermitirGuardar = False
            .PermitirImprimir = False
            .HabilitarEdicion(False)
            .Navegacion = False
        End With
        If Request.QueryString("mod") <> "" Then
            tipoModificativa = Request.QueryString("mod")
        End If
        If tipoModificativa = 1 Then
            Me.Label2.Visible = True
            Me.ddlTipoClausula.Visible = True
        End If
        cargarDatos()
    End Sub

    Public Sub cargarDatos()
        Dim mComponente As New cCLAUSULAS
        Dim lEntidad As New CLAUSULAS
        Dim tipo As Integer

        If tipoModificativa = 1 Then
            tipo = Me.ddlTipoClausula.SelectedValue
        Else
            tipo = 0
        End If

        Me.dgClausula.DataSource = mComponente.ObtenerDataSetPorTipoModificativa(tipo, 0)
        Me.dgClausula.DataBind()

    End Sub

    Protected Sub dgClausula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgClausula.SelectedIndexChanged
        Dim idClausula As Integer
        idClausula = Me.dgClausula.SelectedItem.Cells(2).Text
        Response.Redirect("~/UACI/frmClausula.aspx?mod=EDIT&id=" & idClausula & "&tipoMod=" & tipoModificativa)
    End Sub

    Protected Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Agregar
        Response.Redirect("~/UACI/frmClausula.aspx?mod=NEW&tipoMod=" & tipoModificativa)
    End Sub

    Protected Sub ddlTipoClausula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoClausula.SelectedIndexChanged
        Me.cargarDatos()
    End Sub
End Class
