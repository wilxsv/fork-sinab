Partial Public Class dbCOMISIONPROCESOCOMPRA

#Region " Metodos adicionales "

    ''' <summary>
    ''' Actualizar la clave de la comision evaluadora de alto nivel.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador para realizar el filtro en la tabla</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador para realizar el filtro en la tabla</param>
    ''' <param name="IDCOMISION">Identificador para realizar el filtro en la tabla</param>
    ''' <param name="CLAVE">Clave encriptada</param>
    ''' <returns>Numero entero indicando si la actualizacion ha sido satisfactoria.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_COMISIONPROCESOCOMPRA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Henry Zavaleta]      Creado
    ''' </history> 
    Public Function ActualizarClave(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCOMISION As Integer, ByVal CLAVE As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_COMISIONPROCESOCOMPRA ")
        strSQL.Append("SET ")
        strSQL.Append("CLAVE = @CLAVE ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND IDCOMISION = @IDCOMISION ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@CLAVE", SqlDbType.VarChar)
        args(0).Value = CLAVE
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(2).Value = IDPROCESOCOMPRA
        args(3) = New SqlParameter("@IDCOMISION", SqlDbType.BigInt)
        args(3).Value = IDCOMISION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Verifica si un usuario dado se ha creado como usuario de comisión de alto nivel, si se encuentra habilitado y si la clave proporcionada es correcta.
    ''' </summary>
    ''' <param name="USUARIO">Usuario.</param>
    ''' <param name="CLAVE">Clave encriptada.</param>
    ''' <returns>Boolean.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_COMISIONPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ValidarUsuario(ByVal USUARIO As String, ByVal CLAVE As String) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_UACI_COMISIONPROCESOCOMPRA ")
        strSQL.Append("WHERE USUARIOCOMISION = @USUARIO ")
        If CLAVE <> String.Empty Then
            strSQL.Append("AND CLAVE = @CLAVE ")
        End If
        strSQL.Append("AND ESTAHABILITADO = 1 ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(0).Value = USUARIO

        If CLAVE <> String.Empty Then
            args(1) = New SqlParameter("@CLAVE", SqlDbType.VarChar)
            args(1).Value = CLAVE
        End If

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' Obtiene el establecimiento al cual se encuentra asociado un usuario de comisión de alto nivel.
    ''' </summary>
    ''' <param name="USUARIOCOMISION">Usuario de comisión de alto nivel.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_COMISIONPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerEstablecimientoUsuarioComisionAltoNivel(ByVal USUARIOCOMISION As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_UACI_COMISIONPROCESOCOMPRA ")
        strSQL.Append("WHERE USUARIOCOMISION = @USUARIOCOMISION ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@USUARIOCOMISION", SqlDbType.VarChar)
        args(0).Value = USUARIOCOMISION

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Inhabilita al usuario creado con la comisión de alto nivel, impidiendo su acceso al sistema una vez finalizada la adjudicación.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_COMISIONPROCESOCOMPRA</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function InhabilitarUsuarioComisionAltoNivel(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_UACI_COMISIONPROCESOCOMPRA ")
        strSQL.Append("SET ESTAHABILITADO = 0 ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ExisteComisionEvaluacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT COUNT(CPC.IDCOMISION) ")
        strSQL.Append("FROM SAB_UACI_COMISIONPROCESOCOMPRA CPC ")
        strSQL.Append("INNER JOIN SAB_UACI_COMISIONESEVALUADORAS CE ")
        strSQL.Append("ON CE.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("CE.IDCOMISION = CPC.IDCOMISION ")
        strSQL.Append("WHERE CE.ESALTONIVEL = 0 AND ")
        strSQL.Append("CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function ObtenerDsComision(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_DETALLECOMISIONEVALUADORA.NOMBRE, SAB_UACI_DETALLECOMISIONEVALUADORA.CARGO, SAB_UACI_DETALLECOMISIONEVALUADORA.ESTAHABILITADO ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS AS PC INNER JOIN ")
        strSQL.Append(" SAB_UACI_COMISIONPROCESOCOMPRA AS CPC ON PC.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" PC.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_COMISIONESEVALUADORAS AS CE ON CPC.IDCOMISION = CE.IDCOMISION AND ")
        strSQL.Append(" CPC.IDESTABLECIMIENTO = CE.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLECOMISIONEVALUADORA ON CE.IDCOMISION = SAB_UACI_DETALLECOMISIONEVALUADORA.IDCOMISION AND ")
        strSQL.Append(" CE.IDESTABLECIMIENTO = SAB_UACI_DETALLECOMISIONEVALUADORA.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
