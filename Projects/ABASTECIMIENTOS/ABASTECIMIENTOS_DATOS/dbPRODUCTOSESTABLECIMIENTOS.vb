Imports System.Text

Public Class dbPRODUCTOSESTABLECIMIENTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Return -1

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int64) As listaPRODUCTOSESTABLECIMIENTOS
        Return Nothing
    End Function

#End Region

    Public Function contarProductosEstablecimiento(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal filtro As String = "") As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_cat_productosEstablecimientos pe ")
        strSQL.Append("     inner join dbo.vv_CATALOGOPRODUCTOS vv on ")
        strSQL.Append("       pe.idProducto = vv.idProducto ")
        strSQL.Append(" where ")
        strSQL.Append("   pe.idEstablecimiento = @IDESTABLECIMIENTO and ")
        strSQL.Append("   vv.idSuministro = 1 ")

        If filtro <> "" Then
            Dim flt() As String
            flt = filtro.Split("|")

            strSQL.Append("   and ")
            strSQL.Append(flt(0))
            strSQL.Append(" ")
            Select Case flt(2)
                Case "eq"
                    strSQL.Append(" = '")
                    strSQL.Append(flt(1))
                    strSQL.Append("'")
                Case "ne"
                    strSQL.Append(" like '%")
                    strSQL.Append(flt(1))
                    strSQL.Append("%' ")
            End Select

        End If

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function contarProductosNoEnEstablecimiento(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal filtro As String = "") As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   count(*) ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.vv_CATALOGOPRODUCTOS vv ")
        strSQL.Append("     left outer join sab_cat_productosEstablecimientos pe on ")
        strSQL.Append("       pe.idProducto = vv.idProducto and ")
        strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append(" where ")
        strSQL.Append("   vv.idSuministro = 1 and ")
        strSQL.Append("   pe.idProducto is null ")

        If filtro <> "" Then
            Dim flt() As String
            flt = filtro.Split("|")

            strSQL.Append("   and ")
            strSQL.Append(flt(0))
            strSQL.Append(" ")
            Select Case flt(2)
                Case "eq"
                    strSQL.Append(" = '")
                    strSQL.Append(flt(1))
                    strSQL.Append("'")
                Case "ne"
                    strSQL.Append(" like '%")
                    strSQL.Append(flt(1))
                    strSQL.Append("%' ")
            End Select

        End If

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerListaProductosEstablecimientos(ByVal idEstablecimiento As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("  vv.idProducto, vv.corrproducto, vv.desclargo, vv.descripcion ")
        strSQL.Append(" from ")
        strSQL.Append("  sab_cat_productosEstablecimientos pe ")
        strSQL.Append("    inner join dbo.vv_CATALOGOPRODUCTOS vv on ")
        strSQL.Append("      pe.idProducto = vv.idProducto ")
        strSQL.Append(" where ")
        strSQL.Append("  pe.idEstablecimiento = @IDESTABLECIMIENTO and ")
        strSQL.Append("  vv.idSuministro = 1 ")
        strSQL.Append(" order by ")
        strSQL.Append("  vv.corrproducto asc ")

        Dim args(0) As SqlClient.SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    Public Function obtenerListaProductosNoEnEstablecimientos(ByVal idEstablecimiento As Integer, ByVal campoOrden As String, ByVal tipoOrden As String, ByVal inicio As Integer, ByVal limite As Integer, Optional ByVal filtro As String = "") As ArrayList

        Dim strSQL As New StringBuilder
        Dim arr As New ArrayList

        strSQL.Append(" with s as ( ")
        strSQL.Append("   select ")
        strSQL.Append("     row_number() over(order by ")
        strSQL.Append(campoOrden)
        strSQL.Append(" ")
        strSQL.Append(tipoOrden)
        strSQL.Append(") as linea, ")
        strSQL.Append("     vv.idProducto, vv.corrproducto, vv.desclargo, vv.descripcion ")
        strSQL.Append(" from ")
        strSQL.Append("   dbo.vv_CATALOGOPRODUCTOS vv ")
        strSQL.Append("     left outer join sab_cat_productosEstablecimientos pe on ")
        strSQL.Append("       pe.idProducto = vv.idProducto and ")
        strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append(" where ")
        strSQL.Append("   vv.idSuministro = 1 and ")
        strSQL.Append("   pe.idProducto is null ")

        If filtro <> "" Then
            Dim flt() As String
            flt = filtro.Split("|")

            strSQL.Append("   and ")
            strSQL.Append(flt(0))
            strSQL.Append(" ")
            Select Case flt(2)
                Case "eq"
                    strSQL.Append(" = '")
                    strSQL.Append(flt(1))
                    strSQL.Append("'")
                Case "ne"
                    strSQL.Append(" like '%")
                    strSQL.Append(flt(1))
                    strSQL.Append("%' ")
            End Select

        End If

        strSQL.Append(" ) ")
        strSQL.Append(" ")
        strSQL.Append(" select ")
        strSQL.Append("   idProducto, corrproducto, desclargo, descripcion ")
        strSQL.Append(" from ")
        strSQL.Append("   s ")
        strSQL.Append(" where ")
        strSQL.Append("   linea between @INICIO and @FIN ")
        strSQL.Append(" order by ")
        strSQL.Append(campoOrden)
        strSQL.Append(" ")
        strSQL.Append(tipoOrden)

        Dim args(2) As SqlClient.SqlParameter
        args(0) = New SqlClient.SqlParameter("@INICIO", SqlDbType.Int)
        args(0).Value = inicio
        args(1) = New SqlClient.SqlParameter("@FIN", SqlDbType.Int)
        args(1).Value = inicio + limite
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = idEstablecimiento

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

        While dr.Read

            Dim arrDatos(3) As String
            arrDatos(0) = dr.Item("corrproducto")
            arrDatos(1) = dr.Item("desclargo")
            arrDatos(2) = dr.Item("descripcion")
            arrDatos(3) = dr.Item("idProducto")
            arr.Add(arrDatos)

        End While

        dr.Close()

        Return arr

    End Function

    Public Function agregarProductoEstablecimiento(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO SAB_CAT_PRODUCTOSESTABLECIMIENTOS(IDESTABLECIMIENTO, IDPRODUCTO, AUUSUARIOCREACION, AUFECHACREACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION, ESTASINCRONIZADA) ")
        strSQL.Append("VALUES(@IDESTABLECIMIENTO, @IDPRODUCTO, NULL, NULL, NULL, NULL, 0) ")

        Dim args(1) As SqlClient.SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    Public Function quitarProductoEstablecimiento(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPRODUCTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_PRODUCTOSESTABLECIMIENTOS WHERE ")
        strSQL.Append("IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDPRODUCTO = @IDPRODUCTO ")

        Dim args(1) As SqlClient.SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me._cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    Public Function obtenerIdProductoEstablecimiento(ByVal codproducto As String) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" select ")
        strSQL.Append("   vvCP.idProducto,  vvCP.CORRPRODUCTO, vvCP.idUnidadMedida, vvCP.desclargo ")
        strSQL.Append(" from ")
        strSQL.Append("   VV_CATALOGOPRODUCTOS vvCP ")
        strSQL.Append(" where ")
        strSQL.Append("   vvCP.idTipoSuministro = 1 AND ")
        strSQL.Append("   vvCP.CORRPRODUCTO = '" + codproducto + "' ")

        
        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function obtenerCodigoProductoEstablecimiento(ByVal CODIGO As String) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   vvCP.idProducto, vvCP.idUnidadMedida, vvCP.desclargo ")
        strSQL.Append(" from ")
        strSQL.Append("   VV_CATALOGOPRODUCTOS vvCP ")
        strSQL.Append(" where ")
        strSQL.Append("   vvCP.idTipoSuministro = 1 AND ")
        strSQL.Append("   vvCP.corrproducto = @CODIGO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(0).Value = CODIGO

        Return SqlHelper.ExecuteDataset(Me._cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

End Class
