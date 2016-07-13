Imports System.Text
''' <summary>
''' Contiene funciones y métodos para la manipulación y lectura de  información de las programaciones de compra
''' </summary>
''' <remarks></remarks>
Public Class dbPROGRAMACION
    Inherits dbBase

#Region "Sin Utilizar"

    Public Overrides Function Actualizar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

#End Region

    ''' <summary>
    ''' Selecciona los datos relevantes de la tabla de programación de compras
    ''' </summary>
    ''' <param name="strSQL">Consulta SQL de la selección</param>
    ''' <remarks></remarks>
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT ")
        strSQL.Append("   P.FECHAPROGRAMACION, P.FECHAULTIMOPROGRAMA, P.FECHACORTE, (convert(varchar, MONTH(P.FECHAPROGRAMACION)) + '/' + ")
        strSQL.Append("   convert(varchar, YEAR(P.FECHAPROGRAMACION))) AS PERIODO, P.IDPROGRAMACION, P.DESCRIPCION, ")
        strSQL.Append("   P.MESESCPM, P.MESESPLANEACION, P.INDICEINFLACION, P.ESTADO, CASE P.ESTADO WHEN 1 THEN 'Creada' WHEN 2 THEN 'Liberada' WHEN 3 THEN 'Def. Entregas' ELSE 'Finalizada' END as DETALLEESTADO, IDSUMINISTRO, ENTREGAS ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACION P ")

    End Sub

    ''' <summary>
    ''' Obtiene el siguiente correlativo de la tabla para la nueva programación de compras
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada a la programación de compras</param>
    ''' <returns>Nuevo correlativo de la tabla</returns>
    ''' <remarks></remarks>
    Public Overrides Function ObtenerID(ByVal aEntidad As ENTIDADES.entidadBase) As String

        Dim lEntidad As PROGRAMACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPROGRAMACION),0) + 1 ")
        strSQL.Append(" FROM SAB_URMIM_PROGRAMACION ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Actualiza una programación de compras específica
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada a la programación de compras</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarProgramacion(ByVal aEntidad As ENTIDADES.entidadBase, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PROGRAMACION
        lEntidad = aEntidad

        Dim lID As Long

        If lEntidad.IDPROGRAMACION = 0 Or lEntidad.IDPROGRAMACION = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDPROGRAMACION = lID

            Return agregarProgramacion(lEntidad, tran)

        End If

        Dim strSQL As New StringBuilder

        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_URMIM_PROGRAMACION SET ")
        strSQL.Append("  DESCRIPCION=@DESCRIPCION, FECHAULTIMOPROGRAMA=@FECHAULTIMOPROGRAMA, FECHACORTE=@FECHACORTE, ")
        strSQL.Append("  MESESCPM=@MESESCPM, MESESPLANEACION=@MESESPLANEACION,")
        strSQL.Append("  INDICEINFLACION=@INDICEINFLACION, AUUSUARIOMODIFICACION=@AUUSUARIOMODIFICACION, AUFECHAMODIFICACION=@AUFECHAMODIFICACION, IDPROGRAMA=@IDPROGRAMA ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION=@IDPROGRAMACION AND ")
        strSQL.Append("  FECHAPROGRAMACION=@FECHAPROGRAMACION ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@FECHAPROGRAMACION", SqlDbType.DateTime)
        args(1).Value = lEntidad.FECHAPROGRAMACION
        args(2) = New SqlParameter("@FECHAULTIMOPROGRAMA", SqlDbType.DateTime)
        args(2).Value = lEntidad.FECHAPROYECCION
        args(3) = New SqlParameter("@FECHACORTE", SqlDbType.DateTime)
        args(3).Value = lEntidad.FECHACORTE
        args(4) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(4).Value = lEntidad.DESCRIPCION
        args(5) = New SqlParameter("@MESESCPM", SqlDbType.Int)
        args(5).Value = lEntidad.MESESCPM
        args(6) = New SqlParameter("@MESESPLANEACION", SqlDbType.Int)
        args(6).Value = lEntidad.MESESPLANEACION
        args(7) = New SqlParameter("@INDICEINFLACION", SqlDbType.Decimal)
        args(7).Value = lEntidad.INDICEINFLACION
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = lEntidad.AUUSUARIOMODIFICACION
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = lEntidad.AUFECHAMODIFICACION
        args(10) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(10).Value = lEntidad.IDPROGRAMA

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Adiciona una programación de compras a la base de datos
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada a la programación de compras</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarProgramacion(ByVal aEntidad As ENTIDADES.entidadBase, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PROGRAMACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO ")
        strSQL.Append("  SAB_URMIM_PROGRAMACION(")
        strSQL.Append("  IDPROGRAMACION, FECHAPROGRAMACION, FECHAULTIMOPROGRAMA, FECHACORTE, ")
        strSQL.Append("  DESCRIPCION, MESESCPM, MESESPLANEACION, INDICEINFLACION, ESTADO, ")
        strSQL.Append("  AUUSUARIOCREACION, AUFECHACREACION, IDSUMINISTRO,IDPROGRAMA ")
        strSQL.Append("  ) ")
        strSQL.Append("  VALUES(")
        strSQL.Append("  @IDPROGRAMACION, @FECHAPROGRAMACION, @FECHAULTIMOPROGRAMA, @FECHACORTE, ")
        strSQL.Append("  @DESCRIPCION, @MESESCPM, @MESESPLANEACION, @INDICEINFLACION, @ESTADO, ")
        strSQL.Append("  @AUUSUARIOCREACION, @AUFECHACREACION, @IDSUMINISTRO,@IDPROGRAMA ")
        strSQL.Append("  ) ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@FECHAPROGRAMACION", SqlDbType.DateTime)
        args(1).Value = lEntidad.FECHAPROGRAMACION
        args(2) = New SqlParameter("@FECHAULTIMOPROGRAMA", SqlDbType.DateTime)
        args(2).Value = lEntidad.FECHAPROYECCION
        args(3) = New SqlParameter("@FECHACORTE", SqlDbType.DateTime)
        args(3).Value = lEntidad.FECHACORTE
        args(4) = New SqlParameter("@DESCRIPCION", SqlDbType.VarChar)
        args(4).Value = lEntidad.DESCRIPCION
        args(5) = New SqlParameter("@MESESCPM", SqlDbType.Int)
        args(5).Value = lEntidad.MESESCPM
        args(6) = New SqlParameter("@MESESPLANEACION", SqlDbType.Int)
        args(6).Value = lEntidad.MESESPLANEACION
        args(7) = New SqlParameter("@INDICEINFLACION", SqlDbType.Int)
        args(7).Value = lEntidad.INDICEINFLACION
        args(8) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(8).Value = lEntidad.ESTADO
        args(9) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(9).Value = lEntidad.AUUSUARIOCREACION
        args(10) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(10).Value = lEntidad.AUFECHACREACION
        args(11) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(11).Value = lEntidad.IDSUMINISTRO
        args(12) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(12).Value = lEntidad.IDPROGRAMA

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene toda la información de una programación de compras específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificación de la programación de la que se desea obtener su información</param>
    ''' <returns>Información de la programación en forma de entidad</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionPorID(ByVal IDPROGRAMACION As Integer) As PROGRAMACION

        Dim lEntidad As New PROGRAMACION

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPROGRAMACION = @IDPROGRAMACION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dr.Read Then

            lEntidad.FECHAPROGRAMACION = dr.Item("FECHAPROGRAMACION")
            lEntidad.FECHAPROYECCION = dr.Item("FECHAULTIMOPROGRAMA")
            lEntidad.FECHACORTE = dr.Item("FECHACORTE")
            lEntidad.IDPROGRAMACION = dr.Item("IDPROGRAMACION")
            lEntidad.DESCRIPCION = dr.Item("DESCRIPCION")
            lEntidad.MESESCPM = dr.Item("MESESCPM")
            lEntidad.MESESPLANEACION = dr.Item("MESESPLANEACION")
            lEntidad.INDICEINFLACION = dr.Item("INDICEINFLACION")
            lEntidad.ESTADO = dr.Item("ESTADO")
            lEntidad.IDSUMINISTRO = dr.Item("IDSUMINISTRO")
            lEntidad.ENTREGAS = dr.Item("ENTREGAS")

        Else
            lEntidad = Nothing
        End If

        dr.Close()

        Return lEntidad

    End Function

    ''' <summary>
    ''' Obtiene el estado del detalle de una programación para un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación de la que se desea conocer su estado</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del que se desea conocer su estado</param>
    ''' <returns>Estado del detalle de la programación para el establecimiento</returns>
    ''' <remarks></remarks>
    Public Function obtenerEstadoProgramacionEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT isnull(ESTADO,0) FROM SAB_URMIM_PROGRAMACIONDETALLE ")
        strSQL.Append(" WHERE IDPROGRAMACION = @IDPROGRAMACION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el listado de programaciones según su estado
    ''' </summary>
    ''' <param name="estado">Filtro del estado de la programación</param>
    ''' <returns>Lista de programaciones en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDsProgramacion(Optional ByVal estado As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        strSQL.Append(" WHERE (ESTADO=@ESTADO OR @ESTADO=0) ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   YEAR(FECHAPROGRAMACION) DESC, MONTH(FECHAPROGRAMACION) DESC, IDPROGRAMACION DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(0).Value = estado

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el listado de programaciones para un establecimiento específico
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento para el que se desea obtener el listado de programaciones</param>
    ''' <param name="estado">Filtro del estado de la programación</param>
    ''' <returns>Lista de programaciones para el establecimiento según su estado en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDsProgramacionEstablecimiento(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal estado As Integer = 0, Optional ByVal IdRol As Integer = 0, Optional IDPROGRAMA As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT distinct ")
        strSQL.Append("    P.FECHAPROGRAMACION, P.FECHAULTIMOPROGRAMA, P.FECHACORTE, (convert(varchar, MONTH(P.FECHAPROGRAMACION)) + '/' + ")
        strSQL.Append("    convert(varchar, YEAR(P.FECHAPROGRAMACION))) AS PERIODO, P.IDPROGRAMACION, P.DESCRIPCION, ")
        strSQL.Append("    P.MESESCPM, P.MESESPLANEACION, P.INDICEINFLACION, P.ESTADO, CASE P.ESTADO WHEN 1 THEN 'Creada'  when 2 then 'Liberada' ELSE 'finalizada' END as DETALLEESTADO, ")
        strSQL.Append("    ISNULL(PD.ESTADO, 0) AS ESTADOESTABLECIMIENTO, ")
        strSQL.Append("    CASE PD.ESTADO ")
        strSQL.Append("      WHEN 1 THEN 'En revisión' ")
        strSQL.Append("      WHEN 2 THEN 'En ajuste' ")
        strSQL.Append("      WHEN 3 THEN 'Finalizada' ")
        strSQL.Append("      ELSE 'No iniciada' ")
        strSQL.Append("    END AS ESTADODESCEST ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_URMIM_PROGRAMACION P ")
        strSQL.Append("      INNER JOIN SAB_URMIM_PROGRAMACIONDETALLE PD ON ")
        strSQL.Append("        P.IDPROGRAMACION = PD.IDPROGRAMACION  ")
        If idprograma = 0 Then
            strSQL.Append("        AND PD.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        End If

        strSQL.Append("      INNER JOIN SAB_URMIM_ROLESSUMINISTROS RS ON ")
        strSQL.Append("        RS.IDSUMINISTRO = P.IDSUMINISTRO ")
        strSQL.Append(" WHERE (P.ESTADO>=@ESTADO OR @ESTADO=0) AND (RS.IDROL=@IDROL OR @IDROL=0) ")
        If IDPROGRAMA <> 0 Then
            strSQL.Append("        AND P.IDPROGRAMA<>0 ")
        End If
        strSQL.Append(" group by p.DESCRIPCION, P.FECHAPROGRAMACION, P.FECHAULTIMOPROGRAMA, P.FECHACORTE, P.IDPROGRAMACION,  P.MESESCPM, P.MESESPLANEACION, P.INDICEINFLACION, P.ESTADO, PD.ESTADO ORDER BY  P.FECHAPROGRAMACION desc  ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(0).Value = estado
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(2).Value = IdRol

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el listado de programaciones para un establecimiento específico de producto no medico
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento para el que se desea obtener el listado de programaciones</param>
    ''' <param name="estado">Filtro del estado de la programación</param>
    ''' <returns>Lista de programaciones para el establecimiento según su estado en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDsProgramacionEstablecimientoOtros(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal estado As Integer = 0, Optional ByVal IdRol As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("    P.FECHAPROGRAMACION, P.FECHAULTIMOPROGRAMA, P.FECHACORTE, (convert(varchar, MONTH(P.FECHAPROGRAMACION)) + '/' + ")
        strSQL.Append("    convert(varchar, YEAR(P.FECHAPROGRAMACION))) AS PERIODO, P.IDPROGRAMACION, P.DESCRIPCION, ")
        strSQL.Append("    P.MESESCPM, P.MESESPLANEACION, P.INDICEINFLACION, P.ESTADO, CASE P.ESTADO WHEN 1 THEN 'Creada'  when 2 then 'Liberada' ELSE 'finalizada' END as DETALLEESTADO, ")
        strSQL.Append("    ISNULL(PD.ESTADO, 0) AS ESTADOESTABLECIMIENTO, ")
        strSQL.Append("    CASE PD.ESTADO ")
        ' strSQL.Append("      WHEN 1 THEN 'En revisión' ")
        'strSQL.Append("      WHEN 2 THEN 'En ajuste' ")
        strSQL.Append("      WHEN 3 THEN 'Finalizada' ")
        strSQL.Append("      ELSE 'No iniciada' ")
        strSQL.Append("    END AS ESTADODESCEST ")
        strSQL.Append("  FROM ")
        strSQL.Append("    SAB_URMIM_PROGRAMACION P ")
        strSQL.Append("      INNER JOIN SAB_URMIM_PROGRAMACIONDETALLE PD ON ")
        strSQL.Append("        P.IDPROGRAMACION = PD.IDPROGRAMACION AND ")
        strSQL.Append("        PD.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("      INNER JOIN SAB_URMIM_ROLESSUMINISTROS RS ON ")
        strSQL.Append("        RS.IDSUMINISTRO = P.IDSUMINISTRO ")
        strSQL.Append(" WHERE (P.ESTADO>=@ESTADO OR @ESTADO=0) AND (RS.IDROL=@IDROL OR @IDROL=0) ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   YEAR(FECHAPROGRAMACION) DESC, MONTH(FECHAPROGRAMACION) DESC ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(0).Value = estado
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDROL", SqlDbType.Int)
        args(2).Value = IdRol

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function



    ''' <summary>
    ''' Agrega un producto a una programación específica
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada a la programación de compras</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarProgramacionProducto(ByVal aEntidad As ENTIDADES.entidadBase, ByVal tran As DistributedTransaction) As Integer

        Dim lEntidad As PROGRAMACION
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_URMIM_PROGRAMACIONPRODUCTO ")
        strSQL.Append("   SELECT ")
        strSQL.Append("     @IDPROGRAMACION, CP.IDPRODUCTO, ISNULL(PUC.PRECIO, 0), @AUUSUARIOCREACION, @AUFECHACREACION, NULL, NULL ")
        strSQL.Append("   FROM ")
        strSQL.Append("     VV_CATALOGOPRODUCTOS CP ")
        If lEntidad.IDPROGRAMA <> 0 Then
            strSQL.Append("     INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PP ON PP.IDPRODUCTO=CP.IDPRODUCTO AND PP.IDPROGRAMA=" & lEntidad.IDPROGRAMA)
            strSQL.Append("       LEFT OUTER JOIN fn_UltimoPrecioCompraParaiso(@FECHA) PUC ")
        Else
            strSQL.Append("       LEFT OUTER JOIN fn_UltimoPrecioCompra(@FECHA) PUC ")
        End If
        strSQL.Append("         ON CP.IDPRODUCTO = PUC.IDPRODUCTO ")
        strSQL.Append("   WHERE ")
        strSQL.Append("     CP.IDSUMINISTRO = @IDSUMINISTRO and CP.PERTENECELISTADOOFICIAL = 1 ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(1).Value = DateAdd(DateInterval.Year, -2, Now)
        args(2) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = lEntidad.AUUSUARIOCREACION
        args(3) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(3).Value = lEntidad.AUFECHACREACION
        args(4) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(4).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el total de productos con precio cero para una programación específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación que se desea consultar</param>
    ''' <returns>Un entero identificando el número de productos con precio cero para la programación</returns>
    ''' <remarks></remarks>
    Public Function obtenerTotalProductosCeros(ByVal idProgramacion As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONPRODUCTO pp ")
        strSQL.Append(" where ")
        strSQL.Append("   idProgramacion = @IDPROGRAMACION and ")
        strSQL.Append("   precio = 0 ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el listado de establecimientos que no han cerrado una programación específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación que se desea consultar</param>
    ''' <returns>Un entero identificando el número de establecimientos que no han cerrado su programación</returns>
    ''' <remarks></remarks>
    Public Function obtenerEstablecimientosAbiertos(ByVal idProgramacion As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE pp ")
        strSQL.Append(" where ")
        strSQL.Append("   idProgramacion = @IDPROGRAMACION and ")
        strSQL.Append("   PRESUPUESTOAJUSTADO = 0 ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el estado de una programación específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación que se desea actualizar</param>
    ''' <param name="estado">Nuevo estado de la programación</param>
    ''' <param name="usuario">Usuario que actualiza la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarEstadoProgramacion(ByVal idProgramacion As Integer, ByVal estado As Integer, ByVal usuario As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("UPDATE ")
        strSQL.Append("  SAB_URMIM_PROGRAMACION SET ")
        strSQL.Append("  ESTADO=@ESTADO, AUUSUARIOMODIFICACION=@AUUSUARIOMODIFICACION, AUFECHAMODIFICACION=@AUFECHAMODIFICACION ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION=@IDPROGRAMACION ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion
        args(1) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(1).Value = estado
        args(2) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(2).Value = usuario
        args(3) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(3).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene una lista con el detalle de una programación específica para cada establecimiento en ella
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación que se desea consultar</param>
    ''' <returns>Lista de detalle de la programación</returns>
    ''' <remarks></remarks>
    Public Function detalleEstadoProgramacion(ByVal idProgramacion As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append("select ")
        strSQL.Append("  e.nombre as establecimiento, pd.presupuestoreal as montototal, pd.presupuestoajustado as montototalajustado, pd.presupuestoasignado as montoasignado ")
        strSQL.Append("from ")
        strSQL.Append("  dbo.SAB_URMIM_PROGRAMACIONDETALLE pd ")
        strSQL.Append("    inner join dbo.SAB_CAT_ESTABLECIMIENTOS e ")
        strSQL.Append("      on pd.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append(" where ")
        strSQL.Append("   pd.idProgramacion = @IDPROGRAMACION ")
        strSQL.Append(" order by ")
        strSQL.Append("   e.nombre ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega el detalle de entregas para una programación específica
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada a la tabla de entregas de la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function ingresarEntregaProgramacion(ByVal eEntidad As ENTREGAPROGRAMACION, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONENTREGA")
        strSQL.Append("     (IDPROGRAMACION, IDENTREGA, NUMEROENTREGA, PORCENTAJEENTREGA, DIASENTREGA, AUUSUARIOCREACION,")
        strSQL.Append("     AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION)")
        strSQL.Append(" VALUES(")
        strSQL.Append("   @IDPROGRAMACION, @IDENTREGA, @NUMEROENTREGA, @PORCENTAJEENTREGA, @DIASENTREGA, @AUUSUARIOCREACION,")
        strSQL.Append("   @AUFECHACREACION, NULL, NULL)")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDENTREGA", SqlDbType.Int)
        args(1).Value = eEntidad.IDENTREGA
        args(2) = New SqlParameter("@NUMEROENTREGA", SqlDbType.Int)
        args(2).Value = eEntidad.NUMEROENTREGA
        args(3) = New SqlParameter("@PORCENTAJEENTREGA", SqlDbType.Decimal)
        args(3).Value = eEntidad.PORCENTAJEENTREGA
        args(4) = New SqlParameter("@DIASENTREGA", SqlDbType.Int)
        args(4).Value = eEntidad.DIASENTREGA
        args(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(5).Value = eEntidad.AUUSUARIOCREACION
        args(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(6).Value = eEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Consolida una programación de compras específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación a consolidar</param>
    ''' <param name="usuario">Usuario que realiza la consolidación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha consolidado o no la programación en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function ingresarConsolidadoProgramacion(ByVal idProgramacion As Integer, ByVal usuario As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" with s as(")
        strSQL.Append("   SELECT")
        strSQL.Append("     distinct ppe.idProgramacion, ppe.idProducto, cp.codigo")
        strSQL.Append("   FROM")
        strSQL.Append("     dbo.SAB_URMIM_PROGRAMACIONPRODUCTOESTABLECIMIENTO ppe")
        strSQL.Append("       inner join sab_cat_catalogoProductos cp on")
        strSQL.Append("         ppe.idProducto = cp.idProducto")
        strSQL.Append("   WHERE")
        strSQL.Append("     ppe.idProgramacion = @IDPROGRAMACION and")
        strSQL.Append("     ppe.cantidadComprarAjustada > 0")
        strSQL.Append(" )")
        strSQL.Append("")
        strSQL.Append(" INSERT INTO dbo.SAB_URMIM_PROGRAMACIONENTREGADETALLE")
        strSQL.Append(" select")
        strSQL.Append("   @IDPROGRAMACION, idProducto, row_number() over(order by codigo) as renglon, 0, @USUARIO, getDate(), null, null, null")
        strSQL.Append(" from")
        strSQL.Append("   s")
        strSQL.Append(" order by codigo")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion
        args(1) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(1).Value = usuario

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el máximo número de entregas para una programación específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación que se desea consultar</param>
    ''' <param name="tabla">Tabla que se desea consultar</param>
    ''' <param name="campo">Campo que se desea consultar</param>
    ''' <returns>Un entero indentificando el número máximo de entregas para la programación</returns>
    ''' <remarks></remarks>
    Public Function obtenerTotalEntregas(ByVal idProgramacion As Integer, Optional ByVal tabla As String = "SAB_URMIM_PROGRAMACIONENTREGA", Optional ByVal campo As String = "IDENTREGA") As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT ISNULL(MAX(" & campo & "), 0) as ENTREGAS")
        strSQL.Append(" FROM ")
        strSQL.Append(tabla)
        strSQL.Append(" WHERE")
        strSQL.Append("   IDPROGRAMACION = @IDPROGRAMACION")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el número de entregas para una programación específica
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada al número de entregas de la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarTotalEntregas(ByVal eEntidad As PROGRAMACION, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE")
        strSQL.Append("   SAB_URMIM_PROGRAMACION")
        strSQL.Append(" SET ENTREGAS=@ENTREGAS, AUUSUARIOMODIFICACION=@AUUSUARIOMODIFICACION, AUFECHAMODIFICACION=@AUFECHAMODIFICACION")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDPROGRAMACION = @IDPROGRAMACION")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = eEntidad.AUUSUARIOMODIFICACION
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = eEntidad.AUFECHAMODIFICACION
        args(3) = New SqlParameter("@ENTREGAS", SqlDbType.Int)
        args(3).Value = eEntidad.ENTREGAS

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Elimina el detalle de entregas para una programación específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación de la que se desean eliminar las entregas</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <param name="entregas">Filtro del número de entregas a eliminar</param>
    ''' <returns>Un entero indicando si se ha eliminado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function borrarEntregas(ByVal idProgramacion As Integer, ByVal tran As DistributedTransaction, Optional ByVal entregas As Integer = -1) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" DELETE FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONENTREGA")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDPROGRAMACION = @IDPROGRAMACION")

        If entregas > -1 Then
            strSQL.Append("   AND IDENTREGA > " & entregas)
        End If

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega el detalle de entregas para una programación específica
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada a las entregas de la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function ingresarEntregas(ByVal eEntidad As ENTREGAPROGRAMACION, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONENTREGA(IDPROGRAMACION,IDENTREGA,NUMEROENTREGA,PORCENTAJEENTREGA,")
        strSQL.Append("   DIASENTREGA,AUUSUARIOCREACION,AUFECHACREACION,AUUSUARIOMODIFICACION,AUFECHAMODIFICACION)")
        strSQL.Append(" VALUES")
        strSQL.Append("   (@IDPROGRAMACION,@IDENTREGA,@NUMEROENTREGA,@PORCENTAJEENTREGA,")
        strSQL.Append("   @DIASENTREGA,@AUUSUARIOCREACION,@AUFECHACREACION,NULL,NULL)")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDENTREGA", SqlDbType.Int)
        args(1).Value = eEntidad.IDENTREGA
        args(2) = New SqlParameter("@NUMEROENTREGA", SqlDbType.Int)
        args(2).Value = eEntidad.NUMEROENTREGA
        args(3) = New SqlParameter("@PORCENTAJEENTREGA", SqlDbType.Decimal)
        args(3).Value = eEntidad.PORCENTAJEENTREGA
        args(4) = New SqlParameter("@DIASENTREGA", SqlDbType.Int)
        args(4).Value = eEntidad.DIASENTREGA
        args(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(5).Value = eEntidad.AUUSUARIOCREACION
        args(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(6).Value = eEntidad.AUFECHACREACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el detalle de entregas para una programación específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación que se desea consultar</param>
    ''' <returns>Detalle de entregas para la programación en forma de arreglo</returns>
    ''' <remarks></remarks>
    Public Function obtenerEntregasProgramacion(ByVal idProgramacion As Integer) As ArrayList

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT")
        strSQL.Append("   IDENTREGA, NUMEROENTREGA, PORCENTAJEENTREGA, DIASENTREGA")
        strSQL.Append(" FROM")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONENTREGA")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDPROGRAMACION = @IDPROGRAMACION")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim arr As New ArrayList

        Do While dr.Read
            Dim s(3) As String
            s(0) = dr.Item("IDENTREGA")
            s(1) = dr.Item("NUMEROENTREGA")
            s(2) = dr.Item("PORCENTAJEENTREGA")
            s(3) = dr.Item("DIASENTREGA")
            arr.Add(s)
        Loop

        dr.Close()

        Return arr

    End Function

    ''' <summary>
    ''' Actualiza el número de entregas para un producto de una programación específica
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada a la programación</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarEntregaProductoProgramacion(ByVal eEntidad As ENTREGAPROGRAMACION, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONENTREGADETALLE SET ENTREGA = @ENTREGA, OBSERVACION=@OBSERVACION, ")
        strSQL.Append("   AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE")
        strSQL.Append("   IDPROGRAMACION = @IDPROGRAMACION AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(5) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@ENTREGA", SqlDbType.Int)
        args(1).Value = eEntidad.IDENTREGA
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = eEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = eEntidad.AUUSUARIOMODIFICACION
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = eEntidad.AUFECHAMODIFICACION
        args(5) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(5).Value = eEntidad.OBSERVACION

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el número de renglones con definición de entrega para una programación específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación que se desea consultar</param>
    ''' <returns>Un entero indicando el número de renglones con entregas definidas</returns>
    ''' <remarks></remarks>
    Public Function obtenerRenglonesEntrega(ByVal idProgramacion As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("   (SELECT COUNT (*) FROM SAB_URMIM_PROGRAMACIONENTREGADETALLE WHERE IDPROGRAMACION = @IDPROGRAMACION) - ")
        strSQL.Append("   (SELECT COUNT (*) FROM SAB_URMIM_PROGRAMACIONENTREGADETALLE WHERE IDPROGRAMACION = @IDPROGRAMACION AND ENTREGA = 0) as total ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega una observación para un producto de un establecimiento de una programación definida
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada a la programación</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarObservacion(ByVal eEntidad As PROGRAMACIONPRODUCTO) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_URMIM_PROGRAMACIONOBSERVACION( ")
        strSQL.Append(" IDPROGRAMACION, IDESTABLECIMIENTO, IDPRODUCTO, IDOBSERVACION, TIPO, FECHA , OBSERVACION, USUARIO) ")
        strSQL.Append(" VALUES( ")
        strSQL.Append(" @IDPROGRAMACION, @IDESTABLECIMIENTO, @IDPRODUCTO, @IDOBSERVACION, @TIPO, @FECHA, @OBSERVACION, @USUARIO) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = eEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@IDOBSERVACION", SqlDbType.Int)
        args(3).Value = eEntidad.IDOBSERVACION
        args(4) = New SqlParameter("@TIPO", SqlDbType.Int)
        args(4).Value = eEntidad.TIPOOBSERVACION
        args(5) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(5).Value = eEntidad.AUFECHACREACION
        args(6) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(6).Value = eEntidad.OBSERVACION
        args(7) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(7).Value = eEntidad.AUUSUARIOCREACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el siguiente correlativo de la tabla para una observación de una programación de compras
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada a la programación</param>
    ''' <returns>Nuevo correlativo de la tabla</returns>
    ''' <remarks></remarks>
    Public Function obtenerIdObservacion(ByVal eEntidad As PROGRAMACIONPRODUCTO) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT isnull(max(IDOBSERVACION), 0) + 1 FROM SAB_URMIM_PROGRAMACIONOBSERVACION ")
        strSQL.Append(" WHERE IDPROGRAMACION = @IDPROGRAMACION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPRODUCTO = @IDPRODUCTO")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = eEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene un listado de las observaciones para una programación específica
    ''' </summary>
    ''' <param name="eEntidad">Entidad relacionada a la programación</param>
    ''' <returns>Listado de observaciones en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerListaObservaciones(ByVal eEntidad As PROGRAMACIONPRODUCTO) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   po.fecha, po.observacion, po.usuario, cp.desclargo, cp.corrproducto, cp.descripcion as um, ")
        strSQL.Append("   e.nombre, case when po.tipo = 1 then 'Observación a la captura de datos' else 'Observación a ajuste de datos' end as tipoObs ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_urmim_programacionobservacion po ")
        strSQL.Append("     inner join vv_catalogoproductos cp on ")
        strSQL.Append("       po.idProducto = cp.idProducto ")
        strSQL.Append("     inner join sab_cat_establecimientos e on ")
        strSQL.Append("       po.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append(" where ")
        strSQL.Append("   po.idProgramacion = @idProgramacion and ")
        strSQL.Append("   e.idEstablecimiento = @idEstablecimiento and ")
        strSQL.Append("   (po.idProducto = @idProducto or @idProducto = 0) and ")
        strSQL.Append("   po.tipo = @tipo ")
        strSQL.Append(" order by cp.corrproducto, po.fecha ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = eEntidad.IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(2).Value = eEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@TIPO", SqlDbType.Int)
        args(3).Value = eEntidad.TIPOOBSERVACION

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    '**************************************************************
    ''' <summary>
    ''' Obtiene el listado de establecimientos que pueden ver una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a consultar</param>
    ''' <returns>Lista de establecimientos en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerEstablecimientosProgramacion(ByVal IDPROGRAMACION As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   pd.idProgramacion, e.idEstablecimiento, e.nombre, pd.estado, pd.presupuestoasignado ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_urmim_programaciondetalle pd ")
        strSQL.Append("     inner join sab_cat_establecimientos e on ")
        strSQL.Append("       pd.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append(" where ")
        strSQL.Append("   pd.idProgramacion = @IDPROGRAMACION ")
        strSQL.Append(" order by ")
        strSQL.Append("   e.nombre asc ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega el detalle de programación para un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación para la que se desea agregar el establecimiento</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a agregar</param>
    ''' <param name="USUARIO">Usuario que agrega el detalle</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarProgramacionEstablecimientos(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal USUARIO As String) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_URMIM_PROGRAMACIONDETALLE(IDPROGRAMACION, IDESTABLECIMIENTO, ESTADO, AUUSUARIOCREACION, AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION) ")
        strSQL.Append("  VALUES(@IDPROGRAMACION, @IDESTABLECIMIENTO, 0, @USUARIO, @FECHA, NULL, NULL) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(2).Value = USUARIO
        args(3) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(3).Value = Now

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Elimina el detalle de programación para un establecimiento específico
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación para la que se desea eliminar el establecimiento</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento a eliminar</param>
    ''' <returns>Un entero indicando si se ha eliminado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function eliminarProgramacionEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM ")
        strSQL.Append("  SAB_URMIM_PROGRAMACIONDETALLE ")
        strSQL.Append("  WHERE ")
        strSQL.Append("  IDPROGRAMACION = @IDPROGRAMACION AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega todos los hospitales, regiones y el almacén el paraiso al detalle de una programación específica
    ''' </summary>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a la que se agregarán los establecimientos</param>
    ''' <param name="USUARIO">Usuario que agrega los establecimientos</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se han agregado o no los registros en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function agregarListaHospitalesRegionesParaiso(ByVal IDPROGRAMACION As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" insert into SAB_URMIM_PROGRAMACIONDETALLE ")
        strSQL.Append(" select ")
        strSQL.Append("   @IDPROGRAMACION, idEstablecimiento, 0, 0, 0, 0, @USUARIO, @FECHA, NULL, NULL ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append(" where ")
        strSQL.Append("   idTipoEstablecimiento in (3, 7, 8, 10) and ")
        strSQL.Append("   idEstablecimiento not in (506, 619, 656, 763, 655, 833, 1091 ,1415 ) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION
        args(1) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(1).Value = USUARIO
        args(2) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(2).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el total de establecimientos para una programación específica
    ''' </summary>
    ''' <param name="idProgramacion">Identificador de la programación a consultar</param>
    ''' <returns>Un entero identificando el total de establecimientos relacionados a la programación</returns>
    ''' <remarks></remarks>
    Public Function obtenerTotalEstablecimientosProgramacion(ByVal idProgramacion As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONDETALLE pd ")
        strSQL.Append(" where ")
        strSQL.Append("   idProgramacion = @IDPROGRAMACION ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene un listado de las programaciones disponibles para ser consolidadas
    ''' </summary>
    ''' <returns>Listado de programaciones disponibles en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDsProgramacionDisponible() As DataSet

        Dim strSQL As New StringBuilder
        'SelectTabla(strSQL)

        strSQL.Append(" SELECT ")
        strSQL.Append("   (convert(varchar, MONTH(P.FECHAPROGRAMACION)) + '/' + convert(varchar, YEAR(P.FECHAPROGRAMACION))) AS PERIODO, ")
        strSQL.Append("   P.IDPROGRAMACION, P.DESCRIPCION, S.IDSUMINISTRO, S.DESCRIPCION AS SUMINISTRO ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACION P ")
        strSQL.Append("     INNER JOIN SAB_CAT_SUMINISTROS S ON ")
        strSQL.Append("       P.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   P.ESTADO = 4 ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   YEAR(P.FECHAPROGRAMACION) DESC, MONTH(P.FECHAPROGRAMACION) DESC, IDPROGRAMACION DESC ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Obtiene la información de una o varias programaciones de compras
    ''' </summary>
    ''' <param name="lista">Lista de programaciones para las que se desea su información</param>
    ''' <returns>Lista de información para las programaciones en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDsProgramacionListaID(ByVal lista As String) As DataSet

        Dim strSQL As New StringBuilder
        'SelectTabla(strSQL)

        strSQL.Append(" SELECT ")
        strSQL.Append("   (convert(varchar, MONTH(P.FECHAPROGRAMACION)) + '/' + convert(varchar, YEAR(P.FECHAPROGRAMACION))) AS FPROGRAMACION, ")
        strSQL.Append("   (convert(varchar, MONTH(P.FECHAULTIMOPROGRAMA)) + '/' + convert(varchar, YEAR(P.FECHAULTIMOPROGRAMA))) AS FULTIMO, ")
        strSQL.Append("   (convert(varchar, MONTH(P.FECHACORTE)) + '/' + convert(varchar, YEAR(P.FECHACORTE))) AS FCORTE, ")
        strSQL.Append("   P.IDPROGRAMACION, P.DESCRIPCION, ")
        strSQL.Append("   P.MESESCPM, P.MESESPLANEACION, P.INDICEINFLACION, P.IDSUMINISTRO, S.DESCRIPCION AS SUMINISTRO ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACION P ")
        strSQL.Append("     INNER JOIN SAB_CAT_SUMINISTROS S ON ")
        strSQL.Append("       P.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   P.ESTADO = 4 AND P.IDPROGRAMACION IN (")
        strSQL.Append(lista)
        strSQL.Append(") ORDER BY ")
        strSQL.Append("   YEAR(P.FECHAPROGRAMACION) DESC, MONTH(P.FECHAPROGRAMACION) DESC, IDPROGRAMACION DESC ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Obtiene una lista de inconsistencias para una serie de programaciones de compra
    ''' </summary>
    ''' <param name="idSuministro">Identificador del suministro de las programaciones</param>
    ''' <param name="lista">Lista de programaciones que se desean verificar</param>
    ''' <param name="productos">Lista de productos a verificar</param>
    ''' <returns>Lista de datos relevantes para verificación en forma de arreglo</returns>
    ''' <remarks></remarks>
    Public Function obtenerListaInconsistenciasProgramacion(ByVal idSuministro As Integer, ByVal lista As ArrayList, ByRef productos As ArrayList) As Array

        Dim strSQL As New StringBuilder
        Dim total As Integer = obtenerTotalInconsistenciasProgramacion(idSuministro, lista)

        Dim tmp As New ArrayList

        Dim matrix(total, ((lista.Count - 1) * 2) + 1) As Decimal

        strSQL.Append(" with s as( ")
        strSQL.Append(" 	select ")
        strSQL.Append(" 	  vv.corrproducto, ")

        For i As Integer = 0 To lista.Count - 1

            If i > 0 Then
                strSQL.Append(" 	  ,")
            End If

            strSQL.Append(" 	  case when l" & i + 1 & ".precio is null then -1 else convert(decimal(15,2), l" & i + 1 & ".precio) end as precio" & i + 1 & ", ")
            strSQL.Append(" 	  case when l" & i + 1 & ".entrega is null then -1 else l" & i + 1 & ".entrega end as entrega" & i + 1 & " ")

        Next

        strSQL.Append(" 	from ")
        strSQL.Append(" 	  VV_CATALOGOPRODUCTOS VV ")

        For i As Integer = 0 To lista.Count - 1

            strSQL.Append(" 		left outer join fn_ListaProductosProgramacion(" & lista(i) & ") l" & i + 1 & " ")
            strSQL.Append(" 		  on vv.idProducto = l" & i + 1 & ".idProducto ")

        Next

        strSQL.Append(" 	where ")
        strSQL.Append(" 	  vv.idTipoSuministro = @IDSUMINISTRO ")
        strSQL.Append(" ) ")
        strSQL.Append("  ")
        strSQL.Append(" select ")
        strSQL.Append("   * ")
        strSQL.Append(" from  ")
        strSQL.Append("   s ")
        strSQL.Append(" where ")

        For i As Integer = 0 To lista.Count - 1

            If i > 0 Then
                strSQL.Append("   or ")
            End If

            strSQL.Append("   s.entrega" & i + 1 & " <> -1 ")

        Next

        strSQL.Append(" order by ")
        strSQL.Append("   s.corrproducto asc ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = idSuministro

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Dim k As Integer = 0

        Do While dr.Read

            tmp.Add(dr.Item(0))

            For j As Integer = 0 To lista.Count - 1

                'Precios primero
                matrix(k, (j * 2)) = dr.Item((j * 2) + 1)
                matrix(k, (j * 2) + 1) = dr.Item((j * 2) + 2)

            Next

            k += 1

        Loop

        dr.Close()

        productos = tmp

        Return matrix

    End Function

    ''' <summary>
    ''' Obtiene el total de inconsistencias para una serie de programaciones de compra
    ''' </summary>
    ''' <param name="idSuministro">Identificador del suministro de las programaciones</param>
    ''' <param name="lista">Lista de programaciones que se desean verificar</param>
    ''' <returns>Un entero indicando el número de registros de la programación</returns>
    ''' <remarks></remarks>
    Public Function obtenerTotalInconsistenciasProgramacion(ByVal idSuministro As Integer, ByVal lista As ArrayList) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" with s as( ")
        strSQL.Append(" 	select ")
        strSQL.Append(" 	  vv.corrproducto, ")

        For i As Integer = 0 To lista.Count - 1

            If i > 0 Then
                strSQL.Append(" 	  ,")
            End If

            strSQL.Append(" 	  case when l" & i + 1 & ".precio is null then -1 else convert(decimal(15,2), l" & i + 1 & ".precio) end as precio" & i + 1 & ", ")
            strSQL.Append(" 	  case when l" & i + 1 & ".entrega is null then -1 else l" & i + 1 & ".entrega end as entrega" & i + 1 & " ")

        Next

        strSQL.Append(" 	from ")
        strSQL.Append(" 	  VV_CATALOGOPRODUCTOS VV ")

        For i As Integer = 0 To lista.Count - 1

            strSQL.Append(" 		left outer join fn_ListaProductosProgramacion(" & lista(i) & ") l" & i + 1 & " ")
            strSQL.Append(" 		  on vv.idProducto = l" & i + 1 & ".idProducto ")

        Next

        strSQL.Append(" 	where ")
        strSQL.Append(" 	  vv.idTipoSuministro = @IDSUMINISTRO ")
        strSQL.Append(" ) ")
        strSQL.Append("  ")
        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from  ")
        strSQL.Append("   s ")
        strSQL.Append(" where ")

        For i As Integer = 0 To lista.Count - 1

            If i > 0 Then
                strSQL.Append("   or ")
            End If

            strSQL.Append("   s.entrega" & i + 1 & " <> -1 ")

        Next

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = idSuministro

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene una lista del cuadro de entregas para una serie de programaciones de compras
    ''' </summary>
    ''' <param name="lista">Lista de programaciones que se desean verificar</param>
    ''' <returns>Lista de datos relevantes para verificación en forma de arreglo</returns>
    ''' <remarks></remarks>
    Public Function obtenerListaEntregasProgramacion(ByVal lista As ArrayList) As Array

        Dim strSQL As New StringBuilder
        Dim total As Integer = TotalEntregasProgramacion(lista)

        Dim matrix(total, ((lista.Count - 1) * 2) + 2) As Decimal

        strSQL.Append(" with s as ( ")
        strSQL.Append("   select 1 as idEntrega, 1 as numeroEntrega union ")
        strSQL.Append("   select 2 as idEntrega, 1 as numeroEntrega union ")
        strSQL.Append("   select 2 as idEntrega, 2 as numeroEntrega union ")
        strSQL.Append("   select 3 as idEntrega, 1 as numeroEntrega union ")
        strSQL.Append("   select 3 as idEntrega, 2 as numeroEntrega union ")
        strSQL.Append("   select 3 as idEntrega, 3 as numeroEntrega union ")
        strSQL.Append("   select 4 as idEntrega, 1 as numeroEntrega union ")
        strSQL.Append("   select 4 as idEntrega, 2 as numeroEntrega union ")
        strSQL.Append("   select 4 as idEntrega, 3 as numeroEntrega union ")
        strSQL.Append("   select 4 as idEntrega, 4 as numeroEntrega ")
        strSQL.Append(" ) ")
        strSQL.Append(" ")
        strSQL.Append(" select ")
        strSQL.Append("   s.idEntrega, ")

        For i As Integer = 0 To lista.Count - 1

            If i > 0 Then
                strSQL.Append(" 	  ,")
            End If

            strSQL.Append(" 	  case when ep" & i + 1 & ".porcentajeEntrega is null then -1 else convert(decimal(15,2), ep" & i + 1 & ".porcentajeEntrega) end as porcentajeEntrega" & i + 1 & ", ")
            strSQL.Append(" 	  case when ep" & i + 1 & ".diasEntrega is null then -1 else ep" & i + 1 & ".diasEntrega end as diasEntrega" & i + 1 & " ")

        Next

        strSQL.Append(" from ")
        strSQL.Append("   s ")

        For i As Integer = 0 To lista.Count - 1

            strSQL.Append(" 		left outer join fn_EntregasProgramacion(" & lista(i) & ") ep" & i + 1 & " on ")
            strSQL.Append("           s.idEntrega = ep" & i + 1 & ".idEntrega and ")
            strSQL.Append("           s.numeroEntrega = ep" & i + 1 & ".numeroEntrega ")

        Next

        strSQL.Append(" where ")

        For i As Integer = 0 To lista.Count - 1

            If i > 0 Then
                strSQL.Append("   or ")
            End If

            strSQL.Append("   ep" & i + 1 & ".porcentajeEntrega <> -1 ")

        Next

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())
        Dim k As Integer = 0

        Do While dr.Read

            matrix(k, 0) = dr.Item(0)

            For j As Integer = 0 To lista.Count - 1

                'Precios primero
                matrix(k, (j * 2) + 1) = dr.Item((j * 2) + 1)
                matrix(k, (j * 2) + 2) = dr.Item((j * 2) + 2)

            Next

            k += 1

        Loop

        dr.Close()

        Return matrix

    End Function

    ''' <summary>
    ''' Obtiene el total de entregas para una serie de programaciones de compras
    ''' </summary>
    ''' <param name="lista">Lista de programaciones que se desean verificar</param>
    ''' <returns>Un entero identificando el total de entregas para la serie de programaciones</returns>
    ''' <remarks></remarks>
    Public Function TotalEntregasProgramacion(ByVal lista As ArrayList) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" with s as ( ")
        strSQL.Append("   select 1 as idEntrega, 1 as numeroEntrega union ")
        strSQL.Append("   select 2 as idEntrega, 1 as numeroEntrega union ")
        strSQL.Append("   select 2 as idEntrega, 2 as numeroEntrega union ")
        strSQL.Append("   select 3 as idEntrega, 1 as numeroEntrega union ")
        strSQL.Append("   select 3 as idEntrega, 2 as numeroEntrega union ")
        strSQL.Append("   select 3 as idEntrega, 3 as numeroEntrega union ")
        strSQL.Append("   select 4 as idEntrega, 1 as numeroEntrega union ")
        strSQL.Append("   select 4 as idEntrega, 2 as numeroEntrega union ")
        strSQL.Append("   select 4 as idEntrega, 3 as numeroEntrega union ")
        strSQL.Append("   select 4 as idEntrega, 4 as numeroEntrega ")
        strSQL.Append(" ) ")
        strSQL.Append(" ")
        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   s ")

        For i As Integer = 0 To lista.Count - 1

            strSQL.Append(" 		left outer join fn_EntregasProgramacion(" & lista(i) & ") ep" & i + 1 & " on ")
            strSQL.Append("           s.idEntrega = ep" & i + 1 & ".idEntrega and ")
            strSQL.Append("           s.numeroEntrega = ep" & i + 1 & ".numeroEntrega ")

        Next

        strSQL.Append(" where ")

        For i As Integer = 0 To lista.Count - 1

            If i > 0 Then
                strSQL.Append("   or ")
            End If

            strSQL.Append("   ep" & i + 1 & ".numeroEntrega <> -1 ")

        Next

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Agrega el detalle de programaciones consolidadas para un grupo
    ''' </summary>
    ''' <param name="IDGRUPO">Identificador del grupo a agregar</param>
    ''' <param name="IDPROGRAMACION">Identificador de la programación a agregar al grupo</param>
    ''' <param name="USUARIO">Usuario que agrega la programación al grupo</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function insertarGrupoProgramacion(ByVal IDGRUPO As Integer, ByVal IDPROGRAMACION As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_URMIM_PROGRAMACIONGRUPO ")
        strSQL.Append(" (IDGRUPO, IDPROGRAMACION, IDFUENTEFINANCIAMIENTO, AUUSUARIOCREACION, ")
        strSQL.Append("  AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" (@IDGRUPO, @IDPROGRAMACION, NULL, @AUUSUARIOCREACION, ")
        strSQL.Append("  @AUFECHACREACION, NULL, NULL) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO
        args(1) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(1).Value = IDPROGRAMACION
        args(2) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = USUARIO
        args(3) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(3).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el siguiente correlativo de la tabla para el grupo consolidado de programaciones de compra
    ''' </summary>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Nuevo correlativo de la tabla</returns>
    ''' <remarks></remarks>
    Public Function obtenerMaxGrupo(ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" select isnull(max(idgrupo),0)+1 from dbo.SAB_URMIM_GRUPO ")

        Return SqlHelper.ExecuteScalar(tran.SqlTransaction, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Obtiene el listado de grupos de programaciones consolidadas
    ''' </summary>
    ''' <returns>Lista de grupos en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerGrupos() As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   distinct pg.idGrupo, s.descripcion, s.idsuministro, g.estado ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_URMIM_PROGRAMACIONGRUPO pg ")
        strSQL.Append("     inner join dbo.SAB_URMIM_PROGRAMACION p on ")
        strSQL.Append("       pg.idProgramacion = p.idProgramacion ")
        strSQL.Append("     inner join dbo.SAB_CAT_SUMINISTROS s on ")
        strSQL.Append("       p.idSuministro = s.idSuministro ")
        strSQL.Append("     inner join dbo.SAB_URMIM_GRUPO g on ")
        strSQL.Append("       pg.idGrupo = g.idGrupo ")
        strSQL.Append(" order by ")
        strSQL.Append("   idGrupo ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Obtiene el listado de programaciones relacionadas a un grupo específico
    ''' </summary>
    ''' <param name="idGrupo">Identificador del grupo a consultar</param>
    ''' <returns>Lista de programaciones en forma de arreglo</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionesGrupo(ByVal idGrupo As Integer) As ArrayList

        Dim arr As New ArrayList

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   p.descripcion ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_URMIM_PROGRAMACIONGRUPO pg ")
        strSQL.Append("     inner join dbo.SAB_URMIM_PROGRAMACION p on ")
        strSQL.Append("       pg.idProgramacion = p.idProgramacion ")
        strSQL.Append("     inner join dbo.SAB_CAT_SUMINISTROS s on ")
        strSQL.Append("       p.idSuministro = s.idSuministro ")
        strSQL.Append(" where ")
        strSQL.Append("   pg.idGrupo = @IDGRUPO ")
        strSQL.Append(" order by ")
        strSQL.Append("   p.descripcion ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = idGrupo

        Dim dr As SqlClient.SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Do While dr.Read
            arr.Add(dr.Item(0))
        Loop

        dr.Close()

        Return arr

    End Function

    ''' <summary>
    ''' Obtiene el listado de programaciones relacionadas a un grupo específico
    ''' </summary>
    ''' <param name="idGrupo">Identificador del grupo a consultar</param>
    ''' <returns>Lista de programaciones en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerProgramacionesGrupoDs(ByVal idGrupo As Integer) As DataSet

        Dim arr As New ArrayList

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   pg.idGrupo, pg.idProgramacion, p.descripcion, case when pg.idFuenteFinanciamiento is null then -1 else pg.idFuenteFinanciamiento end as idFuente,  ")
        strSQL.Append("   case when ff.idGrupo is null then -1 else ff.idGrupo end as idGrupoFF  ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_URMIM_PROGRAMACIONGRUPO pg ")
        strSQL.Append("     inner join dbo.SAB_URMIM_PROGRAMACION p on ")
        strSQL.Append("       pg.idProgramacion = p.idProgramacion ")
        strSQL.Append("     inner join dbo.SAB_CAT_SUMINISTROS s on ")
        strSQL.Append("       p.idSuministro = s.idSuministro ")
        strSQL.Append("     left outer join SAB_CAT_FUENTEFINANCIAMIENTOS ff on ")
        strSQL.Append("       pg.idFuenteFinanciamiento = ff.idFuenteFinanciamiento ")
        strSQL.Append(" where ")
        strSQL.Append("   pg.idGrupo = @IDGRUPO ")
        strSQL.Append(" order by ")
        strSQL.Append("   p.descripcion ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = idGrupo

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza la fuente de financiamiento para una programación específica
    ''' </summary>
    ''' <param name="IDGRUPO">Identificador del grupo de la programación</param>
    ''' <param name="IDPROGRAMACION">Identificador de la programación</param>
    ''' <param name="IDFUENTEFINANCIAMIENTO">Identificador de la fuente de financiamiento a relacionar con la programación</param>
    ''' <param name="USUARIO">Usuario que actualiza la fuente de financiamiento</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarFuenteProgramacion(ByVal IDGRUPO As Integer, ByVal IDPROGRAMACION As Integer, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE SAB_URMIM_PROGRAMACIONGRUPO SET ")
        strSQL.Append("   IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("   AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   IDGRUPO = @IDGRUPO and IDPROGRAMACION = @IDPROGRAMACION ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO
        args(1) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(1).Value = IDPROGRAMACION
        args(2) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(2).Value = IIf(IDFUENTEFINANCIAMIENTO = -1, DBNull.Value, IDFUENTEFINANCIAMIENTO)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = USUARIO
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega un nuevo grupo de programaciones consolidadas
    ''' </summary>
    ''' <param name="IDGRUPO">Identificador del grupo a agregar</param>
    ''' <param name="USUARIO">Usuario que agrega el grupo</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha agregado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function insertarGrupo(ByVal IDGRUPO As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_URMIM_GRUPO ")
        strSQL.Append(" (IDGRUPO, ESTADO, AUUSUARIOCREACION, ")
        strSQL.Append("  AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" (@IDGRUPO, 1, @AUUSUARIOCREACION, ")
        strSQL.Append("  @AUFECHACREACION, NULL, NULL) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO
        args(1) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(1).Value = USUARIO
        args(2) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(2).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Agrega los establecimientos consolidados de una serie de programaciones de compras
    ''' </summary>
    ''' <param name="IDGRUPO">Identificador del grupo de programaciones consolidadas</param>
    ''' <param name="USUARIO">Usuario que agrega los establecimientos</param>
    ''' <param name="lista">Lista de programaciones pertenecientes al grupo</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se han agregado o no los registros en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function insertarGrupoEstablecimientos(ByVal IDGRUPO As Integer, ByVal USUARIO As String, ByVal lista As ArrayList, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_URMIM_PROGRAMACIONGRUPOLUGARENTREGA ")
        strSQL.Append(" SELECT ")
        strSQL.Append("  DISTINCT @IDGRUPO, IDESTABLECIMIENTO, NULL, @AUUSUARIOCREACION, @AUFECHACREACION, NULL, NULL ")
        strSQL.Append(" FROM SAB_URMIM_PROGRAMACIONDETALLE WHERE ")
        strSQL.Append("  IDPROGRAMACION IN (")

        For i As Integer = 0 To lista.Count - 1
            If i = 0 Then
                strSQL.Append(lista(i))
            Else
                strSQL.Append("," & lista(i))
            End If
        Next

        strSQL.Append(")")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO
        args(1) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(1).Value = USUARIO
        args(2) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(2).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtiene el listado de establecimientos relacionados a las programaciones de un grupo específico
    ''' </summary>
    ''' <param name="IDGRUPO">Identificador del grupo a consultar</param>
    ''' <returns>Lista de establecimientos en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerGrupoEstablecimientos(ByVal IDGRUPO As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("   pgl.idGrupo, e.idEstablecimiento, e.nombre, ")
        strSQL.Append("   case when pgl.idAlmacen is null then -1 else pgl.idAlmacen end as idAlmacen ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONGRUPOLUGARENTREGA pgl ")
        strSQL.Append("     inner join SAB_CAT_ESTABLECIMIENTOS e ON ")
        strSQL.Append("       pgl.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   pgl.idGrupo = @IDGRUPO ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("    e.nombre ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el lugar de entrega para un establecimiento específico
    ''' </summary>
    ''' <param name="IDGRUPO">Identificador del grupo al que pertenece el establecimiento</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDALMACEN">Identificador del almacén de entrega a asociar</param>
    ''' <param name="USUARIO">Usuario que actualiza el lugar de entrega</param>
    ''' <param name="tran">Transacción relacionada a la conexión de la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarAlmacenProgramacion(ByVal IDGRUPO As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer, ByVal USUARIO As String, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE SAB_URMIM_PROGRAMACIONGRUPOLUGARENTREGA SET ")
        strSQL.Append("   IDALMACEN = @IDALMACEN, ")
        strSQL.Append("   AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        strSQL.Append(" WHERE ")
        strSQL.Append("   IDGRUPO = @IDGRUPO and (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IIf(IDALMACEN = -1, DBNull.Value, IDALMACEN)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = USUARIO
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = Now

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString(), args)

    End Function

    'Inconsistencias ***********************************************

    Public Function inconsistenciasPrecios(ByVal IDPROGRAMACION1 As Integer, ByVal IDPROGRAMACION2 As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   pp1.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion as um ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_URMIM_PROGRAMACIONPRODUCTO pp1 ")
        strSQL.Append("     inner join dbo.SAB_URMIM_PROGRAMACION p1 on ")
        strSQL.Append("       pp1.idProgramacion = p1.idProgramacion ")
        strSQL.Append("     inner join dbo.SAB_URMIM_PROGRAMACIONPRODUCTO pp2 on ")
        strSQL.Append("       pp1.idProducto = pp2.idProducto ")
        strSQL.Append("     inner join dbo.SAB_URMIM_PROGRAMACION p2 on ")
        strSQL.Append("       pp2.idProgramacion = p2.idProgramacion ")
        strSQL.Append("     inner join vv_catalogoProductos cp on ")
        strSQL.Append("       pp1.idProducto = cp.idProducto ")
        strSQL.Append(" where ")
        strSQL.Append("   p1.idProgramacion = @IDPROGRAMACION1 and ")
        strSQL.Append("   p2.idProgramacion = @IDPROGRAMACION2 and ")
        strSQL.Append("   (pp1.precio * (1+(p1.indiceinflacion/100))) <> (pp2.precio * (1+(p2.indiceinflacion/100))) ")
        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION1", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION1
        args(1) = New SqlParameter("@IDPROGRAMACION2", SqlDbType.Int)
        args(1).Value = IDPROGRAMACION2

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function inconsistenciasEntregas(ByVal IDPROGRAMACION1 As Integer, ByVal IDPROGRAMACION2 As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" with s as( ")
        strSQL.Append(" 	select ")
        strSQL.Append(" 	  ped1.idProducto, ped1.entrega as entrega1, ped2.entrega as entrega2 ")
        strSQL.Append(" 	from ")
        strSQL.Append(" 	  dbo.SAB_URMIM_PROGRAMACIONENTREGADETALLE ped1 ")
        strSQL.Append(" 		inner join dbo.SAB_URMIM_PROGRAMACIONENTREGADETALLE ped2 on ")
        strSQL.Append(" 		  ped1.idProducto = ped2.idProducto ")
        strSQL.Append(" 	where ")
        strSQL.Append(" 	  ped1.idProgramacion = @IDPROGRAMACION1 and ")
        strSQL.Append(" 	  ped2.idProgramacion = @IDPROGRAMACION2 and ")
        strSQL.Append(" 	  ped1.entrega <> ped2.entrega ")
        strSQL.Append(" ) ")
        strSQL.Append("  ")
        strSQL.Append(" select ")
        strSQL.Append("   s.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion as um ")
        strSQL.Append(" from ")
        strSQL.Append("   s ")
        strSQL.Append("     inner join vv_catalogoProductos cp on ")
        strSQL.Append("       s.idProducto = cp.idProducto ")
        strSQL.Append(" where ")
        strSQL.Append("   s.entrega1 > 0 and s.entrega2 > 0 ")
        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION1", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION1
        args(1) = New SqlParameter("@IDPROGRAMACION2", SqlDbType.Int)
        args(1).Value = IDPROGRAMACION2

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function inconsistenciasTablaEntregas(ByVal IDPROGRAMACION1 As Integer, ByVal IDPROGRAMACION2 As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_URMIM_PROGRAMACIONENTREGA pe1 ")
        strSQL.Append("     inner join dbo.SAB_URMIM_PROGRAMACIONENTREGA pe2 on ")
        strSQL.Append("       pe1.idEntrega = pe2.idEntrega and ")
        strSQL.Append("       pe1.numeroEntrega = pe2.numeroEntrega ")
        strSQL.Append(" where ")
        strSQL.Append("   pe1.idProgramacion = @IDPROGRAMACION1 and ")
        strSQL.Append("   pe2.idProgramacion = @IDPROGRAMACION2 and ")
        strSQL.Append("   (pe1.porcentajeEntrega <> pe2.porcentajeEntrega or pe1.diasEntrega <> pe2.diasEntrega) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION1", SqlDbType.Int)
        args(0).Value = IDPROGRAMACION1
        args(1) = New SqlParameter("@IDPROGRAMACION2", SqlDbType.Int)
        args(1).Value = IDPROGRAMACION2

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    '**************************************************************

    ''' <summary>
    ''' Obtiene el listado de programaciones según su estado
    ''' </summary>
    ''' <param name="estado">Filtro del estado de la programación</param>
    ''' <returns>Lista de programaciones en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDsProgramacionFiltrada(ByVal idProgramacion As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        strSQL.Append(" WHERE P.IDPROGRAMACION <> @IDPROGRAMACION ")
        strSQL.Append(" ORDER BY ")
        strSQL.Append("   YEAR(FECHAPROGRAMACION) DESC, MONTH(FECHAPROGRAMACION) DESC, IDPROGRAMACION DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMACION", SqlDbType.Int)
        args(0).Value = idProgramacion

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function reporteFuentesProgramacion(ByVal idGrupo As Integer, ByVal lista As ArrayList) As DataSet

        Dim strSQL As New StringBuilder

        'strSQL.Append(" with s as( ")
       
        'For i As Integer = 0 To lista.Count - 1
        '    If i > 0 Then
        '        strSQL.Append(" 	union ")
        '        strSQL.Append(" 	select idProducto, idEstablecimiento, cantidadcomprarajustada, entrega, fuente, precio from fn_DetalleFuenteProgramacion(@IDGRUPO, " & lista.Item(i) & ") ")
        '    Else
        '        strSQL.Append(" 	select idProducto, idEstablecimiento, cantidadcomprarajustada, entrega, fuente, precio from fn_DetalleFuenteProgramacion(@IDGRUPO, " & lista.Item(i) & ") ")
        '    End If
        'Next

        'strSQL.Append(" ) ")
        'strSQL.Append(" ")
        'strSQL.Append(" select ")
        'strSQL.Append("   cp.corrproducto, cp.desclargo, cp.descripcion, cp.codigonacionesunidas, ")
        'strSQL.Append("   e.nombre, s.cantidadcomprarajustada as cantidad, s.entrega, ")
        'strSQL.Append("   s.fuente, s.precio ")
        'strSQL.Append(" from ")
        'strSQL.Append("   s ")
        'strSQL.Append("     inner join vv_catalogoProductos cp on ")
        'strSQL.Append("       s.idProducto = cp.idProducto ")
        'strSQL.Append("     inner join sab_cat_establecimientos e on ")
        'strSQL.Append("       s.idEstablecimiento = e.idEstablecimiento ")
        'strSQL.Append(" order by ")
        'strSQL.Append("   cp.corrproducto asc ")

        strSQL.Append(" 	select * from fn_DetalleFuenteProgramacionCompleta(@IDGRUPO)  order by corrproducto asc 	 ")
        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = idGrupo

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerProgramacionesGrupos2(ByVal idGrupo As Integer) As ArrayList

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT ")
        strSQL.Append("   idProgramacion ")
        strSQL.Append(" FROM ")
        strSQL.Append("   SAB_URMIM_PROGRAMACIONGRUPO ")
        strSQL.Append(" where ")
        strSQL.Append("   idGrupo = @IDGRUPO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = idGrupo

        Dim arr As New ArrayList
        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Do While dr.Read
            arr.Add(dr.Item(0))
        Loop

        dr.Close()

        Return arr

    End Function

    Public Function verificarCierreGrupo(ByVal idGrupo As Integer) As Integer

        Dim strSQL As New StringBuilder
        Dim k As Integer
        Dim j As Integer

        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_URMIM_PROGRAMACIONGRUPO ")
        strSQL.Append(" where ")
        strSQL.Append("   idFuenteFinanciamiento is null and ")
        strSQL.Append("   idGrupo = @IDGRUPO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = idGrupo

        j = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        strSQL = New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.SAB_URMIM_PROGRAMACIONGRUPOLUGARENTREGA ")
        strSQL.Append(" where ")
        strSQL.Append("   idAlmacen is null and ")
        strSQL.Append("   idGrupo = @IDGRUPO ")

        k = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return j + k

    End Function

    Public Function actualizarGrupo(ByVal idGrupo As Integer, ByVal estado As Integer, ByVal usuario As String) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" UPDATE SAB_URMIM_GRUPO ")
        strSQL.Append("    SET ESTADO = @ESTADO, AUUSUARIOMODIFICACION = @USUARIO, AUFECHAMODIFICACION = @FECHA ")
        strSQL.Append("  WHERE IDGRUPO = @IDGRUPO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = idGrupo
        args(1) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(1).Value = estado
        args(2) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(2).Value = usuario
        args(3) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(3).Value = Now

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerEstadoGrupo(ByVal idGrupo As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT ESTADO FROM SAB_URMIM_GRUPO ")
        strSQL.Append("  WHERE IDGRUPO = @IDGRUPO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = idGrupo

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    '**************************************************************
    Public Function productosSeleccionables(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, IDPROGRAMACION As Integer, Optional ByVal CORRPRODUCTO As String = "", Optional IDPROGRAMA As Integer = 0) As DataSet
        Dim strSQL As New StringBuilder



        strSQL.Append(" SELECT ")
        strSQL.Append("   CP.IDPRODUCTO, CP.CODIGONOMBRE AS DESCLARGO, CP.IDUNIDADMEDIDA, CP.CORRPRODUCTO ")
        strSQL.Append(" FROM ")
        strSQL.Append("   VV_CATALOGOPRODUCTOS CP ")

        If IDPROGRAMA <> 0 Then
            strSQL.Append("       INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PP ON PP.IDPRODUCTO=CP.IDPRODUCTO ")
        End If
        strSQL.Append(" WHERE ")
        strSQL.Append("   CP.IDSUMINISTRO = @IDSUMINISTRO  ")

        strSQL.Append("  AND CP.IDPRODUCTO NOT IN (SELECT IDPRODUCTO FROM SAB_URMIM_PROGRAMACIONCONSOLIDADA WHERE IDPROGRAMACION=" & IDPROGRAMACION & ")")

        If CORRPRODUCTO <> "" Then
            strSQL.Append(" AND CORRPRODUCTO = @CORRPRODUCTO ")
        End If

        If IDPROGRAMA <> 0 Then
            strSQL.Append(" AND pp.idprograma = @IDPROGRAMA ")
        End If
        strSQL.Append(" ORDER BY DESCLARGO ASC ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(0).Value = IDSUMINISTRO
        args(1) = New SqlParameter("@CORRPRODUCTO", SqlDbType.VarChar)
        args(1).Value = CORRPRODUCTO
        args(2) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(2).Value = IDALMACEN
        args(3) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(3).Value = IDPROGRAMA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
End Class
