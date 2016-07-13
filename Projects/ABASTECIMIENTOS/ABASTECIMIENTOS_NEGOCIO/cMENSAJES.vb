''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cMENSAJES
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla ALMACENES
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[GenApp]	18/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cMENSAJES
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbMENSAJES()
    Private mEntidad As New MENSAJES
#End Region

    Public Function ObtenerLista() As listaMENSAJES
        Try
            Return mDb.ObtenerListaPorID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMENSAJES(ByRef aEntidad As MENSAJES) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerMENSAJES(ByVal IDMENSAJE As Int32) As MENSAJES
        Try
            mEntidad.IDMENSAJE = IDMENSAJE
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarMENSAJE(ByVal aEntidad As MENSAJES) As Integer
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

#End Region

End Class
