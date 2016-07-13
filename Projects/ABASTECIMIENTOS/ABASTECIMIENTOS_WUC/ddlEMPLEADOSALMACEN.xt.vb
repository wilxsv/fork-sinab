Partial Public Class ddlEMPLEADOSALMACEN

    'JOSE CHAVEZ
    Public Sub RecuperarListaGuardaalmacen(ByVal IDALMACEN As Int32)
        Dim miComponente As New cEMPLEADOSALMACEN
        Me.DataSource = miComponente.RecuperarGuardalmacen(IDALMACEN)
        Me.DataTextField = "CODIGONOMBRE"
        Me.DataValueField = "IDEMPLEADOGUARDAALMACEN"

        Me.DataBind()
    End Sub

End Class
