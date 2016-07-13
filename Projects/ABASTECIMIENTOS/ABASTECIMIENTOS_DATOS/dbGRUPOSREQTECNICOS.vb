Public Class dbGRUPOSREQTECNICOS
    Inherits dbBase

    Public Function ObtenerDataSetGRUPOSREQTECNICOS() As DataSet
        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT [IDGRUPOREQ],[NOMBRE] FROM [SAB_CAT_GRUPOSREQTECNICOS] ")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
        Dim fila As DataRow = ds.Tables(0).NewRow
        fila("IDGRUPOREQ") = 0
        fila("NOMBRE") = "Todos"
        ds.Tables(0).Rows.Add(fila)
        Return ds
    End Function

    Public Overrides Function Actualizar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As ENTIDADES.entidadBase) As String
        Return String.Empty
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function
End Class
