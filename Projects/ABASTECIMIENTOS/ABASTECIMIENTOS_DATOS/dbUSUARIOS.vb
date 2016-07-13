Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbUSUARIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SEGUSUARIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	05/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbUSUARIOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As USUARIOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDUSUARIO = 0 _
            Or lEntidad.IDUSUARIO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDUSUARIO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SEGUSUARIOS ")
        strSQL.Append(" SET USUARIO = @USUARIO, ")
        strSQL.Append(" CLAVE = @CLAVE, ")
        strSQL.Append(" IDEMPLEADO = @IDEMPLEADO, ")
        strSQL.Append(" ESTAHABILITADO = @ESTAHABILITADO, ")
        strSQL.Append(" ESTAELIMINADO = @ESTAELIMINADO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" AUUSUARIOELIMINACION = @AUUSUARIOELIMINACION, ")
        strSQL.Append(" AUFECHAELIMINACION = @AUFECHAELIMINACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDUSUARIO = @IDUSUARIO ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(0).Value = lEntidad.USUARIO
        args(1) = New SqlParameter("@CLAVE", SqlDbType.VarChar)
        args(1).Value = lEntidad.CLAVE
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(2).Value = lEntidad.IDEMPLEADO
        args(3) = New SqlParameter("@ESTAHABILITADO", SqlDbType.TinyInt)
        args(3).Value = lEntidad.ESTAHABILITADO
        args(4) = New SqlParameter("@ESTAELIMINADO", SqlDbType.Int)
        args(4).Value = lEntidad.ESTAELIMINADO
        args(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(5).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(6).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(7) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(7).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(8) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(9) = New SqlParameter("@AUUSUARIOELIMINACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.AUUSUARIOELIMINACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOELIMINACION)
        args(10) = New SqlParameter("@AUFECHAELIMINACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.AUFECHAELIMINACION = Nothing, DBNull.Value, lEntidad.AUFECHAELIMINACION)
        args(11) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(11).Value = lEntidad.ESTASINCRONIZADA
        args(12) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(12).Value = lEntidad.IDUSUARIO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As USUARIOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SEGUSUARIOS ")
        strSQL.Append(" ( IDUSUARIO, ")
        strSQL.Append(" USUARIO, ")
        strSQL.Append(" CLAVE, ")
        strSQL.Append(" IDEMPLEADO, ")
        strSQL.Append(" ESTAHABILITADO, ")
        strSQL.Append(" ESTAELIMINADO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" AUUSUARIOELIMINACION, ")
        strSQL.Append(" AUFECHAELIMINACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDUSUARIO, ")
        strSQL.Append(" @USUARIO, ")
        strSQL.Append(" @CLAVE, ")
        strSQL.Append(" @IDEMPLEADO, ")
        strSQL.Append(" @ESTAHABILITADO, ")
        strSQL.Append(" @ESTAELIMINADO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @AUUSUARIOELIMINACION, ")
        strSQL.Append(" @AUFECHAELIMINACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(12) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(0).Value = lEntidad.IDUSUARIO
        args(1) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(1).Value = lEntidad.USUARIO
        args(2) = New SqlParameter("@CLAVE", SqlDbType.VarChar)
        args(2).Value = lEntidad.CLAVE
        args(3) = New SqlParameter("@IDEMPLEADO", SqlDbType.Int)
        args(3).Value = lEntidad.IDEMPLEADO
        args(4) = New SqlParameter("@ESTAHABILITADO", SqlDbType.TinyInt)
        args(4).Value = lEntidad.ESTAHABILITADO
        args(5) = New SqlParameter("@ESTAELIMINADO", SqlDbType.Int)
        args(5).Value = lEntidad.ESTAELIMINADO
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(10) = New SqlParameter("@AUUSUARIOELIMINACION", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.AUUSUARIOELIMINACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOELIMINACION)
        args(11) = New SqlParameter("@AUFECHAELIMINACION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.AUFECHAELIMINACION = Nothing, DBNull.Value, lEntidad.AUFECHAELIMINACION)
        args(12) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(12).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As USUARIOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SEGUSUARIOS ")
        strSQL.Append(" WHERE IDUSUARIO = @IDUSUARIO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(0).Value = lEntidad.IDUSUARIO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As USUARIOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDUSUARIO = @IDUSUARIO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        args(0).Value = lEntidad.IDUSUARIO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.USUARIO = IIf(.Item("USUARIO") Is DBNull.Value, Nothing, .Item("USUARIO"))
                lEntidad.CLAVE = IIf(.Item("CLAVE") Is DBNull.Value, Nothing, .Item("CLAVE"))
                lEntidad.IDEMPLEADO = IIf(.Item("IDEMPLEADO") Is DBNull.Value, Nothing, .Item("IDEMPLEADO"))
                lEntidad.ESTAHABILITADO = IIf(.Item("ESTAHABILITADO") Is DBNull.Value, Nothing, .Item("ESTAHABILITADO"))
                lEntidad.ESTAELIMINADO = IIf(.Item("ESTAELIMINADO") Is DBNull.Value, Nothing, .Item("ESTAELIMINADO"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.AUUSUARIOELIMINACION = IIf(.Item("AUUSUARIOELIMINACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOELIMINACION"))
                lEntidad.AUFECHAELIMINACION = IIf(.Item("AUFECHAELIMINACION") Is DBNull.Value, Nothing, .Item("AUFECHAELIMINACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As USUARIOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDUSUARIO),0) + 1 ")
        strSQL.Append(" FROM SEGUSUARIOS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaPorID() As listaUSUARIOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Dim lista As New listaUSUARIOS

        Try
            Do While dr.Read()
                Dim mEntidad As New USUARIOS
                mEntidad.IDUSUARIO = IIf(dr("IDUSUARIO") Is DBNull.Value, Nothing, dr("IDUSUARIO"))
                mEntidad.USUARIO = IIf(dr("USUARIO") Is DBNull.Value, Nothing, dr("USUARIO"))
                mEntidad.CLAVE = IIf(dr("CLAVE") Is DBNull.Value, Nothing, dr("CLAVE"))
                mEntidad.IDEMPLEADO = IIf(dr("IDEMPLEADO") Is DBNull.Value, Nothing, dr("IDEMPLEADO"))
                mEntidad.ESTAHABILITADO = IIf(dr("ESTAHABILITADO") Is DBNull.Value, Nothing, dr("ESTAHABILITADO"))
                mEntidad.ESTAELIMINADO = IIf(dr("ESTAELIMINADO") Is DBNull.Value, Nothing, dr("ESTAELIMINADO"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.AUUSUARIOELIMINACION = IIf(dr("AUUSUARIOELIMINACION") Is DBNull.Value, Nothing, dr("AUUSUARIOELIMINACION"))
                mEntidad.AUFECHAELIMINACION = IIf(dr("AUFECHAELIMINACION") Is DBNull.Value, Nothing, dr("AUFECHAELIMINACION"))
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

        ds = SqlHelper.ExecuteDataset(Me.cnnStrSeg, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim tables(0) As String
        tables(0) = New String("USUARIOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDUSUARIO, ")
        strSQL.Append(" USUARIO, ")
        strSQL.Append(" CLAVE, ")
        strSQL.Append(" IDEMPLEADO, ")
        strSQL.Append(" ESTAHABILITADO, ")
        strSQL.Append(" ESTAELIMINADO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" AUUSUARIOELIMINACION, ")
        strSQL.Append(" AUFECHAELIMINACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SEGUSUARIOS ")

    End Sub

#End Region

End Class
