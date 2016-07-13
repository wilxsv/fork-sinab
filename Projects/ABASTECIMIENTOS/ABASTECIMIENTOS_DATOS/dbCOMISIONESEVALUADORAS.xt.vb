Partial Public Class dbCOMISIONESEVALUADORAS

#Region "Metodos adicionales"

    Public Function ObtenerListaComisiones(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal ESALTONIVEL As Integer = 0) As listaCOMISIONESEVALUADORAS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CE.IDESTABLECIMIENTO, ")
        strSQL.Append("CE.IDCOMISION, ")
        strSQL.Append("CE.NOMBRE, ")
        strSQL.Append("CE.FECHACREACION, ")
        strSQL.Append("CE.ESTADO, ")
        strSQL.Append("CE.ESALTONIVEL ")
        strSQL.Append("FROM SAB_UACI_COMISIONESEVALUADORAS CE ")
        strSQL.Append("INNER JOIN SAB_UACI_COMISIONPROCESOCOMPRA CPC ")
        strSQL.Append("ON (CE.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND CE.IDCOMISION = CPC.IDCOMISION) ")
        strSQL.Append("WHERE CE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CE.ESALTONIVEL = @ESALTONIVEL ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@ESALTONIVEL", SqlDbType.Int)
        args(2).Value = ESALTONIVEL

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCOMISIONESEVALUADORAS

        Try
            Do While dr.Read()
                Dim mEntidad As New COMISIONESEVALUADORAS
                mEntidad.IDCOMISION = IIf(dr("IDCOMISION") Is DBNull.Value, Nothing, dr("IDCOMISION"))
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.FECHACREACION = IIf(dr("FECHACREACION") Is DBNull.Value, Nothing, dr("FECHACREACION"))
                mEntidad.ESTADO = IIf(dr("ESTADO") Is DBNull.Value, Nothing, dr("ESTADO"))
                mEntidad.ESALTONIVEL = IIf(dr("ESALTONIVEL") Is DBNull.Value, Nothing, dr("ESALTONIVEL"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerListaComisionesAN(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As listaCOMISIONESEVALUADORAS

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("CE.IDESTABLECIMIENTO, ")
        strSQL.Append("CE.IDCOMISION, ")
        strSQL.Append("CE.NOMBRE, ")
        strSQL.Append("CE.FECHACREACION, ")
        strSQL.Append("CE.ESTADO, ")
        strSQL.Append("CE.ESALTONIVEL ")
        strSQL.Append("FROM SAB_UACI_COMISIONESEVALUADORAS CE ")
        strSQL.Append("INNER JOIN SAB_UACI_COMISIONPROCESOCOMPRA CPC ")
        strSQL.Append("ON (CE.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO ")
        strSQL.Append("AND CE.IDCOMISION = CPC.IDCOMISION) ")
        strSQL.Append("WHERE CE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CE.ESALTONIVEL = 1 ")
        strSQL.Append("AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCOMISIONESEVALUADORAS

        Try
            Do While dr.Read()
                Dim mEntidad As New COMISIONESEVALUADORAS
                mEntidad.IDCOMISION = IIf(dr("IDCOMISION") Is DBNull.Value, Nothing, dr("IDCOMISION"))
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.FECHACREACION = IIf(dr("FECHACREACION") Is DBNull.Value, Nothing, dr("FECHACREACION"))
                mEntidad.ESTADO = IIf(dr("ESTADO") Is DBNull.Value, Nothing, dr("ESTADO"))
                mEntidad.ESALTONIVEL = IIf(dr("ESALTONIVEL") Is DBNull.Value, Nothing, dr("ESALTONIVEL"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerEstablecimiento(ByVal IDUSUARIOCOMISION As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_UACI_COMISIONESEVALUADORAS ")
        strSQL.Append("WHERE IDUSUARIOCOMISION = @IDUSUARIOCOMISION")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIOCOMISION", SqlDbType.Int)
        args(0).Value = IDUSUARIOCOMISION

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function DevolverIDusuarioComision(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCOMISION As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDUSUARIOCOMISION ")
        strSQL.Append("FROM SAB_UACI_COMISIONESEVALUADORAS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDCOMISION = @IDCOMISION")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCOMISION", SqlDbType.Int)
        args(1).Value = IDCOMISION

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
