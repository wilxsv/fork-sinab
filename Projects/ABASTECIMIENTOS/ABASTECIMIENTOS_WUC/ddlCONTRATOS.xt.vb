Partial Public Class ddlCONTRATOS

    Public Sub ObtenerDocumentosPendientesPorProveedor(ByVal IDPROVEEDOR As Int32)
        Dim miComponente As New cCONTRATOS
        Dim ds As DataSet

        ds = miComponente.ObtenerDocumentosPendientesPorProveedorDS(IDPROVEEDOR)
        If Not ds.Tables(0).Rows.Count > 0 Then
            Return
        End If

        Me.DataSource = ds
        Me.DataTextField = "NUMEROCONTRATO"
        Me.DataValueField = "IDCONTRATO"

        Me.DataBind()
    End Sub

End Class
