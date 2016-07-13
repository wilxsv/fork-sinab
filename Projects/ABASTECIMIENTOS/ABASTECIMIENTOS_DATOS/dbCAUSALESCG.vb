Imports System.Text
Public Class dbCAUSALESCG
    Inherits dbBase

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As CAUSALESCG
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCAUSAL = 0 _
            Or lEntidad.IDCAUSAL = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDCAUSAL = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CG_CAUSALES ")
        strSQL.Append(" SET NOMBRE = @NOMBRE ")
        strSQL.Append(" WHERE IDCAUSAL = @IDCAUSAL AND IDTIPOGARANTIA=@IDTIPOGARANTIA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDCAUSAL", SqlDbType.Int)
        args(0).Value = lEntidad.IDCAUSAL
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(2).Value = lEntidad.IDTIPOGARANTIA


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CAUSALESCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CG_CAUSALES ")
        strSQL.Append(" values (@IDCAUSAL,@IDTIPOGARANTIA, ")
        strSQL.Append(" @NOMBRE) ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDCAUSAL", SqlDbType.Int)
        args(0).Value = lEntidad.IDCAUSAL
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(2).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CAUSALESCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CG_CAUSALES ")
        strSQL.Append(" WHERE IDCAUSAL = @IDCAUSAL AND IDTIPOGARANTIA=@IDTIPOGARANTIA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDCAUSAL", SqlDbType.Int)
        args(0).Value = lEntidad.IDCAUSAL
        args(1) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDCAUSAL, IDTIPOGARANTIA, ")
        strSQL.Append(" NOMBRE ")
        strSQL.Append(" FROM SAB_CG_CAUSALES ")

    End Sub
    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As CAUSALESCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCAUSAL),0) + 1 ")
        strSQL.Append(" FROM SAB_CG_CAUSALES ")
        strSQL.Append(" WHERE IDTIPOGARANTIA=@IDTIPOGARANTIA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function


    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

    End Function
    Public Function ObtenerDataSetPorID2(ByVal Idcausal As Integer, ByVal idtipogarantia As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDcausal=" & Idcausal & " and idtipogarantia=" & idtipogarantia)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorID3(ByVal idtipogarantia As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE idtipogarantia=" & idtipogarantia)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerID2(ByVal IDTIPOGARANTIA As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCAUSAL),0) + 1 ")
        strSQL.Append(" FROM SAB_CG_MODALIDADCOMPRA WHERE IDTIPOGARANTIA=" & IDTIPOGARANTIA)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerTiposGarantias() As DataSet
       
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDTIPOGARANTIA, NOMBRE  ")
        strSQL.Append(" FROM SAB_CG_TIPOSGARANTIA ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ObtenerCausales() As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT C.IDCAUSAL, C.IDTIPOGARANTIA, C.NOMBRE, T.NOMBRE AS TIPOGARANTIA ")
        strSQL.Append(" FROM SAB_CG_CAUSALES C INNER JOIN SAB_CG_TIPOSGARANTIA  T ")
        strSQL.Append(" ON C.IDTIPOGARANTIA=T.IDTIPOGARANTIA ORDER BY C.IDTIPOGARANTIA")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
End Class
