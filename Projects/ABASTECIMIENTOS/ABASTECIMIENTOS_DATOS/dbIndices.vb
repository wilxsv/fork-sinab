Public Class dbIndices
    Inherits dbBase
    ''Cr_Report.Sections(6).Suppress = True 

    Public Function GET_INFO_INDICADORES_MR(ByVal IDEstablecimiento As String, ByVal IDProcesoCompra As String, ByVal IDProveedor As String, ByVal IDAlmacenEntrega As String, ByVal IDCONTRATO As String) As dsIndices
        Dim cmdStr As String = "SP_GET_INFO_INDICADORES_MR"
        Dim da As New SqlClient.SqlDataAdapter(cmdStr, Me.cnnStr)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@IDESTABLECIMIENTO", SqlDbType.Int).Value = IDEstablecimiento
        da.SelectCommand.Parameters.Add("@IDPROCESOCOMPRA", SqlDbType.BigInt).Value = IDProcesoCompra
        da.SelectCommand.Parameters.Add("@IDPROVEEDOR", SqlDbType.Int).Value = IDProveedor
        da.SelectCommand.Parameters.Add("@IDALMACENENTREGA", SqlDbType.Int).Value = IDAlmacenEntrega
        da.SelectCommand.Parameters.Add("@IDCONTRATO", SqlDbType.Int).Value = IDCONTRATO
        Dim ds As New dsIndices
        da.Fill(ds.SP_GET_INFO_INDICADORES_MR)
        Return ds
    End Function
    Public Function GET_INFO_INDICADORES_MR(ByVal IDEstablecimiento As String) As dsIndices
        Dim cmdStr As String = "SP_GET_INFO_INDICADORES_DATA_MR"
        Dim da As New SqlClient.SqlDataAdapter(cmdStr, Me.cnnStr)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@IDESTABLECIMIENTO", SqlDbType.Int).Value = IDEstablecimiento
        Dim ds As New dsIndices
        da.Fill(ds.SP_GET_INFO_INDICADORES_MR)
        Return ds
    End Function
    Public Overrides Function Actualizar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As ENTIDADES.entidadBase) As String
        Return Nothing
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function
End Class
