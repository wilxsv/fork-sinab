Partial Public Class dbPRODUCTOSPROGRAMAS

#Region " Métodos Agregados "

    Public Function ObtenerDataSetListaProductosProgramas() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PP.IDPRODUCTO, ")
        strSQL.Append("PP.IDPROGRAMA, ")
        strSQL.Append("CP.CORRPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO PRODUCTO, ")
        strSQL.Append("P.NOMBRE PROGRAMA ")
        strSQL.Append("FROM vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PP ")
        strSQL.Append("ON CP.IDPRODUCTO = PP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROGRAMAS P ")
        strSQL.Append("ON PP.IDPROGRAMA = P.IDPROGRAMA ")
        strSQL.Append("ORDER BY P.NOMBRE, CP.DESCLARGO ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function BuscarProductosProgramas(ByVal IDPRODUCTO As Int32, ByVal IDPROGRAMA As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPRODUCTO, IDPROGRAMA ")
        strSQL.Append(" FROM SAB_CAT_PRODUCTOSPROGRAMAS ")
        strSQL.Append(" WHERE (IDPRODUCTO = @IDPRODUCTO) AND (IDPROGRAMA = @IDPROGRAMA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO
        args(1) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(1).Value = IDPROGRAMA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Devuelve la lista de programas al que pertenece un producto.
    ''' </summary>
    ''' <returns>Dataset con la lista de programas.</returns>
    ''' <remarks>
    ''' Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' <history>
    '''   [AUTOR: José Alberto Chávez Loarca 10/02/07  Creado]
    ''' </history>
    ''' </remarks>
    Public Function ObtenerProgramasPorProducto(ByVal IDPRODUCTO As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PP.IDPROGRAMA, ")
        strSQL.Append("P.NOMBRE AS PROGRAMA, ")
        strSQL.Append("PP.IDPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION AS UNIDADMEDIDA ")
        strSQL.Append("FROM ")
        strSQL.Append("vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PP ")
        strSQL.Append("ON CP.IDPRODUCTO = PP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROGRAMAS P ")
        strSQL.Append("ON PP.IDPROGRAMA = P.IDPROGRAMA ")
        strSQL.Append("WHERE PP.IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = IDPRODUCTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerProductoxPrograma(ByVal IDPROGRAMA As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PP.IDPROGRAMA, ")
        strSQL.Append("P.NOMBRE AS PROGRAMA, ")
        strSQL.Append("PP.IDPRODUCTO, ")
        strSQL.Append("CP.DESCLARGO, ")
        strSQL.Append("CP.DESCRIPCION AS UNIDADMEDIDA ")
        strSQL.Append("FROM ")
        strSQL.Append("vv_CATALOGOPRODUCTOS CP ")
        strSQL.Append("INNER JOIN SAB_CAT_PRODUCTOSPROGRAMAS PP ")
        strSQL.Append("ON CP.IDPRODUCTO = PP.IDPRODUCTO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROGRAMAS P ")
        strSQL.Append("ON PP.IDPROGRAMA = P.IDPROGRAMA ")
        strSQL.Append("WHERE PP.IDPROGRAMA = @IDPROGRAMA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(0).Value = IDPROGRAMA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
#End Region

End Class
