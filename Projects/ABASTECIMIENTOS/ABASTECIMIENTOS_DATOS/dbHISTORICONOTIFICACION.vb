Imports System.Text

Public Class dbHISTORICONOTIFICACION
    Inherits dbBase

#Region " Metodos Agregados "

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMEMUESTRAS
        lEntidad = aEntidad

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("INSERT INTO SAB_LAB_HISTORICONOTIFICACION ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDINFORME, ")
        strSQL.Append(" NOMBRECOMERCIAL, ")
        strSQL.Append(" LABORATORIOFABRICANTE, ")
        strSQL.Append(" LOTE, ")
        strSQL.Append(" NUMEROUNIDADES, ")
        strSQL.Append(" FECHAFABRICACION, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" CANTIDADAENTREGAR) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDINFORME, ")
        strSQL.Append(" @NOMBRECOMERCIAL, ")
        strSQL.Append(" @LABORATORIOFABRICANTE, ")
        strSQL.Append(" @LOTE, ")
        strSQL.Append(" @NUMEROUNIDADES, ")
        strSQL.Append(" @FECHAFABRICACION, ")
        strSQL.Append(" @FECHAVENCIMIENTO, ")
        strSQL.Append(" @CANTIDADAENTREGAR) ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = lEntidad.IDINFORME
        args(2) = New SqlParameter("@NOMBRECOMERCIAL", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRECOMERCIAL
        args(3) = New SqlParameter("@LABORATORIOFABRICANTE", SqlDbType.VarChar)
        args(3).Value = lEntidad.LABORATORIOFABRICANTE
        args(4) = New SqlParameter("@LOTE", SqlDbType.VarChar)
        args(4).Value = lEntidad.LOTE
        args(5) = New SqlParameter("@NUMEROUNIDADES", SqlDbType.Decimal)
        args(5).Value = lEntidad.NUMEROUNIDADES
        args(6) = New SqlParameter("@FECHAFABRICACION", SqlDbType.DateTime)
        args(6).Value = lEntidad.FECHAFABRICACION
        args(7) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(7).Value = lEntidad.FECHAVENCIMIENTO
        args(8) = New SqlParameter("@CANTIDADAENTREGAR", SqlDbType.Decimal)
        args(8).Value = lEntidad.CANTIDADAENTREGAR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INFORMEMUESTRAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_LAB_HISTORICONOTIFICACION ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDINFORME = @IDINFORME ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDINFORME", SqlDbType.Int)
        args(1).Value = lEntidad.IDINFORME

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String
        Return String.Empty
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function

End Class
