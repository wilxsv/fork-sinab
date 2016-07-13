Partial Public Class ddlOPCIONESSISTEMA

    Private miComponente As New cOPCIONESSISTEMA

    Public Sub RecuperarPadres()
        Me.DataSource = miComponente.ObtenerListaPadres()
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDOPCIONSISTEMA"

        Me.DataBind()
    End Sub

    Public Sub RecuperarListaOpcionesParaRol(ByVal IDROL As Int32)
        Me.DataSource = miComponente.ObtenerListaOpcionesParaRol(IDROL)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDOPCIONSISTEMA"

        Me.DataBind()
    End Sub

End Class
