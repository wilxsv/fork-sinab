Partial Public Class cUNIDADMEDIDAS

#Region "  Metodos Agregados  "

    Public Function ObtenerDataSetIDUNIDADMEDIDA(ByVal unidadMedida As String) As Integer
        Try
            Return mDb.ObtenerDataSetIDUNIDADMEDIDA(unidadMedida)
        Catch ex As Exception
            'ExceptionManager.Publish(ex) 
            Return -1
        End Try
    End Function

#End Region

#Region "Metodos adicionales"

    'Validar NOMBRE CORTO
    Public Function ValidarDescripcion(ByVal DESCRIPCION As String, ByVal IDUNIDADMEDIDA As Int32) As Int16
        Try
            Return mDb.ValidarDescripcion(DESCRIPCION, IDUNIDADMEDIDA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Validar DESCRIPCION LARGA
    Public Function ValidarDescripcionlarga(ByVal DESCRIPCIONLARGA As String, ByVal IDUNIDADMEDIDA As Int32) As Int16
        Try
            Return mDb.ValidarDescripcionlarga(DESCRIPCIONLARGA, IDUNIDADMEDIDA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerLista2(ByVal IDSUMINISTRO As Integer) As listaUNIDADMEDIDAS
        Try
            Return mDb.ObtenerListaPorSuministro(IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
