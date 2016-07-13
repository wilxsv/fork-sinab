Partial Public Class ddlTIPOESTABLECIMIENTOS

    Public Sub RecuperarlistaOrdenada(ByVal tipo As Integer)
        Dim miComponente As New cTIPOESTABLECIMIENTOS
        Me.DataSource = miComponente.ObtenerListaPorOrden(tipo)

        Me.DataTextField = "NOMBRECORTO"
        Me.DataValueField = "IDTIPOESTABLECIMIENTO"

        Me.DataBind()
    End Sub

End Class
