Partial Public Class cCRITERIOPROCESOCOMPRA

#Region "  Metodos Agregados  "

    Public Function ObtenerDataSetCriteriosProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDTIPOCRITERIO As Int16) As DataSet
        Try
            Return mDb.ObtenerDataSetCriteriosProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDTIPOCRITERIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetCriteriosPC(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDTIPOCRITERIO As Int16) As DataSet
        Try
            Return mDb.ObtenerDataSetCriteriosPC(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDTIPOCRITERIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetCriteriosFinancieroProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetCriteriosFinancieroProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EtiquetaCriterioTecnico(ByVal TABLA As String, ByVal CAMPO As String) As DataSet
        Try
            Return mDb.EtiquetaCriterioTecnico(TABLA, CAMPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetCriteriosProcesoCompraRC(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal TIPOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetCriteriosProcesoCompraRC(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, TIPOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BorrarCRITERIOPROCESOCOMPRA(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            Return mDb.Borrar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
