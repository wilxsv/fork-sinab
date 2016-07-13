''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cMOTIVOSNOACEPTACIONINFORME
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_LAB_MOTIVOSNOACEPTACIONINFORME
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	04/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cMOTIVOSNOACEPTACIONINFORME
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbMOTIVOSNOACEPTACIONINFORME()
    Private mEntidad As New MOTIVOSNOACEPTACIONINFORME
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDINFORME As Int32, ByVal IDMOTIVONOACEPTACION As Byte) As listaMOTIVOSNOACEPTACIONINFORME
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDINFORME, IDMOTIVONOACEPTACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMOTIVOSNOACEPTACIONINFORME(ByRef aEntidad As MOTIVOSNOACEPTACIONINFORME) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerMOTIVOSNOACEPTACIONINFORME(ByVal IDESTABLECIMIENTO As Int32, ByVal IDINFORME As Int32, ByVal IDMOTIVONOACEPTACION As Byte) As MOTIVOSNOACEPTACIONINFORME
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDINFORME = IDINFORME
            mEntidad.IDMOTIVONOACEPTACION = IDMOTIVONOACEPTACION
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarMOTIVOSNOACEPTACIONINFORME(ByVal IDESTABLECIMIENTO As Int32, ByVal IDINFORME As Int32, ByVal IDMOTIVONOACEPTACION As Byte) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDINFORME = IDINFORME
            mEntidad.IDMOTIVONOACEPTACION = IDMOTIVONOACEPTACION
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarMOTIVOSNOACEPTACIONINFORME(ByVal aEntidad As MOTIVOSNOACEPTACIONINFORME) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarMOTIVOSNOACEPTACIONINFORME(ByVal aEntidad As MOTIVOSNOACEPTACIONINFORME) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDINFORME As Int32, ByVal IDMOTIVONOACEPTACION As Byte) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDINFORME, IDMOTIVONOACEPTACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDINFORME As Int32, ByVal IDMOTIVONOACEPTACION As Byte, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDINFORME, IDMOTIVONOACEPTACION, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
