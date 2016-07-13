Partial Public Class ddlFUENTEFINANCIAMIENTOSCONTRATOS

    Public Sub RecuperarListaPorContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64)
        Dim miComponente As New cFUENTEFINANCIAMIENTOSCONTRATOS
        Dim ds As Data.DataSet
        ds = miComponente.ObtenerFuentesPorContratoDS(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)

        If Not ds.Tables(0).Rows.Count > 0 Then
            Return
        ElseIf ds.Tables(0).Rows.Count = 1 Then
            Me.Enabled = False
        End If

        Me.DataSource = ds
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDFUENTEFINANCIAMIENTO"

        Me.DataBind()
    End Sub

End Class
