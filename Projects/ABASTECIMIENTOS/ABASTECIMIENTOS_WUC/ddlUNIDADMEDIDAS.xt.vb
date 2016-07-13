Partial Public Class ddlUNIDADMEDIDAS

    Public Sub RecuperarPorSuministro(ByVal idsuministro As Integer)
        Dim miComponente As New cUNIDADMEDIDAS
        Dim Lista As listaUNIDADMEDIDAS

        Lista = miComponente.ObtenerLista2(idsuministro)

        Me.DataSource = Lista
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDUNIDADMEDIDA"

        Me.DataBind()
    End Sub

End Class
