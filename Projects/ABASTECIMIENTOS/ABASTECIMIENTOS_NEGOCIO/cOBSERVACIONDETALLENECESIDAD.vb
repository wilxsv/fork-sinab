''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cOBSERVACIONDETALLENECESIDAD
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla OBSERVACIONDETALLENECESIDAD
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cOBSERVACIONDETALLENECESIDAD
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbOBSERVACIONDETALLENECESIDAD()
    Private mEntidad As New OBSERVACIONDETALLENECESIDAD
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As listaOBSERVACIONDETALLENECESIDAD
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerOBSERVACIONDETALLENECESIDAD(ByRef aEntidad As OBSERVACIONDETALLENECESIDAD) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerOBSERVACIONDETALLENECESIDAD(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64, ByVal IDOBSERVACION As Int64) As OBSERVACIONDETALLENECESIDAD
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDNECESIDAD = IDNECESIDAD
            mEntidad.IDPRODUCTO = IDPRODUCTO
            mEntidad.IDOBSERVACION = IDOBSERVACION
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarOBSERVACIONDETALLENECESIDAD(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64, ByVal IDOBSERVACION As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDNECESIDAD = IDNECESIDAD
            mEntidad.IDPRODUCTO = IDPRODUCTO
            mEntidad.IDOBSERVACION = IDOBSERVACION
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarOBSERVACIONDETALLENECESIDAD(ByVal aEntidad As OBSERVACIONDETALLENECESIDAD) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
