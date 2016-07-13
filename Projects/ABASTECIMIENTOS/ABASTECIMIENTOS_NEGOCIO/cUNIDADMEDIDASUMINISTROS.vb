''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cUNIDADMEDIDASUMINISTROS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_CAT_UNIDADMEDIDASUMINISTROS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	14/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cUNIDADMEDIDASUMINISTROS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbUNIDADMEDIDASUMINISTROS()
    Private mEntidad As New UNIDADMEDIDASUMINISTROS
#End Region

    Public Function ObtenerLista(ByVal IDSUMINISTRO As Int32, ByVal IDUNIDADMEDIDA As Int32) As listaUNIDADMEDIDASUMINISTROS
        Try
            Return mDb.ObtenerListaPorID(IDSUMINISTRO, IDUNIDADMEDIDA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerUNIDADMEDIDASUMINISTROS(ByRef aEntidad As UNIDADMEDIDASUMINISTROS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerUNIDADMEDIDASUMINISTROS(ByVal IDSUMINISTRO As Int32, ByVal IDUNIDADMEDIDA As Int32) As UNIDADMEDIDASUMINISTROS
        Try
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            mEntidad.IDUNIDADMEDIDA = IDUNIDADMEDIDA
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarUNIDADMEDIDASUMINISTROS(ByVal IDSUMINISTRO As Int32, ByVal IDUNIDADMEDIDA As Int32) As Integer
        Try
            mEntidad.IDSUMINISTRO = IDSUMINISTRO
            mEntidad.IDUNIDADMEDIDA = IDUNIDADMEDIDA
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarUNIDADMEDIDASUMINISTROS(ByVal aEntidad As UNIDADMEDIDASUMINISTROS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarUNIDADMEDIDASUMINISTROS(ByVal aEntidad As UNIDADMEDIDASUMINISTROS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDSUMINISTRO As Int32, ByVal IDUNIDADMEDIDA As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDSUMINISTRO, IDUNIDADMEDIDA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDSUMINISTRO As Int32, ByVal IDUNIDADMEDIDA As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDSUMINISTRO, IDUNIDADMEDIDA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
