Partial Public Class cANALISTAPROVEEDORES

#Region " Metodos Agregados "

    Public Function ObtenerProveedoresNoAsignados(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerProveedoresNoAsignados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProveedoresAsignados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDANALISTA As Integer) As DataSet
        Try
            Return mDb.ObtenerProveedoresAsignados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDANALISTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProveedoresAsignadosPorProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDANALISTA As Integer) As Integer
        Try
            Return mDb.ObtenerProveedoresAsignadosPorProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDANALISTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try
    End Function

#End Region

End Class
