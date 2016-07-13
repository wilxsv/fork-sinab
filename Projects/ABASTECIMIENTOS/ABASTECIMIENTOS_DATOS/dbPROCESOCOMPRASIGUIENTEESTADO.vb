Public Class dbPROCESOCOMPRASIGUIENTEESTADO
    Inherits dbBase

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
    Public Function getSiguienteEstado(ByVal idestablecimiento As Integer, ByVal iddependendia As Integer, ByVal idestado As Integer) As Integer
        Dim sqlStr As String = "select isnull(idestadosiguiente,2) idestadosiguiente FROM SAB_EST_PROCESOCOMPRASIGUIENTEESTADO where idestablecimiento=@idestablecimiento and iddependencia=@iddependencia and idestado=@idestado "
        Dim con As New SqlConnection(Me.cnnStr)
        Dim cmd As New SqlCommand(sqlStr, con)
        cmd.Parameters.Add("@idestablecimiento", SqlDbType.Int).Value = idestablecimiento
        cmd.Parameters.Add("@iddependencia", SqlDbType.Int).Value = iddependendia
        cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = idestado
        Dim val As Integer
        con.Open()
        val = cmd.ExecuteScalar
        con.Close()
        Return val
    End Function
    Public Function getSiguienteEstadoByUser(ByVal usuario As String, ByVal idestado As Integer) As Integer
        Dim sqlStr As String = "select isnull(idestadosiguiente,2) idestadosiguiente FROM SAB_EST_SOLICITUDUSUARIOSIGUIENTEESTADO where usuario=@usuario and idestado=@idestado "
        Dim con As New SqlConnection(Me.cnnStr)
        Dim cmd As New SqlCommand(sqlStr, con)
        cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario
        cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = idestado
        Dim val As Integer
        con.Open()
        val = cmd.ExecuteScalar
        con.Close()
        Return val
    End Function
End Class
