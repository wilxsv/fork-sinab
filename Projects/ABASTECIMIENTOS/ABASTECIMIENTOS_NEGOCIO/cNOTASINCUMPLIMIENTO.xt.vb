Partial Public Class cNOTASINCUMPLIMIENTO

#Region "  Metodos Agregados  "

    ''' <summary>
    ''' Validar existencia de nota
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPROCESO"></param> identificdor de proceso de compra
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarExistenciaNota(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean
        Try
            Return mDb.ValidarExistenciaNota(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Dataset con la informacion de la documentacion faltante por el ofertante
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPROCESO"></param> identificador de proceso
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetDocumentacionFaltanteOfertante(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, Optional ByVal IDPROVEEDOR As Int32 = 0) As DataSet
        Try
            Return mDb.DataSetRptDocumentacionFaltanteOfertante(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    '''   dataset con la informacion de la documentacion faltante de los renglones ofertados por el proveedor
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDPROCESO"></param> identificador del proceso de compra
    ''' <param name="IDPROVEEDOR"></param> identificador del proveedor
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetDocumentacionFaltanteRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESO As Int32, Optional ByVal IDPROVEEDOR As Int32 = 0, Optional ByVal IDGRUPOREQTEC As Integer = 0) As DataSet
        Try
            Return mDb.DataSetRptDocumentacionFaltanteRenglon(IDESTABLECIMIENTO, IDPROCESO, IDPROVEEDOR, IDGRUPOREQTEC)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' validar existencia de numero de oficio
    ''' </summary>
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <param name="NUMEROOFICIO"></param> numero de oficio
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarNumeroOficio(ByVal IDPROVEEDOR As Int32, ByVal NUMEROOFICIO As String, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Try
            Return mDb.ValidarNumeroOficio(IDPROVEEDOR, NUMEROOFICIO, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtener fecha de examen preliminar
    ''' </summary>
    ''' <param name="IDPROCESO"></param> identificador de proceso
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' fecha de examen preliminar
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerFechaExamenPreliminar(ByVal IDPROCESO As Int32, ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROVEEDOR As Int64) As Date
        Try
            Return mDb.ObtenerFechaExamenPreliminar(IDPROCESO, IDESTABLECIMIENTO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptDocumentacionFaltante(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, Optional ByVal IDPROVEEDOR As Int32 = 0) As DataSet
        Try
            Return mDb.RptDocumentacionFaltante(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
