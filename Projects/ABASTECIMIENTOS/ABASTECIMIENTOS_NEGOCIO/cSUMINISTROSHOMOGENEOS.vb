Public Class cSUMINISTROSHOMOGENEOS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbSUMINISTROSHOMOGENEOS()
    Private mEntidad As New SUMINISTROSHOMOGENEOS
#End Region

    Public Function ObtenerLista(ByVal IDSUMINISTRO As Int32, ByVal IDSUMINISTROHOMOGENEO As Int32) As listaSUMINISTROSHOMOGENEOS
        Try
            Return mDb.ObtenerListaPorID(IDSUMINISTRO, IDSUMINISTROHOMOGENEO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerSUMINISTROSHOMOGENEOS(ByRef aEntidad As SUMINISTROSHOMOGENEOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerSUMINISTROSHOMOGENEOS(ByVal IDSUMINISTRO As Int32, ByVal IDSUMINISTROHOMOGENEO As Int32) As SUMINISTROSHOMOGENEOS
        Try
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            mEntidad.IDSUMINISTROHOMOGENEO = IDSUMINISTROHOMOGENEO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarSUMINISTROSHOMOGENEOS(ByVal IDSUMINISTRO As Int32, ByVal IDSUMINISTROHOMOGENEO As Int32) As Integer
        Try
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            mEntidad.IDSUMINISTROHOMOGENEO = IDSUMINISTROHOMOGENEO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarSUMINISTROSHOMOGENEOS(ByVal aEntidad As SUMINISTROSHOMOGENEOS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarSUMINISTROSHOMOGENEOS(ByVal aEntidad As SUMINISTROSHOMOGENEOS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDSUMINISTRO As Int32, ByVal IDSUMINISTROHOMOGENEO As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDSUMINISTRO, IDSUMINISTROHOMOGENEO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDSUMINISTRO As Int32, ByVal IDSUMINISTROHOMOGENEO As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDSUMINISTRO, IDSUMINISTROHOMOGENEO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

#Region " Métodos agregados"

    Public Function ObtenerSuministrosHomogeneos() As DataSet
        Try
            Return mDb.ObtenerSuministrosHomogeneos()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
