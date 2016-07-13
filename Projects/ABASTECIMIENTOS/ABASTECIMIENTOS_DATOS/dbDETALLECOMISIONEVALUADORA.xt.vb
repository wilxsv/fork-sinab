Partial Public Class dbDETALLECOMISIONEVALUADORA

#Region "Metodos Adicionales"

    ''' <summary>
    ''' Obtiene un detalle de la comisión de evaluación.
    ''' </summary>
    ''' <param name="idcomision">Especifica el valor a utilizar para identificar la comisión.</param>
    ''' <param name="idestablecimiento">Especifica el campo a utilizar para identificar al establecimiento</param>
    ''' <returns>Dataset con el detalle de la comisión de evaluación.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLECOMISIONEVALUADORA</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ObtenerDetallePorComisionAN(ByVal IDCOMISION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DCE.IDCOMISION, ")
        strSQL.Append("DCE.IDDETALLE, ")
        strSQL.Append("DCE.IDEMPLEADO, ")
        strSQL.Append("DCE.NOMBRE AS NOMBRE, ")
        strSQL.Append("DCE.CARGO, ")
        strSQL.Append("DCE.ESTAHABILITADO ")
        strSQL.Append("FROM SAB_UACI_DETALLECOMISIONEVALUADORA DCE ")
        'strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        'strSQL.Append("ON DCE.IDEMPLEADO = E.IDEMPLEADO ")
        strSQL.Append("WHERE DCE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DCE.IDCOMISION = @IDCOMISION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(1).Value = IDCOMISION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene un detalle de la comisión de evaluación.
    ''' </summary>
    ''' <param name="idcomision">Especifica el valor a utilizar para identificar la comisión.</param>
    ''' <param name="idestablecimiento">Especifica el campo a utilizar para identificar al establecimiento</param>
    ''' <returns>Dataset con el detalle de la comisión de evaluación.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLECOMISIONEVALUADORA</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ObtenerDetallePorComision(ByVal IDCOMISION As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("DCE.IDCOMISION, ")
        strSQL.Append("DCE.IDDETALLE, ")
        'strSQL.Append("E.IDEMPLEADO, ")
        strSQL.Append("isnull(DCE.NOMBRE, '') NOMBRE, ")
        strSQL.Append("DCE.CARGO, ")
        strSQL.Append("DCE.ESTAHABILITADO ")
        strSQL.Append("FROM SAB_UACI_DETALLECOMISIONEVALUADORA DCE ")
        'strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS E ")
        'strSQL.Append("ON DCE.IDEMPLEADO = E.IDEMPLEADO ")
        strSQL.Append("WHERE DCE.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DCE.IDCOMISION = @IDCOMISION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(1).Value = IDCOMISION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Actualiza el registro del empleado para deshabilitarlo de una comisión.
    ''' </summary>
    ''' <param name="aEntidad">Entidad que representa al empleado</param>
    ''' <returns>Numero que representa si la actualizacion de la comisión de evaluación se realizo satisfactoriamente.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLECOMISIONEVALUADORA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ActualizarEmpleado(ByVal aEntidad As DETALLECOMISIONEVALUADORA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLECOMISIONEVALUADORA ")
        strSQL.Append(" SET ESTAHABILITADO = @ESTAHABILITADO ")
        strSQL.Append(" WHERE IDDETALLE = @IDDETALLE AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@ESTAHABILITADO", SqlDbType.SmallInt)
        args(0).Value = aEntidad.ESTAHABILITADO
        args(1) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDDETALLE
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el registro del empleado para deshabilitarlo de una comisión.
    ''' </summary>
    ''' <param name="aEntidad">Entidad que representa al empleado</param>
    ''' <returns>Numero que representa si la actualizacion de la comisión de evaluación se realizo satisfactoriamente.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_DETALLECOMISIONEVALUADORA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ActualizarEmpleadoAN(ByVal aEntidad As DETALLECOMISIONEVALUADORA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLECOMISIONEVALUADORA ")
        strSQL.Append(" SET ESTAHABILITADO = @ESTAHABILITADO ")
        strSQL.Append(" WHERE NOMBRE = @NOMBRE AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDCOMISION = @IDCOMISION")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@ESTAHABILITADO", SqlDbType.SmallInt)
        args(0).Value = aEntidad.ESTAHABILITADO
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = aEntidad.NOMBRE
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(2).Value = aEntidad.IDESTABLECIMIENTO
        args(3) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(3).Value = aEntidad.IDCOMISION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
