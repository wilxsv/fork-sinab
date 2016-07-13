Partial Public Class ddlGRUPOS

    Private miComponente As New cGRUPOS

    Public Sub RecuperarListaOrdenada()
        Me.DataSource = miComponente.ObtenerListaOrdenada()
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDGRUPO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaFiltrada(ByVal IDSUMINISTRO As Int32)
        Me.DataSource = miComponente.ObtenerListaPorSuministro(IDSUMINISTRO)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDGRUPO"

        Me.DataBind()
    End Sub

    Public Sub RecuperarListaFiltrada2(ByVal IDSUMINISTRO As Int32)
        Me.DataSource = miComponente.ObtenerListaPorSuministro(IDSUMINISTRO)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "CORRELATIVO"
        Me.DataBind()
    End Sub
    Public Sub RecuperarListaFiltradaPorUT(ByVal IDSUMINISTRO As Int32, ByVal AREATECNICA As Integer)
        Me.DataSource = miComponente.ObtenerListaPorUT(IDSUMINISTRO, AREATECNICA)
        Me.DataTextField = "DESCGRUPO"
        Me.DataValueField = "IDGRUPO"

        Me.DataBind()
    End Sub

End Class
