Public Class cDETALLEINVENTARIOINICIAL
    Inherits controladorBase

#Region "Metodos Generador"

#Region "Privadas"
    Private mDb As New dbDETALLEINVENTARIOINICIAL
    Private mEntidad As New DETALLEINVENTARIOINICIAL
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As listaDETALLEINVENTARIOINICIAL
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDETALLEINVENTARIOINICIAL(ByRef aEntidad As DETALLEINVENTARIOINICIAL) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDETALLEINVENTARIOINICIAL(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDLOTE As Int64) As DETALLEINVENTARIOINICIAL
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDINVENTARIO = IDINVENTARIO
            mEntidad.IDLOTE = IDLOTE
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarDETALLEINVENTARIOINICIAL(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDLOTE As Int64) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDINVENTARIO = IDINVENTARIO
            mEntidad.IDLOTE = IDLOTE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarDETALLEINVENTARIOINICIAL(ByVal aEntidad As DETALLEINVENTARIOINICIAL) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDINVENTARIO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDALMACEN, IDINVENTARIO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
