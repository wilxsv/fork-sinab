Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucPlantilla
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me.UcBarraNavegacion1
            .PermitirAgregar = True
            .PermitirConsultar = False
            .PermitirEditar = False
            .HabilitarEdicion(True)
            .PermitirGuardar = False
            .PermitirImprimir = False
            .Navegacion = False
        End With
        obtenerPlantillas()
    End Sub

    Public Sub obtenerPlantillas()
        Dim mComponente As New cPLANTILLAS
        Me.dgPlantilla.DataSource = mComponente.ObtenerDataSetPorId
        Me.dgPlantilla.DataBind()
    End Sub

    Protected Sub dgPlantilla_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPlantilla.SelectedIndexChanged

    End Sub
End Class
