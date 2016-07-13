Imports System.Text
Public Class dbAspectoCP
    Inherits dbBase

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As ASPECTOCP
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDASPECTO = 0 _
            Or lEntidad.IDASPECTO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDASPECTO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CP_CAT_ASPECTOS ")
        strSQL.Append(" SET NOMBRE = @NOMBRE ")
        strSQL.Append(" WHERE IDLISTA = @IDLISTA AND IDASPECTO=@IDASPECTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDASPECTO", SqlDbType.Int)
        args(2).Value = lEntidad.IDASPECTO


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ASPECTOCP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_CAT_ASPECTOS ")
        strSQL.Append(" values (@IDASPECTO,@IDLISTA,@NOMBRE ) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDASPECTO", SqlDbType.Int)
        args(2).Value = lEntidad.IDASPECTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As ASPECTOCP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_CAT_ASPECTOS ")
        strSQL.Append(" WHERE IDLISTA = @IDLISTA AND IDASPECTO=@IDASPECTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@IDASPECTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDASPECTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDLISTA, IDASPECTO, NOMBRE")
        strSQL.Append(" NOMBRE ")
        strSQL.Append(" FROM SAB_CP_CAT_ASPECTOS ")

    End Sub
    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As ASPECTOCP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDASPECTO),0) + 1 ")
        strSQL.Append(" FROM SAB_CP_CAT_ASPECTOS ")
        strSQL.Append(" WHERE IDLISTA=@IDLISTA ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function


    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

    End Function
    Public Function ObtenerDataSetPorID2(ByVal IDLISTA As Integer, ByVal IDASPECTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDLISTA=" & IDLISTA & " and IDASPECTO=" & IDASPECTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorID3(ByVal IDLISTA As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDLISTA=" & IDLISTA)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerID2(ByVal IDLISTA As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDASPECTO),0) + 1 ")
        strSQL.Append(" FROM SAB_CP_CAT_ASPECTOS WHERE IDLISTA=" & IDLISTA)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerListas() As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDLISTA, NOMBRE  ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ObtenerASPECTOS() As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT A.IDLISTA, A.IDASPECTO, A.NOMBRE, L.NOMBRE AS LISTA ")
        strSQL.Append(" FROM SAB_CP_CAT_ASPECTOS A INNER JOIN SAB_CP_CAT_LISTA  L ")
        strSQL.Append(" ON A.IDLISTA=L.IDLISTA ORDER BY A.IDLISTA ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
End Class
