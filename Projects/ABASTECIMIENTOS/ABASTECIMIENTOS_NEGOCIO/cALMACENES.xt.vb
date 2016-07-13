Partial Public Class cALMACENES

#Region " METODOS AGREGADOS "

    Public Function FiltroAlmacenPorId(ByVal BID As String) As DataSet
        Try
            Return mDb.FiltroAlmacenPorId(BID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarAlmacenesConSqlException(ByVal IDALMACEN As Int32) As Integer
        Try
            mEntidad.IDALMACEN = IDALMACEN
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerListaOrden(Optional ByVal Tipo As Integer = 0) As listaALMACENES
        Try
            Return mDb.ObtenerListaOrden(Tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerListaOrden2(Optional ByVal Tipo As Integer = 0) As listaALMACENES
        Try
            Return mDb.ObtenerListaOrden2(Tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerAlmacenesDSProcesoCompraContrato(ByVal idprocesocompra As Integer, ByVal idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerAlmacenesDSProcesoCompraContrato(idprocesocompra, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerAlmacenesDatasetPorPeriodo(ByVal fini As Date, ByVal ffin As Date, ByVal idestablecimiento As Integer) As DataSet
        Try
            Return mDb.ObtenerAlmacenesDatasetPorPeriodo(fini, ffin, idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverAlmacen(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Int64, ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.DevolverAlmacen(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarOrdenada() As DataSet
        Try
            Return mDb.RecuperarOrdenada()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverAlmacenPeriodo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer, ByVal dsP As DataSet) As DataSet
        Try
            Return mDb.DevolverAlmacenPeriodo(IDESTABLECIMIENTO, IDALMACEN, dsP)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetListaAlmacenes() As DataSet
        Try
            Return mDb.ObtenerDataSetListaAlmacenes()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerListaAlmacenes(ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerListaAlmacenes(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerSemana(ByVal fecha As DateTime) As Integer
        Try
            Return mDb.ObtenerSemana(fecha)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDatosSemana(ByVal IdSemana As Integer) As String
        Try
            Return mDb.ObtenerDatosSemana(IdSemana)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function EliminarProductosSinExistencia(ByVal Idalmacen As Integer, ByVal idsemana As Integer, ByVal idsuministro As Integer) As Integer
        Try
            Return mDb.EliminarProductosSinExistencia(Idalmacen, idsemana, idsuministro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AdicionarProductosSinExistencia(ByVal Idalmacen As Integer, ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal idproducto As Integer) As Integer
        Try
            Return mDb.AdicionarProductosSinExistencia(Idalmacen, idsemana, idsuministro, idproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProductosSinExistencia(ByVal Idalmacen As Integer, ByVal anio As Integer, ByVal idsuministro As Integer, ByVal idsemana As Integer) As Data.DataSet
        Try
            Return mDb.ObtenerProductosSinExistencia(Idalmacen, anio, idsuministro, idsemana)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarProductosSinExistencia(ByVal Idalmacen As Integer, ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal idproducto As Integer, ByVal ANIO As Integer, ByVal existenciafarmacia As Integer) As Integer
        Try
            Return mDb.ActualizarProductosSinExistencia(Idalmacen, idsemana, idsuministro, idproducto, ANIO, existenciafarmacia)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerSemanasaConsultar() As DataSet
        Try
            Return mDb.ObtenerSemanasAConsultar(mDb.ObtenerSemana(DateTime.Now))
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerSemanasaConsultar(ByVal anio As Integer) As DataSet
        Try
            Return mDb.ObtenerSemanasAConsultarAnteriores(anio)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerAnioAbastecimiento() As DataSet
        Try
            Return mDb.ObtenerAnioAbastecimiento()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNivelAbastecimiento(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal anio As Integer, Optional idprograma As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerNivelAbastecimiento(idsemana, idsuministro, anio, idprograma)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerNivelAbastecimientoPantalla(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal anio As Integer) As DataSet
        Try
            Return mDb.ObtenerNivelAbastecimientoPantalla(idsemana, idsuministro, anio)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'Public Function ObtenerNivelAbastecimientoPantalla(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal anio As Integer) As DataSet
    '    Try
    '        Return mDb.ObtenerNivelAbastecimientoPantalla(idsemana, idsuministro, anio)
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return Nothing
    '    End Try
    'End Function
    Public Function ObtenerNivelAbastecimientoProductos(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal idhospital As Integer) As DataSet
        Try
            Return mDb.ObtenerNivelAbastecimientoProductos(idsemana, idsuministro, DateTime.Now.Year, idhospital)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'scms
    Public Function ObtenerNivelAbastecimientoProductosMensual(ByVal Mes As String, ByVal idsuministro As Integer, ByVal anio As Integer, ByVal idhospital As Integer, Optional idprograma As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerNivelAbastecimientoProductosMensual(Mes, idsuministro, anio, idhospital, idprograma)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerNombre(ByVal idhospital As Integer) As String
        Try
            Return mDb.ObtenerNombre(idhospital)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerPromedioNacional(ByVal idsemana As Integer, ByVal idsuministro As Integer, ByVal anio As Integer) As Decimal
        Try
            Return mDb.ObtenerPromedioNacional(idsemana, idsuministro, anio)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class