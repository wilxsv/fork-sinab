Partial Public Class dbCANCELACIONPRODUCTO

#Region " Metodos Agregados "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <param name="RENGLON"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerCancelacionesPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("convert(varchar, CP.FECHACANCELACION, 103) FECHACANCELACION, ")
        strSQL.Append("isnull(CP.MOTIVOCANCELACION, '') MOTIVOCANCELACION, ")
        strSQL.Append("isnull(convert(varchar, CP.FECHAANULACION, 103), '') FECHAANULACION, ")
        strSQL.Append("isnull(CP.MOTIVOANULACION, '') MOTIVOANULACION, ")
        strSQL.Append("DCP.LOTE, ")
        strSQL.Append("DCP.ESTAHABILITADO ")
        strSQL.Append("FROM SAB_UACI_CANCELACIONPRODUCTO CP ")
        strSQL.Append("LEFT OUTER JOIN SAB_UACI_DETALLECANCELACIONPRODUCTO DCP ")
        strSQL.Append("ON (CP.IDESTABLECIMIENTO = DCP.IDESTABLECIMIENTO ")
        strSQL.Append("AND CP.IDPROVEEDOR = DCP.IDPROVEEDOR ")
        strSQL.Append("AND CP.IDCONTRATO = DCP.IDCONTRATO ")
        strSQL.Append("AND CP.RENGLON = DCP.RENGLON ")
        strSQL.Append("AND CP.IDCANCELACION = DCP.IDCANCELACION) ")
        strSQL.Append("WHERE CP.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND CP.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND CP.IDCONTRATO = @IDCONTRATO ")
        strSQL.Append("AND CP.RENGLON = @RENGLON ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@RENGLON", SqlDbType.BigInt)
        args(3).Value = RENGLON

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

#End Region

End Class
