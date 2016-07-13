Partial Public Class dbROLESUSUARIOS

#Region "metodos"
    ''' <summary>
    '''  Se utiliza para devolver el rol de usuario correspondiente al nombre usuario que ingreso al sistema
    ''' </summary>
    ''' <param name="asUser"></param> nombre de usuario
    ''' <returns>
    ''' el rol de un usuario
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SEGROLESUSUARIOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function RolUsuario(ByVal asUser As String) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDROL ")
        strSQL.Append(" FROM SEGROLESUSUARIOS ")
        strSQL.Append(" WHERE IDUSUARIO = @user_id ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@user_id", SqlDbType.VarChar)
        args(0).Value = asUser

        Return SqlHelper.ExecuteScalar(Me.cnnStrSeg, CommandType.Text, strSQL.ToString(), args)

        Return True
    End Function

#End Region

End Class
