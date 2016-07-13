Partial Public Class dbCLAUSULASPLANTILLA

    Public Function ObtenerDataSetporPlantilla(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_CLAUSULASPLANTILLA.IDPLANTILLA, SAB_UACI_CLAUSULASPLANTILLA.IDCLAUSULA, SAB_CAT_CLAUSULAS.NOMBRE, ")
        strSQL.Append(" SAB_UACI_CLAUSULASPLANTILLA.ORDEN, SAB_CAT_CLAUSULAS.CONTENIDO ")
        strSQL.Append(" FROM SAB_UACI_CLAUSULASPLANTILLA INNER JOIN ")
        strSQL.Append(" SAB_CAT_CLAUSULAS ON SAB_UACI_CLAUSULASPLANTILLA.IDCLAUSULA = SAB_CAT_CLAUSULAS.IDCLAUSULA ")
        strSQL.Append(" WHERE (SAB_UACI_CLAUSULASPLANTILLA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") and (SAB_UACI_CLAUSULASPLANTILLA.IDPLANTILLA = " & IDPLANTILLA & ")")
        strSQL.Append(" ORDER BY SAB_UACI_CLAUSULASPLANTILLA.ORDEN ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ActualizarxClausula(ByVal aEntidad As CLAUSULASPLANTILLA, ByVal ORDEN_ACTUAL As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_CLAUSULASPLANTILLA SET ")
        strSQL.Append(" ORDEN = @ORDEN, ")
        strSQL.Append(" CONTENIDO = @CONTENIDO, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPLANTILLA = @IDPLANTILLA ")
        strSQL.Append(" AND IDCLAUSULA = @IDCLAUSULA ")
        strSQL.Append(" AND ORDEN = " & ORDEN_ACTUAL)

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@CONTENIDO", SqlDbType.VarChar)
        args(0).Value = IIf(IsNothing(aEntidad.CONTENIDO), DBNull.Value, aEntidad.CONTENIDO)
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = aEntidad.ESTASINCRONIZADA
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(5).Value = aEntidad.IDPLANTILLA
        args(6) = New SqlParameter("@IDCLAUSULA", SqlDbType.Int)
        args(6).Value = aEntidad.IDCLAUSULA
        args(7) = New SqlParameter("@ORDEN", SqlDbType.TinyInt)
        args(7).Value = aEntidad.ORDEN

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerOrden(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal IDCLAUSULA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT isnull(MAX(ORDEN), 0) + 1 as ORDEN ")
        strSQL.Append(" FROM SAB_UACI_CLAUSULASPLANTILLA ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPLANTILLA = " & IDPLANTILLA & ") ")

        Dim Orden As Integer
        Orden = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return Orden

    End Function

    Public Function validaOrden(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal IDCLAUSULA As Integer, ByVal ORDEN As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT count(ORDEN) ")
        strSQL.Append(" FROM SAB_UACI_CLAUSULASPLANTILLA ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND ")
        strSQL.Append(" (IDPLANTILLA = " & IDPLANTILLA & ") AND (ORDEN = " & ORDEN & ") ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    'Esta función permite obtener un listado de las clausulas que pertenecen a la plantilla seleccionada
    'el listado contiene los siguientes campos IDCLAUSULA, NOMBRE, ORDEN, ESREQUERIDA
    'Creado por Juan José Rivas
    '22/01/2007
    Public Function obtenerClausulasPlantillaDs(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal tipo As Integer, ByVal IDMODIFICATIVA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDCLAUSULACONTRATO, IDCLAUSULA, NOMBRE, ORDEN, 1 as ESREQUERIDA, origen ")
        strSQL.Append(" FROM ( ")
        strSQL.Append(" SELECT 0 AS IDCLAUSULACONTRATO, SAB_UACI_CLAUSULASPLANTILLA.IDCLAUSULA, SAB_CAT_CLAUSULAS.NOMBRE, SAB_UACI_CLAUSULASPLANTILLA.ORDEN, ")
        strSQL.Append(" SAB_CAT_CLAUSULAS.ESREQUERIDA, 'A' as origen ")
        strSQL.Append(" FROM SAB_UACI_CLAUSULASPLANTILLA INNER JOIN ")
        strSQL.Append(" SAB_CAT_CLAUSULAS ON SAB_UACI_CLAUSULASPLANTILLA.IDCLAUSULA = SAB_CAT_CLAUSULAS.IDCLAUSULA ")
        strSQL.Append(" WHERE (SAB_UACI_CLAUSULASPLANTILLA.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CLAUSULASPLANTILLA.IDPLANTILLA = " & IDPLANTILLA & ")) as A ") ' AND ")
        'strSQL.Append(" (SAB_UACI_CLAUSULASPLANTILLA.IDCLAUSULA NOT IN ")
        'strSQL.Append(" (SELECT SAB_UACI_CLAUSULASCONTRATOS.IDCLAUSULA ")
        'strSQL.Append(" FROM SAB_CAT_CLAUSULAS AS SAB_CAT_CLAUSULAS_1 INNER JOIN ")
        'strSQL.Append("       SAB_UACI_CLAUSULASCONTRATOS ON ")
        'strSQL.Append("       SAB_CAT_CLAUSULAS_1.IDCLAUSULA = SAB_UACI_CLAUSULASCONTRATOS.IDCLAUSULA ")
        'strSQL.Append(" WHERE (SAB_UACI_CLAUSULASCONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CLAUSULASCONTRATOS.IDCONTRATO = " & IDCONTRATO & ") and (SAB_UACI_CLAUSULASCONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ")")

        'If tipo = 1 Then
        '    strSQL.Append("AND (SAB_UACI_CLAUSULASCONTRATOS.IDMODIFICATIVA = " & IDMODIFICATIVA & "))) ")
        '    strSQL.Append(" AND (SAB_CAT_CLAUSULAS_1.MODIFICATIVA = 1)")
        'Else
        '    strSQL.Append(" )) ")
        'End If
        'strSQL.Append(" UNION ")
        'strSQL.Append(" SELECT SAB_UACI_CLAUSULASCONTRATOS.IDCLAUSULACONTRATO, SAB_UACI_CLAUSULASCONTRATOS.IDCLAUSULA, SAB_CAT_CLAUSULAS.NOMBRE, SAB_UACI_CLAUSULASCONTRATOS.ORDEN, ")
        'strSQL.Append(" SAB_CAT_CLAUSULAS.ESREQUERIDA, 'B' as origen ")
        'strSQL.Append(" FROM SAB_CAT_CLAUSULAS INNER JOIN ")
        'strSQL.Append(" SAB_UACI_CLAUSULASCONTRATOS ON SAB_CAT_CLAUSULAS.IDCLAUSULA = SAB_UACI_CLAUSULASCONTRATOS.IDCLAUSULA ")
        'strSQL.Append(" WHERE (SAB_UACI_CLAUSULASCONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (SAB_UACI_CLAUSULASCONTRATOS.IDCONTRATO = " & IDCONTRATO & ") AND (SAB_UACI_CLAUSULASCONTRATOS.IDPROVEEDOR = " & IDPROVEEDOR & ") ")
        'If tipo = 1 Then
        '    strSQL.Append(" AND (SAB_CAT_CLAUSULAS.MODIFICATIVA = 1) AND (SAB_UACI_CLAUSULASCONTRATOS.IDMODIFICATIVA = " & IDMODIFICATIVA & ")")
        'End If

        strSQL.Append(" ORDER BY ORDEN ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

End Class
