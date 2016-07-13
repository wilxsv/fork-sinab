Partial Public Class dbHISTORICOPRECIOS

#Region " Metodos Agregados "

    ''' <summary>
    ''' Recupera el historico de precios de un producto.
    ''' </summary>
    ''' <param name="IDPRODUCTO">Identificador del producto.</param>
    ''' <returns>Dataset con la información del historial de precios</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_HISTORICOPRECIOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  25/09/2006    Creado
    ''' </history> 
    Public Function ObtenerHistorialProducto(ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("HP.IDPRODUCTO, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.PRECIOACTUAL, ")
        strSQL.Append("CP.DESCSUMINISTRO, ")
        strSQL.Append("CP.DESCGRUPO, ")
        strSQL.Append("CP.DESCSUBGRUPO, ")
        strSQL.Append("CP.DESCRIPCION, ")
        strSQL.Append("HP.FECHA, ")
        strSQL.Append("HP.PRECIO, ")
        strSQL.Append("HP.CODIGOLICITACION, ")
        strSQL.Append("HP.CORRELATIVO ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS as CP ")
        strSQL.Append("RIGHT OUTER JOIN SAB_CAT_HISTORICOPRECIOS as HP ")
        strSQL.Append("ON CP.IDPRODUCTO = HP.IDPRODUCTO ")
        strSQL.Append("WHERE CP.IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Registra los precios de los productos adjudicados en un proceso de compra dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="FECHAPRECIO">Fecha histórica en la que se registran los precios.</param>
    ''' <param name="USUARIOCREACION">Usuario que realiza la actualización.</param>
    ''' <param name="FECHACREACION">Fecha en la que se realiza la actualización.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Procedimientos utilizadas:
    ''' <list type="bullet">
    ''' <item>sproc_CopiarPreciosHistoricos</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function RegistrarPreciosHistoricos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal FECHAPRECIO As DateTime, ByVal USUARIOCREACION As String, ByVal FECHACREACION As DateTime) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_CopiarPreciosHistoricos")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(2).Direction = ParameterDirection.Input
        args(2).Value = IDPROCESOCOMPRA
        args(3) = New SqlParameter("@FECHAPRECIO", SqlDbType.DateTime)
        args(3).Direction = ParameterDirection.Input
        args(3).Value = FECHAPRECIO
        args(4) = New SqlParameter("@USUARIOCREACION", SqlDbType.VarChar)
        args(4).Direction = ParameterDirection.Input
        args(4).Value = USUARIOCREACION
        args(5) = New SqlParameter("@FECHACREACION", SqlDbType.DateTime)
        args(5).Direction = ParameterDirection.Input
        args(5).Value = FECHACREACION

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

#End Region

End Class
