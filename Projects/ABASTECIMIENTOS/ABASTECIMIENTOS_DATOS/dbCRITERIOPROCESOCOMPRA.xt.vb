Partial Public Class dbCRITERIOPROCESOCOMPRA

#Region " Métodos Agregados "

    Public Function ObtenerDataSetCriteriosProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDTIPOCRITERIO As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_CRITERIOSEVALUACION.DESCRIPCION, SAB_UACI_CRITERIOPROCESOCOMPRA.PORCENTAJE ")
        strSQL.Append(" FROM SAB_CAT_CRITERIOSEVALUACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_CRITERIOPROCESOCOMPRA ON SAB_CAT_CRITERIOSEVALUACION.IDCRITERIOEVALUACION = SAB_UACI_CRITERIOPROCESOCOMPRA.IDCRITERIOEVALUACION ")
        strSQL.Append(" WHERE (SAB_UACI_CRITERIOPROCESOCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_CRITERIOPROCESOCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND ")
        strSQL.Append(" (SAB_CAT_CRITERIOSEVALUACION.IDTIPOCRITERIO = @IDTIPOCRITERIO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDTIPOCRITERIO", SqlDbType.SmallInt)
        args(2).Value = IDTIPOCRITERIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetCriteriosPC(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDTIPOCRITERIO As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_CRITERIOPROCESOCOMPRA.IDCRITERIOEVALUACION as IDCRITERIO, SAB_CAT_CRITERIOSEVALUACION.DESCRIPCION as CRITERIO, SAB_UACI_CRITERIOPROCESOCOMPRA.PORCENTAJE ")
        strSQL.Append(" FROM SAB_CAT_CRITERIOSEVALUACION INNER JOIN ")
        strSQL.Append(" SAB_UACI_CRITERIOPROCESOCOMPRA ON SAB_CAT_CRITERIOSEVALUACION.IDCRITERIOEVALUACION = SAB_UACI_CRITERIOPROCESOCOMPRA.IDCRITERIOEVALUACION ")
        strSQL.Append(" WHERE (SAB_UACI_CRITERIOPROCESOCOMPRA.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_CRITERIOPROCESOCOMPRA.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND ")
        strSQL.Append(" (SAB_CAT_CRITERIOSEVALUACION.IDTIPOCRITERIO = @IDTIPOCRITERIO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDTIPOCRITERIO", SqlDbType.SmallInt)
        args(2).Value = IDTIPOCRITERIO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetCriteriosFinancieroProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT PORCENTAJEINDICESOLVENCIA, PORCENTAJECAPITALTRABAJO, PORCENTAJEENDEUDAMIENTO, PORCENTAJEREFERENCIASBANC, ")
        strSQL.Append(" PORCENTAJEFINANCIERO ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function EtiquetaCriterioTecnico(ByVal TABLA As String, ByVal CAMPO As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ETIQUETA ")
        strSQL.Append(" FROM SAB_CAT_ETIQUETASCAMPOS ")
        strSQL.Append(" WHERE (TABLA = @TABLA) AND (CAMPO = @CAMPO)")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@TABLA", SqlDbType.VarChar)
        args(0).Value = TABLA
        args(1) = New SqlParameter("@CAMPO", SqlDbType.VarChar)
        args(1).Value = CAMPO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene los criterios de evaluacion de un proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROCESOCOMPRA">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDPROVEEDOR">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="IDDETALLE">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <param name="TipoCompra">Especifica el valor a utilizar para filtrar la información.</param>
    ''' <returns>Dataset con los criterios de evaluacion por proceso de compra y proveedor</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CALIFICACIONRENGLONOFERTAS</description></item>
    ''' <item><description>SAB_UACI_CRITERIOPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_CAT_CRITERIOSEVALUACION</description></item>
    ''' <item><description>SAB_UACI_EXAMENOFERTA</description></item>
    ''' <item><description>SAB_UACI_PROCESOCOMPRAS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]    Creado
    ''' </history> 
    Public Function ObtenerDataSetCriteriosProcesoCompraRC(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal TipoCompra As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT CPP.IDCRITERIOEVALUACION, ")
        strSQL.Append("CE.DESCRIPCION + ' (' + CONVERT(VARCHAR(8),CPP.PORCENTAJE) + '%)' AS CRITERIO, CPP.PORCENTAJE, ")
        strSQL.Append("ISNULL((SELECT CRO.PORCENTAJE ")
        strSQL.Append("FROM SAB_UACI_CALIFICACIONRENGLONOFERTAS CRO ")
        strSQL.Append("WHERE CRO.IDESTABLECIMIENTO = CPP.IDESTABLECIMIENTO ")
        strSQL.Append("AND CRO.IDPROCESOCOMPRA = CPP.IDPROCESOCOMPRA ")
        strSQL.Append("AND CRO.IDCRITERIOEVALUACION = CPP.IDCRITERIOEVALUACION ")
        strSQL.Append("AND CRO.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND CRO.IDDETALLE = @IDDETALLE ")
        strSQL.Append("), 0) PORCENTAJE2 ")
        strSQL.Append("FROM SAB_UACI_CRITERIOPROCESOCOMPRA CPP ")
        strSQL.Append("INNER JOIN SAB_CAT_CRITERIOSEVALUACION CE ")
        strSQL.Append("ON CPP.IDCRITERIOEVALUACION = CE.IDCRITERIOEVALUACION ")
        strSQL.Append("WHERE CPP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CPP.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND CE.ESGLOBAL <> 1 ")
        If TipoCompra = 1 Then
            strSQL.Append(" AND CE.IDTIPOCRITERIO = 1")
            strSQL.Append(" union ")
            strSQL.Append(" SELECT 99, 'Evaluación Financiera (' + convert(varchar, pc.porcentajefinanciero) + '%)' , EO.PONDERACIONCAPITAL + EO.PONDERACIONSOLVENCIA + EO.PONDERACIONENDEUDAMIENTO + EO.PONDERACIONREFERENCIA AS PONDERACIONROEXAMEN,   EO.PONDERACIONCAPITAL + EO.PONDERACIONSOLVENCIA + EO.PONDERACIONENDEUDAMIENTO + EO.PONDERACIONREFERENCIA AS PORCENTAJE2")
            strSQL.Append(" FROM SAB_UACI_EXAMENOFERTA EO inner join SAB_UACI_PROCESOCOMPRAS pc ON EO.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND EO.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA")
            strSQL.Append(" WHERE (EO.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (EO.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) AND (EO.IDPROVEEDOR = @IDPROVEEDOR) ")
        ElseIf TipoCompra = 2 Then
            strSQL.Append(" AND CE.IDTIPOCRITERIO = 3")
        End If

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@IDDETALLE", SqlDbType.BigInt)
        args(3).Value = IDDETALLE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function Borrar(ByVal aEntidad As CRITERIOPROCESOCOMPRA) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_CRITERIOPROCESOCOMPRA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = aEntidad.IDPROCESOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
