Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucCreaPlantillaContrato
    Inherits System.Web.UI.UserControl
    Private _tipoPlantilla As Integer
    Public Property tipoPlantilla() As Integer
        Get
            Return _tipoPlantilla
        End Get
        Set(ByVal value As Integer)
            _tipoPlantilla = value
            If Not Me.ViewState("tipoPlantilla") Is Nothing Then Me.ViewState.Remove("tipoPlantilla")
            Me.ViewState.Add("tipoPlantilla", value)
        End Set
    End Property
    Public Sub cargarDatos()

        If Not IsPostBack Then
            Me.DdlTIPOCOMPRAS1.Recuperar()
            Me.DdlSUMINISTROS1.Recuperar()
        End If

        UcBarraNavegacion1.Navegacion = False
        With UcBarraNavegacion1
            .PermitirConsultar = False
            .PermitirEditar = False
            .PermitirGuardar = False
            .PermitirImprimir = False
            .HabilitarEdicion(False)
            .Navegacion = False
        End With

        Dim mComponente As New cPLANTILLASCONTRATO
        Dim ds As Data.DataSet

        tipoPlantilla = Request.QueryString("mod")

        If tipoPlantilla = 1 Then
            Label1.Text = "Listado de plantillas para modificativa"
        End If

        ds = mComponente.ObtenerPLANTILLASCONTRATO(Session("IdEstablecimiento"), Me.DdlTIPOCOMPRAS1.SelectedValue, Me.DdlSUMINISTROS1.SelectedValue, tipoPlantilla)

        Me.dgPlantilla.DataSource = ds
        Me.dgPlantilla.DataBind()

    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Dim mComponente As New cPLANTILLASCONTRATO
        Dim ds As Data.DataSet

        ds = mComponente.ObtenerPLANTILLASCONTRATO(Session("IdEstablecimiento"), Me.DdlTIPOCOMPRAS1.SelectedValue, Me.DdlSUMINISTROS1.SelectedValue, tipoPlantilla)

        Me.dgPlantilla.DataSource = ds
        Me.dgPlantilla.DataBind()

    End Sub

    Protected Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Agregar
        Response.Redirect("~/UACI/FrmDetCreaPlantillaContratos.aspx?mod=NEW&tipoMod=" & tipoPlantilla)
    End Sub

    Protected Sub dgPlantilla_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPlantilla.SelectedIndexChanged
        Response.Redirect("~/UACI/FrmDetCreaPlantillaContratos.aspx?mod=EDIT&id=" & Me.dgPlantilla.SelectedItem.Cells(1).Text & "&tipoMod=" & tipoPlantilla)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("tipoPlantilla") Is Nothing Then Me._tipoPlantilla = Me.ViewState("tipoPlantilla")
        End If
    End Sub
End Class
