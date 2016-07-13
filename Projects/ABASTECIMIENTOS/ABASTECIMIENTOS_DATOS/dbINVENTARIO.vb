Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbINVENTARIO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla INVENTARIO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbINVENTARIO
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INVENTARIO
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDINVENTARIO = 0 _
            Or lEntidad.IDINVENTARIO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDINVENTARIO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_ALM_INVENTARIO ")
        strSQL.Append("SET FECHAINICIO = @FECHAINICIO, ")
        strSQL.Append("FECHACIERRE = @FECHACIERRE, ")
        strSQL.Append("FECHACIERREEXISTENCIA = @FECHACIERREEXISTENCIA, ")
        strSQL.Append("IDSUMINISTRO = @IDSUMINISTRO, ")
        strSQL.Append("IDFUENTEFINANCIAMIENTO = @IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("IDRESPONSABLEDISTRIBUCION = @IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("ESTACERRADO = @ESTACERRADO, ")
        strSQL.Append("CONSIDERARFUENTE = @CONSIDERARFUENTE, ")
        strSQL.Append("CONSIDERARRESPONSABLE = @CONSIDERARRESPONSABLE, ")
        strSQL.Append("CONSIDERARVENCIDOS = @CONSIDERARVENCIDOS, ")
        strSQL.Append("CONSIDERARNODISPONIBLES = @CONSIDERARNODISPONIBLES, ")
        strSQL.Append("AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append("CONSIDERARDISPONIBLES = @CONSIDERARDISPONIBLES ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(18) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(2).Value = lEntidad.FECHAINICIO
        args(3) = New SqlParameter("@FECHACIERRE", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHACIERRE = Nothing, DBNull.Value, lEntidad.FECHACIERRE)
        args(4) = New SqlParameter("@FECHACIERREEXISTENCIA", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.FECHACIERREEXISTENCIA = Nothing, DBNull.Value, lEntidad.FECHACIERREEXISTENCIA)
        args(5) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(5).Value = lEntidad.IDSUMINISTRO
        args(6) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(6).Value = IIf(lEntidad.IDFUENTEFINANCIAMIENTO = Nothing, DBNull.Value, lEntidad.IDFUENTEFINANCIAMIENTO)
        args(7) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(7).Value = IIf(lEntidad.IDRESPONSABLEDISTRIBUCION = Nothing, DBNull.Value, lEntidad.IDRESPONSABLEDISTRIBUCION)
        args(8) = New SqlParameter("@ESTACERRADO", SqlDbType.TinyInt)
        args(8).Value = lEntidad.ESTACERRADO
        args(9) = New SqlParameter("@CONSIDERARFUENTE", SqlDbType.TinyInt)
        args(9).Value = lEntidad.CONSIDERARFUENTE
        args(10) = New SqlParameter("@CONSIDERARRESPONSABLE", SqlDbType.TinyInt)
        args(10).Value = lEntidad.CONSIDERARRESPONSABLE
        args(11) = New SqlParameter("@CONSIDERARVENCIDOS", SqlDbType.TinyInt)
        args(11).Value = lEntidad.CONSIDERARVENCIDOS
        args(12) = New SqlParameter("@CONSIDERARNODISPONIBLES", SqlDbType.TinyInt)
        args(12).Value = lEntidad.CONSIDERARNODISPONIBLES
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
        args(18) = New SqlParameter("@CONSIDERARDISPONIBLES", SqlDbType.TinyInt)
        args(18).Value = lEntidad.CONSIDERARDISPONIBLES

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INVENTARIO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO SAB_ALM_INVENTARIO ")
        strSQL.Append("( IDALMACEN, ")
        strSQL.Append("IDINVENTARIO, ")
        strSQL.Append("FECHAINICIO, ")
        strSQL.Append("FECHACIERRE, ")
        strSQL.Append("FECHACIERREEXISTENCIA, ")
        strSQL.Append("IDSUMINISTRO, ")
        strSQL.Append("IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("ESTACERRADO, ")
        strSQL.Append("CONSIDERARFUENTE, ")
        strSQL.Append("CONSIDERARRESPONSABLE, ")
        strSQL.Append("CONSIDERARVENCIDOS, ")
        strSQL.Append("CONSIDERARNODISPONIBLES, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("ESTASINCRONIZADA, ")
        strSQL.Append("CONSIDERARDISPONIBLES) ")
        strSQL.Append("VALUES ")
        strSQL.Append("( @IDALMACEN, ")
        strSQL.Append("@IDINVENTARIO, ")
        strSQL.Append("@FECHAINICIO, ")
        strSQL.Append("@FECHACIERRE, ")
        strSQL.Append("@FECHACIERREEXISTENCIA, ")
        strSQL.Append("@IDSUMINISTRO, ")
        strSQL.Append("@IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("@IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("@ESTACERRADO, ")
        strSQL.Append("@CONSIDERARFUENTE, ")
        strSQL.Append("@CONSIDERARRESPONSABLE, ")
        strSQL.Append("@CONSIDERARVENCIDOS, ")
        strSQL.Append("@CONSIDERARNODISPONIBLES, ")
        strSQL.Append("@AUUSUARIOCREACION, ")
        strSQL.Append("@AUFECHACREACION, ")
        strSQL.Append("@ESTASINCRONIZADA, ")
        strSQL.Append("@CONSIDERARDISPONIBLES) ")

        Dim args(18) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO
        args(2) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(2).Value = lEntidad.FECHAINICIO
        args(3) = New SqlParameter("@FECHACIERRE", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHACIERRE = Nothing, DBNull.Value, lEntidad.FECHACIERRE)
        args(4) = New SqlParameter("@FECHACIERREEXISTENCIA", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.FECHACIERREEXISTENCIA = Nothing, DBNull.Value, lEntidad.FECHACIERREEXISTENCIA)
        args(5) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(5).Value = lEntidad.IDSUMINISTRO
        args(6) = New SqlParameter("@IDFUENTEFINANCIAMIENTO", SqlDbType.Int)
        args(6).Value = IIf(lEntidad.IDFUENTEFINANCIAMIENTO = Nothing, DBNull.Value, lEntidad.IDFUENTEFINANCIAMIENTO)
        args(7) = New SqlParameter("@IDRESPONSABLEDISTRIBUCION", SqlDbType.Int)
        args(7).Value = IIf(lEntidad.IDRESPONSABLEDISTRIBUCION = Nothing, DBNull.Value, lEntidad.IDRESPONSABLEDISTRIBUCION)
        args(8) = New SqlParameter("@ESTACERRADO", SqlDbType.TinyInt)
        args(8).Value = lEntidad.ESTACERRADO
        args(9) = New SqlParameter("@CONSIDERARFUENTE", SqlDbType.TinyInt)
        args(9).Value = lEntidad.CONSIDERARFUENTE
        args(10) = New SqlParameter("@CONSIDERARRESPONSABLE", SqlDbType.TinyInt)
        args(10).Value = lEntidad.CONSIDERARRESPONSABLE
        args(11) = New SqlParameter("@CONSIDERARVENCIDOS", SqlDbType.TinyInt)
        args(11).Value = lEntidad.CONSIDERARVENCIDOS
        args(12) = New SqlParameter("@CONSIDERARNODISPONIBLES", SqlDbType.TinyInt)
        args(12).Value = lEntidad.CONSIDERARNODISPONIBLES
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
        args(18) = New SqlParameter("@CONSIDERARDISPONIBLES", SqlDbType.TinyInt)
        args(18).Value = lEntidad.CONSIDERARDISPONIBLES

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INVENTARIO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_ALM_INVENTARIO ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As INVENTARIO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")
        strSQL.Append("AND IDINVENTARIO = @IDINVENTARIO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDINVENTARIO", SqlDbType.Int)
        args(1).Value = lEntidad.IDINVENTARIO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.FECHAINICIO = IIf(.Item("FECHAINICIO") Is DBNull.Value, Nothing, .Item("FECHAINICIO"))
                lEntidad.FECHACIERRE = IIf(.Item("FECHACIERRE") Is DBNull.Value, Nothing, .Item("FECHACIERRE"))
                lEntidad.FECHACIERREEXISTENCIA = IIf(.Item("FECHACIERREEXISTENCIA") Is DBNull.Value, Nothing, .Item("FECHACIERREEXISTENCIA"))
                lEntidad.IDSUMINISTRO = IIf(.Item("IDSUMINISTRO") Is DBNull.Value, Nothing, .Item("IDSUMINISTRO"))
                lEntidad.IDFUENTEFINANCIAMIENTO = IIf(.Item("IDFUENTEFINANCIAMIENTO") Is DBNull.Value, Nothing, .Item("IDFUENTEFINANCIAMIENTO"))
                lEntidad.IDRESPONSABLEDISTRIBUCION = IIf(.Item("IDRESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, .Item("IDRESPONSABLEDISTRIBUCION"))
                lEntidad.ESTACERRADO = IIf(.Item("ESTACERRADO") Is DBNull.Value, Nothing, .Item("ESTACERRADO"))
                lEntidad.CONSIDERARFUENTE = IIf(.Item("CONSIDERARFUENTE") Is DBNull.Value, Nothing, .Item("CONSIDERARFUENTE"))
                lEntidad.CONSIDERARRESPONSABLE = IIf(.Item("CONSIDERARRESPONSABLE") Is DBNull.Value, Nothing, .Item("CONSIDERARRESPONSABLE"))
                lEntidad.CONSIDERARVENCIDOS = IIf(.Item("CONSIDERARVENCIDOS") Is DBNull.Value, Nothing, .Item("CONSIDERARVENCIDOS"))
                lEntidad.CONSIDERARNODISPONIBLES = IIf(.Item("CONSIDERARNODISPONIBLES") Is DBNull.Value, Nothing, .Item("CONSIDERARNODISPONIBLES"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.CONSIDERARDISPONIBLES = IIf(.Item("CONSIDERARDISPONIBLES") Is DBNull.Value, Nothing, .Item("CONSIDERARDISPONIBLES"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As INVENTARIO
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDINVENTARIO),0) + 1 ")
        strSQL.Append("FROM SAB_ALM_INVENTARIO ")
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = lEntidad.IDALMACEN

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDALMACEN As Int32) As listaINVENTARIO

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaINVENTARIO

        Try
            Do While dr.Read()
                Dim mEntidad As New INVENTARIO
                mEntidad.IDALMACEN = IDALMACEN
                mEntidad.IDINVENTARIO = IIf(dr("IDINVENTARIO") Is DBNull.Value, Nothing, dr("IDINVENTARIO"))
                mEntidad.FECHAINICIO = IIf(dr("FECHAINICIO") Is DBNull.Value, Nothing, dr("FECHAINICIO"))
                mEntidad.FECHACIERRE = IIf(dr("FECHACIERRE") Is DBNull.Value, Nothing, dr("FECHACIERRE"))
                mEntidad.FECHACIERREEXISTENCIA = IIf(dr("FECHACIERREEXISTENCIA") Is DBNull.Value, Nothing, dr("FECHACIERREEXISTENCIA"))
                mEntidad.IDSUMINISTRO = IIf(dr("IDSUMINISTRO") Is DBNull.Value, Nothing, dr("IDSUMINISTRO"))
                mEntidad.IDFUENTEFINANCIAMIENTO = IIf(dr("IDFUENTEFINANCIAMIENTO") Is DBNull.Value, Nothing, dr("IDFUENTEFINANCIAMIENTO"))
                mEntidad.IDRESPONSABLEDISTRIBUCION = IIf(dr("IDRESPONSABLEDISTRIBUCION") Is DBNull.Value, Nothing, dr("IDRESPONSABLEDISTRIBUCION"))
                mEntidad.ESTACERRADO = IIf(dr("ESTACERRADO") Is DBNull.Value, Nothing, dr("ESTACERRADO"))
                mEntidad.CONSIDERARFUENTE = IIf(dr("CONSIDERARFUENTE") Is DBNull.Value, Nothing, dr("CONSIDERARFUENTE"))
                mEntidad.CONSIDERARRESPONSABLE = IIf(dr("CONSIDERARRESPONSABLE") Is DBNull.Value, Nothing, dr("CONSIDERARRESPONSABLE"))
                mEntidad.CONSIDERARVENCIDOS = IIf(dr("CONSIDERARVENCIDOS") Is DBNull.Value, Nothing, dr("CONSIDERARVENCIDOS"))
                mEntidad.CONSIDERARNODISPONIBLES = IIf(dr("CONSIDERARNODISPONIBLES") Is DBNull.Value, Nothing, dr("CONSIDERARNODISPONIBLES"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.CONSIDERARDISPONIBLES = IIf(dr("CONSIDERARDISPONIBLES") Is DBNull.Value, Nothing, dr("CONSIDERARDISPONIBLES"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDALMACEN As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE IDALMACEN = @IDALMACEN ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Dim tables(0) As String
        tables(0) = New String("INVENTARIO")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append("SELECT IDALMACEN, ")
        strSQL.Append("IDINVENTARIO, ")
        strSQL.Append("FECHAINICIO, ")
        strSQL.Append("FECHACIERRE, ")
        strSQL.Append("FECHACIERREEXISTENCIA, ")
        strSQL.Append("IDSUMINISTRO, ")
        strSQL.Append("IDFUENTEFINANCIAMIENTO, ")
        strSQL.Append("IDRESPONSABLEDISTRIBUCION, ")
        strSQL.Append("ESTACERRADO, ")
        strSQL.Append("CONSIDERARFUENTE, ")
        strSQL.Append("CONSIDERARRESPONSABLE, ")
        strSQL.Append("CONSIDERARVENCIDOS, ")
        strSQL.Append("CONSIDERARNODISPONIBLES, ")
        strSQL.Append("AUUSUARIOCREACION, ")
        strSQL.Append("AUFECHACREACION, ")
        strSQL.Append("AUUSUARIOMODIFICACION, ")
        strSQL.Append("AUFECHAMODIFICACION, ")
        strSQL.Append("ESTASINCRONIZADA, ")
        strSQL.Append("CONSIDERARDISPONIBLES ")
        strSQL.Append("FROM SAB_ALM_INVENTARIO ")

    End Sub

#End Region

End Class