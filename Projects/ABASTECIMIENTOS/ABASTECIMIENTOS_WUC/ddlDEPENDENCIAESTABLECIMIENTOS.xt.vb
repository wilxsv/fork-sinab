
Partial Public Class ddlDEPENDENCIAESTABLECIMIENTOS

    Public Sub ObtenerDependenciaEstablecimiento(ByVal IDESTABLECIMIENTO As Integer)
        Dim miComponente As New cDEPENDENCIAESTABLECIMIENTOS
        Me.DataSource = miComponente.ObtenerDependenciaEstablecimiento(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDDEPENDENCIA"
        Me.DataBind()
    End Sub

End Class
