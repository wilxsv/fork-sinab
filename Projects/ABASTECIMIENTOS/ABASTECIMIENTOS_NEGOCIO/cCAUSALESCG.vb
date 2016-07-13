
Public Class cCAUSALESCG
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbCAUSALESCG()
    Private mCAUSALESCG As New CAUSALESCG
#End Region

    Public Function ObtenerPROVEEDORES(ByRef aPROVEEDORES As PROVEEDORESCG) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aPROVEEDORES)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function


    Public Function EliminarCAUSALES(ByVal IDCAUSAL As Int32, ByVal IDTIPOGARANTIA As Integer) As Integer
        Try
            mCAUSALESCG.IDCAUSAL = IDCAUSAL
            mCAUSALESCG.IDTIPOGARANTIA = IDTIPOGARANTIA
            Return mDb.Eliminar(mCAUSALESCG)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCAUSALES(ByVal aCAUSALES As CAUSALESCG) As Integer
        Try
            Return mDb.Actualizar(aCAUSALES)
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
    Public Function ObtenerTiposGarantias() As DataSet
        Try
            Return mDb.ObtenerTiposGarantias()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetPorId2(ByVal IDCAUSAL As Int32, ByVal IDTIPOGARANTIA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDCAUSAL, IDTIPOGARANTIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetPorID3(ByVal idtipogarantia As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID3(idtipogarantia)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerID2(ByVal IDTIPOGARANTIA As Integer) As Integer
        Try
            Return mDb.ObtenerID2(IDTIPOGARANTIA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try


    End Function
    Public Function ObtenerCausales() As DataSet
        Try
            Return mDb.ObtenerCausales()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
#End Region

End Class
