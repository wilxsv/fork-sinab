''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cDETALLENOTAINCUMPLIMIENTOCONTRATO
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_UACI_DETALLENOTAINCUMPLIMIENTOCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	18/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cDETALLENOTAINCUMPLIMIENTOCONTRATO
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbDETALLENOTAINCUMPLIMIENTOCONTRATO()
    Private mEntidad As New DETALLENOTAINCUMPLIMIENTOCONTRATO
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDNOTA As Int32) As listaDETALLENOTAINCUMPLIMIENTOCONTRATO
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDETALLENOTAINCUMPLIMIENTOCONTRATO(ByRef aEntidad As DETALLENOTAINCUMPLIMIENTOCONTRATO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDETALLENOTAINCUMPLIMIENTOCONTRATO(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDNOTA As Int32, ByVal IDDETALLENOTAINCUMPLIMIENTOCONTRATO As Int64) As DETALLENOTAINCUMPLIMIENTOCONTRATO
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDNOTA = IDNOTA
            mEntidad.IDDETALLENOTAINCUMPLIMIENTOCONTRATO = IDDETALLENOTAINCUMPLIMIENTOCONTRATO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarDETALLENOTAINCUMPLIMIENTOCONTRATO(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDNOTA As Int32, ByVal IDDETALLENOTAINCUMPLIMIENTOCONTRATO As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDCONTRATO = IDCONTRATO
            mEntidad.IDNOTA = IDNOTA
            mEntidad.IDDETALLENOTAINCUMPLIMIENTOCONTRATO = IDDETALLENOTAINCUMPLIMIENTOCONTRATO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarDETALLENOTAINCUMPLIMIENTOCONTRATO(ByVal aEntidad As DETALLENOTAINCUMPLIMIENTOCONTRATO) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDNOTA As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDNOTA As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
