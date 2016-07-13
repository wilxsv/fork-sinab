Partial Public Class dbCRITERIOSEVALUACION

#Region " Metodos Agregados "

    Public Function ObtenerDataSetPorTipoCriterio(ByVal IDTIPOCRITERIO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDTIPOCRITERIO = @IDTIPOCRITERIO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCRITERIO", SqlDbType.BigInt)
        args(0).Value = IDTIPOCRITERIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetXTipoCriterio(ByVal IDTIPOCRITERIO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDCRITERIOEVALUACION as IDCRITERIO, ")
        strSQL.Append("DESCRIPCION AS CRITERIO, ")
        strSQL.Append("PORCENTAJE ")
        strSQL.Append("FROM SAB_CAT_CRITERIOSEVALUACION ")
        strSQL.Append("WHERE IDTIPOCRITERIO = @IDTIPOCRITERIO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOCRITERIO", SqlDbType.BigInt)
        args(0).Value = IDTIPOCRITERIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetListaCriteriosEvaluacion(Optional ByVal EsLG As Boolean = False) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CE.IDCRITERIOEVALUACION, ")
        strSQL.Append("CE.IDTIPOCRITERIO, ")
        strSQL.Append("TC.DESCRIPCION TIPOCRITERIO, ")
        strSQL.Append("CE.DESCRIPCION, ")
        strSQL.Append("CE.PORCENTAJE, ")
        strSQL.Append("CE.ESGLOBAL, ")
        strSQL.Append("CE.AUUSUARIOCREACION, ")
        strSQL.Append("CE.AUFECHACREACION, ")
        strSQL.Append("CE.AUUSUARIOMODIFICACION, ")
        strSQL.Append("CE.AUFECHAMODIFICACION, ")
        strSQL.Append("CE.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_CRITERIOSEVALUACION CE ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCRITERIO TC ")
        strSQL.Append("ON CE.IDTIPOCRITERIO = TC.IDTIPOCRITERIO ")
        If EsLG = True Then
            strSQL.Append("WHERE CE.IDTIPOCRITERIO = 3 ")
        End If
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

#End Region

End Class
