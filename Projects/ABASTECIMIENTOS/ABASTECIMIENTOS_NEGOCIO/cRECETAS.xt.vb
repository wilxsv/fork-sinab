Partial Public Class cRECETAS

#Region " Metodos Agregados "

    ''' <summary>
    ''' En esta función para dataset de recetas SIM por producto
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimiento
    ''' <param name="IDPRODUCTO"></param> identificador del producto
    ''' <param name="FECHAINICIO"></param> fecha de inicio
    ''' <param name="FECHAFIN"></param> fecha de fin
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DataSetRecetaXproducto(ByVal idEstablecimiento As Int32, ByVal idProducto As Int32, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataSet
        Return mDb.DataSetRecetaXproducto(idEstablecimiento, idProducto, FechaInicio, FechaFin)
    End Function

    ''' <summary>
    ''' En esta función para dataset de recetas SIM por servicio hospitalario
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimento
    ''' <param name="IDSERVICIO"></param> identificadro de servicio 
    ''' <param name="FECHAINICIO"></param> fecha de inicio
    ''' <param name="FECHAFIN"></param> fecha de fin
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DDataSetRecetaXServicioHosp(ByVal idEstablecimiento As Int32, ByVal idServicio As Int32, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataSet
        Return mDb.DataSetRecetaXServicioHosp(idEstablecimiento, idServicio, FechaInicio, FechaFin)
    End Function

    ''' <summary>
    ''' En esta función para dataset de recetas SIM
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DDataSetImportacionSIM(ByVal idEstablecimiento As Int32) As DataSet
        Return mDb.DataSetImportacionSIM(idEstablecimiento)
    End Function

    ''' <summary>
    ''' Data set de servicios hospitalarios SIM
    ''' </summary>
    ''' <param name="idEstablecimiento"></param> identificadro de establecimiento
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DDataSetServiciosSIM(ByVal idEstablecimiento As Int32) As DataSet
        Return mDb.DataSetServiciosSIM(idEstablecimiento)
    End Function

    ''' <summary>
    ''' En esta función para dataset de recetas SIM
    ''' </summary>
    ''' <param name="idEstablecimiento"></param> identificador establecimientos
    ''' <param name="idCarga"></param> identificador de carga
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>

    Public Function DDataSetRecetasSIM(ByVal idEstablecimiento As Int32, ByVal idCarga As Int32) As DataSet

        Return mDb.DataSetRecetasSIM(idEstablecimiento, idCarga)
    End Function

    ''' <summary>
    ''' Dataset detalle de reseta SIM
    ''' </summary>
    ''' <param name="idEstablecimiento"></param> identificador de establecimiento
    ''' <param name="idCarga"></param>identificador de carga
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DDataSetDetalleRecetasSIM(ByVal idEstablecimiento As Int32, ByVal idCarga As Int32) As DataSet
        Return mDb.DataSetDetalleRecetasSIM(idEstablecimiento, idCarga)
    End Function

    ''' <summary>
    ''' Agregar receta
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo RECETAS
    ''' <returns>
    ''' numero de registros afectados con la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function AgregarRECETAS(ByVal aEntidad As RECETAS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Calcula cantidad de resetas por establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' cantidad de recetas por establecimiento
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerCantidadReceta(ByVal idestablecimiento As Int32) As Integer
        Return mDb.CantidadRecetas(idestablecimiento)
    End Function

    ''' <summary>
    ''' Calcula cantidad de productos recetados en receta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' cantidad de roductos por receta
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ObtenerCantidadDetalleReceta(ByVal idestablecimiento As Int32) As Integer
        Return mDb.CantidadDetalleRecetas(idestablecimiento)
    End Function

    ''' <summary>
    ''' dataset con la informacion del detalle de la receta
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DDataSetDetalleConsumo(ByVal idEstablecimiento As Int32) As DataSet
        Return mDb.DataDetalleConsumo(idEstablecimiento)
    End Function

#End Region

End Class
