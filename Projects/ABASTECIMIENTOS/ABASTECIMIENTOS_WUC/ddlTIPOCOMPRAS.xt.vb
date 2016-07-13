Partial Public Class ddlTIPOCOMPRAS

    Private Sub RecuperarListaXmonto(ByVal xmonto As Decimal)
        Dim miComponente As New cTIPOCOMPRAS
        Me.DataSource = miComponente.obtenerListaporMonto(xmonto)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPOCOMPRA"
        Me.DataBind()
    End Sub

    Public Sub RecuperarXmonto(ByVal xmonto As Decimal)
        If xmonto > 0 Then
            RecuperarListaXmonto(xmonto)
        Else
            Recuperar()
        End If
    End Sub

    Public Sub RecuperarOrdenada()
        Dim miComponente As New cTIPOCOMPRAS
        Me.DataSource = miComponente.RecuperarOrdenada()
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPOCOMPRA"
        Me.DataBind()
    End Sub

    Public Sub ObtenerTipoCompraXModalidad(ByVal IDMODALIDAD As Integer)
        Dim miComponente As New cTIPOCOMPRAS
        Me.DataSource = miComponente.obtenerTipoCompraxMODALIDAD(IDMODALIDAD)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPOCOMPRA"
        Me.DataBind()
    End Sub

End Class
