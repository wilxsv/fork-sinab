Partial Public Class dbEMPLEADOS

#Region " Metodos adicionales "

    ''' <summary>
    ''' Obtiene un listado de empleados.
    ''' </summary>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history>
      Public Function ObtenerListaEmpladosNA() As listaEMPLEADOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("ORDER BY NOMBRE")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                'NOMBRE + APELLIDO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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
    ''' Obtiene un listado de empleados por establecimiento y dependencia.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.</param>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history>
    Public Function ObtenerListaEmpladosNA(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer) As listaEMPLEADOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDDEPENDENCIA = " & IDDEPENDENCIA & ") ")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                'NOMBRE + APELLIDO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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
    ''' Obtiene un listado de empleados por establecimiento y dependencia, omitiendo un empleado en particular.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.</param>
    ''' <param name="IDEMPLEADO">Identificador del empleado que se desea excluir.</param>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaEmpladosPorDependencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, ByVal IDEMPLEADO As Integer) As listaEMPLEADOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append("AND IDEMPLEADO <> @IDEMPLEADO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(2).Value = IDEMPLEADO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                'NOMBRE + APELLIDO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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


    Public Function RecuperarEmpleadosPorDependenciaAnalistaJuridico(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, ByVal IDEMPLEADO As Integer) As listaEMPLEADOS

        Dim strSQL As New Text.StringBuilder



        strSQL.Append("SELECT e.IDEMPLEADO,  e.IDDEPENDENCIA,  e.NOMBRECORTO,  e.NOMBRE,  e.APELLIDO,  e.TITULAR,  e.IDCARGO,  e.IDESTABLECIMIENTO,  ")
        strSQL.Append("e.AUUSUARIOCREACION, e.AUFECHACREACION, e.AUUSUARIOMODIFICACION, e.AUFECHAMODIFICACION, e.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_EMPLEADOS e ")
        strSQL.Append("inner join  [segabasii].[dbo].[SEGUSUARIOS] s on s.IDEMPLEADO=e.IDEMPLEADO  ")
        strSQL.Append("inner join  [segabasii].[dbo].SEGROLESUSUARIOS ru on ru.IDUSUARIO=s.IDUSUARIO ")

        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO  ")
        strSQL.Append("AND e.IDDEPENDENCIA = @IDDEPENDENCIA  AND e.IDEMPLEADO <> @IDEMPLEADO and ru.IDROL=13 AND s.ESTAHABILITADO=1 ")



        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(2).Value = IDEMPLEADO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                'NOMBRE + APELLIDO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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


    Public Function ObtenerListaEmpladosPorDependenciaInspector(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, ByVal IDEMPLEADO As Integer) As listaEMPLEADOS

        Dim strSQL As New Text.StringBuilder
        'SelectTabla(strSQL)
        strSQL.Append(" select ce.* from SAB_CAT_EMPLEADOS ")
        strSQL.Append(" ce  inner join segabas.dbo.segusuarios u on u.idempleado = ce.idempleado ")
        strSQL.Append("WHERE ce.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND (ce.IDDEPENDENCIA = @IDDEPENDENCIA OR @IDDEPENDENCIA = 0) ")
        strSQL.Append("AND ce.IDEMPLEADO <> @IDEMPLEADO ")
        strSQL.Append("AND ce.IDCARGO = 130  and u.estahabilitado=1  ") ' CARGO DE INSPECTOR solo Habilitados--Mayra Martinez 25082011

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(2).Value = IDEMPLEADO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                'NOMBRE + APELLIDO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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

    Public Function ObtenerListaEmpladosPorDependenciaCoordinador(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, ByVal IDEMPLEADO As Integer) As listaEMPLEADOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDDEPENDENCIA = @IDDEPENDENCIA ")
        strSQL.Append("AND IDEMPLEADO <> @IDEMPLEADO ")
        strSQL.Append("AND IDCARGO = 94 ") ' CARGO DE COORDINADOR

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(2).Value = IDEMPLEADO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                'NOMBRE + APELLIDO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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
    ''' Obtiene un listado de empleados por establecimiento y dependencia, omitiendo un empleado en particular.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.</param>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Jose Chavez]    Creado
    ''' </history>
    Public Function ObtenerEmpleadosPorDependencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer) As listaEMPLEADOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDDEPENDENCIA = @IDDEPENDENCIA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                'NOMBRE + APELLIDO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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

    Public Function ObtenerDataSetporEstablecimiento(ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT E.IDEMPLEADO, E.APELLIDO + ', ' + E.NOMBRE AS EMPLEADO, C.DESCRIPCION, ")
        strSQL.Append("E.IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_CAT_EMPLEADOS E INNER JOIN ")
        strSQL.Append("SAB_CAT_CARGOS C ON E.IDCARGO = C.IDCARGO ")
        strSQL.Append("WHERE E.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function BuscarEmpleado(ByVal FILTRO As String) As listaEMPLEADOS

        FILTRO = "'" & FILTRO & "%" & "'"
        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE NOMBRE LIKE @filtro ")
        strSQL.Append("OR APELLIDO LIKE @filtro")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@filtro", SqlDbType.VarChar)
        args(0).Value = FILTRO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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

    Public Function ObtenerNombreCompleto() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * from vv_EMPLEADOS ")
        strSQL.Append("ORDER BY NOMBRE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerNombreCompleto(ByVal TITULAR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * from vv_EMPLEADOS where TITULAR = " & TITULAR)
        strSQL.Append("ORDER BY NOMBRE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerNombreCompleto(ByVal IDESTABLECIMIENTO As Integer, ByVal TITULAR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * from vv_EMPLEADOS where TITULAR = " & TITULAR & " AND IDESTABLECIMIENTO = " & IDESTABLECIMIENTO)
        strSQL.Append("ORDER BY NOMBRE ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerEmpleadoXEstblecimientoNombreCompleto(ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * from vv_EMPLEADOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY NOMBRE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetporCargo(ByVal IDESTABLECIMIENTO As Int64, ByVal IDEMPLEADO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT C.DESCRIPCION, ")
        strSQL.Append(" E.IDESTABLECIMIENTO ")
        strSQL.Append(" FROM SAB_CAT_EMPLEADOS E INNER JOIN ")
        strSQL.Append(" SAB_CAT_CARGOS C ON E.IDCARGO = C.IDCARGO ")
        strSQL.Append(" WHERE E.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND E.IDEMPLEADO = @IDEMPLEADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = IDEMPLEADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Validar si un nombre corto ya existe
    ''' </summary>
    ''' <param name="Cfiltro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Eduardo Rodriguez]    15/12/06    Creado
    ''' </history>
    Public Function BuscarNombreCorto(ByVal NOMBRECORTO As String, ByVal IDEMPLEADO As Int64) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_EMPLEADOS ")
        strSQL.Append("WHERE NOMBRECORTO = @NOMBRECORTO AND (IDEMPLEADO <> @IDEMPLEADO OR @IDEMPLEADO = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@NOMBRECORTO", SqlDbType.VarChar)
        args(0).Value = NOMBRECORTO
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.BigInt)
        args(1).Value = IDEMPLEADO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0, 1, 0)

    End Function

    ''' <summary>
    ''' Validar si un EMPLEADO ya ASIGNADO UN USUARIO
    ''' </summary>
    ''' <param name="IDEMPLEADO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Eduardo Rodriguez]    18/12/06    Creado
    ''' </history>
    Public Function EmpleadoUsuario(ByVal IDEMPLEADO As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT count(IDEMPLEADO) ")
        strSQL.Append(" FROM SEGUSUARIOS ")
        strSQL.Append(" WHERE IDEMPLEADO = @IDEMPLEADO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(0).Value = IDEMPLEADO

        Return IIf(SqlHelper.ExecuteScalar(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args) = 0, True, False)

    End Function

    ''' <summary>
    ''' Devuelve los empleados sin usuario asignado.
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario.  Opcional.</param>
    ''' <returns>Dataset.</returns>
    ''' <remarks>Procedimientos utilizados:
    ''' <list type="bullet">
    ''' <item>sproc_EmpleadosSinUsuario</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerNombreCompletoEmpleadosSinUsuario(Optional ByVal IDUSUARIO As Int32 = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_EmpleadosSinUsuario")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(0).Value = IDUSUARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve un listado de empleados, incluyendo los nombres de establecimiento, dependencia y cargo.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerDataSetListaEmpleados() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("IDEMPLEADO, ")
        strSQL.Append("E.IDDEPENDENCIA, ")
        strSQL.Append("DE.NOMBRE DEPENDENCIA, ")
        strSQL.Append("E.NOMBRECORTO, ")
        strSQL.Append("E.NOMBRE, ")
        strSQL.Append("E.APELLIDO, ")
        strSQL.Append("isnull(E.APELLIDO + ', ' + E.NOMBRE, '') NOMBREAPELLIDO, ")
        strSQL.Append("E.IDCARGO, ")
        strSQL.Append("CA.DESCRIPCION CARGO, ")
        strSQL.Append("E.IDESTABLECIMIENTO, ")
        strSQL.Append("ES.NOMBRE ESTABLECIMIENTO, ")
        strSQL.Append("E.AUUSUARIOCREACION, ")
        strSQL.Append("E.AUFECHACREACION, ")
        strSQL.Append("E.AUUSUARIOMODIFICACION, ")
        strSQL.Append("E.AUFECHAMODIFICACION, ")
        strSQL.Append("E.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_CAT_EMPLEADOS E ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTABLECIMIENTOS ES ")
        strSQL.Append("ON E.IDESTABLECIMIENTO = ES.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_DEPENDENCIAS DE ")
        strSQL.Append("ON E.IDDEPENDENCIA = DE.IDDEPENDENCIA ")
        strSQL.Append("INNER JOIN SAB_CAT_CARGOS CA ")
        strSQL.Append("ON E.IDCARGO = CA.IDCARGO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetporEstablecimientoDependencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT E.IDEMPLEADO, E.APELLIDO + ', ' + E.NOMBRE AS EMPLEADO, C.DESCRIPCION, ")
        strSQL.Append(" E.IDESTABLECIMIENTO ")
        strSQL.Append(" FROM SAB_CAT_EMPLEADOS E INNER JOIN ")
        strSQL.Append(" SAB_CAT_CARGOS C ON E.IDCARGO = C.IDCARGO ")
        strSQL.Append(" WHERE E.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND E.IDDEPENDENCIA = @IDDEPENDENCIA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve los empleados titulares del establecimiento y de la dependencia
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.  Opcional.</param>
    ''' <returns>listaEMPLEADOS</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_CAT_EMPLEADOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerTitulares(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer) As listaEMPLEADOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND (IDDEPENDENCIA = @IDDEPENDENCIA OR @IDDEPENDENCIA = 0) ")
        strSQL.Append("AND TITULAR = 1 ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaEMPLEADOS

        Try
            Do While dr.Read()
                Dim mEntidad As New EMPLEADOS
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
                mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
                'NOMBRE + APELLIDO
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
                mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
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

    Public Function ObtenerDataSetCodigoEmpleado() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT E.IDEMPLEADO, E.NOMBRECORTO + ' / ' + E.APELLIDO + ', ' + E.NOMBRE AS EMPLEADO ")
        strSQL.Append("FROM SAB_CAT_EMPLEADOS E ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la lista completa de empleados de un establecimiento.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento (Filtro)</param>
    ''' <returns>Dataset con la lista de empleados.</returns>
    ''' <remarks>Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>vv_EMPLEADOS</description></item>
    ''' </list>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  11/12/2006    Creado
    ''' </history>
    ''' </remarks>
    Public Function ObtenerEmpleadoXEstblecimientoCodigoNombre(ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT * from vv_EMPLEADOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY NOMBRE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerJefeUACI(ByVal IDESTABLECIMIENTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDEMPLEADO, NOMBRE + ' ' + APELLIDO AS NOMBRE FROM SAB_CAT_EMPLEADOS AS EMPLEADOS ")
        strSQL.Append("WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDCARGO = 159) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return ds

    End Function

    Public Function ObtenerNombreJefeUACI(ByVal IDESTABLECIMIENTO As Int64) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT NOMBRE + ' ' + APELLIDO AS NOMBRE FROM SAB_CAT_EMPLEADOS ")
        strSQL.Append("WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDCARGO = 159) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    'Public Function RecuperarEmpleadosPorDependenciaAnalistaSuministros(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer, ByVal IDEMPLEADO As Integer) As listaEMPLEADOS

    '    Dim strSQL As New Text.StringBuilder



    '    strSQL.Append("SELECT e.IDEMPLEADO,  e.IDDEPENDENCIA,  e.NOMBRECORTO,  e.NOMBRE,  e.APELLIDO,  e.TITULAR,  e.IDCARGO,  e.IDESTABLECIMIENTO,  ")
    '    strSQL.Append("e.AUUSUARIOCREACION, e.AUFECHACREACION, e.AUUSUARIOMODIFICACION, e.AUFECHAMODIFICACION, e.ESTASINCRONIZADA ")
    '    strSQL.Append("FROM SAB_CAT_EMPLEADOS e ")
    '    strSQL.Append("inner join  [segabasii].[dbo].[SEGUSUARIOS] s on s.IDEMPLEADO=e.IDEMPLEADO  ")
    '    strSQL.Append("inner join  [segabasii].[dbo].SEGROLESUSUARIOS ru on ru.IDUSUARIO=s.IDUSUARIO ")

    '    strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO  ")
    '    strSQL.Append("AND e.IDDEPENDENCIA = @IDDEPENDENCIA  AND e.IDEMPLEADO <> @IDEMPLEADO and ru.IDROL=10 AND s.ESTAHABILITADO=1 ")



    '    Dim args(2) As SqlParameter
    '    args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
    '    args(0).Value = IDESTABLECIMIENTO
    '    args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
    '    args(1).Value = IDDEPENDENCIA
    '    args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
    '    args(2).Value = IDEMPLEADO

    '    Dim dr As SqlDataReader
    '    dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    '    Dim lista As New listaEMPLEADOS

    '    Try
    '        Do While dr.Read()
    '            Dim mEntidad As New EMPLEADOS
    '            mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
    '            mEntidad.IDDEPENDENCIA = IIf(dr("IDDEPENDENCIA") Is DBNull.Value, Nothing, dr("IDDEPENDENCIA"))
    '            mEntidad.NOMBRECORTO = IIf(dr("NOMBRECORTO") Is DBNull.Value, Nothing, dr("NOMBRECORTO"))
    '            'NOMBRE + APELLIDO
    '            mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE")) & " " & IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
    '            mEntidad.APELLIDO = IIf(dr("APELLIDO") Is DBNull.Value, Nothing, dr("APELLIDO"))
    '            mEntidad.IDCARGO = IIf(dr("IDCARGO") Is DBNull.Value, Nothing, dr("IDCARGO"))
    '            mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
    '            mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
    '            mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
    '            mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
    '            mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
    '            mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
    '            lista.Add(mEntidad)
    '        Loop
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        dr.Close()
    '    End Try

    '    Return lista

    'End Function



#End Region

End Class
