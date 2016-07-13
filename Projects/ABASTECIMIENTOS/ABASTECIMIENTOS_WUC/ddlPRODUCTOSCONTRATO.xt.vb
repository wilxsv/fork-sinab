Partial Public Class ddlPRODUCTOSCONTRATO

    Public Sub ObtenerRenglonesPendientesTotales(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64)
        Dim miComponente As New cCONTRATOS
        Dim ds As DataSet

        ds = miComponente.ObtenerRenglonesPendientesTotales(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        If Not ds.Tables.Item(0).Rows.Count > 0 Then
            Return
        End If

        Me.DataSource = ds
        Me.DataTextField = "NUMEROTEXTORENGLON"
        Me.DataValueField = "RENGLON"

        Me.DataBind()
    End Sub

End Class
