Imports System.Text

Partial Public Class dbMODALIDADESCOMPRA

    Public Function obtenerModalidadCompra(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append("TC.IDMODALIDADCOMPRA, ")
        strSQL.Append("TC.DESCRIPCION, ")
        strSQL.Append("MC.DESCRIPCION AS MODALIDADCOMPRA ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON PC.IDTIPOCOMPRAEJECUTAR = TC.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_MODALIDADESCOMPRA MC ")
        strSQL.Append("ON TC.IDMODALIDADCOMPRA = MC.IDMODALIDADCOMPRA ")
        strSQL.Append("WHERE ")
        strSQL.Append("(PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")
        strSQL.Append("AND (PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(1).Value = IDPROCESOCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene la información de una modalidad de compra especifica.
    ''' </summary>
    ''' <param name="IDMODALIDADCOMPRA">Identificador de la modalidad de compra.</param>
    ''' <returns>Dataset con la información de la modalidad.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_MODALIDADESCOMPRA</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  Creado
    ''' </history> 
    Public Function ObtenerModalidadPorID(ByVal IDMODALIDADCOMPRA As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDMODALIDADCOMPRA = @IDMODALIDADCOMPRA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.Int)
        args(0).Value = IDMODALIDADCOMPRA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

End Class
