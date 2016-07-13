Partial Public Class cENTREGAPROCESOCOMPRA

#Region "  Metodos Agregados  "

    Public Function AgregarEntregasProcesoCompra(ByVal ARR_SOLICITUD As listaSOLICITUDES, ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Try
            Return mDb.AgregarEntregasProcesoCompra(ARR_SOLICITUD, IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ValidarIDENTREGA(ByVal BIDPROCESOCOMPRA As Int64, ByVal BIDESTABLECIMIENTO As Int32, ByVal BIDENTREGA As Int16) As Boolean
        Try
            Return mDb.ValidarIDENTREGA(BIDPROCESOCOMPRA, BIDESTABLECIMIENTO, BIDENTREGA)
        Catch ex As Exception

        End Try
    End Function

    Public Function AgregarENTREGAPROCESOCOMPRA(ByVal aEntidad As ENTREGAPROCESOCOMPRA) As Integer
        '
        'Try
        Return mDb.Agregar(aEntidad)
        'Catch ex As Exception
        'ExceptionManager.Publish(ex)
        'Return -1
        'End Try
    End Function
    Public Function AgregarEntregasProcesoCompra2(ByVal ARR_SOLICITUD As listaSOLICITUDES, ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64) As Integer
        Try
            Return mDb.AgregarEntregasProcesoCompra2(ARR_SOLICITUD, IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
#End Region

End Class
