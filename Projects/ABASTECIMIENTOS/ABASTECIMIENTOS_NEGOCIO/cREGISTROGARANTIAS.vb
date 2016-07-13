
Public Class cREGISTROGARANTIAS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbREGISTROGARANTIASCG
    Private mREGISTROGARANTIAS As New REGISTROGARANTIAS
#End Region

    Public Function ObtenerREGISTROGARANTIAS(ByRef aREGISTROGARANTIAS As REGISTROGARANTIAS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aREGISTROGARANTIAS)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerREGISTROGARANTIAS(ByVal IDREGISTROGARANTIAS As Int32) As REGISTROGARANTIAS
        Try
            mREGISTROGARANTIAS.IDGARANTIA = IDREGISTROGARANTIAS
            Dim liRet As Integer
            liRet = mDb.Recuperar(mREGISTROGARANTIAS)
            If liRet = 1 Then Return mREGISTROGARANTIAS
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarREGISTROGARANTIAS(ByVal IDREGISTROGARANTIAS As Int32, ByVal IDESTABLECIMIENTO As Integer) As Integer
        Try
            mREGISTROGARANTIAS.IDGARANTIA = IDREGISTROGARANTIAS
            mREGISTROGARANTIAS.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mDb.BorrarFechasGarantias(IDREGISTROGARANTIAS, IDESTABLECIMIENTO)
            Return mDb.Eliminar(mREGISTROGARANTIAS)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarREGISTROGARANTIAS(ByVal aREGISTROGARANTIAS As REGISTROGARANTIAS) As Integer
        Try
            Return mDb.Actualizar(aREGISTROGARANTIAS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId() As DataSet
        Try
            Return mDb.ObtenerDataSetPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerDataSetGarantias(ByVal idestablecimiento As Integer, ByVal idtipogarantia As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetGarantias(idestablecimiento, idtipogarantia)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIDGarantia(ByVal idestablecimiento As Integer, ByVal idtipogarantia As Integer) As Integer
        Try
            Return mDb.ObtenerIDGarantias(idestablecimiento, idtipogarantia)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function InsertarFechas(ByVal idgarantia As Integer, ByVal idestablecimiento As Integer, ByVal fechapresentacion As Date, ByVal fechaobservacion As Date) As Integer
        Try
            mDb.BorrarFechasGarantias(idgarantia, idestablecimiento)
            Return mDb.InsertarFechas(idgarantia, idestablecimiento, fechapresentacion, fechaobservacion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerFechas(ByVal idgarantia As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerFechas(idgarantia, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerGarantias() As DataSet
        Try
            Return mDb.ObtenerGarantias()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporte(ByVal fechaprox As DateTime, Optional ByVal idproveedor As Integer = 0, Optional ByVal nit As String = "", Optional ByVal eg As Integer = 0, Optional ByVal eeg As Integer = 0, Optional ByVal tipo As Integer = 0, Optional ByVal idmodalidad As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerReporte(fechaprox, idproveedor, nit, eg, eeg, tipo, idmodalidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerRegistroUnaGarantia(ByVal idgarantia As Integer, ByVal idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerRegistroUnaGarantia(idgarantia, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteUnaGarantia(ByVal idgarantia As Integer, ByVal idtg As Integer, ByVal idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerReporteUnaGarantia(idgarantia, idtg, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
