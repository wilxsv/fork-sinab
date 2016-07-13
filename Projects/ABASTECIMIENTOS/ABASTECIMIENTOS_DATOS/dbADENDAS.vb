Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCARGOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_CAT_CARGOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbADENDAS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As ADENDAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDADENDA = 0 _
            Or lEntidad.IDADENDA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDADENDA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_ADENDAS ")
        strSQL.Append(" SET IDESTABLECIMIENTO = @IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA = @IDPROCESOCOMPRA, ")
        strSQL.Append(" NUMEROADENDA = @NUMEROADENDA, ")
        strSQL.Append(" FECHAADENDA = @FECHAADENDA, ")
        strSQL.Append(" DETALLEADENDA = @DETALLEADENDA ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" WHERE IDADENDA = @IDADENDA ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDADENDA", SqlDbType.Int)
        args(0).Value = lEntidad.IDADENDA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROCESOCOMPRA
        args(3) = New SqlParameter("@NUMEROADENDA", SqlDbType.VarChar)
        args(3).Value = lEntidad.NUMEROADENDA
        args(4) = New SqlParameter("@FECHAADENDA", SqlDbType.DateTime)
        args(4).Value = lEntidad.FECHAADENDA
        args(5) = New SqlParameter("@DETALLEADENDA", SqlDbType.Text)
        args(5).Value = lEntidad.DETALLEADENDA
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ADENDAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_ADENDAS ")
        strSQL.Append(" ( IDADENDA, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" NUMEROADENDA, ")
        strSQL.Append(" FECHAADENDA, ")
        strSQL.Append(" DETALLEADENDA, ")
        strSQL.Append(" AUUSUARIOCREACION) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDADENDA, ")
        strSQL.Append(" @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROCESOCOMPRA, ")
        strSQL.Append(" @NUMEROADENDA, ")
        strSQL.Append(" @FECHAADENDA, ")
        strSQL.Append(" @DETALLEADENDA, ")
        strSQL.Append(" @AUUSUARIOCREACION) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDADENDA", SqlDbType.Int)
        args(0).Value = lEntidad.IDADENDA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(2).Value = lEntidad.IDPROCESOCOMPRA
        args(3) = New SqlParameter("@NUMEROADENDA", SqlDbType.VarChar)
        args(3).Value = lEntidad.NUMEROADENDA
        args(4) = New SqlParameter("@FECHAADENDA", SqlDbType.DateTime)
        args(4).Value = lEntidad.FECHAADENDA
        args(5) = New SqlParameter("@DETALLEADENDA", SqlDbType.Text)
        args(5).Value = lEntidad.DETALLEADENDA
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ADENDAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_ADENDAS ")
        strSQL.Append(" WHERE IDADENDA = @IDADENDA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDADENDA", SqlDbType.Int)
        args(0).Value = lEntidad.IDADENDA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ADENDAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDADENDA = @IDADENDA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDADENDA", SqlDbType.Int)
        args(0).Value = lEntidad.IDADENDA

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDESTABLECIMIENTO = IIf(.Item("IDESTABLECIMIENTO") Is DBNull.Value, Nothing, .Item("IDESTABLECIMIENTO"))
                lEntidad.IDPROCESOCOMPRA = IIf(.Item("IDPROCESOCOMPRA") Is DBNull.Value, Nothing, .Item("IDPROCESOCOMPRA"))
                lEntidad.NUMEROADENDA = IIf(.Item("NUMEROADENDA") Is DBNull.Value, Nothing, .Item("NUMEROADENDA"))
                lEntidad.FECHAADENDA = IIf(.Item("FECHAADENDA") Is DBNull.Value, Nothing, .Item("FECHAADENDA"))
                lEntidad.DETALLEADENDA = IIf(.Item("DETALLEADENDA") Is DBNull.Value, Nothing, .Item("DETALLEADENDA"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As ADENDAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDADENDA),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_ADENDAS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

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
        tables(0) = New String("ADENDAS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDADENDA, ")
        strSQL.Append(" IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROCESOCOMPRA, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" NUMEROADENDA, ")
        strSQL.Append(" FECHAADENDA, ")
        strSQL.Append(" DETALLEADENDA ")
        strSQL.Append(" FROM SAB_UACI_ADENDAS ")

    End Sub

#End Region

End Class
