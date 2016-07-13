Partial Public Class dbCARGADATOSSIM

    ''' <summary>
    ''' Obtener el numero de carga que se realizo del SIM al SAB pero no se ha generado consumo
    ''' </summary>
    ''' <param name="idestablecimiento"></param> 'identificador de establecimiento
    ''' <returns>
    ''' numero de id de carga
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_CARGADATOSSIM</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCargaSIM(ByVal idestablecimiento As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDCARGA ")
        strSQL.Append(" FROM SAB_EST_CARGADATOSSIM ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND ESTASINCRONIZADA = 1") 'se hizo carga

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiento

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
