Partial Public Class cPRODUCTOSPROGRAMAS

#Region " Métodos Agregados "

    Public Function ObtenerDataSetListaProductosProgramas() As DataSet
        Try
            Return mDb.ObtenerDataSetListaProductosProgramas()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BuscarProductosProgramas(ByVal IDPRODUCTO As Int32, ByVal IDPROGRAMA As Int32) As Boolean
        Try
            Return mDb.BuscarProductosProgramas(IDPRODUCTO, IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarConSqlException(ByVal IDPRODUCTO As Int32, ByVal IDPROGRAMA As Int32) As Integer
        Try
            mEntidad.IDPRODUCTO = IDPRODUCTO
            mEntidad.IDPROGRAMA = IDPROGRAMA
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la lista de programas al que pertenece un producto.
    ''' </summary>
    ''' <returns>Dataset con la lista de programas.</returns>
    ''' <remarks>
    ''' Lista de tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' <history>
    '''   [AUTOR: José Alberto Chávez Loarca 10/02/07  Creado]
    ''' </history>
    ''' </remarks>
    Public Function ObtenerProgramasPorProducto(ByVal IDPRODUCTO As Int64) As DataSet
        Try
            Return mDb.ObtenerProgramasPorProducto(IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProductoxPrograma(ByVal IDPROGRAMA As Int64) As DataSet
        Try
            Return mDb.ObtenerProductoxPrograma(IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
