Partial Public Class ddlCARGOS

#Region " Metodos Agregados"

    Public Sub RecuperarOrdenada(ByVal tipo As Integer)
        Dim miComponente As New cCARGOS
        Dim Lista As listaCARGOS

        Lista = miComponente.ObtenerListaOrden(tipo)

        Me.DataSource = Lista

        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDCARGO"

        Me.DataBind()
    End Sub

#End Region

End Class
