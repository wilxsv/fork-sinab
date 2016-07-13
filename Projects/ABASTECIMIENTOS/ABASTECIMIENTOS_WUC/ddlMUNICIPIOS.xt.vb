Partial Public Class ddlMUNICIPIOS

    Public Sub RecuperarNombreMunicipio()
        Dim miComponente As New cMUNICIPIOS
        Dim Lista As listaMUNICIPIOS

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDMUNICIPIO"

        Me.DataBind()
    End Sub

End Class
