Partial Public Class cINFORMEMUESTRAS

#Region " Metodos Agregados "

    ''' <summary>
    ''' Obtiene los informes de muestras que cumplen con el criterio especificado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del informe.</param>
    ''' <param name="IDESTADO">Identificador del estado en el que se encuentra el informe.  Opcional.  Por defecto es cero y no se considera.</param>
    ''' <param name="IDTIPOINFORME">Identificador del tipo de informe (aceptación, rechazo, no inspección).  Opcional.  Por defecto es cero y no se considera.</param>
    ''' <param name="IDEMPLEADO">Identificador del empleado responsable (inspector o coordinador) del informe.  Opcional.  Por defecto es cero y no se considera.</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaInformes(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal IDESTADO As Integer = 0, Optional ByVal IDTIPOINFORME() As Byte = Nothing, Optional ByVal IDEMPLEADO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerListaInformes(IDESTABLECIMIENTO, IDESTADO, IDTIPOINFORME, IDEMPLEADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <param name="RENGLON"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Function ObtenerInformacionProveedores(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.ObtenerInformacionProveedor(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la información de un contrato dado, junto con la de los informes de muestras relacionados a los mismos.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ReporteProveedoresContratados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.ReporteProveedoresContratados(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la información de los lotes examinados por el laboratorio para un renglón especifico.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el renglón.</param>
    ''' <param name="RENGLON">Número del renglón seleccionado.</param>
    ''' <returns>Dataset con la información de los lotes.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  05/02/2007    Creado
    ''' </history> 
    Public Function ObtenerInformacionLotesRenglon(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.ObtenerInformacionLotesRenglon(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerInformacionLotesRecibo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORMECONTROLCALIDAD As Integer) As DataSet
        Try
            Return mDb.ObtenerInformacionLotesRecibo(IDESTABLECIMIENTO, IDINFORMECONTROLCALIDAD)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la información de los lotes examinados por el laboratorio para un renglón especifico,
    ''' mostrando unicamente aquellos lotes que han sido rechazados.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el renglón.</param>
    ''' <param name="RENGLON">Número del renglón seleccionado.</param>
    ''' <returns>Dataset con la información de los lotes.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  05/02/2007    Creado
    ''' </history> 
    Public Function ObtenerInformacionLoteRenglonRechazado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal LOTE As String) As DataSet
        Try
            Return mDb.ObtenerInformacionLoteRenglonRechazado(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, LOTE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la información de un informe de calidad para un renglón y lote especifico.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor al que pertenece el contrato.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato al que pertenece el renglón.</param>
    ''' <param name="RENGLON">Número del renglón seleccionado.</param>
    ''' <returns>Dataset con la información de los lotes.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  05/02/2007    Creado
    ''' </history> 
    Public Function ObtenerInformacionLote(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer, ByVal LOTE As String) As DataSet
        Try
            Return mDb.ObtenerInformacionLote(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, LOTE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve los datos del informe de muestras junto con los del contrato relacionado.
    ''' </summary>
    ''' <param name="aEntidad">Entidad INFORMEMUESTRAS.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerInformeMuestrasContrato(ByRef aEntidad As INFORMEMUESTRAS) As Integer
        Try
            Return mDb.RecuperarInformeMuestrasContrato(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerInformeMuestrasContrato2(ByRef aEntidad As INFORMEMUESTRAS) As Integer
        Try
            Return mDb.RecuperarInformeMuestrasContrato2(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Devuelve todos los datos del informe de muestras necesarios para el reporte.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function RptInformeMuestras(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As DataSet
        Try
            Return mDb.RptInformeMuestras(IDESTABLECIMIENTO, IDINFORME)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RptInformeMuestras2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As DataSet
        Try
            Return mDb.RptInformeMuestras2(IDESTABLECIMIENTO, IDINFORME)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Para un renglón dado, obtiene todos los lotes que se han inspeccionado, certificado y aceptado para su recepción.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del contrato.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerLotesCancelacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.ObtenerLotesCancelacion(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Verifica si el número de informe indicado ya ha sido utilizado.
    ''' </summary>
    ''' <param name="NUMEROINFORME">Número de informe a verificar.</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del informe.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function VerificarNumeroInforme(ByVal NUMEROINFORME As String, ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As Integer
        Try
            Return mDb.VerificarNumeroInforme(NUMEROINFORME, IDESTABLECIMIENTO, IDINFORME)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 1
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todas las modificativas del contrato asociado al informe de muestras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del informe.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>String.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerModificativas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As String
        Try
            Return mDb.ObtenerModificativas(IDESTABLECIMIENTO, IDINFORME)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Elimina los motivos de no aceptación (en caso de que los hubiera) y posteriormente elimina el informe de muestras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del informe.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarMotivosEInforme(ByVal IDESTABLECIMIENTO As Int32, ByVal IDINFORME As Int32) As Integer
        Try
            Dim cMNAI As New cMOTIVOSNOACEPTACIONINFORME
            cMNAI.EliminarMOTIVOSNOACEPTACIONINFORME(IDESTABLECIMIENTO, IDINFORME)

            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDINFORME = IDINFORME
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerFechasRemision(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal numeroinforme As String = "", Optional ByVal idtipoinfome As Integer = 0, Optional ByVal resultadoinspeccion As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerFechasRemision(IDESTABLECIMIENTO, numeroinforme, idtipoinfome, resultadoinspeccion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFechasRemision2(ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.ObtenerFechasRemision2(IDESTABLECIMIENTOCONTRATO, IDPROCESOCOMPRA, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarFechasRemision(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal FECHAREMISION As Date) As Integer
        Try
            Return mDb.ActualizarFechasRemision(IDESTABLECIMIENTO, IDINFORME, FECHAREMISION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarFechaNotiProv(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal FECHANOTIPROV As Date) As Integer
        Try
            Return mDb.ActualizarFechaNotiProv(IDESTABLECIMIENTO, IDINFORME, FECHANOTIPROV)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function RecuperarProveedores() As DataSet
        Try
            Return mDb.RecuperarProveedores()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarcONTRATOS() As DataSet
        Try
            Return mDb.RecuperarContratos()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarCompras() As DataSet
        Try
            Return mDb.RecuperarCompras()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarLotes() As DataSet
        Try
            Return mDb.RecuperarLotes()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarProducto() As DataSet
        Try
            Return mDb.RecuperarProducto()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ConsultaInformes(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal ORIGENPRODUCTO As Int16 = 2, Optional ByVal TIPOPRODUCTO As Int16 = 3, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal IDCONTRATO As String = "", Optional ByVal NUMEROMODALIDADCOMPRA As String = "", Optional ByVal IDTIPOINFORME As Int16 = 0, Optional ByVal LOTE As String = "", Optional ByVal NOMBREMEDICAMENTO As String = "", Optional ByVal RESULTADOINSPECCION As Int16 = 0) As DataSet
        Try
            Return mDb.ConsultaInformes(IDESTABLECIMIENTO, ORIGENPRODUCTO, TIPOPRODUCTO, IDPROVEEDOR, IDCONTRATO, NUMEROMODALIDADCOMPRA, IDTIPOINFORME, LOTE, NOMBREMEDICAMENTO, RESULTADOINSPECCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerLotesNotificados(ByVal idestablecimiento As Integer, ByVal idproveedor As Integer, ByVal renglon As Integer, ByVal idprocesocompra As Integer, Optional ByVal idcontrato As Integer = 0, Optional ByVal idinspector As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerLotesNotificados(idestablecimiento, idproveedor, renglon, idprocesocompra, idcontrato, idinspector)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerLotesNotificadosXInspector(ByVal idestablecimiento As Integer, ByVal idproveedor As Integer, ByVal IDINSPECTOR As Integer, ByVal idprocesocompra As Integer, Optional ByVal idcontrato As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerLotesNotificadosXInspector(idestablecimiento, idproveedor, IDINSPECTOR, idprocesocompra, idcontrato)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerLotesNotificadosSinInspector(ByVal idestablecimiento As Integer, ByVal idproveedor As Integer, ByVal idprocesocompra As Integer, Optional ByVal idcontrato As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerLotesNotificadosSinInspector(idestablecimiento, idproveedor, idprocesocompra, idcontrato)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarInspector(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal IDINSPECTOR As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal OBSERVACIONASIGNACION As String, ByVal FECHAASIGNACION As DateTime) As Integer
        Try
            Return mDb.ActualizarInspector(IDESTABLECIMIENTO, IDINFORME, IDINSPECTOR, AUUSUARIOMODIFICACION, OBSERVACIONASIGNACION, FECHAASIGNACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerRptCuadroAsignacion(ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.ObtenerRptCuadroAsignacion(IDESTABLECIMIENTOCONTRATO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerLotesNotificadosRetiro(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDINSPECTOR As Integer, ByVal IDPROCESOCOMPRA As Integer, Optional ByVal IDCONTRATO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerLotesNotificadosRetiro(IDESTABLECIMIENTO, IDPROVEEDOR, IDINSPECTOR, IDPROCESOCOMPRA, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerRptRetiroMuestras(ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDINSPECTOR As Integer, ByVal IDPROVEEDOR As Integer, ByVal NI As Integer) As DataSet
        Try
            Return mDb.ObtenerRptRetiroMuestras(IDESTABLECIMIENTOCONTRATO, IDPROCESOCOMPRA, IDINSPECTOR, IDPROVEEDOR, NI)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerNumeroNotificacion(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As Integer
        Try
            Return mDb.ObtenerNumeroNotificacion(IDPROCESOCOMPRA, IDESTABLECIMIENTOCONTRATO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarINFORMEMUESTRASeHistorico(ByVal aEntidad As INFORMEMUESTRAS) As Integer
        Try
            mDb.Actualizar(aEntidad)

            Dim X As New dbHISTORICONOTIFICACION
            X.Agregar(aEntidad)

            Return 1
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerNotificacionesCapturadas(Optional ByVal estado As Integer = 0, Optional ByVal inspector As Integer = 0, Optional ByVal IDPROVEEDOR As Integer = 0, Optional ByVal IDCONTRATO As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerNotificacionesCapturadas(estado, inspector, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerLotesRegistroNotificacion(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTOCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal NUMERONOTIFICACION As Integer, ByVal IDESTADO As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.ObtenerLotesRegistroNotificacion(IDPROCESOCOMPRA, IDESTABLECIMIENTOCONTRATO, IDPROVEEDOR, NUMERONOTIFICACION, IDESTADO, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarEstado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal NUMNOTIFICACION As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal AUFECHAMODIFICACION As Date, ByVal ESTADO As Integer) As Integer
        Try
            Return mDb.ActualizarEstado(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, NUMNOTIFICACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION, ESTADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function BorrarAsignacionesInspectores(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal NUMERONOTIFICACION As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal AUFECHAMODIFICACION As Date) As Integer
        Try
            Return mDb.BorrarAsignacionesInspectores(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, NUMERONOTIFICACION, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerHojaCalculo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer) As DataSet
        Try
            Return mDb.ObtenerHojaCalculo(IDESTABLECIMIENTO, IDINFORME)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarEstadoInforme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal AUFECHAMODIFICACION As Date, ByVal ESTADO As Integer) As Integer
        Try
            Return mDb.ActualizarEstadoInforme(IDESTABLECIMIENTO, IDINFORME, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION, ESTADO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerNotificacionesCapturadasCoordinador(ByVal estado As Integer, ByVal inspector As Integer) As DataSet
        Try
            Return mDb.ObtenerNotificacionesCapturadasCoordinador(estado, inspector)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarInformacionCoordinador(ByVal Entidad As INFORMEMUESTRAS) As Integer
        Try
            Return mDb.ActualizarInformacionCoordinador(Entidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarObservacionAsignacionInforme(ByVal IDESTABLECIMIENTO As Integer, ByVal IDINFORME As Integer, ByVal AUUSUARIOMODIFICACION As String, ByVal AUFECHAMODIFICACION As Date, ByVal observacionasignacion As String) As Integer
        Try
            Return mDb.ActualizarObservacionAsignacionInforme(IDESTABLECIMIENTO, IDINFORME, AUUSUARIOMODIFICACION, AUFECHAMODIFICACION, observacionasignacion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarInformacionJefe(ByVal Entidad As entidadBase) As Integer
        Try
            Return mDb.ActualizarInformacionJefe(Entidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
