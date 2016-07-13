Partial Public Class ddlINFORMEMUESTRAS

#Region "  Metodos Agregados  "

    Public Sub RecuperarLotesRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer)
        Dim mComponente As New cINFORMEMUESTRAS
        Dim ds As Data.DataSet

        ds = mComponente.ObtenerInformacionLotesRenglon(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        If ds.Tables(0).Rows.Count = 0 Then
            Return
        Else
            Me.DataSource = ds
            Me.DataTextField = "LOTE"
            Me.DataValueField = "IDINFORME"
        End If

        Me.DataBind()
    End Sub

#End Region

End Class
