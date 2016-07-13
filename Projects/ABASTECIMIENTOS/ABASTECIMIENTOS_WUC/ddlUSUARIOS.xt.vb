Partial Public Class ddlUSUARIOS

    Public Sub RecuperarUsuariosSinRol()
        Dim miComponente As New cUSUARIOS
        Me.DataSource = miComponente.ObtenerListaUsuariosSinRol()
        Me.DataTextField = "USUARIONOMBRE"
        Me.DataValueField = "IDUSUARIO"
        Me.DataBind()
    End Sub

End Class
