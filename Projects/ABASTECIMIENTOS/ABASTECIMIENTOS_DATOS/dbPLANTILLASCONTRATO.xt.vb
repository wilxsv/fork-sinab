Partial Public Class dbPLANTILLASCONTRATO

    Public Function obtenerPlantillasContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDTIPOCOMPRA As Integer, ByVal IDSUMINISTRO As Integer, ByVal tipoPlantilla As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSUMINISTRO = @IDSUMINISTRO ")
        strSQL.Append(" AND IDTIPOCOMPRA = @IDTIPOCOMPRA ")
        strSQL.Append(" AND MODIFICATIVA = @tipoPlantilla")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDTIPOCOMPRA", SqlDbType.Int)
        args(1).Value = IDTIPOCOMPRA
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = IDSUMINISTRO
        args(3) = New SqlParameter("@tipoPlantilla", SqlDbType.Int)
        args(3).Value = tipoPlantilla

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerDataSetxPlantilla(ByVal aEntidad As PLANTILLASCONTRATO) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPLANTILLA = @IDPLANTILLA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(1).Value = aEntidad.IDPLANTILLA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
