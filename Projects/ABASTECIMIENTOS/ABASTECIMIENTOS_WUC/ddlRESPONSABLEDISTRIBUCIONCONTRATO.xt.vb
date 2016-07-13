Partial Public Class ddlRESPONSABLEDISTRIBUCIONCONTRATO

    Public Sub RecuperarListaPorContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64)
        Dim miComponente As New cRESPONSABLEDISTRIBUCIONCONTRATO

        Dim ds As Data.DataSet
        ds = miComponente.ObtenerResponsablesPorContratoDS(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

        If Not ds.Tables(0).Rows.Count > 0 Then
            Return
        ElseIf ds.Tables(0).Rows.Count = 1 Then
            Me.Enabled = False
        End If

        Me.DataSource = ds
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDRESPONSABLEDISTRIBUCION"

        Me.DataBind()
    End Sub

End Class
