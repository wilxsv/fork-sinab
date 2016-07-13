
Public Class cMODALIDADCOMPRACG
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbMODALIDADCOMPRACG()
    Private mMODALIDADCOMPRA As New MODALIDADCOMPRACG
#End Region

    Public Function ObtenerMODALIDADCOMPRA(ByRef aMODALIDADCOMPRA As MODALIDADCOMPRACG) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aMODALIDADCOMPRA)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerMODALIDADCOMPRA(ByVal IDMODALIDADCOMPRA As Int32) As MODALIDADCOMPRACG
        Try
            mMODALIDADCOMPRA.IDMODALIDAD = IDMODALIDADCOMPRA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mMODALIDADCOMPRA)
            If liRet = 1 Then Return mMODALIDADCOMPRA
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarMODALIDADCOMPRA(ByVal IDMODALIDADCOMPRA As Int32) As Integer
        Try
            mMODALIDADCOMPRA.IDMODALIDAD = IDMODALIDADCOMPRA
            Return mDb.Eliminar(mMODALIDADCOMPRA)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarMODALIDADCOMPRA(ByVal aMODALIDADCOMPRA As MODALIDADCOMPRACG) As Integer
        Try
            Return mDb.Actualizar(aMODALIDADCOMPRA)
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
