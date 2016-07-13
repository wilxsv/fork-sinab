''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cCRITERIOSPLANTILLAS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla CRITERIOSPLANTILLAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cCRITERIOSPLANTILLAS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbCRITERIOSPLANTILLAS()
    Private mEntidad As New CRITERIOSPLANTILLAS
#End Region

    Public Function ObtenerLista(ByVal IDPLANTILLA As Int32, ByVal IDCRITERIOEVALUACION As Int16) As listaCRITERIOSPLANTILLAS
        Try
            Return mDb.ObtenerListaPorID(IDPLANTILLA, IDCRITERIOEVALUACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCRITERIOSPLANTILLAS(ByRef aEntidad As CRITERIOSPLANTILLAS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerCRITERIOSPLANTILLAS(ByVal IDPLANTILLA As Int32, ByVal IDCRITERIOEVALUACION As Int16) As CRITERIOSPLANTILLAS
        Try
            mEntidad.IDPLANTILLA = IDPLANTILLA
            mEntidad.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarCRITERIOSPLANTILLAS(ByVal IDPLANTILLA As Int32, ByVal IDCRITERIOEVALUACION As Int16) As Integer
        Try
            mEntidad.IDPLANTILLA = IDPLANTILLA
            mEntidad.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarCRITERIOSPLANTILLAS(ByVal aEntidad As CRITERIOSPLANTILLAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCRITERIOSPLANTILLAS(ByVal aEntidad As CRITERIOSPLANTILLAS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPLANTILLA As Int32, ByVal IDCRITERIOEVALUACION As Int16) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDPLANTILLA, IDCRITERIOEVALUACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDPLANTILLA As Int32, ByVal IDCRITERIOEVALUACION As Int16, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDPLANTILLA, IDCRITERIOEVALUACION, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
