Partial Public Class ddlSUBGRUPOS

#Region " Metodos Agregados "

    Public Sub RecuperarListaFiltrada(ByVal IDGRUPO As Int32)
        Dim miComponente As New cSUBGRUPOS
        Dim Lista As listaSUBGRUPOS

        Lista = miComponente.ObtenerListaPorGrupo(IDGRUPO)

        Me.DataSource = Lista
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUBGRUPO"

        Me.DataBind()
    End Sub

    Public Sub RecuperarListaFiltrada2(ByVal IDGRUPO As Int32)
        Dim miComponente As New cSUBGRUPOS
        Dim Lista As listaSUBGRUPOS

        Lista = miComponente.ObtenerListaPorGrupo(IDGRUPO)

        Me.DataSource = Lista
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "CORRELATIVO"

        Me.DataBind()
    End Sub
    Public Sub RecuperarListaFiltradaUT(ByVal IDGRUPO As Int32, ByVal AREATECNICA As Integer)
        Dim miComponente As New cSUBGRUPOS
        Dim Lista As New DataSet

        Lista = miComponente.ObtenerListaPorGrupoUT(IDGRUPO, AREATECNICA)

        Me.DataSource = Lista
        Me.DataTextField = "DESCSUBGRUPO"
        Me.DataValueField = "IDSUBGRUPO"

        Me.DataBind()
    End Sub

#End Region

End Class
