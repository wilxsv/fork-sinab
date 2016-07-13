Public Class cAspectoCP
    Inherits controladorBase
    Private mDb As New dbAspectoCP()
    Private mAspectoCP As New ASPECTOCP

    Public Function ObtenerAspectos() As DataSet
        Try
            Return mDb.ObtenerAspectos()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function ObtenerListas() As DataSet
        Try
            Return mDb.ObtenerListas()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarAspectos(ByVal aAspecto As ASPECTOCP) As Integer
        Try
            Return mDb.Actualizar(aAspecto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function EliminarLista(ByVal IDASPECTO As Int32, ByVal IDLISTA As Integer) As Integer
        Try
            mAspectoCP.IDASPECTO = IDASPECTO
            mAspectoCP.IDLISTA = IDLISTA
            Return mDb.Eliminar(mAspectoCP)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerDataSetPorId2(ByVal IDASPECTO As Int32, ByVal IDLISTA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDLISTA, IDASPECTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerID2(ByVal IDLISTA As Integer) As Integer
        Try
            Return mDb.ObtenerID2(IDLISTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try


    End Function

End Class
