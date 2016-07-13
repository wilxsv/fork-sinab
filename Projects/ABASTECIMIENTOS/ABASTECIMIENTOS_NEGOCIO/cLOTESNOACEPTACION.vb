''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cLOTESNOACEPTACION
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_ALM_LOTESNOACEPTACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cLOTESNOACEPTACION
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbLOTESNOACEPTACION()
    Private mEntidad As New LOTESNOACEPTACION
#End Region

    Public Function ObtenerLista(ByVal IDALMACEN As Int32) As listaLOTESNOACEPTACION
        Try
            Return mDb.ObtenerListaPorID(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerLOTESNOACEPTACION(ByRef aEntidad As LOTESNOACEPTACION) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerLOTESNOACEPTACION(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int64) As LOTESNOACEPTACION
        Try
            mEntidad.IDALMACEN = IDALMACEN
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

    Public Function EliminarLOTESNOACEPTACION(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int64) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            mEntidad.IDLOTE = IDLOTE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarLOTESNOACEPTACION(ByVal aEntidad As LOTESNOACEPTACION) As Integer
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
