Partial Public Class dbNIVELESUSOESTABLECIMIENTOS

#Region "Metodos agregados"

    ''' <summary>
    ''' Obtiene niveles de uso por establecimientos
    ''' </summary>
    ''' <param name="IDNIVELUSO">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_NIVELESUSOESTABLECIMIENTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function DevolverEstablecimientos(ByVal IDNIVELUSO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDNIVELUSO = " & IDNIVELUSO & " ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerDataSetListaNivelesUsoEstablecimiento() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT NUE.IDESTABLECIMIENTO, NUE.IDNIVELUSO, NU.NOMBRECORTO, NU.DESCRIPCION AS NIVELDEUSO, E.NOMBRE AS ESTABLECIMIENTO, ")
        strSQL.Append("NUE.AUUSUARIOCREACION, NUE.AUFECHACREACION, NUE.AUUSUARIOMODIFICACION, NUE.AUFECHAMODIFICACION, NUE.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_ESTABLECIMIENTOS AS E INNER JOIN ")
        strSQL.Append("SAB_CAT_NIVELESUSOESTABLECIMIENTOS AS NUE ON E.IDESTABLECIMIENTO = NUE.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("SAB_CAT_NIVELESUSO AS NU ON NUE.IDNIVELUSO = NU.IDNIVELUSO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function BuscarNivelUsoEstablecimiento(ByVal IDEstablecimiento As Int32, ByVal IDNiveUso As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, IDNIVELUSO ")
        strSQL.Append(" FROM(SAB_CAT_NIVELESUSOESTABLECIMIENTOS) ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDEstablecimiento) AND (IDNIVELUSO = @IDNiveUso) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDEstablecimiento", SqlDbType.Int)
        args(0).Value = IDEstablecimiento
        args(1) = New SqlParameter("@IDNiveUso", SqlDbType.Int)
        args(1).Value = IDNiveUso

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

#End Region

End Class