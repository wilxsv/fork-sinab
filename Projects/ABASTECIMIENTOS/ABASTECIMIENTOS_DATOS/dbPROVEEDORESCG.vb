Imports System.Text
Public Class dbPROVEEDORESCG
    Inherits dbBase

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As PROVEEDORESCG
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDPROVEEDOR = 0 _
            Or lEntidad.IDPROVEEDOR = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDPROVEEDOR = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CG_proveedores ")
        strSQL.Append(" SET NOMBRE = @NOMBRE, NOMBREABR=@NOMBREABR ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = lEntidad.IDESTABLECIMIENTO
        args(3) = New SqlParameter("@NOMBREABR", SqlDbType.VarChar)
        args(3).Value = lEntidad.NOMBREABR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROVEEDORESCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CG_proveedores ")
        strSQL.Append(" VALUES (@IDPROVEEDOR,@IDESTABLECIMIENTO,@NIT,@NOMBRE,@NOMBREABR) ")



        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = lEntidad.IDESTABLECIMIENTO
        args(3) = New SqlParameter("@NIT", SqlDbType.VarChar)
        args(3).Value = lEntidad.NIT
        args(4) = New SqlParameter("@NOMBREABR", SqlDbType.VarChar)
        args(4).Value = lEntidad.NOMBREABR

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROVEEDORESCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CG_PROVEEDORES ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDPROVEEDOR, IDESTABLECIMIENTO, ")
        strSQL.Append(" NIT, NOMBRE, NOMBREABR ")
        strSQL.Append(" FROM SAB_CG_PROVEEDORES ")

    End Sub
    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO=" & IDESTABLECIMIENTO)
        strSQL.Append(" ORDER BY nombre ")
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As PROVEEDORESCG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPROVEEDOR),0) + 1 ")
        strSQL.Append(" FROM SAB_CG_PROVEEDORES WHERE IDESTABLECIMIENTO=" & lEntidad.IDESTABLECIMIENTO)

      

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function


    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

    End Function
    Public Function ObtenerTiposGarantias() As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDTIPOGARANTIA, NOMBRE ")
        strSQL.Append(" FROM SAB_CG_TIPOSGARANTIAS ")


        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDataSetPorID2(ByVal idproveedor As Integer, ByVal idestablecimiento As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO=" & idestablecimiento & " and idproveedor=" & idproveedor)
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerID2(ByVal IDESTABLECIMIENTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPROVEEDOR),0) + 1 ")
        strSQL.Append(" FROM SAB_CG_PROVEEDORES WHERE IDESTABLECIMIENTO=" & IDESTABLECIMIENTO)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerDataSetPorNIT(ByVal idestablecimiEnto As Integer, ByVal NIT As String) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDPROVEEDOR FROM SAB_CG_PROVEEDORES")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=" & idestablecimiEnto & " and NIT='" & NIT & "'")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerProveedorPorNIT(ByVal idestablecimiEnto As Integer, ByVal NIT As String) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDPROVEEDOR,NOMBRE,NOMBREABR FROM SAB_CG_PROVEEDORES")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=" & idestablecimiEnto & " and NIT='" & NIT & "'")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerProveedorPorIdProveedor(ByVal idestablecimiEnto As Integer, ByVal idp As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT NIT, NOMBRE,NOMBREABR FROM SAB_CG_PROVEEDORES")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=" & idestablecimiEnto & " and idproveedor=" & idp)

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerProveedorPorNombre(ByVal idestablecimiEnto As Integer, ByVal nombre As String) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDPROVEEDOR,NOMBRE,NOMBREABR,NIT FROM SAB_CG_PROVEEDORES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO=@idestablecimiento and nombre LIKE '%' + @nombre + '%' ")
        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idestablecimiEnto
        args(1) = New SqlParameter("@nombre", SqlDbType.VarChar)
        args(1).Value = nombre
        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
End Class
