Partial Public Class dbMENSAJES

#Region " METODOS AGREGADOS "

    Public Function FiltroMensajePorId(ByVal IDMENSAJE As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDMENSAJE = " + IDMENSAJE)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerListaOrden(ByVal tipo As Integer) As listaMENSAJES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        Select Case tipo
            Case Is = 0
                strSQL.Append(" order by FECHAINICIO ASC ")
            Case Is = 1
                strSQL.Append(" order by FECHAINICIO DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaMENSAJES

        Try
            Do While dr.Read()
                Dim mEntidad As New MENSAJES
                mEntidad.IDMENSAJE = IIf(dr("IDMENSAJE") Is DBNull.Value, Nothing, dr("IDMENSAJE"))
                mEntidad.MENSAJE = IIf(dr("MENSAJE") Is DBNull.Value, Nothing, dr("MENSAJE"))
                mEntidad.FECHAINICIO = IIf(dr("FECHAINICIO") Is DBNull.Value, Nothing, dr("FECHAINICIO"))
                mEntidad.FECHAFIN = IIf(dr("FECHAFIN") Is DBNull.Value, Nothing, dr("FECHAFIN"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function RecuperarOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDMENSAJE, ")
        strSQL.Append(" MENSAJE, ")
        strSQL.Append(" FECHAINICIO, ")
        strSQL.Append(" FECHAFIN, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_MENSAJES ")
        strSQL.Append(" ORDER BY FECHAINICIO")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerDataSetListaMensajes() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("	SELECT ")
        strSQL.Append("	MJ.IDMENSAJE, ")
        strSQL.Append("	MJ.MENSAJE, ")
        strSQL.Append("	CONVERT(varchar(10), MJ.FECHAINICIO, 103) as FECHAINICIO, ")
        strSQL.Append("	MJ.FECHAFIN, MJ.AUUSUARIOCREACION, ")
        strSQL.Append("	MJ.AUFECHACREACION, ")
        strSQL.Append("	MJ.AUUSUARIOMODIFICACION, ")
        strSQL.Append("	MJ.AUFECHAMODIFICACION, ")
        strSQL.Append("	MJ.ESTASINCRONIZADA ")
        strSQL.Append("	FROM SAB_CAT_MENSAJES as MJ ")
        strSQL.Append("	ORDER BY MJ.IDMENSAJE DESC ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetListaMensajesInicio() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("	SELECT ")
        strSQL.Append("	CASE ")
        strSQL.Append("	  WHEN datediff(day, getdate(), MJ.FECHAINICIO) IN (0, 1) THEN 'flechas.gif' ")
        strSQL.Append("	  ELSE  '' ")
        strSQL.Append("	  END ")
        strSQL.Append("	IMAGEN, ")
        strSQL.Append("	MJ.IDMENSAJE, ")
        strSQL.Append("	MJ.MENSAJE ")
        strSQL.Append("	FROM SAB_CAT_MENSAJES as MJ ")
        strSQL.Append("	WHERE (DATEDIFF(day, GETDATE(), FECHAFIN) >= 0) ")
        strSQL.Append("	ORDER BY MJ.IDMENSAJE DESC ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

#End Region

End Class
