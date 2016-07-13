''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cPROGRAMADISTRIBUCION
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_UACI_PROGRAMADISTRIBUCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	29/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cPROGRAMADISTRIBUCION
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbPROGRAMADISTRIBUCION()
    Private mEntidad As New PROGRAMADISTRIBUCION
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64) As listaPROGRAMADISTRIBUCION
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDESTABLECIMIENTOSOLICITA, IDSOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerPROGRAMADISTRIBUCION(ByRef aEntidad As PROGRAMADISTRIBUCION) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerPROGRAMADISTRIBUCION(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64, ByVal RENGLON As Int32) As PROGRAMADISTRIBUCION
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            mEntidad.IDESTABLECIMIENTOSOLICITA = IDESTABLECIMIENTOSOLICITA
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.RENGLON = RENGLON
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarPROGRAMADISTRIBUCION(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64, ByVal RENGLON As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            mEntidad.IDESTABLECIMIENTOSOLICITA = IDESTABLECIMIENTOSOLICITA
            mEntidad.IDSOLICITUD = IDSOLICITUD
            mEntidad.RENGLON = RENGLON
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarPROGRAMADISTRIBUCION(ByVal aEntidad As PROGRAMADISTRIBUCION) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDESTABLECIMIENTOSOLICITA, IDSOLICITUD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDESTABLECIMIENTOSOLICITA, IDSOLICITUD, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
