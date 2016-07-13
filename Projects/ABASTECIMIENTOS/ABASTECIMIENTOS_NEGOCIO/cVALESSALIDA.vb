''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cVALESSALIDA
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_ALM_VALESSALIDA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	06/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cVALESSALIDA
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbVALESSALIDA()
    Private mEntidad As New VALESSALIDA
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32) As listaVALESSALIDA
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerVALESSALIDA(ByRef aEntidad As VALESSALIDA) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerVALESSALIDA(ByVal IDALMACEN As Int32, ByVal ANIO As Int16, ByVal IDVALE As Int32) As VALESSALIDA
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.ANIO = ANIO
            mEntidad.IDVALE = IDVALE
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarVALESSALIDA(ByVal IDALMACEN As Int32, ByVal ANIO As Int16, ByVal IDVALE As Int32) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.ANIO = ANIO
            mEntidad.IDVALE = IDVALE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarVALESSALIDA(ByVal aEntidad As VALESSALIDA) As Integer
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
