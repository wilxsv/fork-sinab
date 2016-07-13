Partial Public Class dbMODIFICATIVASCONTRATO

#Region " Metodos Agregados "

    Public Function ObtenerModificativasContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT MC.NUMEROMODIFICATIVA ")
        strSQL.Append("FROM SAB_UACI_MODIFICATIVASCONTRATO MC ")
        strSQL.Append("WHERE MC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND MC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND MC.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("ORDER BY MC.NUMEROMODIFICATIVA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim mc As String = String.Empty

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    If mc <> String.Empty Then mc += ", "
                    mc += dr.Item(0)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return mc

    End Function

#End Region

End Class
