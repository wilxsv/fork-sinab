Partial Public Class ddlROLES

    Public Sub RecuperarListaOrdenada(ByVal Campo As String)
        Dim miComponente As New cROLES
        Dim Lista As listaROLES

        Lista = miComponente.ObtenerListaOrdenada(Campo)

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDROL"

        Me.DataBind()
    End Sub

    Public Sub RecuperarListaRolesHabilitados()
        Dim miComponente As New cROLES

        Me.DataSource = miComponente.RecuperarListaRolesHabilitados()
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDROL"

        Me.DataBind()
    End Sub

End Class
