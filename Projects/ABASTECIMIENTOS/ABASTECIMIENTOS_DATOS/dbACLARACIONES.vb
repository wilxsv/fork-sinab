Imports System.Text

Public Class dbACLARACIONES
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As ACLARACIONES
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDACLARACION = 0 _
            Or lEntidad.IDACLARACION = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDACLARACION = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ACLARACIONES ")
        strSQL.Append(" SET ")
        strSQL.Append(" NUMEROACLARACION = @NUMEROACLARACION, ")
        strSQL.Append(" FECHAACLARACION = @FECHAACLARACION, ")
        strSQL.Append(" DETALLEACLARACION = @DETALLEACLARACION ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDACLARACION = @IDACLARACION ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDACLARACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDACLARACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROCESOCOMPRA
        args(3) = New SqlParameter("@NUMEROACLARACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.NUMEROACLARACION
        args(4) = New SqlParameter("@FECHAACLARACION", SqlDbType.DateTime)
        args(4).Value = lEntidad.FECHAACLARACION
        args(5) = New SqlParameter("@DETALLEACLARACION", SqlDbType.Text)
        args(5).Value = lEntidad.DETALLEACLARACION
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ACLARACIONES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO SAB_UACI_ACLARACIONES ")
        strSQL.Append(" (IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" IDACLARACION, ")
        strSQL.Append(" NUMEROACLARACION, ")
        strSQL.Append(" FECHAACLARACION, ")
        strSQL.Append(" DETALLEACLARACION, ")
        strSQL.Append(" AUUSUARIOCREACION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" (@IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @IDACLARACION, ")
        strSQL.Append(" @NUMEROACLARACION, ")
        strSQL.Append(" @FECHAACLARACION, ")
        strSQL.Append(" @DETALLEACLARACION, ")
        strSQL.Append(" @AUUSUARIOCREACION) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDACLARACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDACLARACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROCESOCOMPRA
        args(3) = New SqlParameter("@NUMEROACLARACION", SqlDbType.VarChar)
        args(3).Value = lEntidad.NUMEROACLARACION
        args(4) = New SqlParameter("@FECHAACLARACION", SqlDbType.DateTime)
        args(4).Value = lEntidad.FECHAACLARACION
        args(5) = New SqlParameter("@DETALLEACLARACION", SqlDbType.Text)
        args(5).Value = lEntidad.DETALLEACLARACION
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ACLARACIONES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_ACLARACIONES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDACLARACION = @IDACLARACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDACLARACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDACLARACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROCESOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ACLARACIONES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDACLARACION = @IDACLARACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDACLARACION", SqlDbType.Int)
        args(0).Value = lEntidad.IDACLARACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROCESOCOMPRA

        Dim dsDatos As DataSet
        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDESTABLECIMIENTO = IIf(.Item("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTO"))
                lEntidad.IDPROCESOCOMPRA = IIf(.Item("IDPROCESOCOMPRA") Is DBNull.Value, Nothing, .Item("IDPROCESOCOMPRA"))
                lEntidad.NUMEROACLARACION = IIf(.Item("NUMEROACLARACION") Is DBNull.Value, Nothing, .Item("NUMEROACLARACION"))
                lEntidad.FECHAACLARACION = IIf(.Item("FECHAACLARACION") Is DBNull.Value, Nothing, .Item("FECHAACLARACION"))
                lEntidad.DETALLEACLARACION = IIf(.Item("DETALLEACLARACION") Is DBNull.Value, Nothing, .Item("DETALLEACLARACION"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As ACLARACIONES
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDACLARACION),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_ACLARACIONES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROCESOCOMPRA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim tables(0) As String
        tables(0) = New String("ACLARACIONES")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDACLARACION, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" NUMEROACLARACION, ")
        strSQL.Append(" FECHAACLARACION, ")
        strSQL.Append(" DETALLEACLARACION ")
        strSQL.Append(" FROM SAB_UACI_ACLARACIONES ")

    End Sub

    Public Function ObtenerACLARACIONESPorProceso(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDACLARACION, IDESTABLECIMIENTO, IDPROCESOCOMPRA, NUMEROACLARACION, ")
        strSQL.Append(" FECHAACLARACION, DETALLEACLARACION, AUUSUARIOCREACION ")
        strSQL.Append(" FROM SAB_UACI_ACLARACIONES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataporACLARACION(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDACLARACION As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT A.IDACLARACION AS ACLARACION, A.NUMEROACLARACION AS NACLARACION, convert(varchar(10),FECHAACLARACION,103) as FECHAACLARACION, A.DETALLEACLARACION, PC.IDPROCESOCOMPRA AS PROCESOCOMPRA, ")
        strSQL.Append(" PC.CODIGOLICITACION AS LICITACION, PC.TITULOLICITACION AS TITULO, PC.DESCRIPCIONLICITACION AS NOMBREPROCESO, ")
        strSQL.Append(" S.CORRELATIVO AS SOLICITUD, E.NOMBRE AS ESTABLECIMIENTO, F.NOMBRE AS FUENTE, SM.DESCRIPCION AS SUMINISTRO ")
        strSQL.Append(" FROM SAB_UACI_ACLARACIONES AS A INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS PC ON A.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDESPROCESOCOMPRAS AS SP ON PC.IDPROCESOCOMPRA = SP.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = SP.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_EST_SOLICITUDES AS S ON SP.IDSOLICITUD = S.IDSOLICITUD AND SP.IDESTABLECIMIENTOSOLICITUD = S.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTABLECIMIENTOS AS E ON S.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES AS FP ON S.IDSOLICITUD = FP.IDSOLICITUD AND ")
        strSQL.Append(" S.IDESTABLECIMIENTO = FP.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_FUENTEFINANCIAMIENTOS AS F ON FP.IDFUENTEFINANCIAMIENTO = F.IDFUENTEFINANCIAMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_SUMINISTROS AS SM ON S.IDCLASESUMINISTRO = SM.IDSUMINISTRO ")
        strSQL.Append(" WHERE A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" AND IDACLARACION = @IDACLARACION ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDACLARACION", SqlDbType.Int)
        args(0).Value = IDACLARACION
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
