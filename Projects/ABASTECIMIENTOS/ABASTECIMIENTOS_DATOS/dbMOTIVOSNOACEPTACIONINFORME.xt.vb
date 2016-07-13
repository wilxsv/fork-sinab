Partial Public Class dbMOTIVOSNOACEPTACIONINFORME

#Region " Metodos Agregados "

    ''' <summary>
    ''' Elimina todos los motivos de no aceptación asociados a un informe de muestras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_LAB_MOTIVOSNOACEPTACIONINFORME</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarMOTIVOSNOACEPTACIONINFORME(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_LAB_MOTIVOSNOACEPTACIONINFORME ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDINFORME = @IDINFORME ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene todos los motivos de no aceptación correspondientes a un informe de muestras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_LAB_MOTIVOSNOACEPTACIONINFORME</item>
    ''' <item>SAB_CAT_MOTIVOSNOACEPTACION</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerMOTIVOSNOACEPTACIONINFORME(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("MNAI.IDMOTIVONOACEPTACION, ")
        strSQL.Append("MNA.DESCRIPCION ")
        strSQL.Append("FROM SAB_LAB_MOTIVOSNOACEPTACIONINFORME MNAI ")
        strSQL.Append("INNER JOIN SAB_CAT_MOTIVOSNOACEPTACION MNA ")
        strSQL.Append("ON MNAI.IDMOTIVONOACEPTACION = MNA.IDMOTIVONOACEPTACION ")
        strSQL.Append("WHERE MNAI.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND MNAI.IDINFORME = @IDINFORME ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = IDINFORME

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
