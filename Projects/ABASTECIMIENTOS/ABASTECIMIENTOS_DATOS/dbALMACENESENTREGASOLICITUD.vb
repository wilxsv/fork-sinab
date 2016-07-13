Imports System.Text
Public Class dbALMACENESENTREGASOLICITUD
    Inherits dbBase
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ALMACENESENTREGASOLICITUD
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_EST_ALMACENESENTREGASOLICITUD ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" IDPRODUCTO, ")
        strSQL.Append(" IDENTREGA, ")
        strSQL.Append(" NUMEROENTREGA, ")
        strSQL.Append(" RENGLON, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" CANTIDAD, ")
        strSQL.Append(" PRECIOUNITARIO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADO, ")
        strSQL.Append(" IDESPECIFICACION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDSOLICITUD, ")
        strSQL.Append(" @IDPRODUCTO, ")
        strSQL.Append(" @IDENTREGA, ")
        strSQL.Append(" @NUMEROENTREGA, ")
        strSQL.Append(" @RENGLON, ")
        strSQL.Append(" @IDALMACENENTREGA, ")
        strSQL.Append(" @IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append(" @CANTIDAD, ")
        strSQL.Append(" @PRECIOUNITARIO, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADO, ")
        strSQL.Append(" @IDESPECIFICACION) ")


        Dim args(16) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = lEntidad.IDSOLICITUD
        args(2) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDPRODUCTO
        args(3) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(3).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(4) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(5) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(6) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(7) = New SqlParameter("@ESTASINCRONIZADO", SqlDbType.SmallInt)
        args(7).Value = lEntidad.ESTASINCRONIZADA
        args(8) = New SqlParameter("@IDENTREGA", SqlDbType.BigInt)
        args(8).Value = lEntidad.IDENTREGA
        args(9) = New SqlParameter("@RENGLON", SqlDbType.Int)
        args(9).Value = lEntidad.RENGLON
        args(10) = New SqlParameter("@CANTIDAD", SqlDbType.Decimal)
        args(10).Value = lEntidad.CANTIDAD
        args(11) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(11).Value = lEntidad.IDFUENTEFINANCIAMIENTO
        args(12) = New SqlParameter("@IDALMACENENTREGA", SqlDbType.Int)
        args(12).Value = lEntidad.IDALMACENENTREGA
        args(13) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(13).Value = lEntidad.IDUNIDADMEDIDA
        args(14) = New SqlParameter("@PRECIOUNITARIO", SqlDbType.Decimal)
        args(14).Value = lEntidad.PRECIOUNITARIO
        args(15) = New SqlParameter("@NUMEROENTREGA", SqlDbType.Int)
        args(15).Value = lEntidad.NUMEROENTREGA
        If lEntidad.IDESPECIFICACION = 0 Then
            args(16) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
            args(16).Value = DBNull.Value
        Else

            args(16) = New SqlParameter("@IDESPECIFICACION", SqlDbType.Int)
            args(16).Value = lEntidad.IDESPECIFICACION
        End If
        



        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function ACTUALIZAR(ByVal aEntidad As entidadBase) As Integer

    End Function
    Public Overrides Function RECUPERAR(ByVal aEntidad As entidadBase) As Integer

    End Function
    Public Overrides Function ELIMINAR(ByVal aEntidad As entidadBase) As Integer

    End Function
    Public Overrides Function OBTENERID(ByVal aEntidad As entidadBase) As String
        Return String.Empty
    End Function
End Class
