Public Class cESPECIFICOSGASTO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbESPECIFICOSGASTO
    Private mEntidad As New ESPECIFICOSGASTO
#End Region

    Public Function ObtenerLista() As listaESPECIFICOSGASTO
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerESPECIFICOGASTO(ByRef aEntidad As ESPECIFICOSGASTO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerESPECIFICOGASTO(ByVal IDESPECIFICOGASTO As Int16) As ESPECIFICOSGASTO
        Try
            mEntidad.IDESPECIFICOGASTO = IDESPECIFICOGASTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarESPECIFICOGASTO(ByVal IDESPECIFICOGASTO As Int16) As Integer
        Try
            mEntidad.IDESPECIFICOGASTO = IDESPECIFICOGASTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarESPECIFICOGASTO(ByVal aEntidad As ESPECIFICOSGASTO) As Integer
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

    Public Function ObtenerDataSetPorId(ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function Recuperar(ByVal lEntidad As entidadBase) As Integer
        Try
            Return mDb.Recuperar(lEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function BuscarCodigo(ByVal CODIGO As String, ByVal IDESPECIFICOGASTO As Int16) As Int16
        Try
            Return mDb.BuscarCodigo(CODIGO, IDESPECIFICOGASTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarEspecificos() As DataSet
        Try
            Return mDb.RecuperarEspecificos()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
