Imports System.Text
Public Class dbListaCP
    Inherits dbBase

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As LISTACP
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDLISTA = 0 _
            Or lEntidad.IDLISTA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDLISTA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CP_CAT_LISTA ")
        strSQL.Append(" SET NOMBRE = @NOMBRE ")
        strSQL.Append(" WHERE IDLISTA = @IDLISTA AND IDSUMINISTRO=@IDSUMINISTRO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = lEntidad.IDSUMINISTRO


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As LISTACP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_CAT_LISTA ")
        strSQL.Append(" values (@IDLISTA,@NOMBRE, @IDSUMINISTRO) ")



        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As LISTACP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_CAT_LISTA ")
        strSQL.Append(" WHERE IDLISTA = @IDLISTA AND IDSUMINISTRO=@IDSUMINISTRO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDLISTA, IDSUMINISTRO, ")
        strSQL.Append(" NOMBRE ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA ")

    End Sub
    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As LISTACP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDLISTA),0) + 1 ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA ")
        ' strSQL.Append(" WHERE IDSUMINISTRO=@IDSUMINISTRO ")

        'Dim args(0) As SqlParameter
        'args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        'args(0).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function


    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

    End Function
    Public Function ObtenerDataSetPorID2(ByVal Idcausal As Integer, ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDLISTA=" & Idcausal & " and IDSUMINISTRO=" & IDSUMINISTRO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorID3(ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDSUMINISTRO=" & IDSUMINISTRO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerID2(ByVal IDSUMINISTRO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDLISTAL),0) + 1 ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA WHERE IDSUMINISTRO=" & IDSUMINISTRO)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerSuministros() As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDSUMINISTRO, DESCRIPCION  ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ObtenerLISTAS() As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT L.IDLISTA, L.IDSUMINISTRO, L.NOMBRE, S.DESCRIPCION AS SUMINISTRO ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA L INNER JOIN SAB_CAT_SUMINISTROS  S ")
        strSQL.Append(" ON L.IDSUMINISTRO=S.IDSUMINISTRO ORDER BY S.IDSUMINISTRO ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
End Class
