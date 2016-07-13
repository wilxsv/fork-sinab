Partial Class ddlESTADOS

    Public Sub FiltrarEstados(ByVal operador As String, ByVal idestab As Int32)
        Dim miComponente As New cESTADOS
        Me.DataSource = miComponente.ObtenerDataSetEstados(operador, idestab)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDESTADO"
        Me.DataBind()
    End Sub

End Class
