Imports System.Text
Public Class dbTIPOSDOCUMENTOSCG
    Inherits dbBase

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As TIPOSDOCUMENTOCG
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDTIPODOCUMENTO = 0 _
            Or lEntidad.IDTIPODOCUMENTO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDTIPODOCUMENTO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CG_TIPOSDOCUMENTO ")
        strSQL.Append(" SET NOMBRE = @NOMBRE ")
        strSQL.Append(" WHERE IDTIPODOCUMENTO = @IDTIPODOCUMENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPODOCUMENTO
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOSDOCUMENTOCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CG_TIPOSDOCUMENTO ")
        strSQL.Append(" VALUES (@IDTIPODOCUMENTO, ")
        strSQL.Append(" @NOMBRE) ")


        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPODOCUMENTO
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As TIPOSDOCUMENTOCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CG_TIPOSDOCUMENTO ")
        strSQL.Append(" WHERE IDTIPODOCUMENTO = @IDTIPODOCUMENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPODOCUMENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDTIPODOCUMENTO, ")
        strSQL.Append(" NOMBRE ")
        strSQL.Append(" FROM SAB_CG_TIPOSDOCUMENTO ")

    End Sub
    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As TIPOSDOCUMENTOCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDTIPODOCUMENTO),0) + 1 ")
        strSQL.Append(" FROM SAB_CG_TIPOSDOCUMENTO ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function


    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

    End Function
    Public Function ObtenerDataSetPorID2(ByVal Identidad As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPODOCUMENTO=" & Identidad)
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerID2() As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDTIPODOCUMENTO),0) + 1 ")
        strSQL.Append(" FROM SAB_CG_TIPOSDOCUMENTO ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
End Class