Partial Public Class ddlTIPODOCUMENTOCONTRATO

    Private miComponente As New cTIPODOCUMENTOCONTRATO

    Public Sub ObtenerTipoDocumentosClasificados(ByVal CLASIFICACION As Int16)
        Me.DataSource = miComponente.ObtenerTipoDocumentoFiltrado(CLASIFICACION)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPODOCUMENTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarOrdenada()
        Me.DataSource = miComponente.RecuperarOrdenada()
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPODOCUMENTO"
        Me.DataBind()
    End Sub

    Public Sub ObtenerTipoDocumentoFiltrado(ByVal CLASIFICACION As Int16)
        Me.DataSource = miComponente.ObtenerTipoDocumentoFiltrado(CLASIFICACION)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPODOCUMENTO"
        Me.DataBind()
    End Sub

End Class
