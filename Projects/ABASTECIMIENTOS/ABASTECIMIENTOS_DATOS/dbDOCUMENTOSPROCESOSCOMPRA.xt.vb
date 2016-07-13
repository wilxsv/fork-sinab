Partial Public Class dbDOCUMENTOSPROCESOSCOMPRA

#Region " Métodos Agregados "

    Public Function ObtenerDataSetPorTipoDocumento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDTIPODOCUMENTOBASE As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DB.DESCRIPCION ")
        strSQL.Append("FROM SAB_UACI_DOCUMENTOSPROCESOSCOMPRA DPC ")
        strSQL.Append("INNER JOIN SAB_CAT_DOCUMENTOSBASE DB ")
        strSQL.Append("ON DPC.IDDOCUMENTOBASE = DB.IDDOCUMENTOBASE ")
        strSQL.Append("WHERE ")
        strSQL.Append("(DPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (DPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")
        strSQL.Append("AND (DB.IDTIPODOCUMENTOBASE = @IDTIPODOCUMENTOBASE) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDTIPODOCUMENTOBASE", SqlDbType.SmallInt)
        args(2).Value = IDTIPODOCUMENTOBASE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
