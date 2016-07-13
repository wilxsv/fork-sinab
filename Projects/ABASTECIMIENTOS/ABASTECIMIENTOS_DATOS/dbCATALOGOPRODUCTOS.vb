Imports System.Text
Imports System.Data.SqlTypes

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCATALOGOPRODUCTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_CATALOGOPRODUCTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbCATALOGOPRODUCTOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CATALOGOPRODUCTOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDPRODUCTO = 0 _
            Or lEntidad.IDPRODUCTO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDPRODUCTO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_CATALOGOPRODUCTOS ")
        strSQL.Append(" SET CODIGO = @CODIGO, ")
        strSQL.Append(" IDTIPOPRODUCTO = @IDTIPOPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA = @IDUNIDADMEDIDA, ")
        strSQL.Append(" NOMBRE = @NOMBRE, ")
        strSQL.Append(" NIVELUSO = @NIVELUSO, ")
        strSQL.Append(" CONCENTRACION = @CONCENTRACION, ")
        strSQL.Append(" FORMAFARMACEUTICA = @FORMAFARMACEUTICA, ")
        strSQL.Append(" PRESENTACION = @PRESENTACION, ")
        strSQL.Append(" PRIORIDAD = @PRIORIDAD, ")
        strSQL.Append(" PRECIOACTUAL = @PRECIOACTUAL, ")
        strSQL.Append(" APLICALOTE = @APLICALOTE, ")
        strSQL.Append(" EXISTENCIAACTUAL = @EXISTENCIAACTUAL, ")
        strSQL.Append(" ESPECIFICACIONESTECNICAS = @ESPECIFICACIONESTECNICAS, ")
        strSQL.Append(" CODIGONACIONESUNIDAS = @CODIGONACIONESUNIDAS, ")
        strSQL.Append(" PERTENECELISTADOOFICIAL = @PERTENECELISTADOOFICIAL, ")
        strSQL.Append(" ESTADOPRODUCTO = @ESTADOPRODUCTO, ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append(" IDESTABLECIMIENTO = @IDESTABLECIMIENTO, ")
        strSQL.Append(" AREATECNICA = @AREATECNICA, ")
        'se modifica para adicionar especifico de gasto
        strSQL.Append(" IDESPECIFICOGASTO = @IDESPECIFICOGASTO ")
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(25) As SqlParameter
        args(0) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(0).Value = lEntidad.CODIGO
        args(1) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOPRODUCTO
        args(2) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(2).Value = lEntidad.IDUNIDADMEDIDA
        args(3) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(3).Value = lEntidad.NOMBRE
        args(4) = New SqlParameter("@NIVELUSO", SqlDbType.TinyInt)
        args(4).Value = lEntidad.NIVELUSO
        args(5) = New SqlParameter("@CONCENTRACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.CONCENTRACION = Nothing, DBNull.Value, lEntidad.CONCENTRACION)
        args(6) = New SqlParameter("@FORMAFARMACEUTICA", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.FORMAFARMACEUTICA = Nothing, DBNull.Value, lEntidad.FORMAFARMACEUTICA)
        args(7) = New SqlParameter("@PRESENTACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.PRESENTACION = Nothing, DBNull.Value, lEntidad.PRESENTACION)
        args(8) = New SqlParameter("@PRIORIDAD", SqlDbType.SmallInt)
        args(8).Value = IIf(lEntidad.PRIORIDAD = Nothing, DBNull.Value, lEntidad.PRIORIDAD)
        args(9) = New SqlParameter("@PRECIOACTUAL", SqlDbType.Decimal)
        args(9).Value = IIf(lEntidad.PRECIOACTUAL = Nothing, DBNull.Value, lEntidad.PRECIOACTUAL)
        args(10) = New SqlParameter("@APLICALOTE", SqlDbType.TinyInt)
        args(10).Value = lEntidad.APLICALOTE
        args(11) = New SqlParameter("@EXISTENCIAACTUAL", SqlDbType.Decimal)
        args(11).Value = IIf(lEntidad.EXISTENCIAACTUAL = Nothing, DBNull.Value, lEntidad.EXISTENCIAACTUAL)
        args(12) = New SqlParameter("@ESPECIFICACIONESTECNICAS", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.ESPECIFICACIONESTECNICAS = Nothing, DBNull.Value, lEntidad.ESPECIFICACIONESTECNICAS)
        args(13) = New SqlParameter("@CODIGONACIONESUNIDAS", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.CODIGONACIONESUNIDAS = Nothing, DBNull.Value, lEntidad.CODIGONACIONESUNIDAS)
        args(14) = New SqlParameter("@PERTENECELISTADOOFICIAL", SqlDbType.TinyInt)
        args(14).Value = lEntidad.PERTENECELISTADOOFICIAL
        args(15) = New SqlParameter("@ESTADOPRODUCTO", SqlDbType.TinyInt)
        args(15).Value = lEntidad.ESTADOPRODUCTO
        args(16) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(17) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(18) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(19) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(20) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(21) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(21).Value = lEntidad.ESTASINCRONIZADA
        args(22) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(22).Value = lEntidad.IDPRODUCTO
        args(23) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(23).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(24) = New SqlParameter("@AREATECNICA", SqlDbType.Int)
        args(24).Value = IIf(lEntidad.AREATECNICA = Nothing, DBNull.Value, lEntidad.AREATECNICA)
        'SE ADICIONA ESPECIFICO DE GASTO
        args(25) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.Int)
        args(25).Value = IIf(lEntidad.IDESPECIFICOGASTO = Nothing, DBNull.Value, lEntidad.IDESPECIFICOGASTO)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CATALOGOPRODUCTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_CATALOGOPRODUCTOS ")
        strSQL.Append(" ( IDPRODUCTO, ")
        strSQL.Append(" CODIGO, ")
        strSQL.Append(" IDTIPOPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" NIVELUSO, ")
        strSQL.Append(" CONCENTRACION, ")
        strSQL.Append(" FORMAFARMACEUTICA, ")
        strSQL.Append(" PRESENTACION, ")
        strSQL.Append(" PRIORIDAD, ")
        strSQL.Append(" PRECIOACTUAL, ")
        strSQL.Append(" APLICALOTE, ")
        strSQL.Append(" EXISTENCIAACTUAL, ")
        strSQL.Append(" ESPECIFICACIONESTECNICAS, ")
        strSQL.Append(" CODIGONACIONESUNIDAS, ")
        strSQL.Append(" PERTENECELISTADOOFICIAL, ")
        strSQL.Append(" ESTADOPRODUCTO, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" IDESTABLECIMIENTO, CLASIFICACION, AREATECNICA, TIPOUACI,  ")
        strSQL.Append(" IDESPECIFICOGASTO) ")

        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDPRODUCTO, ")
        strSQL.Append(" @CODIGO, ")
        strSQL.Append(" @IDTIPOPRODUCTO, ")
        strSQL.Append(" @IDUNIDADMEDIDA, ")
        strSQL.Append(" @NOMBRE, ")
        strSQL.Append(" @NIVELUSO, ")
        strSQL.Append(" @CONCENTRACION, ")
        strSQL.Append(" @FORMAFARMACEUTICA, ")
        strSQL.Append(" @PRESENTACION, ")
        strSQL.Append(" @PRIORIDAD, ")
        strSQL.Append(" @PRECIOACTUAL, ")
        strSQL.Append(" @APLICALOTE, ")
        strSQL.Append(" @EXISTENCIAACTUAL, ")
        strSQL.Append(" @ESPECIFICACIONESTECNICAS, ")
        strSQL.Append(" @CODIGONACIONESUNIDAS, ")
        strSQL.Append(" @PERTENECELISTADOOFICIAL, ")
        strSQL.Append(" @ESTADOPRODUCTO, ")
        strSQL.Append(" @OBSERVACION, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA, ")
        strSQL.Append(" @IDESTABLECIMIENTO, @CLASIFICACION, @AREATECNICA, @TIPOUACI, ")

        strSQL.Append(" @IDESPECIFICOGASTO) ")

        Dim args(27) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO
        args(1) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(1).Value = lEntidad.CODIGO
        args(2) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(2).Value = lEntidad.IDTIPOPRODUCTO
        args(3) = New SqlParameter("@IDUNIDADMEDIDA", SqlDbType.Int)
        args(3).Value = lEntidad.IDUNIDADMEDIDA
        args(4) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(4).Value = lEntidad.NOMBRE
        args(5) = New SqlParameter("@NIVELUSO", SqlDbType.TinyInt)
        args(5).Value = lEntidad.NIVELUSO
        args(6) = New SqlParameter("@CONCENTRACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.CONCENTRACION = Nothing, DBNull.Value, lEntidad.CONCENTRACION)
        args(7) = New SqlParameter("@FORMAFARMACEUTICA", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.FORMAFARMACEUTICA = Nothing, DBNull.Value, lEntidad.FORMAFARMACEUTICA)
        args(8) = New SqlParameter("@PRESENTACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.PRESENTACION = Nothing, DBNull.Value, lEntidad.PRESENTACION)
        args(9) = New SqlParameter("@PRIORIDAD", SqlDbType.SmallInt)
        args(9).Value = IIf(lEntidad.PRIORIDAD = Nothing, DBNull.Value, lEntidad.PRIORIDAD)
        args(10) = New SqlParameter("@PRECIOACTUAL", SqlDbType.Decimal)
        args(10).Value = lEntidad.PRECIOACTUAL
        args(11) = New SqlParameter("@APLICALOTE", SqlDbType.TinyInt)
        args(11).Value = lEntidad.APLICALOTE
        args(12) = New SqlParameter("@EXISTENCIAACTUAL", SqlDbType.Decimal)
        args(12).Value = IIf(lEntidad.EXISTENCIAACTUAL = Nothing, DBNull.Value, lEntidad.EXISTENCIAACTUAL)
        args(13) = New SqlParameter("@ESPECIFICACIONESTECNICAS", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.ESPECIFICACIONESTECNICAS = Nothing, DBNull.Value, lEntidad.ESPECIFICACIONESTECNICAS)
        args(14) = New SqlParameter("@CODIGONACIONESUNIDAS", SqlDbType.VarChar)
        args(14).Value = IIf(lEntidad.CODIGONACIONESUNIDAS = Nothing, DBNull.Value, lEntidad.CODIGONACIONESUNIDAS)
        args(15) = New SqlParameter("@PERTENECELISTADOOFICIAL", SqlDbType.TinyInt)
        args(15).Value = lEntidad.PERTENECELISTADOOFICIAL
        args(16) = New SqlParameter("@ESTADOPRODUCTO", SqlDbType.TinyInt)
        args(16).Value = lEntidad.ESTADOPRODUCTO
        args(17) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.OBSERVACION = Nothing, DBNull.Value, lEntidad.OBSERVACION)
        args(18) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(18).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(19) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(20) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(20).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(21) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(21).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(22) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(22).Value = lEntidad.ESTASINCRONIZADA
        args(23) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(23).Value = IIf(lEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, lEntidad.IDESTABLECIMIENTO)
        args(24) = New SqlParameter("@CLASIFICACION", SqlDbType.VarChar)
        args(24).Value = lEntidad.CLASIFICACION
        args(25) = New SqlParameter("@AREATECNICA", SqlDbType.Int)
        args(25).Value = IIf(lEntidad.AREATECNICA = Nothing, DBNull.Value, lEntidad.AREATECNICA)
        args(26) = New SqlParameter("@TIPOUACI", SqlDbType.Int)
        args(26).Value = IIf(lEntidad.TIPOUACI = Nothing, DBNull.Value, lEntidad.TIPOUACI)
        args(27) = New SqlParameter("@IDESPECIFICOGASTO", SqlDbType.Int)
        args(27).Value = IIf(lEntidad.IDESPECIFICOGASTO = Nothing, DBNull.Value, lEntidad.IDESPECIFICOGASTO)







        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CATALOGOPRODUCTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_CATALOGOPRODUCTOS ")
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CATALOGOPRODUCTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDPRODUCTO = @IDPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = lEntidad.IDPRODUCTO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.CODIGO = IIf(.Item("CODIGO") Is DBNull.Value, Nothing, .Item("CODIGO"))
                lEntidad.IDTIPOPRODUCTO = IIf(.Item("IDTIPOPRODUCTO") Is DBNull.Value, Nothing, .Item("IDTIPOPRODUCTO"))
                lEntidad.IDUNIDADMEDIDA = IIf(.Item("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, .Item("IDUNIDADMEDIDA"))
                lEntidad.NOMBRE = IIf(.Item("NOMBRE") Is DBNull.Value, Nothing, .Item("NOMBRE"))
                lEntidad.NIVELUSO = IIf(.Item("NIVELUSO") Is DBNull.Value, Nothing, .Item("NIVELUSO"))
                lEntidad.CONCENTRACION = IIf(.Item("CONCENTRACION") Is DBNull.Value, Nothing, .Item("CONCENTRACION"))
                lEntidad.FORMAFARMACEUTICA = IIf(.Item("FORMAFARMACEUTICA") Is DBNull.Value, Nothing, .Item("FORMAFARMACEUTICA"))
                lEntidad.PRESENTACION = IIf(.Item("PRESENTACION") Is DBNull.Value, Nothing, .Item("PRESENTACION"))
                lEntidad.PRIORIDAD = IIf(.Item("PRIORIDAD") Is DBNull.Value, Nothing, .Item("PRIORIDAD"))
                lEntidad.PRECIOACTUAL = IIf(.Item("PRECIOACTUAL") Is DBNull.Value, Nothing, .Item("PRECIOACTUAL"))
                lEntidad.APLICALOTE = IIf(.Item("APLICALOTE") Is DBNull.Value, Nothing, .Item("APLICALOTE"))
                lEntidad.EXISTENCIAACTUAL = IIf(.Item("EXISTENCIAACTUAL") Is DBNull.Value, Nothing, .Item("EXISTENCIAACTUAL"))
                lEntidad.ESPECIFICACIONESTECNICAS = IIf(.Item("ESPECIFICACIONESTECNICAS") Is DBNull.Value, Nothing, .Item("ESPECIFICACIONESTECNICAS"))
                lEntidad.CODIGONACIONESUNIDAS = IIf(.Item("CODIGONACIONESUNIDAS") Is DBNull.Value, Nothing, .Item("CODIGONACIONESUNIDAS"))
                lEntidad.PERTENECELISTADOOFICIAL = IIf(.Item("PERTENECELISTADOOFICIAL") Is DBNull.Value, Nothing, .Item("PERTENECELISTADOOFICIAL"))
                lEntidad.ESTADOPRODUCTO = IIf(.Item("ESTADOPRODUCTO") Is DBNull.Value, Nothing, .Item("ESTADOPRODUCTO"))
                lEntidad.OBSERVACION = IIf(.Item("OBSERVACION") Is DBNull.Value, Nothing, .Item("OBSERVACION"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.IDESTABLECIMIENTO = IIf(.Item("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTO"))
                lEntidad.AREATECNICA = IIf(.Item("AREATECNICA") Is DBNull.Value, Nothing, .Item("AREATECNICA"))
                lEntidad.IDESPECIFICOGASTO = IIf(.Item("IDESPECIFICOGASTO") Is DBNull.Value, Nothing, .Item("IDESPECIFICOGASTO"))


            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As CATALOGOPRODUCTOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPRODUCTO),0) + 1 ")
        strSQL.Append(" FROM SAB_CAT_CATALOGOPRODUCTOS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaCATALOGOPRODUCTOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaCATALOGOPRODUCTOS

        Try
            Do While dr.Read()
                Dim mEntidad As New CATALOGOPRODUCTOS
                mEntidad.IDPRODUCTO = IIf(dr("IDPRODUCTO") Is DBNull.Value, Nothing, dr("IDPRODUCTO"))
                mEntidad.CODIGO = IIf(dr("CODIGO") Is DBNull.Value, Nothing, dr("CODIGO"))
                mEntidad.IDTIPOPRODUCTO = IIf(dr("IDTIPOPRODUCTO") Is DBNull.Value, Nothing, dr("IDTIPOPRODUCTO"))
                mEntidad.IDUNIDADMEDIDA = IIf(dr("IDUNIDADMEDIDA") Is DBNull.Value, Nothing, dr("IDUNIDADMEDIDA"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.NIVELUSO = IIf(dr("NIVELUSO") Is DBNull.Value, Nothing, dr("NIVELUSO"))
                mEntidad.CONCENTRACION = IIf(dr("CONCENTRACION") Is DBNull.Value, Nothing, dr("CONCENTRACION"))
                mEntidad.FORMAFARMACEUTICA = IIf(dr("FORMAFARMACEUTICA") Is DBNull.Value, Nothing, dr("FORMAFARMACEUTICA"))
                mEntidad.PRESENTACION = IIf(dr("PRESENTACION") Is DBNull.Value, Nothing, dr("PRESENTACION"))
                mEntidad.PRIORIDAD = IIf(dr("PRIORIDAD") Is DBNull.Value, Nothing, dr("PRIORIDAD"))
                mEntidad.PRECIOACTUAL = IIf(dr("PRECIOACTUAL") Is DBNull.Value, Nothing, dr("PRECIOACTUAL"))
                mEntidad.APLICALOTE = IIf(dr("APLICALOTE") Is DBNull.Value, Nothing, dr("APLICALOTE"))
                mEntidad.EXISTENCIAACTUAL = IIf(dr("EXISTENCIAACTUAL") Is DBNull.Value, Nothing, dr("EXISTENCIAACTUAL"))
                mEntidad.ESPECIFICACIONESTECNICAS = IIf(dr("ESPECIFICACIONESTECNICAS") Is DBNull.Value, Nothing, dr("ESPECIFICACIONESTECNICAS"))
                mEntidad.CODIGONACIONESUNIDAS = IIf(dr("CODIGONACIONESUNIDAS") Is DBNull.Value, Nothing, dr("CODIGONACIONESUNIDAS"))
                mEntidad.PERTENECELISTADOOFICIAL = IIf(dr("PERTENECELISTADOOFICIAL") Is DBNull.Value, Nothing, dr("PERTENECELISTADOOFICIAL"))
                mEntidad.ESTADOPRODUCTO = IIf(dr("ESTADOPRODUCTO") Is DBNull.Value, Nothing, dr("ESTADOPRODUCTO"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.IDESTABLECIMIENTO = IIf(dr("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, dr("IDESTABLECIMIENTO"))
                mEntidad.IDESPECIFICOGASTO = IIf(dr("IDESPECIFICOGASTO") Is DBNull.Value, Nothing, dr("IDESPECIFICOGASTO"))

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
        tables(0) = New String("CATALOGOPRODUCTOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDPRODUCTO, ")
        strSQL.Append(" CODIGO, ")
        strSQL.Append(" IDTIPOPRODUCTO, ")
        strSQL.Append(" IDUNIDADMEDIDA, ")
        strSQL.Append(" NOMBRE, ")
        strSQL.Append(" NIVELUSO, ")
        strSQL.Append(" CONCENTRACION, ")
        strSQL.Append(" FORMAFARMACEUTICA, ")
        strSQL.Append(" PRESENTACION, ")
        strSQL.Append(" PRIORIDAD, ")
        strSQL.Append(" PRECIOACTUAL, ")
        strSQL.Append(" APLICALOTE, ")
        strSQL.Append(" EXISTENCIAACTUAL, ")
        strSQL.Append(" ESPECIFICACIONESTECNICAS, ")
        strSQL.Append(" CODIGONACIONESUNIDAS, ")
        strSQL.Append(" PERTENECELISTADOOFICIAL, ")
        strSQL.Append(" ESTADOPRODUCTO, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" AREATECNICA, ")
        strSQL.Append(" IDESPECIFICOGASTO ")
        strSQL.Append(" FROM SAB_CAT_CATALOGOPRODUCTOS ")

    End Sub
    Public Function ActualizarTipoProductoUACI(ByVal idproducto As Integer, ByVal idgrupo As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" UPDATE SAB_CAT_CATALOGOPRODUCTOS ")
        strSQL.Append(" SET TIPOUACI=@TIPOUACI ")
        strSQL.Append(" WHERE IDPRODUCTO=@IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.BigInt)
        args(0).Value = idproducto
        args(1) = New SqlParameter("@TIPOUACI", SqlDbType.BigInt)
        args(1).Value = idgrupo

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
#End Region

End Class
