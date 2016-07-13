
Public Class cENTIDADCG
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbEntidadCG()
    Private mEntidad As New ENTIDADFINANCIERA
#End Region

    Public Function ObtenerEntidad(ByRef aEntidad As ENTIDADFINANCIERA) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerEntidad(ByVal identidad As Int32) As ENTIDADFINANCIERA
        Try
            mEntidad.IDENTIDAD = identidad
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarEntidad(ByVal identidad As Int32) As Integer
        Try
            mEntidad.IDENTIDAD = identidad
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarENTIDAD(ByVal aEntidad As ENTIDADFINANCIERA) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
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
    Public Function ObtenerDataSetPorId2(ByVal IDENTIDAD As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDENTIDAD)
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
