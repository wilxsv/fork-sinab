Partial Public Class dbROLES

#Region " Metodos Agregados "

    ''' <summary>
    ''' obtener lista ordenada por un campo especifico 
    ''' </summary>
    ''' <param name="Campo"></param> campo por el cual se hara ordenamiento
    ''' <returns>
    ''' lista ordenada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGROLES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerListaPorIDOrdenada(ByVal Campo As String) As listaROLES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" ORDER BY ")
        strSQL.Append(Campo)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Dim lista As New listaROLES

        Try
            Do While dr.Read()
                Dim mEntidad As New ROLES
                mEntidad.IDROL = IIf(dr("IDROL") Is DBNull.Value, Nothing, dr("IDROL"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                mEntidad.ESTAHABILITADO = IIf(dr("ESTAHABILITADO") Is DBNull.Value, Nothing, dr("ESTAHABILITADO"))
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

    ''' <summary>
    ''' obtener un dataset de usuarios por roles
    ''' </summary>
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGROLES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerListaRolesUsuarios() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("R.IDROL, ")
        strSQL.Append("R.NOMBRE, ")
        strSQL.Append("R.DESCRIPCION, ")
        strSQL.Append("R.ESTAHABILITADO, ")
        strSQL.Append("R.AUFECHACREACION, ")
        strSQL.Append("(SELECT count(*) FROM SEGROLESUSUARIOS RU WHERE RU.IDROL = R.IDROL) USUARIOS ")
        strSQL.Append("FROM SEGROLES R ")
        strSQL.Append("ORDER BY R.NOMBRE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Recuperar un listado de roles hablitados
    ''' </summary>
    ''' <returns>
    ''' listado de roles
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGROLES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function RecuperarListaRolesHabilitados() As listaROLES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE ESTAHABILITADO = 1 ")
        strSQL.Append("ORDER BY NOMBRE")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Dim lista As New listaROLES

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    Dim mEntidad As New ROLES
                    mEntidad.IDROL = IIf(dr("IDROL") Is DBNull.Value, Nothing, dr("IDROL"))
                    mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                    mEntidad.DESCRIPCION = IIf(dr("DESCRIPCION") Is DBNull.Value, Nothing, dr("DESCRIPCION"))
                    mEntidad.ESTAHABILITADO = IIf(dr("ESTAHABILITADO") Is DBNull.Value, Nothing, dr("ESTAHABILITADO"))
                    mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                    mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                    mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                    mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                    mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                    lista.Add(mEntidad)
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    ''' <summary>
    ''' Se utiliza para obtener un data set con los roles y usuarios con el que esta relacionado
    ''' </summary>
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>sproc_ListadoRolesUsuarios</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Jürgen Kappler]      Creado
    ''' </history>
    Public Function ObtenerDsRolesUsuarios() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ListadoRolesUsuarios")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.StoredProcedure, strSQL.ToString())

        Return ds

    End Function

#End Region

End Class
