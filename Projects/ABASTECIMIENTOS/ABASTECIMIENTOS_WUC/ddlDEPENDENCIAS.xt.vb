Partial Public Class ddlDEPENDENCIAS

#Region " Metodos Agregados "

    Public Sub RecuperarOrdenada(ByVal tipo As Integer)
        Dim miComponente As New cDEPENDENCIAS
        Dim lista As listaDEPENDENCIAS

        lista = miComponente.ObtenerListaOrden(tipo)

        Me.DataSource = lista

        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDDEPENDENCIA"

        Me.DataBind()
    End Sub

    Public Sub ObtenerAreaTecnica()
        Dim miComponente As New cDEPENDENCIAS

        Me.DataSource = miComponente.ObtenerdsAreaTecnica
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDDEPENDENCIA"
        Me.DataBind()
    End Sub

#End Region

End Class
