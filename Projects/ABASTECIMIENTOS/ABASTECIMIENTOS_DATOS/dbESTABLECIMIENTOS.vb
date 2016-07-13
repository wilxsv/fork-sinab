Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_ESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbESTABLECIMIENTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDESTABLECIMIENTO = 0 _
            Or lEntidad.IDESTABLECIMIENTO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDESTABLECIMIENTO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append(" SET CODIGOESTABLECIMIENTO = @CODIGOESTABLECIMIENTO, ")
        strSQL.Append(" IDMUNICIPIO = @IDMUNICIPIO, ")
        strSQL.Append(" IDTIPOESTABLECIMIENTO = @IDTIPOESTABLECIMIENTO, ")
        strSQL.Append(" IDZONA = @IDZONA, ")
        strSQL.Append(" IDINSTITUCION = @IDINSTITUCION, ")
        strSQL.Append(" NOMBRE = @NOMBRE, ")
        strSQL.Append(" DIRECCION = @DIRECCION, ")
        strSQL.Append(" TELEFONO = @TELEFONO, ")
        strSQL.Append(" FAX = @FAX, ")
        strSQL.Append(" IDPADRE = @IDPADRE, ")
        strSQL.Append(" NIVEL = @NIVEL, ")
        strSQL.Append(" TIPOCONSUMO = @TIPOCONSUMO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@CODIGOESTABLECIMIENTO", SqlDbType.VarChar)
        args(0).Value = lEntidad.CODIGOESTABLECIMIENTO
        args(1) = New SqlParameter("@IDMUNICIPIO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.IDMUNICIPIO
        args(2) = New SqlParameter("@IDTIPOESTABLECIMIENTO", SqlDbType.TinyInt)
        args(2).Value = lEntidad.IDTIPOESTABLECIMIENTO
        args(3) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(3).Value = lEntidad.IDZONA
        args(4) = New SqlParameter("@IDINSTITUCION", SqlDbType.Int)
        args(4).Value = lEntidad.IDINSTITUCION
        args(5) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(5).Value = lEntidad.NOMBRE
        args(6) = New SqlParameter("@DIRECCION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.DIRECCION = Nothing, DBNull.Value, lEntidad.DIRECCION)
        args(7) = New SqlParameter("@TELEFONO", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.TELEFONO = Nothing, DBNull.Value, lEntidad.TELEFONO)
        args(8) = New SqlParameter("@FAX", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.FAX = Nothing, DBNull.Value, lEntidad.FAX)
        args(9) = New SqlParameter("@IDPADRE", SqlDbType.Int)
        args(9).Value = IIf(lEntidad.IDPADRE = Nothing, DBNull.Value, lEntidad.IDPADRE)
        args(10) = New SqlParameter("@NIVEL", SqlDbType.Int)
        args(10).Value = IIf(lEntidad.NIVEL = Nothing, DBNull.Value, lEntidad.NIVEL)
        args(11) = New SqlParameter("@TIPOCONSUMO", SqlDbType.VarChar)
        args(11).Value = lEntidad.TIPOCONSUMO
        args(12) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(13) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(14) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(15) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(16) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(16).Value = lEntidad.ESTASINCRONIZADA
        args(17) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(17).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" CODIGOESTABLECIMIENTO, ")
        strSQL.Append(" IDMUNICIPIO, ")
        strSQL.Append(" IDTIPOESTABLECIMIENTO, ")
        strSQL.Append(" IDZONA, ")
        strSQL.Append(" IDINSTITUCION, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" IDPADRE, ")
        strSQL.Append(" NIVEL, ")
        strSQL.Append(" TIPOCONSUMO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @CODIGOESTABLECIMIENTO, ")
        strSQL.Append(" @IDMUNICIPIO, ")
        strSQL.Append(" @IDTIPOESTABLECIMIENTO, ")
        strSQL.Append(" @IDZONA, ")
        strSQL.Append(" @IDINSTITUCION, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @DIRECCION, ")
        strSQL.Append(" @TELEFONO, ")
        strSQL.Append(" @FAX, ")
        strSQL.Append(" @IDPADRE, ")
        strSQL.Append(" @NIVEL, ")
        strSQL.Append(" @TIPOCONSUMO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(17) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@CODIGOESTABLECIMIENTO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CODIGOESTABLECIMIENTO
        args(2) = New SqlParameter("@IDMUNICIPIO", SqlDbType.SmallInt)
        args(2).Value = lEntidad.IDMUNICIPIO
        args(3) = New SqlParameter("@IDTIPOESTABLECIMIENTO", SqlDbType.TinyInt)
        args(3).Value = lEntidad.IDTIPOESTABLECIMIENTO
        args(4) = New SqlParameter("@IDZONA", SqlDbType.Int)
        args(4).Value = lEntidad.IDZONA
        args(5) = New SqlParameter("@IDINSTITUCION", SqlDbType.Int)
        args(5).Value = lEntidad.IDINSTITUCION
        args(6) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(6).Value = lEntidad.NOMBRE
        args(7) = New SqlParameter("@DIRECCION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.DIRECCION = Nothing, DBNull.Value, lEntidad.DIRECCION)
        args(8) = New SqlParameter("@TELEFONO", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.TELEFONO = Nothing, DBNull.Value, lEntidad.TELEFONO)
        args(9) = New SqlParameter("@FAX", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.FAX = Nothing, DBNull.Value, lEntidad.FAX)
        args(10) = New SqlParameter("@IDPADRE", SqlDbType.Int)
        args(10).Value = IIf(lEntidad.IDPADRE = Nothing, DBNull.Value, lEntidad.IDPADRE)
        args(11) = New SqlParameter("@NIVEL", SqlDbType.Int)
        args(11).Value = IIf(lEntidad.NIVEL = Nothing, DBNull.Value, lEntidad.NIVEL)
        args(12) = New SqlParameter("@TIPOCONSUMO", SqlDbType.VarChar)
        args(12).Value = lEntidad.TIPOCONSUMO
        args(13) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(14) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(15) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(16) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(17) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(17).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_ESTABLECIMIENTOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.CODIGOESTABLECIMIENTO = IIf(.Item("CODIGOESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("CODIGOESTABLECIMIENTO"))
                lEntidad.IDMUNICIPIO = IIf(.Item("IDMUNICIPIO") Is DBNull.Value, Nothing, .Item("IDMUNICIPIO"))
                lEntidad.IDTIPOESTABLECIMIENTO = IIf(.Item("IDTIPOESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDTIPOESTABLECIMIENTO"))
                lEntidad.IDZONA = IIf(.Item("IDZONA") Is DBNull.Value, Nothing, .Item("IDZONA"))
                lEntidad.IDINSTITUCION = IIf(.Item("IDINSTITUCION") Is DBNull.Value, Nothing, .Item("IDINSTITUCION"))
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.DIRECCION = IIf(.Item("DIRECCION") Is DBNull.Value, Nothing, .Item("DIRECCION"))
                lEntidad.TELEFONO = IIf(.Item("TELEFONO") Is DBNull.Value, Nothing, .Item("TELEFONO"))
                lEntidad.FAX = IIf(.Item("FAX") Is DBNull.Value, Nothing, .Item("FAX"))
                lEntidad.IDPADRE = IIf(.Item("IDPADRE") Is DBNull.Value, Nothing, .Item("IDPADRE"))
                lEntidad.NIVEL = IIf(.Item("NIVEL") Is DBNull.Value, Nothing, .Item("NIVEL"))
                lEntidad.TIPOCONSUMO = IIf(.Item("TIPOCONSUMO") Is DBNull.Value, Nothing, .Item("TIPOCONSUMO"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As ESTABLECIMIENTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDESTABLECIMIENTO),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_ESTABLECIMIENTOS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaESTABLECIMIENTOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" ORDER BY NOMBRE")

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaESTABLECIMIENTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New ESTABLECIMIENTOS
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.CODIGOESTABLECIMIENTO = IIf(dr("CODIGOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("CODIGOESTABLECIMIENTO"))
                mEntidad.IDMUNICIPIO = IIf(dr("IDMUNICIPIO") Is DBNull.Value, Nothing, dr("IDMUNICIPIO"))
                mEntidad.IDTIPOESTABLECIMIENTO = IIf(dr("IDTIPOESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDTIPOESTABLECIMIENTO"))
                mEntidad.IDZONA = IIf(dr("IDZONA") Is DBNull.Value, Nothing, dr("IDZONA"))
                mEntidad.IDINSTITUCION = IIf(dr("IDINSTITUCION") Is DBNull.Value, Nothing, dr("IDINSTITUCION"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.IDPADRE = IIf(dr("IDPADRE") Is DBNull.Value, Nothing, dr("IDPADRE"))
                mEntidad.NIVEL = IIf(dr("NIVEL") Is DBNull.Value, Nothing, dr("NIVEL"))
                mEntidad.TIPOCONSUMO = IIf(dr("TIPOCONSUMO") Is DBNull.Value, Nothing, dr("TIPOCONSUMO"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

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
        tables(0) = New String("ESTABLECIMIENTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" CODIGOESTABLECIMIENTO, ")
        strSQL.Append(" IDMUNICIPIO, ")
        strSQL.Append(" IDTIPOESTABLECIMIENTO, ")
        strSQL.Append(" IDZONA, ")
        strSQL.Append(" IDINSTITUCION, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" DIRECCION, ")
        strSQL.Append(" TELEFONO, ")
        strSQL.Append(" FAX, ")
        strSQL.Append(" IDPADRE, ")
        strSQL.Append(" NIVEL, ")
        strSQL.Append(" TIPOCONSUMO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_CAT_ESTABLECIMIENTOS ")

    End Sub

#End Region

End Class
