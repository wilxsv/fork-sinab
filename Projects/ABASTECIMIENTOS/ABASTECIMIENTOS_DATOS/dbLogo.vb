Public Class dbLogo
    Inherits dbBase
    ''' <summary>
    ''' Captura la imagen del establecimiento principal.
    ''' </summary>
    ''' <param name="IDEstablecimiento">Establecimiento donde se encuentra registrado el usuario</param>
    ''' <returns>El id del establecimiento con el logo de entidad principal.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_COMISIONPROCESOCOMPRA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Robinson Ruiz]      Creado
    ''' </history> 

    Public Function GetLogo(ByVal IDEstablecimiento As String) As dsLogo
        Dim cmdStr As String = "sp_GetLogoRaizEstablecimiento"
        Dim da As New SqlClient.SqlDataAdapter(cmdStr, Me.cnnStr)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@IDEstablecimiento", SqlDbType.Int).Value = IDEstablecimiento
        Dim ds As New dsLogo()
        da.Fill(ds.GetLogo)
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
