Partial Public Class cENTREGABASES

#Region " Métodos Agregados "

    Public Function ObtenerDataSetPorIDwPROVEEDOR(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorIDwPROVEEDOR(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPROVEEDOR(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPROVEEDOR(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function GeneraDetalleDiscoProveedorR(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.GeneraSolDetalleDiscoProveedor(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function GeneraSolDiscoProveedorR(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.GeneraSolDiscoProveedor(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function GeneraProvDiscoProveedor(ByVal IDPROVEEDOR As Int64) As DataSet
        Try
            Return mDb.GeneraProvDiscoProveedor(IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetOrden(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetOrden(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerOrdenRecibeOferta(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Try
            Return mDb.ObtenerOrdenRecibeOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorIDwPROVEEDORRpt(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorIDwPROVEEDORRpt(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarENTREGABASES2(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Try
            Return mDb.Eliminar2(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetRptLG(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetRptLG(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
