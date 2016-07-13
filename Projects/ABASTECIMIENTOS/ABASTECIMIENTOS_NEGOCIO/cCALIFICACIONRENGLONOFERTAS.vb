''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cCALIFICACIONRENGLONOFERTAS
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla CALIFICACIONRENGLONOFERTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	07/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cCALIFICACIONRENGLONOFERTAS
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbCALIFICACIONRENGLONOFERTAS()
    Private mEntidad As New CALIFICACIONRENGLONOFERTAS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDCRITERIOEVALUACION As Int16, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As listaCALIFICACIONRENGLONOFERTAS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCRITERIOEVALUACION, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCALIFICACIONRENGLONOFERTAS(ByRef aEntidad As CALIFICACIONRENGLONOFERTAS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerCALIFICACIONRENGLONOFERTAS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDCRITERIOEVALUACION As Int16, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As CALIFICACIONRENGLONOFERTAS
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            mEntidad.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDDETALLE = IDDETALLE
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarCALIFICACIONRENGLONOFERTAS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDCRITERIOEVALUACION As Int16, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            mEntidad.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION
            mEntidad.IDPROVEEDOR = IDPROVEEDOR
            mEntidad.IDDETALLE = IDDETALLE
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarCALIFICACIONRENGLONOFERTAS(ByVal aEntidad As CALIFICACIONRENGLONOFERTAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCALIFICACIONRENGLONOFERTAS(ByVal aEntidad As CALIFICACIONRENGLONOFERTAS) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDCRITERIOEVALUACION As Int16, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCRITERIOEVALUACION, IDPROVEEDOR, IDDETALLE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDCRITERIOEVALUACION As Int16, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCRITERIOEVALUACION, IDPROVEEDOR, IDDETALLE, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
