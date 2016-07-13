
Public Class cTIPOSDOCUMENTOSCG
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbTIPOSDOCUMENTOSCG()
    Private mTIPOsDOCUMENTOs As New TIPOSDOCUMENTOCG
#End Region

    Public Function ObtenerTIPOsDOCUMENTOs(ByRef aTIPOsDOCUMENTOs As TIPOSDOCUMENTOCG) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aTIPOsDOCUMENTOs)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerTIPOsDOCUMENTOs(ByVal IDTIPODOCUMENTO As Int32) As TIPOSDOCUMENTOCG
        Try
            mTIPOsDOCUMENTOs.IDTIPODOCUMENTO = IDTIPODOCUMENTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mTIPOsDOCUMENTOs)
            If liRet = 1 Then Return mTIPOsDOCUMENTOs
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarTIPOsDOCUMENTOs(ByVal IDTIPODOCUMENTO As Int32) As Integer
        Try
            mTIPOsDOCUMENTOs.IDTIPODOCUMENTO = IDTIPODOCUMENTO
            Return mDb.Eliminar(mTIPOsDOCUMENTOs)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarTIPOsDOCUMENTOs(ByVal aTIPOsDOCUMENTOs As TIPOSDOCUMENTOCG) As Integer
        Try
            Return mDb.Actualizar(aTIPOsDOCUMENTOs)
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
    Public Function ObtenerDataSetPorId2(ByVal IDENTIDAD As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDENTIDAD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerID2() As Integer
        Try
            Return mDb.ObtenerID2()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
#End Region

End Class
