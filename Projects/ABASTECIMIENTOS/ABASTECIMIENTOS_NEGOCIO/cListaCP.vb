Public Class cListaCP
    Inherits controladorBase
    Private mDb As New dbListaCP()
    Private mListaCP As New ListaCP

    Public Function ObtenerListas() As DataSet
        Try
            Return mDb.ObtenerListas()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function ObtenerSuministros() As DataSet
        Try
            Return mDb.ObtenerSuministros()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarLista(ByVal aLista As ListaCP) As Integer
        Try
            Return mDb.Actualizar(aLista)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function EliminarLista(ByVal IDLISTA As Int32, ByVal IDSUMINISTRO As Integer) As Integer
        Try
            mListaCP.IDLISTA = IDLISTA
            mListaCP.IDSUMINISTRO = IDSUMINISTRO
            Return mDb.Eliminar(mListaCP)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerDataSetPorId2(ByVal IDLISTA As Int32, ByVal IDSUMINISTRO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDLISTA, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerID2(ByVal IDSUMINISTRO As Integer) As Integer
        Try
            Return mDb.ObtenerID2(IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try


    End Function

End Class
