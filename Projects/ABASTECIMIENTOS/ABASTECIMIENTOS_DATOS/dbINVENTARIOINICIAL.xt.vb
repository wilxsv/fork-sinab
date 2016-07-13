Imports System.Text

Partial Public Class dbINVENTARIOINICIAL
    Inherits dbBase

#Region "Metodos Adicionales"

    Public Function ObtenerInventariosPorAlmacen(ByVal IDALMACEN As Int32, ByVal ESTACERRADO As Byte) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("II.*, ")
        strSQL.Append("S.DESCRIPCION SUMINISTRO ")
        strSQL.Append("FROM SAB_ALM_INVENTARIOINICIAL II ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON II.IDSUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("WHERE II.IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND ESTACERRADO = @ESTACERRADO ")
        strSQL.Append("ORDER BY II.FECHAINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@ESTACERRADO", SqlDbType.TinyInt)
        args(1).Value = ESTACERRADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function EliminarInventarioDetalle(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("DELETE SAB_ALM_DETALLEINVENTARIOINICIAL ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim strSQL1 As New Text.StringBuilder
        strSQL1.Append("DELETE SAB_ALM_INVENTARIOINICIAL ")
        strSQL1.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL1.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = IDINVENTARIO

        Dim resultado As Integer

        Using c As New SqlConnection(Me.cnnStr)

            c.Open()

            Dim t As SqlTransaction = c.BeginTransaction()

            Try

                SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL.ToString, args)
                SqlHelper.ExecuteNonQuery(t, System.Data.CommandType.Text, strSQL1.ToString, args)

                t.Commit()

                resultado = 1

            Catch ex As Exception
                t.Rollback()
                Throw
            Finally
                If Not c.State = ConnectionState.Closed Then c.Close()
            End Try

        End Using

        Return resultado

    End Function

#End Region

End Class
