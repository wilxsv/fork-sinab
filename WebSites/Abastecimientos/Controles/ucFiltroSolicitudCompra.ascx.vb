Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Controles_ucFiltroSolicitudCompra
    Inherits System.Web.UI.UserControl

    Protected Sub BttBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttBuscar.Click
        Dim mControl As New cSOLICITUDES
        Dim textoBusqueda As String
        Dim criterioBusqueda As String
        Dim operadorBusqueda As String

        criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
        textoBusqueda = Me.TxtBuscar.Text
        operadorBusqueda = Me.DdlOperadorBusqueda.SelectedItem.Value

        Me.DdlPlazoentrega.Visible = False

        'Me.dgLista.DataSource = mControl.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda)
        'Me.dgLista.DataBind()
    End Sub

    Protected Sub DdlCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCriterio.SelectedIndexChanged
        Dim criterioBusqueda As String
        criterioBusqueda = Me.DdlCriterio.SelectedItem.Value

        Select Case criterioBusqueda
            Case Is = "1"
                criterioBusqueda = "CORRELATIVO"
            Case Is = "2"
                criterioBusqueda = "FECHASOLICITUD"
            Case Is = "3"
                criterioBusqueda = "IDDEPENDENCIASOLICITANTE"
            Case Is = "4"
                Me.DdlPlazoentrega.Visible = True
                Me.TxtBuscar.Visible = False
            Case Is = "5"
                criterioBusqueda = "IDESTADO"

        End Select
    End Sub
End Class
