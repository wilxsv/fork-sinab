Public Class cINVENTARIOINICIAL
    Inherits controladorBase

#Region "Metodos Generador"

#Region "Privadas"
    Private mDb As New dbINVENTARIOINICIAL
    Private mEntidad As New INVENTARIOINICIAL
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32) As listaINVENTARIOINICIAL
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerINVENTARIOINICIAL(ByRef aEntidad As INVENTARIOINICIAL) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerINVENTARIOINICIAL(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As INVENTARIOINICIAL
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDINVENTARIO = IDINVENTARIO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarINVENTARIOINICIAL(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDINVENTARIO = IDINVENTARIO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarINVENTARIOINICIAL(ByVal aEntidad As INVENTARIOINICIAL) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
