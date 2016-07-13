Partial Public Class cESTABLECIMIENTOS

#Region "metodos adicionales"

    Public Function ObtenerListaOrden(ByVal Tipo As Integer) As listaESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaOrden(Tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerSIBASISporZona(ByVal idzona As Integer) As listaESTABLECIMIENTOS
        Try
            Return mDb.ObtenerSIBASISporZona(idzona)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function FiltrarEstabParaConsolidado() As DataSet
        Try
            Return mDb.FiltrarEstabParaConsolidado()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerUbicacionEstablecimiento(ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerUbicacionEstablecimiento(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ' Autor: Yessenia Henriquez
    '-------------------------------------------------------------------------------------------------------------------------
    ' En esta función nos dice si el establecimiento es una region
    ' fecha 20/10/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function EsRegionElEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Try
            Return mDb.EsRegionElEstablecimiento(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenetEstablecimientosXSibasi(ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.FiltrarEstablecimientosPorSibasi(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ' Autor: Yessenia Henriquez
    '-------------------------------------------------------------------------------------------------------------------------
    ' En esta función nos dice si el establecimiento es especial
    ' fecha 20/10/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function EsEspecialElEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Try
            Return mDb.EsEspecialElEstablecimiento(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function FiltrosEstablecimientosETZ(Optional ByVal IDZONA As Int32 = 0) As DataSet
        Try
            Return mDb.FiltrosEstablecimientosZonaETZ(IDZONA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerdsEstablecimiento() As DataSet
        Try
            Return mDb.ObtenerdsEstablecimiento()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarEstablecConSqlException(ByVal IDESTABLECIMIENTO As Int32) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerLista2(ByVal IDZONA As Integer) As listaESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaPorID2(IDZONA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetCodigoEstablecimiento() As DataSet
        Try
            Return mDb.ObtenerDataSetCodigoEstablecimiento()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNomEstablecimiento(ByVal idestablecimiento) As String
        Try
            Return mDb.ObtenerNomEstablecimiento(idestablecimiento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ExisteCodigo(ByVal CODIGO As String) As Boolean
        Try
            Return mDb.ExisteCodigo(CODIGO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerIDEstablecimiento(ByVal CODIGo As String) As Integer
        Try
            Return mDb.ObtenerIDEstablecimiento(CODIGo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function InsertarDetalleDisco(ByVal aEntidad As DetalleCompraDisco) As Integer
        Try
            Return mDb.InsertarDetalleDisco(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function InsertarDetalleDisco2(ByVal aEntidad As DetalleCompraDisco) As Integer
        Try
            Return mDb.InsertarDetalleDisco2(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BorrarDetalleDisco() As Integer
        Try
            Return mDb.BorrarDetalleDisco()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function BorrarDetalleDisco2() As Integer
        Try
            Return mDb.BorrarDetalleDisco2()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CrearDetalleSolicitudDiscoURMIM(ByVal IDESTABLECIMIENTOSOLICITUD As Int64, ByVal IDSOLICITUD As Integer, ByVal usuario As String, ByVal idgrupo As Integer, ByVal idespecificacion As Integer) As Integer

        Return mDb.CrearDetalleSolicitudDiscoURMIM(IDESTABLECIMIENTOSOLICITUD, IDSOLICITUD, usuario, idgrupo, idespecificacion)

    End Function

    Public Function CrearDetalleSolicitudDiscoURMIM2(ByVal IDESTABLECIMIENTOSOLICITUD As Int64, ByVal IDSOLICITUD As Integer, ByVal usuario As String) As Integer
        Try
            Return mDb.CrearDetalleSolicitudDiscoURMIM2(IDESTABLECIMIENTOSOLICITUD, IDSOLICITUD, usuario)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CrearDetalleSolicitudDiscoURMIM_CJ(ByVal IDESTABLECIMIENTOSOLICITUD As Int64, ByVal IDSOLICITUD As Integer, ByVal IDESTABLECIMIENTO As Int64, ByVal IDALMACEN As Integer, ByVal usuario As String) As Integer
        Try
            Return mDb.CrearDetalleSolicitudDiscoURMIM_CJ(IDESTABLECIMIENTOSOLICITUD, IDSOLICITUD, IDESTABLECIMIENTO, IDALMACEN, usuario)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function CrearDetalleSolicitudDiscoURMIM2_CJ(ByVal IDESTABLECIMIENTOSOLICITUD As Int64, ByVal IDSOLICITUD As Integer, ByVal usuario As String) As Integer
        Try
            Return mDb.CrearDetalleSolicitudDiscoURMIM2_CJ(IDESTABLECIMIENTOSOLICITUD, IDSOLICITUD, usuario)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarEstablecimientosPorZonaAlmancen(ByVal IDALMACEN As Integer, Optional ByVal VERTODOS As Integer = 0) As DataSet
        Try
            Return mDb.RecuperarEstablecimientosPorZonaAlmancen(IDALMACEN, VERTODOS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarLugaresDestinoHospitales(ByVal IDALMACEN As Integer, Optional ByVal VERTODOS As Integer = 0) As DataSet
        Try
            Return mDb.RecuperarLugaresDestinoPorHospital(IDALMACEN, VERTODOS)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarEstablecimientosCargaDiscoURMIM() As DataSet
        Try
            Return mDb.RecuperarEstablecimientosCargaDiscoURMIM()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarEstablecimientosCargaDiscoURMIM2() As DataSet
        Try
            Return mDb.RecuperarEstablecimientosCargaDiscoURMIM2()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarEstablecimientos() As DataSet
        Try
            Return mDb.RecuperarEstablecimientos()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerHospitalesRegiones() As DataSet

        Try
            Return mDb.obtenerHospitalesRegiones
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerEstablecimientosProgramacion(ByVal IDPROGRAMACION As Integer) As DataSet

        Try
            Return mDb.obtenerEstablecimientosProgramacion(IDPROGRAMACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerHospitalesRegionesParaiso(ByVal IDPROGRAMACION) As DataSet

        Try
            Return mDb.obtenerHospitalesRegionesParaiso(IDPROGRAMACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

#End Region

End Class
