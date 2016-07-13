Partial Public Class dbUSUARIOS

#Region " Metodos Agregados "

    ''' <summary>
    ''' Se utiliza para VERIFICAR QUE EXISTA EL USUARIO Y LA CLAVE
    ''' </summary>
    ''' <param name="USUARIO"></param> nombre usuario
    ''' <param name="CLAVE"></param> clave de usuario
    ''' <returns>
    ''' verdadero si existe.
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGUSUARIOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarUsuario(ByVal USUARIO As String, ByVal CLAVE As String) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SEGUSUARIOS ")
        strSQL.Append("WHERE USUARIO = @USUARIO ")
        strSQL.Append("AND CLAVE = @CLAVE ")
        strSQL.Append("AND ESTAHABILITADO = '1' ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(0).Value = USUARIO
        args(1) = New SqlParameter("@CLAVE", SqlDbType.VarChar)
        args(1).Value = CLAVE

        If SqlHelper.ExecuteScalar(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Se utiliza para devolver el id de usuario correspondiente al nombre usuario que ingreso al sistema
    ''' </summary>
    ''' <param name="USUARIO"></param> usuario nombre
    ''' <returns>
    ''' id del usuario correspondiente
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGUSUARIOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DatosUsuario(ByVal USUARIO As String) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDUSUARIO ")
        strSQL.Append("FROM SEGUSUARIOS ")
        strSQL.Append("WHERE USUARIO = @USUARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(0).Value = USUARIO

        Return SqlHelper.ExecuteScalar(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return True

    End Function

    ''' <summary>
    ''' Se utiliza para obtener listado de usuarios por rol
    ''' </summary>
    ''' <param name="IDROL"></param> 'identificador de rol
    ''' <returns>
    ''' Dataset de listado de usuarios por rol
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>sproc_ListadoUsuariosPorRol</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Cecconi]      Creado
    ''' </history> 
    Public Function ObtenerListaPorRol(ByVal IDROL As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ListadoUsuariosPorRol")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Value = IDROL

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.StoredProcedure, strSQL.ToString, args)

        Return ds

    End Function

    ''' <summary>
    ''' Eliminar la asiganción de un usuario a un rol dado.
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario.</param>
    ''' <param name="IDROL">Identificador de rol.</param>
    ''' <returns>Integer.</returns>
    ''' <list type="bullet">
    ''' <item>SEGROLESUSUARIOS</item>
    ''' </list> 
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarUsuarioRol(ByVal IDUSUARIO As Integer, ByVal IDROL As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SEGROLESUSUARIOS ")
        strSQL.Append("WHERE IDUSUARIO = @IDUSUARIO ")
        strSQL.Append("AND IDROL = @IDROL ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(0).Value = IDUSUARIO
        args(1) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(1).Value = IDROL

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve un dataset de usuarios sin rol asignado.
    ''' </summary>
    ''' <returns>Dataset.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item>sproc_ListadoUsuariosSinRol</item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaUsuariosSinRol() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ListadoUsuariosSinRol")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.StoredProcedure, strSQL.ToString())

        Return ds

    End Function

    ''' <summary>
    ''' Se utiliza para obtener un dataset con el listado de las opciones disponibles segun el rol que el usuario
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador del usuario.</param>
    ''' <returns>Dataset de opciones por usuario.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description> vv_OPCIONESUSUARIOSROL</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]      Creado
    ''' </history> 
    Public Function ObtenerDsUsuariosOpciones(ByVal IDUSUARIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("IDUSUARIO, ")
        strSQL.Append("USUARIO, ")
        strSQL.Append("IDROL, ")
        strSQL.Append("NOMBRE, ")
        strSQL.Append("IDOPCIONSISTEMA, ")
        strSQL.Append("DESCRIPCION, ")
        strSQL.Append("isnull(URL, '') URL, ")
        strSQL.Append("ESTAHABILITADO, ")
        strSQL.Append("IDPADRE, ")
        strSQL.Append("ORDEN ")
        strSQL.Append("FROM vv_OPCIONESUSUARIOSROL ")
        strSQL.Append("WHERE IDUSUARIO = @IDUSUARIO ")
        strSQL.Append("ORDER BY ORDEN ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(0).Value = IDUSUARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve un dataset con las opciones no habilitadas para el rol al que se encuentra asociado el usuario.
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario.</param>
    ''' <returns>Dataset.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item>SEGUSUARIOS</item>
    ''' <item>SEGROLES</item>
    ''' <item>SEGOPCIONESSISTEMAROLES</item>
    ''' <item>SEGOPCIONESSISTEMA</item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Jürgen Kappler]    Creado
    ''' </history>
    Public Function ObtenerDsOpcionesNoHabilitadas(ByVal IDUSUARIO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("OS.URL ")
        strSQL.Append("FROM ")
        strSQL.Append("SEGOPCIONESSISTEMA OS ")
        strSQL.Append("EXCEPT ")
        strSQL.Append("SELECT DISTINCT")
        strSQL.Append("OS.URL ")
        strSQL.Append("FROM SEGUSUARIOS U ")
        strSQL.Append("INNER JOIN SEGROLESUSUARIOS RU ")
        strSQL.Append("ON U.IDUSUARIO = RU.IDUSUARIO ")
        strSQL.Append("INNER JOIN SEGROLES R ")
        strSQL.Append("ON RU.IDROL = R.IDROL ")
        strSQL.Append("INNER JOIN SEGOPCIONESSISTEMAROLES ORS ")
        strSQL.Append("ON R.IDROL = ORS.IDROL ")
        strSQL.Append("INNER JOIN SEGOPCIONESSISTEMA OS ")
        strSQL.Append("ON ORS.IDOPCIONSISTEMA = OS.IDOPCIONSISTEMA ")
        strSQL.Append("WHERE OS.ESTAHABILITADO = 1 ")
        strSQL.Append("AND U.IDUSUARIO = @IDUSUARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(0).Value = IDUSUARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve una lista de usuarios, ordenada por el campo que se especifica.
    ''' </summary>
    ''' <param name="Campo">Nombre del campo por el cual se ordena.</param>
    ''' <returns>Lista listaUSUARIOS.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item>SEGUSUARIOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaPorIDOrdenada(ByVal Campo As String) As listaUSUARIOS

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("ORDER BY " + Campo)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Dim lista As New listaUSUARIOS

        Try
            If dr.HasRows Then
                Do While dr.Read()
                    Dim mEntidad As New USUARIOS
                    mEntidad.IDUSUARIO = IIf(dr("IDUSUARIO") Is DBNull.Value, Nothing, dr("IDUSUARIO"))
                    mEntidad.USUARIO = IIf(dr("USUARIO") Is DBNull.Value, Nothing, dr("USUARIO"))
                    mEntidad.CLAVE = IIf(dr("CLAVE") Is DBNull.Value, Nothing, dr("CLAVE"))
                    mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
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
    ''' Permite actualizar todos los datos de un usuario excepto su clave.
    ''' </summary>
    ''' <param name="aEntidad">Entidad USUARIOS.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item>SEGUSUARIOS</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarSinClave(ByVal aEntidad As USUARIOS) As Integer

        Dim lID As Long
        If aEntidad.IDUSUARIO = 0 _
            Or aEntidad.IDUSUARIO = Nothing Then

            lID = Me.ObtenerID(aEntidad)

            If lID = -1 Then Return -1

            aEntidad.IDUSUARIO = lID

            Return Agregar(aEntidad)

        End If

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SEGUSUARIOS ")
        strSQL.Append(" SET USUARIO = @USUARIO, ")
        strSQL.Append(" IDEMPLEADO = @IDEMPLEADO, ")
        strSQL.Append(" ESTAHABILITADO = @ESTAHABILITADO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDUSUARIO = @IDUSUARIO ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(0).Value = aEntidad.USUARIO
        args(1) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(1).Value = aEntidad.IDEMPLEADO
        args(2) = New SqlParameter("@ESTAHABILITADO", SqlDbType.VarChar)
        args(2).Value = aEntidad.ESTAHABILITADO
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(7).Value = aEntidad.ESTASINCRONIZADA
        args(8) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(8).Value = aEntidad.IDUSUARIO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve un dataset de los usuarios junto con los datos de los empleado relacionados.
    ''' </summary>
    ''' <param name="ESTAELIMINADO">0: sin eliminar 1: eliminado</param>
    ''' <returns>Dataset.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description> sproc_ListadoUsuarios</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerDsUsuariosEmpleados(Optional ByVal ESTAELIMINADO As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ListadoUsuarios")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@ESTAELIMINADO", SqlDbType.Int)
        args(0).Direction = ParameterDirection.Input
        args(0).Value = ESTAELIMINADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve los datos del usuario junto con el nombre completo y el número del empleado relacionado.
    ''' </summary>
    ''' <param name="aEntidad">Entidad USUARIO</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item>sproc_ListadoUsuarios</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function RecuperarUsuarioConNombreEmpleado(ByVal aEntidad As USUARIOS) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ListadoUsuarios")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(0).Value = aEntidad.IDUSUARIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.StoredProcedure, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With ds.Tables(0).Rows(0)
                aEntidad.IDUSUARIO = IIf(.Item("IDUSUARIO") Is DBNull.Value, Nothing, .Item("IDUSUARIO"))
                aEntidad.USUARIO = IIf(.Item("USUARIO") Is DBNull.Value, Nothing, .Item("USUARIO"))
                aEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                aEntidad.IDEMPLEADO = IIf(.Item("IDEMPLEADO") Is DBNull.Value, Nothing, .Item("IDEMPLEADO"))
                aEntidad.ESTAHABILITADO = IIf(.Item("ESTAHABILITADO") Is DBNull.Value, Nothing, .Item("ESTAHABILITADO"))
                aEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                aEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    ''' <summary>
    ''' Eliminación de usuarios con auditoría de usuario y fecha.
    ''' </summary>
    ''' <param name="IDUSUARIO">Identificador de usuario</param>
    ''' <param name="AUUSUARIOELIMINACION">Usuario que elimina.</param>
    ''' <param name="AUFECHAELIMINACION">Fecha de eliminación.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item>sproc_ListadoUsuarios</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarUSUARIOS(ByVal IDUSUARIO As Int32, ByVal AUUSUARIOELIMINACION As String, ByVal AUFECHAELIMINACION As DateTime) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SEGUSUARIOS ")
        strSQL.Append("SET ")
        strSQL.Append("ESTAELIMINADO = IDUSUARIO, ")
        strSQL.Append("AUUSUARIOELIMINACION = @AUUSUARIOELIMINACION, ")
        strSQL.Append("AUFECHAELIMINACION = @AUFECHAELIMINACION ")
        strSQL.Append("WHERE IDUSUARIO = @IDUSUARIO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.VarChar)
        args(0).Value = IDUSUARIO
        args(1) = New SqlParameter("@AUUSUARIOELIMINACION", SqlDbType.VarChar)
        args(1).Value = AUUSUARIOELIMINACION
        args(2) = New SqlParameter("@AUFECHAELIMINACION", SqlDbType.DateTime)
        args(2).Value = AUFECHAELIMINACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarClave(ByVal IDUSUARIO As Integer, ByVal CLAVE As String) As Integer

        Dim strSQL As New System.Text.StringBuilder
        strSQL.Append("UPDATE SEGUSUARIOS ")
        strSQL.Append("SET ")
        strSQL.Append("CLAVE = @CLAVE ")
        strSQL.Append("WHERE IDUSUARIO = @IDUSUARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.VarChar)
        args(0).Value = IDUSUARIO
        args(1) = New SqlParameter("@CLAVE", SqlDbType.VarChar)
        args(1).Value = CLAVE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerEmpleadosUsuarios() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_ListadoUsuariosPorRol")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(0).Direction = ParameterDirection.Input
        args(0).Value = 0

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.StoredProcedure, strSQL.ToString, args)

        Return ds

    End Function

    Public Function ObtenerTablasBD() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT TABLE_NAME ")
        strSQL.Append("FROM INFORMATION_SCHEMA.TABLES ")
        strSQL.Append("WHERE (TABLE_TYPE = 'BASE TABLE') AND (TABLE_NAME NOT IN ")
        strSQL.Append("(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS where DATA_TYPE = 'TEXT')) ")
        strSQL.Append("AND (TABLE_NAME LIKE 'SAB_%') AND (TABLE_NAME <> 'SAB_AUDITORIA') ")
        strSQL.Append("ORDER BY TABLE_NAME ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerRegistroUsuarios(ByVal fechai As Date, ByVal fechaf As Date, ByVal usuario As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT USUARIO, DIRECCIONIP, AUFECHACREACION, CONVERT(VARCHAR,AUFECHACREACION,103) FECHA ")
        strSQL.Append("FROM SEGACCESOS ")
        strSQL.Append("WHERE ")
        strSQL.Append("convert(datetime, convert(varchar, AUFECHACREACION, 103)) between @fechai and @fechaf ")
        If usuario <> "Todos" Then
            strSQL.Append("and usuario = @usuario")
        End If

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@fechai", SqlDbType.DateTime)
        args(0).Value = fechai
        args(1) = New SqlParameter("@fechaf", SqlDbType.DateTime)
        args(1).Value = fechaf
        If usuario <> "Todos" Then
            args(2) = New SqlParameter("@usuario", SqlDbType.VarChar)
            args(2).Value = usuario
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerBitacoraSABAS(ByVal fechai As Date, ByVal fechaf As Date, ByVal usuario As String, ByVal movimiento As Integer, ByVal tabla As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select case type when 'I' then 'Inserción' when 'U' then 'Actualización' when 'D' then 'Eliminación' end type ,tablename,pk,fieldname,isnull(oldvalue,'NULL') oldvalue ,isnull(newvalue,'NULL') newvalue,updatedate,username, convert(varchar, updatedate,103) fecha ")
        strSQL.Append("from sab_auditoria ")
        strSQL.Append("where convert(datetime, convert(varchar, updatedate, 103)) between @fechai and @fechaf ")

        Select Case movimiento
            Case Is = 0
                strSQL.Append(" ")
            Case Is = 1
                strSQL.Append("and type = 'U' ")
            Case Is = 2
                strSQL.Append("and type = 'I' ")
            Case Is = 3
                strSQL.Append("and type = 'D' ")
        End Select

        If tabla <> "Todos" Then
            strSQL.Append("and tablename = @tabla ")
        End If

        If usuario <> "Todos" Then
            strSQL.Append("and username = @usuario ")
        End If

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@fechai", SqlDbType.DateTime)
        args(0).Value = fechai
        args(1) = New SqlParameter("@fechaf", SqlDbType.DateTime)
        args(1).Value = fechaf
        If usuario <> "Todos" Then
            args(2) = New SqlParameter("@usuario", SqlDbType.VarChar)
            args(2).Value = usuario
        End If
        If tabla <> "Todos" Then
            args(3) = New SqlParameter("@tabla", SqlDbType.VarChar)
            args(3).Value = tabla
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
